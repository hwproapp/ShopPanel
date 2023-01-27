using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using newsSite90tv.Models;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.Models.ViewModels;
using newsSite90tv.PublicClass;
using Newtonsoft.Json;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class propertypartController : Controller
    {
        private readonly IUnitOfWork _context;

        public propertypartController(IUnitOfWork context)
        {
            _context = context;
        }


        public IActionResult Index(int page = 1)
        {

            int paresh = (page - 1) * 10;

            int totalCount = _context.partRepositoryUW.Get(a=>a.isenable).Count();
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


            var model = _context.partRepositoryUW.Get(a => a.isenable).Skip(paresh).Take(10);
            return View(model);
        }


      


        [HttpGet]

        public IActionResult Delete(int id)
        {
            var model = _context.partRepositoryUW.GetById(id);

            return PartialView(model);
        }


        [ActionName("Delete")]
        
        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var model = _context.partRepositoryUW.GetById(id);

                    model.isenable = false;

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
            return RedirectToAction("Index");

        }




        [HttpGet]
        public IActionResult Create()
        {
            
            return PartialView();
        }


        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Part part)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    part.isenable = true;
                    _context.partRepositoryUW.Create(part);
                    var res = await _context.saveAsync();


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
                TempData["message"] = EndPointMessage.Value_MSG;
                TempData["type"] = EndPointMessage.Value_TYPE;

            }




            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model =  await    _context.partRepositoryUW.GetByIdAsync(id);
            return PartialView(model);
        }


        [HttpPost , ValidateAntiForgeryToken]

        public async  Task<IActionResult> Edit(Part part)
        {
            if (ModelState.IsValid)
            {
               


                try
                {
                    _context.partRepositoryUW.Update(part);
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
                TempData["message"] = EndPointMessage.Value_MSG;
                TempData["type"] = EndPointMessage.Value_TYPE;
            }

            return RedirectToAction(nameof(Index));
        }





        [HttpGet]
        public IActionResult CreateProp(int id)
        {
            ViewBag.partId = id;
            

            var model = new CreatePartPropertyViewModel();

            model.category = _context.CategoryRepositoryUW.Get(a => a.type == categoryType.product.ToByte() && a.isenable);
           
            return PartialView(model);
        }


        

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProp(Property property)
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
                TempData["message"] = EndPointMessage.Value_MSG;
                TempData["type"] = EndPointMessage.Value_TYPE;

            }




            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult EditProp(int id)
        {
            var model = new CreatePartPropertyViewModel();


            model.property = _context.PropertyRepositoryUW.GetById(id);

            model.category = _context.CategoryRepositoryUW.Get(a => a.type == categoryType.product.ToByte()&& a.isenable);




            return PartialView(model);
        }




        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProp(Property property)
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
                catch (Exception ex)
                {

                    TempData["message"] = EndPointMessage.Fail_MSG  + ex.Message;
                    TempData["type"] = EndPointMessage.Fail_TYPE;
                }




            }
            else
            {
                TempData["message"] = EndPointMessage.Value_MSG;
                TempData["type"] = EndPointMessage.Value_TYPE;

            }




            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult DeleteProp(int id)
        {
            

            var model = _context.PropertyRepositoryUW.GetById(id);

            return PartialView(model);
        }
        

        [ActionName("DeleteProp")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            if (ModelState.IsValid)
            {


                try
                {
                    var property = _context.PropertyRepositoryUW.GetById(id);

                    property.isenable = false;

                    await _context.saveAsync();



                    TempData["message"] = "خصوصیت مربوط با موفقیت حذف شد";
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






        public IActionResult propertyofpart(int id, int page = 1)
        {

            int paresh = (page - 1) * 10;

            int totalCount = _context.PropertyRepositoryUW.Get(a => a.isenable && a.part_id == id).Count();
            ViewBag.PageID = page;
            ViewBag.PartId = id;
            double remain = totalCount % 10;

            if (remain == 0)
            {
                ViewBag.PageCount = totalCount / 10;
            }
            else
            {
                ViewBag.PageCount = (totalCount / 10) + 1;
            }


            var model = _context.PropertyRepositoryUW.Get(a => a.isenable && a.part_id == id, null, "Tbl_Category").Skip(paresh).Take(10);

            return View(model);
        }


        [HttpPost]
        
        public IActionResult getProps(int id)
        {
            var model = _context.PropertyRepositoryUW.Get(a=>a.part_id == id);
            return Content(JsonConvert.SerializeObject(model));
        }
    }
}