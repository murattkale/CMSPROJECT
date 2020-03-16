using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;




namespace ProductCMS.Controllers
{
    public class ServiceConfigController : Controller
    {
        IServiceConfigService _IServiceConfigService;
        public ServiceConfigController(IServiceConfigService _IServiceConfigService) { this._IServiceConfigService = _IServiceConfigService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<ServiceConfig> param, ServiceConfig searchModel)
        {
            var result = _IServiceConfigService.GetPaging(null, true, param, false,o=>o.Parent);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IServiceConfigService.Where().Result.Select(o => new { value = o.Id, text = o.Name });
            return Json(result);
        }


        public JsonResult InsertOrUpdate(ServiceConfig postModel)
        {
            var result = _IServiceConfigService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public ServiceConfig Get(int id)
        {
            var result = _IServiceConfigService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IServiceConfigService.Delete(id);
            _IServiceConfigService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "ServiceConfig";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
