using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class appversionController : Controller
    {
        private readonly IUnitOfWork _context;

        public appversionController(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.viewtitle = "تنظیمات ورژن اپلیکیشن";

            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها
            int totalCount = await _context.AppversionRepositoryUW.GetCountAsync(a => a.isEnable);

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

            var model = await _context.AppversionRepositoryUW.GetWithSkipAsync(a => a.isEnable, a => a.OrderByDescending(b => b.status == 1), "", paresh, 10);
            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.AppversionRepositoryUW.GetByIdAsync(id);
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.viewtitle = "افرودن تنظیمات ورژن";
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appversion appversion)
        {
            ViewBag.viewtitle = "افرودن تنظیمات ورژن";
            try
            {
                if (ModelState.IsValid)
                {

                    // get last version added
                    var lastversion = await _context.AppversionRepositoryUW.GetLastEntityAsync(a => a.isEnable && a.status == 1);

                    if (lastversion != null)
                    {
                        // get last version code to make new version code 
                        appversion.versionCode = lastversion.versionCode + 1;  // ie => 2

                        // last version is old version and set is off
                        lastversion.status = 0;
                    }
                    else
                    {
                        // defualt version code first time app builded
                        appversion.versionCode = 1;
                    }


                    appversion.isEnable = true;
                    appversion.status = 1;


                    _context.AppversionRepositoryUW.Create(appversion);
                    await _context.saveAsync();


                    ViewBag.message = EndPointMessage.SUCCESS_MSG;
                    ViewBag.type = EndPointMessage.SUCCESS_TYPE;
                }
                else
                {
                    ViewBag.message = EndPointMessage.Value_MSG;
                    ViewBag.type = EndPointMessage.Value_TYPE;

                }
            }
            catch (Exception)
            {

                ViewBag.message = EndPointMessage.Fail_MSG;
                ViewBag.type = EndPointMessage.Fail_TYPE;
            }

            return View(appversion);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.viewtitle = "ویرایش تنظیمات ورژن";
            var model = await _context.AppversionRepositoryUW.GetByIdAsync(id);
            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Appversion appversion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.AppversionRepositoryUW.Update(appversion);
                    await _context.saveAsync();


                    ViewBag.message = EndPointMessage.SUCCESS_Edit_MSG;
                    ViewBag.type = EndPointMessage.SUCCESS_Edit_TYPE;
                }
                else
                {
                    ViewBag.message = EndPointMessage.Value_MSG;
                    ViewBag.type = EndPointMessage.Value_TYPE;
                }
            }
            catch (Exception)
            {

                ViewBag.message = EndPointMessage.Fail_MSG;
                ViewBag.type = EndPointMessage.Fail_TYPE;
            }

            return View(appversion);

        }




        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.AppversionRepositoryUW.GetByIdAsync(id);
            return View(model);
        }


        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfimed(int id)
        {
            try
            {
                var model = await _context.AppversionRepositoryUW.GetByIdAsync(id);
                

               
                model.isEnable = false;
                model.status = 0;


                _context.AppversionRepositoryUW.Update(model);


                await _context.saveAsync();


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





    }
}