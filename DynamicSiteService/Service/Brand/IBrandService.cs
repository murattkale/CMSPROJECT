using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;


using System;



public interface IBrandService : IGenericRepo<Brand>
{
    RModel<Brand> InsertOrUpdate(Brand model);

}

