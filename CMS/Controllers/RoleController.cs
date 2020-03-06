using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;




namespace CMS.Controllers
{
    public class RoleController : Controller
    {
        IRoleService _IRoleService;
        public RoleController(IRoleService _IRoleService) { this._IRoleService = _IRoleService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Role> param, Role searchModel)
        {
            var result = _IRoleService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IRoleService.Where().Result.Select(o => new { value = o.Id, text = o.Name });
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Role postModel)
        {
            var result = _IRoleService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Role Get(int id)
        {
            var result = _IRoleService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IRoleService.Delete(id);
            _IRoleService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Role";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
