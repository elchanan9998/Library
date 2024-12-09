using BLL;
using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DAL
{
    public class SuppliersDAL
    {
        public static Suppliers GetById(int id)
        {
            Suppliers Tmp = null;
            DbContext db = new DbContext();
            string Sql = $"SELECT * FROM T_Suppliers WHERE SuppliersId=[id]";  //מבקש את הספר לפי האיי די שהתבקש
            DataTable Dt = db.Execute(Sql);  // התוצאות מגיעות לכאן

            if (Dt.Rows.Count > 0)   //שואל האם יש לפחות תו אחד זה אומר שיש תוצאה
            {
                Tmp = new Suppliers()
                {
                    SId = int.Parse(Dt.Rows[0]["SId"] + " "),  //פונה אל השורה הראשונה ואל שם העמודה
                    SName = Dt.Rows[0]["SName"] + "",
                    SAddress = Dt.Rows[0]["SAddress"] + "",
                    SPhone = Dt.Rows[0]["SPhone"] + "",
                    SWeb = Dt.Rows[0]["SWeb"] + "",
                    SEmail = Dt.Rows[0]["SEmail"] + "",
                    Contact = Dt.Rows[0]["Contact"] + "",
                };
            }

            // null במידה ולא הייתה תוצאה אז אני אקבל את הערך 
            return Tmp;
        }
        public static List<Suppliers> Get()
        {
            List<Suppliers> LstTmp = new List<Suppliers>();
            DbContext db = new DbContext();
            string Sql = $"SELECT * FROM T_Suppliers";  //מבקש את כל הספרים
            DataTable Dt = db.Execute(Sql);  // התוצאות מגיעות לכאן

            for (int i = 0; i < Dt.Rows.Count; i++)   //שואל האם יש לפחות תו אחד זה אומר שיש תוצאה
            {
                Suppliers Tmp = new Suppliers()
                {
                    SId = int.Parse(Dt.Rows[0]["SId"] + " "),  //פונה אל השורה הראשונה ואל שם העמודה
                    SName = Dt.Rows[0]["SName"] + "",
                    SAddress = Dt.Rows[0]["SAddress"] + "",
                    SPhone = Dt.Rows[0]["SPhone"] + "",
                    SWeb = Dt.Rows[0]["SWeb"] + "",
                    SEmail = Dt.Rows[0]["SEmail"] + "",
                    Contact = Dt.Rows[0]["Contact"] + "",
                };
                LstTmp.Add(Tmp);
            }

            return LstTmp;

        }
        public static int Delete(int id)
        {
            Books Tmp = null;
            DbContext db = new DbContext();
            string Sql = $"DELETE * FROM T_Suppliers WHERE SuppliersId=[id]";  //מוחק את הספר לפי האיי די שהתבקש
            int ReCount = 0;
            ReCount = db.ExecuteNonQuery(Sql); //מחזירה מספר שלן שמייצג כמה רשימות הושפעו

            return ReCount;
        }
        public static int Save(Suppliers Tmp)
        {
            int ReCount = 0;
            DbContext Db = new DbContext();
            string Sql = "";
            if (Tmp.SId == -1)    //אם קיבלתי את הערך מינוס אחד אז אני עושה הוספה
            {

                Sql = $"INSERT INTO t_Suppliers (SuppliersName,JoinDate,Name,Email,Phone)Values ";
                Sql += $" (N'{Tmp.SName}',N'{Tmp.SEmail}',N'{Tmp.SPhone}')";
            }
            else  //אם לא הוספה אז עושה עדכון
            {
                Sql = $"UPDATE T_Suppliers set";
                Sql += $"SId=N'{Tmp.SId}', ";
                Sql += $"SName=N'{Tmp.SName}', ";
                Sql += $"Email=N'{Tmp.SEmail}', ";
                Sql += $"Phone=N'{Tmp.SPhone}', ";
                Sql = $" WHERE SuppliersId={Tmp.SId}";
            }

            ReCount = Db.ExecuteNonQuery(Sql); //מחזירה מספר שלן שמייצג כמה רשימות הושפעו
            if (Tmp.SId == -1)
            {
                Tmp.SId = Db.GetMaxId("T_Suppliers", "SId");
            }
            return ReCount;
        }
    }
}