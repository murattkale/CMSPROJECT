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
    public class BankaController : Controller
    {
        IBankaService _IBankaService;
        public BankaController(IBankaService _IBankaService) { this._IBankaService = _IBankaService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Banka> param, Banka searchModel)
        {
            var result = _IBankaService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IBankaService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }

        public JsonResult InsertOrUpdate(Banka postModel)
        {
            var result = _IBankaService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Banka Get(int id)
        {
            var result = _IBankaService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IBankaService.Delete(id);
            _IBankaService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Banka";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
