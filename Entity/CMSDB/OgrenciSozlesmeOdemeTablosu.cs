using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class OgrenciSozlesmeOdemeTablosu : BaseModel
    {
       
        
        
        
       
        
       
       
        [Required()] public int OgrenciSozlesmeId { get; set; }
        [Required()]  public double  Tutar { get; set; }
        public DateTime PesinatTarih { get; set; }

        public virtual OgrenciSozlesme OgrenciSozlesme { get; set; }
    }
}
