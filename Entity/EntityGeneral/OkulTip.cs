using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class OkulTip : BaseModel
    {
        public OkulTip()
        {
            Okullar = new HashSet<Okul>();
        }

       
        
        
        
       
        
       
       
        public string Ad { get; set; }
        [Required()] public int OkulTipId { get; set; }

        public virtual ICollection<Okul> Okullar { get; set; }
    }
}
