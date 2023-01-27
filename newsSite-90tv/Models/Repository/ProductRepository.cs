
using newsSite90tv.Controllers.api;
using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWork _db;

        private readonly IsaveImage _isv;

        private readonly Ideleteimage _ideleteimage;


        private readonly IAthenticate _athenticate;
        public ProductRepository(ApplicationDbContext context, IsaveImage isv,
                                    IUnitOfWork db, Iuseraddress userapp,
                                    IAthenticate athenticate, Ideleteimage ideleteimage)
        {

            _context = context;


            _db = db;

            _isv = isv;


            _ideleteimage = ideleteimage;

            _athenticate = athenticate;

        }
        // offer product 
        public async Task<ProductOfferObject> homeapi()
        {
            var api = new ProductOfferObject();

            try
            {

                // off 
                api.offerproducts = _db.productRepositoryUW.Get(a => a.status == Status.valid.ToByte() && a.enable, null, "Tbl_Shop").Take(10).Select(a => new ProductOfferModel
                {
                    Id = a.Id,
                    offpercent = a.offpercent,
                    image = a.image,
                    price = a.price,
                    shopid = a.shop_id,
                    shopname = a.Tbl_Shop.title,
                    title = a.title,
                    summary = a.summary


                });


                // new
                api.newestproducts = _db.productRepositoryUW.Get(a => a.status == 1 && a.enable , a=>a.OrderByDescending(s=>s.dateMiladi)).Take(10).Select(a => new ProductModel
                {

                    Id = a.Id,
                    image = a.image,
                    offpercent = a.offpercent,
                    price = a.price,
                    title = a.title
                });


                // top like
                api.toplikeproducts = _db.productRepositoryUW.Get(a => a.status == 1 && a.enable, a => a.OrderByDescending(s => s.likeCount)).Take(10).Select(a => new ProductModel
                {

                    Id = a.Id,
                    image = a.image,
                    offpercent = a.offpercent,
                    price = a.price,
                    title = a.title
                });


                // top view

                api.topviewproducts = _db.productRepositoryUW.Get(a => a.status == 1 && a.enable, a => a.OrderByDescending(s => s.viewCount)).Take(10).Select(a => new ProductModel
                {

                    Id = a.Id,
                    image = a.image,
                    offpercent = a.offpercent,
                    price = a.price,
                    title = a.title
                });


                // top sell

                // write it later
                api.topsellproducts = _db.productRepositoryUW.Get(a => a.status == 1 && a.enable).Take(10).Select(a => new ProductModel
                {

                    Id = a.Id,
                    image = a.image,
                    offpercent = a.offpercent,
                    price = a.price,
                    title = a.title

                });



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



        // get ostan
        public async Task<OstanApiModel> getostan()
        {
            var api = new OstanApiModel();

            try
            {
                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;

                api.ostans = await _db.ostanRepositoryUW.GetAllAsync();
            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }


        // get city 

        public async Task<CityApiModel> getcity(int id)
        {
            var api = new CityApiModel();

            try
            {
                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;


                api.city = await _db.cityRepositoryUW.GetManyAsync(a => a.ostan_id == id);

            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }


            return api;
        }


        // get size by category
        public async Task<SizeApiObject> getsizebycategory(int categoryid)
        {
            var api = new SizeApiObject();

            try
            {
                api.sizes = _db.SizeCategoryRepositoryUW.Get(a => a.cat_id == categoryid, null, "Tbl_Size").Where(a => a.Tbl_Size.isEnable).Select(s => s.Tbl_Size);

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



        // get all city
        public async Task<CityApiModel> getallcity(int page)
        {
            var api = new CityApiModel();

            try
            {
                int paresh = (page - 1) * 10;

                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;


                api.city = _db.cityRepositoryUW.Get().Skip(paresh).Take(20);

            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }


            return api;
        }




        // get city by name

        public async Task<CityApiModel> getcitybyname(string title)
        {
            var api = new CityApiModel();

            try
            {


                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;


                api.city = await _db.cityRepositoryUW.GetManyAsync(a => a.title.Contains(title) || a.title == title);

            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }


            return api;
        }



        // get prev product factor 
        public async Task<FactorProductApiObject> getfactorproduct(long price)
        {
            var api = new FactorProductApiObject();

            try
            {
                // get wage of app

                var model = await _db.AppsettingRepositoryUW.GetSingleAsync();


                // get price with wage
                var newprice = price.getpricewithwage(model.wage);


                var tariff = price - newprice;
                var tax = 0;
                var sellerShare = newprice;


                FactorProductApiModel factorProduct = new FactorProductApiModel
                {
                    tariff = tariff,
                    sellerShare = sellerShare,
                    tax = tax
                };


                api.factorProduct = factorProduct;



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



        // get product detail

        public async Task<ProductDetailObject> productdetail(long id)
        {
            var model = new ProductDetailObject();

            try
            {

                var product = await _db.productRepositoryUW.GetAsync(a=>a.Id == id && a.status  == Status.valid.ToByte() && a.enable);

                product.viewCount++;

                _db.productRepositoryUW.Update(product);

                await _context.SaveChangesAsync();

                // product detail

                model.productDetail = new ProductDetailModel
                {
                    id = product.Id,
                    isexist = product.isexist,
                    offpercent = product.offpercent,
                    price = product.price,
                    shopid = product.shop_id,
                    shopname = _db.shopRepositoryUW.GetById(product.shop_id).title,
                    title = product.title,
                    brand = _db.productBrandRepositoryUW.GetById(product.brand_id).name,
                    cat = _db.CategoryRepositoryUW.GetById(product.cat_id).Title,
                    desc = product.desc,
                    image = product.image,
                    likecount = product.likeCount,
                    viewcount = product.viewCount,
                    garanty = product.garanty,
                    summary   = product.summary
                    

                };

                //product images 
                model.productgallary = _db.ProductGallaryUW.Get(a => a.product_id == id).Select(a => a.imagepath);



                //product colors
                model.productcolors = _db.ProductColorUW.Get(a => a.product_id == id, null, "Tbl_color").Select(a => a.Tbl_color);



                //product size
                model.productsize = _db.ProductSizeRepositoryUW.Get(a => a.product_id == id, null, "Tbl_Size").Select(a => new ProductSizeApiModel
                {
                    Id = a.Id,
                    name = a.Tbl_Size.name
                });



                //product comment
                model.productcomment = _db.commentRepositoryUW.Get(a => a.status == 1 && a.isEnable && a.product_id == id, a => a.OrderByDescending(o => o.dateMiladi), "Tbl_UserApp").Take(5).Select(a => new CommentApiModel
                {
                    id = a.Id,
                    title = a.title,
                    fullname = a.Tbl_UserApp.firstName + " " + a.Tbl_UserApp.lastName,
                    msg = a.body,
                    userimage = a.Tbl_UserApp.image
                });




                // product same
                model.sameproduct = _db.productRepositoryUW.Get(a => a.enable && a.status == 1 && a.Id != id && a.cat_id == product.cat_id, null, "Tbl_Shop,brand,Tbl_Category").TakeLast(10).Select(a => new SameProductListApiModel
                {
                    productid = a.Id,
                    brand = a.brand.name,
                    isexist = a.isexist,
                    likecount = a.likeCount,
                    offpercent = a.offpercent,
                    price = a.price,
                    viewcount = a.viewCount,
                    shopname = a.Tbl_Shop.title,
                    title = a.title,
                    image = a.image,
                  

                });



                // product property

                model.productproperty = _db.ProductPropertiesRepositoryUW.Get(a => a.product_id == id , null , "Tbl_PropertiesValue,Tbl_Properties").Select(a => new ProductPropertyListApiModel
                {
                    name = a.Tbl_Properties.name,
                    value = a.Tbl_PropertiesValue.value

                });




                model.message = EndPointMessage.API_OK_MSG;
                model.status = EndPointMessage.API_OK_Std;


            }
            catch (Exception)
            {

                model.message = EndPointMessage.API_ERROR_MSG;
                model.status = EndPointMessage.API_ERROR_Std;
            }

            return model;

        }







        // add product get 

        public async Task<CreateProductGetApiObject> createproductget()
        {
            var api = new CreateProductGetApiObject();

            try
            {
                api.colors = await _db.colorRepositoryUW.GetManyAsync(a => a.isenable);
                api.brands = await _db.productBrandRepositoryUW.GetManyAsync(a => a.isenable);
                api.categories = await _db.CategoryRepositoryUW.GetManyAsync(a => a.isenable && a.type == categoryType.product.ToByte());

                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;
            }
            catch (Exception)
            {

                api.status = EndPointMessage.API_ERROR_Std;
                api.message = EndPointMessage.API_OK_MSG;
            }

            return api;
        }



        // add new product post
        public async Task<AllApi> createproductpost(ProductCreateModel model, string token)
        {
            var api = new AllApi();

            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {

                    var newproduct = new Product
                    {

                        title = model.title,
                        summary = model.summary,
                        desc = model.desc,
                        cat_id = model.categoryId,
                        brand_id = model.brandId,
                        qty = model.qty,
                        isexist = model.qty >= 0,
                        keyword = "",
                        code = Utility.Generatecode(),
                        enable = true,
                        status = Status.suspend.ToByte(),
                        offpercent = model.offpercent,
                        price = model.price,
                        garanty = model.garanty,
                        ispublish = true,
                        weight = model.weight,
                        shop_id = model.shopId,
                        viewCount = 0,
                        likeCount = 0,
                        seller_id = _db.shopRepositoryUW.GetById(model.shopId).seller_id,
                        image = await _isv.SaveProductIndexImage(model.indexImage),

                    };


                    _db.productRepositoryUW.Create(newproduct);

                    await _db.saveAsync();

                    //check product color 

                    if (!string.IsNullOrEmpty(model.colorId))
                    {
                        string[] colorids = model.colorId.Split(',');

                        for (int i = 0; i < colorids.Length - 1; i++)
                        {
                            int color_id = int.Parse(colorids[i]);

                            ProductColor productColor = new ProductColor
                            {
                                color_id = color_id,
                                product_id = newproduct.Id
                            };


                            _db.ProductColorUW.Create(productColor);
                        }


                        await _db.saveAsync();
                    }


                    //check product size

                    if (!string.IsNullOrEmpty(model.sizeId))
                    {
                        string[] sizeIds = model.sizeId.Split(',');

                        for (int i = 0; i < sizeIds.Length - 1; i++)
                        {
                            int size_id = int.Parse(sizeIds[i]);

                            ProductSize productSize = new ProductSize
                            {
                                size_id = size_id,
                                product_id = newproduct.Id
                            };


                            _db.ProductSizeRepositoryUW.Create(productSize);
                        }


                        await _db.saveAsync();
                    }



                    //check product property

                    if (!string.IsNullOrEmpty(model.propertyId))
                    {
                        string[] propertyIds = model.propertyId.Split(',');

                        for (int i = 0; i < propertyIds.Length - 1; i++)
                        {
                            int propertyvalue_id = int.Parse(propertyIds[i]);

                            ProductProperties productProperties = new ProductProperties
                            {
                                product_id = newproduct.Id,
                                properties_id = _db.PropertiesValueRepositoryUW.GetById(propertyvalue_id).properties_id,
                                propertiesvalue_id = propertyvalue_id

                            };


                            _db.ProductPropertiesRepositoryUW.Create(productProperties);
                        }


                        await _db.saveAsync();
                    }


                    //  check image gallary


                    if (model.gallaryImages.Count() != 0)
                    {
                        foreach (var image in model.gallaryImages)
                        {
                            var imagename = await _isv.SaveProductGallaryImages(image);

                            // save to db

                            ProductGallary productGallary = new ProductGallary
                            {
                                product_id = newproduct.Id,
                                imagepath = imagename
                            };


                            _db.ProductGallaryUW.Create(productGallary);
                        }

                        await _db.saveAsync();
                    }





                    api.message = EndPointMessage.API_CREATE_PRODUCT_SUCCESS;
                    api.status = EndPointMessage.API_OK_Std;
                }
                else
                {
                    api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                    api.status = EndPointMessage.API_Token_FAIL_Std;
                }



            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_Fail_MSG;
                api.status = EndPointMessage.API_Fail_Std;
            }

            return api;
        }




        // update product get
        public async Task<UpdateProductGetApiObject> updateproductget(long productId)
        {
            var api = new UpdateProductGetApiObject();

            try
            {

                var product = await _db.productRepositoryUW.GetByIdAsync(productId);





                // product info

                UpdateProductGetApiModel updateProductGet = new UpdateProductGetApiModel
                {
                    productId = product.Id,
                    brandId = product.brand_id,
                    categoryId = product.cat_id,
                    desc = product.desc,
                    garanty = product.garanty,
                    indexImage = product.image,
                    offpercent = product.offpercent,
                    price = product.price,
                    qty = product.qty,
                    summary = product.summary,
                    title = product.title,
                    weight = product.weight,
                };

                // product
                api.product = updateProductGet;


                // product color

                api.productColor = _db.ProductColorUW.Get(a => a.product_id == productId, null, "Tbl_color").Select(a => a.Tbl_color).ToList();


                // product size 

                api.productSize = _db.ProductSizeRepositoryUW.Get(a => a.product_id == productId, null, "Tbl_Size").Select(a => new SizeApiModel
                {
                    id = a.Id,
                    name = a.Tbl_Size.name

                }).ToList();


                // product property 

                api.properties = _db.ProductPropertiesRepositoryUW.Get(a => a.product_id == productId, null, "Tbl_Properties,Tbl_PropertiesValue").Select(a => new PropertyGetApiModel
                {
                    PropertiesId = a.properties_id,
                    PropertiesName = a.Tbl_Properties.name,
                    PropertiesValue = a.Tbl_PropertiesValue.value,
                    PropertyValueId = a.propertiesvalue_id

                }).ToList();


                // product gallary image

                api.gallaryImages = _db.ProductGallaryUW.Get(a => a.product_id == productId).Select(a => new ImageApiModel
                {
                    id = a.Id,
                    url = a.imagepath

                }).ToList();


                // categoris

                api.categories = await _db.CategoryRepositoryUW.GetManyAsync(a => a.isenable && a.type == categoryType.product.ToByte());

                // brands

                api.brands = await _db.productBrandRepositoryUW.GetManyAsync(a => a.isenable);

                // colors 

                api.colors = await _db.colorRepositoryUW.GetManyAsync(a => a.isenable);




                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;


            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;
            }

            return api;
        }





        // update product post
        public async Task<AllApi> updateproductpost(ProductUpdateModel model, string token)
        {
            var api = new AllApi();

            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {

                    // find editable product

                    var mainproduct = await _db.productRepositoryUW.GetByIdAsync(model.productId);


                    // split image name to find it
                    string[] arr = model.indexImage.Split('.');

                    if (arr.Length == 1)
                    {
                        // index image  changed


                        // delete previus image from host
                        await _ideleteimage.DeleteImageHost(mainproduct.image, "upload\\products\\normalimage\\", "upload\\products\\thumbnailimage\\", "nopicture.png");

                        mainproduct.image = await _isv.SaveProductIndexImage(model.indexImage);
                    }
                    else
                    {
                        if (!arr[1].Contains("jpg") && !arr[1].Contains("png"))
                        {
                            // index image  changed


                            // delete previus image from host
                            await _ideleteimage.DeleteImageHost(mainproduct.image, "upload\\products\\normalimage\\", "upload\\products\\thumbnailimage\\", "nopicture.png");

                            mainproduct.image = await _isv.SaveProductIndexImage(model.indexImage);
                        }
                    }





                    // edit base property of model
                    mainproduct.title = model.title;
                    mainproduct.summary = model.summary;
                    mainproduct.desc = model.desc;
                    mainproduct.cat_id = model.categoryId;
                    mainproduct.brand_id = model.brandId;
                    mainproduct.weight = model.weight;
                    mainproduct.qty = model.qty;
                    mainproduct.price = model.price;
                    mainproduct.offpercent = model.offpercent;
                    mainproduct.garanty = model.garanty;
                    mainproduct.isexist = model.qty >= 0;


                    // updated 
                    _db.productRepositoryUW.Update(mainproduct);

                    await _db.saveAsync();


                    // first delete all previuse exist colors 
                    var productcolors = await _db.ProductColorUW.GetManyAsync(a => a.product_id == model.productId);
                    _db.ProductColorUW.DeleteAll(productcolors);
                    await _db.saveAsync();
                    // end


                    //check product color 

                    if (!string.IsNullOrEmpty(model.colorId))
                    {

                        string[] colorids = model.colorId.Split(',');

                        for (int i = 0; i < colorids.Length - 1; i++)
                        {
                            int color_id = int.Parse(colorids[i]);

                            // save to db

                            ProductColor productColor = new ProductColor
                            {
                                color_id = color_id,
                                product_id = model.productId
                            };


                            _db.ProductColorUW.Create(productColor);
                        }


                        await _db.saveAsync();
                    }





                    // first delete all previuse exist sizes 
                    var productsizes = await _db.ProductSizeRepositoryUW.GetManyAsync(a => a.product_id == model.productId);
                    _db.ProductSizeRepositoryUW.DeleteAll(productsizes);
                    await _db.saveAsync();
                    // end



                    //check product size

                    if (!string.IsNullOrEmpty(model.sizeId))
                    {

                        string[] sizeIds = model.sizeId.Split(',');

                        for (int i = 0; i < sizeIds.Length - 1; i++)
                        {
                            int size_id = int.Parse(sizeIds[i]);


                            // save to db
                            ProductSize productSize = new ProductSize
                            {
                                size_id = size_id,
                                product_id = model.productId
                            };


                            _db.ProductSizeRepositoryUW.Create(productSize);
                        }


                        await _db.saveAsync();
                    }





                    //check product property

                    if (!string.IsNullOrEmpty(model.propertyId))
                    {

                        // first delete all previuse exist properties 
                        var productproperties = await _db.ProductPropertiesRepositoryUW.GetManyAsync(a => a.product_id == model.productId);
                        _db.ProductPropertiesRepositoryUW.DeleteAll(productproperties);
                        await _db.saveAsync();
                        // end

                        string[] propertyIds = model.propertyId.Split(',');

                        for (int i = 0; i < propertyIds.Length - 1; i++)
                        {
                            int propertyvalue_id = int.Parse(propertyIds[i]);

                            // save to db

                            ProductProperties productProperties = new ProductProperties
                            {
                                product_id = model.productId,
                                properties_id = _db.PropertiesValueRepositoryUW.GetById(propertyvalue_id).properties_id,
                                propertiesvalue_id = propertyvalue_id

                            };


                            _db.ProductPropertiesRepositoryUW.Create(productProperties);
                        }


                        await _db.saveAsync();
                    }




                    //  check image gallary

                    if (model.gallaryImages.Count() != 0)
                    {

                        // new product image gallary

                        foreach (var image in model.gallaryImages)
                        {
                            var imagename = await _isv.SaveProductGallaryImages(image);

                            // save to db

                            ProductGallary productGallary = new ProductGallary
                            {
                                product_id = model.productId,
                                imagepath = imagename
                            };


                            _db.ProductGallaryUW.Create(productGallary);
                        }

                        await _db.saveAsync();
                    }


                    // trash images means some gallary image want delete from db and host

                    if (model.trashImages.Count() != 0)
                    {


                        foreach (var trashid in model.trashImages)
                        {
                            long id = long.Parse(trashid);

                            var productgallary = await _db.ProductGallaryUW.GetByIdAsync(id);

                            // delete from host
                            await _ideleteimage.DeleteImageHost(productgallary.imagepath, "upload\\gallaryUp\\normalimage\\", "", "nopicture.png");


                            _db.ProductGallaryUW.Delete(productgallary);

                        }

                        await _db.saveAsync();


                    }




                    api.message = EndPointMessage.API_UPDATE_PRODUCT_SUCCESS;
                    api.status = EndPointMessage.API_OK_Std;
                }
                else
                {
                    api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                    api.status = EndPointMessage.API_Token_FAIL_Std;
                }



            }
            catch (Exception ex)
            {

                api.message = EndPointMessage.API_Fail_MSG;
                api.status = EndPointMessage.API_Fail_Std;
            }

            return api;
        }




        // delete product

        public async Task<AllApi> deleteproduct(long id, string token)
        {
            var api = new AllApi();

            try
            {

                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    var product = _db.productRepositoryUW.GetById(id);

                    product.enable = false;

                    _db.productRepositoryUW.Update(product);

                    await _db.saveAsync();


                    // delete product image 

                    await _ideleteimage.DeleteImageHost(product.image, "upload\\products\\normalimage\\", "upload\\products\\thumbnailimage\\", "nopicture.png");


                    var productgallary = await _db.ProductGallaryUW.GetManyAsync(a => a.product_id == product.Id);

                    foreach (var productGallary in productgallary)
                    {
                        await _ideleteimage.DeleteImageHost(productGallary.imagepath, "upload\\gallaryUp\\normalimage\\", "", "nopicture.png");

                        _db.ProductGallaryUW.Delete(productGallary);

                    }

                    await _db.saveAsync();



                    api.message = EndPointMessage.API_DELETE_PRODUCT_SUCCESS;
                    api.status = EndPointMessage.API_OK_Std;

                }
                else
                {
                    api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                    api.status = EndPointMessage.API_Token_FAIL_Std;
                }



            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_Fail_MSG;
                api.status = EndPointMessage.API_Fail_Std;
            }

            return api;
        }





        // get products by category 
        public async Task<ProductListAllApiObject> getproductsbycat(int catId, int page)
        {
            var api = new ProductListAllApiObject();

            try

            {
                int paresh = (page - 1) * 10;

                api.products = _db.productRepositoryUW.Get(a => a.status == Status.valid.ToByte() && a.cat_id == catId && a.enable, null, "Tbl_Shop,Tbl_Category,brand").Skip(paresh).Take(10).Select(a => new ProductListApiModel
                {

                    id = a.Id,
                    exist = a.isexist,
                    image = a.image,
                    likecount = a.likeCount,
                    offpercent = a.offpercent,
                    price = a.price,
                    shopname = a.Tbl_Shop.title,
                    title = a.title,
                    viewcount = a.viewCount,
                    category = a.Tbl_Category.Title,
                    brand = a.brand.name,
                    summary = a.summary


                }).ToList();





                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;
            }
            catch (Exception)
            {

                api.status = EndPointMessage.API_ERROR_Std;
                api.message = EndPointMessage.API_ERROR_MSG;
            }


            return api;
        }



        // get all products
        public async Task<ProductListAllApiObject> allproduct(int page)
        {
            var api = new ProductListAllApiObject();

            try
            {
                int paresh = (page - 1) * 10;

                api.products = _db.productRepositoryUW.Get(a => a.enable && a.status == Status.valid.ToByte(), null, "Tbl_Shop,Tbl_Category,brand").Skip(paresh).Take(10).Select(a => new ProductListApiModel
                {
                    id = a.Id,
                    exist = a.isexist,
                    image = a.image,
                    likecount = a.likeCount,
                    offpercent = a.offpercent,
                    price = a.price,
                    shopname = a.Tbl_Shop.title,
                    title = a.title,
                    viewcount = a.viewCount,
                    category = a.Tbl_Category.Title,
                    brand = a.brand.name,
                    summary = a.summary

                }).ToList();


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




        // get products by title
        public async Task<ProductListAllApiObject> getproductsbytitle(string title, int page)
        {
            var api = new ProductListAllApiObject();

            try
            {
                int paresh = (page - 1) * 10;

                api.products = _db.productRepositoryUW.Get(a => a.enable && a.status == Status.valid.ToByte(), null, "Tbl_Product,Tbl_Shop,brand").Skip(paresh).Take(10).Select(a => new ProductListApiModel
                {

                    id = a.Id,
                    exist = a.isexist,
                    image = a.image,
                    likecount = a.likeCount,
                    offpercent = a.offpercent,
                    price = a.price,
                    shopname = a.Tbl_Shop.title,
                    title = a.title,
                    viewcount = a.viewCount,
                    brand = a.brand.name,
                    category = a.Tbl_Category.Title,
                    summary = a.summary

                }).ToList();


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



        // product search auto complete
        public async Task<ProductListAutoCompleteObject> autocomplete(string key, int page)
        {
            var api = new ProductListAutoCompleteObject();
            try
            {
                int paresh = (page - 1) * 10;


                api.autocomplete = _db.productRepositoryUW.Get(a => a.title.Contains(key) && a.enable && a.status == Status.valid.ToByte()).Skip(paresh).Take(10).Select(a => a.title);


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





        // get products by sort 
        public async Task<ProductListAllApiObject> allproductbysort(int sort, int page)
        {
            var api = new ProductListAllApiObject();

            try
            {
                int paresh = (page - 1) * 10;


                switch (sort)
                {
                    case 0: // topview product
                        {
                            api.products = _db.productRepositoryUW.Get(a => a.enable && a.status == Status.valid.ToByte(),null ,  "Tbl_Product,Tbl_Shop,brand").Skip(paresh).Take(10).Select(a =>
                               new ProductListApiModel
                            {

                                id = a.Id,
                                exist = a.isexist,
                                image = a.image,
                                likecount = a.likeCount,
                                offpercent = a.offpercent,
                                price = a.price,
                                shopname = a.Tbl_Shop.title,
                                title = a.title,
                                viewcount = a.viewCount,
                                category = a.Tbl_Category.Title,
                                brand = a.brand.name,
                                summary = a.summary



                            }).ToList();

                            break;
                        }

                    case 1: //mostsell product
                        {



                            api.products = _db.productRepositoryUW.Get(a => a.enable && a.status == Status.valid.ToByte(), a => a.OrderByDescending(b => b.price), "Tbl_Product,Tbl_Shop,brand").Skip(paresh).Take(10).Select(a => new ProductListApiModel
                            {
                                id = a.Id,
                                exist = a.isexist,
                                image = a.image,
                                likecount = a.likeCount,
                                offpercent = a.offpercent,
                                price = a.price,
                                shopname = a.Tbl_Shop.title,
                                title = a.title,
                                viewcount = a.viewCount,
                                category = a.Tbl_Category.Title,
                                summary = a.summary,
                                brand = a.brand.name

                            }).ToList();



                        }
                        break;

                    case 2: // prcie desc
                        {
                            api.products = _db.productRepositoryUW.Get(a => a.enable && a.status == Status.valid.ToByte(), a => a.OrderByDescending(b => b.price), "Tbl_Product,Tbl_Shop,brand").Skip(paresh).Take(10).Select(a => new ProductListApiModel
                            {
                                id = a.Id,
                                exist = a.isexist,
                                image = a.image,
                                likecount = a.likeCount,
                                offpercent = a.offpercent,
                                price = a.price,
                                shopname = a.Tbl_Shop.title,
                                title = a.title,
                                viewcount = a.viewCount,
                                category = a.Tbl_Category.Title,
                                summary = a.summary,
                                brand = a.brand.name

                            }).ToList();
                        }
                        break;

                    case 3: // price  asc
                        {
                            api.products = _db.productRepositoryUW.Get(a => a.enable && a.status == Status.valid.ToByte(), a => a.OrderBy(b => b.price), "Tbl_Product,Tbl_Shop,brand").Skip(paresh).Take(10).Select(a => new ProductListApiModel
                            {
                                id = a.Id,
                                exist = a.isexist,
                                image = a.image,
                                likecount = a.likeCount,
                                offpercent = a.offpercent,
                                price = a.price,
                                shopname = a.Tbl_Shop.title,
                                title = a.title,
                                viewcount = a.viewCount,
                                category = a.Tbl_Category.Title,
                                summary = a.summary,
                                brand = a.brand.name

                            }).ToList();
                        }
                        break;


                    case 4: //topnew product
                        {
                            api.products = _db.productRepositoryUW.Get(a => a.enable && a.status == Status.valid.ToByte(), a => a.OrderBy(b => b.dateMiladi), "Tbl_Product,Tbl_Shop,brand").Skip(paresh).Take(10).Select(a => new ProductListApiModel
                            {
                                id = a.Id,
                                exist = a.isexist,
                                image = a.image,
                                likecount = a.likeCount,
                                offpercent = a.offpercent,
                                price = a.price,
                                shopname = a.Tbl_Shop.title,
                                title = a.title,
                                viewcount = a.viewCount,
                                category = a.Tbl_Category.Title,
                                summary = a.summary,
                                brand = a.brand.name

                            }).ToList();
                        }
                        break;

                    case 5: //toplike(fav) product
                        {
                            api.products = _db.productRepositoryUW.Get(a => a.enable && a.status == Status.valid.ToByte(), a => a.OrderByDescending(b => b.likeCount), "Tbl_Product,Tbl_Shop,brand").Skip(paresh).Take(10).Select(a => new ProductListApiModel
                            {
                                id = a.Id,
                                exist = a.isexist,
                                image = a.image,
                                likecount = a.likeCount,
                                offpercent = a.offpercent,
                                price = a.price,
                                shopname = a.Tbl_Shop.title,
                                title = a.title,
                                viewcount = a.viewCount,
                                category = a.Tbl_Category.Title,
                                summary = a.summary,
                                brand = a.brand.name

                            }).ToList();
                        }
                        break;

                    default:
                        api.products = new List<ProductListApiModel>();
                        break;
                }





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


        // get products by filter
        public async Task<ProductListAllApiObject> getproductsbyfilter(int page, string title, string brands, string price, string regions)
        {
            var api = new ProductListAllApiObject();

            try
            {

                int filter = 0;

                int paresh = (page - 1) * 10;

                List<ProductSeller> temp = new List<ProductSeller>();

                if (brands.Length != 0 && !string.IsNullOrEmpty(brands))
                {
                    var brand = brands.Split(',');

                    for (int i = 0; i < brand.Length; i++)
                    {
                        temp.AddRange(_db.ProductSellerUW.Get(a => a.Tbl_Product.brand_id == brand[i].ToInt() && (a.Tbl_Product.title.Contains(title) || a.Tbl_Product.Tbl_Category.Title.Contains(title)) && a.isEnable && a.status == 1 && a.Tbl_Product.enable && a.Tbl_Product.status == 1 && a.Tbl_Shop.status == 1 && a.Tbl_Shop.enable, null, "Tbl_Shop,Tbl_Product").ToList());
                    }

                    filter = 1;
                }

                if (regions.Length != 0 && !string.IsNullOrEmpty(regions))
                {
                    var region = regions.Split(',');
                    if (filter == 0) // no filter before
                    {
                        temp = _db.ProductSellerUW.Get(a => a.Tbl_Shop.city_id == region[0].ToInt() && a.Tbl_Shop.ostan_id == region[1].ToInt() && a.isEnable && a.status == 1 && a.Tbl_Product.enable && a.Tbl_Product.status == 1 && a.Tbl_Shop.status == 1 && a.Tbl_Shop.enable, null, "Tbl_Shop,Tbl_Product").ToList();
                    }
                    else
                    {
                        temp = temp.Where(a => a.Tbl_Shop.city_id == region[0].ToInt() && a.Tbl_Shop.ostan_id == region[1].ToInt() && a.ismainseller).ToList();
                    }

                    filter = 1;
                }

                if (price.Length != 0 && !string.IsNullOrEmpty(price))
                {
                    var myprice = price.Split(',');

                    if (filter == 0) // no filter before
                    {
                        temp = _db.ProductSellerUW.Get(a => a.price >= myprice[0].ToInt() && a.price <= myprice[1].ToInt() && a.isEnable && a.status == 1 && a.Tbl_Product.enable && a.Tbl_Product.status == 1 && a.Tbl_Shop.status == 1 && a.Tbl_Shop.enable, null, "Tbl_Shop,Tbl_Product").ToList();
                    }
                    else
                    {
                        temp = temp.Where(a => a.price >= myprice[0].ToInt() && a.price <= myprice[1].ToInt() && a.ismainseller).ToList();
                    }

                    filter = 1;
                }


                api.products = temp.Skip(paresh).Take(10).Select(a => new ProductListApiModel
                {
                    id = a.product_id,
                    exist = a.isExist,
                    image = a.Tbl_Product.image,
                    likecount = a.Tbl_Product.likeCount,
                    offpercent = a.offpercent,
                    price = a.price.RialToToman(),
                    shopname = a.Tbl_Shop.title,
                    title = a.Tbl_Product.title,
                    viewcount = a.Tbl_Product.viewCount,
                    category = _db.CategoryRepositoryUW.GetById(a.Tbl_Product.cat_id).Title,
                    //  colors = _db.ProductColorUW.Get(b => b.product_id == a.product_id, null, "Tbl_color").Select(s => s.Tbl_color.nameen),
                    brand = _db.productBrandRepositoryUW.GetById(a.Tbl_Product.brand_id).name,
                    // sellercount = _db.ProductSellerUW.Get(d => d.shop_id != a.shop_id && d.product_id == a.product_id && d.status == 1 && d.isEnable && d.Tbl_Shop.status == 1 && d.Tbl_Shop.enable && d.Tbl_Shop.todate.CompareTo(DateTime.Now) > 0, null, "Tbl_Shop").Count()

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








    }
}
