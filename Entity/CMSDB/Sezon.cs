using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Sezon : BaseModel
    {
        public string Ad { get; set; }
        public int KurumId { get; set; }

        public virtual Kurum Kurum { get; set; }
    }
}
