using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface IHesapTipService : IGenericRepo<HesapTip>
{
    RModel<HesapTip> InsertOrUpdate(HesapTip model);

}


