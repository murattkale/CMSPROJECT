using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public partial class Model : BaseModel
{
    public Model()
    {
        Motor = new HashSet<Motor>();
        ContentPage = new HashSet<ContentPage>();
    }


    [DisplayName("Marka Adı")]
    [Required()] public int BrandId { get; set; }

    [DisplayName("Model Adı")]
    public string Name { get; set; }

    public string Year { get; set; }

    public virtual Brand Brand { get; set; }
    public virtual ICollection<Motor> Motor { get; set; }
    public virtual ICollection<ContentPage> ContentPage { get; set; }
}

