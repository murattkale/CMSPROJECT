using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class VeliDetay : BaseModel
    {
        public VeliDetay()
        {
            OgrenciSozlesme = new HashSet<OgrenciSozlesme>();
        }

       
        
        
        
       
        
       
       
        public int OgrenciDetayId { get; set; }
        public int YakinlikDerecesiId { get; set; }
        public bool? Iletisim { get; set; }

        public virtual ICollection<OgrenciSozlesme> OgrenciSozlesme { get; set; }
    }
}
