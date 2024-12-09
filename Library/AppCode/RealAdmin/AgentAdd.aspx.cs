using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateAshdod.RealAdmin
{
    public partial class AgentAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                FillData();
            }
        }
        public void FillData()
        {
            string AgentId = Request["AgentId"] + "";
            Agent Tmp = null;
            if (string.IsNullOrEmpty(AgentId))
            {
                AgentId = "-1";// הוספת סוכן חדש
            }
            else
            {
                Tmp = Agent.GetById(int.Parse(AgentId));
                if (Tmp == null)
                {
                    AgentId = "-1";// מעברל למצב הוספת סוכן חדש
                }
            }
            HidAgentId.Value= AgentId;// שמירת קוד הסוכן לעריכה או הוספת חדש בשדה הנסתר
            // נמלא את כל הטופס בהנתונים הראשוניים שלו
            DDLCity.DataSource = City.Get();// הגדרת מקור הנתונים
            DDLCity.DataTextField = "CityName";
            DDLCity.DataValueField = "CityId";
            DDLCity.DataBind();// קשירת הנתונים לתיבת הרשימה
            DDLCity.Items.Insert(0, "בחר עיר");

            if(Tmp!=null)// אנחנו במצב עריכה של סוכן, לכן יש למלא את השדות בפרטים שלו
            {
                TxtFullName.Text = Tmp.FullName;
                TxtId.Text = Tmp.Id;
                TxtAddress.Text = Tmp.Address;
                TxtEmail.Text = Tmp.Email;
                TxtPass.Text = Tmp.Pass;
                TxtPhone.Text = Tmp.Phone;
                TxtStartDate.Text = Tmp.StartDate.ToString("yyyy-MM-dd");
                DDLCity.SelectedValue = Tmp.CityId+"";
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Agent Tmp = new Agent() { 
            AgentId=int.Parse(HidAgentId.Value),
            FullName=TxtFullName.Text,
            Id=TxtId.Text,
            Address=TxtAddress.Text,
            Phone=TxtPhone.Text,
            Email=TxtEmail.Text,
            Pass=TxtPass.Text,
            StartDate=DateTime.Parse(TxtStartDate.Text),
            CityId=int.Parse(DDLCity.SelectedValue)
            
            };
            Tmp.Save();
            Response.Redirect("AgentList.aspx");
        }
    }
}