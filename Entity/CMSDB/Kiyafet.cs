using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Kiyafet : BaseModel
    {
        public Kiyafet()
        {
            OgrenciSozlesmeKiyafet = new HashSet<OgrenciSozlesmeKiyafet>();
        }

       
        
        
        
       
        
       
       
        public string Ad { get; set; }
        public int KiyafetTurId { get; set; }
        public int Beden { get; set; }
        public int Stok { get; set; }

        public virtual KiyafetTur KiyafetTur { get; set; }
        public virtual ICollection<OgrenciSozlesmeKiyafet> OgrenciSozlesmeKiyafet { get; set; }
    }
}
