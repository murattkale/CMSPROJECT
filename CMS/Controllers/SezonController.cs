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
using Entity.CMSDB;

namespace CMS.Controllers
{
    public class SezonController : Controller
    {
        ISezonService _ISezonService;
        public SezonController(ISezonService _ISezonService) { this._ISezonService = _ISezonService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Sezon> param, Sezon searchModel)
        {
            var result = _ISezonService.GetPaging(null, true, param, false, o => o.Kurum);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _ISezonService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Sezon postModel)
        {
            var result = _ISezonService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Sezon Get(int id)
        {
            var result = _ISezonService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _ISezonService.Delete(id);
            _ISezonService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Sezon";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
