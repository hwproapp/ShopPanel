using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.Models.ViewModels;
using newsSite90tv.PublicClass;
using newsSite90tv.Services;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    //[Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IUploadfile _upload;
        private readonly Ideleteimage _ideleteimage;

        public UserController(IUnitOfWork context,
            IUploadfile upload,
            UserManager<ApplicationUsers> userManager , Ideleteimage ideleteimage)
        {
            _context = context;
            _userManager = userManager;
            _upload = upload;
            _ideleteimage = ideleteimage;
        }

        public IActionResult Index()
        {
            ViewBag.ViewTitle = "  لیست کاربران سیستم";
            var model = _context.userManagerUW.Get(a=>a.isEnable);
            return View(model);
        }

        public IActionResult UploadFile(IEnumerable<IFormFile> files)
        {
            //"upload\\userimage\\normalimage\\"
            //"\\upload\\userimage\\thumbnailimage\\"
            string filename = _upload.UploadFiles(files, "upload\\userimage\\normalimage\\", "upload\\userimage\\thumbnailimage\\");
            return Json(new { status = "success", message = "تصویر با موفقیت آپلود شد.", imagename = filename });

        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ViewTitle = "فرم افزودن کاربر";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            EditUserViewModel model = new EditUserViewModel();
            ApplicationUsers user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.Email = user.Email;
                model.PhoneNumber = user.PhoneNumber;
                model.BirthDayDate = user.BirthDayDate;
                model.gender = user.gender;
                model.UserImage = user.UserImagePath;
               
            }


           
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel model, string imagename="")
        {
            if (ModelState.IsValid)
            {
                try
                {

                    model.UserImage = imagename;


                    ApplicationUsers user = new ApplicationUsers
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        PhoneNumber = model.PhoneNumber,
                        UserName = model.UserName,
                        Email = model.Email,
                        gender = model.gender,
                        BirthDayDate = model.BirthDayDate,
                        UserImagePath = model.UserImage,
                        isEnable = true
                    };

                    IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {

                        ViewBag.mesasge = EndPointMessage.SUCCESS_MSG;
                        ViewBag.type    = EndPointMessage.SUCCESS_TYPE;

                      
                    }
                    else
                    {
                        ViewBag.mesasge = EndPointMessage.Fail_MSG;
                        ViewBag.type= EndPointMessage.Fail_TYPE;
                    }

                }
                catch
                {
                    ViewBag.message = EndPointMessage.Fail_MSG;
                    ViewBag.type     = EndPointMessage.Fail_TYPE;
                }
               

            }
            else
            {
                ViewBag.message = EndPointMessage.Value_MSG;
                ViewBag.type = EndPointMessage.Value_TYPE;
            }
            ViewBag.ViewTitle = "فرم ایجاد کاربر";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {

            EditUserViewModel model = new EditUserViewModel();
            ApplicationUsers user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.Email = user.Email;
                model.PhoneNumber = user.PhoneNumber;
                model.BirthDayDate = user.BirthDayDate;
                model.gender = user.gender;
                model.UserImage = user.UserImagePath;
            }


            ViewBag.ViewTitle = "فرم ویرایش کاربر";
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model, string id,
            string imagename, string chkinput)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Update
                    ApplicationUsers user = await _userManager.FindByIdAsync(id);

                    if (user != null)
                    {
                        user.FirstName = model.FirstName;
                        user.LastName = model.LastName;
                        user.PhoneNumber = model.PhoneNumber;
                        user.Email = model.Email;
                        user.gender = model.gender;
                        user.BirthDayDate = model.BirthDayDate;


                        if (!string.IsNullOrEmpty(imagename))
                        {
                            if (!string.IsNullOrEmpty(user.UserImagePath))
                            {
                                await _ideleteimage.DeleteImageHost(user.UserImagePath, "upload\\userimage\\normalimage\\", "upload\\userimage\\thumbnailimage\\");
                            }
                            user.UserImagePath = imagename;
                        }


                        if (chkinput == "on")
                        {
                            //Reset Password
                            //123d@F
                            user.PasswordHash = "AQAAAAEAACcQAAAAEAabKLaDOcVF55N+pqYxMKEsctUlZmrmudfUurx8DtbxZcPv0wXbujbbfg3g2LrYrg==";
                        }

                        IdentityResult result = await _userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {

                            ViewBag.resetpass = "123d@F";
                            ViewBag.message = EndPointMessage.SUCCESS_Edit_MSG;
                            ViewBag.type = EndPointMessage.SUCCESS_Edit_TYPE;

                           
                        }
                        else
                        {
                            ViewBag.message = EndPointMessage.Fail_MSG;
                            ViewBag.type = EndPointMessage.Fail_TYPE;
                        }

                    }
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

            ViewBag.ViewTitle = "فرم ویرایش کاربر";
            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {

            ApplicationUsers user = await _userManager.FindByIdAsync(id);
            return PartialView(user);
        }


        [HttpPost , ValidateAntiForgeryToken , ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                ApplicationUsers user = await _userManager.FindByIdAsync(id);
                
                user.isEnable = false;

                await _context.saveAsync();

                if (!string.IsNullOrEmpty(user.UserImagePath))
                {
                    _ideleteimage.DeleteImageHost(user.UserImagePath, "upload\\userimage\\normalimage\\", "upload\\userimage\\thumbnailimage\\");
                }


                TempData["message"]  = EndPointMessage.DELETE_MSG;
                TempData["type"]  = EndPointMessage.DELETE_TYPE;
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