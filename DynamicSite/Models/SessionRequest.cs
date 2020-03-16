﻿
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;

public static class SessionRequest
{
    private static IHttpContextAccessor _IHttpContextAccessor;

    public static void Configure(IHttpContextAccessor __IHttpContextAccessor)
    {
        _IHttpContextAccessor = __IHttpContextAccessor;
    }

    public static HttpContext _HttpContext => _IHttpContextAccessor.HttpContext;

    public static User _User
    {
        get
        {
            return new User()
            {
                Id = 1,
            };
            //return _IHttpContextAccessor.HttpContext.Session.Get<Users>("_user");
        }
        set { }
    }

    public static SiteConfig config
    {
        get
        {
            return _IHttpContextAccessor.HttpContext.Session.Get<SiteConfig>("config");
        }
        set { }
    }

    public static string Title = "Kazasker Fen Bilimleri";
    public static string StartPage = "Base";
    public static string StartAction = "Index";
    public static string version = DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(".", "").Replace(" ", "");
    public static string copyright = $"{DateTime.Now.Year} © Yazılım&Tasarım (Software&Design)  <a target='_blank' href='http://muratkale.com.tr'>by Murat KALE 0530 511 71 27</a>";
    public static string layoutID = "1";
    public static string layoutUrlBase = $"http://cms.dyness.com.tr";
    public static string layoutUrl = $"{layoutUrlBase}";
    public static string logo = "~/img/logo.png";
    public static string defaultImage = "~/img/default.png";
    public static string baseUrl = "/";
    public static string ImageUrl = "http://admin.kazaskerfenbilimleri.com/uploads/";
    public static string RawUrl { get; set; }
    public static string jokerPass = "123_*1";


}




