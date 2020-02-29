using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class Okullar : BaseModel
    {
        public Okullar()
        {
            OgrenciDetay = new HashSet<OgrenciDetay>();
        }

       
        
        
        
       
        
       
       
        public string Ad { get; set; }
        [Required()] public int OkulTipId { get; set; }

        public virtual ICollection<OgrenciDetay> OgrenciDetay { get; set; }
    }
}
