using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace SMModels
{
    public class BaseSearch
    {
        protected string _orderBy;
        protected string _columnName;

        public virtual string OrderBy
        {
            get
            {

                if (string.IsNullOrWhiteSpace(_orderBy))
                {
                    return "desc";
                }
                return _orderBy;

            }
            set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    _orderBy = "desc";
                }
                else
                {
                    _orderBy = value.ToLower();
                }
            }
        }

        public virtual string ColumnName
        {
            get
            {

                if (string.IsNullOrWhiteSpace(_columnName))
                {
                    return "id";
                }
                return _columnName;

            }

            set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    _columnName = "id";
                }
                else
                {
                    _columnName = value.ToLower();
                }
            }




        }


        public BaseSearch()
        {
            Page = new Page();
            Page.RowCount = 5;
            Page.CurrentPage = 1;
        }



        public  string   GetPages(BaseSearch baseSearch, List<SqlParameter> sp)
        {
            // baseSearch.Page.TotalRows = list.Count();
            baseSearch.Page.TotalPages = (int)Math.Ceiling(baseSearch.Page.TotalRows * 1.0 / baseSearch.Page.RowCount * 1.0);
            if (baseSearch.Page.CurrentPage > baseSearch.Page.TotalPages)
            {
                baseSearch.Page.CurrentPage = 1;
            }

            baseSearch.Page.CurrentRowStart = (baseSearch.Page.CurrentPage - 1) * baseSearch.Page.RowCount + 1;
            baseSearch.Page.CurrentRowEnd = (baseSearch.Page.CurrentPage - 1) * baseSearch.Page.RowCount + baseSearch.Page.RowCount;

            if (baseSearch.Page.CurrentRowEnd > baseSearch.Page.TotalRows)
            {
                baseSearch.Page.CurrentRowEnd = baseSearch.Page.TotalRows;
            }

            SqlParameter s1 = new SqlParameter("@OffsetValue", (baseSearch.Page.CurrentPage - 1) * baseSearch.Page.RowCount);
            SqlParameter s2 = new SqlParameter("@nextValue", baseSearch.Page.RowCount);
            sp.Add(s1);
            sp.Add(s2);
             return $" OFFSET @OffsetValue ROWS FETCH NEXT @nextValue ROWS ONLY ";


            //  return $" OFFSET {(baseSearch.Page.CurrentPage - 1) * baseSearch.Page.RowCount} ROWS FETCH NEXT {baseSearch.Page.RowCount} ROWS ONLY ";

        }




        public Page Page { get; set; }

        public void ReversOrderBy()
        {
            this.OrderBy = "desc".Equals(this.OrderBy) ?
                "asc" : "desc";
        }
    }

    public static class AnyLogics
    {

        ///RowCount =3
        ///TotalRows=7;
        ///TOtalPages=7/3 = 2.33
        ///

       public static IQueryable<T> GetPages<T>(this IQueryable<T>  list, BaseSearch baseSearch)
        {
            // baseSearch.Page.TotalRows = list.Count();
            baseSearch.Page.TotalPages =(int)Math.Ceiling( baseSearch.Page.TotalRows * 1.0/ baseSearch.Page.RowCount* 1.0);
            if(baseSearch.Page.CurrentPage > baseSearch.Page.TotalPages)
            {
                baseSearch.Page.CurrentPage = 1;
            }

            baseSearch.Page.CurrentRowStart = (baseSearch.Page.CurrentPage - 1) * baseSearch.Page.RowCount + 1;
            baseSearch.Page.CurrentRowEnd = (baseSearch.Page.CurrentPage - 1) * baseSearch.Page.RowCount  + baseSearch.Page.RowCount;

            if (baseSearch.Page.CurrentRowEnd > baseSearch.Page.TotalRows)
            {
                baseSearch.Page.CurrentRowEnd = baseSearch.Page.TotalRows;
            }

            return list.Skip((baseSearch.Page.CurrentPage-1)*baseSearch.Page.RowCount).Take(baseSearch.Page.RowCount);
        }
    }

}
