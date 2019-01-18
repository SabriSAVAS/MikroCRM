using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebService.MikroORM;

namespace MikroCrm.MikroORM
{
    public class OrmBase<TEntity> : IBaseOrm<TEntity> where TEntity : class
    {

        Type GetType
        {
            get { return typeof(TEntity); }
        }
        public List<TEntity> GetList()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = String.Format("Select * From {0}", GetType.Name);
            cmd.Connection = Tools.Connection;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (cmd.Connection!=null)
            {
                adp.Fill(dt);
            }
            var result = ToListGeneric<TEntity>(dt);
            return result.ToList();
        }
        public List<TEntity> GetList(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Tools.Connection;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                adp.Fill(dt);
            }
            catch (Exception)
            {


            }
            var result = ToListGeneric<TEntity>(dt);
            return result.ToList();
        }


        public static List<T> ToListGeneric<T>(DataTable dt)
        {

            var result = new List<T>();
            string colName = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                var Tp = typeof(T);
                T prd = Activator.CreateInstance<T>();
                var properties = Tp.GetProperties();
                foreach (var prop in properties)
                {
                    colName = prop.Name;
                    if (!dt.Columns.Contains(colName)) continue;
                    if (row[colName] == null) continue;
                    if (row[colName] == DBNull.Value) continue;
                    prop.SetValue(prd, row[colName], null);
                }
                result.Add(prd);
            }
            return result;
        }

        public bool Insert(TEntity Entity)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("prc_{0}_Insert", GetType.Name);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = Tools.Connection;
            PropertyInfo[] pro = GetType.GetProperties();
            foreach (var item in pro)
            {
                string pramAdi = "@" + item.Name;
                object value = item.GetValue(Entity);
                cmd.Parameters.AddWithValue(pramAdi, value);
            }

            return Tools.ExecuteNonQuery(cmd);
        }

        public bool Update(TEntity Entity)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("prc_{0}_Update", GetType.Name);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = Tools.Connection;
            PropertyInfo[] pro = GetType.GetProperties();
            foreach (var item in pro)
            {
                string pramAdi = "@" + item.Name;
                object value = item.GetValue(Entity);
                cmd.Parameters.AddWithValue(pramAdi, value);
            }

            return Tools.ExecuteNonQuery(cmd);
        }
        public bool Delete(int id)
        {
            TEntity ent = Activator.CreateInstance<TEntity>();
            PropertyInfo PrimaryColumn = GetType.GetProperty("PrimaryColumn");
            object prm = PrimaryColumn.GetValue(ent);
            SqlCommand cmd = new SqlCommand(string.Format("prc_{0}_Delete",GetType.Name));
            cmd.Connection = Tools.Connection;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(prm.ToString(), id);

            return Tools.ExecuteNonQuery(cmd);
        }
        public bool Delete(string sql)
        {
            //TEntity ent = Activator.CreateInstance<TEntity>();
            //PropertyInfo PrimaryColumn = GetType.GetProperty("PrimaryColumn");
            //object prm = PrimaryColumn.GetValue(ent);

            //StringBuilder sb = new StringBuilder();
            //sb.Append("Delete from ");
            //sb.Append(GetType.Name + " ");
            //sb.Append(" where "+ prm + "=");
            //sb.Append(id);
            //string sql = sb.ToString();
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = Tools.Connection;
            return Tools.ExecuteNonQuery(cmd);
        }
    }
}
