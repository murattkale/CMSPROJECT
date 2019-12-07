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

namespace CMS.Controllers
{
    public class MenusController : Controller
    {
        IMenusService _service_Menus;
        public MenusController(IMenusService _service_Menus) { this._service_Menus = _service_Menus; }



        [HttpPost]
        public JsonResult GetPaging(DTParameters<Menus> param, Menus searchModel)
        {
            var result = _service_Menus.Where(null, null, true, param, false, null);

            if (param == null || param.Draw == 0)
            {
                var resultData = result.Result.ToList();
                return Json(resultData);
            }
            else
            {
                var resultData = result.ResultPaging;
                return Json(resultData);
            }

        }


        [HttpPost]
        public JsonResult GetParent(int? Id)
        {
            var resultData = GetResult().Where(o => (Id == null ? true : o.Id != Id)).OrderBy(o => o.Id).ToList();
            return Json(resultData);
        }

        IQueryable<Menus> GetResult()
        {
            return _service_Menus.Where().Result;
        }


        public JsonResult InsertOrUpdate(Menus postModel)
        {
            var result = _service_Menus.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Menus Get(int id)
        {
            var result = _service_Menus.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _service_Menus.Delete(id);
            _service_Menus.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Menus";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
