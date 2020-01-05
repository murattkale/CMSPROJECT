using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class SinifOgrenci : BaseModel
    {
       
        
        
        
       
        
       
       
        public int SinifId { get; set; }
        public int OgrenciId { get; set; }

        public virtual Users Ogrenci { get; set; }
        public virtual Sinif Sinif { get; set; }
    }
}
