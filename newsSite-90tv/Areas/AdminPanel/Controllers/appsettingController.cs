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
    public class appsettingController : Controller
    {
        private readonly IUnitOfWork _context;

        public appsettingController(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            ViewBag.viewtitle = "تنظیمات اپلیکیشن";

            var model = await _context.AppsettingRepositoryUW.GetSingleAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.viewtitle = "تنظیمات جدید";
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(Appsetting model)
        {
            try
            {
               

                _context.AppsettingRepositoryUW.Create(model);
                await _context.saveAsync();

                ViewBag.message = EndPointMessage.SUCCESS_MSG;
                ViewBag.type = EndPointMessage.SUCCESS_TYPE;
            }
            catch (Exception)
            {

                ViewBag.message = EndPointMessage.Fail_MSG;
                ViewBag.type = EndPointMessage.Fail_TYPE;
            }

            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.viewtitle = "ویرایش تنظیمات";

            var model =await _context.AppsettingRepositoryUW.GetByIdAsync(id);
            return View(model);
        } 


        [HttpPost]
        public async Task<IActionResult> Edit(Appsetting model)
        {
            try
            {
             

                _context.AppsettingRepositoryUW.Update(model);
                await _context.saveAsync();

                ViewBag.message = EndPointMessage.SUCCESS_Edit_MSG;
                ViewBag.type = EndPointMessage.SUCCESS_Edit_TYPE;
            }
            catch (Exception)
            {

                ViewBag.message = EndPointMessage.Fail_MSG;
                ViewBag.type = EndPointMessage.Fail_TYPE;
            }

            return View(model);
        }





        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.AppsettingRepositoryUW.GetByIdAsync(id);

            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfimed(int id)
        {
            try
            {
                 _context.AppsettingRepositoryUW.DeleteById(id);
               
               // _context.AppsettingRepositoryUW.Update(model);
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