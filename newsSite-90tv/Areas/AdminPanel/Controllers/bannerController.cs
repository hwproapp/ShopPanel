using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class bannerController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IUploadfile _uploadfile;
        private readonly Ideleteimage _deleteimage;

        public bannerController(IUnitOfWork context , IUploadfile uploadfile , Ideleteimage ideleteimage)
        {
            _context = context;
            _uploadfile = uploadfile;
            _deleteimage = ideleteimage;

        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int paresh = (page - 1) * 10;
            int totalCount =await _context.workerBannerRepositoryUW.GetCountAsync(a => a.isenable);
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
            var model = await _context.workerBannerRepositoryUW.GetWithSkipAsync(a => a.isenable, a => a.OrderByDescending(b => b.status == Status.suspend.ToByte()), "Tbl_UserApp", paresh,10);
            return View(model);
        }


        public async Task<IActionResult> Details(long id)
        {
            var model = new BannerDetailsViewModel();


            model.banner = await _context.workerBannerRepositoryUW.GetAsync(a => a.Id == id, "Tbl_UserApp,Tbl_Category");
            model.bannerimage = await _context.bannerimagesRepositoryUW.GetManyAsync(a => a.banner_id == id);

            return PartialView(model);
        }


        public IActionResult Create()
        {
            var model = new CreateBannerViewModel();

            model.appusers = _context.userappRepositoryUW.Get(a => a.isEnable).Select(a=>new AppUserDropDownViewModel
            {
                fullname  = a.firstName + " " + a.lastName,
                id = a.Id
            });

            model.category = _context.CategoryRepositoryUW.Get(a => a.isenable && a.type == categoryType.service.ToByte());

            model.ostan = _context.ostanRepositoryUW.Get();

            return View(model);
        }


        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(workerBanner banner , IEnumerable<IFormFile> images , string imagename)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    banner.image = string.IsNullOrEmpty(imagename) ? "nopicture.png" : imagename;
                    banner.isenable = true;
                    banner.todate = DateTime.Now.AddMonths(1);
                    banner.viewcount = 0;
                    banner.status = Status.valid.ToByte(); // for admin creation is valid



                    _context.workerBannerRepositoryUW.Create(banner);
                    await _context.saveAsync();

                    //save banner's gallary images 

                    if (images.Count() != 0)
                    {
                        foreach (var image in images)
                        {
                           var path = _uploadfile.UploadFilesSingle(image, "upload\\banners\\normalimage\\", "");

                            bannerImage bannerImage = new bannerImage
                            {
                                banner_id = banner.Id,
                                image = path,
                            };

                            _context.bannerimagesRepositoryUW.Create(bannerImage);
                        }

                       await _context.saveAsync();
                    }



                    ViewBag.message = EndPointMessage.SUCCESS_MSG;
                    ViewBag.type = EndPointMessage.SUCCESS_Edit_TYPE;
                }
                else
                {
                    ViewBag.message = EndPointMessage.Value_MSG;
                    ViewBag.type = EndPointMessage.Value_TYPE;
                }


                
            }

            catch (Exception)
            {

                ViewBag.message = EndPointMessage.Fail_MSG;
                ViewBag.type = EndPointMessage.Fail_TYPE;
            }


            var model = new CreateBannerViewModel();



            model.appusers = _context.userappRepositoryUW.Get(a => a.isEnable).Select(a => new AppUserDropDownViewModel
            {
                fullname = a.firstName + " " + a.lastName,
                id = a.Id
            });

            model.category = await _context.CategoryRepositoryUW.GetManyAsync(a => a.isenable && a.type == categoryType.service.ToByte());

            model.ostan = await _context.ostanRepositoryUW.GetAllAsync();

            model.banner = banner;

            model.city = await _context.cityRepositoryUW.GetManyAsync(a => a.ostan_id == model.banner.ostan_id);

            return View(model);
        }


        //............

        public async  Task<IActionResult> Edit(long id)
        {
            var model = new EditBannerViewModel();


            model.banner = await _context.workerBannerRepositoryUW.GetByIdAsync(id);

            model.appusers = _context.userappRepositoryUW.Get(a => a.isEnable).Select(a => new AppUserDropDownViewModel
            {
                id = a.Id,
                fullname = a.firstName + " " + a.lastName
               
            });

            model.category =await _context.CategoryRepositoryUW.GetAsync(a => a.isenable && a.type == categoryType.service.ToByte() , null  , "");

            model.ostan = await _context.ostanRepositoryUW.GetAllAsync();

            model.city = await _context.cityRepositoryUW.GetManyAsync(a=>a.ostan_id == model.banner.ostan_id);

            return View(model);

        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(workerBanner banner, IEnumerable<IFormFile> images , string trashimage , string imagename)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (!string.IsNullOrEmpty(imagename))
                    {

                        // delete prev image
                        await _deleteimage.DeleteImageHost(banner.image , "upload\\banners\\normalimage\\", "upload\\banners\\thumbnailimage\\");


                        banner.image = imagename;
                    }


                    _context.workerBannerRepositoryUW.Update(banner);
                    await _context.saveAsync();

                    //save images 

                    if (images.Count() != 0)
                    {
                        foreach (var item in images)
                        {
                            var path = _uploadfile.UploadFilesSingle(item, "upload\\banners\\normalimage\\", "");

                            bannerImage bannerImage = new bannerImage
                            {
                                banner_id = banner.Id,
                                image = path,
                            };

                            _context.bannerimagesRepositoryUW.Create(bannerImage);
                        }

                        await _context.saveAsync();
                    }


                    //....trash image 
                 
                    if (!string.IsNullOrEmpty(trashimage))
                    {
                        var idarr  = Utility.ParseJson<List<long>>(trashimage);

                        foreach (var id in idarr)
                        {
                            var bannerImage = await _context.bannerimagesRepositoryUW.GetByIdAsync(id);

                            // delete from db
                            _context.bannerimagesRepositoryUW.Delete(bannerImage);

                            // delete from host
                            await _deleteimage.DeleteImageHost(bannerImage.image , "uplaod\\normalimage\\normalimage" , "");
                        }

                        await _context.saveAsync();

                    }



                    ViewBag.message = EndPointMessage.SUCCESS_MSG;
                    ViewBag.type = EndPointMessage.SUCCESS_Edit_TYPE;
                }
                else
                {
                    ViewBag.message = EndPointMessage.Value_MSG;
                    ViewBag.type = EndPointMessage.Value_TYPE;
                }



            }

            catch (Exception ex)
            {

                ViewBag.message = EndPointMessage.Fail_MSG + ex.ToString();
                ViewBag.type = EndPointMessage.Fail_TYPE;
            }




            var model = new EditBannerViewModel();


            model.appusers = _context.userappRepositoryUW.Get(a => a.isEnable).Select(a => new AppUserDropDownViewModel
            {
                fullname = a.firstName + " " + a.lastName,
                id = a.Id
            });


            model.category =await  _context.CategoryRepositoryUW.GetManyAsync(a => a.isenable && a.type == categoryType.service.ToByte());
            model.ostan =await _context.ostanRepositoryUW.GetAllAsync();
            model.banner = banner;
            model.city = await  _context.cityRepositoryUW.GetManyAsync(a => a.Id == banner.ostan_id);


            return View(model);
        }




        public IActionResult GetCity(int ostanid)
        {
            ViewBag.id = "banner_city_id";

            ViewBag.name = "banner.city_id";

            var model = _context.cityRepositoryUW.Get(a => a.ostan_id == ostanid);

            return PartialView("_GetCity", model);
        }






        public async Task<IActionResult> Delete(long id)
        {
            var model =await _context.workerBannerRepositoryUW.GetByIdAsync(id);
            return PartialView(model);
        }




        [HttpPost , ValidateAntiForgeryToken , ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            try
            {
                var model = await _context.workerBannerRepositoryUW.GetByIdAsync(id);



                model.isenable = false;

                _context.workerBannerRepositoryUW.Update(model);

                await _context.saveAsync();


                //...... delete banener gallary images


                var images = await  _context.bannerimagesRepositoryUW.GetManyAsync(a => a.banner_id == id);

                _context.bannerimagesRepositoryUW.DeleteAll(images);

                await _context.saveAsync();

                foreach (var item in images)
                {

                    await _deleteimage.DeleteImageHost(item.image , "upload\\banners\\normalimage" , "");
                  
                }
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



        // chnage state of banner
        public async Task<IActionResult> changestatus(long id, int state = 2)
        {
            try
            {
                var banner = await _context.workerBannerRepositoryUW.GetByIdAsync(id);

                banner.status = state.ToByte();

                _context.workerBannerRepositoryUW.Update(banner);

                await _context.saveAsync();


                TempData["message"] = EndPointMessage.DONE_MSG;
                TempData["type"]    =  EndPointMessage.DONE_TYPE;
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
            string filename = _uploadfile.UploadFiles(files, "upload\\banners\\normalimage\\", "\\upload\\banners\\thumbnailimage\\");
            return Json(new { status = "success", message = "تصویر با موفقیت آپلود شد.", imagename = filename });

        }



    }
    
}