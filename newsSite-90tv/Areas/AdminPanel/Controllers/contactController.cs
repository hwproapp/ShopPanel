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
    public class contactController : Controller
    {
        private readonly IUnitOfWork _context;


        public contactController(IUnitOfWork context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.viewtitle = "ارتباط با ما";

            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها
            int totalCount = await _context.ContactRepositoryUW.GetCountAsync(a => a.isenable);
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


            var model = await _context.ContactRepositoryUW.GetWithSkipAsync(a => a.isenable, a => a.OrderByDescending(b => b.status == contactstate.unread.ToByte()), "Tbl_UserApp", paresh, 10);

            return View(model);
        }


        public async Task<IActionResult> setRead(int id)
        {
            try
            {
                var model = await _context.ContactRepositoryUW.GetByIdAsync(id);

                model.status = contactstate.read.ToByte();

                _context.ContactRepositoryUW.Update(model);

                await _context.saveAsync();


                TempData["message"] = EndPointMessage.DONE_MSG;
                TempData["type"] = EndPointMessage.DONE_TYPE;

            }
            catch (Exception)
            {
                TempData["message"] = EndPointMessage.Fail_MSG;
                TempData["type"] = EndPointMessage.Fail_TYPE;

            }

            return RedirectToAction(nameof(Index));

        }
        


        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.ContactRepositoryUW.GetAsync(a=>a.Id == id , "Tbl_UserApp" );
            return View(model);
        }
        

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.ContactRepositoryUW.GetByIdAsync(id);
            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfimed(int id)
        {
            try
            {
                var model = await _context.ContactRepositoryUW.GetByIdAsync(id);

                 model.isenable = false;

                _context.ContactRepositoryUW.Update(model);

                await _context.saveAsync();



                TempData["message"] = EndPointMessage.DELETE_MSG;
                TempData["type"] = EndPointMessage.DELETE_TYPE;

            }
            catch (Exception)
            {

                TempData["message"] = EndPointMessage.DELETE_MSG;
                TempData["type"] = EndPointMessage.DELETE_TYPE;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}