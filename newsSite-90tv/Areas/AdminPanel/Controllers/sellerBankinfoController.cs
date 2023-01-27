using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.Models.ViewModels;
using newsSite90tv.PublicClass;
using newsSite90tv.Services;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class sellerBankinfoController : Controller
    {
        private readonly IUnitOfWork _context;
   


        public sellerBankinfoController(IUnitOfWork context)
        {
            _context = context;
            
        }


        public IActionResult Index(int page=1)
        {
            int paresh = (page - 1) * 10;
        
            int totalCount = _context.sellerBankRepositoryUW.Get(a=>a.isenable).Count();
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
            
            var model = _context.sellerBankRepositoryUW.Get(a => a.isenable, null , "Tbl_Salsman").Skip(paresh).Take(10);
            return View(model);
        }

      


        [HttpGet]
        public IActionResult Create()
        {
            var model = new selbankinfocreateViewModel();

            model.sellers = _context.salsmanRepositoryUW.Get(a=>a.isEnable && a.status == 1 , null , "Tbl_Userapp").Select(a=>new AppUserDropDownViewModel
            {
                fullname = a.Tbl_Userapp.firstName + " " + a.Tbl_Userapp.lastName,
                id = a.Id,
            });
            

            return View(model);
        }



        [HttpPost , ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(sellerBank bankinfo)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    bankinfo.status =1;
                    bankinfo.isenable = true;


                    _context.sellerBankRepositoryUW.Create(bankinfo);
                    await _context.saveAsync();


                    ViewBag.message = EndPointMessage.SUCCESS_MSG;
                    ViewBag.type = EndPointMessage.SUCCESS_TYPE;

                }
                catch
                {

                    ViewBag.message = EndPointMessage.Fail_MSG;
                    ViewBag.type = EndPointMessage.Fail_TYPE;
                }
            }
            else
            {
                ViewBag.message = EndPointMessage.Value_MSG;
                ViewBag.type = EndPointMessage.Value_TYPE;
            }

            var model = new selbankinfocreateViewModel();

            model.sellers = _context.salsmanRepositoryUW.Get(a => a.isEnable && a.status == 1, null, "Tbl_Userapp").Select(a => new AppUserDropDownViewModel
            {
                fullname = a.Tbl_Userapp.firstName + " " + a.Tbl_Userapp.lastName,
                id = a.Id,
            });

            model.bankinfo = bankinfo;

            return View(model);
        }
        

        public IActionResult Edit(long id)
        {
            var model = new selbankinfocreateViewModel();

            model.sellers = _context.salsmanRepositoryUW.Get(a => a.isEnable && a.status == 1, null, "Tbl_Userapp").Select(a => new AppUserDropDownViewModel
            {
                fullname = a.Tbl_Userapp.firstName + " " + a.Tbl_Userapp.lastName,
                id = a.Id,
            });

            model.bankinfo = _context.sellerBankRepositoryUW.GetById(id);

            return View(model);
            
        }


        [HttpPost  , ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(sellerBank bankinfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.sellerBankRepositoryUW.Update(bankinfo);
                    await _context.saveAsync();


                    ViewBag.message = EndPointMessage.SUCCESS_Edit_MSG;
                    ViewBag.type = EndPointMessage.SUCCESS_Edit_TYPE;

                }
                catch
                {

                    ViewBag.message = EndPointMessage.Fail_MSG;
                    ViewBag.type = EndPointMessage.Fail_TYPE;
                }
            }
            else
            {
                ViewBag.message = EndPointMessage.Value_MSG;
                ViewBag.type = EndPointMessage.Value_TYPE;
            }

            var model = new selbankinfocreateViewModel();

            model.sellers = _context.salsmanRepositoryUW.Get(a => a.isEnable && a.status == 1, null, "Tbl_Userapp").Select(a => new AppUserDropDownViewModel
            {
                fullname = a.Tbl_Userapp.firstName + " " + a.Tbl_Userapp.lastName,
                id = a.Id,
            });
            model.bankinfo = bankinfo;


            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var model =await _context.sellerBankRepositoryUW.GetByIdAsync(id);
            return PartialView(model);
        }

        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfimed(long id)
        {
            
            try
            {

                var bank = await _context.sellerBankRepositoryUW.GetByIdAsync( id);
                bank.isenable = false;

                _context.sellerBankRepositoryUW.Update(bank);
                await _context.saveAsync();

                TempData["message"] = "حذف موفقیت آمیز بود";
                TempData["type"] = "success";


            }
            catch (Exception)
            {

                TempData["message"] = "در اجرای عملیات خطایی رخ داده است";
                TempData["type"] = "danger";
            }

            return RedirectToAction(nameof(Index));
        }






    }
}