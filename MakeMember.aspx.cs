using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

//public partial class MakeMember : System.Web.UI.Page
public partial class MakeMember : SwingModel.UI.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        //Response.Redirect("https://www.swingmodel.com/Shop/PayMembership.aspx?Username=" + CreateUserWizard1.UserName);
        Response.Redirect("Shop/PayMembership.aspx?Username=" + CreateUserWizard1.UserName);
    }
}
