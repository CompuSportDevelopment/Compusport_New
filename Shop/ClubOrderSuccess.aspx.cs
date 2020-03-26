using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Text;
using System.IO;
using System.Net;
using SwingModel.Data;
using SwingModel.Entities;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Web.Services.Protocols;

//public partial class Shop_ClubOrderSuccess : System.Web.UI.Page
public partial class Shop_ClubOrderSuccess : SwingModel.UI.BasePage
{
    Customer customer = new Customer();
    CustomerProfile customerprofile = new CustomerProfile();
    Order order = new Order();
    TList<ClubOrder> cluborder = new TList<ClubOrder>();
    bool customerexists = false;
    bool customerprofileexists = false;
    string strOrderId;

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
        }
        catch
        {
            //no entery in CustomerProfile table for current member
            customerprofileexists = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        ShippingMethodLookup sml = new ShippingMethodLookup();
        string FullShippingAddress;
        CountryLookup countrylookup = new CountryLookup();

        strOrderId = Request.QueryString.Get("orderid");
        //MessageBox.Show(strOrderId);
        order = DataRepository.OrderProvider.GetByOrderId(Convert.ToInt16(strOrderId));
        cluborder = DataRepository.ClubOrderProvider.GetByOrderId(Convert.ToInt16(strOrderId));

        Label1.Text = customer.FirstName + " " + customer.LastName;
        Label8.Text = order.OrderId.ToString();
        Label9.Text = order.OrderDate.ToString();
        Label2.Text = "$" + order.Subtotal.ToString();
        Label3.Text = "$" + order.ShippingCost.ToString();
        if (order.Expedite.Equals(1))
            Label4.Text = "$" + order.ExpediteCost.ToString();
        else
            Label4.Text = "$0.00";
        Label5.Text = "$" + order.GrandTotal;

        sml = DataRepository.ShippingMethodLookupProvider.GetByShippingMethodLookupId(order.ShippingMethod.Value);
        Label6.Text = sml.ShippingMethodText;

        FullShippingAddress = customer.FirstName + " " + customer.LastName + "<br>"
            + order.ShippingAddress1 + "<br>";
        try
        {
            string sa2 = order.ShippingAddress2;
            if (!sa2.Equals("") && !sa2.Equals(null))
                FullShippingAddress = FullShippingAddress + order.ShippingAddress2 + "<br>";
        }
        catch { }
        FullShippingAddress = FullShippingAddress + order.ShippingCity
            + " " + order.ShippingState
            + " " + order.ShippingZip + "<br>";
        countrylookup = DataRepository.CountryLookupProvider.GetByCountryId(order.ShippingCountry.Value);
        FullShippingAddress = FullShippingAddress + countrylookup.CountryName + "<br>";
        Label7.Text = FullShippingAddress;

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
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://www.swingmodel.com/Users/Default.aspx");
    }
}
