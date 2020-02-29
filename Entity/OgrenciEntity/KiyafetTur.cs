using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class KiyafetTur : BaseModel
    {
        public KiyafetTur()
        {
            Kiyafet = new HashSet<Kiyafet>();
        }

       
        
        
        
       
        
       
       
        public string Ad { get; set; }

        public virtual ICollection<Kiyafet> Kiyafet { get; set; }
    }
}
