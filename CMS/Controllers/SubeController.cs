using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Models;

using Entity;
using Entity.CMSDB;

namespace CMS.Controllers
{
    public class SubeController : Controller
    {
        ISubeService _ISubeService;
        public SubeController(ISubeService _ISubeService) { this._ISubeService = _ISubeService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Sube> param, Sube searchModel)
        {
            var result = _ISubeService.GetPaging(null, true, param, false, o => o.Sehir, o => o.Ilce, o => o.Kurum);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _ISubeService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }

        [HttpPost]
        public JsonResult Getlist(int? id)
        {
            var result = _ISubeService.Where(o => o.KurumId == id).Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }

        public JsonResult InsertOrUpdate(Sube postModel)
        {
            var result = _ISubeService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Sube Get(int id)
        {
            var result = _ISubeService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _ISubeService.Delete(id);
            _ISubeService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Sube";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
