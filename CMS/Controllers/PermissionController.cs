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
    public class PermissionsController : Controller
    {
        IPermissionsService _IPermissionsService;
        public PermissionsController(IPermissionsService _IPermissionsService) { this._IPermissionsService = _IPermissionsService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Permissions> param, Permissions searchModel)
        {
            var result = _IPermissionsService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IPermissionsService.Where().Result.Select(o => new { value = o.Id, text = o.Name });
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Permissions postModel)
        {
            var result = _IPermissionsService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Permissions Get(int id)
        {
            var result = _IPermissionsService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IPermissionsService.Delete(id);
            _IPermissionsService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Permissions";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
