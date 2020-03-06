using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;




namespace CMS.Controllers
{
    public class SozlesmeTurController : Controller
    {
        ISozlesmeTurService _ISozlesmeTurService;
        public SozlesmeTurController(ISozlesmeTurService _ISozlesmeTurService) { this._ISozlesmeTurService = _ISozlesmeTurService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<SozlesmeTur> param, SozlesmeTur searchModel)
        {
            var result = _ISozlesmeTurService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _ISozlesmeTurService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }

        public JsonResult InsertOrUpdate(SozlesmeTur postModel)
        {
            var result = _ISozlesmeTurService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public SozlesmeTur Get(int id)
        {
            var result = _ISozlesmeTurService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _ISozlesmeTurService.Delete(id);
            _ISozlesmeTurService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "SozlesmeTur";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
