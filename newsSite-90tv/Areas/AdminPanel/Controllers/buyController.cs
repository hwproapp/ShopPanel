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
    public class buyController : Controller
    {

        private readonly IUnitOfWork _context;


        public buyController(IUnitOfWork context)
        {
            _context = context;
        }
        public IActionResult Index(int page =1 , int q = 4)
        {
            ViewBag.viewtitle = "لیست  خرید";


            IEnumerable<Buy> model = null;

            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها

            if (q == 4)
            {
                int totalCount = _context.buyRepositoryUW.Get(a => a.isenable).Count();
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


                model = _context.buyRepositoryUW.Get(a => a.isenable, null, "Tbl_Product,Tbl_Shop").Skip(paresh).Take(10);
               

            }
            else
            {
                int totalCount = _context.buyRepositoryUW.Get(a => a.isenable && a.buystatus == q).Count();
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


                 model = _context.buyRepositoryUW.Get(a => a.isenable && a.buystatus == q, null, "Tbl_Product,Tbl_Shop").Skip(paresh).Take(10);
              
            }

            ViewBag.q = q;
            return View(model);

        }


        

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        { 
            var model =await _context.buyRepositoryUW.GetAsync(a=> a.Id == id , "Tbl_Product,Tbl_Shop,Tbl_UserApp");
            return View(model);
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _context.buyRepositoryUW.GetById(id);
            return View(model: model);
        }

        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfimed(int id)
        {

            try
            {
                

                var buy = await _context.buyRepositoryUW.GetByIdAsync(id);

                buy.isenable = false;

                _context.buyRepositoryUW.Update(buy);

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