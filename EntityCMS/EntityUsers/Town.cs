using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;


    public partial class Town : BaseModel
    {
        public Town()
        {
        }









        [Required()] public int CityId { get; set; }
        public string TownName { get; set; }

        public virtual City City { get; set; }
    }

