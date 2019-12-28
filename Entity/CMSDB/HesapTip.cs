using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class HesapTip : BaseModel
    {
        public HesapTip()
        {
            Hesap = new HashSet<Hesap>();
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
        public int? GelirGiderTipi { get; set; }

        public virtual ICollection<Hesap> Hesap { get; set; }
    }
}
