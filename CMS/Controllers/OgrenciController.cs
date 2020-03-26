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
    public class OgrenciController : Controller
    {
        IUserService _IUserService;
        IRoleService _IRoleService;
        IUserRoleService _IUserRoleService;
        IOgrenciDetayService _IOgrenciDetayService;
        IOgrenciSozlesmeService _IOgrenciSozlesmeService;
        IOgrenciSozlesmeYayinService _IOgrenciSozlesmeYayinService;
        IOgrenciSozlesmeKiyafetService _IOgrenciSozlesmeKiyafetService;
        IOgrenciSozlesmeOdemeTablosuService _IOgrenciSozlesmeOdemeTablosuService;
        public OgrenciController(
             IUserService _IUserService,
             IRoleService _IRoleService,
        IUserRoleService _IUserRoleService,
        IOgrenciDetayService _IOgrenciDetayService,
        IOgrenciSozlesmeService _IOgrenciSozlesmeService,
        IOgrenciSozlesmeYayinService _IOgrenciSozlesmeYayinService,
        IOgrenciSozlesmeKiyafetService _IOgrenciSozlesmeKiyafetService,
        IOgrenciSozlesmeOdemeTablosuService _IOgrenciSozlesmeOdemeTablosuService
            )
        {
            this._IUserService = _IUserService;
            this._IRoleService = _IRoleService;
            this._IUserRoleService = _IUserRoleService;
            this._IOgrenciDetayService = _IOgrenciDetayService;
            this._IOgrenciSozlesmeService = _IOgrenciSozlesmeService;
            this._IOgrenciSozlesmeYayinService = _IOgrenciSozlesmeYayinService;
            this._IOgrenciSozlesmeKiyafetService = _IOgrenciSozlesmeKiyafetService;
            this._IOgrenciSozlesmeOdemeTablosuService = _IOgrenciSozlesmeOdemeTablosuService;
        }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<User> param)
        {
            var result = _IUserService.GetPaging(o => o.UserRoles.Any(oo => oo.Role.Name == "Öğrenci"), true, param, false,
                o => o.City,
                o => o.Town,
                o => o.UserRoles,
                o => o.OgrenciDetay
                );
            return Json(result);
        }

        public JsonResult GetSexType()
        {
            var list = Enum.GetValues(typeof(SexType)).Cast<int>().Select(x => new { name = ((SexType)x).ToStr(), value = x.ToString(), text = ((SexType)x).ExGetDescription() }).ToArray();
            return Json(list);
        }

        public JsonResult InsertOrUpdate(User postModel)
        {
            if (postModel.Id < 1)
            {
                var result = _IUserService.InsertOrUpdate(postModel);
                var role = _IRoleService.Where(o => o.Name == "Öğrenci").Result.FirstOrDefault();
                var userrole = new UserRole() { UserId = result.ResultRow.Id, RoleId = role.Id };
                _IUserRoleService.InsertOrUpdate(userrole);
                return Json(result);
            }
            else
            {
                var result = _IUserService.InsertOrUpdate(postModel);
                return Json(result);
            }
        }

        public User Get(int id)
        {
            var result = _IUserService.Where(o => o.Id == id).Result.FirstOrDefault();
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
            ViewBag.pageTitle = "Öğrenci";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
