using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;


    public partial class Yayin : BaseModel
    {
        public Yayin()
        {
            OgrenciSozlesmeYayin = new HashSet<OgrenciSozlesmeYayin>();
        }

       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }
        public int? BransId { get; set; }
        [Required()] public int SinifSeviye { get; set; }
        [Required()] public int DersId { get; set; }
        [Required()] public int StokAdet { get; set; }

        public virtual Brans Brans { get; set; }
        public virtual Ders Ders { get; set; }
        public virtual ICollection<OgrenciSozlesmeYayin> OgrenciSozlesmeYayin { get; set; }
    }
