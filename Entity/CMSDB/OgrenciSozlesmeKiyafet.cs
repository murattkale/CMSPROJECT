using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class OgrenciSozlesmeKiyafet : BaseModel
    {
       
        
        
        
       
        
       
       
        public int OgrenciSozlesmeId { get; set; }
        public int KiyafetId { get; set; }

        public virtual Kiyafet Kiyafet { get; set; }
        public virtual OgrenciSozlesme OgrenciSozlesme { get; set; }
    }
}
