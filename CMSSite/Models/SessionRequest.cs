
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;



public static class SessionRequest
{
    public static string Title = "CMS";
    public static string StartPage = "Content";
    public static string StartAction = "Index";
    public static string StyleVersion = DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(".", "").Replace(" ", "");
    public static string Copyright = $"{DateTime.Now.Year} © Tasarım&Yazılım (Design&Software)  <a target='_blank' href='https://www.muratkale.com.tr'>www.muratkale.com.tr </a>";
    public static string ImageUrl = "http://cms.dyness.com.tr/upload";

    public static string defaultImage = "/images/default.png";
    public static string logo = "/content/img/logo.png";


    public static int KurumId
    {
        get
        {
            //return AppHttpContext.Current.Request.GetString("_User").Cast<Kullanici>() as Kullanici;
            return AppHttpContext.Current.Request.Path.Value.Split('/')[1].Replace("/", "").ToInt();
        }
    }


    public static int SubeId
    {
        get
        {
            return AppHttpContext.Current.Request.Path.Value.Contains("/sube/")
                || AppHttpContext.Current.Request.Path.Value.Contains("/iletisim/") ?
                AppHttpContext.Current.Request.Path.Value.Split('/').LastOrDefault().Replace("/", "").ToInt() : 0;
        }
    }

    public static string baseUrl
    {
        get
        {
            return "/" + AppHttpContext.Current.Request.Path.Value.Split('/')[1].Replace("/", "") + "/";
        }
    }

    public static string RawUrl
    {
        get
        {
            return AppHttpContext.Current.Request.Path.Value;
        }
    }


    //#region SessionRequestInfo
    //public static User _User
    //{
    //    get
    //    {
    //        return HttpContext.Current.Session["_User"] as User;
    //    }
    //}


    //#endregion

    //public static string SubUrl
    //{
    //    get
    //    {
    //        string SubUrl = HttpContext.Current.Request.Path.Split('/').FirstOrDefault();
    //        SubUrl = SubUrl == "" ? "/" : "/" + SubUrl + "/";
    //        return SubUrl;
    //    }
    //}

    public static string Trans(this string keyword)
    {
        return keyword;
    }

}

public static class AppHttpContext
{
    static IServiceProvider services = null;

    /// <summary>
    /// Provides static access to the framework's services provider
    /// </summary>
    public static IServiceProvider Services
    {
        get { return services; }
        set
        {
            if (services != null)
            {
                throw new Exception("Can't set once a value has already been set.");
            }
            services = value;
        }
    }

    /// <summary>
    /// Provides static access to the current HttpContext
    /// </summary>
    public static HttpContext Current
    {
        get
        {
            IHttpContextAccessor httpContextAccessor = services.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
            return httpContextAccessor?.HttpContext;
        }
    }

}




