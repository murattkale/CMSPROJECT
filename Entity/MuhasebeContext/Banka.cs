using System;
using System.Collections.Generic;

namespace Entity.MuhasebeContext
{
    public partial class Banka : BaseModel
    {
        public Banka()
        {
            Kasa = new HashSet<Kasa>();
            OdemeTip = new HashSet<OdemeTip>();
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

        public virtual ICollection<Kasa> Kasa { get; set; }
        public virtual ICollection<OdemeTip> OdemeTip { get; set; }
    }
}
