﻿using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface IVeliDetayService : IGenericRepo<VeliDetay>
{
    RModel<VeliDetay> InsertOrUpdate(VeliDetay model);

}

