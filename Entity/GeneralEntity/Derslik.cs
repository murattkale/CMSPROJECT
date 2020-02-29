using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class Derslik : BaseModel
    {
        public Derslik()
        {
            Sinif = new HashSet<Sinif>();
        }

       
        
        
        
       
        
       
       
        public string Ad { get; set; }
        [Required()] public int SubeId { get; set; }

        public virtual Sube Sube { get; set; }
        public virtual ICollection<Sinif> Sinif { get; set; }
    }
}
