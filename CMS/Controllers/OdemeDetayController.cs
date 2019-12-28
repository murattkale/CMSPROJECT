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
using Entity.CMSDB;

namespace CMS.Controllers
{
    public class OdemeDetayController : Controller
    {
        IOdemeDetayService _IOdemeDetayService;
        IHesapService _IHesapService;
        public OdemeDetayController(IOdemeDetayService _IOdemeDetayService,
            IHesapService _IHesapService
            ) { 
            this._IOdemeDetayService = _IOdemeDetayService; 
            this._IHesapService = _IHesapService; 
        
        }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<OdemeDetay> param, OdemeDetay searchModel)
        {
            var result = _IOdemeDetayService.GetPaging(null, true, param, false, o => o.Hesap);
            return Json(result);
        }

        public JsonResult InsertOrUpdate(OdemeDetay postModel)
        {
            var result = _IOdemeDetayService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public OdemeDetay Get(int id)
        {
            var result = _IOdemeDetayService.Where(o => o.HesapId == id, true, false, o => o.Hesap).Result.FirstOrDefault();
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IOdemeDetayService.Delete(id);
            _IOdemeDetayService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "OdemeDetay";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());

            ViewBag.edit_Hesap = _IHesapService.Where(o => o.Id == Request.Query["id"].ToInt(), true, false, o => o.OdemeTip).Result.FirstOrDefault();

            return View();
        }


    }
}
