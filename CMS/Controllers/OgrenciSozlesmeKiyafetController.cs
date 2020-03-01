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
    public class OgrenciSozlesmeKiyafetController : Controller
    {
        IOgrenciSozlesmeKiyafetService _IOgrenciSozlesmeKiyafetService;
        public OgrenciSozlesmeKiyafetController(IOgrenciSozlesmeKiyafetService _IOgrenciSozlesmeKiyafetService) { this._IOgrenciSozlesmeKiyafetService = _IOgrenciSozlesmeKiyafetService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<OgrenciSozlesmeKiyafet> param, OgrenciSozlesmeKiyafet searchModel)
        {
            var result = _IOgrenciSozlesmeKiyafetService.GetPaging(null, true, param, false);
            return Json(result);
        }


        public JsonResult InsertOrUpdate(OgrenciSozlesmeKiyafet postModel)
        {
            var result = _IOgrenciSozlesmeKiyafetService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public OgrenciSozlesmeKiyafet Get(int id)
        {
            var result = _IOgrenciSozlesmeKiyafetService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IOgrenciSozlesmeKiyafetService.Delete(id);
            _IOgrenciSozlesmeKiyafetService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "OgrenciSozlesmeKiyafet";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
