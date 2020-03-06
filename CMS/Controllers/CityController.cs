using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Models;

using Entity;


namespace CMS.Controllers
{
    public class CityController : Controller
    {
        ICityService _ICityService;
        public CityController(ICityService _ICityService) { this._ICityService = _ICityService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<City> param, City searchModel)
        {
            var result = _ICityService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _ICityService.Where().Result.Select(o => new { value = o.Id, text = o.CityName }).ToList();
            return Json(result);
        }


        public JsonResult InsertOrUpdate(City postModel)
        {
            var result = _ICityService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public City Get(int id)
        {
            var result = _ICityService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _ICityService.Delete(id);
            _ICityService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "City";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
