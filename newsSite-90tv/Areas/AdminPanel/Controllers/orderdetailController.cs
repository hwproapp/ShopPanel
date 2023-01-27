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
    public class orderdetailController : Controller
    {

        private readonly IUnitOfWork _context;


        public orderdetailController(IUnitOfWork context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {

            ViewBag.viewtitle = "جزییات سفارشات";

            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها
            int totalCount = _context.orderdetailRepositoryUW.Get(a => a.isenable).Count();
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


            var  model = _context.orderdetailRepositoryUW.Get(a => a.isenable ,  null , "Tbl_Product,Tbl_Shop,Tbl_Order").Skip(paresh).Take(10);
            return View(model);
            

        }


        public IActionResult OrderDetails(long id , string codeorder)
        {

            ViewBag.codeorder = codeorder;
            var model = _context.orderdetailRepositoryUW.Get(a => a.order_id == id,null,"Tbl_Product,Tbl_Shop,Tbl_Order");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var model = await _context.orderdetailRepositoryUW.GetAsync(a => a.Id == id);
            return View(model);
        }


        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfimed(long id)
        {
            try
            {
                var model = await _context.orderdetailRepositoryUW.GetAsync(a => a.Id == id);

                model.isenable = false;

                _context.orderdetailRepositoryUW.Update(model);
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