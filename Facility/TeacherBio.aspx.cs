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
using SwingModel.Data;
using SwingModel.Entities;
using System.Windows.Forms;
using CompuSportDAL;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.IO;


//public partial class Teachers_TeacherBio : System.Web.UI.Page
public partial class Teachers_TeacherBio : SwingModel.UI.BasePage
{
    public Customer customer = new Customer();
    public Teacher teacher = new Teacher();
    public CustomerProfile customerprofile;
    public TList<TeacherSite> teachersatsite = new TList<TeacherSite>();
    public CustomerSite customersite;
    public Teacher CoachSearched = new Teacher();
    string[] roles = Roles.GetAllRoles();

    bool AthleteAlreadyInList;
    int x;
    SprintAthleteEdit _sprintAthleteEdit = new SprintAthleteEdit();
    Customer AthleteSearched;



    //protected override void OnPreLoad(EventArgs e)
    //{
    //    if (Page.User.Identity.IsAuthenticated)
    //    {
    //        try
    //        {
    //            customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
    //            customerexists = true;
    //        }
    //        catch
    //        {
    //            //no entry in Customer table for current member
    //            customerexists = false;
    //        }
    //    }
    //}

    //protected override void OnPreRender(EventArgs e)
    //{
    //    CheckProfiles myCheckProfiles = new CheckProfiles();

    //    //MessageBox.Show(Convert.ToString(myCheckProfiles.Personal()));
    //    //MessageBox.Show(Convert.ToString(myCheckProfiles.Address()));
    //    //MessageBox.Show(Convert.ToString(myCheckProfiles.Contact()));

    //    //if (this.User.Identity.IsAuthenticated)
    //    //{
    //        if (!myCheckProfiles.Personal())
    //        {
    //            //MessageBox.Show("1a");
    //            this.Page.Response.Redirect("~/Users/MyAccount.aspx");
    //        }

    //        if (!myCheckProfiles.Address())
    //        {
    //            if (myCheckProfiles.Personal() && myCheckProfiles.Facility())
    //            {
    //                //MessageBox.Show("2a");
    //                this.Page.Response.Redirect("~/Users/MyAccount.aspx");
    //            }
    //        }

    //        if (!myCheckProfiles.Facility())
    //        {
    //            if (myCheckProfiles.Personal() && myCheckProfiles.Address())
    //            {
    //                //MessageBox.Show("3a");
    //                this.Page.Response.Redirect("~/Users/MyAccount.aspx");
    //            }
    //        }

    //        if (!myCheckProfiles.Dimensions())
    //        {
    //            if (myCheckProfiles.Personal() && myCheckProfiles.Address() && myCheckProfiles.Facility())
    //            {
    //                //MessageBox.Show("4a");
    //                this.Page.Response.Redirect("~/Users/MyDimensions.aspx");
    //            }
    //        }

