﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;

namespace DynamicSiteCMS.Controllers
{
    public class BaseController : Controller
    {

        IHostingEnvironment _IHostingEnvironment;
        IServiceConfigService _IServiceConfigService;
        IHttpContextAccessor _IHttpContextAccessor;

        public BaseController(IHostingEnvironment _IHostingEnvironment, IServiceConfigService _IServiceConfigService, IHttpContextAccessor _IHttpContextAccessor)
        {
            this._IHostingEnvironment = _IHostingEnvironment;
            this._IServiceConfigService = _IServiceConfigService;
            this._IHttpContextAccessor = _IHttpContextAccessor;

        }


        public IActionResult Index()
        {


            if (SessionRequest._User == null)
            {
                return RedirectToAction("Login1", "Login");
            }
            ViewBag.pageTitle = "Dashboard";

            var menus = _IServiceConfigService.Where().Result.ToList();
            _IHttpContextAccessor.HttpContext.Session.Set("menus", menus);

            if (menus.Count<1)
            {
                var menuler = Directory.EnumerateFiles(_IHostingEnvironment.ContentRootPath + @"\Views", "*", SearchOption.AllDirectories).Select(o =>
                   o.Split("\\")[8].ToStr()

                   ).Where(o =>
                   !o.ToStr().Contains("Base")
                   && !o.ToStr().Contains("Shared")
                   && !o.ToStr().Contains("Login")
                   && !o.ToStr().Contains("_")
                   ).Distinct().OrderBy(o => o).ToList();

                menuler.ForEach(o =>
                {
                    _IServiceConfigService.Add(new ServiceConfig()
                    {
                        Name = o,
                        Description = o,
                        Url = "/" + o,
                        ServiceName = o
                    });
                    _IServiceConfigService.SaveChanges();
                });
            }




            return View();
        }


        public IActionResult Logout()
        {
            _IHttpContextAccessor.HttpContext.Session.Clear();
            return RedirectToAction("Login1", "Login");
        }

        public IActionResult Report()
        {
            return View();
        }


    }
}
