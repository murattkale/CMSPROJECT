using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class Okul : BaseModel
    {
        public Okul()
        {
            OgrenciDetay = new HashSet<OgrenciDetay>();
        }

       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }
        [Required()] public int OkulTipId { get; set; }

        public virtual ICollection<OgrenciDetay> OgrenciDetay { get; set; }
        public virtual OkulTip OkulTip { get; set; }
    }
}
