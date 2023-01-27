using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;
using newsSite90tv.Services;
using Newtonsoft.Json;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IUploadfile _uploadfile;
        private readonly Ideleteimage _ideleteimage;

        private readonly IHostingEnvironment _hostingEnvironment;

        public CategoryController(IUnitOfWork context, IUploadfile uploadfile, IHostingEnvironment hostingEnvironment, Ideleteimage ideleteimage)
        {
            _context = context;
            _uploadfile = uploadfile;
            _hostingEnvironment = hostingEnvironment;
            _ideleteimage = ideleteimage;
        }
        public IActionResult Index(int page =1)
        {
            if (page == 1)
            {
                List<TreeViewNode> prodnodes = new List<TreeViewNode>();
                List<TreeViewNode> shopnodes = new List<TreeViewNode>();
                List<TreeViewNode> jobnodes = new List<TreeViewNode>();

                prodnodes.Add(new TreeViewNode
                {
                    id = "0",
                    parent = "#",
                    text = "دسته بندی محصولات"
                });

                shopnodes.Add(new TreeViewNode
                {
                    id = "0",
                    parent = "#",
                    text = "دسته بندی فروشگاه "
                });

                jobnodes.Add(new TreeViewNode
                {
                    id = "0",
                    parent = "#",
                    text = "دسته بندی اشتغال "
                });



                prodnodes.AddRange(_context.CategoryRepositoryUW.Get(a => a.type == categoryType.product.ToByte() && a.isenable).Select(a => new TreeViewNode
                {
                    id = a.Id.ToString(),
                    parent = a.ParentId.ToString(),
                    text = a.Title
                }));

                shopnodes.AddRange(_context.CategoryRepositoryUW.Get(a => a.type == categoryType.shop.ToByte() && a.isenable).Select(a => new TreeViewNode
                {
                    id = a.Id.ToString(),
                    parent = a.ParentId.ToString(),
                    text = a.Title
                }));


                jobnodes.AddRange(_context.CategoryRepositoryUW.Get(a => a.type == categoryType.service.ToByte() && a.isenable).Select(a => new TreeViewNode
                {
                    id = a.Id.ToString(),
                    parent = a.ParentId.ToString(),
                    text = a.Title
                }));

                
                ViewBag.prodJson = JsonConvert.SerializeObject(prodnodes);
                ViewBag.shopJson = JsonConvert.SerializeObject(shopnodes);
                ViewBag.jobJson = JsonConvert.SerializeObject(jobnodes);

            }

            //paging 
            int paresh = (page - 1) * 10;
           
            int totalCount = _context.CategoryRepositoryUW.Get(a=>a.isenable).Count();
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


            var model = _context.CategoryRepositoryUW.Get(a=>a.isenable).Skip(paresh).Take(10);



            return View(model);

            
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.cats = _context.CategoryRepositoryUW.Get(a=>a.isenable && a.type == categoryType.product.ToByte());
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Category category, string imagename)
        {
            if (ModelState.IsValid)
            {

                category.isenable = true;
                category.image =  string.IsNullOrEmpty(imagename) ? "nopicture.png" : imagename;

                _context.CategoryRepositoryUW.Create(category);


                category.datemiladi = DateTime.Now;
                category.dateshamsi = DateAndTimeShamsi.DateTimeShamsi();

                await _context.saveAsync();

                ViewBag.message = "با موفقیت ثبت شد";
                ViewBag.alerttype = "success";
            }
            else
            {

                ViewBag.message = "مقادیر بدرستی وارد شود";
                ViewBag.alerttype = "danger";
            }

            ViewBag.cats = _context.CategoryRepositoryUW.Get();
            return View(category);
        }


        [HttpGet]

        public IActionResult Edit(int id)
        {
            var model = _context.CategoryRepositoryUW.GetById(id);
            ViewBag.cats = _context.CategoryRepositoryUW.Get(a=>a.type  == model.type);
            return View(model: model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category, string imagename)
        {

            if (ModelState.IsValid)
            {
             

                if (!string.IsNullOrEmpty(imagename))
                {
                  
                    // delet old image
                    await _ideleteimage.DeleteImageHost(category.image, "upload\\category\\normalimage\\", "upload\\category\\thumbnailimage\\", "nopicture.png");

                    category.image = imagename;

                }


                _context.CategoryRepositoryUW.Update(category);
                await _context.saveAsync();

                ViewBag.message = "ویرایش موفقیت آمیز بود";
                ViewBag.alerttype = "success";
            }
            else
            {
                
                ViewBag.message = "مقادیر بدرستی وارد شود";
                ViewBag.alerttype = "danger";
            }
            ViewBag.cats = _context.CategoryRepositoryUW.Get();
            return View(category);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _context.CategoryRepositoryUW.GetById(id);
            return View(model: model);
        }

        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfimed(int id)
        {
           
            try
            {

               
                var cat = await _context.CategoryRepositoryUW.GetByIdAsync(id);

                cat.isenable = false;

                _context.CategoryRepositoryUW.Update(cat);

                await _context.saveAsync();

               
               await _ideleteimage.DeleteImageHost(cat.image, "upload\\category\\normalimage\\", "upload\\category\\thumbnailimage\\", "nopicture.png");




                TempData["message"] = EndPointMessage.DELETE_MSG;
                TempData["type"]    = EndPointMessage.DELETE_TYPE;

              


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
            string filename = _uploadfile.UploadFiles(files, "upload\\category\\normalimage\\", "\\upload\\category\\thumbnailimage\\");
            return Json(new { status = "success", message = "تصویر با موفقیت آپلود شد.", imagename = filename });

        }




        [HttpPost]
        public string categoryTypes(int mode)
        {
            object model = null;

            switch (mode)
            {
                case 0:
                    model = _context.CategoryRepositoryUW.Get(a => a.type == categoryType.product.ToByte());
                    break;

                case 1:
                    model = _context.CategoryRepositoryUW.Get(a => a.type == categoryType.service.ToByte());
                    break;


                case 2:
                    model = _context.CategoryRepositoryUW.Get(a => a.type == categoryType.shop.ToByte());
                    break;
                default:
                   
                    break;  
            }

            return JsonConvert.SerializeObject(model);

        }


       



    }
}