using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class Role : BaseModel
    {
        public Role()
        {
            ParentRoles = new HashSet<Role>();
            Permissions = new HashSet<Permission>();
            ServiceConfigAuth = new HashSet<ServiceConfigAuth>();
            UserRoles = new HashSet<UserRole>();
        }

       
        
        
        
       
        
       
       
        public int? RoleParentId { get; set; }
        public string Name { get; set; }
        public int? ServiceConfigId { get; set; }

        public virtual Role RoleParent { get; set; }
        public virtual ServiceConfig ServiceConfig { get; set; }
        public virtual ICollection<Role> ParentRoles { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<ServiceConfigAuth> ServiceConfigAuth { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