    //        if (!myCheckProfiles.Golf())
    //        {
    //            if (myCheckProfiles.Personal() && myCheckProfiles.Address() && myCheckProfiles.Facility() && myCheckProfiles.Dimensions())
    //            {
    //                //MessageBox.Show("5a");
    //                this.Page.Response.Redirect("~/Users/MyGolf.aspx");
    //            }
    //        }
    //    //}
    //}

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Image1.Visible = false;
            Label1.Visible = false;
            FileUpload1.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
        }
        customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
        teacher = DataRepository.TeacherProvider.GetByAspnetMembershipUserId(customer.AspnetMembershipUserId)[0];

        customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
        customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customer.CustomerId)[0];

        customersite = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(customerprofile.CustomerSite);
        // Label1.Text = customersite.SiteName;

        teachersatsite = DataRepository.TeacherSiteProvider.GetBySiteId(customerprofile.CustomerSite);
        teachersatsite.Sort("TeacherId ASC");

        if (DropDownList1.Items.Count.Equals(0))
        {
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add("Make a Selection");
            DropDownList1.Items[0].Value = "-1";
            int x = 0;
            foreach (TeacherSite ts in teachersatsite)
            {
                x++;
                string userrolename = string.Empty;
                teacher = DataRepository.TeacherProvider.GetByTeacherId(ts.TeacherId);
                CoachSearched = DataRepository.TeacherProvider.GetByTeacherId(teacher.TeacherId);
                Guid MemGuid = new Guid(CoachSearched.AspnetMembershipUserId.ToString());
                MembershipUser user = Membership.GetUser(MemGuid);
                string[] userrole = Roles.GetRolesForUser(user.UserName);
                userrolename = userrole[0];
                if (userrolename != "Athletes")
                {
                    DropDownList1.Items.Add(teacher.FirstName + " " + teacher.LastName);
                    DropDownList1.Items[x].Value = teacher.TeacherId.ToString();
                }
            }
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblsubnittext.Visible = false;
        Image1.Visible = true;
        Label1.Visible = true;
        FileUpload1.Visible = true;
        Label5.Visible = true;
        Label6.Visible = true;
        Label7.Visible = true;
        Label4.Text = "";
        Label2.Visible = true;
        Label3.Visible = true;
        int SelectedTeacherId = Convert.ToInt16(DropDownList1.SelectedValue);

        try
        {
            Teacher teach = DataRepository.TeacherProvider.GetByTeacherId(SelectedTeacherId);
            //LblWelcomeText.Visible = true;
            Image1.ImageUrl = "~" + teach.PicturePath;

        }
        catch
        {
        }


        try
        {
            teacher = DataRepository.TeacherProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
        }
        catch
        {

        }
        CustomerSite siteid;
        int x = 0;
        DataTable dt = new DataTable();
        dt.Columns.Add("First Name", typeof(string));
        dt.Columns.Add("Last Name", typeof(string));
        //dt.Columns.Add("TeacherType", typeof(int));

        DataTable dt1 = new DataTable();
        dt1.Columns.Add("First Name", typeof(string));
        dt1.Columns.Add("Last Name", typeof(string));
        //dt1.Columns.Add("TeacherType", typeof(int));

        DataTable dtathlets1 = _sprintAthleteEdit.GetSecondaryAthlets_Coach(SelectedTeacherId);
        DataTable dtathlets = _sprintAthleteEdit.GetPrimaryAthletsCoach(SelectedTeacherId);

        try
        {
            #region[Primary Coach Data]
            if (dtathlets != null)
            {
                foreach (DataRow row in dtathlets.Rows)
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
                        r["First Name"] = row["FirstName"].ToString();
                        r["Last Name"] = row["LastName"].ToString();
                        // r["TeacherType"] = 1;
                        dt.Rows.Add(r);
                    }
                }
            }
            #endregion[Primary Coach Data]
        }
        catch
        {
        }
        if (dt.Rows.Count > 0)
        {
            lblerror.Visible = false;

        }
        else
        {
            lblprimaryCoach.Visible = true;
            lblprimaryList.Visible = true;
            lblerror.Visible = true;
        }
        lblprimaryCoach.Visible = true;
        lblprimaryList.Visible = true;
        DataTable AthleteData = dt;
        GridView1.DataSource = AthleteData;
        GridView1.DataBind();


        try
        {
            #region[Secondary Coach Data]
            if (dtathlets1 != null)
            {
                foreach (DataRow row in dtathlets1.Rows)
                {
                    DataRow r = dt1.NewRow();
                    string userrolename1 = string.Empty;
                    int customerid1 = Convert.ToInt32(row["CustomerId"]);
                    AthleteSearched = DataRepository.CustomerProvider.GetByCustomerId(customerid1);
                    Guid MemGuid1 = new Guid(AthleteSearched.AspnetMembershipUserId.ToString());
                    MembershipUser user1 = Membership.GetUser(MemGuid1);
                    string[] userrole1 = Roles.GetRolesForUser(user1.UserName);
                    userrolename1 = userrole1[0];
                    if (userrolename1 == "Athletes")
                    {
                        r["First Name"] = row["FirstName"].ToString();
                        r["Last Name"] = row["LastName"].ToString();
                        // r["TeacherType"] = 2;
                        dt1.Rows.Add(r);
                    }
                }
            }
            #endregion[Secondary Coach Data]
            lblSecondryCoach.Visible = true;
            lblSecondaryList.Visible = true;
            DataTable AthleteData1 = dt1;
            GridView2.DataSource = AthleteData1;
            GridView2.DataBind();
        }
        catch
        {
        }
        if (dt1.Rows.Count > 0)
        {
            lblerror1.Visible = false;

        }
        else
        {
            lblSecondryCoach.Visible = true;
            lblSecondaryList.Visible = true;
            lblerror1.Visible = true;
        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {


        string selval = DropDownList1.SelectedValue.ToString();
        //lblsubnittext.Visible = false;
        teacher = DataRepository.TeacherProvider.GetByTeacherId(Convert.ToInt32(selval));
        bool boolCommit = false;
        bool ImageUploaded = false;
       

        if (FileUpload1.HasFile)
        {

            if (FileUpload1.FileName.ToLower().EndsWith(".jpg") || FileUpload1.FileName.ToLower().EndsWith(".png"))
            {
                try
                {
                    FileUpload1.SaveAs(Server.MapPath("~/TeacherPics/" + FileUpload1.FileName));
                    teacher.PicturePath = "/TeacherPics/" + FileUpload1.FileName;
                    // Button1.Visible = false;
                    boolCommit = true;
                    ImageUploaded = true;
                }
                catch (Exception ex)
                {
                    boolCommit = false;
                    ImageUploaded = false;
                }
            }
            else
            {
                boolCommit = false;
                ImageUploaded = false;
            }
        }
        else
        {
            //No image to upload
            boolCommit = true;
            ImageUploaded = false;
        }

        if (boolCommit)
        {
            try
            {
                DataRepository.TeacherProvider.Update(teacher);
                if (ImageUploaded)
                {
                    lblsubnittext.Visible = true;
                    Label5.Visible = false;
                    Label6.Visible = false;
                    Label7.Visible = false;
                    Image1.ImageUrl = "~" + teacher.PicturePath;
                   

                }
                else
                {

                    Label4.Text = "No image was uploaded, though. Visit the My Teacher page to review.";
                    Label4.Visible = true;

                }
            }
            catch (Exception ex)
            {
                Label4.Text = "Your data was not successfully submitted. There was an error updating the database.";
                Label4.Visible = false;
            }
        }
    }

}
