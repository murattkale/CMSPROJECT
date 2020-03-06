using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;




namespace CMS.Controllers
{
    public class PermissionController : Controller
    {
        IPermissionService _IPermissionService;
        public PermissionController(IPermissionService _IPermissionService) { this._IPermissionService = _IPermissionService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Permission> param, Permission searchModel)
        {
            var result = _IPermissionService.GetPaging(null, true, param, false,o=>o.Role);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IPermissionService.Where().Result.Select(o => new { value = o.Id, text = o.Name });
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Permission postModel)
        {
            var result = _IPermissionService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Permission Get(int id)
        {
            var result = _IPermissionService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IPermissionService.Delete(id);
            _IPermissionService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Permission";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
