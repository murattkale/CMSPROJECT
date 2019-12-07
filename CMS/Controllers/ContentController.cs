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

namespace CMS.Controllers
{
    public class ContentController : Controller
    {
        IContentService _service_Content;
        public ContentController(IContentService _service_Content) { this._service_Content = _service_Content; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Content> param, Content searchModel)
        {
            var result = _service_Content.Where(null, null, true, param, false, null);

            if (param == null || param.Draw == 0)
            {
                var resultData = result.Result.ToList();
                return Json(resultData);
            }
            else
            {
                var resultData = result.ResultPaging;
                return Json(resultData);
            }

        }


        public JsonResult InsertOrUpdate(Content postModel)
        {
            var result = _service_Content.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Content Get(int id)
        {
            var result = _service_Content.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _service_Content.Delete(id);
            _service_Content.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Content";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
