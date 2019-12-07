using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MenusModel : BaseModel
{
    public int? MenuType { get; set; }

    public string Name { get; set; }

    public string Title { get; set; }

    public string Link { get; set; }

    public int? ParentId { get; set; }

    public string Description { get; set; }

    public string Keywords { get; set; }
    public List<MenusModel> subMenus = new List<MenusModel>();
}

