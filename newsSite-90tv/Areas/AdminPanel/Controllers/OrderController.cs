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
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _context;
        
        public OrderController(IUnitOfWork context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1 , int q = 2)
        {
            ViewBag.viewtitle = " سفارشات";


            IEnumerable<Order> model = null;

            int paresh = (page - 1) * 10;
              //تعداد کل ردیف ها

            if (q != 2)
            {
              
              
                int totalCount = _context.OrderRepositoryUW.Get(a => a.isEnable && a.isfinish == Convert.ToBoolean(q)).Count();
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


                model = _context.OrderRepositoryUW.Get(a => a.isEnable && a.isfinish == Convert.ToBoolean(q)).Skip(paresh).Take(10);

                
            }
            else if (q == 2)
            {
               
                //تعداد کل ردیف ها
                int totalCount = _context.OrderRepositoryUW.Get(a => a.isEnable ).Count();
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


                model = _context.OrderRepositoryUW.Get(a => a.isEnable).Skip(paresh).Take(10);

               
            }

            ViewBag.q = q;
            return View(model);




        }


        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var model =await _context.OrderRepositoryUW.GetAsync(a=>a.Id == id , "Tbl_UserApp");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var model = await _context.OrderRepositoryUW.GetAsync(a => a.Id == id);
            return View(model);
        }


        [ActionName("Delete")]
        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfimed(long id)
        {
            try
            {
                var model = await _context.OrderRepositoryUW.GetAsync(a => a.Id == id);

                model.isEnable = false;

                _context.OrderRepositoryUW.Update(model);
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