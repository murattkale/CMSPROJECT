using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public partial class Hesap:BaseModel
    {
        public int? Tip { get; set; }
        [Column("HesapTipID")]
        public int? HesapTipId { get; set; }
        [Column("ilgiliKasaId")]
        public int? IlgiliKasaId { get; set; }
        [Column("aliciKasaId")]
        public int? AliciKasaId { get; set; }
        public int? KasaTipId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Tutar { get; set; }
        [Column("islemTarihi", TypeName = "datetime")]
        public DateTime? IslemTarihi { get; set; }
        public string Aciklama { get; set; }
        public bool? OnayTipId { get; set; }

        [ForeignKey(nameof(HesapTipId))]
        [InverseProperty("Hesap")]
        public virtual HesapTip HesapTip { get; set; }
        [ForeignKey(nameof(IlgiliKasaId))]
        [InverseProperty(nameof(Kasa.Hesap))]
        public virtual Kasa IlgiliKasa { get; set; }
        [ForeignKey(nameof(KasaTipId))]
        [InverseProperty("Hesap")]
        public virtual KasaTip KasaTip { get; set; }
    }
}
