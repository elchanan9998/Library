using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using DAL;
using System.Data;
using System.Security.Policy;
using System.Xml.Linq;
using Microsoft.Exchange.WebServices.Data;
using DATA;
using MongoDB.Bson;

namespace DAL
{
    public class UsersDAL
    {
        public static Users GetById(int id)
        {
            Users Tmp = null;
            DbContext db = new DbContext();
            string Sql = $"SELECT * FROM T_Users WHERE UsersId=[id]";  //מבקש את הספר לפי האיי די שהתבקש
            DataTable Dt = db.Execute(Sql);  // התוצאות מגיעות לכאן

            if (Dt.Rows.Count > 0)   //שואל האם יש לפחות תו אחד זה אומר שיש תוצאה
            {
                Tmp = new Users()
                {
                    UserId = int.Parse(Dt.Rows[0]["UsersId"] + " "),  //פונה אל השורה הראשונה ואל שם העמודה
                    UserName = Dt.Rows[0]["UsersName"] + "",
                    JoinDate = DateTime.Parse(Dt.Rows[0]["JoinDate"] + ""),
                    Name = Dt.Rows[0]["Name"] + "",
                    Address = Dt.Rows[0]["Address"] + "",
                    Email = Dt.Rows[0]["Email"] + "",
                    Phone = Dt.Rows[0]["Phone"] + "",
                };
            }

            // null במידה ולא הייתה תוצאה אז אני אקבל את הערך 
            return Tmp;
        }
        public static List<Users> Get()
        {
            List<Users> LstTmp = new List<Users>();
            DbContext db = new DbContext();
            string Sql = $"SELECT * FROM T_Users";  //מבקש את כל הספרים
            DataTable Dt = db.Execute(Sql);  // התוצאות מגיעות לכאן

            for (int i = 0; i < Dt.Rows.Count; i++)   //שואל האם יש לפחות תו אחד זה אומר שיש תוצאה
            {
                Users Tmp = new Users()
                {
                    UserId = int.Parse(Dt.Rows[i]["UserId"] + " "),  //פונה אל השורה הראשונה ואל שם העמודה
                    UserName = Dt.Rows[i]["UserName"] + "",
                    JoinDate = DateTime.Parse(Dt.Rows[i]["JoinDate"] + ""),
                    Name = Dt.Rows[i]["Name"] + "",
                    Email = Dt.Rows[i]["Email"] + "",
                    Phone = Dt.Rows[i]["Phone"] + "",
                    UserPass = Dt.Rows[i]["UserPass"] + ""
                };
                LstTmp.Add(Tmp);
            }

            return LstTmp;

        }
        public static int Delete(int id)
        {
            Users Tmp = null;
            DbContext db = new DbContext();
            string Sql = $"DELETE * FROM T_Users WHERE UserId=[id]";  //מוחק את הספר לפי האיי די שהתבקש
            int ReCount = 0;
            ReCount = db.ExecuteNonQuery(Sql); //מחזירה מספר שלן שמייצג כמה רשימות הושפעו

            return ReCount;
        }
        public static int Save(Users Tmp)
        {
            int ReCount = 0;
            DbContext Db = new DbContext();
            string Sql = "";
            if (Tmp.UserId == -1)    //אם קיבלתי את הערך מינוס אחד אז אני עושה הוספה
            {
               
                Sql = $"INSERT INTO t_Users (UserName,JoinDate,Name,Email,Address,Phone,UserPass)Values ";
                Sql+=$" (N'{Tmp.UserName}','{Tmp.JoinDate.ToString("yyyy-MM-dd")}',N'{Tmp.Name}',N'{Tmp.Email}',N'{Tmp.Address}',N'{Tmp.Phone}',N'{Tmp.UserPass}')";
            }
            else  //אם לא הוספה אז עושה עדכון
            {
                Sql = $"UPDATE T_Users set";
                Sql+= $"UserName=N'{Tmp.UserName}', ";
                Sql += $"JoinDate='{Tmp.JoinDate.ToString("yyyy-MM-dd")}' ";
                Sql += $"Name=N'{Tmp.Name}', ";
                Sql += $"Email=N'{Tmp.Email}', ";
                Sql += $"Address=N'{Tmp.Address}', ";
                Sql += $"Phone=N'{Tmp.Phone}', ";
                Sql += $"UserPass=N'{Tmp.UserPass}', ";
                Sql =$" WHERE UsersId={Tmp.UserId}";
            }

            ReCount = Db.ExecuteNonQuery(Sql); //מחזירה מספר שלן שמייצג כמה רשימות הושפעו
            if (Tmp.UserId == -1)
            {
                Tmp.UserId = Db.GetMaxId("T_Users", "UserId");
            }
            return ReCount;
        }


        //public static int Save(Users Tmp, string ContextName)
        //{

        //    BsonDocument Users = new BsonDocument
        //    {
        //        { "UserId",Tmp.UserId},
        //        { "UserName",Tmp.UserName},
        //    };
        //    MongoContext mongoContext = new MongoContext();

        //    mongoContext.InsertOne("Users", Users);
        //    int ReCount = 1;
        //    return ReCount;
        //}
    }
}