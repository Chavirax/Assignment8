using Assignment5.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<CharityDbContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:BookCharityConnection"]); //passing configuration, where we are going to store the connection string
           });

            services.AddScoped<ICharityRepository, EFCharityRepository>();
            
            services.AddRazorPages(); //adds razor pages
            services.AddDistributedMemoryCache(); //'this will get the cart info to stick
            services.AddSession();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage",
                    "{category}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page",
                    "{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", pageNum = 1 });

                endpoints.MapControllerRoute( // this customises the display in the URL
                   "Pagination",
                   "Books/{pageNum}", // e user can type /P2 to access the second page and /P3 to access the third page and so on.

                   new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute(); // default index, if they don't type anything
                endpoints.MapRazorPages(); //razor pages endopoint

                endpoints.MapDefaultControllerRoute();
            });
            //Once the database has already been created, you don't need this anymore.
            SeedData.EnsurePopulated(app);
        }
    }
}
