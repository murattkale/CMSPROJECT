using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;


    public partial class SozlesmeTur : BaseModel
    {
        public SozlesmeTur()
        {
            OgrenciSozlesme = new HashSet<OgrenciSozlesme>();
        }

       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }
        public string Kontroller { get; set; }

        public virtual ICollection<OgrenciSozlesme> OgrenciSozlesme { get; set; }
    }

