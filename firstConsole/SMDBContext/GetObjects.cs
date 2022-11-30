using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SMDBContext
{

 public  static class GetObjects
    {
        public static List<Dictionary<string,string>> ObjectDictionaryByRawSql(this DbContext dbContext, string sql, SqlParameter[] sps)
        {
            SqlConnection connection = dbContext.Database.GetDbConnection() as SqlConnection;
            List<Dictionary<string, string>> keyValuePairs = new List<Dictionary<string, string>>();
            try
            {
                connection.Open();
                SqlCommand command1 = connection.CreateCommand();

                try
                {

                }
                catch
                {

                }
                finally
                {
                    command1.Dispose();
                }
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    if (sps != null)
                    {
                        foreach (var item in sps)
                        {
                            command.Parameters.Add(item);
                        }
                    }
                    

                    using (DbDataReader dataReader = command.ExecuteReader())
                        if (dataReader.HasRows)
                            while (dataReader.Read())
                            {
                                var keyValuePair = new Dictionary<string, string>();
                                for (int i = 0; i < dataReader.FieldCount; i++)
                                {
                                    var val = dataReader.GetValue(i);
                                    keyValuePair.Add(dataReader.GetName(i).ToLower(), val==null?"": val.ToString());
                                }
                                keyValuePairs.Add(keyValuePair);                                 
                            }
                                
                }


               
            }

            // We should have better error handling here
            catch (System.Exception e) { }

            finally { connection.Close(); }

            return keyValuePairs;
        }



        public static List<List<string>> ObjectListByRawSql(this DbContext dbContext, string sql, SqlParameter[] sps)
        {
            SqlConnection connection = dbContext.Database.GetDbConnection() as SqlConnection;
            List<List<string>> keyValuePairs = new List<List<string>>();
            try
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    if (sps != null)
                    {
                        foreach (var item in sps)
                        {
                            command.Parameters.Add(item);
                        }
                    }

                    using (DbDataReader dataReader = command.ExecuteReader())
                        if (dataReader.HasRows)
                            while (dataReader.Read())
                            {
                                var lst = new List<string>();
                                for (int i = 0; i < dataReader.FieldCount; i++)
                                {
                                    var val = dataReader.GetValue(i);
                                    lst.Add( val == null ? "" : val.ToString());
                                }
                                keyValuePairs.Add(lst);
                            }

                }
            }

            // We should have better error handling here
            catch (System.Exception e) { }

            finally { connection.Close(); }

            return keyValuePairs;
        }



    }
}
