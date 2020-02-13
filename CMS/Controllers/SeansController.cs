using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Models;

using Entity;
using Entity.CMSDB; using Entity.ContextModel;

namespace CMS.Controllers
{
    public class SeansController : Controller
    {
        ISeansService _ISeansService;
        public SeansController(ISeansService _ISeansService) { this._ISeansService = _ISeansService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Seans> param, Seans searchModel)
        {
            var result = _ISeansService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _ISeansService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Seans postModel)
        {
            var result = _ISeansService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Seans Get(int id)
        {
            var result = _ISeansService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _ISeansService.Delete(id);
            _ISeansService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Seans";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
