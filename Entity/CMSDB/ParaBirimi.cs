using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class ParaBirimi : BaseModel
    {
        public ParaBirimi()
        {
            Kasa = new HashSet<Kasa>();
        }

        public int Id { get; set; }
        public int CreaUser { get; set; }
        public DateTime CreaDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public int? OrderNo { get; set; }
        public DateTime? IsDeleted { get; set; }
        public int? IsStatus { get; set; }
        public string Ad { get; set; }
        public string Kod { get; set; }

        public virtual ICollection<Kasa> Kasa { get; set; }
    }
}
