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

//public partial class Users_ScheduleLesson : System.Web.UI.Page
public partial class Users_ScheduleLesson : SwingModel.UI.BasePage
{
    int x;
    Teacher teacher = new Teacher();
    int facilityid = -1;

    protected override void OnPreRender(EventArgs e)
    {
        //MessageBox.Show(Request.QueryString.Get("facilityid"));
        TList<CustomerSite> customersites = DataRepository.CustomerSiteProvider.GetAll();
        if (DropDownList8.SelectedIndex <= 0)
        {
            DropDownList8.Items.Clear();
            DropDownList8.Items.Add("Select Location");
            DropDownList8.Items[0].Value = "0";
        }
        if (DropDownList8.SelectedIndex <= 0)
        {
            if (facilityid.Equals(-1))
                DropDownList8.Items[0].Selected = true;
            else
            {
                DropDownList8.Items[0].Selected = false;
                DropDownList8.ClearSelection();
            }
        }
        x = 0;
        //MessageBox.Show(DropDownList2.SelectedIndex.ToString());
        if (DropDownList8.SelectedIndex <= 0)
        {
            foreach (CustomerSite cs in customersites)
            {
                x++;
                DropDownList8.Items.Add(cs.SiteName);
                DropDownList8.Items[x].Value = cs.CustomerSiteId.ToString();
                if (DropDownList8.SelectedIndex.Equals(x))
                    DropDownList8.Items[x].Selected = true;
                else
                {
                    if (facilityid.Equals(cs.CustomerSiteId))
                    {
                        DropDownList8.ClearSelection();
                        DropDownList8.Items[x].Selected = true;
                        DropDownList8_SelectedIndexChanged(this, null);
                        //MessageBox.Show(DropDownList2.SelectedIndex.ToString());
                    }
                }
            }
        }

        if (DropDownList8.SelectedIndex.Equals(0))
        {
            TList<TeacherSite> teachersatsite = DataRepository.TeacherSiteProvider.GetBySiteId(Convert.ToInt16(DropDownList8.SelectedValue));
            DropDownList9.Items.Clear();
            DropDownList9.Items.Add("Select Teacher");
            DropDownList9.Items[0].Value = "0";
            DropDownList9.Items[0].Selected = true;
        }

        if (TextBox2.Text.Equals("") || TextBox2.Text.Equals(null))
        {
            Label9.Text = "Please Select A Beginning Date";
            Label9.Visible = true;
        }
        else
            Label9.Visible = false;

        if (TextBox3.Text.Equals("") || TextBox3.Text.Equals(null))
        {
            Label10.Text = "Please Select An Ending Date";
            Label10.Visible = true;
        }
        else
            Label10.Visible = false;

        if (!TextBox3.Text.Equals("") && !TextBox3.Text.Equals(null) && TextBox2.Text.Equals("") && TextBox2.Text.Equals(null))
        {
            if (DateTime.Parse(TextBox3.Text) < DateTime.Parse(TextBox2.Text))
            {
                Label10.Text = "Date Cannot Be Earlier Than Beginning Date";
                Label10.Visible = true;
            }
        }

        if (TextBox5.Text.Equals("") || TextBox5.Text.Equals(null))
            Label12.Visible = true;
        else
            Label12.Visible = false;

        if (TextBox4.Text.Equals("") || TextBox4.Text.Equals(null))
            Label13.Visible = true;
        else
            Label13.Visible = false;

        base.OnPreRender(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        facilityid = Convert.ToInt16(Request.QueryString.Get("facilityid"));
    }

    protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
    {
        TList<TeacherSite> teachersatsite = DataRepository.TeacherSiteProvider.GetBySiteId(Convert.ToInt16(DropDownList8.SelectedValue));
        DropDownList9.Items.Clear();
        DropDownList9.Items.Add("Select Teacher");
        DropDownList9.Items[0].Value = "0";
        DropDownList9.Items[0].Selected = false;
        x = 0;
        foreach (TeacherSite tas in teachersatsite)
        {
            x++;
            teacher = DataRepository.TeacherProvider.GetByTeacherId(tas.TeacherId);
            DropDownList9.Items.Add(teacher.FirstName + " " + teacher.LastName);
            DropDownList9.Items[x].Value = teacher.TeacherId.ToString();
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        string TeacherEmail = "";
        teacher = DataRepository.TeacherProvider.GetByTeacherId(Convert.ToInt16(DropDownList9.SelectedValue));
        Guid TeacherGuid = new Guid();
        TeacherGuid = teacher.AspnetMembershipUserId;
        MembershipUser TeacherUser = new MembershipUser("AspNetSqlMembershipProvider", null, null, null, null, null, true, true, System.DateTime.Now, System.DateTime.Now, System.DateTime.Now, System.DateTime.Now, System.DateTime.Now);
        TeacherUser = Membership.GetUser(TeacherGuid);
        TeacherEmail = TeacherUser.Email;

        if (TextBox2.Text.Equals("") || TextBox2.Text.Equals(null) || TextBox3.Text.Equals("") || TextBox3.Text.Equals(null) || TextBox5.Text.Equals("") || TextBox5.Text.Equals(null) || TextBox4.Text.Equals("") || TextBox4.Text.Equals(null))
        {
            //One of the fields is empty
        }
        else
        {
            MailAddress from = new MailAddress(TextBox4.Text);
            MailAddress to = new MailAddress(TeacherEmail);
            MailAddress ccFrom = new MailAddress(TextBox4.Text);
            MailAddress ccDev = new MailAddress("info@compusport.com");
            MailMessage message = new MailMessage(from, to);
            message.IsBodyHtml = true;

            message.Subject = "SwingModel Lesson Appointment Request";
            message.Body = "The following lesson appointment request has been submitted through the SwingModel website.<br><br>"
                + "Name: " + TextBox5.Text + "<br>"
                + "Beginning Date: " + TextBox2.Text + "<br>"
                + "Ending Date: " + TextBox3.Text + "<br>"
                + "Start Time: " + DropDownList1.SelectedValue + "<br>"
                + "Lesson Hours: " + DropDownList2.SelectedValue + "<br><br>"
                + "Special Information:" + "<br><br>"
                + FreeTextBox1.Text;
            message.CC.Add(ccFrom);
            message.CC.Add(ccDev);

            Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
            SmtpClient client = new SmtpClient(settings.Smtp.Network.Host);
            try
            {
                client.Send(message);
                //Response.Write("Your Email has been sent sucessfully - Thank You");
                Label14.Visible = true;
            }
            catch (Exception ex)
            {
                //Response.Write("Send failure: " + ex.ToString());
                Label14.Text = "Send failure. Please try sending again. If the problem persists, please contact SwingModel.";
                Label14.Visible = true;
            }
        }
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        if (DateTime.Parse(TextBox2.Text) <= DateTime.Today)
        {
            Label9.Visible = true;
            TextBox2.Text = "";
        }
        else
        {
            Label9.Visible = false;
        }
    }

    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        if (DateTime.Parse(TextBox3.Text) <= DateTime.Today)
        {
            Label10.Visible = true;
            TextBox3.Text = "";
        }
        else
        {
            Label10.Visible = false;
            if (!TextBox2.Text.Equals("") && !TextBox2.Text.Equals(null))
            {
                if (DateTime.Parse(TextBox3.Text) < DateTime.Parse(TextBox2.Text))
                {
                    Label10.Text = "Date Cannot Be Earlier Than Beginning Date";
                    Label10.Visible = true;
                    TextBox3.Text = "";
                }
            }
            else
            {
                Label10.Visible = false;
            }
        }
    }
}
