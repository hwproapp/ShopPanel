using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models.UnitOfWork;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ReportShopController : Controller
    {
        private readonly IUnitOfWork _context;

        public ReportShopController(IUnitOfWork context)
        {
            _context = context;
        }


        public IActionResult Index(int page = 1)
        {
            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها
            int totalCount = _context.ReportShopRepositoryUW.Get(a => a.isenable && a.status == 0).Count();
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

            var model = _context.ReportShopRepositoryUW.Get(a => a.isenable && a.status == 0, a => a.OrderByDescending(o => o.dateMiladi), "Tbl_Reason,Tbl_UserApp").Skip(paresh).Take(10);

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.ReportShopRepositoryUW.GetAsync(a => a.Id == id, "Tbl_Shop,Tbl_UserApp");

            return PartialView(model);
        }
    }
}