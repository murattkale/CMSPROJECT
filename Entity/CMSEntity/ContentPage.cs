using Entity.CMSDB;
using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class ContentPage : BaseModel
    {
        public ContentPage()
        {
            Documents = new HashSet<Documents>();
        }
        public int? KurumId { get; set; }
        public int? SubeId { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public int ContentPageType { get; set; }
        public bool? IsHeaderMenu { get; set; }
        public bool? IsFooterMenu { get; set; }
        public bool? IsSideMenu { get; set; }
        public bool? IsHamburgerMenu { get; set; }
        public string Content { get; set; }
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
}
