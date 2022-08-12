using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace cafetrungnguyen
{
    public static class DataProvider
    {   //Select dùng excutequery
        public static DataTable ExcuteQuery (string query, Dictionary<string, object> parameters =  null)
        {
            try
            {
                string connectionString = @"Data Source = .\sqlexpress; Initial Catalog = QLcafetrungnguyen; User = sa; Password = votinh111003";
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

    }
}