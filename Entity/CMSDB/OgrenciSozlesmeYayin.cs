using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class OgrenciSozlesmeYayin : BaseModel
    {
       
        
        
        
       
        
       
       
        [Required()] public int OgrenciSozlesmeId { get; set; }
        [Required()] public int YayinId { get; set; }

        public virtual OgrenciSozlesme OgrenciSozlesme { get; set; }
        public virtual Yayin Yayin { get; set; }
    }
}
