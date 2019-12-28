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

        public int Id { get; set; }
        public int CreaUser { get; set; }
        public DateTime CreaDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public int? OrderNo { get; set; }
        public DateTime? IsDeleted { get; set; }
        public int? IsStatus { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<ServiceConfigAuth> ServiceConfigAuth { get; set; }
    }
}
