using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Ders : BaseModel
    {
        public Ders()
        {
            DersBrans = new HashSet<DersBrans>();
            Yayin = new HashSet<Yayin>();
        }

       
        
        
        
       
        
       
       
        public string Ad { get; set; }
        public int DersGrupId { get; set; }

        public virtual DersGrup DersGrup { get; set; }
        public virtual ICollection<DersBrans> DersBrans { get; set; }
        public virtual ICollection<Yayin> Yayin { get; set; }
    }
}
