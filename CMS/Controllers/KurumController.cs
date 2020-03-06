using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;




namespace CMS.Controllers
{
    public class KurumController : Controller
    {
        IKurumService _IKurumService;
        public KurumController(IKurumService _IKurumService) { this._IKurumService = _IKurumService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Kurum> param, Kurum searchModel)
        {
        
            var result = _IKurumService.GetPaging(null, true, param, false, o => o.City, o => o.Town);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IKurumService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Kurum postModel)
        {
            var result = _IKurumService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Kurum Get(int id)
        {
            var result = _IKurumService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IKurumService.Delete(id);
            _IKurumService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Kurum";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
