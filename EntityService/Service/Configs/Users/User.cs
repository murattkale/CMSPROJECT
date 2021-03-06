﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using System.ComponentModel.DataAnnotations.Schema;


public partial class User : BaseModel
{
    public User()
    {
        OgrenciDetay = new HashSet<OgrenciDetay>();
        OgrenciSozlesmeGorusenPersonel = new HashSet<OgrenciSozlesme>();
        OgrenciSozlesmeKurumaGetirenPersonel = new HashSet<OgrenciSozlesme>();
        ServiceConfigAuth = new HashSet<ServiceConfigAuth>();
        SinifOgrenci = new HashSet<SinifOgrenci>();
        UserRoles = new HashSet<UserRole>();

    }

    [DisplayName("Kurum")] public int? KurumId { get; set; }
    public virtual Kurum Kurum { get; set; }

    [DisplayName("Şube")] public int? SubeId { get; set; }
    public virtual Sube Sube { get; set; }

    [Required()]
    [DisplayName("TC No")]
    [MaxLength(11)]
    public string Tc { get; set; }
    [Required]
    [DisplayName("Şifre")]
    public string Pass { get; set; }
    [Required]
    [DisplayName("Ad")]
    public string Name { get; set; }
    [Required]
    [DisplayName("Soyad")]
    public string Surname { get; set; }
    [DisplayName("Mail 1")]
    public string Mail1 { get; set; }
    [DisplayName("Mail 2")]
    public string Mail2 { get; set; }
    [DisplayName("Telefon 1")]
    public string Phone1 { get; set; }
    [DisplayName("Telefon 2")]
    public string Phone2 { get; set; }
    [DisplayName("Telefon 3")]
    public string Phone3 { get; set; }
    [DisplayName("Adres 1")]
    public string Adress1 { get; set; }
    [DisplayName("Adres 2")]
    public string Adress2 { get; set; }
    [DisplayName("Doğum Tarihi")]
    public DateTime BirdhDay { get; set; }
    [DisplayName("Kullanıcı No")]
    public string UserNo { get; set; }

    [Required]
    [DisplayName("Cinsiyet")]
    public SexType SexType { get; set; }

    [DisplayName("İL")]
    public int? CityId { get; set; }
    [DisplayName("İlçe")]
    public int? TownId { get; set; }
    [DisplayName("Posta Kodu")]
    public string ZipCode { get; set; }
    [DisplayName("Profil Resmi")]
    public string ProfilImage { get; set; }
    [DisplayName("Açıklama")]
    //[Column(TypeName = "Text")]
    public string Description { get; set; }

    public City City { get; set; }
    public Town Town { get; set; }


    public virtual ICollection<OgrenciDetay> OgrenciDetay { get; set; }
    public virtual ICollection<OgrenciSozlesme> OgrenciSozlesmeGorusenPersonel { get; set; }
    public virtual ICollection<OgrenciSozlesme> OgrenciSozlesmeKurumaGetirenPersonel { get; set; }
    public virtual ICollection<ServiceConfigAuth> ServiceConfigAuth { get; set; }
    public virtual ICollection<SinifOgrenci> SinifOgrenci { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
}

