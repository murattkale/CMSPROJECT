using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Models;

using Entity;


namespace CMS.Controllers
{
    public class OdemeTipController : Controller
    {
        IOdemeTipService _IOdemeTipService;
        public OdemeTipController(IOdemeTipService _IOdemeTipService) { this._IOdemeTipService = _IOdemeTipService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<OdemeTip> param, OdemeTip searchModel)
        {
            var result = _IOdemeTipService.GetPaging(null, true, param, false, o => o.Banka);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IOdemeTipService.Where(null, true, false, o => o.Banka).Result
                .Select(o => new { value = o.Id, text = o.Ad + (o.Banka == null ? "" : " (" + o.Banka.Ad + ")") });
            return Json(result);
        }

        public JsonResult InsertOrUpdate(OdemeTip postModel)
        {
            var result = _IOdemeTipService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public OdemeTip Get(int id)
        {
            var result = _IOdemeTipService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IOdemeTipService.Delete(id);
            _IOdemeTipService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "OdemeTip";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
