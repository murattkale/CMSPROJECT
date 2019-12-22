using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;
using Entity.MuhasebeContext;


public interface IHesapService : IGenericRepo<Hesap>
{
    RModel<Hesap> InsertOrUpdate(Hesap model);

}


