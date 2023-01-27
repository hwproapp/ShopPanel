using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class ReportProductController : Controller
    {
        private readonly IUnitOfWork _context;

        public ReportProductController(IUnitOfWork context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(int page = 1)
        {
            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها
            int totalCount = await _context.ReportProductRepositoryUW.GetCountAsync(a=>a.isenable);
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
       
            var model =await _context.ReportProductRepositoryUW.GetWithSkipAsync(a => a.isenable , a=>a.OrderByDescending(o=>o.dateMiladi), "Tbl_ReportReason,Tbl_UserApp", paresh , 10  );
            
            return View(model);
        }


        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.ReportProductRepositoryUW.GetAsync(a => a.Id == id, "Tbl_product,Tbl_UserApp");

            return PartialView(model);
        }

        public async Task<IActionResult> changestatus(int id)
        {
            try
            {
                var model = await _context.ReportProductRepositoryUW.GetByIdAsync(id);

                model.status = 1; // checked

                _context.ReportProductRepositoryUW.Update(model);

                await _context.saveAsync();


                TempData["message"] = EndPointMessage.DONE_MSG;
                TempData["type"] =EndPointMessage.DONE_TYPE;

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