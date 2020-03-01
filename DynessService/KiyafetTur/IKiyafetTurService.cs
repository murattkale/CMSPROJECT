using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;


public interface IKiyafetTurService : IGenericRepo<KiyafetTur>
{
    RModel<KiyafetTur> InsertOrUpdate(KiyafetTur model);

}

