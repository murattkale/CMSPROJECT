using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using System;
using Entity; using Entity.ContextModel;


public interface IUserRoleService : IGenericRepo<UserRole>
{
    RModel<UserRole> InsertOrUpdate(UserRole model);

}

