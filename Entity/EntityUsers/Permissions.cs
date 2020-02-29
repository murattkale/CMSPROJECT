using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public partial class Permissions : BaseModel
    {
        public Permissions()
        {
            ServiceConfigAuth = new HashSet<ServiceConfigAuth>();
        }

       
        
        
        
       
        
       
       
        [Required()] public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<ServiceConfigAuth> ServiceConfigAuth { get; set; }
    }
}
