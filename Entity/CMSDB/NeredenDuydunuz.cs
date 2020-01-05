using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class NeredenDuydunuz : BaseModel
    {
        public NeredenDuydunuz()
        {
            OgrenciDetay = new HashSet<OgrenciDetay>();
        }

       
        
        
        
       
        
       
       
        public string Name { get; set; }

        public virtual ICollection<OgrenciDetay> OgrenciDetay { get; set; }
    }
}
