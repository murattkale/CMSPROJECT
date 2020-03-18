using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


    public partial class Ders : BaseModel
    {
        public Ders()
        {
            DersBrans = new HashSet<DersBrans>();
            Yayin = new HashSet<Yayin>();
        }

       
        
        
        
       
        
       
       
        [Required()] public string Ad  { get; set; }
        [DisplayName("Ders Grup")]
        [Required()] public int DersGrupId { get; set; }

        public virtual DersGrup DersGrup { get; set; }
        public virtual ICollection<DersBrans> DersBrans { get; set; }
        public virtual ICollection<Yayin> Yayin { get; set; }
    }

