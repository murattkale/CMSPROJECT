using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class UserRoles : BaseModel
    {
       
        
       
       
        public int? RoleId { get; set; }
        public int? UserId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
