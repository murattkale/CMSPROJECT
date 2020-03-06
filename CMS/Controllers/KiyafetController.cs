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
    public class KiyafetController : Controller
    {
        IKiyafetService _IKiyafetService;
        public KiyafetController(IKiyafetService _IKiyafetService) { this._IKiyafetService = _IKiyafetService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Kiyafet> param, Kiyafet searchModel)
        {
            var result = _IKiyafetService.GetPaging(null, true, param, false,o=>o.KiyafetTur);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IKiyafetService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }

        public JsonResult InsertOrUpdate(Kiyafet postModel)
        {
            var result = _IKiyafetService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Kiyafet Get(int id)
        {
            var result = _IKiyafetService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IKiyafetService.Delete(id);
            _IKiyafetService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Kiyafet";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
