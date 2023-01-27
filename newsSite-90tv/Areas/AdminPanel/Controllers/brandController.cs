using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;
using Newtonsoft.Json;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class brandController : Controller
    {
        private readonly IUnitOfWork _context;

        public brandController(IUnitOfWork context)
        {
            _context = context;
        }
        

        public IActionResult Index(int page =1)
        {
            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها
            int totalCount = _context.productBrandRepositoryUW.Get(a=>a.isenable).Count();
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


            var model = _context.productBrandRepositoryUW.Get(a => a.isenable).Skip(paresh).Take(10);
            
            return View(model);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductBrand brand)
        {
            if (ModelState.IsValid)
            {
                brand.isenable = true;

                _context.productBrandRepositoryUW.Create(brand);
                await _context.saveAsync();

                TempData["message"] = EndPointMessage.SUCCESS_MSG;
                TempData["type"] = EndPointMessage.SUCCESS_TYPE;
            }
            else
            {
                TempData["message"] = EndPointMessage.Value_MSG;
                TempData["type"] = EndPointMessage.Value_TYPE;
            }

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _context.productBrandRepositoryUW.GetByIdAsync(id);
            return View(brand);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductBrand brand)
        {
            if (ModelState.IsValid)
            {
               

                _context.productBrandRepositoryUW.Create(brand);
                await _context.saveAsync();



                TempData["message"] = EndPointMessage.SUCCESS_Edit_MSG;
                TempData["type"] = EndPointMessage.SUCCESS_TYPE;
            }
            else
            {
                TempData["message"] = EndPointMessage.Value_MSG;
                TempData["type"] = EndPointMessage.Value_TYPE;
            }

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Delete(int id)
        {
            var brand = await _context.productBrandRepositoryUW.GetByIdAsync(id);
            return PartialView(brand);
        }


        [ActionName("Delete")]
        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                 var brand = await _context.productBrandRepositoryUW.GetByIdAsync(id);

                 brand.isenable = false;


                _context.productBrandRepositoryUW.Update(brand);
                 await  _context.saveAsync();


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