﻿using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;
 


public class NeredenDuydunuzService : GenericRepo<CMSDBContext,NeredenDuydunuz>, INeredenDuydunuzService
    {


        public NeredenDuydunuzService(CMSDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
        {
        }
        public RModel<NeredenDuydunuz> InsertOrUpdate(NeredenDuydunuz model)
        {
            RModel<NeredenDuydunuz> res = new RModel<NeredenDuydunuz>();
            res.ResultType = new ResultType();
            res.ResultType.MessageList = new List<string>();

            //Duplicate Control
            var modelControl = Where(o => o.Id != model.Id &&  o.Ad == model.Ad, false).Result.FirstOrDefault();
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

