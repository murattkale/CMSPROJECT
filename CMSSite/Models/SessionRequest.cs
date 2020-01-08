
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
    public static string ImageUrl = "http://cms.dyness.com.tr/uploads/";

    public static string defaultImage = "/images/default.png";
    public static string logo = "/content/img/logo.png";


    public static int KurumId { get; set; }
    public static int SubeId { get; set; }
    //public static int KurumId
    //{
    //    get
    //    {
    //        //return AppHttpContext.Current.Request.GetString("_User").Cast<Kullanici>() as Kullanici;
    //        return AppHttpContext.Current.Request.Path.Value.Split('/')[1].Replace("/", "").ToInt();
    //    }
    //}


    //public static int SubeId
    //{
    //    get
    //    {
    //        return AppHttpContext.Current.Request.Path.Value.Contains("/sube/")
    //            || AppHttpContext.Current.Request.Path.Value.Contains("/iletisim/") ?
    //            AppHttpContext.Current.Request.Path.Value.Split('/').LastOrDefault().Replace("/", "").ToInt() : 0;
    //    }
    //}

    public static string baseUrl { get; set; }
    //public static string baseUrl
    //{
    //    get
    //    {
    //        return "/" + AppHttpContext.Current.Request.Path.Value.Split('/')[1].Replace("/", "") + "/";
    //    }
    //}

    //public static string RawUrl
    public static string RawUrl { get; set; }
    //{
    //    get
    //    {
    //        return AppHttpContext.Current.Request.Path.Value;
    //    }
    //}


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




