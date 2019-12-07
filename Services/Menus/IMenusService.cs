using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;

namespace Services
{
    public interface IMenusService : IGenericRepo<Menus>
    {
        RModel<Menus> InsertOrUpdate(Menus model);
        List<MenusModel> getSubMenus(List<Menus> menus, int? ParentId);
    }
}
