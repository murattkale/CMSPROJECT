
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    [Table("User")]
    public partial class User : BaseModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Pass { get; set; }

        public int KurumId { get; set; }


    }

