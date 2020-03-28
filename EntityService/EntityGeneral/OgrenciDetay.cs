using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public partial class OgrenciDetay : BaseModel
{
    public OgrenciDetay()
    {
        VeliDetay = new HashSet<VeliDetay>();
        OgrenciSozlesme = new HashSet<OgrenciSozlesme>();
        SinifOgrenci = new HashSet<SinifOgrenci>();
    }


    [Required()] public int OgrenciId { get; set; }

    [DisplayName("Öğrenci No")]
    [Required()] public string OgrenciNo { get; set; }

    [DisplayName("Nereden Duydunuz")]
    public int? NeredenDuydunuzId { get; set; }

    [DisplayName("Aile Medeni Durumu")]
    [Required()] public AileMedeniDurum AileMedeniDurum { get; set; }


    [DisplayName("Özel Hastalık")]

    public string OzelHastalik { get; set; }

    [DisplayName("Sınıf Tekrarı")]

    public bool? SinifTekrar { get; set; }

    [DisplayName("Okulu")]
    public int? OkulId { get; set; }


    public virtual User Ogrenci { get; set; }
    public virtual NeredenDuydunuz NeredenDuydunuz { get; set; }
    public virtual Okul Okul { get; set; }
    public virtual ICollection<OgrenciSozlesme> OgrenciSozlesme { get; set; }

    public virtual ICollection<VeliDetay> VeliDetay { get; set; }

    public virtual ICollection<SinifOgrenci> SinifOgrenci { get; set; }
}

