using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

public class MailModel
{
    public string Konu { get; set; }
    public string KimdenMail { get; set; }
    public string KimdenText { get; set; }


    [DataType(DataType.MultilineText)]
    public string Icerik { get; set; }
    public string[] Alicilar { get; set; }
    public string[] cc { get; set; }

}


