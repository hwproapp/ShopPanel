using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Services
{
    public interface IReport
    {
        Task<AllApi> AddProductReport(ErrorReportApiModel model , string token);
        Task<AllApi> AddshopReport(ErrorReportApiModel model, string token);
        Task<ReportReasonListApiObject> GetReasonList(int type);
    }
}
