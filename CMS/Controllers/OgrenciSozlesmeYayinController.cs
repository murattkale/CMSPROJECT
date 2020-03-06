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
    public class OgrenciSozlesmeYayinController : Controller
    {
        IOgrenciSozlesmeYayinService _IOgrenciSozlesmeYayinService;
        IYayinService _IYayinService;
        public OgrenciSozlesmeYayinController(IOgrenciSozlesmeYayinService _IOgrenciSozlesmeYayinService, IYayinService _IYayinService)
        { this._IOgrenciSozlesmeYayinService = _IOgrenciSozlesmeYayinService; this._IYayinService = _IYayinService; }


        public IActionResult setData(int id1, int id2, string type)
        {
            if (type == "add")
            {
                _IOgrenciSozlesmeYayinService.Add(new OgrenciSozlesmeYayin() { OgrenciSozlesmeId = id1, YayinId = id2 });
            }
            else
            {
                var dp = _IOgrenciSozlesmeYayinService.Where(o => o.OgrenciSozlesmeId == id1 && o.YayinId == id2).Result.ToList();
                _IOgrenciSozlesmeYayinService.DeleteBulk(dp);
            }
            _IOgrenciSozlesmeYayinService.SaveChanges();

            return Json("ok");
        }

        public IActionResult getData(int id1)
        {
            var dp = _IOgrenciSozlesmeYayinService.Where(o => o.OgrenciSozlesmeId == id1).Result.ToList();
            var departman = _IYayinService.Where().Result.ToList().Select(o =>
               new
               {
                   value = o.Id,
                   text = o.Ad,
                   selected = dp.Any(oo => oo.YayinId == o.Id)
               }).ToList();
            return Json(departman);
        }


        public IActionResult Index()
        {
            ViewBag.pageTitle = "OgrenciSozlesmeYayin";
            return View();
        }


    }
}
