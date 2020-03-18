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
    public class HesapTipController : Controller
    {
        IHesapTipService _IHesapTipService;
        public HesapTipController(IHesapTipService _IHesapTipService) { this._IHesapTipService = _IHesapTipService; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<HesapTip> param, HesapTip searchModel)
        {

            //var list = new List<HesapTip>();

            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "AVUKAT GİDERLERİ  ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "BAKIM ONARIM TADİLAT             ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "BANKA MASRAFLARI                 ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "BİNA AİDAT                       ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "DEMİRBAŞ ALIM GİDERLERİ          ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "DOĞALGAZ GİDERLERİ               ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "ELEKTRİK FATURASI                ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 2, Ad = "ETKİNLİK GELİRİ                  ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "FİZİKİ REKLAM GİDERLERİ          ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "FOTOKOPİ GİDERLERİ               ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "GSM FATURASI                     ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "İNTERNET FATURASI                ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "İŞTİRAKÇİ PAY DAĞITIMI           ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 2, Ad = "KANTİN GELİRİ                    ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "KANTİN GİDERİ                    ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "KARGO VE POSTA GİDERLERİ         ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "KDV ÖDEMELERİ                    ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 2, Ad = "KIYAFET GELİRİ                   ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "KIYAFET GİDERİ                   ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "KİRA ÖDEMELERİ                   ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "KOMİSYON GİDERLERİ               ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "MALİ MÜŞAVİR GİDERLERİ           ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "NAKLİYE GİDERLERİ                ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "PERSONEL ÖDEMELERİ               ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "PERSONEL PRİM GİDERLERİ          ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "SABİT TELEFON GİDERLERİ          ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "SARF MALZEME GİDERLERİ           ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 2, Ad = "SERVİS GELİRİ                    ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "SERVİS GİDERİ                    ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "SGK ÖDEMESİ                      ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "SMS GİDERLERİ                    ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "SOSYAL ETKİNLİK GİDERLERİ        ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "SOSYAL MEDYA REKLAM GİDERLERİ    ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "SU FATURASI                      ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "TEMİZLİK MALZEME GİDERLERİ       ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "TEMSİL VE İKRAM GİDERLERİ        ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "ULAŞIM VE BENZİN GİDERLERİ       ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "VERGİ ÖDEMELERİ                  ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 2, Ad = "YAYIN GELİRİ                     ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "YAYIN GİDERLERİ                  ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "YAZILIM GİDERLERİ                ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 2, Ad = "YEMEK GELİRİ (ÖĞRENCİ)           ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 2, Ad = "YEMEK GELİRİ (PERSONEL)          ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "YEMEK GİDERİ (ÖĞRENCİ)           ".Trim() });
            //list.Add(new HesapTip() { GelirGiderTipi = 1, Ad = "YEMEK GİDERİ (PERSONEL)          ".Trim() });

            //_IHesapTipService.AddBulk(list);
            //_IHesapTipService.SaveChanges();

            var result = _IHesapTipService.GetPaging(null, true, param, false);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IHesapTipService.Where().Result.Select(o => new { value = o.Id, text = o.Ad + " (" + ((GelirGiderTipi)o.GelirGiderTipi).ExGetDescription() + ")" });
            return Json(result);
        }

        public JsonResult InsertOrUpdate(HesapTip postModel)
        {
            var result = _IHesapTipService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public JsonResult GetGelirGiderTipi()
        {
            var list = Enum.GetValues(typeof(GelirGiderTipi)).Cast<int>().Select(x => new { name = ((GelirGiderTipi)x).ToStr(), value = x.ToString(), text = ((GelirGiderTipi)x).ExGetDescription() }).ToArray();
            return Json(list);
        }

        public HesapTip Get(int id)
        {
            var result = _IHesapTipService.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IHesapTipService.Delete(id);
            _IHesapTipService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "HesapTip";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
