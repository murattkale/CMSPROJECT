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
    public class DersController : Controller
    {
        IDersService _IDersService;
        public DersController(IDersService _IDersService) { this._IDersService = _IDersService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Ders> param, Ders searchModel)
        {
            var result = _IDersService.GetPaging(null, true, param, false,o=>o.DersGrup);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IDersService.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }

        public JsonResult InsertOrUpdate(Ders postModel)
        {
            var result = _IDersService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Ders Get(int id)
        {
            var result = _IDersService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IDersService.Delete(id);
            _IDersService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Ders";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
