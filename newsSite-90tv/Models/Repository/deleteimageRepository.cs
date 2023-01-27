using Microsoft.AspNetCore.Hosting;
using newsSite90tv.Models.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Repository
{
    public class deleteimageRepository : Ideleteimage
    {

        private readonly IHostingEnvironment _hosting;

        public deleteimageRepository(IHostingEnvironment hosting)
        {
            _hosting = hosting;
        }



        public async Task<bool>  DeleteImageHost(string imagename , string path1 , string path2="" , string filter="")
        {

            try
            {

                if (string.IsNullOrEmpty(imagename))
                {
                    return false;
                }
                

                // normal image
                if (!string.IsNullOrEmpty(path1))
                {
                    var pathnormal = Path.Combine(_hosting.WebRootPath, path1);

                    if (File.Exists(pathnormal + imagename) &&  imagename != "nopicture.png")
                    {
                        File.Delete(pathnormal + imagename);
                    }
                }

                // thumbnail  image
                if (!string.IsNullOrEmpty(path2))
                {
                    var pathtumbnail = Path.Combine(_hosting.WebRootPath, path2);

                    if (File.Exists(pathtumbnail + imagename) && imagename != "nopicture.png")
                    {
                        File.Delete(pathtumbnail + imagename);
                    }
                }


                return true;

                

               
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
