using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Models;

using Entity;
using Entity.ContextModel;

namespace CMS.Controllers
{
    public class OgrenciController : Controller
    {
        IUsersService _IUsersService;
        IOgrenciDetayService _IOgrenciDetayService;
        IOgrenciSozlesmeService _IOgrenciSozlesmeService;
        IOgrenciSozlesmeYayinService _IOgrenciSozlesmeYayinService;
        IOgrenciSozlesmeKiyafetService _IOgrenciSozlesmeKiyafetService;
        IOgrenciSozlesmeOdemeTablosuService _IOgrenciSozlesmeOdemeTablosuService;
        public OgrenciController(
             IUsersService _IUsersService,
        IOgrenciDetayService _IOgrenciDetayService,
        IOgrenciSozlesmeService _IOgrenciSozlesmeService,
        IOgrenciSozlesmeYayinService _IOgrenciSozlesmeYayinService,
        IOgrenciSozlesmeKiyafetService _IOgrenciSozlesmeKiyafetService,
        IOgrenciSozlesmeOdemeTablosuService _IOgrenciSozlesmeOdemeTablosuService
            )
        {
            this._IUsersService = _IUsersService;
            this._IOgrenciDetayService = _IOgrenciDetayService;
            this._IOgrenciSozlesmeService = _IOgrenciSozlesmeService;
            this._IOgrenciSozlesmeYayinService = _IOgrenciSozlesmeYayinService;
            this._IOgrenciSozlesmeKiyafetService = _IOgrenciSozlesmeKiyafetService;
            this._IOgrenciSozlesmeOdemeTablosuService = _IOgrenciSozlesmeOdemeTablosuService;
        }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Users> param)
        {
            var result = _IUsersService.GetPaging(o => o.UserRoles.Any(oo => oo.Role.Name == "Öğrenci"), true, param, false,
                o => o.City,
                o => o.Town,
                o => o.UserRoles

                );
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Users postModel)
        {
            var result = _IUsersService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Users Get(int id)
        {
            var result = _IUsersService.Where(o => o.Id == id).Result.FirstOrDefault();
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
