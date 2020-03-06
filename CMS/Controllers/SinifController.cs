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
    public class SinifController : Controller
    {
        ISinifService _ISinifService;
        public SinifController(ISinifService _ISinifService) { this._ISinifService = _ISinifService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Sinif> param, Sinif searchModel)
        {
            var result = _ISinifService.GetPaging(null, true, param, false, o => o.Seans, o => o.Derslik, o => o.Sube);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _ISinifService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Sinif postModel)
        {
            var result = _ISinifService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Sinif Get(int id)
        {
            var result = _ISinifService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _ISinifService.Delete(id);
            _ISinifService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Sinif";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
