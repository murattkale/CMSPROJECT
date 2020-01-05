using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class KiyafetTur : BaseModel
    {
        public KiyafetTur()
        {
            Kiyafet = new HashSet<Kiyafet>();
        }

       
        
        
        
       
        
       
       
        public string Ad { get; set; }

        public virtual ICollection<Kiyafet> Kiyafet { get; set; }
    }
}
