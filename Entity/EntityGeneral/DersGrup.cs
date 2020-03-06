using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;


    public partial class DersGrup : BaseModel
    {
        public DersGrup()
        {
            Ders = new HashSet<Ders>();
        }

       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }

        public virtual ICollection<Ders> Ders { get; set; }
    }

