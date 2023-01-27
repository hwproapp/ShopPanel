using InsertShowImage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Services
{
    public class UploadFile : IUploadfile
    {
        private readonly IHostingEnvironment _appEnvironment;
        public UploadFile(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public string UploadFiles(IEnumerable<IFormFile> files,string uploadPath,string uploadthumbnailPath)
        {
            //"upload\\userimage\\normalimage\\"
            try
            {
               
                var upload = Path.Combine(_appEnvironment.WebRootPath, uploadPath);
                var filename = "";
                foreach (var file in files)
                {
                    filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                    using (var fs = new FileStream(Path.Combine(upload, filename), FileMode.Create))
                    {
                        file.CopyTo(fs);

                       
                    }
                }
                //"\\upload\\userimage\\thumbnailimage\\"
                /////////تغییر سایز عکس و ذخیره
                if (uploadthumbnailPath != "")
                {
                    ImageResizer img = new ImageResizer();
                    img.Resize(upload + filename, _appEnvironment.WebRootPath + uploadthumbnailPath + filename);

                    //Image myimg  = Image.FromFile(upload + filename);
                    //InsertShowImage.Resize.ResizeImage(myimg, 150, 150, _appEnvironment.WebRootPath + uploadthumbnailPath + filename);
                }
                return filename;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string UploadFilesGallary(IFormFile file, string uploadPath, string uploadthumbnailPath)
        {
            try
            {
                //"upload\\userimage\\normalimage\\"
                var upload = Path.Combine(_appEnvironment.WebRootPath, uploadPath);
                var filename = "";
                filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                using (var fs = new FileStream(Path.Combine(upload, filename), FileMode.Create))
                {
                    file.CopyTo(fs);

                }
                //"\\upload\\userimage\\thumbnailimage\\"
                /////////تغییر سایز عکس و ذخیره
                if (uploadthumbnailPath != "")
                {
                    ImageResizer img = new ImageResizer();
                    img.Resize(upload + filename, _appEnvironment.WebRootPath + uploadthumbnailPath + filename);
                }
                return filename;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public string UploadFilesSingle(IFormFile file, string uploadPath, string uploadthumbnailPath)
        {
            try
            {
                //"upload\\userimage\\normalimage\\"
                var upload = Path.Combine(_appEnvironment.WebRootPath, uploadPath);
                var filename = "";
                filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                using (var fs = new FileStream(Path.Combine(upload, filename), FileMode.Create))
                {
                    file.CopyTo(fs);

                }
                //"\\upload\\userimage\\thumbnailimage\\"
                /////////تغییر سایز عکس و ذخیره
                ///
                if (uploadthumbnailPath != "")
                {
                   ImageResizer img = new ImageResizer();
                    img.Resize(upload + filename, _appEnvironment.WebRootPath + uploadthumbnailPath + filename);
                }
                return filename;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
