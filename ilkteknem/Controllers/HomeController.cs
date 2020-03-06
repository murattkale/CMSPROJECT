using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entity;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ilkteknem.Controllers
{
    public class HomeController : Controller
    {
        IFormlarService _IFormlarService;
        public HomeController(
            IFormlarService _IFormlarService
            )
        {
            this._IFormlarService = _IFormlarService;

        }

        public JsonResult FormlarSave(Formlar postModel)
        {
            var result = _IFormlarService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult denizletanisma()
        {
            return View();
        }

        public IActionResult hakkimizda()
        {
            return View();
        }

        public IActionResult iletisim()
        {
            return View();
        }

        public IActionResult ilkteknem()
        {
            return View();
        }

        public IActionResult programigor()
        {
            return View();
        }

        public IActionResult referanslar()
        {
            return View();
        }

        public IActionResult yararliyazilar()
        {
            return View();
        }


    }
}
