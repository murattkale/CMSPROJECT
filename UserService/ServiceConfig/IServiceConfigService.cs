﻿using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;
using Entity.CMSDB;


public interface IServiceConfigService : IGenericRepo<ServiceConfig>
{
    RModel<ServiceConfig> InsertOrUpdate(ServiceConfig model);

}
