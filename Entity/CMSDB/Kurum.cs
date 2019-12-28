using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Kurum : BaseModel
    {
        public Kurum()
        {
            Brans = new HashSet<Brans>();
            Sezon = new HashSet<Sezon>();
            Sube = new HashSet<Sube>();
        }

       
        public string Ad { get; set; }
        public int SehirId { get; set; }
        public int IlceId { get; set; }
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

        public virtual Town Ilce { get; set; }
        public virtual City Sehir { get; set; }
        public virtual ICollection<Brans> Brans { get; set; }
        public virtual ICollection<Sezon> Sezon { get; set; }
        public virtual ICollection<Sube> Sube { get; set; }
    }
}
