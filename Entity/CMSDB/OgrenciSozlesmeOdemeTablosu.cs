using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class OgrenciSozlesmeOdemeTablosu : BaseModel
    {
       
        
        
        
       
        
       
       
        public int OgrenciSozlesmeId { get; set; }
        public double Tutar { get; set; }
        public DateTime PesinatTarih { get; set; }

        public virtual OgrenciSozlesme OgrenciSozlesme { get; set; }
    }
}
