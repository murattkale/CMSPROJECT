using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSSite.Models;
using Entity;
using Entity.CMSDB; using Entity.ContextModel;
using GenericRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CMSSite
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
            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession(s => s.IdleTimeout = TimeSpan.FromMinutes(30));

            services
                .AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    opt.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                }
                );
            ;


            services.AddEntityFrameworkSqlServer().AddDbContext<CMSDBContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("CMSDBContext"), b => b.MigrationsAssembly("CMSDBContext")));

            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped(typeof(IBaseSession), typeof(BaseSession));
            services.AddSingleton(typeof(IHttpContextAccessor), typeof(HttpContextAccessor));


            services.AddScoped(typeof(IKurumService), typeof(KurumService));
            services.AddScoped(typeof(ISubeService), typeof(SubeService));
            services.AddScoped(typeof(ISezonService), typeof(SezonService));
            services.AddScoped(typeof(ISeansService), typeof(SeansService));
            services.AddScoped(typeof(IDerslikService), typeof(DerslikService));
            services.AddScoped(typeof(IBransService), typeof(BransService));
            services.AddScoped(typeof(ISinifService), typeof(SinifService));
            services.AddScoped(typeof(ISinifOgrenciService), typeof(SinifOgrenciService));

            services.AddScoped(typeof(ICityService), typeof(CityService));
            services.AddScoped(typeof(ITownService), typeof(TownService));

            services.AddScoped(typeof(IUsersService), typeof(UsersService));
            services.AddScoped(typeof(IUserRolesService), typeof(UserRolesService));
            services.AddScoped(typeof(IRolesService), typeof(RolesService));
            services.AddScoped(typeof(IPermissionsService), typeof(PermissionsService));

            services.AddScoped(typeof(IServiceConfigService), typeof(ServiceConfigService));
            services.AddScoped(typeof(IServiceConfigAuthService), typeof(ServiceConfigAuthService));

            services.AddScoped(typeof(IContentPageService), typeof(ContentPageService));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            string baseURL = "{site}/";


            app.UseMvc(routes =>
            {

                routes.MapRoute(
                "subeler",
                baseURL + "subeler",
                defaults: new { site = "", controller = "Base", action = "subeler", link = "", }
               );

                routes.MapRoute(
                 "sube",
                 baseURL + "sube/{id}",
                 defaults: new { site = "", controller = "Base", action = "sube", link = "", id = @"\d10" }
                );

                routes.MapRoute(
                "iletisim",
                baseURL + "iletisim/{id?}",
                defaults: new { site = "", controller = "Base", action = "iletisim", link = "", id = @"\d10" }
               );

                routes.MapRoute(
                  "Ajax",
                  baseURL + "Base/{action}/{id?}",
                  defaults: new { site = "", controller = "Base", action = "", link = "", id = "" }
                 );


                routes.MapRoute(
                   name: "Content",
                   template: baseURL + "{*link}",
                   constraints: new { site = new DynamicRouting() },
                   defaults: new { site = "", controller = "Base", action = "Content", link = "" }
               );


                routes.MapRoute(name: "default", template: baseURL + "{controller=Base}/{action=Index}/{Id?}");
            });



        }
    }
}
