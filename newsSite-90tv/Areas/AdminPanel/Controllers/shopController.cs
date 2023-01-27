using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.Services;

using newsSite90tv.PublicClass;
using newsSite90tv.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;
using newsSite90tv.Models.Services;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class shopController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IUploadfile _uploadfile;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IsearchResult _isearchResult;
        private readonly Ideleteimage _ideleteimage;

        public shopController(IUnitOfWork contex  , IUploadfile uploadfile  , UserManager<ApplicationUsers> userManager, 
            IHostingEnvironment hostingEnvironment , IsearchResult searchResult  , Ideleteimage ideleteimage)
        {
            _context = contex;
            _uploadfile = uploadfile;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
            _isearchResult = searchResult;
            _ideleteimage = ideleteimage;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int paresh = (page - 1) * 10;
        
            int totalCount = await _context.shopRepositoryUW.GetCountAsync(a =>a.enable);
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


         
            var model = await _context.shopRepositoryUW.GetWithSkipAsync(a=>a.enable ,a => a.OrderByDescending(b => b.status == 0),"" , paresh , 10);


            ViewBag.viewtitle = "لیست فروشگاه ها";
            return View(model);
        }



       




        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.viewtitle = "ایجاد فروشگاه ";

            var model = new shopCreateViewModel();
            
            model.ostan = _context.ostanRepositoryUW.Get();

            model.seller = _context.salsmanRepositoryUW.Get(a => a.status == 1 && a.isEnable, null, "Tbl_Userapp").Select(a => new AppUserDropDownViewModel
            {
                fullname = a.Tbl_Userapp.firstName + " " + a.Tbl_Userapp.lastName,
                id = a.Id
            });

            model.shopCategory = _context.CategoryRepositoryUW.Get(a => a.type == categoryType.shop.ToByte());
            return View(model);
        }


        [HttpPost  , ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Shop shop  ,string imagename)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var shpopnameexist  =await _context.shopRepositoryUW.GetAsync(a=>a.title == shop.title);

                    if (shpopnameexist == null)
                    {

                        shop.image = string.IsNullOrEmpty(imagename) ? "shopdefult.png" : imagename ;
                        shop.status = 1;
                        shop.enable = true;


                        _context.shopRepositoryUW.Create(shop);
                        await _context.saveAsync();





                        ViewBag.message = EndPointMessage.SUCCESS_MSG;
                        ViewBag.type = EndPointMessage.SUCCESS_TYPE;
                    }
                    else
                    {
                        ViewBag.message = EndPointMessage.SHOP_NAME_REAPETS;
                        ViewBag.type =EndPointMessage.SHOP_NAME_REAPETS_TYPE;
                    }

                  
                }
                catch(Exception )
                {

                    ViewBag.message = EndPointMessage.Fail_MSG ;
                    ViewBag.type = EndPointMessage.Fail_TYPE;
                }

            }
            else
            {
                ViewBag.message = EndPointMessage.Value_MSG;
                ViewBag.type = EndPointMessage.Value_TYPE;
            }


            var model = new shopCreateViewModel();

            model.shop = shop;
         
            model.ostan = _context.ostanRepositoryUW.Get();

            model.seller = _context.salsmanRepositoryUW.Get(a => a.status == Status.valid.ToByte() && a.isEnable, null, "Tbl_Userapp").Select(a => new AppUserDropDownViewModel
            {
                fullname = a.Tbl_Userapp.firstName + " " + a.Tbl_Userapp.lastName,
                id = a.Id
            });
            model.shopCategory = _context.CategoryRepositoryUW.Get(a => a.type == categoryType.shop.ToByte());
            ViewBag.viewtitle = "ایجاد فروشگاه ";
            return View(model);

        }


        [HttpGet]
        public IActionResult Edit(long id)
        {
            ViewBag.viewtitle = "ویرایش فروشگاه ";

            var model = new shopCreateViewModel();

           
            model.seller = _context.salsmanRepositoryUW.Get(a => a.status == Status.valid.ToByte() && a.isEnable,null,"Tbl_Userapp").Select(a=>new AppUserDropDownViewModel
            {
                fullname = a.Tbl_Userapp.firstName + " " +a.Tbl_Userapp.lastName,
                id = a.Id
            });
            model.shopCategory = _context.CategoryRepositoryUW.Get(a => a.type == categoryType.shop.ToByte());
            model.shop = _context.shopRepositoryUW.GetById(id);

            model.cities = _context.cityRepositoryUW.Get(a=>a.ostan_id == model.shop.ostan_id);
            model.ostan = _context.ostanRepositoryUW.Get();


            return View(model);


            
        }


        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Shop shop  , string imagename )
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                   

                    if (!string.IsNullOrEmpty(imagename))
                    {

                        var oldimage = shop.image;

                        if (oldimage != "shopdefult.png")
                        {
                            await _ideleteimage.DeleteImageHost(oldimage, "upload\\shop\\normalimage\\", "upload\\shop\\thumbnailimage\\");

                        }

                        shop.image = imagename;
                    }
                    
                    _context.shopRepositoryUW.Update(shop);
                    await _context.saveAsync();





                    ViewBag.message = EndPointMessage.SUCCESS_Edit_MSG;
                    ViewBag.type = EndPointMessage.SUCCESS_Edit_TYPE;


                }
                catch 
                {

                    ViewBag.message = EndPointMessage.Fail_MSG;
                    ViewBag.type = EndPointMessage.Fail_TYPE;
                }

            }else

            {
                ViewBag.message = EndPointMessage.Value_MSG;
                ViewBag.type = EndPointMessage.Value_TYPE;
            }

           

            var model = new shopCreateViewModel();

            ViewBag.viewtitle = "ویرایش فروشگاه ";

            model.cities = _context.cityRepositoryUW.Get();
            model.ostan = _context.ostanRepositoryUW.Get();
            model.seller = _context.salsmanRepositoryUW.Get(a => a.status == Status.valid.ToByte() && a.isEnable, null, "Tbl_Userapp").Select(a => new AppUserDropDownViewModel
            {
                fullname = a.Tbl_Userapp.firstName + " " + a.Tbl_Userapp.lastName,
                id = a.Id
            });
            model.shopCategory = _context.CategoryRepositoryUW.Get(a => a.type == categoryType.shop.ToByte());
            model.shop = shop;

            return View(model);
        }


        public async Task<IActionResult> Delete(long id)
        {
            ViewBag.controller = "shop";
            var model = await _context.shopRepositoryUW.GetByIdAsync(id);
            return PartialView("_Delete", model);
        }




        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            try
            {
                var model = await _context.shopRepositoryUW.GetByIdAsync(id);

                 model.enable = false;

                _context.shopRepositoryUW.Update(model);

                await _context.saveAsync();


                if (model.image != "shopdefult.png")
                    _ideleteimage.DeleteImageHost(model.image, "upload\\shop\\normalimage\\", "upload\\shop\\thumbnailimage\\");





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
        public IActionResult UploadFile(IEnumerable<IFormFile> files)
        {
            //"upload\\userimage\\normalimage\\"
            //"\\upload\\userimage\\thumbnailimage\\"
            string filename = _uploadfile.UploadFiles(files, "upload\\shop\\normalimage\\", "\\upload\\shop\\thumbnailimage\\");
            return Json(new { status = "success", message = "تصویر با موفقیت آپلود شد.", imagename = filename });

        }



        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var model = await _context.shopRepositoryUW.GetByIdAsync(id);

            return View(model);
        }


        [HttpGet]
        public  async Task<IActionResult> shopProduct(long id , int page = 1)
        {

            ViewBag.shopid = id;

            //..........
            int paresh = (page - 1) * 10;
           
            int totalCount = await _context.productRepositoryUW.GetCountAsync(a => a.shop_id == id && a.enable);

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



            var model = await _context.productRepositoryUW.GetWithSkipAsync(a => a.shop_id == id && a.enable, a=>a.OrderByDescending(b=>b.status == 1)  , "" , paresh , 10);

            return View(model);
            
        }
        

      


        [HttpGet]
        public IActionResult searchBox()
        {
            return PartialView("_searchBox");
        }




        [HttpGet , HttpPost]

        public IActionResult searchResult(string q  , byte order, int page = 1)
        {

            ViewBag.q = q;
            ViewBag.order = order;
            ViewBag.PageID = page;


            var sres = _isearchResult.SearchResShop(order, q, page, Convert.ToByte(pagingTake.ten));


            //ICollection key = sres.Result.Keys;


            var model = (IEnumerable<Shop>)sres["shops"];
            int totalCount = (int)sres["count"];

            double remain = totalCount % 10;

            if (remain == 0)
            {
                ViewBag.PageCount = totalCount / 10;
            }
            else
            {
                ViewBag.PageCount = (totalCount / 10) + 1;
            }



            return View(model);
        }


        [HttpPost]
        public string getostan()
        {
            var model = _context.ostanRepositoryUW.Get();
            return JsonConvert.SerializeObject(model);
        }

        



        [HttpPost]
        public IActionResult allshops()
        {
            var model = _context.shopRepositoryUW.Get(a => a.status == 1 && a.enable);
            return Content(JsonConvert.SerializeObject(model));
        }


        public IActionResult GetCity(int ostanid)
        {
            ViewBag.id = "shop_city_id";
            ViewBag.name = "shop.city_id";

            var model = _context.cityRepositoryUW.Get(a => a.ostan_id == ostanid);
            return PartialView("_GetCity", model);
        }

      
        public async Task<IActionResult> changeStatus(long id, byte state = 2)
        {
            var shop = await _context.shopRepositoryUW.GetByIdAsync(id);

            shop.status = state;

            _context.shopRepositoryUW.Update(shop);
            await _context.saveAsync();


            return RedirectToAction(nameof(Index));


        }


       

    }
}