using newsSite90tv.Models.Repository;
using newsSite90tv.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        
        CrudGenericMethod<ApplicationUsers> userManagerUW { get; }
        CrudGenericMethod<shopcomments> shopCommentUW { get; }
        CrudGenericMethod<ProductSeller> ProductSellerUW { get; }
     
        CrudGenericMethod<ProductGallary> ProductGallaryUW { get; }
      
        CrudGenericMethod<ProductColor> ProductColorUW { get; }
        CrudGenericMethod<Buycheck> buyCheckRepositoryUW { get; }
        CrudGenericMethod<Sellcheck> sellCheckRepositoryUW { get; }

        CrudGenericMethod<shopadvertise> AdvertisRepositoryUW { get; }
        CrudGenericMethod<FileManager> fileManagerRepositoryUW { get; }
        CrudGenericMethod<Poll> PollRepositoryUW { get; }
        CrudGenericMethod<PollOption> PollOptionRepositoryUW { get; }
      

        CrudGenericMethod<UserApp> userappRepositoryUW { get; }
        CrudGenericMethod<Color> colorRepositoryUW { get; }
        CrudGenericMethod<Plan> planRepositoryUW { get; }
        CrudGenericMethod<Sell> sellRepositoryUW { get; }
        CrudGenericMethod<Sellfix> sellfixRepositoryUW { get; }
      
    

        CrudGenericMethod<Salsman> salsmanRepositoryUW { get; }
  
        CrudGenericMethod<Product> productRepositoryUW { get; }
        CrudGenericMethod<Shop> shopRepositoryUW { get; }
        CrudGenericMethod<ProductBrand> productBrandRepositoryUW { get; }
        CrudGenericMethod<Ostan> ostanRepositoryUW { get; }
        CrudGenericMethod<City> cityRepositoryUW { get; }
        CrudGenericMethod<ProdProp> ProductPropRepositoryUW { get; }
        CrudGenericMethod<Property> PropertyRepositoryUW { get; }
        CrudGenericMethod<Fixrequest> fixRequestRepositoryUW { get; }

        CrudGenericMethod<Category> CategoryRepositoryUW { get; }

      
   
        CrudGenericMethod<Order> OrderRepositoryUW { get; }
     
        CrudGenericMethod<sellerBank> sellerBankRepositoryUW { get; }
    
        CrudGenericMethod<payment> paymentRepositoryUW { get; }
        CrudGenericMethod<Comment> commentRepositoryUW { get; }
        CrudGenericMethod<FollowShop> FollowShopRepositoryUW { get; }
      
    
        CrudGenericMethod<UserBuy> userbuyRepositoryUW { get; }
        CrudGenericMethod<SellerSell> sellersellRepositoryUW { get; }


       


        CrudGenericMethod<Part> partRepositoryUW { get; }
        CrudGenericMethod<ProductFav> favRepositoryUW { get; }
    
        
      
        CrudGenericMethod<workerBanner> workerBannerRepositoryUW { get; }
      
        CrudGenericMethod<ReportProduct> ReportProductRepositoryUW { get; }
        CrudGenericMethod<ErrorReportShop> ReportShopRepositoryUW { get; }
        CrudGenericMethod<ReportReason> ReportReasonRepositoryUW { get; }
        CrudGenericMethod<UserAddress> useraddRepositoryUW { get; }
        CrudGenericMethod<UserAlarm> useralarmRepositoryUW { get; }
        CrudGenericMethod<bannerImage> bannerimagesRepositoryUW { get; }
        CrudGenericMethod<orderDetail> orderdetailRepositoryUW { get; }
        CrudGenericMethod<Buy> buyRepositoryUW { get; }
        CrudGenericMethod<CheckoutRequest> CheckoutRequestRepositoryUW { get; }
        CrudGenericMethod<Checkout> CheckoutRepositoryUW { get; }
        CrudGenericMethod<Appsetting> AppsettingRepositoryUW { get; }
        CrudGenericMethod<Appversion> AppversionRepositoryUW { get; }
        CrudGenericMethod<Size> SizeRepositoryUW { get; }
        CrudGenericMethod<ProductSize> ProductSizeRepositoryUW { get; }
        CrudGenericMethod<SizeCategory> SizeCategoryRepositoryUW { get; }
        CrudGenericMethod<ContactUs> ContactRepositoryUW { get; }


        CrudGenericMethod<Properties> PropertiesRepositoryUW { get; }
        CrudGenericMethod<PropertiesValue> PropertiesValueRepositoryUW { get; }

        CrudGenericMethod<ProductProperties> ProductPropertiesRepositoryUW { get; }


        IEntityDataBaseTransaction BeginTransaction();

        Task<int> saveAsync();

        void save();
    }
}
