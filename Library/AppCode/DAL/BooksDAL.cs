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
                    BookId=int.Parse (Dt.Rows[0]["BookId"]+" "),  //פונה אל השורה הראשונה ואל שם העמודה
                    BookName = Dt.Rows[0]["BookName"]+"",
                     Year = DateTime.Parse(Dt.Rows[0]["Year"]+"")  
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
                    BookId = int.Parse(Dt.Rows[i]["BookId"] + " "),  // i פונה אל השורה במקום  ה     
                    BookName = Dt.Rows[i]["BookName"] + "",
                    Year = DateTime.Parse(Dt.Rows[i]["Year"] + "")
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
            DbContext db = new DbContext();
            string Sql = "";
           if(Tmp.BookId == -1)    //אם קיבלתי את הערך מינוס אחד אז אני עושה הוספה
            {
                Sql = $"INSERT INTO t_Books (BooksName)Values(N'{Tmp.BookName}')";
            }
           else  //אם לא הוספה אז עושה עדכון
            {
                Sql = $"UPDATE T_Books set BooksName=N'{Tmp.BookName}'WHERE BooksId={Tmp.BookId}";
            }

            ReCount = db.ExecuteNonQuery(Sql); //מחזירה מספר שלן שמייצג כמה רשימות הושפעו
            if(Tmp.BookId == -1)
            {
                Tmp.BookId= Db.GetMaxId("T_Books","BooksId")
            }
            return ReCount;
        }
    }
}