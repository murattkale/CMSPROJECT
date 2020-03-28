using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public partial class VeliDetay : BaseModel
{
    public VeliDetay()
    {
        OgrenciSozlesme = new HashSet<OgrenciSozlesme>();
    }



    [Required()] public int OgrenciDetayId { get; set; }

    [DisplayName("Yakınlık Derecesi")]
    [Required()] public YakinlikDerecesi YakinlikDerecesi { get; set; }

    [DisplayName("Ad")]
    [Required()]
    public string Ad { get; set; }

    [DisplayName("Soyad")]
    [Required()]
    public string Soyad { get; set; }

    [DisplayName("Tc")]
    public string Tc { get; set; }

    [DisplayName("Ev Adresi")]
    public string EvAdres { get; set; }

    [DisplayName("İş Adresi")]
    public string IsAdres { get; set; }


    [DisplayName("Telefon")]
    public string Telefon { get; set; }

    [DisplayName("Mail")]
    public string Mail { get; set; }

    [DisplayName("Not")]
    public string Not { get; set; }


    [DisplayName("İletişim")]
    public bool? Iletisim { get; set; }

    public virtual OgrenciDetay OgrenciDetay { get; set; }
    public virtual ICollection<OgrenciSozlesme> OgrenciSozlesme { get; set; }
}
