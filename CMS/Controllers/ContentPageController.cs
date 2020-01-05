using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Models;
using Services;
using Entity;
using Entity.CMSDB;

namespace CMS.Controllers
{
    public class ContentPageController : Controller
    {
        IContentPageService _IContentPageService;
        public ContentPageController(IContentPageService _IContentPageService)
        {
            this._IContentPageService = _IContentPageService;

            getContentPageType();
        }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<ContentPage> param, ContentPage searchModel)
        {
            var result = _IContentPageService.GetPaging(null, true, param, false, o => o.Kurum);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetParent()
        {
            var result = _IContentPageService.Where().Result.Select(o => new { value = o.Id, text = o.Name });
            return Json(result);
        }


        public JsonResult InsertOrUpdate(ContentPage postModel)
        {
            var result = _IContentPageService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public ContentPage Get(int id)
        {
            var result = _IContentPageService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IContentPageService.Delete(id);
            _IContentPageService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "ContentPage";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


        public JsonResult getContentPageType()
        {
            var list = Enum.GetValues(typeof(ContentPageType)).Cast<int>().Select(x => new { value = x.ToString(), text = ((ContentPageType)x).ExGetDescription() }).ToArray();
            return Json(list);
        }

    }
}
