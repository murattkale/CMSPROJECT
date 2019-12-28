using System;
using System.Collections.Generic;

namespace Entity.MuhasebeContext
{
    public partial class Users : BaseModel
    {
        public Users()
        {
            ServiceConfigAuth = new HashSet<ServiceConfigAuth>();
            UserRoles = new HashSet<UserRoles>();
        }

        public int Id { get; set; }
        public int? CreaUser { get; set; }
        public DateTime? CreaDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public int? OrderNo { get; set; }
        public DateTime? IsDeleted { get; set; }
        public int? IsStatus { get; set; }
        public string Tc { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<ServiceConfigAuth> ServiceConfigAuth { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
