using System;
using System.Collections.Generic;

namespace Entity.MuhasebeContext
{
    public partial class ParaBirimi : BaseModel
    {
        public ParaBirimi()
        {
            Kasa = new HashSet<Kasa>();
        }

     
        public string Ad { get; set; }
        public string Kod { get; set; }

        public virtual ICollection<Kasa> Kasa { get; set; }
    }
}
