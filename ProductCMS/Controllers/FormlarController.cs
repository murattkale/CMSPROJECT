using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ProductCMS.Controllers
{
    public class FormlarController : Controller
    {
        IFormlarService _service_Formlar;
        public FormlarController(IFormlarService _service_Formlar) { this._service_Formlar = _service_Formlar; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Formlar> param, Formlar searchModel)
        {
            var result = _service_Formlar.GetPaging(null, true, param, false);
            return Json(result);
        }



        public JsonResult InsertOrUpdate(Formlar postModel)
        {
            var result = _service_Formlar.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Formlar Get(int id)
        {
            var result = _service_Formlar.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _service_Formlar.Delete(id);
            _service_Formlar.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Formlar";
            return View();
        }
        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }




    }
}
