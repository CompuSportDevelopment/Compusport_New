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

//public partial class Facility_AddTeachers : System.Web.UI.Page
public partial class Facility_AddTeachers : SwingModel.UI.BasePage
{
    public GetMemberList gml = new GetMemberList();
    Customer customer = new Customer();
    CustomerProfile customerprofile = new CustomerProfile();
    CustomerSite customersite = new CustomerSite();
    CountryLookup countrylookup = new CountryLookup();
    int SelectedFacility;
    DataTable dt = new DataTable();
    int x;
    TList<TeacherSite> facilityteachers = new TList<TeacherSite>();
    Teacher teacher = new Teacher();

    protected void Page_Load(object sender, EventArgs e)
    {
        customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
        customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customer.CustomerId)[0];
        SelectedFacility = customerprofile.CustomerSite;
        customersite = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(SelectedFacility);
        Label1.Text = customersite.SiteName;
        facilityteachers = DataRepository.TeacherSiteProvider.GetBySiteId(SelectedFacility);
        dt.Columns.Add("TeacherId", typeof(int));
        dt.Columns.Add("First Name", typeof(string));
        dt.Columns.Add("Last Name", typeof(string));
        dt.Columns.Add("Roles", typeof(string));
        dt.Columns.Add("Mobile Phone", typeof(string));
        dt.Columns.Add("Fax", typeof(string));
        dt.Columns.Add("AspNetMembershipUserId", typeof(string));
        dt.Columns.Add("Picture Path", typeof(string));
        dt.Columns.Add("Bio Text", typeof(string));
        dt.Columns.Add("Welcome Text", typeof(string));
        dt.Columns.Add("Teaching Password", typeof(string));
        dt.Columns.Add("TeacherLocationId", typeof(int));
        x = 0;
        foreach (TeacherSite ts in facilityteachers)
        {
            teacher = DataRepository.TeacherProvider.GetByTeacherId(ts.TeacherId);
            customersite = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(ts.SiteId);
            Guid MemGuid = new Guid(teacher.AspnetMembershipUserId.ToString());
            MembershipUser user = Membership.GetUser(MemGuid);
            string[] userrole = Roles.GetRolesForUser(user.UserName);
            string userrolename = string.Empty;
            if (userrole.Length > 0)
            {
                userrolename = userrole[0];
            }

            dt.Rows.Add(teacher.TeacherId, teacher.FirstName, teacher.LastName, userrolename, teacher.MobilePhone, teacher.Fax, teacher.AspnetMembershipUserId.ToString(), teacher.PicturePath, teacher.BioText, teacher.WelcomeText, teacher.TeachingPassword, ts.TeacherLocationId);
            x++;
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int RowID = Convert.ToInt32(e.CommandArgument);
        TeacherSite tas = new TeacherSite();

        if (e.CommandName == "DeleteRow")
        {
            bool isfacilityadmin = false;
            tas.TeacherLocationId = Convert.ToInt32(RowID);
            tas = DataRepository.TeacherSiteProvider.GetByTeacherLocationId(RowID);
            teacher = DataRepository.TeacherProvider.GetByTeacherId(tas.TeacherId);
            Guid MemGuid = new Guid(teacher.AspnetMembershipUserId.ToString());
            MembershipUser user = Membership.GetUser(MemGuid);
            try
            {
                string[] allroles = Roles.GetRolesForUser(user.UserName);
                foreach (var item in allroles)
                {
                    if (item.ToString() == "Facility Administrators")
                    {
                        isfacilityadmin = true;
                        LinkButton lnkDelete = (LinkButton)GridView1.Rows[0].FindControl("lnkDelete");
                        lnkDelete.Visible = false;
                    }
                }
                if (!isfacilityadmin)
                {
                    DataRepository.TeacherSiteProvider.Delete(tas);
                }

            }
            catch
            { }

            //this.Page.Response.Redirect("~/Facility/AddTeachers.aspx");
        }


        if (e.CommandName == "EditRow")
        {
            this.Page.Response.Redirect("~/Facility/EditTeacher.aspx?TeacherId=" + RowID.ToString() + "");
        }
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ListBox1.SelectedValue.Equals("No Matches"))
        {

            int x = ListBox1.SelectedIndex;
            int comma = ListBox1.Items[x].Value.IndexOf(",");
            int bar = ListBox1.Items[x].Value.IndexOf("|");
            int customerid = Convert.ToInt16(ListBox1.Items[x].Value.Substring(0, comma));
            string MemberUsername = ListBox1.Items[x].Value.Substring(comma + 1, bar - comma - 1);
            string MemberEmail = ListBox1.Items[x].Value.Substring(bar + 1);

            customer = DataRepository.CustomerProvider.GetByCustomerId(customerid);
            customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customer.CustomerId)[0];
            countrylookup = DataRepository.CountryLookupProvider.GetByCountryId(customer.Country);
            int SelectedFacilitynew = customerprofile.CustomerSite;
            customersite = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(SelectedFacility);
            teacher = DataRepository.TeacherProvider.GetByTeacherId(customerprofile.Teacher);
            Guid MemGuid = new Guid(customer.AspnetMembershipUserId.ToString());
            MembershipUser user = Membership.GetUser(MemGuid);
            string[] userrole = Roles.GetRolesForUser(user.UserName.ToString());

