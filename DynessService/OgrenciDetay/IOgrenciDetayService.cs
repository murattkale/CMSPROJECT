using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface IOgrenciDetayService : IGenericRepo<OgrenciDetay>
{
    RModel<OgrenciDetay> InsertOrUpdate(OgrenciDetay model);

}

