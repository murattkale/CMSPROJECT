using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Okullar : BaseModel
    {
        public Okullar()
        {
            OgrenciDetay = new HashSet<OgrenciDetay>();
        }

       
        
        
        
       
        
       
       
        public string Ad { get; set; }
        public int OkulTipId { get; set; }

        public virtual ICollection<OgrenciDetay> OgrenciDetay { get; set; }
    }
}
