using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using Entity;
using System;

namespace Services
{
    public class BankaService : GenericRepo<Banka>, IBankaService
    {


        public BankaService(MuhasebeContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
        {
        }
        public RModel<Banka> InsertOrUpdate(Banka model)
        {
            RModel<Banka> res = new RModel<Banka>();
            res.ResultType = new ResultType();
            res.ResultType.MessageList = new List<string>();

            //Duplicate Control
            var modelControl = Where(null, o => o.Id != model.Id &&  o.Ad == model.Ad, false).Result.FirstOrDefault();
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


        public DTResult<Banka> GetPaging(
             Expression<Func<Banka, bool>> filter = null
            , bool AsNoTracking = true
            , DTParameters<Banka> param = null
            , bool IsDeletedShow = false
            , params Expression<Func<Banka, object>>[] includes
            )
        {
            var query = Where(null, filter, AsNoTracking, null, IsDeletedShow, includes).Result;

            //var query = result.Select(o => new Banka
            //{
            //    _Banka = o,
            //    _Fikir = o.Fikir,
            //    FikirAd = o.Fikir.Ad,
            //    EtiketAd = o.Kategori.Ad,
            //    ustKategoriAd1 = o.Kategori.ustKategori == null ? "" : o.Kategori.ustKategori.Ad,
            //    ustKategoriAd2 = o.Kategori.ustKategori.ustKategori == null ? "" : o.Kategori.ustKategori.ustKategori.Ad,
            //    ustKategoriAd3 = o.Kategori.ustKategori.ustKategori.ustKategori == null ? "" : o.Kategori.ustKategori.ustKategori.ustKategori.Ad,
            //    SLA1 = o.Departman.SLA1,
            //    SLA2 = o.Departman.SLA2,
            //    DepartmanAd = o.Departman.Ad,
            //});


            var GlobalSearchFilteredData = query.ToGlobalSearchInAllColumn<Banka>(param);
            var IndividualColSearchFilteredData = GlobalSearchFilteredData.ToIndividualColumnSearch(param);
            var SortedFilteredData = IndividualColSearchFilteredData.ToSorting(param);
            var SortedData = SortedFilteredData.ToPagination(param);

            var rSortedData = SortedData.ToList();

            int Count = query.Count();

            var resultData = new DTResult<Banka>
            {
                draw = param.Draw,
                data = rSortedData,
                recordsFiltered = Count,
                recordsTotal = Count
            };

            return resultData;

        }






    }
}
