using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Entity;

namespace CMS.Controllers
{
    public class OgrenciSozlesmeKiyafetController : Controller
    {
        IOgrenciSozlesmeKiyafetService _IOgrenciSozlesmeKiyafetService;
        IKiyafetService _IKiyafetService;
        public OgrenciSozlesmeKiyafetController(IOgrenciSozlesmeKiyafetService _IOgrenciSozlesmeKiyafetService, IKiyafetService _IKiyafetService)
        { this._IOgrenciSozlesmeKiyafetService = _IOgrenciSozlesmeKiyafetService; this._IKiyafetService = _IKiyafetService; }


        public IActionResult setData(int id1, int id2, string type)
        {
            if (type == "add")
            {
                _IOgrenciSozlesmeKiyafetService.Add(new OgrenciSozlesmeKiyafet() { OgrenciSozlesmeId = id1, KiyafetId = id2 });
            }
            else
            {
                var dp = _IOgrenciSozlesmeKiyafetService.Where(o => o.OgrenciSozlesmeId == id1 && o.KiyafetId == id2).Result.ToList();
                _IOgrenciSozlesmeKiyafetService.DeleteBulk(dp);
            }
            _IOgrenciSozlesmeKiyafetService.SaveChanges();

            return Json("ok");
        }

        public IActionResult getData(int id1)
        {
            var dp = _IOgrenciSozlesmeKiyafetService.Where(o => o.OgrenciSozlesmeId == id1).Result.ToList();
            var departman = _IKiyafetService.Where().Result.ToList().Select(o =>
               new
               {
                   value = o.Id,
                   text = o.Ad,
                   selected = dp.Any(oo => oo.KiyafetId == o.Id)
               }).ToList();
            return Json(departman);
        }


        public IActionResult Index()
        {
            ViewBag.pageTitle = "OgrenciSozlesmeKiyafet";
            return View();
        }


    }
}
