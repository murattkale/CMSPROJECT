using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using System;
using Entity;

public interface IUserRoleService : IGenericRepo<UserRole>
{
    RModel<UserRole> InsertOrUpdate(UserRole model);

}

