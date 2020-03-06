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
    public class UserRoleController : Controller
    {
        IUserRoleService _IUserRoleService;
        IRoleService _IRoleService;
        public UserRoleController(IUserRoleService _IUserRoleService, IRoleService _IRoleService)
        { this._IUserRoleService = _IUserRoleService; this._IRoleService = _IRoleService; }


        public IActionResult setData(int id1, int id2, string type)
        {
            if (type == "add")
            {
                _IUserRoleService.Add(new UserRole() { UserId = id1, RoleId = id2 });
            }
            else
            {
                var dp = _IUserRoleService.Where(o => o.UserId == id1 && o.RoleId == id2).Result.ToList();
                _IUserRoleService.DeleteBulk(dp);
            }
            _IUserRoleService.SaveChanges();

            return Json("ok");
        }

        public IActionResult getData(int id1)
        {
            var dp = _IUserRoleService.Where(o => o.UserId == id1).Result.ToList();
            var departman = _IRoleService.Where().Result.ToList().Select(o =>
               new
               {
                   value = o.Id,
                   text = o.Name,
                   selected = dp.Any(oo => oo.RoleId == o.Id)
               }).ToList();
            return Json(departman);
        }


        public IActionResult Index()
        {
            ViewBag.pageTitle = "UserRole";
            return View();
        }


    }
}
