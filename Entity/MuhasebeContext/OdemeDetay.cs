using System;
using System.Collections.Generic;

namespace Entity.MuhasebeContext
{
    public partial class OdemeDetay : BaseModel
    {
        public int Id { get; set; }
        public int CreaUser { get; set; }
        public DateTime CreaDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public int? OrderNo { get; set; }
        public DateTime? IsDeleted { get; set; }
        public int? IsStatus { get; set; }
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
