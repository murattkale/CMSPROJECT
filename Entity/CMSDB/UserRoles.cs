using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class UserRoles : BaseModel
    {
       
        
       
       
        public int? RoleId { get; set; }
        public int? UserId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
