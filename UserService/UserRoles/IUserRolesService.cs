using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;
using Entity; using Entity.ContextModel;


public interface IUserRolesService : IGenericRepo<UserRoles>
{
    RModel<UserRoles> InsertOrUpdate(UserRoles model);

}

