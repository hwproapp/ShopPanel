using InsertShowImage;
using Microsoft.AspNetCore.Hosting;
using newsSite90tv.Models.Services;
using newsSite90tv.PublicClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Repository
{
    public class saveImageRepository : IsaveImage
    {
        private readonly IHostingEnvironment _hosting;

        public saveImageRepository(IHostingEnvironment hosting)
        {
            _hosting = hosting;
        }

        public async Task<bool> DelProductGallaryImages(List<string> names)
        {

            try
            {
                var path = Path.Combine(_hosting.WebRootPath, "upload\\gallaryUp\\normalimage\\");

                for (int i = 0; i < names.Count; i++)
                {
                    string mainPath = Path.Combine(path, names[i]);
                    if (File.Exists(mainPath))
                    {
                        File.Delete(mainPath);
                    }
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }



        public async Task<string> SaveProductGallaryImages(string image)
        {
            string imagename = "nopicture.png";

            if (!string.IsNullOrEmpty(image))
            {

                try
                {
                    var path = Path.Combine(_hosting.WebRootPath, "upload\\gallaryUp\\normalimage\\");

                    byte[] imagebytearr = Convert.FromBase64String(image);

                    imagename = Utility.GenerateImageName() + ".jpg";

                    using (MemoryStream ms = new MemoryStream(imagebytearr))
                    {
                        using (FileStream fs = new FileStream(Path.Combine(path, imagename), FileMode.Create))
                        {
                            ms.WriteTo(fs);
                        }
                    }


                }
                catch (Exception)
                {

                    imagename = "nopicture.png";
                }

            }
            else
            {
                imagename = "nopicture.png";
            }

            return imagename;

        }



        public async Task<string> SaveProductIndexImage(string image)
        {
            string imagename = "nopicture.png";

            if (!string.IsNullOrEmpty(image))
            {
                try
                {

                    byte[] imagebytearray = Convert.FromBase64String(image);

                    imagename = Utility.GenerateImageName() + ".jpg";


                    var path = Path.Combine(_hosting.WebRootPath, "upload\\products\\normalimage\\");

                    var pathtumbnail = Path.Combine(_hosting.WebRootPath, "upload\\products\\thumbnailimage\\");

                    using (MemoryStream ms = new MemoryStream(imagebytearray))
                    {
                        using (FileStream fs = new FileStream(Path.Combine(path, imagename), FileMode.Create))
                        {
                            ms.WriteTo(fs);
                        }
                    }



                    //save image shape of thumbnail 

                    ImageResizer img = new ImageResizer();

                    img.Resize(Path.Combine(path, imagename), Path.Combine(_hosting.WebRootPath, pathtumbnail + imagename));




                }
                catch (Exception)
                {
                    // error happen set defult image 

                    imagename = "nopicture.png";
                }
            }
            else
            {
                imagename = "nopicture.png";
            }

            return imagename;
        }



        public async Task<string> SaveShopIndexImage(byte[] image)
        {
            try
            {
                var imagename = Utility.GenerateImageName() + ".jpg";


                var path = Path.Combine(_hosting.WebRootPath, "upload\\shop\\normalimage\\");

                var pathtum = Path.Combine(_hosting.WebRootPath, "upload\\shop\\thumbnailimage\\");

                using (MemoryStream ms = new MemoryStream(image))
                {
                    using (FileStream fs = new FileStream(Path.Combine(path, imagename), FileMode.Create))
                    {
                        ms.WriteTo(fs);
                    }
                }

                Image myimg = Image.FromFile(path + imagename);
                InsertShowImage.Resize.ResizeImage(myimg, 150, 150, Path.Combine(pathtum, imagename));

                return imagename;

            }
            catch (Exception)
            {

                return string.Empty;
            }
        }


        public async Task<bool> DelShopIndexImage(string name)
        {
            try
            {
                var path = Path.Combine(_hosting.WebRootPath, "upload\\shop\\normalimage\\");

                var pathtum = Path.Combine(_hosting.WebRootPath, "upload\\shop\\thumbnailimage\\");

                string mainPath = Path.Combine(path, name);
                string thumpath = Path.Combine(pathtum, name);


                if (File.Exists(mainPath))
                {
                    File.Delete(mainPath);
                    File.Delete(thumpath);
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> SaveAdvShopImage(byte[] image)
        {
            try
            {
                var imagename = Utility.GenerateImageName() + ".jpg";


                var path = Path.Combine(_hosting.WebRootPath, "upload\\advImage\\");



                using (MemoryStream ms = new MemoryStream(image))
                {
                    using (FileStream fs = new FileStream(Path.Combine(path, imagename), FileMode.Create))
                    {
                        ms.WriteTo(fs);
                    }
                }


                return imagename;

            }
            catch (Exception)
            {

                return string.Empty;
            }
        }


        public async Task<string> SaveJobBannerImage(byte[] image)
        {
            try
            {
                var imagename = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";


                var path = Path.Combine(_hosting.WebRootPath, "upload\\banners\\normalimage");



                using (MemoryStream ms = new MemoryStream(image))
                {
                    using (FileStream fs = new FileStream(Path.Combine(path, imagename), FileMode.Create))
                    {
                        ms.WriteTo(fs);
                    }
                }


                return imagename;

            }
            catch (Exception)
            {

                return string.Empty;
            }
        }


        public async Task<string> SaveUserAppImage(string oldimage, byte[] newimage)
        {
            try
            {
                var imagename = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";


                var path = Path.Combine(_hosting.WebRootPath, "upload\\userAppimage\\normalimage");
                var paththumb = Path.Combine(_hosting.WebRootPath, "upload\\userAppimage\\thumbnailimage");



                using (MemoryStream ms = new MemoryStream(newimage))
                {
                    using (FileStream fs = new FileStream(Path.Combine(path, imagename), FileMode.Create))
                    {
                        ms.WriteTo(fs);
                    }


                }

                // save thumb image to host
                ImageResizer img = new ImageResizer();
                img.Resize(Path.Combine(path, imagename), Path.Combine(paththumb, imagename));

                // delete old image

                if (File.Exists(Path.Combine(path, oldimage)))
                {
                    File.Delete(Path.Combine(path, imagename));
                    File.Delete(Path.Combine(paththumb, imagename));
                }


                return imagename;

            }
            catch (Exception)
            {

                return string.Empty;
            }
        }



        public void DeleteImageHost(string imagename, string path1, string path2 = "")
        {

            try
            {

                if (string.IsNullOrEmpty(imagename))
                {
                    return;
                }


                // normal image
                if (!string.IsNullOrEmpty(path1))
                {
                    var pathnormal = Path.Combine(_hosting.WebRootPath, path1);


                    if (File.Exists(pathnormal + imagename))
                    {
                        File.Delete(pathnormal + imagename);
                    }
                }

                // thumnail  image
                if (!string.IsNullOrEmpty(path2))
                {
                    var pathtumbnail = Path.Combine(_hosting.WebRootPath, path2);
                    if (File.Exists(pathtumbnail + imagename))
                    {
                        File.Delete(pathtumbnail + imagename);
                    }
                }




            }
            catch (Exception)
            {

                return;
            }
        }
    }
}
