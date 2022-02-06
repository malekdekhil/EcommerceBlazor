using Data;
using Domains;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Implementations;
using Services.Interfaces;
using ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkManager;
using Microsoft.EntityFrameworkCore.SqlServer;
using Noums_eCommerce_UI.Pages.ViewModels;

namespace Noums_eCommerce_UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServerSideBlazor();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddHttpContextAccessor();
            var cnxString = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<AppDbContext>(options =>
            //      options.UseMySql(cnxString, MySqlServerVersion.AutoDetect(cnxString),
            //      opts =>
            //      {
            //          opts.MigrationsAssembly("Data");

            //          //opts.EnableRetryOnFailure();
            //      }

            //          ), ServiceLifetime.Transient);


            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(cnxString,
                opts =>
                {
                    opts.MigrationsAssembly("Data");
                    opts.EnableRetryOnFailure();
                }), ServiceLifetime.Transient);


            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            }).AddDefaultUI().AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
            services.AddAuthentication().AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
            });
            //-------------Add session ne concerne pas blazor---------------------
            services.AddSession(options =>
            {
                options.IOTimeout = TimeSpan.FromMinutes(120);

            });
            services.AddDistributedMemoryCache();
            //-------------Add Serives---------------------
            services.AddTransient<AppUser>();
            services.AddTransient<IShoppingUserTmp, ShoppingUserTmp>();
            services.AddTransient<IUserTmp, ClsUserTmp>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICategory, ClsCategory>();
            services.AddTransient<IProduct, ClsProduct>();
            services.AddTransient<IOpignion, ClsOpinion>();
            services.AddTransient<IOrder, ClsOrder>();
            services.AddTransient<IOrderItem, ClsOrderItem>();
            services.AddTransient<IProvider, ClsProvider>();
            services.AddTransient<IPicture, ClsPicture>();
            services.AddTransient<ICart, ClsShoppingCart>();
             //-------------Add session ne concerne pas blazor---------------------

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");


            });
        }
    }
}
