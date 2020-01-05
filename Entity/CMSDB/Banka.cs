using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Banka : BaseModel
    {
        public Banka()
        {
            Kasa = new HashSet<Kasa>();
            OdemeTip = new HashSet<OdemeTip>();
        }

       
        
        
        
       
        
       
       
        public string Ad { get; set; }

        public virtual ICollection<Kasa> Kasa { get; set; }
        public virtual ICollection<OdemeTip> OdemeTip { get; set; }
    }
}
