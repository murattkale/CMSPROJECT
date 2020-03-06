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
            var content = _IContentPageService.Where(o => o.Link == link, true, false, o => o.Documents, o => o.ContentPageChilds, o => o.Parent).Result.ToList();
            content.ForEach(o => { 
                o.Documents = o.Documents.Where(oo => oo.IsDeleted == null).ToList();
                o.ContentPageChilds = o.ContentPageChilds.Where(oo => oo.IsDeleted == null).ToList();
            
            });
            ViewBag.content = content;

            //ViewBag.kategori = allContent.Where(o => o.ContentPageType == ContentPageType.kategori);
            //ViewBag.Sayfa = allContent.FirstOrDefault(o => o.ContentPageType == ContentPageType.Sayfa);
            //ViewBag.row1 = allContent.FirstOrDefault(o => o.ContentPageType == ContentPageType.row1);
            //ViewBag.row2 = allContent.Where(o => o.ContentPageType == ContentPageType.row2);
            //ViewBag.row3 = allContent.Where(o => o.ContentPageType == ContentPageType.row3);
            //ViewBag.row4 = allContent.Where(o => o.ContentPageType == ContentPageType.row4);
            //ViewBag.row5 = allContent.FirstOrDefault(o => o.ContentPageType == ContentPageType.row5);
            //ViewBag.etkinlikler = allContent.Where(o => o.ContentPageType == ContentPageType.etkinlikler);
            //ViewBag.blog = allContent.Where(o => o.ContentPageType == ContentPageType.blog);
            //ViewBag.haberler = allContent.Where(o => o.ContentPageType == ContentPageType.haberler);
            //ViewBag.galeri = allContent.Where(o => o.ContentPageType == ContentPageType.galeri);
            //ViewBag.sliderUst = allContent.Where(o => o.ContentPageType == ContentPageType.sliderUst);
            //ViewBag.sliderAlt = allContent.Where(o => o.ContentPageType == ContentPageType.sliderAlt);

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
