﻿using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;



    public interface IKasaService : IGenericRepo<Kasa>
    {
        RModel<Kasa> InsertOrUpdate(Kasa model);
    }
