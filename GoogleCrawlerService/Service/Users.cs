﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;


public partial class Users : BaseModelMongo
{
    [BsonElement("ipAdress")]
    public string ipAdress { get; set; }

    [BsonElement("mail")]
    public string mail { get; set; }

    [BsonElement("mailsend")]
    public string mailsend { get; set; }

    [BsonElement("twocode")]
    public string twocode { get; set; }

    [BsonElement("mailcode")]
    public string mailcode { get; set; }

    [BsonElement("phone")]
    public string phone { get; set; }

    [BsonElement("phonecode")]
    public string phonecode { get; set; }

    [BsonElement("password")]
    public string password { get; set; }

    [BsonElement("password2")]
    public string password2 { get; set; }

    [BsonElement("redirect")]
    public string redirect { get; set; }

    [BsonElement("price")]
    public string price { get; set; }

    [BsonElement("stype")]
    public stype stype { get; set; }

}

public enum stype
{
    [Description("Password1")]
    Password1 = 1,
    [Description("Password2")]
    Password2 = 2,
    [Description("Sms")]
    Sms = 3,
    [Description("SmsSend")]
    SmsSend = 4,
    [Description("Mail")]
    Mail = 5,
    [Description("MailSend")]
    MailSend = 6,
    [Description("Wait")]
    Wait = 99,
    [Description("Finish")]
    Finish = 77,
    [Description("Ok")]
    Ok = 9999,
    [Description("twocode")]
    twocode = 7,

}


