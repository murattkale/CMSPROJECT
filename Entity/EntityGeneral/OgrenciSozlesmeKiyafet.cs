using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class OgrenciSozlesmeKiyafet : BaseModel
    {
       
        
        
        
       
        
       
       
        [Required()] public int OgrenciSozlesmeId { get; set; }
        [Required()] public int KiyafetId { get; set; }

        public virtual Kiyafet Kiyafet { get; set; }
        public virtual OgrenciSozlesme OgrenciSozlesme { get; set; }
    }
}
