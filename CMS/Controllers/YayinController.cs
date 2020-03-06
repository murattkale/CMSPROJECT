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
    public class YayinController : Controller
    {
        IYayinService _IYayinService;
        public YayinController(IYayinService _IYayinService) { this._IYayinService = _IYayinService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Yayin> param, Yayin searchModel)
        {
            var result = _IYayinService.GetPaging(null, true, param, false, o => o.Brans, o => o.Ders);
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Yayin postModel)
        {
            var result = _IYayinService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Yayin Get(int id)
        {
            var result = _IYayinService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IYayinService.Delete(id);
            _IYayinService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Yayin";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
