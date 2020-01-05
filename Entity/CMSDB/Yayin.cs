using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Yayin : BaseModel
    {
        public Yayin()
        {
            OgrenciSozlesmeYayin = new HashSet<OgrenciSozlesmeYayin>();
        }

       
        
        
        
       
        
       
       
        public string Ad { get; set; }
        public int? BransId { get; set; }
        public int SinifSeviye { get; set; }
        public int DersId { get; set; }
        public int StokAdet { get; set; }

        public virtual Brans Brans { get; set; }
        public virtual Ders Ders { get; set; }
        public virtual ICollection<OgrenciSozlesmeYayin> OgrenciSozlesmeYayin { get; set; }
    }
}
