using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public partial class Brand : BaseModel
{
    public Brand()
    {
        Model = new HashSet<Model>();
        ContentPage = new HashSet<ContentPage>();
    }


    [DisplayName("Marka Adı")]
    public string Name { get; set; }

    public virtual ICollection<Model> Model { get; set; }
    public virtual ICollection<ContentPage> ContentPage { get; set; }
}

