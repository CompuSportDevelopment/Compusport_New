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
using System.IO;
using MemberDownload;
using SwingModel.Data;
using SwingModel.Entities;

public partial class MasterPages_MasterPageMain : System.Web.UI.MasterPage
{
    Guid MemGuid;
    Customer customer;
    Login Login1 = new Login();

    protected void Page_Init(object sender, EventArgs e)
    {
        if ((Request.UserAgent.IndexOf("AppleWebKit") > 0))
        {
            Request.Browser.Adapters.Clear();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            MembershipUser member = Membership.GetUser();
            customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(member.ProviderUserKey.ToString()))[0];
            string userName = customer.FirstName + " " + customer.LastName;
            Label2.Text = userName;
            Label2.Visible = true;
        }
        catch (Exception ex)
        {
            Label2.Visible = false;
        }
        //if (Request.UserAgent.IndexOf("AppleWebKit") > 0)//To detect the chrome browser version and get work mouse over effects of menus
        //{
        //    Request.Browser.Adapters.Clear();
        //}

        string URL = "";
        URL = Request.Url.AbsolutePath.ToLower();
        //MessageBox.Show("URL: " + URL);

        if (URL.Contains("users/myswing.aspx") || URL.Contains("users/fixaddto.aspx") || URL.Contains("admin/summaryplayer.aspx") || URL.Contains("teachers/summaryplayer.aspx")
            || URL.Contains("facility/summaryplayer.aspx"))
        {
            string sInclude = "http://code.jquery.com/jquery-1.11.0.min.js";
            sInclude = ResolveUrl(sInclude);
            HtmlGenericControl Include11 = new HtmlGenericControl("script");
            Include11.Attributes.Add("type", "text/javascript");
            Include11.Attributes.Add("src", sInclude);
            this.Page.Header.Controls.Add(Include11);

            //sInclude = "http://code.jquery.com/jquery-1.8.2.js";
            //sInclude = ResolveUrl(sInclude);
            //HtmlGenericControl Include12 = new HtmlGenericControl("script");
            //Include12.Attributes.Add("type", "text/javascript");
            //Include12.Attributes.Add("src", sInclude);
            //this.Page.Header.Controls.Add(Include12);

            //new
            sInclude = "http://code.jquery.com/jquery-1.11.1.min.js";
            sInclude = ResolveUrl(sInclude);
            HtmlGenericControl Include12 = new HtmlGenericControl("script");
            Include12.Attributes.Add("type", "text/javascript");
            Include12.Attributes.Add("src", sInclude);
            this.Page.Header.Controls.Add(Include12);
            //new end

            sInclude = "http://code.jquery.com/ui/1.10.3/jquery-ui.js";
            sInclude = ResolveUrl(sInclude);
            HtmlGenericControl Include13 = new HtmlGenericControl("script");
            Include13.Attributes.Add("type", "text/javascript");
            Include13.Attributes.Add("src", sInclude);
            this.Page.Header.Controls.Add(Include13);

            sInclude = "../Scripts/swfobject/swfobject.js";
            sInclude = ResolveUrl(sInclude);
            HtmlGenericControl Include = new HtmlGenericControl("script");
            Include.Attributes.Add("type", "text/javascript");
            Include.Attributes.Add("src", sInclude);
            this.Page.Header.Controls.Add(Include);



            sInclude = "../Scripts/mootools12.js";
            sInclude = ResolveUrl(sInclude);
            HtmlGenericControl Include2 = new HtmlGenericControl("script");
            Include2.Attributes.Add("type", "text/javascript");
            Include2.Attributes.Add("src", sInclude);
            this.Page.Header.Controls.Add(Include2);

            //sInclude = "../Scripts/player.js";
            //sInclude = ResolveUrl(sInclude);
            //HtmlGenericControl Include3 = new HtmlGenericControl("script");
            //Include3.Attributes.Add("type", "text/javascript");
            //Include3.Attributes.Add("src", sInclude);
            //this.Page.Header.Controls.Add(Include3);

        }
        HtmlLink cssF = new HtmlLink();
        HtmlLink cssIE1 = new HtmlLink();
        HtmlLink cssIE2 = new HtmlLink();
    }
    //void sendNotFoundEmail(DateTime LoginTime, DateTime logOutTime , string timeString )
    //{

    //    //var message = _initialMessage + _finalMessage;
    //    var message = "LogIn Time And Date =" + " " + " " + logOutTime + "\n" + "LogOut Time And Date =" + " " + " " + LoginTime + "\n" + "Total Time on the Site = "+ " " + timeString;
    //    var email = Membership.GetUser().Email;
    //    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
    //    msg.From = new System.Net.Mail.MailAddress(email);
    //    msg.To.Add("roshant@sveltoz.com");
    //    msg.Body = message;
    //    msg.Subject = "Compusport : " + customer.FirstName + "" + customer.LastName ;
    //    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
    //    smtp.Host = "smtpout.secureserver.net";
    //    smtp.Port = 25;
    //    smtp.Credentials = new System.Net.NetworkCredential("anandb@sveltoz.com", "Passw0rd1");
    //    smtp.Send(msg);
    //}

    //protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
    //{
    //    MembershipUser member = Membership.GetUser();
    //    var UserName = member.UserName;
    //    var LoginTime = member.LastActivityDate;
    //    var logOutTime = member.LastLoginDate;
    //    TimeSpan timeSpan = LoginTime.Subtract(logOutTime);
    //    string timeString =
    //        string.Format(
    //            "{0:00}:{1:00}:{2:00}",
    //            timeSpan.Hours,
    //            timeSpan.Minutes,
    //            timeSpan.Seconds
    //        );
    //    sendNotFoundEmail(LoginTime, logOutTime, timeString);
    //}
}
