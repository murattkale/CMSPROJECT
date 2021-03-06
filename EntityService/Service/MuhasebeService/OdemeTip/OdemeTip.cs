﻿using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;


    public partial class OdemeTip : BaseModel
    {
        public OdemeTip()
        {
            Hesap = new HashSet<Hesap>();
        }

       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }
        public int? BankaId { get; set; }

        public virtual Banka Banka { get; set; }
        public virtual ICollection<Hesap> Hesap { get; set; }
    }

