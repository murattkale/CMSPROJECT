using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;
using Entity.MuhasebeContext;


public class HesapService : GenericRepo<Hesap>, IHesapService
{


    public HesapService(MUHASEBEDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
    {
    }
    public RModel<Hesap> InsertOrUpdate(Hesap model)
    {
        RModel<Hesap> res = new RModel<Hesap>();
        res.ResultType = new ResultType();
        res.ResultType.MessageList = new List<string>();

        //Duplicate Control
        //var modelControl = Where(o => o.Id != model.Id && o.HesapTipId == model.HesapTipId && o., false).Result.FirstOrDefault();
        if (false)
        {
            //res.ResultType.RType = RType.Warning;
            //res.ResultType.MessageList.Add("Duplicate");
            //res.ResultRow = modelControl;
        }
        else
        {
            if (model.Id > 0)
            {
                res.ResultRow = Update(model);
            }
            else
            {
                res.ResultRow = Add(model);
            }
            var rs = SaveChanges();
            res.ResultType.RType = RType.OK;
        }
        return res;
    }






}

