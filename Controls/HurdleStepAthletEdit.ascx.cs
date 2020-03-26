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
using SwingModel.Data;
using SwingModel.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.XPath;
using System.Xml;
using System.Globalization;
using System.Threading;
using System.Text;
using CompuSportDAL;

public partial class Controls_HurdleStepAthletEdit : System.Web.UI.UserControl
{
    TList<Lesson> lessonlist = new TList<Lesson>();
    string location;
    int lessonid;
    public string wmpfile = "";
    int x;

    public Customer customerid;
    public Customer cust;
    public CustomerProfile customerprofile;
    public CustomerProfile customerprofile1;
    TList<Customer> customer = new TList<Customer>();
    Movie movieSide;
    Movie CurrentMovieSide;
    Movie CurrentMovieBack;
    bool isMovieClipsExist = false;
    bool isSummarySessionExist = false;
    SummaryMovie summaryMovie;
    int _lessonid;
    int summarysessionlessionid = 0;
    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    CompuSportDAL.SprintAthleteEdit sae = new CompuSportDAL.SprintAthleteEdit();
    CompuSportDAL.SprintData _SprintData = new CompuSportDAL.SprintData();
    Customer Hurdlecustomer;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        btnUpload.Enabled = false;
        btnToBrowseCurrentVideo.Enabled = false;
        btnUpload2.Enabled = false;
        btnSubmit.Enabled = false;
        btnDeleteSession.Enabled = false;
        btndateloc.Enabled = false;
        btnInpuFullSession.Enabled = false;
        btnDeleteInitialMovies.Enabled = false;
        btnDeleteCurrentMovies.Enabled = false;
        bool AthleteAlreadyInList = false;
        customerid = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
        customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customerid.CustomerId)[0];
        if (!IsPostBack)
        {
            customer = DataRepository.CustomerProvider.GetAll();
            customer.Sort("FirstName");
            foreach (var item in customer)
            {
                cust = DataRepository.CustomerProvider.GetByCustomerId(item.CustomerId);
                {
                    if (DropDownList1.Items.Count > 0)
                    {
                        if (DropDownList1.Items.Contains(DropDownList1.Items.FindByValue(item.CustomerId.ToString())))
                            AthleteAlreadyInList = true;
                        else
                            AthleteAlreadyInList = false;
                    }

                    if (!AthleteAlreadyInList)
                    {
                        x++;
                        DropDownList1.Items.Add(item.FirstName + " " + item.LastName);
                        DropDownList1.Items[x].Value = item.CustomerId.ToString();

                        continue;
                    }
                }
            }
        }
    }
    //private void LoadExistingLocation()
    //{
    //    int AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
    //    lessonlist = DataRepository.LessonProvider.GetByCustomerId(AthleteSelected);
    //    if (lessonlist.Count != 0)
    //    {
    //        int athleteSelected;
    //        athleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
    //        HurdleStepsPageOnTrackSessi hurdleStepsPageOnTrackSessi = new HurdleStepsPageOnTrackSessi();
    //        hurdleStepsPageOnTrackSessi.HurdlePageOnTrackSessionData(athleteSelected);

    //        Label2.Visible = false;
    //        btndateloc.Visible = true;
    //        btnDeleteSession.Visible = true;
    //        btnSubmit.Visible = true;
    //        DropDownList2.Visible = true;
    //        Customer cust = DataRepository.CustomerProvider.GetByCustomerId(AthleteSelected);
    //        Lesson lessonid1 = DataRepository.LessonProvider.GetByCustomerId(cust.CustomerId)[0];
    //        string athletelessonid = lessonid1.LessonId.ToString();
    //        lessonlist.Sort("LessonDate DESC");
    //        x = 0;
    //        DropDownList2.Items.Add("Select Analysis Date and Location");
    //        DropDownList2.Items[0].Value = "";

    //        foreach (Lesson lesson in lessonlist)
    //        {
    //            string location = sae.SelectLessonlocation(lesson.LessonId.ToString());

    //            if (lesson.LessonTypeId.Equals(6))//chk
    //            {
    //                x++;
    //                // DropDownList2.Items.Add(lesson.LessonDate.ToString("MM/dd/yyyy HH:mm:ss"));
    //                DropDownList2.Items.Add(lesson.LessonDate.ToString("MM/dd/yyyy") + " - " + location);
    //                DropDownList2.Items[x].Value = lesson.LessonId.ToString();
    //            }
    //        }
    //    }
    //    else
    //    {
    //        Label2.Visible = true;
    //        btndateloc.Visible = true;
    //        DropDownList2.Visible = false;
    //        btnDeleteSession.Visible = true;
    //        btnSubmit.Visible = true;
    //        btnInpuFullSession.Visible = true;
    //        DropdownListXmlFle.Visible = true;
    //    }
    //}

    private void LoadExistingLocation()
    {
        int AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
        lessonlist = DataRepository.LessonProvider.GetByCustomerId(AthleteSelected);
        if (lessonlist.Count != 0)
        {
            Label2.Visible = false;
            btndateloc.Visible = true;
            btnDeleteSession.Visible = true;
            btnSubmit.Visible = true;
            DropDownList2.Visible = true;
            int athleteSelected;
            athleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
            HurdleStepsPageOnTrackSessi hurdleStepsPageOnTrackSessi = new HurdleStepsPageOnTrackSessi();
            hurdleStepsPageOnTrackSessi.HurdlePageOnTrackSessionData(athleteSelected);
            string expression = "LessonTypeID = 6";
            var rows = sae.GetAllAthliteListData(athleteSelected).Select(expression).ToList();
            DropDownList2.Items.Add("Select Analysis Date and Location");
            foreach (DataRow row in rows)
            {
                var lessiodatelocaon = Convert.ToDateTime(row["LessonDate"]).ToString("MM/dd/yyyy") + " - " + row["LessonLocation"];
                DropDownList2.Items.Add(lessiodatelocaon);
                x++;
                DropDownList2.Items[x].Value = row["LessonId"].ToString();
            }
        }
        else
        {
            Label2.Visible = true;
            btndateloc.Visible = true;
            DropDownList2.Visible = false;
            btnDeleteSession.Visible = true;
            btnSubmit.Visible = true;
            btnInpuFullSession.Visible = true;
            DropdownListXmlFle.Visible = true;
        }
    }
