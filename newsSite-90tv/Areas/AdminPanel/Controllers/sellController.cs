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
    public class sellController : Controller
    {

        private readonly IUnitOfWork _context;

        public sellController(IUnitOfWork context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, int q = 4)
        {
            ViewBag.viewtitle = "لیست  فروش";

           


            IEnumerable<Sell> model = null;

            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها

            if (q == 4)
            {
                int totalCount = _context.sellRepositoryUW.Get(a => a.isenable).Count();
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


                model = _context.sellRepositoryUW.Get(a => a.isenable, null, "Tbl_Product,Tbl_Shop,Tbl_Salsman").Skip(paresh).Take(10);


            }
            else
            {
                int totalCount = _context.sellRepositoryUW.Get(a => a.isenable && a.sellstatus == q).Count();
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


                model = _context.sellRepositoryUW.Get(a => a.isenable && a.sellstatus == q, null, "Tbl_Product,Tbl_Shop,Tbl_Salsman").Skip(paresh).Take(10);

            }

            ViewBag.q = q;
            return View(model);

        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        { 
            var model = await _context.sellRepositoryUW.GetAsync(a=>a.Id == id , "Tbl_Product,Tbl_Shop,Tbl_Salsman");
            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _context.sellRepositoryUW.GetById(id);
            return View(model: model);
        }

        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfimed(int id)
        {

            try
            {


                var sell = await _context.sellRepositoryUW.GetByIdAsync(id);

                sell.isenable = false;

                _context.sellRepositoryUW.Update(sell);

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



        // this action get all remain sell of seller whi give fix request

        [HttpGet]
        public async Task<IActionResult> SellerSellNotFix(long id  ,int page = 1)
        {

           
            ViewBag.viewtitle = "فروش  های تسویه نشده فروشنده";
            
            int totalCount = _context.sellRepositoryUW.Get(a => a.seller_id == id && a.isenable   && a.sellstatus == 2).Count();
            ViewBag.PageID = page;
            ViewBag.SellerID = id;
            double remain = totalCount % 10;

            if (remain == 0)
            {
                ViewBag.PageCount = totalCount / 10;
            }
            else
            {
                ViewBag.PageCount = (totalCount / 10) + 1;
            }


            var model = await _context.sellRepositoryUW.GetAsync(a => a.seller_id == id && a.isenable   &&  a.sellstatus == 2, null, "Tbl_Product,Tbl_Shop,Tbl_Salsman");

            return View(model);
        }
    }
}