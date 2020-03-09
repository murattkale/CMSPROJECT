using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;




public enum LoginErrorType : int
{
    Error = -1,
    Success = 0,
    Page = 1,
    Permission = 2,
    Role = 3,
    User = 4,
}

public enum ContentPageType : int
{
    //[Description("Kategori")]
    //kategori = 11,
    [Description("SAYFA")]
    Sayfa = 12,
    [Description("AnaSayfa 1.KISIM")]
    row1 = 1,
    [Description("AnaSayfa 2.KISIM")]
    row2 = 2,
    [Description("AnaSayfa 3.KISIM")]
    row3 = 3,
    [Description("AnaSayfa 4.KISIM")]
    row4 = 4,
    [Description("AnaSayfa 5.KISIM")]
    row5 = 5,
    [Description("ETKİNLİK (Max 10 Görsel)")]
    etkinlikler = 13,
    [Description("BLOG (Max 10 Görsel)")]
    blog = 14,
    [Description("HABER (Max 10 Görsel)")]
    haberler = 15,
    [Description("GALERİ (Max 10 Görsel)")]
    galeri = 16,
    [Description("ÜST SLİDER (Max 10 Görsel)")]
    sliderUst = 17,
    [Description("ALT SLİDER (Max 10 Görsel)")]
    sliderAlt = 18,
}


public enum FormType : int
{
    [Description("Anasayfa")]
    Anasayfa = 1,
    [Description("İletişim")]
    Iletisim = 2,

}




