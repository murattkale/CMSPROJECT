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
    public class DersBransController : Controller
    {
        IDersBransService _IDersBransService;
        IDersService _IDersService;
        public DersBransController(IDersBransService _IDersBransService, IDersService _IDersService)
        { this._IDersBransService = _IDersBransService; this._IDersService = _IDersService; }


        public IActionResult setData(int id1, int id2, string type)
        {
            if (type == "add")
            {
                _IDersBransService.Add(new DersBrans() { BransId = id1, DersId = id2 });
            }
            else
            {
                var dp = _IDersBransService.Where(o => o.BransId == id1 && o.DersId == id2).Result.ToList();
                _IDersBransService.DeleteBulk(dp);
            }
            _IDersBransService.SaveChanges();

            return Json("ok");
        }

        public IActionResult getData(int id1)
        {
            var dp = _IDersBransService.Where(o => o.BransId == id1).Result.ToList();
            var departman = _IDersService.Where().Result.ToList().Select(o =>
               new
               {
                   value = o.Id,
                   text = o.Ad,
                   selected = dp.Any(oo => oo.DersId == o.Id)
               }).ToList();
            return Json(departman);
        }


        public IActionResult Index()
        {
            ViewBag.pageTitle = "DersBrans";
            return View();
        }


    }
}
