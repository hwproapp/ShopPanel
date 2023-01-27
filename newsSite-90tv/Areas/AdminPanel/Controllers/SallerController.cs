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
using newsSite90tv.Models.Repository;
using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.Models.ViewModels;
using newsSite90tv.PublicClass;
using newsSite90tv.Services;
using Newtonsoft.Json;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class SallerController : Controller
    {

        private readonly IUnitOfWork _context;

        private readonly IUploadfile _uploadfile;
        private readonly UserManager<ApplicationUsers> _userManager;
        
        private readonly IsearchResult _searchResult;

        private readonly IHostingEnvironment _appEnvironment;
        private readonly Ideleteimage _ideleteimage;
        
        public SallerController(IUnitOfWork context , IsearchResult searchResult ,  IUploadfile uploadfile , UserManager<ApplicationUsers> usermanager , IHostingEnvironment appEnvironment , Ideleteimage ideleteimage)
        {

            _searchResult = searchResult;

            _context = context;
            _uploadfile = uploadfile;
            _userManager = usermanager;
            _appEnvironment = appEnvironment;
            _ideleteimage = ideleteimage;
        }


        public IActionResult Index(int page=1)
        {
            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها
            int totalCount = _context.salsmanRepositoryUW.Get(a=>a.isEnable).Count();
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


            var model = _context.salsmanRepositoryUW.Get(a=>a.isEnable , a=>a.OrderByDescending(b=> b.status == 0 ), "Tbl_Userapp").Skip(paresh).Take(10);


            ViewBag.viewtitle = "لیست فروشدگان";
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var mymodel = new sellerDetailViewModel();
         
            mymodel.bankinfo = _context.sellerBankRepositoryUW.Get(a => a.seller_id == id);

            mymodel.seller = await _context.salsmanRepositoryUW.GetAsync(a=> a.Id == id  , "Tbl_Userapp");
        
            
            return View(mymodel);

        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.viewtitle = "فرم ایجاد فروشندگان";
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserApp userApp, string imagename = "")
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var userphoneexist = await _context.userappRepositoryUW.GetAsync(a => a.mobile == userApp.mobile);

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
                        userApp.type = 1;

                        _context.userappRepositoryUW.Create(userApp);
                        await _context.saveAsync();


                        // create seller
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


                        ViewBag.message = EndPointMessage.SUCCESS_MSG;
                        ViewBag.type = EndPointMessage.SUCCESS_TYPE;
                    }
                    else
                    {
                        ViewBag.message = EndPointMessage.USER_PHONE_REAPETS;
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

            ViewBag.viewtitle = "فرم ایجاد فروشندگان";
            return View(userApp);
        }




        public IActionResult Edit(long id)
        {
            ViewBag.viewtitle = "فرم ویرایش فروشندگان";
            var model = _context.userappRepositoryUW.GetById(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserApp user, string imagename)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    if (!string.IsNullOrEmpty(imagename))
                    {
                        var oldimage = user.image;

                       await   _ideleteimage.DeleteImageHost(oldimage, "upload\\userAppimage\\normalimage\\", "\\upload\\userAppimage\\thumbnailimage\\");

                        user.image = imagename;
                    }


                    _context.userappRepositoryUW.Update(user);
                    await _context.saveAsync();

                    
            
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

            ViewBag.viewtitle = "فرم ویرایش فروشندگان";
            return View(user);
        }

        

        [HttpPost]

        public IActionResult findSeller(string q)
        {
            var model = _context.salsmanRepositoryUW.Get(a => a.Tbl_Userapp.firstName.Contains(q) || a.Tbl_Userapp.lastName.Contains(q) || a.Tbl_Userapp.phone.Contains(q) && a.isEnable && a.status == 1);
        
            return Content(JsonConvert.SerializeObject(model));
        }



        public async Task<IActionResult> changeStatus(long id , byte state =2)
        {
            var seller =await _context.salsmanRepositoryUW.GetByIdAsync(id);
            
            seller.status = state;

            _context.salsmanRepositoryUW.Update(seller);
            await _context.saveAsync();


            return RedirectToAction(nameof(Index));


        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            var model = _context.salsmanRepositoryUW.Get(a=>a.Id == id ,  null , "Tbl_Userapp").FirstOrDefault();
            return PartialView(model);
        }

        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfimed(long id)
        {

            try
            {

                var salsman = await _context.salsmanRepositoryUW.GetByIdAsync(id);

                salsman.isEnable = false;

                await _context.saveAsync();

              //  _ideleteimage.DeleteImageHost(appuser.image, "upload\\userAppimage\\normalimage\\", "\\upload\\userAppimage\\thumbnailimage\\");

                TempData["message"] = EndPointMessage.DELETE_MSG;
                TempData["type"] = EndPointMessage.DELETE_TYPE;


            }
            catch (Exception)
            {

                TempData["message"] = EndPointMessage.Fail_MSG;
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

            var sres = _searchResult.SearchResSeller(order, q, page, Convert.ToByte(pagingTake.ten));

            var model = (IEnumerable<Salsman>)sres["sellers"];
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