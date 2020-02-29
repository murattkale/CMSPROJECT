using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class NeredenDuydunuz : BaseModel
    {
        public NeredenDuydunuz()
        {
            OgrenciDetay = new HashSet<OgrenciDetay>();
        }

       
        
        
        
       
        
       
       
        public string Ad { get; set; }

        public virtual ICollection<OgrenciDetay> OgrenciDetay { get; set; }
    }
}
