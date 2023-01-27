using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.Models.ViewModels;
using newsSite90tv.PublicClass;
using Newtonsoft.Json;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{


    [Area("AdminPanel")]
    public class propertyController : Controller
    {
        private readonly IUnitOfWork _context;

        public propertyController(IUnitOfWork context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        { 
            int paresh = (page - 1) * 10;
           
            int totalCount = _context.PropertyRepositoryUW.Get(a => a.isenable).Count();
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


            var model = _context.PropertyRepositoryUW.Get(a=>a.isenable , null , "Tbl_Part,Tbl_Category").Skip(paresh).Take(10);

            return View(model);

        }
        
       



        public IActionResult Create()
        {
            var model = new PropertyCreateViewModel();

            model.part = _context.partRepositoryUW.Get(a => a.isenable);
            model.category = _context.CategoryRepositoryUW.Get(a => a.type == categoryType.product.ToByte() && a.isenable);
            return PartialView(model);
        }


        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Property property)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    property.isenable = true;

                    _context.PropertyRepositoryUW.Create(property);
                    await _context.saveAsync();


                    TempData["message"] = EndPointMessage.SUCCESS_MSG;
                    TempData["type"] = EndPointMessage.SUCCESS_TYPE;
                }
                catch (Exception)
                {

                    TempData["message"] = EndPointMessage.Fail_MSG;
                    TempData["type"] = EndPointMessage.Fail_TYPE;
                }

              
            }
            else
            {
                TempData["message"]   = EndPointMessage.Fail_MSG;
                TempData["type"] = EndPointMessage.Fail_TYPE;
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            var model = new PropertyCreateViewModel();

            model.property = _context.PropertyRepositoryUW.GetById(id);
            model.part = _context.partRepositoryUW.Get(a => a.isenable);
            model.category = _context.CategoryRepositoryUW.Get(a => a.type == categoryType.product.ToByte() && a.isenable);

            return PartialView(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Property property)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    _context.PropertyRepositoryUW.Update(property);
                    await _context.saveAsync();


                    TempData["message"] = EndPointMessage.SUCCESS_Edit_MSG;
                    TempData["type"] = EndPointMessage.SUCCESS_Edit_TYPE;
                }
                catch (Exception)
                {

                    TempData["message"] = EndPointMessage.Fail_MSG;
                    TempData["type"] = EndPointMessage.Fail_TYPE;
                }
            }
            else
            {
                TempData["message"] = EndPointMessage.Fail_MSG;
                TempData["type"] = EndPointMessage.Fail_TYPE;
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {


            var model = _context.PropertyRepositoryUW.GetById(id);

            return PartialView(model);
        }


        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfimed(int id)
        {
            if (ModelState.IsValid)
            {


                try
                {
                    var property = _context.PropertyRepositoryUW.GetById(id);

                    property.isenable = false;

                    await _context.saveAsync();



                    TempData["message"] = EndPointMessage.DELETE_MSG;
                    TempData["type"] = EndPointMessage.DELETE_TYPE;
                }
                catch (Exception)
                {

                    TempData["message"] = EndPointMessage.Fail_MSG;
                    TempData["type"] = EndPointMessage.Fail_TYPE;
                }

            }
            else
            {
                TempData["message"] = EndPointMessage.DELETE_MSG;
                TempData["type"] = EndPointMessage.DELETE_TYPE;

            }

            return RedirectToAction(nameof(Index));
        }





        [HttpGet]
        public IEnumerable<object> GetPropertyByCategory(int catid)
        {
            var model = _context.PropertyRepositoryUW.Get(a=>a.cat_id == catid && a.isenable).Select(a=>new 
            {
                id = a.Id,
                name = a.name
            });


            return model;
        }

    }
}