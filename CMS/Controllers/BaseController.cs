using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Models;

using Entity;

namespace CMS.Controllers
{
    public class BaseController : Controller
    {
    

        public IActionResult Index()
        {
            if (HttpContext.Request.Path.ToUriComponent().Split('/').Where(o => !string.IsNullOrEmpty(o)).FirstOrDefault().ToInt() > 0)
            {
                SessionRequest.KurumId = HttpContext.Request.Path.ToUriComponent().Split('/').Where(o => !string.IsNullOrEmpty(o)).FirstOrDefault().ToInt();
                SessionRequest.baseUrl = "/" + SessionRequest.KurumId + "/";
                SessionRequest.RawUrl = SessionRequest.baseUrl;
            }
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

   
    }
}
