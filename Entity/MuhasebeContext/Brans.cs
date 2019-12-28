using System;
using System.Collections.Generic;

namespace Entity.MuhasebeContext
{
    public partial class Brans : BaseModel
    {
        public int Id { get; set; }
        public int CreaUser { get; set; }
        public DateTime CreaDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public int? OrderNo { get; set; }
        public DateTime? IsDeleted { get; set; }
        public int? IsStatus { get; set; }
        public string Ad { get; set; }
        public int KurumId { get; set; }

        public virtual Kurum Kurum { get; set; }
    }
}
