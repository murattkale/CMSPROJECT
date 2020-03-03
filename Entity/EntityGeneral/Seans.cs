using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class Seans : BaseModel
    {
        public Seans()
        {
            Sinif = new HashSet<Sinif>();
        }

       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }
        [Required()] public int SubeId { get; set; }

        public virtual Sube Sube { get; set; }
        public virtual ICollection<Sinif> Sinif { get; set; }
    }
}
