using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;





namespace ProductCMS.Controllers
{
    public class TownController : Controller
    {
        ITownService _ITownService;
        public TownController(ITownService _ITownService) { this._ITownService = _ITownService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Town> param, Town searchModel)
        {
            var result = _ITownService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect(int id)
        {
            var result = _ITownService.Where(o=>o.CityId == id).Result.Select(o => new { value = o.Id, text = o.TownName }).ToList();
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Town postModel)
        {
            var result = _ITownService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Town Get(int id)
        {
            var result = _ITownService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _ITownService.Delete(id);
            _ITownService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Town";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
