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
    public class OkulController : Controller
    {
        IOkulService _IOkulService;
        public OkulController(IOkulService _IOkulService) { this._IOkulService = _IOkulService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Okul> param, Okul searchModel)
        {
            var result = _IOkulService.GetPaging(null, true, param, false,o=>o.OkulTip);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IOkulService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }

        public JsonResult InsertOrUpdate(Okul postModel)
        {
            var result = _IOkulService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Okul Get(int id)
        {
            var result = _IOkulService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IOkulService.Delete(id);
            _IOkulService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Okul";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
