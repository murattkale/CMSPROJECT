using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IBaseModelMongo
{

    string Id { get; }
    DateTime CreaDate { get; }
    int CreaUser { get; set; }
    int? ModUser { get; set; }
    DateTime? ModDate { get; set; }
    int? OrderNo { get; set; }
    DateTime? IsDeleted { get; set; }

    int? IsStatus { get; set; }

    int? LoginCount { get; set; }
}

