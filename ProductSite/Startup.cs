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

namespace ProductSite
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
            #region BaseServices
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
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


            services.AddEntityFrameworkSqlServer().AddDbContext<CMSDBContext>();

            services.AddScoped(typeof(IBaseSession), typeof(BaseSession));
            services.AddScoped(typeof(IGenericRepo<IBaseModel>), typeof(GenericRepo<CMSDBContext, IBaseModel>));
            #endregion


            //UserService
            services.AddScoped(typeof(ILangService), typeof(LangService));
            services.AddScoped(typeof(ISendMail), typeof(SendMail));
            services.AddScoped(typeof(ICityService), typeof(CityService));
            services.AddScoped(typeof(ITownService), typeof(TownService));

            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IUserRoleService), typeof(UserRoleService));
            services.AddScoped(typeof(IRoleService), typeof(RoleService));
            services.AddScoped(typeof(IPermissionService), typeof(PermissionService));

            services.AddScoped(typeof(IServiceConfigService), typeof(ServiceConfigService));
            services.AddScoped(typeof(IServiceConfigAuthService), typeof(ServiceConfigAuthService));

            //CMSService
            services.AddScoped(typeof(IContentPageService), typeof(ContentPageService));
            services.AddScoped(typeof(IFormlarService), typeof(FormlarService));
            services.AddScoped(typeof(IDocumentsService), typeof(DocumentsService));

            services.AddScoped(typeof(IBrandService), typeof(BrandService));
            services.AddScoped(typeof(IModelService), typeof(ModelService));
            services.AddScoped(typeof(IMotorService), typeof(MotorService));


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
            app.UseCookiePolicy();
            app.UseSession();
            app.UseHsts();
            app.UseHttpsRedirection();

            SessionRequest.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());

            app.UseMvc(routes =>
            {

                routes.MapRoute(
                  "Ajax",
                   "/Base/{action}/{id?}",
                  defaults: new { site = "", controller = "Base", action = "", link = "", id = "" }
                 );


                routes.MapRoute(
                   name: "Sayfa",
                   template: "{*link}",
                   constraints: new { site = new DynamicRouting() },
                   defaults: new { site = "", controller = "Base", action = "Sayfa", link = "" }
               );


                routes.MapRoute(name: "default", template: "{controller=Base}/{action=Index}/{Id?}");
            });







        }
    }
}
