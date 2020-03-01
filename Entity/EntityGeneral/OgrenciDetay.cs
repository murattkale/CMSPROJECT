using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class OgrenciDetay : BaseModel
    {
        public OgrenciDetay()
        {
            VeliDetay = new HashSet<VeliDetay>();

            OgrenciSozlesme = new HashSet<OgrenciSozlesme>();
        }


        [Required()] public int OgrenciId { get; set; }
        public int? NeredenDuydunuzId { get; set; }
        [Required()] public bool AileMedeniDurum { get; set; }
        public string OzelHastalik { get; set; }
        public bool? SinifTekrar { get; set; }
        public int? OkulId { get; set; }


        public virtual Users Ogrenci { get; set; }
        public virtual NeredenDuydunuz NeredenDuydunuz { get; set; }
        public virtual Okul Okul { get; set; }
        public virtual ICollection<OgrenciSozlesme> OgrenciSozlesme { get; set; }

        public virtual ICollection<VeliDetay> VeliDetay { get; set; }
    }
}
