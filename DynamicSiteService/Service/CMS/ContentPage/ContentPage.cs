﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

public partial class ContentPage : BaseModel
{
    public ContentPage()
    {
        Documents = new HashSet<Documents>();
        ContentPageChilds = new HashSet<ContentPage>();
        Gallery = new HashSet<Documents>();
    }


    //1. Sayfa Yapısı
    //[Display(Description ="", Order = 1)]
    [Column(Order = 1)]
    [DisplayName("Üst Kategori")]
    public int? ContentPageId { get; set; }

    [Column(Order = 1)]
    [DisplayName("Başlık")]
    [Required()]
    public string Name { get; set; }

    [Column(Order = 1)]
    [DisplayName("Şablon Tipi")]
    [Required()]
    public ContentPageType ContentPageType { get; set; }




    [Column(Order = 1)]
    [DisplayName("Sayfa Url")]
    [Required()]
    public string Link { get; set; }


    [Column(Order = 1)]
    [DisplayName("Dış Url")]
    public string ExternalLink { get; set; }






    //2. Sayfa İçeriği
    [Column(Order = 2)]
    [DisplayName("Ön Görsel")]
    public Documents ThumbImage { get; set; }

    [Column(Order = 2)]
    [DisplayName("Görsel")]
    public Documents Picture { get; set; }

    [Column(Order = 2)]
    [DisplayName("Banner Görsel")]
    public Documents BannerImage { get; set; }

    [Column(Order = 2)]
    [DisplayName("Banner Yazı")]
    public string BannerText { get; set; }

    [Column(Order = 2)]
    [DisplayName("Banner Button Yazı")]
    public string BannerButtonText { get; set; }

    [Column(Order = 2)]
    [DisplayName("Button Yazı")]
    public string ButtonText { get; set; }

    [Column(Order = 2)]
    [DisplayName("Button Link")]
    public string ButtonLink { get; set; }

    [Column(Order = 2)]
    [DataType("text")]
    [DisplayName("Açıklama")]
    public string Description { get; set; }


    [Column(Order = 2)]
    [DataType("text")]
    [DisplayName("Kısa İçerik")]
    public string ContentShort { get; set; }


    [Column(Order = 2)]
    [DataType("text")]
    [DisplayName("İçerik")]
    public string ContentData { get; set; }



    [Column(Order = 2)]
    [DisplayName("Video Link")]
    public string VideoLink { get; set; }




    //3. Sayfa Ayarları
    [Column(Order = 3)]
    [DisplayName("Üst Menü")]
    public bool? IsHeaderMenu { get; set; }

    [Column(Order = 3)]
    [DisplayName("Alt Menü")]
    public bool? IsFooterMenu { get; set; }

    [Column(Order = 3)]
    [DisplayName("Tıklanabilir")]
    public bool? IsClick { get; set; }

    [Column(Order = 3)]
    [DisplayName("Yan Menü")]
    public bool? IsSideMenu { get; set; }

    [Column(Order = 3)]
    [DisplayName("Hamburger Menü")]
    public bool? IsHamburgerMenu { get; set; }

    [Column(Order = 3)]
    [DisplayName("Form")]
    public bool? IsForm { get; set; }

    [Column(Order = 3)]
    [DisplayName("Galeri")]
    public bool? IsGallery { get; set; }

    [Column(Order = 3)]
    [DisplayName("Harita")]
    public bool? IsMap { get; set; }

    [Column(Order = 3)]
    [DisplayName("Aktiflik Durumu")]
    public bool? IsActive { get; set; }

    [Column(Order = 3)]
    [DisplayName("Yayına Alma Durumu")]
    public bool? IsPublish { get; set; }



    [Column(Order = 3)]
    [DisplayName("İçerik Sırası")]
    public int? ContentOrderNo { get; set; }



    [Column(Order = 3)]
    [DisplayName("Meta Title")]
    public string MetaTitle { get; set; }

    [Column(Order = 3)]
    [DisplayName("Meta Keywords")]
    public string MetaKeywords { get; set; }

    [Column(Order = 3)]
    [DisplayName("Meta Description")]
    public string MetaDescription { get; set; }

    [Column(Order = 3)]
    [DisplayName("Galeri")]
    public virtual ICollection<Documents> Gallery { get; set; }

    [Column(Order = 3)]
    [DisplayName("Dökümanlar")]
    public virtual ICollection<Documents> Documents { get; set; }

    [Column(Order = 3)]
    [DisplayName("Alt Liste")]
    public virtual ICollection<ContentPage> ContentPageChilds { get; set; }

    [Column(Order = 3)]
    [DisplayName("Üst Liste")]
    public virtual ContentPage Parent { get; set; }

    [Column(Order = 3)]
    [DisplayName("Dil")]
    [Required()] public int LangId { get; set; }
    public virtual Lang Lang { get; set; }
}

