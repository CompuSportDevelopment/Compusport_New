using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Net;
using SwingModel.Data;
using SwingModel.Entities;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using System.Net.Mail;
//using RateWebServiceClient.RateServiceWebReference;

//public partial class Shop_ClubOrder : System.Web.UI.Page
public partial class Shop_ClubOrder : SwingModel.UI.BasePage
{
    Customer customer = new Customer();
    CustomerProfile customerprofile = new CustomerProfile();
    Order order = new Order();
    TList<ClubOrder> cluborder = new TList<ClubOrder>();
    ClubBuilder clubbuilder = new ClubBuilder();
    CustomerSite customersite = new CustomerSite();
    CurrentFitStatus currentfitstatus = new CurrentFitStatus();
    bool customerexists = false;
    bool customerprofileexists = false;
    string strOrderId;
    decimal subtotal = Convert.ToDecimal(0);
    decimal grandtotal = Convert.ToDecimal(0);
    decimal DeclaredValue = Convert.ToDecimal(0);
    int NumberClubs = 0;
    int x;

    protected override void OnPreLoad(EventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            try
            {
                customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
                customerexists = true;
            }
            catch
            {
                //no entry in Customer table for current member
                customerexists = false;
            }
        }

        try
        {
            customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customer.CustomerId)[0];
            customerprofileexists = true;
            customersite = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(customerprofile.CustomerSite);
            clubbuilder = DataRepository.ClubBuilderProvider.GetByClubBuilderId(customersite.ClubBuilder);
        }
        catch
        {
            //no entery in CustomerProfile table for current member
            customerprofileexists = false;
        }

        if (DropDownList4.SelectedValue.Equals("") || DropDownList4.SelectedValue.Equals(null))
        {
            TList<CountryLookup> countries = DataRepository.CountryLookupProvider.GetAll();
            DropDownList4.Items.Clear();
            DropDownList4.Items.Add("Select Country");
            DropDownList4.Items[0].Value = "0";
            DropDownList4.Items[0].Selected = false;
            x = 0;
            foreach (CountryLookup country in countries)
            {
                x++;
                DropDownList4.Items.Add(country.CountryName);
                DropDownList4.Items[x].Value = country.CountryId.ToString();
            }
        }
        if (DropDownList6.SelectedValue.Equals("") || DropDownList6.SelectedValue.Equals(null))
        {
            TList<CountryLookup> countries = DataRepository.CountryLookupProvider.GetAll();
            DropDownList6.Items.Clear();
            DropDownList6.Items.Add("Select Country");
            DropDownList6.Items[0].Value = "0";
            DropDownList6.Items[0].Selected = false;
            x = 0;
            foreach (CountryLookup country in countries)
            {
                x++;
                DropDownList6.Items.Add(country.CountryName);
                DropDownList6.Items[x].Value = country.CountryId.ToString();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        int woods = 0;
        int irons = 0;
        decimal ExpediteCost;

        strOrderId = Request.QueryString.Get("orderid");
        //MessageBox.Show(strOrderId);
        order = DataRepository.OrderProvider.GetByOrderId(Convert.ToInt16(strOrderId));
        cluborder = DataRepository.ClubOrderProvider.GetByOrderId(Convert.ToInt16(strOrderId));

        dt.Columns.Add("Club", typeof(string));
        dt.Columns.Add("Lie", typeof(string));
        dt.Columns.Add("Loft", typeof(decimal));
        dt.Columns.Add("Shaft", typeof(string));
        dt.Columns.Add("Freq", typeof(int));
        dt.Columns.Add("Length", typeof(decimal));
        dt.Columns.Add("Cost", typeof(string));

        foreach (ClubOrder co in cluborder)
        {
            dt.Rows.Add(co.Club, co.Lie, co.Loft, co.Shaft, co.Frequency, co.Length, "$" + co.Cost.ToString());
            subtotal = subtotal + co.Cost;
            if (co.Lie.ToLower().Equals("std"))
                woods++;
            else
                irons++;
        }
        NumberClubs = woods + irons;
        GridView1.DataSource = dt;
        GridView1.DataBind();

        Label2.Text = "$" + subtotal.ToString();

        DropDownList3.Items.Add("Year");
        DropDownList3.Items[0].Value = "0";
        x = 0;
        for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 15; i++)
        {
            x++;
            DropDownList3.Items.Add(i.ToString());
            DropDownList3.Items[x].Value = i.ToString().Substring(2, 2);
        }

        ExpediteCost = Convert.ToDecimal(woods * 75) + Convert.ToDecimal(irons * 50);
        Label48.Text = "$" + ExpediteCost.ToString("#.00");
    }

    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(DropDownList4.SelectedValue).Equals(248) || Convert.ToInt16(DropDownList4.SelectedValue).Equals(287))
        {
            DropDownList5.Visible = true;
            TextBox7.Visible = false;

            DropDownList5.Items.Clear();
            DropDownList5.Items.Add("Select State/Province");
            DropDownList5.Items[0].Value = "0";
            x = 0;
            TList<StateProvince> states = DataRepository.StateProvinceProvider.GetByCountry(Convert.ToInt16(DropDownList4.SelectedValue));
            foreach (StateProvince sp in states)
            {
                x++;
                DropDownList5.Items.Add(sp.StateProvinceName);
                DropDownList5.Items[x].Value = sp.StateProvinceAbbvr;
            }
            DropDownList5.SelectedValue = DropDownList5.Items[0].Value;
        }
        else
        {
            DropDownList5.Visible = false;
            TextBox7.Visible = true;
            TextBox7.Text = "";
        }
    }

    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(DropDownList6.SelectedValue).Equals(248) || Convert.ToInt16(DropDownList6.SelectedValue).Equals(287))
        {
            DropDownList7.Visible = true;
            TextBox14.Visible = false;

            DropDownList7.Items.Clear();
            DropDownList7.Items.Add("Select State/Province");
            DropDownList7.Items[0].Value = "0";
            x = 0;
            TList<StateProvince> states = DataRepository.StateProvinceProvider.GetByCountry(Convert.ToInt16(DropDownList6.SelectedValue));
            foreach (StateProvince sp in states)
            {
                x++;
                DropDownList7.Items.Add(sp.StateProvinceName);
                DropDownList7.Items[x].Value = sp.StateProvinceAbbvr;
            }
            DropDownList7.SelectedValue = DropDownList7.Items[0].Value;
        }
        else
        {
            DropDownList7.Visible = false;
            TextBox14.Visible = true;
            TextBox14.Text = "";
        }
        Button1.Enabled = false;
        RadioButtonList1.Items[0].Selected = true;
        RadioButtonList1.Items[1].Selected = false;
        RadioButtonList1.Items[2].Selected = false;
        RadioButtonList1.Items[3].Selected = false;
        RadioButtonList1.Items[0].Enabled = false;
        RadioButtonList1.Items[1].Enabled = false;
        RadioButtonList1.Items[2].Enabled = false;
        RadioButtonList1.Items[3].Enabled = false;
        Label55.Text = "";
        Label56.Text = "";
        Label57.Text = "";
        Label58.Text = "";
        Label58.Enabled = false;
        Label50.Text = "";
        CheckBox1.Enabled = false;
        Label48.Enabled = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        bool DoCharge = false;
        string[] response_array;

        Label47.Visible = false;

        if (TextBox1.Text.Equals("") || TextBox1.Text.Equals(null))
        {
            DoCharge = false;
            Label45.Visible = true;
            Label21.Visible = true;
        }
        else
        {
            DoCharge = true;
            Label45.Visible = false;
            Label21.Visible = false;
        }
        if (TextBox10.Text.Equals("") || TextBox10.Text.Equals(null))
        {
            DoCharge = false;
            Label45.Visible = true;
            Label33.Visible = true;
        }
        else
        {
            if (DoCharge)
                DoCharge = true;
            Label45.Visible = false;
            Label33.Visible = false;
        }
        if (TextBox2.Text.Equals("") || TextBox2.Text.Equals(null))
        {
            DoCharge = false;
            Label45.Visible = true;
            Label23.Visible = true;
        }
        else
        {
            if (TextBox2.Text.Length < 15)
            {
                DoCharge = false;
                Label45.Text = "Please complete items with * below. Enter correct Card Number.";
                Label45.Visible = true;
                Label23.Visible = true;
            }
            else
            {
                if (DropDownList1.SelectedValue.Equals("AmericanExpress"))
                {
                    if (!TextBox2.Text.Length.Equals(15))
                    {
                        DoCharge = false;
                        Label45.Text = "Please complete items with * below. Select correct Card Type or enter correct Card Number.";
                        Label45.Visible = true;
                        Label23.Visible = true;
                    }
                    else if (!TextBox2.Text.StartsWith("3"))
                    {
                        DoCharge = false;
                        Label45.Text = "Please complete items with * below. Enter correct Card Number.";
                        Label45.Visible = true;
                        Label23.Visible = true;
                    }
                    else
                    {
                        if (DoCharge)
                            DoCharge = true;
                        Label45.Text = "Please complete items with * below.";
                        Label45.Visible = false;
                        Label23.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Discover"))
                {
                    if (!TextBox2.Text.Length.Equals(16))
                    {
                        DoCharge = false;
                        Label45.Text = "Please complete items with * below. Select correct Card Type or enter correct Card Number.";
                        Label45.Visible = true;
                        Label23.Visible = true;
                    }
                    else if (!TextBox2.Text.StartsWith("6"))
                    {
                        DoCharge = false;
                        Label45.Text = "Please complete items with * below. Enter correct Card Number.";
                        Label45.Visible = true;
                        Label23.Visible = true;
                    }
                    else
                    {
                        if (DoCharge)
                            DoCharge = true;
                        Label45.Text = "Please complete items with * below.";
                        Label45.Visible = false;
                        Label23.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Mastercard"))
                {
                    if (!TextBox2.Text.Length.Equals(16))
                    {
                        DoCharge = false;
                        Label45.Text = "Please complete items with * below. Select correct Card Type or enter correct Card Number.";
                        Label45.Visible = true;
                        Label23.Visible = true;
                    }
                    else if (!TextBox2.Text.StartsWith("5"))
                    {
                        DoCharge = false;
                        Label45.Text = "Please complete items with * below. Enter correct Card Number.";
                        Label45.Visible = true;
                        Label23.Visible = true;
                    }
                    else
                    {
                        if (DoCharge)
                            DoCharge = true;
                        Label45.Text = "Please complete items with * below.";
                        Label45.Visible = false;
                        Label23.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Visa"))
                {
                    if (!TextBox2.Text.Length.Equals(16))
                    {
                        DoCharge = false;
                        Label45.Text = "Please complete items with * below. Select correct Card Type or enter correct Card Number.";
                        Label45.Visible = true;
                        Label23.Visible = true;
                    }
                    else if (!TextBox2.Text.StartsWith("4"))
                    {
                        DoCharge = false;
                        Label45.Text = "Please complete items with * below. Enter correct Card Number.";
                        Label45.Visible = true;
                        Label23.Visible = true;
                    }
                    else
                    {
                        if (DoCharge)
                            DoCharge = true;
                        Label45.Text = "Please complete items with * below.";
                        Label45.Visible = false;
                        Label23.Visible = false;
                    }
                }
                else
                {
                    if (DoCharge)
                        DoCharge = true;
                    Label45.Text = "Please complete items with * below.";
                    Label45.Visible = false;
                    Label23.Visible = false;
                }
            }
        }
        if (DropDownList2.SelectedValue.Equals("0") || DropDownList3.SelectedValue.Equals("0"))
        {
            DoCharge = false;
            Label45.Visible = true;
            Label24.Visible = true;
        }
        else
        {
            if (DoCharge)
                DoCharge = true;
            Label45.Visible = false;
            Label24.Visible = false;
        }
        if (TextBox3.Text.Equals("") || TextBox3.Text.Equals(null))
        {
            DoCharge = false;
            Label45.Visible = true;
            Label25.Visible = true;
        }
        else
        {
            if (TextBox3.Text.Length < 3)
            {
                DoCharge = false;
                Label45.Text = "Please complete items with * below. Enter correct CVV Number.";
                Label45.Visible = true;
                Label25.Visible = true;
            }
            else
            {
                if (DropDownList1.SelectedValue.Equals("AmericanExpress"))
                {
                    if (!TextBox3.Text.Length.Equals(4))
                    {
                        DoCharge = false;
                        Label45.Text = "Please complete items with * below. Enter correct CVV Number.";
                        Label45.Visible = true;
                        Label25.Visible = true;
                    }
                    else
                    {
                        if (DoCharge)
                            DoCharge = true;
                        Label45.Text = "Please complete items with * below.";
                        Label45.Visible = false;
                        Label25.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Discover"))
                {
                    if (!TextBox3.Text.Length.Equals(3))
                    {
                        DoCharge = false;
                        Label45.Text = "Please complete items with * below. Enter correct CVV Number.";
                        Label45.Visible = true;
                        Label25.Visible = true;
                    }
                    else
                    {
                        if (DoCharge)
                            DoCharge = true;
                        Label45.Text = "Please complete items with * below.";
                        Label45.Visible = false;
                        Label25.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Mastercard"))
                {
                    if (!TextBox3.Text.Length.Equals(3))
                    {
                        DoCharge = false;
                        Label45.Text = "Please complete items with * below. Enter correct CVV Number.";
                        Label45.Visible = true;
                        Label25.Visible = true;
                    }
                    else
                    {
                        if (DoCharge)
                            DoCharge = true;
                        Label45.Text = "Please complete items with * below.";
                        Label45.Visible = false;
                        Label25.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Visa"))
                {
                    if (!TextBox3.Text.Length.Equals(3))
                    {
                        DoCharge = false;
                        Label45.Text = "Please complete items with * below. Enter correct CVV Number.";
                        Label45.Visible = true;
                        Label25.Visible = true;
                    }
                    else
                    {
                        if (DoCharge)
                            DoCharge = true;
                        Label45.Text = "Please complete items with * below.";
                        Label45.Visible = false;
                        Label25.Visible = false;
                    }
                }
                else
                {
                    if (DoCharge)
                        DoCharge = true;
                    Label45.Text = "Please complete items with * below.";
                    Label45.Visible = false;
                    Label25.Visible = false;
                }
            }
        }
        if (DropDownList4.SelectedValue.Equals("0"))
        {
            DoCharge = false;
            Label45.Visible = true;
            Label26.Visible = true;
        }
        else
        {
            if (DoCharge)
                Label45.Visible = false;
            Label26.Visible = false;
        }
        if (TextBox4.Text.Equals("") || TextBox4.Text.Equals(null))
        {
            DoCharge = false;
            Label45.Visible = true;
            Label27.Visible = true;
        }
        else
        {
            if (DoCharge)
                Label45.Visible = false;
            Label27.Visible = false;
        }
        if (TextBox6.Text.Equals("") || TextBox6.Text.Equals(null))
        {
            DoCharge = false;
            Label45.Visible = true;
            Label28.Visible = true;
        }
        else
        {
            if (DoCharge)
                Label45.Visible = false;
            Label28.Visible = false;
        }
        if (TextBox7.Visible.Equals(true))
        {
            if (TextBox7.Text.Equals("") || TextBox7.Text.Equals(null))
            {
                DoCharge = false;
                Label45.Visible = true;
                Label29.Visible = true;
            }
            else
            {
                if (DoCharge)
                    Label45.Visible = false;
                Label29.Visible = false;
            }
        }
        else
        {
            if (DropDownList5.SelectedValue.Equals("0"))
            {
                DoCharge = false;
                Label45.Visible = true;
                Label29.Visible = true;
            }
            else
            {
                if (DoCharge)
                    Label45.Visible = false;
                Label29.Visible = false;
            }
        }
        if (TextBox8.Text.Equals("") || TextBox8.Text.Equals(null))
        {
            DoCharge = false;
            Label45.Visible = true;
            Label30.Visible = true;
        }
        else
        {
            if (DoCharge)
                Label45.Visible = false;
            Label30.Visible = false;
        }
        if (TextBox9.Text.Equals("") || TextBox9.Text.Equals(null))
        {
            DoCharge = false;
            Label45.Visible = true;
            Label31.Visible = true;
        }
        else
        {
            if (DoCharge)
                Label45.Visible = false;
            Label31.Visible = false;
        }
        if (DropDownList6.SelectedValue.Equals("0"))
        {
            DoCharge = false;
            Label45.Visible = true;
            Label32.Visible = true;
        }
        else
        {
            if (DoCharge)
                Label45.Visible = false;
            Label32.Visible = false;
        }
        if (TextBox11.Text.Equals("") || TextBox11.Text.Equals(null))
        {
            DoCharge = false;
            Label35.Visible = true;
            Label27.Visible = true;
        }
        else
        {
            if (DoCharge)
                Label45.Visible = false;
            Label35.Visible = false;
        }
        if (TextBox13.Text.Equals("") || TextBox13.Text.Equals(null))
        {
            DoCharge = false;
            Label45.Visible = true;
            Label38.Visible = true;
        }
        else
        {
            if (DoCharge)
                Label45.Visible = false;
            Label38.Visible = false;
        }
        if (TextBox14.Visible.Equals(true))
        {
            if (TextBox14.Text.Equals("") || TextBox14.Text.Equals(null))
            {
                DoCharge = false;
                Label45.Visible = true;
                Label40.Visible = true;
            }
            else
            {
                if (DoCharge)
                    Label45.Visible = false;
                Label40.Visible = false;
            }
        }
        else
        {
            if (DropDownList7.SelectedValue.Equals("0"))
            {
                DoCharge = false;
                Label45.Visible = true;
                Label40.Visible = true;
            }
            else
            {
                if (DoCharge)
                    Label45.Visible = false;
                Label40.Visible = false;
            }
        }
        if (TextBox15.Text.Equals("") || TextBox15.Text.Equals(null))
        {
            DoCharge = false;
            Label45.Visible = true;
            Label42.Visible = true;
        }
        else
        {
            if (DoCharge)
                Label45.Visible = false;
            Label42.Visible = false;
        }
        if (TextBox16.Text.Equals("") || TextBox16.Text.Equals(null))
        {
            DoCharge = false;
            Label45.Visible = true;
            Label44.Visible = true;
        }
        else
        {
            if (DoCharge)
                Label45.Visible = false;
            Label44.Visible = false;
        }

        if (DoCharge)
        {
            // By default, this sample code is designed to post to our test server for
            // developer accounts: https://test.authorize.net/gateway/transact.dll
            // for real accounts (even in test mode), please make sure that you are
            // posting to: https://secure.authorize.net/gateway/transact.dll
            //String post_url = "https://test.authorize.net/gateway/transact.dll";
            String post_url = "https://secure.authorize.net/gateway/transact.dll";

            Hashtable post_values = new Hashtable();

            //the API Login ID and Transaction Key must be replaced with valid values
            post_values.Add("x_login", ConfigurationSettings.AppSettings["x_login"]);
            post_values.Add("x_tran_key", ConfigurationSettings.AppSettings["x_tran_key"]);
            post_values.Add("x_test_request", "TRUE");

            post_values.Add("x_delim_data", "TRUE");
            post_values.Add("x_delim_char", '|');
            post_values.Add("x_relay_response", "FALSE");

            post_values.Add("x_type", "AUTH_CAPTURE");
            post_values.Add("x_method", "CC");
            //post_values.Add("x_card_num", "4111111111111111");
            post_values.Add("x_card_num", TextBox2.Text);
            post_values.Add("x_exp_date", DropDownList2.SelectedValue + DropDownList3.SelectedValue);
            post_values.Add("x_card_code", TextBox3.Text);

            //post_values.Add("x_amount", "99.00");
            //MessageBox.Show("Amount Charged: $" + Label50.Text.Substring(1, Label50.Text.Length - 1));
            post_values.Add("x_amount", Label50.Text.Substring(1, Label50.Text.Length-1));
            post_values.Add("x_description", "SwingModel Custom Club Order");

            post_values.Add("x_first_name", TextBox1.Text);
            post_values.Add("x_last_name", TextBox10.Text);
            post_values.Add("x_address", TextBox4.Text);
            if (TextBox7.Visible.Equals(true))
                post_values.Add("x_state", TextBox7.Text);
            else
                post_values.Add("x_state", DropDownList5.SelectedValue);
            post_values.Add("x_zip", TextBox8.Text);
            post_values.Add("x_email", TextBox9.Text);
            // Additional fields can be added here as outlined in the AIM integration
            // guide at: http://developer.authorize.net

            // This section takes the input fields and converts them to the proper format
            // for an http post.  For example: "x_login=username&x_tran_key=a1B2c3D4"
            String post_string = "";
            foreach (DictionaryEntry field in post_values)
            {
                post_string += field.Key + "=" + field.Value + "&";
            }
            post_string = post_string.TrimEnd('&');

            // create an HttpWebRequest object to communicate with Authorize.net
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(post_url);
            objRequest.Method = "POST";
            objRequest.ContentLength = post_string.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            // post data is sent as a stream
            StreamWriter myWriter = null;
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(post_string);
            myWriter.Close();

            // returned values are returned as a stream, then read into a string
            String post_response;
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                post_response = responseStream.ReadToEnd();
                responseStream.Close();
            }

            // the response string is broken into an array
            // The split character specified here must match the delimiting character specified above
            //Array response_array = post_response.Split('|');
            response_array = post_response.Split('|');

            // the results are output to the screen in the form of an html numbered list.
            /*
            resultSpan.InnerHtml += "<OL> \n";
            foreach (string value in response_array)
            {
                resultSpan.InnerHtml += "<LI>" + value + "&nbsp;</LI> \n";
            }
            resultSpan.InnerHtml += "</OL> \n";
            */
            // individual elements of the array could be accessed to read certain response
            // fields.  For example, response_array[0] would return the Response Code,
            // response_array[2] would return the Response Reason Code.
            // for a list of response fields, please review the AIM Implementation Guide
            if (response_array[0].Equals("1"))
            {
                order.TransactionComplete = 1;
                order.BillingType = 1;
                order.OrderDate = DateTime.Now;
                order.CardFirstName = TextBox1.Text.Trim();
                order.CardLastName = TextBox10.Text.Trim();
                order.CardLast4 = TextBox2.Text.Substring(TextBox2.Text.Length - 4, 4);
                order.BillingCountry = Convert.ToInt16(DropDownList4.SelectedValue);
                order.BillingAddress1 = TextBox4.Text;
                if (!TextBox5.Text.Equals("") && TextBox5.Text.Equals(null))
                    order.BillingAddress2 = TextBox5.Text;
                order.BillingCity = TextBox6.Text;
                if (TextBox7.Visible)
                    order.BillingState = TextBox7.Text;
                else
                    order.BillingState = DropDownList5.SelectedValue;
                order.BillingZip = TextBox8.Text;
                order.BillingEmail = TextBox9.Text;
                order.ShippingCountry = Convert.ToInt16(DropDownList6.SelectedValue);
                order.ShippingAddress1 = TextBox11.Text;
                if (!TextBox12.Text.Equals("") && TextBox12.Text.Equals(null))
                    order.ShippingAddress2 = TextBox12.Text;
                order.ShippingCity = TextBox13.Text;
                if (TextBox14.Visible)
                    order.ShippingState = TextBox14.Text;
                else
                    order.ShippingState = DropDownList7.SelectedValue;
                order.ShippingZip = TextBox15.Text;
                order.ShippingEmail = TextBox16.Text;
                order.Subtotal = Convert.ToDecimal(Label2.Text.Substring(1, Label2.Text.Length - 1));
                order.ShippingMethod = Convert.ToInt16(RadioButtonList1.SelectedValue);
                switch (RadioButtonList1.SelectedValue)
                {
                    case "1":
                        order.ShippingCost = Convert.ToDecimal(Label55.Text.Substring(1, Label55.Text.Length-1));
                        break;

                    case "2":
                        order.ShippingCost = Convert.ToDecimal(Label56.Text.Substring(1, Label56.Text.Length - 1));
                        break;

                    case "3":
                        order.ShippingCost = Convert.ToDecimal(Label57.Text.Substring(1, Label57.Text.Length - 1));
                        break;

                    case "4":
                        order.ShippingCost = Convert.ToDecimal(Label58.Text.Substring(1, Label58.Text.Length - 1));
                        break;
                }
                if (CheckBox1.Checked)
                    order.Expedite = 1;
                else
                    order.Expedite = 0;
                order.ExpediteCost = Convert.ToDecimal(Label48.Text.Substring(1, Label48.Text.Length-1));
                order.GrandTotal = Convert.ToDecimal(Label50.Text.Substring(1, Label50.Text.Length-1));
                order.ClubBuilder = clubbuilder.ClubBuilderId;

                DataRepository.OrderProvider.Update(order);

                // Email SwingModel, Customer, ClubBuilder, Facility
                MembershipUser member = Membership.GetUser();
                string MemberEmail = member.Email;
                string BuilderEmail = clubbuilder.Email;
                currentfitstatus = DataRepository.CurrentFitStatusProvider.GetByCustomerId(customer.CustomerId)[0];
                CustomerSite FitSite = new CustomerSite();
                FitSite = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(currentfitstatus.FitSite);
                string CustomerSiteEmail = FitSite.ClubOrderEmail;
                SendOrderEmails(MemberEmail, BuilderEmail, CustomerSiteEmail);
                
                // Redirect to Order Completed Page
                Response.Redirect("~/Shop/ClubOrderSuccess.aspx?orderid=" + order.OrderId);

                Label47.Text = "The charge was successful. You will receive an email with the transaction details (" + TextBox9.Text + "). Click the Continue button below to go to the Login page.";
                Label47.Visible = true;
            }
            else
            {
                Label47.Text = "The charge attempt failed. Please correct the information above, or use a different credit card. The Response Reason Code is: " + response_array[2];
                Label47.Visible = true;
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        RateService FedExRateService = new RateService();
        bool GetRates = false;

        Label45.Visible = false;
        Label47.Visible = false;
        /*
        if (TextBox1.Text.Equals("") || TextBox1.Text.Equals(null))
        {
            GetRates = false;
            Label45.Visible = true;
            Label21.Visible = true;
        }
        else
        {
            GetRates = true;
            Label45.Visible = false;
            Label21.Visible = false;
        }
        if (TextBox10.Text.Equals("") || TextBox10.Text.Equals(null))
        {
            GetRates = false;
            Label45.Visible = true;
            Label33.Visible = true;
        }
        else
        {
            if (GetRates)
                GetRates = true;
            Label45.Visible = false;
            Label33.Visible = false;
        }
        if (TextBox2.Text.Equals("") || TextBox2.Text.Equals(null))
        {
            GetRates = false;
            Label45.Visible = true;
            Label23.Visible = true;
        }
        else
        {
            if (TextBox2.Text.Length < 15)
            {
                GetRates = false;
                Label45.Text = "Please complete items with * below. Enter correct Card Number.";
                Label45.Visible = true;
                Label23.Visible = true;
            }
            else
            {
                if (DropDownList1.SelectedValue.Equals("AmericanExpress"))
                {
                    if (!TextBox2.Text.Length.Equals(15))
                    {
                        GetRates = false;
                        Label45.Text = "Please complete items with * below. Select correct Card Type or enter correct Card Number.";
                        Label45.Visible = true;
                        Label23.Visible = true;
                    }
                    else if (!TextBox2.Text.StartsWith("3"))
                    {
                        GetRates = false;
                        Label45.Text = "Please complete items with * below. Enter correct Card Number.";
                        Label45.Visible = true;
                        Label23.Visible = true;
                    }
                    else
                    {
                        if (GetRates)
                            GetRates = true;
                        Label45.Text = "Please complete items with * below.";
                        Label45.Visible = false;
                        Label23.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Discover"))
                {
                    if (!TextBox2.Text.Length.Equals(16))
                    {
                        GetRates = false;
                        Label45.Text = "Please complete items with * below. Select correct Card Type or enter correct Card Number.";
                        Label45.Visible = true;
                        Label23.Visible = true;
                    }
                    else if (!TextBox2.Text.StartsWith("6"))
                    {
                        GetRates = false;
                        Label45.Text = "Please complete items with * below. Enter correct Card Number.";
                        Label45.Visible = true;
                        Label23.Visible = true;
                    }
                    else
                    {
                        if (GetRates)
                            GetRates = true;
                        Label45.Text = "Please complete items with * below.";
                        Label45.Visible = false;
                        Label23.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Mastercard"))
                {
                    if (!TextBox2.Text.Length.Equals(16))
                    {
                        GetRates = false;
                        Label45.Text = "Please complete items with * below. Select correct Card Type or enter correct Card Number.";
                        Label45.Visible = true;
                        Label23.Visible = true;
                    }
                    else if (!TextBox2.Text.StartsWith("5"))
                    {
                        GetRates = false;
                        Label45.Text = "Please complete items with * below. Enter correct Card Number.";
                        Label45.Visible = true;
                        Label23.Visible = true;
                    }
                    else
                    {
                        if (GetRates)
                            GetRates = true;
                        Label45.Text = "Please complete items with * below.";
                        Label45.Visible = false;
                        Label23.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Visa"))
                {
                    if (!TextBox2.Text.Length.Equals(16))
                    {
                        GetRates = false;
                        Label45.Text = "Please complete items with * below. Select correct Card Type or enter correct Card Number.";
                        Label45.Visible = true;
                        Label23.Visible = true;
                    }
                    else if (!TextBox2.Text.StartsWith("4"))
                    {
                        GetRates = false;
                        Label45.Text = "Please complete items with * below. Enter correct Card Number.";
                        Label45.Visible = true;
                        Label23.Visible = true;
                    }
                    else
                    {
                        if (GetRates)
                            GetRates = true;
                        Label45.Text = "Please complete items with * below.";
                        Label45.Visible = false;
                        Label23.Visible = false;
                    }
                }
                else
                {
                    if (GetRates)
                        GetRates = true;
                    Label45.Text = "Please complete items with * below.";
                    Label45.Visible = false;
                    Label23.Visible = false;
                }
            }
        }
        if (DropDownList2.SelectedValue.Equals("0") || DropDownList3.SelectedValue.Equals("0"))
        {
            GetRates = false;
            Label45.Visible = true;
            Label24.Visible = true;
        }
        else
        {
            if (GetRates)
                GetRates = true;
            Label45.Visible = false;
            Label24.Visible = false;
        }
        if (TextBox3.Text.Equals("") || TextBox3.Text.Equals(null))
        {
            GetRates = false;
            Label45.Visible = true;
            Label25.Visible = true;
        }
        else
        {
            if (TextBox3.Text.Length < 3)
            {
                GetRates = false;
                Label45.Text = "Please complete items with * below. Enter correct CVV Number.";
                Label45.Visible = true;
                Label25.Visible = true;
            }
            else
            {
                if (DropDownList1.SelectedValue.Equals("AmericanExpress"))
                {
                    if (!TextBox3.Text.Length.Equals(4))
                    {
                        GetRates = false;
                        Label45.Text = "Please complete items with * below. Enter correct CVV Number.";
                        Label45.Visible = true;
                        Label25.Visible = true;
                    }
                    else
                    {
                        if (GetRates)
                            GetRates = true;
                        Label45.Text = "Please complete items with * below.";
                        Label45.Visible = false;
                        Label25.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Discover"))
                {
                    if (!TextBox3.Text.Length.Equals(3))
                    {
                        GetRates = false;
                        Label45.Text = "Please complete items with * below. Enter correct CVV Number.";
                        Label45.Visible = true;
                        Label25.Visible = true;
                    }
                    else
                    {
                        if (GetRates)
                            GetRates = true;
                        Label45.Text = "Please complete items with * below.";
                        Label45.Visible = false;
                        Label25.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Mastercard"))
                {
                    if (!TextBox3.Text.Length.Equals(3))
                    {
                        GetRates = false;
                        Label45.Text = "Please complete items with * below. Enter correct CVV Number.";
                        Label45.Visible = true;
                        Label25.Visible = true;
                    }
                    else
                    {
                        if (GetRates)
                            GetRates = true;
                        Label45.Text = "Please complete items with * below.";
                        Label45.Visible = false;
                        Label25.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Visa"))
                {
                    if (!TextBox3.Text.Length.Equals(3))
                    {
                        GetRates = false;
                        Label45.Text = "Please complete items with * below. Enter correct CVV Number.";
                        Label45.Visible = true;
                        Label25.Visible = true;
                    }
                    else
                    {
                        if (GetRates)
                            GetRates = true;
                        Label45.Text = "Please complete items with * below.";
                        Label45.Visible = false;
                        Label25.Visible = false;
                    }
                }
                else
                {
                    if (GetRates)
                        GetRates = true;
                    Label45.Text = "Please complete items with * below.";
                    Label45.Visible = false;
                    Label25.Visible = false;
                }
            }
        }
        */
        /*
        if (DropDownList4.SelectedValue.Equals("0"))
        {
            GetRates = false;
            Label45.Visible = true;
            Label26.Visible = true;
        }
        else
        {
            if (GetRates)
                Label45.Visible = false;
            Label26.Visible = false;
        }
        if (TextBox4.Text.Equals("") || TextBox4.Text.Equals(null))
        {
            GetRates = false;
            Label45.Visible = true;
            Label27.Visible = true;
        }
        else
        {
            if (GetRates)
                Label45.Visible = false;
            Label27.Visible = false;
        }
        if (TextBox6.Text.Equals("") || TextBox6.Text.Equals(null))
        {
            GetRates = false;
            Label45.Visible = true;
            Label28.Visible = true;
        }
        else
        {
            if (GetRates)
                Label45.Visible = false;
            Label28.Visible = false;
        }
        if (TextBox7.Visible.Equals(true))
        {
            if (TextBox7.Text.Equals("") || TextBox7.Text.Equals(null))
            {
                GetRates = false;
                Label45.Visible = true;
                Label29.Visible = true;
            }
            else
            {
                if (GetRates)
                    Label45.Visible = false;
                Label29.Visible = false;
            }
        }
        else
        {
            if (DropDownList5.SelectedValue.Equals("0"))
            {
                GetRates = false;
                Label45.Visible = true;
                Label29.Visible = true;
            }
            else
            {
                if (GetRates)
                    Label45.Visible = false;
                Label29.Visible = false;
            }
        }
        if (TextBox8.Text.Equals("") || TextBox8.Text.Equals(null))
        {
            GetRates = false;
            Label45.Visible = true;
            Label30.Visible = true;
        }
        else
        {
            if (GetRates)
                Label45.Visible = false;
            Label30.Visible = false;
        }
        if (TextBox9.Text.Equals("") || TextBox9.Text.Equals(null))
        {
            GetRates = false;
            Label45.Visible = true;
            Label31.Visible = true;
        }
        else
        {
            if (GetRates)
                Label45.Visible = false;
            Label31.Visible = false;
        }
        */
        if (DropDownList6.SelectedValue.Equals("0"))
        {
            GetRates = false;
            Label45.Visible = true;
            Label32.Visible = true;
        }
        else
        {
            GetRates = true;
            if (GetRates)
                Label45.Visible = false;
            Label32.Visible = false;
        }
        if (TextBox11.Text.Equals("") || TextBox11.Text.Equals(null))
        {
            GetRates = false;
            Label35.Visible = true;
            Label45.Visible = true;
        }
        else
        {
            if (GetRates)
                Label45.Visible = false;
            Label35.Visible = false;
        }
        if (TextBox13.Text.Equals("") || TextBox13.Text.Equals(null))
        {
            GetRates = false;
            Label45.Visible = true;
            Label38.Visible = true;
        }
        else
        {
            if (GetRates)
                Label45.Visible = false;
            Label38.Visible = false;
        }
        if (TextBox14.Visible.Equals(true))
        {
            if (TextBox14.Text.Equals("") || TextBox14.Text.Equals(null))
            {
                GetRates = false;
                Label45.Visible = true;
                Label40.Visible = true;
            }
            else
            {
                if (GetRates)
                    Label45.Visible = false;
                Label40.Visible = false;
            }
        }
        else
        {
            if (DropDownList7.SelectedValue.Equals("0"))
            {
                GetRates = false;
                Label45.Visible = true;
                Label40.Visible = true;
            }
            else
            {
                if (GetRates)
                    Label45.Visible = false;
                Label40.Visible = false;
            }
        }
        if (TextBox15.Text.Equals("") || TextBox15.Text.Equals(null))
        {
            GetRates = false;
            Label45.Visible = true;
            Label42.Visible = true;
        }
        else
        {
            if (GetRates)
                Label45.Visible = false;
            Label42.Visible = false;
        }
        if (TextBox16.Text.Equals("") || TextBox16.Text.Equals(null))
        {
            GetRates = false;
            Label45.Visible = true;
            Label44.Visible = true;
        }
        else
        {
            if (GetRates)
                Label45.Visible = false;
            Label44.Visible = false;
        }

        decimal ShippingRate;
        if (GetRates)
        {
            //Response.Write("here0");
            RateRequest request = new RateRequest();
            if (DropDownList6.SelectedValue.Equals("248"))
            {
                for (int m = 1; m < 4; m++)
                {
                    switch (m)
                    {
                        case 1:
                            request = CreateRateRequest(ServiceType.GROUND_HOME_DELIVERY, CarrierCodeType.FDXG);
                            break;

                        case 2:
                            request = CreateRateRequest(ServiceType.FEDEX_2_DAY, CarrierCodeType.FDXE);
                            break;

                        case 3:
                            request = CreateRateRequest(ServiceType.STANDARD_OVERNIGHT, CarrierCodeType.FDXE);
                            break;
                    }

                    DeclaredValue = Math.Round(subtotal / Convert.ToDecimal(100), MidpointRounding.AwayFromZero);
                    if (DeclaredValue < Convert.ToDecimal(1))
                        DeclaredValue = Convert.ToDecimal(1);
                    RateService service = new RateService(); // Initialize the service
                    try
                    {
                        //MessageBox.Show("here1");
                        //Response.Write("here1");
                        // Call the web service passing in a RateRequest and returning a RateReply
                        RateReply reply = service.getRates(request);
                        if (reply.HighestSeverity == NotificationSeverityType.SUCCESS || reply.HighestSeverity == NotificationSeverityType.NOTE || reply.HighestSeverity == NotificationSeverityType.WARNING) // check if the call was successful
                        {
                            //ShowRateReply(reply);
                            ShippingRate = GetRateReply(reply) + (DeclaredValue * Convert.ToDecimal(.70));
                            switch (m)
                            {
                                case 1:
                                    Label55.Text = "$" + ShippingRate.ToString("#.00");
                                    Label55.Enabled = true;
                                    RadioButtonList1.Items[0].Enabled = true;
                                    if (CheckBox1.Checked)
                                        grandtotal = subtotal + ShippingRate + Convert.ToDecimal(Label48.Text.Substring(1, Label48.Text.Length - 1));
                                    else
                                        grandtotal = subtotal + ShippingRate;
                                    Label50.Text = "$" + grandtotal.ToString();
                                    break;

                                case 2:
                                    Label56.Text = "$" + ShippingRate.ToString("#.00");
                                    Label56.Enabled = false;
                                    RadioButtonList1.Items[1].Enabled = true;
                                    break;

                                case 3:
                                    Label57.Text = "$" + ShippingRate.ToString("#.00");
                                    Label57.Enabled = false;
                                    RadioButtonList1.Items[2].Enabled = true;
                                    break;
                            }
                            RadioButtonList1.Items[1].Selected = false;
                            RadioButtonList1.Items[2].Selected = false;
                            RadioButtonList1.Items[3].Selected = false;
                            RadioButtonList1.Items[0].Selected = true;
                            Label58.Text = "";
                            Label58.Enabled = false;
                            RadioButtonList1.Items[3].Enabled = false;
                        }
                        else
                        {
                            //MessageBox.Show("here1a");
                            //MessageBox.Show(reply.Notifications[0].Message);
                            //Response.Write("here1a ");
                            //Response.Write(reply.Notifications[0].Message);
                        }
                    }
                    catch (SoapException eSoap)
                    {
                        //MessageBox.Show("here2");
                        //MessageBox.Show(eSoap.Detail.InnerText);
                        //Response.Write("here2 ");
                        //Response.Write(eSoap.Detail.InnerText);
                    }
                    catch (Exception eEx)
                    {
                        //MessageBox.Show("here3");
                        //MessageBox.Show(eEx.Message);
                        //Response.Write("here3 ");
                        //Response.Write(eEx.Message);
                    }
                }
            }
            else
            {
                request = CreateRateRequest(ServiceType.INTERNATIONAL_PRIORITY, CarrierCodeType.FDXE);

                RateService service = new RateService(); // Initialize the service
                try
                {
                    //MessageBox.Show("here1");
                    // Call the web service passing in a RateRequest and returning a RateReply
                    RateReply reply = service.getRates(request);
                    if (reply.HighestSeverity == NotificationSeverityType.SUCCESS || reply.HighestSeverity == NotificationSeverityType.NOTE || reply.HighestSeverity == NotificationSeverityType.WARNING) // check if the call was successful
                    {
                        //ShowRateReply(reply);
                        ShippingRate = GetRateReply(reply) + (DeclaredValue * Convert.ToDecimal(.70));
                        if (CheckBox1.Checked)
                            grandtotal = subtotal + ShippingRate + Convert.ToDecimal(Label48.Text.Substring(1, Label48.Text.Length - 1));
                        else
                            grandtotal = subtotal + ShippingRate;
                        Label50.Text = "$" + grandtotal.ToString();
                        Label55.Text = "";
                        Label56.Text = "";
                        Label57.Text = "";
                        Label58.Text = "$" + ShippingRate.ToString("#.00");
                        Label55.Enabled = false;
                        Label56.Enabled = false;
                        Label57.Enabled = false;
                        Label58.Enabled = true;
                        RadioButtonList1.Items[0].Selected = false;
                        RadioButtonList1.Items[1].Selected = false;
                        RadioButtonList1.Items[2].Selected = false;
                        RadioButtonList1.Items[3].Enabled = true;
                        RadioButtonList1.Items[3].Selected = true;
                    }
                    else
                    {
                        //MessageBox.Show("here1a");
                        //MessageBox.Show(reply.Notifications[0].Message);
                    }
                    RadioButtonList1.Items[0].Enabled = false;
                    RadioButtonList1.Items[1].Enabled = false;
                    RadioButtonList1.Items[2].Enabled = false;
                }
                catch (SoapException eSoap)
                {
                    //MessageBox.Show("here2");
                    //MessageBox.Show(eSoap.Detail.InnerText);
                }
                catch (Exception eEx)
                {
                    //MessageBox.Show("here3");
                    //MessageBox.Show(eEx.Message);
                }
            }
            CheckBox1.Enabled = true;
            Label48.Enabled = true;
            Button1.Enabled = true;
        }
        else
        {
            //Response.Write("here0-NOT");
        }
    }

    protected void RadioButtonList1_IndexChanged(object sender, EventArgs e)
    {
        switch (RadioButtonList1.SelectedIndex)
        {
            case 0:
                if (CheckBox1.Checked)
                {
                    Label55.Enabled = true;
                    Label56.Enabled = false;
                    Label57.Enabled = false;
                    Label58.Enabled = false;
                    grandtotal = subtotal + Convert.ToDecimal(Label55.Text.Substring(1, Label55.Text.Length - 1)) + Convert.ToDecimal(Label48.Text.Substring(1, Label48.Text.Length - 1));
                }
                else
                {
                    Label55.Enabled = true;
                    Label56.Enabled = false;
                    Label57.Enabled = false;
                    Label58.Enabled = false;
                    grandtotal = subtotal + Convert.ToDecimal(Label55.Text.Substring(1, Label55.Text.Length - 1));
                }
                break;

            case 1:
                if (CheckBox1.Checked)
                {
                    Label55.Enabled = false;
                    Label56.Enabled = true;
                    Label57.Enabled = false;
                    Label58.Enabled = false;
                    grandtotal = subtotal + Convert.ToDecimal(Label56.Text.Substring(1, Label56.Text.Length - 1)) + Convert.ToDecimal(Label48.Text.Substring(1, Label48.Text.Length - 1));
                }
                else
                {
                    Label55.Enabled = false;
                    Label56.Enabled = true;
                    Label57.Enabled = false;
                    Label58.Enabled = false;
                    grandtotal = subtotal + Convert.ToDecimal(Label56.Text.Substring(1, Label56.Text.Length - 1));
                }
                break;

            case 2:
                if (CheckBox1.Checked)
                {
                    Label55.Enabled = false;
                    Label56.Enabled = false;
                    Label57.Enabled = true;
                    Label58.Enabled = false;
                    grandtotal = subtotal + Convert.ToDecimal(Label57.Text.Substring(1, Label57.Text.Length - 1)) + Convert.ToDecimal(Label48.Text.Substring(1, Label48.Text.Length - 1));
                }
                else
                {
                    Label55.Enabled = false;
                    Label56.Enabled = false;
                    Label57.Enabled = true;
                    Label58.Enabled = false;
                    grandtotal = subtotal + Convert.ToDecimal(Label57.Text.Substring(1, Label57.Text.Length - 1));
                }
                break;

            case 3:
                if (CheckBox1.Checked)
                {
                    Label55.Enabled = false;
                    Label56.Enabled = false;
                    Label57.Enabled = false;
                    Label58.Enabled = true;
                    grandtotal = subtotal + Convert.ToDecimal(Label58.Text.Substring(1, Label58.Text.Length - 1)) + Convert.ToDecimal(Label48.Text.Substring(1, Label48.Text.Length - 1));
                }
                else
                {
                    Label55.Enabled = false;
                    Label56.Enabled = false;
                    Label57.Enabled = false;
                    Label58.Enabled = true;
                    grandtotal = subtotal + Convert.ToDecimal(Label58.Text.Substring(1, Label58.Text.Length - 1));
                }
                break;
        }
        Label50.Text = "$" + grandtotal.ToString();
    }

    protected void CheckBox1_Changed(object sender, EventArgs e)
    {
        switch (RadioButtonList1.SelectedIndex)
        {
            case 0:
                if (CheckBox1.Checked)
                    grandtotal = subtotal + Convert.ToDecimal(Label55.Text.Substring(1, Label55.Text.Length - 1)) + Convert.ToDecimal(Label48.Text.Substring(1, Label48.Text.Length - 1));
                else
                    grandtotal = subtotal + Convert.ToDecimal(Label55.Text.Substring(1, Label55.Text.Length - 1));
                break;

            case 1:
                if (CheckBox1.Checked)
                    grandtotal = subtotal + Convert.ToDecimal(Label56.Text.Substring(1, Label56.Text.Length - 1)) + Convert.ToDecimal(Label48.Text.Substring(1, Label48.Text.Length - 1));
                else
                    grandtotal = subtotal + Convert.ToDecimal(Label56.Text.Substring(1, Label56.Text.Length - 1));
                break;

            case 2:
                if (CheckBox1.Checked)
                    grandtotal = subtotal + Convert.ToDecimal(Label57.Text.Substring(1, Label57.Text.Length - 1)) + Convert.ToDecimal(Label48.Text.Substring(1, Label48.Text.Length - 1));
                else
                    grandtotal = subtotal + Convert.ToDecimal(Label57.Text.Substring(1, Label57.Text.Length - 1));
                break;

            case 3:
                if (CheckBox1.Checked)
                    grandtotal = subtotal + Convert.ToDecimal(Label58.Text.Substring(1, Label58.Text.Length - 1)) + Convert.ToDecimal(Label48.Text.Substring(1, Label48.Text.Length - 1));
                else
                    grandtotal = subtotal + Convert.ToDecimal(Label58.Text.Substring(1, Label58.Text.Length - 1));
                break;
        }
        Label50.Text = "$" + grandtotal.ToString();
    }

    protected void CheckBox2_Changed(object sender, EventArgs e)
    {
        if (CheckBox2.Checked)
        {
            DropDownList6.SelectedValue = DropDownList4.SelectedValue;
            TextBox11.Text = TextBox4.Text;
            TextBox12.Text = TextBox5.Text;
            TextBox13.Text = TextBox6.Text;
            if (DropDownList4.SelectedValue.Equals("248") || DropDownList4.SelectedValue.Equals("287"))
            {
                DropDownList7.Visible = true;
                TextBox14.Visible = false;
                TextBox14.Text = "";
                DropDownList7.Items.Clear();
                DropDownList7.Items.Add("Select State/Province");
                DropDownList7.Items[0].Value = "0";
                x = 0;
                TList<StateProvince> states = DataRepository.StateProvinceProvider.GetByCountry(Convert.ToInt16(DropDownList6.SelectedValue));
                foreach (StateProvince sp in states)
                {
                    x++;
                    DropDownList7.Items.Add(sp.StateProvinceName);
                    DropDownList7.Items[x].Value = sp.StateProvinceAbbvr;
                }
                DropDownList7.SelectedValue = DropDownList5.SelectedValue;
            }
            else
            {
                DropDownList7.Visible = false;
                TextBox14.Visible = true;
                TextBox14.Text = TextBox7.Text;
                DropDownList7.SelectedValue = "0";
            }
            TextBox15.Text = TextBox8.Text;
            TextBox16.Text = TextBox9.Text;

            Label55.Text = "";
            Label56.Text = "";
            Label57.Text = "";
            Label58.Text = "";
            RadioButtonList1.Items[1].Selected = false;
            RadioButtonList1.Items[2].Selected = false;
            RadioButtonList1.Items[3].Selected = false;
            RadioButtonList1.Items[0].Selected = true;
            for (int i = 0; i < RadioButtonList1.Items.Count; i++)
            {
                RadioButtonList1.Items[i].Enabled = false;
            }
            CheckBox1.Enabled = false;
            Label48.Text = "";
            Button1.Enabled = false;
        }
        else
        {
            DropDownList6.SelectedValue = "0";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";
            TextBox14.Text = "";
            TextBox14.Visible = true;
            DropDownList7.SelectedValue = "0";
            DropDownList7.Visible = false;
            TextBox15.Text = "";
            TextBox16.Text = "";

            Label55.Text = "";
            Label56.Text = "";
            Label57.Text = "";
            Label58.Text = "";
            RadioButtonList1.Items[1].Selected = false;
            RadioButtonList1.Items[2].Selected = false;
            RadioButtonList1.Items[3].Selected = false;
            RadioButtonList1.Items[0].Selected = true;
            for (int i = 0; i < RadioButtonList1.Items.Count; i++)
            {
                RadioButtonList1.Items[i].Enabled = false;
            }
            CheckBox1.Enabled = false;
            Label48.Text = "";
            Button1.Enabled = false;
        }
    }
 
    public RateRequest CreateRateRequest(ServiceType st, CarrierCodeType cct)
    {
        // Build the RateRequest
        RateRequest request = new RateRequest();
        
        request.WebAuthenticationDetail = new WebAuthenticationDetail();
        request.WebAuthenticationDetail.UserCredential = new WebAuthenticationCredential();
        //request.WebAuthenticationDetail.UserCredential.Key = "XXX"; // Replace "XXX" with the Key
        //request.WebAuthenticationDetail.UserCredential.Key = "ALC47LaRZ9c5gT0A"; // Test Key
        request.WebAuthenticationDetail.UserCredential.Key = "C8wxZ9zCCug3URNb"; // Production Key
        //request.WebAuthenticationDetail.UserCredential.Password = "XXX"; // Replace "XXX" with the Password
        //request.WebAuthenticationDetail.UserCredential.Password = "flRCkb4O0HZInjD1c7uX3TaK2"; // First Test Password
        //request.WebAuthenticationDetail.UserCredential.Password = "GFwj8Mb5hvEAZghgYCn6LmBmh"; // Second Test Password
        request.WebAuthenticationDetail.UserCredential.Password = "ibWogufK4SVdhWQlONrOV1Lf2"; // Production Password
        
        request.ClientDetail = new ClientDetail();
        //request.ClientDetail.AccountNumber = "XXX"; // Replace "XXX" with client's account number
        //request.ClientDetail.AccountNumber = "510087100"; // Test account number
        request.ClientDetail.AccountNumber = "171580889"; // Production account number
        //request.ClientDetail.MeterNumber = "XXX"; // Replace "XXX" with client's meter number
        //request.ClientDetail.MeterNumber = "100034318"; // Test meter number
        request.ClientDetail.MeterNumber = "102227968"; // Production meter number
        
        request.TransactionDetail = new TransactionDetail();
        request.TransactionDetail.CustomerTransactionId = "***Rate v9 Request using VC#***"; // This is a reference field for the customer.  Any value can be used and will be provided in the response.
        
        request.Version = new VersionId(); // WSDL version information, value is automatically set from wsdl
        
        SetShipmentDetails(request, st, cct);
        
        SetOrigin(request);
        
        SetDestination(request);
        
        SetPayment(request);
        
        //SetSmartPostDetails(request);
        
        SetIndividualPackageLineItems(request);
        
        return request;
    }

    public void SetShipmentDetails(RateRequest request, ServiceType st, CarrierCodeType cct)
    {
        request.RequestedShipment = new RequestedShipment();
        request.RequestedShipment.DropoffType = DropoffType.BUSINESS_SERVICE_CENTER;
        //request.RequestedShipment.ServiceType = ServiceType.SMART_POST; // Service type is SmartPost
        request.RequestedShipment.ServiceType = st;
        request.RequestedShipment.ServiceTypeSpecified = true;
        request.RequestedShipment.PackagingType = PackagingType.YOUR_PACKAGING;
        request.RequestedShipment.PackagingTypeSpecified = true;
        
        request.RequestedShipment.TotalInsuredValue = new Money();
        //request.RequestedShipment.TotalInsuredValue.Amount = 100;
        request.RequestedShipment.TotalInsuredValue.Amount = Convert.ToDecimal(subtotal);
        request.RequestedShipment.TotalInsuredValue.Currency = "USD";
        request.RequestedShipment.TotalInsuredValue.AmountSpecified = true;
        request.RequestedShipment.ShipTimestamp = DateTime.Now; // Shipping date and time
        request.RequestedShipment.ShipTimestampSpecified = true;
        request.RequestedShipment.RateRequestTypes = new RateRequestType[2];
        request.RequestedShipment.RateRequestTypes[0] = RateRequestType.ACCOUNT;
        request.RequestedShipment.RateRequestTypes[1] = RateRequestType.LIST;
        request.RequestedShipment.PackageDetail = RequestedPackageDetailType.INDIVIDUAL_PACKAGES;
        request.RequestedShipment.PackageDetailSpecified = true;
        
        request.ReturnTransitAndCommit = true;
        request.ReturnTransitAndCommitSpecified = true;
        request.CarrierCodes = new CarrierCodeType[1];
        //CarrierCodeType: The carrier code to use for the query. In most
        //    cases, this will be FDXE (Fedex Express). Must be one of the
        //    following four-letter codes:
        //        - FDXC (Fedex Cargo)
        //        - FDXE (Fedex Express)
        //        - FDXG (Fedex Ground)
        //        - FXCC (Fedex Custom Critical)
        //        - FXFR (Fedex Freight)
        //        - FXSP (Fedex Smartpost)
        //request.CarrierCodes[0] = CarrierCodeType.FXSP; // FXSP is for SmartPost
        request.CarrierCodes[0] = cct;
        // Variable Options are Optional
        //request.VariableOptions = new ServiceOptionType[1];
        //request.VariableOptions[0] = ServiceOptionType.SMART_POST_ALLOWED_INDICIA;
    }

    public void SetOrigin(RateRequest request)
    {
        CountryLookup countrylookup = new CountryLookup();
        countrylookup = DataRepository.CountryLookupProvider.GetByCountryId(clubbuilder.Country);

        request.RequestedShipment.Shipper = new Party();
        request.RequestedShipment.Shipper.Address = new Address();
        //request.RequestedShipment.Shipper.Address.StreetLines = new string[1] { "Sender Address Line 1" };
        //request.RequestedShipment.Shipper.Address.City = "Austin";
        //request.RequestedShipment.Shipper.Address.StateOrProvinceCode = "TX";
        //request.RequestedShipment.Shipper.Address.PostalCode = "73301";
        //request.RequestedShipment.Shipper.Address.CountryCode = "US";
        request.RequestedShipment.Shipper.Address.StreetLines = new string[2] { clubbuilder.Address1, clubbuilder.Address2 };
        request.RequestedShipment.Shipper.Address.City = clubbuilder.City;
        request.RequestedShipment.Shipper.Address.StateOrProvinceCode = clubbuilder.State;
        request.RequestedShipment.Shipper.Address.PostalCode = clubbuilder.Zip;
        request.RequestedShipment.Shipper.Address.CountryCode = countrylookup.CountryAbbvr;
    }

    public void SetDestination(RateRequest request)
    {
        CountryLookup countrylookup = new CountryLookup();
        countrylookup = DataRepository.CountryLookupProvider.GetByCountryId(Convert.ToInt16(DropDownList6.SelectedValue));

        request.RequestedShipment.Recipient = new Party();
        request.RequestedShipment.Recipient.Address = new Address();
        //request.RequestedShipment.Recipient.Address.StreetLines = new string[1] { "Recipient Address Line 1" };
        //request.RequestedShipment.Recipient.Address.City = "Collierville";
        //request.RequestedShipment.Recipient.Address.StateOrProvinceCode = "TN";
        //request.RequestedShipment.Recipient.Address.PostalCode = "38017";
        //request.RequestedShipment.Recipient.Address.CountryCode = "US";
        request.RequestedShipment.Recipient.Address.StreetLines = new string[2] { TextBox11.Text, TextBox12.Text };
        request.RequestedShipment.Recipient.Address.City = TextBox13.Text;
        if (DropDownList7.Visible)
        {
            request.RequestedShipment.Recipient.Address.StateOrProvinceCode = DropDownList7.SelectedValue;
        }
        else
            request.RequestedShipment.Recipient.Address.StateOrProvinceCode = TextBox14.Text;
        request.RequestedShipment.Recipient.Address.PostalCode = TextBox15.Text;
        request.RequestedShipment.Recipient.Address.CountryCode = countrylookup.CountryAbbvr;
        request.RequestedShipment.Recipient.Address.Residential = true;
        request.RequestedShipment.Recipient.Address.ResidentialSpecified = true;
    }

    public void SetPayment(RateRequest request)
    {
        request.RequestedShipment.ShippingChargesPayment = new Payment();
        request.RequestedShipment.ShippingChargesPayment.PaymentType = PaymentType.SENDER; // Payment options are RECIPIENT, SENDER, THIRD_PARTY
        request.RequestedShipment.ShippingChargesPayment.PaymentTypeSpecified = true;
        request.RequestedShipment.ShippingChargesPayment.Payor = new Payor();
        //request.RequestedShipment.ShippingChargesPayment.Payor.AccountNumber = "XXX"; // Replace "XXX" with client's account number
        //request.RequestedShipment.ShippingChargesPayment.Payor.AccountNumber = "510087100"; // Test account number
        request.RequestedShipment.ShippingChargesPayment.Payor.AccountNumber = "171580889"; // Production account number
    }

    public void SetSmartPostDetails(RateRequest request)
    {
        request.RequestedShipment.SmartPostDetail = new SmartPostShipmentDetail();
        request.RequestedShipment.SmartPostDetail.Indicia = SmartPostIndiciaType.PARCEL_SELECT;
        request.RequestedShipment.SmartPostDetail.IndiciaSpecified = true;
        request.RequestedShipment.SmartPostDetail.AncillaryEndorsement = SmartPostAncillaryEndorsementType.ADDRESS_CORRECTION; // Replace with a valid ancillary endorsement type
        request.RequestedShipment.SmartPostDetail.AncillaryEndorsementSpecified = true;
        request.RequestedShipment.SmartPostDetail.HubId = "XXX"; // Replace "XXX" with the hub id
    }

    public void SetIndividualPackageLineItems(RateRequest request)
    {
        // ------------------------------------------
        // Passing individual pieces rate request
        // ------------------------------------------
        request.RequestedShipment.PackageCount = "1";
        
        request.RequestedShipment.RequestedPackageLineItems = new RequestedPackageLineItem[2];
        request.RequestedShipment.RequestedPackageLineItems[0] = new RequestedPackageLineItem();
        request.RequestedShipment.RequestedPackageLineItems[0].SequenceNumber = "1"; // package sequence number
        
        request.RequestedShipment.RequestedPackageLineItems[0].Weight = new Weight(); // package weight
        request.RequestedShipment.RequestedPackageLineItems[0].Weight.Units = WeightUnits.LB;
        //request.RequestedShipment.RequestedPackageLineItems[0].Weight.Value = 15.0M;
        request.RequestedShipment.RequestedPackageLineItems[0].Weight.Value = Convert.ToDecimal(NumberClubs);
        
        request.RequestedShipment.RequestedPackageLineItems[0].Dimensions = new Dimensions(); // package dimensions
        request.RequestedShipment.RequestedPackageLineItems[0].Dimensions.Length = "48";
        if (NumberClubs < 5)
        {
            request.RequestedShipment.RequestedPackageLineItems[0].Dimensions.Width = "6";
            request.RequestedShipment.RequestedPackageLineItems[0].Dimensions.Height = "6";
        }
        else
        {
            request.RequestedShipment.RequestedPackageLineItems[0].Dimensions.Width = "12";
            request.RequestedShipment.RequestedPackageLineItems[0].Dimensions.Height = "12";
        }
        request.RequestedShipment.RequestedPackageLineItems[0].Dimensions.Units = LinearUnits.IN;
    }

    public void ShowRateReply(RateReply reply)
    {
        //MessageBox.Show("RateReply details:");
        foreach (RateReplyDetail rateDetail in reply.RateReplyDetails)
        {
            //MessageBox.Show("ServiceType : " + rateDetail.ServiceType);
            //MessageBox.Show("**********************************************************");
            foreach (RatedShipmentDetail shipmentDetail in rateDetail.RatedShipmentDetails)
            {
                ShowPackageRateDetails(shipmentDetail);
            }
            //ShowDeliveryDetails(rateDetail);
        }
    }

    public decimal GetRateReply(RateReply reply)
    {
        decimal ShippingRate;
        decimal HandlingFee = Convert.ToDecimal(7.5);

        ShippingRate = reply.RateReplyDetails[0].RatedShipmentDetails[0].ShipmentRateDetail.TotalNetCharge.Amount + HandlingFee;

        return ShippingRate;
    }

    public void ShowPackageRateDetails(RatedShipmentDetail shipmentDetail)
    {
        //MessageBox.Show("RateType : " + shipmentDetail.ShipmentRateDetail.RateType);
        //MessageBox.Show("Total Billing Weight : " + shipmentDetail.ShipmentRateDetail.TotalBillingWeight.Value);
        //MessageBox.Show("Total Base Charge : " + shipmentDetail.ShipmentRateDetail.TotalBaseCharge.Amount);
        //MessageBox.Show("Total Discount : " + shipmentDetail.ShipmentRateDetail.TotalFreightDiscounts.Amount);
        //MessageBox.Show("Total Surcharges : " + shipmentDetail.ShipmentRateDetail.TotalSurcharges.Amount);
        //MessageBox.Show("Net Charge : " + shipmentDetail.ShipmentRateDetail.TotalNetCharge.Amount);
        //MessageBox.Show("**********************************************************");
    }

    public void ShowDeliveryDetails(RateReplyDetail rateDetail)
    {
        if (rateDetail.DeliveryTimestampSpecified)
        {
            //MessageBox.Show("Delivery timestamp " + rateDetail.DeliveryTimestamp.ToString());
        }
        //MessageBox.Show("Transit Time: " + rateDetail.TransitTime);
    }

    public void SendOrderEmails(string CustomerEmail, string BuilderEmail, string CustomerSiteEmail)
    {
        MailAddress from1 = new MailAddress("info@swingmodel.com");
        MailAddress to1 = new MailAddress(CustomerEmail);
        MailAddress cc1CSE = new MailAddress(CustomerSiteEmail);
        MailAddress cc1SM = new MailAddress("dev@swingmodel.com");
        MailMessage message1 = new MailMessage(from1, to1);
        message1.CC.Add(cc1CSE);
        message1.CC.Add(cc1SM);

        message1.IsBodyHtml = true;
        message1.Subject = "SwingModel Club Order - Order #" + order.OrderId.ToString();
        message1.Body = "<html>"
            + "<head>"
            + "<title></title>"
            + "<style type=\"text/css\">"
            + ".style1"
            + "{"
            + "text-align: justify;"
            + "}"
            + "</style>"
            + "</head>"
            + "<body style=\"font-family: Calibri; font-size: small; width: 980px;\">"
            + "<p style=\"text-align: left\">"
            + "<img alt=\"\" src=\"http://www.swingmodel.com/Images/EmailHeader.jpg\" width=\"980\" height=\"151\" /></p>"
            + "<p>"
            + "Dear " + customer.FirstName + " " + customer.LastName + ",</p>"
            + "<p>"
            + "Your SwingModel Club Order is listed below:</p>"
            + "<p></p>"
            + "<table cellpadding='0' cellspacing='0' width='925'>"
            + "<tr>"
            + "<td width='300'>Club</td>"
            + "<td align='center' width='50'>Lie</td>"
            + "<td align='center' width='50'>Loft</td>"
            + "<td width='300'>Shaft</td>"
            + "<td align='center' width='75'>Frequency</td>"
            + "<td align='center' width='50'>Length</td>"
            + "<td align='center' width='100'>Cost</td>"
            + "</tr>";
        foreach (ClubOrder co in cluborder)
        {
            message1.Body = message1.Body + "<tr>"
                + "<td width='300' valign='top'>"
                + co.Club + "</td>"
                + "<td align='center' width='50' valign='top'>"
                + co.Lie + "</td>"
                + "<td align='center' width='50' valign='top'>"
                + co.Loft.ToString() + "</td>"
                + "<td width='300' valign='top'>"
                + co.Shaft + "</td>"
                + "<td align='center' width='75' valign='top'>"
                + co.Frequency.ToString() + "</td>"
                + "<td align='center' width='50' valign='top'>"
                + co.Length.ToString() + " </td>"
                + "<td align='right' width='100' valign='top'>"
                + "$" + co.Cost.ToString() + "</td>"
                + "</tr>";
        }
        message1.Body = message1.Body + "</table>"
            + "<br>"
            + "<table cellpadding='0' cellspacing='0' width='925'>"
            + "<tr>"
            + "<td align='right' width='825'><b>Order Subtotal:</b></td>"
            + "<td align='right' width='100'>$" + order.Subtotal.ToString() + "</td>"
            + "</tr>"
            + "<tr>"
            + "<td align='right' width='825'><b>Shipping Amount:</b></td>"
            + "<td align='right' width='100'>$" + order.ShippingCost.ToString() + "</td>"
            + "</tr>"
            + "<tr>";
        if (order.Expedite.Value.Equals(1))
        {
            message1.Body = message1.Body + "<td align='right' width='825'><b>Expedite Fee:</b></td>"
                + "<td align='right' width='100'>$" + order.ExpediteCost.ToString() + "</td>"
                + "</tr>"
                + "<tr>";
        }
        else
        {
            message1.Body = message1.Body + "<td align='right' width='825'><b>Expedite Fee:</b></td>"
                + "<td align='right' width='100'>$0.00</td>"
                + "</tr>"
                + "<tr>";
        }
        message1.Body = message1.Body + "<td align='right' width='825'><b>Grand Total:</b></td>"
            + "<td align='right' width='100'>$" + order.GrandTotal.ToString() + "</td>"
            + "</tr>"
            + "</table>";
        ShippingMethodLookup smo = new ShippingMethodLookup();
        smo = DataRepository.ShippingMethodLookupProvider.GetByShippingMethodLookupId(order.ShippingMethod.Value);
        message1.Body = message1.Body + "<p>"
            + "Your order will be shipped via " + smo.ShippingMethodText + "</p>"
            + "<p></p>"
            + "<p>"
            + "Ship to:<br>"
            + customer.FirstName + " " + customer.LastName + "<br>"
            + order.ShippingAddress1 + "<br>";
        try
        {
            string sa2 = order.ShippingAddress2;
            if (!sa2.Equals("") && !sa2.Equals(null))
                message1.Body = message1.Body + sa2 + "<br>";
        }
        catch { }
        message1.Body = message1.Body + order.ShippingCity
            + " " + order.ShippingState
            + " " + order.ShippingZip + "<br>";
        CountryLookup cl = new CountryLookup();
        cl = DataRepository.CountryLookupProvider.GetByCountryId(order.ShippingCountry.Value);
        message1.Body = message1.Body + cl.CountryName + "</p>"
            + "<p>"
            + "If you have any questions, please email us at <a href='mailto:info@swingmodel.com'>info@swingmodel.com</a>, or call 702-879-8337.</p>";

        Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
        MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
        SmtpClient client = new SmtpClient(settings.Smtp.Network.Host);
        try
        {
            client.Send(message1);
        }
        catch (Exception ex)
        {
        }

        MailAddress from2 = new MailAddress("info@swingmodel.com");
        MailAddress to2 = new MailAddress(BuilderEmail);
        MailMessage message2 = new MailMessage(from2, to2);
        message2.CC.Add(cc1SM);

        message2.IsBodyHtml = true;
        message2.Subject = "SwingModel Club Build Order - Order #" + order.OrderId.ToString();
        message2.Body = "<html>"
            + "<head>"
            + "<title></title>"
            + "<style type=\"text/css\">"
            + ".style1"
            + "{"
            + "text-align: justify;"
            + "}"
            + "</style>"
            + "</head>"
            + "<body style=\"font-family: Calibri; font-size: small; width: 980px;\">"
            + "<p style=\"text-align: left\">"
            + "<img alt=\"\" src=\"http://www.swingmodel.com/Images/EmailHeader.jpg\" width=\"980\" height=\"151\" /></p>"
            + "<p>"
            + "The following SwingModel Club Order has been placed:</p>"
            + "<p></p>"
            + "<table cellpadding='0' cellspacing='0' width='1190'>"
            + "<tr>"
            + "<td width='300'>Club</td>"
            + "<td align='center' width='50'>Lie</td>"
            + "<td align='center' width='50'>Loft</td>"
            + "<td width='300'>Shaft</td>"
            + "<td align='center' width='75'>Frequency</td>"
            + "<td align='center' width='50'>Length</td>"
            + "<td align='center' width='150'>Grip</td>"
            + "<td aligh='center' width='75'>Size</td>"
            + "<td align='center' width='100'>Cost</td>"
            + "<td align='center' width='40'>Notes</td>"
            + "</tr>";
        foreach (ClubOrder co in cluborder)
        {
            message2.Body = message2.Body + "<tr>"
                + "<td width='300' valign='top'>"
                + co.Club + "</td>"
                + "<td align='center' width='50' valign='top'>"
                + co.Lie + "</td>"
                + "<td align='center' width='50' valign='top'>"
                + co.Loft.ToString() + "</td>"
                + "<td width='300' valign='top'>"
                + co.Shaft + "</td>"
                + "<td align='center' width='75' valign='top'>"
                + co.Frequency.ToString() + "</td>"
                + "<td align='center' width='50' valign='top'>"
                + co.Length.ToString() + " </td>"
                + "<td align='center' width='150' valign='top'>"
                + co.Grip + "</td>"
                + "<td aligh='center' width='75' valign='top'>"
                + co.GripSize + "</td>"
                + "<td align='right' width='100' valign='top'>"
                + "$" + co.Cost.ToString() + "</td>"
                + "<td align='center' width='40' valign='top'>"
                + co.FitType.ToString() + "</td>"
                + "</tr>";
        }
        message2.Body = message2.Body + "</table>"
            + "<br>"
            + "<table cellpadding='0' cellspacing='0' width='1190'>"
            + "<tr>"
            + "<td align='right' width='1050'><b>Order Subtotal:</b></td>"
            + "<td align='right' width='100'>$" + order.Subtotal.ToString() + "</td>"
            + "<td width='40'>&nbsp;</td>"
            + "</tr>"
            + "<tr>"
            + "<td align='right' width='1050'><b>Shipping Amount:</b></td>"
            + "<td align='right' width='100'>$" + order.ShippingCost.ToString() + "</td>"
            + "<td width='40'>&nbsp;</td>"
            + "</tr>"
            + "<tr>";
        if (order.Expedite.Value.Equals(1))
        {
            message2.Body = message2.Body + "<td align='right' width='1050'><b>Expedite Fee:</b></td>"
                + "<td align='right' width='100'>$" + order.ExpediteCost.ToString() + "</td>"
                + "<td width='40'>&nbsp;</td>"
                + "</tr>"
                + "<tr>";
        }
        else
        {
            message2.Body = message2.Body + "<td align='right' width='1050'><b>Expedite Fee:</b></td>"
                + "<td align='right' width='100'>$0.00</td>"
                + "<td width='40'>&nbsp;</td>"
                + "</tr>"
                + "<tr>";
        }
        message2.Body = message2.Body + "<td align='right' width='1050'><b>Grand Total:</b></td>"
            + "<td align='right' width='100'>$" + order.GrandTotal.ToString() + "</td>"
            + "<td width='40'>&nbsp;</td>"
            + "</tr>"
            + "</table>";
        message2.Body = message2.Body + "<p>"
            + "Ship the order via " + smo.ShippingMethodText + "</p>"
            + "<p></p>"
            + "<p>"
            + "Ship to:<br>"
            + customer.FirstName + " " + customer.LastName + "<br>"
            + order.ShippingAddress1 + "<br>";
        try
        {
            string sa2 = order.ShippingAddress2;
            if (!sa2.Equals("") && !sa2.Equals(null))
                message1.Body = message1.Body + sa2 + "<br>";
        }
        catch { }
        message2.Body = message2.Body + order.ShippingCity
            + " " + order.ShippingState
            + " " + order.ShippingZip + "<br>";
        message2.Body = message2.Body + cl.CountryName + "</p>";
        message2.Body = message2.Body + "<p>";
        bool AddNotes1 = false;
        bool AddNotes2 = false;
        bool AddNotes3 = false;
        bool AddNotes4 = false;
        string Notes1 = "";
        string Notes2 = "";
        string Notes3 = "";
        string Notes4 = "";
        foreach (ClubOrder co in cluborder)
        {
            if (co.FitType.Equals(1))
            {
                AddNotes1 = true;
                Notes1 = co.Notes;
            }
            if (co.FitType.Equals(2))
            {
                AddNotes2 = true;
                Notes2 = co.Notes;
            }
            if (co.FitType.Equals(3))
            {
                AddNotes3 = true;
                Notes3 = co.Notes;
            }
            if (co.FitType.Equals(4))
            {
                AddNotes4 = true;
                Notes4 = co.Notes;
            }
        }
        if (AddNotes1)
            message2.Body = message2.Body + "Notes (1): "
                + Notes1 + "<br>";
        if (AddNotes2)
            message2.Body = message2.Body + "Notes (2): "
                + Notes2 + "<br>";
        if (AddNotes3)
            message2.Body = message2.Body + "Notes (3): "
                + Notes3 + "<br>";
        if (AddNotes4)
            message2.Body = message2.Body + "Notes (4): "
                + Notes4 + "<br>";

        try
        {
            client.Send(message2);
        }
        catch (Exception ex)
        {
        }
    }
}
