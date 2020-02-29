using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class OkulTip : BaseModel
    {
        public OkulTip()
        {
            Okullar = new HashSet<Okullar>();
        }

       
        
        
        
       
        
       
       
        public string Ad { get; set; }
        [Required()] public int OkulTipId { get; set; }

        public virtual ICollection<Okullar> Okullar { get; set; }
    }
}
