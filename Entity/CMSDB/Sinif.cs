using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Sinif : BaseModel
    {
        public Sinif()
        {
            SinifOgrenci = new HashSet<SinifOgrenci>();
        }

        public string Ad { get; set; }
        public int SubeId { get; set; }
        public int? Tur { get; set; }
        public int? Seviye { get; set; }
        public int? SeansId { get; set; }
        public int? DerslikId { get; set; }
        public int? SorumluKisiId { get; set; }
        public int ToplamDersSaati { get; set; }
        public int Kapasite { get; set; }
        public double KayitUcreti { get; set; }
        public int EgitimSuresi { get; set; }

        public virtual Derslik Derslik { get; set; }
        public virtual Seans Seans { get; set; }
        public virtual Sube Sube { get; set; }
        public virtual ICollection<SinifOgrenci> SinifOgrenci { get; set; }
    }
}
