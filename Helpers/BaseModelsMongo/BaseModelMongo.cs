using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BaseModelMongo : IBaseModelMongo
{

    public BaseModelMongo()
    {
        Id = Guid.NewGuid();
    }

    public BaseModelMongo(Guid id)
    {
        Id = id;
    }

    [BsonElement("Id")]
    [BsonId]
    [Required()] public Guid Id { get; set; }

    [BsonElement("CreaDate")]
    [Required()]  public DateTime CreaDate { get; set; }
    [BsonElement("CreaUser")]
    [Required()] public int CreaUser { get; set; }
    [BsonElement("ModUser")]
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

