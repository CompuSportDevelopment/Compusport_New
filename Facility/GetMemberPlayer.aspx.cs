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
using System.IO;
using MemberDownload;
using SwingModel.Data;
using SwingModel.Entities;

public partial class Admin_GetMemberPlayer : System.Web.UI.Page
{
    public TList<CustomerSite> customersites = new TList<CustomerSite>();
    public CustomerSite customersite;
    public TList<TeacherSite> teachersatsite = new TList<TeacherSite>();
    public Teacher teacher;
    public Customer customer;
    public CustomerProfile customerprofile;
    public TList<CustomerProfile> customerprofiles = new TList<CustomerProfile>();

    protected void Page_Load(object sender, EventArgs e)
    {
        customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
        customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customer.CustomerId)[0];
        int SelectedFacility = customerprofile.CustomerSite;
        Button2.Attributes.Add("onClick", "return getAlert()");

        if (!SelectedFacility.Equals(-1))
        {
            if (DropDownList2.Items.Count.Equals(0))
            //if (!SelectedFacility.Equals(0))
            {
                teachersatsite = DataRepository.TeacherSiteProvider.GetBySiteId(SelectedFacility);
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add("Make a Selection");
                DropDownList2.Items[0].Value = "-1";
                int x = 0;
                foreach (TeacherSite ts in teachersatsite)
                {
                    x++;
                    teacher = DataRepository.TeacherProvider.GetByTeacherId(ts.TeacherId);
                    customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(teacher.AspnetMembershipUserId)[0];
                    customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customer.CustomerId)[0];
                    DropDownList2.Items.Add(teacher.FirstName + " " + teacher.LastName);
                    DropDownList2.Items[x].Value = teacher.TeacherId.ToString();
                }
            }
            //else
            //{
            //    DropDownList2.Items.Clear();
            //}
        }
        else
        {
            DropDownList2.Items.Clear();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        bool DoSubmit = false;
        ListBox1.Items.Clear();

        if (TextBox1.Text.Equals("") || TextBox1.Text.Equals(null))
        {
            TextBox1.Text = "Select a Date";
            DoSubmit = false;
        }
        else
        {
            try
            {
                DateTime.Parse(TextBox1.Text);
                DoSubmit = true;
            }
            catch
            {
                DoSubmit = false;
            }
        }

        if (TextBox2.Text.Equals("") || TextBox2.Text.Equals(null))
        {
            TextBox2.Text = "Select a Date";
            DoSubmit = false;
        }
        else
        {
            try
            {
                DateTime.Parse(TextBox2.Text);
                if (DoSubmit)
                    DoSubmit = true;
            }
            catch
            {
                DoSubmit = false;
            }
        }

        if (DropDownList2.SelectedValue.Equals("-1") || DropDownList2.SelectedValue.Equals(null))
        {
            DoSubmit = false;
        }
        else
        {
            if (DoSubmit)
                DoSubmit = true;
        }

        if (DoSubmit)
        {
            if (DateTime.Parse(TextBox2.Text) < DateTime.Parse(TextBox1.Text))
                TextBox2.Text = "Select a Later Date";
            else
            {
                try
                {
                DataTable dt = new DataTable();
                dt.Columns.Add("FirstName",typeof(string));
                dt.Columns.Add("LastName", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Username", typeof(string));
                dt.Columns.Add("CustomerId", typeof(int));
                customerprofiles = DataRepository.CustomerProfileProvider.GetByTeacher(Convert.ToInt16(DropDownList2.SelectedValue));
                foreach (CustomerProfile cs in customerprofiles)
                {
                    customer = DataRepository.CustomerProvider.GetByCustomerId(cs.CustomerId);
                    MembershipUser user = Membership.GetUser(customer.AspnetMembershipUserId);
                    //MessageBox.Show("user: " + user.UserName);
                    try
                    {
                        if (user.CreationDate >= DateTime.Parse(TextBox1.Text) && user.CreationDate <= DateTime.Parse(TextBox2.Text))
                            dt.Rows.Add(customer.FirstName, customer.LastName, user.Email, user.UserName, customer.CustomerId);
                    }
                    catch {}
                   
                }
                DataRow[] foundRows;
                foundRows = dt.Select(null, "LastName ASC, FirstName ASC, Username ASC");

                if (dt.Rows.Count.Equals(0))
                {
                    ListBox1.Items.Add("No Matches");
                }
                else
                {
                    int x = 0;
                    string ListBoxItem = "";
                    foreach (DataRow dr in foundRows)
                    {
                        ListBoxItem = dr.Field<string>("FirstName") + " " + dr.Field<string>("LastName") + ", " + dr.Field<string>("Email") + ", " + dr.Field<string>("Username");

                        ListBox1.Items.Add(ListBoxItem);
                        ListBox1.Items[x].Value = dr.Field<int>("CustomerId") + "," + dr.Field<string>("Username") + "|" + dr.Field<string>("Email");
                        x++;
                    }
                }
            }
            catch(Exception ex)
            {
            }
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (!ListBox1.SelectedValue.Equals("No Matches") && !ListBox1.Items.Count.Equals(0))
        {
            int x = ListBox1.SelectedIndex;
            if (x >= 0)
            {
                int comma = ListBox1.Items[x].Value.IndexOf(",");
                int customerid = Convert.ToInt16(ListBox1.Items[x].Value.Substring(0, comma));

                //this.Page.Response.Redirect("~/Facility/GetMemberPlayer.aspx?customerid=" + customerid.ToString());
              // this.Server.Transfer("~/Admin/SummaryPlayer.aspx?customerid=" + customerid.ToString());
                this.Page.Response.Redirect("~/Admin/SummaryPlayer.aspx?customerid=" + customerid.ToString());

            }
            else
            {
                Button2.Attributes.Add("onClick", "return getAlert()");

            }
        }
    }
}
