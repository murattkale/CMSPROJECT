using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;




namespace CMS.Controllers
{
    public class KiyafetTurController : Controller
    {
        IKiyafetTurService _IKiyafetTurService;
        public KiyafetTurController(IKiyafetTurService _IKiyafetTurService) { this._IKiyafetTurService = _IKiyafetTurService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<KiyafetTur> param, KiyafetTur searchModel)
        {
            var result = _IKiyafetTurService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IKiyafetTurService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }

        public JsonResult InsertOrUpdate(KiyafetTur postModel)
        {
            var result = _IKiyafetTurService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public KiyafetTur Get(int id)
        {
            var result = _IKiyafetTurService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IKiyafetTurService.Delete(id);
            _IKiyafetTurService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "KiyafetTur";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
