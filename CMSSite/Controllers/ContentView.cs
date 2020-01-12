using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CMS.Components
{

    public class ContentView : ViewComponent
    {

        IHttpContextAccessor _httpContextAccessor;


        IContentPageService _IContentPageService;
        IKurumService _IKurumService;
        ISubeService _ISubeService;
        ICityService _ICityService;
        ITownService _ITownService;
        public ContentView(
            IContentPageService _IContentPageService,

             IKurumService _IKurumService,
        ISubeService _ISubeService,
        ICityService _ICityService,
        ITownService _ITownService,
        IHttpContextAccessor httpContextAccessor
            )
        {
            this._IContentPageService = _IContentPageService;
            this._IKurumService = _IKurumService;
            this._ISubeService = _ISubeService;
            this._ICityService = _ICityService;
            this._ITownService = _ITownService;

            this._httpContextAccessor = httpContextAccessor;


        }



        public IViewComponentResult Invoke(ContentPageType ContentPageType)
        {
            var listAll = _IContentPageService.Where().Result.OrderByDescending(o => o.CreaDate).AsQueryable();

              

            var paths = _httpContextAccessor.HttpContext.Request.Path.ToUriComponent().Split('/').Where(o => !string.IsNullOrEmpty(o)).ToList();

            if (paths.Count() > 2 && paths.Any(o => (o.Contains("sube") || o.Contains("iletisim"))) && SessionRequest.SubeId > 0)
            {
                SessionRequest.SubeId = paths.LastOrDefault().ToInt();
                listAll = listAll.Where(o => o.SubeId == SessionRequest.SubeId);
            }
            else
            {
                SessionRequest.SubeId = 0;
                listAll = listAll.Where(o => o.KurumId == SessionRequest.KurumId);

            }

            var list = listAll.Where(o => o.ContentPageType == (int)ContentPageType);



            switch (ContentPageType)
            {
                case ContentPageType.row1:
                    {
                        ViewBag.contents = list.ToList();
                        return View("row1");
                    }
                case ContentPageType.row2:
                    {
                        ViewBag.contents = list.ToList();
                        return View("row2");
                    }
                case ContentPageType.row3:
                    {
                        ViewBag.contents = list.ToList();
                        return View("row3");
                    }
                case ContentPageType.row4:
                    {
                        ViewBag.contents = list.ToList();
                        return View("row4");
                    }
                case ContentPageType.sliderUst:
                    {
                        ViewBag.contents = list.ToList();
                        return View("sliderUst");
                    }
                case ContentPageType.sliderAlt:
                    {
                        ViewBag.contents = list.ToList();
                        return View("sliderAlt");
                    }
                case ContentPageType.etkinlikler:
                    {
                        listAll = listAll.Where(o => o.ContentPageType == (int)ContentPageType.etkinlikler3 || o.ContentPageType == (int)ContentPageType).OrderByDescending(o => o.CreaDate);
                        ViewBag.contents = listAll.ToList();
                        return View("etkinlikler");
                    }
                case ContentPageType.etkinlikler3:
                    {
                        ViewBag.contents = list.Take(3).ToList();
                        return View("etkinlikler3");
                    }
                case ContentPageType.haberler:
                    {
                        listAll = listAll.Where(o => o.ContentPageType == (int)ContentPageType.haberler3 || o.ContentPageType == (int)ContentPageType).OrderByDescending(o => o.CreaDate);
                        ViewBag.contents = listAll.ToList();
                        return View("haberler");
                    }
                case ContentPageType.haberler3:
                    {
                        ViewBag.contents = list.Take(3).ToList();
                        return View("haberler3");
                    }
            }
            return View();
        }



    }
}