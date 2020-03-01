using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class HesapTip : BaseModel
    {
        public HesapTip()
        {
            Hesap = new HashSet<Hesap>();
        }

       
        
        
        
       
        
       
       
        public string Ad { get; set; }
        public int? GelirGiderTipi { get; set; }

        public virtual ICollection<Hesap> Hesap { get; set; }
    }
}
