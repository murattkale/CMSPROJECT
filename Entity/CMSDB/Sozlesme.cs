using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Sozlesme : BaseModel
    {
       
        
        
        
       
        
       
       
        public string Ad { get; set; }
        public string Metin { get; set; }
        public int SubeId { get; set; }

        public virtual Sube Sube { get; set; }
    }
}
