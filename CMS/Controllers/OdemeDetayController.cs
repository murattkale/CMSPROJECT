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
using Entity.MuhasebeContext;

namespace CMS.Controllers
{
    public class OdemeDetayController : Controller
    {
        IOdemeDetayService _IOdemeDetayService;
        public OdemeDetayController(IOdemeDetayService _IOdemeDetayService) { this._IOdemeDetayService = _IOdemeDetayService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<OdemeDetay> param, OdemeDetay searchModel)
        {
            var result = _IOdemeDetayService.GetPaging(null, true, param, false, o => o.Hesap);
            return Json(result);
        }

        public JsonResult InsertOrUpdate(OdemeDetay postModel)
        {
            var result = _IOdemeDetayService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public OdemeDetay Get(int id)
        {
            var result = _IOdemeDetayService.Where(o=>o.HesapId == id).Result.FirstOrDefault();
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IOdemeDetayService.Delete(id);
            _IOdemeDetayService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "OdemeDetay";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
