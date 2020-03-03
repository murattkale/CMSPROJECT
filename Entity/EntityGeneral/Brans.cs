using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class Brans : BaseModel
    {
        public Brans()
        {
            DersBrans = new HashSet<DersBrans>();
            Yayin = new HashSet<Yayin>();
        }

       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }
        [Required()] public int KurumId { get; set; }

        public virtual Kurum Kurum { get; set; }
        public virtual ICollection<DersBrans> DersBrans { get; set; }
        public virtual ICollection<Yayin> Yayin { get; set; }
    }
}
