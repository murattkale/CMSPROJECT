using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace DynamicSite.Controllers
{
    public class BaseController : Controller
    {
        IHttpContextAccessor _httpContextAccessor;
        IHostingEnvironment _IHostingEnvironment;
        IContentPageService _IContentPageService;
        public BaseController(
            IContentPageService _IContentPageService,
         IHttpContextAccessor _IHttpContextAccessor,
         IHostingEnvironment _IHostingEnvironment
            )
        {
            this._IContentPageService = _IContentPageService;
            this._httpContextAccessor = _IHttpContextAccessor;
            this._IHostingEnvironment = _IHostingEnvironment;
        }


        public IActionResult Content()
        {
            var link = HttpContext.Items["cmspage"].ToString();
            if (!string.IsNullOrEmpty(link))
            {
                var menu = _IContentPageService.Where(o => o.Link == link).Result.FirstOrDefault();
                if (menu != null)
                {
                    ViewBag.page = menu;
                    return View();
                }
                else if (_IContentPageService.Where(o => o.Link == link).Result.FirstOrDefault() != null)
                {
                    ViewBag.page = _IContentPageService.Where(o => o.Link == link).Result.FirstOrDefault();
                    return View();
                }
                else
                {
                    return Redirect(SessionRequest.baseUrl);
                }


            }
            else
            {
                return Redirect(SessionRequest.baseUrl);
            }

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult hakkimizda()
        {
            return View();
        }


        public IActionResult biznasilcalisiriz()
        {
            return View();
        }


        public IActionResult iletisim()
        {
            return View();
        }

        public IActionResult referanslar()
        {
            return View();
        }


        public IActionResult paketlerimiz()
        {
            return View();
        }

        public IActionResult istatistikler()
        {
            return View();
        }

        public IActionResult sosyalmedya()
        {
            return View();
        }



    }
}
