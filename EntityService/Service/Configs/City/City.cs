﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public partial class City : BaseModel
{
    public City()
    {
        Kurum = new HashSet<Kurum>();
        Sube = new HashSet<Sube>();
        Town = new HashSet<Town>();
    }









    [DisplayName("İL")] public string CityName { get; set; }

    public virtual ICollection<Kurum> Kurum { get; set; }
    public virtual ICollection<Sube> Sube { get; set; }
    public virtual ICollection<Town> Town { get; set; }
}
