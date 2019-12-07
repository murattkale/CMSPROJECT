
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



    public static string Trans(this string keyword)
    {
        return keyword;
    }

}


