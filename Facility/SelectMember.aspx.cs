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
using CompuSportDAL;

//public partial class Teachers_SelectMember : System.Web.UI.Page
public partial class Teachers_SelectMember : SwingModel.UI.BasePage
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
    SprintAthleteEdit _sprintAthleteEdit = new SprintAthleteEdit();
    string[] roles = Roles.GetAllRoles();
    Customer AthleteSearched;
    protected override void OnPreRender(EventArgs e)
    {
        TextBox1.AutoCompleteType = AutoCompleteType.Disabled;
        TextBox2.AutoCompleteType = AutoCompleteType.Disabled;
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
        Button2.Attributes.Add("onClick", "return getAlert()");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int i = -9999;

        ListBox1.Items.Clear();

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
            //i = gml.GetMembers(TextBox1.Text, TextBox2.Text, TextBox3.Text);
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (!ListBox1.SelectedValue.Equals("No Matches") && !ListBox1.Items.Count.Equals(0))
        {
            int x = ListBox1.SelectedIndex;
            if (x >= 0)
            {
                #region[Old code for seraching which getting all the athlet]
                //int comma = ListBox1.Items[x].Value.IndexOf(",");
                //int customerid = Convert.ToInt16(ListBox1.Items[x].Value.Substring(0, comma));
                #endregion[Old code for seraching which getting all the athlet]
                int customerid = Convert.ToInt16(ListBox1.Items[x].Value);
                this.Page.Response.Redirect("~/Facility/SummaryPlayer.aspx?customerid=" + customerid.ToString());
                //this.Server.Transfer("~/Admin/SummaryPlayer.aspx?customerid=" + customerid.ToString());

            }
            else
            {
                Button2.Attributes.Add("onClick", "return getAlert()");

            }
        }
    }
}
