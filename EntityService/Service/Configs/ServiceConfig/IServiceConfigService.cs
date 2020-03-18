using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface IServiceConfigService : IGenericRepo<ServiceConfig>
{
    RModel<ServiceConfig> InsertOrUpdate(ServiceConfig model);

}

