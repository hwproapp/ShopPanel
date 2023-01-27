using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using newsSite90tv.Models;
using newsSite90tv.Models.Repository;
using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.Services;

namespace newsSite90tv
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //verify Connection String To app
            services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("MyConnectionString")));
            //verify Idenity service
            services.AddIdentity<ApplicationUsers, ApplicationRoles>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAspNetUserRoleRepository, AspNetUserRoleRepository>();
            services.AddScoped<IUploadfile, UploadFile>();
            services.AddScoped<IsearchResult, searchResult>();
            services.AddScoped<IProduct, ProductRepository>();
            services.AddScoped<ICategory, CategoryRepository>();
            services.AddScoped<IAthenticate, AthencateRepository>();

            services.AddScoped<IsaveImage, saveImageRepository>();
            services.AddScoped<Icomment, commnetRepository>();


            services.AddScoped<IAdvertise, AdvertiseRepository>();
            services.AddScoped<IShop, ShopRepository>();
          
            services.AddScoped<Iuseraddress, userAddressRepository>();
            services.AddScoped<IUserapp, userappRepository>();
          
            services.AddScoped<Isend, sendRepository>();
            services.AddScoped<Iseller, sellerRepository>();
            services.AddScoped<Ibanner, bannerRepository>();
            services.AddScoped<IReport, ErrorReportRepository>();
            services.AddScoped<Iuseralarm, useralarmRepository>();
            services.AddScoped<Ideleteimage, deleteimageRepository>();
            services.AddScoped<Iorder, OrderRepository>();
            services.AddScoped<Iuserbuy, userbuyRepository>();
            services.AddScoped<Isellersell, sellersellRepository>();
            services.AddScoped<Ifav, favRepository>();
            services.AddScoped<ISellerbank, sellerbankRepository>();
            services.AddScoped<Icontact, ContactRepository>();

            services.AddScoped<IProperties, PropertiesRepository>();




            services.ConfigureApplicationCookie(option => option.LoginPath = "/Account/login");
            services.AddMvc();

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
                
            });


           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "AdminPanel",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
