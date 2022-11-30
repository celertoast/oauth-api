using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMModels
{
   public class SqlParametersResult
    {

        public string OrderByQuery { get; set; } = " Order By ";
        public string WhereQuery { get; set; }
        public List<SqlParameter> SqlParameter { get; set; } = new List<SqlParameter>();
   

        public string GetWhereQuery(string baseQuery)
        {
            return baseQuery + WhereQuery;
        }

        public string GetQueryWithOrderBY(string baseQuery, BaseSearch baseSearch)
        {
            return baseQuery + WhereQuery + OrderByQuery + baseSearch.GetPages(baseSearch, SqlParameter);
        }


    }
}
