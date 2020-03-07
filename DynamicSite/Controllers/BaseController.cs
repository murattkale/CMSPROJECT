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
        IDocumentsService _IDocumentsService;
        public BaseController(
            IDocumentsService _IDocumentsService,
            IContentPageService _IContentPageService,
         IHttpContextAccessor _IHttpContextAccessor,
         IHostingEnvironment _IHostingEnvironment
            )
        {
            this._IDocumentsService = _IDocumentsService;
            this._IContentPageService = _IContentPageService;
            this._httpContextAccessor = _IHttpContextAccessor;
            this._IHostingEnvironment = _IHostingEnvironment;
        }


        public IActionResult Content()
        {
            var link = HttpContext.Items["cmspage"].ToString();
            if (!string.IsNullOrEmpty(link))
            {
                var menu = _IContentPageService.Where(o => o.Link == link, true, false, o => o.Documents).Result.FirstOrDefault();
                if (menu != null)
                {
                    menu.Documents = menu.Documents.Where(o => o.dataid == o.ContentPage.Id && o.IsDeleted == null).ToList();
                    ViewBag.page = menu;
                    return View();
                }
                //else if (_IContentPageService.Where(o => o.Link == link).Result.FirstOrDefault() != null)
                //{
                //    ViewBag.page = _IContentPageService.Where(o => o.Link == link).Result.FirstOrDefault();
                //    return View();
                //}
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
            var link = HttpContext.Request.Path.Value.Trim().ToStr();
            var content = _IContentPageService.Where(o => o.Link == link, true, false, o => o.ContentPageChilds, o => o.Parent).Result.ToList();

            var document = _IDocumentsService.Where().Result.ToList();

            content.ForEach(o =>
            {
                o.Documents = document.Where(oo => oo.dataid == o.Id && oo.IsDeleted == null).ToList();
                o.ContentPageChilds = o.ContentPageChilds.Where(oo => oo.IsDeleted == null).Select(o => new ContentPage
                {
                    Name = o.Name,
                    Link = o.Link,
                    ContentOrderNo = o.ContentOrderNo,
                    ButtonText1 = o.ButtonText1,
                    ButtonText1Link = o.ButtonText1Link,
                    ButtonText2 = o.ButtonText2,
                    ButtonText2Link = o.ButtonText2Link,
                    ContentShort = o.ContentShort,
                    ContentPageType = o.ContentPageType,
                    Documents = document.Where(oo => oo.dataid == o.Id && oo.IsDeleted == null).ToList()
                }).ToList();

            });
            ViewBag.content = content;



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
