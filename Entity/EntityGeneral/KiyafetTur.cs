using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;


    public partial class KiyafetTur : BaseModel
    {
        public KiyafetTur()
        {
            Kiyafet = new HashSet<Kiyafet>();
        }

       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }

        public virtual ICollection<Kiyafet> Kiyafet { get; set; }
    }

