using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;


    public partial class NeredenDuydunuz : BaseModel
    {
        public NeredenDuydunuz()
        {
            OgrenciDetay = new HashSet<OgrenciDetay>();
        }

       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }

        public virtual ICollection<OgrenciDetay> OgrenciDetay { get; set; }
    }

