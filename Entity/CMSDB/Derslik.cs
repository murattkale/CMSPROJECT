using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Derslik : BaseModel
    {
        public Derslik()
        {
            Sinif = new HashSet<Sinif>();
        }

       
        public string Ad { get; set; }

        public virtual ICollection<Sinif> Sinif { get; set; }
    }
}
