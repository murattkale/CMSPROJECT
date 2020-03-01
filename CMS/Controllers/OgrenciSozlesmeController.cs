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
    public class OgrenciSozlesmeController : Controller
    {
        IOgrenciSozlesmeService _IOgrenciSozlesmeService;
        public OgrenciSozlesmeController(IOgrenciSozlesmeService _IOgrenciSozlesmeService) { this._IOgrenciSozlesmeService = _IOgrenciSozlesmeService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<OgrenciSozlesme> param, OgrenciSozlesme searchModel)
        {
            var result = _IOgrenciSozlesmeService.GetPaging(null, true, param, false,
                o => o.OgrenciDetay,
                o => o.OgrenciDetay.Ogrenci,
                o => o.SozlesmeTur,
                o => o.Sube,
                o => o.KurumaGetirenPersonel,
                o => o.Sezon,
                o => o.Servis,
                o => o.Finansor


                );
            return Json(result);
        }


        public JsonResult InsertOrUpdate(OgrenciSozlesme postModel)
        {
            var result = _IOgrenciSozlesmeService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public OgrenciSozlesme Get(int id)
        {
            var result = _IOgrenciSozlesmeService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IOgrenciSozlesmeService.Delete(id);
            _IOgrenciSozlesmeService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "OgrenciSozlesme";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
