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
    public class ServisController : Controller
    {
        IServisService _IServisService;
        public ServisController(IServisService _IServisService) { this._IServisService = _IServisService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Servis> param, Servis searchModel)
        {
            var result = _IServisService.GetPaging(null, true, param, false, o => o.Sube);
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Servis postModel)
        {
            var result = _IServisService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Servis Get(int id)
        {
            var result = _IServisService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IServisService.Delete(id);
            _IServisService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Servis";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
