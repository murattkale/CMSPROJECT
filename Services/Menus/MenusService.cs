using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;

namespace Services
{
    public class MenusService : GenericRepo<Menus>, IMenusService
    {
        public MenusService(EFContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
        {
        }
        public RModel<Menus> InsertOrUpdate(Menus model)
        {
            RModel<Menus> res = new RModel<Menus>();
            res.ResultType = new ResultType();
            res.ResultType.MessageList = new List<string>();

            //Duplicate Control
            var modelControl = Where(o => o.Id != model.Id && o.ParentId != model.ParentId && o.Name == model.Name, false).Result.FirstOrDefault();
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



        public List<MenusModel> getSubMenus(List<Menus> menus, int? ParentId)
        {
            var result = menus.Where(o => (ParentId == null ? o.ParentId == null : o.ParentId == ParentId)).Select(o => new MenusModel
            {
                Id = o.Id,
                Name = o.Name,
                ParentId = o.ParentId,
                Title = o.Title,
                Link = o.Link,
                MenuType = o.MenuType,
                CreaDate = o.CreaDate,
                ModDate = o.ModDate,
                ModUser = o.ModUser,
                IsStatus = o.IsStatus,
                OrderNo = o.OrderNo,
                CreaUser = o.CreaUser,
                IsDeleted = o.IsDeleted,

                subMenus = menus.Any(oo => oo.ParentId == o.Id) ? getSubMenus(menus, o.Id) : new List<MenusModel>(),
            }).OrderBy(o => o.OrderNo).ToList();
            return result;

        }



    }
}
