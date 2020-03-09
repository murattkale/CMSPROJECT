using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


public partial class ContentPage : BaseModel
{
    public ContentPage()
    {
        Documents = new HashSet<Documents>();
        ContentPageChilds = new HashSet<ContentPage>();
    }

    [DisplayName("Üst Kategori")]
    public int? ContentPageId { get; set; }

    [DisplayName("Başlık")]
    public string Name { get; set; }


    [DisplayName("İçerik Tipi")]
    [Required()] public ContentPageType ContentPageType { get; set; }


    [DisplayName("İçerik Sırası")]
    public int? ContentOrderNo { get; set; }


    [DisplayName("Üst Menü")]
    public bool? IsHeaderMenu { get; set; }
    [DisplayName("Alt Menü")]
    public bool? IsFooterMenu { get; set; }
    [DisplayName("Yan Menü")]
    public bool? IsSideMenu { get; set; }
    [DisplayName("Hamburger Menü")]
    public bool? IsHamburgerMenu { get; set; }

    [DataType("text")]
    [DisplayName("İçerik")]
    public string ContentData { get; set; }


    [DisplayName("Kısa İçerik")]
    public string ContentShort { get; set; }

    public string Link { get; set; }

    [DisplayName("Video Link")]
    public string VideoLink { get; set; }


    [DisplayName("Resim Link")]
    public string ResimLink { get; set; }


    public string MetaKeywords { get; set; }
    public string MetaDescription { get; set; }

    [DataType("text")]
    public string HeadScript { get; set; }
    [DataType("text")]
    public string HeadStyle { get; set; }
    [DataType("text")]
    public string BodyScript { get; set; }
    [DataType("text")]
    public string FooterScript { get; set; }
    [DataType("text")]
    public string FooterStyle { get; set; }

    public string BannerText { get; set; }
    public string BannerImage { get; set; }
    public string DefaultImage { get; set; }

    public string ButtonText1 { get; set; }
    public string ButtonText1Link { get; set; }
    public string ButtonText2 { get; set; }
    public string ButtonText2Link { get; set; }


    public virtual ICollection<Documents> Documents { get; set; }
    public virtual ICollection<ContentPage> ContentPageChilds { get; set; }

    public virtual ContentPage Parent { get; set; }
}

