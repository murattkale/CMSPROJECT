using System;
using System.Collections.Generic;

namespace Entity.MuhasebeContext
{
    public partial class ServiceConfigAuth : BaseModel
    {
        public int Id { get; set; }
        public int? CreaUser { get; set; }
        public DateTime? CreaDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public int? OrderNo { get; set; }
        public DateTime? IsDeleted { get; set; }
        public int? IsStatus { get; set; }
        public int? ServiceConfigId { get; set; }
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
