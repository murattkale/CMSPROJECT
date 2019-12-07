using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public partial class Banka:BaseModel
    {
        public Banka()
        {
            KasaTip = new HashSet<KasaTip>();
        }

        public string Ad { get; set; }
        public int? KasaTipId { get; set; }

        [InverseProperty("Banka")]
        public virtual ICollection<KasaTip> KasaTip { get; set; }
    }
}
