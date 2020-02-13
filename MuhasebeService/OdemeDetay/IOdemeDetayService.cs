using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;
using Entity.CMSDB; using Entity.ContextModel;


public interface IOdemeDetayService : IGenericRepo<OdemeDetay>
{
    RModel<OdemeDetay> InsertOrUpdate(OdemeDetay model);

}


