using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Servis : BaseModel
    {
        public Servis()
        {
            OgrenciSozlesme = new HashSet<OgrenciSozlesme>();
        }

       
        
        
        
       
        
       
       
        public int SubeId { get; set; }
        public string Plaka { get; set; }
        public string Guzergah { get; set; }
        public int Kapasite { get; set; }

        public virtual ICollection<OgrenciSozlesme> OgrenciSozlesme { get; set; }
    }
}
