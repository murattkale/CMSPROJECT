using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface ISinifOgrenciService : IGenericRepo<SinifOgrenci>
{
    RModel<SinifOgrenci> InsertOrUpdate(SinifOgrenci model);

}

