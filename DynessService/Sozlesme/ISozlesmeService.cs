using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;


public interface ISozlesmeService : IGenericRepo<Sozlesme>
{
    RModel<Sozlesme> InsertOrUpdate(Sozlesme model);

}

