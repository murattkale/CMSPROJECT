using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class Town : BaseModel
    {
        public Town()
        {
            Kurum = new HashSet<Kurum>();
            Sube = new HashSet<Sube>();
        }









        [Required()] public int CityId { get; set; }
        public string TownName { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Kurum> Kurum { get; set; }
        public virtual ICollection<Sube> Sube { get; set; }
    }
}
