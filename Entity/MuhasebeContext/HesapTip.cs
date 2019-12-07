using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public partial class HesapTip:BaseModel
    {
        public HesapTip()
        {
            Hesap = new HashSet<Hesap>();
        }

        public string Ad { get; set; }

        [InverseProperty("HesapTip")]
        public virtual ICollection<Hesap> Hesap { get; set; }
    }
}
