using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;


public enum RType
{
    OK = 1,
    Error = 2,
    Warning = 3
}

public enum LoginErrorType
{
    Error = -1,
    Success = 0,
    Page = 1,
    Permission = 2,
    Role = 3,
    User = 4,
}

public enum ContentPageType
{
    //[Description("KATEGORİ")]
    //Kategori = 1,
    [Description("SAYFA")]
    Sayfa = 2,
    [Description("1.KISIM")]
    row1 = 3,
    [Description("2.KISIM")]
    row2 = 4,
    [Description("3.KISIM")]
    row3 = 5,
    [Description("4.KISIM")]
    row4 = 6,
    [Description("ÜST SLİDER (Max 10 Görsel)")]
    sliderUst = 7,
    [Description("ALT SLİDER (Max 10 Görsel)")]
    sliderAlt = 8,
    [Description("ETKİNLİK")]
    etkinlikler = 9,
    [Description("HABER")]
    haberler = 10,
    [Description("3'LÜ HABER")]
    haberler3 = 11,
    [Description("3'LÜ ETKİNLİK")]
    etkinlikler3 = 12,
    [Description("GALERİ (Max 3 Görsel)")]
    galeri = 13,
}


public enum FormType
{
    [Description("Anasayfa")]
    Anasayfa = 1,
    [Description("Şube")]
    Şube = 2,
    [Description("Franch")]
    Franch = 3,
    [Description("Diğer")]
    Diger = 4,
    [Description("ilkteknem.com")]
    ilkteknem = 9,
}

public enum GelirGiderType
{
    [Description("Gelir")]
    Gelir = 1,
    [Description("Gider")]
    Gider = 2,
}


public enum YakinlikDerecesi
{
    [Description("Anne")]
    Anne = 1,
    [Description("Baba")]
    Baba = 2,
    [Description("Teyze")]
    Teyze = 3,
    [Description("Hala")]
    Hala = 4,
    [Description("Amca")]
    Amca = 5,
    [Description("Dayı")]
    Dayi = 6,
    [Description("Dede")]
    Dede = 7,
    [Description("BüyükAnne")]
    BüyükAnne = 8,
    [Description("Diğer")]
    Diger = 9,
}




