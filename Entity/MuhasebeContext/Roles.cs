using System;
using System.Collections.Generic;

namespace Entity.MuhasebeContext
{
    public partial class Roles : BaseModel
    {
        public Roles()
        {
            InverseParent = new HashSet<Roles>();
            Permissions = new HashSet<Permissions>();
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
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public int? StartPageId { get; set; }

        public virtual Roles Parent { get; set; }
        public virtual ServiceConfig StartPage { get; set; }
        public virtual ICollection<Roles> InverseParent { get; set; }
        public virtual ICollection<Permissions> Permissions { get; set; }
        public virtual ICollection<ServiceConfigAuth> ServiceConfigAuth { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
