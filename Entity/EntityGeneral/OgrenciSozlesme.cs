using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class OgrenciSozlesme : BaseModel
    {
        public OgrenciSozlesme()
        {
            OgrenciSozlesmeKiyafet = new HashSet<OgrenciSozlesmeKiyafet>();
            OgrenciSozlesmeOdemeTablosu = new HashSet<OgrenciSozlesmeOdemeTablosu>();
            OgrenciSozlesmeYayin = new HashSet<OgrenciSozlesmeYayin>();
        }

       
        
        
        
       
        
       
       
        [Required()] public int OgrenciDetayId { get; set; }
        [Required()] public int SozlesmeTurId { get; set; }
        public string ReferansAdSoyad { get; set; }
        public int? SubeId { get; set; }
        public int? GorusenPersonelId { get; set; }
        public int? KurumaGetirenPersonelId { get; set; }
        [Required()] public int SezonId { get; set; }
        public int? ServisId { get; set; }
        [Required()] public int FinansorId { get; set; }
        public string FaturaAd { get; set; }
        public string FaturaSoyad { get; set; }
        public string VergiNo { get; set; }
        public string VergiDairesi { get; set; }
        public double? EgitimTutar { get; set; }
        public double? ServisTutar { get; set; }
        public double? YayinTutar { get; set; }
        public double? ToplamTutar { get; set; }
        public double? PesinatTutari { get; set; }
        public int? TaksitAdet { get; set; }
        public DateTime? TaksitBaslangic { get; set; }
        public int? DersAdedi { get; set; }
        public double? DersBirimTutar { get; set; }

        public virtual VeliDetay Finansor { get; set; }
        public virtual Users GorusenPersonel { get; set; }
        public virtual Users KurumaGetirenPersonel { get; set; }
        public virtual OgrenciDetay OgrenciDetay { get; set; }
        public virtual Servis Servis { get; set; }
        public virtual Sezon Sezon { get; set; }
        public virtual SozlesmeTur SozlesmeTur { get; set; }
        public virtual Sube Sube { get; set; }
        public virtual ICollection<OgrenciSozlesmeKiyafet> OgrenciSozlesmeKiyafet { get; set; }
        public virtual ICollection<OgrenciSozlesmeOdemeTablosu> OgrenciSozlesmeOdemeTablosu { get; set; }
        public virtual ICollection<OgrenciSozlesmeYayin> OgrenciSozlesmeYayin { get; set; }
    }
}
