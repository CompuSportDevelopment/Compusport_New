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

//public partial class Teachers_TeacherBio : System.Web.UI.Page
public partial class Teachers_TeacherBio : SwingModel.UI.BasePage
{
    bool isTeacherExist = false;
    // bool isCustomerExist = false;

    CompuSportDAL.SprintAthleteEdit _sprintAthleteEdit = new CompuSportDAL.SprintAthleteEdit();
    public Customer customer = new Customer();
    public Teacher teacher = new Teacher();
    bool teacherexists;
    int teacherId;
    protected override void OnPreLoad(EventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            try
            {
                teacherId = Convert.ToInt16(Request.QueryString.Get("teacherid"));

                teacher = DataRepository.TeacherProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];

                teacherexists = true;
            }
            catch
            {
                //no entry in Customer table for current member
                teacherexists = false;
            }
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        CheckProfiles myCheckProfiles = new CheckProfiles();
        Guid MemGuid = new Guid(teacher.AspnetMembershipUserId.ToString());
        Guid rollid = _sprintAthleteEdit.GetRollIdByUserId(MemGuid);
        //MessageBox.Show(Convert.ToString(myCheckProfiles.Personal()));
        //MessageBox.Show(Convert.ToString(myCheckProfiles.Address()));
        //MessageBox.Show(Convert.ToString(myCheckProfiles.Contact()));

        if (this.User.Identity.IsAuthenticated)
        {
            if ((rollid.ToString().Trim() != "3c195d36-1032-4cf9-a383-757a2ec5bea2") && (rollid.ToString().Trim() != "6b5a6229-1751-436c-a419-8196d6e8170b") && (rollid.ToString().Trim() != "a7df4248-034a-4900-8d69-f914bce9396d"))
            {
                if (!myCheckProfiles.Personal())
                {
                    //MessageBox.Show("1a");
                    this.Page.Response.Redirect("~/Users/MyAccount.aspx");
                }
            }
            if ((rollid.ToString().Trim() != "3c195d36-1032-4cf9-a383-757a2ec5bea2") && (rollid.ToString().Trim() != "6b5a6229-1751-436c-a419-8196d6e8170b") && (rollid.ToString().Trim() != "a7df4248-034a-4900-8d69-f914bce9396d"))
            {
                if (!myCheckProfiles.Address())
                {
                    if (myCheckProfiles.Personal() && myCheckProfiles.Facility())
                    {
                        //MessageBox.Show("2a");
                        this.Page.Response.Redirect("~/Users/MyAccount.aspx");
                    }
                }
            }
            if ((rollid.ToString().Trim() != "3c195d36-1032-4cf9-a383-757a2ec5bea2") && (rollid.ToString().Trim() != "6b5a6229-1751-436c-a419-8196d6e8170b") && (rollid.ToString().Trim() != "a7df4248-034a-4900-8d69-f914bce9396d"))
            {
                if (!myCheckProfiles.Facility())
                {
                    if (myCheckProfiles.Personal() && myCheckProfiles.Address())
                    {
                        //MessageBox.Show("3a");
                        this.Page.Response.Redirect("~/Users/MyAccount.aspx");
                    }
                }
            }
            if ((rollid.ToString().Trim() != "3c195d36-1032-4cf9-a383-757a2ec5bea2") && (rollid.ToString().Trim() != "6b5a6229-1751-436c-a419-8196d6e8170b") && (rollid.ToString().Trim() != "a7df4248-034a-4900-8d69-f914bce9396d"))
            {
                if (!myCheckProfiles.Dimensions())
                {
                    if (myCheckProfiles.Personal() && myCheckProfiles.Address() && myCheckProfiles.Facility())
                    {
                        //MessageBox.Show("4a");
                        this.Page.Response.Redirect("~/Users/MyDimensions.aspx");
                    }
                }
            }
            if ((rollid.ToString().Trim() != "3c195d36-1032-4cf9-a383-757a2ec5bea2") && (rollid.ToString().Trim() != "6b5a6229-1751-436c-a419-8196d6e8170b") && (rollid.ToString().Trim() != "a7df4248-034a-4900-8d69-f914bce9396d"))
            {
                if (!myCheckProfiles.Golf())
                {
                    if (myCheckProfiles.Personal() && myCheckProfiles.Address() && myCheckProfiles.Facility() && myCheckProfiles.Dimensions())
                    {
                        //MessageBox.Show("5a");
                        this.Page.Response.Redirect("~/Users/MyGolf.aspx");
                    }
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        Image1.Visible = true;
        Label1.Visible = true;
        FileUpload1.Visible = true;
        Label5.Visible = true;
        Label6.Visible = true;
        Label7.Visible = true;
        Label4.Text = "";
        Label2.Visible = true;
        Label3.Visible = true;
        lblsubnittext.Visible = false;

        try
        {
            teacher = DataRepository.TeacherProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
            isTeacherExist = true;
        }
        catch
        {
        }
        //int x = 0;
        DataTable dt = new DataTable();
        dt.Columns.Add("First Name", typeof(string));
        dt.Columns.Add("Last Name", typeof(string));
        // dt.Columns.Add("TeacherType", typeof(int));

        DataTable dt1 = new DataTable();
        dt1.Columns.Add("First Name", typeof(string));
        dt1.Columns.Add("Last Name", typeof(string));
        //  dt1.Columns.Add("TeacherType", typeof(int));


        DataTable dtathlets = _sprintAthleteEdit.GetPrimaryAthletsCoach(teacher.TeacherId);
        DataTable dtathlets1 = _sprintAthleteEdit.GetSecondaryAthlets_Coach(teacher.TeacherId);

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
                        //  r["TeacherType"] = 1;
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
                        //r["TeacherType"] = 2;
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

        // teacher = DataRepository.TeacherProvider.GetByAspnetMembershipUserId(customer.AspnetMembershipUserId)[0];
        teacherId = Convert.ToInt16(Request.QueryString.Get("teacherid"));
        if (teacherId != 0)
        {
            teacher = DataRepository.TeacherProvider.GetByTeacherId(teacherId);
        }
        else
        {
            teacher = DataRepository.TeacherProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
        }
        if (!IsPostBack)
        {
            //if (!teacher.WelcomeText.Equals("") && !teacher.WelcomeText.Equals(null))
            //    LblWelcomeText.Text = teacher.WelcomeText;
            LblWelcomeText.Visible = true;
            //if (!teacher.BioText.Equals("") && !teacher.BioText.Equals(null))
            //    FreeTextBox2.Text = teacher.BioText;
        }
        Image1.ImageUrl = "~" + teacher.PicturePath;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (teacherId != 0)
        {
            teacher = DataRepository.TeacherProvider.GetByTeacherId(teacherId);
        }
        else
        {
            teacher = DataRepository.TeacherProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
        }
        // teacher = DataRepository.TeacherProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
        bool boolCommit = false;
        bool ImageUploaded = true;

        if (FileUpload1.HasFile)
        {
            if (FileUpload1.FileName.ToLower().EndsWith(".jpg") || FileUpload1.FileName.ToLower().EndsWith(".png"))
            {
                try
                {
                    lblsubnittext.Visible = false;
                    FileUpload1.SaveAs(Server.MapPath("~/TeacherPics/" + FileUpload1.FileName));
                    teacher.PicturePath = "/TeacherPics/" + FileUpload1.FileName;
                    boolCommit = true;
                    ImageUploaded = true;
                    // Button1.Visible = false;
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

    public Customer AthleteSearched { get; set; }
}
