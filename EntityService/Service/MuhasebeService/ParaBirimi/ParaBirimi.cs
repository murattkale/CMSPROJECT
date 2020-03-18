using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;


    public partial class ParaBirimi : BaseModel
    {
        public ParaBirimi()
        {
            Kasa = new HashSet<Kasa>();
        }

       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }
        public string Kod { get; set; }

        public virtual ICollection<Kasa> Kasa { get; set; }
    }

