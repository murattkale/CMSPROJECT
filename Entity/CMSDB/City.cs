using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class City : BaseModel
    {
        public City()
        {
            Kurum = new HashSet<Kurum>();
            Sube = new HashSet<Sube>();
            Town = new HashSet<Town>();
        }

        public int Id { get; set; }
        public int CreaUser { get; set; }
        public DateTime CreaDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public int? OrderNo { get; set; }
        public DateTime? IsDeleted { get; set; }
        public int? IsStatus { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Kurum> Kurum { get; set; }
        public virtual ICollection<Sube> Sube { get; set; }
        public virtual ICollection<Town> Town { get; set; }
    }
}
