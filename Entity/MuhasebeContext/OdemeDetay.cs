using System;
using System.Collections.Generic;

namespace Entity.MuhasebeContext
{
    public partial class OdemeDetay : BaseModel
    {
        public int HesapId { get; set; }
        public string BankaSubesi { get; set; }
        public string BankaHesapNo { get; set; }
        public string Borclu { get; set; }
        public string CekFazlasi { get; set; }
        public DateTime? VadeTarihi { get; set; }
        public string CekNo { get; set; }
        public string EnSonCiroEden { get; set; }
        public string EkBilgi { get; set; }
        public string KullanilanKartTuru { get; set; }
        public string SlipOnayKodu { get; set; }
        public int? TaksitSayisi { get; set; }

        public virtual Hesap Hesap { get; set; }
    }
}
