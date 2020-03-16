using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public partial class Motor : BaseModel
{
    public Motor()
    {
        ContentPage = new HashSet<ContentPage>();
    }


    [DisplayName("Motor Adı/Kodu")]
    [Required()] public int BrandId { get; set; }
    [DisplayName("Model Adı")]
    public string Name { get; set; }
    [DisplayName("Motor Kodu")]
    public string Code { get; set; }
    [DisplayName("Silindir Hacmi")]
    public string CylinderVolume { get; set; }
    [DisplayName("Beygir Gücü")]
    public string HP { get; set; }

    public virtual Brand Brand { get; set; }
    public virtual ICollection<ContentPage> ContentPage { get; set; }

}

