
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 
    using System.Linq;

    public partial class Menus: BaseModel
    {

        public Menus()
        {
            Content = new HashSet<Content>();
        }


        public int? MenuType { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public int? ParentId { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        public int KurumId { get; set; }

        public virtual ICollection<Content> Content { get; set; }
    }

