using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


    public partial class Sezon : BaseModel
    {
        public Sezon()
        {
            OgrenciSozlesme = new HashSet<OgrenciSozlesme>();
        }

       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }
        [Required()] [DisplayName("Kurum")] public int KurumId { get; set; }

        public virtual Kurum Kurum { get; set; }
        public virtual ICollection<OgrenciSozlesme> OgrenciSozlesme { get; set; }
    }

