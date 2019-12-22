﻿using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using Entity.MuhasebeContext;

namespace Services
{
    public class KasaService : GenericRepo<Kasa>, IKasaService
    {
        public KasaService(EFContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
        {
        }
        public RModel<Kasa> InsertOrUpdate(Kasa model)
        {
            RModel<Kasa> res = new RModel<Kasa>();
            res.ResultType = new ResultType();
            res.ResultType.MessageList = new List<string>();

            //Duplicate Control
            var modelControl = Where(o => o.Id != model.Id && o.UstKasaId != model.UstKasaId && o.BankaId == model.BankaId, false).Result.FirstOrDefault();
            if (modelControl != null)
            {
                res.ResultType.RType = RType.Warning;
                res.ResultType.MessageList.Add("Duplicate");
                res.ResultRow = modelControl;
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
                SaveChanges();
                res.ResultType.RType = RType.OK;
            }
            return res;
        }







    }
}
