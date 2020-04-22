using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public partial class Users : BaseModelMongo
{

    [BsonElement("identifier")]
    public string identifier { get; set; }

    [BsonElement("password")]
    public string password { get; set; }

    [BsonElement("redirect")]
    public string redirect { get; set; }

}


