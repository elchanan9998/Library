using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DAL;
using BLL;

namespace Data
{
    public class DbContext
    {
        public string ConnStr { get; set; }
        public SqlConnection Conn { get; set; }
        public DbContext()
        {
            ConnStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //ניצור אובייקט מסוג חיבור /צינור לבסיס הנתונים
            // SqlConnection Conn=new SqlConnection(ConnStr);

            // ניצור אובייקט מסוג חיבור / צינור לבסיס הנתונים
            Conn = new SqlConnection();
            //הגדרת מחרוזת התחברות עבור אובייקט הצינור 
            Conn.ConnectionString = ConnStr;
            Conn.Open(); //פתיחת הצינור /החבירו לבסיס הנתונים
        }
        public DbContext(string ConnStr)
        {
            this.ConnStr=ConnStr;
            Conn = new SqlConnection();
            Conn.ConnectionString = ConnStr;
            Conn.Open(); 
        }
        public void Close()
        {
            Conn.Close();
        }
        public int GetMaxById(string TableName,string PrimaryKeyName)
        {
            int MaxId = -1;
            string Sql = $"SELECT MAX({PrimaryKeyName})FROM {TableName}";
            SqlCommand Cmd = new SqlCommand(Sql, Conn);
            MaxId=(int)Cmd.ExecuteScalar();
            Cmd.Dispose();
            return MaxId;
        }
        public int ExecuteNonQuery(string Sql)   // עבור שאילתות שלא מחזירות ערך
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Conn;   
            Cmd.CommandText = Sql; 

            int RetVal = Cmd.ExecuteNonQuery();
            Cmd.Dispose(); //שחרור הזכרון באופן יזום
            return RetVal; // החזרת מספר הרשומות שהושפעו מהשאילתה
        } 
        public object ExecuteScalar(string Sql)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = Sql;
            object RetVal = Cmd.ExecuteScalar();
            Cmd.Dispose(); //שחרור הזכרון באופן יזום
            return RetVal; // החזרת מספר הרשומות שהושפעו מהשאילתה
        
        }
        public DataTable Execute(string Sql)  //פונקציה זו תשמש לשליפה של הנתונים
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Conn; // הגדרת הצינור בו ישתמש אובייקט הפקודה
            Cmd.CommandText = Sql; // הגדרת השאילתה אותה ברצוננו לבצע
            DataTable Dt = new DataTable();// יצירת אובייקט מסוג טבלת נתונים
            SqlDataAdapter Da=new SqlDataAdapter(); // הגדרת אובייקט מסוג מתאם נתונים
            Da.SelectCommand = Cmd;  // הגדרת תותח השאילתות אותו יתפעל המתאם
            Da.Fill(Dt); //  מילוי טבלת הנתונים בתוצאות שחזרו מהפעלת השאילתה
            return Dt; // החזרת מספר הרשומות שהושפעו השאילתה
        }

    }
}