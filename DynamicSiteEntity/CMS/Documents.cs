using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;


    public partial class Documents : BaseModel
    {
        public Documents()
        {

        }


        public string Types { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public string Guid { get; set; }

        public string Alt { get; set; }

        public string Title { get; set; }

        public string data_class { get; set; }

        [Required()] public int dataid { get; set; }

        public ContentPage ContentPage { get; set; }

    }

