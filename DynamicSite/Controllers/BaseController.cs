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
using System.Web;

namespace DynamicSite.Controllers
{
    public class BaseController : Controller
    {
        IHttpContextAccessor _httpContextAccessor;
        IHostingEnvironment _IHostingEnvironment;
        IContentPageService _IContentPageService;
        IDocumentsService _IDocumentsService;
        ISiteConfigService _ISiteConfigService;
        public BaseController(
            IDocumentsService _IDocumentsService,
            IContentPageService _IContentPageService,
         IHttpContextAccessor _IHttpContextAccessor,
         IHostingEnvironment _IHostingEnvironment,
         ISiteConfigService _ISiteConfigService
            )
        {
            this._ISiteConfigService = _ISiteConfigService;
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
                    var config = _ISiteConfigService.Where().Result.FirstOrDefault();
                    _httpContextAccessor.HttpContext.Session.Set("config", config);
                    ViewBag.page = menu;
                    return View();
                }
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
            var contentPages = _IContentPageService.Where(null, true, false, o => o.ContentPageChilds, o => o.Documents).Result.ToList();

            contentPages.ForEach(o =>
            {
                o.ContentPageChilds = contentPages.Where(oo => oo.ContentPageId == o.Id).ToList();
            });

            ViewBag.IsHeaderMenu = contentPages.Where(o => o.IsHeaderMenu == true).OrderBy(o => o.ContentOrderNo).ThenBy(o => o.Name).ToList();
            ViewBag.IsFooterMenu = contentPages.Where(o => o.IsFooterMenu == true).OrderBy(o => o.ContentOrderNo).ThenBy(o => o.Name).ToList();

            ViewBag.contentPages = contentPages;

            var config = _ISiteConfigService.Where().Result.FirstOrDefault();
            _httpContextAccessor.HttpContext.Session.Set("config", config);
            #endregion
        }



    }
}
