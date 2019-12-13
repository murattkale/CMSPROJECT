using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using GenericRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;

namespace CMS
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

            //unutulmayan hata json result ba� harf k���k > b�y�k
            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });


            services.AddEntityFrameworkSqlServer().AddDbContext<EFContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("EFContext"), b => b.MigrationsAssembly("EFContext")));

            services.AddEntityFrameworkSqlServer().AddDbContext<MuhasebeContext>(opt =>
          opt.UseSqlServer(Configuration.GetConnectionString("MuhasebeContext"), b => b.MigrationsAssembly("MuhasebeContext")));


            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped(typeof(IBaseSession), typeof(BaseSession));

            services.AddScoped(typeof(IMenusService), typeof(MenusService));
            services.AddScoped(typeof(IContentService), typeof(ContentService));
            services.AddScoped(typeof(IFormlarService), typeof(FormlarService));

            services.AddScoped(typeof(IBankaService), typeof(BankaService));
            services.AddScoped(typeof(IParaBirimiService), typeof(ParaBirimiService));




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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Menus}/{action=Index}/{id?}");
            });
        }
    }
}
