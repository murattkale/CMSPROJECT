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
    public class DerslikController : Controller
    {
        IDerslikService _IDerslikService;
        public DerslikController(IDerslikService _IDerslikService) { this._IDerslikService = _IDerslikService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Derslik> param, Derslik searchModel)
        {
            var result = _IDerslikService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IDerslikService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Derslik postModel)
        {
            var result = _IDerslikService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Derslik Get(int id)
        {
            var result = _IDerslikService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IDerslikService.Delete(id);
            _IDerslikService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Derslik";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
