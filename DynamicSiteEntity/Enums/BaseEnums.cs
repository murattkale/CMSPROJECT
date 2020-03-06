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
    [Description("SAYFA")]
    Sayfa = 2,
    [Description("AnaSayfa 1.KISIM")]
    row1 = 3,
    [Description("AnaSayfa 2.KISIM")]
    row2 = 4,
    [Description("AnaSayfa 3.KISIM")]
    row4 = 6,
    [Description("ÜST SLİDER (Max 10 Görsel)")]
    sliderUst = 7,
    [Description("ALT SLİDER (Max 10 Görsel)")]
    sliderAlt = 8,
    [Description("ETKİNLİK (Max 10 Görsel - Boyut:370x275)")]
    etkinlikler = 9,
    [Description("HABER (Max 10 Görsel - Boyut:370x205)")]
    haberler = 10,
    [Description("3'LÜ HABER (Max 10 Görsel - Boyut:370x205)")]
    haberler3 = 11,
    [Description("3'LÜ ETKİNLİK (Max 10 Görsel - Boyut:370x275)")]
    etkinlikler3 = 12,
    [Description("GALERİ (Max 3 Görsel)")]
    galeri = 13,
}


public enum FormType : int
{
    [Description("Anasayfa")]
    Anasayfa = 1,
    [Description("İletişim")]
    Iletisim = 2,

}




