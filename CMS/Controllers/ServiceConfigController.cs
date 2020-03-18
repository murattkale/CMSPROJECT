using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;




namespace CMS.Controllers
{
    public class ServiceConfigController : Controller
    {
        IHostingEnvironment _IHostingEnvironment;
        IHttpContextAccessor _IHttpContextAccessor;
        IServiceConfigService _IServiceConfigService;
        public ServiceConfigController(IServiceConfigService _IServiceConfigService,
            IHostingEnvironment _IHostingEnvironment,
            IHttpContextAccessor _IHttpContextAccessor
            ) { this._IServiceConfigService = _IServiceConfigService;
            this._IHostingEnvironment = _IHostingEnvironment;
            this._IHttpContextAccessor = _IHttpContextAccessor;
        }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<ServiceConfig> param, ServiceConfig searchModel)
        {
            var result = _IServiceConfigService.GetPaging(null, true, param, false, o => o.Parent);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IServiceConfigService.Where(null, true, false, o => o.Parent, o => o.Parent.Parent)
                .Result.Select(o => new { value = o.Id, text = (o.Parent.Parent == null ? "" : o.Parent.Parent.Name  + " / ") + (o.Parent == null ? "" : o.Parent.Name + " / ") + o.Name });
            return Json(result);
        }


        public JsonResult InsertOrUpdate(ServiceConfig postModel)
        {
            var result = _IServiceConfigService.InsertOrUpdate(postModel);

            var menus = _IServiceConfigService.Where().Result.ToList();
            _IHttpContextAccessor.HttpContext.Session.Set("menus", menus);

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

            var menus = _IServiceConfigService.Where().Result.ToList();
            _IHttpContextAccessor.HttpContext.Session.Set("menus", menus);

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
