using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Models;

using Entity; using Entity.ContextModel;

namespace CMS.Controllers
{
    public class DersGrupController : Controller
    {
        IDersGrupService _IDersGrupService;
        public DersGrupController(IDersGrupService _IDersGrupService) { this._IDersGrupService = _IDersGrupService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<DersGrup> param, DersGrup searchModel)
        {
            var result = _IDersGrupService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IDersGrupService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }

        public JsonResult InsertOrUpdate(DersGrup postModel)
        {
            var result = _IDersGrupService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public DersGrup Get(int id)
        {
            var result = _IDersGrupService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IDersGrupService.Delete(id);
            _IDersGrupService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "DersGrup";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
