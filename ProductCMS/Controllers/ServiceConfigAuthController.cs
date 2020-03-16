using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;





namespace ProductCMS.Controllers
{
    public class ServiceConfigAuthController : Controller
    {
        IServiceConfigAuthService _IServiceConfigAuthService;
        public ServiceConfigAuthController(IServiceConfigAuthService _IServiceConfigAuthService) { this._IServiceConfigAuthService = _IServiceConfigAuthService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<ServiceConfigAuth> param, ServiceConfigAuth searchModel)
        {
            var result = _IServiceConfigAuthService.GetPaging(null, true, param, false, o => o.Role, o => o.ServiceConfig, o => o.Permission, o => o.Users);
            return Json(result);
        }

        public JsonResult InsertOrUpdate(ServiceConfigAuth postModel)
        {
            var result = _IServiceConfigAuthService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public ServiceConfigAuth Get(int id)
        {
            var result = _IServiceConfigAuthService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IServiceConfigAuthService.Delete(id);
            _IServiceConfigAuthService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "ServiceConfigAuth";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
