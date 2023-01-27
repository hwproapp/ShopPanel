using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.Services;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class fileController : Controller
    {

        private readonly IUnitOfWork _contex;

        private readonly IUploadfile _uploadfile;

        private readonly IHostingEnvironment _appEnvironment;
        public fileController(IUnitOfWork contex , IUploadfile uploadfile , IHostingEnvironment hostingEnvironment)
        {
            _contex = contex;
            _uploadfile = uploadfile;
            _appEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            
            return View();
        }


        public IActionResult Create()
        {
            var model = _contex.fileManagerRepositoryUW.GetAllAsync().Result;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> UploadFile(IEnumerable<IFormFile> files)
        {
            //"upload\\userimage\\normalimage\\"
            //"\\upload\\userimage\\thumbnailimage\\"
            try
            {
                var upload = Path.Combine(_appEnvironment.WebRootPath, "upload\\gallaryUp\\normalimage\\");
                string msg = "";
                string filename = "";
                string imagespath = "";

                string ids = "";
                bool valid = true;
                int count = 0;

                if (files.Count() !=0)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 303085)
                        {
                            msg += "اندازه فایل زیاد است" + file.FileName;
                            valid = false;

                        }
                        if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
                        {
                            msg += "نوع فایل نامعتبر است" + file.FileName;
                            valid = false;
                        }

                        if (valid)
                        {
                            filename = _uploadfile.UploadFilesGallary(file, "upload\\gallaryUp\\normalimage\\", "\\upload\\gallaryUp\\thumbnailimage\\");

                            FileManager newfile = new FileManager
                            {
                                path = filename,
                               
                            };

                            _contex.fileManagerRepositoryUW.Create(newfile);
                            await _contex.saveAsync();
                            count++;

                            imagespath += filename + ",";

                            ids += newfile.Id + ",";



                            if (count == files.Count())
                            {
                                return Json(new { status = "success", message = "تصویر با موفقیت آپلود شد.", imagenames = imagespath ,fileid=ids});
                            }
                        }
                        else
                        {
                           return Json(new { status = "fail", message = msg.ToString(), imagenames = "" });
                        }
                    }
                   
                }
                return Json(new { status = "fail2", message = "فایلی وجود ندارد", imagenames = "" });


            }
            catch
            {
                return Json(new { status = "fail2", message = "خطایی رخ داده است", imagenames = "" });
            }


           

        }



        [HttpPost]

        public async Task<IActionResult> DeleteFile(long id)
        {
            var file =  _contex.fileManagerRepositoryUW.GetById(id);

            string filename = file.path;

            var upload = Path.Combine(_appEnvironment.WebRootPath, "upload\\gallaryUp\\normalimage\\");
            var upload2 = Path.Combine(_appEnvironment.WebRootPath, "upload\\gallaryUp\\thumbnailimage\\");

            try
            {
                if (System.IO.File.Exists(upload + filename))
                {
                    System.IO.File.Delete(upload + filename);
                    System.IO.File.Delete(upload2 + filename);


                    _contex.fileManagerRepositoryUW.DeleteById(id);
                    await _contex.saveAsync();

                    return Json(new { status = "success", message = "فایل با موفقیت حذف شد" });
                }
             
                return Json(new { status = "fail2", message = "فایلی برای حذف پیدا نشد", imagenames = "" });
            }
            catch (Exception)
            {

                return Json(new { status = "fail2", message = "خطایی رخ داده است", imagenames = "" });
            }
        }


        [HttpGet]
        public IActionResult manager()
        {
            var files = _contex.fileManagerRepositoryUW.GetAllAsync().Result;
            return PartialView("_manager", files);
        }

    }
}