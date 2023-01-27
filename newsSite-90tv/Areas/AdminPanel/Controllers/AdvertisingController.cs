using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.Models.ViewModels;
using newsSite90tv.PublicClass;
using newsSite90tv.Services;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    // [Authorize(Roles = "Advertise")]
    public class AdvertisingController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IUploadfile _upload;
        private readonly UserManager<ApplicationUsers> _usermanager;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly IsearchResult _searchresult;
        private readonly Ideleteimage _ideleteimage;

        public AdvertisingController(IUnitOfWork context, IUploadfile upload, UserManager<ApplicationUsers> usermanager,
            IHostingEnvironment webroot , IsearchResult searchresult , Ideleteimage ideleteimage)
        {
            _context = context;
            _upload = upload;
            _usermanager = usermanager;
            _appEnvironment = webroot;
            _searchresult = searchresult;
            _ideleteimage = ideleteimage;
        }


       

        public IActionResult Index(int page = 1)
        {
            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها
            int totalCount = _context.AdvertisRepositoryUW.Get(a=> a.isenable).Count();
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


            var model = _context.AdvertisRepositoryUW.Get(a=>a.isenable , a=>a.OrderByDescending(b=>b.status == 0)).Skip(paresh).Take(10);
           
            return View(model);
        }




        [HttpGet]

        public IActionResult Create()
        {
            var model = new AdvertizeCreateViewModel();


            model.shops = _context.shopRepositoryUW.Get(a=> a.enable && a.status == 1);

            return View(model);
        }



        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(shopadvertise adv , string imagename="")
        {

            if (ModelState.IsValid)
            {
               
                try
                {
                    adv.image = imagename;
                    adv.status =(byte) Status.suspend;
                    adv.users_id = _usermanager.GetUserId(User);
                    adv.isenable = true;

                    if (!string.IsNullOrEmpty(adv.fromdateshamsi) && !string.IsNullOrEmpty(adv.todateshamsi))
                    {
                        adv.fromdatemiladi = adv.fromdateshamsi.shamsitoMiladi();
                        adv.todatemiladi = adv.todateshamsi.shamsitoMiladi();
                    }


                    _context.AdvertisRepositoryUW.Create(adv);
                    await _context.saveAsync();

                    ViewBag.message = EndPointMessage.SUCCESS_MSG;
                    ViewBag.alerttype = EndPointMessage.SUCCESS_TYPE;
                   
                }
                catch 
                {
                    ViewBag.message = EndPointMessage.Fail_MSG;
                    ViewBag.alerttype = EndPointMessage.Fail_TYPE;

                }

            }
            else
            {
                ViewBag.message = EndPointMessage.Value_MSG;
                ViewBag.alerttype = EndPointMessage.Value_TYPE;
            }


            var model = new AdvertizeCreateViewModel();

            model.shops = _context.shopRepositoryUW.Get(a=> a.enable && a.status == 1 );
            model.adv = adv;
            return View(model);
        }




        public IActionResult Edit(long id)
        {
            var model = new AdvertizeCreateViewModel();
            model.adv = _context.AdvertisRepositoryUW.GetById(id);
            model.shops = _context.shopRepositoryUW.Get(a => a.enable && a.status == 1);

           
            return View(model);
        }


        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(shopadvertise adv, string imagename)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(imagename))
                    {
                        var upload = Path.Combine(_appEnvironment.WebRootPath, "upload\\advImage\\");
                        var old = adv.image;
                        if (System.IO.File.Exists(upload + old))
                        {
                            System.IO.File.Delete(upload + old);
                        }
                        
                        adv.image = imagename;

                    }


                    adv.fromdatemiladi = adv.fromdateshamsi.shamsitoMiladi();
                    adv.todatemiladi = adv.todateshamsi.shamsitoMiladi();


                    _context.AdvertisRepositoryUW.Update(adv);
                    await _context.saveAsync();


                    ViewBag.message = EndPointMessage.SUCCESS_Edit_MSG;
                    ViewBag.alerttype = EndPointMessage.SUCCESS_Edit_TYPE;
                }
                catch (Exception ex)
                {
                    ViewBag.message = EndPointMessage.Fail_MSG;
                    ViewBag.alerttype = EndPointMessage.Fail_TYPE;

                }


            }
            else
            {
                ViewBag.message = EndPointMessage.Value_MSG;
                ViewBag.alerttype = EndPointMessage.Value_TYPE;
            }

            var model = new AdvertizeCreateViewModel();

            model.adv = adv;
            model.shops = _context.shopRepositoryUW.Get(a => a.enable && a.status == 1 );

            return View(model);
        }



        public async Task<IActionResult> Details(long id)
        {
            var model = await _context.AdvertisRepositoryUW.GetByIdAsync(id);
            return PartialView("_Details", model);
        }



        public async Task<IActionResult> Delete(long id)
        {
            var model = await _context.AdvertisRepositoryUW.GetByIdAsync(id);
            return PartialView("_Delete", model);
        }

        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfimed(long id)
        {
            
            try
            {
                var model = await _context.AdvertisRepositoryUW.GetByIdAsync(id);

                _context.AdvertisRepositoryUW.Delete(model);
                await _context.saveAsync();


                await  _ideleteimage.DeleteImageHost(model.image, "upload\\advImage\\");
                

                ViewBag.message = "حذف موفقیت آمیز بود";
                ViewBag.alerttype = "success";


            }
            catch (Exception)
            {

                ViewBag.message = "در اجرای عملیات خطایی رخ داده است";
                ViewBag.alerttype = "success";
            }

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> changeStatus(long id, byte state = 2)
        {
            var shopadv = await _context.AdvertisRepositoryUW.GetByIdAsync(id);

            shopadv.status = state;

            _context.AdvertisRepositoryUW.Update(shopadv);
            await _context.saveAsync();


            return RedirectToAction(nameof(Index));


        }






        [HttpGet]
        public IActionResult searchBox()
        {
            return PartialView("_searchBox");
        }

        [HttpGet]
        public IActionResult searchResult(string q, int page = 1)
        {

            ViewBag.q = q;
            ViewBag.PageID = page;

            var sres = _searchresult.SearchResadv(q, page, Convert.ToByte(pagingTake.ten));

            var model = (IEnumerable<shopadvertise>)sres["adv"];
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



        public IActionResult UploadFile(IEnumerable<IFormFile> files)
        {
            string filename = _upload.UploadFiles(files, "upload\\advImage\\", "");
            return Json(new { status = "success", message = "تصویر با موفقیت آپلود شد.", imagename = filename });
        }

    }
}