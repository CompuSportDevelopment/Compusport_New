using System;
using System.Collections.Generic;
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
using SwingModel.Data.SqlClient;
using SwingModel.Entities;
using CompuSportDataAccess;
using System.Data;
//using mojoPortal.Business;
//using mojoPortal.Business.WebHelpers;
//using mojoPortal.Web;
//using compusport.Data;
//using compusport.Entities;

public partial class TrackData_BodyDimensions : System.Web.UI.UserControl
{
    //SiteUser currentUser;
    //MpUsers mpuser;
    //TList<MpUserRoles> athletelist = new TList<MpUserRoles>();
    //TList<MpUsers> userslist = new TList<MpUsers>();
    //MpUsers athlete;
    TList<Lesson> lessonlist = new TList<Lesson>();
    //AthleteBodyDimensions abd;
    //TList<Teacher> teachers = new TList<Teacher>();
    TList<Customer> customers = new TList<Customer>();
    Customer customer = new Customer();
    CustomerProfile customerprofile = new CustomerProfile();
    CountryLookup countrylookup = new CountryLookup();
    CustomerSite customersite = new CustomerSite();
    Teacher teacher = new Teacher();
    Customer teacherc = new Customer();
    CustomerProfile teachercp = new CustomerProfile();
    int x;
    AthleteBodyDimensions athletebodydimensions = new AthleteBodyDimensions();
    DataTable abd = new DataTable();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            int x = 0;
            customers = DataRepository.CustomerProvider.GetAll();
            foreach (var item in customers)
            {

                x++;
                DropDownList1.Items.Add(item.FirstName + " " + item.LastName);
                DropDownList1.Items[x].Value = item.CustomerId.ToString();
                continue;
            }
        }
       
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!DropDownList1.SelectedValue.Equals("noathlete"))
        {
            abd = athletebodydimensions.GetAllBodyDimensionsBycustomerid(Convert.ToInt32(DropDownList1.SelectedValue));
            if (!abd.Rows.Count.Equals(0))
            {
                TextBox1.Text = abd.Rows[0]["Height"].ToString();
                TextBox2.Text = abd.Rows[0]["Waist"].ToString();
                TextBox3.Text = abd.Rows[0]["HipHeight"].ToString();
                TextBox4.Text = abd.Rows[0]["UpperLegLength"].ToString();
                TextBox5.Text = abd.Rows[0]["LowerLegLength"].ToString();
                TextBox6.Text = abd.Rows[0]["AnkleHeight"].ToString();
                TextBox7.Text = abd.Rows[0]["ShoeSize"].ToString();
                TextBox8.Text = abd.Rows[0]["TrunkLength"].ToString();
                TextBox9.Text = abd.Rows[0]["UpperArmLength"].ToString();
                TextBox10.Text = abd.Rows[0]["LowerArmLength"].ToString();
                TextBox11.Text = abd.Rows[0]["ShoulderWidth"].ToString();
                TextBox12.Text = abd.Rows[0]["EnterVelocity"].ToString();
                TextBox13.Text = abd.Rows[0]["EnterStartVelocity"].ToString();
               
            }
            else
            {
                Emptydata();
            }
        }
        else
        {
            Emptydata();

        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int x;
        AthleteBodyDimensions abdA = new AthleteBodyDimensions();

        abdA.AthleteUserId = Convert.ToInt32(DropDownList1.SelectedValue);
        abdA.Height = Convert.ToDecimal(TextBox1.Text);
        abdA.Waist = Convert.ToDecimal(TextBox2.Text);
        abdA.HipHeight = Convert.ToDecimal(TextBox3.Text);
        abdA.UpperLegLength = Convert.ToDecimal(TextBox4.Text);
        abdA.LowerLegLength = Convert.ToDecimal(TextBox5.Text);
        abdA.AnkleHeight = Convert.ToDecimal(TextBox6.Text);
        abdA.ShoeSize = Convert.ToDecimal(TextBox7.Text);
        abdA.TrunkLength = Convert.ToDecimal(TextBox8.Text);
        abdA.UpperArmLength = Convert.ToDecimal(TextBox9.Text);
        abdA.LowerArmLength = Convert.ToDecimal(TextBox10.Text);
        abdA.ShoulderWidth = Convert.ToDecimal(TextBox11.Text);
        abdA.EnterVelocity = Convert.ToDecimal(TextBox12.Text);
        abdA.EnterStartVelocity = Convert.ToDecimal(TextBox13.Text);

        if (abd.Rows.Count.Equals(0))
        { 
        x = abdA.Insert_ABD();
          Response.Write("<script>alert('Athlete body dimnesions data has been inserted successfully.');</script>");
        }
        else
        {
          x = abdA.Update_ABD();
          Response.Write("<script>alert('Athlete body dimnesions data has been Updated successfully.');</script>");
        }
        Emptydata();
        DropDownList1.SelectedValue = "noathlete";
    }
    private void Emptydata()
    {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";
    }
}
