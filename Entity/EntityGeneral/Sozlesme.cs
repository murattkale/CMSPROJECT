using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class Sozlesme : BaseModel
    {
       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }
        public string Metin { get; set; }
        [Required()] public int SubeId { get; set; }

        public virtual Sube Sube { get; set; }
    }
}
