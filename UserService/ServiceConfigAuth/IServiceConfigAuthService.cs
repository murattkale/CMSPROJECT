using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;
using Entity.MuhasebeContext;


public interface IServiceConfigAuthService : IGenericRepo<ServiceConfigAuth>
{
    RModel<ServiceConfigAuth> InsertOrUpdate(ServiceConfigAuth model);

}

