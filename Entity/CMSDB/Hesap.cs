using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Hesap : BaseModel
    {
        public Hesap()
        {
            OdemeDetay = new HashSet<OdemeDetay>();
        }

       
        
       
        public int HesapTipId { get; set; }
        public int IlgiliKasaId { get; set; }
        public int? AliciKasaId { get; set; }
        public int OdemeTipId { get; set; }
        public double Tutar { get; set; }
        public string Aciklama { get; set; }
        public bool OnayTip { get; set; }

        public virtual Kasa AliciKasa { get; set; }
        public virtual HesapTip HesapTip { get; set; }
        public virtual Kasa IlgiliKasa { get; set; }
        public virtual OdemeTip OdemeTip { get; set; }
        public virtual ICollection<OdemeDetay> OdemeDetay { get; set; }
    }
}
