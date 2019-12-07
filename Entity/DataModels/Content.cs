
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Table("Content")]
    public partial class Content : BaseModel
    {

        public Content()
        {
            Images = new HashSet<Images>();
        }
        public string ContentName { get; set; }

        public string ContentTitle { get; set; }


        public int ContentType { get; set; }

        public int? MenuId { get; set; }
        public int? SubeId { get; set; }
        public int? KurumId { get; set; }

        [Column(TypeName = "text")]
        public string ContentText1 { get; set; }

        [Column(TypeName = "text")]
        public string ContentText2 { get; set; }

        [Column(TypeName = "text")]
        public string ContentText3 { get; set; }

        public string ButtonText1 { get; set; }
        public string ButtonText1Link { get; set; }
        public string ButtonText2 { get; set; }
        public string ButtonText2Link { get; set; }


        public string Link { get; set; }

        public virtual Menus Menus { get; set; }
        public virtual ICollection<Images> Images { get; set; }

    }

