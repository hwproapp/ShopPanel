using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.ViewModels;

namespace newsSite90tv.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUsers> _signInManager;
        private readonly UserManager<ApplicationUsers> _userManager;

        public AccountController(SignInManager<ApplicationUsers> signInManager,
            UserManager<ApplicationUsers> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        
        [HttpGet]
        public   IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {

            // check for user login which redirect to panel
            //if (_signInManager.IsSignedIn(User))
            //{
            //    return RedirectToAction("Index", "Home", new { area = "AdminPanel" });
            //}

            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName,
                    model.Password, model.RememberMe, lockoutOnFailure: false);
                
                if (result.Succeeded) // user not delete or lock can login 
                {
                    //Success Login
                    var user = await _userManager.FindByNameAsync(model.UserName);

                    if (user.isEnable)
                    {
                       // TempData["FullName"] = user.FirstName + "  " + user.LastName;

                        return Json(new { status = "success" });
                    }
                    else
                    {
                        return Json(new { status = "fail3" });
                    }

                    //var userRole = await _userManager.GetRolesAsync(user);

                  

                    //return RedirectToLocal(userRole.ToArray(), returnUrl);
                }
                {
                    //اگر اطلاعات کاربر اشتباه بود
                    //ModelState.AddModelError("MyKey","نام کاربری یا رمز عبور اشتباه است");
                    //return PartialView("_loginPartial");
                    return Json(new { status = "fail" });
                    //Failed Login
                }
            }
            //return PartialView("_loginPartial",model);
            return Json(new { status = "fail2" });
        }


        private IActionResult RedirectToLocal(string[] Roles,string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                if (Roles.Contains("User"))
                {
                    return Redirect("/AdminPanel/User");
                }
            }
            return null;
        }



        [HttpPost ,  ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

    }
}