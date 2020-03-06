using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface IHesapService : IGenericRepo<Hesap>
{
    RModel<Hesap> InsertOrUpdate(Hesap model);

}


