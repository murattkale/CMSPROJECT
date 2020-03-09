using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


public partial class Formlar : BaseModel
{

    [Required()] public string Ad { get; set; }
    [Required()] public string Soyad { get; set; }
    public string Mail { get; set; }
    [Required()] public string Telefon { get; set; }
    public string Adres { get; set; }
    public string Icerik { get; set; }

    public FormType? FormType { get; set; }


}

