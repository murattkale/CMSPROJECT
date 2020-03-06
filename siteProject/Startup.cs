using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace siteProject
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            //unutulmayan hata json result baþ harf küçük > büyük
            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });
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
                //app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
         name: "sosyalmedya",
         pattern: "sosyalmedya/{controller=Home}/{action=sosyalmedya}/{id?}");

                endpoints.MapControllerRoute(
           name: "istatistikler",
           pattern: "istatistikler/{controller=Home}/{action=istatistikler}/{id?}");

                endpoints.MapControllerRoute(
                name: "referanslar",
                pattern: "referanslar/{controller=Home}/{action=referanslar}/{id?}");

                endpoints.MapControllerRoute(
            name: "paketlerimiz",
            pattern: "paketlerimiz/{controller=Home}/{action=paketlerimiz}/{id?}");


                endpoints.MapControllerRoute(
              name: "iletisim",
              pattern: "iletisim/{controller=Home}/{action=iletisim}/{id?}");


                endpoints.MapControllerRoute(
                name: "biznasilcalisiriz",
                pattern: "biznasilcalisiriz/{controller=Home}/{action=biznasilcalisiriz}/{id?}");


                endpoints.MapControllerRoute(
                  name: "hakkimizda",
                  pattern: "hakkimizda/{controller=Home}/{action=hakkimizda}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
