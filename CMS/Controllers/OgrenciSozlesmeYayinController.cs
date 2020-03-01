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
    public class OgrenciSozlesmeYayinController : Controller
    {
        IOgrenciSozlesmeYayinService _IOgrenciSozlesmeYayinService;
        public OgrenciSozlesmeYayinController(IOgrenciSozlesmeYayinService _IOgrenciSozlesmeYayinService) { this._IOgrenciSozlesmeYayinService = _IOgrenciSozlesmeYayinService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<OgrenciSozlesmeYayin> param, OgrenciSozlesmeYayin searchModel)
        {
            var result = _IOgrenciSozlesmeYayinService.GetPaging(null, true, param, false);
            return Json(result);
        }


        public JsonResult InsertOrUpdate(OgrenciSozlesmeYayin postModel)
        {
            var result = _IOgrenciSozlesmeYayinService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public OgrenciSozlesmeYayin Get(int id)
        {
            var result = _IOgrenciSozlesmeYayinService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IOgrenciSozlesmeYayinService.Delete(id);
            _IOgrenciSozlesmeYayinService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "OgrenciSozlesmeYayin";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
