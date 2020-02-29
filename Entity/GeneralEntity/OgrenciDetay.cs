using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class OgrenciDetay : BaseModel
    {
        public OgrenciDetay()
        {
            OgrenciSozlesme = new HashSet<OgrenciSozlesme>();
        }

       
        
        
        
       
        
       
       
        public int? NeredenDuydunuzId { get; set; }
        public bool AileMedeniDurum { get; set; }
        public string OzelHastalik { get; set; }
        public bool? SinifTekrar { get; set; }
        public int? OkullarId { get; set; }

        public virtual NeredenDuydunuz NeredenDuydunuz { get; set; }
        public virtual Okullar Okullar { get; set; }
        public virtual ICollection<OgrenciSozlesme> OgrenciSozlesme { get; set; }
    }
}
