using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Sube : BaseModel
    {
        public Sube()
        {
            ContentPage = new HashSet<ContentPage>();
            Derslik = new HashSet<Derslik>();
            Kasa = new HashSet<Kasa>();
            OgrenciSozlesme = new HashSet<OgrenciSozlesme>();
            Seans = new HashSet<Seans>();
            Sinif = new HashSet<Sinif>();
            Sozlesme = new HashSet<Sozlesme>();
        }

       
        
        
        
       
        
       
        public int? IsStatus { get; set; }
        public int KurumId { get; set; }
        public string Ad { get; set; }
        public int? SehirId { get; set; }
        public int? IlceId { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Cep { get; set; }
        public string Mail { get; set; }
        public string Logo { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Youtube { get; set; }
        public string Linkedin { get; set; }
        public string Pinterest { get; set; }
        public string Twitter { get; set; }
        public string GoogleAnalytic { get; set; }
        public string Maps { get; set; }
        public string TicariUnvan { get; set; }
        public string VergiNo { get; set; }
        public string VergiDairesi { get; set; }
        public int? SozlesmeTaksitLimit { get; set; }

        public virtual Town Ilce { get; set; }
        public virtual Kurum Kurum { get; set; }
        public virtual City Sehir { get; set; }
        public virtual ICollection<ContentPage> ContentPage { get; set; }
        public virtual ICollection<Derslik> Derslik { get; set; }
        public virtual ICollection<Kasa> Kasa { get; set; }
        public virtual ICollection<OgrenciSozlesme> OgrenciSozlesme { get; set; }
        public virtual ICollection<Seans> Seans { get; set; }
        public virtual ICollection<Sinif> Sinif { get; set; }
        public virtual ICollection<Sozlesme> Sozlesme { get; set; }
    }
}
