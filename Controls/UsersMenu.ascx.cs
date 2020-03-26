using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwingModel.Data;
using SwingModel.Entities;
using System.Windows.Forms;

public partial class Controls_UsersMenu : System.Web.UI.UserControl
{
    Customer customer = new Customer();

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
            if (customer.FirstName.ToLower().Equals("demo") && customer.LastName.ToLower().Equals("student"))
            {
                HyperLink12.Visible = true;
                Label1.Visible = true;
            }
            else
            {
                HyperLink12.Visible = false;
                Label1.Visible = false;
            }
        }
        catch (Exception ex)
        {
            HyperLink12.Visible = false;
            Label1.Visible = false;
        }
    }
}
