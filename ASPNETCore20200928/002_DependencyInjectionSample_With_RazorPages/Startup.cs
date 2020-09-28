using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _002_DependencyInjections;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _002_DependencyInjectionSample_With_RazorPages
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

            //Parameter�bertragung f�r Konstruktoren einer angebundenen Klasse -> https://stackoverflow.com/questions/53884417/net-core-di-ways-of-passing-parameters-to-constructor
            services.AddScoped(typeof(ICar), typeof(MockCarV2));
            services.AddScoped(typeof(ICar), typeof(MockCar)); //Letzte Objekt wird f�r den IoC Container verwendet! -> Es arbeitet ein Dictionary im Hintergrund
            services.AddSingleton(typeof(ICar), typeof(MockCarV3));
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

            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
