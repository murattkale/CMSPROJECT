using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ProductSite.Controllers
{
    public class FormlarController : Controller
    {
        IFormlarService _service_Formlar;
        ISendMail _ISendMail;
        public FormlarController(IFormlarService _service_Formlar, ISendMail _ISendMail) { this._service_Formlar = _service_Formlar; this._ISendMail = _ISendMail; }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<Formlar> param, Formlar searchModel)
        {
            var result = _service_Formlar.GetPaging(null, true, param, false);
            return Json(result);
        }



        public JsonResult InsertOrUpdate(Formlar postModel)
        {
            var result = _service_Formlar.InsertOrUpdate(postModel);

            var str = "";
            str += "Ad : " + postModel.Ad + "</br>";
            str += "Soyad : " + postModel.Soyad + "</br>";
            str += "Mail : " + postModel.Mail + "</br>";
            str += "Telefon : " + postModel.Telefon + "</br>";

            _ISendMail.SendMails(new MailModel()
            {
                Alicilar = new string[] { "bilgi@kazaskerfenbilimleri.com", "ilker.asan@hotmail.com" },
                cc = new string[] { "bilgi@kazaskerfenbilimleri.com" },
                KimdenMail = "bilgi@kazaskerfenbilimleri.com",
                KimdenText = "bilgi@kazaskerfenbilimleri.com",
                Konu = "Bilgi Formu",
                Icerik = str
            });
            return Json(result);
        }

        public Formlar Get(int id)
        {
            var result = _service_Formlar.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _service_Formlar.Delete(id);
            _service_Formlar.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Formlar";
            return View();
        }
        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }




    }
}
