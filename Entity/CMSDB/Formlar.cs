using System;
using System.Collections.Generic;

namespace Entity.CMSDB
{
    public partial class Formlar : BaseModel
    {

        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public int? SubeId { get; set; }
        public int? SehirId { get; set; }
        public int? IlceId { get; set; }
        public string Icerik { get; set; }

        public int? FormType { get; set; }


    }
}
