using System;
using System.Collections.Generic; using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Linq.Dynamic;
using System.Globalization;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

public static class ServerSideProcessor
{
    public static IQueryable<T> ToGlobalSearchInAllColumn<T>(this IQueryable<T> table, DTParameters<T> Param)
    {
        var GlobalSearchText = Param.Search != null && Param.Search.Value != null ? Param.Search.Value : string.Empty;
        var pagingSearchParam = Param.pagingSearchParam;
        var pagingSearchParamSplit = pagingSearchParam.Split(',').ToList();
        if (!string.IsNullOrEmpty(GlobalSearchText))
        {
            // return BooksData.Where(x => x.BookId.ToString() == GlobalSearchText || x.BookName.Contains(GlobalSearchText) || x.Category.Contains(GlobalSearchText));
            StringBuilder WhereQueryMaker = new StringBuilder();
            Type types = typeof(T);
            DateTime CreatedOn;
            foreach (PropertyInfo prop in types.GetProperties())
            {
                if (pagingSearchParam != null && pagingSearchParamSplit.Contains(prop.Name) && prop.PropertyType == typeof(System.String))
                    WhereQueryMaker.Append((WhereQueryMaker.Length == 0 ? "" : " OR ") + prop.Name + ".ToLower().Contains(@0) ");
                else if (pagingSearchParam != null && pagingSearchParamSplit.Contains(prop.Name) && prop.PropertyType == typeof(System.Int32))
                    //if data type is integer then you need to parse to ToString() to use Contains() function
                    WhereQueryMaker.Append((WhereQueryMaker.Length == 0 ? "" : " OR ") + prop.Name + ".ToString().Contains(@0)");
                else if (pagingSearchParam != null && pagingSearchParamSplit.Contains(prop.Name) && prop.PropertyType == typeof(System.DateTime?) && DateTime.TryParseExact(GlobalSearchText, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out CreatedOn))
                    //Date object comparison required to follow DateTime(2018,08,15) as format. so need to supply yyyy, MM, dd value on it.
                    WhereQueryMaker.Append((WhereQueryMaker.Length == 0 ? "" : " OR ") + prop.Name + "== DateTime(" + CreatedOn.Year + ", " + CreatedOn.Month + ", " + CreatedOn.Day + ")");
            }
            return table.Where(WhereQueryMaker.ToString(), GlobalSearchText.ToLower());
        }
        return table;
    }

    public static IQueryable<T> ToIndividualColumnSearch<T>(this IQueryable<T> table, DTParameters<T> Param)
    {
        if (Param.Columns != null && Param.Columns.Count() > 0)
        {
            Type EntityType = typeof(T);
            var Properties = EntityType.GetProperties();
            DateTime CreatedOn;
            int Id;
            //listing necessary column where individual columns search has applied. Filtered with search text as well it data types
            Param.Columns.Where(w => w.Search != null &&
            !string.IsNullOrEmpty(w.Search.Value)).ToList().ForEach(x =>
            {
                //x.Data is column name as string format coming from Param object.
                //x.Search.Value specific search text applied on column
                //Added extra check on column name coming from Param and its data type on search text.
                if (int.TryParse(x.Search.Value, out Id) && Properties.Count(p => p.Name == x.Data && p.PropertyType == typeof(System.Int32)) > 0)
                    table = table.Where(x.Data + ".ToString().Contains(@0)", x.Search.Value);
                else if (DateTime.TryParseExact(x.Search.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out CreatedOn) && Properties.Count(p => p.Name == x.Data && p.PropertyType == typeof(System.DateTime?)) > 0)
                    table = table.Where(x.Data + "==DateTime(" + CreatedOn.Year + ", " + CreatedOn.Month + ", " + CreatedOn.Day + ")");
                else if (Properties.Count(p => p.Name == x.Data && p.PropertyType == typeof(System.String)) > 0)
                    table = table.Where(x.Data + ".Contains(@0)", x.Search.Value);
            });
        }
        return table;
    }

    public static IQueryable<T> ToSorting<T>(this IQueryable<T> table, DTParameters<T> Param)
    {
        //Param.SortOrder return sorting column name
        //Param.Order[0].Dir return direction as asc/desc
        Type EntityType = typeof(T);
        var Properties = EntityType.GetProperties();
        var cl = Param.Columns.Select(o => o.Data).ToList();
        if (Param.SortOrder != null && Param.SortOrder != "Image" && Param.SortOrder != "sitePrice" && Param.SortOrder != "Detail" && Properties.Any(p => p.Name == Param.SortOrder) && Properties.Any(p => cl.Contains(p.Name)))
        {
            return table.OrderBy(Param.SortOrder + " " + Param.Order[0].Dir).AsQueryable();
        }
        else
        {
            //var ddd = table.ToString();
            //return table.OrderBy("order by 1 desc").AsQueryable();
            return table.AsQueryable();
        }

    }

    public static IQueryable<T> ToPagination<T>(this IQueryable<T> table, DTParameters<T> Param)
    {
        //Param.Start return start index
        //Param.Length page length
        if (Param.Length > 0)
            return table.Skip(Param.Start).Take(Param.Length);
        else return table.Skip(Param.Start);
    }
}
