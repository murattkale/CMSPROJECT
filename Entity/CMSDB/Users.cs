using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Users : BaseModel
    {
        public Users()
        {
            ServiceConfigAuth = new HashSet<ServiceConfigAuth>();
            SinifOgrenci = new HashSet<SinifOgrenci>();
            UserRoles = new HashSet<UserRoles>();
        }

        public int Id { get; set; }
        public int CreaUser { get; set; }
        public DateTime CreaDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public int? OrderNo { get; set; }
        public DateTime? IsDeleted { get; set; }
        public int? IsStatus { get; set; }
        public string Tc { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail1 { get; set; }
        public string Mail2 { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Adress1 { get; set; }
        public string Adress2 { get; set; }
        public DateTime BirdhDay { get; set; }
        public string UserNo { get; set; }
        public string SexType { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? TownId { get; set; }
        public string ZipCode { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ServiceConfigAuth> ServiceConfigAuth { get; set; }
        public virtual ICollection<SinifOgrenci> SinifOgrenci { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
