using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


    public partial class Servis : BaseModel
    {
        public Servis()
        {
            OgrenciSozlesme = new HashSet<OgrenciSozlesme>();
        }

       
        
        
        
       
        
       
       
        [Required()] [DisplayName("Şube")] public int SubeId { get; set; }
        public string Plaka { get; set; }
        public string Guzergah { get; set; }
        [Required()] public int Kapasite { get; set; }

        public virtual Sube Sube { get; set; }
        public virtual ICollection<OgrenciSozlesme> OgrenciSozlesme { get; set; }
    }

