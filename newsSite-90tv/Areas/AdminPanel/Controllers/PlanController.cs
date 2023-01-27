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
    public class PlanController : Controller
    {
        private readonly IUnitOfWork _context;

        public PlanController(IUnitOfWork context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {
            ViewBag.viewtitle = "لیست پلن ها";

            //paging 
            int paresh = (page - 1) * 10;

            int totalCount = _context.planRepositoryUW.Get(a => a.isEnable).Count();
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


            var model = _context.planRepositoryUW.Get(a => a.isEnable).Skip(paresh).Take(10);
            
            return View(model);
        }


        public IActionResult Create()
        {
            ViewBag.viewtitle = "ایجاد پلن";
            return View();
        }



        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Plan plan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    plan.isEnable = true;
                    plan.dateMiladi = DateTime.Now;
                    plan.dateShamsi = DateAndTimeShamsi.DateTimeShamsi();

                    _context.planRepositoryUW.Create(plan);
                    await _context.saveAsync();


                    ViewBag.message = EndPointMessage.SUCCESS_MSG;
                    ViewBag.type = EndPointMessage.SUCCESS_TYPE;
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
                ViewBag.type = EndPointMessage.Value_TYPE;
            }

            ViewBag.viewtitle = "ایجاد پلن";
            return View(plan);
        }





        public IActionResult Edit(int id)
        {

            ViewBag.viewtitle = "ویراش پلن";
            var model = _context.planRepositoryUW.GetById(id);
            return View(model);
        }



        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Plan plan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   

                    _context.planRepositoryUW.Update(plan);
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
                ViewBag.type = EndPointMessage.Value_TYPE;
            }


            ViewBag.viewtitle = "ویراش پلن";
            return View(plan);
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.viewtitle = "حذف پلن";

            var model = _context.planRepositoryUW.GetById(id);
            return View(model: model);
        }

        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfimed(int id)
        {

            try
            {
                

                var plan = await _context.planRepositoryUW.GetByIdAsync(id);

                plan.isEnable = false;
                
                _context.planRepositoryUW.Update(plan);
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


        public IActionResult Details(int id)
        {
            var model = _context.planRepositoryUW.GetById(id);
            return View(model);
        }

    }
}