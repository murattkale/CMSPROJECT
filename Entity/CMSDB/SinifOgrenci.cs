using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class SinifOgrenci : BaseModel
    {
        public int Id { get; set; }
        public int CreaUser { get; set; }
        public DateTime CreaDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public int? OrderNo { get; set; }
        public DateTime? IsDeleted { get; set; }
        public int? IsStatus { get; set; }
        public int SinifId { get; set; }
        public int OgrenciId { get; set; }

        public virtual Users Ogrenci { get; set; }
        public virtual Sinif Sinif { get; set; }
    }
}
