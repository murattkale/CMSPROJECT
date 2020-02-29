using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class SinifOgrenci : BaseModel
    {
       
        
        
        
       
        
       
       
        [Required()] public int SinifId { get; set; }
        [Required()] public int OgrenciId { get; set; }

        public virtual Users Ogrenci { get; set; }
        public virtual Sinif Sinif { get; set; }
    }
}
