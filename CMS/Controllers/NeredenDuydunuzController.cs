using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;




namespace CMS.Controllers
{
    public class NeredenDuydunuzController : Controller
    {
        INeredenDuydunuzService _INeredenDuydunuzService;
        public NeredenDuydunuzController(INeredenDuydunuzService _INeredenDuydunuzService) { this._INeredenDuydunuzService = _INeredenDuydunuzService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<NeredenDuydunuz> param, NeredenDuydunuz searchModel)
        {
            var result = _INeredenDuydunuzService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _INeredenDuydunuzService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }

        public JsonResult InsertOrUpdate(NeredenDuydunuz postModel)
        {
            var result = _INeredenDuydunuzService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public NeredenDuydunuz Get(int id)
        {
            var result = _INeredenDuydunuzService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _INeredenDuydunuzService.Delete(id);
            _INeredenDuydunuzService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "NeredenDuydunuz";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
