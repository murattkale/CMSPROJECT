﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using siteProject.Models;

namespace siteProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult hakkimizda()
        {
            return View();
        }


        public IActionResult biznasilcalisiriz()
        {
            return View();
        }


        public IActionResult iletisim()
        {
            return View();
        }

        public IActionResult referanslar()
        {
            return View();
        }


        public IActionResult paketlerimiz()
        {
            return View();
        }

        public IActionResult istatistikler()
        {
            return View();
        }

        public IActionResult sosyalmedya()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
