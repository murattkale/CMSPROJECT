using Entity;
using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


    public partial class ContentPage : BaseModel
    {
        public ContentPage()
        {
            Documents = new HashSet<Documents>();
        }

        [DisplayName("Kurum")]
        public int? KurumId { get; set; }
        [DisplayName("Sube")]
        public int? SubeId { get; set; }
        [DisplayName("Üst Kategori")]
        public int? ParentId { get; set; }

        [DisplayName("Başlık")]
        public string Name { get; set; }
        [DisplayName("Tip")]
        [Required()] public int ContentPageType { get; set; }
        [DisplayName("Üst Menü")]
        public bool? IsHeaderMenu { get; set; }
        [DisplayName("Alt Menü")]
        public bool? IsFooterMenu { get; set; }
        [DisplayName("Yan Menü")]
        public bool? IsSideMenu { get; set; }
        [DisplayName("Hamburger Menü")]
        public bool? IsHamburgerMenu { get; set; }
        [DisplayName("İçerik")]
        public string ContentData { get; set; }
        [DisplayName("Kısa İçerik")]
        public string ContentShort { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string BannerText { get; set; }
        public string BannerImage { get; set; }
        public string DefaultImage { get; set; }
        public string Link { get; set; }
        public string ButtonText1 { get; set; }
        public string ButtonText1Link { get; set; }
        public string ButtonText2 { get; set; }
        public string ButtonText2Link { get; set; }

        public virtual Kurum Kurum { get; set; }
        public virtual Sube Sube { get; set; }

        public virtual ICollection<Documents> Documents { get; set; }
    }

