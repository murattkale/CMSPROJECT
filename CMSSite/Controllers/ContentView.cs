using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CMS.Components
{

    public class ContentView : ViewComponent
    {
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
        ITownService _ITownService
            )
        {
            this._IContentPageService = _IContentPageService;
            this._IKurumService = _IKurumService;
            this._ISubeService = _ISubeService;
            this._ICityService = _ICityService;
            this._ITownService = _ITownService;


        }



        public IViewComponentResult Invoke(ContentPageType ContentPageType)
        {
            var list = _IContentPageService.Where(o => o.KurumId == SessionRequest.KurumId && o.ContentPageType == (int)ContentPageType)
                .Result.OrderByDescending(o => o.CreaDate).AsQueryable();

            if (SessionRequest.SubeId > 0)
            {
                list = list.Where(o => o.Id == SessionRequest.SubeId);
            }

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
                        ViewBag.contents = list.ToList();
                        return View("etkinlikler");
                    }
                case ContentPageType.etkinlikler3:
                    {
                        list = _IContentPageService.Where(o => o.ContentPageType == (int)ContentPageType.etkinlikler).Result.OrderByDescending(o => o.CreaDate);
                        if (SessionRequest.SubeId > 0)
                        {
                            list = list.Where(o => o.Id == SessionRequest.SubeId);
                        }
                        ViewBag.contents = list.Take(3).ToList();
                        return View("etkinlikler3");
                    }
                case ContentPageType.haberler:
                    {
                        ViewBag.contents = list.ToList();
                        return View("haberler");
                    }
                case ContentPageType.haberler3:
                    {
                        list = _IContentPageService.Where(o => o.ContentPageType == (int)ContentPageType.haberler).Result.OrderByDescending(o => o.CreaDate);
                        if (SessionRequest.SubeId > 0)
                        {
                            list = list.Where(o => o.Id == SessionRequest.SubeId);
                        }
                        ViewBag.contents = list.Take(3).ToList();
                        return View("haberler3");
                    }
            }
            return View();
        }
     


    }
}