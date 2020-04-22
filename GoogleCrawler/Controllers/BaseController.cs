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
using Microsoft.AspNetCore.Localization;

namespace GoogleCrawler.Controllers
{
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
            _usersRepository = usersRepository;
            _uow = uow;

            this._httpContextAccessor = _IHttpContextAccessor;
            this._IHostingEnvironment = _IHostingEnvironment;


        }


        public IActionResult Index()
        {
            return View();
        }

        [Route("finish")]
        public IActionResult finish()
        {
            var result = _httpContextAccessor.HttpContext.Session.Get<Users>("postmodel");
            ViewBag.users = result;
            _usersRepository.Add(result);
            _uow.Commit();
            return View();
        }

        [Route("Password")]
        public IActionResult Password()
        {
            ViewBag.users = _httpContextAccessor.HttpContext.Session.Get<Users>("postmodel");
            return View();
        }

        [Route("Login")]
        public IActionResult Login(Users postModel)
        {
            _httpContextAccessor.HttpContext.Session.Set("postmodel", postModel);
            return Json("");
        }


    }



}


