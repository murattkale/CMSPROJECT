using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public partial class Kasa:BaseModel
    {
        public Kasa()
        {
            Hesap = new HashSet<Hesap>();
            InverseUstKasa = new HashSet<Kasa>();
        }

        public string Ad { get; set; }
        public int? ParaBirimId { get; set; }
        public int? KasaTipId { get; set; }
        public int? UstKasaId { get; set; }
        public int? SubeId { get; set; }
        public int? OgrenciId { get; set; }
        public int? PersonelId { get; set; }

        [ForeignKey(nameof(KasaTipId))]
        [InverseProperty("Kasa")]
        public virtual KasaTip KasaTip { get; set; }
        [ForeignKey(nameof(ParaBirimId))]
        [InverseProperty(nameof(ParaBirimi.Kasa))]
        public virtual ParaBirimi ParaBirim { get; set; }
        [ForeignKey(nameof(UstKasaId))]
        [InverseProperty(nameof(Kasa.InverseUstKasa))]
        public virtual Kasa UstKasa { get; set; }
        [InverseProperty("IlgiliKasa")]
        public virtual ICollection<Hesap> Hesap { get; set; }
        [InverseProperty(nameof(Kasa.UstKasa))]
        public virtual ICollection<Kasa> InverseUstKasa { get; set; }
    }
}
