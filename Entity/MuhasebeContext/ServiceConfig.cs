using System;
using System.Collections.Generic;

namespace Entity.MuhasebeContext
{
    public partial class ServiceConfig : BaseModel
    {
        public ServiceConfig()
        {
            InverseParent = new HashSet<ServiceConfig>();
            Roles = new HashSet<Roles>();
            ServiceConfigAuth = new HashSet<ServiceConfigAuth>();
        }

        public int Id { get; set; }
        public int? CreaUser { get; set; }
        public DateTime? CreaDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public int? OrderNo { get; set; }
        public DateTime? IsDeleted { get; set; }
        public int? IsStatus { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ServiceName { get; set; }
        public string Url { get; set; }
        public string UrlTarget { get; set; }

        public virtual ServiceConfig Parent { get; set; }
        public virtual ICollection<ServiceConfig> InverseParent { get; set; }
        public virtual ICollection<Roles> Roles { get; set; }
        public virtual ICollection<ServiceConfigAuth> ServiceConfigAuth { get; set; }
    }
}
