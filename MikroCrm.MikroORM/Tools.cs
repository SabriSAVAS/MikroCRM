using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using MikroCrm.Data.Domain.Entities;

namespace WebService.MikroORM
{
    public class Tools
    {

        
        private static SqlConnection connection;

        public static SqlConnection Connection
        {

            get
            {
                var current = HttpContext.Current;
                if (current.Session["SqlConnection"] == null)
                {
                    var data = (SettingData)HttpContext.Current.Session["UserDataBase"];
                    if (data != null)
                    {
                        connection = new SqlConnection("server=" + data.Server + ";Database=" + data.DataBase + ";User=" + data.UserName + ";Password=" + data.Password + ";pooling=true");
                    }
                     current.Session["SqlConnection"] = connection;
                    return (SqlConnection)current.Session["SqlConnection"]; 
                }
                return (SqlConnection)current.Session["SqlConnection"];
            }
            set { connection = value; }
        }

        internal static bool ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                }
            }
        }
    }
}
