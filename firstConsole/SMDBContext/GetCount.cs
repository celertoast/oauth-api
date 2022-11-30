using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SMDBContext
{
 public static   class GetCount
    {

        public static int CountByRwSql(this DbContext  dbContext, string query, SqlParameter[] sps)
        {
            int result = -1;

            SqlConnection connection = dbContext.Database.GetDbConnection() as SqlConnection;

            try
            {
                connection.Open();

                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = query;

                    if (sps != null)
                    {
                        foreach (var item in sps)
                        {
                            sqlCommand.Parameters.Add(item);
                        }
                    }

                    using (DbDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                result = dataReader.GetInt32(0);
                            }
                        }
                    }
                }

               

            }
            catch
            {

            }


            return result;
        }
    }
}
