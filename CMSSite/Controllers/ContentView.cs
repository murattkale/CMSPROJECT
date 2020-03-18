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
            var listAll = _IContentPageService.Where(null, true, false, o => o.Documents).Result.OrderByDescending(o => o.CreaDate).AsQueryable();

            var paths = _httpContextAccessor.HttpContext.Request.Path.ToUriComponent().Split('/').Where(o => !string.IsNullOrEmpty(o)).ToList();

            listAll = listAll.Where(o => o.KurumId == SessionRequest.KurumId);

            if (paths.Count() > 2 && paths.Any(o => (o.Contains("sube") || o.Contains("iletisim"))) && SessionRequest.SubeId > 0)
            {
                SessionRequest.SubeId = paths.LastOrDefault().ToInt();
                listAll = listAll.Where(o => o.SubeId == SessionRequest.SubeId);
            }
            else
            {
                SessionRequest.SubeId = 0;
            }

            var list = listAll.Where(o => o.ContentPageType == (ContentPageType));

            var lastList = list.ToList();
            ViewBag.contents = lastList.ToList();

            switch (ContentPageType)
            {
                case ContentPageType.row1:
                    {
                        return View("row1");
                    }
                case ContentPageType.row2:
                    {
                        return View("row2");
                    }
                case ContentPageType.row4:
                    {
                        return View("row4");
                    }
                case ContentPageType.sliderUst:
                    {
                        return View("sliderUst");
                    }
                case ContentPageType.sliderAlt:
                    {
                        return View("sliderAlt");
                    }
                case ContentPageType.etkinlikler3:
                    {
                        return View("etkinlikler3");
                    }
                case ContentPageType.haberler3:
                    {
                        return View("haberler3");
                    }
                case ContentPageType.galeri:
                    {
                        return View("galeri");
                    }
                case ContentPageType.haberler:
                    {
                        var lastListSon = listAll.Where(o => o.ContentPageType == ContentPageType.haberler3 || o.ContentPageType == ContentPageType).OrderByDescending(o => o.CreaDate).ToList();
                        //lastListSon.ForEach(o => { o.Documents = o.Documents.Where(oo => oo.dataid == o.Id && oo.IsDeleted == null).ToList(); });
                        ViewBag.contents = lastListSon.ToList();
                        return View("haberler");
                    }
                case ContentPageType.etkinlikler:
                    {
                        var lastListSon = listAll.Where(o => o.ContentPageType == ContentPageType.etkinlikler3 || o.ContentPageType == ContentPageType).OrderByDescending(o => o.CreaDate).ToList();
                        //lastListSon.ToList().ForEach(o => { o.Documents = o.Documents.Where(oo => oo.dataid == o.Id && oo.IsDeleted == null).ToList(); });
                        ViewBag.contents = lastListSon.ToList();
                        return View("etkinlikler");
                    }

            }
            return View();
        }



    }
}