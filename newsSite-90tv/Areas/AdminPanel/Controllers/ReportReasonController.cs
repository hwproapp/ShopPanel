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
    public class ReportReasonController : Controller
    {
        private readonly IUnitOfWork _context;

        public ReportReasonController(IUnitOfWork context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(int page = 1)
        {
            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها
            int totalCount =await _context.ReportReasonRepositoryUW.GetCountAsync(a => a.isenable);
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

            var model =await _context.ReportReasonRepositoryUW.GetWithSkipAsync(a => a.isenable,null , "" , paresh ,10);

            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return PartialView();
        }


        [HttpPost , ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(ReportReason reason)
        {
            if (ModelState.IsValid)
            {
                reason.isenable = true;

                _context.ReportReasonRepositoryUW.Create(reason);
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



        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.ReportReasonRepositoryUW.GetByIdAsync(id);
            return PartialView(model);
        }


        [HttpPost , ValidateAntiForgeryToken,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {

                var model = await _context.ReportReasonRepositoryUW.GetByIdAsync(id);

                model.isenable = false;
                await _context.saveAsync();


                TempData["message"] = EndPointMessage.DELETE_MSG;
                TempData["type"] = EndPointMessage.DELETE_TYPE;

            }
            catch 
            {

                TempData["message"] = EndPointMessage.Fail_MSG;
                TempData["type"] = EndPointMessage.Fail_TYPE;
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.ReportReasonRepositoryUW.GetByIdAsync(id);
            return PartialView(model);
        }


        [HttpPost, ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(ReportReason reason)
        {
            if (ModelState.IsValid)
            {
               

                _context.ReportReasonRepositoryUW.Update(reason);
                await _context.saveAsync();

                TempData["message"] = EndPointMessage.SUCCESS_Edit_MSG;
                TempData["type"] = EndPointMessage.SUCCESS_Edit_TYPE;
            }
            else
            {
                TempData["message"] = EndPointMessage.Value_MSG;
                TempData["type"] = EndPointMessage.Value_TYPE;
            }

            return RedirectToAction(nameof(Index));
        }

    }
}