using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSSite.Models;
using Entity;


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

            #region BaseServices
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


            services.AddEntityFrameworkSqlServer().AddDbContext<CMSDBContext>();

            services.AddScoped(typeof(IBaseSession), typeof(BaseSession));
            services.AddScoped(typeof(IGenericRepo<IBaseModel>), typeof(GenericRepo<CMSDBContext, IBaseModel>));
            #endregion


            //MuhasebeService
            services.AddScoped(typeof(IBankaService), typeof(BankaService));
            services.AddScoped(typeof(IHesapTipService), typeof(HesapTipService));
            services.AddScoped(typeof(IHesapService), typeof(HesapService));
            services.AddScoped(typeof(IKasaService), typeof(KasaService));
            services.AddScoped(typeof(IOdemeTipService), typeof(OdemeTipService));
            services.AddScoped(typeof(IOdemeDetayService), typeof(OdemeDetayService));
            services.AddScoped(typeof(IParaBirimiService), typeof(ParaBirimiService));


            //UserService
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

            //DynessService
            services.AddScoped(typeof(IBransService), typeof(BransService));
            services.AddScoped(typeof(IDersService), typeof(DersService));
            services.AddScoped(typeof(IDersBransService), typeof(DersBransService));
            services.AddScoped(typeof(IDersGrupService), typeof(DersGrupService));
            services.AddScoped(typeof(IDerslikService), typeof(DerslikService));
            services.AddScoped(typeof(IKiyafetService), typeof(KiyafetService));
            services.AddScoped(typeof(IKiyafetTurService), typeof(KiyafetTurService));
            services.AddScoped(typeof(IKurumService), typeof(KurumService));
            services.AddScoped(typeof(INeredenDuydunuzService), typeof(NeredenDuydunuzService));
            services.AddScoped(typeof(IOgrenciDetayService), typeof(OgrenciDetayService));
            services.AddScoped(typeof(IOgrenciSozlesmeService), typeof(OgrenciSozlesmeService));
            services.AddScoped(typeof(IOgrenciSozlesmeKiyafetService), typeof(OgrenciSozlesmeKiyafetService));
            services.AddScoped(typeof(IOgrenciSozlesmeOdemeTablosuService), typeof(OgrenciSozlesmeOdemeTablosuService));
            services.AddScoped(typeof(IOgrenciSozlesmeYayinService), typeof(OgrenciSozlesmeYayinService));
            services.AddScoped(typeof(IOkulService), typeof(OkulService));
            services.AddScoped(typeof(IOkulTipService), typeof(OkulTipService));
            services.AddScoped(typeof(ISeansService), typeof(SeansService));
            services.AddScoped(typeof(IServisService), typeof(ServisService));
            services.AddScoped(typeof(ISezonService), typeof(SezonService));
            services.AddScoped(typeof(ISinifService), typeof(SinifService));
            services.AddScoped(typeof(ISinifOgrenciService), typeof(SinifOgrenciService));
            services.AddScoped(typeof(ISozlesmeService), typeof(SozlesmeService));
            services.AddScoped(typeof(ISozlesmeTurService), typeof(SozlesmeTurService));
            services.AddScoped(typeof(ISubeService), typeof(SubeService));
            services.AddScoped(typeof(IVeliDetayService), typeof(VeliDetayService));
            services.AddScoped(typeof(IYayinService), typeof(YayinService));





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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();
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
