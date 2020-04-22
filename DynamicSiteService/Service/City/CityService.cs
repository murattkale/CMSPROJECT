using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;


using System;


    public class CityService : GenericRepo<CMSDBContext,City>, ICityService
    {
        public CityService(CMSDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
        {
        }
        public RModel<City> InsertOrUpdate(City model)
        {
            RModel<City> res = new RModel<City>();
            res.ResultType = new ResultType();
            res.ResultType.MessageList = new List<string>();

            //Duplicate Control
            var modelControl = Where(o => o.Id != model.Id &&  o.CityName == model.CityName, false).Result.FirstOrDefault();
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

