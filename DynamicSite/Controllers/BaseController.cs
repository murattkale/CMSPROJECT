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


        public IActionResult Sayfa()
        {
            var link = HttpContext.Items["cmspage"].ToString();
            if (!string.IsNullOrEmpty(link))
            {
                var menu = _IContentPageService.Where(o => o.Link == link, true, false, o => o.Documents).Result.FirstOrDefault();
                if (menu != null)
                {
                    var document = _IDocumentsService.Where().Result.ToList();

                    menu.Documents = document.Where(o => o.ContentPageId == menu.Id).ToList();
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
            setData();
            return View();
        }


        public void setData()
        {
            #region dynamicContent
            var link = HttpContext.Request.Path.Value.Trim().ToStr();
            var contentPages = _IContentPageService.Where(null, true, false, o => o.ContentPageChilds, o => o.Parent).Result.ToList();
            var document = _IDocumentsService.Where().Result.ToList();

            ViewBag.IsHeaderMenu = contentPages.Where(o => o.IsHeaderMenu == true).OrderBy(o => o.ContentOrderNo).ThenBy(o => o.Name).ToList();
            ViewBag.IsFooterMenu = contentPages.Where(o => o.IsFooterMenu == true).OrderBy(o => o.ContentOrderNo).ThenBy(o => o.Name).ToList();
            var content = contentPages.ToList();

            content.ForEach(o =>
            {
                o.Documents = document.Where(oo => oo.ContentPageId == o.Id && oo.IsDeleted == null).ToList();
                o.ContentPageChilds = o.ContentPageChilds.Where(oo => oo.IsDeleted == null).Select(o => new ContentPage
                {
                    Id = o.Id,
                    Name = o.Name,
                    Link = o.Link,
                    ContentOrderNo = o.ContentOrderNo,
                    ButtonText1 = o.ButtonText1,
                    ButtonText1Link = o.ButtonText1Link,
                    ButtonText2 = o.ButtonText2,
                    ButtonText2Link = o.ButtonText2Link,
                    VideoLink = o.VideoLink,
                    ResimLink = o.ResimLink,
                    ContentShort = o.ContentShort,
                    ContentPageType = o.ContentPageType,
                    Documents = document.Where(oo => oo.ContentPageId == o.Id && oo.IsDeleted == null).ToList()
                }).ToList();

            });
            ViewBag.content = content;
            #endregion
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
