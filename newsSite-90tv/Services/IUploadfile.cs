using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Services
{
    public interface IUploadfile
    {
        string UploadFiles(IEnumerable<IFormFile> files, string uploadPath, string uploadthumbnailPath);

        string UploadFilesGallary(IFormFile files, string uploadPath, string uploadthumbnailPath);
        string UploadFilesSingle(IFormFile files, string uploadPath, string uploadthumbnailPath);
    }
}
