using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class Servis : BaseModel
    {
        public Servis()
        {
            OgrenciSozlesme = new HashSet<OgrenciSozlesme>();
        }

       
        
        
        
       
        
       
       
        [Required()] public int SubeId { get; set; }
        public string Plaka { get; set; }
        public string Guzergah { get; set; }
        [Required()] public int Kapasite { get; set; }

        public virtual ICollection<OgrenciSozlesme> OgrenciSozlesme { get; set; }
    }
}
