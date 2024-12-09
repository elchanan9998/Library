using BLL;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            var LstUsers = (List<Users>)Application["Users"];
            bool isAuthenticated = false;

            foreach (var user in LstUsers)
            {
                if (TxtEmail.Text == user.Email && TxtPass.Text == user.UserPass)
                {
                    isAuthenticated = true;
                    Session["LoginForm"] = true;
                    Response.Redirect("Default1.aspx");
                    break;
                }
            }

            if (!isAuthenticated)
            {
                LtMsg2.Text = "אימייל וסיסמא אינם נכונים";
            }
        }
    }
}
