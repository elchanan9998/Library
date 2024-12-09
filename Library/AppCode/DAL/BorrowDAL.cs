using BLL;
using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DAL
{
    public class BorrowDAL
    {
        public static Borrow GetById(int id)
        {
            Borrow Tmp = null;
            DbContext db = new DbContext();
            string Sql = $"SELECT * FROM T_Borrow WHERE BorrowId=[id]";  //מבקש את הספר לפי האיי די שהתבקש
            DataTable Dt = db.Execute(Sql);  // התוצאות מגיעות לכאן

            if (Dt.Rows.Count > 0)   //שואל האם יש לפחות תו אחד זה אומר שיש תוצאה
            {
                Tmp = new Borrow()
                {
                    BorrowId = int.Parse(Dt.Rows[0]["BorrowId"] + " "),  //פונה אל השורה הראשונה ואל שם העמודה
                    BorrowName = Dt.Rows[0]["BoroowName"] + "",
                    BookId = int.Parse(Dt.Rows[0]["BookId"] + " "),
                    UserId = int.Parse(Dt.Rows[0]["UserId"] + " "),
                    BorrowDate = DateTime.Parse(Dt.Rows[0]["BorrowDate"] + ""),
                    ReturnDatePlan = DateTime.Parse(Dt.Rows[0]["ReturnDatePlan"] + ""),
                    ActualReturnDate = DateTime.Parse(Dt.Rows[0]["ActualReturnDate"] + ""),
                    Notes = Dt.Rows[0]["Notes"] + "",
                };
            }

            // null במידה ולא הייתה תוצאה אז אני אקבל את הערך 
            return Tmp;
        }
        public static List<Borrow> Get()
        {
            List<Borrow> LstTmp = new List<Borrow>();
            DbContext db = new DbContext();
            string Sql = $"SELECT * FROM T_Borrow";  //מבקש את כל הספרים
            DataTable Dt = db.Execute(Sql);  // התוצאות מגיעות לכאן

            for (int i = 0; i < Dt.Rows.Count; i++)   //שואל האם יש לפחות תו אחד זה אומר שיש תוצאה
            {
                Borrow Tmp = new Borrow()
                {
                    BorrowId = int.Parse(Dt.Rows[0]["BorrowId"] + " "),  //פונה אל השורה הראשונה ואל שם העמודה
                    BorrowName = Dt.Rows[0]["BoroowName"] + "",
                    BookId = int.Parse(Dt.Rows[0]["BookId"] + " "),
                    UserId = int.Parse(Dt.Rows[0]["UserId"] + " "),
                    BorrowDate = DateTime.Parse(Dt.Rows[0]["BorrowDate"] + ""),
                    ReturnDatePlan = DateTime.Parse(Dt.Rows[0]["ReturnDatePlan"] + ""),
                    ActualReturnDate = DateTime.Parse(Dt.Rows[0]["ActualReturnDate"] + ""),
                    Notes = Dt.Rows[0]["Notes"] + "",
                };
                LstTmp.Add(Tmp);
            }

            return LstTmp;

        }
        public static int Delete(int id)
        {
            Borrow Tmp = null;
            DbContext db = new DbContext();
            string Sql = $"DELETE * FROM T_Borrow WHERE BorrowId=[id]";  //מוחק את הספר לפי האיי די שהתבקש
            int ReCount = 0;
            ReCount = db.ExecuteNonQuery(Sql); //מחזירה מספר שלן שמייצג כמה רשימות הושפעו

            return ReCount;
        }
        public static int Save(Borrow Tmp)
        {
            int ReCount = 0;
            DbContext Db = new DbContext();
            string Sql = "";
            if (Tmp.BorrowId == -1)    //אם קיבלתי את הערך מינוס אחד אז אני עושה הוספה
            {
                Sql = $"INSERT INTO t_Borrow (BorrowName)Values(N'{Tmp.BorrowName}')";
            }
            else  //אם לא הוספה אז עושה עדכון
            {
                Sql = $"UPDATE T_Borrow set BorrowName=N'{Tmp.BorrowName}'WHERE BorrowId={Tmp.BorrowId}";
            }

            ReCount = Db.ExecuteNonQuery(Sql); //מחזירה מספר שלן שמייצג כמה רשימות הושפעו
            if (Tmp.BorrowId == -1)
            {
                Tmp.BorrowId = Db.GetMaxId("T_Borrow", "BorrowId");
            }
            return ReCount;
        }
    }
}