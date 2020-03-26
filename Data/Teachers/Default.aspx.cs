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
using System.Xml.Linq;
using System.Windows.Forms;
using System.Text;
using SwingModel.Data;
using SwingModel.Entities;

//public partial class Teachers_Default : System.Web.UI.Page
public partial class Teachers_Default : SwingModel.UI.BasePage
{
    
    Teacher _teacher = new Teacher();
    TeacherSite _teachersite = new TeacherSite();
    CustomerSite _customersite = new CustomerSite();
    protected override void OnPreLoad(EventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            try
            {
                _teacher = DataRepository.TeacherProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
                int teacherid = _teacher.TeacherId;
                _teachersite = DataRepository.TeacherSiteProvider.GetByTeacherId(teacherid)[0];
                int techersiteid = _teachersite.SiteId;
                _customersite = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(techersiteid);
            }
            catch
            {
            }
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        Label3.Text= _teacher.FirstName;
        Label4.Text = _teacher.LastName;

        Label6.Text = _customersite.SiteName;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
