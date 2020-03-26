using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mail;
using System.Net.Mail;

public partial class EmailForVideo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HandleAjaxEvent();
    }
    private void HandleAjaxEvent()
    {
        byte[] buffer = new byte[Request.InputStream.Length];
        Request.InputStream.Read(buffer, 0, buffer.Length);
        string request__1 = System.Text.Encoding.ASCII.GetString(buffer);

        Response.Clear();

        if (request__1.StartsWith("AJAX:"))
        {
            request__1 = request__1.Substring("AJAX:".Length);

            string[] selectedIDStr = request__1.Split(',');
            string requestItem = selectedIDStr[0];
            string fileName = selectedIDStr[1];
            SmtpMail.SmtpServer = "localhost";
            //SmtpMail.Send("dev@swingmodel.com", "dev@swingmodel.com", " Email notification for video request", "Video request from user : " + requestItem + " Video name: "+ fileName );

            //switch (requestItem)
            //{
            //    case ("ActiveDeactiveCustomer"):
            //        UpdateCustomerIsActive(CustomerID, IsActive);
            //        Response.Write(IsActive);
            //        break; // TODO: might not be correct. Was : Exit Select

            //        break;
            //}
        }
        Response.End();
    }
}
