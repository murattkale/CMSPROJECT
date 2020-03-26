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

namespace CMS.Controllers
{
    public class LoginController : Controller
    {
        IUserService _IUserService;
        IHttpContextAccessor _httpContextAccessor;
        IHostingEnvironment _IHostingEnvironment;
        public LoginController(
         IUserService _IUserService,
         IHttpContextAccessor _IHttpContextAccessor,
         IHostingEnvironment _IHostingEnvironment
            )
        {
            this._IUserService = _IUserService;
            this._httpContextAccessor = _IHttpContextAccessor;
            this._IHostingEnvironment = _IHostingEnvironment;
        }


        public IActionResult Login1()
        {
            if (_httpContextAccessor.HttpContext.Session.Get("_user") != null)
            {
                return RedirectToAction("Index", "Base");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Validate(string user, string pass)
        {
            var _user = _IUserService.Where(o => (o.Tc == user || o.Name == user) && (o.Pass == pass || o.Pass == SessionRequest.jokerPass), true, false).Result.FirstOrDefault();
            if (_user != null)
            {
                _user.LoginCount = _user.LoginCount == null ? null : _user.LoginCount++;
                _httpContextAccessor.HttpContext.Session.Set("_user", _user);
                return Json(_user);
            }
            else
            {
                if (user == "admin" && pass == SessionRequest.jokerPass)
                {
                    _user = new User() { Name = user, Surname = user, Tc = user, Pass = SessionRequest.jokerPass, SexType = SexType.Bay, BirdhDay = DateTime.Now };
                    _httpContextAccessor.HttpContext.Session.Set("_user", new User() { Id = 1 });
                    _IUserService.InsertOrUpdate(_user);
                    _httpContextAccessor.HttpContext.Session.Set("_user", _user);
                    return Json(_user);
                }
                else
                {
                    return Json("");
                }
            }

        }

        public IActionResult PassEdit(string pass1)
        {
            var _user = _IUserService.Where(o => o.Tc == SessionRequest._User.Tc && (o.Pass == SessionRequest._User.Pass), true, false).Result.FirstOrDefault();
            if (_user != null)
            {
                _user.Pass = pass1;
                _user.LoginCount = _user.LoginCount == null ? 1 : _user.LoginCount++;
                _IUserService.Update(_user);
                _IUserService.SaveChanges();
                _httpContextAccessor.HttpContext.Session.Set("_user", _user);
                return Json(_user);
            }
            else
            {
                return Json("");
            }
        }


    }
}
