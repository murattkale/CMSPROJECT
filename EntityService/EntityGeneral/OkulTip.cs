using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

    public partial class OkulTip : BaseModel
    {
        public OkulTip()
        {
            Okul = new HashSet<Okul>();
        }

       
       
        [Required()] public string Ad  { get; set; }

        public virtual ICollection<Okul> Okul { get; set; }
    }

