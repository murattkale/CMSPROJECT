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

    public class MenuView : ViewComponent
    {

        IHttpContextAccessor _httpContextAccessor;
        IContentPageService _IContentPageService;
        IDocumentsService _IDocumentsService;
        public MenuView(
            IContentPageService _IContentPageService,
            IDocumentsService _IDocumentsService,
        IHttpContextAccessor httpContextAccessor
            )
        {
            this._IContentPageService = _IContentPageService;
            this._httpContextAccessor = httpContextAccessor;
            this._IDocumentsService = _IDocumentsService;
        }



        public IViewComponentResult Invoke(string type)
        {
            #region dynamicContent
            var link = HttpContext.Request.Path.Value.Trim().ToStr();
            var contentPages = _IContentPageService.Where(null, true, false, o => o.ContentPageChilds, o => o.Documents, o => o.Parent).Result.ToList();

            ViewBag.IsHeaderMenu = contentPages.Where(o => o.IsHeaderMenu == true).OrderBy(o => o.ContentOrderNo).ThenBy(o => o.Name).ToList();
            ViewBag.IsFooterMenu = contentPages.Where(o => o.IsFooterMenu == true).OrderBy(o => o.ContentOrderNo).ThenBy(o => o.Name).ToList();
            var content = contentPages.Where(o => o.Link == link).ToList();


            ViewBag.content = content;
            #endregion


            if (type == "h")
            {
                return View("_Header");
            }
            else
            {
                return View("_Footer");
            }


        }



    }
}