﻿using System;
using System.Collections.Generic;

namespace Entity.MuhasebeContext
{
    public partial class Kasa : BaseModel
    {
        public Kasa()
        {
            HesapAliciKasa = new HashSet<Hesap>();
            HesapIlgiliKasa = new HashSet<Hesap>();
            InverseUstKasa = new HashSet<Kasa>();
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
        public int ParaBirimId { get; set; }
        public int? BankaId { get; set; }
        public int? UstKasaId { get; set; }
        public double? GelenTotal { get; set; }
        public double? CekilenTotal { get; set; }
        public double? Total { get; set; }

        public virtual Banka Banka { get; set; }
        public virtual ParaBirimi ParaBirim { get; set; }
        public virtual Kasa UstKasa { get; set; }
        public virtual ICollection<Hesap> HesapAliciKasa { get; set; }
        public virtual ICollection<Hesap> HesapIlgiliKasa { get; set; }
        public virtual ICollection<Kasa> InverseUstKasa { get; set; }
    }
}
