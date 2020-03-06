using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using MailService;

namespace templateSite.Controllers
{
    public class BaseController : Controller
    {
        ISendMail _ISendMail;
        IHttpContextAccessor _httpContextAccessor;
        IHostingEnvironment _IHostingEnvironment;
        public BaseController(
            ISendMail _ISendMail,
         IHttpContextAccessor _IHttpContextAccessor,
         IHostingEnvironment _IHostingEnvironment
            )
        {
            this._ISendMail = _ISendMail;
            this._httpContextAccessor = _IHttpContextAccessor;
            this._IHostingEnvironment = _IHostingEnvironment;
        }

        public IActionResult FormSave(CustomMailModel postModel)
        {
            var str = "";

            str += "Ad Soyad : " + postModel.adsoyad + "</br>";
            str += "Yaş : " + postModel.yas + "</br>";
            str += "Mail : " + postModel.mail + "</br>";
            str += "İl : " + postModel.il + "</br>";
            str += "İlçe : " + postModel.ilce + "</br>";
            str += "Telefon : " + postModel.telefon + "</br>";
            str += "Cinsiyet : " + postModel.cinsiyet + "</br>";
            str += "Arzuladığı Yaş : " + postModel.yasaraligi + "</br>";
            str += "Mesaj : " + postModel.gorusme + "</br>";


            _ISendMail.SendMails(new templateMailModel
            {
                Alicilar = new string[] { "elifaltay495@gmail.com" },
                cc = new string[] { "elifaltay495@gmail.com" },
                KimdenMail = "elifaltay495@gmail.com",
                KimdenText = "Ajans",
                Konu = "Bilgilendirme",
                Icerik = str


            });

            return Json("ok");
        }

        [Route("kayit")]

        public IActionResult kayit()
        {
            return View();
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }


        [Route("iletisim")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("bayan-adaylar")]
        public IActionResult FemaleList()
        {
            return View();
        }

        [Route("Members")]
        public IActionResult Members()
        {
            return View();
        }

        [Route("erkek-adaylar")]
        public IActionResult MaleList()
        {
            return View();
        }



    }
}
