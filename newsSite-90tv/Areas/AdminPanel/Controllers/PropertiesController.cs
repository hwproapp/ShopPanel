using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.Models.ViewModels;
using newsSite90tv.PublicClass;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class PropertiesController : Controller
    {
        private readonly IUnitOfWork _context;

        public PropertiesController(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page =1)
        {
          
            int paresh = (page - 1) * 10;
            int totalCount = await _context.PropertiesRepositoryUW.GetCountAsync(a => a.isEnable);
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
            var model = await _context.PropertiesRepositoryUW.GetWithSkipAsync(a => a.isEnable , null , "Tbl_Category", paresh, 10);
            return View(model);
        }

        [HttpGet]

        public async Task<IActionResult> Create()
        {
            var model = new PropertiesCreateViewModel();

            model.categories = await _context.CategoryRepositoryUW.GetManyAsync(a => a.isenable && a.type == categoryType.product.ToByte());
            model.properties = new Properties();

            return PartialView(model);
        }


        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Properties properties)
        {
            try
            {
                 properties.isEnable = true;

                _context.PropertiesRepositoryUW.Create(properties);

                 await _context.saveAsync();


                TempData["message"] =EndPointMessage.SUCCESS_MSG;
                TempData["type"] = EndPointMessage.SUCCESS_TYPE;


            }
            catch (Exception)
            {
                TempData["message"] = EndPointMessage.Fail_MSG;
                TempData["type"] = EndPointMessage.Fail_TYPE;
            }

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Edit(int id)
        {
            var model = new PropertiesCreateViewModel();

            model.categories = await _context.CategoryRepositoryUW.GetManyAsync(a => a.isenable && a.type == categoryType.product.ToByte());

            model.properties =await _context.PropertiesRepositoryUW.GetByIdAsync(id);

            return PartialView(model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Properties properties)
        {
            try
            {
               
                _context.PropertiesRepositoryUW.Update(properties);

                await _context.saveAsync();


                TempData["message"] = EndPointMessage.SUCCESS_Edit_MSG;
                TempData["type"] = EndPointMessage.SUCCESS_Edit_TYPE;


            }
            catch (Exception)
            {
                TempData["message"] = EndPointMessage.Fail_MSG;
                TempData["type"] = EndPointMessage.Fail_TYPE;
            }

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Delete(int id)
        {

            var  model = await _context.PropertiesRepositoryUW.GetByIdAsync(id);

            return PartialView(model);
        }


        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {

                var model = await _context.PropertiesRepositoryUW.GetByIdAsync(id);

                model.isEnable = false;

                _context.PropertiesRepositoryUW.Update(model);

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