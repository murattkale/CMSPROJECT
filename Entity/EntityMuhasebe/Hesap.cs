using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

    public partial class Hesap : BaseModel
    {
        public Hesap()
        {
            OdemeDetay = new HashSet<OdemeDetay>();
        }

       
        
       
        [Required()] public int HesapTipId { get; set; }
        [Required()] public int IlgiliKasaId { get; set; }
        public int? AliciKasaId { get; set; }
        [Required()] public int OdemeTipId { get; set; }
        [Required()]  public double  Tutar { get; set; }
        public string Aciklama { get; set; }
        public bool OnayTip { get; set; }

        public virtual Kasa AliciKasa { get; set; }
        public virtual HesapTip HesapTip { get; set; }
        public virtual Kasa IlgiliKasa { get; set; }
        public virtual OdemeTip OdemeTip { get; set; }
        public virtual ICollection<OdemeDetay> OdemeDetay { get; set; }
    }
