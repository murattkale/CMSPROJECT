using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class UserRoles : BaseModel
    {
        public int Id { get; set; }
        public int? CreaUser { get; set; }
        public DateTime? CreaDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public int? OrderNo { get; set; }
        public DateTime? IsDeleted { get; set; }
        public int? IsStatus { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
