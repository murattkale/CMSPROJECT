﻿using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;


public interface IDersBransService : IGenericRepo<DersBrans>
{
    RModel<DersBrans> InsertOrUpdate(DersBrans model);

}

