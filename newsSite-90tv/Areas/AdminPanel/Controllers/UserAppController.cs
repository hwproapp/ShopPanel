using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;
using newsSite90tv.Services;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserAppController : Controller
    {

        private readonly IUnitOfWork _context;
        private readonly IUploadfile _upload;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IHostingEnvironment _hosting;
        private readonly IsearchResult _searchresult;
        private readonly Ideleteimage _ideleteimage;

        public UserAppController(IUnitOfWork context, 
            IUploadfile uploadfile 
            ,UserManager<ApplicationUsers> usermanager , 
            IHostingEnvironment hosting , IsearchResult search , Ideleteimage ideleteimage)
        {
            _context = context;
            _upload = uploadfile;
            _userManager = usermanager;
            _hosting = hosting;
            _searchresult = search;
            _ideleteimage = ideleteimage;
        }
        
        public IActionResult Index(int page = 1)
        {
            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها
            int totalCount = _context.userappRepositoryUW.Get(a=>a.isEnable).Count();
            ViewBag.PageID = page;
            double remain = totalCount % 10;

            if (remain == 0)
            {
                ViewBag.PageCount = totalCount / 10;
            }
            else
            {
                ViewBag.PageCount = (totalCount / 10) + 1;
            }


            var model = _context.userappRepositoryUW.Get(a=>a.isEnable  , a=>a.OrderByDescending(b=>b.datemiladi)).Skip(paresh).Take(10);

            ViewBag.viewtitle = "کاربران   اپلیکیشن";

            return View(model);
        }


        [HttpGet]
        public IActionResult Details(long id)
        {
            var users = _context.userappRepositoryUW.GetById(id);
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.viewtitle = "فرم ایجاد کاربران اپلیکیشن";
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserApp userApp, string imagename="")
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    var userphoneexist = await _context.userappRepositoryUW.GetAsync(a =>a.mobile == userApp.mobile);

                    if (userphoneexist == null)
                    {
                        userApp.image = imagename;
                        userApp.datemiladi = DateTime.Now;
                        userApp.dateshamsi = DateAndTimeShamsi.DateTimeShamsi();
                        userApp.mobileActiveStatus = false;
                        userApp.token = "";
                        userApp.User_id = _userManager.GetUserId(User);
                        userApp.mobileActiveCode = "";
                        userApp.isEnable = true;

                        _context.userappRepositoryUW.Create(userApp);
                        await _context.saveAsync();


                        if (userApp.type == 1) // seller type
                        {
                            Salsman salsman = new Salsman
                            {
                                appuser_id = userApp.Id,
                                dateMiladi = DateTime.Now,
                                dateShamsi = DateAndTimeShamsi.DateTimeShamsi(),
                                isEnable = true,
                                status = 1, // valid
                                user_id = _userManager.GetUserId(User)
                            };


                            _context.salsmanRepositoryUW.Create(salsman);
                            await _context.saveAsync();

                        }


                        ViewBag.message = EndPointMessage.SUCCESS_MSG;
                        ViewBag.type = EndPointMessage.SUCCESS_TYPE;
                    }
                    else
                    {
                        ViewBag.message =EndPointMessage.USER_PHONE_REAPETS;
                        ViewBag.type = EndPointMessage.USER_PHONE_REAPETS_TYPE;
                    }

                    
                }
                catch
                {

                    ViewBag.message = EndPointMessage.Fail_MSG;
                    ViewBag.type = EndPointMessage.Fail_TYPE;
                }

            }
            else
            {
                ViewBag.message = EndPointMessage.Value_MSG;
                ViewBag.type = EndPointMessage.Value_MSG;
            }

            ViewBag.viewtitle = "فرم ایجاد کاربران اپلیکیشن";
            return View(userApp);
        }

       


        public IActionResult Edit(long id)
        {
            ViewBag.viewtitle = "فرم ویرایش کاربران اپلیکیشن";
            var model = _context.userappRepositoryUW.GetById(id);
            return View(model);
        }
        
        [HttpPost , ValidateAntiForgeryToken]
        public  async Task<IActionResult> Edit(UserApp user  , string imagename)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    //var userphoneexist = await _context.userappRepositoryUW.GetAsync(a => a.mobile == user.mobile);

                    //if (userphoneexist == null)
                    //{
                        

                    //}
                    //else
                    //{
                    //    ViewBag.message = EndPointMessage.USER_PHONE_REAPETS;
                    //    ViewBag.type = EndPointMessage.USER_PHONE_REAPETS_TYPE;
                    //}


                    if (!string.IsNullOrEmpty(imagename))
                    {
                        var oldimage = user.image;

                        await _ideleteimage.DeleteImageHost(oldimage, "upload\\userAppimage\\normalimage\\", "\\upload\\userAppimage\\thumbnailimage\\");

                        user.image = imagename;
                    }


                    _context.userappRepositoryUW.Update(user);
                    await _context.saveAsync();



                    var exist = await _context.salsmanRepositoryUW.GetAsync(a => a.appuser_id == user.Id);
                    if (user.type == 1 && exist == null) // seller type
                    {
                        Salsman salsman = new Salsman
                        {
                            appuser_id = user.Id,
                            dateMiladi = DateTime.Now,
                            dateShamsi = DateAndTimeShamsi.DateTimeShamsi(),
                            isEnable = true,
                            status = 1, // valid
                            user_id = _userManager.GetUserId(User)
                        };


                        _context.salsmanRepositoryUW.Create(salsman);
                        await _context.saveAsync();


                    }

                    ViewBag.message = EndPointMessage.SUCCESS_Edit_MSG;
                    ViewBag.type = EndPointMessage.SUCCESS_Edit_TYPE;



                }
                catch (Exception)
                {

                    ViewBag.message = EndPointMessage.Fail_MSG;
                    ViewBag.type = EndPointMessage.Fail_TYPE;
                }        
            }
            else
            {
                ViewBag.message = EndPointMessage.Value_MSG;
                ViewBag.type = EndPointMessage.Value_MSG;
            }

            ViewBag.viewtitle = "فرم ویرایش کاربران اپلیکیشن";
            return View(user);
        }








        public IActionResult UploadFile(IEnumerable<IFormFile> files)
        {
            //"upload\\userimage\\normalimage\\"
            //"\\upload\\userimage\\thumbnailimage\\"
            string filename = _upload.UploadFiles(files, "upload\\userAppimage\\normalimage\\", "\\upload\\userAppimage\\thumbnailimage\\");
            return Json(new { status = "success", message = "تصویر با موفقیت آپلود شد.", imagename = filename });

        }



        [HttpGet]
        public IActionResult Delete(long id)
        {
            var model = _context.userappRepositoryUW.GetById(id);
            return PartialView(model);
        }

        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfimed(long id)
        {

            try
            {

                var appuser =await _context.userappRepositoryUW.GetByIdAsync( id);
                appuser.isEnable = false;

                await _context.saveAsync();

                _ideleteimage.DeleteImageHost(appuser.image, "upload\\userAppimage\\normalimage\\", "\\upload\\userAppimage\\thumbnailimage\\");

                TempData["message"] = EndPointMessage.DELETE_MSG;
                TempData["type"] = EndPointMessage.DELETE_TYPE;


            }
            catch (Exception)
            {

                TempData["message"] =  EndPointMessage.Fail_MSG;
                TempData["type"] = EndPointMessage.Fail_TYPE;
            }

            return RedirectToAction(nameof(Index));
        }





        [HttpGet]
        public IActionResult searchBox()
        {
            return PartialView("_searchBox");
        }


        [HttpGet]
        public IActionResult searchResult(string q, byte order, int page = 1)
        {

            ViewBag.q = q;
            ViewBag.order = order;
            ViewBag.PageID = page;

            var sres = _searchresult.SearchResuserApp(order, q, page, Convert.ToByte(pagingTake.ten));

            var model = (IEnumerable<UserApp>)sres["userapp"];
            int totalCount = (int)sres["count"];

            double remain = totalCount % 10;

            if (remain == 0)
            {
                ViewBag.PageCount = totalCount / 10;
            }
            else
            {
                ViewBag.PageCount = (totalCount / 10) + 1;
            }



            return View(model);
        }




    }
}