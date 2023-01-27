using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.Models.ViewModels;
using newsSite90tv.PublicClass;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class PropertiesValueController : Controller
    {
        private readonly IUnitOfWork _context;

        public PropertiesValueController(IUnitOfWork context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index(int id)
        {
            //ViewBag.propertiesId = id;

            var model = new PropertiesValueCreateViewModel();

            model.properties = await _context.PropertiesRepositoryUW.GetByIdAsync(id);

            model.propertiesValues = await _context.PropertiesValueRepositoryUW.GetManyAsync(a => a.isEnable && a.properties_id == id);

            model.propertiesValue = new PropertiesValue();

            return View(model);


        }



        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertiesValue propertiesValue)
        {
            try
            {
                 propertiesValue.isEnable = true;

                _context.PropertiesValueRepositoryUW.Create(propertiesValue);

                await _context.saveAsync();
            }
            catch (Exception)
            {

                throw;
            }


            return RedirectToAction(nameof(Index),new { id = propertiesValue.properties_id });


        }


        public async Task<IActionResult> Edit(int id)
        {

            var model = await _context.PropertiesValueRepositoryUW.GetByIdAsync(id);
            return PartialView(model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PropertiesValue propertiesValue)
        {
            try
            {

                _context.PropertiesValueRepositoryUW.Update(propertiesValue);

                await _context.saveAsync();


                TempData["message"] = EndPointMessage.SUCCESS_Edit_MSG;
                TempData["type"] = EndPointMessage.SUCCESS_Edit_TYPE;


            }
            catch (Exception)
            {
                TempData["message"] = EndPointMessage.Fail_MSG;
                TempData["type"] = EndPointMessage.Fail_TYPE;
            }

            return RedirectToAction(nameof(Index), new { id = propertiesValue.properties_id });
        }



        public async Task<IActionResult> Delete(int id)
        {

            var model = await _context.PropertiesValueRepositoryUW.GetByIdAsync(id);

            return PartialView(model);
        }


        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            int properties_id = -1;

            try
            {

                var model = await _context.PropertiesValueRepositoryUW.GetByIdAsync(id);

                model.isEnable = false;

                properties_id = model.properties_id;

                _context.PropertiesValueRepositoryUW.Update(model);
 
                await _context.saveAsync();


                TempData["message"] = EndPointMessage.DELETE_MSG;
                TempData["type"] = EndPointMessage.DELETE_TYPE;


            }
            catch (Exception)
            {
                TempData["message"] = EndPointMessage.Fail_MSG;
                TempData["type"] = EndPointMessage.Fail_TYPE;
            }

            return RedirectToAction(nameof(Index), new { id = properties_id });
        }




    }
}