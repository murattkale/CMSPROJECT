using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface IOdemeDetayService : IGenericRepo<OdemeDetay>
{
    RModel<OdemeDetay> InsertOrUpdate(OdemeDetay model);

}


