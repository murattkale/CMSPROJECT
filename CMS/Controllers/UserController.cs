using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Entity;

namespace CMS.Controllers
{
    public class UserController : Controller
    {
        IUserService _IUserService;
        public UserController(IUserService _IUserService) { this._IUserService = _IUserService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<User> param, User searchModel)
        {
            var result = _IUserService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IUserService.Where(o => o.Name != "admin").Result.Select(o => new { value = o.Id, text = o.Name + " " + o.Surname });
            return Json(result);
        }


        public JsonResult InsertOrUpdate(User postModel)
        {
            var result = _IUserService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public User Get(int id)
        {
            var result = _IUserService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IUserService.Delete(id);
            _IUserService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "User";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
