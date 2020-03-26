using System;
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
using System.Windows.Forms;
using SwingModel.Data;
using System.IO;
using SwingModel.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using CompuSportDAL;
using System.Web.Configuration;


public partial class Controls_RelayAthleteEdit : System.Web.UI.UserControl
{
    int x;    
    public Customer customerid;
    public Customer cust;
    
    public CustomerProfile customerprofile;
    TList<Customer> customer = new TList<Customer>();
    
    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    //CompuSportDAL.HurdleData rd = new CompuSportDAL.HurdleData();
    //CompuSportDAL.HurdleData _hurdledata = new CompuSportDAL.HurdleData();
    CompuSportDAL.HurdleData rd = new CompuSportDAL.HurdleData();
    
    

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        bool AthleteAlreadyInList = false;
        customerid = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
        customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customerid.CustomerId)[0];

        if (!IsPostBack)
        {
            customer = DataRepository.CustomerProvider.GetAll();
            customer.Sort("FirstName");
            foreach (var item in customer)
            {
                cust = DataRepository.CustomerProvider.GetByCustomerId(item.CustomerId);
                {
                    if (DropDownList1.Items.Count > 0)
                    {
                        if (DropDownList1.Items.Contains(DropDownList1.Items.FindByValue(item.CustomerId.ToString())))
                            AthleteAlreadyInList = true;
                        else
                            AthleteAlreadyInList = false;
                    }

                    if (!AthleteAlreadyInList)
                    {
                        x++;
                        DropDownList1.Items.Add(item.FirstName + " " + item.LastName);
                        DropDownList1.Items[x].Value = item.CustomerId.ToString();

                        continue;
                    }
                }
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                string connection = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

                int flag = Convert.ToInt32(ViewState["flag"].ToString());

                if (flag == 1)
                {
                    using (SqlConnection con = new SqlConnection(connection))
                    {
                        con.Open();
                        SqlCommand cmdInsert = new SqlCommand("InsertIntoRelayDate", con);

                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.Parameters.AddWithValue("@CustomerID", DropDownList1.SelectedItem.Value);
                        cmdInsert.Parameters.AddWithValue("@RelayVelocityIn", Convert.ToDecimal(lblRelayVelocityIn.Text));
                        cmdInsert.Parameters.AddWithValue("@RelayVelocityOut", Convert.ToDecimal(lblRelayVelocityOut.Text));
                        cmdInsert.Parameters.AddWithValue("@RelayStart", Convert.ToDecimal(lblRelayStart.Text));
                        cmdInsert.Parameters.AddWithValue("@MeterTime", Convert.ToDecimal(lblMeterTime.Text));

                        if (Convert.ToBoolean(cmdInsert.ExecuteNonQuery()))
                        {
                            Message.ForeColor = System.Drawing.Color.Red;
                            Message.Text = "Data Stored Successfully...";
                            //lblRelayVelocityIn.Text = "";
                            //lblRelayVelocityOut.Text = "";
                            //lblRelayStart.Text = "";
                            //lblMeterTime.Text = "";
                        }
                        else
                        {
                            Message.ForeColor = System.Drawing.Color.Red;
                            Message.Text = "Data Saving Error...";
                        }
                    }

                }
                else
                {
                    using (SqlConnection con = new SqlConnection(connection))
                    {
                        con.Open();
                        SqlCommand cmdUpdate = new SqlCommand("UpdateRelayData", con);

                        cmdUpdate.CommandType = CommandType.StoredProcedure;

                        cmdUpdate.Parameters.AddWithValue("@CustomerID", DropDownList1.SelectedItem.Value);
                        cmdUpdate.Parameters.AddWithValue("@RelayVelocityIn", Convert.ToDecimal(lblRelayVelocityIn.Text));
                        cmdUpdate.Parameters.AddWithValue("@RelayVelocityOut", Convert.ToDecimal(lblRelayVelocityOut.Text));
                        cmdUpdate.Parameters.AddWithValue("@RelayStart", Convert.ToDecimal(lblRelayStart.Text));
                        cmdUpdate.Parameters.AddWithValue("@MeterTime", Convert.ToDecimal(lblMeterTime.Text));

                        int result = Convert.ToInt32(cmdUpdate.ExecuteNonQuery());
                        if (result < 0)
                        {
                            Message.ForeColor = System.Drawing.Color.Red;
                            Message.Text = "Data Updated Successfully...";
                            //lblRelayVelocityIn.Text = "";
                            //lblRelayVelocityOut.Text = "";
                            //lblRelayStart.Text = "";
                            //lblMeterTime.Text = "";
                        }
                        else
                        {
                            Message.ForeColor = System.Drawing.Color.Red;
                            Message.Text = "Data Updating Error...";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else
        {
            Message.Text = "Please Fill the item...";
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{
            Message.Text = "";
            Label117.Text = "";

            string connection = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand sqlcmd = new SqlCommand("GenderIdentify", conn);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@custID", DropDownList1.SelectedValue);
            sqlcmd.Parameters.AddWithValue("@isset", 0);
            sqlcmd.Parameters["@isset"].Direction = ParameterDirection.Output;

            sqlcmd.ExecuteNonQuery();
            int result = Convert.ToInt32(sqlcmd.Parameters["@isset"].Value);


            if (result == 1)
            {
                //Label117.Text = "Please Set Gender of the Athlete from Input Athlete Account Data Page!";
                //Response.Write("<script>alert('Please Set Gender of the Athlete from Input Athlete Account Data Page!')</script>");
                string stralert = "alert('Please set the Gender from Input Athlete Account Data Page.')";
                //ScriptManager.RegisterStartupScript(this, GetType(), "Please Set Gender", "showAlert()",true);
                ScriptManager.RegisterStartupScript(this, GetType(), "Please Set Gender", stralert, true);

            }
            else
            {

                if (!DropDownList1.SelectedValue.Equals("noathlete"))
                {
                    lblRelayVelocityIn.Text = "";
                    lblRelayVelocityOut.Text = "";
                    lblRelayStart.Text = "";
                    lblMeterTime.Text = "";
                }
                //string connection = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
                SqlConnection con = new SqlConnection(connection);
                String str1 = "select * from Input_RelayData where CustomerID=" + DropDownList1.SelectedValue;
                SqlCommand cmd = new SqlCommand(str1, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {

                    ViewState["flag"] = "0";

                    if (dr.Read() == true)
                    {
                        lblRelayVelocityIn.Text = dr[1].ToString();
                        lblRelayVelocityOut.Text = dr[2].ToString();
                        lblRelayStart.Text = dr[3].ToString();
                        lblMeterTime.Text = dr[4].ToString();
                    }
                }
                else
                {
                    lblRelayVelocityIn.Text = string.Empty;
                    lblRelayVelocityOut.Text = string.Empty;
                    lblRelayStart.Text = string.Empty;
                    lblMeterTime.Text = string.Empty;
                    ViewState["flag"] = "1";


                }
            }

        
        //else
        //{
        //    //Message.Text = "Please Select The Value";
        //    ScriptManager.RegisterStartupScript(this, GetType(), "Please Select Gender", "ShowEmptyAlert()", true);
        //    //ValidateDropDown()
        //}
    }    
}
