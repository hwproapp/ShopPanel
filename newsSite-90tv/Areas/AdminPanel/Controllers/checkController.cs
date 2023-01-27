using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models.UnitOfWork;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class checkController : Controller
    {
        private readonly IUnitOfWork _context;

        public checkController(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<IActionResult> buycheck(int page = 1)
        {
            ViewBag.viewtitle = "پیگری  خرید";

            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها

            int totalCount = await _context.buyCheckRepositoryUW.GetCountAsync(a => a.isenable);
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


            var model = await _context.buyCheckRepositoryUW.GetWithSkipAsync(a => a.isenable, null, "", paresh, 10);
            return View(model);

        }


        public async Task<IActionResult> sellcheck(int page = 1)
        {
            ViewBag.viewtitle = "پیگری  فروش";

            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها

            int totalCount = await _context.sellCheckRepositoryUW.GetCountAsync(a => a.isenable);
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


            var model = await _context.sellCheckRepositoryUW.GetWithSkipAsync(a => a.isenable, null ,"", paresh, 10);
            return View(model);

        }
    }
}