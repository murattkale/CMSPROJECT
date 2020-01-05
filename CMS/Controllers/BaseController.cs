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
    

        public IActionResult Index()
        {
     
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

   
    }
}
