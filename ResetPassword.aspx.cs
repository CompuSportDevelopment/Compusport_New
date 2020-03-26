using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Globalization;

public partial class ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       if (!Page.IsPostBack)
       {
            string name = Request.QueryString["UserName"];
            name = name.Replace("_"," ");
            txtUserName.Text = name;
            string v = Request.QueryString["Email"];
            string g = Request.QueryString["guid"];
            string Email = "";
            Boolean IsActive = false;
            if (v != null)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ToString()))
                {     
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("select EmailLinkKey,IsActive from [NewCompuSportdb_LIVE_dev].[dbo].[aspnet_Membership] where Email='" + v + "'", con);
                    //cmd1.ExecuteNonQuery();

                    //SqlCommand comm = new SqlCommand("SELECT EmailLinkKey,IsActive FROM [Swing1].[dbo].[aspnet_Membership]", con);
                    SqlDataReader reader = cmd1.ExecuteReader();
                    // if (reader.HasRows)
                    // {
                    while (reader.Read())
                    {
                        try
                        {
                            //string val2 = reader.GetString(1);
                            Email = reader[0].ToString();
                            if (string.IsNullOrEmpty(reader[1].ToString()))
                            {
                                IsActive = false;
                            }
                            else
                            {
                                IsActive = Convert.ToBoolean(reader[1]);
                            }
                            //reader.Close();

                            // }
                        }
                        catch (Exception ex)
                        {
                        }



                        // }


                    }
                    reader.Close();
                    if (Email == g && IsActive == false)
                    {

                        SqlCommand cmd = new SqlCommand("update [NewCompuSportdb_LIVE_dev].[dbo].[aspnet_Membership] set IsActive = 1 where Email= '" + v + "'", con);
                        cmd.ExecuteNonQuery();

                    }
                    else
                    {
                        //Response.Redirect("~/LinkExpired.aspx");

                    }


                    MyHyperLinkControl.Visible = false;
                   
                }
            }
        }
        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        string str = Convert.ToString(txtUserName.Text);
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ToString()))
        {
            if(!txtUserName.Text.Equals("") && !txtUserName.Text.Equals(null))
            {
                try
                {

                    int temp = 0;
                    //SqlCommand cmd1 = new SqlCommand("update [Swing1].[dbo].[aspnet_Membership] set IsActive = 1 where UserName='" + str + "'", con);
                    cmd = new SqlCommand("select * from [NewCompuSportdb_LIVE_dev].[dbo].[aspnet_Users] where UserName='" + str + "'", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        temp = 1;
                        
                    }
                                        
                    if (temp == 1)
                    {
                        MembershipUser member = Membership.GetUser(txtUserName.Text);
                        //byte[] encdata_byte = new byte[txtNewPwd.Text.Length];
                        //encdata_byte = System.Text.Encoding.UTF8.GetBytes(txtNewPwd.Text);
                        //string encodeddata = Convert.ToBase64String(encdata_byte);
                        member.ChangePassword(member.ResetPassword(), txtNewPwd.Text);
                                               
                        lblsuccess.Text = "Successfully Reset Password!";
                        //Response.Redirect("~/login.aspx");
                        MyHyperLinkControl.Visible = true;
                        lblStatus.Visible = false;
                        txtUserName.Text = "";
                    }
                    else
                    {
                        lblStatus.Text = "Your UserName Is not valid!";
                        lblStatus.Visible = true;
                        MyHyperLinkControl.Visible = false;
                        lblsuccess.Visible = false;
                        txtUserName.Text = "";
                    }

                }
                catch (Exception ex)
                {

                }
            }
        }

    }

}

