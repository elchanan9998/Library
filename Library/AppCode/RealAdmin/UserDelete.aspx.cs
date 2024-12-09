using System;
using System.Data.SqlClient;
using System.Configuration;

namespace YourNamespace
{
    public partial class DeleteUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // קבל את ה-UserId מה-URL
                string UserId = Request.QueryString["UserId"];
                if (string.IsNullOrEmpty(UserId))
                {
                    lblMessage.Text = "User ID is missing!";
                    btnDelete.Enabled = false;
                }
                else
                {
                    LoadUserName(UserId);
                }
            }
        }

        private void LoadUserName(string UserId)
        { 
            string connectionString = ConfigurationManager.ConnectionStrings["LocalDBConnStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Name FROM Users WHERE UserId = @UserId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        lblUserName.Text = $"משתמש: {result.ToString()}";
                    }
                    else
                    {
                        lblMessage.Text = "User not found!";
                        btnDelete.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An error occurred: " + ex.Message;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string UserId = Request.QueryString["UserId"];
            if (!string.IsNullOrEmpty(UserId))
            {
                DeleteUserById(UserId);
            }
        }

        private void DeleteUserById(string UserId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Users WHERE UserId = @UserId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "User deleted successfully.";
                        Response.Redirect("UsersList.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "User not found!";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An error occurred: " + ex.Message;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // חזרה לרשימת המשתמשים אם בוטלה המחיקה
            Response.Redirect("UsersList.aspx");
        }
    }
}
