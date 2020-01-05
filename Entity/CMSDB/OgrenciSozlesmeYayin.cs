using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class OgrenciSozlesmeYayin : BaseModel
    {
       
        
        
        
       
        
       
       
        public int OgrenciSozlesmeId { get; set; }
        public int YayinId { get; set; }

        public virtual OgrenciSozlesme OgrenciSozlesme { get; set; }
        public virtual Yayin Yayin { get; set; }
    }
}
