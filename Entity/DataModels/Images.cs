
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    public partial class Images : BaseModel
    {
       
        [Required]
        public string ImageUrl { get; set; }

        public string ImageAlt { get; set; } 

        public string ImageTitle { get; set; }

        public string ImageW { get; set; }

        public string ImageH { get; set; }

        public int? ContentId { get; set; }
        public bool? IsDefault { get; set; }

        public Content Content { get; set; }

    }

