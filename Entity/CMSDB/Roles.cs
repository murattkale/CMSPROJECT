using System;
using System.Collections.Generic;

namespace Entity.CMSDB
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
