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
    public class HesapTipController : Controller
    {
        IHesapTipService _IHesapTipService;
        public HesapTipController(IHesapTipService _IHesapTipService) { this._IHesapTipService = _IHesapTipService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<HesapTip> param, HesapTip searchModel)
        {
            var result = _IHesapTipService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IHesapTipService.Where().Result.Select(o => new { value = o.Id, text = o.Ad + " (" + ((GelirGiderTipi)o.GelirGiderTipi).ExGetDescription() + ")" });
            return Json(result);
        }

        public JsonResult InsertOrUpdate(HesapTip postModel)
        {
            var result = _IHesapTipService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public HesapTip Get(int id)
        {
            var result = _IHesapTipService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IHesapTipService.Delete(id);
            _IHesapTipService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "HesapTip";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
