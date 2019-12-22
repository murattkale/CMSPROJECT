using System;
using System.Collections.Generic;

namespace Entity.MuhasebeContext
{
    public partial class OdemeTip : BaseModel
    {
        public OdemeTip()
        {
            Hesap = new HashSet<Hesap>();
        }

        public string Ad { get; set; }
        public int? BankaId { get; set; }

        public virtual Banka Banka { get; set; }
        public virtual ICollection<Hesap> Hesap { get; set; }
    }
}
