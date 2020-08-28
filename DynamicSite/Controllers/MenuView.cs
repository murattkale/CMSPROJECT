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

            ViewBag.IsHeaderMenu = _IContentPageService.Where(o => o.IsHeaderMenu == true).Result.OrderBy(o => o.ContentOrderNo).ThenBy(o => o.Name).ToList();
            ViewBag.IsFooterMenu = _IContentPageService.Where(o => o.IsFooterMenu == true).Result.OrderBy(o => o.ContentOrderNo).ThenBy(o => o.Name).ToList();
            var content = _IContentPageService.Where(o => o.Link == link).Result.ToList();


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