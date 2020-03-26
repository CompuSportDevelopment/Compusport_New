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
using System.Security.Principal;
using CompuSportDAL;


//public partial class Teachers_MemberSearch : System.Web.UI.Page
public partial class Teachers_MemberSearch : SwingModel.UI.BasePage
{
    public GetMemberList gml = new GetMemberList();
    string FirstName = "";
    string LastName = "";
    string EmailAddress = "";

    Customer customer = new Customer();
    CustomerProfile customerprofile = new CustomerProfile();
    CountryLookup countrylookup = new CountryLookup();
    CustomerSite customersite = new CustomerSite();
    Teacher teacher = new Teacher();
    Teacher teacher1 = new Teacher();
    SprintAthleteEdit _sprintAthleteEdit = new SprintAthleteEdit();
    string[] roles = Roles.GetAllRoles();
    Customer AthleteSearched;

    protected override void OnPreRender(EventArgs e)
    {
        FirstName = Request.QueryString.Get("FirstName");
        LastName = Request.QueryString.Get("LastName");
        EmailAddress = Request.QueryString.Get("Email");

        //MessageBox.Show("FN: " + FirstName);
        //MessageBox.Show("LN: " + LastName);
        //MessageBox.Show("EA: " + EmailAddress);

        TextBox1.Text = FirstName;
        TextBox2.Text = LastName;
        //TextBox3.Text = EmailAddress;

        if (!TextBox1.Text.Equals("") && !TextBox1.Text.Equals(null) && !TextBox2.Equals("") && !TextBox2.Equals(null))
            Button1_Click(this, null);
        base.OnPreRender(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (User.Identity.IsAuthenticated)
        //{

        //    Page.Title = "Home page for " + User.Identity.Name;
        //}
        //else
        //{
        //    Page.Title = "Home page for guest user.";
        //}

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int i = -9999;

            ListBox1.Items.Clear();

            Label5.Text = "";
            Label7.Text = "";
            Label9.Text = "";
            Label11.Text = "";
            Label13.Text = "";
            Label15.Text = "";
            Label17.Text = "";
            Label19.Text = "";
            Label21.Text = "";
            Label23.Text = "";
            Label25.Text = "";
            Label27.Text = "";
            Label29.Text = "";
            Label31.Text = "";
            Label33.Text = "";
            Label35.Text = "";
            Label37.Text = "";
            Label39.Text = "";
            Label41.Text = "";

            //if (TextBox1.Text.Equals(null) || TextBox1.Text.Equals("") || TextBox2.Text.Equals(null) || TextBox2.Text.Equals(""))
            //{
            //    ListBox1.Items.Add("No Matches");
            //}
            if (TextBox1.Text.Equals("") && TextBox2.Text.Equals(""))
            {
                ListBox1.Items.Add("No Matches");
            }
            else
            {
                if (TextBox1.Text == "*" || TextBox2.Text == "*")
                {
                    if (TextBox1.Text == "*")
                    {
                        TextBox1.Text = "";
                    }
                    else
                    {
                        TextBox1.Text = TextBox1.Text;
                    }
                    if (TextBox2.Text == "*")
                    {
                        TextBox2.Text = "";
                    }
                    else
                        TextBox2.Text = TextBox2.Text;

                }
                #region[Old code for seraching which getting all the athlet]
                //i = gml.GetMembers(TextBox1.Text, TextBox2.Text, "");
                //if (gml.GuidMatch.Count.Equals(0))
                //{
                //    //MessageBox.Show("No Matches");
                //    ListBox1.Items.Add("No Matches");
                //}
                //else
                //{
                //    int x = 0;
                //    string ListBoxItem = "";
                //    foreach (string MemberGuid in gml.GuidMatch)
                //    {
                //        ListBoxItem = gml.FirstNameMatch[x].ToString() + " " + gml.LastNameMatch[x].ToString() + ", " + gml.EmailMatch[x].ToString() + ", " + gml.UsernameMatch[x].ToString();

                //        ListBox1.Items.Add(ListBoxItem);
                //        ListBox1.Items[x].Value = gml.CustomerIdMatch[x].ToString() + "," + gml.UsernameMatch[x].ToString() + "|" + gml.EmailMatch[x].ToString();
                //        x++;
                //    }
                //}
                #endregion[Old code for seraching which getting all the athlet]
                #region[new code for seraching which getting all the athlet of particular teacher]
                if (Page.User.Identity.IsAuthenticated)
                {
                    DataTable dt = new DataTable();
                    teacher = DataRepository.TeacherProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
                    DataTable dstecher = _sprintAthleteEdit.GetMembers(TextBox1.Text, TextBox2.Text, teacher.TeacherId);
                    if (dstecher != null)
                    {
                        int x = 0;
                        string ListBoxItem = "";
                        foreach (DataRow row in dstecher.Rows)
                        {
                            DataRow r = dt.NewRow();
                            string userrolename = string.Empty;
                            int customerid = Convert.ToInt32(row["CustomerId"]);
                            AthleteSearched = DataRepository.CustomerProvider.GetByCustomerId(customerid);
                            Guid MemGuid = new Guid(AthleteSearched.AspnetMembershipUserId.ToString());
                            MembershipUser user = Membership.GetUser(MemGuid);
                            string[] userrole = Roles.GetRolesForUser(user.UserName);
                            userrolename = userrole[0];
                            if (userrolename == "Athletes")
                            {

                                ListBoxItem = row["FirstName"].ToString() + " " + row["LastName"].ToString() + ", " + row["Email"].ToString();
                                ListBox1.Items.Add(ListBoxItem);
                                ListBox1.Items[x].Value = row["CustomerID"].ToString();
                                x++;
                            }
                        }
                        if (ListBox1.Items.Count == 0)
                        {
                            ListBox1.Items.Add("No Matches");
                        }

                    }
                    else
                    {
                        ListBox1.Items.Add("No Matches");
                    }
                }
                #endregion[new code for seraching which getting all the athlet of particular teacher]
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    //protected void Button2_Click(object sender, EventArgs e)
    //public void ListBox1_SIC()
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ListBox1.SelectedValue.Equals("No Matches"))
        {
            #region[Old code for seraching which getting all the athlet]
            //int x = ListBox1.SelectedIndex;
            //int comma = ListBox1.Items[x].Value.IndexOf(",");
            //int bar = ListBox1.Items[x].Value.IndexOf("|");
            //int customerid = Convert.ToInt16(ListBox1.Items[x].Value.Substring(0, comma));
            //string MemberUsername = ListBox1.Items[x].Value.Substring(comma + 1, bar - comma - 1);
            //string MemberEmail = ListBox1.Items[x].Value.Substring(bar + 1);

            //customer = DataRepository.CustomerProvider.GetByCustomerId(customerid);
            //customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customer.CustomerId)[0];
            //countrylookup = DataRepository.CountryLookupProvider.GetByCountryId(customer.Country);
            //customersite = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(customerprofile.CustomerSite);
            //teacher = DataRepository.TeacherProvider.GetByTeacherId(customerprofile.Teacher);
            //Guid MemGuid = new Guid(customer.AspnetMembershipUserId.ToString());
            //MembershipUser user = Membership.GetUser(MemGuid);

            //Label5.Text = customer.FirstName;
            //Label7.Text = customer.LastName;
            //Label9.Text = MemberUsername;
            //Label11.Text = MemberEmail;
            //if (!customer.Address1.ToLower().Equals("none"))
            //    Label13.Text = customer.Address1;
            //else
            //    Label13.Text = "";
            //Label15.Text = customer.Address2;
            //if (!customer.City.ToLower().Equals("none"))
            //    Label17.Text = customer.City;
            //else
            //    Label17.Text = "";
            //if (!customer.State.ToLower().Equals("none"))
            //    Label19.Text = customer.State;
            //else
            //    Label19.Text = "";
            //if (!customer.Zip.ToLower().Equals("none"))
            //    Label21.Text = customer.Zip;
            //else
            //    Label21.Text = "";
            //if (customer.Address1.ToLower().Equals("none") && customer.Country.Equals(248))
            //    Label23.Text = "";
            //else
            //    Label23.Text = countrylookup.CountryName;
            //Label25.Text = customer.PhoneHome;
            //Label27.Text = customer.PhoneWork;
            //Label29.Text = customer.PhoneMobile;
            //Label31.Text = customer.Fax;
            //Label33.Text = customersite.SiteName;
            //Label35.Text = teacher.FirstName + " " + teacher.LastName;
            //Label37.Text = user.CreationDate.ToLongDateString();
            //Label39.Text = customer.MembershipExpiration.ToLongDateString();
            //switch (customer.MembershipStatus)
            //{
            //    case 0:
            //        Label41.Text = "Expired";
            //        break;

            //    case 1:
            //        Label41.Text = "Member";
            //        break;

            //    case 2:
            //        Label41.Text = "Full Teaching";
            //        break;

            //    case 3:
            //        Label41.Text = "Full Fitting";
            //        break;

            //    case 4:
            //        Label41.Text = "Full Teaching & Fitting";
            //        break;

            //    case 97:
            //        Label41.Text = "Comp Teaching";
            //        break;

            //    case 98:
            //        Label41.Text = "Comp Fitting";
            //        break;

            //    case 99:
            //        Label41.Text = "Comp Teaching & Fitting";
            //        break;

            //    default:
            //        Label41.Text = "Missing";
            //        break;
            //}
            #endregion[Old code for seraching which getting all the athlet]
            #region[new code for seraching which getting all the athlet of particular teacher]
            int x = ListBox1.SelectedIndex;
            int customerid = Convert.ToInt16(ListBox1.Items[x].Value);
            customer = DataRepository.CustomerProvider.GetByCustomerId(customerid);
            Guid MemGuid = new Guid(customer.AspnetMembershipUserId.ToString());
            MembershipUser user1 = Membership.GetUser(MemGuid);
            string MemberUsername = user1.UserName.ToString();
            string MemberEmail = user1.Email;
            countrylookup = DataRepository.CountryLookupProvider.GetByCountryId(customer.Country);
            try
            {
                customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customer.CustomerId)[0];
                customersite = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(customerprofile.CustomerSite);
                teacher1 = DataRepository.TeacherProvider.GetByTeacherId(customerprofile.Teacher);
            }
            catch (Exception ex)
            {
                customerprofile = new CustomerProfile();
            }


            Label5.Text = customer.FirstName;
            Label7.Text = customer.LastName;
            Label9.Text = MemberUsername;
            Label11.Text = MemberEmail;
            if (!customer.Address1.ToLower().Equals("none"))
                Label13.Text = customer.Address1;
            else
                Label13.Text = "";
            Label15.Text = customer.Address2;
            if (!customer.City.ToLower().Equals("none"))
                Label17.Text = customer.City;
            else
                Label17.Text = "";
            if (!customer.State.ToLower().Equals("none"))
                Label19.Text = customer.State;
            else
                Label19.Text = "";
            if (!customer.Zip.ToLower().Equals("none"))
                Label21.Text = customer.Zip;
            else
                Label21.Text = "";
            if (customer.Address1.ToLower().Equals("none") && customer.Country.Equals(248))
                Label23.Text = "";
            else
                Label23.Text = countrylookup.CountryName;
            Label25.Text = customer.PhoneHome;
            Label27.Text = customer.PhoneWork;
            Label29.Text = customer.PhoneMobile;
            Label31.Text = customer.Fax;
            Label33.Text = customersite.SiteName;
            Label35.Text = teacher1.FirstName + " " + teacher1.LastName;
            Label37.Text = user1.CreationDate.ToLongDateString();
            Label39.Text = customer.MembershipExpiration.ToLongDateString();
            switch (customer.MembershipStatus)
            {
                case 0:
                    Label41.Text = "Expired";
                    break;

                case 1:
                    Label41.Text = "Member";
                    break;

                case 2:
                    Label41.Text = "Full Teaching";
                    break;

                case 3:
                    Label41.Text = "Full Fitting";
                    break;

                case 4:
                    Label41.Text = "Full Teaching & Fitting";
                    break;

                case 97:
                    Label41.Text = "Comp Teaching";
                    break;

                case 98:
                    Label41.Text = "Comp Fitting";
                    break;

                case 99:
                    Label41.Text = "Comp Teaching & Fitting";
                    break;

                default:
                    Label41.Text = "Missing";
                    break;
            }
            #endregion[new code for seraching which getting all the athlet of particular teacher]
        }
        return;
    }
}
