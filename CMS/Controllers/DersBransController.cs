using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Models;

using Entity; using Entity.ContextModel;

namespace CMS.Controllers
{
    public class DersBransController : Controller
    {
        IDersBransService _IDersBransService;
        public DersBransController(IDersBransService _IDersBransService) { this._IDersBransService = _IDersBransService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<DersBrans> param, DersBrans searchModel)
        {
            var result = _IDersBransService.GetPaging(null, true, param, false);
            return Json(result);
        }

     

        public JsonResult InsertOrUpdate(DersBrans postModel)
        {
            var result = _IDersBransService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public DersBrans Get(int id)
        {
            var result = _IDersBransService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IDersBransService.Delete(id);
            _IDersBransService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "DersBrans";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
