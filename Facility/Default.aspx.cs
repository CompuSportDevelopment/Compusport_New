using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwingModel.Entities;
using SwingModel.Data;
using System.Web.Security;

public partial class Facility_Default : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnPreRender(EventArgs e)
    {
        Label3.Text = _teacher.FirstName;
        Label4.Text = _teacher.LastName;
        Label6.Text = _customersite.SiteName;
    }

}
