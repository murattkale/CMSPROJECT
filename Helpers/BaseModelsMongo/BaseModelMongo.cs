using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BaseModelMongo : IBaseModelMongo
{

    [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    [BsonElement("Id", Order = 0)]
    [Required()]
    public string Id { get; } = ObjectId.GenerateNewId().ToString();

    [BsonRepresentation(BsonType.DateTime)]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    [BsonElement("CreaDate", Order = 1)]
    [Required()]
    public DateTime CreaDate { get; } = DateTime.Now;

    [BsonElement("CreaUser", Order = 2)]
    [Required()]
    public int CreaUser { get; set; }

    [BsonElement("ModUser",Order =3)]
    public int? ModUser { get; set; }

    [BsonElement("ModDate")]
    public DateTime? ModDate { get; set; }

    [BsonElement("OrderNo")]
    public int? OrderNo { get; set; }

    [BsonElement("IsDeleted")]
    public DateTime? IsDeleted { get; set; }

    [BsonElement("IsStatus")]
    public int? IsStatus { get; set; }

    [BsonElement("LoginCount")]
    public int? LoginCount { get; set; }



}

