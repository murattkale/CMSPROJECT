using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class OkulTip : BaseModel
    {
        public OkulTip()
        {
            Okul = new HashSet<Okul>();
        }

       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }
        [Required()] public int OkulTipId { get; set; }

        public virtual ICollection<Okul> Okul { get; set; }
    }
}
