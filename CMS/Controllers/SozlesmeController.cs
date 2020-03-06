using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Models;



namespace CMS.Controllers
{
    public class SozlesmeController : Controller
    {
        ISozlesmeService _ISozlesmeService;
        public SozlesmeController(ISozlesmeService _ISozlesmeService) { this._ISozlesmeService = _ISozlesmeService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Sozlesme> param, Sozlesme searchModel)
        {
            var result = _ISozlesmeService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _ISozlesmeService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }

        public JsonResult InsertOrUpdate(Sozlesme postModel)
        {
            var result = _ISozlesmeService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Sozlesme Get(int id)
        {
            var result = _ISozlesmeService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _ISozlesmeService.Delete(id);
            _ISozlesmeService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Sozlesme";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
