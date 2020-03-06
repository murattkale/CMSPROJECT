using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Models;



namespace CMS.Controllers
{
    public class OkulTipController : Controller
    {
        IOkulTipService _IOkulTipService;
        public OkulTipController(IOkulTipService _IOkulTipService) { this._IOkulTipService = _IOkulTipService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<OkulTip> param, OkulTip searchModel)
        {
            var result = _IOkulTipService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IOkulTipService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }

        public JsonResult InsertOrUpdate(OkulTip postModel)
        {
            var result = _IOkulTipService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public OkulTip Get(int id)
        {
            var result = _IOkulTipService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IOkulTipService.Delete(id);
            _IOkulTipService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "OkulTip";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
