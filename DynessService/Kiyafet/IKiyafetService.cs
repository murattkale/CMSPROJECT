﻿using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;


public interface IKiyafetService : IGenericRepo<Kiyafet>
{
    RModel<Kiyafet> InsertOrUpdate(Kiyafet model);

}

