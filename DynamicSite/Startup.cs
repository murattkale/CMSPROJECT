using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DynamicSite
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
            services.AddDistributedMemoryCache();//To Store session in Memory, This is default implementation of IDistributedCache    
            services.AddSession(s => s.IdleTimeout = TimeSpan.FromMinutes(30));
            services.AddMvc(option => option.EnableEndpointRouting = false).AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    opt.SerializerSettings.DateFormatString = "dd/MM/yyyy";
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();


            services.AddEntityFrameworkNpgsql().AddDbContext<CMSDBContext>();

            services.AddScoped(typeof(IBaseSession), typeof(BaseSession));
            services.AddScoped(typeof(IGenericRepo<IBaseModel>), typeof(GenericRepo<CMSDBContext, IBaseModel>));

           
            services.AddScoped(typeof(IContentPageService), typeof(ContentPageService));
            services.AddScoped(typeof(IDocumentsService), typeof(DocumentsService));
            services.AddScoped(typeof(IFormlarService), typeof(FormlarService));






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
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthorization();

            //app.UseAuthenticationMiddleware();

            SessionRequest.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());


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


            app.UseMvc(routes =>
            {



                routes.MapRoute(
                  "Ajax",
                   "/Base/{action}/{id?}",
                  defaults: new { site = "", controller = "Base", action = "", link = "", id = "" }
                 );


                routes.MapRoute(
                    "ContentPages",
                    "/ContentPages",
                    defaults: new { site = "", controller = "ContentPages", action = "", link = "", }
                   );

                routes.MapRoute(
                   name: "Content",
                   template: "{*link}",
                   constraints: new { site = new DynamicRouting() },
                   defaults: new { site = "", controller = "Base", action = "Content", link = "" }
               );


                routes.MapRoute(name: "default", template: "{controller=Base}/{action=Index}/{Id?}");
            });







        }
    }
}
