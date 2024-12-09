using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace RealEstateAshdod.RealAdmin
{
    public partial class AgentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // בעת הטיענה הראשונית, נמלא את תוכן העמוד ברשימת הסוכנים
            if(!IsPostBack)
            {
                FillData();
            }
        }
        public void FillData()
        {
            //נשלוף את רשימת הסוכנים ונחבר אותם לרפיטר
            RptAgent.DataSource = Agent.Get();
            RptAgent.DataBind();
        }
    }
}