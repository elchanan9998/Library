using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Library.AppCode.RealAdmin
{
    public partial class Defalut1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPopularUsers();

                if (Session["UserName"] != null)
                {
                    lblWelcome.Text = $"ברוך הבא, {Session["UserName"]}!";
                }
                else
                {
                    lblWelcome.Text = "ברוך הבא לספרייה שלנו!";
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                lblSearchResult.Text = $"תוצאות חיפוש עבור: {searchQuery}";
                // חיפוש בספרייה
                SearchUsersInDatabase(searchQuery);
            }
            else
            {
                lblSearchResult.Text = "אנא הכנס מילות חיפוש.";
            }
        }

        private void LoadPopularUsers()
        {
            var popularUsers = new List<Users1>
            {
                new Users1 { Title = "ספר 1", Description = "תיאור ספר 1", ImageUrl = "images/User1.jpg", DetailsUrl = "UserDetails.aspx?id=1" },
                new Users1 { Title = "ספר 2", Description = "תיאור ספר 2", ImageUrl = "images/User2.jpg", DetailsUrl = "UserDetails.aspx?id=2" },
                new Users1 { Title = "ספר 3", Description = "תיאור ספר 3", ImageUrl = "images/User3.jpg", DetailsUrl = "UserDetails.aspx?id=3" }
            };

            rptPopularUsers.DataSource = popularUsers;
            rptPopularUsers.DataBind();
        }

        private void SearchUsersInDatabase(string searchQuery)
        {
            // הוספת קוד לחיפוש בסיס נתונים כאן
        }
    }

    public class Users1
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string DetailsUrl { get; set; }
    }
}
