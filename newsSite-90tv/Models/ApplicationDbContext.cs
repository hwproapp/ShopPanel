using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using newsSite90tv.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers, ApplicationRoles, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<Category> Tbl_Category { get; set; }

        public DbSet<Ostan> Tbl_Ostans { get; set; }
        public DbSet<City> Tbl_City { get; set; }

        public DbSet<Salsman> Tbl_Salsman { get; set; }
        public DbSet<ProductBrand> Tbl_Brand { get; set; }
        public DbSet<Shop> Tbl_Shop { get; set; }
        public DbSet<Product> Tbl_Products { get; set; }


        public DbSet<Color> Tbl_Color { get; set; }

        public DbSet<ProductColor> Tbl_ProductColor { get; set; }


        public DbSet<Size> Tbl_Size { get; set; }

        public DbSet<ProductSize> Tbl_ProductSize { get; set; }
        public DbSet<SizeCategory> Tbl_SizeCategory { get; set; }



        public DbSet<UserApp> Tbl_UserApp { get; set; }

        public DbSet<FollowShop> Tbl_FollowShop { get; set; }

        public DbSet<shopadvertise> Tbl_ShopAdvertise { get; set; }


        public DbSet<ProductGallary> Tbl_ProductGallary { get; set; }




        public DbSet<Comment> Tbl_comment { get; set; }

        public DbSet<sellerBank> Tbl_sellerBank { get; set; }




        public DbSet<workerBanner> Tbl_Banner { get; set; }
        public DbSet<Plan> Tbl_Plan { get; set; }

        public DbSet<ReportProduct> Tbl_ReportProduct { get; set; }

        public DbSet<ReportReason> Tbl_ReportReason { get; set; }


        public DbSet<ProductFav> Tbl_Favorite { get; set; }

        public DbSet<UserAddress> Tbl_Useraddress { get; set; }


        public DbSet<UserAlarm> Tbl_UserAlarm { get; set; }

        public DbSet<bannerImage> Tbl_BannerImage { get; set; }

        public DbSet<Order> Tbl_Order { get; set; }

        public DbSet<payment> Tbl_payment { get; set; }

        public DbSet<orderDetail> Tbl_orderdetail { get; set; }

        public DbSet<Sell> Tbl_Sell { get; set; }

        public DbSet<Buy> Tbl_Buy { get; set; }

        public DbSet<Checkout> Tbl_Checkout { get; set; }

        public DbSet<CheckoutRequest> Tbl_CheckoutRequest { get; set; }

        public DbSet<Appsetting> Tbl_Appsetting { get; set; }
        public DbSet<Appversion> Tbl_Appversion { get; set; }

        public DbSet<ShopPlanState> Tbl_ShopPlanState { get; set; }
        public DbSet<ContactUs> Tbl_Contact { get; set; }


        public DbSet<PropertiesValue> Tbl_PropertiesValue { get; set; }
        public DbSet<Properties> Tbl_Properties { get; set; }
        public DbSet<ProductProperties> Tbl_ProductProperties { get; set; }





        // public DbSet<AdvertisePlanState> Tbl_AdvertisePlanState { get; set; }

        //public DbSet<ProductSeller> Tbl_ProductSeller { get; set; }
        //public DbSet<Buycheck> Tbl_BuyCheck { get; set; }
        //public DbSet<Sellcheck> Tbl_SellCheck { get; set; }
        // public DbSet<shopcomments> Tbl_ShopComment { get; set; }
        //public DbSet<Part> Tbl_PropertyPart { get; set; }
        //public DbSet<Property> Tbl_Property{ get; set; }
        //public DbSet<ProdProp> Tbl_ProductProperty { get; set; }

        //  public DbSet<FileManager> Tbl_filemanager { get; set; }




    }
}
