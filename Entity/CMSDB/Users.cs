using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity.CMSDB
{
    public partial class Users : BaseModel
    {
        public Users()
        {
            OgrenciSozlesmeGorusenPersonel = new HashSet<OgrenciSozlesme>();
            OgrenciSozlesmeKurumaGetirenPersonel = new HashSet<OgrenciSozlesme>();
            ServiceConfigAuth = new HashSet<ServiceConfigAuth>();
            SinifOgrenci = new HashSet<SinifOgrenci>();
            UserRoles = new HashSet<UserRoles>();
        }

       
        
        [Required]
        [DisplayName("TC NO")]
        public string Tc { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string Pass { get; set; }
        [Required]
        [DisplayName("Ad")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyad")]
        public string Surname { get; set; }
        public string Mail1 { get; set; }
        public string Mail2 { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Adress1 { get; set; }
        public string Adress2 { get; set; }
        [Required]
        [DisplayName("Doğum Tarihi")]
        public DateTime BirdhDay { get; set; }
        public string UserNo { get; set; }
        public string SexType { get; set; }
        [DisplayName("Şehir")]
        public int? CityId { get; set; }
        [DisplayName("İlçe")]
        public int? TownId { get; set; }
        public string ZipCode { get; set; }
        public string ProfilImage { get; set; }
        public string Description { get; set; }

        public City City { get; set; }
        public Town Town { get; set; }

        public virtual ICollection<OgrenciSozlesme> OgrenciSozlesmeGorusenPersonel { get; set; }
        public virtual ICollection<OgrenciSozlesme> OgrenciSozlesmeKurumaGetirenPersonel { get; set; }
        public virtual ICollection<ServiceConfigAuth> ServiceConfigAuth { get; set; }
        public virtual ICollection<SinifOgrenci> SinifOgrenci { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
