using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class DersGrup : BaseModel
    {
        public DersGrup()
        {
            Ders = new HashSet<Ders>();
        }

       
        
        
        
       
        
       
       
        public string Ad { get; set; }

        public virtual ICollection<Ders> Ders { get; set; }
    }
}
