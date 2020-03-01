using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Entity.ObjectModels
{
    public class MailModel
    {
        public string Konu { get; set; }
        public string KimdenMail { get; set; }
        public string KimdenText { get; set; }

        [AllowHtml]
        public string Icerik { get; set; }
        public string[] Alicilar { get; set; }
        public string[] cc { get; set; }

    }

}
