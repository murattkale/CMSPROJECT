using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;


    public partial class DersBrans : BaseModel
    {
       
        
        
        
       
        
       
       
        [Required()] public int BransId { get; set; }
        [Required()] public int DersId { get; set; }

        public virtual Brans Brans { get; set; }
        public virtual Ders Ders { get; set; }
    }

