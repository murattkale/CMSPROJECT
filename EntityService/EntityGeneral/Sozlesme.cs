using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


    public partial class Sozlesme : BaseModel
    {
       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }
        public string Metin { get; set; }
        [Required()] [DisplayName("Şube")] public int SubeId { get; set; }

        public virtual Sube Sube { get; set; }
    }
