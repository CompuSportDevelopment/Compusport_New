using System;
using System.Collections;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Text;
using System.Net.Mail;
using SwingModel.Data;
using SwingModel.Entities;

//public partial class Users_EmailTeacher : System.Web.UI.Page
public partial class Users_EmailTeacher : SwingModel.UI.BasePage
{
    int x;
    Teacher teacher = new Teacher();
    int facilityid = -1;

    protected override void OnPreRender(EventArgs e)
    {
        //MessageBox.Show(Request.QueryString.Get("facilityid"));
       
        if (!IsPostBack)
        {
            IEnumerable customersites = DataRepository.CustomerSiteProvider.GetAll().OrderBy(s => s.SiteName);
            if (DropDownList2.SelectedIndex <= 0)
                DropDownList2.Items.Clear();
            DropDownList2.Items.Add("Select Location");
            DropDownList2.Items[0].Value = "0";
            if (DropDownList2.SelectedIndex <= 0)
            {
                if (facilityid.Equals(-1))
                    DropDownList2.Items[0].Selected = true;
                else
                {
                    DropDownList2.Items[0].Selected = false;
                    DropDownList2.ClearSelection();
                }
            }
            x = 0;
            //MessageBox.Show(DropDownList2.SelectedIndex.ToString());
            foreach (CustomerSite cs in customersites)
            {
                x++;
                DropDownList2.Items.Add(cs.SiteName);
                DropDownList2.Items[x].Value = cs.CustomerSiteId.ToString();
                if (DropDownList2.SelectedIndex.Equals(x))
                    DropDownList2.Items[x].Selected = true;
                else
                {
                    if (facilityid.Equals(cs.CustomerSiteId))
                    {
                        DropDownList2.ClearSelection();
                        DropDownList2.Items[x].Selected = true;
                        DropDownList2_SelectedIndexChanged(this, null);
                    }
                }
            }

            if (DropDownList2.SelectedIndex.Equals(0))
            {
                TList<TeacherSite> teachersatsite = DataRepository.TeacherSiteProvider.GetBySiteId(Convert.ToInt16(DropDownList2.SelectedValue));
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add("Select Coach");
                DropDownList1.Items[0].Value = "0";
                DropDownList1.Items[0].Selected = true;
            }

            base.OnPreRender(e);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {      
        
            facilityid = Convert.ToInt16(Request.QueryString.Get("facilityid"));
        
    }       

    

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        TList<TeacherSite> teachersatsite = DataRepository.TeacherSiteProvider.GetBySiteId(Convert.ToInt16(DropDownList2.SelectedValue));
        DropDownList1.Items.Clear();
        DropDownList1.Items.Add("Select Coach");
        DropDownList1.Items[0].Value = "0";
        DropDownList1.Items[0].Selected = false;
        int count = 0;
        foreach (TeacherSite tas in teachersatsite)
        {
            count++;
            teacher = DataRepository.TeacherProvider.GetByTeacherId(tas.TeacherId);
            DropDownList1.Items.Add(teacher.FirstName + " " + teacher.LastName);
            DropDownList1.Items[count].Value = teacher.TeacherId.ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string TeacherEmail = "";
        teacher = DataRepository.TeacherProvider.GetByTeacherId(Convert.ToInt16(DropDownList1.SelectedValue));
        Guid TeacherGuid = new Guid();
        TeacherGuid = teacher.AspnetMembershipUserId;
        MembershipUser TeacherUser = new MembershipUser("AspNetSqlMembershipProvider", null, null, null, null, null, true, true, System.DateTime.Now, System.DateTime.Now, System.DateTime.Now, System.DateTime.Now, System.DateTime.Now);
        TeacherUser = Membership.GetUser(TeacherGuid);
        TeacherEmail = TeacherUser.Email;

        MailAddress from = new MailAddress(TextBox3.Text);
        MailAddress to = new MailAddress(TeacherEmail);
        MailAddress ccFrom = new MailAddress(TextBox3.Text);
        MailAddress ccDev = new MailAddress("info@compusport.com");
        MailMessage message = new MailMessage(from, to);
        message.IsBodyHtml = true;

        message.Subject = TextBox1.Text;
        message.Body = FreeTextBox1.Text;
        //MessageBox.Show(message.Body);
        message.CC.Add(ccFrom);
        message.CC.Add(ccDev);

        Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
        MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
        SmtpClient client = new SmtpClient(settings.Smtp.Network.Host);
        try
        {
            client.Send(message);
            //Response.Write("Your Email has been sent sucessfully - Thank You");
            Label2.Visible = true;
        }
        catch (Exception ex)
        {
            //Response.Write("Send failure: " + ex.ToString());
            Label2.Text = "Send failure. Please try sending again. If the problem persists, please contact SwingModel.";
            Label2.Visible = true;
        }

    }
}
