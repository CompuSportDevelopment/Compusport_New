using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Web.Script.Serialization;
using System.Windows.Forms;
using SwfDotNet.IO;
using System.Drawing;
using CompuSportDAL;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;

public partial class PDF_File_HTML_FileToPDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            lblUserName.Text = Session["UserName"].ToString();
        }
        if (Session["Session Details"] != null)
        {
            lblSession.Text = Session["Session Details"].ToString();
        }
        if (Session["PageInfo"] !=null)
        {
            lblPageInfo.Text = Session["PageInfo"].ToString();
        }
        if (Session["ErrorList"] != null)
        {
            var sessionError = Session["ErrorList"].ToString().Split(',');
            for (int i = 0; i < sessionError.Length; i++)
            {
                ErrorList.Text += sessionError[i] + "<br />";
            }
        }
    }
    void sendNotFoundEmail(string message, string playerDetails)
    {
        var email = Membership.GetUser().Email;
        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
        msg.From = new System.Net.Mail.MailAddress(email);
        msg.To.Add("roshant@sveltoz.com");
        msg.Body = message;
        msg.Subject = "Compusport : " + playerDetails + " File Missing";
        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        smtp.Host = "smtpout.secureserver.net";
        smtp.Port = 25;
        smtp.Credentials = new System.Net.NetworkCredential("anandb@sveltoz.com", "Passw0rd1");
        smtp.Send(msg);

    }
}