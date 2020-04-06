using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DincSite.Components
{

    public class ContentView : ViewComponent
    {

        IHttpContextAccessor _httpContextAccessor;
        IContentPageService _IContentPageService;
        IDocumentsService _IDocumentsService;
        public ContentView(
            IContentPageService _IContentPageService,
            IDocumentsService _IDocumentsService,
        IHttpContextAccessor httpContextAccessor
            )
        {
            this._IContentPageService = _IContentPageService;
            this._httpContextAccessor = httpContextAccessor;
            this._IDocumentsService = _IDocumentsService;
        }



        public IViewComponentResult Invoke(ContentPageType ContentPageType)
        {
            var contentPages = _IContentPageService.Where(null, true, false, o => o.ContentPageChilds, o => o.Documents, o => o.Parent).Result;

            var list = contentPages.Where(o => o.ContentPageType == ContentPageType);
          

            ViewBag.contents = list.ToList();

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
                case ContentPageType.Sayfa:
                    {
                        return View("Sayfa");
                    }
            }


            return View();
        }



    }
}