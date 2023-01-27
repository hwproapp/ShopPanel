using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models.ExtraClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Services
{
    public   interface IExcelUtil
    {
        Task<FileStreamResult> CreateExcel(List<PayaModel> model);
    }
}
