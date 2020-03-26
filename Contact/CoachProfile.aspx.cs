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

public partial class Contact_CoachProfile : System.Web.UI.Page
{
    CompuSportDAL.SprintAthleteEdit _sprintAthleteEdit = new CompuSportDAL.SprintAthleteEdit();
    public Customer customer = new Customer();
    public Teacher teacher = new Teacher();
    bool teacherexists;
    int teacherId;
    Guid MemGuid;

    protected override void OnPreLoad(EventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            try
            {
                //   teacherId = Convert.ToInt16(Request.QueryString.Get("teacherid"));

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
        teacherId = Convert.ToInt16(Request.QueryString.Get("teacherid"));
        try
        {
            if (teacherId != 0)
            {
                teacher = DataRepository.TeacherProvider.GetByTeacherId(teacherId);
            }
          
            if (teacherexists)
            {
                lblImgUpload.Visible = true;
                FileUpload1.Visible = true;
                lblImgTxt1.Visible = true;
                lblImgTxt2.Visible = true;
                lblImgTxt3.Visible = true;
                Button1.Visible = true;
            }
            else
            {
                lblImgUpload.Visible = false;
                FileUpload1.Visible = false;
                lblImgTxt1.Visible = false;
                lblImgTxt2.Visible = false;
                lblImgTxt3.Visible = false;
                Button1.Visible = false;
                FreeTextBox1.ReadOnly = true;
                FreeTextBox2.ReadOnly = true;
            }
            if (!IsPostBack)
            {
                if (!teacher.WelcomeText.Equals("") && !teacher.WelcomeText.Equals(null))
                    FreeTextBox1.Text = teacher.WelcomeText;
                if (!teacher.BioText.Equals("") && !teacher.BioText.Equals(null))
                    FreeTextBox2.Text = teacher.BioText;
            }
            Image1.ImageUrl = "~" + teacher.PicturePath;
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
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
            bool ImageUploaded = false;

            if (FileUpload1.HasFile)
            {
                if (FileUpload1.FileName.ToLower().EndsWith(".jpg") || FileUpload1.FileName.ToLower().EndsWith(".png"))
                {
                    try
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/TeacherPics/" + FileUpload1.FileName));
                        teacher.PicturePath = "/TeacherPics/" + FileUpload1.FileName;
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
                if (!FreeTextBox1.Text.Equals("") && !FreeTextBox1.Text.Equals(null) && !FreeTextBox2.Text.Equals("") && !FreeTextBox2.Text.Equals(null))
                {
                    teacher.WelcomeText = FreeTextBox1.Text;
                    teacher.BioText = FreeTextBox2.Text;
                    try
                    {
                        DataRepository.TeacherProvider.Update(teacher);
                        if (ImageUploaded)
                        {
                            Label4.Text = "Your details were successfully saved to the database. Visit the My Teacher page to review.";
                            Label4.Visible = true;
                            Image1.ImageUrl = "~" + teacher.PicturePath;
                        }
                        else
                        {
                            Label4.Text = "Your details were successfully saved to the database. No image was uploaded, though. Visit the My Teacher page to review.";
                            Label4.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Label4.Text = "Your data was not successfully submitted. There was an error updating the database.";
                        Label4.Visible = true;
                    }
                }
                else
                {
                    Label4.Text = "Your data was not successfully submitted. Please insure that the Welcome Text box and Bio Text box are not empty.";
                    Label4.Visible = true;
                }
            }
            else
            {
                Label4.Text = "Your data was not successfully submitted. There was an error uploading the image.";
                Label4.Visible = true;
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}


