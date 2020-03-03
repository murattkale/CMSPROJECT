using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class Kasa : BaseModel
    {
        public Kasa()
        {
            HesapAliciKasa = new HashSet<Hesap>();
            HesapIlgiliKasa = new HashSet<Hesap>();
            UstKasaList = new HashSet<Kasa>();
        }

       
        [Required()] public string Ad  { get; set; }
        [Required()] public int ParaBirimId { get; set; }
        public int? BankaId { get; set; }
        public int? UstKasaId { get; set; }
        public double? GelenTotal { get; set; }
        public double? CekilenTotal { get; set; }
        public double? Total { get; set; }
        public int? KurumId { get; set; }
        public int? SubeId { get; set; }

        public virtual Banka Banka { get; set; }
        public virtual Kurum Kurum { get; set; }
        public virtual ParaBirimi ParaBirim { get; set; }
        public virtual Sube Sube { get; set; }
        public virtual Kasa UstKasa { get; set; }
        public virtual ICollection<Hesap> HesapAliciKasa { get; set; }
        public virtual ICollection<Hesap> HesapIlgiliKasa { get; set; }
        public virtual ICollection<Kasa> UstKasaList { get; set; }
    }
}
