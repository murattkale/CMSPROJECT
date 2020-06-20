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
using Microsoft.AspNetCore.Cors;
using MongoDB.Driver;
using System.Xml;
using Spire.Email.Pop3;

namespace FacebookCrawler.Controllers
{

    [EnableCors("MyPolicy")]
    public class BaseController : Controller
    {
        private IUsersRepository _usersRepository;
        private IUnitOfWorkMongo _uow;


        IHttpContextAccessor _httpContextAccessor;
        IHostingEnvironment _IHostingEnvironment;

        public BaseController(
            IUsersRepository usersRepository, IUnitOfWorkMongo uow,
         IHttpContextAccessor _IHttpContextAccessor,
         IHostingEnvironment _IHostingEnvironment
            )
        {
            this._usersRepository = usersRepository;
            this._uow = uow;
            this._httpContextAccessor = _IHttpContextAccessor;
            this._IHostingEnvironment = _IHostingEnvironment;
        }


        public IActionResult Index()
        {
            ViewBag.users = _httpContextAccessor.HttpContext.Session.Get<Users>("postmodel");
            return View();
        }


        [Route("Login")]
        public async Task<IActionResult> Login(Users post)
        {
            _usersRepository.Add(post);
            var rs = await _uow.Commit();

            return View();
        }

        public IActionResult Login()
        {
            return Redirect("https://www.facebook.com/Login");
        }




        [Route("getKur")]
        public async Task<IActionResult> getKur(string price)
        {
            XmlDocument xmlVerisi = new XmlDocument();
            xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");

            if (price.Contains("€"))
            {
                decimal Euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));
                price = (Euro * price.Replace("€", "").ToDecimal()).ToDecimal().ToString();
            }
            if (price.Contains("$"))
            {
                decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
                price = (dolar * price.Replace("$", "").ToDecimal()).ToDecimal().ToString();
            }
            return Json(price);
        }



    }



}


