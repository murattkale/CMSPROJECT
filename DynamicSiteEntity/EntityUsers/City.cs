using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;


    public partial class City : BaseModel
    {
        public City()
        {
            Town = new HashSet<Town>();
        }

       
       
        public string CityName { get; set; }

        public virtual ICollection<Town> Town { get; set; }
    }

