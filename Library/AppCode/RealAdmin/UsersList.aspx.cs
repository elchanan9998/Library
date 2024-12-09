using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace Library.AppCode.RealAdmin
{
    public partial class UsersList : System.Web.UI.Page
    {
        protected void Page_load(object sender, EventArgs e)
        {
            // בעת טעינה ראשונית נמלא את תוכן העמוד
            if (!IsPostBack)
            {
                FillData();
            }
        }
        public void FillData()
        {
            //נשלוף את רשימת המשתמשים ונחבר לרפיטר
            rptUsers.DataSource = Users.Get();
            rptUsers.DataBind();
            // הקוד ישכפל את עצמו כמספר שנקבל מהליסט בפונקציה של גט
        }
    }
}