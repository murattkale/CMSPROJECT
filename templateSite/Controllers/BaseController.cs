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

            str += "Ad Soyad : " + postModel.adsoyad + " | ";
            str += "Yaş : " + postModel.yas + " | ";
            str += "Mail : " + postModel.mail + " | ";
            str += "İl : " + postModel.il + " | ";
            str += "İlçe : " + postModel.ilce + " | ";
            str += "Telefon : " + postModel.telefon + " | ";
            str += "Cinsiyet : " + postModel.cinsiyet + " | ";
            str += "Arzuladığı Yaş : " + postModel.yasaraligi + " | ";
            str += "Mesaj : " + postModel.gorusme + " | ";


            _ISendMail.Send(new MailModelCustom
            {
                Alicilar = new string[] { "elifaltay495@gmail.com", "info@ajanspiink.com", "murat.kale9339@gmail.com" },
                SmtpMail = "elifaltay495@gmail.com",
                SmtpMailPass = "Bgokcek39",
                SmtpUseDefaultCredentials = true,
                SmtpSSL = true,
                MailGorunenAd = "Ajans",
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
