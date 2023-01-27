using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.Models.ViewModels;
using newsSite90tv.PublicClass;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class ProductsizeController : Controller
    {
        private readonly IUnitOfWork _context;

        public ProductsizeController(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int paresh = (page - 1) * 10;
            int totalCount = await _context.SizeRepositoryUW.GetCountAsync(a => a.isEnable);
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
            var model = await _context.SizeRepositoryUW.GetWithSkipAsync(a => a.isEnable, null, "" , paresh, 10);
            return View(model);
        }





        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new ProductSizeViewModel();
            model.categories = await _context.CategoryRepositoryUW.GetManyAsync(a => a.isenable && a.type == 0);
            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Size size   , string catid)
        {
            try
            {
                if (ModelState.IsValid)
                {
                     size.isEnable = true;
                    _context.SizeRepositoryUW.Create(size);


                    await _context.saveAsync();

                    // size category 
                    if (!string.IsNullOrEmpty(catid))
                    {
                        var id = Utility.ParseJson<List<int>>(catid);
                        foreach (var catsid in id)
                        {
                            SizeCategory sizeCategory = new SizeCategory
                            {
                                cat_id = catsid,
                                size_id = size.Id
                            };

                            _context.SizeCategoryRepositoryUW.Create(sizeCategory);
                        }

                        await _context.saveAsync();
                    }


                    ViewBag.message = EndPointMessage.SUCCESS_MSG;
                    ViewBag.type = EndPointMessage.SUCCESS_TYPE;
                }
                else
                {


                    ViewBag.message = EndPointMessage.Value_MSG;
                    ViewBag.type = EndPointMessage.Value_TYPE;
                }

            }
            catch (Exception)
            {

                ViewBag.message = EndPointMessage.Fail_MSG;
                ViewBag.type = EndPointMessage.Fail_TYPE;
            }


            var model = new ProductSizeViewModel();
            model.categories = await _context.CategoryRepositoryUW.GetManyAsync(a => a.isenable && a.type == 0);
            model.size = size;
            return View(model);
           

        
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new SizeDetailViewModel();

             model.category = _context.SizeCategoryRepositoryUW.Get(a => a.size_id == id , null , "Tbl_Category").Select(a => a.Tbl_Category.Title);
             model.size = await _context.SizeRepositoryUW.GetByIdAsync(id);

             return View(model);
        }

        

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new ProductSizeEditViewModel();
            model.categories = await _context.CategoryRepositoryUW.GetManyAsync(a => a.isenable && a.type == 0);
            model.size = await _context.SizeRepositoryUW.GetByIdAsync(id);
            model.selectedid =  _context.SizeCategoryRepositoryUW.Get(a=>a.size_id == id).Select(a=>a.cat_id);
            return View(model);
        }



        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Size size , string catid)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  
                    _context.SizeRepositoryUW.Update(size);
                    
                    await _context.saveAsync();


                    // size category 
                    if (!string.IsNullOrEmpty(catid))
                    {
                        //delete prev size category 

                         var li =  _context.SizeCategoryRepositoryUW.Get(a => a.size_id == size.Id);
                        if (li != null && li.Count() != 0)
                        {
                            _context.SizeCategoryRepositoryUW.DeleteAll(li);
                            await _context.saveAsync();
                        }

                      

                        //recreate size category agan
                        var id = Utility.ParseJson<List<int>>(catid);
                        foreach (var catsid in id)
                        {
                            SizeCategory sizeCategory = new SizeCategory
                            {
                                cat_id = catsid,
                                size_id = size.Id
                            };

                            _context.SizeCategoryRepositoryUW.Create(sizeCategory);
                        }

                        await _context.saveAsync();
                    }



                    ViewBag.message = EndPointMessage.SUCCESS_Edit_MSG;
                    ViewBag.type = EndPointMessage.SUCCESS_Edit_TYPE;
                }
                else
                {


                    ViewBag.message = EndPointMessage.Value_MSG;
                    ViewBag.type = EndPointMessage.Value_TYPE;
                }

            }
            catch (Exception)
            {

                ViewBag.message = EndPointMessage.Fail_MSG;
                ViewBag.type = EndPointMessage.Fail_TYPE;
            }


            var model = new ProductSizeEditViewModel();
            model.categories = await _context.CategoryRepositoryUW.GetManyAsync(a => a.isenable && a.type == 0);
            model.selectedid = _context.SizeCategoryRepositoryUW.Get(a => a.size_id == size.Id).Select(a => a.cat_id);
            model.size = size;
            return View(model);
            
        }




        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model =await _context.SizeRepositoryUW.GetByIdAsync(id);
            return View(model);
        }




        [ActionName("Delete")]
        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfimed(int id)
        {
            try
            {
                 var model = await _context.SizeRepositoryUW.GetByIdAsync(id);

                 model.isEnable = false;

               
               // _context.SizeCategoryRepositoryUW.DeleteAll(_context.SizeCategoryRepositoryUW.Get(a => a.size_id == id));

                _context.SizeRepositoryUW.Update(model);

                await _context.saveAsync();
                
                TempData["message"] = EndPointMessage.DELETE_MSG;
                TempData["type"] = EndPointMessage.DELETE_TYPE;

              
            }
            catch (Exception)
            {
                TempData["message"] = EndPointMessage.Fail_MSG;
                TempData["type"] = EndPointMessage.Fail_TYPE; 
            }

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IEnumerable<object> GetSizeByCategory(int catid)
        {

            var model = _context.SizeCategoryRepositoryUW.Get(a => a.cat_id == catid ,null ,  "Tbl_Size").Select(a => new
            {
                id = a.size_id,
                name = a.Tbl_Size.name
            });


            return model;
        }
    }
}