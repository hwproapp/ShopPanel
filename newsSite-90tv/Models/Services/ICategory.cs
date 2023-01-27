using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static newsSite90tv.Models.Repository.CategoryRepository;

namespace newsSite90tv.Models.Services
{
    public interface ICategory
    {


        Task<CategoryObject> getproductcategory(int page);

        Task<CategoryObject> getsubcategory(int categoryid , int page);

        Task<CategoryObject> getshopcategory(int page);


        /*
        Task<JobCategoryApiObject> getjobcategory(int page);
        Task<ShopcategoryApiObject> getshopcategory(int page);

        Task<CategoryObject> getcategory(int type , int page);
       
        Task<CategoryApiObj> getsubcategory(int id);
        Task<CategoryApiObject> GetJobCategory();

       */






    }

}
