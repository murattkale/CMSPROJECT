using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DynamicSiteCMS
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

            services.AddScoped(typeof(ISendMail), typeof(SendMail));//Kullanýcaðýnýz servis projesinden en az birtane servisi çaðýrmalýsýnýz.

            var servicesAll = AppDomain.CurrentDomain.GetAssemblies().Where(o => o.GetName().Name.Contains("DynamicSiteService"))
                .FirstOrDefault().DefinedTypes.Where(o => !o.Name.Contains("SendMail") && !o.IsInterface && o.BaseType.Name.Contains("GenericRepo")).ToList();
            servicesAll.ForEach(baseService => { services.AddScoped(baseService.GetInterface("I" + baseService.Name), baseService); });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration config)
        {
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                //app.Run(async (context) =>
                //{
                //var sb = new StringBuilder();
                //var nl = System.Environment.NewLine;
                //var rule = string.Concat(nl, new string('-', 40), nl);
                //var authSchemeProvider = app.ApplicationServices
                //    .GetRequiredService<IAuthenticationSchemeProvider>();

                //sb.Append($"Request{rule}");
                //sb.Append($"{DateTimeOffset.Now}{nl}");
                //sb.Append($"{context.Request.Method} {context.Request.Path}{nl}");
                //sb.Append($"Scheme: {context.Request.Scheme}{nl}");
                //sb.Append($"Host: {context.Request.Headers["Host"]}{nl}");
                //sb.Append($"PathBase: {context.Request.PathBase.Value}{nl}");
                //sb.Append($"Path: {context.Request.Path.Value}{nl}");
                //sb.Append($"Query: {context.Request.QueryString.Value}{nl}{nl}");

                //sb.Append($"Connection{rule}");
                //sb.Append($"RemoteIp: {context.Connection.RemoteIpAddress}{nl}");
                //sb.Append($"RemotePort: {context.Connection.RemotePort}{nl}");
                //sb.Append($"LocalIp: {context.Connection.LocalIpAddress}{nl}");
                //sb.Append($"LocalPort: {context.Connection.LocalPort}{nl}");
                //sb.Append($"ClientCert: {context.Connection.ClientCertificate}{nl}{nl}");

                //sb.Append($"Identity{rule}");
                //sb.Append($"User: {context.User.Identity.Name}{nl}");
                //var scheme = await authSchemeProvider
                //    .GetSchemeAsync(IISDefaults.AuthenticationScheme);
                //sb.Append($"DisplayName: {scheme?.DisplayName}{nl}{nl}");

                //sb.Append($"Headers{rule}");
                //foreach (var header in context.Request.Headers)
                //{
                //    sb.Append($"{header.Key}: {header.Value}{nl}");
                //}
                //sb.Append(nl);

                //sb.Append($"Websockets{rule}");
                //if (context.Features.Get<IHttpUpgradeFeature>() != null)
                //{
                //    sb.Append($"Status: Enabled{nl}{nl}");
                //}
                //else
                //{
                //    sb.Append($"Status: Disabled{nl}{nl}");
                //}

                //sb.Append($"Configuration{rule}");
                //foreach (var pair in config.AsEnumerable())
                //{
                //    sb.Append($"{pair.Key}: {pair.Value}{nl}");
                //}
                //sb.Append(nl);

                //sb.Append($"Environment Variables{rule}");
                //var vars = System.Environment.GetEnvironmentVariables();
                //foreach (var key in vars.Keys.Cast<string>().OrderBy(key => key,
                //    StringComparer.OrdinalIgnoreCase))
                //{
                //    var value = vars[key];
                //    sb.Append($"{key}: {value}{nl}");
                //}

                //context.Response.ContentType = "text/plain";
                //await context.Response.WriteAsync(sb.ToString());
                //});
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthorization();
            app.UseAuthenticationMiddleware();


            SessionRequest.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());


            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Base}/{action=Index}/{Id?}");
            });
        }
    }
}
