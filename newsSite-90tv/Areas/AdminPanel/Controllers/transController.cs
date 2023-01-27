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
    public class transController : Controller
    {
        private readonly IUnitOfWork _context;

        public transController(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int paresh = (page - 1) * 10;

            int totalCount =await _context.paymentRepositoryUW.GetCountAsync(a => a.isenable);
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



            var model =await _context.paymentRepositoryUW.GetWithSkipAsync(a => a.isenable, null, "Tbl_UserApp", paresh, 10);

            ViewBag.viewtitle = "تراکنش ها";
            return View(model);
        }



        public async Task<IActionResult> Details(long id)
        {
            var model =await _context.paymentRepositoryUW.GetAsync(a => a.Id == id, "Tbl_UserApp");
            return View(model);
        }


        public async Task<IActionResult> Delete(long id)
        {
            var model = await _context.paymentRepositoryUW.GetAsync(a => a.Id == id);
            return PartialView(model);
        }


        [HttpPost , ValidateAntiForgeryToken , ActionName("Delete")]
        public async Task<IActionResult> DeleteConfimed(long id)
        {
           
            try
            {
                var model = await _context.paymentRepositoryUW.GetAsync(a => a.Id == id);

                model.isenable = false;

                _context.paymentRepositoryUW.Update(model);
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