using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace CommonComponents
{
    public static class DBConnection
    {
        public static SqlConnectionStringBuilder db = new SqlConnectionStringBuilder();

        public static string SqlConnection()
        {
            db.UserID = Constants.Properties["userId"];
            db.Password = Constants.Properties["dbPassword"];
            db.InitialCatalog = Constants.Properties["initialCatalog"];
            db.DataSource = Constants.Properties["dataSource"];
            db.IntegratedSecurity = bool.Parse(Constants.Properties["integratedSecurity"]);
            return db.ConnectionString;
        }

        public static void Create(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnection()))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public static string Select(string query, string columnname)
        {
            string str = (string)null;
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnection()))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader != null)
                    {
                        try
                        {
                            while (sqlDataReader.Read())
                                str = sqlDataReader[columnname].ToString();
                        }
                        finally
                        {
                            sqlDataReader.Close();
                            sqlConnection.Close();
                        }
                    }
                }
            }
            return str;
        }

        public static void Insert(StringBuilder query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnection()))
            {
                SqlCommand sqlCommand = new SqlCommand(query.ToString(), sqlConnection);
                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public static void Update(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnection()))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public static void Delete(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnection()))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public static List<string> RetrieveList(string query, string columnname)
        {
            List<string> stringList = new List<string>();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnection()))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader != null)
                    {
                        try
                        {
                            while (sqlDataReader.Read())
                                stringList.Add(sqlDataReader[columnname].ToString());
                        }
                        finally
                        {
                            sqlDataReader.Close();
                            sqlConnection.Close();
                        }
                    }
                }
            }
            return stringList;
        }

        public static Dictionary<string, string> RetrieveDict(string query, int columncount)
        {

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Clear();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnection()))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader != null)
                    {
                        try
                        {

                            while (sqlDataReader.Read())
                            {
                                int i = 0;
                                while (i < columncount)
                                {
                                    dictionary.Add(sqlDataReader.GetName(i), sqlDataReader[i].ToString());
                                    i++;
                                }
                            }
                        }
                        finally
                        {
                            sqlDataReader.Close();
                            sqlConnection.Close();
                        }
                    }
                }
            }
            return dictionary;
        }

        public static Dictionary<string, string> RetrieveKVPDict(string query, string key, string value)
        {

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Clear();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnection()))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader != null)
                    {
                        try
                        {

                            while (sqlDataReader.Read())
                            {
                                dictionary.Add(sqlDataReader[key].ToString(), sqlDataReader[value].ToString());
                            }
                        }
                        finally
                        {
                            sqlDataReader.Close();
                            sqlConnection.Close();
                        }
                    }
                }
            }
            return dictionary;
        }

        public static string SelectColumnValue(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnection()))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                try
                {
                    return Convert.ToString(sqlCommand.ExecuteScalar());
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public static DateTime SelectDateColumnValue(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnection()))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                try
                {
                    return Convert.ToDateTime(sqlCommand.ExecuteScalar());
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public static int SelectCount(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnection()))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                try
                {
                    return (int)sqlCommand.ExecuteScalar();
                }
                catch
                {
                    return 0;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }


        public static void Drop(string query)
        {
            string str = (string)null;
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnection()))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader != null)
                    {
                        try
                        {
                            while (sqlDataReader.Read())
                                str = sqlDataReader["CUIT"].ToString();
                        }
                        finally
                        {
                            sqlDataReader.Close();
                        }
                    }
                }
                try
                {
                    new SqlCommand(str, sqlConnection).ExecuteNonQuery();
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
