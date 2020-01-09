
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;



public static class SessionRequest
{
    public static string Title = "CMS";
    public static string StartPage = "Base";
    public static string StartAction = "Index";
    public static string version = DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(".", "").Replace(" ", "");
    public static string copyright = $"{DateTime.Now.Year} © Yazılım&Tasarım (Software&Design)  <a target='_blank' href='#'> by Murat Kale</a>";
    public static string layoutID = "1";
    //public static string layoutUrl = $"http://content.zonagency.com/demo{layoutID}";
    public static string layoutUrl = $"http://site.dyness.com.tr";
    public static string logo = "~/img/logo.png";
    public static string defaultImage = "~/img/default.png";


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
    public static string Trans(this string keyword)
    {
        return keyword;
    }

}


