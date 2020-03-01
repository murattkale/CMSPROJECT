using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Models;

using Entity;
using Entity.ContextModel;

namespace CMS.Controllers
{
    public class OgrenciDetayController : Controller
    {
        IOgrenciDetayService _IOgrenciDetayService;
        public OgrenciDetayController(IOgrenciDetayService _IOgrenciDetayService) { this._IOgrenciDetayService = _IOgrenciDetayService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<OgrenciDetay> param, OgrenciDetay searchModel)
        {
            var result = _IOgrenciDetayService.GetPaging(null, true, param, false, o => o.NeredenDuydunuz, o => o.Okul, o => o.Ogrenci);
            return Json(result);
        }


        public JsonResult InsertOrUpdate(OgrenciDetay postModel)
        {
            var result = _IOgrenciDetayService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public OgrenciDetay Get(int id)
        {
            var result = _IOgrenciDetayService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IOgrenciDetayService.Delete(id);
            _IOgrenciDetayService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "OgrenciDetay";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
