using newsSite90tv.Models.Repository;
using newsSite90tv.Services;
using System;
using System.Threading.Tasks;

namespace newsSite90tv.Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;



        public UnitOfWork(ApplicationDbContext context)
        {
            _context = this._context ?? context;


        }



        private CrudGenericMethod<ApplicationUsers> _userManager;
    
        private CrudGenericMethod<Category> _category;
        private CrudGenericMethod<CheckoutRequest> _CheckoutrequestRepositoryUW;
        private CrudGenericMethod<shopadvertise> _AdvertiseRepositoryUW;
        private CrudGenericMethod<Poll> _PollRepositoryUW;
        private CrudGenericMethod<PollOption> _PolloptionRepositoryUW;
        private CrudGenericMethod<UserApp> _UserAppRepositoryUW;
        private CrudGenericMethod<Salsman> _SalsmanRepositoryUW;
        private CrudGenericMethod<Product> _ProductRepositoryUW;
        private CrudGenericMethod<Color> _colorRepositoryUW;
      
        private CrudGenericMethod<ProductBrand> _productBrandRepositoryUW;
        private CrudGenericMethod<Shop> _shopRepositoryUW;
        private CrudGenericMethod<FileManager> _filemanagerRepositoryUW;
        private CrudGenericMethod<FollowShop> _FollowShopRepositoryUW;


        private CrudGenericMethod<ProductGallary> _ProductGallaryRepositoryUW;
       
        private CrudGenericMethod<ProductColor> _ProductColorRepositoryUW;
        private CrudGenericMethod<ContactUs> _contactRepositoryUW;
     
    
        private CrudGenericMethod<Ostan> _ostanRepositoryUW;
        private CrudGenericMethod<City> _cityRepositoryUW;
        private CrudGenericMethod<Property> _PropertyRepositoryUW;
        private CrudGenericMethod<ProdProp> _ProductPropRepositoryUW;
        private CrudGenericMethod<Sellfix> _SellfixRepositoryUW;
     
      
        private CrudGenericMethod<Order> _orderRepositoryUW;
        private CrudGenericMethod<Sellcheck> _sellcheckRepositoryUW;
      
        private CrudGenericMethod<sellerBank> _sellerBankRepositoryUW;
     
        private CrudGenericMethod<payment> _paymentRepositoryUW;
        private CrudGenericMethod<Comment> _commentRepositoryUW;
        private CrudGenericMethod<ReportProduct> _errorReportRepositoryUW;
     
        private CrudGenericMethod<orderDetail> _orderDetailRepositoryUW;
        private CrudGenericMethod<Sell> _sellRepositoryUW;
        private CrudGenericMethod<Fixrequest> _fixrequestRepositoryUW;

       



        private CrudGenericMethod<Part> _partRepositoryUW;

        private CrudGenericMethod<Buycheck> _buycheckRepositoryUW;

    
     
        private CrudGenericMethod<workerBanner> _workerBannerRepositoryUW;
 
        private CrudGenericMethod<shopcomments> _shopCommentRepositoryUW;
        private CrudGenericMethod<ProductSeller> _ProductsellerRepositoryUW;
        private CrudGenericMethod<Plan> _PlanRepositoryUW;
   
 

        private CrudGenericMethod<ReportProduct> _ReportProductRepositoryUW;
        private CrudGenericMethod<ErrorReportShop> _ReportShopRepositoryUW;
        private CrudGenericMethod<ReportReason> _ReportReasonRepositoryUW;
        private CrudGenericMethod<UserAddress> _useraddRepositoryUW;
        private CrudGenericMethod<UserAlarm> _useralarmRepositoryUW;
        private CrudGenericMethod<bannerImage> _bannerimageRepositoryUW;
    
        private CrudGenericMethod<UserBuy> _userbuyRepositoryUW;
        private CrudGenericMethod<SellerSell> _sellersellRepositoryUW;
        private CrudGenericMethod<Buy> _buyepositoryUW;
        private CrudGenericMethod<ProductFav> _favRepositoryUW;
        private CrudGenericMethod<Checkout> _CheckoutRepositoryUW;
        private CrudGenericMethod<Appsetting> _AppsettingRepositoryUW;

        private CrudGenericMethod<Appversion> _AppversionRepositoryUW;
        private CrudGenericMethod<Size> _SizeRepositoryUW;
        private CrudGenericMethod<ProductSize> _ProductSizeRepositoryUW;
        private CrudGenericMethod<SizeCategory> _SizeCategoryRepositoryUW;


        private CrudGenericMethod<Properties> _PropertiesRepositoryUW;
        private CrudGenericMethod<PropertiesValue> _PropertiesValueRepositoryUW;
        private CrudGenericMethod<ProductProperties> _ProductPropertiesRepositoryUW;



        //کاربران سایت
        public CrudGenericMethod<ApplicationUsers> userManagerUW
        {
            //فقط خواندنی
            get
            {
                if (_userManager == null)
                {
                    _userManager = new CrudGenericMethod<ApplicationUsers>(_context);
                }
                return _userManager;
            }
        }


        //تبلیغات
        public CrudGenericMethod<shopadvertise> AdvertisRepositoryUW
        {
            //فقط خواندنی
            get
            {
                if (_AdvertiseRepositoryUW == null)
                {
                    _AdvertiseRepositoryUW = new CrudGenericMethod<shopadvertise>(_context);
                }
                return _AdvertiseRepositoryUW;
            }
        }

        //متن نظرسنجی
        public CrudGenericMethod<Poll> PollRepositoryUW
        {
            //فقط خواندنی
            get
            {
                if (_PollRepositoryUW == null)
                {
                    _PollRepositoryUW = new CrudGenericMethod<Poll>(_context);
                }
                return _PollRepositoryUW;
            }
        }
        //پاسخهای نظرسنجی
        public CrudGenericMethod<PollOption> PollOptionRepositoryUW
        {
            //فقط خواندنی
            get
            {
                if (_PolloptionRepositoryUW == null)
                {
                    _PolloptionRepositoryUW = new CrudGenericMethod<PollOption>(_context);
                }
                return _PolloptionRepositoryUW;
            }
        }

        public CrudGenericMethod<Category> CategoryRepositoryUW
        {
            get
            {
                if (_category == null)
                {
                    _category = new CrudGenericMethod<Category>(_context);
                }
                return _category;
            }

        }


        //کاربر اپلیکیشن
        public CrudGenericMethod<UserApp> userappRepositoryUW
        {
            get
            {
                if (_UserAppRepositoryUW == null)
                {
                    _UserAppRepositoryUW = new CrudGenericMethod<UserApp>(_context);
                }
                return _UserAppRepositoryUW;
            }
        }

        public CrudGenericMethod<Salsman> salsmanRepositoryUW
        {
            get
            {
                if (_SalsmanRepositoryUW == null)
                {
                    _SalsmanRepositoryUW = new CrudGenericMethod<Salsman>(_context);
                }

                return _SalsmanRepositoryUW;
            }
        }

        public CrudGenericMethod<Product> productRepositoryUW
        {
            get
            {
                if (_ProductRepositoryUW == null)
                {
                    _ProductRepositoryUW = new CrudGenericMethod<Product>(_context);
                }
                return _ProductRepositoryUW;
            }
        }

        public CrudGenericMethod<Color> colorRepositoryUW
        {
            get
            {
                if (_colorRepositoryUW == null)
                {
                    _colorRepositoryUW = new CrudGenericMethod<Color>(_context);
                }
                return _colorRepositoryUW;
            }
        }


        public CrudGenericMethod<ProductBrand> productbrandRepositoryUW
        {
            get
            {
                if (_productBrandRepositoryUW == null)
                {
                    _productBrandRepositoryUW = new CrudGenericMethod<ProductBrand>(_context);
                }

                return _productBrandRepositoryUW;
            }
        }

        public CrudGenericMethod<Shop> shopRepositoryUW
        {
            get
            {
                if (_shopRepositoryUW == null)
                {
                    _shopRepositoryUW = new CrudGenericMethod<Shop>(_context);
                }
                return _shopRepositoryUW;
            }
        }

        public CrudGenericMethod<FileManager> fileManagerRepositoryUW
        {
            get
            {
                if (_filemanagerRepositoryUW == null)
                {
                    _filemanagerRepositoryUW = new CrudGenericMethod<FileManager>(_context);
                }
                return _filemanagerRepositoryUW;
            }
        }


     
       

        public CrudGenericMethod<ProductGallary> ProductGallaryUW
        {
            get
            {
                if (_ProductGallaryRepositoryUW == null)
                {
                    _ProductGallaryRepositoryUW = new CrudGenericMethod<ProductGallary>(_context);
                }
                return _ProductGallaryRepositoryUW;
            }
        }

       CrudGenericMethod<ProductColor> ProductColorUW
        {
            get
            {
                if (_ProductColorRepositoryUW == null)
                {
                    _ProductColorRepositoryUW = new CrudGenericMethod<ProductColor>(_context);
                }
                return _ProductColorRepositoryUW;
            }
        }

        public CrudGenericMethod<ProductBrand> productBrandRepositoryUW
        {
            get
            {
                if (_productBrandRepositoryUW == null)
                {
                    _productBrandRepositoryUW = new CrudGenericMethod<ProductBrand>(_context);
                }

                return _productBrandRepositoryUW;
            }
        }

        public CrudGenericMethod<Ostan> ostanRepositoryUW
        {
            get
            {
                if (_ostanRepositoryUW == null)
                {
                    _ostanRepositoryUW = new CrudGenericMethod<Ostan>(_context);
                }
                return _ostanRepositoryUW;
            }
        }

        public CrudGenericMethod<City> cityRepositoryUW
        {
            get
            {
                if (_cityRepositoryUW == null)
                {
                    _cityRepositoryUW = new CrudGenericMethod<City>(_context);
                }
                return _cityRepositoryUW;
            }
        }

       

        public CrudGenericMethod<Property> PropertyRepositoryUW
        {
            get
            {
                if (_PropertyRepositoryUW == null)
                {
                    _PropertyRepositoryUW = new CrudGenericMethod<Property>(_context);
                }

                return _PropertyRepositoryUW;
            }
        }


        public CrudGenericMethod<Order> OrderRepositoryUW
        {
            get
            {
                if (_orderRepositoryUW == null)
                {
                    _orderRepositoryUW = new CrudGenericMethod<Order>(_context);
                }

                return _orderRepositoryUW;
            }
        }

      
        public CrudGenericMethod<sellerBank> sellerBankRepositoryUW
        {
            get
            {
                if (_sellerBankRepositoryUW == null)
                {
                    _sellerBankRepositoryUW = new CrudGenericMethod<sellerBank>(_context);
                }

                return _sellerBankRepositoryUW;
            }
        }

     

        public CrudGenericMethod<payment> paymentRepositoryUW
        {
            get
            {
                if (_paymentRepositoryUW == null)
                {
                    _paymentRepositoryUW = new CrudGenericMethod<payment>(_context);
                }
                return _paymentRepositoryUW;
            }
        }

        public CrudGenericMethod<Comment> commentRepositoryUW
        {
            get
            {
                if (_commentRepositoryUW == null)
                {
                    _commentRepositoryUW = new CrudGenericMethod<Comment>(_context);
                }
                return _commentRepositoryUW;
            }
        }

        public CrudGenericMethod<FollowShop> FollowShopRepositoryUW
        {
            get
            {
                if (_FollowShopRepositoryUW == null)
                {
                    _FollowShopRepositoryUW = new CrudGenericMethod<FollowShop>(_context);
                }
                return _FollowShopRepositoryUW;
            }
        }

        public CrudGenericMethod<ReportProduct> ErrorReportRepositoryUW
        {
            get
            {
                if (_errorReportRepositoryUW == null)
                {
                    _errorReportRepositoryUW = new CrudGenericMethod<ReportProduct>(_context);
                }

                return _errorReportRepositoryUW;
            }
        }

 

      

        public CrudGenericMethod<Part> partRepositoryUW
        {
            get
            {
                if (_partRepositoryUW == null)
                {
                    _partRepositoryUW = new CrudGenericMethod<Part>(_context);
                }

                return _partRepositoryUW;
            }
        }


        public CrudGenericMethod<ProdProp> ProductPropRepositoryUW
        {
            get
            {
                if (_ProductPropRepositoryUW == null)
                {
                    _ProductPropRepositoryUW = new CrudGenericMethod<ProdProp>(_context);
                }

                return _ProductPropRepositoryUW;
            }
        }

    


        public CrudGenericMethod<workerBanner> workerBannerRepositoryUW
        {
            get
            {
                if (_workerBannerRepositoryUW == null)
                {
                    _workerBannerRepositoryUW = new CrudGenericMethod<workerBanner>(_context);
                }
                return _workerBannerRepositoryUW;
            }
        }

       
        public CrudGenericMethod<shopcomments> shopCommentUW
        {
            get
            {
                if (_shopCommentRepositoryUW == null)
                {
                    _shopCommentRepositoryUW = new CrudGenericMethod<shopcomments>(_context);
                }

                return _shopCommentRepositoryUW;
            }
        }

     
        public CrudGenericMethod<ProductSeller> ProductSellerUW
        {
            get
            {
                if (_ProductsellerRepositoryUW == null)
                {
                    _ProductsellerRepositoryUW = new CrudGenericMethod<ProductSeller>(_context);
                }

                return _ProductsellerRepositoryUW;
            }
        }

    

      

        public CrudGenericMethod<ReportProduct> ReportProductRepositoryUW
        {
            get
            {
                if (_ReportProductRepositoryUW == null)
                {
                    _ReportProductRepositoryUW = new CrudGenericMethod<ReportProduct>(_context);
                }
                return _ReportProductRepositoryUW;
            }
        }

        public CrudGenericMethod<ErrorReportShop> ReportShopRepositoryUW
        {
            get
            {
                if (_ReportShopRepositoryUW == null)
                {
                    _ReportShopRepositoryUW = new CrudGenericMethod<ErrorReportShop>(_context);
                }
                return _ReportShopRepositoryUW;
            }
        }

        public CrudGenericMethod<ReportReason> ReportReasonRepositoryUW
        {
            get
            {
                if (_ReportReasonRepositoryUW == null)
                {
                    _ReportReasonRepositoryUW = new CrudGenericMethod<ReportReason>(_context);
                }
                return _ReportReasonRepositoryUW;
            }
        }

        public CrudGenericMethod<UserAddress> useraddRepositoryUW
        {
            get
            {
                if (_useraddRepositoryUW == null)
                {
                    _useraddRepositoryUW = new CrudGenericMethod<UserAddress>(_context);
                }

                return _useraddRepositoryUW;
            }
        }

        public CrudGenericMethod<UserAlarm> useralarmRepositoryUW
         {
            get
            {
                if (_useralarmRepositoryUW == null)
                {
                    _useralarmRepositoryUW = new CrudGenericMethod<UserAlarm>(_context);
                }
                return _useralarmRepositoryUW;
            }
        }

        public CrudGenericMethod<bannerImage> bannerimagesRepositoryUW
        {
            get
            {
                if (_bannerimageRepositoryUW == null)
                {
                    _bannerimageRepositoryUW = new CrudGenericMethod<bannerImage>(_context);
                }
                return _bannerimageRepositoryUW;
            }
        }

       
        public CrudGenericMethod<orderDetail> orderdetailRepositoryUW
        {
            get
            {
                if (_orderDetailRepositoryUW == null)
                {
                    _orderDetailRepositoryUW = new CrudGenericMethod<orderDetail>(_context);
                }

                return _orderDetailRepositoryUW;
            }
        }

        public CrudGenericMethod<UserBuy> userbuyRepositoryUW
        {
            get
            {
                if (_userbuyRepositoryUW == null)
                {
                    _userbuyRepositoryUW = new CrudGenericMethod<UserBuy>(_context);
                }

                return _userbuyRepositoryUW;
            }
        }

        public CrudGenericMethod<SellerSell> sellersellRepositoryUW
        {
            get
            {
                if (_sellersellRepositoryUW == null)
                {
                    _sellersellRepositoryUW = new CrudGenericMethod<SellerSell>(_context);
                }

                return _sellersellRepositoryUW;
            }
        }

        public CrudGenericMethod<ProductFav> favRepositoryUW
        {
            get
            {
                if (_favRepositoryUW == null)
                {
                    _favRepositoryUW = new CrudGenericMethod<ProductFav>(_context);
                }

                return _favRepositoryUW;
            }
        }

        CrudGenericMethod<ProductColor> IUnitOfWork.ProductColorUW
        {
            get
            {
                if (_ProductColorRepositoryUW == null)
                {
                    _ProductColorRepositoryUW = new CrudGenericMethod<ProductColor>(_context);
                }

                return _ProductColorRepositoryUW;
            }
        }

        public CrudGenericMethod<Plan> planRepositoryUW
        {
            get
            {
                if (_PlanRepositoryUW  == null)
                {
                    _PlanRepositoryUW = new CrudGenericMethod<Plan>(_context);
                }

                return _PlanRepositoryUW;
            }
        }

        public CrudGenericMethod<Buy> buyRepositoryUW
        {
            get
            {
                if (_buyepositoryUW == null)
                {
                    _buyepositoryUW = new CrudGenericMethod<Buy>(_context);
                }

                return  _buyepositoryUW;
            }
        }

        public CrudGenericMethod<Sell> sellRepositoryUW
        {
            get
            {
                if (_sellRepositoryUW == null)
                {
                    _sellRepositoryUW = new CrudGenericMethod<Sell>(_context);
                }

                return _sellRepositoryUW;
            }
        }

        public CrudGenericMethod<Sellfix> sellfixRepositoryUW
        {
            get
            {
                if (_SellfixRepositoryUW == null)
                {
                    _SellfixRepositoryUW = new CrudGenericMethod<Sellfix>(_context);
                }

                return _SellfixRepositoryUW;
            }
        }

        public CrudGenericMethod<Fixrequest> fixRequestRepositoryUW
        {
            get
            {
                if (_fixrequestRepositoryUW == null)
                {
                    _fixrequestRepositoryUW = new CrudGenericMethod<Fixrequest>(_context);
                }

               return _fixrequestRepositoryUW;
            }
        }

        public CrudGenericMethod<Buycheck> buyCheckRepositoryUW
        {
            get
            {
                if (_buycheckRepositoryUW == null)
                {
                    _buycheckRepositoryUW = new CrudGenericMethod<Buycheck>(_context);
                }

                return _buycheckRepositoryUW;
            }
        }

        public CrudGenericMethod<Sellcheck> sellCheckRepositoryUW
        {
            get
            {
                if (_sellcheckRepositoryUW == null)
                {
                    _sellcheckRepositoryUW = new CrudGenericMethod<Sellcheck>(_context);
                }

                return _sellcheckRepositoryUW;
            }
        }

        public CrudGenericMethod<CheckoutRequest> CheckoutRequestRepositoryUW
        {
            get
            {
                if (_CheckoutrequestRepositoryUW == null)
                {
                    _CheckoutrequestRepositoryUW  = new CrudGenericMethod<CheckoutRequest>(_context);
                }
                return _CheckoutrequestRepositoryUW;
            }
        }

        public CrudGenericMethod<Checkout> CheckoutRepositoryUW
        {
            get
            {
                if (_CheckoutRepositoryUW == null)
                {
                    _CheckoutRepositoryUW = new CrudGenericMethod<Checkout>(_context);
                }
                return _CheckoutRepositoryUW;
            }
        }

        public CrudGenericMethod<Appsetting> AppsettingRepositoryUW
        {
            get
            {
                if (_AppsettingRepositoryUW == null)
                {
                    _AppsettingRepositoryUW = new CrudGenericMethod<Appsetting>(_context);
                }

                return _AppsettingRepositoryUW;
            }
        }

        public CrudGenericMethod<Appversion> AppversionRepositoryUW
        {
            get
            {
                if (_AppversionRepositoryUW == null)
                {
                    _AppversionRepositoryUW = new CrudGenericMethod<Appversion>(_context);
                }
                return _AppversionRepositoryUW;
            }
        }

        public CrudGenericMethod<Size> SizeRepositoryUW
        {
            get
            {
                if (_SizeRepositoryUW == null)
                {
                    _SizeRepositoryUW = new CrudGenericMethod<Size>(_context);
                }
                return _SizeRepositoryUW;
            }
        }

        public CrudGenericMethod<ProductSize> ProductSizeRepositoryUW
        {
            get
            {
                if (_ProductSizeRepositoryUW == null)
                {
                    _ProductSizeRepositoryUW = new CrudGenericMethod<ProductSize>(_context);
                }
                return _ProductSizeRepositoryUW;
            }
        }

        public CrudGenericMethod<SizeCategory> SizeCategoryRepositoryUW
        {
            get
            {
                if (_SizeCategoryRepositoryUW == null)
                {
                    _SizeCategoryRepositoryUW = new CrudGenericMethod<SizeCategory>(_context);
                }
                return _SizeCategoryRepositoryUW;
            }
        }

        public CrudGenericMethod<ContactUs> ContactRepositoryUW
        {
            get
            {
                if (_contactRepositoryUW == null)
                {
                    _contactRepositoryUW = new CrudGenericMethod<ContactUs>(_context);
                }

                return _contactRepositoryUW;
            }
        }

        public CrudGenericMethod<Properties> PropertiesRepositoryUW
        {
            get
            {
                if (_PropertiesRepositoryUW == null)
                {
                    _PropertiesRepositoryUW = new CrudGenericMethod<Properties>(_context);

                }

                return _PropertiesRepositoryUW;
            }
        }

        public CrudGenericMethod<PropertiesValue> PropertiesValueRepositoryUW
        {
            get
            {
                if (_PropertiesValueRepositoryUW == null)
                {
                    _PropertiesValueRepositoryUW = new CrudGenericMethod<PropertiesValue>(_context);

                }

                return _PropertiesValueRepositoryUW;
            }

        }

        public CrudGenericMethod<ProductProperties> ProductPropertiesRepositoryUW
        {
            get
            {
                if (_ProductPropertiesRepositoryUW == null)
                {
                    _ProductPropertiesRepositoryUW = new CrudGenericMethod<ProductProperties>(_context);

                }

                return _ProductPropertiesRepositoryUW;
            }
        }




        //مدیریت تراکنش
        public IEntityDataBaseTransaction BeginTransaction()
        {
            return new EntityDataBaseTransaction(_context);
        }


        public async  Task<int> saveAsync()
        {
            return await  _context.SaveChangesAsync();
        }

        public void save()
        {
            _context.SaveChanges();
        }


        #region Dispose
        protected bool isDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                _context.Dispose();
            }

            isDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
