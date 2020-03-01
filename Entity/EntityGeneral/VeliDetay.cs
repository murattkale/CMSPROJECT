using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class VeliDetay : BaseModel
    {
        public VeliDetay()
        {
            OgrenciSozlesme = new HashSet<OgrenciSozlesme>();
        }

       
        
        
        
       
        
       
       
        [Required()] public int OgrenciDetayId { get; set; }
        [Required()] public YakinlikDerecesi YakinlikDerecesiId { get; set; }
        public bool? Iletisim { get; set; }

        public virtual OgrenciDetay OgrenciDetay { get; set; }
        public virtual ICollection<OgrenciSozlesme> OgrenciSozlesme { get; set; }
    }
}
