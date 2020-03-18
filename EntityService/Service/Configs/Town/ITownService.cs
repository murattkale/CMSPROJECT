﻿using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface ITownService : IGenericRepo<Town>
{
    RModel<Town> InsertOrUpdate(Town model);

}

