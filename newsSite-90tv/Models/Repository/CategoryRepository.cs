using newsSite90tv.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using newsSite90tv.PublicClass;
using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.Models.apiobject;

namespace newsSite90tv.Models.Repository
{
    public class CategoryRepository  : ICategory
    {


        private readonly IUnitOfWork _context;


        public CategoryRepository(IUnitOfWork context  ) 
        {

            _context = context;
           
        }


        // get category contain product
        public async Task<CategoryObject> getproductcategory(int page)
        {
            var api = new CategoryObject();

            try
            {
                int paresh = (page - 1) * 10;


                api.categories =await _context.CategoryRepositoryUW.GetWithSkipAsync(a => a.isenable && a.type == categoryType.product.ToByte() && a.ParentId == 0 ,null , "" , paresh , 10);

                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;

            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }




        // get sub category contain product
        public async Task<CategoryObject> getsubcategory(int categoryId , int page)
        {
            var api = new CategoryObject();

            try
            {
                int paresh = (page - 1) * 10;


                api.categories = await _context.CategoryRepositoryUW.GetWithSkipAsync(a => a.isenable && a.type == categoryType.product.ToByte() && a.ParentId == categoryId, null, "", paresh, 10);

                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;
            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }



        // get shop category
        public async Task<CategoryObject> getshopcategory(int page)
        {
            var api = new CategoryObject();
            try
            {
                int paresh = (page - 1) * 10;


                api.categories = await _context.CategoryRepositoryUW.GetWithSkipAsync(a => a.isenable && a.type == categoryType.shop.ToByte(), null, "", paresh, 10);


                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;

            }
            catch
            {
                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }









        /*
         

        //get shop category

          public async Task<ShopcategoryApiObject> getshopcategory(int page)
        {
            var api = new ShopcategoryApiObject();
            try
            {
                int paresh = (page - 1) * 10;


                api.categories = await _db.CategoryRepositoryUW.GetWithSkipAsync(a => a.isenable && a.type == categoryType.shop.ToByte(), null, "", paresh, 10);


                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;

            }
            catch
            {
                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }




        // ge category based type with paging
        public async Task<CategoryObject> getcategory(int type , int page)
        {
            var api = new CategoryObject();

            try
            {
                int paresh = (page -1) * 10;


                api.categories = _context.Tbl_Category.Where(a => a.type == type && a.ParentId == 0 && a.isenable).Skip(paresh).Take(10).Select(a => new CategoryListApiModel
                {
                    type = a.type,
                    Title = a.Title,
                    ParentId = a.ParentId,
                    image = string.IsNullOrEmpty(a.image) ? "category.png": a.image,
                    Id = a.Id
                });

                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;

            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }

        

        //get job category

        public async Task<JobCategoryApiObject> getjobcategory(int page)
        {
            var api = new JobCategoryApiObject();
            try
            {
                int paresh = (page - 1) * 10;

                api.category = _context.Tbl_Category.Where(a => a.type == categoryType.service.ToByte() && a.isenable).Skip(paresh).Take(10).Select(a => new JobCategoryApiModel
                {
                    id = a.Id,
                    image = string.IsNullOrEmpty(a.image) ? "category.png" : a.image,
                    productcount = _context.Tbl_Banner.Where(b=>b.category_id == a.Id).Count(),
                    subid = a.ParentId,
                    title = a.Title ,
                    type = a.type
                    

                }).ToList();


                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;

            }
            catch
            {
                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }




       
        // get sub category of a category

        public async Task<CategoryApiObj> getsubcategory(int id)
        {
            var cat_obj = new CategoryApiObj();


            try
            {
                //int paresh = (page - 1) * 10;


                cat_obj.cat_list_of = _context.Tbl_Category.Where(a => a.ParentId == id).ToList().Select(a => new CategoryApiModel
                {
                    id = a.Id,
                    title = a.Title,
                    subid = a.ParentId,
                    type = a.type,

                    subcat = _context.Tbl_Category.Where(b => b.ParentId == a.Id).ToList().Select(b => new CategoryApiModel
                    {
                        id = b.Id,
                        title = b.Title,
                        subid = b.ParentId,
                        type = a.type,
                        subcat = new List<CategoryApiModel>()
                    }).ToList()


                }).ToList();

                cat_obj.message = EndPointMessage.API_OK_MSG;
                cat_obj.status = EndPointMessage.API_OK_Std;
            }
            catch
            {
                cat_obj.message = EndPointMessage.API_ERROR_MSG;
                cat_obj.status = EndPointMessage.API_ERROR_Std;

            }



            return cat_obj;






        }


        // get job vategory for banner add
        public async  Task<CategoryApiObject> GetJobCategory()
        {
            var api = new CategoryApiObject();

            try
            {

                api.jobcategory = _context.Tbl_Category.Where(a => a.type == categoryType.service.ToByte() && a.isenable).Select(a => new KeyValue
                {
                    id = a.Id,
                    title = a.Title

                });


                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;
            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }






        public class CategoryApiObj : AllApi
        {
            public List<CategoryApiModel> cat_list_of { get; set; }
        }

        



        public class CategoryApiModel
        {
            public int id { get; set; }
            public string title { get; set; }

            public int subid { get; set; }

            public int type { get; set; }

            public List<CategoryApiModel> subcat { get; set; }

        }





    */



    }
}
