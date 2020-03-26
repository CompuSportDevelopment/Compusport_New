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
using System.Windows.Forms;
using SwingModel.Data;
using SwingModel.Entities;
using System.Data.SqlClient;
using System.Text;
using System.Net.Mail;
using System.Globalization;


//public partial class login : System.Web.UI.Page
public partial class login : SwingModel.UI.BasePage
{
    Guid MemGuid;
    Customer customer;
    Teacher teacher;
    CompuSportDAL.SprintAthleteEdit _sprintAthleteEdit = new CompuSportDAL.SprintAthleteEdit();

    protected void Login1_OnLoginError(object sender, EventArgs e)
    {
        try
        {

            MembershipUser member = Membership.GetUser(Login1.UserName);
            if (!member.IsApproved)
                Response.Redirect("http://www.swingmodel.com/Shop/PayRenewal.aspx?Username=" + Login1.UserName);
        }
        catch (Exception ex)
        {
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        // Manually redirect to DestinationPageUrl as Framework doesn't give property precedence over the
        // referring page (ReturnUrl), which it should, according to Login.DestinationPageUrl documentation

        string RetURL = "";
        Guid rollid = new Guid();       
        try
        {          
            MembershipUser member = Membership.GetUser(Login1.UserName);
            try
            {
                customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(member.ProviderUserKey.ToString()))[0];
                MemGuid = new Guid(customer.AspnetMembershipUserId.ToString());
            }
            catch
            {                
                teacher = DataRepository.TeacherProvider.GetByAspnetMembershipUserId(new Guid(member.ProviderUserKey.ToString()))[0];
                MemGuid = new Guid(teacher.AspnetMembershipUserId.ToString());
            }

            rollid = _sprintAthleteEdit.GetRollIdByUserId(MemGuid);
            if (rollid.ToString().Trim().ToUpper() == "3C195D36-1032-4CF9-A383-757A2EC5BEA2")//Administrators
            {
                //RetURL = Request.QueryString.Get("ReturnUrl").ToLower();
                RetURL = "~/Users/Default.aspx";
            }
            else if (rollid.ToString().Trim().ToUpper() == "6B5A6229-1751-436C-A419-8196D6E8170B")//Facility Administrators
            {
                RetURL = "~/Users/Default.aspx";
            }
            else if (rollid.ToString().Trim().ToUpper() == "D27F6DE3-A8D4-492E-B154-CF1BC5B44129")//Golfer
            {
                RetURL = "~/Users/Default.aspx";
            }
            else if (rollid.ToString().Trim().ToUpper() == "A7DF4248-034A-4900-8D69-F914BCE9396D")//Teacher(Coach)
            {
                RetURL = "~/Users/Default.aspx";
            }            
            //MessageBox.Show("RetURL: " + RetURL);
        }
        catch (Exception ex)
        {

        }

        if (RetURL.Contains("users"))
        {
            //do nothing, keep ReturnUrl
        }
        else
            Response.Redirect(ResolveClientUrl(RetURL));
    }
    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        //SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        string name;
        string str = Convert.ToString(txtusername.Text);
        name = str.Replace(" ", "_");

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ToString()))
        {
            if (!txtusername.Text.Equals("") && !txtusername.Text.Equals(null))
            {
                try
                {
                    int temp = 0;
                    //cmd = new SqlCommand("select * from [Compusport_new].[dbo].[aspnet_Users] where UserName='" + str + "'", con);
                    cmd = new SqlCommand("select * from [NewCompuSportdb_LIVE_dev].[dbo].[aspnet_Users] where UserName='" + str + "'", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        temp = 1;

                        //Label8.Text = "Your email address has been changed successfully.";
                        //Label8.Visible = true;
                    }
                    dr.Close();
                    if (temp == 1)
                    {
                        Guid g;
                        g = Guid.NewGuid();

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("<br/>Hello&nbsp;" + str);
                        sb.Append("<br/>");
                        sb.Append("<br/> You have requested a new password for your CompuSport account.  To enter a new password, click on the link below:<br/>");
                        sb.Append("<br/>");

                        sb.Append("<a href=http://localhost/CompuSport/ResetPassword.aspx?Email=" + GetUserEmail(txtusername.Text));
                        sb.Append("&guid=" + g);
                        sb.Append("&UserName=" + name + " >Click here to change your password</a><br/>");


                        sb.Append("<br/>If you have not requested a password change, simply ignore this email and your password will remain the same.<br/>");

                        sb.Append("<br/>Thanks<br/>");

                        sb.Append("<br/>CompuSport Support<br/>");

                        string To = GetUserEmail(txtusername.Text);

                        SqlCommand cmd1 = new SqlCommand("update [NewCompuSportdb_LIVE_dev].[dbo].[aspnet_Membership] set EmailLinkKey = '" + g + "' where Email = '" + To + "'", con);
                        cmd1.ExecuteNonQuery();

                        //"&Username=" + txtusername.Text + "
                        MailMessage message = new System.Net.Mail.MailMessage("chirags@sveltoz.com", To, "Reset Your Password", sb.ToString());

                        SmtpClient smtp = new SmtpClient();

                        smtp.Host = "smtp.secureserver.net";
                        
                        smtp.Port = 25;
                                                
                        smtp.Credentials = new System.Net.NetworkCredential("chirags@sveltoz.com", "");

                        smtp.EnableSsl = false;

                        message.IsBodyHtml = true;

                        smtp.Send(message);
                                                
                        lblsuccess.Text = "Information on changing your password has been sent to your Member email address!";

                    }
                    else
                    {
                        Label8.Text = "Your UserName Is not valid!";
                        Label8.Visible = true;
                    }

                }
                catch (Exception ex)
                {

                }

            }
        }
    }


    private string GetUserEmail(string UserName)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ToString()))
        {
            SqlCommand cmd = new SqlCommand("select m.Email from [NewCompuSportdb_LIVE_dev].[dbo].[aspnet_Users] u join [NewCompuSportdb_LIVE_dev].[dbo].[aspnet_Membership] m on u.UserId = m.UserId and u.UserName='" + UserName + "'", con);

            con.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            //string To = reader.Equals("Email");

            //string username = cmd.ExecuteScalar().ToString();
            string Email = cmd.ExecuteScalar().ToString();
            return Email;

        }

    }
    
}
