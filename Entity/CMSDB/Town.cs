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

        public int Id { get; set; }
        public int CreaUser { get; set; }
        public DateTime CreaDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public int? OrderNo { get; set; }
        public DateTime? IsDeleted { get; set; }
        public int? IsStatus { get; set; }
        public int CityId { get; set; }
        public string TownName { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Kurum> Kurum { get; set; }
        public virtual ICollection<Sube> Sube { get; set; }
    }
}
