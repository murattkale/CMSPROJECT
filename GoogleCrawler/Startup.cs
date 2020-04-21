using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleCrawler.Models.Context;
using GoogleCrawler.Models.Interfaces;
using GoogleCrawler.Models.Persistence;
using GoogleCrawler.Models.Repository;
using GoogleCrawler.Models.UoW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GoogleCrawler
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsersRepository, UsersRepository>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            MongoDbPersistence.Configure();

            services.AddDistributedMemoryCache();//To Store session in Memory, This is default implementation of IDistributedCache    
            services.AddSession(s => s.IdleTimeout = TimeSpan.FromMinutes(60));
            services.AddMvc(option => option.EnableEndpointRouting = false).AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                opt.SerializerSettings.DateFormatString = "dd/MM/yyyy";
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            RegisterServices(services);

            //services.AddEntityFrameworkSqlServer().AddDbContext<CMSDBContext>();

            //services.AddScoped(typeof(IBaseSession), typeof(BaseSession));
            //services.AddScoped(typeof(IGenericRepo<IBaseModel>), typeof(GenericRepo<CMSDBContext, IBaseModel>));
            //#endregion

            //services.AddScoped(typeof(ISendMail), typeof(SendMail));//Kullan�ca��n�z servis projesinden en az birtane servisi �a��rmal�s�n�z.

            //var allprops = AppDomain.CurrentDomain.GetAssemblies();
            //var props = allprops.Where(o => o.GetName().Name.Contains("DynamicSiteService"))
            //    .FirstOrDefault().DefinedTypes;
            //var servicesAll = props.Where(o => (!o.IsInterface && o.BaseType.Name.Contains("GenericRepo"))).ToList();
            //servicesAll.ForEach(baseService => { services.AddScoped(baseService.GetInterface("I" + baseService.Name), baseService); });



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
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseRequestLocalization();

            SessionRequest.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());

            app.UseMvc(routes =>
            {

               // routes.MapRoute(
               //   "Ajax",
               //    "/Base/{action}/{id?}",
               //   defaults: new { site = "", controller = "Base", action = "", link = "", id = "" }
               //  );


               // routes.MapRoute(
               //    name: "Sayfa",
               //    template: "{*link}",
               //    constraints: new { site = new DynamicRouting() },
               //    defaults: new { site = "", controller = "Base", action = "Sayfa", link = "" }
               //);


                routes.MapRoute(name: "default", template: "{controller=Base}/{action=Index}/{Id?}");
            });







        }
    }
}
