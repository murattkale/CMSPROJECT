using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Roles : BaseModel
    {
        public Roles()
        {
            ParentRoles = new HashSet<Roles>();
            Permissions = new HashSet<Permissions>();
            ServiceConfigAuth = new HashSet<ServiceConfigAuth>();
            UserRoles = new HashSet<UserRoles>();
        }

       
        
        
        
       
        
       
       
        public int? RoleId { get; set; }
        public string Name { get; set; }
        public int? ServiceConfigId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ServiceConfig ServiceConfig { get; set; }
        public virtual ICollection<Roles> ParentRoles { get; set; }
        public virtual ICollection<Permissions> Permissions { get; set; }
        public virtual ICollection<ServiceConfigAuth> ServiceConfigAuth { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
