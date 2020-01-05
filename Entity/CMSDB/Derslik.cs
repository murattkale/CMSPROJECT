using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Derslik : BaseModel
    {
        public Derslik()
        {
            Sinif = new HashSet<Sinif>();
        }

       
        
        
        
       
        
       
       
        public string Ad { get; set; }
        public int SubeId { get; set; }

        public virtual Sube Sube { get; set; }
        public virtual ICollection<Sinif> Sinif { get; set; }
    }
}
