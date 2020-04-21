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
using GoogleCrawler.Models.Interfaces;

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
            var result = _httpContextAccessor.HttpContext.Session.Get<UsersModel>("postmodel");
            ViewBag.users = result;

            var addUser = new UsersModel();
            result.GetType().GetProperties().ToList().ForEach(o =>
            {
                var row = addUser.GetType().GetProperty(o.Name);
                var value = result.GetPropValue(o.Name);
                if (value != null)
                    addUser.SetValueCustom(o.Name, value);
            });

            _usersRepository.Add(addUser);

            // it will be null
            var testProduct = _usersRepository.GetById(result.Id.Value);

            // If everything is ok then:
            _uow.Commit();

            //// The product will be added only after commit
            //testProduct = _usersRepository.GetById(result.Id.Value);

            return View();
        }

        [Route("Password")]
        public IActionResult Password()
        {
            ViewBag.users = _httpContextAccessor.HttpContext.Session.Get<UsersModel>("postmodel");
            return View();
        }

        [Route("Login")]
        public IActionResult Login(UsersModel postModel)
        {
            _httpContextAccessor.HttpContext.Session.Set("postmodel", postModel);
            return Json("");
        }


    }



}


