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
