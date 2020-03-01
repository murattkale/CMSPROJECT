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
    public class OgrenciSozlesmeOdemeTablosuController : Controller
    {
        IOgrenciSozlesmeOdemeTablosuService _IOgrenciSozlesmeOdemeTablosuService;
        public OgrenciSozlesmeOdemeTablosuController(IOgrenciSozlesmeOdemeTablosuService _IOgrenciSozlesmeOdemeTablosuService) { this._IOgrenciSozlesmeOdemeTablosuService = _IOgrenciSozlesmeOdemeTablosuService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<OgrenciSozlesmeOdemeTablosu> param, OgrenciSozlesmeOdemeTablosu searchModel)
        {
            var result = _IOgrenciSozlesmeOdemeTablosuService.GetPaging(null, true, param, false,
                o => o.OgrenciSozlesme,
                o => o.OgrenciSozlesme.OgrenciDetay,
                o => o.OgrenciSozlesme.OgrenciDetay.Ogrenci


                );
            return Json(result);
        }


        public JsonResult InsertOrUpdate(OgrenciSozlesmeOdemeTablosu postModel)
        {
            var result = _IOgrenciSozlesmeOdemeTablosuService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public OgrenciSozlesmeOdemeTablosu Get(int id)
        {
            var result = _IOgrenciSozlesmeOdemeTablosuService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IOgrenciSozlesmeOdemeTablosuService.Delete(id);
            _IOgrenciSozlesmeOdemeTablosuService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "OgrenciSozlesmeOdemeTablosu";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
