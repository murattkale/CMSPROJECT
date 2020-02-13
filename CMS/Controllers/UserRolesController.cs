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
    public class UserRolesController : Controller
    {
        IUserRolesService _IUserRolesService;
        public UserRolesController(IUserRolesService _IUserRolesService) { this._IUserRolesService = _IUserRolesService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<UserRoles> param, UserRoles searchModel)
        {
            var result = _IUserRolesService.GetPaging(null, true, param, false);
            return Json(result);
        }


        public JsonResult InsertOrUpdate(UserRoles postModel)
        {
            var result = _IUserRolesService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public UserRoles Get(int id)
        {
            var result = _IUserRolesService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IUserRolesService.Delete(id);
            _IUserRolesService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "UserRoles";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
