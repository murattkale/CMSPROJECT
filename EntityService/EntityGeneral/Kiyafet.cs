using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;


    public partial class Kiyafet : BaseModel
    {
        public Kiyafet()
        {
            OgrenciSozlesmeKiyafet = new HashSet<OgrenciSozlesmeKiyafet>();
        }

       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }
        [Required()] public int KiyafetTurId { get; set; }
        [Required()] public int Beden { get; set; }
        [Required()] public int Stok { get; set; }

        public virtual KiyafetTur KiyafetTur { get; set; }
        public virtual ICollection<OgrenciSozlesmeKiyafet> OgrenciSozlesmeKiyafet { get; set; }
    }

