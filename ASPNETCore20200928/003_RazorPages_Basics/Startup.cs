using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _003_RazorPages_Basics.Pages.Sample002;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _003_RazorPages_Basics
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            

            services.AddSession(option =>
            {
                option.Cookie.HttpOnly = true;
                option.IdleTimeout = new TimeSpan(0, 0, 10);
            });

            services.AddResponseCaching();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            
            AppDomain.CurrentDomain.SetData("BildVerzeichnis", env.WebRootPath);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseLoggerMiddleware();

            app.UseResponseCaching();

            app.UseCookiePolicy();
            app.UseSession();

            app.MapWhen(context => context.Request.Path.ToString().Contains("imagegen"), subapp =>
            {
                subapp.UseThumbnailGen();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
