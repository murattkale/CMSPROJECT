using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Brans : BaseModel
    {
        public Brans()
        {
            DersBrans = new HashSet<DersBrans>();
            Yayin = new HashSet<Yayin>();
        }

       
        
        
        
       
        
       
       
        public string Ad { get; set; }
        public int KurumId { get; set; }

        public virtual Kurum Kurum { get; set; }
        public virtual ICollection<DersBrans> DersBrans { get; set; }
        public virtual ICollection<Yayin> Yayin { get; set; }
    }
}
