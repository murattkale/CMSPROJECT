﻿using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;


using System;



public interface ICityService : IGenericRepo<City>
{
    RModel<City> InsertOrUpdate(City model);

}