void sendNotFoundEmail(int initialcnt, int modelCnt, int CurrentCnt)
    {
        var _initialMessage = "This initial variable has 0 values = ";
        var _modelMessage = "This model variable has 0 values = ";
        var _currentMessage = "This current variable has 0 values = ";
        var message = "";
        var dataMising = false;
        for (int i = 0; i < missingVariable.Count; i++)
        {
            if (missingVariable[i].type == "initial" && initialcnt < 39)
            {
                dataMising = true;
                _initialMessage += missingVariable[i].variableName + ", ";
            }
            if (missingVariable[i].type == "model" && modelCnt < 39)
            {
                dataMising = true;
                _modelMessage += missingVariable[i].variableName + ", ";
            }
            if (missingVariable[i].type == "current" && CurrentCnt < 39)
            {
                dataMising = true;
                _currentMessage += missingVariable[i].variableName + ", ";
            }
        }
        if (dataMising == true)
        {
            var lessiodatelocaon = (DropDownList2.SelectedItem.Text);
            message = "Session Details :- " + "Hurdle Step " + " " + "->" + " " + lessiodatelocaon + "\n" + _initialMessage + "\n" + _modelMessage + "\n" + _currentMessage;
            var email = Membership.GetUser().Email;
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new System.Net.Mail.MailAddress(email);
            msg.To.Add("dev@Compusport.com");
            msg.Body = message;
            msg.Subject = "Compusport : " + Hurdlecustomer.FirstName + " " + Hurdlecustomer.LastName + " Data Missing";
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "198.143.141.120";
            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential("dev@compusport.com", "develop!?");
            smtp.Send(msg);
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropdownListXmlFle.Items.Clear();
        DropDownList2.Items.Clear();
        txtndbtnVisibleOFF();
        if (!DropDownList1.SelectedValue.Equals("noathlete"))
        {
            txtndbtnVisibleOFF();
            lblDate.Visible = false;
            lblLocation.Visible = false;
            txtDate.Visible = false;
            txtLocation.Visible = false;
            lblDateEx.Visible = false;
            lblexlocation.Visible = false;
            txtTime.Visible = false;
            lblTime.Visible = false;
            lblExTime.Visible = false;
            btnDeleteInitialMovies.Visible = true;
            btnDeleteCurrentMovies.Visible = true;
            btnDeleteSummaryMovie.Visible = true;
            btnUpload.Enabled = true;
            btnToBrowseCurrentVideo.Enabled = true;
            btnUpload2.Enabled = true;
            btnSubmit.Enabled = true;
            btnDeleteSession.Enabled = true;
            btndateloc.Enabled = true;
            btnInpuFullSession.Enabled = true;
            btnDeleteInitialMovies.Enabled = true;
            btnDeleteCurrentMovies.Enabled = true;
            btnDeleteSummaryMovie.Enabled = true;
            lblNoVideo.Visible = false;
            ClearData();
            DataClear(); //05/01/2017
            DropdownListXmlFle.Items.Clear();
            Label3.Visible = false;
            txtbFilePath.Text = "";
            txtbFilePath.Text = "";
            txtSumFilePath.Text = "";
            txtForCurrentVideo.Text = "";
            DropDownList2.Items.Clear();
            LoadExistingLocation();
            ClearFramesData();
        }
    }
    private void DataClear()
    {
        #region[DataClear]

        TxtHurdleDistanceBtweenM1.Text = "";
        TxtHurdleDistanceIntoM1.Text = "";
        TxtHurdleDistanceOffM1.Text = "";
        //TxtHurdleVelocityM1.Text = "";

        //Step 1
        TxtStep1GroundTimeM1.Text = "";
        TxtStep1AirTimeM1.Text = "";
        //TxtStep1UlFlexTimeM1.Text = "";
        //TxtStep1StrideRateM1.Text = "";
        TxtStep1StrideLengthM1.Text = "";
        TxtStep1TouchDistanceM1.Text = "";
        TxtStep1KSTouchDistanceM1.Text = "";
        TxtStep1TrunkTouchdownAngleM1.Text = "";
        TxtStep1TrunkTakeoffAngleM1.Text = ""; ;
        TxtStep1ULFullExtensionM1.Text = "";
        TxtStep1LLTakeOffM1.Text = "";
        TxtStep1ULFullFlexionM1.Text = "";

        //Step 2
        TxtStep2GroundTimeM1.Text = "";
        TxtStep2AirTimeM1.Text = "";
        //TxtStep2UlFlexTimeM1.Text = "";
        //TxtStep2StrideRateM1.Text = "";
        TxtStep2StrideLengthM1.Text = "";
        TxtStep2TouchDistanceM1.Text = "";
        TxtStep2KSTouchDistanceM1.Text = "";
        TxtStep2TrunkTouchdownAngleM1.Text = "";
        TxtStep2TrunkTakeoffAngleM1.Text = "";
        TxtStep2TrunkTakeoffAngleM1.Text = "";

        TxtStep2ULFullExtensionM1.Text = "";
        TxtStep2LLTakeOffM1.Text = "";
        TxtStep2LLFullFlexionM1.Text = "";
        //TxtStep2LLAnkleCrossM1.Text = "";
        TxtStep2ULFullFlexionM1.Text = "";

        //Step 3
        TxtStep3GroundTimeM1.Text = "";
        TxtStep3AirTimeM1.Text = "";
        // TxtStep3UlFlexTimeM1.Text = "";
        //TxtStep3StrideRateM1.Text = "";
        TxtStep3StrideLengthM1.Text = "";
        TxtStep3TouchDistanceM1.Text = "";
        TxtStep3KSTouchDistanceM1.Text = "";
        TxtStep3TrunkTouchdownAngleM1.Text = "";

        TxtStep3TrunkTouchdownAngleM1.Text = "";

        TxtStep3TrunkTakeoffAngleM1.Text = "";
        TxtStep3ULFullExtensionM1.Text = "";
        TxtStep3LLTakeOffM1.Text = "";
        TxtStep3LLFullFlexionM1.Text = "";
        //TxtStep3LLAnkleCrossM1.Text = "";
        TxtStep3ULFullFlexionM1.Text = "";

        //IntoHurdle STeps 

        TxtIntoHurdleTouchDistanceM1.Text = "";
        TxtIntoHurdleKSTouchDistanceM1.Text = "";
        TxtIntoHurdleTrunkTouchdownAngleM1.Text = "";
        TxtIntoHurdleLLTouchDistanceM1.Text = "";

        #endregion[DataClear]
    }
    private void ClearData()
    {

        #region[Cleardata]

        //Initial Data
        TxtHurdleDistanceBtweenI.Text = "";
        TxtHurdleDistanceIntoI.Text = "";
        TxtHurdleDistanceOffI.Text = "";
        // TxtHurdleVelocityI.Text = "";

        //Step 1
        TxtStep1GroundTimeI.Text = "";
        TxtStep1AirTimeI.Text = "";
        // TxtStep1UlFlexTimeI.Text = "";
        //TxtStep1StrideRateI.Text = "";
        TxtStep1StrideLengthI.Text = "";
        TxtStep1TouchDistanceI.Text = "";
        TxtStep1KSTouchDistanceI.Text = "";
        TxtStep1TrunkTouchdownAngleI.Text = "";
        TxtStep1TrunkTakeoffAngleI.Text = "";
        TxtStep1ULFullExtensionI.Text = "";
        TxtStep1LLTakeOffI.Text = "";
        TxtStep1ULFullFlexionI.Text = "";

        //Step 2
        TxtStep2GroundTimeI.Text = "";
        TxtStep2AirTimeI.Text = "";
        // TxtStep2UlFlexTimeI.Text = "";
        //TxtStep2StrideRateI.Text = "";
        TxtStep2StrideLengthI.Text = "";
        TxtStep2TouchDistanceI.Text = "";
        TxtStep2KSTouchDistanceI.Text = "";
        TxtStep2TrunkTouchdownAngleI.Text = "";
        TxtStep2TrunkTakeoffAngleI.Text = "";
        TxtStep2ULFullExtensionI.Text = "";
        TxtStep2LLTakeOffI.Text = "";
        TxtStep2LLFullFlexionI.Text = "";
        //TxtStep2LLAnkleCrossI.Text = "";
        TxtStep2ULFullFlexionI.Text = "";

        //Step 3
        TxtStep3GroundTimeI.Text = "";
        TxtStep3AirTimeI.Text = "";
        //TxtStep3UlFlexTimeI.Text = "";
        //TxtStep3StrideRateI.Text = "";
        TxtStep3StrideLengthI.Text = "";
        TxtStep3TouchDistanceI.Text = "";
        TxtStep3KSTouchDistanceI.Text = "";
        TxtStep3TrunkTouchdownAngleI.Text = "";
        TxtStep3TrunkTakeoffAngleI.Text = "";
        TxtStep3ULFullExtensionI.Text = "";
        TxtStep3LLTakeOffI.Text = "";
        TxtStep3LLFullFlexionI.Text = "";
        //TxtStep3LLAnkleCrossI.Text = "";
        TxtStep3ULFullFlexionI.Text = "";


        //IntoHurdle STeps 

        TxtIntoHurdleTouchDistanceI.Text = "";
        TxtIntoHurdleKSTouchDistanceI.Text = "";
        TxtIntoHurdleTrunkTouchdownAngleI.Text = "";
        TxtIntoHurdleLLTouchDistanceI.Text = "";


        //Model Data

        //TxtHurdleDistanceBtweenM1.Text = "";
        //TxtHurdleDistanceIntoM1.Text = "";
        //TxtHurdleDistanceOffM1.Text = "";
        ////TxtHurdleVelocityM1.Text = "";//Already comment

        ////Step 1
        //TxtStep1GroundTimeM1.Text = "";
        //TxtStep1AirTimeM1.Text = "";
        ////TxtStep1UlFlexTimeM1.Text = ""; //Already comment
        ////TxtStep1StrideRateM1.Text = ""; //Already comment
        //TxtStep1StrideLengthM1.Text = "";
        //TxtStep1TouchDistanceM1.Text = "";
        //TxtStep1KSTouchDistanceM1.Text = "";
        //TxtStep1TrunkTouchdownAngleM1.Text = "";
        //TxtStep1TrunkTakeoffAngleM1.Text = ""; ;
        //TxtStep1ULFullExtensionM1.Text = "";
        //TxtStep1LLTakeOffM1.Text = "";
        //TxtStep1ULFullFlexionM1.Text = "";

        ////Step 2
        //TxtStep2GroundTimeM1.Text = "";
        //TxtStep2AirTimeM1.Text = "";
        ////TxtStep2UlFlexTimeM1.Text = "";//Already comment
        ////TxtStep2StrideRateM1.Text = "";//Already comment
        //TxtStep2StrideLengthM1.Text = "";
        //TxtStep2TouchDistanceM1.Text = "";
        //TxtStep2KSTouchDistanceM1.Text = "";
        //TxtStep2TrunkTouchdownAngleM1.Text = "";
        //TxtStep2TrunkTakeoffAngleM1.Text = "";
        //TxtStep2TrunkTakeoffAngleM1.Text = "";

        //TxtStep2ULFullExtensionM1.Text = "";
        //TxtStep2LLTakeOffM1.Text = "";
        //TxtStep2LLFullFlexionM1.Text = "";
        ////TxtStep2LLAnkleCrossM1.Text = "";//Already comment
        //TxtStep2ULFullFlexionM1.Text = "";

        ////Step 3
        //TxtStep3GroundTimeM1.Text = "";
        //TxtStep3AirTimeM1.Text = "";
        //// TxtStep3UlFlexTimeM1.Text = "";//Already comment
        ////TxtStep3StrideRateM1.Text = "";//Already comment
        //TxtStep3StrideLengthM1.Text = "";
        //TxtStep3TouchDistanceM1.Text = "";
        //TxtStep3KSTouchDistanceM1.Text = "";
        //TxtStep3TrunkTouchdownAngleM1.Text = "";

        //TxtStep3TrunkTouchdownAngleM1.Text = "";

        //TxtStep3TrunkTakeoffAngleM1.Text = "";
        //TxtStep3ULFullExtensionM1.Text = "";
        //TxtStep3LLTakeOffM1.Text = "";
        //TxtStep3LLFullFlexionM1.Text = "";
        ////TxtStep3LLAnkleCrossM1.Text = "";//Already comment
        //TxtStep3ULFullFlexionM1.Text = "";

        //IntoHurdle STeps 

        //TxtIntoHurdleTouchDistanceM1.Text = "";
        //TxtIntoHurdleKSTouchDistanceM1.Text = "";
        //TxtIntoHurdleTrunkTouchdownAngleM1.Text = "";
        //TxtIntoHurdleLLTouchDistanceM1.Text = "";


        //Current Data


        TxtHurdleDistanceBtweenF.Text = "";
        TxtHurdleDistanceIntoF.Text = "";
        TxtHurdleDistanceOffF.Text = "";
        // TxtHurdleVelocityF.Text = "";

        //Step 1
        TxtStep1GroundTimeF.Text = "";
        TxtStep1AirTimeF.Text = "";
        // TxtStep1UlFlexTimeF.Text = "";
        //TxtStep1StrideRateF.Text = "";
        TxtStep1StrideLengthF.Text = "";
        TxtStep1TouchDistanceF.Text = "";
        TxtStep1KSTouchDistanceF.Text = "";
        TxtStep1TrunkTouchdownAngleF.Text = "";
        TxtStep1TrunkTakeoffAngleF.Text = "";
        TxtStep1ULFullExtensionF.Text = "";
        TxtStep1LLTakeOffF.Text = "";
        TxtStep1ULFullFlexionF.Text = "";

        //Step 2
        TxtStep2GroundTimeF.Text = "";
        TxtStep2AirTimeF.Text = "";
        // TxtStep2UlFlexTimeF.Text = "";
        // TxtStep2StrideRateF.Text = "";
        TxtStep2StrideLengthF.Text = "";
        TxtStep2TouchDistanceF.Text = "";
        TxtStep2KSTouchDistanceF.Text = "";
        TxtStep2TrunkTouchdownAngleF.Text = "";
        TxtStep2TrunkTakeoffAngleF.Text = "";
        TxtStep2ULFullExtensionF.Text = "";
        TxtStep2LLTakeOffF.Text = "";
        TxtStep2LLFullFlexionF.Text = "";
        //TxtStep2LLAnkleCrossF.Text = "";
        TxtStep2ULFullFlexionF.Text = "";

        //Step 3
        TxtStep3GroundTimeF.Text = "";
        TxtStep3AirTimeF.Text = "";
        //TxtStep3UlFlexTimeF.Text = "";
        //TxtStep3StrideRateF.Text = "";
        TxtStep3StrideLengthF.Text = "";
        TxtStep3TouchDistanceF.Text = "";
        TxtStep3KSTouchDistanceF.Text = "";
        TxtStep3TrunkTouchdownAngleF.Text = "";
        TxtStep3TrunkTakeoffAngleF.Text = "";
        TxtStep3ULFullExtensionF.Text = "";
        TxtStep3LLTakeOffF.Text = "";
        TxtStep3LLFullFlexionF.Text = "";
        //TxtStep3LLAnkleCrossF.Text = "";
        TxtStep3ULFullFlexionF.Text = "";

        //IntoHurdle STeps 

        TxtIntoHurdleTouchDistanceF.Text = "";
        TxtIntoHurdleKSTouchDistanceF.Text = "";
        TxtIntoHurdleTrunkTouchdownAngleF.Text = "";
        TxtIntoHurdleLLTouchDistanceF.Text = "";
        Label117.Text = "";
        #endregion[Cleardata]//chk

    }
    public void txtndbtnVisibleOFF()
    {
        txtbFilePath.Text = "";
        txtForCurrentVideo.Text = "";
        //Initial Data
        TxtHurdleDistanceBtweenI.Text = "";
        TxtHurdleDistanceIntoI.Text = "";
        TxtHurdleDistanceOffI.Text = "";
        // TxtHurdleVelocityI.Text = "";

        //Step 1
        TxtStep1GroundTimeI.Text = "";
        TxtStep1AirTimeI.Text = "";
        // TxtStep1UlFlexTimeI.Text = "";
        //TxtStep1StrideRateI.Text = "";
        TxtStep1StrideLengthI.Text = "";
        TxtStep1TouchDistanceI.Text = "";
        TxtStep1KSTouchDistanceI.Text = "";
        TxtStep1TrunkTouchdownAngleI.Text = "";
        TxtStep1TrunkTakeoffAngleI.Text = "";
        TxtStep1ULFullExtensionI.Text = "";
        TxtStep1LLTakeOffI.Text = "";
        TxtStep1ULFullFlexionI.Text = "";

        //Step 2
        TxtStep2GroundTimeI.Text = "";
        TxtStep2AirTimeI.Text = "";
        // TxtStep2UlFlexTimeI.Text = "";
        //TxtStep2StrideRateI.Text = "";
        TxtStep2StrideLengthI.Text = "";
        TxtStep2TouchDistanceI.Text = "";
        TxtStep2KSTouchDistanceI.Text = "";
        TxtStep2TrunkTouchdownAngleI.Text = "";
        TxtStep2TrunkTakeoffAngleI.Text = "";
        TxtStep2ULFullExtensionI.Text = "";
        TxtStep2LLTakeOffI.Text = "";
        TxtStep2LLFullFlexionI.Text = "";
        //TxtStep2LLAnkleCrossI.Text = "";
        TxtStep2ULFullFlexionI.Text = "";

        //Step 3
        TxtStep3GroundTimeI.Text = "";
        TxtStep3AirTimeI.Text = "";
        //TxtStep3UlFlexTimeI.Text = "";
        //TxtStep3StrideRateI.Text = "";
        TxtStep3StrideLengthI.Text = "";
        TxtStep3TouchDistanceI.Text = "";
        TxtStep3KSTouchDistanceI.Text = "";
        TxtStep3TrunkTouchdownAngleI.Text = "";
        TxtStep3TrunkTakeoffAngleI.Text = "";
        TxtStep3ULFullExtensionI.Text = "";
        TxtStep3LLTakeOffI.Text = "";
        TxtStep3LLFullFlexionI.Text = "";
        //TxtStep3LLAnkleCrossI.Text = "";
        TxtStep3ULFullFlexionI.Text = "";


        //IntoHurdle STeps 

        TxtIntoHurdleTouchDistanceI.Text = "";
        TxtIntoHurdleKSTouchDistanceI.Text = "";
        TxtIntoHurdleTrunkTouchdownAngleI.Text = "";
        TxtIntoHurdleLLTouchDistanceI.Text = "";


        //Model Data

        TxtHurdleDistanceBtweenM1.Text = "";
        TxtHurdleDistanceIntoM1.Text = "";
        TxtHurdleDistanceOffM1.Text = "";
        //TxtHurdleVelocityM1.Text = "";//Already comment

        //Step 1
        TxtStep1GroundTimeM1.Text = "";
        TxtStep1AirTimeM1.Text = "";
        //TxtStep1UlFlexTimeM1.Text = ""; //Already comment
        //TxtStep1StrideRateM1.Text = ""; //Already comment
        TxtStep1StrideLengthM1.Text = "";
        TxtStep1TouchDistanceM1.Text = "";
        TxtStep1KSTouchDistanceM1.Text = "";
        TxtStep1TrunkTouchdownAngleM1.Text = "";
        TxtStep1TrunkTakeoffAngleM1.Text = ""; ;
        TxtStep1ULFullExtensionM1.Text = "";
        TxtStep1LLTakeOffM1.Text = "";
        TxtStep1ULFullFlexionM1.Text = "";

        //Step 2
        TxtStep2GroundTimeM1.Text = "";
        TxtStep2AirTimeM1.Text = "";
        //TxtStep2UlFlexTimeM1.Text = "";//Already comment
        //TxtStep2StrideRateM1.Text = "";//Already comment
        TxtStep2StrideLengthM1.Text = "";
        TxtStep2TouchDistanceM1.Text = "";
        TxtStep2KSTouchDistanceM1.Text = "";
        TxtStep2TrunkTouchdownAngleM1.Text = "";
        TxtStep2TrunkTakeoffAngleM1.Text = "";
        TxtStep2TrunkTakeoffAngleM1.Text = "";

        TxtStep2ULFullExtensionM1.Text = "";
        TxtStep2LLTakeOffM1.Text = "";
        TxtStep2LLFullFlexionM1.Text = "";
        //TxtStep2LLAnkleCrossM1.Text = "";//Already comment
        TxtStep2ULFullFlexionM1.Text = "";

        //Step 3
        TxtStep3GroundTimeM1.Text = "";
        TxtStep3AirTimeM1.Text = "";
        // TxtStep3UlFlexTimeM1.Text = "";//Already comment
        //TxtStep3StrideRateM1.Text = "";//Already comment
        TxtStep3StrideLengthM1.Text = "";
        TxtStep3TouchDistanceM1.Text = "";
        TxtStep3KSTouchDistanceM1.Text = "";
        TxtStep3TrunkTouchdownAngleM1.Text = "";

        TxtStep3TrunkTouchdownAngleM1.Text = "";

        TxtStep3TrunkTakeoffAngleM1.Text = "";
        TxtStep3ULFullExtensionM1.Text = "";
        TxtStep3LLTakeOffM1.Text = "";
        TxtStep3LLFullFlexionM1.Text = "";
        //TxtStep3LLAnkleCrossM1.Text = "";//Already comment
        TxtStep3ULFullFlexionM1.Text = "";

        //IntoHurdle STeps 

        TxtIntoHurdleTouchDistanceM1.Text = "";
        TxtIntoHurdleKSTouchDistanceM1.Text = "";
        TxtIntoHurdleTrunkTouchdownAngleM1.Text = "";
        TxtIntoHurdleLLTouchDistanceM1.Text = "";


        //Current Data


        TxtHurdleDistanceBtweenF.Text = "";
        TxtHurdleDistanceIntoF.Text = "";
        TxtHurdleDistanceOffF.Text = "";
        // TxtHurdleVelocityF.Text = "";

        //Step 1
        TxtStep1GroundTimeF.Text = "";
        TxtStep1AirTimeF.Text = "";
        // TxtStep1UlFlexTimeF.Text = "";
        //TxtStep1StrideRateF.Text = "";
        TxtStep1StrideLengthF.Text = "";
        TxtStep1TouchDistanceF.Text = "";
        TxtStep1KSTouchDistanceF.Text = "";
        TxtStep1TrunkTouchdownAngleF.Text = "";
        TxtStep1TrunkTakeoffAngleF.Text = "";
        TxtStep1ULFullExtensionF.Text = "";
        TxtStep1LLTakeOffF.Text = "";
        TxtStep1ULFullFlexionF.Text = "";

        //Step 2
        TxtStep2GroundTimeF.Text = "";
        TxtStep2AirTimeF.Text = "";
        // TxtStep2UlFlexTimeF.Text = "";
        // TxtStep2StrideRateF.Text = "";
        TxtStep2StrideLengthF.Text = "";
        TxtStep2TouchDistanceF.Text = "";
        TxtStep2KSTouchDistanceF.Text = "";
        TxtStep2TrunkTouchdownAngleF.Text = "";
        TxtStep2TrunkTakeoffAngleF.Text = "";
        TxtStep2ULFullExtensionF.Text = "";
        TxtStep2LLTakeOffF.Text = "";
        TxtStep2LLFullFlexionF.Text = "";
        //TxtStep2LLAnkleCrossF.Text = "";
        TxtStep2ULFullFlexionF.Text = "";

        //Step 3
        TxtStep3GroundTimeF.Text = "";
        TxtStep3AirTimeF.Text = "";
        //TxtStep3UlFlexTimeF.Text = "";
        //TxtStep3StrideRateF.Text = "";
        TxtStep3StrideLengthF.Text = "";
        TxtStep3TouchDistanceF.Text = "";
        TxtStep3KSTouchDistanceF.Text = "";
        TxtStep3TrunkTouchdownAngleF.Text = "";
        TxtStep3TrunkTakeoffAngleF.Text = "";
        TxtStep3ULFullExtensionF.Text = "";
        TxtStep3LLTakeOffF.Text = "";
        TxtStep3LLFullFlexionF.Text = "";
        //TxtStep3LLAnkleCrossF.Text = "";
        TxtStep3ULFullFlexionF.Text = "";

        //IntoHurdle STeps 

        TxtIntoHurdleTouchDistanceF.Text = "";
        TxtIntoHurdleKSTouchDistanceF.Text = "";
        TxtIntoHurdleTrunkTouchdownAngleF.Text = "";
        TxtIntoHurdleLLTouchDistanceF.Text = "";
        Label117.Text = "";

        txtBFrame1.Text = "";
        txtBFrame2.Text = "";
        txtBFrame3.Text = "";
        txtBFrame4.Text = "";
        txtBFrame5.Text = "";
        txtBFrame6.Text = "";
        txtBFrame7.Text = "";
        txtBFrame8.Text = "";
        txtCBFrame1.Text = "";
        txtCBFrame2.Text = "";
        txtCBFrame3.Text = "";
        txtCBFrame4.Text = "";
        txtCBFrame5.Text = "";
        txtCBFrame6.Text = "";
        txtCBFrame7.Text = "";
        txtCBFrame8.Text = "";
    }
    private void OntrackSessionSelect()
    {
        btnUpload.Enabled = false;
        btnToBrowseCurrentVideo.Enabled = false;
        btnUpload2.Enabled = false;
        btnSubmit.Enabled = false;
        btnDeleteSession.Enabled = false;
        btnInpuFullSession.Enabled = false;
        btnDeleteInitialMovies.Enabled = false;
        btnDeleteCurrentMovies.Enabled = false;

        txtbFilePath.ReadOnly = true;
        txtForCurrentVideo.ReadOnly = true;
        //Initial Data
        TxtHurdleDistanceBtweenI.ReadOnly = true;
        TxtHurdleDistanceIntoI.ReadOnly = true;
        TxtHurdleDistanceOffI.ReadOnly = true;


        //Step 1
        TxtStep1GroundTimeI.ReadOnly = true;
        TxtStep1AirTimeI.ReadOnly = true;

        TxtStep1StrideLengthI.ReadOnly = true;
        TxtStep1TouchDistanceI.ReadOnly = true;
        TxtStep1KSTouchDistanceI.ReadOnly = true;
        TxtStep1TrunkTouchdownAngleI.ReadOnly = true;
        TxtStep1TrunkTakeoffAngleI.ReadOnly = true;
        TxtStep1ULFullExtensionI.ReadOnly = true;
        TxtStep1LLTakeOffI.ReadOnly = true;
        TxtStep1ULFullFlexionI.ReadOnly = true;

        //Step 2
        TxtStep2GroundTimeI.ReadOnly = true;
        TxtStep2AirTimeI.ReadOnly = true;

        TxtStep2StrideLengthI.ReadOnly = true;
        TxtStep2TouchDistanceI.ReadOnly = true;
        TxtStep2KSTouchDistanceI.ReadOnly = true;
        TxtStep2TrunkTouchdownAngleI.ReadOnly = true;
        TxtStep2TrunkTakeoffAngleI.ReadOnly = true;
        TxtStep2ULFullExtensionI.ReadOnly = true;
        TxtStep2LLTakeOffI.ReadOnly = true;
        TxtStep2LLFullFlexionI.ReadOnly = true;
        TxtStep2ULFullFlexionI.ReadOnly = true;

        //Step 3
        TxtStep3GroundTimeI.ReadOnly = true;
        TxtStep3AirTimeI.ReadOnly = true;
        TxtStep3StrideLengthI.ReadOnly = true;
        TxtStep3TouchDistanceI.ReadOnly = true;
        TxtStep3KSTouchDistanceI.ReadOnly = true;
        TxtStep3TrunkTouchdownAngleI.ReadOnly = true;
        TxtStep3TrunkTakeoffAngleI.ReadOnly = true;
        TxtStep3ULFullExtensionI.ReadOnly = true;
        TxtStep3LLTakeOffI.ReadOnly = true;
        TxtStep3LLFullFlexionI.ReadOnly = true;
        TxtStep3ULFullFlexionI.ReadOnly = true;


        //IntoHurdle STeps 

        TxtIntoHurdleTouchDistanceI.ReadOnly = true;
        TxtIntoHurdleKSTouchDistanceI.ReadOnly = true;
        TxtIntoHurdleTrunkTouchdownAngleI.ReadOnly = true;
        TxtIntoHurdleLLTouchDistanceI.ReadOnly = true;


        //Model Data

        TxtHurdleDistanceBtweenM1.ReadOnly = true;
        TxtHurdleDistanceIntoM1.ReadOnly = true;
        TxtHurdleDistanceOffM1.ReadOnly = true;

        //Step 1
        TxtStep1GroundTimeM1.ReadOnly = true;
        TxtStep1AirTimeM1.ReadOnly = true;
        TxtStep1StrideLengthM1.ReadOnly = true;
        TxtStep1TouchDistanceM1.ReadOnly = true;
        TxtStep1KSTouchDistanceM1.ReadOnly = true;
        TxtStep1TrunkTouchdownAngleM1.ReadOnly = true;
        TxtStep1TrunkTakeoffAngleM1.ReadOnly = true;
        TxtStep1ULFullExtensionM1.ReadOnly = true;
        TxtStep1LLTakeOffM1.ReadOnly = true;
        TxtStep1ULFullFlexionM1.ReadOnly = true;

        //Step 2
        TxtStep2GroundTimeM1.ReadOnly = true;
        TxtStep2AirTimeM1.ReadOnly = true;
        TxtStep2StrideLengthM1.ReadOnly = true;
        TxtStep2TouchDistanceM1.ReadOnly = true;
        TxtStep2KSTouchDistanceM1.ReadOnly = true;
        TxtStep2TrunkTouchdownAngleM1.ReadOnly = true;
        TxtStep2TrunkTakeoffAngleM1.ReadOnly = true;
        TxtStep2TrunkTakeoffAngleM1.ReadOnly = true;

        TxtStep2ULFullExtensionM1.ReadOnly = true;
        TxtStep2LLTakeOffM1.ReadOnly = true;
        TxtStep2LLFullFlexionM1.ReadOnly = true;
        TxtStep2ULFullFlexionM1.ReadOnly = true;

        //Step 3
        TxtStep3GroundTimeM1.ReadOnly = true;
        TxtStep3AirTimeM1.ReadOnly = true;
        TxtStep3StrideLengthM1.ReadOnly = true;
        TxtStep3TouchDistanceM1.ReadOnly = true;
        TxtStep3KSTouchDistanceM1.ReadOnly = true;
        TxtStep3TrunkTouchdownAngleM1.ReadOnly = true;

        TxtStep3TrunkTouchdownAngleM1.ReadOnly = true;

        TxtStep3TrunkTakeoffAngleM1.ReadOnly = true;
        TxtStep3ULFullExtensionM1.ReadOnly = true;
        TxtStep3LLTakeOffM1.ReadOnly = true;
        TxtStep3LLFullFlexionM1.ReadOnly = true;
        TxtStep3ULFullFlexionM1.ReadOnly = true;

        //IntoHurdle STeps 

        TxtIntoHurdleTouchDistanceM1.ReadOnly = true;
        TxtIntoHurdleKSTouchDistanceM1.ReadOnly = true;
        TxtIntoHurdleTrunkTouchdownAngleM1.ReadOnly = true;
        TxtIntoHurdleLLTouchDistanceM1.ReadOnly = true;

        //Current Data

        TxtHurdleDistanceBtweenF.ReadOnly = true;
        TxtHurdleDistanceIntoF.ReadOnly = true;
        TxtHurdleDistanceOffF.ReadOnly = true;

        //Step 1
        TxtStep1GroundTimeF.ReadOnly = true;
        TxtStep1AirTimeF.ReadOnly = true;
        TxtStep1StrideLengthF.ReadOnly = true;
        TxtStep1TouchDistanceF.ReadOnly = true;
        TxtStep1KSTouchDistanceF.ReadOnly = true;
        TxtStep1TrunkTouchdownAngleF.ReadOnly = true;
        TxtStep1TrunkTakeoffAngleF.ReadOnly = true;
        TxtStep1ULFullExtensionF.ReadOnly = true;
        TxtStep1LLTakeOffF.ReadOnly = true;
        TxtStep1ULFullFlexionF.ReadOnly = true;

        //Step 2
        TxtStep2GroundTimeF.ReadOnly = true;
        TxtStep2AirTimeF.ReadOnly = true;
        TxtStep2StrideLengthF.ReadOnly = true;
        TxtStep2TouchDistanceF.ReadOnly = true;
        TxtStep2KSTouchDistanceF.ReadOnly = true;
        TxtStep2TrunkTouchdownAngleF.ReadOnly = true;
        TxtStep2TrunkTakeoffAngleF.ReadOnly = true;
        TxtStep2ULFullExtensionF.ReadOnly = true;
        TxtStep2LLTakeOffF.ReadOnly = true;
        TxtStep2LLFullFlexionF.ReadOnly = true;
        TxtStep2ULFullFlexionF.ReadOnly = true;

        //Step 3
        TxtStep3GroundTimeF.ReadOnly = true;
        TxtStep3AirTimeF.ReadOnly = true;
        TxtStep3StrideLengthF.ReadOnly = true;
        TxtStep3TouchDistanceF.ReadOnly = true;
        TxtStep3KSTouchDistanceF.ReadOnly = true;
        TxtStep3TrunkTouchdownAngleF.ReadOnly = true;
        TxtStep3TrunkTakeoffAngleF.ReadOnly = true;
        TxtStep3ULFullExtensionF.ReadOnly = true;
        TxtStep3LLTakeOffF.ReadOnly = true;
        TxtStep3LLFullFlexionF.ReadOnly = true;
        TxtStep3ULFullFlexionF.ReadOnly = true;

        //IntoHurdle STeps 

        TxtIntoHurdleTouchDistanceF.ReadOnly = true;
        TxtIntoHurdleKSTouchDistanceF.ReadOnly = true;
        TxtIntoHurdleTrunkTouchdownAngleF.ReadOnly = true;
        TxtIntoHurdleLLTouchDistanceF.ReadOnly = true;


        txtBFrame1.ReadOnly = true;
        txtBFrame2.ReadOnly = true;
        txtBFrame3.ReadOnly = true;
        txtBFrame4.ReadOnly = true;
        txtBFrame5.ReadOnly = true;
        txtBFrame6.ReadOnly = true;
        txtBFrame7.ReadOnly = true;
        txtBFrame8.ReadOnly = true;
        txtCBFrame1.ReadOnly = true;
        txtCBFrame2.ReadOnly = true;
        txtCBFrame3.ReadOnly = true;
        txtCBFrame4.ReadOnly = true;
        txtCBFrame5.ReadOnly = true;
        txtCBFrame6.ReadOnly = true;
        txtCBFrame7.ReadOnly = true;
        txtCBFrame8.ReadOnly = true;
    }
    private void ReadOntrackSessionSelect()
    {
        btnUpload.Enabled = true;
        btnToBrowseCurrentVideo.Enabled = true;
        btnUpload2.Enabled = true;
        btnSubmit.Enabled = true;
        btnDeleteSession.Enabled = true;
        btnInpuFullSession.Enabled = true;
        btnDeleteInitialMovies.Enabled = true;
        btnDeleteCurrentMovies.Enabled = true;

        txtbFilePath.ReadOnly = false;
        txtForCurrentVideo.ReadOnly = false;
        //Initial Data
        TxtHurdleDistanceBtweenI.ReadOnly = false;
        TxtHurdleDistanceIntoI.ReadOnly = false;
        TxtHurdleDistanceOffI.ReadOnly = false;


        //Step 1
        TxtStep1GroundTimeI.ReadOnly = false;
        TxtStep1AirTimeI.ReadOnly = false;

        TxtStep1StrideLengthI.ReadOnly = false;
        TxtStep1TouchDistanceI.ReadOnly = false;
        TxtStep1KSTouchDistanceI.ReadOnly = false;
        TxtStep1TrunkTouchdownAngleI.ReadOnly = false;
        TxtStep1TrunkTakeoffAngleI.ReadOnly = false;
        TxtStep1ULFullExtensionI.ReadOnly = false;
        TxtStep1LLTakeOffI.ReadOnly = false;
        TxtStep1ULFullFlexionI.ReadOnly = false;

        //Step 2
        TxtStep2GroundTimeI.ReadOnly = false;
        TxtStep2AirTimeI.ReadOnly = false;

        TxtStep2StrideLengthI.ReadOnly = false;
        TxtStep2TouchDistanceI.ReadOnly = false;
        TxtStep2KSTouchDistanceI.ReadOnly = false;
        TxtStep2TrunkTouchdownAngleI.ReadOnly = false;
        TxtStep2TrunkTakeoffAngleI.ReadOnly = false;
        TxtStep2ULFullExtensionI.ReadOnly = false;
        TxtStep2LLTakeOffI.ReadOnly = false;
        TxtStep2LLFullFlexionI.ReadOnly = false;
        TxtStep2ULFullFlexionI.ReadOnly = false;

        //Step 3
        TxtStep3GroundTimeI.ReadOnly = false;
        TxtStep3AirTimeI.ReadOnly = false;
        TxtStep3StrideLengthI.ReadOnly = false;
        TxtStep3TouchDistanceI.ReadOnly = false;
        TxtStep3KSTouchDistanceI.ReadOnly = false;
        TxtStep3TrunkTouchdownAngleI.ReadOnly = false;
        TxtStep3TrunkTakeoffAngleI.ReadOnly = false;
        TxtStep3ULFullExtensionI.ReadOnly = false;
        TxtStep3LLTakeOffI.ReadOnly = false;
        TxtStep3LLFullFlexionI.ReadOnly = false;
        TxtStep3ULFullFlexionI.ReadOnly = false;


        //IntoHurdle STeps 

        TxtIntoHurdleTouchDistanceI.ReadOnly = false;
        TxtIntoHurdleKSTouchDistanceI.ReadOnly = false;
        TxtIntoHurdleTrunkTouchdownAngleI.ReadOnly = false;
        TxtIntoHurdleLLTouchDistanceI.ReadOnly = false;


        //Model Data

        TxtHurdleDistanceBtweenM1.ReadOnly = false;
        TxtHurdleDistanceIntoM1.ReadOnly = false;
        TxtHurdleDistanceOffM1.ReadOnly = false;

        //Step 1
        TxtStep1GroundTimeM1.ReadOnly = false;
        TxtStep1AirTimeM1.ReadOnly = false;
        TxtStep1StrideLengthM1.ReadOnly = false;
        TxtStep1TouchDistanceM1.ReadOnly = false;
        TxtStep1KSTouchDistanceM1.ReadOnly = false;
        TxtStep1TrunkTouchdownAngleM1.ReadOnly = false;
        TxtStep1TrunkTakeoffAngleM1.ReadOnly = false;
        TxtStep1ULFullExtensionM1.ReadOnly = false;
        TxtStep1LLTakeOffM1.ReadOnly = false;
        TxtStep1ULFullFlexionM1.ReadOnly = false;

        //Step 2
        TxtStep2GroundTimeM1.ReadOnly = false;
        TxtStep2AirTimeM1.ReadOnly = false;
        TxtStep2StrideLengthM1.ReadOnly = false;
        TxtStep2TouchDistanceM1.ReadOnly = false;
        TxtStep2KSTouchDistanceM1.ReadOnly = false;
        TxtStep2TrunkTouchdownAngleM1.ReadOnly = false;
        TxtStep2TrunkTakeoffAngleM1.ReadOnly = false;
        TxtStep2TrunkTakeoffAngleM1.ReadOnly = false;

        TxtStep2ULFullExtensionM1.ReadOnly = false;
        TxtStep2LLTakeOffM1.ReadOnly = false;
        TxtStep2LLFullFlexionM1.ReadOnly = false;
        TxtStep2ULFullFlexionM1.ReadOnly = false;

        //Step 3
        TxtStep3GroundTimeM1.ReadOnly = false;
        TxtStep3AirTimeM1.ReadOnly = false;
        TxtStep3StrideLengthM1.ReadOnly = false;
        TxtStep3TouchDistanceM1.ReadOnly = false;
        TxtStep3KSTouchDistanceM1.ReadOnly = false;
        TxtStep3TrunkTouchdownAngleM1.ReadOnly = false;

        TxtStep3TrunkTouchdownAngleM1.ReadOnly = false;

        TxtStep3TrunkTakeoffAngleM1.ReadOnly = false;
        TxtStep3ULFullExtensionM1.ReadOnly = false;
        TxtStep3LLTakeOffM1.ReadOnly = false;
        TxtStep3LLFullFlexionM1.ReadOnly = false;
        TxtStep3ULFullFlexionM1.ReadOnly = false;

        //IntoHurdle STeps 

        TxtIntoHurdleTouchDistanceM1.ReadOnly = false;
        TxtIntoHurdleKSTouchDistanceM1.ReadOnly = false;
        TxtIntoHurdleTrunkTouchdownAngleM1.ReadOnly = false;
        TxtIntoHurdleLLTouchDistanceM1.ReadOnly = false;

        //Current Data

        TxtHurdleDistanceBtweenF.ReadOnly = false;
        TxtHurdleDistanceIntoF.ReadOnly = false;
        TxtHurdleDistanceOffF.ReadOnly = false;

        //Step 1
        TxtStep1GroundTimeF.ReadOnly = false;
        TxtStep1AirTimeF.ReadOnly = false;
        TxtStep1StrideLengthF.ReadOnly = false;
        TxtStep1TouchDistanceF.ReadOnly = false;
        TxtStep1KSTouchDistanceF.ReadOnly = false;
        TxtStep1TrunkTouchdownAngleF.ReadOnly = false;
        TxtStep1TrunkTakeoffAngleF.ReadOnly = false;
        TxtStep1ULFullExtensionF.ReadOnly = false;
        TxtStep1LLTakeOffF.ReadOnly = false;
        TxtStep1ULFullFlexionF.ReadOnly = false;

        //Step 2
        TxtStep2GroundTimeF.ReadOnly = false;
        TxtStep2AirTimeF.ReadOnly = false;
        TxtStep2StrideLengthF.ReadOnly = false;
        TxtStep2TouchDistanceF.ReadOnly = false;
        TxtStep2KSTouchDistanceF.ReadOnly = false;
        TxtStep2TrunkTouchdownAngleF.ReadOnly = false;
        TxtStep2TrunkTakeoffAngleF.ReadOnly = false;
        TxtStep2ULFullExtensionF.ReadOnly = false;
        TxtStep2LLTakeOffF.ReadOnly = false;
        TxtStep2LLFullFlexionF.ReadOnly = false;
        TxtStep2ULFullFlexionF.ReadOnly = false;

        //Step 3
        TxtStep3GroundTimeF.ReadOnly = false;
        TxtStep3AirTimeF.ReadOnly = false;
        TxtStep3StrideLengthF.ReadOnly = false;
        TxtStep3TouchDistanceF.ReadOnly = false;
        TxtStep3KSTouchDistanceF.ReadOnly = false;
        TxtStep3TrunkTouchdownAngleF.ReadOnly = false;
        TxtStep3TrunkTakeoffAngleF.ReadOnly = false;
        TxtStep3ULFullExtensionF.ReadOnly = false;
        TxtStep3LLTakeOffF.ReadOnly = false;
        TxtStep3LLFullFlexionF.ReadOnly = false;
        TxtStep3ULFullFlexionF.ReadOnly = false;

        //IntoHurdle STeps 

        TxtIntoHurdleTouchDistanceF.ReadOnly = false;
        TxtIntoHurdleKSTouchDistanceF.ReadOnly = false;
        TxtIntoHurdleTrunkTouchdownAngleF.ReadOnly = false;
        TxtIntoHurdleLLTouchDistanceF.ReadOnly = false;


        txtBFrame1.ReadOnly = false;
        txtBFrame2.ReadOnly = false;
        txtBFrame3.ReadOnly = false;
        txtBFrame4.ReadOnly = false;
        txtBFrame5.ReadOnly = false;
        txtBFrame6.ReadOnly = false;
        txtBFrame7.ReadOnly = false;
        txtBFrame8.ReadOnly = false;
        txtCBFrame1.ReadOnly = false;
        txtCBFrame2.ReadOnly = false;
        txtCBFrame3.ReadOnly = false;
        txtCBFrame4.ReadOnly = false;
        txtCBFrame5.ReadOnly = false;
        txtCBFrame6.ReadOnly = false;
        txtCBFrame7.ReadOnly = false;
        txtCBFrame8.ReadOnly = false;

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

        ClearData();
        Label4.Visible = false;
        txtbFilePath.Text = "";
        txtSumFilePath.Text = "";
        txtForCurrentVideo.Text = "";
        txtbFilePath.Visible = true;
        txtForCurrentVideo.Visible = true;
        btnUpload.Visible = true;
        btnUpload2.Visible = true;
        btnToBrowseCurrentVideo.Visible = true;
        txtSumFilePath.Visible = true;
        lblDate.Visible = false;
        lblLocation.Visible = false;
        txtDate.Visible = false;
        txtLocation.Visible = false;
        lblDateEx.Visible = false;
        lblexlocation.Visible = false;
        txtTime.Visible = false;
        lblTime.Visible = false;
        lblExTime.Visible = false;
        tblCurrentFrames.Visible = true;
        tblInitialFrames.Visible = true;
        ClearFramesData();
        btnDeleteCurrentMovies.Visible = true;
        btndateloc.Enabled = true;
        btnDeleteCurrentMovies.Enabled = true;
        btnInpuFullSession.Enabled = true;
        DropdownListXmlFle.Enabled = true;
        txtbFilePath.Enabled = true;
        btnUpload.Enabled = true;
        btnDeleteInitialMovies.Enabled = true;
        txtForCurrentVideo.Enabled = true;
        btnToBrowseCurrentVideo.Enabled = true;
        btnDeleteCurrentMovies.Visible = true;
        txtSumFilePath.Enabled = true;
        btnUpload2.Enabled = true;
        btnDeleteSummaryMovie.Enabled = true;
        btnSubmit.Enabled = true;
        btnDeleteSession.Enabled = true;


        int LessonSelected;
        var path = HttpContext.Current.Server.MapPath("~/Archive/manifest");
        DirectoryInfo d = new DirectoryInfo(path);
        FileInfo[] Files = d.GetFiles("*.xml");
        List<string> filesList = new List<string>();
        if (DropDownList2.SelectedValue != "" && DropDownList2.SelectedValue != "Select Analysis Date and Location" && DropDownList2.SelectedValue != "0")
        {
            DropdownListXmlFle.Items.Clear();
            try
            {
                LessonSelected = Convert.ToInt16(DropDownList2.SelectedValue);
                int AthleteSelected;
                AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);


                Customer custmer = Hurdlecustomer = DataRepository.CustomerProvider.GetByCustomerId(AthleteSelected);
                Lesson lesson = DataRepository.LessonProvider.GetByLessonId(LessonSelected);
                int lessonid = lesson.LessonId;
                //    summaryMovie = DataRepository.SummaryMovieProvider.GetByLessonId(lessonid)[0];
                try
                {
                    var data = DataRepository.MovieProvider.GetByLessonId(lessonid);
                    if (data.Count > 0)
                    {
                        movieSide = data[0];
                    }
                }
                catch (Exception ex)
                {
                    var error = ex.Message;
                }
                DataSet dsmodelData = new DataSet();
                bool modeldataexist = false;
                bool summarySessionModelDataExist = false;
                dsmodelData = sae.GetAllHurdleStepsAthletesData(lessonid);

                string groundtimeM = string.Empty;
                var tablegroundtimeM = dsmodelData.Tables[1];
                string groundtimeI = string.Empty;
                var tablegroundtimeI = dsmodelData.Tables[0];
                string groundtimeC = string.Empty;
                var tablegroundtimeC = dsmodelData.Tables[2];
                Dictionary<string, string> vals = new Dictionary<string, string>();
                Dictionary<string, string> valsModel = new Dictionary<string, string>();
                Dictionary<string, string> valsCurnt = new Dictionary<string, string>();
                List<string> Curantlist = new List<string>();
                List<string> Modellist = new List<string>();
                List<string> Initiallist = new List<string>();
                //if (tablegroundtimeM.Rows.Count > 0 )
                //{
                //    groundtimeM = dsmodelData.Tables[1].Rows[0]["Step1GroundTime"].ToString();
                //}
                //if (tablegroundtimeI.Rows.Count > 0)
                //{
                //    groundtimeI = dsmodelData.Tables[0].Rows[0]["Step1GroundTime"].ToString();
                //}
                //if (tablegroundtimeC.Rows.Count > 0)
                //{
                //    groundtimeC = dsmodelData.Tables[2].Rows[0]["Step1GroundTime"].ToString();
                //}
                if (tablegroundtimeI.Rows.Count > 0)
                {
                    foreach (DataRow dr in tablegroundtimeI.Rows)
                    {
                        for (int i = 0; i < tablegroundtimeI.Columns.Count; i++)
                        {
                            vals.Add(tablegroundtimeI.Columns[i].ColumnName, dr[tablegroundtimeI.Columns[i].ColumnName].ToString());
                        }
                    }
                }

                foreach (var item in vals.Values)
                {
                    if (item != "0" && item != "0.000" && item != "")
                    {
                        Initiallist.Add(item);
                    }
                }
                if (tablegroundtimeM.Rows.Count > 0)
                {
                    foreach (DataRow dr in tablegroundtimeM.Rows)
                    {
                        for (int i = 0; i < tablegroundtimeM.Columns.Count; i++)
                        {
                            valsModel.Add(tablegroundtimeM.Columns[i].ColumnName, dr[tablegroundtimeM.Columns[i].ColumnName].ToString());
                        }
                    }

                    foreach (var item in valsModel.Values)
                    {
                        if (item != "0" && item != "0.000" && item != "")
                        {
                            Modellist.Add(item);
                        }
                    }
                }
                if (tablegroundtimeC.Rows.Count > 0)
                {
                    foreach (DataRow dr in tablegroundtimeC.Rows)
                    {
                        for (int i = 0; i < tablegroundtimeC.Columns.Count; i++)
                        {
                            valsCurnt.Add(tablegroundtimeC.Columns[i].ColumnName, dr[tablegroundtimeC.Columns[i].ColumnName].ToString());
                        }
                    }

                    foreach (var item in valsCurnt.Values)
                    {
                        if (item != "0" && item != "0.000" && item != "")
                        {
                            Curantlist.Add(item);
                        }
                    }
                }
                string location1 = sae.SelectLessonlocation(lesson.LessonId.ToString());
                if (location1 == "On-Track Sesssion Summary")
                {
                    OntrackSessionSelect();
                    GetAllHurdleStepsAthleteData(lessonid);
                    
                }
                //else if ((groundtimeM != "0.000") && (groundtimeM != ""))
                //{
                //    GetAllHurdleStepsAthleteData(lessonid);
                //}
                //else if ((groundtimeI != "0.000" || groundtimeC != "0.000") && groundtimeM != "0.000")
                //{
                //    GetAllHurdleStepsAthleteData(lessonid);
                //}
                //else if (groundtimeM != "0.000")
                //{
                //    GetAllHurdleStepsAthleteData(lessonid);
                //}
                else if (Modellist.Count > 0)
                {
                    GetAllHurdleStepsAthleteData(lessonid);
                }
                else if ((Initiallist.Count > 0 || Curantlist.Count > 0) && Modellist.Count > 0)
                {
                    GetAllHurdleStepsAthleteData(lessonid);
                }
                else if (Curantlist.Count > 0)
                {
                    GetAllHurdleStepsAthleteData(lessonid);
                }
                else
                {

                    // BindModelDataOnly(dsmodelData);
                    GetAllHurdleStepsAthleteDataInitialNdCorrent(lessonid);
                    #region[getting summary model data]
                    TList<Lesson> lessons = DataRepository.LessonProvider.GetByCustomerId(AthleteSelected);
                    foreach (Lesson l in lessons)
                    {
                        string date = l.LessonDate.ToString();
                        if (date == "1/1/2020 12:00:00 AM")
                        {
                            summarysessionlessionid = l.LessonId;
                            break;
                        }
                    }
                    if (summarysessionlessionid > 0)
                    {
                        dsmodelData = null;
                        dsmodelData = sae.GetAllHurdleStepsAthletesData(summarysessionlessionid);
                        if (!string.IsNullOrEmpty(groundtimeM))
                        {
                            if ((groundtimeM != "0.000") && (groundtimeM != ""))
                            {
                                BindModelDataOnly(dsmodelData);
                                ReadOntrackSessionSelect();
                            }
                        }
                    }

                    #endregion[getting summary model data]
                }

                #region[Binding First Browse Path]
                //string[] browsepath = new string[2];
                string browsepath = string.Empty;

                //int counter = 0;

                TList<Movie> movies = DataRepository.MovieProvider.GetByLessonId(lessonid);
                for (int i = 0; i < movies.Count; i++)
                {
                    if (movies[i].MovieType == 0)
                    {

                        string _filePath = movies[i].FilePath.ToString();
                        string[] Sidepatha = _filePath.Split('/');
                        browsepath = Sidepatha[2].ToString();
                        string TextToRemove = "-Side.mp4";
                        if (Sidepatha[2].Contains("-Side.mp4"))
                        {
                            browsepath = Sidepatha[2].Substring(0, Sidepatha[2].Length - TextToRemove.Length);
                            btnDeleteInitialMovies.Visible = true;
                            var filename = Sidepatha[2].Split('-');
                            var filename1 = filename[0] + "-" + filename[1];
                            var file = Files.Where(f => f.Name.Contains(filename1.Trim())).Select(s => s.Name).ToArray();
                        }

                        TList<MovieClip> InitialClips = new TList<MovieClip>();
                        DataTable dtathlets = GetMovieClips(movies[i].MovieId);
                        if (dtathlets != null)
                        {
                            if (dtathlets.Rows.Count > 0)
                            {
                                txtBFrame1.Text = dtathlets.Rows[0]["endframe"].ToString();
                                txtBFrame2.Text = dtathlets.Rows[1]["endframe"].ToString();
                                txtBFrame3.Text = dtathlets.Rows[2]["endframe"].ToString();
                                txtBFrame4.Text = dtathlets.Rows[3]["endframe"].ToString();
                                txtBFrame5.Text = dtathlets.Rows[4]["endframe"].ToString();
                                txtBFrame6.Text = dtathlets.Rows[5]["endframe"].ToString();
                                txtBFrame7.Text = dtathlets.Rows[6]["endframe"].ToString();
                                txtBFrame8.Text = dtathlets.Rows[7]["endframe"].ToString();
                            }
                        }
                    }
                }

                txtbFilePath.Text = browsepath.ToString();
                if (txtbFilePath.Text == "")
                {
                    btnDeleteInitialMovies.Visible = false;
                }
                else
                {
                    btnDeleteInitialMovies.Visible = true;
                }
                #endregion[Binding first Browse Path]

                #region[Binding Second(current) Browse Path]
                string browsepath1 = string.Empty;

                //int counter1 = 0;
                TList<Movie> movies1 = DataRepository.MovieProvider.GetByLessonId(lessonid);
                for (int i = 0; i < movies1.Count; i++)
                {
                    if (movies1[i].MovieType == 2)
                    {
                        string _filePath = movies1[i].FilePath.ToString();
                        string[] Sidepatha = _filePath.Split('/');
                        browsepath1 = Sidepatha[2].ToString();
                        string TextToRemove = "-Side.mp4";
                        if (Sidepatha[2].Contains("-Side.mp4"))
                        {
                            browsepath1 = Sidepatha[2].Substring(0, Sidepatha[2].Length - TextToRemove.Length);
                            btnDeleteCurrentMovies.Visible = true;
                            var filename = Sidepatha[2].Split('-');
                            var filename1 = filename[0] + "-" + filename[1];
                            var file = Files.Where(f => f.Name.Contains(filename1.Trim())).Select(s => s.Name).ToArray();
                        }
                        TList<MovieClip> CurrentClips = new TList<MovieClip>();
                        DataTable dtathlets = GetMovieClips(movies[i].MovieId);
                        // CurrentClips = DataRepository.MovieClipProvider.GetByMovieId(movies1[i].MovieId);
                        if (dtathlets != null)
                        {
                            if (dtathlets.Rows.Count > 0)
                            {
                                txtCBFrame1.Text = dtathlets.Rows[0]["endframe"].ToString();
                                txtCBFrame2.Text = dtathlets.Rows[1]["endframe"].ToString();
                                txtCBFrame3.Text = dtathlets.Rows[2]["endframe"].ToString();
                                txtCBFrame4.Text = dtathlets.Rows[3]["endframe"].ToString();
                                txtCBFrame5.Text = dtathlets.Rows[4]["endframe"].ToString();
                                txtCBFrame6.Text = dtathlets.Rows[5]["endframe"].ToString();
                                txtCBFrame7.Text = dtathlets.Rows[6]["endframe"].ToString();
                                txtCBFrame8.Text = dtathlets.Rows[7]["endframe"].ToString();
                            }
                        }
                    }
                }
                txtForCurrentVideo.Text = browsepath1.ToString();
                if (txtForCurrentVideo.Text == "")
                {
                    btnDeleteCurrentMovies.Visible = false;
                }
                else
                {
                    btnDeleteCurrentMovies.Visible = true;
                }
                #endregion[Binding Second(current) Browse Path]

                #region[Binding second Browse Path]
                TList<SummaryMovie> Sumovies = DataRepository.SummaryMovieProvider.GetByLessonId(lessonid);
                if (Sumovies.Count > 0)
                {
                    string _filePath = Sumovies[0].FilePath.ToString();
                    string[] Sidepatha = _filePath.Split('/');
                    txtSumFilePath.Text = Sidepatha[2].ToString();
                    btnDeleteSummaryMovie.Visible = true;
                }
                else
                {
                    txtSumFilePath.Text = "";
                }
                if (txtSumFilePath.Text == "")
                {
                    btnDeleteSummaryMovie.Visible = false;
                }
                else
                {
                    btnDeleteSummaryMovie.Visible = true;
                }
                #endregion[Binding second Browse Path]


                var AthliteName = DropDownList1.SelectedItem.Text;
                var lessionName = DropDownList2.SelectedItem.Text;
                var filename2 = custmer.LastName.ToLower();
                var filename3 = custmer.FirstName.ToLower();
                if (location1 != "On-Track Sesssion Summary")
                {
                    foreach (var Filename in Files)
                    {
                        if (Filename.Name.ToLower().Contains(filename2) && Filename.Name.ToLower().Contains(filename3))
                        {
                            DropdownListXmlFle.Items.Add(Filename.Name);
                            ReadOntrackSessionSelect();
                        }
                    }
                    //DropdownListXmlFle.DataBind();
                }
            }
            catch (Exception ex)
            {
                GetAllHurdleStepsAthleteData(lessonid);
                txtbFilePath.Text = "";
                txtSumFilePath.Text = "";
                btnUpload2.Visible = true;
                txtSumFilePath.Visible = true;
                ClearData();
                Gridview1.Visible = false;
                txtbFilePath.Text = "";
                //  txtbFilePath1.Text = "";
                txtbFilePath.Visible = true;
                // txtbFilePath1.Visible = true;
                btnUpload.Visible = true;
                lblDate.Visible = false;
                lblDateEx.Visible = false;
                lblLocation.Visible = false;
                txtDate.Visible = false;
                txtLocation.Visible = false;
                lblexlocation.Visible = false;
                txtTime.Visible = false;
                lblTime.Visible = false;
                lblExTime.Visible = false;
            }
        }
        else
        {
            txtndbtnVisibleOFF();
        }
    }

    private decimal convertDecimal(string value)
    {
        decimal convertedVal = 0;
        if (!string.IsNullOrEmpty(value))
        {
            convertedVal = Math.Round(Convert.ToDecimal(value), 3);
        }

        return convertedVal;
    }
    private int convertInt(string value)
    {
        int convertedVal = 0;
        if (!string.IsNullOrEmpty(value))
        {
            convertedVal = Convert.ToInt32(value);
        }

        return convertedVal;
    }
    private decimal ConvertToInt(string value)
    {
        decimal convertedVal = 0;
        int convertedValInInt = 0;
        if (!string.IsNullOrEmpty(value))
        {
            convertedVal = Math.Round(Convert.ToDecimal(value), 3);
            convertedValInInt = Convert.ToInt32(convertedVal);
        }

        return convertedValInInt;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {


        Label117.Text = ""; //test
        Label1.Text = "";
        movieSide = new Movie();
        summaryMovie = new SummaryMovie();
        Movie movieBack = new Movie();

        if (!DropDownList1.SelectedValue.Equals("noathlete"))
        {
            Lesson lesson = new Lesson();
            int LessonSelected = 0;
            //the following status of is  newlession varible is changed depending upon the visibility of 
            //date text box because the text box is visible only when the create the new lesson 
            bool isNewLesson = txtDate.Visible;
            try
            {
                if (DropDownList2.SelectedValue != "")
                {
                    LessonSelected = Convert.ToInt32(DropDownList2.SelectedValue);
                    isNewLesson = false;
                }
                else
                {
                    if (DropDownList2.Items.Count > 0)
                    {
                        if (!isNewLesson)
                        {
                            MessageBox.Show("please create new lesson");
                            return;
                        }
                    }
                    else
                    {
                        if (!isNewLesson)
                        {
                            MessageBox.Show("please create new lesson");
                            return;
                        }
                    }
                }
                if (LessonSelected > 0 & !isNewLesson)
                {
                    lesson = DataRepository.LessonProvider.GetByLessonId(LessonSelected);

                    //IList movieList = DataRepository.MovieProvider.GetByLessonId(LessonSelected);
                    //if (movieList.Count > 0)
                    //{
                    //    movieSide = (Movie)movieList[0];
                    //    movieBack = (Movie)movieList[1];
                    //}
                    ////else if (movieList.Count == 1)
                    ////{
                    ////    movieSide = (Movie)movieList[0];
                    ////}
                    //else
                    //{
                    //    movieSide = new Movie();
                    //    movieBack = new Movie();
                    //}
                    IList SuummarymovieList = DataRepository.SummaryMovieProvider.GetByLessonId(LessonSelected);
                    if (SuummarymovieList.Count > 0)
                    {
                        summaryMovie = (SummaryMovie)SuummarymovieList[0];
                    }
                    else
                    {
                        summaryMovie = new SummaryMovie();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            #region[Insert or Update Lession data ]
            try
            {
                lesson.CustomerId = Convert.ToInt32(DropDownList1.SelectedValue);
                lesson.LessonTypeId = 6;//chk
                if (DropDownList2.SelectedValue != "")
                {
                    if (DropDownList2.Items[0].Selected == true)
                    {
                        try
                        {
                            string time = txtTime.Text;
                            lesson.LessonDate = Convert.ToDateTime(txtDate.Text + " " + time);
                            location = txtLocation.Text;
                            lessonid = Convert.ToInt32(DropDownList2.SelectedValue);
                        }
                        catch
                        {
                            Label1.Text = "Please enter valid [MM-dd-yyyy]";
                            return;
                        }
                    }
                }
                if (isNewLesson)
                {
                    try
                    {
                        location = txtLocation.Text;
                        string time = txtTime.Text;
                        string datetime = txtDate.Text + " " + time;

                        DateTime myDate = DateTime.ParseExact(datetime, "MM/dd/yyyy HH:mm:ss",
                                                              System.Globalization.CultureInfo.InvariantCulture);

                        lesson.LessonDate = myDate;
                        //lesson.LessonDate = Convert.ToDateTime(txtDate.Text + " " + time);

                    }
                    catch
                    {
                        Label1.Text = "Please enter valid [MM-dd-yyyy]";
                        return;
                    }
                    int AthleteSelectedId;
                    bool customerprofileisexist = false;
                    AthleteSelectedId = Convert.ToInt16(DropDownList1.SelectedValue);
                    Customer custmer = DataRepository.CustomerProvider.GetByCustomerId(AthleteSelectedId);
                    try
                    {
                        customerprofile1 = DataRepository.CustomerProfileProvider.GetByCustomerId(custmer.CustomerId)[0];
                        customerprofileisexist = true;
                    }
                    catch
                    {
                        customerprofile1 = new CustomerProfile();
                    }
                    DataSet dstecher = sae.GetPrimaryCoach(custmer.CustomerId);
                    if (dstecher != null)
                    {
                        if (dstecher.Tables[0].Rows.Count > 0)
                        {
                            lesson.TeacherId = Convert.ToInt32(dstecher.Tables[0].Rows[0]["TeacherId"].ToString());
                        }
                        else
                        {
                            lesson.TeacherId = 7;
                        }
                    }
                    else
                    {
                        lesson.TeacherId = 7;
                    }
                    if (customerprofileisexist)
                    {
                        lesson.SiteId = customerprofile1.CustomerSite;
                    }
                    else
                    {
                        lesson.SiteId = 11;
                    }
                    lesson.CustomerId = custmer.CustomerId;
                    lesson.LessonTypeId = 6;//chk
                    lesson.MachineNumber = 1;
                    DataRepository.LessonProvider.Insert(lesson);//test
                    sae.UpdateLessonLocation(location, lesson.LessonId);
                }
                else
                {
                    DataRepository.LessonProvider.Update(lesson);
                    sae.UpdateLessonLocation(location, lessonid);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            #endregion[Insert or Update Lession data ]//test
            #region[Insert or Update HurdleSteps Inital Data ]
            try
            {
                _SprintData.LessonId = lesson.LessonId;

                _SprintData.SetDistanceBetweenHurdleSteps = convertDecimal(TxtHurdleDistanceBtweenI.Text);
                _SprintData.SetDistanceIntoHurdleSteps = convertDecimal(TxtHurdleDistanceIntoI.Text);
                _SprintData.SetDistanceOffHurdleSteps = convertDecimal(TxtHurdleDistanceOffI.Text);

                _SprintData.Step1GroundTime = convertDecimal(TxtStep1GroundTimeI.Text);
                _SprintData.Step1AirTime = convertDecimal(TxtStep1AirTimeI.Text);
                _SprintData.Step1StrideLength = convertDecimal(TxtStep1StrideLengthI.Text);
                _SprintData.Step1TouchdownDistance = convertDecimal(TxtStep1TouchDistanceI.Text);
                _SprintData.Step1KneeSeperationatTouchdown = convertDecimal(TxtStep1KSTouchDistanceI.Text);
                _SprintData.Step1TrunkTakeoffAngle = convertInt(TxtStep1TrunkTakeoffAngleI.Text);

                _SprintData.Step1TrunkTouchdownAngle = convertInt(TxtStep1TrunkTouchdownAngleI.Text);

                _SprintData.Step1ULAtFullExtension = convertInt(TxtStep1ULFullExtensionI.Text);
                _SprintData.Step1LLAtTakeoff = convertInt(TxtStep1LLTakeOffI.Text);
                _SprintData.Step1ULAtFullFlexion = convertInt(TxtStep1ULFullFlexionI.Text);
                _SprintData.Step2GroundTime = convertDecimal(TxtStep2GroundTimeI.Text);

                _SprintData.Step2AirTime = convertDecimal(TxtStep2AirTimeI.Text);
                _SprintData.Step2StrideLength = convertDecimal(TxtStep2StrideLengthI.Text);
                _SprintData.Step2TouchdownDistance = convertDecimal(TxtStep2TouchDistanceI.Text);
                _SprintData.Step2KneeSeperationatTouchdown = convertDecimal(TxtStep2KSTouchDistanceI.Text);
                _SprintData.Step2TrunkTouchdownAngle = convertInt(TxtStep2TrunkTouchdownAngleI.Text);
                _SprintData.Step2TrunkTakeoffAngle = convertInt(TxtStep2TrunkTakeoffAngleI.Text);
                _SprintData.Step2ULAtFullExtension = convertInt(TxtStep2ULFullExtensionI.Text);
                _SprintData.Step2LLAtTakeoff = convertInt(TxtStep2LLTakeOffI.Text);
                _SprintData.Step2LLAtFullFlexion = convertInt(TxtStep2LLFullFlexionI.Text);
                _SprintData.Step2ULAtFullFlexion = convertInt(TxtStep2ULFullFlexionI.Text);
                _SprintData.Step3GroundTime = convertDecimal(TxtStep3GroundTimeI.Text);
                _SprintData.Step3AirTime = convertDecimal(TxtStep3AirTimeI.Text);
                _SprintData.Step3StrideLength = convertDecimal(TxtStep3StrideLengthI.Text);
                _SprintData.Step3TouchdownDistance = convertDecimal(TxtStep3TouchDistanceI.Text);
                _SprintData.Step3KneeSeperationatTouchdown = convertDecimal(TxtStep3KSTouchDistanceI.Text);
                _SprintData.Step3TrunkTouchdownAngle = convertInt(TxtStep3TrunkTouchdownAngleI.Text);
                _SprintData.Step3TrunkTakeoffAngle = convertInt(TxtStep3TrunkTakeoffAngleI.Text);
                _SprintData.Step3ULAtFullExtension = convertInt(TxtStep3ULFullExtensionI.Text);
                _SprintData.Step3LLAtTakeoff = convertInt(TxtStep3LLTakeOffI.Text);
                _SprintData.Step3LLAtFullFlexion = convertInt(TxtStep3LLFullFlexionI.Text);
                _SprintData.Step3ULAtFullFlexion = convertInt(TxtStep3ULFullFlexionI.Text);
                _SprintData.SetTouchdownDistanceIntoTheHurdle = convertDecimal(TxtIntoHurdleTouchDistanceI.Text);
                _SprintData.SetKneeSeperationatTouchdownIntoTheHurdle = convertDecimal(TxtIntoHurdleKSTouchDistanceI.Text);
                _SprintData.SetTrunkTouchdownAngleIntoTheHurdle = convertInt(TxtIntoHurdleTrunkTouchdownAngleI.Text);
                _SprintData.SetLLAtTouchdownIntoTheHurdle = convertInt(TxtIntoHurdleLLTouchDistanceI.Text);


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            // _SprintData.LessonId = Convert.ToInt32(DropDownList2.SelectedValue); //test
            string Sprint_InitialDataId = sae.SelectHurdleStepsInitialDataid(_SprintData.LessonId.ToString());

            if (Sprint_InitialDataId == "")//test 
            {
                _SprintData.InsertIntoHurdleStepsInitialData();
            }
            else
            {
                _SprintData.UpdateHurdleStepsInitialData();
            }
            #endregion[Insert or Update HurdleSteps  Inital Data ]
            #region[Insert Or Update HurdleSteps Current Data]
            try
            {
                _SprintData.LessonId = lesson.LessonId;
                _SprintData.SetDistanceBetweenHurdleSteps = convertDecimal(TxtHurdleDistanceBtweenF.Text);
                _SprintData.SetDistanceIntoHurdleSteps = convertDecimal(TxtHurdleDistanceIntoF.Text);
                _SprintData.SetDistanceOffHurdleSteps = convertDecimal(TxtHurdleDistanceOffF.Text);
                _SprintData.Step1GroundTime = convertDecimal(TxtStep1GroundTimeF.Text);
                _SprintData.Step1AirTime = convertDecimal(TxtStep1AirTimeF.Text);
                _SprintData.Step1StrideLength = convertDecimal(TxtStep1StrideLengthF.Text);
                _SprintData.Step1TouchdownDistance = convertDecimal(TxtStep1TouchDistanceF.Text);
                _SprintData.Step1KneeSeperationatTouchdown = convertDecimal(TxtStep1KSTouchDistanceF.Text);
                _SprintData.Step1TrunkTouchdownAngle = convertInt(TxtStep1TrunkTouchdownAngleF.Text);
                _SprintData.Step1TrunkTakeoffAngle = convertInt(TxtStep1TrunkTakeoffAngleF.Text);
                _SprintData.Step1ULAtFullExtension = convertInt(TxtStep1ULFullExtensionF.Text);
                _SprintData.Step1LLAtTakeoff = convertInt(TxtStep1LLTakeOffF.Text);
                _SprintData.Step1ULAtFullFlexion = convertInt(TxtStep1ULFullFlexionF.Text);
                _SprintData.Step2GroundTime = convertDecimal(TxtStep2GroundTimeF.Text);
                _SprintData.Step2AirTime = convertDecimal(TxtStep2AirTimeF.Text);
                _SprintData.Step2StrideLength = convertDecimal(TxtStep2StrideLengthF.Text);
                _SprintData.Step2TouchdownDistance = convertDecimal(TxtStep2TouchDistanceF.Text);
                _SprintData.Step2KneeSeperationatTouchdown = convertDecimal(TxtStep2KSTouchDistanceF.Text);
                _SprintData.Step2TrunkTouchdownAngle = convertInt(TxtStep2TrunkTouchdownAngleF.Text);
                _SprintData.Step2TrunkTakeoffAngle = convertInt(TxtStep2TrunkTakeoffAngleF.Text);
                _SprintData.Step2ULAtFullExtension = convertInt(TxtStep2ULFullExtensionF.Text);
                _SprintData.Step2LLAtTakeoff = convertInt(TxtStep2LLTakeOffF.Text);
                _SprintData.Step2LLAtFullFlexion = convertInt(TxtStep2LLFullFlexionF.Text);
                _SprintData.Step2ULAtFullFlexion = convertInt(TxtStep2ULFullFlexionF.Text);
                _SprintData.Step3GroundTime = convertDecimal(TxtStep3GroundTimeF.Text);
                _SprintData.Step3AirTime = convertDecimal(TxtStep3AirTimeF.Text);
                _SprintData.Step3StrideLength = convertDecimal(TxtStep3StrideLengthF.Text);
                _SprintData.Step3TouchdownDistance = convertDecimal(TxtStep3TouchDistanceF.Text);
                _SprintData.Step3KneeSeperationatTouchdown = convertDecimal(TxtStep3KSTouchDistanceF.Text);
                _SprintData.Step3TrunkTouchdownAngle = convertInt(TxtStep3TrunkTouchdownAngleF.Text);
                _SprintData.Step3TrunkTakeoffAngle = convertInt(TxtStep3TrunkTakeoffAngleF.Text);
                _SprintData.Step3ULAtFullExtension = convertInt(TxtStep3ULFullExtensionF.Text);
                _SprintData.Step3LLAtTakeoff = convertInt(TxtStep3LLTakeOffF.Text);
                _SprintData.Step3LLAtFullFlexion = convertInt(TxtStep3LLFullFlexionF.Text);
                _SprintData.Step3ULAtFullFlexion = convertInt(TxtStep3ULFullFlexionF.Text);
                _SprintData.SetTouchdownDistanceIntoTheHurdle = convertDecimal(TxtIntoHurdleTouchDistanceF.Text);
                _SprintData.SetKneeSeperationatTouchdownIntoTheHurdle = convertDecimal(TxtIntoHurdleKSTouchDistanceF.Text);
                _SprintData.SetTrunkTouchdownAngleIntoTheHurdle = convertInt(TxtIntoHurdleTrunkTouchdownAngleF.Text);
                _SprintData.SetLLAtTouchdownIntoTheHurdle = convertInt(TxtIntoHurdleLLTouchDistanceF.Text);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            //_SprintData.LessonId = Convert.ToInt32(DropDownList2.SelectedValue);
            string Sprint_CurrentDataId = sae.SelectHurdleStepsCurrentDataid(_SprintData.LessonId.ToString());
            if (Sprint_CurrentDataId == "")//test
            {
                _SprintData.InsertIntoHurdleStepsCurrentData();
            }
            else
            {
                _SprintData.UpdateHurdleStepsCurrentData();
            }
            #endregion[Insert Or Update HurdleSteps Current Data]
            #region[Insertupdate to HurdleSteps ModelData]
            try
            {
                _SprintData.LessonId = lesson.LessonId;
                _SprintData.SetDistanceBetweenHurdleSteps = convertDecimal(TxtHurdleDistanceBtweenM1.Text);
                _SprintData.SetDistanceIntoHurdleSteps = convertDecimal(TxtHurdleDistanceIntoM1.Text);
                _SprintData.SetDistanceOffHurdleSteps = convertDecimal(TxtHurdleDistanceOffM1.Text);
                _SprintData.Step1GroundTime = convertDecimal(TxtStep1GroundTimeM1.Text);
                _SprintData.Step1AirTime = convertDecimal(TxtStep1AirTimeM1.Text);
                _SprintData.Step1StrideLength = convertDecimal(TxtStep1StrideLengthM1.Text);
                _SprintData.Step1TouchdownDistance = convertDecimal(TxtStep1TouchDistanceM1.Text);
                _SprintData.Step1KneeSeperationatTouchdown = convertDecimal(TxtStep1KSTouchDistanceM1.Text);
                _SprintData.Step1TrunkTouchdownAngle = convertInt(TxtStep1TrunkTouchdownAngleM1.Text);
                _SprintData.Step1TrunkTakeoffAngle = convertInt(TxtStep1TrunkTakeoffAngleM1.Text);
                _SprintData.Step1ULAtFullExtension = convertInt(TxtStep1ULFullExtensionM1.Text);
                _SprintData.Step1LLAtTakeoff = convertInt(TxtStep1LLTakeOffM1.Text);
                _SprintData.Step1ULAtFullFlexion = convertInt(TxtStep1ULFullFlexionM1.Text);
                _SprintData.Step2GroundTime = convertDecimal(TxtStep2GroundTimeM1.Text);
                _SprintData.Step2AirTime = convertDecimal(TxtStep2AirTimeM1.Text);
                _SprintData.Step2StrideLength = convertDecimal(TxtStep2StrideLengthM1.Text);
                _SprintData.Step2TouchdownDistance = convertDecimal(TxtStep2TouchDistanceM1.Text);
                _SprintData.Step2KneeSeperationatTouchdown = convertDecimal(TxtStep2KSTouchDistanceM1.Text);
                _SprintData.Step2TrunkTouchdownAngle = convertInt(TxtStep2TrunkTouchdownAngleM1.Text);
                _SprintData.Step2TrunkTakeoffAngle = convertInt(TxtStep2TrunkTakeoffAngleM1.Text);
                _SprintData.Step2ULAtFullExtension = convertInt(TxtStep2ULFullExtensionM1.Text);
                _SprintData.Step2LLAtTakeoff = convertInt(TxtStep2LLTakeOffM1.Text);
                _SprintData.Step2LLAtFullFlexion = convertInt(TxtStep2LLFullFlexionM1.Text);
                _SprintData.Step2ULAtFullFlexion = convertInt(TxtStep2ULFullFlexionM1.Text);
                _SprintData.Step3GroundTime = convertDecimal(TxtStep3GroundTimeM1.Text);
                _SprintData.Step3AirTime = convertDecimal(TxtStep3AirTimeM1.Text);
                _SprintData.Step3StrideLength = convertDecimal(TxtStep3StrideLengthM1.Text);
                _SprintData.Step3TouchdownDistance = convertDecimal(TxtStep3TouchDistanceM1.Text);
                _SprintData.Step3KneeSeperationatTouchdown = convertDecimal(TxtStep3KSTouchDistanceM1.Text);
                _SprintData.Step3TrunkTouchdownAngle = convertInt(TxtStep3TrunkTouchdownAngleM1.Text);
                _SprintData.Step3TrunkTakeoffAngle = convertInt(TxtStep3TrunkTakeoffAngleM1.Text);
                _SprintData.Step3ULAtFullExtension = convertInt(TxtStep3ULFullExtensionM1.Text);
                _SprintData.Step3LLAtTakeoff = convertInt(TxtStep3LLTakeOffM1.Text);
                _SprintData.Step3LLAtFullFlexion = convertInt(TxtStep3LLFullFlexionM1.Text);
                _SprintData.Step3ULAtFullFlexion = convertInt(TxtStep3ULFullFlexionM1.Text);
                _SprintData.SetTouchdownDistanceIntoTheHurdle = convertDecimal(TxtIntoHurdleTouchDistanceM1.Text);
                _SprintData.SetKneeSeperationatTouchdownIntoTheHurdle = convertDecimal(TxtIntoHurdleKSTouchDistanceM1.Text);
                _SprintData.SetTrunkTouchdownAngleIntoTheHurdle = convertInt(TxtIntoHurdleTrunkTouchdownAngleM1.Text);
                _SprintData.SetLLAtTouchdownIntoTheHurdle = convertInt(TxtIntoHurdleLLTouchDistanceM1.Text);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            //_SprintData.LessonId = Convert.ToInt32(DropDownList2.SelectedValue);
            string Sprint_ModelDataId = sae.SelectHurdleStepsModelDataid(_SprintData.LessonId.ToString());
            if (Sprint_ModelDataId == "")//test
            {
                _SprintData.InsertIntoHurdleStepsModelData();
            }
            else
            {
                _SprintData.UpdateHurdleStepsModelData();
            }
            #endregion[Insertupdate to HurdleSteps ModelData]

            #region[save Initial movies]//test
            try
            {
                if (txtbFilePath.Text != string.Empty && txtbFilePath.Text.Trim() != string.Empty)
                {
                    //IList movieList = DataRepository.MovieProvider.GetByLessonId(LessonSelected);
                    movieSide = new Movie();
                    movieBack = new Movie();
                    IList<Movie> movieList = GetMovieListByLessionId_LessionType(LessonSelected, 0, 1);
                    if (movieList != null)
                    {
                        if (movieList.Count > 0)
                        {
                            movieSide = movieList[0];
                            movieBack = movieList[1];
                        }
                    }
                    if (movieSide.MovieId <= 0)
                    {
                        movieSide.LessonId = lesson.LessonId;
                        movieSide.DateRecorded = lesson.LessonDate;
                        movieSide.MovieType = 0;
                        movieSide.FilePath = "Users/MovieFiles/" + Convert.ToString(txtbFilePath.Text) + "-Side.mp4";
                        DataRepository.MovieProvider.Insert(movieSide);
                    }
                    else
                    {
                        if (movieSide.MovieType == 0)
                            movieSide.FilePath = "Users/MovieFiles/" + Convert.ToString(txtbFilePath.Text) + "-Side.mp4";
                        DataRepository.MovieProvider.Update(movieSide);
                    }
                    if (movieBack.MovieId <= 0)
                    {
                        //Back View
                        movieBack.LessonId = lesson.LessonId;
                        movieBack.DateRecorded = lesson.LessonDate;
                        movieBack.MovieType = 1;
                        movieBack.FilePath = "Users/MovieFiles/" + Convert.ToString(txtbFilePath.Text) + "-Back.mp4";
                        DataRepository.MovieProvider.Insert(movieBack);
                    }
                    else
                    {
                        if (movieBack.MovieType == 1)
                            movieBack.FilePath = "Users/MovieFiles/" + Convert.ToString(txtbFilePath.Text) + "-Back.mp4";
                        DataRepository.MovieProvider.Update(movieBack);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            #endregion[save Initial movies]


            #region[insert Initial side Frames]
            if (txtbFilePath.Text != string.Empty && txtbFilePath.Text.Trim() != string.Empty)
            {

                MovieClip InitialSideClips = new MovieClip();
                int IniitalSideMovieid = movieSide.MovieId;
                try
                {
                    InitialSideClips = DataRepository.MovieClipProvider.GetByMovieId(IniitalSideMovieid)[0];
                    if (InitialSideClips != null)
                    {
                        isMovieClipsExist = true;
                    }
                    else
                    {
                        isMovieClipsExist = false;
                    }
                }
                catch
                {
                    isMovieClipsExist = false;
                }
                InitialSideClips.MovieId = IniitalSideMovieid;
                if (txtBFrame1.Text != "")
                {
                    InitialSideClips.BeginFrame = Convert.ToInt16(txtBFrame1.Text);
                    InitialSideClips.EndFrame = Convert.ToInt16(txtBFrame1.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(InitialSideClips);
                    else
                        DataRepository.MovieClipProvider.Update(InitialSideClips);
                }
                InitialSideClips.MovieClipId++;
                if (txtBFrame2.Text != "")
                {
                    InitialSideClips.MovieId = IniitalSideMovieid;
                    InitialSideClips.BeginFrame = Convert.ToInt16(txtBFrame1.Text);
                    InitialSideClips.EndFrame = Convert.ToInt16(txtBFrame2.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(InitialSideClips);
                    else
                        DataRepository.MovieClipProvider.Update(InitialSideClips);
                }
                InitialSideClips.MovieClipId++;
                if (txtBFrame3.Text != "")
                {
                    InitialSideClips.MovieId = IniitalSideMovieid;
                    InitialSideClips.BeginFrame = Convert.ToInt16(txtBFrame2.Text);
                    InitialSideClips.EndFrame = Convert.ToInt16(txtBFrame3.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(InitialSideClips);
                    else
                        DataRepository.MovieClipProvider.Update(InitialSideClips);
                }
                InitialSideClips.MovieClipId++;
                if (txtBFrame4.Text != "")
                {
                    InitialSideClips.MovieId = IniitalSideMovieid;
                    InitialSideClips.BeginFrame = Convert.ToInt16(txtBFrame3.Text);
                    InitialSideClips.EndFrame = Convert.ToInt16(txtBFrame4.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(InitialSideClips);
                    else
                        DataRepository.MovieClipProvider.Update(InitialSideClips);
                }
                InitialSideClips.MovieClipId++;
                if (txtBFrame5.Text != "")
                {
                    InitialSideClips.MovieId = IniitalSideMovieid;
                    InitialSideClips.BeginFrame = Convert.ToInt16(txtBFrame4.Text);
                    InitialSideClips.EndFrame = Convert.ToInt16(txtBFrame5.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(InitialSideClips);
                    else
                        DataRepository.MovieClipProvider.Update(InitialSideClips);
                }
                InitialSideClips.MovieClipId++;
                if (txtBFrame6.Text != "")
                {
                    InitialSideClips.MovieId = IniitalSideMovieid;
                    InitialSideClips.BeginFrame = Convert.ToInt16(txtBFrame5.Text);
                    InitialSideClips.EndFrame = Convert.ToInt16(txtBFrame6.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(InitialSideClips);
                    else
                        DataRepository.MovieClipProvider.Update(InitialSideClips);
                }
                InitialSideClips.MovieClipId++;
                if (txtBFrame7.Text != "")
                {
                    InitialSideClips.MovieId = IniitalSideMovieid;
                    InitialSideClips.BeginFrame = Convert.ToInt16(txtBFrame6.Text);
                    InitialSideClips.EndFrame = Convert.ToInt16(txtBFrame7.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(InitialSideClips);
                    else
                        DataRepository.MovieClipProvider.Update(InitialSideClips);
                }
                InitialSideClips.MovieClipId++;
                if (txtBFrame8.Text != "")
                {
                    InitialSideClips.MovieId = IniitalSideMovieid;
                    InitialSideClips.BeginFrame = Convert.ToInt16(txtBFrame7.Text);
                    InitialSideClips.EndFrame = Convert.ToInt16(txtBFrame8.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(InitialSideClips);
                    else
                        DataRepository.MovieClipProvider.Update(InitialSideClips);
                }

            }
            #endregion[insert Initial side Frames]

            #region[insert Initial back Frames]
            if (txtbFilePath.Text != string.Empty && txtbFilePath.Text.Trim() != string.Empty)
            {
                MovieClip InitialBackClips = new MovieClip();
                int IniitalbackMovieid = movieBack.MovieId;

                try
                {
                    InitialBackClips = DataRepository.MovieClipProvider.GetByMovieId(IniitalbackMovieid)[0];
                    if (InitialBackClips != null)
                    {
                        isMovieClipsExist = true;
                    }
                    else
                    {
                        isMovieClipsExist = true;
                    }
                }
                catch
                {
                    isMovieClipsExist = false;
                }
                if (txtBFrame1.Text != "")
                {
                    InitialBackClips.MovieId = IniitalbackMovieid;
                    InitialBackClips.BeginFrame = Convert.ToInt16(txtBFrame1.Text);
                    InitialBackClips.EndFrame = Convert.ToInt16(txtBFrame1.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(InitialBackClips);
                    else
                        DataRepository.MovieClipProvider.Update(InitialBackClips);
                }
                InitialBackClips.MovieClipId++;
                if (txtBFrame2.Text != "")
                {
                    InitialBackClips.MovieId = IniitalbackMovieid;
                    InitialBackClips.BeginFrame = Convert.ToInt16(txtBFrame1.Text);
                    InitialBackClips.EndFrame = Convert.ToInt16(txtBFrame2.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(InitialBackClips);
                    else
                        DataRepository.MovieClipProvider.Update(InitialBackClips);
                }
                InitialBackClips.MovieClipId++;
                if (txtBFrame3.Text != "")
                {
                    InitialBackClips.MovieId = IniitalbackMovieid;
                    InitialBackClips.BeginFrame = Convert.ToInt16(txtBFrame2.Text);
                    InitialBackClips.EndFrame = Convert.ToInt16(txtBFrame3.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(InitialBackClips);
                    else
                        DataRepository.MovieClipProvider.Update(InitialBackClips);
                }
                InitialBackClips.MovieClipId++;
                if (txtBFrame4.Text != "")
                {
                    InitialBackClips.MovieId = IniitalbackMovieid;
                    InitialBackClips.BeginFrame = Convert.ToInt16(txtBFrame3.Text);
                    InitialBackClips.EndFrame = Convert.ToInt16(txtBFrame4.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(InitialBackClips);
                    else
                        DataRepository.MovieClipProvider.Update(InitialBackClips);
                }
                InitialBackClips.MovieClipId++;
                if (txtBFrame5.Text != "")
                {
                    InitialBackClips.MovieId = IniitalbackMovieid;
                    InitialBackClips.BeginFrame = Convert.ToInt16(txtBFrame4.Text);
                    InitialBackClips.EndFrame = Convert.ToInt16(txtBFrame5.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(InitialBackClips);
                    else
                        DataRepository.MovieClipProvider.Update(InitialBackClips);
                }
                InitialBackClips.MovieClipId++;
                if (txtBFrame6.Text != "")
                {
                    InitialBackClips.MovieId = IniitalbackMovieid;
                    InitialBackClips.BeginFrame = Convert.ToInt16(txtBFrame5.Text);
                    InitialBackClips.EndFrame = Convert.ToInt16(txtBFrame6.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(InitialBackClips);
                    else
                        DataRepository.MovieClipProvider.Update(InitialBackClips);
                }
                InitialBackClips.MovieClipId++;
                if (txtBFrame7.Text != "")
                {
                    InitialBackClips.MovieId = IniitalbackMovieid;
                    InitialBackClips.BeginFrame = Convert.ToInt16(txtBFrame6.Text);
                    InitialBackClips.EndFrame = Convert.ToInt16(txtBFrame7.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(InitialBackClips);
                    else
                        DataRepository.MovieClipProvider.Update(InitialBackClips);
                }
                InitialBackClips.MovieClipId++;
                if (txtBFrame8.Text != "")
                {
                    InitialBackClips.MovieId = IniitalbackMovieid;
                    InitialBackClips.BeginFrame = Convert.ToInt16(txtBFrame7.Text);
                    InitialBackClips.EndFrame = Convert.ToInt16(txtBFrame8.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(InitialBackClips);
                    else
                        DataRepository.MovieClipProvider.Update(InitialBackClips);
                }
            }
            #endregion[insert initial back Frames]

            #region[save current movies]
            try
            {
                if (txtForCurrentVideo.Text != string.Empty && txtForCurrentVideo.Text.Trim() != string.Empty)
                {
                    // IList CurrentmovieList = DataRepository.MovieProvider.GetByLessonId(LessonSelected);  
                    CurrentMovieSide = new Movie();
                    CurrentMovieBack = new Movie();
                    IList<Movie> CurrentmovieList = GetMovieListByLessionId_LessionType(LessonSelected, 2, 3);
                    if (CurrentmovieList != null)
                    {
                        if (CurrentmovieList.Count > 0)
                        {
                            CurrentMovieSide = CurrentmovieList[0];
                            CurrentMovieBack = CurrentmovieList[1];
                        }
                    }
                    if (CurrentMovieSide.MovieId <= 0)
                    {
                        CurrentMovieSide.LessonId = lesson.LessonId;
                        CurrentMovieSide.DateRecorded = lesson.LessonDate;
                        CurrentMovieSide.MovieType = 2;
                        CurrentMovieSide.FilePath = "Users/MovieFiles/" + Convert.ToString(txtForCurrentVideo.Text) + "-Side.mp4";
                        DataRepository.MovieProvider.Insert(CurrentMovieSide);
                    }
                    else
                    {
                        if (CurrentMovieSide.MovieType == 2)
                            CurrentMovieSide.FilePath = "Users/MovieFiles/" + Convert.ToString(txtForCurrentVideo.Text) + "-Side.mp4";
                        DataRepository.MovieProvider.Update(CurrentMovieSide);
                    }
                    if (CurrentMovieBack.MovieId <= 0)
                    {
                        //Back View

                        CurrentMovieBack.LessonId = lesson.LessonId;
                        CurrentMovieBack.DateRecorded = lesson.LessonDate;
                        CurrentMovieBack.MovieType = 3;
                        CurrentMovieBack.FilePath = "Users/MovieFiles/" + Convert.ToString(txtForCurrentVideo.Text) + "-Back.mp4";
                        DataRepository.MovieProvider.Insert(CurrentMovieBack);
                    }
                    else
                    {
                        if (CurrentMovieBack.MovieType == 3)
                            CurrentMovieBack.FilePath = "Users/MovieFiles/" + Convert.ToString(txtForCurrentVideo.Text) + "-Back.mp4";
                        DataRepository.MovieProvider.Update(CurrentMovieBack);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            #endregion[save current movies]

            #region[Insert Current Side Frames]
            if (txtForCurrentVideo.Text != string.Empty && txtForCurrentVideo.Text.Trim() != string.Empty)
            {
                MovieClip CurrentSideClips = new MovieClip();
                int CurrentSideMovieid = CurrentMovieSide.MovieId;
                try
                {
                    CurrentSideClips = DataRepository.MovieClipProvider.GetByMovieId(CurrentSideMovieid)[0];
                    if (CurrentSideClips != null)
                    {
                        isMovieClipsExist = true;
                    }
                    else
                    {
                        isMovieClipsExist = false;
                    }
                }
                catch
                {
                    isMovieClipsExist = false;
                }
                if (txtCBFrame1.Text != "")
                {
                    CurrentSideClips.MovieId = CurrentSideMovieid;
                    CurrentSideClips.BeginFrame = Convert.ToInt16(txtCBFrame1.Text);
                    CurrentSideClips.EndFrame = Convert.ToInt16(txtCBFrame1.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(CurrentSideClips);
                    else
                        DataRepository.MovieClipProvider.Update(CurrentSideClips);
                }
                if (txtCBFrame2.Text != "")
                {
                    CurrentSideClips.MovieClipId++;
                    CurrentSideClips.MovieId = CurrentSideMovieid;
                    CurrentSideClips.BeginFrame = Convert.ToInt16(txtCBFrame1.Text);
                    CurrentSideClips.EndFrame = Convert.ToInt16(txtCBFrame2.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(CurrentSideClips);
                    else
                        DataRepository.MovieClipProvider.Update(CurrentSideClips);
                }
                CurrentSideClips.MovieClipId++;
                if (txtCBFrame3.Text != "")
                {
                    CurrentSideClips.MovieId = CurrentSideMovieid;
                    CurrentSideClips.BeginFrame = Convert.ToInt16(txtCBFrame2.Text);
                    CurrentSideClips.EndFrame = Convert.ToInt16(txtCBFrame3.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(CurrentSideClips);
                    else
                        DataRepository.MovieClipProvider.Update(CurrentSideClips);
                }
                CurrentSideClips.MovieClipId++;
                if (txtCBFrame4.Text != "")
                {
                    CurrentSideClips.MovieId = CurrentSideMovieid;
                    CurrentSideClips.BeginFrame = Convert.ToInt16(txtCBFrame3.Text);
                    CurrentSideClips.EndFrame = Convert.ToInt16(txtCBFrame4.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(CurrentSideClips);
                    else
                        DataRepository.MovieClipProvider.Update(CurrentSideClips);
                }
                CurrentSideClips.MovieClipId++;
                if (txtCBFrame5.Text != "")
                {
                    CurrentSideClips.MovieId = CurrentSideMovieid;
                    CurrentSideClips.BeginFrame = Convert.ToInt16(txtCBFrame4.Text);
                    CurrentSideClips.EndFrame = Convert.ToInt16(txtCBFrame5.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(CurrentSideClips);
                    else
                        DataRepository.MovieClipProvider.Update(CurrentSideClips);
                }
                CurrentSideClips.MovieClipId++;
                if (txtCBFrame6.Text != "")
                {
                    CurrentSideClips.MovieId = CurrentSideMovieid;
                    CurrentSideClips.BeginFrame = Convert.ToInt16(txtCBFrame5.Text);
                    CurrentSideClips.EndFrame = Convert.ToInt16(txtCBFrame6.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(CurrentSideClips);
                    else
                        DataRepository.MovieClipProvider.Update(CurrentSideClips);
                }
                CurrentSideClips.MovieClipId++;
                if (txtCBFrame7.Text != "")
                {
                    CurrentSideClips.MovieId = CurrentSideMovieid;
                    CurrentSideClips.BeginFrame = Convert.ToInt16(txtCBFrame6.Text);
                    CurrentSideClips.EndFrame = Convert.ToInt16(txtCBFrame7.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(CurrentSideClips);
                    else
                        DataRepository.MovieClipProvider.Update(CurrentSideClips);
                }
                CurrentSideClips.MovieClipId++;
                if (txtCBFrame8.Text != "")
                {
                    CurrentSideClips.MovieId = CurrentSideMovieid;
                    CurrentSideClips.BeginFrame = Convert.ToInt16(txtCBFrame7.Text);
                    CurrentSideClips.EndFrame = Convert.ToInt16(txtCBFrame8.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(CurrentSideClips);
                    else
                        DataRepository.MovieClipProvider.Update(CurrentSideClips);
                }
            }
            #endregion[Insert Current Side Frames]

            #region[Insert Current back Frames]
            if (txtForCurrentVideo.Text != string.Empty && txtForCurrentVideo.Text.Trim() != string.Empty)
            {
                MovieClip CurrentBackClips = new MovieClip();
                int CurrentBackMovieid = CurrentMovieBack.MovieId;
                try
                {
                    CurrentBackClips = DataRepository.MovieClipProvider.GetByMovieId(CurrentBackMovieid)[0];

                    if (CurrentBackClips != null)
                    {
                        isMovieClipsExist = true;
                    }
                    else
                    {
                        isMovieClipsExist = false;
                    }
                }
                catch
                {
                    isMovieClipsExist = false;
                }
                if (txtCBFrame1.Text != "")
                {
                    CurrentBackClips.MovieId = CurrentBackMovieid;
                    CurrentBackClips.BeginFrame = Convert.ToInt16(txtCBFrame1.Text);
                    CurrentBackClips.EndFrame = Convert.ToInt16(txtCBFrame1.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(CurrentBackClips);
                    else
                        DataRepository.MovieClipProvider.Update(CurrentBackClips);
                }
                CurrentBackClips.MovieClipId++;
                if (txtCBFrame2.Text != "")
                {
                    CurrentBackClips.MovieId = CurrentBackMovieid;
                    CurrentBackClips.BeginFrame = Convert.ToInt16(txtCBFrame1.Text);
                    CurrentBackClips.EndFrame = Convert.ToInt16(txtCBFrame2.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(CurrentBackClips);
                    else
                        DataRepository.MovieClipProvider.Update(CurrentBackClips);
                }
                CurrentBackClips.MovieClipId++;
                if (txtCBFrame3.Text != "")
                {
                    CurrentBackClips.MovieId = CurrentBackMovieid;
                    CurrentBackClips.BeginFrame = Convert.ToInt16(txtCBFrame2.Text);
                    CurrentBackClips.EndFrame = Convert.ToInt16(txtCBFrame3.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(CurrentBackClips);
                    else
                        DataRepository.MovieClipProvider.Update(CurrentBackClips);
                }
                CurrentBackClips.MovieClipId++;
                if (txtCBFrame4.Text != "")
                {
                    CurrentBackClips.MovieId = CurrentBackMovieid;
                    CurrentBackClips.BeginFrame = Convert.ToInt16(txtCBFrame3.Text);
                    CurrentBackClips.EndFrame = Convert.ToInt16(txtCBFrame4.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(CurrentBackClips);
                    else
                        DataRepository.MovieClipProvider.Update(CurrentBackClips);
                }
                CurrentBackClips.MovieClipId++;
                if (txtCBFrame5.Text != "")
                {
                    CurrentBackClips.MovieId = CurrentBackMovieid;
                    CurrentBackClips.BeginFrame = Convert.ToInt16(txtCBFrame4.Text);
                    CurrentBackClips.EndFrame = Convert.ToInt16(txtCBFrame5.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(CurrentBackClips);
                    else
                        DataRepository.MovieClipProvider.Update(CurrentBackClips);
                }
                CurrentBackClips.MovieClipId++;
                if (txtCBFrame6.Text != "")
                {
                    CurrentBackClips.MovieId = CurrentBackMovieid;
                    CurrentBackClips.BeginFrame = Convert.ToInt16(txtCBFrame5.Text);
                    CurrentBackClips.EndFrame = Convert.ToInt16(txtCBFrame6.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(CurrentBackClips);
                    else
                        DataRepository.MovieClipProvider.Update(CurrentBackClips);
                }
                CurrentBackClips.MovieClipId++;
                if (txtCBFrame7.Text != "")
                {
                    CurrentBackClips.MovieId = CurrentBackMovieid;
                    CurrentBackClips.BeginFrame = Convert.ToInt16(txtCBFrame6.Text);
                    CurrentBackClips.EndFrame = Convert.ToInt16(txtCBFrame7.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(CurrentBackClips);
                    else
                        DataRepository.MovieClipProvider.Update(CurrentBackClips);
                }
                CurrentBackClips.MovieClipId++;
                if (txtCBFrame8.Text != "")
                {
                    CurrentBackClips.MovieId = CurrentBackMovieid;
                    CurrentBackClips.BeginFrame = Convert.ToInt16(txtCBFrame7.Text);
                    CurrentBackClips.EndFrame = Convert.ToInt16(txtCBFrame8.Text);
                    if (!isMovieClipsExist)
                        DataRepository.MovieClipProvider.Insert(CurrentBackClips);
                    else
                        DataRepository.MovieClipProvider.Update(CurrentBackClips);
                }
            }

            #endregion[Insert Current back Frames]

            #region[Save Summary Movie]
            try
            {
                if (txtSumFilePath.Text != string.Empty && txtSumFilePath.Text.Trim() != string.Empty)
                {
                    summaryMovie.LessonId = lesson.LessonId;
                    summaryMovie.DateRecorded = lesson.LessonDate;
                    //  summaryMovie.MovieType = 0;
                    summaryMovie.FilePath = "Users/SummaryFiles/" + Convert.ToString(txtSumFilePath.Text);
                    //Back View
                    //movieBack.LessonId = lesson.LessonId;
                    //movieBack.MovieType = 1;
                    //movieBack.FilePath = "Users/SummaryFiles/" + Convert.ToString(txtSumFilePath.Text) + "-Back.swf";
                    if (summaryMovie.SummaryId <= 0)
                    {
                        DataRepository.SummaryMovieProvider.Insert(summaryMovie);
                    }
                    else
                    {
                        DataRepository.SummaryMovieProvider.Update(summaryMovie);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            #endregion[save summary movie]

            DropDownList1_SelectedIndexChanged(null, null);
            lblDate.Visible = false;
            lblDateEx.Visible = false;
            txtDate.Visible = false;

            lblLocation.Visible = false;
            txtLocation.Visible = false;
            lblexlocation.Visible = false;

            lblTime.Visible = false;
            lblExTime.Visible = false;
            txtTime.Visible = false;

            txtbFilePath.Visible = true;
            // txtbFilePath1.Visible = false;
            txtSumFilePath.Visible = true;
            Gridview1.Visible = false;
            Gridview2.Visible = false;
            Gridview3.Visible = false;
            btnUpload.Visible = true;
            btnUpload2.Visible = true;
            btnDeleteInitialMovies.Visible = true;
            btnDeleteCurrentMovies.Visible = true;
            btnDeleteSummaryMovie.Visible = true;
            tblCurrentFrames.Visible = true;
            tblInitialFrames.Visible = true;
            ClearData();
            ClearFramesData();
            // lblDataSave.Visible = true;
            Label117.Text = "Data saved successfully";
            int athleteSelected;
            athleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
            HurdleStepsPageOnTrackSessi hurdleStepsPageOnTrackSessi = new HurdleStepsPageOnTrackSessi();
            hurdleStepsPageOnTrackSessi.HurdlePageOnTrackSessionData(athleteSelected);
        }
        else
        {
            Label117.Text = "Please select Athlete";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Lesson _lesson = new Lesson();
        Movie _movieSide = new Movie();
        Movie _movieBack = new Movie();
        int _lessonselected = Convert.ToInt32(DropDownList2.SelectedValue);
        _lesson = DataRepository.LessonProvider.GetByLessonId(_lessonselected);
        IList<Movie> movieList = GetMovieListByLessionId_LessionType(_lessonselected, 0, 1);
        if (movieList.Count > 0)
        {
            _movieSide = movieList[0];
            _movieBack = movieList[1];
            int InitialSide = _movieSide.MovieId;
            int InitialBack = _movieBack.MovieId;
            DataRepository.MovieClipProvider.Delete(InitialSide);
            DataRepository.MovieClipProvider.Delete(InitialBack);
            DataRepository.MovieProvider.Delete(InitialSide);
            DataRepository.MovieProvider.Delete(InitialBack);

            txtbFilePath.Text = "";
            txtBFrame1.Text = "";
            txtBFrame2.Text = "";
            txtBFrame3.Text = "";
            txtBFrame4.Text = "";
            txtBFrame5.Text = "";
            txtBFrame6.Text = "";
            txtBFrame7.Text = "";
            txtBFrame8.Text = "";
        }
    }
    protected void btnDeleteCurrentMovies_Click(object sender, EventArgs e)
    {
        Lesson _lesson = new Lesson();
        Movie _movieCurrentSide = new Movie();
        Movie _movieCurrentBack = new Movie();
        int _lessonselected = Convert.ToInt32(DropDownList2.SelectedValue);
        _lesson = DataRepository.LessonProvider.GetByLessonId(_lessonselected);
        IList<Movie> movieList = GetMovieListByLessionId_LessionType(_lessonselected, 2, 3);
        if (movieList.Count > 0)
        {
            _movieCurrentSide = movieList[0];
            _movieCurrentBack = movieList[1];
            int CurrentSide = _movieCurrentSide.MovieId;
            int CurrentBack = _movieCurrentBack.MovieId;
            DataRepository.MovieClipProvider.Delete(CurrentSide);
            DataRepository.MovieClipProvider.Delete(CurrentBack);
            DataRepository.MovieProvider.Delete(CurrentSide);
            DataRepository.MovieProvider.Delete(CurrentBack);
            txtForCurrentVideo.Text = "";
            txtCBFrame1.Text = "";
            txtCBFrame2.Text = "";
            txtCBFrame3.Text = "";
            txtCBFrame4.Text = "";
            txtCBFrame5.Text = "";
            txtCBFrame6.Text = "";
            txtCBFrame7.Text = "";
            txtCBFrame8.Text = "";

        }
    }
    protected void DeleteSummaryMovie_Click(object sender, EventArgs e)
    {
        Lesson _lesson = new Lesson();
        int _lessonselected = Convert.ToInt32(DropDownList2.SelectedValue);
        _lesson = DataRepository.LessonProvider.GetByLessonId(_lessonselected);
        int summarylessonid = _lesson.LessonId;
        DataRepository.SummaryMovieProvider.Delete(summarylessonid);
        txtSumFilePath.Text = "";
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        // create session for clearing record 
        //  readtext();
        txtCBFrame1.Text = "";
        txtCBFrame2.Text = "";
        txtCBFrame3.Text = "";
        txtCBFrame4.Text = "";
        txtCBFrame5.Text = "";
        txtCBFrame6.Text = "";
        txtCBFrame7.Text = "";
        txtCBFrame8.Text = "";

        txtBFrame1.Text = "";
        txtBFrame2.Text = "";
        txtBFrame3.Text = "";
        txtBFrame4.Text = "";
        txtBFrame5.Text = "";
        txtBFrame6.Text = "";
        txtBFrame7.Text = "";
        txtBFrame8.Text = "";

        Label117.Text = "";
        ClearData();
        DataClear(); //05/01/2017
        //DropDownList2.SelectedValue = "";
        DropDownList2.Items.Clear();


        lblDate.Visible = true;
        lblDateEx.Visible = true;
        txtDate.Visible = true;

        lblLocation.Visible = true;
        txtLocation.Visible = true;
        lblexlocation.Visible = true;

        lblTime.Visible = true;
        txtTime.Visible = true;
        lblExTime.Visible = true;

        txtDate.Text = "";
        txtTime.Text = "";
        txtLocation.Text = "";

        txtForCurrentVideo.Visible = true;
        txtForCurrentVideo.Text = "";
        btnToBrowseCurrentVideo.Visible = true;
        btnDeleteCurrentMovies.Enabled = true;
        btnUpload2.Visible = true;
        txtSumFilePath.Visible = true;
        txtbFilePath.Visible = true;
        //  txtbFilePath1.Visible = true;
        btnUpload.Visible = true;
        txtSumFilePath.Text = "";
        txtbFilePath.Text = "";
        tblCurrentFrames.Visible = true;
        tblInitialFrames.Visible = true;
        btnSubmit.Visible = true;
        btnDeleteSession.Visible = true;
        lblNoVideo.Visible = false;
        btnInpuFullSession.Visible = true;
        DropdownListXmlFle.Visible = true;
        btnInpuFullSession.Enabled = true;
        DropdownListXmlFle.Enabled = true;
        btnInpuFullSession.Enabled = true;
        DropdownListXmlFle.Enabled = true;
        txtbFilePath.Enabled = true;
        btnUpload.Enabled = true;
        btnDeleteInitialMovies.Enabled = true;
        txtForCurrentVideo.Enabled = true;
        btnToBrowseCurrentVideo.Enabled = true;
        btnDeleteCurrentMovies.Visible = true;
        txtSumFilePath.Enabled = true;
        btnUpload2.Enabled = true;
        btnDeleteSummaryMovie.Enabled = true;
        btnSubmit.Enabled = true;
        btnDeleteSession.Enabled = true;


    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            btnDeleteSummaryMovie.Visible = true;
            btndateloc.Enabled = true;
            btnDeleteCurrentMovies.Enabled = true;
            btnInpuFullSession.Enabled = true;
            DropdownListXmlFle.Enabled = true;
            txtbFilePath.Enabled = true;
            btnUpload.Enabled = true;
            btnDeleteInitialMovies.Enabled = true;
            txtForCurrentVideo.Enabled = true;
            btnToBrowseCurrentVideo.Enabled = true;
            btnDeleteCurrentMovies.Visible = true;
            txtSumFilePath.Enabled = true;
            btnUpload2.Enabled = true;
            btnDeleteSummaryMovie.Enabled = true;
            btnSubmit.Enabled = true;
            btnDeleteSession.Enabled = true;
            Gridview1.Visible = true;
            Gridview2.Visible = false;
            Gridview3.Visible = false;
            // FileInfo myFile = new FileInfo("G:\\NewCompuSport\\SourceCode\\Users\\MovieFiles");
            //string[] files = Directory.GetFiles("G:\\NewCompuSport\\SourceCode\\Users\\MovieFiles");
            string mappath = Server.MapPath(".");
            if (mappath.Contains("Admin"))
            {
                mappath = mappath.Replace("Admin", "Users");
            }
            string[] files = Directory.GetFiles(mappath + "\\" + "MovieFiles");
            ArrayList arrFiles = new ArrayList();

            for (int i = 0; i < files.Length; i++)
            {
                FilePathClassa2 objFilePathClass = new FilePathClassa2();
                objFilePathClass.Index = i;
                try
                {
                    string strTemp = files[i];
                    if (!strTemp.Contains("Current"))
                    {
                        files[i] = strTemp.Substring(strTemp.LastIndexOf("\\") + 1, strTemp.Length - strTemp.LastIndexOf("\\") - 1).Replace("-Back.mp4", "").Replace("-Side.mp4", "");
                        objFilePathClass.FilePath = files[i];
                        arrFiles.Add(objFilePathClass);
                    }
                }
                catch (Exception ex1)
                { }
                i++;
            }

            Gridview1.DataSource = arrFiles;
            Gridview1.DataBind();
            Label117.Text = "";
        }
        catch (Exception ex)
        { }
    }

    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        LinkButton lnkSelect = (LinkButton)e.Row.FindControl("lnkSelect");
        if (lnkSelect != null)
        {
            lnkSelect.OnClientClick = "return PrintFilePath('" + lnkSelect.Text + "');";
        }
    }
    protected void Gridview2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        LinkButton lnkSumSelect = (LinkButton)e.Row.FindControl("lnkSumSelect");
        if (lnkSumSelect != null)
        {
            lnkSumSelect.OnClientClick = "return PrintFilePathTwo('" + lnkSumSelect.Text + "');";
        }
    }
    protected void Gridview3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        LinkButton lnkSelectCurrent = (LinkButton)e.Row.FindControl("lnkSelectCurrent");
        if (lnkSelectCurrent != null)
        {
            lnkSelectCurrent.OnClientClick = "return PrintFilePathThree('" + lnkSelectCurrent.Text + "');";
        }
    }
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void Gridview2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void Gridview3_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void btnUpload2_Click(object sender, EventArgs e)
    {
        try
        {
            btnDeleteSummaryMovie.Visible = true;
            btndateloc.Enabled = true;
            btnDeleteCurrentMovies.Enabled = true;
            btnInpuFullSession.Enabled = true;
            DropdownListXmlFle.Enabled = true;
            txtbFilePath.Enabled = true;
            btnUpload.Enabled = true;
            btnDeleteInitialMovies.Enabled = true;
            txtForCurrentVideo.Enabled = true;
            btnToBrowseCurrentVideo.Enabled = true;
            btnDeleteCurrentMovies.Visible = true;
            txtSumFilePath.Enabled = true;
            btnUpload2.Enabled = true;
            btnDeleteSummaryMovie.Enabled = true;
            btnSubmit.Enabled = true;
            btnDeleteSession.Enabled = true;
            Gridview2.Visible = true;
            Gridview1.Visible = false;
            Gridview3.Visible = false;
            FileInfo myFile = new FileInfo("G:\\NewCompuSport\\SourceCode\\Users\\SummaryFiles");
            //string[] files = Directory.GetFiles("G:\\NewCompuSport\\SourceCode\\Users\\SummaryFiles");
            string mappath = Server.MapPath(".");
            if (mappath.Contains("Admin"))
            {
                mappath = mappath.Replace("Admin", "Users");
            }
            string[] files = Directory.GetFiles(mappath + "\\" + "SummaryFiles");
            ArrayList arrFiles = new ArrayList();

            for (int i = 0; i < files.Length; i++)
            {
                FilePathClassa2 objFilePathClass = new FilePathClassa2();
                objFilePathClass.Index = i;
                try
                {
                    string strTemp = files[i];
                    files[i] = strTemp.Substring(strTemp.LastIndexOf("\\") + 1, strTemp.Length - strTemp.LastIndexOf("\\") - 1);
                    objFilePathClass.FilePath = files[i];
                    arrFiles.Add(objFilePathClass);
                }
                catch (Exception ex1)
                { }
            }

            Gridview2.DataSource = arrFiles;
            Gridview2.DataBind();
            Label117.Text = "";
        }
        catch (Exception ex)
        { }

    }
    protected void Gridview2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    //chk
    public void GetHurdleStepsSummaryModeldata(int lesson_id)
    {
        if (ds != null)
        {
            ds = sae.GetAllHurdleStepsAthletesData(lesson_id);
            if (ds.Tables[1].Rows.Count > 0)
            {

                #region[Summary Session Hurdle Step model data]
                TxtHurdleDistanceBtweenM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetDistanceBetweenHurdleSteps"].ToString());
                if (TxtHurdleDistanceBtweenM1.Text == "" || TxtHurdleDistanceBtweenM1.Text == "0")
                {
                    TxtHurdleDistanceBtweenM1.Text = "";
                }
                TxtHurdleDistanceIntoM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetDistanceIntoHurdleSteps"].ToString());
                if (TxtHurdleDistanceIntoM1.Text == "" || TxtHurdleDistanceIntoM1.Text == "0")
                {
                    TxtHurdleDistanceIntoM1.Text = "";
                }
                TxtHurdleDistanceOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetDistanceOffHurdleSteps"].ToString());
                if (TxtHurdleDistanceOffM1.Text == "" || TxtHurdleDistanceOffM1.Text == "0")
                {
                    TxtHurdleDistanceOffM1.Text = "";
                }
                //TxtHurdleVelocityM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Velocity"].ToString());
                //if (TxtHurdleVelocityM1.Text == "" || TxtHurdleVelocityM1.Text == "0")
                //{
                //    TxtHurdleVelocityM1.Text = "";
                //}
                //step 1
                TxtStep1GroundTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1GroundTime"].ToString());
                if (TxtStep1GroundTimeM1.Text == "" || TxtStep1GroundTimeM1.Text == "0")
                {
                    TxtStep1GroundTimeM1.Text = "";
                }
                TxtStep1AirTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1AirTime"].ToString());
                if (TxtStep1AirTimeM1.Text == "" || TxtStep1AirTimeM1.Text == "0")
                {
                    TxtStep1AirTimeM1.Text = "";
                }
                //TxtStep1UlFlexTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1UlFlexTime"].ToString());
                //if (TxtStep1UlFlexTimeM1.Text == "" || TxtStep1UlFlexTimeM1.Text == "0")
                //{
                //    TxtStep1UlFlexTimeM1.Text = "";
                //}
                //TxtStep1StrideRateM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1StrideRate"].ToString());
                //if (TxtStep1StrideRateI.Text == "" || TxtStep1StrideRateM1.Text == "0.000")
                //{
                //    TxtStep1StrideRateM1.Text = "";
                //}
                TxtStep1StrideLengthM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1StrideLength"].ToString());
                if (TxtStep1StrideLengthM1.Text == "" || TxtStep1StrideLengthM1.Text == "0")
                {
                    TxtStep1StrideLengthM1.Text = "";
                }
                TxtStep1TouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1TouchdownDistance"].ToString());
                if (TxtStep1TouchDistanceM1.Text == "" || TxtStep1TouchDistanceM1.Text == "0")
                {
                    TxtStep1TouchDistanceM1.Text = "";
                }
                TxtStep1KSTouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1KneeSeperationatTouchdown"].ToString());
                if (TxtStep1KSTouchDistanceM1.Text == "" || TxtStep1KSTouchDistanceM1.Text == "0")
                {
                    TxtStep1KSTouchDistanceM1.Text = "";
                }

                //TrunkTd

                TxtStep1ULFullExtensionM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1ULAtFullExtension"].ToString());
                if (TxtStep1ULFullExtensionM1.Text == "" || TxtStep1ULFullExtensionM1.Text == "0")
                {
                    TxtStep1ULFullExtensionM1.Text = "";
                }

                TxtStep1LLTakeOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1LLAtTakeoff"].ToString());
                if (TxtStep1LLTakeOffI.Text == "" || TxtStep1LLTakeOffM1.Text == "0")
                {
                    TxtStep1LLTakeOffM1.Text = "";
                }
                TxtStep1ULFullFlexionM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1ULAtFullFlexion"].ToString());
                if (TxtStep1ULFullFlexionM1.Text == "" || TxtStep1ULFullFlexionM1.Text == "0")
                {
                    TxtStep1ULFullFlexionM1.Text = "";
                }
                //step 2

                TxtStep2GroundTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2GroundTime"].ToString());
                if (TxtStep2GroundTimeM1.Text == "" || TxtStep2GroundTimeM1.Text == "0")
                {
                    TxtStep2GroundTimeM1.Text = "";
                }
                TxtStep2AirTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2AirTime"].ToString());
                if (TxtStep2AirTimeM1.Text == "" || TxtStep2AirTimeM1.Text == "0")
                {
                    TxtStep2AirTimeM1.Text = "";
                }
                //TxtStep2UlFlexTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2UlFlexTime"].ToString());
                //if (TxtStep2UlFlexTimeM1.Text == "" || TxtStep2UlFlexTimeM1.Text == "0")
                //{
                //    TxtStep2UlFlexTimeM1.Text = "";
                //}
                //TxtStep2StrideRateM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2 Stride Rate"].ToString());
                //if (TxtStep2StrideRateM1.Text == "" || TxtStep2StrideRateM1.Text == "0")
                //{
                //    TxtStep2StrideRateM1.Text = "";
                //}
                TxtStep2StrideLengthM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2StrideLength"].ToString());
                if (TxtStep2StrideLengthM1.Text == "" || TxtStep2StrideLengthM1.Text == "0")
                {
                    TxtStep2StrideLengthM1.Text = "";
                }
                TxtStep2TouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2TouchdownDistance"].ToString());
                if (TxtStep2TouchDistanceM1.Text == "" || TxtStep2TouchDistanceM1.Text == "0")
                {
                    TxtStep2TouchDistanceM1.Text = "";
                }
                TxtStep2KSTouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2KneeSeperationatTouchdown"].ToString());
                if (TxtStep2KSTouchDistanceM1.Text == "" || TxtStep2KSTouchDistanceM1.Text == "0")
                {
                    TxtStep2KSTouchDistanceM1.Text = "";
                }

                //TrunkTd

                TxtStep2ULFullExtensionM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2ULAtFullExtension"].ToString());
                if (TxtStep2ULFullExtensionM1.Text == "" || TxtStep2ULFullExtensionM1.Text == "0")
                {
                    TxtStep2ULFullExtensionM1.Text = "";
                }
                TxtStep2LLTakeOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2LLAtTakeoff"].ToString());
                if (TxtStep2LLTakeOffM1.Text == "" || TxtStep2LLTakeOffM1.Text == "0")
                {
                    TxtStep2LLTakeOffM1.Text = "";
                }
                TxtStep2LLFullFlexionM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2LLAtFullFlexion"].ToString());
                if (TxtStep2LLFullFlexionM1.Text == "" || TxtStep2LLFullFlexionM1.Text == "0")
                {
                    TxtStep2LLFullFlexionM1.Text = "";
                }
                //TxtStep2LLAnkleCrossM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2LLAtatAnkleCross"].ToString());
                //if (TxtStep2LLAnkleCrossM1.Text == "" || TxtStep2LLAnkleCrossM1.Text == "0")
                //{
                //    TxtStep2LLAnkleCrossM1.Text = "";
                //}
                TxtStep2ULFullFlexionM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2ULAtFullFlexion"].ToString());
                if (TxtStep2ULFullFlexionM1.Text == "" || TxtStep2ULFullFlexionM1.Text == "0")
                {
                    TxtStep2ULFullFlexionM1.Text = "";
                }

                //Step3

                TxtStep3GroundTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3GroundTime"].ToString());
                if (TxtStep3GroundTimeM1.Text == "" || TxtStep3GroundTimeM1.Text == "0")
                {
                    TxtStep3GroundTimeM1.Text = "";
                }
                TxtStep3AirTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3AirTime"].ToString());
                if (TxtStep3AirTimeM1.Text == "" || TxtStep3AirTimeM1.Text == "0")
                {
                    TxtStep3AirTimeM1.Text = "";
                }
                //TxtStep3UlFlexTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3UlFlexTime"].ToString());
                //if (TxtStep3UlFlexTimeM1.Text == "" || TxtStep3UlFlexTimeM1.Text == "0")
                //{
                //    TxtStep3UlFlexTimeM1.Text = "";
                //}
                //TxtStep3StrideRateM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3StrideRate"].ToString());
                //if (TxtStep3StrideRateI.Text == "" || TxtStep3StrideRateM1.Text == "0")
                //{
                //    TxtStep3StrideRateM1.Text = "";
                //}
                TxtStep3StrideLengthM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3StrideLength"].ToString());
                if (TxtStep3StrideLengthM1.Text == "" || TxtStep3StrideLengthM1.Text == "0")
                {
                    TxtStep3StrideLengthM1.Text = "";
                }
                TxtStep3TouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3TouchdownDistance"].ToString());
                if (TxtStep2TouchDistanceM1.Text == "" || TxtStep3TouchDistanceM1.Text == "0")
                {
                    TxtStep3TouchDistanceM1.Text = "";
                }
                TxtStep3KSTouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3KneeSeperationatTouchdown"].ToString());
                if (TxtStep3KSTouchDistanceM1.Text == "" || TxtStep3KSTouchDistanceM1.Text == "0")
                {
                    TxtStep3KSTouchDistanceM1.Text = "";
                }

                //TrunkTd

                TxtStep3ULFullExtensionM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3ULAtFullExtension"].ToString());
                if (TxtStep3ULFullExtensionM1.Text == "" || TxtStep3ULFullExtensionM1.Text == "0")
                {
                    TxtStep3ULFullExtensionM1.Text = "";
                }
                TxtStep3LLTakeOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3LLAtTakeoff"].ToString());
                if (TxtStep3LLTakeOffM1.Text == "" || TxtStep3LLTakeOffM1.Text == "0")
                {
                    TxtStep3LLTakeOffM1.Text = "";
                }
                TxtStep3LLFullFlexionM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3LLAtFullFlexion"].ToString());
                if (TxtStep3LLFullFlexionM1.Text == "" || TxtStep3LLFullFlexionM1.Text == "0")
                {
                    TxtStep3LLFullFlexionM1.Text = "";
                }
                //TxtStep3LLAnkleCrossM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3LLAtatAnkleCross"].ToString());
                //if (TxtStep3LLAnkleCrossM1.Text == "" || TxtStep3LLAnkleCrossM1.Text == "0")
                //{
                //    TxtStep3LLAnkleCrossM1.Text = "";
                //}
                TxtStep3ULFullFlexionM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3ULAtFullFlexion"].ToString());
                if (TxtStep3ULFullFlexionM1.Text == "" || TxtStep3ULFullFlexionM1.Text == "0")
                {
                    TxtStep3ULFullFlexionM1.Text = "";
                }

                //IntoHurdleSteps

                TxtIntoHurdleTouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetTouchdownDistanceIntoTheHurdle"].ToString());
                if (TxtIntoHurdleTouchDistanceM1.Text == "" || TxtIntoHurdleTouchDistanceM1.Text == "0")
                {
                    TxtIntoHurdleTouchDistanceM1.Text = "";
                }
                TxtIntoHurdleKSTouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetKneeSeperationatTouchdownIntoTheHurdle"].ToString());
                if (TxtIntoHurdleKSTouchDistanceM1.Text == "" || TxtIntoHurdleKSTouchDistanceM1.Text == "0")
                {
                    TxtIntoHurdleKSTouchDistanceM1.Text = "";
                }


                //TrunkTD

                TxtIntoHurdleLLTouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetLLAtTouchdownIntoTheHurdle"].ToString());
                if (TxtIntoHurdleLLTouchDistanceM1.Text == "" || TxtIntoHurdleLLTouchDistanceM1.Text == "0")
                {
                    TxtIntoHurdleLLTouchDistanceM1.Text = "";
                }
                #endregion[model Data]
            }
        }
    }

    //chk
    private void BindModelDataOnly(DataSet dsmodelData)
    {
        try
        {
            if (dsmodelData != null)
            {
                if (dsmodelData.Tables.Count > 1)
                {
                    if (dsmodelData.Tables[1].Rows.Count > 0)
                    {

                        #region[Hurdle Steps model data]
                        TxtHurdleDistanceBtweenM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["SetDistanceBetweenHurdleSteps"].ToString());
                        if (TxtHurdleDistanceBtweenM1.Text == "" || TxtHurdleDistanceBtweenM1.Text == "0")
                        {
                            TxtHurdleDistanceBtweenM1.Text = "";
                        }
                        TxtHurdleDistanceIntoM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["SetDistanceIntoHurdleSteps"].ToString());
                        if (TxtHurdleDistanceIntoM1.Text == "" || TxtHurdleDistanceIntoM1.Text == "0")
                        {
                            TxtHurdleDistanceIntoM1.Text = "";
                        }
                        TxtHurdleDistanceOffM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["SetDistanceOffHurdleSteps"].ToString());
                        if (TxtHurdleDistanceOffM1.Text == "" || TxtHurdleDistanceOffM1.Text == "0")
                        {
                            TxtHurdleDistanceOffM1.Text = "";
                        }
                        //TxtHurdleVelocityM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Velocity"].ToString());
                        //if (TxtHurdleVelocityM1.Text == "" || TxtHurdleVelocityM1.Text == "0")
                        //{
                        //    TxtHurdleVelocityM1.Text = "";
                        //}
                        //step 1
                        TxtStep1GroundTimeM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step1GroundTime"].ToString());
                        if (TxtStep1GroundTimeM1.Text == "" || TxtStep1GroundTimeM1.Text == "0")
                        {
                            TxtStep1GroundTimeM1.Text = "";
                        }
                        TxtStep1AirTimeM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step1AirTime"].ToString());
                        if (TxtStep1AirTimeM1.Text == "" || TxtStep1AirTimeM1.Text == "0")
                        {
                            TxtStep1AirTimeM1.Text = "";
                        }
                        //TxtStep1UlFlexTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1UlFlexTime"].ToString());
                        //if (TxtStep1UlFlexTimeM1.Text == "" || TxtStep1UlFlexTimeM1.Text == "0")
                        //{
                        //    TxtStep1UlFlexTimeM1.Text = "";
                        //}
                        //TxtStep1StrideRateM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1StrideRate"].ToString());
                        //if (TxtStep1StrideRateI.Text == "" || TxtStep1StrideRateM1.Text == "0.000")
                        //{
                        //    TxtStep1StrideRateM1.Text = "";
                        //}
                        TxtStep1StrideLengthM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step1StrideLength"].ToString());
                        if (TxtStep1StrideLengthM1.Text == "" || TxtStep1StrideLengthM1.Text == "0")
                        {
                            TxtStep1StrideLengthM1.Text = "";
                        }
                        TxtStep1TouchDistanceM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step1TouchdownDistance"].ToString());
                        if (TxtStep1TouchDistanceM1.Text == "" || TxtStep1TouchDistanceM1.Text == "0")
                        {
                            TxtStep1TouchDistanceM1.Text = "";
                        }
                        TxtStep1KSTouchDistanceM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step1KneeSeperationatTouchdown"].ToString());
                        if (TxtStep1KSTouchDistanceM1.Text == "" || TxtStep1KSTouchDistanceM1.Text == "0")
                        {
                            TxtStep1KSTouchDistanceM1.Text = "";
                        }

                        //TrunkTd
                        TxtStep1TrunkTouchdownAngleM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step1TrunkTouchdownAngle"].ToString());
                        if (TxtStep1KSTouchDistanceM1.Text == "" || TxtStep1TrunkTouchdownAngleM1.Text == "0")
                        {
                            TxtStep1TrunkTouchdownAngleM1.Text = "";
                        }
                        //TrunkTO
                        TxtStep1TrunkTakeoffAngleM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step1TrunkTakeoffAngle"].ToString());
                        if (TxtStep1TrunkTakeoffAngleM1.Text == "" || TxtStep1TrunkTakeoffAngleM1.Text == "0")
                        {
                            TxtStep1TrunkTakeoffAngleM1.Text = "";
                        }



                        TxtStep1ULFullExtensionM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step1ULAtFullExtension"].ToString());
                        if (TxtStep1ULFullExtensionM1.Text == "" || TxtStep1ULFullExtensionM1.Text == "0")
                        {
                            TxtStep1ULFullExtensionM1.Text = "";
                        }

                        TxtStep1LLTakeOffM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step1LLAtTakeoff"].ToString());
                        if (TxtStep1LLTakeOffM1.Text == "" || TxtStep1LLTakeOffM1.Text == "0")
                        {
                            TxtStep1LLTakeOffM1.Text = "";
                        }
                        TxtStep1ULFullFlexionM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step1ULAtFullFlexion"].ToString());
                        if (TxtStep1ULFullFlexionM1.Text == "" || TxtStep1ULFullFlexionM1.Text == "0")
                        {
                            TxtStep1ULFullFlexionM1.Text = "";
                        }
                        //step 2

                        TxtStep2GroundTimeM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step2GroundTime"].ToString());
                        if (TxtStep2GroundTimeM1.Text == "" || TxtStep2GroundTimeM1.Text == "0")
                        {
                            TxtStep2GroundTimeM1.Text = "";
                        }
                        TxtStep2AirTimeM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step2AirTime"].ToString());
                        if (TxtStep2AirTimeM1.Text == "" || TxtStep2AirTimeM1.Text == "0")
                        {
                            TxtStep2AirTimeM1.Text = "";
                        }
                        //TxtStep2UlFlexTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2UlFlexTime"].ToString());
                        //if (TxtStep2UlFlexTimeM1.Text == "" || TxtStep2UlFlexTimeM1.Text == "0")
                        //{
                        //    TxtStep2UlFlexTimeM1.Text = "";
                        //}
                        //TxtStep2StrideRateM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2 Stride Rate"].ToString());
                        //if (TxtStep2StrideRateM1.Text == "" || TxtStep2StrideRateM1.Text == "0")
                        //{
                        //    TxtStep2StrideRateM1.Text = "";
                        //}
                        TxtStep2StrideLengthM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step2StrideLength"].ToString());
                        if (TxtStep2StrideLengthM1.Text == "" || TxtStep2StrideLengthM1.Text == "0")
                        {
                            TxtStep2StrideLengthM1.Text = "";
                        }
                        TxtStep2TouchDistanceM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step2TouchdownDistance"].ToString());
                        if (TxtStep2TouchDistanceM1.Text == "" || TxtStep2TouchDistanceM1.Text == "0")
                        {
                            TxtStep2TouchDistanceM1.Text = "";
                        }
                        TxtStep2KSTouchDistanceM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step2KneeSeperationatTouchdown"].ToString());
                        if (TxtStep2KSTouchDistanceM1.Text == "" || TxtStep2KSTouchDistanceM1.Text == "0")
                        {
                            TxtStep2KSTouchDistanceM1.Text = "";
                        }

                        //TrunkTd

                        //TrunkTd
                        TxtStep2TrunkTouchdownAngleM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step2TrunkTouchdownAngle"].ToString());
                        if (TxtStep1KSTouchDistanceM1.Text == "" || TxtStep2TrunkTouchdownAngleM1.Text == "0")
                        {
                            TxtStep2TrunkTouchdownAngleM1.Text = "";
                        }
                        //TrunkTO
                        TxtStep2TrunkTakeoffAngleM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step2TrunkTakeoffAngle"].ToString());
                        if (TxtStep2TrunkTakeoffAngleM1.Text == "" || TxtStep2TrunkTakeoffAngleM1.Text == "0")
                        {
                            TxtStep2TrunkTakeoffAngleM1.Text = "";
                        }








                        TxtStep2ULFullExtensionM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step2ULAtFullExtension"].ToString());
                        if (TxtStep2ULFullExtensionM1.Text == "" || TxtStep2ULFullExtensionM1.Text == "0")
                        {
                            TxtStep2ULFullExtensionM1.Text = "";
                        }
                        TxtStep2LLTakeOffM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step2LLAtTakeoff"].ToString());
                        if (TxtStep2LLTakeOffM1.Text == "" || TxtStep2LLTakeOffM1.Text == "0")
                        {
                            TxtStep2LLTakeOffM1.Text = "";
                        }
                        TxtStep2LLFullFlexionM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step2LLAtFullFlexion"].ToString());
                        if (TxtStep2LLFullFlexionM1.Text == "" || TxtStep2LLFullFlexionM1.Text == "0")
                        {
                            TxtStep2LLFullFlexionM1.Text = "";
                        }
                        //TxtStep2LLAnkleCrossM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2LLAtatAnkleCross"].ToString());
                        //if (TxtStep2LLAnkleCrossM1.Text == "" || TxtStep2LLAnkleCrossM1.Text == "0")
                        //{
                        //    TxtStep2LLAnkleCrossM1.Text = "";
                        //}
                        TxtStep2ULFullFlexionM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step2ULAtFullFlexion"].ToString());
                        if (TxtStep2ULFullFlexionM1.Text == "" || TxtStep2ULFullFlexionM1.Text == "0")
                        {
                            TxtStep2ULFullFlexionM1.Text = "";
                        }

                        //Step3

                        TxtStep3GroundTimeM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step3GroundTime"].ToString());
                        if (TxtStep3GroundTimeM1.Text == "" || TxtStep3GroundTimeM1.Text == "0")
                        {
                            TxtStep3GroundTimeM1.Text = "";
                        }
                        TxtStep3AirTimeM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step3AirTime"].ToString());
                        if (TxtStep3AirTimeM1.Text == "" || TxtStep3AirTimeM1.Text == "0")
                        {
                            TxtStep3AirTimeM1.Text = "";
                        }
                        //TxtStep3UlFlexTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3UlFlexTime"].ToString());
                        //if (TxtStep3UlFlexTimeM1.Text == "" || TxtStep3UlFlexTimeM1.Text == "0")
                        //{
                        //    TxtStep3UlFlexTimeM1.Text = "";
                        //}
                        //TxtStep3StrideRateM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3StrideRate"].ToString());
                        //if (TxtStep3StrideRateI.Text == "" || TxtStep3StrideRateM1.Text == "0")
                        //{
                        //    TxtStep3StrideRateM1.Text = "";
                        //}
                        TxtStep3StrideLengthM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step3StrideLength"].ToString());
                        if (TxtStep3StrideLengthM1.Text == "" || TxtStep3StrideLengthM1.Text == "0")
                        {
                            TxtStep3StrideLengthM1.Text = "";
                        }
                        TxtStep3TouchDistanceM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step3TouchdownDistance"].ToString());
                        if (TxtStep2TouchDistanceM1.Text == "" || TxtStep3TouchDistanceM1.Text == "0")
                        {
                            TxtStep3TouchDistanceM1.Text = "";
                        }
                        TxtStep3KSTouchDistanceM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step3KneeSeperationatTouchdown"].ToString());
                        if (TxtStep3KSTouchDistanceM1.Text == "" || TxtStep3KSTouchDistanceM1.Text == "0")
                        {
                            TxtStep3KSTouchDistanceM1.Text = "";
                        }

                        //TrunkTd
                        //TrunkTd
                        TxtStep3TrunkTouchdownAngleM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step3TrunkTouchdownAngle"].ToString());
                        if (TxtStep3KSTouchDistanceM1.Text == "" || TxtStep3TrunkTouchdownAngleM1.Text == "0")
                        {
                            TxtStep3TrunkTouchdownAngleM1.Text = "";
                        }
                        //TrunkTO
                        TxtStep3TrunkTakeoffAngleM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step3TrunkTakeoffAngle"].ToString());
                        if (TxtStep3TrunkTakeoffAngleM1.Text == "" || TxtStep3TrunkTakeoffAngleM1.Text == "0")
                        {
                            TxtStep3TrunkTakeoffAngleM1.Text = "";
                        }






                        TxtStep3ULFullExtensionM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step3ULAtFullExtension"].ToString());
                        if (TxtStep3ULFullExtensionM1.Text == "" || TxtStep3ULFullExtensionM1.Text == "0")
                        {
                            TxtStep3ULFullExtensionM1.Text = "";
                        }
                        TxtStep3LLTakeOffM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step3LLAtTakeoff"].ToString());
                        if (TxtStep3LLTakeOffM1.Text == "" || TxtStep3LLTakeOffM1.Text == "0")
                        {
                            TxtStep3LLTakeOffM1.Text = "";
                        }
                        TxtStep3LLFullFlexionM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step3LLAtFullFlexion"].ToString());
                        if (TxtStep3LLFullFlexionM1.Text == "" || TxtStep3LLFullFlexionM1.Text == "0")
                        {
                            TxtStep3LLFullFlexionM1.Text = "";
                        }
                        //TxtStep3LLAnkleCrossM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3LLAtatAnkleCross"].ToString());
                        //if (TxtStep3LLAnkleCrossM1.Text == "" || TxtStep3LLAnkleCrossM1.Text == "0")
                        //{
                        //    TxtStep3LLAnkleCrossM1.Text = "";
                        //}
                        TxtStep3ULFullFlexionM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["Step3ULAtFullFlexion"].ToString());
                        if (TxtStep3ULFullFlexionM1.Text == "" || TxtStep3ULFullFlexionM1.Text == "0")
                        {
                            TxtStep3ULFullFlexionM1.Text = "";
                        }

                        //IntoHurdleSteps

                        TxtIntoHurdleTouchDistanceM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["SetTouchdownDistanceIntoTheHurdle"].ToString());
                        if (TxtIntoHurdleTouchDistanceM1.Text == "" || TxtIntoHurdleTouchDistanceM1.Text == "0")
                        {
                            TxtIntoHurdleTouchDistanceM1.Text = "";
                        }
                        TxtIntoHurdleKSTouchDistanceM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["SetKneeSeperationatTouchdownIntoTheHurdle"].ToString());
                        if (TxtIntoHurdleKSTouchDistanceM1.Text == "" || TxtIntoHurdleKSTouchDistanceM1.Text == "0")
                        {
                            TxtIntoHurdleKSTouchDistanceM1.Text = "";
                        }


                        //TrunkTD

                        TxtIntoHurdleTrunkTouchdownAngleM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["SetTrunkTouchdownAngleIntoTheHurdle"].ToString());
                        if (TxtIntoHurdleTrunkTouchdownAngleM1.Text == "" || TxtIntoHurdleTrunkTouchdownAngleM1.Text == "0")
                        {
                            TxtIntoHurdleTrunkTouchdownAngleM1.Text = "";
                        }





                        TxtIntoHurdleLLTouchDistanceM1.Text = Convert.ToString(dsmodelData.Tables[1].Rows[0]["SetLLAtTouchdownIntoTheHurdle"].ToString());
                        if (TxtIntoHurdleLLTouchDistanceM1.Text == "" || TxtIntoHurdleLLTouchDistanceM1.Text == "0")
                        {
                            TxtIntoHurdleLLTouchDistanceM1.Text = "";
                        }
                        #endregion[model Data]


                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }

    //chk
    private string setVariableData(string xmlValue)
    {
        string vairableValue = xmlValue;
        if (vairableValue == "" || vairableValue == "0.000" || vairableValue == "0")
        {
            vairableValue = "";
        }
        return vairableValue;
    }
    List<MissingVariable> missingVariable = new List<MissingVariable>();
    public void GetAllHurdleStepsAthleteDataInitialNdCorrent(int LessonId)
    {
        if (ds != null)
        {
            ds = sae.GetAllHurdleStepsAthletesData(LessonId);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow drVariable = ds.Tables[0].Rows[0];
                    #region[initial Data]

                    TxtHurdleDistanceBtweenI.Text = setVariableData(drVariable["SetDistanceBetweenHurdleSteps"].ToString());
                    TxtHurdleDistanceIntoI.Text = setVariableData(drVariable["SetDistanceIntoHurdleSteps"].ToString());
                    TxtHurdleDistanceOffI.Text = setVariableData(drVariable["SetDistanceOffHurdleSteps"].ToString());
                    TxtStep1GroundTimeI.Text = setVariableData(drVariable["Step1GroundTime"].ToString());
                    TxtStep1AirTimeI.Text = setVariableData(drVariable["Step1AirTime"].ToString());
                    TxtStep1StrideLengthI.Text = setVariableData(drVariable["Step1StrideLength"].ToString());
                    TxtStep1TouchDistanceI.Text = setVariableData(drVariable["Step1TouchdownDistance"].ToString());
                    TxtStep1KSTouchDistanceI.Text = setVariableData(drVariable["Step1KneeSeperationatTouchdown"].ToString());
                    TxtStep1TrunkTouchdownAngleI.Text = setVariableData(drVariable["Step1TrunkTouchdownAngle"].ToString());
                    TxtStep1TrunkTakeoffAngleI.Text = setVariableData(drVariable["Step1TrunkTakeoffAngle"].ToString());
                    TxtStep1ULFullExtensionI.Text = setVariableData(drVariable["Step1ULAtFullExtension"].ToString());
                    TxtStep1LLTakeOffI.Text = setVariableData(drVariable["Step1LLAtTakeoff"].ToString());
                    TxtStep1ULFullFlexionI.Text = setVariableData(drVariable["Step1ULAtFullFlexion"].ToString());
                    TxtStep2GroundTimeI.Text = setVariableData(drVariable["Step2GroundTime"].ToString());
                    TxtStep2AirTimeI.Text = setVariableData(drVariable["Step2AirTime"].ToString());
                    TxtStep2StrideLengthI.Text = setVariableData(drVariable["Step2StrideLength"].ToString());
                    TxtStep2TouchDistanceI.Text = setVariableData(drVariable["Step2TouchdownDistance"].ToString());
                    TxtStep2KSTouchDistanceI.Text = setVariableData(drVariable["Step2KneeSeperationatTouchdown"].ToString());
                    TxtStep2TrunkTouchdownAngleI.Text = setVariableData(drVariable["Step2TrunkTouchdownAngle"].ToString());
                    TxtStep2TrunkTakeoffAngleI.Text = setVariableData(drVariable["Step2TrunkTakeoffAngle"].ToString());
                    TxtStep2ULFullExtensionI.Text = setVariableData(drVariable["Step2ULAtFullExtension"].ToString());
                    TxtStep2LLTakeOffI.Text = setVariableData(drVariable["Step2LLAtTakeoff"].ToString());
                    TxtStep2LLFullFlexionI.Text = setVariableData(drVariable["Step2LLAtFullFlexion"].ToString());
                    TxtStep2ULFullFlexionI.Text = setVariableData(drVariable["Step2ULAtFullFlexion"].ToString());
                    TxtStep3GroundTimeI.Text = setVariableData(drVariable["Step3GroundTime"].ToString());
                    TxtStep3AirTimeI.Text = setVariableData(drVariable["Step3AirTime"].ToString());
                    TxtStep3StrideLengthI.Text = setVariableData(drVariable["Step3StrideLength"].ToString());
                    TxtStep3TouchDistanceI.Text = setVariableData(drVariable["Step3TouchdownDistance"].ToString());
                    TxtStep3KSTouchDistanceI.Text = setVariableData(drVariable["Step3KneeSeperationatTouchdown"].ToString());
                    TxtStep3TrunkTouchdownAngleI.Text = setVariableData(drVariable["Step3TrunkTouchdownAngle"].ToString());
                    TxtStep3TrunkTakeoffAngleI.Text = setVariableData(drVariable["Step3TrunkTakeoffAngle"].ToString());
                    TxtStep3ULFullExtensionI.Text = setVariableData(drVariable["Step3ULAtFullExtension"].ToString());
                    TxtStep3LLTakeOffI.Text = setVariableData(drVariable["Step3LLAtTakeoff"].ToString());
                    TxtStep3LLFullFlexionI.Text = setVariableData(drVariable["Step3LLAtFullFlexion"].ToString());
                    TxtStep3ULFullFlexionI.Text = setVariableData(drVariable["Step3ULAtFullFlexion"].ToString());
                    TxtIntoHurdleTouchDistanceI.Text = setVariableData(drVariable["SetTouchdownDistanceIntoTheHurdle"].ToString());
                    TxtIntoHurdleKSTouchDistanceI.Text = setVariableData(drVariable["SetKneeSeperationatTouchdownIntoTheHurdle"].ToString());
                    TxtIntoHurdleTrunkTouchdownAngleI.Text = setVariableData(drVariable["SetTrunkTouchdownAngleIntoTheHurdle"].ToString());
                    TxtIntoHurdleLLTouchDistanceI.Text = setVariableData(drVariable["SetLLAtTouchdownIntoTheHurdle"].ToString());

                    #endregion[initial Data]
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    DataRow drVariable = ds.Tables[2].Rows[0];
                    #region[current Data]
                    TxtHurdleDistanceBtweenF.Text = setVariableData(drVariable["SetDistanceBetweenHurdleSteps"].ToString());
                    TxtHurdleDistanceIntoF.Text = setVariableData(drVariable["SetDistanceIntoHurdleSteps"].ToString());
                    TxtHurdleDistanceOffF.Text = setVariableData(drVariable["SetDistanceOffHurdleSteps"].ToString());
                    TxtStep1GroundTimeF.Text = setVariableData(drVariable["Step1GroundTime"].ToString());
                    TxtStep1AirTimeF.Text = setVariableData(drVariable["Step1AirTime"].ToString());
                    TxtStep1StrideLengthF.Text = setVariableData(drVariable["Step1StrideLength"].ToString());
                    TxtStep1TouchDistanceF.Text = setVariableData(drVariable["Step1TouchdownDistance"].ToString());
                    TxtStep1KSTouchDistanceF.Text = setVariableData(drVariable["Step1KneeSeperationatTouchdown"].ToString());
                    TxtStep1TrunkTouchdownAngleF.Text = setVariableData(drVariable["Step1TrunkTouchdownAngle"].ToString());
                    TxtStep1TrunkTakeoffAngleF.Text = setVariableData(drVariable["Step1TrunkTakeoffAngle"].ToString());
                    TxtStep1ULFullExtensionF.Text = setVariableData(drVariable["Step1ULAtFullExtension"].ToString());
                    TxtStep1LLTakeOffF.Text = setVariableData(drVariable["Step1LLAtTakeoff"].ToString());
                    TxtStep1ULFullFlexionF.Text = setVariableData(drVariable["Step1ULAtFullFlexion"].ToString());
                    TxtStep2GroundTimeF.Text = setVariableData(drVariable["Step2GroundTime"].ToString());
                    TxtStep2AirTimeF.Text = setVariableData(drVariable["Step2AirTime"].ToString());
                    TxtStep2StrideLengthF.Text = setVariableData(drVariable["Step2StrideLength"].ToString());
                    TxtStep2TouchDistanceF.Text = setVariableData(drVariable["Step2TouchdownDistance"].ToString());
                    TxtStep2KSTouchDistanceF.Text = setVariableData(drVariable["Step2KneeSeperationatTouchdown"].ToString());
                    TxtStep2TrunkTouchdownAngleF.Text = setVariableData(drVariable["Step2TrunkTouchdownAngle"].ToString());
                    TxtStep2TrunkTakeoffAngleF.Text = setVariableData(drVariable["Step2TrunkTakeoffAngle"].ToString());
                    TxtStep2ULFullExtensionF.Text = setVariableData(drVariable["Step2ULAtFullExtension"].ToString());
                    TxtStep2LLTakeOffF.Text = setVariableData(drVariable["Step2LLAtTakeoff"].ToString());
                    TxtStep2LLFullFlexionF.Text = setVariableData(drVariable["Step2LLAtFullFlexion"].ToString());
                    TxtStep2ULFullFlexionF.Text = setVariableData(drVariable["Step2ULAtFullFlexion"].ToString());
                    TxtStep3GroundTimeF.Text = setVariableData(drVariable["Step3GroundTime"].ToString());
                    TxtStep3AirTimeF.Text = setVariableData(drVariable["Step3AirTime"].ToString());
                    TxtStep3StrideLengthF.Text = setVariableData(drVariable["Step3StrideLength"].ToString());
                    TxtStep3TouchDistanceF.Text = setVariableData(drVariable["Step3TouchdownDistance"].ToString());
                    TxtStep3KSTouchDistanceF.Text = setVariableData(drVariable["Step3KneeSeperationatTouchdown"].ToString());
                    TxtStep3TrunkTouchdownAngleF.Text = setVariableData(drVariable["Step3TrunkTouchdownAngle"].ToString());
                    TxtStep3TrunkTakeoffAngleF.Text = setVariableData(drVariable["Step3TrunkTakeoffAngle"].ToString());
                    TxtStep3ULFullExtensionF.Text = setVariableData(drVariable["Step3ULAtFullExtension"].ToString());
                    TxtStep3LLTakeOffF.Text = setVariableData(drVariable["Step3LLAtTakeoff"].ToString());
                    TxtStep3LLFullFlexionF.Text = setVariableData(drVariable["Step3LLAtFullFlexion"].ToString());
                    TxtStep3ULFullFlexionF.Text = setVariableData(drVariable["Step3ULAtFullFlexion"].ToString());
                    TxtIntoHurdleTouchDistanceF.Text = setVariableData(drVariable["SetTouchdownDistanceIntoTheHurdle"].ToString());
                    TxtIntoHurdleKSTouchDistanceF.Text = setVariableData(drVariable["SetKneeSeperationatTouchdownIntoTheHurdle"].ToString());
                    TxtIntoHurdleTrunkTouchdownAngleF.Text = setVariableData(drVariable["SetTrunkTouchdownAngleIntoTheHurdle"].ToString());
                    TxtIntoHurdleLLTouchDistanceF.Text = setVariableData(drVariable["SetLLAtTouchdownIntoTheHurdle"].ToString());

                    #endregion[current Data]
                }
            }
        }
    }

    public void GetAllHurdleStepsAthleteData(int LessonId)
    {
        if (ds != null)
        {
            int initialcnt = 0;
            int modelCnt = 0;
            int CurrentCnt = 0;

            ds = sae.GetAllHurdleStepsAthletesData(LessonId);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow drVariable = ds.Tables[0].Rows[0];
                    #region[initial Data]

                    TxtHurdleDistanceBtweenI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetDistanceBetweenHurdleSteps"].ToString());
                    if (TxtHurdleDistanceBtweenI.Text == "" || TxtHurdleDistanceBtweenI.Text == "0" || TxtHurdleDistanceBtweenI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "SetDistanceBetweenHurdleSteps";
                        missingVariable.Add(misv);
                        TxtHurdleDistanceBtweenI.Text = "";
                        initialcnt++;
                    }

                    TxtHurdleDistanceIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetDistanceIntoHurdleSteps"].ToString());
                    if (TxtHurdleDistanceIntoI.Text == "" || TxtHurdleDistanceIntoI.Text == "0" || TxtHurdleDistanceIntoI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "SetDistanceIntoHurdleSteps";
                        missingVariable.Add(misv);
                        TxtHurdleDistanceIntoI.Text = "";
                        initialcnt++;
                    }
                    TxtHurdleDistanceOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetDistanceOffHurdleSteps"].ToString());
                    if (TxtHurdleDistanceOffI.Text == "" || TxtHurdleDistanceOffI.Text == "0" || TxtHurdleDistanceOffI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "SetDistanceOffHurdleSteps";
                        missingVariable.Add(misv);
                        TxtHurdleDistanceOffI.Text = "";
                        initialcnt++;
                    }
                    //TxtHurdleVelocityI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Velocity"].ToString());
                    //if (TxtHurdleVelocityI.Text == "" || TxtHurdleVelocityI.Text == "0")
                    //{
                    //    TxtHurdleVelocityI.Text = "";
                    //}
                    //step 1
                    TxtStep1GroundTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1GroundTime"].ToString());
                    if (TxtStep1GroundTimeI.Text == "" || TxtStep1GroundTimeI.Text == "0" || TxtStep1GroundTimeI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step1GroundTime";
                        missingVariable.Add(misv);
                        TxtStep1GroundTimeI.Text = "";
                        initialcnt++;
                    }
                    TxtStep1AirTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1AirTime"].ToString());
                    if (TxtStep1AirTimeI.Text == "" || TxtStep1AirTimeI.Text == "0" || TxtStep1AirTimeI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step1AirTime";
                        missingVariable.Add(misv);
                        TxtStep1AirTimeI.Text = "";
                        initialcnt++;
                    }
                    //TxtStep1UlFlexTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1UlFlexTime"].ToString());
                    //if (TxtStep1UlFlexTimeI.Text == "" || TxtStep1UlFlexTimeI.Text == "0")
                    //{
                    //    TxtStep1UlFlexTimeI.Text = "";//[Step1 Stride Rate]
                    //}
                    //TxtStep1StrideRateI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1 Stride Rate"].ToString());
                    //if (TxtStep1StrideRateI.Text == "" || TxtStep1StrideRateI.Text == "0.000")
                    //{
                    //    TxtStep1StrideRateI.Text = "";
                    //}
                    TxtStep1StrideLengthI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1StrideLength"].ToString());
                    if (TxtStep1StrideLengthI.Text == "" || TxtStep1StrideLengthI.Text == "0" || TxtStep1StrideLengthI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step1StrideLength";
                        missingVariable.Add(misv);
                        TxtStep1StrideLengthI.Text = "";
                        initialcnt++;
                    }
                    TxtStep1TouchDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1TouchdownDistance"].ToString());
                    if (TxtStep1TouchDistanceI.Text == "" || TxtStep1TouchDistanceI.Text == "0" || TxtStep1TouchDistanceI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step1TouchdownDistance";
                        missingVariable.Add(misv);
                        TxtStep1TouchDistanceI.Text = "";
                        initialcnt++;
                    }
                    TxtStep1KSTouchDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1KneeSeperationatTouchdown"].ToString());
                    if (TxtStep1KSTouchDistanceI.Text == "" || TxtStep1KSTouchDistanceI.Text == "0" || TxtStep1KSTouchDistanceI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step1KneeSeperationatTouchdown";
                        missingVariable.Add(misv);
                        TxtStep1KSTouchDistanceI.Text = "";
                        initialcnt++;
                    }

                    //TrunkTd

                    TxtStep1TrunkTouchdownAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1TrunkTouchdownAngle"].ToString());
                    if (TxtStep1TrunkTouchdownAngleI.Text == "" || TxtStep1TrunkTouchdownAngleI.Text == "0" || TxtStep1TrunkTouchdownAngleI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step1TrunkTouchdownAngle";
                        missingVariable.Add(misv);
                        TxtStep1TrunkTouchdownAngleI.Text = "";
                        initialcnt++;
                    }
                    //TrunkTO
                    TxtStep1TrunkTakeoffAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1TrunkTakeoffAngle"].ToString());
                    if (TxtStep1TrunkTakeoffAngleI.Text == "" || TxtStep1TrunkTakeoffAngleI.Text == "0" | TxtStep1TrunkTakeoffAngleI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step1TrunkTakeoffAngle";
                        missingVariable.Add(misv);
                        TxtStep1TrunkTakeoffAngleI.Text = "";
                        initialcnt++;
                    }

                    TxtStep1ULFullExtensionI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1ULAtFullExtension"].ToString());
                    if (TxtStep1ULFullExtensionI.Text == "" || TxtStep1ULFullExtensionI.Text == "0" || TxtStep1ULFullExtensionI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step1ULAtFullExtension";
                        missingVariable.Add(misv);
                        TxtStep1ULFullExtensionI.Text = "";
                        initialcnt++;
                    }

                    TxtStep1LLTakeOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1LLAtTakeoff"].ToString());
                    if (TxtStep1LLTakeOffI.Text == "" || TxtStep1LLTakeOffI.Text == "0" || TxtStep1LLTakeOffI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step1LLAtTakeoff";
                        missingVariable.Add(misv);
                        TxtStep1LLTakeOffI.Text = "";
                        initialcnt++;
                    }
                    TxtStep1ULFullFlexionI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1ULAtFullFlexion"].ToString());
                    if (TxtStep1ULFullFlexionI.Text == "" || TxtStep1ULFullFlexionI.Text == "0" || TxtStep1ULFullFlexionI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step1ULAtFullFlexion";
                        missingVariable.Add(misv);
                        TxtStep1ULFullFlexionI.Text = "";
                        initialcnt++;
                    }
                    //step 2

                    TxtStep2GroundTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2GroundTime"].ToString());
                    if (TxtStep2GroundTimeI.Text == "" || TxtStep2GroundTimeI.Text == "0" || TxtStep2GroundTimeI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step2GroundTime";
                        missingVariable.Add(misv);
                        TxtStep2GroundTimeI.Text = "";
                        initialcnt++;
                    }
                    TxtStep2AirTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2AirTime"].ToString());
                    if (TxtStep2AirTimeI.Text == "" || TxtStep2AirTimeI.Text == "0" || TxtStep2AirTimeI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step2AirTime";
                        missingVariable.Add(misv);
                        TxtStep2AirTimeI.Text = "";
                        initialcnt++;
                    }
                    //TxtStep2UlFlexTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2UlFlexTime"].ToString());
                    //if (TxtStep2UlFlexTimeI.Text == "" || TxtStep2UlFlexTimeI.Text == "0")
                    //{
                    //    TxtStep2UlFlexTimeI.Text = "";
                    //}
                    //TxtStep2StrideRateI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2 Stride Rate"].ToString());
                    //if (TxtStep2StrideRateI.Text == "" || TxtStep2StrideRateI.Text == "0")
                    //{
                    //    TxtStep2StrideRateI.Text = "";
                    //}
                    TxtStep2StrideLengthI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2StrideLength"].ToString());
                    if (TxtStep2StrideLengthI.Text == "" || TxtStep2StrideLengthI.Text == "0" || TxtStep2StrideLengthI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step2StrideLength";
                        missingVariable.Add(misv);
                        TxtStep2StrideLengthI.Text = "";
                        initialcnt++;
                    }
                    TxtStep2TouchDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2TouchdownDistance"].ToString());
                    if (TxtStep2TouchDistanceI.Text == "" || TxtStep2TouchDistanceI.Text == "0" || TxtStep2TouchDistanceI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step2TouchdownDistance";
                        missingVariable.Add(misv);
                        TxtStep2TouchDistanceI.Text = "";
                        initialcnt++;
                    }
                    TxtStep2KSTouchDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2KneeSeperationatTouchdown"].ToString());
                    if (TxtStep2KSTouchDistanceI.Text == "" || TxtStep2KSTouchDistanceI.Text == "0" || TxtStep2KSTouchDistanceI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step2KneeSeperationatTouchdown";
                        missingVariable.Add(misv);
                        TxtStep2KSTouchDistanceI.Text = "";
                        initialcnt++;
                    }

                    //TrunkTd
                    TxtStep2TrunkTouchdownAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2TrunkTouchdownAngle"].ToString());
                    if (TxtStep2TrunkTouchdownAngleI.Text == "" || TxtStep2TrunkTouchdownAngleI.Text == "0" || TxtStep2TrunkTouchdownAngleI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step2TrunkTouchdownAngle";
                        missingVariable.Add(misv);
                        TxtStep2TrunkTouchdownAngleI.Text = "";
                        initialcnt++;
                    }
                    //TrunkTO
                    TxtStep2TrunkTakeoffAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2TrunkTakeoffAngle"].ToString());
                    if (TxtStep2TrunkTakeoffAngleI.Text == "" || TxtStep2TrunkTakeoffAngleI.Text == "0" || TxtStep2TrunkTakeoffAngleI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step2TrunkTakeoffAngle";
                        missingVariable.Add(misv);
                        TxtStep2TrunkTakeoffAngleI.Text = "";
                        initialcnt++;
                    }
                    TxtStep2ULFullExtensionI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2ULAtFullExtension"].ToString());
                    if (TxtStep2ULFullExtensionI.Text == "" || TxtStep2ULFullExtensionI.Text == "0" || TxtStep2ULFullExtensionI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step2ULAtFullExtension";
                        missingVariable.Add(misv);
                        TxtStep2ULFullExtensionI.Text = "";
                        initialcnt++;
                    }
                    TxtStep2LLTakeOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2LLAtTakeoff"].ToString());
                    if (TxtStep2LLTakeOffI.Text == "" || TxtStep2LLTakeOffI.Text == "0" || TxtStep2LLTakeOffI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step2LLAtTakeoff";
                        missingVariable.Add(misv);
                        TxtStep2LLTakeOffI.Text = "";
                        initialcnt++;
                    }
                    TxtStep2LLFullFlexionI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2LLAtFullFlexion"].ToString());
                    if (TxtStep2LLFullFlexionI.Text == "" || TxtStep2LLFullFlexionI.Text == "0" || TxtStep2LLFullFlexionI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step2LLAtFullFlexion";
                        missingVariable.Add(misv);
                        TxtStep2LLFullFlexionI.Text = "";
                        initialcnt++;
                    }
                    //TxtStep2LLAnkleCrossI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2LLAtatAnkleCross"].ToString());
                    //if (TxtStep2LLAnkleCrossI.Text == "" || TxtStep2LLAnkleCrossI.Text == "0")
                    //{
                    //    TxtStep2LLAnkleCrossI.Text = "";
                    //}
                    TxtStep2ULFullFlexionI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2ULAtFullFlexion"].ToString());
                    if (TxtStep2ULFullFlexionI.Text == "" || TxtStep2ULFullFlexionI.Text == "0" || TxtStep2ULFullFlexionI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step2ULAtFullFlexion";
                        missingVariable.Add(misv);
                        TxtStep2ULFullFlexionI.Text = "";
                        initialcnt++;
                    }

                    //Step3

                    TxtStep3GroundTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3GroundTime"].ToString());
                    if (TxtStep3GroundTimeI.Text == "" || TxtStep3GroundTimeI.Text == "0" || TxtStep3GroundTimeI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step3GroundTime";
                        missingVariable.Add(misv);
                        TxtStep3GroundTimeI.Text = "";
                        initialcnt++;
                    }
                    TxtStep3AirTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3AirTime"].ToString());
                    if (TxtStep3AirTimeI.Text == "" || TxtStep3AirTimeI.Text == "0" || TxtStep3AirTimeI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step3AirTime";
                        missingVariable.Add(misv);
                        TxtStep3AirTimeI.Text = "";
                        initialcnt++;
                    }
                    //TxtStep3UlFlexTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3UlFlexTime"].ToString());
                    //if (TxtStep3UlFlexTimeI.Text == "" || TxtStep3UlFlexTimeI.Text == "0")
                    //{
                    //    TxtStep3UlFlexTimeI.Text = "";
                    //}
                    //TxtStep3StrideRateI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3 Stride Rate"].ToString());
                    //if (TxtStep3StrideRateI.Text == "" || TxtStep3StrideRateI.Text == "0")
                    //{
                    //    TxtStep3StrideRateI.Text = "";
                    //}
                    TxtStep3StrideLengthI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3StrideLength"].ToString());
                    if (TxtStep3StrideLengthI.Text == "" || TxtStep3StrideLengthI.Text == "0" || TxtStep3StrideLengthI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step3StrideLength";
                        missingVariable.Add(misv);
                        TxtStep3StrideLengthI.Text = "";
                        initialcnt++;
                    }
                    TxtStep3TouchDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3TouchdownDistance"].ToString());
                    if (TxtStep3TouchDistanceI.Text == "" || TxtStep3TouchDistanceI.Text == "0" || TxtStep3TouchDistanceI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step3TouchdownDistance";
                        missingVariable.Add(misv);
                        TxtStep3TouchDistanceI.Text = "";
                        initialcnt++;
                    }
                    TxtStep3KSTouchDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3KneeSeperationatTouchdown"].ToString());
                    if (TxtStep3KSTouchDistanceI.Text == "" || TxtStep3KSTouchDistanceI.Text == "0" || TxtStep3KSTouchDistanceI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step3KneeSeperationatTouchdown";
                        missingVariable.Add(misv);
                        TxtStep3KSTouchDistanceI.Text = "";
                        initialcnt++;
                    }

                    //TrunkTd

                    //TrunkTd
                    TxtStep3TrunkTouchdownAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3TrunkTouchdownAngle"].ToString());
                    if (TxtStep3TrunkTouchdownAngleI.Text == "" || TxtStep3TrunkTouchdownAngleI.Text == "0" || TxtStep3TrunkTouchdownAngleI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step3TrunkTouchdownAngle";
                        missingVariable.Add(misv);
                        TxtStep3TrunkTouchdownAngleI.Text = "";
                        initialcnt++;
                    }
                    //TrunkTO

                    TxtStep3TrunkTakeoffAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3TrunkTakeoffAngle"].ToString());
                    if (TxtStep3TrunkTakeoffAngleI.Text == "" || TxtStep3TrunkTakeoffAngleI.Text == "0" || TxtStep3TrunkTakeoffAngleI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step3TrunkTakeoffAngle";
                        missingVariable.Add(misv);
                        TxtStep3TrunkTakeoffAngleI.Text = "";
                        initialcnt++;
                    }



                    TxtStep3ULFullExtensionI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3ULAtFullExtension"].ToString());
                    if (TxtStep2ULFullExtensionI.Text == "" || TxtStep3ULFullExtensionI.Text == "0" || TxtStep3ULFullExtensionI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step3ULAtFullExtension";
                        missingVariable.Add(misv);
                        TxtStep3ULFullExtensionI.Text = "";
                        initialcnt++;
                    }
                    TxtStep3LLTakeOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3LLAtTakeoff"].ToString());
                    if (TxtStep3LLTakeOffI.Text == "" || TxtStep3LLTakeOffI.Text == "0" || TxtStep3LLTakeOffI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step3LLAtTakeoff";
                        missingVariable.Add(misv);
                        TxtStep3LLTakeOffI.Text = "";
                        initialcnt++;
                    }
                    TxtStep3LLFullFlexionI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3LLAtFullFlexion"].ToString());
                    if (TxtStep3LLFullFlexionI.Text == "" || TxtStep3LLFullFlexionI.Text == "0" || TxtStep3LLFullFlexionI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step3LLAtFullFlexion";
                        missingVariable.Add(misv);
                        TxtStep3LLFullFlexionI.Text = "";
                        initialcnt++;
                    }
                    //TxtStep3LLAnkleCrossI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3LLAtatAnkleCross"].ToString());
                    //if (TxtStep3LLAnkleCrossI.Text == "" || TxtStep3LLAnkleCrossI.Text == "0")
                    //{
                    //    TxtStep3LLAnkleCrossI.Text = "";
                    //}
                    TxtStep3ULFullFlexionI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3ULAtFullFlexion"].ToString());
                    if (TxtStep3ULFullFlexionI.Text == "" || TxtStep3ULFullFlexionI.Text == "0" || TxtStep3ULFullFlexionI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "Step3ULAtFullFlexion";
                        missingVariable.Add(misv);
                        TxtStep3ULFullFlexionI.Text = "";
                        initialcnt++;
                    }

                    //IntoHurdleSteps

                    TxtIntoHurdleTouchDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetKneeSeperationatTouchdownIntoTheHurdle"].ToString());
                    if (TxtIntoHurdleTouchDistanceI.Text == "" || TxtIntoHurdleTouchDistanceI.Text == "0.00" || TxtIntoHurdleTouchDistanceI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "SetKneeSeperationatTouchdownIntoTheHurdle";
                        missingVariable.Add(misv);
                        TxtIntoHurdleTouchDistanceI.Text = "";
                        initialcnt++;
                    }
                    TxtIntoHurdleKSTouchDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetKneeSeperationatTouchdownIntoTheHurdle"].ToString());
                    if (TxtIntoHurdleKSTouchDistanceI.Text == "" || TxtIntoHurdleKSTouchDistanceI.Text == "0.00" || TxtIntoHurdleKSTouchDistanceI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "SetKneeSeperationatTouchdownIntoTheHurdle";
                        missingVariable.Add(misv);
                        TxtIntoHurdleKSTouchDistanceI.Text = "";
                        initialcnt++;
                    }

                    TxtIntoHurdleTrunkTouchdownAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetTrunkTouchdownAngleIntoTheHurdle"].ToString());
                    if (TxtIntoHurdleTrunkTouchdownAngleI.Text == "" || TxtIntoHurdleTrunkTouchdownAngleI.Text == "0" || TxtIntoHurdleTrunkTouchdownAngleI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "SetTrunkTouchdownAngleIntoTheHurdle";
                        missingVariable.Add(misv);
                        TxtIntoHurdleTrunkTouchdownAngleI.Text = "";
                        initialcnt++;
                    }

                    //TrunkTD

                    TxtIntoHurdleLLTouchDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetLLAtTouchdownIntoTheHurdle"].ToString());
                    if (TxtIntoHurdleLLTouchDistanceI.Text == "" || TxtIntoHurdleLLTouchDistanceI.Text == "0" || TxtIntoHurdleLLTouchDistanceI.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        misv.variableName = "SetLLAtTouchdownIntoTheHurdle";
                        missingVariable.Add(misv);
                        TxtIntoHurdleLLTouchDistanceI.Text = "";
                        initialcnt++;
                    }

                    #endregion[initial Data]
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataRow drVariable = ds.Tables[1].Rows[0];
                    #region[model data]
                    TxtHurdleDistanceBtweenM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetDistanceBetweenHurdleSteps"].ToString());
                    if (TxtHurdleDistanceBtweenM1.Text == "" || TxtHurdleDistanceBtweenM1.Text == "0" || TxtHurdleDistanceBtweenM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "SetDistanceBetweenHurdleSteps";
                        missingVariable.Add(misv);
                        TxtHurdleDistanceBtweenM1.Text = "";
                        modelCnt++;
                    }
                    TxtHurdleDistanceIntoM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetDistanceIntoHurdleSteps"].ToString());
                    if (TxtHurdleDistanceIntoM1.Text == "" || TxtHurdleDistanceIntoM1.Text == "0" || TxtHurdleDistanceIntoM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "SetDistanceIntoHurdleSteps";
                        missingVariable.Add(misv);
                        TxtHurdleDistanceIntoM1.Text = "";
                        modelCnt++;
                    }
                    TxtHurdleDistanceOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetDistanceOffHurdleSteps"].ToString());
                    if (TxtHurdleDistanceOffM1.Text == "" || TxtHurdleDistanceOffM1.Text == "0" || TxtHurdleDistanceOffM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "SetDistanceOffHurdleSteps";
                        missingVariable.Add(misv);
                        TxtHurdleDistanceOffM1.Text = "";
                        modelCnt++;
                    }
                    //TxtHurdleVelocityM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Velocity"].ToString());
                    //if (TxtHurdleVelocityM1.Text == "" || TxtHurdleVelocityM1.Text == "0")
                    //{
                    //    TxtHurdleVelocityM1.Text = "";
                    //}
                    //step 1
                    TxtStep1GroundTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1GroundTime"].ToString());
                    if (TxtStep1GroundTimeM1.Text == "" || TxtStep1GroundTimeM1.Text == "0" || TxtStep1GroundTimeM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step1GroundTime";
                        missingVariable.Add(misv);
                        TxtStep1GroundTimeM1.Text = "";
                        modelCnt++;
                    }
                    TxtStep1AirTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1AirTime"].ToString());
                    if (TxtStep1AirTimeM1.Text == "" || TxtStep1AirTimeM1.Text == "0" || TxtStep1AirTimeM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step1AirTime";
                        missingVariable.Add(misv);
                        TxtStep1AirTimeM1.Text = "";
                        modelCnt++;
                    }
                    //TxtStep1UlFlexTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1UlFlexTime"].ToString());
                    //if (TxtStep1UlFlexTimeM1.Text == "" || TxtStep1UlFlexTimeM1.Text == "0")
                    //{
                    //    TxtStep1UlFlexTimeM1.Text = "";
                    //}
                    //TxtStep1StrideRateM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1 Stride Rate"].ToString());
                    //if (TxtStep1StrideRateI.Text == "" || TxtStep1StrideRateM1.Text == "0.000")
                    //{
                    //    TxtStep1StrideRateM1.Text = "";
                    //}
                    TxtStep1StrideLengthM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1StrideLength"].ToString());
                    if (TxtStep1StrideLengthM1.Text == "" || TxtStep1StrideLengthM1.Text == "0" || TxtStep1StrideLengthM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step1StrideLength";
                        missingVariable.Add(misv);
                        TxtStep1StrideLengthM1.Text = "";
                        modelCnt++;
                    }
                    TxtStep1TouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1TouchdownDistance"].ToString());
                    if (TxtStep1TouchDistanceM1.Text == "" || TxtStep1TouchDistanceM1.Text == "0" || TxtStep1TouchDistanceM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step1TouchdownDistance";
                        missingVariable.Add(misv);
                        TxtStep1TouchDistanceM1.Text = "";
                        modelCnt++;
                    }
                    TxtStep1KSTouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1KneeSeperationatTouchdown"].ToString());
                    if (TxtStep1KSTouchDistanceM1.Text == "" || TxtStep1KSTouchDistanceM1.Text == "0" || TxtStep1KSTouchDistanceM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step1KneeSeperationatTouchdown";
                        missingVariable.Add(misv);
                        TxtStep1KSTouchDistanceM1.Text = "";
                        modelCnt++;
                    }


                    //TrunkTd
                    TxtStep1TrunkTouchdownAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1TrunkTouchdownAngle"].ToString());
                    if (TxtStep1TrunkTouchdownAngleM1.Text == "" || TxtStep1TrunkTouchdownAngleM1.Text == "0" || TxtStep1TrunkTouchdownAngleM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step1TrunkTouchdownAngle";
                        missingVariable.Add(misv);
                        TxtStep1TrunkTouchdownAngleM1.Text = "";
                        modelCnt++;
                    }
                    //TrunkTO
                    TxtStep1TrunkTakeoffAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1TrunkTakeoffAngle"].ToString());
                    if (TxtStep1TrunkTakeoffAngleM1.Text == "" || TxtStep1TrunkTakeoffAngleM1.Text == "0" || TxtStep1TrunkTakeoffAngleM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step1TrunkTakeoffAngle";
                        missingVariable.Add(misv);
                        TxtStep1TrunkTakeoffAngleM1.Text = "";
                        modelCnt++;
                    }

                    TxtStep1ULFullExtensionM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1ULAtFullExtension"].ToString());
                    if (TxtStep1ULFullExtensionM1.Text == "" || TxtStep1ULFullExtensionM1.Text == "0" || TxtStep1ULFullExtensionM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step1ULAtFullExtension";
                        missingVariable.Add(misv);
                        TxtStep1ULFullExtensionM1.Text = "";
                        modelCnt++;
                    }

                    TxtStep1LLTakeOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1LLAtTakeoff"].ToString());
                    if (TxtStep1LLTakeOffM1.Text == "" || TxtStep1LLTakeOffM1.Text == "0" || TxtStep1LLTakeOffM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step1LLAtTakeoff";
                        missingVariable.Add(misv);
                        TxtStep1LLTakeOffM1.Text = "";
                        modelCnt++;
                    }
                    TxtStep1ULFullFlexionM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1ULAtFullFlexion"].ToString());
                    if (TxtStep1ULFullFlexionM1.Text == "" || TxtStep1ULFullFlexionM1.Text == "0" || TxtStep1ULFullFlexionM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step1ULAtFullFlexion";
                        missingVariable.Add(misv);
                        TxtStep1ULFullFlexionM1.Text = "";
                        modelCnt++;
                    }
                    //step 2

                    TxtStep2GroundTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2GroundTime"].ToString());
                    if (TxtStep2GroundTimeM1.Text == "" || TxtStep2GroundTimeM1.Text == "0" || TxtStep2GroundTimeM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step2GroundTime";
                        missingVariable.Add(misv);
                        TxtStep2GroundTimeM1.Text = "";
                        modelCnt++;
                    }
                    TxtStep2AirTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2AirTime"].ToString());
                    if (TxtStep2AirTimeM1.Text == "" || TxtStep2AirTimeM1.Text == "0" || TxtStep2AirTimeM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step2AirTime";
                        missingVariable.Add(misv);
                        TxtStep2AirTimeM1.Text = "";
                        modelCnt++;
                    }
                    //TxtStep2UlFlexTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2UlFlexTime"].ToString());
                    //if (TxtStep2UlFlexTimeM1.Text == "" || TxtStep2UlFlexTimeM1.Text == "0")
                    //{
                    //    TxtStep2UlFlexTimeM1.Text = "";
                    //}
                    //TxtStep2StrideRateM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2 Stride Rate"].ToString());
                    //if (TxtStep2StrideRateM1.Text == "" || TxtStep2StrideRateM1.Text == "0")
                    //{
                    //    TxtStep2StrideRateM1.Text = "";
                    //}
                    TxtStep2StrideLengthM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2StrideLength"].ToString());
                    if (TxtStep2StrideLengthM1.Text == "" || TxtStep2StrideLengthM1.Text == "0" || TxtStep2StrideLengthM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step2StrideLength";
                        missingVariable.Add(misv);
                        TxtStep2StrideLengthM1.Text = "";
                        modelCnt++;
                    }
                    TxtStep2TouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2TouchdownDistance"].ToString());
                    if (TxtStep2TouchDistanceM1.Text == "" || TxtStep2TouchDistanceM1.Text == "0" || TxtStep2TouchDistanceM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step2TouchdownDistance";
                        missingVariable.Add(misv);
                        TxtStep2TouchDistanceM1.Text = "";
                        modelCnt++;
                    }
                    TxtStep2KSTouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2KneeSeperationatTouchdown"].ToString());
                    if (TxtStep2KSTouchDistanceM1.Text == "" || TxtStep2KSTouchDistanceM1.Text == "0" || TxtStep2KSTouchDistanceM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step2KneeSeperationatTouchdown";
                        missingVariable.Add(misv);
                        TxtStep2KSTouchDistanceM1.Text = "";
                        modelCnt++;
                    }

                    //TrunkTd


                    //TrunkTd
                    TxtStep2TrunkTouchdownAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2TrunkTouchdownAngle"].ToString());
                    if (TxtStep2TrunkTouchdownAngleM1.Text == "" || TxtStep2TrunkTouchdownAngleM1.Text == "0" || TxtStep2TrunkTouchdownAngleM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step2TrunkTouchdownAngle";
                        missingVariable.Add(misv);
                        TxtStep2TrunkTouchdownAngleM1.Text = "";
                        modelCnt++;
                    }
                    //TrunkTO
                    TxtStep2TrunkTakeoffAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2TrunkTakeoffAngle"].ToString());
                    if (TxtStep2TrunkTakeoffAngleM1.Text == "" || TxtStep2TrunkTakeoffAngleM1.Text == "0" || TxtStep2TrunkTakeoffAngleM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step2TrunkTakeoffAngle";
                        missingVariable.Add(misv);
                        TxtStep2TrunkTakeoffAngleM1.Text = "";
                        modelCnt++;
                    }
                    TxtStep2ULFullExtensionM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2ULAtFullExtension"].ToString());
                    if (TxtStep2ULFullExtensionM1.Text == "" || TxtStep2ULFullExtensionM1.Text == "0" || TxtStep2ULFullExtensionM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step2ULAtFullExtension";
                        missingVariable.Add(misv);
                        TxtStep2ULFullExtensionM1.Text = "";
                        modelCnt++;
                    }
                    TxtStep2LLTakeOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2LLAtTakeoff"].ToString());
                    if (TxtStep2LLTakeOffM1.Text == "" || TxtStep2LLTakeOffM1.Text == "0" || TxtStep2LLTakeOffM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step2LLAtTakeoff";
                        missingVariable.Add(misv);
                        TxtStep2LLTakeOffM1.Text = "";
                        modelCnt++;
                    }
                    TxtStep2LLFullFlexionM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2LLAtFullFlexion"].ToString());
                    if (TxtStep2LLFullFlexionM1.Text == "" || TxtStep2LLFullFlexionM1.Text == "0" || TxtStep2LLFullFlexionM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step2LLAtFullFlexion";
                        missingVariable.Add(misv);
                        TxtStep2LLFullFlexionM1.Text = "";
                        modelCnt++;
                    }
                    //TxtStep2LLAnkleCrossM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2LLAtatAnkleCross"].ToString());
                    //if (TxtStep2LLAnkleCrossM1.Text == "" || TxtStep2LLAnkleCrossM1.Text == "0")
                    //{
                    //    TxtStep2LLAnkleCrossM1.Text = "";
                    //}
                    TxtStep2ULFullFlexionM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2ULAtFullFlexion"].ToString());
                    if (TxtStep2ULFullFlexionM1.Text == "" || TxtStep2ULFullFlexionM1.Text == "0" || TxtStep2ULFullFlexionM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step2ULAtFullFlexion";
                        missingVariable.Add(misv);
                        TxtStep2ULFullFlexionM1.Text = "";
                        modelCnt++;
                    }

                    //Step3

                    TxtStep3GroundTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3GroundTime"].ToString());
                    if (TxtStep3GroundTimeM1.Text == "" || TxtStep3GroundTimeM1.Text == "0" || TxtStep3GroundTimeM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step3GroundTime";
                        missingVariable.Add(misv);
                        TxtStep3GroundTimeM1.Text = "";
                        modelCnt++;
                    }
                    TxtStep3AirTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3AirTime"].ToString());
                    if (TxtStep3AirTimeM1.Text == "" || TxtStep3AirTimeM1.Text == "0" || TxtStep3AirTimeM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step3AirTime";
                        missingVariable.Add(misv);
                        TxtStep3AirTimeM1.Text = "";
                        modelCnt++;
                    }
                    //TxtStep3UlFlexTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3UlFlexTime"].ToString());
                    //if (TxtStep3UlFlexTimeM1.Text == "" || TxtStep3UlFlexTimeM1.Text == "0")
                    //{
                    //    TxtStep3UlFlexTimeM1.Text = "";
                    //}
                    //TxtStep3StrideRateM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3 Stride Rate"].ToString());
                    //if (TxtStep3StrideRateI.Text == "" || TxtStep3StrideRateM1.Text == "0")
                    //{
                    //    TxtStep3StrideRateM1.Text = "";
                    //}
                    TxtStep3StrideLengthM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3StrideLength"].ToString());
                    if (TxtStep3StrideLengthM1.Text == "" || TxtStep3StrideLengthM1.Text == "0" || TxtStep3StrideLengthM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step3StrideLength";
                        missingVariable.Add(misv);
                        TxtStep3StrideLengthM1.Text = "";
                        modelCnt++;
                    }
                    TxtStep3TouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3TouchdownDistance"].ToString());
                    if (TxtStep2TouchDistanceM1.Text == "" || TxtStep3TouchDistanceM1.Text == "0" || TxtStep3TouchDistanceM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step3TouchdownDistance";
                        missingVariable.Add(misv);
                        TxtStep3TouchDistanceM1.Text = "";
                        modelCnt++;
                    }
                    TxtStep3KSTouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3KneeSeperationatTouchdown"].ToString());
                    if (TxtStep3KSTouchDistanceM1.Text == "" || TxtStep3KSTouchDistanceM1.Text == "0" || TxtStep3KSTouchDistanceM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step3KneeSeperationatTouchdown";
                        missingVariable.Add(misv);
                        TxtStep3KSTouchDistanceM1.Text = "";
                        modelCnt++;
                    }

                    //TrunkTd

                    //TrunkTd
                    TxtStep3TrunkTouchdownAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3TrunkTouchdownAngle"].ToString());
                    if (TxtStep3TrunkTouchdownAngleM1.Text == "" || TxtStep3TrunkTouchdownAngleM1.Text == "0" || TxtStep3TrunkTouchdownAngleM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step3TrunkTouchdownAngle";
                        missingVariable.Add(misv);
                        TxtStep3TrunkTouchdownAngleM1.Text = "";
                        modelCnt++;
                    }
                    //TrunkTO
                    TxtStep3TrunkTakeoffAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3TrunkTakeoffAngle"].ToString());
                    if (TxtStep3TrunkTakeoffAngleM1.Text == "" || TxtStep3TrunkTakeoffAngleM1.Text == "0" || TxtStep3TrunkTakeoffAngleM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step3TrunkTakeoffAngle";
                        missingVariable.Add(misv);
                        TxtStep3TrunkTakeoffAngleM1.Text = "";
                        modelCnt++;
                    }
                    TxtStep3ULFullExtensionM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3ULAtFullExtension"].ToString());
                    if (TxtStep3ULFullExtensionM1.Text == "" || TxtStep3ULFullExtensionM1.Text == "0" || TxtStep3ULFullExtensionM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step3ULAtFullExtension";
                        missingVariable.Add(misv);
                        TxtStep3ULFullExtensionM1.Text = "";
                        modelCnt++;
                    }
                    TxtStep3LLTakeOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3LLAtTakeoff"].ToString());
                    if (TxtStep3LLTakeOffM1.Text == "" || TxtStep3LLTakeOffM1.Text == "0" || TxtStep3LLTakeOffM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step3LLAtTakeoff";
                        missingVariable.Add(misv);
                        TxtStep3LLTakeOffM1.Text = "";
                        modelCnt++;
                    }
                    TxtStep3LLFullFlexionM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3LLAtFullFlexion"].ToString());
                    if (TxtStep3LLFullFlexionM1.Text == "" || TxtStep3LLFullFlexionM1.Text == "0" || TxtStep3LLFullFlexionM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step3LLAtFullFlexion";
                        missingVariable.Add(misv);
                        TxtStep3LLFullFlexionM1.Text = "";
                        modelCnt++;
                    }
                    //TxtStep3LLAnkleCrossM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3LLAtatAnkleCross"].ToString());
                    //if (TxtStep3LLAnkleCrossM1.Text == "" || TxtStep3LLAnkleCrossM1.Text == "0")
                    //{
                    //    TxtStep3LLAnkleCrossM1.Text = "";
                    //}
                    TxtStep3ULFullFlexionM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3ULAtFullFlexion"].ToString());
                    if (TxtStep3ULFullFlexionM1.Text == "" || TxtStep3ULFullFlexionM1.Text == "0" || TxtStep3ULFullFlexionM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "Step3ULAtFullFlexion";
                        missingVariable.Add(misv);
                        TxtStep3ULFullFlexionM1.Text = "";
                        modelCnt++;
                    }

                    //IntoHurdleSteps

                    TxtIntoHurdleTouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetTouchdownDistanceIntoTheHurdle"].ToString());
                    if (TxtIntoHurdleTouchDistanceM1.Text == "" || TxtIntoHurdleTouchDistanceM1.Text == "0" || TxtIntoHurdleTouchDistanceM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "SetTouchdownDistanceIntoTheHurdle";
                        missingVariable.Add(misv);
                        TxtIntoHurdleTouchDistanceM1.Text = "";
                        modelCnt++;
                    }
                    TxtIntoHurdleKSTouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetKneeSeperationatTouchdownIntoTheHurdle"].ToString());
                    if (TxtIntoHurdleKSTouchDistanceM1.Text == "" || TxtIntoHurdleKSTouchDistanceM1.Text == "0" || TxtIntoHurdleKSTouchDistanceM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "SetKneeSeperationatTouchdownIntoTheHurdle";
                        missingVariable.Add(misv);
                        TxtIntoHurdleKSTouchDistanceM1.Text = "";
                        modelCnt++;
                    }


                    //TrunkTD
                    TxtIntoHurdleTrunkTouchdownAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetTrunkTouchdownAngleIntoTheHurdle"].ToString());
                    if (TxtIntoHurdleTrunkTouchdownAngleM1.Text == "" || TxtIntoHurdleTrunkTouchdownAngleM1.Text == "0" || TxtIntoHurdleTrunkTouchdownAngleM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "SetTrunkTouchdownAngleIntoTheHurdle";
                        missingVariable.Add(misv);
                        TxtIntoHurdleTrunkTouchdownAngleM1.Text = "";
                        modelCnt++;
                    }
                    TxtIntoHurdleLLTouchDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetLLAtTouchdownIntoTheHurdle"].ToString());
                    if (TxtIntoHurdleLLTouchDistanceM1.Text == "" || TxtIntoHurdleLLTouchDistanceM1.Text == "0" || TxtIntoHurdleLLTouchDistanceM1.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        misv.variableName = "SetLLAtTouchdownIntoTheHurdle";
                        missingVariable.Add(misv);
                        TxtIntoHurdleLLTouchDistanceM1.Text = "";
                        modelCnt++;
                    }
                    #endregion[model Data]
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    DataRow drVariable = ds.Tables[2].Rows[0];
                    #region[current Data]
                    TxtHurdleDistanceBtweenF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetDistanceBetweenHurdleSteps"].ToString());
                    if (TxtHurdleDistanceBtweenF.Text == "" || TxtHurdleDistanceBtweenF.Text == "0" || TxtHurdleDistanceBtweenF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "SetDistanceBetweenHurdleSteps";
                        missingVariable.Add(misv);
                        TxtHurdleDistanceBtweenF.Text = "";
                        CurrentCnt++;
                    }
                    TxtHurdleDistanceIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetDistanceIntoHurdleSteps"].ToString());
                    if (TxtHurdleDistanceIntoF.Text == "" || TxtHurdleDistanceIntoF.Text == "0" || TxtHurdleDistanceIntoF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "SetDistanceIntoHurdleSteps";
                        missingVariable.Add(misv);
                        TxtHurdleDistanceIntoF.Text = "";
                        CurrentCnt++;
                    }
                    TxtHurdleDistanceOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetDistanceOffHurdleSteps"].ToString());
                    if (TxtHurdleDistanceOffF.Text == "" || TxtHurdleDistanceOffF.Text == "0" || TxtHurdleDistanceOffF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "SetDistanceOffHurdleSteps";
                        missingVariable.Add(misv);
                        TxtHurdleDistanceOffF.Text = "";
                        CurrentCnt++;
                    }
                    //TxtHurdleVelocityF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Velocity"].ToString());
                    //if (TxtHurdleVelocityF.Text == "" || TxtHurdleVelocityF.Text == "0")
                    //{
                    //    TxtHurdleVelocityF.Text = "";
                    //}
                    //step 1
                    TxtStep1GroundTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1GroundTime"].ToString());
                    if (TxtStep1GroundTimeF.Text == "" || TxtStep1GroundTimeF.Text == "0" || TxtStep1GroundTimeF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step1GroundTime";
                        missingVariable.Add(misv);
                        TxtStep1GroundTimeF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep1AirTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1AirTime"].ToString());
                    if (TxtStep1AirTimeF.Text == "" || TxtStep1AirTimeF.Text == "0" || TxtStep1AirTimeF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step1AirTime";
                        missingVariable.Add(misv);
                        TxtStep1AirTimeF.Text = "";
                        CurrentCnt++;
                    }
                    //TxtStep1UlFlexTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1UlFlexTime"].ToString());
                    //if (TxtStep1UlFlexTimeF.Text == "" || TxtStep1UlFlexTimeF.Text == "0")
                    //{
                    //    TxtStep1UlFlexTimeF.Text = "";
                    //}
                    //TxtStep1StrideRateF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1 Stride Rate"].ToString());
                    //if (TxtStep1StrideRateF.Text == "" || TxtStep1StrideRateF.Text == "0.000")
                    //{
                    //    TxtStep1StrideRateF.Text = "";
                    //}
                    TxtStep1StrideLengthF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1StrideLength"].ToString());
                    if (TxtStep1StrideLengthF.Text == "" || TxtStep1StrideLengthF.Text == "0" || TxtStep1StrideLengthF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step1StrideLength";
                        missingVariable.Add(misv);
                        TxtStep1StrideLengthF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep1TouchDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1TouchdownDistance"].ToString());
                    if (TxtStep1TouchDistanceF.Text == "" || TxtStep1TouchDistanceF.Text == "0" || TxtStep1TouchDistanceF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step1TouchdownDistance";
                        missingVariable.Add(misv);
                        TxtStep1TouchDistanceF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep1KSTouchDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1KneeSeperationatTouchdown"].ToString());
                    if (TxtStep1KSTouchDistanceF.Text == "" || TxtStep1KSTouchDistanceF.Text == "0" || TxtStep1KSTouchDistanceF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step1KneeSeperationatTouchdown";
                        missingVariable.Add(misv);
                        TxtStep1KSTouchDistanceF.Text = "";
                        CurrentCnt++;
                    }

                    //TrunkTd

                    //TrunkTd
                    TxtStep1TrunkTouchdownAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1TrunkTouchdownAngle"].ToString());
                    if (TxtStep1TrunkTouchdownAngleF.Text == "" || TxtStep1TrunkTouchdownAngleF.Text == "0" || TxtStep1TrunkTouchdownAngleF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step1TrunkTouchdownAngle";
                        missingVariable.Add(misv);
                        TxtStep1TrunkTouchdownAngleF.Text = "";
                        CurrentCnt++;
                    }
                    //TrunkTO
                    TxtStep1TrunkTakeoffAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1TrunkTakeoffAngle"].ToString());
                    if (TxtStep1TrunkTakeoffAngleF.Text == "" || TxtStep1TrunkTakeoffAngleF.Text == "0" || TxtStep1TrunkTakeoffAngleF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step1TrunkTakeoffAngle";
                        missingVariable.Add(misv);
                        TxtStep1TrunkTakeoffAngleF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep1ULFullExtensionF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1ULAtFullExtension"].ToString());
                    if (TxtStep1ULFullExtensionF.Text == "" || TxtStep1ULFullExtensionF.Text == "0" || TxtStep1ULFullExtensionF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step1ULAtFullExtension";
                        missingVariable.Add(misv);
                        TxtStep1ULFullExtensionF.Text = "";
                        CurrentCnt++;
                    }

                    TxtStep1LLTakeOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1LLAtTakeoff"].ToString());
                    if (TxtStep1LLTakeOffF.Text == "" || TxtStep1LLTakeOffF.Text == "0" || TxtStep1LLTakeOffF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step1LLAtTakeoff";
                        missingVariable.Add(misv);
                        TxtStep1LLTakeOffF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep1ULFullFlexionF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1ULAtFullFlexion"].ToString());
                    if (TxtStep1ULFullFlexionF.Text == "" || TxtStep1ULFullFlexionF.Text == "0" || TxtStep1ULFullFlexionF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step1ULAtFullFlexion";
                        missingVariable.Add(misv);
                        TxtStep1ULFullFlexionF.Text = "";
                        CurrentCnt++;
                    }
                    //step 2

                    TxtStep2GroundTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2GroundTime"].ToString());
                    if (TxtStep2GroundTimeF.Text == "" || TxtStep2GroundTimeF.Text == "0" || TxtStep2GroundTimeF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step2GroundTime";
                        missingVariable.Add(misv);
                        TxtStep2GroundTimeF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep2AirTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2AirTime"].ToString());
                    if (TxtStep2AirTimeF.Text == "" || TxtStep2AirTimeF.Text == "0" || TxtStep2AirTimeF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step2AirTime";
                        missingVariable.Add(misv);
                        TxtStep2AirTimeF.Text = "";
                        CurrentCnt++;
                    }
                    //TxtStep2UlFlexTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2UlFlexTime"].ToString());
                    //if (TxtStep2UlFlexTimeF.Text == "" || TxtStep2UlFlexTimeF.Text == "0")
                    //{
                    //    TxtStep2UlFlexTimeM1.Text = "";
                    //}
                    //TxtStep2StrideRateF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2 Stride Rate"].ToString());
                    //if (TxtStep2StrideRateF.Text == "" || TxtStep2StrideRateF.Text == "0")
                    //{
                    //    TxtStep2StrideRateF.Text = "";
                    //}
                    TxtStep2StrideLengthF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2StrideLength"].ToString());
                    if (TxtStep2StrideLengthF.Text == "" || TxtStep2StrideLengthF.Text == "0" || TxtStep2StrideLengthF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step2StrideLength";
                        missingVariable.Add(misv);
                        TxtStep2StrideLengthF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep2TouchDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2TouchdownDistance"].ToString());
                    if (TxtStep2TouchDistanceF.Text == "" || TxtStep2TouchDistanceF.Text == "0" || TxtStep2TouchDistanceF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step2TouchdownDistance";
                        missingVariable.Add(misv);
                        TxtStep2TouchDistanceF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep2KSTouchDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2KneeSeperationatTouchdown"].ToString());
                    if (TxtStep2KSTouchDistanceF.Text == "" || TxtStep2KSTouchDistanceF.Text == "0" || TxtStep2KSTouchDistanceF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step2KneeSeperationatTouchdown";
                        missingVariable.Add(misv);
                        TxtStep2KSTouchDistanceF.Text = "";
                        CurrentCnt++;
                    }

                    //TrunkTd

                    TxtStep2TrunkTouchdownAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2TrunkTouchdownAngle"].ToString());
                    if (TxtStep2TrunkTouchdownAngleF.Text == "" || TxtStep2TrunkTouchdownAngleF.Text == "0" || TxtStep2TrunkTouchdownAngleF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step2TrunkTouchdownAngle";
                        missingVariable.Add(misv);
                        TxtStep2TrunkTouchdownAngleF.Text = "";
                        CurrentCnt++;
                    }
                    //TrunkTO
                    TxtStep2TrunkTakeoffAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2TrunkTakeoffAngle"].ToString());
                    if (TxtStep2TrunkTakeoffAngleF.Text == "" || TxtStep2TrunkTakeoffAngleF.Text == "0" || TxtStep2TrunkTakeoffAngleF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step2TrunkTakeoffAngle";
                        missingVariable.Add(misv);
                        TxtStep2TrunkTakeoffAngleF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep2ULFullExtensionF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2ULAtFullExtension"].ToString());
                    if (TxtStep2ULFullExtensionF.Text == "" || TxtStep2ULFullExtensionF.Text == "0" || TxtStep2ULFullExtensionF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step2ULAtFullExtension";
                        missingVariable.Add(misv);
                        TxtStep2ULFullExtensionF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep2LLTakeOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2LLAtTakeoff"].ToString());
                    if (TxtStep2LLTakeOffF.Text == "" || TxtStep2LLTakeOffF.Text == "0" || TxtStep2LLTakeOffF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step2LLAtTakeoff";
                        missingVariable.Add(misv);
                        TxtStep2LLTakeOffF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep2LLFullFlexionF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2LLAtFullFlexion"].ToString());
                    if (TxtStep2LLFullFlexionF.Text == "" || TxtStep2LLFullFlexionF.Text == "0" || TxtStep2LLFullFlexionF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step2LLAtFullFlexion";
                        missingVariable.Add(misv);
                        TxtStep2LLFullFlexionF.Text = "";
                        CurrentCnt++;
                    }
                    //TxtStep2LLAnkleCrossF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2LLAtatAnkleCross"].ToString());
                    //if (TxtStep2LLAnkleCrossF.Text == "" || TxtStep2LLAnkleCrossF.Text == "0")
                    //{
                    //    TxtStep2LLAnkleCrossF.Text = "";
                    //}
                    TxtStep2ULFullFlexionF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2ULAtFullFlexion"].ToString());
                    if (TxtStep2ULFullFlexionF.Text == "" || TxtStep2ULFullFlexionF.Text == "0" || TxtStep2ULFullFlexionF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step2ULAtFullFlexion";
                        missingVariable.Add(misv);
                        TxtStep2ULFullFlexionF.Text = "";
                        CurrentCnt++;
                    }

                    //Step3

                    TxtStep3GroundTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3GroundTime"].ToString());
                    if (TxtStep3GroundTimeF.Text == "" || TxtStep3GroundTimeF.Text == "0" || TxtStep3GroundTimeF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step3GroundTime";
                        missingVariable.Add(misv);
                        TxtStep3GroundTimeF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep3AirTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3AirTime"].ToString());
                    if (TxtStep3AirTimeF.Text == "" || TxtStep3AirTimeF.Text == "0" || TxtStep3AirTimeF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step3AirTime";
                        missingVariable.Add(misv);
                        TxtStep3AirTimeF.Text = "";
                        CurrentCnt++;
                    }
                    //TxtStep3UlFlexTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3UlFlexTime"].ToString());
                    //if (TxtStep3UlFlexTimeF.Text == "" || TxtStep3UlFlexTimeF.Text == "0")
                    //{
                    //    TxtStep3UlFlexTimeF.Text = "";
                    //}
                    //TxtStep3StrideRateF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3 Stride Rate"].ToString());
                    //if (TxtStep3StrideRateF.Text == "" || TxtStep3StrideRateF.Text == "0")
                    //{
                    //    TxtStep3StrideRateF.Text = "";
                    //}
                    TxtStep3StrideLengthF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3StrideLength"].ToString());
                    if (TxtStep3StrideLengthF.Text == "" || TxtStep3StrideLengthF.Text == "0" || TxtStep3StrideLengthF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step3StrideLength";
                        missingVariable.Add(misv);
                        TxtStep3StrideLengthF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep3TouchDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3TouchdownDistance"].ToString());
                    if (TxtStep3TouchDistanceF.Text == "" || TxtStep3TouchDistanceF.Text == "0" || TxtStep3TouchDistanceF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step3TouchdownDistance";
                        missingVariable.Add(misv);
                        TxtStep3TouchDistanceF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep3KSTouchDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3KneeSeperationatTouchdown"].ToString());
                    if (TxtStep3KSTouchDistanceF.Text == "" || TxtStep3KSTouchDistanceF.Text == "0" || TxtStep3KSTouchDistanceF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step3KneeSeperationatTouchdown";
                        missingVariable.Add(misv);
                        TxtStep3KSTouchDistanceF.Text = "";
                        CurrentCnt++;
                    }

                    //TrunkTd
                    TxtStep3TrunkTouchdownAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3TrunkTouchdownAngle"].ToString());
                    if (TxtStep3TrunkTouchdownAngleF.Text == "" || TxtStep3TrunkTouchdownAngleF.Text == "0" || TxtStep3TrunkTouchdownAngleF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step3TrunkTouchdownAngle";
                        missingVariable.Add(misv);
                        TxtStep3TrunkTouchdownAngleF.Text = "";
                        CurrentCnt++;
                    }
                    //TrunkTO
                    TxtStep3TrunkTakeoffAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3TrunkTakeoffAngle"].ToString());
                    if (TxtStep3TrunkTakeoffAngleF.Text == "" || TxtStep3TrunkTakeoffAngleF.Text == "0" || TxtStep3TrunkTakeoffAngleF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step3TrunkTakeoffAngle";
                        missingVariable.Add(misv);
                        TxtStep3TrunkTakeoffAngleF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep3ULFullExtensionF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3ULAtFullExtension"].ToString());
                    if (TxtStep3ULFullExtensionF.Text == "" || TxtStep3ULFullExtensionF.Text == "0" || TxtStep3ULFullExtensionF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step3ULAtFullExtension";
                        missingVariable.Add(misv);
                        TxtStep3ULFullExtensionF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep3LLTakeOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3LLAtTakeoff"].ToString());
                    if (TxtStep3LLTakeOffF.Text == "" || TxtStep3LLTakeOffF.Text == "0" || TxtStep3LLTakeOffF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step3LLAtTakeoff";
                        missingVariable.Add(misv);
                        TxtStep3LLTakeOffF.Text = "";
                        CurrentCnt++;
                    }
                    TxtStep3LLFullFlexionF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3LLAtFullFlexion"].ToString());
                    if (TxtStep3LLFullFlexionF.Text == "" || TxtStep3LLFullFlexionF.Text == "0" || TxtStep3LLFullFlexionF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step3LLAtFullFlexion";
                        missingVariable.Add(misv);
                        TxtStep3LLFullFlexionF.Text = "";
                    }
                    //TxtStep3LLAnkleCrossF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3LLAtatAnkleCross"].ToString());
                    //if (TxtStep3LLAnkleCrossF.Text == "" || TxtStep3LLAnkleCrossF.Text == "0")
                    //{
                    //    TxtStep3LLAnkleCrossF.Text = "";
                    //}
                    TxtStep3ULFullFlexionF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3ULAtFullFlexion"].ToString());
                    if (TxtStep3ULFullFlexionF.Text == "" || TxtStep3ULFullFlexionF.Text == "0" || TxtStep3ULFullFlexionF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "Step3ULAtFullFlexion";
                        missingVariable.Add(misv);
                        TxtStep3ULFullFlexionF.Text = "";
                        CurrentCnt++;
                    }

                    //IntoHurdleSteps

                    TxtIntoHurdleTouchDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetTouchdownDistanceIntoTheHurdle"].ToString());
                    if (TxtIntoHurdleTouchDistanceF.Text == "" || TxtIntoHurdleTouchDistanceF.Text == "0" || TxtIntoHurdleTouchDistanceF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "SetTouchdownDistanceIntoTheHurdle";
                        missingVariable.Add(misv);
                        TxtIntoHurdleTouchDistanceF.Text = "";
                        CurrentCnt++;
                    }
                    TxtIntoHurdleKSTouchDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetKneeSeperationatTouchdownIntoTheHurdle"].ToString());
                    if (TxtIntoHurdleKSTouchDistanceF.Text == "" || TxtIntoHurdleKSTouchDistanceF.Text == "0" || TxtIntoHurdleKSTouchDistanceF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "SetKneeSeperationatTouchdownIntoTheHurdle";
                        missingVariable.Add(misv);
                        TxtIntoHurdleKSTouchDistanceF.Text = "";
                        CurrentCnt++;
                    }


                    //TrunkTD
                    TxtIntoHurdleTrunkTouchdownAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetTrunkTouchdownAngleIntoTheHurdle"].ToString());
                    if (TxtIntoHurdleTrunkTouchdownAngleF.Text == "" || TxtIntoHurdleTrunkTouchdownAngleF.Text == "0" || TxtIntoHurdleTrunkTouchdownAngleF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "SetTrunkTouchdownAngleIntoTheHurdle";
                        missingVariable.Add(misv);
                        TxtIntoHurdleTrunkTouchdownAngleF.Text = "";
                        CurrentCnt++;
                    }
                    TxtIntoHurdleLLTouchDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetLLAtTouchdownIntoTheHurdle"].ToString());
                    if (TxtIntoHurdleLLTouchDistanceF.Text == "" || TxtIntoHurdleLLTouchDistanceF.Text == "0" || TxtIntoHurdleLLTouchDistanceF.Text == "0.000")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        misv.variableName = "SetLLAtTouchdownIntoTheHurdle";
                        missingVariable.Add(misv);
                        TxtIntoHurdleLLTouchDistanceF.Text = "";
                        CurrentCnt++;
                    }
                    #endregion[current Data]
                }
                sendNotFoundEmail(initialcnt, modelCnt, CurrentCnt);
            }
        }
    }
    protected void btnToBrowseCurrentVideo_Click(object sender, EventArgs e)
    {
        try
        {
            btnDeleteCurrentMovies.Visible = true;
            btndateloc.Enabled = true;
            btnDeleteCurrentMovies.Enabled = true;
            btnInpuFullSession.Enabled = true;
            DropdownListXmlFle.Enabled = true;
            txtbFilePath.Enabled = true;
            btnUpload.Enabled = true;
            btnDeleteInitialMovies.Enabled = true;
            txtForCurrentVideo.Enabled = true;
            btnToBrowseCurrentVideo.Enabled = true;
            btnDeleteCurrentMovies.Visible = true;
            txtSumFilePath.Enabled = true;
            btnUpload2.Enabled = true;
            btnDeleteSummaryMovie.Enabled = true;
            btnSubmit.Enabled = true;
            btnDeleteSession.Enabled = true;
            Gridview3.Visible = true;
            Gridview2.Visible = false;
            Gridview1.Visible = false;
            // FileInfo myFile = new FileInfo("G:\\NewCompuSport\\SourceCode\\Users\\MovieFiles");
            //string[] files = Directory.GetFiles("G:\\NewCompuSport\\SourceCode\\Users\\MovieFiles");
            string mappath = Server.MapPath(".");
            if (mappath.Contains("Admin"))
            {
                mappath = mappath.Replace("Admin", "Users");
            }
            string[] files = Directory.GetFiles(mappath + "\\" + "MovieFiles");
            ArrayList arrFiles = new ArrayList();

            for (int i = 0; i < files.Length; i++)
            {
                FilePathClassa2 objFilePathClass = new FilePathClassa2();
                objFilePathClass.Index = i;
                try
                {
                    string strTemp = files[i];
                    if (!strTemp.Contains("Initial"))
                    {
                        files[i] = strTemp.Substring(strTemp.LastIndexOf("\\") + 1, strTemp.Length - strTemp.LastIndexOf("\\") - 1).Replace("-Back.mp4", "").Replace("-Side.mp4", "");
                        objFilePathClass.FilePath = files[i];
                        arrFiles.Add(objFilePathClass);

                    }
                }
                catch (Exception ex1)
                { }
                i++;
            }

            Gridview3.DataSource = arrFiles;
            Gridview3.DataBind();
            Label117.Text = "";
        }
        catch (Exception ex)
        { }
    }
    protected void Gridview3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public IList<Movie> GetMovieListByLessionId_LessionType(int LessonSelected, int movietype1, int movietype2)
    {
        IList<Movie> movielist = new List<Movie>();

        DataTable dt = new DataTable();
        try
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmdMovieList = con.CreateCommand())
                {
                    cmdMovieList.CommandType = CommandType.StoredProcedure;
                    cmdMovieList.CommandText = "GetMovieList";
                    cmdMovieList.Parameters.AddWithValue("@LessonId", LessonSelected);
                    cmdMovieList.Parameters.AddWithValue("@movietype1", movietype1);
                    cmdMovieList.Parameters.AddWithValue("@movietype2", movietype2);
                    cmdMovieList.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmdMovieList);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Movie objmove = new Movie();
                            objmove.MovieId = Convert.ToInt16(dt.Rows[i]["MovieId"].ToString());
                            objmove.MovieType = Convert.ToInt16(dt.Rows[i]["MovieType"].ToString());
                            objmove.DateRecorded = Convert.ToDateTime(dt.Rows[i]["DateRecorded"].ToString());
                            objmove.FilePath = Convert.ToString(dt.Rows[i]["FilePath"].ToString());
                            objmove.LessonId = Convert.ToInt16(dt.Rows[i]["LessonId"].ToString());
                            movielist.Add(objmove);
                        }
                    }
                }
            }
            return movielist;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    private void ClearFramesData()
    {
        txtBFrame1.Text = "";
        txtBFrame2.Text = "";
        txtBFrame3.Text = "";
        txtBFrame4.Text = "";
        txtBFrame5.Text = "";
        txtBFrame6.Text = "";
        txtBFrame7.Text = "";
        txtBFrame8.Text = "";
        txtCBFrame1.Text = "";
        txtCBFrame2.Text = "";
        txtCBFrame3.Text = "";
        txtCBFrame4.Text = "";
        txtCBFrame5.Text = "";
        txtCBFrame6.Text = "";
        txtCBFrame7.Text = "";
        txtCBFrame8.Text = "";
    }

    public DataTable GetMovieClips(int MovieId)
    {
        DataTable dt = new DataTable();
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmdSelectAllCoaches = connection.CreateCommand())
                {
                    cmdSelectAllCoaches.CommandType = CommandType.StoredProcedure;
                    cmdSelectAllCoaches.CommandText = "SelectMovieclips";
                    cmdSelectAllCoaches.Parameters.AddWithValue("@MovieId", MovieId);
                    cmdSelectAllCoaches.Connection = connection;
                    SqlDataAdapter da = new SqlDataAdapter(cmdSelectAllCoaches);
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        catch (Exception ex)
        {
            return dt = null;
        }
    }

    protected void btnDeleteSession_Click(object sender, EventArgs e)
    {
        try
        {
            Lesson _lesson = new Lesson();
            Movie _movieCurrentSide = new Movie();
            Movie _movieCurrentBack = new Movie();
            Movie _movieSide = new Movie();
            Movie _movieBack = new Movie();
            int _lessonselected = Convert.ToInt32(DropDownList2.SelectedValue);
            _lesson = DataRepository.LessonProvider.GetByLessonId(_lessonselected);
            IList<Movie> movieList = GetMovieListByLessionId_LessionType(_lessonselected, 2, 3);
            if (movieList.Count > 0)   //delete current movies
            {
                _movieCurrentSide = movieList[0];
                _movieCurrentBack = movieList[1];
                int CurrentSide = _movieCurrentSide.MovieId;
                int CurrentBack = _movieCurrentBack.MovieId;
                DataRepository.MovieClipProvider.Delete(CurrentSide);
                DataRepository.MovieClipProvider.Delete(CurrentBack);
                DataRepository.MovieProvider.Delete(CurrentSide);
                DataRepository.MovieProvider.Delete(CurrentBack);
            }
            IList<Movie> movieList1 = GetMovieListByLessionId_LessionType(_lessonselected, 0, 1);
            if (movieList1.Count > 0) //delete initial movies
            {
                _movieSide = movieList[0];
                _movieBack = movieList[1];
                int InitialSide = _movieSide.MovieId;
                int InitialBack = _movieBack.MovieId;
                DataRepository.MovieClipProvider.Delete(InitialSide);
                DataRepository.MovieClipProvider.Delete(InitialBack);
                DataRepository.MovieProvider.Delete(InitialSide);
                DataRepository.MovieProvider.Delete(InitialBack);
            }

            string Sprint_InitialDataId = sae.SelectHurdleStepsInitialDataid(_lessonselected.ToString());

            if (Sprint_InitialDataId != "")
            {
                _SprintData.DeleteHurdleStepsInitialLessonData(_lessonselected);
            }

            string Sprint_ModelDataId = sae.SelectHurdleStepsModelDataid(_lessonselected.ToString());
            if (Sprint_ModelDataId != "")
            {
                _SprintData.DeleteHurdleStepsModelLessonData(_lessonselected);
            }

            string Sprint_CurrentDataId = sae.SelectHurdleStepsCurrentDataid(_lessonselected.ToString());
            if (Sprint_CurrentDataId != "")
            {
                _SprintData.DeleteHurdleStepsCurrentLessonData(_lessonselected);
            }

            DataRepository.LessonProvider.Delete(_lessonselected);   //delete lesson 
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "refresh", "refresh();", true);
            HurdleStepsPageOnTrackSessi hurdleStepsPageOnTrackSessi = new HurdleStepsPageOnTrackSessi();
            hurdleStepsPageOnTrackSessi.HurdlePageOnTrackSessionData(_lessonselected);

        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

    }
    //protected void OkButton_Clicked(object sender, EventArgs e)
    //{
    //  //  ModalPopupExtender1.Hide();
    //    txtndbtnVisibleOFF();
    //}
    //protected void CancelButton_Clicked(object sender, EventArgs e)
    //{
    //   // ModalPopupExtender1.Hide();

    //}
    protected void btnInpuFullSession_Click(object sender, EventArgs e)
    {
        lblNoVideo.Visible = false;
        if (DropDownList1.SelectedValue.Equals("noathlete"))
        {
            Label3.Visible = true;
        }
        if (DropDownList2.Items.Count > 0)
        {
            Label4.Visible = true;
        }
        if (DropdownListXmlFle.Items.Count > 0)
        {
            lblNoVideo.Visible = false;
            Label4.Visible = false;
            List<string> filesList1 = new List<string>();
            var file1 = DropdownListXmlFle.SelectedItem.Text;
            var xmlpath1 = HttpContext.Current.Server.MapPath("~/Archive/manifest/" + file1);
            XDocument xmldoc1 = XDocument.Load(xmlpath1);
            IEnumerable<XElement> returnnode1 = xmldoc1.Descendants("mnf");

            var path1 = HttpContext.Current.Server.MapPath("~/Users/MovieFiles");
            DirectoryInfo d1 = new DirectoryInfo(path1);
            FileInfo[] Files1 = d1.GetFiles("*.mp4");
            int cnt11 = 0;
            int cnt22 = 0;
            string message1 = string.Empty;
            //Lession Date --------------->>>>>>>>>>>>>>>>>>>>>>>
            var lessionName = DropDownList2.SelectedItem.Text;
            var lessionNameDate = lessionName.Length <= 10 ? lessionName : lessionName.Substring(0, 10);
            var date = lessionNameDate.ToString().Split('/');

            DateTime lessionNameDate1 = DateTime.MinValue;
            if (date.Count() > 2)
            {

                int year = Convert.ToInt32(date[2]);
                int month = Convert.ToInt32(date[0]);
                int day = Convert.ToInt32(date[1]);
                lessionNameDate1 = new DateTime(year, month, day);
            }
            //XML Date---------------------------------->>>>>>>>>>>>>>>>>>>>
            DateTime? lessionNameDate2 = null;
            var xmlselect = Path.GetFileNameWithoutExtension(DropdownListXmlFle.SelectedItem.Text);
            var fileNameParts = xmlselect.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var dateFromFileName = new List<int>();
            foreach (string fileNamePart in fileNameParts.Reverse())
            {
                int result; int index = 0;
                if (int.TryParse(fileNamePart.ToString(), out result))
                {
                    dateFromFileName.Add(Convert.ToInt32(fileNamePart));
                    index++;
                }
            }

            dateFromFileName.Reverse();
            string dq = dateFromFileName[0] + "/" + dateFromFileName[1] + "/" + dateFromFileName[2].ToString();
            lessionNameDate2 = DateTime.Parse(dq);

            if (returnnode1.Count() > 0)
            {
                //InitialSide Date --------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>
                //DateTime InitialSidedate = DateTime.MinValue;
                DateTime? InitialSidedate11 = null;
                IEnumerable<XElement> InitialSide = returnnode1.Elements("video").Elements("first").Elements("side");
                if (InitialSide.Count() > 0)
                {
                    foreach (XElement packageChild in InitialSide)
                    {
                        var sidefileDate = packageChild.Element("file").Value;

                        if (sidefileDate != "")
                        {
                            cnt11 += Files1.Where(f => f.Name == sidefileDate).Count();
                            sidefileDate = sidefileDate.Substring(0, sidefileDate.LastIndexOf('-'));

                            var InitialSidefileNameParts = sidefileDate.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            var InitialSidedateFromFileName = new List<int>();

                            foreach (string InitialSidefileNamePart in InitialSidefileNameParts.Reverse())
                            {
                                int result; int index = 0;
                                if (int.TryParse(InitialSidefileNamePart.ToString(), out result))
                                {
                                    InitialSidedateFromFileName.Add(Convert.ToInt32(InitialSidefileNamePart));
                                    index++;
                                }
                            }
                            InitialSidedateFromFileName.Reverse();
                            string dq1 = InitialSidedateFromFileName[0] + "/" + InitialSidedateFromFileName[1] + "/" + InitialSidedateFromFileName[2].ToString();
                            InitialSidedate11 = DateTime.Parse(dq1);
                        }
                    }
                }
                //Initialback Date --------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>
                // DateTime Initialbackdate = DateTime.MinValue;
                DateTime? Initialbackdate11 = null;
                IEnumerable<XElement> Initialback = returnnode1.Elements("video").Elements("first").Elements("back");
                if (Initialback.Count() > 0)
                {
                    foreach (XElement packageChild in Initialback)
                    {
                        var InitialbackfileDate = packageChild.Element("file").Value;
                        if (InitialbackfileDate != "")
                        {
                            cnt11 += Files1.Where(f => f.Name == InitialbackfileDate).Count();
                            InitialbackfileDate = InitialbackfileDate.Substring(0, InitialbackfileDate.LastIndexOf('-'));
                            //-------------------

                            var InitialbackfileNameParts = InitialbackfileDate.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                            var InitialbackdateFromFileName = new List<int>();

                            foreach (string InitialbackfileNamePart in InitialbackfileNameParts.Reverse())
                            {
                                int result; int index = 0;
                                if (int.TryParse(InitialbackfileNamePart.ToString(), out result))
                                {
                                    InitialbackdateFromFileName.Add(Convert.ToInt32(InitialbackfileNamePart));
                                    index++;
                                }
                            }
                            InitialbackdateFromFileName.Reverse();
                            string dq1 = InitialbackdateFromFileName[0] + "/" + InitialbackdateFromFileName[1] + "/" + InitialbackdateFromFileName[2].ToString();
                            Initialbackdate11 = DateTime.Parse(dq1);


                        }
                    }
                }
                //Currentside Date -------------------------->>>>>>>>>>>>>>>>>>>>>>>>>
                // DateTime Currentsidekdate = DateTime.MinValue;
                DateTime? Currentsidekdate11 = null;
                IEnumerable<XElement> Currentside = returnnode1.Elements("video").Elements("final").Elements("side");
                if (Currentside.Count() > 0)
                {
                    foreach (XElement packageChild in Currentside)
                    {
                        var CurrentsidefileDate = packageChild.Element("file").Value;
                        if (CurrentsidefileDate != "")
                        {
                            cnt22 += Files1.Where(f => f.Name == CurrentsidefileDate).Count();
                            CurrentsidefileDate = CurrentsidefileDate.Substring(0, CurrentsidefileDate.LastIndexOf('-'));
                            //----------------

                            var CurrentsidefileNameParts = CurrentsidefileDate.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                            var CurrentsidedateFromFileName = new List<int>();

                            foreach (string CurrentsidefileNamePart in CurrentsidefileNameParts.Reverse())
                            {
                                int result; int index = 0;
                                if (int.TryParse(CurrentsidefileNamePart.ToString(), out result))
                                {
                                    CurrentsidedateFromFileName.Add(Convert.ToInt32(CurrentsidefileNamePart));
                                    index++;
                                }
                            }
                            CurrentsidedateFromFileName.Reverse();
                            string dq1 = CurrentsidedateFromFileName[0] + "/" + CurrentsidedateFromFileName[1] + "/" + CurrentsidedateFromFileName[2].ToString();
                            Currentsidekdate11 = DateTime.Parse(dq1);

                        }
                    }
                }
                //Currentback Date ----------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // DateTime Currentbackdate = DateTime.MinValue;
                IEnumerable<XElement> Currentback = returnnode1.Elements("video").Elements("final").Elements("back");
                DateTime? CurrentbackfileDate11 = null;
                if (Currentback.Count() > 0)
                {
                    foreach (XElement packageChild in Currentback)
                    {
                        var CurrentbackfileDate = packageChild.Element("file").Value;

                        if (CurrentbackfileDate != "")
                        {
                            cnt22 += Files1.Where(f => f.Name == CurrentbackfileDate).Count();
                            CurrentbackfileDate = CurrentbackfileDate.Substring(0, CurrentbackfileDate.LastIndexOf('-'));
                            //----------------
                            var CurrentbackfileNameParts = CurrentbackfileDate.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                            var CurrentbackdateFromFileName = new List<int>();

                            foreach (string CurrentbackfileNamePart in CurrentbackfileNameParts.Reverse())
                            {
                                int result; int index = 0;
                                if (int.TryParse(CurrentbackfileNamePart.ToString(), out result))
                                {
                                    CurrentbackdateFromFileName.Add(Convert.ToInt32(CurrentbackfileNamePart));
                                    index++;
                                }
                            }
                            CurrentbackdateFromFileName.Reverse();
                            string dq1 = CurrentbackdateFromFileName[0] + "/" + CurrentbackdateFromFileName[1] + "/" + CurrentbackdateFromFileName[2].ToString();
                            CurrentbackfileDate11 = DateTime.Parse(dq1);

                            //if (CurrentbackdateFromFileName.Count() > 2)
                            //{
                            //    int year = Convert.ToInt32(CurrentbackdateFromFileName[2]);
                            //    int month = Convert.ToInt32(CurrentbackdateFromFileName[0]);
                            //    int day = Convert.ToInt32(CurrentbackdateFromFileName[1]);
                            //    Currentbackdate = new DateTime(year, month, day);
                            //}

                        }
                    }
                }
                if (lessionNameDate1.Date == lessionNameDate2 && lessionNameDate1.Date == InitialSidedate11 || lessionNameDate1.Date == Initialbackdate11 || lessionNameDate1.Date == Currentsidekdate11 || lessionNameDate1.Date == CurrentbackfileDate11)
                {
                    lblNoVideo.Visible = false;
                    try
                    {
                        List<string> filesList = new List<string>();
                        var file = DropdownListXmlFle.SelectedItem.Text;
                        var xmlpath = HttpContext.Current.Server.MapPath("~/Archive/manifest/" + file);
                        XDocument xmldoc = XDocument.Load(xmlpath);
                        IEnumerable<XElement> returnnode = xmldoc.Descendants("mnf");

                        var path = HttpContext.Current.Server.MapPath("~/Users/MovieFiles");
                        DirectoryInfo d = new DirectoryInfo(path);
                        FileInfo[] Files = d.GetFiles("*.mp4");
                        int cnt1 = 0;
                        int cnt2 = 0;
                        string message = string.Empty;
                        if (returnnode.Count() > 0)
                        {
                            IEnumerable<XElement> Initialbackside = returnnode.Elements("video").Elements("first").Elements("side");
                            if (Initialbackside.Count() > 0)
                            {
                                foreach (XElement packageChild in Initialbackside)
                                {
                                    var sidefile = packageChild.Element("file").Value;

                                    if (sidefile != "")
                                    {
                                        cnt1 += Files.Where(f => f.Name == sidefile).Count();
                                        sidefile = sidefile.Substring(0, sidefile.LastIndexOf('-'));
                                        txtbFilePath.Text = sidefile;
                                    }
                                }
                            }

                            IEnumerable<XElement> Initialbackback = returnnode.Elements("video").Elements("first").Elements("back");

                            if (Initialbackback.Count() > 0)
                            {
                                foreach (XElement packageChild in Initialbackback)
                                {
                                    var backfile = packageChild.Element("file").Value;
                                    if (backfile != "")
                                    {
                                        cnt1 += Files.Where(f => f.Name == backfile).Count();
                                        backfile = backfile.Substring(0, backfile.LastIndexOf('-'));
                                        txtbFilePath.Text = backfile;
                                    }
                                }
                            }

                            IEnumerable<XElement> referencepositions = returnnode.Elements("video").Elements("first").Elements("referencepositions");
                            if (referencepositions.Count() > 0)
                            {
                                foreach (XElement packageChild in referencepositions)
                                {

                                    var position1 = packageChild.Element("position1").Value;
                                    if (position1 != "")
                                    {
                                        txtBFrame1.Text = position1;
                                    }
                                    var position2 = packageChild.Element("position2").Value;
                                    if (position2 != "")
                                    {
                                        txtBFrame2.Text = position2;
                                    }
                                    var position3 = packageChild.Element("position3").Value;
                                    if (position3 != "")
                                    {
                                        txtBFrame3.Text = position3;
                                    }
                                    var position4 = packageChild.Element("position4").Value;
                                    if (position4 != "")
                                    {
                                        txtBFrame4.Text = position4;
                                    }
                                    var position5 = packageChild.Element("position5").Value;
                                    if (position5 != "")
                                    {
                                        txtBFrame5.Text = position5;
                                    }
                                    var position6 = packageChild.Element("position6").Value;
                                    if (position6 != "")
                                    {
                                        txtBFrame6.Text = position6;
                                    }
                                    var position7 = packageChild.Element("position7").Value;
                                    if (position7 != "")
                                    {
                                        txtBFrame7.Text = position7;
                                    }
                                    var position8 = packageChild.Element("position8").Value;
                                    if (position8 != "")
                                    {
                                        txtBFrame8.Text = position8;
                                    }
                                    var position9 = packageChild.Element("position9").Value;
                                    //txtBFrame9.Text = position9;
                                    //var position10 = packageChild.Element("position10").Value;

                                }
                            }
                        }
                        if (returnnode.Count() > 0)
                        {
                            IEnumerable<XElement> side = returnnode.Elements("video").Elements("final").Elements("side");
                            if (side.Count() > 0)
                            {
                                foreach (XElement packageChild in side)
                                {
                                    var sidefile = packageChild.Element("file").Value;

                                    if (sidefile != "")
                                    {
                                        cnt1 += Files.Where(f => f.Name == sidefile).Count();
                                        sidefile = sidefile.Substring(0, sidefile.LastIndexOf('-'));
                                        txtForCurrentVideo.Text = sidefile;
                                    }

                                }
                            }
                            IEnumerable<XElement> back = returnnode.Elements("video").Elements("final").Elements("back");
                            if (back.Count() > 0)
                            {
                                foreach (XElement packageChild in back)
                                {
                                    var backfile = packageChild.Element("file").Value;
                                    if (backfile != "")
                                    {
                                        cnt1 += Files.Where(f => f.Name == backfile).Count();
                                        backfile = backfile.Substring(0, backfile.LastIndexOf('-'));
                                        txtForCurrentVideo.Text = backfile;
                                    }
                                }
                            }
                            IEnumerable<XElement> referencepositions = returnnode.Elements("video").Elements("final").Elements("referencepositions");

                            if (referencepositions.Count() > 0)
                            {
                                foreach (XElement packageChild in referencepositions)
                                {
                                    var position1 = packageChild.Element("position1").Value;
                                    if (position1 != "")
                                    {
                                        txtCBFrame1.Text = position1;
                                    }
                                    var position2 = packageChild.Element("position2").Value;
                                    if (position2 != "")
                                    {
                                        txtCBFrame2.Text = position2;
                                    }
                                    var position3 = packageChild.Element("position3").Value;
                                    if (position3 != "")
                                    {
                                        txtCBFrame3.Text = position3;
                                    }
                                    var position4 = packageChild.Element("position4").Value;
                                    if (position4 != "")
                                    {
                                        txtCBFrame4.Text = position4;
                                    }
                                    var position5 = packageChild.Element("position5").Value;
                                    if (position2 != "")
                                    {
                                        txtCBFrame5.Text = position5;
                                    }
                                    var position6 = packageChild.Element("position6").Value;
                                    if (position6 != "")
                                    {
                                        txtCBFrame6.Text = position6;
                                    }
                                    var position7 = packageChild.Element("position7").Value;
                                    if (position7 != "")
                                    {
                                        txtCBFrame7.Text = position7;
                                    }
                                    var position8 = packageChild.Element("position8").Value;
                                    if (position8 != "")
                                    {
                                        txtCBFrame8.Text = position8;
                                    }
                                    var position9 = packageChild.Element("position9").Value;
                                    //txtCBFrame9.Text = position9;
                                    //var position10 = packageChild.Element("position10").Value;
                                }
                            }
                        }
                        // ----------------------IniialSumamary -----------
                        //  ----------<<HurdleDistances>

                        if (returnnode.Count() > 0)
                        {
                            IEnumerable<XElement> HurdleDistances = returnnode.Elements("InitialSummary").Elements("HurdleDistances");
                            if (HurdleDistances.Count() > 0)
                            {
                                foreach (XElement packageChild in HurdleDistances)
                                {

                                    //Hurdle Distance Between
                                    var HurdleDistanceBetween = packageChild.Element("HurdleDistanceBetween").Value;
                                    if (HurdleDistanceBetween != "")
                                    {
                                        TxtHurdleDistanceBtweenI.Text = HurdleDistanceBetween;
                                    }
                                    //Stride Length Into
                                    var HurdleDistanceInto = packageChild.Element("HurdleDistanceInto").Value;
                                    if (HurdleDistanceInto != "")
                                    {
                                        TxtHurdleDistanceIntoI.Text = HurdleDistanceInto;
                                    }

                                    //Stride Length Off
                                    var HurdleDistanceOff = packageChild.Element("HurdleDistanceOff").Value;
                                    if (HurdleDistanceOff != "")
                                    {
                                        TxtHurdleDistanceOffI.Text = HurdleDistanceOff;
                                    }
                                }
                            }
                            // ------------------<Step One>
                            IEnumerable<XElement> Step1 = returnnode.Elements("InitialSummary").Elements("Step1");
                            if (Step1.Count() > 0)
                            {
                                foreach (XElement packageChild in Step1)
                                {

                                    //Step One Ground Time
                                    var GroundTime = packageChild.Element("GroundTime").Value;
                                    if (GroundTime != "")
                                    {
                                        TxtStep1GroundTimeI.Text = GroundTime;
                                    }

                                    //Step One Air Time
                                    var AirTime = packageChild.Element("AirTime").Value;
                                    if (AirTime != "")
                                    {
                                        TxtStep1AirTimeI.Text = AirTime;
                                    }
                                    //Step One Stride Length
                                    var StrideLength = packageChild.Element("StrideLength").Value;
                                    if (StrideLength != "")
                                    {
                                        TxtStep1StrideLengthI.Text = StrideLength;
                                    }

                                    //Step One Touchdown Distance
                                    var TdDistance = packageChild.Element("TdDistance").Value;
                                    if (TdDistance != "")
                                    {
                                        TxtStep1TouchDistanceI.Text = TdDistance;
                                    }

                                    //Step One Knee Seperation at Touchdown
                                    var KneeAnkleSeparationAtTd = packageChild.Element("KneeAnkleSeparationAtTd").Value;
                                    if (KneeAnkleSeparationAtTd != "")
                                    {
                                        TxtStep1KSTouchDistanceI.Text = KneeAnkleSeparationAtTd;
                                    }
                                    //Step One Trunk Touchdown Angle
                                    var TrunkAngleAtTd = packageChild.Element("TrunkAngleAtTd").Value;
                                    if (TrunkAngleAtTd != "")
                                    {
                                        TxtStep1TrunkTouchdownAngleI.Text = TrunkAngleAtTd;
                                    }
                                    //Step One Trunk Takeoff Angle
                                    var TrunkAngleAtTo = packageChild.Element("TrunkAngleAtTo").Value;
                                    if (TrunkAngleAtTo != "")
                                    {
                                        TxtStep1TrunkTakeoffAngleI.Text = TrunkAngleAtTo;
                                    }

                                    //Step One Upper Leg at Full Extension
                                    var UlAngleAtFullExtension = packageChild.Element("UlAngleAtFullExtension").Value;
                                    if (UlAngleAtFullExtension != "")
                                    {
                                        TxtStep1ULFullExtensionI.Text = UlAngleAtFullExtension;
                                    }

                                    //Step One Lower Leg at Take off
                                    var LlAngleAtTo = packageChild.Element("LlAngleAtTo").Value;
                                    if (LlAngleAtTo != "")
                                    {
                                        TxtStep1LLTakeOffI.Text = LlAngleAtTo;
                                    }
                                    //Step One Upper Leg at Full Flexion
                                    var UlAngleAtFullFlexion = packageChild.Element("UlAngleAtFullFlexion").Value;
                                    if (UlAngleAtFullFlexion != "")
                                    {
                                        TxtStep1ULFullFlexionI.Text = UlAngleAtFullFlexion;
                                    }
                                }
                            }

                            // --------------------<Step Two>
                            IEnumerable<XElement> Step2 = returnnode.Elements("InitialSummary").Elements("Step2");
                            if (Step2.Count() > 0)
                            {
                                foreach (XElement packageChild in Step2)
                                {
                                    //Step Two Ground Time
                                    var GroundTime = packageChild.Element("GroundTime").Value;
                                    if (GroundTime != "")
                                    {
                                        TxtStep2GroundTimeI.Text = GroundTime;
                                    }

                                    //Step Two Air Time
                                    var AirTime = packageChild.Element("AirTime").Value;
                                    if (AirTime != "")
                                    {
                                        TxtStep2AirTimeI.Text = AirTime;
                                    }
                                    //Step Two Stride Length
                                    var StrideLength = packageChild.Element("StrideLength").Value;
                                    if (StrideLength != "")
                                    {
                                        TxtStep2StrideLengthI.Text = StrideLength;
                                    }
                                    //Step Two Touchdown Distance
                                    var TdDistance = packageChild.Element("TdDistance").Value;
                                    if (TdDistance != "")
                                    {
                                        TxtStep2TouchDistanceI.Text = TdDistance;
                                    }
                                    //Step Two Knee Seperation at Touchdown
                                    var KneeKneeSeparationAtTd = packageChild.Element("KneeKneeSeparationAtTd").Value;
                                    if (KneeKneeSeparationAtTd != "")
                                    {
                                        TxtStep2KSTouchDistanceI.Text = KneeKneeSeparationAtTd;
                                    }
                                    //Step Two Trunk Touchdown Angle
                                    var TrunkAngleAtTd = packageChild.Element("TrunkAngleAtTd").Value;
                                    if (TrunkAngleAtTd != "")
                                    {
                                        TxtStep2TrunkTouchdownAngleI.Text = TrunkAngleAtTd;
                                    }
                                    //Step Two Trunk Takeoff Angle
                                    var TrunkAngleAtTo = packageChild.Element("TrunkAngleAtTo").Value;
                                    if (TrunkAngleAtTo != "")
                                    {
                                        TxtStep2TrunkTakeoffAngleI.Text = TrunkAngleAtTo;
                                    }
                                    //Step Two Upper Leg at Full Extension
                                    var UlAngleAtFullExtension = packageChild.Element("UlAngleAtFullExtension").Value;
                                    if (UlAngleAtFullExtension != "")
                                    {
                                        TxtStep2ULFullExtensionI.Text = UlAngleAtFullExtension;
                                    }
                                    //Step Two Lower Leg at Take off
                                    var LlAngleAtTo = packageChild.Element("LlAngleAtTo").Value;
                                    if (LlAngleAtTo != "")
                                    {
                                        TxtStep2LLTakeOffI.Text = LlAngleAtTo;
                                    }
                                    //Step Two Lower Leg at Full Flexion
                                    var LlAngleAtFullFlexion = packageChild.Element("LlAngleAtFullFlexion").Value;
                                    if (LlAngleAtFullFlexion != "")
                                    {
                                        TxtStep2LLFullFlexionI.Text = LlAngleAtFullFlexion;
                                    }
                                    //Step Two Upper Leg At Full Flexion
                                    var UlAngleAtFullFlexion = packageChild.Element("UlAngleAtFullFlexion").Value;
                                    if (UlAngleAtFullFlexion != "")
                                    {
                                        TxtStep2ULFullFlexionI.Text = UlAngleAtFullFlexion;
                                    }
                                }
                            }

                            // -------------------------------<Step Three>
                            IEnumerable<XElement> Step3 = returnnode.Elements("InitialSummary").Elements("Step3");
                            if (Step3.Count() > 0)
                            {
                                foreach (XElement packageChild in Step3)
                                {
                                    //Step Three Ground Time
                                    var GroundTime = packageChild.Element("GroundTime").Value;
                                    if (GroundTime != "")
                                    {
                                        TxtStep3GroundTimeI.Text = GroundTime;
                                    }
                                    //Step Three Air Time
                                    var AirTime = packageChild.Element("AirTime").Value;
                                    if (AirTime != "")
                                    {
                                        TxtStep3AirTimeI.Text = AirTime;
                                    }
                                    //Step Three Stride Length
                                    var StrideLength = packageChild.Element("StrideLength").Value;
                                    if (StrideLength != "")
                                    {
                                        TxtStep3StrideLengthI.Text = StrideLength;
                                    }
                                    //Step Three Touchdown Distance
                                    var TdDistance = packageChild.Element("TdDistance").Value;
                                    if (TdDistance != "")
                                    {
                                        TxtStep3TouchDistanceI.Text = TdDistance;
                                    }
                                    //Step Three Knee Seperation at Touchdown
                                    var KneeKneeSeparationAtTd = packageChild.Element("KneeKneeSeparationAtTd").Value;
                                    if (KneeKneeSeparationAtTd != "")
                                    {
                                        TxtStep3KSTouchDistanceI.Text = KneeKneeSeparationAtTd;
                                    }
                                    //Step Three Trunk Touchdown Angle
                                    var TrunkAngleAtTd = packageChild.Element("TrunkAngleAtTd").Value;
                                    if (TrunkAngleAtTd != "")
                                    {
                                        TxtStep3TrunkTouchdownAngleI.Text = TrunkAngleAtTd;
                                    }
                                    //Step Three Trunk Takeoff Angle
                                    var TrunkAngleAtTo = packageChild.Element("TrunkAngleAtTo").Value;
                                    if (TrunkAngleAtTo != "")
                                    {
                                        TxtStep3TrunkTakeoffAngleI.Text = TrunkAngleAtTo;
                                    }
                                    //Step Three Upper Leg at Full Extension
                                    var UlAngleAtFullExtension = packageChild.Element("UlAngleAtFullExtension").Value;
                                    if (UlAngleAtFullExtension != "")
                                    {
                                        TxtStep3ULFullExtensionI.Text = UlAngleAtFullExtension;
                                    }
                                    //Step Three Lower Leg at Take off
                                    var LlAngleAtTo = packageChild.Element("LlAngleAtTo").Value;
                                    if (LlAngleAtTo != "")
                                    {
                                        TxtStep3LLTakeOffI.Text = LlAngleAtTo;
                                    }
                                    //Step Three Lower Leg Full Flexion
                                    var LlAngleAtFullFlexion = packageChild.Element("LlAngleAtFullFlexion").Value;
                                    if (LlAngleAtFullFlexion != "")
                                    {
                                        TxtStep3LLFullFlexionI.Text = LlAngleAtFullFlexion;
                                    }
                                    //Step Three Upper Leg At Full Flexion
                                    var UlAngleAtFullFlexion = packageChild.Element("UlAngleAtFullFlexion").Value;
                                    if (UlAngleAtFullFlexion != "")
                                    {
                                        TxtStep3ULFullFlexionI.Text = UlAngleAtFullFlexion;
                                    }
                                }
                            }

                            //---------------------<Into Hurdle>--------------------------------
                            IEnumerable<XElement> IntoHurdle = returnnode.Elements("InitialSummary").Elements("IntoHurdle");
                            if (IntoHurdle.Count() > 0)
                            {
                                foreach (XElement packageChild in IntoHurdle)
                                {
                                    //Into Hurdle Touchdown Distance
                                    var TdDistance = packageChild.Element("TdDistance").Value;
                                    if (TdDistance != "")
                                    {
                                        TxtIntoHurdleTouchDistanceI.Text = TdDistance;
                                    }
                                    //Into Hurdle Knee Seperation at Touchdown
                                    var KneeKneeSeparationAtTd = packageChild.Element("KneeKneeSeparationAtTd").Value;
                                    if (KneeKneeSeparationAtTd != "")
                                    {
                                        TxtIntoHurdleKSTouchDistanceI.Text = KneeKneeSeparationAtTd;
                                    }
                                    //Into Hurdle Trunk Touchdown Angle
                                    var TrunkAngleAtTd = packageChild.Element("TrunkAngleAtTd").Value;
                                    if (TrunkAngleAtTd != "")
                                    {
                                        TxtIntoHurdleTrunkTouchdownAngleI.Text = TrunkAngleAtTd;
                                    }
                                    //Into Hurdle Lower Leg at Touchdown
                                    var LlAngleAtTo = packageChild.Element("LlAngleAtTo").Value;
                                    if (LlAngleAtTo != "")
                                    {
                                        TxtIntoHurdleLLTouchDistanceI.Text = LlAngleAtTo;
                                    }
                                }
                            }
                        }
                        //---------------------------<end> <InitialSummary> <end>-----------------------
                        if (returnnode.Count() > 0)
                        {
                            IEnumerable<XElement> CurrentHurdleDistances = returnnode.Elements("CurrentSummary").Elements("HurdleDistances");
                            if (CurrentHurdleDistances.Count() > 0)
                            {
                                foreach (XElement packageChild in CurrentHurdleDistances)
                                {
                                    //----------<SetPosition>
                                    //Hurdle Distance Between
                                    var HurdleDistanceBetween = packageChild.Element("HurdleDistanceBetween").Value;
                                    if (HurdleDistanceBetween != "")
                                    {
                                        TxtHurdleDistanceBtweenF.Text = HurdleDistanceBetween;
                                    }
                                    //Stride Length Into
                                    var HurdleDistanceInto = packageChild.Element("HurdleDistanceInto").Value;
                                    if (HurdleDistanceInto != "")
                                    {
                                        TxtHurdleDistanceIntoF.Text = HurdleDistanceInto;
                                    }
                                    //Stride Length Off
                                    var HurdleDistanceOff = packageChild.Element("HurdleDistanceOff").Value;
                                    if (HurdleDistanceOff != "")
                                    {
                                        TxtHurdleDistanceOffF.Text = HurdleDistanceOff;
                                    }
                                }
                            }
                            //------------------<Step One>-------------------------------------
                            IEnumerable<XElement> CurrentStep1 = returnnode.Elements("CurrentSummary").Elements("Step1");
                            if (CurrentStep1.Count() > 0)
                            {
                                foreach (XElement packageChild in CurrentStep1)
                                {
                                    //Step One Ground Time
                                    var GroundTime = packageChild.Element("GroundTime").Value;
                                    if (GroundTime != "")
                                    {
                                        TxtStep1GroundTimeF.Text = GroundTime;
                                    }
                                    //Step One Air Time
                                    var AirTime = packageChild.Element("AirTime").Value;
                                    if (AirTime != "")
                                    {
                                        TxtStep1AirTimeF.Text = AirTime;
                                    }

                                    //Step One Stride Length
                                    var StrideLength = packageChild.Element("StrideLength").Value;
                                    if (StrideLength != "")
                                    {
                                        TxtStep1StrideLengthF.Text = StrideLength;
                                    }

                                    //Step One Touchdown Distance
                                    var TdDistance = packageChild.Element("TdDistance").Value;
                                    if (TdDistance != "")
                                    {
                                        TxtStep1TouchDistanceF.Text = TdDistance;
                                    }
                                    //Step One Knee Seperation at Touchdown
                                    var KneeAnkleSeparationAtTd = packageChild.Element("KneeAnkleSeparationAtTd").Value;
                                    if (KneeAnkleSeparationAtTd != "")
                                    {
                                        TxtStep1KSTouchDistanceF.Text = KneeAnkleSeparationAtTd;
                                    }

                                    //Step One Trunk Touchdown Angle
                                    var TrunkAngleAtTd = packageChild.Element("TrunkAngleAtTd").Value;
                                    if (TrunkAngleAtTd != "")
                                    {
                                        TxtStep1TrunkTouchdownAngleF.Text = TrunkAngleAtTd;
                                    }
                                    //Step One Trunk Takeoff Angle
                                    var TrunkAngleAtTo = packageChild.Element("TrunkAngleAtTo").Value;
                                    if (TrunkAngleAtTo != "")
                                    {
                                        TxtStep1TrunkTakeoffAngleF.Text = TrunkAngleAtTo;
                                    }

                                    //Step One Upper Leg at Full Extension
                                    var UlAngleAtFullExtension = packageChild.Element("UlAngleAtFullExtension").Value;
                                    if (UlAngleAtFullExtension != "")
                                    {
                                        TxtStep1ULFullExtensionF.Text = UlAngleAtFullExtension;
                                    }
                                    //Step One Lower Leg at Take off
                                    var LlAngleAtTo = packageChild.Element("LlAngleAtTo").Value;
                                    if (LlAngleAtTo != "")
                                    {
                                        TxtStep1LLTakeOffF.Text = LlAngleAtTo;
                                    }
                                    //Step One Upper Leg at Full Flexion
                                    var UlAngleAtFullFlexion = packageChild.Element("UlAngleAtFullFlexion").Value;
                                    if (UlAngleAtFullFlexion != "")
                                    {
                                        TxtStep1ULFullFlexionF.Text = UlAngleAtFullFlexion;
                                    }
                                }
                            }

                            //------------------<Step two>--------------------------------
                            IEnumerable<XElement> CurrentStep2 = returnnode.Elements("CurrentSummary").Elements("Step2");
                            if (CurrentStep2.Count() > 0)
                            {
                                foreach (XElement packageChild in CurrentStep2)
                                {
                                    //Step Two Ground Time
                                    var GroundTime = packageChild.Element("GroundTime").Value;
                                    if (GroundTime != "")
                                    {
                                        TxtStep2GroundTimeF.Text = GroundTime;
                                    }
                                    //Step Two Air Time
                                    var AirTime = packageChild.Element("AirTime").Value;
                                    if (AirTime != "")
                                    {
                                        TxtStep2AirTimeF.Text = AirTime;
                                    }
                                    //Step Two Stride Length
                                    var StrideLength = packageChild.Element("StrideLength").Value;
                                    if (StrideLength != "")
                                    {
                                        TxtStep2StrideLengthF.Text = StrideLength;
                                    }

                                    //Step Two Touchdown Distance
                                    var TdDistance = packageChild.Element("TdDistance").Value;
                                    if (TdDistance != "")
                                    {
                                        TxtStep2TouchDistanceF.Text = TdDistance;
                                    }
                                    //Step Two Knee Seperation at Touchdown
                                    var KneeKneeSeparationAtTd = packageChild.Element("KneeKneeSeparationAtTd").Value;
                                    if (KneeKneeSeparationAtTd != "")
                                    {
                                        TxtStep2KSTouchDistanceF.Text = KneeKneeSeparationAtTd;
                                    }
                                    //Step Two Trunk Touchdown Angle
                                    var TrunkAngleAtTd = packageChild.Element("TrunkAngleAtTd").Value;
                                    if (TrunkAngleAtTd != "")
                                    {
                                        TxtStep2TrunkTouchdownAngleF.Text = TrunkAngleAtTd;
                                    }
                                    //Step Two Trunk Takeoff Angle
                                    var TrunkAngleAtTo = packageChild.Element("TrunkAngleAtTo").Value;
                                    if (TrunkAngleAtTo != "")
                                    {
                                        TxtStep2TrunkTakeoffAngleF.Text = TrunkAngleAtTo;
                                    }
                                    //Step Two Upper Leg at Full Extension
                                    var UlAngleAtFullExtension = packageChild.Element("UlAngleAtFullExtension").Value;
                                    if (UlAngleAtFullExtension != "")
                                    {
                                        TxtStep2ULFullExtensionF.Text = UlAngleAtFullExtension;
                                    }
                                    //Step Two Lower Leg at Take off
                                    var LlAngleAtTo = packageChild.Element("LlAngleAtTo").Value;
                                    if (LlAngleAtTo != "")
                                    {
                                        TxtStep2LLTakeOffF.Text = LlAngleAtTo;
                                    }
                                    //Step Two Lower Leg at Full Flexion
                                    var LlAngleAtFullFlexion = packageChild.Element("LlAngleAtFullFlexion").Value;
                                    if (LlAngleAtFullFlexion != "")
                                    {
                                        TxtStep2LLFullFlexionF.Text = LlAngleAtFullFlexion;
                                    }
                                    //Step Two Upper Leg At Full Flexion
                                    var UlAngleAtFullFlexion = packageChild.Element("UlAngleAtFullFlexion").Value;
                                    if (UlAngleAtFullFlexion != "")
                                    {
                                        TxtStep2ULFullFlexionF.Text = UlAngleAtFullFlexion;
                                    }
                                }
                            }

                            // ------------------<Step Three>--------------------------------
                            IEnumerable<XElement> CurrentStep3 = returnnode.Elements("CurrentSummary").Elements("Step3");
                            if (CurrentStep3.Count() > 0)
                            {
                                foreach (XElement packageChild in CurrentStep3)
                                {
                                    //Step Three Ground Time
                                    var GroundTime = packageChild.Element("GroundTime").Value;
                                    if (GroundTime != "")
                                    {
                                        TxtStep3GroundTimeF.Text = GroundTime;
                                    }

                                    //Step Three Air Time
                                    var AirTime = packageChild.Element("AirTime").Value;
                                    if (AirTime != "")
                                    {
                                        TxtStep3AirTimeF.Text = AirTime;
                                    }

                                    //Step Three Stride Length
                                    var StrideLength = packageChild.Element("StrideLength").Value;
                                    if (StrideLength != "")
                                    {
                                        TxtStep3StrideLengthF.Text = StrideLength;
                                    }

                                    //Step Three Touchdown Distance
                                    var TdDistance = packageChild.Element("TdDistance").Value;
                                    if (TdDistance != "")
                                    {
                                        TxtStep3TouchDistanceF.Text = TdDistance;
                                    }
                                    //Step Three Knee Seperation at Touchdown
                                    var KneeKneeSeparationAtTd = packageChild.Element("KneeKneeSeparationAtTd").Value;
                                    if (KneeKneeSeparationAtTd != "")
                                    {
                                        TxtStep3KSTouchDistanceF.Text = KneeKneeSeparationAtTd;
                                    }
                                    //Step Three Trunk Touchdown Angle
                                    var TrunkAngleAtTd = packageChild.Element("TrunkAngleAtTd").Value;
                                    if (TrunkAngleAtTd != "")
                                    {
                                        TxtStep3TrunkTouchdownAngleF.Text = TrunkAngleAtTd;
                                    }

                                    //Step Three Trunk Takeoff Angle
                                    var TrunkAngleAtTo = packageChild.Element("TrunkAngleAtTo").Value;
                                    if (TrunkAngleAtTo != "")
                                    {
                                        TxtStep3TrunkTakeoffAngleF.Text = TrunkAngleAtTo;
                                    }
                                    //Step Three Upper Leg at Full Extension
                                    var UlAngleAtFullExtension = packageChild.Element("UlAngleAtFullExtension").Value;
                                    if (UlAngleAtFullExtension != "")
                                    {
                                        TxtStep3ULFullExtensionF.Text = UlAngleAtFullExtension;
                                    }

                                    //Step Three Lower Leg at Take off
                                    var LlAngleAtTo = packageChild.Element("LlAngleAtTo").Value;
                                    if (LlAngleAtTo != "")
                                    {
                                        TxtStep3LLTakeOffF.Text = LlAngleAtTo;
                                    }

                                    //Step Three Lower Leg Full Flexion
                                    var LlAngleAtFullFlexion = packageChild.Element("LlAngleAtFullFlexion").Value;
                                    if (LlAngleAtFullFlexion != "")
                                    {
                                        TxtStep3LLFullFlexionF.Text = LlAngleAtFullFlexion;
                                    }

                                    //Step Three Upper Leg At Full Flexion
                                    var UlAngleAtFullFlexion = packageChild.Element("UlAngleAtFullFlexion").Value;
                                    if (UlAngleAtFullFlexion != "")
                                    {
                                        TxtStep3ULFullFlexionF.Text = UlAngleAtFullFlexion;
                                    }
                                }
                            }

                            //  ---------------------<Into Hurdle>----------------------
                            IEnumerable<XElement> CurrentIntoHurdle = returnnode.Elements("CurrentSummary").Elements("IntoHurdle");
                            if (CurrentIntoHurdle.Count() > 0)
                            {
                                foreach (XElement packageChild in CurrentIntoHurdle)
                                {
                                    //Into Hurdle Touchdown Distance
                                    var TdDistance = packageChild.Element("TdDistance").Value;
                                    if (TdDistance != "")
                                    {
                                        TxtIntoHurdleTouchDistanceF.Text = TdDistance;
                                    }
                                    //Into Hurdle Knee Seperation at Touchdown
                                    var KneeKneeSeparationAtTd = packageChild.Element("KneeKneeSeparationAtTd").Value;
                                    if (KneeKneeSeparationAtTd != "")
                                    {
                                        TxtIntoHurdleKSTouchDistanceF.Text = KneeKneeSeparationAtTd;
                                    }
                                    //Into Hurdle Trunk Touchdown Angle
                                    var TrunkAngleAtTd = packageChild.Element("TrunkAngleAtTd").Value;
                                    if (TrunkAngleAtTd != "")
                                    {
                                        TxtIntoHurdleTrunkTouchdownAngleF.Text = TrunkAngleAtTd;
                                    }
                                    //Into Hurdle Lower Leg at Touchdown
                                    var LlAngleAtTo = packageChild.Element("LlAngleAtTo").Value;
                                    if (LlAngleAtTo != "")
                                    {
                                        TxtIntoHurdleLLTouchDistanceF.Text = LlAngleAtTo;
                                    }
                                }
                            }
                            btnUpload.Enabled = true;
                            btnToBrowseCurrentVideo.Enabled = true;
                            btnUpload2.Enabled = true;
                            btnSubmit.Enabled = true;
                            btnDeleteSession.Enabled = true;
                            btndateloc.Enabled = true;
                            btnInpuFullSession.Enabled = true;
                            btnDeleteInitialMovies.Enabled = true;
                            btnDeleteCurrentMovies.Enabled = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        btnUpload.Enabled = true;
                        btnToBrowseCurrentVideo.Enabled = true;
                        btnUpload2.Enabled = true;
                        btnSubmit.Enabled = true;
                        btnDeleteSession.Enabled = true;
                        btndateloc.Enabled = true;
                        btnInpuFullSession.Enabled = true;
                        btnDeleteInitialMovies.Enabled = true;
                        btnDeleteCurrentMovies.Enabled = true;
                        var error = ex.Message;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Selected Session Date and either Xml Session Date or at least one Video File Date do not match.\\nPlease resolve and try again');", true);
                    string text = "test \\n testing";

                    btnUpload.Enabled = true;
                    btnToBrowseCurrentVideo.Enabled = true;
                    btnUpload2.Enabled = true;
                    btnSubmit.Enabled = true;
                    btnDeleteSession.Enabled = true;
                    btndateloc.Enabled = true;
                    btnInpuFullSession.Enabled = true;
                    btnDeleteInitialMovies.Enabled = true;
                    btnDeleteCurrentMovies.Enabled = true;

                }
            }

        }

    }
    public string FormateDate(string date, string currentFormat)
    {
        try
        {
            var newDate = string.Empty;
            if (currentFormat == "dd/MM/yyyy")
            {
                string[] sDate = date.Split('/');
                int index = 0;
                foreach (string str in sDate)
                {
                    if (str.Length == 1)
                    {
                        sDate[index] = "0" + str;
                    }
                    index++;
                }
                string sDateTime = sDate[2] + '-' + sDate[1] + '-' + sDate[0];
                newDate = sDateTime;
            }
            else
            {
                //For IDL 
                if (date.Length == 19)
                {
                    string[] strArray = date.Split('T');
                    var IDLdate = strArray[0];
                    if (!string.IsNullOrEmpty(IDLdate))
                        newDate = DateTime.ParseExact(IDLdate, currentFormat, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                }
                else
                {
                    newDate = DateTime.ParseExact(date, currentFormat, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                }
            }
            return newDate;

        }
        catch (Exception e)
        {
            return date;
        }
    }
}

public class FilePathClassa2
{
    public int Index { get; set; }

    public string FilePath { get; set; }
}

