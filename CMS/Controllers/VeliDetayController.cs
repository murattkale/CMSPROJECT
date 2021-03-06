﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


using Entity;


namespace CMS.Controllers
{
    public class VeliDetayController : Controller
    {
        IVeliDetayService _IVeliDetayService;
        public VeliDetayController(IVeliDetayService _IVeliDetayService) { this._IVeliDetayService = _IVeliDetayService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<VeliDetay> param, VeliDetay searchModel)
        {
            var result = _IVeliDetayService.GetPaging(null, true, param, false, o => o.OgrenciDetay, o => o.OgrenciDetay.Ogrenci);
            return Json(result);
        }


        public JsonResult GetYakinlikDerecesi()
        {
            var list = Enum.GetValues(typeof(YakinlikDerecesi)).Cast<int>().Select(x => new { name = ((YakinlikDerecesi)x).ToStr(), value = x.ToString(), text = ((YakinlikDerecesi)x).ExGetDescription() }).ToArray();
            return Json(list);
        }

        public JsonResult InsertOrUpdate(VeliDetay postModel)
        {
            var result = _IVeliDetayService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public VeliDetay Get(int id)
        {
            var result = _IVeliDetayService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IVeliDetayService.Delete(id);
            _IVeliDetayService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "VeliDetay";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
