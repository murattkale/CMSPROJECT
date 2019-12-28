using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class ServiceConfigAuth : BaseModel
    {
       
        public int ServiceConfigId { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public int? PermissionId { get; set; }
        public bool? IsCreate { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsUpdate { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsList { get; set; }

        public virtual Permissions Permission { get; set; }
        public virtual Roles Role { get; set; }
        public virtual ServiceConfig ServiceConfig { get; set; }
        public virtual Users User { get; set; }
    }
}
