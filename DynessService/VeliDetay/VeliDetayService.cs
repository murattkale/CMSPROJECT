﻿using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;
using Entity;



public class VeliDetayService : GenericRepo<CMSDBContext,VeliDetay>, IVeliDetayService
{


    public VeliDetayService(CMSDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
    {
    }
    public RModel<VeliDetay> InsertOrUpdate(VeliDetay model)
    {
        RModel<VeliDetay> res = new RModel<VeliDetay>();
        res.ResultType = new ResultType();
        res.ResultType.MessageList = new List<string>();

        ////Duplicate Control
        //var modelControl = Where(o => o.Id != model.Id &&  o.Ad == model.Ad, false).Result.FirstOrDefault();
        //if (modelControl != null)
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
            SaveChanges();
            res.ResultType.RType = RType.OK;
        }
        return res;
    }






}

