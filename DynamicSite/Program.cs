using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DynamicSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)

              .ConfigureWebHostDefaults(webBuilder =>
              {
                  //webBuilder.UseUrls("http://localhost:1111");
                  //webBuilder.UseKestrel();
                  webBuilder.UseStartup<Startup>()
                   .CaptureStartupErrors(true)
                   .UseSetting("detailedErrors", "true")
                  ;
              });
    }

}