            // DropDownList1.SelectedValue = SelectedFacilitynew.ToString();
            //if (userrole.Length > 0)
            //{
            //    DropDownList2.SelectedValue = userrole[0];
            //}
            //else
            //{
            //    DropDownList2.SelectedValue = "Golfers";

            //}

            Label45.Text = customer.FirstName;
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
            Label35.Text = teacher.FirstName + " " + teacher.LastName;
            Label37.Text = user.CreationDate.ToLongDateString();
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

        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        int i = -9999;

        ListBox1.Items.Clear();

        if (TextBox1.Text.Equals(null) || TextBox1.Text.Equals("") || TextBox2.Text.Equals(null) || TextBox2.Text.Equals(""))
        {
            ListBox1.Items.Add("No Matches");
        }
        else
        {
            //i = gml.GetMembers(TextBox1.Text, TextBox2.Text, TextBox3.Text);
            i = gml.GetMembers(TextBox1.Text, TextBox2.Text, "");

            if (gml.GuidMatch.Count.Equals(0))
            {
                //MessageBox.Show("No Matches");
                ListBox1.Items.Add("No Matches");
            }
            else
            {
                int x = 0;
                string ListBoxItem = "";
                foreach (string MemberGuid in gml.GuidMatch)
                {
                    ListBoxItem = gml.FirstNameMatch[x].ToString() + " " + gml.LastNameMatch[x].ToString() + ", " + gml.EmailMatch[x].ToString() + ", " + gml.UsernameMatch[x].ToString();

                    ListBox1.Items.Add(ListBoxItem);
                    ListBox1.Items[x].Value = gml.CustomerIdMatch[x].ToString() + "," + gml.UsernameMatch[x].ToString() + "|" + gml.EmailMatch[x].ToString();
                    x++;
                }
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        bool teacherexists = false;
        Customer tc = new Customer();
        Teacher teach = new Teacher();
        TeacherSite teachersite = new TeacherSite();
        int customerid = -1;
        bool CurrentTeacher = false;

        if (!ListBox1.SelectedValue.Equals("No Matches") && !ListBox1.Items.Count.Equals(0))
        {
            int x = ListBox1.SelectedIndex;
            int comma = ListBox1.Items[x].Value.IndexOf(",");
            customerid = Convert.ToInt16(ListBox1.Items[x].Value.Substring(0, comma));
        }
        //MessageBox.Show("customerid: " + customerid.ToString());
        if (!customerid.Equals(-1))
        {
            tc = DataRepository.CustomerProvider.GetByCustomerId(customerid);
            try
            {
                teach = DataRepository.TeacherProvider.GetByAspnetMembershipUserId(tc.AspnetMembershipUserId)[0];
                //MessageBox.Show("Teacher First Name: " + teach.FirstName);
                CurrentTeacher = true;
            }
            catch (Exception ex)
            {
                //Selected member is not a current Teacher in database
                //MessageBox.Show("Not a current teacher");
                CurrentTeacher = false;
            }

            if (CurrentTeacher)
            {
                foreach (TeacherSite ts in facilityteachers)
                {
                    if (ts.TeacherId == teach.TeacherId)
                    {
                        teacherexists = true;

                    }
                }
                if (!teacherexists)
                {
                    customer = DataRepository.CustomerProvider.GetByCustomerId(customerid);
                    MembershipUser user = Membership.GetUser(customer.AspnetMembershipUserId);
                    try
                    {

                        Roles.AddUserToRole(user.UserName, "Teachers");
                    }
                    catch { }

                    teachersite.SiteId = SelectedFacility;
                    teachersite.TeacherId = teach.TeacherId;
                    DataRepository.TeacherSiteProvider.Insert(teachersite);
                }
                else
                {
                    //Label1.Text = "This teacher is already exists for this facility";
                }


            }
            else
            {
                teach.FirstName = tc.FirstName;
                teach.LastName = tc.LastName;
                teach.WorkPhone = tc.PhoneWork;
                teach.MobilePhone = tc.PhoneMobile;
                teach.AspnetMembershipUserId = tc.AspnetMembershipUserId;
                teach.PicturePath = "/TeacherPics/" + tc.FirstName + tc.LastName + ".jpg";
                teach.BioText = "Bio Text";
                teach.WelcomeText = "<P>Welcome to the SwingModel learning program. If you haven't "
                    + "taken a look at your most recent lesson video(s), please visit the My Swing "
                    + "page. There you will be able to review the errors we discussed during the "
                    + "lesson. For further review, you may click on the My Summary button in the "
                    + "video player. Continue working the drills as discussed in the lesson. If "
                    + "you'd like to ask questions about your swing or golf game, click on the Email "
                    + "My Teacher link. Be sure to schedule a lesson with me in the near future. You "
                    + "can request a lesson appointment time by clicking on the Schedule A Lesson "
                    + "link.</P>";
                foreach (TeacherSite ts in facilityteachers)
                {
                    if (ts.TeacherId == teach.TeacherId && ts.SiteId == teachersite.SiteId)
                    {
                        teacherexists = true;

                    }
                }
                if (!teacherexists)
                {
                    customer = DataRepository.CustomerProvider.GetByCustomerId(customerid);
                    MembershipUser user = Membership.GetUser(customer.AspnetMembershipUserId);
                    try
                    {

                        Roles.AddUserToRole(user.UserName, "Teachers");
                    }
                    catch { }

                }
                else
                {
                    //Label1.Text = "This teacher is already exists for this facility";
                }

                teach.TeachingPassword = tc.FirstName;
                DataRepository.TeacherProvider.Insert(teach);
                teachersite.SiteId = SelectedFacility;
                teachersite.TeacherId = teach.TeacherId;
                DataRepository.TeacherSiteProvider.Insert(teachersite);
            }
        }

        this.Page.Response.Redirect("~/Facility/AddTeachers.aspx");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
            LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            HiddenField hfRole = (HiddenField)e.Row.FindControl("hfRole");
            if (!hfRole.Value.Equals("Teachers"))
            {
                lnkDelete.Enabled = false;
            }
            if (!hfRole.Value.Equals("Teachers"))
            {
                if (!hfRole.Value.Equals("Facility Administrators"))
                {
                    e.Row.Cells[12].Visible = false;
                    lnkEdit.Enabled = false;
                }
            }

            else
            {
                lnkDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this teacher');");
            }
        }
    }
    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    int RowID = Convert.ToInt32(e.Row);
    //    TeacherSite tas = new TeacherSite();
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
    //        lnkDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this teacher');");

    //    }
    //    bool isfacilityadmin = false;
    //    tas.TeacherLocationId = Convert.ToInt32(RowID);
    //    tas = DataRepository.TeacherSiteProvider.GetByTeacherLocationId(RowID);
    //    teacher = DataRepository.TeacherProvider.GetByTeacherId(tas.TeacherId);
    //    Guid MemGuid = new Guid(teacher.AspnetMembershipUserId.ToString());
    //    MembershipUser user = Membership.GetUser(MemGuid);
    //    try
    //    {
    //        string[] allroles = Roles.GetRolesForUser(user.UserName);
    //        foreach (var item in allroles)
    //        {
    //            if (item.ToString() == "Facility Administrators")
    //            {
    //                isfacilityadmin = true;
    //                LinkButton lnkDelete = (LinkButton)GridView1.Rows[0].FindControl("lnkDelete");
    //                lnkDelete.Visible = false;
    //            }
    //        }           

    //    }
    //    catch
    //    { }           

    //}
}
