using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class DersBrans : BaseModel
    {
       
        
        
        
       
        
       
       
        public int BransId { get; set; }
        public int DersId { get; set; }

        public virtual Brans Brans { get; set; }
        public virtual Ders Ders { get; set; }
    }
}
