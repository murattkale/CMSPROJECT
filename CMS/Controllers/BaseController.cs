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
    public class BaseController : Controller
    {
        //IBankaService _IBankaService;
        //public BaseController(IBankaService _IBankaService) { this._IBankaService = _IBankaService; }


        public IActionResult Index()
        {
            //var dd = _IBankaService.Where().Result.ToList();
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }


    }
}
