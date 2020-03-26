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


public partial class Teachers_CoachAthleteRelayData : System.Web.UI.Page
{
    SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    
    //List<string> l1 = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["dd1PassComplete"] = "";
            ViewState["ddlPassTime"] = "";


            ViewState["dd1Name1"] = "";
            ViewState["dd1Name2"] = "";

            ViewState["dd2Name1"] = "";
            ViewState["dd2Name2"] = "";

            ViewState["dd3Name1"] = "";
            ViewState["dd3Name2"] = "";

            ViewState["dd4Name1"] = "";
            ViewState["dd4Name2"] = "";

        

            ViewState["Final1"] = "";
            ViewState["Final2"] = "";

            ViewState["ThirdTableResult2"] = "";
            ViewState["ThirdTableResult4"] = "";


            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;
            txtname.Enabled = false;
            txtname1.Enabled = false;
            txtrmv.Enabled = false;
            txtrmv1.Enabled = false;
            txtrst.Enabled = false;
            txtrst1.Enabled = false;
            txtrzv.Enabled = false;
            txtrzv1.Enabled = false;
           
        }

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex != 0)
        {
            DropDownList2.Enabled = true;
            DropDownList3.Enabled = true;

            txtname.Enabled = true;
            txtname1.Enabled = true;
            txtrmv.Enabled = true;
            txtrmv1.Enabled = true;
            txtrst.Enabled = true;
            txtrst1.Enabled = true;
            txtrzv.Enabled = true;
            txtrzv1.Enabled = true;
          

            ViewState["dd1PassComplete"] = "";
            ViewState["ddlPassTime"] = "";
            ViewState["dd1Name1"] = "";
            ViewState["dd1Name2"] = "";

            ViewState["dd2Name1"] = "";
            ViewState["dd2Name2"] = "";

            ViewState["dd3Name1"] = "";
            ViewState["dd3Name2"] = "";

            ViewState["dd4Name1"] = "";
            ViewState["dd4Name2"] = "";

            ViewState["Final1"] = "";
            ViewState["Final2"] = "";

            ViewState["ThirdTableResult2"] = "";
            ViewState["ThirdTableResult4"] = "";

        }
        else
        {
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;

            txtname.Enabled = false;
            txtname1.Enabled = false;
            txtrmv.Enabled = false;
            txtrmv1.Enabled = false;
            txtrst.Enabled = false;
            txtrst1.Enabled = false;
            txtrzv.Enabled = false;
            txtrzv1.Enabled = false;
           
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedItem.Value == "0")
        {
            ViewState["dd1PassComplete"] = "10";
        }
        else
        {
            ViewState["dd1PassComplete"] = DropDownList2.SelectedItem.Value;
        }               
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedItem.Value == "0.4")
        {
            ViewState["ddlPassTime"] = "0.4";
        }
        else
        {
            ViewState["ddlPassTime"] = DropDownList3.SelectedItem.Value;
        }

     }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if(Page.IsValid)
        {
            string connection = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            {
                using (SqlConnection scon = new SqlConnection(connection))
                {
                    scon.Open();
                    SqlCommand scmdInsert = new SqlCommand("Insert_into_CoachAthleteRelay", scon);
                    scmdInsert.CommandType = CommandType.StoredProcedure;
                    scmdInsert.Parameters.AddWithValue("@Relay", DropDownList1.SelectedItem.Text);
                    scmdInsert.Parameters.AddWithValue("@PassCompletionPosition", DropDownList2.SelectedItem.Text);
                    scmdInsert.Parameters.AddWithValue("@PassTimeQuality", DropDownList3.SelectedItem.Text);
                    scmdInsert.Parameters.AddWithValue("@AthleteOneName", txtname.Text);
                    scmdInsert.Parameters.AddWithValue("@AthleteOneRMV", txtrmv.Text);
                    scmdInsert.Parameters.AddWithValue("@AthleteOneRZV", txtrzv.Text);
                    scmdInsert.Parameters.AddWithValue("@AthleteOneRST", txtrst.Text);
                    scmdInsert.Parameters.AddWithValue("@AthleteTwoName", txtname1.Text);
                    scmdInsert.Parameters.AddWithValue("@AthleteTwoRMV", txtrmv1.Text);
                    scmdInsert.Parameters.AddWithValue("@AthleteTwoRZV", txtrzv1.Text);
                    scmdInsert.Parameters.AddWithValue("@AthleteTwoRST", txtrst1.Text);
                    scmdInsert.ExecuteNonQuery(); 
                    scon.Close();
                }
            }
        }
       sconn.Open();

       if (DropDownList1.SelectedValue != "0")
       {
           ViewState["dd1Name1"] = txtname.Text;
           ViewState["dd1Name2"] = txtname1.Text;

           ViewState["dd2Name1"] = Convert.ToDecimal(txtrmv.Text).ToString("#0.00");
           ViewState["dd2Name2"] = Convert.ToDecimal(txtrmv1.Text).ToString("#0.00");

           ViewState["dd3Name1"] = Convert.ToDecimal(txtrzv.Text).ToString("#0.00");
           ViewState["dd3Name2"] = Convert.ToDecimal(txtrzv1.Text).ToString("#0.00");

           ViewState["dd4Name1"] = Convert.ToDecimal(txtrst.Text).ToString("#0.00");
           ViewState["dd4Name2"] = Convert.ToDecimal(txtrst1.Text).ToString("#0.00");

           /////////////////////////////////////////
           string demo1, demo2;

           if (DropDownList2.SelectedItem.Value == "10")
               demo1 = "10";
           else
           {
               ViewState["dd1PassComplete"] = DropDownList2.SelectedValue;
               demo1 = DropDownList2.SelectedValue;
           }
           if (DropDownList3.SelectedItem.Value == "0.4")
               demo2 = "0.4";
           else
           {
               ViewState["ddlPassTime"] = DropDownList3.SelectedValue;
               demo2 = DropDownList3.SelectedValue;
           }

            /////////////////////////////////////////////////////
            
           
            // Formula for First Exchange:
            
            ViewState["temp1"] = (Convert.ToDecimal(DropDownList2.SelectedValue.ToString()) - Convert.ToDecimal("10"));
            ViewState["temp2"] = ((((((Convert.ToDecimal("1.182") * Convert.ToDecimal(DropDownList2.SelectedValue.ToString())) +
                Convert.ToDecimal("11.82")) / Convert.ToDecimal("2")) + Convert.ToDecimal("90.373")) /
                Convert.ToDecimal("100")) * Convert.ToDecimal(ViewState["dd3Name2"].ToString()));

            ViewState["temp3"] = (Convert.ToDecimal(ViewState["temp1"].ToString()) / Convert.ToDecimal(ViewState["temp2"].ToString()));
            ViewState["temp4"] = (Convert.ToDecimal(ViewState["dd4Name2"].ToString()) + Convert.ToDecimal(ViewState["temp3"].ToString()) - Convert.ToDecimal(DropDownList3.SelectedValue.ToString()));

            ViewState["Equ1"] = (Convert.ToDecimal(ViewState["temp4"].ToString()) * Convert.ToDecimal(ViewState["dd2Name1"].ToString()));

            ViewState["temp5"] = ((((((Convert.ToDecimal("1.182") * Convert.ToDecimal(DropDownList2.SelectedValue.ToString())) +
                Convert.ToDecimal("11.82")) / Convert.ToDecimal("2")) + Convert.ToDecimal("90.373")) /
                Convert.ToDecimal("100")) * Convert.ToDecimal(ViewState["dd3Name2"].ToString()));

            ViewState["temp6"] = (Convert.ToDecimal(DropDownList3.SelectedValue.ToString()) * Convert.ToDecimal(ViewState["temp5"].ToString()));
            ViewState["Equ2"] = (Convert.ToDecimal("10") + Convert.ToDecimal(DropDownList2.SelectedValue.ToString()) - Convert.ToDecimal("1") - Convert.ToDecimal(ViewState["temp6"].ToString()));

            ViewState["Final1"] = Math.Round((Convert.ToDecimal(ViewState["Equ1"].ToString()) - Convert.ToDecimal(ViewState["Equ2"].ToString())), 2);
           ///////////////////////////////////////////////////////////


           //Formula For Second Exchange:

            ViewState["temp1"] = (Convert.ToDecimal(DropDownList2.SelectedValue.ToString()) - Convert.ToDecimal("10"));
            ViewState["temp2"] = ((((((Convert.ToDecimal("1.182") * Convert.ToDecimal(DropDownList2.SelectedValue.ToString())) +
                Convert.ToDecimal("11.82")) / Convert.ToDecimal("2")) + Convert.ToDecimal("90.373")) /
                Convert.ToDecimal("100")) * Convert.ToDecimal(ViewState["dd3Name1"].ToString()));
                      
            ViewState["temp3"] = (Convert.ToDecimal(ViewState["temp1"].ToString()) / Convert.ToDecimal(ViewState["temp2"].ToString()));
            ViewState["temp4"] = (Convert.ToDecimal(ViewState["dd4Name1"].ToString()) + Convert.ToDecimal(ViewState["temp3"].ToString()) - Convert.ToDecimal(DropDownList3.SelectedValue.ToString()));

            ViewState["Equ1"] = (Convert.ToDecimal(ViewState["temp4"].ToString()) * Convert.ToDecimal(ViewState["dd2Name2"].ToString()));
            
            ViewState["temp5"] = ((((((Convert.ToDecimal("1.182") * Convert.ToDecimal(DropDownList2.SelectedValue.ToString())) +
                Convert.ToDecimal("11.82")) / Convert.ToDecimal("2")) + Convert.ToDecimal("90.373")) /
                Convert.ToDecimal("100")) * Convert.ToDecimal(ViewState["dd3Name1"].ToString()));

            ViewState["temp6"] = (Convert.ToDecimal(DropDownList3.SelectedValue.ToString()) * Convert.ToDecimal(ViewState["temp5"].ToString()));
            ViewState["Equ2"] = (Convert.ToDecimal("10") + Convert.ToDecimal(DropDownList2.SelectedValue.ToString()) - Convert.ToDecimal("1") - Convert.ToDecimal(ViewState["temp6"].ToString()));
            ViewState["Final2"] = Math.Round((Convert.ToDecimal(ViewState["Equ1"].ToString()) - Convert.ToDecimal(ViewState["Equ2"].ToString())), 2);
                                 
           ViewState["temp2"] = ((((Convert.ToDecimal("1.182") * ((Convert.ToDecimal(DropDownList2.SelectedValue.ToString()) +
                                Convert.ToDecimal("20.00")) / Convert.ToDecimal("2"))) + Convert.ToDecimal("90.373")) /
                                Convert.ToDecimal("100")) * (Convert.ToDecimal(ViewState["dd3Name2"].ToString()) * (Convert.ToDecimal("1.07"))));
            ViewState["ThirdTableResult2"] = Math.Round((((Convert.ToDecimal(DropDownList2.SelectedValue.ToString()) - Convert.ToDecimal("0.5")) / (((Convert.ToDecimal(ViewState["dd2Name1"].ToString())) *

                (Convert.ToDecimal("1.07"))) * (Convert.ToDecimal("0.98"))))
                + ((Convert.ToDecimal("20.00") - Convert.ToDecimal(DropDownList2.SelectedValue.ToString()) - Convert.ToDecimal("0.5")) / (Convert.ToDecimal(ViewState["temp2"].ToString())))), 2);

            ViewState["temp2"] = ((((Convert.ToDecimal("1.182") * ((Convert.ToDecimal(DropDownList2.SelectedValue.ToString()) +
                  Convert.ToDecimal("20.00")) / Convert.ToDecimal("2"))) + Convert.ToDecimal("90.373")) /
                  Convert.ToDecimal("100")) * (Convert.ToDecimal(ViewState["dd4Name2"].ToString()) * (Convert.ToDecimal("1.07"))));
            ViewState["ThirdTableResult4"] = Math.Round((((Convert.ToDecimal(DropDownList2.SelectedValue.ToString()) - Convert.ToDecimal("0.5")) / (((Convert.ToDecimal(ViewState["dd3Name1"].ToString())) *

                (Convert.ToDecimal("1.07"))) * (Convert.ToDecimal("0.98"))))
                + ((Convert.ToDecimal("20.00") - Convert.ToDecimal(DropDownList2.SelectedValue.ToString()) - Convert.ToDecimal("0.5")) / (Convert.ToDecimal(ViewState["temp2"].ToString())))), 2);


                ViewState["dd1PassComplete"] = DropDownList2.SelectedItem.Value;
                ViewState["ddlPassTime"] = DropDownList3.SelectedItem.Value;
               

            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;

            txtname.Enabled = false;
            txtname1.Enabled = false;
            txtrmv.Enabled = false;
            txtrmv1.Enabled = false;
            txtrst.Enabled = false;
            txtrst1.Enabled = false;
            txtrzv.Enabled = false;
            txtrzv1.Enabled = false;

         }
        else
        {
            ViewState["dd1PassComplete"] = "";
            ViewState["ddlPassTime"] = "";
            ViewState["dd1Name1"] = "";
            ViewState["dd1Name2"] = "";
            
            ViewState["dd2Name1"] = "";
            ViewState["dd2Name2"] = "";
            
            ViewState["dd3Name1"] = ""  ;
            ViewState["dd3Name2"] = "";
            
            ViewState["dd4Name1"] = "";
            ViewState["dd4Name2"] = "";
            
            ViewState["Final1"] = "";
            ViewState["Final2"] = "";
            
            ViewState["ThirdTableResult2"] = "";
            ViewState["ThirdTableResult4"] = "";

        }
        DropDownList1.SelectedIndex = 0;
        DropDownList2.SelectedIndex = 9;            
        DropDownList3.SelectedIndex = 0;
        
        txtname.Text = "";
        txtrmv.Text = "";
        txtrzv.Text = "";
        txtrst.Text = "";
        txtname1.Text = "";
        txtrmv1.Text = "";
        txtrzv1.Text = "";
        txtrst1.Text = "";

     }
}

