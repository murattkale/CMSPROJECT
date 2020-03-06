using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;


    public partial class SinifOgrenci : BaseModel
    {

  




        [Required()] public int SinifId { get; set; }
        [Required()] public int OgrenciDetayId { get; set; }

        public virtual OgrenciDetay OgrenciDetay { get; set; }
        public virtual Sinif Sinif { get; set; }

    }

