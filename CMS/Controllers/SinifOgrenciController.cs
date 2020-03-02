using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Models;

using Entity; using Entity.ContextModel;

namespace CMS.Controllers
{
    public class SinifOgrenciController : Controller
    {
        ISinifOgrenciService _ISinifOgrenciService;
        public SinifOgrenciController(ISinifOgrenciService _ISinifOgrenciService) { this._ISinifOgrenciService = _ISinifOgrenciService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<SinifOgrenci> param, SinifOgrenci searchModel)
        {
            var result = _ISinifOgrenciService.GetPaging(null, true, param, false);
            return Json(result);
        }


        public JsonResult InsertOrUpdate(SinifOgrenci postModel)
        {
            var result = _ISinifOgrenciService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public SinifOgrenci Get(int id)
        {
            var result = _ISinifOgrenciService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _ISinifOgrenciService.Delete(id);
            _ISinifOgrenciService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "SinifOgrenci";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
