using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Models;
using Services;
using Entity;

namespace CMS.Controllers
{
    public class ParaBirimiController : Controller
    {
        IParaBirimiService _IParaBirimiService;
        public ParaBirimiController(IParaBirimiService _IParaBirimiService) { this._IParaBirimiService = _IParaBirimiService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<ParaBirimi> param, ParaBirimi searchModel)
        {
            var result = _IParaBirimiService.GetPaging(null, true, param, false);
            return Json(result);
        }


        public JsonResult InsertOrUpdate(ParaBirimi postModel)
        {
            var result = _IParaBirimiService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public ParaBirimi Get(int id)
        {
            var result = _IParaBirimiService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IParaBirimiService.Delete(id);
            _IParaBirimiService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "ParaBirimi";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
