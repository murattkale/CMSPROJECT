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
            var document = _IDocumentsService.Where().Result.ToList();

            var list = contentPages.Where(o => o.ContentPageType == ContentPageType);

            var lastList = list.ToList();

            lastList.ForEach(o =>
            {
                o.Documents = document.Where(oo => oo.ContentPageId == o.Id && oo.IsDeleted == null).ToList();
                o.ContentPageChilds = o.ContentPageChilds.Where(oo => oo.IsDeleted == null).Select(o => new ContentPage
                {
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
                case ContentPageType.Sayfa:
                    {
                        return View("Sayfa");
                    }
            }


            return View();
        }



    }
}