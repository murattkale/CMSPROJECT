using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface IUsersService : IGenericRepo<Users>
{
    RModel<Users> InsertOrUpdate(Users model);

}

