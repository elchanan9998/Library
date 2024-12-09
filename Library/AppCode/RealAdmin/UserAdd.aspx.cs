using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;


namespace Library.AppCode.RealAdmin
{
    public partial class UserAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               
                FillData();
            }
        }
        public void FillData()
        {
            string UserId = Request["UserId"] + "";
            Users Tmp = null;
            if (string.IsNullOrEmpty(UserId))
            {
                UserId = "-1";  // הוספת משתמש חדש

            }
            else
            {
                 Tmp= Users.GetById(int.Parse(UserId));
                if (Tmp == null)
                {
                    UserId = "-1";     //חזרה למצב של הוספת משתמש חדש
                }
            }
            HidUserId.Value = UserId; // שמירת קוד משתמש לעריכה או הוספת חדש

            if (Tmp != null)
            {
                TxtUserName.Text = Tmp.UserName;
                Tmp.UserId = Tmp.UserId;
                TxtName.Text = Tmp.Name;
                TxtUserPass.Text = Tmp.UserPass;
                TxtEmail.Text = Tmp.Email;
                TxtAddress.Text = Tmp.Address;
                TxtPhone.Text = Tmp.Phone;
                TxtJoinDate.Text = Tmp.JoinDate.ToString("yyyy-MM-dd");
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            DateTime joinDate;
            bool isValidDate = DateTime.TryParseExact(
                TxtJoinDate.Text,
                "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out joinDate
            );

            if (!isValidDate)
            {
                // טיפול בתאריך לא תקין (לדוגמה, הצגת הודעת שגיאה)
                // יציאה או זריקת חריגה
                return;
            }

            Users Tmp = new Users()
            {
                UserId = int.Parse(HidUserId.Value),
                UserName = TxtUserName.Text,
                Name = TxtName.Text,
                Email = TxtEmail.Text,
                Address = TxtAddress.Text,
                Phone = TxtPhone.Text,
                JoinDate = joinDate
            };
            Tmp.Save();
            Response.Redirect("BooksList.aspx");
        }
    }
}