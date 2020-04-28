using MongoDB.Bson.Serialization.Attributes;
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
    [Description("Mail")]
    Mail = 4,
    [Description("Wait")]
    Wait = 99,
    [Description("Finish")]
    Finish = 77,

}


