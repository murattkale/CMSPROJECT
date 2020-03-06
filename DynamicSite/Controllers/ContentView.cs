using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DynamicSite.Components
{

    public class ContentView : ViewComponent
    {

        IHttpContextAccessor _httpContextAccessor;
        IContentPageService _IContentPageService;
        public ContentView(
            IContentPageService _IContentPageService,

        IHttpContextAccessor httpContextAccessor
            )
        {
            this._IContentPageService = _IContentPageService;
            this._httpContextAccessor = httpContextAccessor;


        }



        public IViewComponentResult Invoke(ContentPageType ContentPageType)
        {
            var listAll = _IContentPageService.Where(null, true, false, o => o.Documents).Result.OrderByDescending(o => o.CreaDate).AsQueryable();


            var list = listAll.Where(o => o.ContentPageType == ContentPageType);

            var lastList = list.ToList();
            lastList.ForEach(o => { o.Documents = o.Documents.Where(oo => oo.dataid == o.Id && oo.IsDeleted == null).ToList(); });
            ViewBag.contents = lastList.ToList();

            switch (ContentPageType)
            {

                case ContentPageType.galeri:
                    {
                        return View("galeri");
                    }
                case ContentPageType.haberler:
                    {
                        return View("haberler");
                    }
                case ContentPageType.etkinlikler:
                    {
                        return View("etkinlikler");
                    }

            }


            return View();
        }



    }
}