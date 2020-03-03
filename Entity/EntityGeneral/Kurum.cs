using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class Kurum : BaseModel
    {
        public Kurum()
        {
            Brans = new HashSet<Brans>();
            ContentPage = new HashSet<ContentPage>();
            Kasa = new HashSet<Kasa>();
            Sezon = new HashSet<Sezon>();
            Sube = new HashSet<Sube>();
        }

       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }
        [Required()] public int CityId { get; set; }
        [Required()] public int TownId { get; set; }
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

        public virtual Town Town { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Brans> Brans { get; set; }
        public virtual ICollection<ContentPage> ContentPage { get; set; }
        public virtual ICollection<Kasa> Kasa { get; set; }
        public virtual ICollection<Sezon> Sezon { get; set; }
        public virtual ICollection<Sube> Sube { get; set; }
    }
}
