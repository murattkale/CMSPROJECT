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
    public class BransController : Controller
    {
        IBransService _IBransService;
        public BransController(IBransService _IBransService) { this._IBransService = _IBransService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Brans> param, Brans searchModel)
        {
            var result = _IBransService.GetPaging(null, true, param, false, o => o.Kurum);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IBransService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Brans postModel)
        {
            var result = _IBransService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Brans Get(int id)
        {
            var result = _IBransService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IBransService.Delete(id);
            _IBransService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Brans";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
