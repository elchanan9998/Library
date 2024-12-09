using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DAL;
using BLL;
using System.Reflection;

namespace Data
{
    public class DbContext
    {
        public string ConnStr { get; set; }
        public SqlConnection Conn { get; set; }
        public DbContext()
        {
            ConnStr = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
            Conn = new SqlConnection(ConnStr);
            Open();
        }
        public void Open()
        {
            Conn.Open();
        }
        public void Close()
        {
            Conn.Close();
        }
        public DataTable Execute(string Sql)
        {
            DataTable Dt = new DataTable();
            SqlCommand Cmd = new SqlCommand(Sql, Conn);

            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);
            Cmd.Dispose();
            //  Close();
            return Dt;
        }
        public int ExecuteNonQuery(string Sql)
        {
            int RecCount = 0;
            SqlCommand Cmd = new SqlCommand(Sql, Conn);
            RecCount = Cmd.ExecuteNonQuery();
            Cmd.Dispose();
            //Close();
            return RecCount;
        }

        public int GetMaxId(string TableName, string PrimaryKeyName)
        {
            int MaxId = -1;
            string Sql = $"SELECT MAX( {PrimaryKeyName}) FROM {TableName} ";
            SqlCommand Cmd = new SqlCommand(Sql, Conn);
            MaxId = (int)Cmd.ExecuteScalar();
            Cmd.Dispose();
            //   Close();
            return MaxId;
        }
        public DataTable ExecuteWithParams(string Sql, List<SqlParameter> Params)
        {
            DataTable Dt = new DataTable();
            SqlCommand Cmd = new SqlCommand(Sql, Conn);
            for (int i = 0; i < Params.Count; i++)
            {
                Cmd.Parameters.Add(Params[i]);
            }
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);
            Cmd.Dispose();
            //  Close();
            return Dt;
        }


        public int ExecuteNonQueryWithParams(string Sql, List<SqlParameter> Params)
        {
            int RecCount = 0;
            SqlCommand Cmd = new SqlCommand(Sql, Conn);
            for (int i = 0; i < Params.Count; i++)
            {
                Cmd.Parameters.Add(Params[i]);
            }
            RecCount = Cmd.ExecuteNonQuery();
            Cmd.Dispose();
            //  Close();
            return RecCount;
        }


        public string GetValueByKey(string TableName, string KeyName, string ValueName, string KeyValue)
        {
            string RetValue = null;
            string Sql = $"SELECT top 1 {ValueName} FROM {TableName} where {KeyName}='{KeyValue}'  ";
            SqlCommand Cmd = new SqlCommand(Sql, Conn);
            RetValue = (string)(Cmd.ExecuteScalar() + "");
            Cmd.Dispose();
            //   Close();
            return RetValue;
        }

        public static List<SqlParameter> CreateParameters(object parametersObject)
        {
            var parameters = new List<SqlParameter>();

            foreach (PropertyInfo property in parametersObject
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                parameters.Add(new SqlParameter($"@{property.Name}", property.GetValue(parametersObject, null)));
            }

            return parameters;
        }
    }
}