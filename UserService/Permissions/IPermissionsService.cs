using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;
using Entity.CMSDB; using Entity.ContextModel;


public interface IPermissionsService : IGenericRepo<Permissions>
{
    RModel<Permissions> InsertOrUpdate(Permissions model);

}

