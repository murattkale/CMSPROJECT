using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class UsersModel
{

    public UsersModel()
    {
        Id = Guid.NewGuid();
    }

    public UsersModel(Guid? id)
    {
        Id = id;
    }

    public Guid? Id { get; set; }

    [BsonElement("identifier")]
    public string identifier { get; set; }

    [BsonElement("password")]
    public string password { get; set; }

    [BsonElement("IsActive")]
    public bool? IsActive { get; set; }

    [BsonElement("redirect")]
    public string redirect { get; set; }

}


