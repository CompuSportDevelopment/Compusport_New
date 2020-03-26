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


public partial class TrackData_SprintAthletEdit : System.Web.UI.UserControl
{
    TList<Lesson> lessonlist = new TList<Lesson>();
    TList<Lesson> lessonlistNew = new TList<Lesson>();
    string location;
    int lessonid;
    public string wmpfile = "";
    int x;
    int y;
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
    Customer Sprintcustomer;
    int summarysessionlessionid = 0;
    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    CompuSportDAL.SprintAthleteEdit sae = new CompuSportDAL.SprintAthleteEdit();
    CompuSportDAL.SprintData _SprintData = new CompuSportDAL.SprintData();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
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


    void sendNotFoundEmail(int initialcnt, int modelCnt, int CurrentCnt)
    {
        var _initialMessage = "This initial variable has 0 values = ";
        var _modelMessage = "This model variable has 0 values = ";
        var _currentMessage = "This current variable has 0 values = ";
        var message = "";
        var dataMising = false;
        for (int i = 0; i < missingVariable.Count; i++)
        {
            if (missingVariable[i].type == "initial" && initialcnt < 22)
            {
                dataMising = true;
                _initialMessage += missingVariable[i].variableName + ", ";
            }
            if (missingVariable[i].type == "model" && modelCnt < 22)
            {
                dataMising = true;
                _modelMessage += missingVariable[i].variableName + ", ";
            }
            if (missingVariable[i].type == "current" && CurrentCnt < 22) 
            {
                dataMising = true;
                _currentMessage += missingVariable[i].variableName + ", ";
            }
        }
        if (dataMising == true)
        {
            var lessiodatelocaon = (DropDownList2.SelectedItem.Text);
            message = "Session Details :- " + " Sprint " + " " + "->" + " " + lessiodatelocaon + "\n" + _initialMessage + "\n" + _modelMessage + "\n" + _currentMessage;
            var email = Membership.GetUser().Email;
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new System.Net.Mail.MailAddress(email);
             msg.To.Add("dev@Compusport.com");
            msg.Body = message;

            msg.Subject = "Compusport : " + Sprintcustomer.FirstName + " " + Sprintcustomer.LastName + " Data Missing";
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "198.143.141.120";
            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential("dev@compusport.com", "develop!?");
            smtp.Send(msg);
        }
    }

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
            OnTrackSession onTrackSession = new OnTrackSession();
            onTrackSession.OnTrackSessionData(athleteSelected);
            string expression = "LessonTypeID = 2";
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

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearAllData();
        DropDownList2.Items.Clear();
        DropdownListXmlFle.Items.Clear();
        if (!DropDownList1.SelectedValue.Equals("noathlete"))
        {
            ClearAllData();
            btnDeleteInitialMovies.Visible = true;
            btnDeleteCurrentMovies.Visible = true;
            btnDeleteSummaryMovie.Visible = true;
            Gridview1.Visible = false;
            Gridview2.Visible = false;
            Gridview3.Visible = false;
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
            Label117.Text = "";
            txtForCurrentVideo.Text = "";
            DropDownList2.Items.Clear();
            LoadExistingLocation();
            ClearFramesData();

        }
    }

    //05/01/2017
    private void DataClear()
    {
        #region[DataClear]

        lblGroundTimeLeftM1.Text = "";
        lblGroundTimeRightM1.Text = "";
        lblAirTimeLeftToRightM1.Text = "";
        lblAirTimeRightToLeftM1.Text = "";
        lblTimeToUpperLegFullFlexionLeftM1.Text = "";
        lblTimeToUpperLegFullFlexionRightM1.Text = "";
        lblStrideLengthLeftToRighM1.Text = "";
        lblStrideLengthRightToLeftM1.Text = "";
        lblTouchDownDistanceLeftM1.Text = "";
        lblTouchDownDistanceRightM1.Text = "";
        lblUpperLegFullExtentionAngleLeftM1.Text = "";
        lblUpperLegFullExtentionAngleRightM1.Text = "";
        lblLowerLegAngleAtTakeOfLeftM1.Text = "";
        lblLowerLegAngleAtTakeOfRightM1.Text = "";
        lblLowerLegFullFlexionAngleLeftM1.Text = "";
        lblLowerLegFullFlexionAngleRightM1.Text = "";
        lblTrunkAngleAtTouchdownLeftM1.Text = "";
        lblTrunkAngleAtTouchdownRightM1.Text = "";
        lblKneeSeperationAtTouchdownLeftM1.Text = "";
        lblKneeSeperationAtTouchdownRightM1.Text = "";
        //lblLowerLegAngleAtAnkleCrossLeftM1.Text = "";
        //lblLowerLegAngleAtAnkleCrossRightM1.Text = "";
        lblUpperLegFullFlexionAngleLeftM1.Text = "";
        lblUpperLegFullFlexionAngleRightM1.Text = "";



        #endregion[DataClear]

    }
    private void ClearData()
    {
        #region[Cleardata]
        lblGroundTimeLeftI.Text = "";
        lblGroundTimeRightI.Text = "";
        lblAirTimeLeftToRightI.Text = "";
        lblAirTimeRightToLeftI.Text = "";

        lblTimeToUpperLegFullFlexionLeftI.Text = "";
        lblTimeToUpperLegFullFlexionRightI.Text = "";
        lblStrideLengthLeftToRightI.Text = "";
        lblStrideLengthRightToLeftI.Text = "";
        lblTouchDownDistanceLeftI.Text = "";
        lblTouchDownDistanceRightI.Text = "";
        lblUpperLegFullExtentionAngleLeftI.Text = "";
        lblUpperLegFullExtentionAngleRightI.Text = "";
        lblLowerLegAngleAtTakeOfLeftI.Text = "";
        lblLowerLegAngleAtTakeOfRightI.Text = "";
        lblLowerLegFullFlexionAngleLeftI.Text = "";
        lblLowerLegFullFlexionAngleRightI.Text = "";
        lblTrunkAngleAtTouchdownLeftI.Text = "";
        lblTrunkAngleAtTouchdownRightI.Text = "";
        lblKneeSeperationAtTouchdownLeftI.Text = "";
        lblKneeSeperationAtTouchdownRightI.Text = "";
        //lblLowerLegAngleAtAnkleCrossLeftI.Text = ""; 
        //lblLowerLegAngleAtAnkleCrossRightI.Text = ""; 
        lblUpperLegFullFlexionAngleLeftI.Text = "";
        lblUpperLegFullFlexionAngleRightI.Text = "";



        lblGroundTimeLeftF.Text = "";
        lblGroundTimeRightF.Text = "";
        lblAirTimeLeftToRightF.Text = "";
        lblAirTimeRightToLeftF.Text = "";
        lblTimeToUpperLegFullFlexionLeftF.Text = "";
        lblTimeToUpperLegFullFlexionRightF.Text = "";
        lblStrideLengthLeftToRighF.Text = "";
        lblStrideLengthRightToLeftF.Text = "";
        lblTouchDownDistanceLeftF.Text = "";
        lblTouchDownDistanceRightF.Text = "";
        lblUpperLegFullExtentionAngleLeftF.Text = "";
        lblUpperLegFullExtentionAngleRightF.Text = "";
        lblLowerLegAngleAtTakeOfLeftF.Text = "";
        lblLowerLegAngleAtTakeOfRightF.Text = "";
        lblLowerLegFullFlexionAngleLeftF.Text = "";
        lblLowerLegFullFlexionAngleRightF.Text = "";
        lblTrunkAngleAtTouchdownLeftF.Text = "";
        lblTrunkAngleAtTouchdownRightF.Text = "";
        //lblLowerLegAngleAtAnkleCrossLeftF.Text = "";
        //lblLowerLegAngleAtAnkleCrossRightF.Text = "";
        lblUpperLegFullFlexionAngleLeftF.Text = "";
        lblUpperLegFullFlexionAngleRightF.Text = "";
        lblKneeSeperationAtTouchdownLeftF.Text = "";
        lblKneeSeperationAtTouchdownRightF.Text = "";
        Label117.Text = "";
        #endregion[Cleardata]

    }
    private void ClearAllData()
    {
        lblGroundTimeLeftI.Text = "";
        lblGroundTimeRightI.Text = "";
        lblAirTimeLeftToRightI.Text = "";
        lblAirTimeRightToLeftI.Text = "";

        lblTimeToUpperLegFullFlexionLeftI.Text = "";
        lblTimeToUpperLegFullFlexionRightI.Text = "";
        lblStrideLengthLeftToRightI.Text = "";
        lblStrideLengthRightToLeftI.Text = "";
        lblTouchDownDistanceLeftI.Text = "";
        lblTouchDownDistanceRightI.Text = "";
        lblUpperLegFullExtentionAngleLeftI.Text = "";
        lblUpperLegFullExtentionAngleRightI.Text = "";
        lblLowerLegAngleAtTakeOfLeftI.Text = "";
        lblLowerLegAngleAtTakeOfRightI.Text = "";
        lblLowerLegFullFlexionAngleLeftI.Text = "";
        lblLowerLegFullFlexionAngleRightI.Text = "";
        lblTrunkAngleAtTouchdownLeftI.Text = "";
        lblTrunkAngleAtTouchdownRightI.Text = "";
        lblKneeSeperationAtTouchdownLeftI.Text = "";
        lblKneeSeperationAtTouchdownRightI.Text = "";
        //lblLowerLegAngleAtAnkleCrossLeftI.Text = ""; 
        //lblLowerLegAngleAtAnkleCrossRightI.Text = ""; 
        lblUpperLegFullFlexionAngleLeftI.Text = "";
        lblUpperLegFullFlexionAngleRightI.Text = "";

        lblGroundTimeLeftM1.Text = "";
        lblGroundTimeRightM1.Text = "";
        lblAirTimeLeftToRightM1.Text = "";
        lblAirTimeRightToLeftM1.Text = "";
        lblTimeToUpperLegFullFlexionLeftM1.Text = "";
        lblTimeToUpperLegFullFlexionRightM1.Text = "";
        lblStrideLengthLeftToRighM1.Text = "";
        lblStrideLengthRightToLeftM1.Text = "";
        lblTouchDownDistanceLeftM1.Text = "";
        lblTouchDownDistanceRightM1.Text = "";
        lblUpperLegFullExtentionAngleLeftM1.Text = "";
        lblUpperLegFullExtentionAngleRightM1.Text = "";
        lblLowerLegAngleAtTakeOfLeftM1.Text = "";
        lblLowerLegAngleAtTakeOfRightM1.Text = "";
        lblLowerLegFullFlexionAngleLeftM1.Text = "";
        lblLowerLegFullFlexionAngleRightM1.Text = "";
        lblTrunkAngleAtTouchdownLeftM1.Text = "";
        lblTrunkAngleAtTouchdownRightM1.Text = "";
        lblKneeSeperationAtTouchdownLeftM1.Text = "";
        lblKneeSeperationAtTouchdownRightM1.Text = "";
        // lblLowerLegAngleAtAnkleCrossLeftM1.Text = ""; // already commint
        //lblLowerLegAngleAtAnkleCrossRightM1.Text = "";// already commint
        lblUpperLegFullFlexionAngleLeftM1.Text = "";
        lblUpperLegFullFlexionAngleRightM1.Text = "";



        lblGroundTimeLeftF.Text = "";
        lblGroundTimeRightF.Text = "";
        lblAirTimeLeftToRightF.Text = "";
        lblAirTimeRightToLeftF.Text = "";
        lblTimeToUpperLegFullFlexionLeftF.Text = "";
        lblTimeToUpperLegFullFlexionRightF.Text = "";
        lblStrideLengthLeftToRighF.Text = "";
        lblStrideLengthRightToLeftF.Text = "";
        lblTouchDownDistanceLeftF.Text = "";
        lblTouchDownDistanceRightF.Text = "";
        lblUpperLegFullExtentionAngleLeftF.Text = "";
        lblUpperLegFullExtentionAngleRightF.Text = "";
        lblLowerLegAngleAtTakeOfLeftF.Text = "";
        lblLowerLegAngleAtTakeOfRightF.Text = "";
        lblLowerLegFullFlexionAngleLeftF.Text = "";
        lblLowerLegFullFlexionAngleRightF.Text = "";
        lblTrunkAngleAtTouchdownLeftF.Text = "";
        lblTrunkAngleAtTouchdownRightF.Text = "";
        //lblLowerLegAngleAtAnkleCrossLeftF.Text = "";
        //lblLowerLegAngleAtAnkleCrossRightF.Text = "";
        lblUpperLegFullFlexionAngleLeftF.Text = "";
        lblUpperLegFullFlexionAngleRightF.Text = "";
        lblKneeSeperationAtTouchdownLeftF.Text = "";
        lblKneeSeperationAtTouchdownRightF.Text = "";
        Label117.Text = "";
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
        txtForCurrentVideo.Text = "";
        txtSumFilePath.Text = "";
        txtbFilePath.Text = "";
    }

    public void readtext()
    {

        lblGroundTimeLeftI.ReadOnly = false;
        lblGroundTimeRightI.ReadOnly = false;
        lblAirTimeLeftToRightI.ReadOnly = false;
        lblAirTimeRightToLeftI.ReadOnly = false;

        lblTimeToUpperLegFullFlexionLeftI.ReadOnly = false;
        lblTimeToUpperLegFullFlexionRightI.ReadOnly = false;
        lblStrideLengthLeftToRightI.ReadOnly = false;
        lblStrideLengthRightToLeftI.ReadOnly = false;
        lblTouchDownDistanceLeftI.ReadOnly = false;
        lblTouchDownDistanceRightI.ReadOnly = false;
        lblUpperLegFullExtentionAngleLeftI.ReadOnly = false;
        lblUpperLegFullExtentionAngleRightI.ReadOnly = false;
        lblLowerLegAngleAtTakeOfLeftI.ReadOnly = false;
        lblLowerLegAngleAtTakeOfRightI.ReadOnly = false;
        lblLowerLegFullFlexionAngleLeftI.ReadOnly = false;
        lblLowerLegFullFlexionAngleRightI.ReadOnly = false;
        lblTrunkAngleAtTouchdownLeftI.ReadOnly = false;
        lblTrunkAngleAtTouchdownRightI.ReadOnly = false;
        lblKneeSeperationAtTouchdownLeftI.ReadOnly = false;
        lblKneeSeperationAtTouchdownRightI.ReadOnly = false;
        //lblLowerLegAngleAtAnkleCrossLeftI.Text = ""; 
        //lblLowerLegAngleAtAnkleCrossRightI.Text = ""; 
        lblUpperLegFullFlexionAngleLeftI.ReadOnly = false;
        lblUpperLegFullFlexionAngleRightI.ReadOnly = false;

        lblGroundTimeLeftM1.ReadOnly = false;
        lblGroundTimeRightM1.ReadOnly = false;
        lblAirTimeLeftToRightM1.ReadOnly = false;
        lblAirTimeRightToLeftM1.ReadOnly = false;
        lblTimeToUpperLegFullFlexionLeftM1.ReadOnly = false;
        lblTimeToUpperLegFullFlexionRightM1.ReadOnly = false;
        lblStrideLengthLeftToRighM1.ReadOnly = false;
        lblStrideLengthRightToLeftM1.ReadOnly = false;
        lblTouchDownDistanceLeftM1.ReadOnly = false;
        lblTouchDownDistanceRightM1.ReadOnly = false;
        lblUpperLegFullExtentionAngleLeftM1.ReadOnly = false;
        lblUpperLegFullExtentionAngleRightM1.ReadOnly = false;
        lblLowerLegAngleAtTakeOfLeftM1.ReadOnly = false;
        lblLowerLegAngleAtTakeOfRightM1.ReadOnly = false;
        lblLowerLegFullFlexionAngleLeftM1.ReadOnly = false;
        lblLowerLegFullFlexionAngleRightM1.ReadOnly = false;
        lblTrunkAngleAtTouchdownLeftM1.ReadOnly = false;
        lblTrunkAngleAtTouchdownRightM1.ReadOnly = false;
        lblKneeSeperationAtTouchdownLeftM1.ReadOnly = false;
        lblKneeSeperationAtTouchdownRightM1.ReadOnly = false;
        //lblLowerLegAngleAtAnkleCrossLeftM1.Text = ""; // already commint
        //lblLowerLegAngleAtAnkleCrossRightM1.Text = "";// already commint
        lblUpperLegFullFlexionAngleLeftM1.ReadOnly = false;
        lblUpperLegFullFlexionAngleRightM1.ReadOnly = false;



        lblGroundTimeLeftF.ReadOnly = false;
        lblGroundTimeRightF.ReadOnly = false;
        lblAirTimeLeftToRightF.ReadOnly = false;
        lblAirTimeRightToLeftF.ReadOnly = false;
        lblTimeToUpperLegFullFlexionLeftF.ReadOnly = false;
        lblTimeToUpperLegFullFlexionRightF.ReadOnly = false;
        lblStrideLengthLeftToRighF.ReadOnly = false;
        lblStrideLengthRightToLeftF.ReadOnly = false;
        lblTouchDownDistanceLeftF.ReadOnly = false;
        lblTouchDownDistanceRightF.ReadOnly = false;
        lblUpperLegFullExtentionAngleLeftF.ReadOnly = false;
        lblUpperLegFullExtentionAngleRightF.ReadOnly = false;
        lblLowerLegAngleAtTakeOfLeftF.ReadOnly = false;
        lblLowerLegAngleAtTakeOfRightF.ReadOnly = false;
        lblLowerLegFullFlexionAngleLeftF.ReadOnly = false;
        lblLowerLegFullFlexionAngleRightF.ReadOnly = false;
        lblTrunkAngleAtTouchdownLeftF.ReadOnly = false;
        lblTrunkAngleAtTouchdownRightF.ReadOnly = false;
        //lblLowerLegAngleAtAnkleCrossLeftF.Text = "";
        //lblLowerLegAngleAtAnkleCrossRightF.Text = "";
        lblUpperLegFullFlexionAngleLeftF.ReadOnly = false;
        lblUpperLegFullFlexionAngleRightF.ReadOnly = false;
        lblKneeSeperationAtTouchdownLeftF.ReadOnly = false;
        lblKneeSeperationAtTouchdownRightF.ReadOnly = false;

        txtCBFrame1.ReadOnly = false;
        txtCBFrame2.ReadOnly = false;
        txtCBFrame3.ReadOnly = false;
        txtCBFrame4.ReadOnly = false;
        txtCBFrame5.ReadOnly = false;
        txtCBFrame6.ReadOnly = false;
        txtCBFrame7.ReadOnly = false;
        txtCBFrame8.ReadOnly = false;

        txtBFrame1.ReadOnly = false;
        txtBFrame2.ReadOnly = false;
        txtBFrame3.ReadOnly = false;
        txtBFrame4.ReadOnly = false;
        txtBFrame5.ReadOnly = false;
        txtBFrame6.ReadOnly = false;
        txtBFrame7.ReadOnly = false;
        txtBFrame8.ReadOnly = false;

        txtLocation.Text = "";

        txtForCurrentVideo.ReadOnly = false;
        txtSumFilePath.ReadOnly = false;
        txtbFilePath.ReadOnly = false;

        btnUpload.Enabled = true;
        btnToBrowseCurrentVideo.Enabled = true;
        btnUpload2.Enabled = true;
        btnSubmit.Enabled = true;
        btnDeleteInitialMovies.Enabled = true;
        btnDeleteCurrentMovies.Enabled = true;
    }

    public void OntrackSessionSelect()
    {
        lblGroundTimeLeftI.ReadOnly = true;
        lblGroundTimeRightI.ReadOnly = true;
        lblAirTimeLeftToRightI.ReadOnly = true;
        lblAirTimeRightToLeftI.ReadOnly = true;

        lblTimeToUpperLegFullFlexionLeftI.ReadOnly = true;
        lblTimeToUpperLegFullFlexionRightI.ReadOnly = true;
        lblStrideLengthLeftToRightI.ReadOnly = true;
        lblStrideLengthRightToLeftI.ReadOnly = true;
        lblTouchDownDistanceLeftI.ReadOnly = true;
        lblTouchDownDistanceRightI.ReadOnly = true;
        lblUpperLegFullExtentionAngleLeftI.ReadOnly = true;
        lblUpperLegFullExtentionAngleRightI.ReadOnly = true;
        lblLowerLegAngleAtTakeOfLeftI.ReadOnly = true;
        lblLowerLegAngleAtTakeOfRightI.ReadOnly = true;
        lblLowerLegFullFlexionAngleLeftI.ReadOnly = true;
        lblLowerLegFullFlexionAngleRightI.ReadOnly = true;
        lblTrunkAngleAtTouchdownLeftI.ReadOnly = true;
        lblTrunkAngleAtTouchdownRightI.ReadOnly = true;
        lblKneeSeperationAtTouchdownLeftI.ReadOnly = true;
        lblKneeSeperationAtTouchdownRightI.ReadOnly = true;
        //lblLowerLegAngleAtAnkleCrossLeftI.Text = ""; 
        //lblLowerLegAngleAtAnkleCrossRightI.Text = ""; 
        lblUpperLegFullFlexionAngleLeftI.ReadOnly = true;
        lblUpperLegFullFlexionAngleRightI.ReadOnly = true;

        lblGroundTimeLeftM1.ReadOnly = true;
        lblGroundTimeRightM1.ReadOnly = true;
        lblAirTimeLeftToRightM1.ReadOnly = true;
        lblAirTimeRightToLeftM1.ReadOnly = true;
        lblTimeToUpperLegFullFlexionLeftM1.ReadOnly = true;
        lblTimeToUpperLegFullFlexionRightM1.ReadOnly = true;
        lblStrideLengthLeftToRighM1.ReadOnly = true;
        lblStrideLengthRightToLeftM1.ReadOnly = true;
        lblTouchDownDistanceLeftM1.ReadOnly = true;
        lblTouchDownDistanceRightM1.ReadOnly = true;
        lblUpperLegFullExtentionAngleLeftM1.ReadOnly = true;
        lblUpperLegFullExtentionAngleRightM1.ReadOnly = true;
        lblLowerLegAngleAtTakeOfLeftM1.ReadOnly = true;
        lblLowerLegAngleAtTakeOfRightM1.ReadOnly = true;
        lblLowerLegFullFlexionAngleLeftM1.ReadOnly = true;
        lblLowerLegFullFlexionAngleRightM1.ReadOnly = true;
        lblTrunkAngleAtTouchdownLeftM1.ReadOnly = true;
        lblTrunkAngleAtTouchdownRightM1.ReadOnly = true;
        lblKneeSeperationAtTouchdownLeftM1.ReadOnly = true;
        lblKneeSeperationAtTouchdownRightM1.ReadOnly = false;
        //lblLowerLegAngleAtAnkleCrossLeftM1.Text = ""; // already commint
        //lblLowerLegAngleAtAnkleCrossRightM1.Text = "";// already commint
        lblUpperLegFullFlexionAngleLeftM1.ReadOnly = true;
        lblUpperLegFullFlexionAngleRightM1.ReadOnly = true;



        lblGroundTimeLeftF.ReadOnly = true;
        lblGroundTimeRightF.ReadOnly = true;
        lblAirTimeLeftToRightF.ReadOnly = true;
        lblAirTimeRightToLeftF.ReadOnly = true;
        lblTimeToUpperLegFullFlexionLeftF.ReadOnly = true;
        lblTimeToUpperLegFullFlexionRightF.ReadOnly = true;
        lblStrideLengthLeftToRighF.ReadOnly = true;
        lblStrideLengthRightToLeftF.ReadOnly = true;
        lblTouchDownDistanceLeftF.ReadOnly = true;
        lblTouchDownDistanceRightF.ReadOnly = true;
        lblUpperLegFullExtentionAngleLeftF.ReadOnly = true;
        lblUpperLegFullExtentionAngleRightF.ReadOnly = true;
        lblLowerLegAngleAtTakeOfLeftF.ReadOnly = true;
        lblLowerLegAngleAtTakeOfRightF.ReadOnly = true;
        lblLowerLegFullFlexionAngleLeftF.ReadOnly = true;
        lblLowerLegFullFlexionAngleRightF.ReadOnly = true;
        lblTrunkAngleAtTouchdownLeftF.ReadOnly = true;
        lblTrunkAngleAtTouchdownRightF.ReadOnly = true;
        //lblLowerLegAngleAtAnkleCrossRightF.Text = "";
        lblUpperLegFullFlexionAngleLeftF.ReadOnly = true;
        lblUpperLegFullFlexionAngleRightF.ReadOnly = true;
        lblKneeSeperationAtTouchdownLeftF.ReadOnly = true;
        lblKneeSeperationAtTouchdownRightF.ReadOnly = true;

        txtCBFrame1.ReadOnly = true;
        txtCBFrame2.ReadOnly = true;
        txtCBFrame3.ReadOnly = true;
        txtCBFrame4.ReadOnly = true;
        txtCBFrame5.ReadOnly = true;
        txtCBFrame6.ReadOnly = true;
        txtCBFrame7.ReadOnly = true;
        txtCBFrame8.ReadOnly = true;

        txtBFrame1.ReadOnly = true;
        txtBFrame2.ReadOnly = true;
        txtBFrame3.ReadOnly = true;
        txtBFrame4.ReadOnly = true;
        txtBFrame5.ReadOnly = true;
        txtBFrame6.ReadOnly = true;
        txtBFrame7.ReadOnly = true;
        txtBFrame8.ReadOnly = true;

        txtLocation.Text = "";

        txtForCurrentVideo.ReadOnly = true;
        txtSumFilePath.ReadOnly = true;
        txtbFilePath.ReadOnly = true;
        DropdownListXmlFle.Enabled = true;

        btnUpload.Enabled = false;
        btnToBrowseCurrentVideo.Enabled = false;
        btnUpload2.Enabled = false;
        btnSubmit.Enabled = false;
        btnDeleteInitialMovies.Enabled = false;
        btnDeleteCurrentMovies.Enabled = false;
        //btnDeleteSession.Enabled = false;
        btnInpuFullSession.Enabled = false;

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


                Customer custmer = Sprintcustomer = DataRepository.CustomerProvider.GetByCustomerId(AthleteSelected);
                Lesson lesson = DataRepository.LessonProvider.GetByLessonId(LessonSelected);
                int lessonid = lesson.LessonId;
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
                dsmodelData = sae.GetAllSprintAthletesData(lessonid);

                string groundtime = string.Empty;
                var tablegroundtime = dsmodelData.Tables[1];
                string groundtimeI = string.Empty;
                var tablegroundtimeI = dsmodelData.Tables[0];
                string groundtimeC = string.Empty;
                var tablegroundtimeC = dsmodelData.Tables[2];
                string groundtimeM = string.Empty;
                var tablegroundtimeM = dsmodelData.Tables[4];
                if (tablegroundtime.Rows.Count > 0)
                {
                    groundtime = dsmodelData.Tables[1].Rows[0]["GroundTime"].ToString();
                }
                if (tablegroundtimeI.Rows.Count > 0)
                {
                    groundtimeI = dsmodelData.Tables[0].Rows[0]["Ground Time Left"].ToString();
                }
                if (tablegroundtimeC.Rows.Count > 0)
                {
                    groundtimeC = dsmodelData.Tables[2].Rows[0]["Ground Time Left"].ToString();
                }
                missingVariable.Clear();
                string location1 = sae.SelectLessonlocation(lesson.LessonId.ToString());
                if ((tablegroundtimeM.Rows.Count > 0) && location1 == "On-Track Sesssion Summary")
                {
                    groundtimeM = dsmodelData.Tables[4].Rows[0]["Ground Time Left"].ToString();
                }
                if (!string.IsNullOrEmpty(groundtimeM))
                {
                    string location = sae.SelectLessonlocation(lesson.LessonId.ToString());
                    if (location == "On-Track Sesssion Summary")
                    {
                        OntrackSessionSelect();
                        GetAllSprintAthleteOnTrackData(lessonid);
                    }
                }
                else if ((groundtimeI != "0.000" || groundtimeC != "0.000") && (groundtime != "" && groundtime != "0.000") || (groundtimeM != "0.000") && (groundtimeM != ""))
                {
                    GetAllSprintAthleteData(lessonid);
                }
                else if ((groundtime != "" && groundtime != "0.000") || (groundtimeM != "0.000") && (groundtimeM != ""))
                {
                    GetAllSprintAthleteData(lessonid);
                }
                else
                {
                    GetAllSprintAthleteInitialAndCurrentData(lessonid);
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
                        dsmodelData = sae.GetAllSprintAthletesData(summarysessionlessionid);
                        if (!string.IsNullOrEmpty(groundtimeM))
                        {
                            if ((groundtimeM != "0.000") && (groundtimeM != ""))
                            {
                                BindModelDataOnly(dsmodelData);
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
                            readtext();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                GetAllSprintAthleteData(lessonid);
                txtbFilePath.Text = "";
                txtSumFilePath.Text = "";
                btnUpload2.Visible = true;
                txtSumFilePath.Visible = true;
                ClearData();
                Gridview1.Visible = false;
                txtbFilePath.Text = "";
                txtbFilePath.Visible = true;
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
            ClearAllData();
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
        Label117.Text = "";
        Label1.Text = "";
        movieSide = new Movie();
        summaryMovie = new SummaryMovie();
        Movie movieBack = new Movie();

        if (!DropDownList1.SelectedValue.Equals("noathlete"))
        {
            Lesson lesson = new Lesson();
            int LessonSelected = 0;
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
                lesson.LessonTypeId = 2;
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
                    lesson.LessonTypeId = 2;
                    lesson.MachineNumber = 1;
                    lesson.TeacherId = Convert.ToInt32(dstecher.Tables[0].Rows[0]["TeacherId"].ToString());
                    DataRepository.LessonProvider.Insert(lesson);
                    // sae.InsertIntoLessonLocation(lesson.LessonId, location);
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
            #endregion[Insert or Update Lession data ]
            #region[Insert or Update Spirint Inital Data ]
            try
            {
                _SprintData.LessonId = lesson.LessonId;
                _SprintData.GroundTimeLeft = convertDecimal(lblGroundTimeLeftI.Text);
                _SprintData.GroundTimeRight = convertDecimal(lblGroundTimeRightI.Text);
                _SprintData.AirTimeLeftToRight = convertDecimal(lblAirTimeLeftToRightI.Text);
                _SprintData.AirTimeRightToLeft = convertDecimal(lblAirTimeRightToLeftI.Text);
                _SprintData.FullFlexionTimeLeft = convertDecimal(lblTimeToUpperLegFullFlexionLeftI.Text);
                _SprintData.FullFlexionTimeRight = convertDecimal(lblTimeToUpperLegFullFlexionRightI.Text);
                _SprintData.StrideLengthLeftToRight = convertDecimal(lblStrideLengthLeftToRightI.Text);
                _SprintData.StrideLengthRightToLeft = convertDecimal(lblStrideLengthRightToLeftI.Text);
                _SprintData.TAATouchDownLeft = convertInt(lblTrunkAngleAtTouchdownLeftI.Text);
                _SprintData.TAATouchDownRight = convertInt(lblTrunkAngleAtTouchdownRightI.Text);
                _SprintData.KSATouchDownLeft = convertDecimal(lblKneeSeperationAtTouchdownLeftI.Text);
                _SprintData.KSATouchDownRight = convertDecimal(lblKneeSeperationAtTouchdownRightI.Text);
                _SprintData.COGDistanceLeft = convertDecimal(lblTouchDownDistanceLeftI.Text);
                _SprintData.COGDistanceRight = convertDecimal(lblTouchDownDistanceRightI.Text);
                _SprintData.ULFullExtensionAngleLeft = convertInt(lblUpperLegFullExtentionAngleLeftI.Text);
                _SprintData.ULFullExtensionAngleRight = convertInt(lblUpperLegFullExtentionAngleRightI.Text);
                _SprintData.LLAngleTakeoffLeft = convertInt(lblLowerLegAngleAtTakeOfLeftI.Text);
                _SprintData.LLAAngleTakeoffRight = convertInt(lblLowerLegAngleAtTakeOfRightI.Text);
                _SprintData.LLFullFlexionAngleLeft = convertInt(lblLowerLegFullFlexionAngleLeftI.Text);
                _SprintData.LLFullFlexionAngleRight = convertInt(lblLowerLegFullFlexionAngleRightI.Text);
                _SprintData.ULFullFlexionAngleLeft = convertInt(lblUpperLegFullFlexionAngleLeftI.Text);
                _SprintData.ULFullFlexionAngleRight = convertInt(lblUpperLegFullFlexionAngleRightI.Text);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            //---------------------Final-----------------
            // _SprintData.LessonId = Convert.ToInt32(DropDownList2.SelectedValue);
            string Sprint_InitialDataId = sae.SelectSprintInitialDataid(_SprintData.LessonId.ToString());

            if (Sprint_InitialDataId == "")
            {
                _SprintData.InsertIntoSprintInitialData();
            }
            else
            {
                _SprintData.UpdateSprinttInitialData();
            }
            #endregion[Insert or Update Spirint Inital Data ]
            #region[Insert Or Update Sprint Current Data]
            try
            {
                _SprintData.LessonId = lesson.LessonId;


                _SprintData.GroundTimeLeft = convertDecimal(lblGroundTimeLeftF.Text);
                _SprintData.GroundTimeRight = convertDecimal(lblGroundTimeRightF.Text);
                _SprintData.AirTimeLeftToRight = convertDecimal(lblAirTimeLeftToRightF.Text);
                _SprintData.AirTimeRightToLeft = convertDecimal(lblAirTimeRightToLeftF.Text);
                _SprintData.FullFlexionTimeLeft = convertDecimal(lblTimeToUpperLegFullFlexionLeftF.Text);
                _SprintData.FullFlexionTimeRight = convertDecimal(lblTimeToUpperLegFullFlexionRightF.Text);
                _SprintData.StrideLengthLeftToRight = convertDecimal(lblStrideLengthLeftToRighF.Text);
                _SprintData.StrideLengthRightToLeft = convertDecimal(lblStrideLengthRightToLeftF.Text);
                _SprintData.KSATouchDownLeft = convertDecimal(lblKneeSeperationAtTouchdownLeftF.Text);
                _SprintData.KSATouchDownRight = convertDecimal(lblKneeSeperationAtTouchdownRightF.Text);
                _SprintData.COGDistanceLeft = convertDecimal(lblTouchDownDistanceLeftF.Text);
                _SprintData.COGDistanceRight = convertDecimal(lblTouchDownDistanceRightF.Text);

                _SprintData.TAATouchDownLeft = convertInt(lblTrunkAngleAtTouchdownLeftF.Text);
                _SprintData.TAATouchDownRight = convertInt(lblTrunkAngleAtTouchdownRightF.Text);
                _SprintData.ULFullExtensionAngleLeft = convertInt(lblUpperLegFullExtentionAngleLeftF.Text);
                _SprintData.ULFullExtensionAngleRight = convertInt(lblUpperLegFullExtentionAngleRightF.Text);
                _SprintData.LLAngleTakeoffLeft = convertInt(lblLowerLegAngleAtTakeOfLeftF.Text);
                _SprintData.LLAAngleTakeoffRight = convertInt(lblLowerLegAngleAtTakeOfRightF.Text);
                _SprintData.LLFullFlexionAngleLeft = convertInt(lblLowerLegFullFlexionAngleLeftF.Text);
                _SprintData.LLFullFlexionAngleRight = convertInt(lblLowerLegFullFlexionAngleRightF.Text);
                _SprintData.ULFullFlexionAngleLeft = convertInt(lblUpperLegFullFlexionAngleLeftF.Text);
                _SprintData.ULFullFlexionAngleRight = convertInt(lblUpperLegFullFlexionAngleRightF.Text);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            //_SprintData.LessonId = Convert.ToInt32(DropDownList2.SelectedValue);
            string Sprint_CurrentDataId = sae.SelectSprintCurrentDataid(_SprintData.LessonId.ToString());
            if (Sprint_CurrentDataId == "")
            {
                _SprintData.InsertIntoSprintCurrentData();
            }
            else
            {
                _SprintData.UpdateSprintCurrentData();
            }
            #endregion[Insert Or Update Sprint Current Data]
            #region[Insertupdate to SprintModelData]
            try
            {
                _SprintData.LessonId = lesson.LessonId;
                _SprintData.GroundTime = convertDecimal(lblGroundTimeLeftM1.Text);
                _SprintData.AirTime = convertDecimal(lblAirTimeLeftToRightM1.Text);
                _SprintData.FullFlexionTime = convertDecimal(lblTimeToUpperLegFullFlexionLeftM1.Text);
                _SprintData.StrideLength = convertDecimal(lblStrideLengthLeftToRighM1.Text);
                _SprintData.TAATouchDown = convertInt(lblTrunkAngleAtTouchdownLeftM1.Text);
                _SprintData.TAATouchDown = convertInt(lblTrunkAngleAtTouchdownRightM1.Text);
                _SprintData.KSATouchDown = convertDecimal(lblKneeSeperationAtTouchdownLeftM1.Text);
                _SprintData.KSATouchDown = convertDecimal(lblKneeSeperationAtTouchdownRightM1.Text);
                _SprintData.COGDistance = convertDecimal(lblTouchDownDistanceLeftM1.Text);
                _SprintData.ULFullExtensionAngle = convertInt(lblUpperLegFullExtentionAngleLeftM1.Text);
                _SprintData.LLAngleTakeoff = convertInt(lblLowerLegAngleAtTakeOfLeftM1.Text);
                _SprintData.LLFullFlexionAngle = convertInt(lblLowerLegFullFlexionAngleLeftM1.Text);
                _SprintData.ULFullFlexionAngle = convertInt(lblUpperLegFullFlexionAngleLeftM1.Text);
                _SprintData.GroundTimeLeft = convertDecimal(lblGroundTimeLeftM1.Text);
                _SprintData.GroundTimeRight = convertDecimal(lblGroundTimeRightM1.Text);
                _SprintData.AirTimeLeftToRight = convertDecimal(lblAirTimeLeftToRightM1.Text);
                _SprintData.AirTimeRightToLeft = convertDecimal(lblAirTimeRightToLeftM1.Text);
                _SprintData.FullFlexionTimeLeft = convertDecimal(lblTimeToUpperLegFullFlexionLeftM1.Text);
                _SprintData.FullFlexionTimeRight = convertDecimal(lblTimeToUpperLegFullFlexionRightM1.Text);
                _SprintData.StrideLengthLeftToRight = convertDecimal(lblStrideLengthLeftToRighM1.Text);
                _SprintData.StrideLengthRightToLeft = convertDecimal(lblStrideLengthRightToLeftM1.Text);
                _SprintData.KSATouchDownLeft = convertDecimal(lblKneeSeperationAtTouchdownLeftM1.Text);
                _SprintData.KSATouchDownRight = convertDecimal(lblKneeSeperationAtTouchdownRightM1.Text);
                _SprintData.COGDistanceLeft = convertDecimal(lblTouchDownDistanceLeftM1.Text);
                _SprintData.COGDistanceRight = convertDecimal(lblTouchDownDistanceRightM1.Text);
                _SprintData.TAATouchDownLeft = convertInt(lblTrunkAngleAtTouchdownLeftM1.Text);
                _SprintData.TAATouchDownRight = convertInt(lblTrunkAngleAtTouchdownRightM1.Text);
                _SprintData.ULFullExtensionAngleLeft = convertInt(lblUpperLegFullExtentionAngleLeftM1.Text);
                _SprintData.ULFullExtensionAngleRight = convertInt(lblUpperLegFullExtentionAngleRightM1.Text);
                _SprintData.LLAngleTakeoffLeft = convertInt(lblLowerLegAngleAtTakeOfLeftM1.Text);
                _SprintData.LLAAngleTakeoffRight = convertInt(lblLowerLegAngleAtTakeOfRightM1.Text);
                _SprintData.LLFullFlexionAngleLeft = convertInt(lblLowerLegFullFlexionAngleLeftM1.Text);
                _SprintData.LLFullFlexionAngleRight = convertInt(lblLowerLegFullFlexionAngleRightM1.Text);
                _SprintData.ULFullFlexionAngleLeft = convertInt(lblUpperLegFullFlexionAngleLeftM1.Text);
                _SprintData.ULFullFlexionAngleRight = convertInt(lblUpperLegFullFlexionAngleRightM1.Text);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            //_SprintData.LessonId = Convert.ToInt32(DropDownList2.SelectedValue);
            string Sprint_ModelDataId = sae.SelectSprintModelDataid(_SprintData.LessonId.ToString());
            if (Sprint_ModelDataId == "")
            {
                if (location == "On-Track Sesssion Summary")
                {
                    _SprintData.UpadteIntoSprintOntrackModelData();
                }
                else
                {
                    _SprintData.InsertIntoSprintModelData();
                }

            }
            else
            {
                _SprintData.UpdateSprintModelData();
            }
            #endregion[Insertupdate to SprintModelData]
            #region[save Initial movies]
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

            Gridview1.Visible = false;
            Gridview2.Visible = false;
            Gridview3.Visible = false;

            lblLocation.Visible = false;
            txtLocation.Visible = false;
            lblexlocation.Visible = false;

            lblTime.Visible = false;
            lblExTime.Visible = false;
            txtTime.Visible = false;

            txtbFilePath.Visible = true;
            // txtbFilePath1.Visible = false;
            txtSumFilePath.Visible = true;
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
            OnTrackSession onTrack = new OnTrackSession();
            onTrack.OnTrackSessionData(athleteSelected);
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
        readtext();
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
        btnDeleteInitialMovies.Visible = true;

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
                FilePathClassa objFilePathClass = new FilePathClassa();
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
        btnDeleteSummaryMovie.Visible = true;
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
                FilePathClassa objFilePathClass = new FilePathClassa();
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

    private void BindModelDataOnly(DataSet dsModelData)
    {
        try
        {
            if (dsModelData != null)
            {
                if (dsModelData.Tables.Count > 1)
                {
                    if (dsModelData.Tables[1].Rows.Count > 0)
                    {
                        #region[model data]
                        lblGroundTimeLeftM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["GroundTime"].ToString());
                        if (lblGroundTimeLeftM1.Text == "" || lblGroundTimeLeftM1.Text == "0.000")
                        {
                            lblGroundTimeLeftM1.Text = "";
                        }
                        lblGroundTimeRightM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["GroundTime"].ToString());
                        if (lblGroundTimeRightM1.Text == "" || lblGroundTimeRightM1.Text == "0.000")
                        {
                            lblGroundTimeRightM1.Text = "";
                        }
                        lblAirTimeLeftToRightM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["AirTime"].ToString());
                        if (lblAirTimeLeftToRightM1.Text == "" || lblAirTimeLeftToRightM1.Text == "0.000")
                        {
                            lblAirTimeLeftToRightM1.Text = "";
                        }
                        lblAirTimeRightToLeftM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["AirTime"].ToString());
                        if (lblAirTimeRightToLeftM1.Text == "" || lblAirTimeRightToLeftM1.Text == "0.000")
                        {
                            lblAirTimeRightToLeftM1.Text = "";
                        }
                        lblTimeToUpperLegFullFlexionLeftM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["FullFlexionTime"].ToString());
                        if (lblTimeToUpperLegFullFlexionLeftM1.Text == "" || lblTimeToUpperLegFullFlexionLeftM1.Text == "0.000")
                        {
                            lblTimeToUpperLegFullFlexionLeftM1.Text = "";
                        }
                        lblTimeToUpperLegFullFlexionRightM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["FullFlexionTime"].ToString());
                        if (lblTimeToUpperLegFullFlexionRightM1.Text == "" || lblTimeToUpperLegFullFlexionRightM1.Text == "0.000")
                        {
                            lblTimeToUpperLegFullFlexionRightM1.Text = "";
                        }
                        lblStrideLengthLeftToRighM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["StrideLength"].ToString());
                        if (lblStrideLengthLeftToRighM1.Text == "" || lblStrideLengthLeftToRighM1.Text == "0.000")
                        {
                            lblStrideLengthLeftToRighM1.Text = "";
                        }
                        lblStrideLengthRightToLeftM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["StrideLength"].ToString());
                        if (lblStrideLengthRightToLeftM1.Text == "" || lblStrideLengthRightToLeftM1.Text == "0.000")
                        {
                            lblStrideLengthRightToLeftM1.Text = "";
                        }
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        lblTrunkAngleAtTouchdownLeftM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["TAATouchDown"].ToString());
                        if (lblTrunkAngleAtTouchdownLeftM1.Text == "" || lblTrunkAngleAtTouchdownLeftM1.Text == "0")
                        {
                            lblTrunkAngleAtTouchdownLeftM1.Text = "";
                        }
                        lblTrunkAngleAtTouchdownRightM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["TAATouchDown"].ToString());
                        if (lblTrunkAngleAtTouchdownRightM1.Text == "" || lblTrunkAngleAtTouchdownRightM1.Text == "0")
                        {
                            lblTrunkAngleAtTouchdownRightM1.Text = "";
                        }

                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        lblKneeSeperationAtTouchdownLeftM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["KSATouchDown"].ToString());
                        if (lblKneeSeperationAtTouchdownLeftM1.Text == "" || lblKneeSeperationAtTouchdownLeftM1.Text == "0.000")
                        {
                            lblKneeSeperationAtTouchdownLeftM1.Text = "";
                        }
                        lblKneeSeperationAtTouchdownRightM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["KSATouchDown"].ToString());
                        if (lblKneeSeperationAtTouchdownRightM1.Text == "" || lblKneeSeperationAtTouchdownRightM1.Text == "0.000")
                        {
                            lblKneeSeperationAtTouchdownRightM1.Text = "";
                        }
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                        lblTouchDownDistanceLeftM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["COGDistance"].ToString());
                        if (lblTouchDownDistanceLeftM1.Text == "" || lblTouchDownDistanceLeftM1.Text == "0.000")
                        {
                            lblTouchDownDistanceLeftM1.Text = "";
                        }
                        lblTouchDownDistanceRightM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["COGDistance"].ToString());
                        if (lblTouchDownDistanceRightM1.Text == "" || lblTouchDownDistanceRightM1.Text == "0.000")
                        {
                            lblTouchDownDistanceRightM1.Text = "";
                        }
                        lblUpperLegFullExtentionAngleLeftM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["ULFullExtensionAngle"].ToString());
                        if (lblUpperLegFullExtentionAngleLeftM1.Text == "" || lblUpperLegFullExtentionAngleLeftM1.Text == "0")
                        {
                            lblUpperLegFullExtentionAngleLeftM1.Text = "";
                        }
                        lblUpperLegFullExtentionAngleRightM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["ULFullExtensionAngle"].ToString());
                        if (lblUpperLegFullExtentionAngleRightM1.Text == "" || lblUpperLegFullExtentionAngleRightM1.Text == "0")
                        {
                            lblUpperLegFullExtentionAngleRightM1.Text = "";
                        }
                        lblLowerLegAngleAtTakeOfLeftM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["LLAngleTakeoff"].ToString());
                        if (lblLowerLegAngleAtTakeOfLeftM1.Text == "" || lblLowerLegAngleAtTakeOfLeftM1.Text == "0")
                        {
                            lblLowerLegAngleAtTakeOfLeftM1.Text = "";
                        }
                        lblLowerLegAngleAtTakeOfRightM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["LLAngleTakeoff"].ToString());
                        if (lblLowerLegAngleAtTakeOfRightM1.Text == "" || lblLowerLegAngleAtTakeOfRightM1.Text == "0")
                        {
                            lblLowerLegAngleAtTakeOfRightM1.Text = "";
                        }
                        lblLowerLegFullFlexionAngleLeftM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["LLFullFlexionAngle"].ToString());
                        if (lblLowerLegFullFlexionAngleLeftM1.Text == "" || lblLowerLegFullFlexionAngleLeftM1.Text == "0")
                        {
                            lblLowerLegFullFlexionAngleLeftM1.Text = "";
                        }
                        lblLowerLegFullFlexionAngleRightM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["LLFullFlexionAngle"].ToString());
                        if (lblLowerLegFullFlexionAngleRightM1.Text == "" || lblLowerLegFullFlexionAngleRightM1.Text == "0")
                        {
                            lblLowerLegFullFlexionAngleRightM1.Text = "";
                        }
                        //lblLowerLegAngleAtAnkleCrossLeftM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["LLAngleAC"].ToString());
                        //if (lblLowerLegAngleAtAnkleCrossLeftM1.Text == "" || lblLowerLegAngleAtAnkleCrossLeftM1.Text == "0")
                        //{
                        //    lblLowerLegAngleAtAnkleCrossLeftM1.Text = "";
                        //}
                        //lblLowerLegAngleAtAnkleCrossRightM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["LLAngleAC"].ToString());
                        //if (lblLowerLegAngleAtAnkleCrossRightM1.Text == "" || lblLowerLegAngleAtAnkleCrossRightM1.Text == "0")
                        //{
                        //    lblLowerLegAngleAtAnkleCrossRightM1.Text = "";
                        //}
                        lblUpperLegFullFlexionAngleLeftM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["ULFullFlexionAngle"].ToString());
                        if (lblUpperLegFullFlexionAngleLeftM1.Text == "" || lblUpperLegFullFlexionAngleLeftM1.Text == "0")
                        {
                            lblUpperLegFullFlexionAngleLeftM1.Text = "";
                        }

                        lblUpperLegFullFlexionAngleRightM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["ULFullFlexionAngle"].ToString());
                        if (lblUpperLegFullFlexionAngleRightM1.Text == "" || lblUpperLegFullFlexionAngleRightM1.Text == "0")
                        {
                            lblUpperLegFullFlexionAngleRightM1.Text = "";
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

    public void GetAllSprintAthleteOnTrackData(int LessonId)
    {
        ArrayList missingVariable = new ArrayList();
        MissingVariable misv = new MissingVariable();
        if (ds != null)
        {
            ds = sae.GetAllSprintAthletesData(LessonId);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow drVariable = ds.Tables[0].Rows[0];
                    #region[initial Data]

                    lblGroundTimeLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ground Time Left"].ToString());
                    if (lblGroundTimeLeftI.Text == "" || lblGroundTimeLeftI.Text == "0.000")
                    {
                        //misv.type = _type;
                        misv.variableName = "Ground Time Left";
                        missingVariable.Add(misv);
                    }
                    lblGroundTimeRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ground Time Right"].ToString());
                    if (lblGroundTimeRightI.Text == "" || lblGroundTimeRightI.Text == "0.000")
                    {
                        //misv.type = _type;
                        misv.variableName = "Ground Time Right";
                        missingVariable.Add(misv);
                    }
                    lblAirTimeLeftToRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Air Time Left to Right"].ToString());
                    if (lblAirTimeLeftToRightI.Text == "" || lblAirTimeLeftToRightI.Text == "0.000")
                    {
                        //misv.type = _type;
                        misv.variableName = "Air Time Left to Right";
                        missingVariable.Add(misv);
                    }
                    lblAirTimeRightToLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Air Time Right to Left"].ToString());
                    if (lblAirTimeRightToLeftI.Text == "" || lblAirTimeRightToLeftI.Text == "0.000")
                    {
                        //misv.type = _type;
                        misv.variableName = "Air Time Right to Left";
                        missingVariable.Add(misv);
                    }
                    lblTimeToUpperLegFullFlexionLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Time to Upper Leg Full Flexion Left"].ToString());
                    if (lblTimeToUpperLegFullFlexionLeftI.Text == "" || lblTimeToUpperLegFullFlexionLeftI.Text == "0.000")
                    {
                        //misv.type = _type;
                        misv.variableName = "Time to Upper Leg Full Flexion Left";
                        missingVariable.Add(misv);
                    }
                    lblTimeToUpperLegFullFlexionRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Time to Upper Leg Full Flexion Right"].ToString());
                    if (lblTimeToUpperLegFullFlexionRightI.Text == "" || lblTimeToUpperLegFullFlexionRightI.Text == "0.000")
                    {
                        //misv.type = _type;
                        misv.variableName = "Time to Upper Leg Full Flexion Right";
                        missingVariable.Add(misv);
                    }
                    lblStrideLengthLeftToRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Stride Length Left to Right"].ToString());
                    if (lblStrideLengthLeftToRightI.Text == "" || lblStrideLengthLeftToRightI.Text == "0.000")
                    {
                        //misv.type = _type;
                        misv.variableName = "Stride Length Left to Right";
                        missingVariable.Add(misv);
                    }
                    lblStrideLengthRightToLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Stride Length Right to Left"].ToString());
                    if (lblStrideLengthRightToLeftI.Text == "" || lblStrideLengthRightToLeftI.Text == "0.000")
                    {
                        //misv.type = _type;
                        misv.variableName = "Stride Length Right to Left";
                        missingVariable.Add(misv);
                    }

                    lblTrunkAngleAtTouchdownLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TAATouchDownLeft"].ToString());
                    if (lblTrunkAngleAtTouchdownLeftI.Text == "" || lblTrunkAngleAtTouchdownLeftI.Text == "0")
                    {
                        //misv.type = _type;
                        misv.variableName = "TAATouchDownLeft";
                        missingVariable.Add(misv);
                    }
                    lblTrunkAngleAtTouchdownRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TAATouchDownRight"].ToString());
                    if (lblTrunkAngleAtTouchdownRightI.Text == "" || lblTrunkAngleAtTouchdownRightI.Text == "0")
                    {
                        //misv.type = _type;
                        misv.variableName = "TAATouchDownRight";
                        missingVariable.Add(misv);
                    }

                    lblKneeSeperationAtTouchdownLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["KSATouchDownLeft"].ToString());
                    if (lblKneeSeperationAtTouchdownLeftI.Text == "" || lblKneeSeperationAtTouchdownLeftI.Text == "0.000")
                    {
                        //misv.type = _type;
                        misv.variableName = "KSATouchDownLeft";
                        missingVariable.Add(misv);
                    }
                    lblKneeSeperationAtTouchdownRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["KSATouchDownRight"].ToString());
                    if (lblKneeSeperationAtTouchdownRightI.Text == "" || lblKneeSeperationAtTouchdownRightI.Text == "0.000")
                    {
                        //misv.type = _type;
                        misv.variableName = "KSATouchDownRight";
                        missingVariable.Add(misv);
                    }

                    lblTouchDownDistanceLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Touchdown Distance Left"].ToString());
                    if (lblTouchDownDistanceLeftI.Text == "" || lblTouchDownDistanceLeftI.Text == "0.000")
                    {
                        //misv.type = _type;
                        misv.variableName = "Touchdown Distance Left";
                        missingVariable.Add(misv);
                    }
                    lblTouchDownDistanceRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Touchdown Distance Right"].ToString());
                    if (lblTouchDownDistanceRightI.Text == "" || lblTouchDownDistanceRightI.Text == "0.000")
                    {
                        //misv.type = _type;
                        misv.variableName = "Touchdown Distance Right";
                        missingVariable.Add(misv);
                    }
                    lblUpperLegFullExtentionAngleLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Extension Angle Left"].ToString());
                    if (lblUpperLegFullExtentionAngleLeftI.Text == "" || lblUpperLegFullExtentionAngleLeftI.Text == "0")
                    {
                        //misv.type = _type;
                        misv.variableName = "Upper Leg Full Extension Angle Left";
                        missingVariable.Add(misv);
                    }
                    lblUpperLegFullExtentionAngleRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Extension Angle Right"].ToString());
                    if (lblUpperLegFullExtentionAngleRightI.Text == "" || lblUpperLegFullExtentionAngleRightI.Text == "0")
                    {
                        //misv.type = _type;
                        misv.variableName = "Upper Leg Full Extension Angle Right";
                        missingVariable.Add(misv);
                    }
                    lblLowerLegAngleAtTakeOfLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Angle at Takeoff Left"].ToString());
                    if (lblLowerLegAngleAtTakeOfLeftI.Text == "" || lblLowerLegAngleAtTakeOfLeftI.Text == "0")
                    {
                        //misv.type = _type;
                        misv.variableName = "Lower Leg Angle at Takeoff Left";
                        missingVariable.Add(misv);
                    }
                    lblLowerLegAngleAtTakeOfRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Angle at Takeoff Right"].ToString());
                    if (lblLowerLegAngleAtTakeOfRightI.Text == "" || lblLowerLegAngleAtTakeOfRightI.Text == "0")
                    {
                        //misv.type = _type;
                        misv.variableName = "Lower Leg Angle at Takeoff Right";
                        missingVariable.Add(misv);
                    }
                    lblLowerLegFullFlexionAngleLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Full Flexion Angle Left"].ToString());
                    if (lblLowerLegFullFlexionAngleLeftI.Text == "" || lblLowerLegFullFlexionAngleLeftI.Text == "0")
                    {
                        //misv.type = _type;
                        misv.variableName = "Lower Leg Full Flexion Angle Left";
                        missingVariable.Add(misv);
                    }
                    lblLowerLegFullFlexionAngleRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Full Flexion Angle Right"].ToString());
                    if (lblLowerLegFullFlexionAngleRightI.Text == "" || lblLowerLegFullFlexionAngleRightI.Text == "0")
                    {
                        //misv.type = _type;
                        misv.variableName = "Lower Leg Full Flexion Angle Right";
                        missingVariable.Add(misv);
                    }
                    lblUpperLegFullFlexionAngleLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Flexion Angle Left"].ToString());
                    if (lblUpperLegFullFlexionAngleLeftI.Text == "" || lblUpperLegFullFlexionAngleLeftI.Text == "0")
                    {
                        //misv.type = _type;
                        misv.variableName = "Upper Leg Full Flexion Angle Left";
                        missingVariable.Add(misv);
                    }
                    lblUpperLegFullFlexionAngleRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Flexion Angle Right"].ToString());
                    if (lblUpperLegFullFlexionAngleRightI.Text == "" || lblUpperLegFullFlexionAngleRightI.Text == "0")
                    {
                        //misv.type = _type;
                        misv.variableName = "Upper Leg Full Flexion Angle Right";
                        missingVariable.Add(misv);
                    }
                    #endregion[initial Data]
                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    string listOfVariableWithZero = "";
                    DataRow drVariable = ds.Tables[4].Rows[0];
                    #region[model data]
                    lblGroundTimeLeftM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Ground Time Left"].ToString());
                    if (lblGroundTimeLeftM1.Text == "" || lblGroundTimeLeftM1.Text == "0.000")
                    {
                        //lblGroundTimeLeftI.Text = "";
                        listOfVariableWithZero = "Ground Time Left";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblGroundTimeRightM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Ground Time Right"].ToString());
                    if (lblGroundTimeRightM1.Text == "" || lblGroundTimeRightM1.Text == "0.000")
                    {
                        //lblGroundTimeRightI.Text = "";
                        listOfVariableWithZero = "Ground Time Right";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblAirTimeLeftToRightM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Air Time Left to Right"].ToString());
                    if (lblAirTimeLeftToRightM1.Text == "" || lblAirTimeLeftToRightM1.Text == "0.000")
                    {
                        //lblAirTimeLeftToRightI.Text = "";
                        listOfVariableWithZero = "Air Time Left to Right";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblAirTimeRightToLeftM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Air Time Right to Left"].ToString());
                    if (lblAirTimeRightToLeftM1.Text == "" || lblAirTimeRightToLeftM1.Text == "0.000")
                    {
                        //lblAirTimeRightToLeftI.Text = "";
                        listOfVariableWithZero = "Air Time Right to Left";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblTimeToUpperLegFullFlexionLeftM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Time to Upper Leg Full Flexion Left"].ToString());
                    if (lblTimeToUpperLegFullFlexionLeftM1.Text == "" || lblTimeToUpperLegFullFlexionLeftM1.Text == "0.000")
                    {
                        //lblTimeToUpperLegFullFlexionLeftI.Text = "";
                        listOfVariableWithZero = "Time to Upper Leg Full Flexion Left";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblTimeToUpperLegFullFlexionRightM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Time to Upper Leg Full Flexion Right"].ToString());
                    if (lblTimeToUpperLegFullFlexionRightM1.Text == "" || lblTimeToUpperLegFullFlexionRightM1.Text == "0.000")
                    {
                        //lblTimeToUpperLegFullFlexionRightI.Text = "";
                        listOfVariableWithZero = "Time to Upper Leg Full Flexion Right";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblStrideLengthLeftToRighM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Stride Length Left to Right"].ToString());
                    if (lblStrideLengthLeftToRighM1.Text == "" || lblStrideLengthLeftToRighM1.Text == "0.000")
                    {
                        //lblStrideLengthLeftToRightI.Text = "";
                        listOfVariableWithZero = "Stride Length Left to Right";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblStrideLengthRightToLeftM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Stride Length Right to Left"].ToString());
                    if (lblStrideLengthRightToLeftM1.Text == "" || lblStrideLengthRightToLeftM1.Text == "0.000")
                    {
                        // lblStrideLengthRightToLeftM1.Text = "";
                        listOfVariableWithZero = "Stride Length Left to Right";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblTrunkAngleAtTouchdownLeftM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["TAATouchDownLeft"].ToString());
                    if (lblTrunkAngleAtTouchdownLeftM1.Text == "" || lblTrunkAngleAtTouchdownLeftM1.Text == "0")
                    {
                        //lblTrunkAngleAtTouchdownLeftM1.Text = "";
                        listOfVariableWithZero = "TAATouchDownLeft";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblTrunkAngleAtTouchdownRightM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["TAATouchDownRight"].ToString());
                    if (lblTrunkAngleAtTouchdownRightM1.Text == "" || lblTrunkAngleAtTouchdownRightM1.Text == "0")
                    {
                        //lblTrunkAngleAtTouchdownRightM1.Text = "";
                        listOfVariableWithZero = "TAATouchDownRight";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblKneeSeperationAtTouchdownLeftM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["KSATouchDownLeft"].ToString());
                    if (lblKneeSeperationAtTouchdownLeftM1.Text == "" || lblKneeSeperationAtTouchdownLeftM1.Text == "0.000")
                    {
                        // lblKneeSeperationAtTouchdownLeftM1.Text = "";
                        listOfVariableWithZero = "KSATouchDownLeft";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblKneeSeperationAtTouchdownRightM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["KSATouchDownRight"].ToString());
                    if (lblKneeSeperationAtTouchdownRightM1.Text == "" || lblKneeSeperationAtTouchdownRightM1.Text == "0.000")
                    {
                        //lblKneeSeperationAtTouchdownRightM1.Text = "";
                        listOfVariableWithZero = "KSATouchDownRight";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblTouchDownDistanceLeftM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Touchdown Distance Left"].ToString());
                    if (lblTouchDownDistanceLeftM1.Text == "" || lblTouchDownDistanceLeftM1.Text == "0.000")
                    {
                        //lblTouchDownDistanceLeftM1.Text = "";
                        listOfVariableWithZero = "Touchdown Distance Left";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblTouchDownDistanceRightM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Touchdown Distance Right"].ToString());
                    if (lblTouchDownDistanceRightM1.Text == "" || lblTouchDownDistanceRightM1.Text == "0.000")
                    {
                        // lblTouchDownDistanceRightM1.Text = "";
                        listOfVariableWithZero = "Touchdown Distance Right";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblUpperLegFullExtentionAngleLeftM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Upper Leg Full Extension Angle Left"].ToString());
                    if (lblUpperLegFullExtentionAngleLeftM1.Text == "" || lblUpperLegFullExtentionAngleLeftM1.Text == "0")
                    {
                        //lblUpperLegFullExtentionAngleLeftI.Text = "";
                        listOfVariableWithZero = "Upper Leg Full Extension Angle Left";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblUpperLegFullExtentionAngleRightM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Upper Leg Full Extension Angle Right"].ToString());
                    if (lblUpperLegFullExtentionAngleRightM1.Text == "" || lblUpperLegFullExtentionAngleRightM1.Text == "0")
                    {

                        //lblUpperLegFullExtentionAngleRightI.Text = "";
                        listOfVariableWithZero = "Upper Leg Full Extension Angle Right";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblLowerLegAngleAtTakeOfLeftM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Lower Leg Angle at Takeoff Left"].ToString());
                    if (lblLowerLegAngleAtTakeOfLeftM1.Text == "" || lblLowerLegAngleAtTakeOfLeftM1.Text == "0")
                    {
                        //lblLowerLegAngleAtTakeOfLeftI.Text = "";
                        listOfVariableWithZero = "Lower Leg Angle at Takeoff Left";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblLowerLegAngleAtTakeOfRightM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Lower Leg Angle at Takeoff Right"].ToString());
                    if (lblLowerLegAngleAtTakeOfRightM1.Text == "" || lblLowerLegAngleAtTakeOfRightM1.Text == "0")
                    {
                        //lblLowerLegAngleAtTakeOfRightI.Text = "";
                        listOfVariableWithZero = "Lower Leg Angle at Takeoff Right";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblLowerLegFullFlexionAngleLeftM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Lower Leg Full Flexion Angle Left"].ToString());
                    if (lblLowerLegFullFlexionAngleLeftM1.Text == "" || lblLowerLegFullFlexionAngleLeftM1.Text == "0")
                    {
                        //lblLowerLegFullFlexionAngleLeftI.Text = "";
                        listOfVariableWithZero = "Lower Leg Full Flexion Angle Left";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblLowerLegFullFlexionAngleRightM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Lower Leg Full Flexion Angle Right"].ToString());
                    if (lblLowerLegFullFlexionAngleRightM1.Text == "" || lblLowerLegFullFlexionAngleRightM1.Text == "0")
                    {
                        //lblLowerLegFullFlexionAngleRightI.Text = "";
                        listOfVariableWithZero = "Lower Leg Full Flexion Angle Right";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    lblUpperLegFullFlexionAngleLeftM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Upper Leg Full Flexion Angle Left"].ToString());
                    if (lblUpperLegFullFlexionAngleLeftM1.Text == "" || lblUpperLegFullFlexionAngleLeftM1.Text == "0")
                    {
                        //lblUpperLegFullFlexionAngleLeftI.Text = "";
                        listOfVariableWithZero = "Upper Leg Full Flexion Angle Left";
                        missingVariable.Add(listOfVariableWithZero);
                    }

                    lblUpperLegFullFlexionAngleRightM1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Upper Leg Full Flexion Angle Right"].ToString());
                    if (lblUpperLegFullFlexionAngleRightM1.Text == "" || lblUpperLegFullFlexionAngleRightM1.Text == "0")
                    {
                        //lblUpperLegFullFlexionAngleRightI.Text = "";
                        listOfVariableWithZero = "Upper Leg Full Flexion Angle Right";
                        missingVariable.Add(listOfVariableWithZero);
                    }
                    #endregion[model Data]
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    DataRow drVariable = ds.Tables[2].Rows[0];
                    #region[current Data]
                    lblGroundTimeLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Ground Time Left"].ToString());
                    if (lblGroundTimeLeftF.Text == "" || lblGroundTimeLeftF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblGroundTimeLeftF.Text = "";
                        misv.variableName = "Ground Time Left";
                        missingVariable.Add(misv);
                    }
                    lblGroundTimeRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Ground Time Right"].ToString());
                    if (lblGroundTimeRightF.Text == "" || lblGroundTimeRightF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblGroundTimeRightF.Text = "";
                        misv.variableName = "Ground Time Right";
                        missingVariable.Add(misv);
                    }
                    lblAirTimeLeftToRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Air Time Left to Right"].ToString());
                    if (lblAirTimeLeftToRightF.Text == "" || lblAirTimeLeftToRightF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblAirTimeLeftToRightF.Text = "";
                        misv.variableName = "Air Time Left to Right";
                        missingVariable.Add(misv);
                    }
                    lblAirTimeRightToLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Air Time Right to Left"].ToString());
                    if (lblAirTimeRightToLeftF.Text == "" || lblAirTimeRightToLeftF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblAirTimeRightToLeftF.Text = "";
                        misv.variableName = "Air Time Right to Left";
                        missingVariable.Add(misv);
                    }
                    lblTimeToUpperLegFullFlexionLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Time to Upper Leg Full Flexion Left"].ToString());
                    if (lblTimeToUpperLegFullFlexionLeftF.Text == "" || lblTimeToUpperLegFullFlexionLeftF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblTimeToUpperLegFullFlexionLeftF.Text = "";
                        misv.variableName = "Time to Upper Leg Full Flexion Left";
                        missingVariable.Add(misv);
                    }
                    lblTimeToUpperLegFullFlexionRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Time to Upper Leg Full Flexion Right"].ToString());
                    if (lblTimeToUpperLegFullFlexionRightF.Text == "" || lblTimeToUpperLegFullFlexionRightF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblTimeToUpperLegFullFlexionRightF.Text = "";
                        misv.variableName = "Time to Upper Leg Full Flexion Right";
                        missingVariable.Add(misv);
                    }
                    lblStrideLengthLeftToRighF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Stride Length Left to Right"].ToString());
                    if (lblStrideLengthLeftToRighF.Text == "" || lblStrideLengthLeftToRighF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblStrideLengthLeftToRighF.Text = "";
                        misv.variableName = "Stride Length Left to Right";
                        missingVariable.Add(misv);
                    }
                    lblStrideLengthRightToLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Stride Length Right to Left"].ToString());
                    if (lblStrideLengthRightToLeftF.Text == "" || lblStrideLengthRightToLeftF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblStrideLengthRightToLeftF.Text = "";
                        misv.variableName = "Stride Length Right to Left";
                        missingVariable.Add(misv);
                    }
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    lblTrunkAngleAtTouchdownLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TAATouchDownLeft"].ToString());
                    if (lblTrunkAngleAtTouchdownLeftF.Text == "" || lblTrunkAngleAtTouchdownLeftF.Text == "0")
                    {
                        //misv.type = _type;
                        lblTrunkAngleAtTouchdownLeftF.Text = "";
                        misv.variableName = "TAATouchDownLeft";
                        missingVariable.Add(misv);
                    }
                    lblTrunkAngleAtTouchdownRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TAATouchDownRight"].ToString());
                    if (lblTrunkAngleAtTouchdownRightF.Text == "" || lblTrunkAngleAtTouchdownRightF.Text == "0")
                    {
                        //misv.type = _type;
                        lblTrunkAngleAtTouchdownRightF.Text = "";
                        misv.variableName = "TAATouchDownRight";
                        missingVariable.Add(misv);
                    }
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    lblKneeSeperationAtTouchdownLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["KSATouchDownLeft"].ToString());
                    if (lblKneeSeperationAtTouchdownLeftF.Text == "" || lblKneeSeperationAtTouchdownLeftF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblKneeSeperationAtTouchdownLeftF.Text = "";
                        misv.variableName = "KSATouchDownLeft";
                        missingVariable.Add(misv);
                    }

                    lblKneeSeperationAtTouchdownRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["KSATouchDownRight"].ToString());
                    if (lblKneeSeperationAtTouchdownRightF.Text == "" || lblKneeSeperationAtTouchdownRightF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblKneeSeperationAtTouchdownRightF.Text = "";
                        misv.variableName = "KSATouchDownRight";
                        missingVariable.Add(misv);
                    }
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    lblTouchDownDistanceLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Touchdown Distance Left"].ToString());
                    if (lblTouchDownDistanceLeftF.Text == "" || lblTouchDownDistanceLeftF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblTouchDownDistanceLeftF.Text = "";
                        misv.variableName = "Touchdown Distance Left";
                        missingVariable.Add(misv);
                    }
                    lblTouchDownDistanceRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Touchdown Distance Right"].ToString());
                    if (lblTouchDownDistanceRightF.Text == "" || lblTouchDownDistanceRightF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblTouchDownDistanceRightF.Text = "";
                        misv.variableName = "Touchdown Distance Right";
                        missingVariable.Add(misv);
                    }
                    lblUpperLegFullExtentionAngleLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Extension Angle Left"].ToString());
                    if (lblUpperLegFullExtentionAngleLeftF.Text == "" || lblUpperLegFullExtentionAngleLeftF.Text == "0")
                    {
                        //misv.type = _type;
                        lblUpperLegFullExtentionAngleLeftF.Text = "";
                        misv.variableName = "Upper Leg Full Extension Angle Left";
                        missingVariable.Add(misv);
                    }
                    lblUpperLegFullExtentionAngleRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Extension Angle Right"].ToString());
                    if (lblUpperLegFullExtentionAngleRightF.Text == "" || lblUpperLegFullExtentionAngleRightF.Text == "0")
                    {
                        //misv.type = _type;
                        lblUpperLegFullExtentionAngleRightF.Text = "";
                        misv.variableName = "Upper Leg Full Extension Angle Right";
                        missingVariable.Add(misv);
                    }
                    lblLowerLegAngleAtTakeOfLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Takeoff Left"].ToString());
                    if (lblLowerLegAngleAtTakeOfLeftF.Text == "" || lblLowerLegAngleAtTakeOfLeftF.Text == "0")
                    {
                        //misv.type = _type;
                        lblLowerLegAngleAtTakeOfLeftF.Text = "";
                        misv.variableName = "Lower Leg Angle at Takeoff Left";
                        missingVariable.Add(misv);
                    }
                    lblLowerLegAngleAtTakeOfRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Takeoff Right"].ToString());
                    if (lblLowerLegAngleAtTakeOfRightF.Text == "" || lblLowerLegAngleAtTakeOfRightF.Text == "0")
                    {
                        //misv.type = _type;
                        lblLowerLegAngleAtTakeOfRightF.Text = "";
                        misv.variableName = "Lower Leg Angle at Takeoff Right";
                        missingVariable.Add(misv);
                    }
                    lblLowerLegFullFlexionAngleLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Full Flexion Angle Left"].ToString());
                    if (lblLowerLegFullFlexionAngleLeftF.Text == "" || lblLowerLegFullFlexionAngleLeftF.Text == "0")
                    {
                        //misv.type = _type;
                        lblLowerLegFullFlexionAngleLeftF.Text = "";
                        misv.variableName = "Lower Leg Full Flexion Angle Left";
                        missingVariable.Add(misv);
                    }
                    lblLowerLegFullFlexionAngleRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Full Flexion Angle Right"].ToString());
                    if (lblLowerLegFullFlexionAngleRightF.Text == "" || lblLowerLegFullFlexionAngleRightF.Text == "0")
                    {
                        //misv.type = _type;
                        lblLowerLegFullFlexionAngleRightF.Text = "";
                        misv.variableName = "Lower Leg Full Flexion Angle Right";
                        missingVariable.Add(misv);
                    }
                    //lblLowerLegAngleAtAnkleCrossLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Ankle Cross Left"].ToString());
                    //if (lblLowerLegAngleAtAnkleCrossLeftF.Text == "" || lblLowerLegAngleAtAnkleCrossLeftF.Text == "0")
                    //{
                    //    lblLowerLegAngleAtAnkleCrossLeftF.Text = "";
                    //}
                    //lblLowerLegAngleAtAnkleCrossRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Ankle Cross Right"].ToString());
                    //if (lblLowerLegAngleAtAnkleCrossRightF.Text == "" || lblLowerLegAngleAtAnkleCrossRightF.Text == "0")
                    //{
                    //    lblLowerLegAngleAtAnkleCrossRightF.Text = "";
                    //}
                    lblUpperLegFullFlexionAngleLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Flexion Angle Left"].ToString());
                    if (lblUpperLegFullFlexionAngleLeftF.Text == "" || lblUpperLegFullFlexionAngleLeftF.Text == "0")
                    {
                        //misv.type = _type;
                        lblUpperLegFullFlexionAngleLeftF.Text = "";
                        misv.variableName = "Upper Leg Full Flexion Angle Left";
                        missingVariable.Add(misv);
                    }
                    lblUpperLegFullFlexionAngleRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Flexion Angle Right"].ToString());
                    if (lblUpperLegFullFlexionAngleRightF.Text == "" || lblUpperLegFullFlexionAngleRightF.Text == "0")
                    {
                        //misv.type = _type;
                        lblUpperLegFullFlexionAngleRightF.Text = "";
                        misv.variableName = "Upper Leg Full Flexion Angle Right";
                        missingVariable.Add(misv);
                    }
                    #endregion[current Data]
                }
            }
        }
    }

    List<MissingVariable> missingVariable = new List<MissingVariable>();

    public void GetAllSprintAthleteData(int LessonId)
    {

        if (ds != null)
        {
            int initialcnt = 0;
            int modelCnt = 0;
            int CurrentCnt = 0;
           
            
            ds = sae.GetAllSprintAthletesData(LessonId);
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //misv.type = "initial";
                    DataRow drVariable = ds.Tables[0].Rows[0];
                    #region[initial Data]

                    lblGroundTimeLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ground Time Left"].ToString());
                    decimal GroundTimeLeft;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Ground Time Left"].ToString(), out GroundTimeLeft);
                    //if (lblGroundTimeLeftI.Text == "" || lblGroundTimeLeftI.Text == "0.000")
                        if (GroundTimeLeft == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblGroundTimeLeftI.Text = "";
                            misv.variableName = "GroundTimeLeft";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        decimal GroundTimeRight;
                        decimal.TryParse(ds.Tables[0].Rows[0]["Ground Time Right"].ToString(), out GroundTimeRight);
                    lblGroundTimeRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ground Time Right"].ToString());
                    //if (lblGroundTimeRightI.Text == "" || lblGroundTimeRightI.Text == "0.000")
                   if (GroundTimeRight  ==0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblGroundTimeRightI.Text = "";
                        misv.variableName = "GroundTimeRight";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblAirTimeLeftToRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Air Time Left to Right"].ToString());
                    //if (lblAirTimeLeftToRightI.Text == "" || lblAirTimeLeftToRightI.Text == "0.000")
                   decimal AirTimeLeftToRight;
                   decimal.TryParse(ds.Tables[0].Rows[0]["Air Time Left to Right"].ToString(), out AirTimeLeftToRight);
                   if (AirTimeLeftToRight == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblAirTimeLeftToRightI.Text = "";
                        misv.variableName = "Air Time Left to Right";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblAirTimeRightToLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Air Time Right to Left"].ToString());
                    //if (lblAirTimeRightToLeftI.Text == "" || lblAirTimeRightToLeftI.Text == "0.000")
                    decimal AirTimeRightToLeft;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Air Time Right to Left"].ToString(), out AirTimeRightToLeft);
                    if (AirTimeRightToLeft == 0)
                    {

                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblAirTimeRightToLeftI.Text = "";
                        misv.variableName = "Air Time Right to Left";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblTimeToUpperLegFullFlexionLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Time to Upper Leg Full Flexion Left"].ToString());
                    //if (lblTimeToUpperLegFullFlexionLeftI.Text == "" || lblTimeToUpperLegFullFlexionLeftI.Text == "0.000")
                    decimal TimeToUpperLegFullFlexionLeft;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Time to Upper Leg Full Flexion Left"].ToString(),out TimeToUpperLegFullFlexionLeft);
                    if (TimeToUpperLegFullFlexionLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblTimeToUpperLegFullFlexionLeftI.Text = "";
                        misv.variableName = "Time to Upper Leg Full Flexion Left";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblTimeToUpperLegFullFlexionRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Time to Upper Leg Full Flexion Right"].ToString());
                    //if (lblTimeToUpperLegFullFlexionRightI.Text == "" || lblTimeToUpperLegFullFlexionRightI.Text == "0.000")
                    decimal TimeToUpperLegFullFlexionRight;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Time to Upper Leg Full Flexion Right"].ToString(), out TimeToUpperLegFullFlexionRight);
                    if(TimeToUpperLegFullFlexionRight ==0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblTimeToUpperLegFullFlexionRightI.Text = "";
                        misv.variableName = "Time to Upper Leg Full Flexion Right";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblStrideLengthLeftToRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Stride Length Left to Right"].ToString());
                    //if (lblStrideLengthLeftToRightI.Text == "" || lblStrideLengthLeftToRightI.Text == "0.000")
                    decimal StrideLengthLeftToRight;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Stride Length Left to Right"].ToString(), out StrideLengthLeftToRight);
                    if(StrideLengthLeftToRight ==0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStrideLengthLeftToRightI.Text = "";
                        misv.variableName = "Stride Length Left to Right";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblStrideLengthRightToLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Stride Length Right to Left"].ToString());
                    //if (lblStrideLengthRightToLeftI.Text == "" || lblStrideLengthRightToLeftI.Text == "0.000")
                    decimal StrideLengthRightToLeft;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Stride Length Right to Left"].ToString(), out StrideLengthRightToLeft);
                    if (StrideLengthRightToLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStrideLengthRightToLeftI.Text = "";
                        misv.variableName = "Stride Length Right to Left";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }

                    lblTrunkAngleAtTouchdownLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TAATouchDownLeft"].ToString());
                    //if (lblTrunkAngleAtTouchdownLeftI.Text == "" || lblTrunkAngleAtTouchdownLeftI.Text == "0")
                    decimal TrunkAngleAtTouchdownLeft;
                    decimal.TryParse(ds.Tables[0].Rows[0]["TAATouchDownLeft"].ToString(), out TrunkAngleAtTouchdownLeft);
                    if (TrunkAngleAtTouchdownLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblTrunkAngleAtTouchdownLeftI.Text = "";
                        misv.variableName = "TAATouchDownLeft";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblTrunkAngleAtTouchdownRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TAATouchDownRight"].ToString());
                    //if (lblTrunkAngleAtTouchdownRightI.Text == "" || lblTrunkAngleAtTouchdownRightI.Text == "0")
                    decimal TrunkAngleAtTouchdownRight;
                    decimal.TryParse(ds.Tables[0].Rows[0]["TAATouchDownRight"].ToString(), out TrunkAngleAtTouchdownRight);
                    if (TrunkAngleAtTouchdownRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblTrunkAngleAtTouchdownRightI.Text = "";
                        misv.variableName = "TAATouchDownRight";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }

                    lblKneeSeperationAtTouchdownLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["KSATouchDownLeft"].ToString());
                    //if (lblKneeSeperationAtTouchdownLeftI.Text == "" || lblKneeSeperationAtTouchdownLeftI.Text == "0.000")
                    decimal KneeSeperationAtTouchdownLeft;
                    decimal.TryParse(ds.Tables[0].Rows[0]["KSATouchDownLeft"].ToString(), out KneeSeperationAtTouchdownLeft);
                    if (KneeSeperationAtTouchdownLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblKneeSeperationAtTouchdownLeftI.Text = "";
                        misv.variableName = "KSATouchDownLeft";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblKneeSeperationAtTouchdownRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["KSATouchDownRight"].ToString());
                    //if (lblKneeSeperationAtTouchdownRightI.Text == "" || lblKneeSeperationAtTouchdownRightI.Text == "0.000")
                    decimal KneeSeperationAtTouchdownRight;
                    decimal.TryParse(ds.Tables[0].Rows[0]["KSATouchDownRight"].ToString(), out KneeSeperationAtTouchdownRight);
                    if (KneeSeperationAtTouchdownRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblKneeSeperationAtTouchdownRightI.Text = "";
                        misv.variableName = "KSATouchDownRight";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }

                    lblTouchDownDistanceLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Touchdown Distance Left"].ToString());
                    //if (lblTouchDownDistanceLeftI.Text == "" || lblTouchDownDistanceLeftI.Text == "0.000")
                    decimal TouchDownDistanceLeft;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Touchdown Distance Left"].ToString(), out TouchDownDistanceLeft);
                    if (TouchDownDistanceLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblTouchDownDistanceLeftI.Text = "";
                        misv.variableName = "Touchdown Distance Left";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblTouchDownDistanceRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Touchdown Distance Right"].ToString());
                    //if (lblTouchDownDistanceRightI.Text == "" || lblTouchDownDistanceRightI.Text == "0.000")
                    decimal TouchDownDistanceRight;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Touchdown Distance Right"].ToString(), out TouchDownDistanceRight);
                    if (TouchDownDistanceRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblTouchDownDistanceRightI.Text = "";
                        misv.variableName = "Touchdown Distance Right";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblUpperLegFullExtentionAngleLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Extension Angle Left"].ToString());
                    //if (lblUpperLegFullExtentionAngleLeftI.Text == "" || lblUpperLegFullExtentionAngleLeftI.Text == "0")
                    decimal UpperLegFullExtentionAngleLeft;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Upper Leg Full Extension Angle Left"].ToString(), out UpperLegFullExtentionAngleLeft);
                    if (UpperLegFullExtentionAngleLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblUpperLegFullExtentionAngleLeftI.Text = "";
                        misv.variableName = "Upper Leg Full Extension Angle Left";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblUpperLegFullExtentionAngleRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Extension Angle Right"].ToString());
                    //if (lblUpperLegFullExtentionAngleRightI.Text == "" || lblUpperLegFullExtentionAngleRightI.Text == "0")
                    decimal UpperLegFullExtentionAngleRight;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Upper Leg Full Extension Angle Right"].ToString(), out UpperLegFullExtentionAngleRight);
                    if (UpperLegFullExtentionAngleRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblUpperLegFullExtentionAngleRightI.Text = "";
                        misv.variableName = "Upper Leg Full Extension Angle Right";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblLowerLegAngleAtTakeOfLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Angle at Takeoff Left"].ToString());
                    //if (lblLowerLegAngleAtTakeOfLeftI.Text == "" || lblLowerLegAngleAtTakeOfLeftI.Text == "0")
                    decimal LowerLegAngleAtTakeOfLeft;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Lower Leg Angle at Takeoff Left"].ToString(), out LowerLegAngleAtTakeOfLeft);
                    if (LowerLegAngleAtTakeOfLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblLowerLegAngleAtTakeOfLeftI.Text = "";
                        misv.variableName = "Lower Leg Angle at Takeoff Left";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblLowerLegAngleAtTakeOfRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Angle at Takeoff Right"].ToString());
                    //if (lblLowerLegAngleAtTakeOfRightI.Text == "" || lblLowerLegAngleAtTakeOfRightI.Text == "0")
                    decimal LowerLegAngleAtTakeOfRight;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Lower Leg Angle at Takeoff Right"].ToString(), out LowerLegAngleAtTakeOfRight);
                    if (LowerLegAngleAtTakeOfRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblLowerLegAngleAtTakeOfRightI.Text = "";
                        misv.variableName = "Lower Leg Angle at Takeoff Right";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblLowerLegFullFlexionAngleLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Full Flexion Angle Left"].ToString());
                    //if (lblLowerLegFullFlexionAngleLeftI.Text == "" || lblLowerLegFullFlexionAngleLeftI.Text == "0")
                    decimal LowerLegFullFlexionAngleLeft;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Lower Leg Full Flexion Angle Left"].ToString(), out LowerLegFullFlexionAngleLeft);
                    if (LowerLegFullFlexionAngleLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblLowerLegFullFlexionAngleLeftI.Text = "";
                        misv.variableName = "Lower Leg Full Flexion Angle Left";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblLowerLegFullFlexionAngleRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Full Flexion Angle Right"].ToString());
                    //if (lblLowerLegFullFlexionAngleRightI.Text == "" || lblLowerLegFullFlexionAngleRightI.Text == "0")
                    decimal LowerLegFullFlexionAngleRight;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Lower Leg Full Flexion Angle Right"].ToString(), out LowerLegFullFlexionAngleRight);
                    if (LowerLegFullFlexionAngleRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblLowerLegFullFlexionAngleRightI.Text = "";
                        misv.variableName = "Lower Leg Full Flexion Angle Right";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblUpperLegFullFlexionAngleLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Flexion Angle Left"].ToString());
                    //if (lblUpperLegFullFlexionAngleLeftI.Text == "" || lblUpperLegFullFlexionAngleLeftI.Text == "0")
                    decimal UpperLegFullFlexionAngleLeft;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Upper Leg Full Flexion Angle Left"].ToString(), out UpperLegFullFlexionAngleLeft);
                    if (UpperLegFullFlexionAngleLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblUpperLegFullFlexionAngleLeftI.Text = "";
                        misv.variableName = "Upper Leg Full Flexion Angle Left";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    lblUpperLegFullFlexionAngleRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Flexion Angle Right"].ToString());
                    //if (lblUpperLegFullFlexionAngleRightI.Text == "" || lblUpperLegFullFlexionAngleRightI.Text == "0")
                    decimal UpperLegFullFlexionAngleRight;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Upper Leg Full Flexion Angle Right"].ToString(), out UpperLegFullFlexionAngleRight);
                    if (UpperLegFullFlexionAngleRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblUpperLegFullFlexionAngleRightI.Text = "";
                        misv.variableName = "Upper Leg Full Flexion Angle Right";
                        missingVariable.Add(misv);
                        initialcnt++;
                    }
                    #endregion[initial Data]
                }
                if (ds.Tables[5].Rows.Count > 0)
                {
                    DataRow drVariable = ds.Tables[5].Rows[0];
                    #region[model data]
                    lblGroundTimeLeftM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["GroundTime"].ToString());
                    //if (lblGroundTimeLeftM1.Text == "" || lblGroundTimeLeftM1.Text == "0.000")
                    decimal GroundTimeLeft;
                    decimal.TryParse(ds.Tables[5].Rows[0]["GroundTime"].ToString(), out GroundTimeLeft);
                    if (GroundTimeLeft == 0)

                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblGroundTimeLeftM1.Text = "";
                        misv.variableName = "GroundTime";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblGroundTimeRightM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["GroundTime"].ToString());
                    //if (lblGroundTimeRightM1.Text == "" || lblGroundTimeRightM1.Text == "0.000")
                    decimal GroundTimeRight;
                    decimal.TryParse(ds.Tables[5].Rows[0]["GroundTime"].ToString(), out GroundTimeRight);
                    if (GroundTimeRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblGroundTimeRightM1.Text = "";
                        misv.variableName = "GroundTime";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblAirTimeLeftToRightM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["AirTime"].ToString());
                    //if (lblAirTimeLeftToRightM1.Text == "" || lblAirTimeLeftToRightM1.Text == "0.000")
                    decimal AirTimeLeftToRight;
                    decimal.TryParse(ds.Tables[5].Rows[0]["AirTime"].ToString(), out AirTimeLeftToRight);
                    if (AirTimeLeftToRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblAirTimeLeftToRightM1.Text = "";
                        misv.variableName = "AirTime";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblAirTimeRightToLeftM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["AirTime"].ToString());
                    //if (lblAirTimeRightToLeftM1.Text == "" || lblAirTimeRightToLeftM1.Text == "0.000")
                    decimal AirTimeRightToLeft;
                    decimal.TryParse(ds.Tables[5].Rows[0]["AirTime"].ToString(), out AirTimeRightToLeft);
                    if (AirTimeRightToLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblAirTimeRightToLeftM1.Text = "";
                        misv.variableName = "AirTime";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblTimeToUpperLegFullFlexionLeftM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["FullFlexionTime"].ToString());
                    //if (lblTimeToUpperLegFullFlexionLeftM1.Text == "" || lblTimeToUpperLegFullFlexionLeftM1.Text == "0.000")
                    decimal TimeToUpperLegFullFlexionRight;
                    decimal.TryParse(ds.Tables[5].Rows[0]["FullFlexionTime"].ToString(), out TimeToUpperLegFullFlexionRight);
                    if (TimeToUpperLegFullFlexionRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblTimeToUpperLegFullFlexionLeftM1.Text = "";
                        misv.variableName = "FullFlexionTime";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblTimeToUpperLegFullFlexionRightM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["FullFlexionTime"].ToString());
                    //if (lblTimeToUpperLegFullFlexionRightM1.Text == "" || lblTimeToUpperLegFullFlexionRightM1.Text == "0.000")
                    decimal TimeToUpperLegFullFlexionLeft;
                    decimal.TryParse(ds.Tables[5].Rows[0]["FullFlexionTime"].ToString(), out TimeToUpperLegFullFlexionLeft);
                    if (TimeToUpperLegFullFlexionLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblTimeToUpperLegFullFlexionRightM1.Text = "";
                        misv.variableName = "FullFlexionTime";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblStrideLengthLeftToRighM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["StrideLength"].ToString());
                    //if (lblStrideLengthLeftToRighM1.Text == "" || lblStrideLengthLeftToRighM1.Text == "0.000")
                    decimal StrideLengthLeftToRig;
                    decimal.TryParse(ds.Tables[5].Rows[0]["StrideLength"].ToString(), out StrideLengthLeftToRig);
                    if (StrideLengthLeftToRig == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStrideLengthLeftToRighM1.Text = "";
                        misv.variableName = "StrideLength";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblStrideLengthRightToLeftM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["StrideLength"].ToString());
                    //if (lblStrideLengthRightToLeftM1.Text == "" || lblStrideLengthRightToLeftM1.Text == "0.000")
                    decimal StrideLengthRightToLeft;
                    decimal.TryParse(ds.Tables[5].Rows[0]["StrideLength"].ToString(), out StrideLengthRightToLeft);
                    if (StrideLengthRightToLeft == 0)

                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStrideLengthRightToLeftM1.Text = "";
                        misv.variableName = "StrideLength";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblTrunkAngleAtTouchdownLeftM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["TAATouchDown"].ToString());
                    //if (lblTrunkAngleAtTouchdownLeftM1.Text == "" || lblTrunkAngleAtTouchdownLeftM1.Text == "0")
                    decimal TrunkAngleAtTouchdownLeft;
                    decimal.TryParse(ds.Tables[5].Rows[0]["TAATouchDown"].ToString(), out TrunkAngleAtTouchdownLeft);
                    if (TrunkAngleAtTouchdownLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblTrunkAngleAtTouchdownLeftM1.Text = "";
                        misv.variableName = "TAATouchDown";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblTrunkAngleAtTouchdownRightM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["TAATouchDown"].ToString());
                    //if (lblTrunkAngleAtTouchdownRightM1.Text == "" || lblTrunkAngleAtTouchdownRightM1.Text == "0")
                    decimal TrunkAngleAtTouchdownRight;
                    decimal.TryParse(ds.Tables[5].Rows[0]["TAATouchDown"].ToString(), out TrunkAngleAtTouchdownRight);
                    if (TrunkAngleAtTouchdownRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblTrunkAngleAtTouchdownRightM1.Text = "";
                        misv.variableName = "TAATouchDown";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblKneeSeperationAtTouchdownLeftM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["KSATouchDown"].ToString());
                    //if (lblKneeSeperationAtTouchdownLeftM1.Text == "" || lblKneeSeperationAtTouchdownLeftM1.Text == "0.000")
                    decimal KneeSeperationAtTouchdownLeft;
                    decimal.TryParse(ds.Tables[5].Rows[0]["KSATouchDown"].ToString(), out KneeSeperationAtTouchdownLeft);
                    if (KneeSeperationAtTouchdownLeft == 0)

                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblKneeSeperationAtTouchdownLeftM1.Text = "";
                        misv.variableName = "KSATouchDown";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblKneeSeperationAtTouchdownRightM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["KSATouchDown"].ToString());
                    //if (lblKneeSeperationAtTouchdownRightM1.Text == "" || lblKneeSeperationAtTouchdownRightM1.Text == "0.000")
                    decimal KneeSeperationAtTouchdownRight;
                    decimal.TryParse(ds.Tables[5].Rows[0]["KSATouchDown"].ToString(), out KneeSeperationAtTouchdownRight);
                    if (KneeSeperationAtTouchdownRight == 0)

                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblKneeSeperationAtTouchdownRightM1.Text = "";
                        misv.variableName = "KSATouchDown";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblTouchDownDistanceLeftM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["COGDistance"].ToString());
                    //if (lblTouchDownDistanceLeftM1.Text == "" || lblTouchDownDistanceLeftM1.Text == "0.000")
                    decimal TouchDownDistanceLeft;
                    decimal.TryParse(ds.Tables[5].Rows[0]["COGDistance"].ToString(), out TouchDownDistanceLeft);
                    if (TouchDownDistanceLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblTouchDownDistanceLeftM1.Text = "";
                        misv.variableName = "COGDistance";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblTouchDownDistanceRightM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["COGDistance"].ToString());
                    //if (lblTouchDownDistanceRightM1.Text == "" || lblTouchDownDistanceRightM1.Text == "0.000")
                    decimal TouchDownDistanceRight;
                    decimal.TryParse(ds.Tables[5].Rows[0]["COGDistance"].ToString(), out TouchDownDistanceRight);
                    if (TouchDownDistanceRight == 0)

                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblTouchDownDistanceRightM1.Text = "";
                        misv.variableName = "COGDistance";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblUpperLegFullExtentionAngleLeftM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["ULFullExtensionAngle"].ToString());
                    //if (lblUpperLegFullExtentionAngleLeftM1.Text == "" || lblUpperLegFullExtentionAngleLeftM1.Text == "0")
                    decimal UpperLegFullExtentionAngleLeft;
                    decimal.TryParse(ds.Tables[5].Rows[0]["ULFullExtensionAngle"].ToString(), out UpperLegFullExtentionAngleLeft);
                    if (UpperLegFullExtentionAngleLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblUpperLegFullExtentionAngleLeftM1.Text = "";
                        misv.variableName = "ULFullExtensionAngle";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblUpperLegFullExtentionAngleRightM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["ULFullExtensionAngle"].ToString());
                    //if (lblUpperLegFullExtentionAngleRightM1.Text == "" || lblUpperLegFullExtentionAngleRightM1.Text == "0")
                    decimal UpperLegFullExtentionAngleRight;
                    decimal.TryParse(ds.Tables[5].Rows[0]["ULFullExtensionAngle"].ToString(), out UpperLegFullExtentionAngleRight);
                    if (UpperLegFullExtentionAngleRight == 0)
                    {

                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblUpperLegFullExtentionAngleRightM1.Text = "";
                        misv.variableName = "ULFullExtensionAngle";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblLowerLegAngleAtTakeOfLeftM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["LLAngleTakeoff"].ToString());
                    //if (lblLowerLegAngleAtTakeOfLeftM1.Text == "" || lblLowerLegAngleAtTakeOfLeftM1.Text == "0")
                    decimal LowerLegAngleAtTakeOfLeft;
                    decimal.TryParse(ds.Tables[5].Rows[0]["LLAngleTakeoff"].ToString(), out LowerLegAngleAtTakeOfLeft);
                    if (LowerLegAngleAtTakeOfLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblLowerLegAngleAtTakeOfLeftM1.Text = "";
                        misv.variableName = "LLAngleTakeoff";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblLowerLegAngleAtTakeOfRightM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["LLAngleTakeoff"].ToString());
                    //if (lblLowerLegAngleAtTakeOfRightM1.Text == "" || lblLowerLegAngleAtTakeOfRightM1.Text == "0")
                    decimal LowerLegAngleAtTakeOfRight;
                    decimal.TryParse(ds.Tables[5].Rows[0]["LLAngleTakeoff"].ToString(), out LowerLegAngleAtTakeOfRight);
                    if (LowerLegAngleAtTakeOfRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblLowerLegAngleAtTakeOfRightM1.Text = "";
                        misv.variableName = "LLAngleTakeoff";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblLowerLegFullFlexionAngleLeftM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["LLFullFlexionAngle"].ToString());
                    //if (lblLowerLegFullFlexionAngleLeftM1.Text == "" || lblLowerLegFullFlexionAngleLeftM1.Text == "0")
                    decimal LowerLegFullFlexionAngleLeft;
                    decimal.TryParse(ds.Tables[5].Rows[0]["LLFullFlexionAngle"].ToString(), out LowerLegFullFlexionAngleLeft);
                    if (LowerLegFullFlexionAngleLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblLowerLegFullFlexionAngleLeftM1.Text = "";
                        misv.variableName = "LLFullFlexionAngle";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblLowerLegFullFlexionAngleRightM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["LLFullFlexionAngle"].ToString());
                    //if (lblLowerLegFullFlexionAngleRightM1.Text == "" || lblLowerLegFullFlexionAngleRightM1.Text == "0")
                    decimal LowerLegFullFlexionAngleRight;
                    decimal.TryParse(ds.Tables[5].Rows[0]["LLFullFlexionAngle"].ToString(), out LowerLegFullFlexionAngleRight);
                    if (LowerLegFullFlexionAngleRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblLowerLegFullFlexionAngleRightM1.Text = "";
                        misv.variableName = "LLFullFlexionAngle";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    lblUpperLegFullFlexionAngleLeftM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["ULFullFlexionAngle"].ToString());
                    //if (lblUpperLegFullFlexionAngleLeftM1.Text == "" || lblUpperLegFullFlexionAngleLeftM1.Text == "0")
                    decimal UpperLegFullFlexionAngleLeft;
                    decimal.TryParse(ds.Tables[5].Rows[0]["ULFullFlexionAngle"].ToString(), out UpperLegFullFlexionAngleLeft);
                    if (UpperLegFullFlexionAngleLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblUpperLegFullFlexionAngleLeftM1.Text = "";
                        misv.variableName = "ULFullFlexionAngle";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }

                    lblUpperLegFullFlexionAngleRightM1.Text = Convert.ToString(ds.Tables[5].Rows[0]["ULFullFlexionAngle"].ToString());
                    //if (lblUpperLegFullFlexionAngleRightM1.Text == "" || lblUpperLegFullFlexionAngleRightM1.Text == "0")
                    decimal UpperLegFullFlexionAngleRight;
                    decimal.TryParse(ds.Tables[5].Rows[0]["ULFullFlexionAngle"].ToString(), out UpperLegFullFlexionAngleRight);
                    if (UpperLegFullFlexionAngleRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblUpperLegFullFlexionAngleRightM1.Text = "";
                        misv.variableName = "ULFullFlexionAngle";
                        missingVariable.Add(misv);
                        modelCnt++;
                    }
                    #endregion[model Data]
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    DataRow drVariable = ds.Tables[2].Rows[0];
                    #region[current Data]
                    decimal GroundTimeLeft;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Ground Time Left"].ToString(), out GroundTimeLeft);

                    lblGroundTimeLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Ground Time Left"].ToString());
                    //if (lblGroundTimeLeftF.Text == "" || lblGroundTimeLeftF.Text == "0.000")
                    if (GroundTimeLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblGroundTimeLeftF.Text = "";
                        misv.variableName = "Ground Time Left";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    lblGroundTimeRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Ground Time Right"].ToString());
                    //if (lblGroundTimeRightF.Text == "" || lblGroundTimeRightF.Text == "0.000")
                    decimal GroundTimeRight;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Ground Time Right"].ToString(), out GroundTimeRight);
                    if (GroundTimeRight ==0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblGroundTimeRightF.Text = "";
                        misv.variableName = "Ground Time Right";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    lblAirTimeLeftToRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Air Time Left to Right"].ToString());
                    //if (lblAirTimeLeftToRightF.Text == "" || lblAirTimeLeftToRightF.Text == "0.000")
		    decimal AirTimeLeftToRight;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Air Time Left to Right"].ToString(), out AirTimeLeftToRight);
                    if(AirTimeLeftToRight == 0 )
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblAirTimeLeftToRightF.Text = "";
                        misv.variableName = "Air Time Left to Right";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    lblAirTimeRightToLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Air Time Right to Left"].ToString());
                    //if (lblAirTimeRightToLeftF.Text == "" || lblAirTimeRightToLeftF.Text == "0.000")
                    decimal AirTimeRightToLeft;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Air Time Right to Left"].ToString(), out AirTimeRightToLeft);
                    if (AirTimeRightToLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblAirTimeRightToLeftF.Text = "";
                        misv.variableName = "Air Time Right to Left";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    lblTimeToUpperLegFullFlexionLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Time to Upper Leg Full Flexion Left"].ToString());
                    //if (lblTimeToUpperLegFullFlexionLeftF.Text == "" || lblTimeToUpperLegFullFlexionLeftF.Text == "0.000")
                    decimal TimeToUpperLegFullFlexionLeft;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Time to Upper Leg Full Flexion Left"].ToString(),out TimeToUpperLegFullFlexionLeft);
                    if (TimeToUpperLegFullFlexionLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblTimeToUpperLegFullFlexionLeftF.Text = "";
                        misv.variableName = "Time to Upper Leg Full Flexion Left";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    lblTimeToUpperLegFullFlexionRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Time to Upper Leg Full Flexion Right"].ToString());
                    //if (lblTimeToUpperLegFullFlexionRightF.Text == "" || lblTimeToUpperLegFullFlexionRightF.Text == "0.000")
                    decimal TimeToUpperLegFullFlexionRight;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Time to Upper Leg Full Flexion Right"].ToString(), out TimeToUpperLegFullFlexionRight);
                    if (TimeToUpperLegFullFlexionRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblTimeToUpperLegFullFlexionRightF.Text = "";
                        misv.variableName = "Time to Upper Leg Full Flexion Right";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                   lblStrideLengthLeftToRighF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Stride Length Left to Right"].ToString());
                    //if (lblStrideLengthLeftToRighF.Text == "" || lblStrideLengthLeftToRighF.Text == "0.000")
                    decimal StrideLengthLeftToRig;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Stride Length Left to Right"].ToString() , out StrideLengthLeftToRig);
                    if (StrideLengthLeftToRig == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                       lblStrideLengthLeftToRighF.Text = "";
                        misv.variableName = "Stride Length Left to Right";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    lblStrideLengthRightToLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Stride Length Right to Left"].ToString());
                    //if (lblStrideLengthRightToLeftF.Text == "" || lblStrideLengthRightToLeftF.Text == "0.000")
                    decimal StrideLengthRightToLeft;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Stride Length Right to Left"].ToString(), out StrideLengthRightToLeft);
                    if (StrideLengthRightToLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStrideLengthRightToLeftF.Text = "";
                        misv.variableName = "Stride Length Right to Left";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    lblTrunkAngleAtTouchdownLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TAATouchDownLeft"].ToString());
                    //if (lblTrunkAngleAtTouchdownLeftF.Text == "" || lblTrunkAngleAtTouchdownLeftF.Text == "0")
                    decimal TrunkAngleAtTouchdownLeft;
                    decimal.TryParse(ds.Tables[2].Rows[0]["TAATouchDownLeft"].ToString(), out TrunkAngleAtTouchdownLeft);
                    if (TrunkAngleAtTouchdownLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblTrunkAngleAtTouchdownLeftF.Text = "";
                        misv.variableName = "TAATouchDownLeft";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    lblTrunkAngleAtTouchdownRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TAATouchDownRight"].ToString());
                    //if (lblTrunkAngleAtTouchdownRightF.Text == "" || lblTrunkAngleAtTouchdownRightF.Text == "0")
                    decimal TrunkAngleAtTouchdownRight;
                    decimal.TryParse(ds.Tables[2].Rows[0]["TAATouchDownRight"].ToString(), out TrunkAngleAtTouchdownRight);
                    if (TrunkAngleAtTouchdownRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                       lblTrunkAngleAtTouchdownRightF.Text = "";
                        misv.variableName = "TAATouchDownRight";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    lblKneeSeperationAtTouchdownLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["KSATouchDownLeft"].ToString());
                    //if (lblKneeSeperationAtTouchdownLeftF.Text == "" || lblKneeSeperationAtTouchdownLeftF.Text == "0.000")
                    decimal KneeSeperationAtTouchdownLeft;
                    decimal.TryParse(ds.Tables[2].Rows[0]["KSATouchDownLeft"].ToString(), out KneeSeperationAtTouchdownLeft);
                    if (KneeSeperationAtTouchdownLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblKneeSeperationAtTouchdownLeftF.Text = "";
                        misv.variableName = "KSATouchDownLeft";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }

                    lblKneeSeperationAtTouchdownRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["KSATouchDownRight"].ToString());
                    //if (lblKneeSeperationAtTouchdownRightF.Text == "" || lblKneeSeperationAtTouchdownRightF.Text == "0.000")
                    decimal KneeSeperationAtTouchdownRight;
                    decimal.TryParse(ds.Tables[2].Rows[0]["KSATouchDownRight"].ToString(), out KneeSeperationAtTouchdownRight);
                    if (KneeSeperationAtTouchdownRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblKneeSeperationAtTouchdownRightF.Text = "";
                        misv.variableName = "KSATouchDownRight";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    lblTouchDownDistanceLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Touchdown Distance Left"].ToString());
                    //if (lblTouchDownDistanceLeftF.Text == "" || lblTouchDownDistanceLeftF.Text == "0.000")
                    decimal TouchDownDistanceLeft;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Touchdown Distance Left"].ToString(), out TouchDownDistanceLeft);
                    if (TouchDownDistanceLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblTouchDownDistanceLeftF.Text = "";
                        misv.variableName = "Touchdown Distance Left";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    lblTouchDownDistanceRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Touchdown Distance Right"].ToString());
                    //if (lblTouchDownDistanceRightF.Text == "" || lblTouchDownDistanceRightF.Text == "0.000")
                    decimal TouchDownDistanceRight;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Touchdown Distance Right"].ToString(), out TouchDownDistanceRight);
                    if (TouchDownDistanceRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblTouchDownDistanceRightF.Text = "";
                        misv.variableName = "Touchdown Distance Right";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    lblUpperLegFullExtentionAngleLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Extension Angle Left"].ToString());
                    //if (lblUpperLegFullExtentionAngleLeftF.Text == "" || lblUpperLegFullExtentionAngleLeftF.Text == "0")
                    decimal UpperLegFullExtentionAngleLeft;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Upper Leg Full Extension Angle Left"].ToString(), out UpperLegFullExtentionAngleLeft);
                    if (UpperLegFullExtentionAngleLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblUpperLegFullExtentionAngleLeftF.Text = "";
                        misv.variableName = "Upper Leg Full Extension Angle Left";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    lblUpperLegFullExtentionAngleRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Extension Angle Right"].ToString());
                    //if (lblUpperLegFullExtentionAngleRightF.Text == "" || lblUpperLegFullExtentionAngleRightF.Text == "0")
                    decimal UpperLegFullExtentionAngleRight;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Upper Leg Full Extension Angle Right"].ToString() , out UpperLegFullExtentionAngleRight);
                    if (UpperLegFullExtentionAngleRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblUpperLegFullExtentionAngleRightF.Text = "";
                        misv.variableName = "Upper Leg Full Extension Angle Right";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    lblLowerLegAngleAtTakeOfLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Takeoff Left"].ToString());
                    //if (lblLowerLegAngleAtTakeOfLeftF.Text == "" || lblLowerLegAngleAtTakeOfLeftF.Text == "0")
                    decimal LowerLegAngleAtTakeOfLeft;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Lower Leg Angle at Takeoff Left"].ToString(), out LowerLegAngleAtTakeOfLeft);
                    if (LowerLegAngleAtTakeOfLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblLowerLegAngleAtTakeOfLeftF.Text = "";
                        misv.variableName = "Lower Leg Angle at Takeoff Left";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    lblLowerLegAngleAtTakeOfRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Takeoff Right"].ToString());
                    //if (lblLowerLegAngleAtTakeOfRightF.Text == "" || lblLowerLegAngleAtTakeOfRightF.Text == "0")
                    decimal LowerLegAngleAtTakeOfRight;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Lower Leg Angle at Takeoff Right"].ToString(), out LowerLegAngleAtTakeOfRight);
                    if (LowerLegAngleAtTakeOfRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblLowerLegAngleAtTakeOfRightF.Text = "";
                        misv.variableName = "Lower Leg Angle at Takeoff Right";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    lblLowerLegFullFlexionAngleLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Full Flexion Angle Left"].ToString());
                    //if (lblLowerLegFullFlexionAngleLeftF.Text == "" || lblLowerLegFullFlexionAngleLeftF.Text == "0")
                    decimal LowerLegFullFlexionAngleLeft;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Lower Leg Full Flexion Angle Left"].ToString(), out LowerLegFullFlexionAngleLeft);
                    if (LowerLegFullFlexionAngleLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblLowerLegFullFlexionAngleLeftF.Text = "";
                        misv.variableName = "Lower Leg Full Flexion Angle Left";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    lblLowerLegFullFlexionAngleRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Full Flexion Angle Right"].ToString());
                    //if (lblLowerLegFullFlexionAngleRightF.Text == "" || lblLowerLegFullFlexionAngleRightF.Text == "0")
                    decimal LowerLegFullFlexionAngleRight;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Lower Leg Full Flexion Angle Right"].ToString(), out LowerLegFullFlexionAngleRight);
                    if (LowerLegFullFlexionAngleRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                       lblLowerLegFullFlexionAngleRightF.Text = "";
                        misv.variableName = "Lower Leg Full Flexion Angle Right";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    //lblLowerLegAngleAtAnkleCrossLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Ankle Cross Left"].ToString());
                    //if (lblLowerLegAngleAtAnkleCrossLeftF.Text == "" || lblLowerLegAngleAtAnkleCrossLeftF.Text == "0")
                    //{
                    //    lblLowerLegAngleAtAnkleCrossLeftF.Text = "";
                    //}
                    //lblLowerLegAngleAtAnkleCrossRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Ankle Cross Right"].ToString());
                    //if (lblLowerLegAngleAtAnkleCrossRightF.Text == "" || lblLowerLegAngleAtAnkleCrossRightF.Text == "0")
                    //{
                    //    lblLowerLegAngleAtAnkleCrossRightF.Text = "";
                    //}
                    lblUpperLegFullFlexionAngleLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Flexion Angle Left"].ToString());
                    //if (lblUpperLegFullFlexionAngleLeftF.Text == "" || lblUpperLegFullFlexionAngleLeftF.Text == "0")
                    decimal UpperLegFullFlexionAngleLeft;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Upper Leg Full Flexion Angle Left"].ToString(), out UpperLegFullFlexionAngleLeft);
                    if (UpperLegFullFlexionAngleLeft == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblUpperLegFullFlexionAngleLeftF.Text = "";
                        misv.variableName = "Upper Leg Full Flexion Angle Left";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    lblUpperLegFullFlexionAngleRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Flexion Angle Right"].ToString());
                    //if (lblUpperLegFullFlexionAngleRightF.Text == "" || lblUpperLegFullFlexionAngleRightF.Text == "0")
                    decimal UpperLegFullFlexionAngleRight;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Upper Leg Full Flexion Angle Right"].ToString() , out UpperLegFullFlexionAngleRight);
                    if (UpperLegFullFlexionAngleRight == 0)
                    {
                        //misv.type = _type;
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblUpperLegFullFlexionAngleRightF.Text = "";
                        misv.variableName = "Upper Leg Full Flexion Angle Right";
                        missingVariable.Add(misv);
                        CurrentCnt++;
                    }
                    #endregion[current Data]
                }
                sendNotFoundEmail(initialcnt, modelCnt, CurrentCnt);
            }
        }
    }

    public void GetAllSprintAthleteInitialAndCurrentData(int LessonId)
    {
        MissingVariable misv = new MissingVariable();
        if (ds != null)
        {
            ds = sae.GetAllSprintAthletesData(LessonId);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow drVariable = ds.Tables[0].Rows[0];
                    #region[initial Data]

                    lblGroundTimeLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ground Time Left"].ToString());
                    if (lblGroundTimeLeftI.Text == "" || lblGroundTimeLeftI.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblGroundTimeLeftI.Text = "";
                        misv.variableName = "GroundTimeLeft";
                        missingVariable.Add(misv);
                    }
                    lblGroundTimeRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ground Time Right"].ToString());
                    if (lblGroundTimeRightI.Text == "" || lblGroundTimeRightI.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblGroundTimeRightI.Text = "";
                        misv.variableName = "GroundTimeRight";
                        missingVariable.Add(misv);
                    }
                    lblAirTimeLeftToRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Air Time Left to Right"].ToString());
                    if (lblAirTimeLeftToRightI.Text == "" || lblAirTimeLeftToRightI.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblAirTimeLeftToRightI.Text = "";
                        misv.variableName = "Air Time Left to Right";
                        missingVariable.Add(misv);
                    }
                    lblAirTimeRightToLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Air Time Right to Left"].ToString());
                    if (lblAirTimeRightToLeftI.Text == "" || lblAirTimeRightToLeftI.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblAirTimeRightToLeftI.Text = "";
                        misv.variableName = "Air Time Right to Left";
                        missingVariable.Add(misv);
                    }
                    lblTimeToUpperLegFullFlexionLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Time to Upper Leg Full Flexion Left"].ToString());
                    if (lblTimeToUpperLegFullFlexionLeftI.Text == "" || lblTimeToUpperLegFullFlexionLeftI.Text == "0.000")
                    {
                        //misv.type = _type;
                        misv.variableName = "Time to Upper Leg Full Flexion Left";
                        missingVariable.Add(misv);
                    }
                    lblTimeToUpperLegFullFlexionRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Time to Upper Leg Full Flexion Right"].ToString());
                    if (lblTimeToUpperLegFullFlexionRightI.Text == "" || lblTimeToUpperLegFullFlexionRightI.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblTimeToUpperLegFullFlexionRightI.Text = "";
                        misv.variableName = "Time to Upper Leg Full Flexion Right";
                        missingVariable.Add(misv);
                    }
                    lblStrideLengthLeftToRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Stride Length Left to Right"].ToString());
                    if (lblStrideLengthLeftToRightI.Text == "" || lblStrideLengthLeftToRightI.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblStrideLengthLeftToRightI.Text = "";
                        misv.variableName = "Stride Length Left to Right";
                        missingVariable.Add(misv);
                    }
                    lblStrideLengthRightToLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Stride Length Right to Left"].ToString());
                    if (lblStrideLengthRightToLeftI.Text == "" || lblStrideLengthRightToLeftI.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblStrideLengthRightToLeftI.Text = "";
                        misv.variableName = "Stride Length Right to Left";
                        missingVariable.Add(misv);
                    }

                    lblTrunkAngleAtTouchdownLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TAATouchDownLeft"].ToString());
                    if (lblTrunkAngleAtTouchdownLeftI.Text == "" || lblTrunkAngleAtTouchdownLeftI.Text == "0")
                    {
                        //misv.type = _type;
                        lblTrunkAngleAtTouchdownLeftI.Text = "";
                        misv.variableName = "TAATouchDownLeft";
                        missingVariable.Add(misv);
                    }
                    lblTrunkAngleAtTouchdownRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TAATouchDownRight"].ToString());
                    if (lblTrunkAngleAtTouchdownRightI.Text == "" || lblTrunkAngleAtTouchdownRightI.Text == "0")
                    {
                        //misv.type = _type;
                        lblTrunkAngleAtTouchdownRightI.Text = "";
                        misv.variableName = "TAATouchDownRight";
                        missingVariable.Add(misv);
                    }

                    lblKneeSeperationAtTouchdownLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["KSATouchDownLeft"].ToString());
                    if (lblKneeSeperationAtTouchdownLeftI.Text == "" || lblKneeSeperationAtTouchdownLeftI.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblKneeSeperationAtTouchdownLeftI.Text = "";
                        misv.variableName = "KSATouchDownLeft";
                        missingVariable.Add(misv);
                    }
                    lblKneeSeperationAtTouchdownRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["KSATouchDownRight"].ToString());
                    if (lblKneeSeperationAtTouchdownRightI.Text == "" || lblKneeSeperationAtTouchdownRightI.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblKneeSeperationAtTouchdownRightI.Text = "";
                        misv.variableName = "KSATouchDownRight";
                        missingVariable.Add(misv);
                    }

                    lblTouchDownDistanceLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Touchdown Distance Left"].ToString());
                    if (lblTouchDownDistanceLeftI.Text == "" || lblTouchDownDistanceLeftI.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblTouchDownDistanceLeftI.Text = "";
                        misv.variableName = "Touchdown Distance Left";
                        missingVariable.Add(misv);
                    }
                    lblTouchDownDistanceRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Touchdown Distance Right"].ToString());
                    if (lblTouchDownDistanceRightI.Text == "" || lblTouchDownDistanceRightI.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblTouchDownDistanceRightI.Text = "";
                        misv.variableName = "Touchdown Distance Right";
                        missingVariable.Add(misv);
                    }
                    lblUpperLegFullExtentionAngleLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Extension Angle Left"].ToString());
                    if (lblUpperLegFullExtentionAngleLeftI.Text == "" || lblUpperLegFullExtentionAngleLeftI.Text == "0")
                    {
                        //misv.type = _type;
                        lblUpperLegFullExtentionAngleLeftI.Text = "";
                        misv.variableName = "Upper Leg Full Extension Angle Left";
                        missingVariable.Add(misv);
                    }
                    lblUpperLegFullExtentionAngleRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Extension Angle Right"].ToString());
                    if (lblUpperLegFullExtentionAngleRightI.Text == "" || lblUpperLegFullExtentionAngleRightI.Text == "0")
                    {
                        //misv.type = _type;
                        lblUpperLegFullExtentionAngleRightI.Text = "";
                        misv.variableName = "Upper Leg Full Extension Angle Right";
                        missingVariable.Add(misv);
                    }
                    lblLowerLegAngleAtTakeOfLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Angle at Takeoff Left"].ToString());
                    if (lblLowerLegAngleAtTakeOfLeftI.Text == "" || lblLowerLegAngleAtTakeOfLeftI.Text == "0")
                    {
                        //misv.type = _type;
                        lblLowerLegAngleAtTakeOfLeftI.Text = "";
                        misv.variableName = "Lower Leg Angle at Takeoff Left";
                        missingVariable.Add(misv);
                    }
                    lblLowerLegAngleAtTakeOfRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Angle at Takeoff Right"].ToString());
                    if (lblLowerLegAngleAtTakeOfRightI.Text == "" || lblLowerLegAngleAtTakeOfRightI.Text == "0")
                    {
                        //misv.type = _type;
                        lblLowerLegAngleAtTakeOfRightI.Text = "";
                        misv.variableName = "Lower Leg Angle at Takeoff Right";
                        missingVariable.Add(misv);
                    }
                    lblLowerLegFullFlexionAngleLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Full Flexion Angle Left"].ToString());
                    if (lblLowerLegFullFlexionAngleLeftI.Text == "" || lblLowerLegFullFlexionAngleLeftI.Text == "0")
                    {
                        //misv.type = _type;
                        lblLowerLegFullFlexionAngleLeftI.Text = "";
                        misv.variableName = "Lower Leg Full Flexion Angle Left";
                        missingVariable.Add(misv);
                    }
                    lblLowerLegFullFlexionAngleRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Full Flexion Angle Right"].ToString());
                    if (lblLowerLegFullFlexionAngleRightI.Text == "" || lblLowerLegFullFlexionAngleRightI.Text == "0")
                    {
                        //misv.type = _type;
                        lblLowerLegFullFlexionAngleRightI.Text = "";
                        misv.variableName = "Lower Leg Full Flexion Angle Right";
                        missingVariable.Add(misv);
                    }
                    lblUpperLegFullFlexionAngleLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Flexion Angle Left"].ToString());
                    if (lblUpperLegFullFlexionAngleLeftI.Text == "" || lblUpperLegFullFlexionAngleLeftI.Text == "0")
                    {
                        //misv.type = _type;
                        lblUpperLegFullFlexionAngleLeftI.Text = "";
                        misv.variableName = "Upper Leg Full Flexion Angle Left";
                        missingVariable.Add(misv);
                    }
                    lblUpperLegFullFlexionAngleRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Flexion Angle Right"].ToString());
                    if (lblUpperLegFullFlexionAngleRightI.Text == "" || lblUpperLegFullFlexionAngleRightI.Text == "0")
                    {
                        //misv.type = _type;
                        lblUpperLegFullFlexionAngleRightI.Text = "";
                        misv.variableName = "Upper Leg Full Flexion Angle Right";
                        missingVariable.Add(misv);
                    }
                    #endregion[initial Data]
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    DataRow drVariable = ds.Tables[2].Rows[0];
                    #region[current Data]
                    lblGroundTimeLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Ground Time Left"].ToString());
                    if (lblGroundTimeLeftF.Text == "" || lblGroundTimeLeftF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblGroundTimeLeftF.Text = "";
                        misv.variableName = "Ground Time Left";
                        missingVariable.Add(misv);
                    }
                    lblGroundTimeRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Ground Time Right"].ToString());
                    if (lblGroundTimeRightF.Text == "" || lblGroundTimeRightF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblGroundTimeRightF.Text = "";
                        misv.variableName = "Ground Time Right";
                        missingVariable.Add(misv);
                    }
                    lblAirTimeLeftToRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Air Time Left to Right"].ToString());
                    if (lblAirTimeLeftToRightF.Text == "" || lblAirTimeLeftToRightF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblAirTimeLeftToRightF.Text = "";
                        misv.variableName = "Air Time Left to Right";
                        missingVariable.Add(misv);
                    }
                    lblAirTimeRightToLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Air Time Right to Left"].ToString());
                    if (lblAirTimeRightToLeftF.Text == "" || lblAirTimeRightToLeftF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblAirTimeRightToLeftF.Text = "";
                        misv.variableName = "Air Time Right to Left";
                        missingVariable.Add(misv);
                    }
                    lblTimeToUpperLegFullFlexionLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Time to Upper Leg Full Flexion Left"].ToString());
                    if (lblTimeToUpperLegFullFlexionLeftF.Text == "" || lblTimeToUpperLegFullFlexionLeftF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblTimeToUpperLegFullFlexionLeftF.Text = "";
                        misv.variableName = "Time to Upper Leg Full Flexion Left";
                        missingVariable.Add(misv);
                    }
                    lblTimeToUpperLegFullFlexionRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Time to Upper Leg Full Flexion Right"].ToString());
                    if (lblTimeToUpperLegFullFlexionRightF.Text == "" || lblTimeToUpperLegFullFlexionRightF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblTimeToUpperLegFullFlexionRightF.Text = "";
                        misv.variableName = "Time to Upper Leg Full Flexion Right";
                        missingVariable.Add(misv);
                    }
                    lblStrideLengthLeftToRighF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Stride Length Left to Right"].ToString());
                    if (lblStrideLengthLeftToRighF.Text == "" || lblStrideLengthLeftToRighF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblStrideLengthLeftToRighF.Text = "";
                        misv.variableName = "Stride Length Left to Right";
                        missingVariable.Add(misv);
                    }
                    lblStrideLengthRightToLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Stride Length Right to Left"].ToString());
                    if (lblStrideLengthRightToLeftF.Text == "" || lblStrideLengthRightToLeftF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblStrideLengthRightToLeftF.Text = "";
                        misv.variableName = "Stride Length Right to Left";
                        missingVariable.Add(misv);
                    }
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    lblTrunkAngleAtTouchdownLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TAATouchDownLeft"].ToString());
                    if (lblTrunkAngleAtTouchdownLeftF.Text == "" || lblTrunkAngleAtTouchdownLeftF.Text == "0")
                    {
                        //misv.type = _type;
                        lblTrunkAngleAtTouchdownLeftF.Text = "";
                        misv.variableName = "TAATouchDownLeft";
                        missingVariable.Add(misv);
                    }
                    lblTrunkAngleAtTouchdownRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TAATouchDownRight"].ToString());
                    if (lblTrunkAngleAtTouchdownRightF.Text == "" || lblTrunkAngleAtTouchdownRightF.Text == "0")
                    {
                        //misv.type = _type;
                        lblTrunkAngleAtTouchdownRightF.Text = "";
                        misv.variableName = "TAATouchDownRight";
                        missingVariable.Add(misv);
                    }
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    lblKneeSeperationAtTouchdownLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["KSATouchDownLeft"].ToString());
                    if (lblKneeSeperationAtTouchdownLeftF.Text == "" || lblKneeSeperationAtTouchdownLeftF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblKneeSeperationAtTouchdownLeftF.Text = "";
                        misv.variableName = "KSATouchDownLeft";
                        missingVariable.Add(misv);
                    }

                    lblKneeSeperationAtTouchdownRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["KSATouchDownRight"].ToString());
                    if (lblKneeSeperationAtTouchdownRightF.Text == "" || lblKneeSeperationAtTouchdownRightF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblKneeSeperationAtTouchdownRightF.Text = "";
                        misv.variableName = "KSATouchDownRight";
                        missingVariable.Add(misv);
                    }
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    lblTouchDownDistanceLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Touchdown Distance Left"].ToString());
                    if (lblTouchDownDistanceLeftF.Text == "" || lblTouchDownDistanceLeftF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblTouchDownDistanceLeftF.Text = "";
                        misv.variableName = "Touchdown Distance Left";
                        missingVariable.Add(misv);
                    }
                    lblTouchDownDistanceRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Touchdown Distance Right"].ToString());
                    if (lblTouchDownDistanceRightF.Text == "" || lblTouchDownDistanceRightF.Text == "0.000")
                    {
                        //misv.type = _type;
                        lblTouchDownDistanceRightF.Text = "";
                        misv.variableName = "Touchdown Distance Right";
                        missingVariable.Add(misv);
                    }
                    lblUpperLegFullExtentionAngleLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Extension Angle Left"].ToString());
                    if (lblUpperLegFullExtentionAngleLeftF.Text == "" || lblUpperLegFullExtentionAngleLeftF.Text == "0")
                    {
                        //misv.type = _type;
                        lblUpperLegFullExtentionAngleLeftF.Text = "";
                        misv.variableName = "Upper Leg Full Extension Angle Left";
                        missingVariable.Add(misv);
                    }
                    lblUpperLegFullExtentionAngleRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Extension Angle Right"].ToString());
                    if (lblUpperLegFullExtentionAngleRightF.Text == "" || lblUpperLegFullExtentionAngleRightF.Text == "0")
                    {
                        //misv.type = _type;
                        lblUpperLegFullExtentionAngleRightF.Text = "";
                        misv.variableName = "Upper Leg Full Extension Angle Right";
                        missingVariable.Add(misv);
                    }
                    lblLowerLegAngleAtTakeOfLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Takeoff Left"].ToString());
                    if (lblLowerLegAngleAtTakeOfLeftF.Text == "" || lblLowerLegAngleAtTakeOfLeftF.Text == "0")
                    {
                        //misv.type = _type;
                        lblLowerLegAngleAtTakeOfLeftF.Text = "";
                        misv.variableName = "Lower Leg Angle at Takeoff Left";
                        missingVariable.Add(misv);
                    }
                    lblLowerLegAngleAtTakeOfRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Takeoff Right"].ToString());
                    if (lblLowerLegAngleAtTakeOfRightF.Text == "" || lblLowerLegAngleAtTakeOfRightF.Text == "0")
                    {
                        //misv.type = _type;
                        lblLowerLegAngleAtTakeOfRightF.Text = "";
                        misv.variableName = "Lower Leg Angle at Takeoff Right";
                        missingVariable.Add(misv);
                    }
                    lblLowerLegFullFlexionAngleLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Full Flexion Angle Left"].ToString());
                    if (lblLowerLegFullFlexionAngleLeftF.Text == "" || lblLowerLegFullFlexionAngleLeftF.Text == "0")
                    {
                        //misv.type = _type;
                        lblLowerLegFullFlexionAngleLeftF.Text = "";
                        misv.variableName = "Lower Leg Full Flexion Angle Left";
                        missingVariable.Add(misv);
                    }
                    lblLowerLegFullFlexionAngleRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Full Flexion Angle Right"].ToString());
                    if (lblLowerLegFullFlexionAngleRightF.Text == "" || lblLowerLegFullFlexionAngleRightF.Text == "0")
                    {
                        //misv.type = _type;
                        lblLowerLegFullFlexionAngleRightF.Text = "";
                        misv.variableName = "Lower Leg Full Flexion Angle Right";
                        missingVariable.Add(misv);
                    }
                    //lblLowerLegAngleAtAnkleCrossLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Ankle Cross Left"].ToString());
                    //if (lblLowerLegAngleAtAnkleCrossLeftF.Text == "" || lblLowerLegAngleAtAnkleCrossLeftF.Text == "0")
                    //{
                    //    lblLowerLegAngleAtAnkleCrossLeftF.Text = "";
                    //}
                    //lblLowerLegAngleAtAnkleCrossRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Ankle Cross Right"].ToString());
                    //if (lblLowerLegAngleAtAnkleCrossRightF.Text == "" || lblLowerLegAngleAtAnkleCrossRightF.Text == "0")
                    //{
                    //    lblLowerLegAngleAtAnkleCrossRightF.Text = "";
                    //}
                    lblUpperLegFullFlexionAngleLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Flexion Angle Left"].ToString());
                    if (lblUpperLegFullFlexionAngleLeftF.Text == "" || lblUpperLegFullFlexionAngleLeftF.Text == "0")
                    {
                        //misv.type = _type;
                        lblUpperLegFullFlexionAngleLeftF.Text = "";
                        misv.variableName = "Upper Leg Full Flexion Angle Left";
                        missingVariable.Add(misv);
                    }
                    lblUpperLegFullFlexionAngleRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Flexion Angle Right"].ToString());
                    if (lblUpperLegFullFlexionAngleRightF.Text == "" || lblUpperLegFullFlexionAngleRightF.Text == "0")
                    {
                        //misv.type = _type;
                        lblUpperLegFullFlexionAngleRightF.Text = "";
                        misv.variableName = "Upper Leg Full Flexion Angle Right";
                        missingVariable.Add(misv);
                    }
                    #endregion[current Data]
                }
            }
        }
    }

    private string setVariableData(string xmlValue)
    {
        string vairableValue = xmlValue;
        if (vairableValue == "" || vairableValue == "0.000" || vairableValue == "0")
        {
            vairableValue = "";
        }
        return vairableValue;
    }
    protected void btnToBrowseCurrentVideo_Click(object sender, EventArgs e)
    {
        btnDeleteCurrentMovies.Visible = true;
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

            //int AthleteSelected;
            //AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
            //Customer custmer = DataRepository.CustomerProvider.GetByCustomerId(AthleteSelected);
            //var path = HttpContext.Current.Server.MapPath("~/Users/MovieFiles");
            //DirectoryInfo d = new DirectoryInfo(path);
            //FileInfo[] Files = d.GetFiles("*.mp4");
            //var filename2 = custmer.LastName + "-" + custmer.FirstName;
            //var file1 = Files.Where(f => f.Name.StartsWith(filename2.Trim())).Where(f => f.Name.Contains("Current")).ToList();

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
                FilePathClassa objFilePathClass = new FilePathClassa();
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
    private void AddFramesData()
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
        if (!DropDownList1.SelectedValue.Equals("noathlete"))//changes 20170111
        {
            try
            {
                Lesson _lesson = new Lesson();
                Movie _movieCurrentSide = new Movie();
                Movie _movieCurrentBack = new Movie();
                Movie _movieSide = new Movie();
                Movie _movieBack = new Movie();
                int AthleteSelectedId = Convert.ToInt16(DropDownList1.SelectedValue);//changes 20170111
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
                    _movieSide = movieList1[0];
                    _movieBack = movieList1[1];
                    int InitialSide = _movieSide.MovieId;
                    int InitialBack = _movieBack.MovieId;
                    DataRepository.MovieClipProvider.Delete(InitialSide);
                    DataRepository.MovieClipProvider.Delete(InitialBack);
                    DataRepository.MovieProvider.Delete(InitialSide);
                    DataRepository.MovieProvider.Delete(InitialBack);
                }

                string Sprint_InitialDataId = sae.SelectSprintInitialDataid(_lessonselected.ToString());

                if (Sprint_InitialDataId != "")
                {
                    _SprintData.DeleteSprintInitialLessonData(_lessonselected);
                }

                string Sprint_ModelDataId = sae.SelectSprintModelDataid(_lessonselected.ToString());
                if (Sprint_ModelDataId != "")
                {
                    _SprintData.DeleteSprintModelLessonData(_lessonselected);
                }

                string Sprint_CurrentDataId = sae.SelectSprintCurrentDataid(_lessonselected.ToString());
                if (Sprint_CurrentDataId != "")
                {
                    _SprintData.DeleteSprintCurrentLessonData(_lessonselected);
                }

                DataRepository.LessonProvider.Delete(_lessonselected);   //delete lesson 
                sae.UpdateLessonLocation(location, _lesson.LessonId); // changes 20170111
                //System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "refresh", "refresh();", true);// changes 20170111
                OnTrackSession onTrack = new OnTrackSession();
                onTrack.OnTrackSessionData(_lessonselected);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            DropDownList1_SelectedIndexChanged(null, null); // changes 20170111
        }
    }

    public static string GetXMLNodeValue(XmlElement sItems, string sNodeTagName)
    {
        string value = string.Empty;

        if (sItems.GetElementsByTagName(sNodeTagName).Count > 0)
        {
            value = sItems.GetElementsByTagName(sNodeTagName)[0].InnerText;
        }

        return value;
    }

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
            DateTime lessionNameDate2 = DateTime.Parse(dq);


            if (returnnode1.Count() > 0)
            {
                //InitialSide Date --------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>
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


                        }
                    }
                }
                if (lessionNameDate1.Date == lessionNameDate2.Date && lessionNameDate1.Date == InitialSidedate11 || lessionNameDate1.Date == Initialbackdate11 || lessionNameDate1.Date == Currentsidekdate11 || lessionNameDate1.Date == CurrentbackfileDate11)
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
                            //if (txtbFilePath.Text == "")
                            //{
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
                                    var position10 = packageChild.Element("position10").Value;

                                }
                            }
                        }
                        //}
                        if (returnnode.Count() > 0)
                        {
                            //if (txtForCurrentVideo.Text == "")
                            //{
                            IEnumerable<XElement> side = returnnode.Elements("video").Elements("final").Elements("side");

                            if (side.Count() > 0)
                            {
                                foreach (XElement packageChild in side)
                                {
                                    var sidefile = packageChild.Element("file").Value;
                                    if (sidefile != "")
                                    {
                                        cnt2 += Files.Where(f => f.Name == sidefile).Count();
                                        sidefile = sidefile.Substring(0, sidefile.LastIndexOf('-'));
                                        lblNoVideo.Visible = false;
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
                                        cnt2 += Files.Where(f => f.Name == backfile).Count();
                                        backfile = backfile.Substring(0, backfile.LastIndexOf('-'));
                                        lblNoVideo.Visible = false;
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
                                    var position10 = packageChild.Element("position10").Value;
                                }
                            }
                        }
                        //}
                        //----------------------IniialSumamary -----------
                        if (returnnode.Count() > 0)
                        {
                            //if (lblGroundTimeLeftI.Text == "")
                            //{
                            IEnumerable<XElement> InitialSummary = returnnode.Elements("InitialSummary");
                            if (InitialSummary.Count() > 0)
                            {
                                foreach (XElement packageChild in InitialSummary)
                                {

                                    var GroundTimeL = Convert.ToString(packageChild.Element("GroundTimeL").Value);
                                    if (GroundTimeL != string.Empty)
                                    {
                                        lblGroundTimeLeftI.Text = GroundTimeL;
                                    }
                                    var GroundTimeR = Convert.ToString(packageChild.Element("GroundTimeR").Value);
                                    if (GroundTimeR != string.Empty)
                                    {
                                        lblGroundTimeRightI.Text = GroundTimeR;
                                    }

                                    var AirTimeLR = Convert.ToString(packageChild.Element("AirTimeLR").Value);
                                    if (AirTimeLR != string.Empty)
                                    {
                                        lblAirTimeLeftToRightI.Text = AirTimeLR;
                                    }

                                    var AirTimeRL = Convert.ToString(packageChild.Element("AirTimeRL").Value);
                                    if (AirTimeRL != string.Empty)
                                    {
                                        lblAirTimeRightToLeftI.Text = AirTimeRL;
                                    }

                                    var UlFexTimeLR = Convert.ToString(packageChild.Element("UlFexTimeLR").Value);
                                    if (UlFexTimeLR != string.Empty)
                                    {
                                        lblTimeToUpperLegFullFlexionLeftI.Text = UlFexTimeLR;
                                    }
                                    var UlFexTimeRL = Convert.ToString(packageChild.Element("UlFexTimeRL").Value);
                                    if (UlFexTimeRL != string.Empty)
                                    {
                                        lblTimeToUpperLegFullFlexionRightI.Text = UlFexTimeRL;
                                    }
                                    var StrideLengthLR = Convert.ToString(packageChild.Element("StrideLengthLR").Value);
                                    if (StrideLengthLR != string.Empty)
                                    {
                                        lblStrideLengthLeftToRightI.Text = StrideLengthLR;
                                    }
                                    var StrideLengthRL = Convert.ToString(packageChild.Element("StrideLengthRL").Value);
                                    if (StrideLengthRL != string.Empty)
                                    {
                                        lblStrideLengthRightToLeftI.Text = StrideLengthRL;
                                    }

                                    var TrunkAngleTdL = Convert.ToString(packageChild.Element("TrunkAngleTdL").Value);
                                    if (TrunkAngleTdL != string.Empty)
                                    {
                                        lblTrunkAngleAtTouchdownLeftI.Text = TrunkAngleTdL;
                                    }

                                    var TrunkAngleTdR = Convert.ToString(packageChild.Element("TrunkAngleTdR").Value);
                                    if (TrunkAngleTdR != string.Empty)
                                    {
                                        lblTrunkAngleAtTouchdownRightI.Text = TrunkAngleTdR;
                                    }

                                    var KneeSepDistanceL = Convert.ToString(packageChild.Element("KneeSepDistanceL").Value);
                                    if (KneeSepDistanceL != string.Empty)
                                    {
                                        lblKneeSeperationAtTouchdownLeftI.Text = KneeSepDistanceL;
                                    }

                                    var KneeSepDistanceR = Convert.ToString(packageChild.Element("KneeSepDistanceR").Value);
                                    if (KneeSepDistanceR != string.Empty)
                                    {
                                        lblKneeSeperationAtTouchdownRightI.Text = KneeSepDistanceR;
                                    }

                                    var TdDistanceL = Convert.ToString(packageChild.Element("TdDistanceL").Value);
                                    if (TdDistanceL != string.Empty)
                                    {
                                        lblTouchDownDistanceLeftI.Text = TdDistanceL;
                                    }

                                    var TdDistanceR = Convert.ToString(packageChild.Element("TdDistanceR").Value);
                                    if (TdDistanceR != string.Empty)
                                    {
                                        lblTouchDownDistanceRightI.Text = TdDistanceR;
                                    }

                                    var UlAngleFullExtL = Convert.ToString(packageChild.Element("UlAngleFullExtL").Value);
                                    if (UlAngleFullExtL != string.Empty)
                                    {
                                        lblUpperLegFullExtentionAngleLeftI.Text = UlAngleFullExtL;
                                    }

                                    var UlAngleFullExtR = Convert.ToString(packageChild.Element("UlAngleFullExtR").Value);
                                    if (UlAngleFullExtR != string.Empty)
                                    {
                                        lblUpperLegFullExtentionAngleRightI.Text = UlAngleFullExtR;
                                    }

                                    var UlAngleFullFlexL = Convert.ToString(packageChild.Element("UlAngleFullFlexL").Value);
                                    if (UlAngleFullFlexL != string.Empty)
                                    {
                                        lblUpperLegFullFlexionAngleLeftI.Text = UlAngleFullFlexL;
                                    }

                                    var UlAngleFullFlexR = Convert.ToString(packageChild.Element("UlAngleFullFlexR").Value);
                                    if (UlAngleFullFlexR != string.Empty)
                                    {
                                        lblUpperLegFullFlexionAngleRightI.Text = UlAngleFullFlexR;
                                    }

                                    var LlAngleToL = Convert.ToString(packageChild.Element("LlAngleToL").Value);
                                    if (LlAngleToL != string.Empty)
                                    {
                                        lblLowerLegAngleAtTakeOfLeftI.Text = LlAngleToL;
                                    }

                                    var LlAngleToR = Convert.ToString(packageChild.Element("LlAngleToR").Value);
                                    if (LlAngleToR != string.Empty)
                                    {
                                        lblLowerLegAngleAtTakeOfRightI.Text = LlAngleToR;
                                    }

                                    var LlAngleFullFlexL = Convert.ToString(packageChild.Element("LlAngleFullFlexL").Value);
                                    if (LlAngleFullFlexL != string.Empty)
                                    {
                                        lblLowerLegFullFlexionAngleLeftI.Text = LlAngleFullFlexL;
                                    }

                                    var LlAngleFullFlexR = Convert.ToString(packageChild.Element("LlAngleFullFlexR").Value);
                                    if (LlAngleFullFlexR != string.Empty)
                                    {
                                        lblLowerLegFullFlexionAngleRightI.Text = LlAngleFullFlexR;
                                    }
                                }
                            }
                            //}
                            //---------------------------<end> <InitialSummary> <end>-----------------------

                            if (returnnode.Count() > 0)
                            {
                                //if (lblGroundTimeLeftF.Text == "")
                                //{
                                IEnumerable<XElement> CurrentSummary = returnnode.Elements("CurrentSummary");

                                if (CurrentSummary.Count() > 0)
                                {
                                    foreach (XElement packageChild in CurrentSummary)
                                    {

                                        var GroundTimeL = Convert.ToString(packageChild.Element("GroundTimeL").Value);
                                        if (GroundTimeL != string.Empty)
                                        {
                                            lblGroundTimeLeftF.Text = GroundTimeL;
                                        }

                                        var GroundTimeR = Convert.ToString(packageChild.Element("GroundTimeR").Value);
                                        if (GroundTimeR != string.Empty)
                                        {
                                            lblGroundTimeRightF.Text = GroundTimeR;
                                        }
                                        var AirTimeLR = Convert.ToString(packageChild.Element("AirTimeLR").Value);
                                        if (AirTimeLR != string.Empty)
                                        {
                                            lblAirTimeLeftToRightF.Text = AirTimeLR;
                                        }

                                        var AirTimeRL = Convert.ToString(packageChild.Element("AirTimeRL").Value);
                                        if (AirTimeRL != string.Empty)
                                        {
                                            lblAirTimeRightToLeftF.Text = AirTimeRL;
                                        }

                                        var UlFexTimeLR = Convert.ToString(packageChild.Element("UlFexTimeLR").Value);
                                        if (UlFexTimeLR != string.Empty)
                                        {
                                            lblTimeToUpperLegFullFlexionLeftF.Text = UlFexTimeLR;
                                        }

                                        var UlFexTimeRL = Convert.ToString(packageChild.Element("UlFexTimeRL").Value);
                                        if (UlFexTimeRL != string.Empty)
                                        {
                                            lblTimeToUpperLegFullFlexionRightF.Text = UlFexTimeRL;
                                        }

                                        var StrideLengthLR = Convert.ToString(packageChild.Element("StrideLengthLR").Value);
                                        if (StrideLengthLR != string.Empty)
                                        {
                                            lblStrideLengthLeftToRighF.Text = StrideLengthLR;
                                        }

                                        var StrideLengthRL = Convert.ToString(packageChild.Element("StrideLengthRL").Value);
                                        if (StrideLengthRL != string.Empty)
                                        {
                                            lblStrideLengthRightToLeftF.Text = StrideLengthRL;
                                        }

                                        var TrunkAngleTdL = Convert.ToString(packageChild.Element("TrunkAngleTdL").Value);
                                        if (TrunkAngleTdL != string.Empty)
                                        {
                                            lblTrunkAngleAtTouchdownLeftF.Text = TrunkAngleTdL;
                                        }

                                        var TrunkAngleTdR = Convert.ToString(packageChild.Element("TrunkAngleTdR").Value);
                                        if (TrunkAngleTdR != string.Empty)
                                        {
                                            lblTrunkAngleAtTouchdownRightF.Text = TrunkAngleTdR;
                                        }

                                        var KneeSepDistanceL = Convert.ToString(packageChild.Element("KneeSepDistanceL").Value);
                                        if (KneeSepDistanceL != string.Empty)
                                        {
                                            lblKneeSeperationAtTouchdownLeftF.Text = KneeSepDistanceL;
                                        }

                                        var KneeSepDistanceR = Convert.ToString(packageChild.Element("KneeSepDistanceR").Value);
                                        if (KneeSepDistanceR != string.Empty)
                                        {
                                            lblKneeSeperationAtTouchdownRightF.Text = KneeSepDistanceR;
                                        }

                                        var TdDistanceL = Convert.ToString(packageChild.Element("TdDistanceL").Value);
                                        if (TdDistanceL != string.Empty)
                                        {
                                            lblTouchDownDistanceLeftF.Text = TdDistanceL;
                                        }

                                        var TdDistanceR = Convert.ToString(packageChild.Element("TdDistanceR").Value);
                                        if (TdDistanceR != string.Empty)
                                        {
                                            lblTouchDownDistanceRightF.Text = TdDistanceR;
                                        }

                                        var UlAngleFullExtL = Convert.ToString(packageChild.Element("UlAngleFullExtL").Value);
                                        if (UlAngleFullExtL != string.Empty)
                                        {
                                            lblUpperLegFullExtentionAngleLeftF.Text = UlAngleFullExtL;
                                        }

                                        var UlAngleFullExtR = Convert.ToString(packageChild.Element("UlAngleFullExtR").Value);
                                        if (UlAngleFullExtR != string.Empty)
                                        {
                                            lblUpperLegFullExtentionAngleRightF.Text = UlAngleFullExtR;
                                        }

                                        var UlAngleFullFlexL = Convert.ToString(packageChild.Element("UlAngleFullFlexL").Value);
                                        if (UlAngleFullFlexL != string.Empty)
                                        {
                                            lblUpperLegFullFlexionAngleLeftF.Text = UlAngleFullFlexL;
                                        }

                                        var UlAngleFullFlexR = Convert.ToString(packageChild.Element("UlAngleFullFlexR").Value);
                                        if (UlAngleFullFlexR != string.Empty)
                                        {
                                            lblUpperLegFullFlexionAngleRightF.Text = UlAngleFullFlexR;
                                        }

                                        var LlAngleToL = Convert.ToString(packageChild.Element("LlAngleToL").Value);
                                        if (LlAngleToL != string.Empty)
                                        {
                                            lblLowerLegAngleAtTakeOfLeftF.Text = LlAngleToL;
                                        }

                                        var LlAngleToR = Convert.ToString(packageChild.Element("LlAngleToR").Value);
                                        if (LlAngleToR != string.Empty)
                                        {
                                            lblLowerLegAngleAtTakeOfRightF.Text = LlAngleToR;
                                        }

                                        var LlAngleFullFlexL = Convert.ToString(packageChild.Element("LlAngleFullFlexL").Value);
                                        if (LlAngleFullFlexL != string.Empty)
                                        {
                                            lblLowerLegFullFlexionAngleLeftF.Text = LlAngleFullFlexL;
                                        }

                                        var LlAngleFullFlexR = Convert.ToString(packageChild.Element("LlAngleFullFlexR").Value);
                                        if (LlAngleFullFlexR != string.Empty)
                                        {
                                            lblLowerLegFullFlexionAngleRightF.Text = LlAngleFullFlexR;
                                        }

                                    }
                                }
                            }
                            //}
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
        else
        {
            // Label5.Visible = true;
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
    protected void lblAirTimeLeftToRightF_TextChanged(object sender, EventArgs e)
    {

    }

}
public class MissingVariable
{
    public string type { get; set; }
    public string variableName { get; set; }
}
public class FilePathClassa
{
    public int Index { get; set; }

    public string FilePath { get; set; }
}