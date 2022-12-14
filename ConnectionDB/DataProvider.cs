using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace cafetrungnguyen
{
    public static class DataProvider
    {
        public static DataTable ExcuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            try
            {
                string connectionString = @"Data Source = .\sqlexpress; Initial Catalog = QLcafetrungnguyen; User= sa; Password=votinh111003";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                if (connection.State != System.Data.ConnectionState.Open)
                    return new DataTable();
                SqlCommand cmd = new SqlCommand(query, connection);
                foreach (var pram in parameters)
                {
                    cmd.Parameters.AddWithValue(pram.Key, pram.Value);               
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public static int ExcuteNonQuery(string query, Dictionary<string,object> parameters =null){
            try
            {
                string connectionString = @"Data Source  = .\sqlexpress; Initial Catalog = QLcafetrungnguyen; User = sa; Password = votinh111003";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                if(connection.State != System.Data.ConnectionState.Open)
                    return -1;
                SqlCommand cmd = new SqlCommand(query, connection);
                if(parameters != null)
                {
                    foreach(var pram in parameters){
                        cmd.Parameters.AddWithValue(pram.Key, pram.Value);
                    }
                }
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex){
                return -1;
            }
        }
    }
}