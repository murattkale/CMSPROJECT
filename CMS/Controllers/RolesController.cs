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
    public class RolesController : Controller
    {
        IRolesService _IRolesService;
        public RolesController(IRolesService _IRolesService) { this._IRolesService = _IRolesService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Roles> param, Roles searchModel)
        {
            var result = _IRolesService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IRolesService.Where().Result.Select(o => new { value = o.Id, text = o.Name });
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Roles postModel)
        {
            var result = _IRolesService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Roles Get(int id)
        {
            var result = _IRolesService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IRolesService.Delete(id);
            _IRolesService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Roles";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
