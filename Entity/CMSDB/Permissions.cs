using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Permissions : BaseModel
    {
        public Permissions()
        {
            ServiceConfigAuth = new HashSet<ServiceConfigAuth>();
        }

       
        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<ServiceConfigAuth> ServiceConfigAuth { get; set; }
    }
}
