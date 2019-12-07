using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public partial class ParaBirimi:BaseModel
    {
        public ParaBirimi()
        {
            Kasa = new HashSet<Kasa>();
        }

        public string Ad { get; set; }
        public string Kod { get; set; }

        [InverseProperty("ParaBirim")]
        public virtual ICollection<Kasa> Kasa { get; set; }
    }
}
