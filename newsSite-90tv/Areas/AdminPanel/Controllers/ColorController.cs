using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;
using Newtonsoft.Json;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ColorController : Controller
    {
        private readonly IUnitOfWork _context;

        public ColorController(IUnitOfWork context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var mdoel = _context.colorRepositoryUW.Get(a => a.isenable);
            return View(mdoel);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost , ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Color color)
        {
            if (ModelState.IsValid)
            {


                color.isenable = true;

                _context.colorRepositoryUW.Create(color);
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



        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _context.colorRepositoryUW.GetByIdAsync(id);
            return PartialView(brand);
        }


        [HttpPost, ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Color color)
        {
            if (ModelState.IsValid)
            {


              

                _context.colorRepositoryUW.Create(color);
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
            var brand = await _context.colorRepositoryUW.GetByIdAsync(id);
            return PartialView(brand);
        }


        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var color = await _context.colorRepositoryUW.GetByIdAsync(id);

                color.isenable = false;


                _context.colorRepositoryUW.Update(color);
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