using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


    public partial class Derslik : BaseModel
    {
        public Derslik()
        {
            Sinif = new HashSet<Sinif>();
        }

       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }
        [Required()] [DisplayName("Şube")] public int SubeId { get; set; }

        public virtual Sube Sube { get; set; }
        public virtual ICollection<Sinif> Sinif { get; set; }
    }

