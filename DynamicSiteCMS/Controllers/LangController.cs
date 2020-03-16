using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;



namespace DynamicSiteCMS.Controllers
{
    public class LangController : Controller
    {
        ILangService _ILangService;
        public LangController(ILangService _ILangService) { this._ILangService = _ILangService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Lang> param, Lang searchModel)
        {
            var result = _ILangService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _ILangService.Where().Result.Select(o => new { value = o.Id, text = o.Name }).ToList();
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Lang postModel)
        {
            var result = _ILangService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Lang Get(int id)
        {
            var result = _ILangService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _ILangService.Delete(id);
            _ILangService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Dil";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
