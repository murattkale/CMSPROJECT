using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public partial class KasaTip:BaseModel
    {
        public KasaTip()
        {
            Hesap = new HashSet<Hesap>();
            Kasa = new HashSet<Kasa>();
        }

        public string Ad { get; set; }
        public int? BankaId { get; set; }

        [ForeignKey(nameof(BankaId))]
        [InverseProperty("KasaTip")]
        public virtual Banka Banka { get; set; }
        [InverseProperty("KasaTip")]
        public virtual ICollection<Hesap> Hesap { get; set; }
        [InverseProperty("KasaTip")]
        public virtual ICollection<Kasa> Kasa { get; set; }
    }
}
