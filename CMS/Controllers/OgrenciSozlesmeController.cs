using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


using Entity;


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
                  o => o.SozlesmeTur
                  //o => o.OgrenciDetay
                  //o => o.OgrenciDetay.Okul,
                  //o => o.OgrenciDetay.Ogrenci,
                  //o => o.OgrenciSozlesmeOdemeTablosu,
                  //o => o.GorusenPersonel,
                  //o => o.KurumaGetirenPersonel,
                  //o => o.Finansor,
                  //o => o.Servis,
                  //o => o.Sezon,
                  //o => o.Sube,
                  //o => o.Sube.Kurum
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
            var result = _IOgrenciSozlesmeService.Where(o => o.OgrenciDetayId == id).Result.FirstOrDefault();
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
