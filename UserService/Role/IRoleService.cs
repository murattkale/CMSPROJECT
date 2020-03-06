﻿using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface IRoleService : IGenericRepo<Role>
{
    RModel<Role> InsertOrUpdate(Role model);

}

