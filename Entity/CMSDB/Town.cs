using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Town : BaseModel
    {
        public Town()
        {
            Kurum = new HashSet<Kurum>();
            Sube = new HashSet<Sube>();
        }

       
        public int CityId { get; set; }
        public string TownName { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Kurum> Kurum { get; set; }
        public virtual ICollection<Sube> Sube { get; set; }
    }
}
