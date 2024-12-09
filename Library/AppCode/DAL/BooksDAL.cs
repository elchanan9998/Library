using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using System.Data;
using DAL;
using Sitecore.FakeDb;

namespace DAL
{
    public class BooksDAL
    {
        public static Books GetById(int id)
        {
            Books Tmp = null;
            DbContext db = new DbContext();
            string Sql = $"SELECT * FROM T_Books WHERE BooksId=[id]";  //מבקש את הספר לפי האיי די שהתבקש
            DataTable Dt = db.Execute(Sql);  // התוצאות מגיעות לכאן
            
            if(Dt.Rows.Count > 0)   //שואל האם יש לפחות תו אחד זה אומר שיש תוצאה
            {
                Tmp = new Books()
                {
                    UserId=int.Parse (Dt.Rows[0]["UserId"]+" "),  //פונה אל השורה הראשונה ואל שם העמודה
                    UserName = Dt.Rows[0]["UserName"]+"",
                     Year = DateTime.Parse(Dt.Rows[0]["Year"]+""),
                     UserAuthor = Dt.Rows[0]["UserAuthor"] + "",
                    UserDescription = Dt.Rows[0]["UserDescription"] + "",
                    UserLang = Dt.Rows[0]["UserLang"] + "",
                    Location = Dt.Rows[0]["Location"] + "",
                    Status = Dt.Rows[0]["Status"] + "",
                    TakenDate = DateTime.Parse(Dt.Rows[0]["TakenDate"] + ""),
                    ReturnTaken = DateTime.Parse(Dt.Rows[0]["ReturnTaken"] + ""),
                };
            }

            // null במידה ולא הייתה תוצאה אז אני אקבל את הערך 
            return Tmp;
        }
        public static List<Books> Get()
        {
            List<Books> LstTmp = new List<Books>();
            DbContext db = new DbContext();
            string Sql = $"SELECT * FROM T_Books";  //מבקש את כל הספרים
            DataTable Dt = db.Execute(Sql);  // התוצאות מגיעות לכאן

            for(int i=0; i<Dt.Rows.Count;i++)   //שואל האם יש לפחות תו אחד זה אומר שיש תוצאה
            {
                Books Tmp = new Books()
                {
                    UserId = int.Parse(Dt.Rows[i]["UserId"] + " "),  // i פונה אל השורה במקום  ה     
                    UserName = Dt.Rows[i]["UserName"] + "",
                    Year = DateTime.Parse(Dt.Rows[i]["Year"] + ""),
                    UserAuthor = Dt.Rows[0]["UserAuthor"] + "",
                    UserDescription = Dt.Rows[0]["UserDescription"] + "",
                    UserLang = Dt.Rows[0]["UserLang"] + "",
                    Location = Dt.Rows[0]["Location"] + "",
                    Status = Dt.Rows[0]["Status"] + "",
                    TakenDate = DateTime.Parse(Dt.Rows[0]["TakenDate"] + ""),
                    ReturnTaken = DateTime.Parse(Dt.Rows[0]["ReturnTaken"] + ""),
                };
                LstTmp.Add(Tmp);
            }

            return LstTmp;

        }
        public static int Delete(int id)
        {
            Books Tmp = null;
            DbContext db = new DbContext();
            string Sql = $"DELETE * FROM T_Books WHERE BooksId=[id]";  //מוחק את הספר לפי האיי די שהתבקש
            int ReCount = 0;
            ReCount = db.ExecuteNonQuery(Sql); //מחזירה מספר שלן שמייצג כמה רשימות הושפעו
 
            return ReCount;
        }
        public static int Save(Books Tmp)
        {
            int ReCount = 0;
            DbContext Db = new DbContext();
            string Sql = "";
           if(Tmp.UserId == -1)    //אם קיבלתי את הערך מינוס אחד אז אני עושה הוספה
            {
                Sql = $"INSERT INTO t_Books (BooksName)Values(N'{Tmp.UserName}')";
            }
           else  //אם לא הוספה אז עושה עדכון
            {
                Sql = $"UPDATE T_Books set BooksName=N'{Tmp.UserName}'WHERE BooksId={Tmp.UserId}";
            }

            ReCount = Db.ExecuteNonQuery(Sql); //מחזירה מספר שלן שמייצג כמה רשימות הושפעו
            if(Tmp.UserId == -1)
            {
                Tmp.UserId = Db.GetMaxId("T_Books", "BooksId");
            }
            return ReCount;
        }
    }
}