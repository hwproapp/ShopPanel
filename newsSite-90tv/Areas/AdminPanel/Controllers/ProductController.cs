using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.Models.ViewModels;
using newsSite90tv.PublicClass;
using newsSite90tv.Services;
using Newtonsoft.Json;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IUploadfile _uploadfile;
        private readonly IsearchResult _searchResult;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly Ideleteimage _ideleteimage;
        public ProductController(IUnitOfWork context, IUploadfile uploadfile, UserManager<ApplicationUsers> usermanager, IsearchResult searchResult, IHostingEnvironment environment , Ideleteimage ideleteimage)
        {
            _context = context;
            _uploadfile = uploadfile;
            _userManager = usermanager;
            _searchResult = searchResult;
            _appEnvironment = environment;
            _ideleteimage = ideleteimage;
        }


        public async Task<IActionResult> Index(int page = 1)
        {
            
            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها

            int totalCount = await _context.productRepositoryUW.GetCountAsync(a=>a.enable);

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
            
            var model = await _context.productRepositoryUW.GetWithSkipAsync(a => a.enable, a => a.OrderByDescending(b => b.status == Status.suspend.ToByte()),"",paresh , 10);

            ViewBag.ViewTitle = "محصولات";
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.ViewTitle = "فرم ایجاد محصول";

            var model = new CreateproductViewModel();

            model.brands = await _context.productBrandRepositoryUW.GetManyAsync(a=>a.isenable);
            model.categories = await _context.CategoryRepositoryUW.GetManyAsync(a => a.type == categoryType.product.ToByte() && a.isenable);
            model.colors = await _context.colorRepositoryUW.GetManyAsync(a=>a.isenable);
            model.shops = await _context.shopRepositoryUW.GetManyAsync(a=>a.enable && a.status == 1);

        
            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, string colors, string propids, string propvals , string sizes, string imagename  , IEnumerable<IFormFile> images )
        {


            if (ModelState.IsValid)
            {
                try
                {

                   
                    product.User_id = _userManager.GetUserId(User);
                    product.enable = true;
                    product.status = 1; // valid
                    product.likeCount = 0;
                    product.viewCount = 0;
                    product.image = string.IsNullOrEmpty(imagename) ? "nopicture.png" : imagename;
                    product.code = Utility.Generatecode();
                    product.seller_id = _context.shopRepositoryUW.GetById(product.shop_id).seller_id;
                    product.isexist = product.qty != 0;

                    product.garanty = string.IsNullOrEmpty(product.garanty) ? "ندارد" : product.garanty;
                    



                    _context.productRepositoryUW.Create(product);
                    await _context.saveAsync();

                    

                    // product colors
                    if (!string.IsNullOrEmpty(colors))
                    {
                        
                        var mycolors = Utility.ParseJson<List<int>>(colors);

                        for (int i = 0; i < mycolors.Count; i++)
                        {
                            ProductColor pc = new ProductColor
                            {
                                product_id = product.Id,
                                color_id = mycolors[i]
                            };

                            _context.ProductColorUW.Create(pc);
                        }

                        await _context.saveAsync();
                    }


                    // product size
                    if (!string.IsNullOrEmpty(sizes))
                    {

                        var mysize = Utility.ParseJson<List<int>>(sizes);

                        for (int i = 0; i < mysize.Count; i++)
                        {
                            ProductSize ps = new ProductSize
                            {
                                product_id = product.Id,
                                size_id = mysize[i]
                               
                            };

                            _context.ProductSizeRepositoryUW.Create(ps);
                        }

                        await _context.saveAsync();
                    }




                    // product property

                    if (!string.IsNullOrEmpty(propids))
                    {
                        

                        var ids = Utility.ParseJson<List<int>>(propids);
                        var vals = Utility.ParseJson<List<string>>(propvals);
                        
                        for (int i = 0; i < ids.Count(); i++)
                        {
                            ProdProp pp = new ProdProp
                            {
                                product_id = product.Id,
                                property_id = ids[i].ToInt(),

                                value = vals[i]

                            };

                            _context.ProductPropRepositoryUW.Create(pp);
                            
                        }

                        await _context.saveAsync();
                    }




                    //product  gallary image
                    if (images.Count() != 0)
                    {
                        foreach (var item in images)
                        {
                            var path = _uploadfile.UploadFilesSingle(item, "upload\\gallaryUp\\normalimage\\", "");

                            ProductGallary productGallary = new ProductGallary
                            {
                                product_id = product.Id,
                                imagepath = path
                            };

                            _context.ProductGallaryUW.Create(productGallary);
                        }

                        await _context.saveAsync();
                    }
                    
                    ViewBag.message = EndPointMessage.SUCCESS_MSG;
                    ViewBag.type = EndPointMessage.SUCCESS_TYPE;
                    
                }
                catch (Exception )
                {

                    ViewBag.message = EndPointMessage.Fail_MSG;
                    ViewBag.type = EndPointMessage.Fail_TYPE;
                }
            }
            else
            {
                ViewBag.message = EndPointMessage.Value_MSG;
                ViewBag.type = EndPointMessage.Value_TYPE;

            }

            //........
            var model = new CreateproductViewModel();

            model.brands = await _context.productBrandRepositoryUW.GetManyAsync(a => a.isenable);
            model.categories = await _context.CategoryRepositoryUW.GetManyAsync(a => a.type == categoryType.product.ToByte() && a.isenable);
            model.colors = await _context.colorRepositoryUW.GetManyAsync(a => a.isenable);
            model.shops = await _context.shopRepositoryUW.GetManyAsync(a => a.enable && a.status == 1);
            model.product = product;

            ViewBag.ViewTitle = "فرم ایجاد محصول";

            return View(model);
        }

        

        [HttpGet]
        public async  Task<IActionResult> Edit(long id)
        {

            var model = new EditproductViewModel();

            model.brands = await _context.productBrandRepositoryUW.GetManyAsync(a => a.isenable);
            model.categories =await _context.CategoryRepositoryUW.GetManyAsync(a => a.type == categoryType.product.ToByte() && a.isenable);
            model.productGallaries =await _context.ProductGallaryUW.GetManyAsync(a=> a.product_id == id);
            model.product = _context.productRepositoryUW.GetById(id);
            model.shops = await _context.shopRepositoryUW.GetManyAsync(a => a.enable && a.status == 1);
            model.coloridselect =  _context.ProductColorUW.Get(a=>a.product_id == id).Select(a=>a.color_id);
            model.colors = await _context.colorRepositoryUW.GetManyAsync(a => a.isenable);
            model.productsize = _context.ProductSizeRepositoryUW.Get(a => a.product_id == id , null , "Tbl_Size").Select(a => a.Tbl_Size);
           

            model.productproperty = _context.ProductPropRepositoryUW.Get(a => a.product_id == id, null , "Tbl_Property").Select(a => new propertyviewmodel
            {
                propertyid = a.property_id,
                name = a.Tbl_Property.name,
                value = a.value
            });


            return View(model);
            

        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product, IEnumerable<IFormFile> images, string propids, string colors,string sizes, string propvals, string imagename , string trashimages)
        {
            if (ModelState.IsValid)
            {
                try
                {
                  
                    if (!string.IsNullOrEmpty(imagename))
                    {
                        if (!string.IsNullOrEmpty(product.image))
                        {
                           await _ideleteimage.DeleteImageHost(product.image, "upload\\products\\normalimage\\", "upload\\products\\thumbnailimage\\", "nopicture.png");
                        }

                        product.image = imagename;
                    }



                    product.garanty = string.IsNullOrEmpty(product.garanty) ? "ندارد" : product.garanty;
                    product.isexist = product.qty != 0;
                    product.seller_id = _context.shopRepositoryUW.GetById(product.shop_id).seller_id;

                    _context.productRepositoryUW.Update(product);
                    await _context.saveAsync();


                    // product size
                    if (!string.IsNullOrEmpty(sizes))
                    {
                        //delete prev size category 

                        var li = _context.ProductSizeRepositoryUW.Get(a => a.product_id == product.Id);
                        if (li != null && li.Count() != 0)
                        {
                            _context.ProductSizeRepositoryUW.DeleteAll(li);
                             await _context.saveAsync();
                        }

                        //recreate 
                        var mysize = Utility.ParseJson<List<int>>(sizes);

                        for (int i = 0; i < mysize.Count; i++)
                        {
                            ProductSize pc = new ProductSize
                            {
                                product_id = product.Id,
                                size_id = mysize[i]

                            };

                            _context.ProductSizeRepositoryUW.Create(pc);
                        }

                        await _context.saveAsync();
                    }


                    // product colors
                    if (!string.IsNullOrEmpty(colors))
                    {
                        // before i delete prev colors of product

                        var prcolor = _context.ProductColorUW.Get(a => a.product_id == product.Id);

                        if (prcolor != null && prcolor.Count() != 0)
                        {
                            _context.ProductColorUW.DeleteAll(prcolor);
                            await _context.saveAsync();
                        }

                        // new colors add again
                        var mycolors = Utility.ParseJson<List<int>>(colors);

                        for (int i = 0; i < mycolors.Count; i++)
                        {
                            ProductColor pc = new ProductColor
                            {
                                product_id = product.Id,
                                color_id = mycolors[i]
                            };

                            _context.ProductColorUW.Create(pc);
                        }

                        await _context.saveAsync();
                    }

                    

                    //product gallary images
                    if (images.Count() != 0)
                    {
                        foreach (var item in images)
                        {
                            var path = _uploadfile.UploadFilesSingle(item, "upload\\gallaryUp\\normalimage\\", "");

                            ProductGallary productGallary = new ProductGallary
                            {
                                
                                product_id = product.Id,
                                imagepath = path
                            };

                            _context.ProductGallaryUW.Create(productGallary);
                        }

                        await _context.saveAsync();
                    }


                    //delete product image of needed
                    //....trash image 

                    if (!string.IsNullOrEmpty(trashimages))
                    {
                        var idarr = Utility.ParseJson<List<long>>(trashimages);

                        foreach (var id in idarr)
                        {
                            var glimage = await _context.ProductGallaryUW.GetByIdAsync(id);

                            // delete from db
                            _context.ProductGallaryUW.Delete(glimage);
                            

                            // delete from host
                           await _ideleteimage.DeleteImageHost(glimage.imagepath , "upload\\gallaryUp\\normalimage\\" , "");
                        }

                        await _context.saveAsync();

                    }

                    
                    //product property
                    if (!string.IsNullOrEmpty(propids))
                    {

                         var props = _context.ProductPropRepositoryUW.Get(a => a.product_id == product.Id);

                        if (props!= null && props.Count() !=0 )
                        {
                            _context.ProductPropRepositoryUW.DeleteAll(props);
                            await _context.saveAsync();

                        }
                        

                        var ids = Utility.ParseJson<List<int>>(propids);
                        var vals = Utility.ParseJson<List<string>>(propvals);

                        for (int i = 0; i < ids.Count; i++)
                        {
                            ProdProp pp = new ProdProp
                            {
                                product_id = product.Id,
                                property_id = ids[i],
                                value = vals[i],

                            };

                            _context.ProductPropRepositoryUW.Create(pp);
                           

                        }

                        await _context.saveAsync();
                    }


                    ViewBag.message = EndPointMessage.SUCCESS_Edit_MSG;
                    ViewBag.type = EndPointMessage.SUCCESS_Edit_TYPE;



                   
                }
                catch(Exception)
                {

                    ViewBag.message = EndPointMessage.Fail_MSG;
                    ViewBag.type = EndPointMessage.Fail_TYPE;
                }

            }
            else
            {
                ViewBag.message = EndPointMessage.Value_MSG;
                ViewBag.type = EndPointMessage.Value_TYPE;
            }


            


            var model = new EditproductViewModel();
            
            model.brands =await  _context.productBrandRepositoryUW.GetManyAsync(a=>a.isenable);
            model.categories = await _context.CategoryRepositoryUW.GetManyAsync(a => a.type == 0 && a.isenable);
            model.productGallaries = await _context.ProductGallaryUW.GetManyAsync(a => a.product_id == product.Id);
            model.product = product;
            model.coloridselect = _context.ProductColorUW.Get(a => a.product_id == product.Id).Select(a => a.color_id);
            model.shops = await _context.shopRepositoryUW.GetManyAsync(a => a.enable && a.status == 1);
            model.colors = await _context.colorRepositoryUW.GetManyAsync(a => a.isenable);
            model.productsize = _context.ProductSizeRepositoryUW.Get(a => a.product_id == product.Id, null, "Tbl_Size").Select(a => a.Tbl_Size);


            model.productproperty = _context.ProductPropRepositoryUW.Get(a => a.product_id == product.Id, null, "Tbl_Property").Select(a => new propertyviewmodel
            {
                propertyid = a.property_id,
                name = a.Tbl_Property.name,
                value = a.value
            });
            
            return View(model);
        }



        [HttpGet]

        public async Task<IActionResult> Details(long id)
        {

            ViewBag.ViewTitle = "جزییات  محصول";

            var model = new productDetailViewModel();

            model.productProperties =  _context.ProductPropertiesRepositoryUW.Get(a => a.product_id == id, null, "Tbl_PropertiesValue,Tbl_Properties");

            model.product =await _context.productRepositoryUW.GetAsync(a=>a.Id == id , "Tbl_Category,Tbl_Shop,brand");

            model.productColor = _context.ProductColorUW.Get(a => a.product_id  == id , null , "Tbl_color").Select(a => a.Tbl_color.code);

            model.productSize = _context.ProductSizeRepositoryUW.Get(a => a.product_id == id, null , "Tbl_Size").Select(a => a.Tbl_Size.name);


            return View(model);
        }





        public IActionResult UploadFile(IEnumerable<IFormFile> files)
        {
            //"upload\\userimage\\normalimage\\"
            //"\\upload\\userimage\\thumbnailimage\\"
            string filename = _uploadfile.UploadFiles(files, "upload\\products\\normalimage\\", "\\upload\\products\\thumbnailimage\\");
            return Json(new { status = "success", message = "تصویر با موفقیت آپلود شد.", imagename = filename });

        }


        public async Task<IActionResult> changestatus(long id, byte state = 2)
        {
           
            try
            {
                var product = await _context.productRepositoryUW.GetByIdAsync(id);
                product.status = state;
                _context.productRepositoryUW.Update(product);

                await _context.saveAsync();


                TempData["message"] = EndPointMessage.DONE_MSG;
                TempData["type"] = EndPointMessage.DONE_TYPE;
            }
            catch (Exception)
            {

                TempData["message"] = EndPointMessage.Fail_MSG;
                TempData["type"] = EndPointMessage.Fail_TYPE;
            }


            return RedirectToAction(nameof(Index));

        }




        [HttpGet]
        public async Task<IActionResult> productGallary(long id)
        {
            var model =await _context.ProductGallaryUW.GetManyAsync(a => a.product_id == id);
            return PartialView("_productGallary", model);


        }




        [HttpGet]
        public IActionResult Delete(long id)
        {
            var model = _context.productRepositoryUW.GetById(id);

            return View(model);
        }


        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfimed(long id)
        {

            try
            {

                var product = await _context.productRepositoryUW.GetByIdAsync(id);

                product.enable = false;


                _context.productRepositoryUW.Update(product);

                await _context.saveAsync();


               

                await _ideleteimage.DeleteImageHost(product.image, "upload\\products\\normalimage\\", "upload\\products\\thumbnailimage\\" , "nopicture.png");

                var productgallary = await _context.ProductGallaryUW.GetManyAsync(a => a.product_id == id);

                foreach (var productGallary in productgallary)
                {
                    await _ideleteimage.DeleteImageHost(productGallary.imagepath, "upload\\gallaryUp\\normalimage\\", "", "nopicture.png");

                    _context.ProductGallaryUW.Delete(productGallary);

                }

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
        public IActionResult searchBox()
        {
            return PartialView("_searchBox");
        }


        [HttpGet]
        public IActionResult searchResult(string q, byte order, int page = 1)
        {

            ViewBag.q = q;
            ViewBag.order = order;
            ViewBag.PageID = page;


            var sres = _searchResult.SearchResProd(order, q, page, Convert.ToByte(pagingTake.ten));


            //ICollection key = sres.Result.Keys;


            var model = (IEnumerable<Product>)sres["prod"];

            int totalCount = (int)sres["count"];

            double remain = totalCount % 10;

            if (remain == 0)
            {
                ViewBag.PageCount = totalCount / 10;
            }
            else
            {
                ViewBag.PageCount = (totalCount / 10) + 1;
            }



            return View(model);
        }




        [HttpPost]
        public string searchtypeList(int mode)
        {
            object model = null;



            switch (mode)
            {
                case 0:
                    //category
                    model = _context.CategoryRepositoryUW.Get();
                    break;

                case 1:
                    //seller
                    model = _context.salsmanRepositoryUW.Get();
                    break;

                case 2:
                    //shop
                    model = _context.shopRepositoryUW.Get();
                    break;
                default:
                    break;
            }

            return JsonConvert.SerializeObject(model);

        }




    }
}