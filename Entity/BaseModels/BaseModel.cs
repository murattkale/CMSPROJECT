using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BaseModel : IBaseModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public DateTime CreaDate { get; set; }
    public int CreaUser { get; set; }
    public int? ModUser { get; set; }
    public DateTime? ModDate { get; set; }
    public int? OrderNo { get; set; }
    public DateTime? IsDeleted { get; set; }

    public int? IsStatus { get; set; }




}

