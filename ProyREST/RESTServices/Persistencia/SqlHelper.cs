using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

using System.IO;

namespace WCFCliente.Dominio
{
    //CLASE FACILITADORA ELARADA POR ROSA OLIVER Y MARIANO FIGUEROA
    class SqlHelper
    {
        public static string Cadena
        {
            get
            {
                return "Data Source=.\\SQLEXPRESS; Initial Catalog=CN_C_EDICSEM; Integrated Security=SSPI;";
                //return "Data Source=(local); Initial Catalog=CN_C_EDICSEM;Integrated Security=SSPI;";
            }
        }

        private static string connStr = "Data Source=.\\SQLEXPRESS; Initial Catalog=CN_C_EDICSEM; Integrated Security=SSPI;";
        //private static string connStr = "Data Source=(local); Initial Catalog=CN_C_EDICSEM;Integrated Security=SSPI;";
        public static int ExecuteNonQuery(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        return cmd.ExecuteNonQuery();
                       
                    }
                }
                catch (Exception error)
                {
                  
                    if (error.Source != null)
                        return 0;
                    throw;
                }

            }
        }
        public static object ExecuteScalar(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    return cmd.ExecuteScalar();
                }

            }
        }
        
        public static DataSet ExecuteDataSet(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dataset = new DataSet();
                        adapter.Fill(dataset);
                        return dataset;
                    }

                }
                catch (Exception error)
                {
                   
                    if (error.Source != null)
                       
                    return null;
                    throw;
                }
            }
        }
        
        public static DataTable ExecuteDataTable(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.Parameters.AddRange(parameters);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dataset = new DataSet();
                        adapter.Fill(dataset);
                        return dataset.Tables[0];
                    }
                }
                catch (Exception error)
                {
                    if (error.Source != null)
                        
                    return null;
                    throw;
                }

            }
        }
        public static Boolean executeProcedure(string nombreProcedure, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = nombreProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parameters);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception error)
                {
                    
                    if (error.Source != null)
                        
                    return false;
                    throw;
                }

            }

        }
    }
}