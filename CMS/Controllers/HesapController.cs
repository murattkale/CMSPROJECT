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
    public class HesapController : Controller
    {
        IHesapService _IHesapService;
        public HesapController(IHesapService _IHesapService) { this._IHesapService = _IHesapService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Hesap> param, Hesap searchModel)
        {
            var result = _IHesapService.GetPaging(null, true, param, false, o => o.HesapTip, o => o.IlgiliKasa, o => o.AliciKasa, o => o.OdemeTip);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IHesapService.Where(null, true, false, o => o.HesapTip, o => o.IlgiliKasa, o => o.AliciKasa, o => o.OdemeTip).Result
                .Select(o => new
                {
                    value = o.Id,
                    text =
                    //o.IlgiliKasa.Ad
                     o.HesapTip.Ad + " / "

                    + (o.OdemeTip.Banka == null ? "" : " / " + o.OdemeTip.Banka.Ad + " / ")
                    + o.OdemeTip.Ad + " / "
                    + (o.AliciKasa == null ? "" : " / " + o.AliciKasa.Ad + " / ")



                }).ToList();
            return Json(result);
        }


        public JsonResult InsertOrUpdate(Hesap postModel)
        {
            var result = _IHesapService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Hesap Get(int id)
        {
            var result = _IHesapService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IHesapService.Delete(id);
            _IHesapService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Hesap";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
