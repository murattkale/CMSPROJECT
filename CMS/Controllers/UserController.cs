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
    public class UsersController : Controller
    {
        IUsersService _IUsersService;
        public UsersController(IUsersService _IUsersService) { this._IUsersService = _IUsersService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Users> param, Users searchModel)
        {
            var result = _IUsersService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IUsersService.Where(o => o.Name != "admin").Result.Select(o => new { value = o.Id, text = o.Name + " " + o.Surname });
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Users postModel)
        {
            var result = _IUsersService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Users Get(int id)
        {
            var result = _IUsersService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IUsersService.Delete(id);
            _IUsersService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Users";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
