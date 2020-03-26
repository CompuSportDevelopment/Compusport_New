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

public partial class TrackData_HurdleAthleteEdit : System.Web.UI.UserControl
{
    int x;
    compusport.Entities.HurdleInitialData hid = new compusport.Entities.HurdleInitialData();
    compusport.Entities.HurdleModelData hmd = new compusport.Entities.HurdleModelData();
    compusport.Entities.HurdleCurrentData hcd = new compusport.Entities.HurdleCurrentData();

    public Customer customerid;
    public Customer cust;
    public CustomerProfile customerprofile;
    public CustomerProfile customerprofile1;
    TList<Customer> customer = new TList<Customer>();
    TList<Lesson> lessonlist = new TList<Lesson>();
    Movie movieSide;
    Movie CurrentMovieSide;
    Movie CurrentMovieBack;
    SummaryMovie summaryMovie;
    string location;
    int lessonid;
    int _lessonid;
    int summarysessionlessionid = 0;
    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    CompuSportDAL.SprintAthleteEdit sae = new CompuSportDAL.SprintAthleteEdit();
    CompuSportDAL.HurdleData _hurdledata = new CompuSportDAL.HurdleData();
    bool isMovieClipsExist = false;
    bool isSummarySessionExist = false;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    Customer Hurdlecustomer;


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
        btnDeleteSummaryMovie.Enabled = false;

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

    void sendNotFoundEmail(int initialcnt, int modelCnt, int CurrentCnt)
    {
        var _initialMessage = "This initial variable has 0 values = ";
        var _modelMessage = "This model variable has 0 values = ";
        var _currentMessage = "This current variable has 0 values = ";
        var message = "";
        var dataMising = false;
        for (int i = 0; i < missingVariable.Count; i++)
        {
            if (missingVariable[i].type == "initial" && initialcnt < 27)
            {
                dataMising = true;
                _initialMessage += missingVariable[i].variableName + ", ";
            }
            if (missingVariable[i].type == "model" && modelCnt < 27)
            {
                dataMising = true;
                _modelMessage += missingVariable[i].variableName + ", ";
            }
            if (missingVariable[i].type == "current" && CurrentCnt < 27)
            {
                dataMising = true;
                _currentMessage += missingVariable[i].variableName + ", ";
            }
        }
        if (dataMising == true)
        {
            var lessiodatelocaon = (DropDownList2.SelectedItem.Text);
            message = "Session Details :- " + "Hurdle" + " " + "->" + " " + lessiodatelocaon + "\n" + _initialMessage + "\n" + _modelMessage + "\n" + _currentMessage;
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
    private void DataClear()
    {
        #region[DataClear]

        lblGroundTimeIntoM1.Text = "";
        lblGroundTimeOffM1.Text = "";
        lblAirTimeM1.Text = "";
        lblStrideLengthIntoM1.Text = "";
        lblStrideLengthOffM1.Text = "";
        lblStrideLengthTotalM1.Text = "";
        lblVelocityHurdleM1.Text = "";
        lblTouchdownDistanceIntoM1.Text = "";
        lblTouchdownDistanceOffM1.Text = "";
        lblKneeSeperationTouchDownIntoM1.Text = "";
        lblKneeSeperationTouchDownOffM1.Text = "";
        lblTrunkTouchDownAngleIntoM1.Text = "";
        lblTrunkTakeoffAngleIntoM1.Text = "";
        lblTrunkMinimumAngleOverM1.Text = "";
        lblTrunkTouchDownAngleOffM1.Text = "";
        lblTrunkTakeoffAngleOffM1.Text = "";


        lblUpperLegAngleatTouchdownIntoM1.Text = "";
        lblUpperLegAngleatTakeoffIntoM1.Text = "";
        lblLeadUpperLegMaximumAngleOverM1.Text = "";
        lblUpperLegAngleatTouchdownOffM1.Text = "";
        lblUpperLegAngleatTakeoffOffM1.Text = "";
        lblKneeAnkleMinimumSeparationOverM1.Text = "";


        lblLeadLowerLegMinimumAngleIntoM1.Text = "";
        lblLeadLowerLegAngleatAnkleCrossIntoM1.Text = "";
        lblLeadLowerLegMaximumAngleOverM1.Text = "";
        lblLowerLegAngleatTouchdownOffM1.Text = "";
        lblLowerLegAngleatTakeoffOffM1.Text = "";


        #endregion[DataClear]
    }

    private void ClearData()
    {
        #region[clear Data]
        lblGroundTimeIntoI.Text = "";
        lblGroundTimeOffI.Text = "";
        lblAirTimeI.Text = "";
        lblStrideLengthIntoI.Text = "";
        lblStrideLengthOffI.Text = "";
        lblStrideLengthTotalI.Text = "";
        lblVelocityI.Text = "";
        lblTouchdownDistanceIntoI.Text = "";
        lblTouchdownDistanceOffI.Text = "";
        lblKneeSeperationTouchDownIntoI.Text = "";
        lblKneeSeperationTouchDownOffI.Text = "";
        lblTrunkTouchDownAngleIntoI.Text = "";
        lblTrunkTakeoffAngleIntoI.Text = "";
        lblTrunkMinimumAngleOverI.Text = "";
        lblTrunkTouchDownAngleOffI.Text = "";
        lblTrunkTakeoffAngleOffI.Text = "";

        lblUpperLegAngleatTouchdownIntoI.Text = "";
        lblUpperLegAngleatTakeoffIntoI.Text = "";
        lblLeadUpperLegMaximumAngleOverI.Text = "";

        lblUpperLegAngleatTouchdownOffI.Text = "";
        lblUpperLegAngleatTakeoffOffI.Text = "";
        lblKneeAnkleMinimumSeparationOverI.Text = "";

        lblLeadLowerLegMinimumAngleIntoI.Text = "";
        lblLeadLowerLegAngleatAnkleCrossIntoI.Text = "";
        lblLeadLowerLegMaximumAngleOverI.Text = "";
        lblLowerLegAngleatTouchdownOffI.Text = "";
        lblLowerLegAngleatTakeoffOffI.Text = "";


        lblGroundTimeIntoF.Text = "";
        lblGroundTimeOffF.Text = "";
        lblAirTimeF.Text = "";
        lblStrideLengthIntoF.Text = "";
        lblStrideLengthOffF.Text = "";
        lblStrideLengthTotalF.Text = "";
        lblVelocityHurdleF.Text = "";
        lblTouchdownDistanceIntoF.Text = "";
        lblTouchdownDistanceOffF.Text = "";
        lblKneeSeperationTouchDownIntoF.Text = "";
        lblKneeSeperationTouchDownOffF.Text = "";
        lblTrunkTouchDownAngleIntoF.Text = "";
        lblTrunkTakeoffAngleIntoF.Text = "";
        lblTrunkMinimumAngleOverF.Text = "";
        lblTrunkTouchDownAngleOffF.Text = "";
        lblTrunkTakeoffAngleOffF.Text = "";

        lblUpperLegAngleatTouchdownIntoF.Text = "";
        lblUpperLegAngleatTakeoffIntoF.Text = "";
        lblLeadUpperLegMaximumAngleOverF.Text = "";
        lblUpperLegAngleatTouchdownOffF.Text = "";
        lblUpperLegAngleatTakeoffOffF.Text = "";
        lblKneeAnkleMinimumSeparationOverF.Text = "";

        lblLeadLowerLegMinimumAngleIntoF.Text = "";
        lblLeadLowerLegAngleatAnkleCrossIntoF.Text = "";
        lblLeadLowerLegMaximumAngleOverF.Text = "";
        lblLowerLegAngleatTouchdownOffF.Text = "";
        lblLowerLegAngleatTakeoffOffF.Text = "";

        lblLeadLowerLegMinimumAngleIntoF.Text = "";
        lblLowerLegAngleatTakeoffOffF.Text="";

        Label117.Text = "";
        #endregion
    }
    private void clearAllData()
    {

        lblGroundTimeOffI.Text = "";
        lblAirTimeI.Text = "";
        lblStrideLengthIntoI.Text = "";
        lblStrideLengthOffI.Text = "";
        lblStrideLengthTotalI.Text = "";
        lblVelocityI.Text = "";
        lblTouchdownDistanceIntoI.Text = "";
        lblTouchdownDistanceOffI.Text = "";
        lblKneeSeperationTouchDownIntoI.Text = "";
        lblKneeSeperationTouchDownOffI.Text = "";
        lblTrunkTouchDownAngleIntoI.Text = "";
        lblTrunkTakeoffAngleIntoI.Text = "";
        lblTrunkMinimumAngleOverI.Text = "";
        lblTrunkTouchDownAngleOffI.Text = "";
        lblTrunkTakeoffAngleOffI.Text = "";

        lblUpperLegAngleatTouchdownIntoI.Text = "";
        lblUpperLegAngleatTakeoffIntoI.Text = "";
        lblLeadUpperLegMaximumAngleOverI.Text = "";

        lblUpperLegAngleatTouchdownOffI.Text = "";
        lblUpperLegAngleatTakeoffOffI.Text = "";
        lblKneeAnkleMinimumSeparationOverI.Text = "";

        lblLeadLowerLegMinimumAngleIntoI.Text = "";
        lblLeadLowerLegAngleatAnkleCrossIntoI.Text = "";
        lblLeadLowerLegMaximumAngleOverI.Text = "";
        lblLowerLegAngleatTouchdownOffI.Text = "";
        lblLowerLegAngleatTakeoffOffI.Text = "";


        lblGroundTimeIntoM1.Text = "";
        lblGroundTimeOffM1.Text = "";
        lblAirTimeM1.Text = "";
        lblStrideLengthIntoM1.Text = "";
        lblStrideLengthOffM1.Text = "";
        lblStrideLengthTotalM1.Text = "";
        lblVelocityHurdleM1.Text = "";
        lblTouchdownDistanceIntoM1.Text = "";
        lblTouchdownDistanceOffM1.Text = "";
        lblKneeSeperationTouchDownIntoM1.Text = "";
        lblKneeSeperationTouchDownOffM1.Text = "";
        lblTrunkTouchDownAngleIntoM1.Text = "";
        lblTrunkTakeoffAngleIntoM1.Text = "";
        lblTrunkMinimumAngleOverM1.Text = "";
        lblTrunkTouchDownAngleOffM1.Text = "";
        lblTrunkTakeoffAngleOffM1.Text = "";


        lblUpperLegAngleatTouchdownIntoM1.Text = "";
        lblUpperLegAngleatTakeoffIntoM1.Text = "";
        lblLeadUpperLegMaximumAngleOverM1.Text = "";
        lblUpperLegAngleatTouchdownOffM1.Text = "";
        lblUpperLegAngleatTakeoffOffM1.Text = "";
        lblKneeAnkleMinimumSeparationOverM1.Text = "";


        lblLeadLowerLegMinimumAngleIntoM1.Text = "";
        lblLeadLowerLegAngleatAnkleCrossIntoM1.Text = "";
        lblLeadLowerLegMaximumAngleOverM1.Text = "";
        lblLowerLegAngleatTouchdownOffM1.Text = "";
        lblLowerLegAngleatTakeoffOffM1.Text = "";



        lblGroundTimeIntoF.Text = "";
        lblGroundTimeOffF.Text = "";
        lblAirTimeF.Text = "";
        lblStrideLengthIntoF.Text = "";
        lblStrideLengthOffF.Text = "";
        lblStrideLengthTotalF.Text = "";
        lblVelocityHurdleF.Text = "";
        lblTouchdownDistanceIntoF.Text = "";
        lblTouchdownDistanceOffF.Text = "";
        lblKneeSeperationTouchDownIntoF.Text = "";
        lblKneeSeperationTouchDownOffF.Text = "";
        lblTrunkTouchDownAngleIntoF.Text = "";
        lblTrunkTakeoffAngleIntoF.Text = "";
        lblTrunkMinimumAngleOverF.Text = "";
        lblTrunkTouchDownAngleOffF.Text = "";
        lblTrunkTakeoffAngleOffF.Text = "";

        lblUpperLegAngleatTouchdownIntoF.Text = "";
        lblUpperLegAngleatTakeoffIntoF.Text = "";
        lblLeadUpperLegMaximumAngleOverF.Text = "";
        lblUpperLegAngleatTouchdownOffF.Text = "";
        lblUpperLegAngleatTakeoffOffF.Text = "";
        lblKneeAnkleMinimumSeparationOverF.Text = "";

        lblLeadLowerLegMinimumAngleIntoF.Text = "";
        lblLeadLowerLegAngleatAnkleCrossIntoF.Text = "";
        lblLeadLowerLegMaximumAngleOverF.Text = "";
        lblLowerLegAngleatTouchdownOffF.Text = "";
        lblLowerLegAngleatTakeoffOffF.Text = "";

        Label117.Text = "";
    }


    public void readtext()
    {
        lblGroundTimeIntoI.ReadOnly = false;
        lblGroundTimeOffI.ReadOnly = false;
        lblAirTimeI.ReadOnly = false;
        lblStrideLengthIntoI.ReadOnly = false;
        lblStrideLengthOffI.ReadOnly = false;
        lblStrideLengthTotalI.ReadOnly = false;
        lblVelocityI.ReadOnly = false;
        lblTouchdownDistanceIntoI.ReadOnly = false;
        lblTouchdownDistanceOffI.ReadOnly = false;
        lblKneeSeperationTouchDownIntoI.ReadOnly = false;
        lblKneeSeperationTouchDownOffI.ReadOnly = false;
        lblTrunkTouchDownAngleIntoI.ReadOnly = false;
        lblTrunkTakeoffAngleIntoI.ReadOnly = false;
        lblTrunkMinimumAngleOverI.ReadOnly = false;
        lblTrunkTouchDownAngleOffI.ReadOnly = false;
        lblTrunkTakeoffAngleOffI.ReadOnly = false;

        lblUpperLegAngleatTouchdownIntoI.ReadOnly = false;
        lblUpperLegAngleatTakeoffIntoI.ReadOnly = false;
        lblLeadUpperLegMaximumAngleOverI.ReadOnly = false;

        lblUpperLegAngleatTouchdownOffI.ReadOnly = false;
        lblUpperLegAngleatTakeoffOffI.ReadOnly = false;
        lblKneeAnkleMinimumSeparationOverI.ReadOnly = false;

        lblLeadLowerLegMinimumAngleIntoI.ReadOnly = false;
        lblLeadLowerLegAngleatAnkleCrossIntoI.ReadOnly = false;
        lblLeadLowerLegMaximumAngleOverI.ReadOnly = false;
        lblLowerLegAngleatTouchdownOffI.ReadOnly = false;
        lblLowerLegAngleatTakeoffOffI.ReadOnly = false;


        lblGroundTimeIntoM1.ReadOnly = false;
        lblGroundTimeOffM1.ReadOnly = false;
        lblAirTimeM1.ReadOnly = false;
        lblStrideLengthIntoM1.ReadOnly = false;
        lblStrideLengthOffM1.ReadOnly = false;
        lblStrideLengthTotalM1.ReadOnly = false;
        lblVelocityHurdleM1.ReadOnly = false;
        lblTouchdownDistanceIntoM1.ReadOnly = false;
        lblTouchdownDistanceOffM1.ReadOnly = false;
        lblKneeSeperationTouchDownIntoM1.ReadOnly = false;
        lblKneeSeperationTouchDownOffM1.ReadOnly = false;
        lblTrunkTouchDownAngleIntoM1.ReadOnly = false;
        lblTrunkTakeoffAngleIntoM1.ReadOnly = false;
        lblTrunkMinimumAngleOverM1.ReadOnly = false;
        lblTrunkTouchDownAngleOffM1.ReadOnly = false;
        lblTrunkTakeoffAngleOffM1.ReadOnly = false;


        lblUpperLegAngleatTouchdownIntoM1.ReadOnly = false;
        lblUpperLegAngleatTakeoffIntoM1.ReadOnly = false;
        lblLeadUpperLegMaximumAngleOverM1.ReadOnly = false;
        lblUpperLegAngleatTouchdownOffM1.ReadOnly = false;
        lblUpperLegAngleatTakeoffOffM1.ReadOnly = false;
        lblKneeAnkleMinimumSeparationOverM1.ReadOnly = false;


        lblLeadLowerLegMinimumAngleIntoM1.ReadOnly = false;
        lblLeadLowerLegAngleatAnkleCrossIntoM1.ReadOnly = false;
        lblLeadLowerLegMaximumAngleOverM1.ReadOnly = false;
        lblLowerLegAngleatTouchdownOffM1.ReadOnly = false;
        lblLowerLegAngleatTakeoffOffM1.ReadOnly = false;



        lblGroundTimeIntoF.ReadOnly = false;
        lblGroundTimeOffF.ReadOnly = false;
        lblAirTimeF.ReadOnly = false;
        lblStrideLengthIntoF.ReadOnly = false;
        lblStrideLengthOffF.ReadOnly = false;
        lblStrideLengthTotalF.ReadOnly = false;
        lblVelocityHurdleF.ReadOnly = false;
        lblTouchdownDistanceIntoF.ReadOnly = false;
        lblTouchdownDistanceOffF.ReadOnly = false;
        lblKneeSeperationTouchDownIntoF.ReadOnly = false;
        lblKneeSeperationTouchDownOffF.ReadOnly = false;
        lblTrunkTouchDownAngleIntoF.ReadOnly = false;
        lblTrunkTakeoffAngleIntoF.ReadOnly = false;
        lblTrunkMinimumAngleOverF.ReadOnly = false;
        lblTrunkTouchDownAngleOffF.ReadOnly = false;
        lblTrunkTakeoffAngleOffF.ReadOnly = false;

        lblUpperLegAngleatTouchdownIntoF.ReadOnly = false;
        lblUpperLegAngleatTakeoffIntoF.ReadOnly = false;
        lblLeadUpperLegMaximumAngleOverF.ReadOnly = false;
        lblUpperLegAngleatTouchdownOffF.ReadOnly = false;
        lblUpperLegAngleatTakeoffOffF.ReadOnly = false;
        lblKneeAnkleMinimumSeparationOverF.ReadOnly = false;

        lblLeadLowerLegMinimumAngleIntoF.ReadOnly = false;
        lblLeadLowerLegAngleatAnkleCrossIntoF.ReadOnly = false;
        lblLeadLowerLegMaximumAngleOverF.ReadOnly = false;
        lblLowerLegAngleatTouchdownOffF.ReadOnly = false;
        lblLowerLegAngleatTakeoffOffF.ReadOnly = false;

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

        txtForCurrentVideo.ReadOnly = false;
        txtSumFilePath.ReadOnly = false;
        txtbFilePath.ReadOnly = false;

        btnUpload.Enabled = true;
        btnToBrowseCurrentVideo.Enabled = true;
        btnUpload2.Enabled = true;
        btnSubmit.Enabled = true;
        btnInpuFullSession.Enabled = true;
    }

    public void OntrackSessionSelect()
    {
        lblGroundTimeIntoI.ReadOnly = true;
        lblGroundTimeOffI.ReadOnly = true;
        lblAirTimeI.ReadOnly = true;
        lblStrideLengthIntoI.ReadOnly = true;
        lblStrideLengthOffI.ReadOnly = true;
        lblStrideLengthTotalI.ReadOnly = true;
        lblVelocityI.ReadOnly = true;
        lblTouchdownDistanceIntoI.ReadOnly = true;
        lblTouchdownDistanceOffI.ReadOnly = true;
        lblKneeSeperationTouchDownIntoI.ReadOnly = true;
        lblKneeSeperationTouchDownOffI.ReadOnly = true;
        lblTrunkTouchDownAngleIntoI.ReadOnly = true;
        lblTrunkTakeoffAngleIntoI.ReadOnly = true;
        lblTrunkMinimumAngleOverI.ReadOnly = true;
        lblTrunkTouchDownAngleOffI.ReadOnly = true;
        lblTrunkTakeoffAngleOffI.ReadOnly = true;

        lblUpperLegAngleatTouchdownIntoI.ReadOnly = true;
        lblUpperLegAngleatTakeoffIntoI.ReadOnly = true;
        lblLeadUpperLegMaximumAngleOverI.ReadOnly = true;

        lblUpperLegAngleatTouchdownOffI.ReadOnly = true;
        lblUpperLegAngleatTakeoffOffI.ReadOnly = true;
        lblKneeAnkleMinimumSeparationOverI.ReadOnly = true;

        lblLeadLowerLegMinimumAngleIntoI.ReadOnly = true;
        lblLeadLowerLegAngleatAnkleCrossIntoI.ReadOnly = true;
        lblLeadLowerLegMaximumAngleOverI.ReadOnly = true;
        lblLowerLegAngleatTouchdownOffI.ReadOnly = true;
        lblLowerLegAngleatTakeoffOffI.ReadOnly = true;


        lblGroundTimeIntoM1.ReadOnly = true;
        lblGroundTimeOffM1.ReadOnly = true;
        lblAirTimeM1.ReadOnly = true;
        lblStrideLengthIntoM1.ReadOnly = true;
        lblStrideLengthOffM1.ReadOnly = true;
        lblStrideLengthTotalM1.ReadOnly = true;
        lblVelocityHurdleM1.ReadOnly = true;
        lblTouchdownDistanceIntoM1.ReadOnly = true;
        lblTouchdownDistanceOffM1.ReadOnly = true;
        lblKneeSeperationTouchDownIntoM1.ReadOnly = true;
        lblKneeSeperationTouchDownOffM1.ReadOnly = true;
        lblTrunkTouchDownAngleIntoM1.ReadOnly = true;
        lblTrunkTakeoffAngleIntoM1.ReadOnly = true;
        lblTrunkMinimumAngleOverM1.ReadOnly = true;
        lblTrunkTouchDownAngleOffM1.ReadOnly = true;
        lblTrunkTakeoffAngleOffM1.ReadOnly = true;


        lblUpperLegAngleatTouchdownIntoM1.ReadOnly = true;
        lblUpperLegAngleatTakeoffIntoM1.ReadOnly = true;
        lblLeadUpperLegMaximumAngleOverM1.ReadOnly = true;
        lblUpperLegAngleatTouchdownOffM1.ReadOnly = true;
        lblUpperLegAngleatTakeoffOffM1.ReadOnly = true;
        lblKneeAnkleMinimumSeparationOverM1.ReadOnly = true;


        lblLeadLowerLegMinimumAngleIntoM1.ReadOnly = true;
        lblLeadLowerLegAngleatAnkleCrossIntoM1.ReadOnly = true;
        lblLeadLowerLegMaximumAngleOverM1.ReadOnly = true;
        lblLowerLegAngleatTouchdownOffM1.ReadOnly = true;
        lblLowerLegAngleatTakeoffOffM1.ReadOnly = true;



        lblGroundTimeIntoF.ReadOnly = true;
        lblGroundTimeOffF.ReadOnly = true;
        lblAirTimeF.ReadOnly = true;
        lblStrideLengthIntoF.ReadOnly = true;
        lblStrideLengthOffF.ReadOnly = true;
        lblStrideLengthTotalF.ReadOnly = true;
        lblVelocityHurdleF.ReadOnly = true;
        lblTouchdownDistanceIntoF.ReadOnly = true;
        lblTouchdownDistanceOffF.ReadOnly = true;
        lblKneeSeperationTouchDownIntoF.ReadOnly = true;
        lblKneeSeperationTouchDownOffF.ReadOnly = true;
        lblTrunkTouchDownAngleIntoF.ReadOnly = true;
        lblTrunkTakeoffAngleIntoF.ReadOnly = true;
        lblTrunkMinimumAngleOverF.ReadOnly = true;
        lblTrunkTouchDownAngleOffF.ReadOnly = true;
        lblTrunkTakeoffAngleOffF.ReadOnly = true;

        lblUpperLegAngleatTouchdownIntoF.ReadOnly = true;
        lblUpperLegAngleatTakeoffIntoF.ReadOnly = true;
        lblLeadUpperLegMaximumAngleOverF.ReadOnly = true;
        lblUpperLegAngleatTouchdownOffF.ReadOnly = true;
        lblUpperLegAngleatTakeoffOffF.ReadOnly = true;
        lblKneeAnkleMinimumSeparationOverF.ReadOnly = true;

        lblLeadLowerLegMinimumAngleIntoF.ReadOnly = true;
        lblLeadLowerLegAngleatAnkleCrossIntoF.ReadOnly = true;
        lblLeadLowerLegMaximumAngleOverF.ReadOnly = true;
        lblLowerLegAngleatTouchdownOffF.ReadOnly = true;
        lblLowerLegAngleatTakeoffOffF.ReadOnly = true;



        txtbFilePath.ReadOnly = true;
        txtBFrame1.ReadOnly = true;
        txtBFrame2.ReadOnly = true;
        txtBFrame3.ReadOnly = true;
        txtBFrame4.ReadOnly = true;
        txtBFrame5.ReadOnly = true;
        txtBFrame6.ReadOnly = true;
        txtBFrame7.ReadOnly = true;
        txtBFrame8.ReadOnly = true;

        txtSumFilePath.ReadOnly = true;
        txtCBFrame1.ReadOnly = true;
        txtCBFrame2.ReadOnly = true;
        txtCBFrame3.ReadOnly = true;
        txtCBFrame4.ReadOnly = true;
        txtCBFrame5.ReadOnly = true;
        txtCBFrame6.ReadOnly = true;
        txtCBFrame7.ReadOnly = true;
        txtCBFrame8.ReadOnly = true;

        txtForCurrentVideo.ReadOnly = true;

        //Buttons
        btnUpload.Enabled = false;

        btnDeleteInitialMovies.Enabled = false;

        btnToBrowseCurrentVideo.Enabled = false;

        btnDeleteCurrentMovies.Enabled = false;

        btnUpload2.Enabled = false;

        btnDeleteSummaryMovie.Enabled = false;

        btnSubmit.Enabled = false;

        btnDeleteSession.Enabled = false;

        btnDeleteInitialMovies.Enabled = false;
        btnDeleteCurrentMovies.Enabled = false;
        btnInpuFullSession.Enabled = false;

        lblGroundTimeIntoM1.ReadOnly = true;
        lblGroundTimeOffM1.ReadOnly = true;
        lblAirTimeM1.ReadOnly = true;
        lblStrideLengthIntoM1.ReadOnly = true;
        lblStrideLengthOffM1.ReadOnly = true;
        lblStrideLengthTotalM1.ReadOnly = true;
        lblVelocityHurdleM1.ReadOnly = true;
        lblTouchdownDistanceIntoM1.ReadOnly = true;
        lblTouchdownDistanceOffM1.ReadOnly = true;
        lblKneeSeperationTouchDownIntoM1.ReadOnly = true;
        lblKneeSeperationTouchDownOffM1.ReadOnly = true;
        lblTrunkTouchDownAngleIntoM1.ReadOnly = true;
        lblTrunkTakeoffAngleIntoM1.ReadOnly = true;
        lblTrunkMinimumAngleOverM1.ReadOnly = true;
        lblTrunkTouchDownAngleOffM1.ReadOnly = true;
        lblTrunkTakeoffAngleOffM1.ReadOnly = true;


        lblUpperLegAngleatTouchdownIntoM1.ReadOnly = true;
        lblUpperLegAngleatTakeoffIntoM1.ReadOnly = true;
        lblLeadUpperLegMaximumAngleOverM1.ReadOnly = true;
        lblUpperLegAngleatTouchdownOffM1.ReadOnly = true;
        lblUpperLegAngleatTakeoffOffM1.ReadOnly = true;
        lblKneeAnkleMinimumSeparationOverM1.ReadOnly = true;


        lblLeadLowerLegMinimumAngleIntoM1.ReadOnly = true;
        lblLeadLowerLegAngleatAnkleCrossIntoM1.ReadOnly = true;
        lblLeadLowerLegMaximumAngleOverM1.ReadOnly = true;
        lblLowerLegAngleatTouchdownOffM1.ReadOnly = true;
        lblLowerLegAngleatTakeoffOffM1.ReadOnly = true;

    }

    public void ReadOntrackSessionSelect()
    {
        lblGroundTimeIntoI.ReadOnly = false;
        lblGroundTimeOffI.ReadOnly = false;
        lblAirTimeI.ReadOnly = false;
        lblStrideLengthIntoI.ReadOnly = false;
        lblStrideLengthOffI.ReadOnly = false;
        lblStrideLengthTotalI.ReadOnly = false;
        lblVelocityI.ReadOnly = false;
        lblTouchdownDistanceIntoI.ReadOnly = false;
        lblTouchdownDistanceOffI.ReadOnly = false;
        lblKneeSeperationTouchDownIntoI.ReadOnly = false;
        lblKneeSeperationTouchDownOffI.ReadOnly = false;
        lblTrunkTouchDownAngleIntoI.ReadOnly = false;
        lblTrunkTakeoffAngleIntoI.ReadOnly = false;
        lblTrunkMinimumAngleOverI.ReadOnly = false;
        lblTrunkTouchDownAngleOffI.ReadOnly = false;
        lblTrunkTakeoffAngleOffI.ReadOnly = false;

        lblUpperLegAngleatTouchdownIntoI.ReadOnly = false;
        lblUpperLegAngleatTakeoffIntoI.ReadOnly = false;
        lblLeadUpperLegMaximumAngleOverI.ReadOnly = false;

        lblUpperLegAngleatTouchdownOffI.ReadOnly = false;
        lblUpperLegAngleatTakeoffOffI.ReadOnly = false;
        lblKneeAnkleMinimumSeparationOverI.ReadOnly = false;

        lblLeadLowerLegMinimumAngleIntoI.ReadOnly = false;
        lblLeadLowerLegAngleatAnkleCrossIntoI.ReadOnly = false;
        lblLeadLowerLegMaximumAngleOverI.ReadOnly = false;
        lblLowerLegAngleatTouchdownOffI.ReadOnly = false;
        lblLowerLegAngleatTakeoffOffI.ReadOnly = false;


        lblGroundTimeIntoM1.ReadOnly = false;
        lblGroundTimeOffM1.ReadOnly = false;
        lblAirTimeM1.ReadOnly = false;
        lblStrideLengthIntoM1.ReadOnly = false;
        lblStrideLengthOffM1.ReadOnly = false;
        lblStrideLengthTotalM1.ReadOnly = false;
        lblVelocityHurdleM1.ReadOnly = false;
        lblTouchdownDistanceIntoM1.ReadOnly = false;
        lblTouchdownDistanceOffM1.ReadOnly = false;
        lblKneeSeperationTouchDownIntoM1.ReadOnly = false;
        lblKneeSeperationTouchDownOffM1.ReadOnly = false;
        lblTrunkTouchDownAngleIntoM1.ReadOnly = false;
        lblTrunkTakeoffAngleIntoM1.ReadOnly = false;
        lblTrunkMinimumAngleOverM1.ReadOnly = false;
        lblTrunkTouchDownAngleOffM1.ReadOnly = false;
        lblTrunkTakeoffAngleOffM1.ReadOnly = false;


        lblUpperLegAngleatTouchdownIntoM1.ReadOnly = false;
        lblUpperLegAngleatTakeoffIntoM1.ReadOnly = false;
        lblLeadUpperLegMaximumAngleOverM1.ReadOnly = false;
        lblUpperLegAngleatTouchdownOffM1.ReadOnly = false;
        lblUpperLegAngleatTakeoffOffM1.ReadOnly = false;
        lblKneeAnkleMinimumSeparationOverM1.ReadOnly = false;


        lblLeadLowerLegMinimumAngleIntoM1.ReadOnly = false;
        lblLeadLowerLegAngleatAnkleCrossIntoM1.ReadOnly = false;
        lblLeadLowerLegMaximumAngleOverM1.ReadOnly = false;
        lblLowerLegAngleatTouchdownOffM1.ReadOnly = false;
        lblLowerLegAngleatTakeoffOffM1.ReadOnly = false;



        lblGroundTimeIntoF.ReadOnly = false;
        lblGroundTimeOffF.ReadOnly = false;
        lblAirTimeF.ReadOnly = false;
        lblStrideLengthIntoF.ReadOnly = false;
        lblStrideLengthOffF.ReadOnly = false;
        lblStrideLengthTotalF.ReadOnly = false;
        lblVelocityHurdleF.ReadOnly = false;
        lblTouchdownDistanceIntoF.ReadOnly = false;
        lblTouchdownDistanceOffF.ReadOnly = false;
        lblKneeSeperationTouchDownIntoF.ReadOnly = false;
        lblKneeSeperationTouchDownOffF.ReadOnly = false;
        lblTrunkTouchDownAngleIntoF.ReadOnly = false;
        lblTrunkTakeoffAngleIntoF.ReadOnly = false;
        lblTrunkMinimumAngleOverF.ReadOnly = false;
        lblTrunkTouchDownAngleOffF.ReadOnly = false;
        lblTrunkTakeoffAngleOffF.ReadOnly = false;

        lblUpperLegAngleatTouchdownIntoF.ReadOnly = false;
        lblUpperLegAngleatTakeoffIntoF.ReadOnly = false;
        lblLeadUpperLegMaximumAngleOverF.ReadOnly = false;
        lblUpperLegAngleatTouchdownOffF.ReadOnly = false;
        lblUpperLegAngleatTakeoffOffF.ReadOnly = false;
        lblKneeAnkleMinimumSeparationOverF.ReadOnly = false;

        lblLeadLowerLegMinimumAngleIntoF.ReadOnly = false;
        lblLeadLowerLegAngleatAnkleCrossIntoF.ReadOnly = false;
        lblLeadLowerLegMaximumAngleOverF.ReadOnly = false;
        lblLowerLegAngleatTouchdownOffF.ReadOnly = false;
        lblLowerLegAngleatTakeoffOffF.ReadOnly = false;



        txtbFilePath.ReadOnly = false;
        txtBFrame1.ReadOnly = false;
        txtBFrame2.ReadOnly = false;
        txtBFrame3.ReadOnly = false;
        txtBFrame4.ReadOnly = false;
        txtBFrame5.ReadOnly = false;
        txtBFrame6.ReadOnly = false;
        txtBFrame7.ReadOnly = false;
        txtBFrame8.ReadOnly = false;

        txtSumFilePath.ReadOnly = false;
        txtCBFrame1.ReadOnly = false;
        txtCBFrame2.ReadOnly = false;
        txtCBFrame3.ReadOnly = false;
        txtCBFrame4.ReadOnly = false;
        txtCBFrame5.ReadOnly = false;
        txtCBFrame6.ReadOnly = false;
        txtCBFrame7.ReadOnly = false;
        txtCBFrame8.ReadOnly = false;

        txtForCurrentVideo.ReadOnly = false;

        //Buttons
        btnUpload.Enabled = true;

        btnDeleteInitialMovies.Enabled = true;

        btnToBrowseCurrentVideo.Enabled = true;

        btnDeleteCurrentMovies.Enabled = true;

        btnUpload2.Enabled = true;

        btnDeleteSummaryMovie.Enabled = true;

        btnSubmit.Enabled = true;

        btnDeleteSession.Enabled = true;

        btnDeleteInitialMovies.Enabled = true;
        btnDeleteCurrentMovies.Enabled = true;
        btnInpuFullSession.Enabled = true;

        lblGroundTimeIntoM1.ReadOnly = false;
        lblGroundTimeOffM1.ReadOnly = false;
        lblAirTimeM1.ReadOnly = false;
        lblStrideLengthIntoM1.ReadOnly = false;
        lblStrideLengthOffM1.ReadOnly = false;
        lblStrideLengthTotalM1.ReadOnly = false;
        lblVelocityHurdleM1.ReadOnly = false;
        lblTouchdownDistanceIntoM1.ReadOnly = false;
        lblTouchdownDistanceOffM1.ReadOnly = false;
        lblKneeSeperationTouchDownIntoM1.ReadOnly = false;
        lblKneeSeperationTouchDownOffM1.ReadOnly = false;
        lblTrunkTouchDownAngleIntoM1.ReadOnly = false;
        lblTrunkTakeoffAngleIntoM1.ReadOnly = false;
        lblTrunkMinimumAngleOverM1.ReadOnly = false;
        lblTrunkTouchDownAngleOffM1.ReadOnly = false;
        lblTrunkTakeoffAngleOffM1.ReadOnly = false;


        lblUpperLegAngleatTouchdownIntoM1.ReadOnly = false;
        lblUpperLegAngleatTakeoffIntoM1.ReadOnly = false;
        lblLeadUpperLegMaximumAngleOverM1.ReadOnly = false;
        lblUpperLegAngleatTouchdownOffM1.ReadOnly = false;
        lblUpperLegAngleatTakeoffOffM1.ReadOnly = false;
        lblKneeAnkleMinimumSeparationOverM1.ReadOnly = false;


        lblLeadLowerLegMinimumAngleIntoM1.ReadOnly = false;
        lblLeadLowerLegAngleatAnkleCrossIntoM1.ReadOnly = false;
        lblLeadLowerLegMaximumAngleOverM1.ReadOnly = false;
        lblLowerLegAngleatTouchdownOffM1.ReadOnly = false;
        lblLowerLegAngleatTakeoffOffM1.ReadOnly = false;

    }

    //private void LoadExistingLocation()
    //{
    //    int AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
    //    lessonlist = DataRepository.LessonProvider.GetByCustomerId(AthleteSelected);

    //    if (lessonlist.Count != 0)
    //    {
    //        int athleteSelected;
    //        athleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
    //        HurdlePageOnTrackSession onTrackSession = new HurdlePageOnTrackSession();
    //        onTrackSession.HurdlePageOnTrackSessionData(athleteSelected);

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

    //            if (lesson.LessonTypeId.Equals(3))
    //            {
    //                x++;
    //                DropDownList2.Items.Add(lesson.LessonDate.ToString("MM/dd/yyyy") + " - " + location);
    //                DropDownList2.Items[x].Value = lesson.LessonId.ToString();
    //            }
    //        }
    //    }
    //    else
    //    {
    //        //Label2.Visible = true;
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
            HurdlePageOnTrackSession onTrackSession = new HurdlePageOnTrackSession();
            onTrackSession.HurdlePageOnTrackSessionData(athleteSelected);
            string expression = "LessonTypeID = 3";
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
                        #region[model Data]
                        lblGroundTimeIntoM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["GroundTimeInto"]);
                        if (lblGroundTimeIntoM1.Text == "" || lblGroundTimeIntoM1.Text == "0.000")
                        {
                            lblGroundTimeIntoM1.Text = "";
                        }
                        lblGroundTimeOffM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["GroundTimeOff"]);
                        if (lblGroundTimeOffM1.Text == "" || lblGroundTimeOffM1.Text == "0.000")
                        {
                            lblGroundTimeOffM1.Text = "";
                        }
                        lblAirTimeM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["AirTimeOver"]);
                        if (lblAirTimeM1.Text == "" || lblAirTimeM1.Text == "0.000")
                        {
                            lblAirTimeM1.Text = "";
                        }
                        lblStrideLengthIntoM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["StrideLengthInto"]);
                        if (lblStrideLengthIntoM1.Text == "" || lblStrideLengthIntoM1.Text == "0.00")
                        {
                            lblStrideLengthIntoM1.Text = "";
                        }
                        lblStrideLengthOffM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["StrideLengthOff"]);
                        if (lblStrideLengthOffM1.Text == "" || lblStrideLengthOffM1.Text == "0.00")
                        {
                            lblStrideLengthOffM1.Text = "";
                        }
                        lblStrideLengthTotalM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["StrideLengthTotal"]);
                        if (lblStrideLengthTotalM1.Text == "" || lblStrideLengthTotalM1.Text == "0.00")
                        {
                            lblStrideLengthTotalM1.Text = "";
                        }
                        lblVelocityHurdleM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["Velocity"]);
                        if (lblVelocityHurdleM1.Text == "" || lblVelocityHurdleM1.Text == "0.00")
                        {
                            lblVelocityHurdleM1.Text = "";
                        }
                        lblTouchdownDistanceIntoM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["COGDistanceInto"]);
                        if (lblTouchdownDistanceIntoM1.Text == "" || lblTouchdownDistanceIntoM1.Text == "0.00")
                        {
                            lblTouchdownDistanceIntoM1.Text = "";
                        }
                        lblTouchdownDistanceOffM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["COGDistanceOff"]);
                        if (lblTouchdownDistanceOffM1.Text == "" || lblTouchdownDistanceOffM1.Text == "0.00")
                        {
                            lblTouchdownDistanceOffM1.Text = "";
                        }
                        lblKneeSeperationTouchDownIntoM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["KSTouchDownInto"]);
                        if (lblKneeSeperationTouchDownIntoM1.Text == "" || lblKneeSeperationTouchDownIntoM1.Text == "0.00")
                        {
                            lblKneeSeperationTouchDownIntoM1.Text = "";
                        }
                        lblKneeSeperationTouchDownOffM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["KSTouchDownOff"]);
                        if (lblKneeSeperationTouchDownOffM1.Text == "" || lblKneeSeperationTouchDownOffM1.Text == "0.00")
                        {
                            lblKneeSeperationTouchDownOffM1.Text = "";
                        }

                        lblTrunkTouchDownAngleIntoM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["TTDAngleInto"]);
                        if (lblTrunkTouchDownAngleIntoM1.Text == "" || lblTrunkTouchDownAngleIntoM1.Text == "0.00")
                        {
                            lblTrunkTouchDownAngleIntoM1.Text = "";
                        }
                        lblTrunkTakeoffAngleIntoM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["TTAngleInto"]);
                        if (lblTrunkTakeoffAngleIntoM1.Text == "" || lblTrunkTakeoffAngleIntoM1.Text == "0.00")
                        {
                            lblTrunkTakeoffAngleIntoM1.Text = "";
                        }
                        lblTrunkMinimumAngleOverM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["TMAngleOver"]);
                        if (lblTrunkMinimumAngleOverM1.Text == "" || lblTrunkMinimumAngleOverM1.Text == "0.00")
                        {
                            lblTrunkMinimumAngleOverM1.Text = "";
                        }
                        lblTrunkTouchDownAngleOffM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["TTDAngleOff"]);
                        if (lblTrunkTouchDownAngleOffM1.Text == "" || lblTrunkTouchDownAngleOffM1.Text == "0.00")
                        {
                            lblTrunkTouchDownAngleOffM1.Text = "";
                        }
                        lblTrunkTakeoffAngleOffM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["TTAngleOff"]);
                        if (lblTrunkTakeoffAngleOffM1.Text == "" || lblTrunkTakeoffAngleOffM1.Text == "0.00")
                        {
                            lblTrunkTakeoffAngleOffM1.Text = "";
                        }


                        lblUpperLegAngleatTouchdownIntoM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["ULAngleTDInto"]);
                        if (lblUpperLegAngleatTouchdownIntoM1.Text == "" || lblUpperLegAngleatTouchdownIntoM1.Text == "0.00")
                        {
                            lblUpperLegAngleatTouchdownIntoM1.Text = "";
                        }
                        lblUpperLegAngleatTakeoffIntoM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["ULAngleTOInto"]);
                        if (lblUpperLegAngleatTakeoffIntoM1.Text == "" || lblUpperLegAngleatTakeoffIntoM1.Text == "0.00")
                        {
                            lblUpperLegAngleatTakeoffIntoM1.Text = "";
                        }


                        lblLeadUpperLegMaximumAngleOverM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["ULMAngleOver"]);
                        if (lblLeadUpperLegMaximumAngleOverM1.Text == "" || lblLeadUpperLegMaximumAngleOverM1.Text == "0.00")
                        {
                            lblLeadUpperLegMaximumAngleOverM1.Text = "";
                        }



                        lblUpperLegAngleatTouchdownOffM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["ULAngleTDOff"]);
                        if (lblUpperLegAngleatTouchdownOffM1.Text == "" || lblUpperLegAngleatTouchdownOffM1.Text == "0.00")
                        {
                            lblUpperLegAngleatTouchdownOffM1.Text = "";
                        }
                        lblUpperLegAngleatTakeoffOffM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["ULAngleTOOff"]);
                        if (lblUpperLegAngleatTakeoffOffM1.Text == "" || lblUpperLegAngleatTakeoffOffM1.Text == "0.00")
                        {
                            lblUpperLegAngleatTakeoffOffM1.Text = "";
                        }

                        lblKneeAnkleMinimumSeparationOverM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["KAMSeparationOver"]);
                        if (lblKneeAnkleMinimumSeparationOverM1.Text == "" || lblKneeAnkleMinimumSeparationOverM1.Text == "0.00")
                        {
                            lblKneeAnkleMinimumSeparationOverM1.Text = "";
                        }


                        lblLeadLowerLegMinimumAngleIntoM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["LeadLegMinimumAngle"]);
                        if (lblLeadLowerLegMinimumAngleIntoM1.Text == "" || lblLeadLowerLegMinimumAngleIntoM1.Text == "0.00")
                        {
                            lblLeadLowerLegMinimumAngleIntoM1.Text = "";
                        }
                        lblLeadLowerLegAngleatAnkleCrossIntoM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["LeadLegAngleAC"]);
                        if (lblLeadLowerLegAngleatAnkleCrossIntoM1.Text == "" || lblLeadLowerLegAngleatAnkleCrossIntoM1.Text == "0.00")
                        {
                            lblLeadLowerLegAngleatAnkleCrossIntoM1.Text = "";
                        }

                        lblLeadLowerLegMaximumAngleOverM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["LLMAngleOver"]);
                        if (lblLeadLowerLegMaximumAngleOverM1.Text == "" || lblLeadLowerLegMaximumAngleOverM1.Text == "0.00")
                        {
                            lblLeadLowerLegMaximumAngleOverM1.Text = "";
                        }

                        lblLowerLegAngleatTouchdownOffM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["LLAngleTDOff"]);
                        if (lblLowerLegAngleatTouchdownOffM1.Text == "" || lblLowerLegAngleatTouchdownOffM1.Text == "0.00")
                        {
                            lblLowerLegAngleatTouchdownOffM1.Text = "";
                        }
                        lblLowerLegAngleatTakeoffOffM1.Text = Convert.ToString(dsModelData.Tables[1].Rows[0]["LLAngleTOOff"]);
                        if (lblLowerLegAngleatTakeoffOffM1.Text == "" || lblLowerLegAngleatTakeoffOffM1.Text == "0.00")
                        {
                            lblLowerLegAngleatTakeoffOffM1.Text = "";
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
    public void GetAllHurdleAthleteDataInitialNdCorrent(int lessonid)
    {
        ds = sae.GetAllHurdleAthleteData(lessonid);
        try
        {
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow drVariable = ds.Tables[0].Rows[0];
                        #region[Initial Data]
                        lblGroundTimeIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["GroundTimeInto"].ToString());
                        if (lblGroundTimeIntoI.Text == "" || lblGroundTimeIntoI.Text == "0.000" || lblGroundTimeIntoI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblGroundTimeIntoI.Text = "";
                            misv.variableName = "GroundTimeInto";
                            missingVariable.Add(misv);

                        }
                        lblGroundTimeOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["GroundTimeOff"]);
                        if (lblGroundTimeOffI.Text == "" || lblGroundTimeOffI.Text == "0.000" || lblGroundTimeOffI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblGroundTimeOffI.Text = "";
                            misv.variableName = "GroundTimeOff";
                            missingVariable.Add(misv);

                        }
                        lblAirTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["AirTimeOver"]);
                        if (lblAirTimeI.Text == "" || lblAirTimeI.Text == "0.000" || lblAirTimeI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblAirTimeI.Text = "";
                            misv.variableName = "AirTimeOver";
                            missingVariable.Add(misv);

                        }
                        lblStrideLengthIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["StrideLengthInto"]);
                        if (lblStrideLengthIntoI.Text == "" || lblStrideLengthIntoI.Text == "0.000" || lblStrideLengthIntoI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblStrideLengthIntoI.Text = "";
                            misv.variableName = "StrideLengthInto";
                            missingVariable.Add(misv);

                        }
                        lblStrideLengthOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["StrideLengthOff"]);
                        if (lblStrideLengthOffI.Text == "" || lblStrideLengthOffI.Text == "0.000" || lblStrideLengthOffI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblStrideLengthOffI.Text = "";
                            misv.variableName = "StrideLengthOff";
                            missingVariable.Add(misv);

                        }
                        lblStrideLengthTotalI.Text = Convert.ToString(ds.Tables[0].Rows[0]["StrideLengthTotal"]);
                        if (lblStrideLengthTotalI.Text == "" || lblStrideLengthTotalI.Text == "0.000" || lblStrideLengthTotalI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblStrideLengthTotalI.Text = "";
                            misv.variableName = "StrideLengthTotal";
                            missingVariable.Add(misv);

                        }
                        lblVelocityI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Velocity"]);
                        if (lblVelocityI.Text == "" || lblVelocityI.Text == "0.000" || lblVelocityI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblVelocityI.Text = "";
                            misv.variableName = "Velocity";
                            missingVariable.Add(misv);

                        }
                        lblTouchdownDistanceIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["COGDistanceInto"]);
                        if (lblTouchdownDistanceIntoI.Text == "" || lblTouchdownDistanceIntoI.Text == "0.000" || lblTouchdownDistanceIntoI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblTouchdownDistanceIntoI.Text = "";
                            misv.variableName = "COGDistanceInto";
                            missingVariable.Add(misv);

                        }

                        lblTouchdownDistanceOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["COGDistanceOff"]);
                        if (lblTouchdownDistanceOffI.Text == "" || lblTouchdownDistanceOffI.Text == "0.000" || lblTouchdownDistanceOffI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblTouchdownDistanceOffI.Text = "";
                            misv.variableName = "COGDistanceOff";
                            missingVariable.Add(misv);

                        }

                        lblKneeSeperationTouchDownIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["KSTouchDownInto"]);
                        if (lblKneeSeperationTouchDownIntoI.Text == "" || lblKneeSeperationTouchDownIntoI.Text == "0.000" || lblKneeSeperationTouchDownIntoI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblKneeSeperationTouchDownIntoI.Text = "";
                            misv.variableName = "KSTouchDownInto";
                            missingVariable.Add(misv);

                        }
                        lblKneeSeperationTouchDownOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["KSTouchDownOff"]);
                        if (lblKneeSeperationTouchDownOffI.Text == "" || lblKneeSeperationTouchDownOffI.Text == "0.000" || lblKneeSeperationTouchDownOffI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblKneeSeperationTouchDownOffI.Text = "";
                            misv.variableName = "KSTouchDownOff";
                            missingVariable.Add(misv);

                        }

                        lblTrunkTouchDownAngleIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TTDAngleInto"]);
                        if (lblTrunkTouchDownAngleIntoI.Text == "" || lblTrunkTouchDownAngleIntoI.Text == "0.000" || lblTrunkTouchDownAngleIntoI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblTrunkTouchDownAngleIntoI.Text = "";
                            misv.variableName = "TTDAngleInto";
                            missingVariable.Add(misv);

                        }
                        lblTrunkTakeoffAngleIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TTAngleInto"]);
                        if (lblTrunkTakeoffAngleIntoI.Text == "" || lblTrunkTakeoffAngleIntoI.Text == "0.000" || lblTrunkTakeoffAngleIntoI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblTrunkTakeoffAngleIntoI.Text = "";
                            misv.variableName = "TTAngleInto";
                            missingVariable.Add(misv);

                        }
                        lblTrunkMinimumAngleOverI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TMAngleOver"]);
                        if (lblTrunkMinimumAngleOverI.Text == "" || lblTrunkMinimumAngleOverI.Text == "0.000" || lblTrunkMinimumAngleOverI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblTrunkMinimumAngleOverI.Text = "";
                            misv.variableName = "TMAngleOver";
                            missingVariable.Add(misv);

                        }
                        lblTrunkTouchDownAngleOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TTDAngleOff"]);
                        if (lblTrunkTouchDownAngleOffI.Text == "" || lblTrunkTouchDownAngleOffI.Text == "0.000" || lblTrunkTouchDownAngleOffI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblTrunkTouchDownAngleOffI.Text = "";
                            misv.variableName = "TTDAngleOff";
                            missingVariable.Add(misv);

                        }
                        lblTrunkTakeoffAngleOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TTAngleOff"]);
                        if (lblTrunkTakeoffAngleOffI.Text == "" || lblTrunkTakeoffAngleOffI.Text == "0.000" || lblTrunkTakeoffAngleOffI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblTrunkTakeoffAngleOffI.Text = "";
                            misv.variableName = "TTAngleOff";
                            missingVariable.Add(misv);

                        }

                        lblUpperLegAngleatTouchdownIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["ULAngleTDInto"]);
                        if (lblUpperLegAngleatTouchdownIntoI.Text == "" || lblUpperLegAngleatTouchdownIntoI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblUpperLegAngleatTouchdownIntoI.Text = "";
                            misv.variableName = "ULAngleTDInto";
                            missingVariable.Add(misv);

                        }
                        lblUpperLegAngleatTakeoffIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["ULAngleTOInto"]);
                        if (lblUpperLegAngleatTakeoffIntoI.Text == "" || lblUpperLegAngleatTakeoffIntoI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblUpperLegAngleatTakeoffIntoI.Text = "";
                            misv.variableName = "ULAngleTOInto";
                            missingVariable.Add(misv);

                        }

                        lblLeadUpperLegMaximumAngleOverI.Text = Convert.ToString(ds.Tables[0].Rows[0]["ULMAngleOver"]);
                        if (lblLeadUpperLegMaximumAngleOverI.Text == "" || lblLeadUpperLegMaximumAngleOverI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblLeadUpperLegMaximumAngleOverI.Text = "";
                            misv.variableName = "ULMAngleOver";
                            missingVariable.Add(misv);

                        }

                        lblUpperLegAngleatTouchdownOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["ULAngleTDOff"]);
                        if (lblUpperLegAngleatTouchdownOffI.Text == "" || lblUpperLegAngleatTouchdownOffI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblUpperLegAngleatTouchdownOffI.Text = "";
                            misv.variableName = "ULAngleTDOff";
                            missingVariable.Add(misv);

                        }
                        lblUpperLegAngleatTakeoffOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["ULAngleTOOff"]);
                        if (lblUpperLegAngleatTakeoffOffI.Text == "" || lblUpperLegAngleatTakeoffOffI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblUpperLegAngleatTakeoffOffI.Text = "";
                            misv.variableName = "ULAngleTOOff";
                            missingVariable.Add(misv);

                        }

                        lblKneeAnkleMinimumSeparationOverI.Text = Convert.ToString(ds.Tables[0].Rows[0]["KAMSeparationOver"]);
                        if (lblKneeAnkleMinimumSeparationOverI.Text == "" || lblKneeAnkleMinimumSeparationOverI.Text == "0.000" || lblKneeAnkleMinimumSeparationOverI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblKneeAnkleMinimumSeparationOverI.Text = "";
                            misv.variableName = "KAMSeparationOver";
                            missingVariable.Add(misv);

                        }

                        lblLeadLowerLegMinimumAngleIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["LeadLegMinimumAngle"]);
                        if (lblLeadLowerLegMinimumAngleIntoI.Text == "" || lblLeadLowerLegMinimumAngleIntoI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblLeadLowerLegMinimumAngleIntoI.Text = "";
                            misv.variableName = "LeadLegMinimumAngle";
                            missingVariable.Add(misv);

                        }
                        lblLeadLowerLegAngleatAnkleCrossIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["LeadLegAngleAC"]);
                        if (lblLeadLowerLegAngleatAnkleCrossIntoI.Text == "" || lblLeadLowerLegAngleatAnkleCrossIntoI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblLeadLowerLegAngleatAnkleCrossIntoI.Text = "";
                            misv.variableName = "LeadLegAngleAC";
                            missingVariable.Add(misv);

                        }

                        lblLeadLowerLegMaximumAngleOverI.Text = Convert.ToString(ds.Tables[0].Rows[0]["LLMAngleOver"]);
                        if (lblLeadLowerLegMaximumAngleOverI.Text == "" || lblLeadLowerLegMaximumAngleOverI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblLeadLowerLegMaximumAngleOverI.Text = "";
                            misv.variableName = "LLMAngleOver";
                            missingVariable.Add(misv);

                        }


                        lblLowerLegAngleatTouchdownOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["LLAngleTDOff"]);
                        if (lblLowerLegAngleatTouchdownOffI.Text == "" || lblLowerLegAngleatTouchdownOffI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblLowerLegAngleatTouchdownOffI.Text = "";
                            misv.variableName = "LLAngleTDOff";
                            missingVariable.Add(misv);

                        }
                        lblLowerLegAngleatTakeoffOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["LLAngleTOOff"]);
                        if (lblLowerLegAngleatTakeoffOffI.Text == "" || lblLowerLegAngleatTakeoffOffI.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblLowerLegAngleatTakeoffOffI.Text = "";
                            misv.variableName = "LLAngleTOOff";
                            missingVariable.Add(misv);

                        }
                        #endregion[Initial Data]
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        DataRow drVariable = ds.Tables[2].Rows[0];
                        #region[Current Data]
                        lblGroundTimeIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["GroundTimeInto"]);
                        if (lblGroundTimeIntoF.Text == "" || lblGroundTimeIntoF.Text == "0.000" || lblGroundTimeIntoF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblGroundTimeIntoF.Text = "";
                            misv.variableName = "GroundTimeInto";
                            missingVariable.Add(misv);

                        }
                        lblGroundTimeOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["GroundTimeOff"]);
                        if (lblGroundTimeOffF.Text == "" || lblGroundTimeOffF.Text == "0.000" || lblGroundTimeOffF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblGroundTimeOffF.Text = "";
                            misv.variableName = "GroundTimeOff";
                            missingVariable.Add(misv);

                        }
                        lblAirTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["AirTimeOver"]);
                        if (lblAirTimeF.Text == "" || lblAirTimeF.Text == "0.000" || lblAirTimeF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblAirTimeF.Text = "";
                            misv.variableName = "AirTimeOver";
                            missingVariable.Add(misv);

                        }
                        lblStrideLengthIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["StrideLengthInto"]);
                        if (lblStrideLengthIntoF.Text == "" || lblStrideLengthIntoF.Text == "0.000" || lblStrideLengthIntoF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblStrideLengthIntoF.Text = "";
                            misv.variableName = "StrideLengthInto";
                            missingVariable.Add(misv);

                        }
                        lblStrideLengthOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["StrideLengthOff"]);
                        if (lblStrideLengthOffF.Text == "" || lblStrideLengthOffF.Text == "0.000" || lblStrideLengthOffF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblStrideLengthOffF.Text = "";
                            misv.variableName = "StrideLengthOff";
                            missingVariable.Add(misv);

                        }
                        lblStrideLengthTotalF.Text = Convert.ToString(ds.Tables[2].Rows[0]["StrideLengthTotal"]);
                        if (lblStrideLengthTotalF.Text == "" || lblStrideLengthTotalF.Text == "0.000" || lblStrideLengthTotalF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblStrideLengthTotalF.Text = "";
                            misv.variableName = "StrideLengthTotal";
                            missingVariable.Add(misv);

                        }
                        lblVelocityHurdleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Velocity"]);
                        if (lblVelocityHurdleF.Text == "" || lblVelocityHurdleF.Text == "0.000" || lblVelocityHurdleF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblVelocityHurdleF.Text = "";
                            misv.variableName = "Velocity";
                            missingVariable.Add(misv);

                        }
                        lblTouchdownDistanceIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["COGDistanceInto"]);
                        if (lblTouchdownDistanceIntoF.Text == "" || lblTouchdownDistanceIntoF.Text == "0.000" || lblTouchdownDistanceIntoF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblTouchdownDistanceIntoF.Text = "";
                            misv.variableName = "COGDistanceInto";
                            missingVariable.Add(misv);

                        }
                        lblTouchdownDistanceOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["COGDistanceOff"]);
                        if (lblTouchdownDistanceOffF.Text == "" || lblTouchdownDistanceOffF.Text == "0.000" || lblTouchdownDistanceOffF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblTouchdownDistanceOffF.Text = "";
                            misv.variableName = "COGDistanceOff";
                            missingVariable.Add(misv);

                        }

                        lblKneeSeperationTouchDownIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["KSTouchDownInto"]);
                        if (lblKneeSeperationTouchDownIntoF.Text == "" || lblKneeSeperationTouchDownIntoF.Text == "0.000" || lblKneeSeperationTouchDownIntoF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblKneeSeperationTouchDownIntoF.Text = "";
                            misv.variableName = "KSTouchDownInto";
                            missingVariable.Add(misv);

                        }
                        lblKneeSeperationTouchDownOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["KSTouchDownOff"]);
                        if (lblKneeSeperationTouchDownOffF.Text == "" || lblKneeSeperationTouchDownOffF.Text == "0.000" || lblKneeSeperationTouchDownOffF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblKneeSeperationTouchDownOffF.Text = "";
                            misv.variableName = "KSTouchDownOff";
                            missingVariable.Add(misv);

                        }

                        lblTrunkTouchDownAngleIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TTDAngleInto"]);
                        if (lblTrunkTouchDownAngleIntoF.Text == "" || lblTrunkTouchDownAngleIntoF.Text == "0.000" || lblTrunkTouchDownAngleIntoF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblTrunkTouchDownAngleIntoF.Text = "";
                            misv.variableName = "TTDAngleInto";
                            missingVariable.Add(misv);

                        }
                        lblTrunkTakeoffAngleIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TTAngleInto"]);
                        if (lblTrunkTakeoffAngleIntoF.Text == "" || lblTrunkTakeoffAngleIntoF.Text == "0.000" || lblTrunkTakeoffAngleIntoF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblTrunkTakeoffAngleIntoF.Text = "";
                            misv.variableName = "TTAngleInto";
                            missingVariable.Add(misv);

                        }
                        lblTrunkMinimumAngleOverF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TMAngleOver"]);
                        if (lblTrunkMinimumAngleOverF.Text == "" || lblTrunkMinimumAngleOverF.Text == "0.000" || lblTrunkMinimumAngleOverF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblTrunkMinimumAngleOverF.Text = "";
                            misv.variableName = "TMAngleOver";
                            missingVariable.Add(misv);

                        }
                        lblTrunkTouchDownAngleOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TTDAngleOff"]);
                        if (lblTrunkTouchDownAngleOffF.Text == "" || lblTrunkTouchDownAngleOffF.Text == "0.000" || lblTrunkTouchDownAngleOffF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblTrunkTouchDownAngleOffF.Text = "";
                            misv.variableName = "TTDAngleOff";
                            missingVariable.Add(misv);

                        }
                        lblTrunkTakeoffAngleOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TTAngleOff"]);
                        if (lblTrunkTakeoffAngleOffF.Text == "" || lblTrunkTakeoffAngleOffF.Text == "0.000" || lblTrunkTakeoffAngleOffF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblTrunkTakeoffAngleOffF.Text = "";
                            misv.variableName = "TTAngleOff";
                            missingVariable.Add(misv);

                        }

                        lblUpperLegAngleatTouchdownIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["ULAngleTDInto"]);
                        if (lblUpperLegAngleatTouchdownIntoF.Text == "" || lblUpperLegAngleatTouchdownIntoF.Text == "0.000" || lblUpperLegAngleatTouchdownIntoF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblUpperLegAngleatTouchdownIntoF.Text = "";
                            misv.variableName = "ULAngleTDInto";
                            missingVariable.Add(misv);

                        }
                        lblUpperLegAngleatTakeoffIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["ULAngleTOInto"]);
                        if (lblUpperLegAngleatTakeoffIntoF.Text == "" || lblUpperLegAngleatTakeoffIntoF.Text == "0.000" || lblUpperLegAngleatTakeoffIntoF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblUpperLegAngleatTakeoffIntoF.Text = "";
                            misv.variableName = "ULAngleTOInto";
                            missingVariable.Add(misv);

                        }

                        lblLeadUpperLegMaximumAngleOverF.Text = Convert.ToString(ds.Tables[2].Rows[0]["ULMAngleOver"]);
                        if (lblLeadUpperLegMaximumAngleOverF.Text == "" || lblLeadUpperLegMaximumAngleOverF.Text == "0.000" || lblLeadUpperLegMaximumAngleOverF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblLeadUpperLegMaximumAngleOverF.Text = "";
                            misv.variableName = "ULMAngleOver";
                            missingVariable.Add(misv);

                        }

                        lblUpperLegAngleatTouchdownOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["ULAngleTDOff"]);
                        if (lblUpperLegAngleatTouchdownOffF.Text == "" || lblUpperLegAngleatTouchdownOffF.Text == "0.000" || lblUpperLegAngleatTouchdownOffF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblUpperLegAngleatTouchdownOffF.Text = "";
                            misv.variableName = "ULAngleTDOff";
                            missingVariable.Add(misv);

                        }
                        lblUpperLegAngleatTakeoffOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["ULAngleTOOff"]);
                        if (lblUpperLegAngleatTakeoffOffF.Text == "" || lblUpperLegAngleatTakeoffOffF.Text == "0.000" || lblUpperLegAngleatTakeoffOffF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblUpperLegAngleatTakeoffOffF.Text = "";
                            misv.variableName = "ULAngleTOOff";
                            missingVariable.Add(misv);

                        }

                        lblKneeAnkleMinimumSeparationOverF.Text = Convert.ToString(ds.Tables[2].Rows[0]["KAMSeparationOver"]);
                        if (lblKneeAnkleMinimumSeparationOverF.Text == "" || lblKneeAnkleMinimumSeparationOverF.Text == "0.000" || lblKneeAnkleMinimumSeparationOverF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblKneeAnkleMinimumSeparationOverF.Text = "";
                            misv.variableName = "KAMSeparationOver";
                            missingVariable.Add(misv);

                        }

                        lblLeadLowerLegMinimumAngleIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["LeadLegMinimumAngle"]);
                        if (lblLeadLowerLegMinimumAngleIntoF.Text == "" || lblLeadLowerLegMinimumAngleIntoF.Text == "0.000" || lblLeadLowerLegMinimumAngleIntoF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblLeadLowerLegMinimumAngleIntoF.Text = "";
                            misv.variableName = "LeadLegMinimumAngle";
                            missingVariable.Add(misv);

                        }
                        lblLeadLowerLegAngleatAnkleCrossIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["LeadLegAngleAC"]);
                        if (lblLeadLowerLegAngleatAnkleCrossIntoF.Text == "" || lblLeadLowerLegAngleatAnkleCrossIntoF.Text == "0.000" || lblLeadLowerLegAngleatAnkleCrossIntoF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblLeadLowerLegAngleatAnkleCrossIntoF.Text = "";
                            misv.variableName = "LeadLegAngleAC";
                            missingVariable.Add(misv);

                        }

                        lblLeadLowerLegMaximumAngleOverF.Text = Convert.ToString(ds.Tables[2].Rows[0]["LLMAngleOver"]);
                        if (lblLeadLowerLegMaximumAngleOverF.Text == "" || lblLeadLowerLegMaximumAngleOverF.Text == "0.000" || lblLeadLowerLegMaximumAngleOverF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblLeadLowerLegMaximumAngleOverF.Text = "";
                            misv.variableName = "LLMAngleOver";
                            missingVariable.Add(misv);

                        }

                        lblLowerLegAngleatTouchdownOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["LLAngleTDOff"]);
                        if (lblLowerLegAngleatTouchdownOffF.Text == " " || lblLowerLegAngleatTouchdownOffF.Text == "0.000" || lblLowerLegAngleatTouchdownOffF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblLowerLegAngleatTouchdownOffF.Text = "";
                            misv.variableName = "LLAngleTDOff";
                            missingVariable.Add(misv);

                        }
                        lblLowerLegAngleatTakeoffOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["LLAngleTOOff"]);
                        if (lblLowerLegAngleatTakeoffOffF.Text == "" || lblLowerLegAngleatTakeoffOffF.Text == "0.000" || lblLowerLegAngleatTakeoffOffF.Text == "0")
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblLowerLegAngleatTakeoffOffF.Text = "";
                            misv.variableName = "LLAngleTOOff";
                            missingVariable.Add(misv);

                        }
                        #endregion[Current Data]
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    public void GetAllHurdleAthleteData(int lessonid)
    {
        ds = sae.GetAllHurdleAthleteData(lessonid);
        try
        {
            if (ds != null)
            {
                int CurrentCnt = 0;
                int initialcnt = 0;
                int modelCnt = 0;

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow drVariable = ds.Tables[0].Rows[0];
                        #region[Initial Data]
                        lblGroundTimeIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["GroundTimeInto"].ToString());
                        decimal GroundTimeInto;
                        decimal.TryParse(ds.Tables[0].Rows[0]["GroundTimeInto"].ToString(), out GroundTimeInto);
                        // if (lblGroundTimeIntoI.Text == "" || lblGroundTimeIntoI.Text == "0.000" || lblGroundTimeIntoI.Text == "0")
                        if (GroundTimeInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblGroundTimeIntoI.Text = "";
                            misv.variableName = "GroundTimeInto";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        lblGroundTimeOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["GroundTimeOff"].ToString());
                        //if (lblGroundTimeOffI.Text == "" || lblGroundTimeOffI.Text == "0.000" || lblGroundTimeOffI.Text == "0")
                        decimal GroundTimeOff;
                        decimal.TryParse(ds.Tables[0].Rows[0]["GroundTimeOff"].ToString(), out GroundTimeOff);
                        if (GroundTimeOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblGroundTimeOffI.Text = "";
                            misv.variableName = "GroundTimeOff";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        lblAirTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["AirTimeOver"].ToString());
                        //if (lblAirTimeI.Text == "" || lblAirTimeI.Text == "0.000" || lblAirTimeI.Text == "0")
                        decimal AirTime;
                        decimal.TryParse(ds.Tables[0].Rows[0]["AirTimeOver"].ToString(), out AirTime);
                        if (AirTime == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblAirTimeI.Text = "";
                            misv.variableName = "AirTimeOver";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        lblStrideLengthIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["StrideLengthInto"].ToString());
                        //if (lblStrideLengthIntoI.Text == "" || lblStrideLengthIntoI.Text == "0.000" || lblStrideLengthIntoI.Text == "0")
                        decimal StrideLengthInto;
                        decimal.TryParse(ds.Tables[0].Rows[0]["StrideLengthInto"].ToString(), out StrideLengthInto);
                        if (StrideLengthInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblStrideLengthIntoI.Text = "";
                            misv.variableName = "StrideLengthInto";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        lblStrideLengthOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["StrideLengthOff"].ToString());
                        // if (lblStrideLengthOffI.Text == "" || lblStrideLengthOffI.Text == "0.000" || lblStrideLengthOffI.Text == "0")
                        decimal StrideLengthOff;
                        decimal.TryParse(ds.Tables[0].Rows[0]["StrideLengthOff"].ToString(), out StrideLengthOff);
                        if (StrideLengthOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblStrideLengthOffI.Text = "";
                            misv.variableName = "StrideLengthOff";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        lblStrideLengthTotalI.Text = Convert.ToString(ds.Tables[0].Rows[0]["StrideLengthTotal"].ToString());
                        // if (lblStrideLengthTotalI.Text == "" || lblStrideLengthTotalI.Text == "0.000" || lblStrideLengthTotalI.Text == "0")
                        decimal StrideLengthTotal;
                        decimal.TryParse(ds.Tables[0].Rows[0]["StrideLengthTotal"].ToString(), out StrideLengthTotal);
                        if (StrideLengthTotal == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblStrideLengthTotalI.Text = "";
                            misv.variableName = "StrideLengthTotal";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        lblVelocityI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Velocity"].ToString());
                        // if (lblVelocityI.Text == "" || lblVelocityI.Text == "0.000" || lblVelocityI.Text == "0")
                        decimal Velocity;
                        decimal.TryParse(ds.Tables[0].Rows[0]["Velocity"].ToString(), out Velocity);
                        if (Velocity == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblVelocityI.Text = "";
                            misv.variableName = "Velocity";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        lblTouchdownDistanceIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["COGDistanceInto"].ToString());
                        // if (lblTouchdownDistanceIntoI.Text == "" || lblTouchdownDistanceIntoI.Text == "0.000" || lblTouchdownDistanceIntoI.Text == "0")
                        decimal TouchdownDistanceInto;
                        decimal.TryParse(ds.Tables[0].Rows[0]["COGDistanceInto"].ToString(), out TouchdownDistanceInto);
                        if (TouchdownDistanceInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblTouchdownDistanceIntoI.Text = "";
                            misv.variableName = "COGDistanceInto";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }

                        lblTouchdownDistanceOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["COGDistanceOff"].ToString());
                        // if (lblTouchdownDistanceOffI.Text == "" || lblTouchdownDistanceOffI.Text == "0.000" || lblTouchdownDistanceOffI.Text == "0")
                        decimal TouchdownDistanceOff;
                        decimal.TryParse(ds.Tables[0].Rows[0]["COGDistanceOff"].ToString(), out TouchdownDistanceOff);
                        if (TouchdownDistanceOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblTouchdownDistanceOffI.Text = "";
                            misv.variableName = "COGDistanceOff";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }

                        lblKneeSeperationTouchDownIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["KSTouchDownInto"].ToString());
                        // if (lblKneeSeperationTouchDownIntoI.Text == "" || lblKneeSeperationTouchDownIntoI.Text == "0.000" || lblKneeSeperationTouchDownIntoI.Text == "0")
                        decimal KneeSeperationTouchDownInto;
                        decimal.TryParse(ds.Tables[0].Rows[0]["KSTouchDownInto"].ToString(), out KneeSeperationTouchDownInto);
                        if (KneeSeperationTouchDownInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblKneeSeperationTouchDownIntoI.Text = "";
                            misv.variableName = "KSTouchDownInto";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        lblKneeSeperationTouchDownOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["KSTouchDownOff"].ToString());
                        // if (lblKneeSeperationTouchDownOffI.Text == "" || lblKneeSeperationTouchDownOffI.Text == "0.000" || lblKneeSeperationTouchDownOffI.Text == "0")
                        decimal KneeSeperationTouchDownOff;
                        decimal.TryParse(ds.Tables[0].Rows[0]["KSTouchDownOff"].ToString(), out KneeSeperationTouchDownOff);
                        if (KneeSeperationTouchDownOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblKneeSeperationTouchDownOffI.Text = "";
                            misv.variableName = "KSTouchDownOff";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }

                        lblTrunkTouchDownAngleIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TTDAngleInto"].ToString());
                        // if (lblTrunkTouchDownAngleIntoI.Text == "" || lblTrunkTouchDownAngleIntoI.Text == "0.000" || lblTrunkTouchDownAngleIntoI.Text == "0")
                        decimal TrunkTouchDownAngleInto;
                        decimal.TryParse(ds.Tables[0].Rows[0]["TTDAngleInto"].ToString(), out TrunkTouchDownAngleInto);
                        if (TrunkTouchDownAngleInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblTrunkTouchDownAngleIntoI.Text = "";
                            misv.variableName = "TTDAngleInto";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        lblTrunkTakeoffAngleIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TTAngleInto"].ToString());
                        //if (lblTrunkTakeoffAngleIntoI.Text == "" || lblTrunkTakeoffAngleIntoI.Text == "0.000" || lblTrunkTakeoffAngleIntoI.Text == "0")
                        decimal TrunkTakeoffAngleInto;
                        decimal.TryParse(ds.Tables[0].Rows[0]["TTAngleInto"].ToString(), out TrunkTakeoffAngleInto);
                        if (TrunkTakeoffAngleInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblTrunkTakeoffAngleIntoI.Text = "";
                            misv.variableName = "TTAngleInto";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        lblTrunkMinimumAngleOverI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TMAngleOver"].ToString());
                        // if (lblTrunkMinimumAngleOverI.Text == "" || lblTrunkMinimumAngleOverI.Text == "0.000" || lblTrunkMinimumAngleOverI.Text == "0")
                        decimal TrunkMinimumAngleOver;
                        decimal.TryParse(ds.Tables[0].Rows[0]["TMAngleOver"].ToString(), out TrunkMinimumAngleOver);
                        if (TrunkMinimumAngleOver == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblTrunkMinimumAngleOverI.Text = "";
                            misv.variableName = "TMAngleOver";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        lblTrunkTouchDownAngleOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TTDAngleOff"].ToString());
                        // if (lblTrunkTouchDownAngleOffI.Text == "" || lblTrunkTouchDownAngleOffI.Text == "0.000" || lblTrunkTouchDownAngleOffI.Text == "0")
                        decimal TrunkTouchDownAngleOff;
                        decimal.TryParse(ds.Tables[0].Rows[0]["TTDAngleOff"].ToString(), out TrunkTouchDownAngleOff);
                        if (TrunkTouchDownAngleOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblTrunkTouchDownAngleOffI.Text = "";
                            misv.variableName = "TTDAngleOff";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        lblTrunkTakeoffAngleOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TTAngleOff"].ToString());
                        //  if (lblTrunkTakeoffAngleOffI.Text == "" || lblTrunkTakeoffAngleOffI.Text == "0.000" || lblTrunkTakeoffAngleOffI.Text == "0")
                        decimal TrunkTakeoffAngleOff;
                        decimal.TryParse(ds.Tables[0].Rows[0]["TTAngleOff"].ToString(), out TrunkTakeoffAngleOff);
                        if (TrunkTakeoffAngleOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblTrunkTakeoffAngleOffI.Text = "";
                            misv.variableName = "TTAngleOff";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }

                        lblUpperLegAngleatTouchdownIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["ULAngleTDInto"].ToString());
                        // if (lblUpperLegAngleatTouchdownIntoI.Text == "" || lblUpperLegAngleatTouchdownIntoI.Text == "0")
                        decimal UpperLegAngleatTouchdownInto;
                        decimal.TryParse(ds.Tables[0].Rows[0]["ULAngleTDInto"].ToString(), out UpperLegAngleatTouchdownInto);
                        if (UpperLegAngleatTouchdownInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblUpperLegAngleatTouchdownIntoI.Text = "";
                            misv.variableName = "ULAngleTDInto";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        lblUpperLegAngleatTakeoffIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["ULAngleTOInto"].ToString());
                        //if (lblUpperLegAngleatTakeoffIntoI.Text == "" || lblUpperLegAngleatTakeoffIntoI.Text == "0")
                        decimal UpperLegAngleatTakeoffInto;
                        decimal.TryParse(ds.Tables[0].Rows[0]["ULAngleTOInto"].ToString(), out UpperLegAngleatTakeoffInto);
                        if (UpperLegAngleatTakeoffInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblUpperLegAngleatTakeoffIntoI.Text = "";
                            misv.variableName = "ULAngleTOInto";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }

                        lblLeadUpperLegMaximumAngleOverI.Text = Convert.ToString(ds.Tables[0].Rows[0]["ULMAngleOver"].ToString());
                        //if (lblLeadUpperLegMaximumAngleOverI.Text == "" || lblLeadUpperLegMaximumAngleOverI.Text == "0")
                        decimal LeadUpperLegMaximumAngleOver;
                        decimal.TryParse(ds.Tables[0].Rows[0]["ULMAngleOver"].ToString(), out LeadUpperLegMaximumAngleOver);
                        if (LeadUpperLegMaximumAngleOver == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblLeadUpperLegMaximumAngleOverI.Text = "";
                            misv.variableName = "ULMAngleOver";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }

                        lblUpperLegAngleatTouchdownOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["ULAngleTDOff"].ToString());
                        // if (lblUpperLegAngleatTouchdownOffI.Text == "" || lblUpperLegAngleatTouchdownOffI.Text == "0")
                        decimal UpperLegAngleatTouchdownOff;
                        decimal.TryParse(ds.Tables[0].Rows[0]["ULAngleTDOff"].ToString(), out UpperLegAngleatTouchdownOff);
                        if (UpperLegAngleatTouchdownOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblUpperLegAngleatTouchdownOffI.Text = "";
                            misv.variableName = "ULAngleTDOff";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        lblUpperLegAngleatTakeoffOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["ULAngleTOOff"].ToString());
                        //if (lblUpperLegAngleatTakeoffOffI.Text == "" || lblUpperLegAngleatTakeoffOffI.Text == "0")
                        decimal UpperLegAngleatTakeoffOff;
                        decimal.TryParse(ds.Tables[0].Rows[0]["ULAngleTOOff"].ToString(), out UpperLegAngleatTakeoffOff);
                        if (UpperLegAngleatTakeoffOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblUpperLegAngleatTakeoffOffI.Text = "";
                            misv.variableName = "ULAngleTOOff";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }

                        lblKneeAnkleMinimumSeparationOverI.Text = Convert.ToString(ds.Tables[0].Rows[0]["KAMSeparationOver"].ToString());
                        // if (lblKneeAnkleMinimumSeparationOverI.Text == "" || lblKneeAnkleMinimumSeparationOverI.Text == "0.000" || lblKneeAnkleMinimumSeparationOverI.Text == "0")
                        decimal KneeAnkleMinimumSeparationOver;
                        decimal.TryParse(ds.Tables[0].Rows[0]["KAMSeparationOver"].ToString(), out KneeAnkleMinimumSeparationOver);
                        if (KneeAnkleMinimumSeparationOver == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblKneeAnkleMinimumSeparationOverI.Text = "";
                            misv.variableName = "KAMSeparationOver";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }

                        lblLeadLowerLegMinimumAngleIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["LeadLegMinimumAngle"].ToString());
                        // if (lblLeadLowerLegMinimumAngleIntoI.Text == "" || lblLeadLowerLegMinimumAngleIntoI.Text == "0")
                        decimal LeadLowerLegMinimumAngleInto;
                        decimal.TryParse(ds.Tables[0].Rows[0]["LeadLegMinimumAngle"].ToString(), out LeadLowerLegMinimumAngleInto);
                        if (LeadLowerLegMinimumAngleInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblLeadLowerLegMinimumAngleIntoI.Text = "";
                            misv.variableName = "LeadLegMinimumAngle";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        lblLeadLowerLegAngleatAnkleCrossIntoI.Text = Convert.ToString(ds.Tables[0].Rows[0]["LeadLegAngleAC"].ToString());
                        // if (lblLeadLowerLegAngleatAnkleCrossIntoI.Text == "" || lblLeadLowerLegAngleatAnkleCrossIntoI.Text == "0")
                        decimal LeadLowerLegAngleatAnkleCrossInto;
                        decimal.TryParse(ds.Tables[0].Rows[0]["LeadLegAngleAC"].ToString(), out LeadLowerLegAngleatAnkleCrossInto);
                        if (LeadLowerLegAngleatAnkleCrossInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblLeadLowerLegAngleatAnkleCrossIntoI.Text = "";
                            misv.variableName = "LeadLegAngleAC";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }

                        lblLeadLowerLegMaximumAngleOverI.Text = Convert.ToString(ds.Tables[0].Rows[0]["LLMAngleOver"].ToString());
                        //if (lblLeadLowerLegMaximumAngleOverI.Text == "" || lblLeadLowerLegMaximumAngleOverI.Text == "0")
                        decimal LeadLowerLegMaximumAngleOver;
                        decimal.TryParse(ds.Tables[0].Rows[0]["LLMAngleOver"].ToString(), out LeadLowerLegMaximumAngleOver);
                        if (LeadLowerLegMaximumAngleOver == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblLeadLowerLegMaximumAngleOverI.Text = "";
                            misv.variableName = "LLMAngleOver";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }


                        lblLowerLegAngleatTouchdownOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["LLAngleTDOff"].ToString());
                        // if (lblLowerLegAngleatTouchdownOffI.Text == "" || lblLowerLegAngleatTouchdownOffI.Text == "0")
                        decimal LowerLegAngleatTouchdownOff;
                        decimal.TryParse(ds.Tables[0].Rows[0]["LLAngleTDOff"].ToString(), out LowerLegAngleatTouchdownOff);
                        if (LowerLegAngleatTouchdownOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblLowerLegAngleatTouchdownOffI.Text = "";
                            misv.variableName = "LLAngleTDOff";
                            missingVariable.Add(misv);
                            initialcnt++;
                        }
                        lblLowerLegAngleatTakeoffOffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["LLAngleTOOff"].ToString());
                        //  if (lblLowerLegAngleatTakeoffOffI.Text == "" || lblLowerLegAngleatTakeoffOffI.Text == "0")
                        decimal LowerLegAngleatTakeoffOff;
                        decimal.TryParse(ds.Tables[0].Rows[0]["LLAngleTOOff"].ToString(), out LowerLegAngleatTakeoffOff);
                        if (LowerLegAngleatTakeoffOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "initial";
                            lblLowerLegAngleatTakeoffOffI.Text = "";
                            misv.variableName = "LLAngleTOOff";
                            missingVariable.Add(misv);
                            initialcnt++;
                          
                        }
                        #endregion[Initial Data]
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataRow drVariable = ds.Tables[1].Rows[0];
                        #region[model Data]
                        lblGroundTimeIntoM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["GroundTimeInto"]);
                        //  if (lblGroundTimeIntoM1.Text == "" || lblGroundTimeIntoM1.Text == "0.000" || lblGroundTimeIntoM1.Text == "0")
                        decimal GroundTimeInto;
                        decimal.TryParse(ds.Tables[1].Rows[0]["GroundTimeInto"].ToString(), out GroundTimeInto);
                        if (GroundTimeInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblGroundTimeIntoM1.Text = "";
                            misv.variableName = "GroundTimeInto";
                            missingVariable.Add(misv);
                            modelCnt++;

                        }
                        lblGroundTimeOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["GroundTimeOff"]);
                        //  if (lblGroundTimeOffM1.Text == "" || lblGroundTimeOffM1.Text == "0.000" || lblGroundTimeOffM1.Text == "0")
                        decimal GroundTimeOff;
                        decimal.TryParse(ds.Tables[1].Rows[0]["GroundTimeOff"].ToString(), out GroundTimeOff);
                        if (GroundTimeOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblGroundTimeOffM1.Text = "";
                            misv.variableName = "GroundTimeOff";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        lblAirTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["AirTimeOver"]);
                        //  if (lblAirTimeM1.Text == "" || lblAirTimeM1.Text == "0.000" || lblAirTimeM1.Text == "0")
                        decimal AirTime;
                        decimal.TryParse(ds.Tables[1].Rows[0]["AirTimeOver"].ToString(), out AirTime);
                        if (AirTime == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblAirTimeM1.Text = "";
                            misv.variableName = "AirTimeOver";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        lblStrideLengthIntoM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["StrideLengthInto"]);
                        //if (lblStrideLengthIntoM1.Text == "" || lblStrideLengthIntoM1.Text == "0.00" || lblStrideLengthIntoM1.Text == "0")
                        decimal StrideLengthInto;
                        decimal.TryParse(ds.Tables[1].Rows[0]["StrideLengthInto"].ToString(), out StrideLengthInto);
                        if (StrideLengthInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblStrideLengthIntoM1.Text = "";
                            misv.variableName = "StrideLengthInto";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        lblStrideLengthOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["StrideLengthOff"]);
                        // if (lblStrideLengthOffM1.Text == "" || lblStrideLengthOffM1.Text == "0.00" || lblStrideLengthOffM1.Text == "0")
                        decimal StrideLengthOff;
                        decimal.TryParse(ds.Tables[1].Rows[0]["StrideLengthOff"].ToString(), out StrideLengthOff);
                        if (StrideLengthOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblStrideLengthOffM1.Text = "";
                            misv.variableName = "StrideLengthOff";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        lblStrideLengthTotalM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["StrideLengthTotal"]);
                        // if (lblStrideLengthTotalM1.Text == "" || lblStrideLengthTotalM1.Text == "0.00" || lblStrideLengthTotalM1.Text == "0")
                        decimal StrideLengthTotal;
                        decimal.TryParse(ds.Tables[1].Rows[0]["StrideLengthTotal"].ToString(), out StrideLengthTotal);
                        if (StrideLengthTotal == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblStrideLengthTotalM1.Text = "";
                            misv.variableName = "StrideLengthTotal";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        lblVelocityHurdleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Velocity"]);
                        // if (lblVelocityHurdleM1.Text == "" || lblVelocityHurdleM1.Text == "0.00" || lblVelocityHurdleM1.Text == "0")
                        decimal Velocity;
                        decimal.TryParse(ds.Tables[1].Rows[0]["Velocity"].ToString(), out Velocity);
                        if (Velocity == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblVelocityHurdleM1.Text = "";
                            misv.variableName = "Velocity";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        lblTouchdownDistanceIntoM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["COGDistanceInto"]);
                        // if (lblTouchdownDistanceIntoM1.Text == "" || lblTouchdownDistanceIntoM1.Text == "0.00" || lblTouchdownDistanceIntoM1.Text == "0")
                        decimal TouchdownDistanceInto;
                        decimal.TryParse(ds.Tables[1].Rows[0]["COGDistanceInto"].ToString(), out TouchdownDistanceInto);
                        if (TouchdownDistanceInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblTouchdownDistanceIntoM1.Text = "";
                            misv.variableName = "COGDistanceInto";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        lblTouchdownDistanceOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["COGDistanceOff"]);
                        // if (lblTouchdownDistanceOffM1.Text == "" || lblTouchdownDistanceOffM1.Text == "0.00" || lblTouchdownDistanceOffM1.Text == "0")
                        decimal TouchdownDistanceOff;
                        decimal.TryParse(ds.Tables[1].Rows[0]["COGDistanceOff"].ToString(), out TouchdownDistanceOff);
                        if (TouchdownDistanceOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblTouchdownDistanceOffM1.Text = "";
                            misv.variableName = "COGDistanceOff";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }

                        lblKneeSeperationTouchDownIntoM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["KSTouchDownInto"]);
                        //if (lblKneeSeperationTouchDownIntoM1.Text == "" || lblKneeSeperationTouchDownIntoM1.Text == "0.00" || lblKneeSeperationTouchDownIntoM1.Text == "0")
                        decimal KneeSeperationTouchDownInto;
                        decimal.TryParse(ds.Tables[1].Rows[0]["KSTouchDownInto"].ToString(), out KneeSeperationTouchDownInto);
                        if (KneeSeperationTouchDownInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblKneeSeperationTouchDownIntoM1.Text = "";
                            misv.variableName = "KSTouchDownInto";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        lblKneeSeperationTouchDownOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["KSTouchDownOff"]);
                        //  if (lblKneeSeperationTouchDownOffM1.Text == "" || lblKneeSeperationTouchDownOffM1.Text == "0.00" || lblKneeSeperationTouchDownOffM1.Text == "0")
                        decimal KneeSeperationTouchDownOff;
                        decimal.TryParse(ds.Tables[1].Rows[0]["KSTouchDownOff"].ToString(), out KneeSeperationTouchDownOff);
                        if (KneeSeperationTouchDownOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblKneeSeperationTouchDownOffM1.Text = "";
                            misv.variableName = "KSTouchDownOff";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }

                        lblTrunkTouchDownAngleIntoM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["TTDAngleInto"]);
                        // if (lblTrunkTouchDownAngleIntoM1.Text == "" || lblTrunkTouchDownAngleIntoM1.Text == "0.00" || lblTrunkTouchDownAngleIntoM1.Text == "0")
                        decimal TrunkTouchDownAngleInto;
                        decimal.TryParse(ds.Tables[1].Rows[0]["TTDAngleInto"].ToString(), out TrunkTouchDownAngleInto);
                        if (TrunkTouchDownAngleInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblTrunkTouchDownAngleIntoM1.Text = "";
                            misv.variableName = "TTDAngleInto";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        lblTrunkTakeoffAngleIntoM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["TTAngleInto"]);
                        // if (lblTrunkTakeoffAngleIntoM1.Text == "" || lblTrunkTakeoffAngleIntoM1.Text == "0.00" || lblTrunkTakeoffAngleIntoM1.Text == "0")
                        decimal TrunkTakeoffAngleInto;
                        decimal.TryParse(ds.Tables[1].Rows[0]["TTAngleInto"].ToString(), out TrunkTakeoffAngleInto);
                        if (TrunkTakeoffAngleInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblTrunkTakeoffAngleIntoM1.Text = "";
                            misv.variableName = "TTAngleInto";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        lblTrunkMinimumAngleOverM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["TMAngleOver"]);
                        // if (lblTrunkMinimumAngleOverM1.Text == "" || lblTrunkTakeoffAngleIntoM1.Text == "0.00" || lblTrunkTakeoffAngleIntoM1.Text == "0")
                        decimal TrunkMinimumAngleOver;
                        decimal.TryParse(ds.Tables[1].Rows[0]["TMAngleOver"].ToString(), out TrunkMinimumAngleOver);
                        if (TrunkMinimumAngleOver == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblTrunkMinimumAngleOverM1.Text = "";
                            misv.variableName = "TMAngleOver";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        lblTrunkTouchDownAngleOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["TTDAngleOff"]);
                        //  if (lblTrunkTouchDownAngleOffM1.Text == "" || lblTrunkTouchDownAngleOffM1.Text == "0.00" || lblTrunkTouchDownAngleOffM1.Text == "0")
                        decimal TrunkTouchDownAngleOff;
                        decimal.TryParse(ds.Tables[1].Rows[0]["TTDAngleOff"].ToString(), out TrunkTouchDownAngleOff);
                        if (TrunkTouchDownAngleOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblTrunkTouchDownAngleOffM1.Text = "";
                            misv.variableName = "TTDAngleOff";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        lblTrunkTakeoffAngleOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["TTAngleOff"]);
                        // if (lblTrunkTakeoffAngleOffM1.Text == "" || lblTrunkTakeoffAngleOffM1.Text == "0.00" || lblTrunkTakeoffAngleOffM1.Text == "0")
                        decimal TrunkTakeoffAngleOff;
                        decimal.TryParse(ds.Tables[1].Rows[0]["TTAngleOff"].ToString(), out TrunkTakeoffAngleOff);
                        if (TrunkTakeoffAngleOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblTrunkTakeoffAngleOffM1.Text = "";
                            misv.variableName = "TTAngleOff";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }

                        lblUpperLegAngleatTouchdownIntoM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["ULAngleTDInto"]);
                        //  if (lblUpperLegAngleatTouchdownIntoM1.Text == "" || lblUpperLegAngleatTouchdownIntoM1.Text == "0.00" || lblUpperLegAngleatTouchdownIntoM1.Text == "0")
                        decimal UpperLegAngleatTouchdownInto;
                        decimal.TryParse(ds.Tables[1].Rows[0]["ULAngleTDInto"].ToString(), out UpperLegAngleatTouchdownInto);
                        if (UpperLegAngleatTouchdownInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblUpperLegAngleatTouchdownIntoM1.Text = "";
                            misv.variableName = "ULAngleTDInto";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        lblUpperLegAngleatTakeoffIntoM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["ULAngleTOInto"]);
                        //  if (lblUpperLegAngleatTakeoffIntoM1.Text == "" || lblUpperLegAngleatTakeoffIntoM1.Text == "0.00" || lblUpperLegAngleatTakeoffIntoM1.Text == "0")
                        decimal UpperLegAngleatTakeoffInto;
                        decimal.TryParse(ds.Tables[1].Rows[0]["ULAngleTOInto"].ToString(), out UpperLegAngleatTakeoffInto);
                        if (UpperLegAngleatTakeoffInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblUpperLegAngleatTakeoffIntoM1.Text = "";
                            misv.variableName = "ULAngleTOInto";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }

                        lblLeadUpperLegMaximumAngleOverM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["ULMAngleOver"]);
                        //  if (lblLeadUpperLegMaximumAngleOverM1.Text == "" || lblLeadUpperLegMaximumAngleOverM1.Text == "0.00" || lblLeadUpperLegMaximumAngleOverM1.Text == "0")
                        decimal LeadUpperLegMaximumAngleOver;
                        decimal.TryParse(ds.Tables[1].Rows[0]["ULMAngleOver"].ToString(), out LeadUpperLegMaximumAngleOver);
                        if (LeadUpperLegMaximumAngleOver == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblLeadUpperLegMaximumAngleOverM1.Text = "";
                            misv.variableName = "ULMAngleOver";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }

                        lblUpperLegAngleatTouchdownOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["ULAngleTDOff"]);
                        //   if (lblUpperLegAngleatTouchdownOffM1.Text == "" || lblUpperLegAngleatTouchdownOffM1.Text == "0.00" || lblUpperLegAngleatTouchdownOffM1.Text == "0")
                        decimal UpperLegAngleatTouchdownOff;
                        decimal.TryParse(ds.Tables[1].Rows[0]["ULAngleTDOff"].ToString(), out UpperLegAngleatTouchdownOff);
                        if (UpperLegAngleatTouchdownOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblUpperLegAngleatTouchdownOffM1.Text = "";
                            misv.variableName = "ULAngleTDOff";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        lblUpperLegAngleatTakeoffOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["ULAngleTOOff"]);
                        //   if (lblUpperLegAngleatTakeoffOffM1.Text == "" || lblUpperLegAngleatTakeoffOffM1.Text == "0.00" || lblUpperLegAngleatTakeoffOffM1.Text == "0")
                        decimal UpperLegAngleatTakeoffOff;
                        decimal.TryParse(ds.Tables[1].Rows[0]["ULAngleTOOff"].ToString(), out UpperLegAngleatTakeoffOff);
                        if (UpperLegAngleatTakeoffOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblUpperLegAngleatTakeoffOffM1.Text = "";
                            misv.variableName = "ULAngleTOOff";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }

                        lblKneeAnkleMinimumSeparationOverM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["KAMSeparationOver"]);
                        // if (lblKneeAnkleMinimumSeparationOverM1.Text == "" || lblKneeAnkleMinimumSeparationOverM1.Text == "0.00" || lblKneeAnkleMinimumSeparationOverM1.Text == "0")
                        decimal KneeAnkleMinimumSeparationOver;
                        decimal.TryParse(ds.Tables[1].Rows[0]["KAMSeparationOver"].ToString(), out KneeAnkleMinimumSeparationOver);
                        if (KneeAnkleMinimumSeparationOver == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblKneeAnkleMinimumSeparationOverM1.Text = "";
                            misv.variableName = "KAMSeparationOver";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }

                        lblLeadLowerLegMinimumAngleIntoM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["LeadLegMinimumAngle"]);
                        //   if (lblLeadLowerLegMinimumAngleIntoM1.Text == "" || lblLeadLowerLegMinimumAngleIntoM1.Text == "0.00" || lblLeadLowerLegMinimumAngleIntoM1.Text == "0")
                        decimal LeadLowerLegMinimumAngleInto;
                        decimal.TryParse(ds.Tables[1].Rows[0]["LeadLegMinimumAngle"].ToString(), out LeadLowerLegMinimumAngleInto);
                        if (LeadLowerLegMinimumAngleInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblLeadLowerLegMinimumAngleIntoM1.Text = "";
                            misv.variableName = "LeadLegMinimumAngle";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        lblLeadLowerLegAngleatAnkleCrossIntoM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["LeadLegAngleAC"]);
                        //  if (lblLeadLowerLegAngleatAnkleCrossIntoM1.Text == "" || lblLeadLowerLegAngleatAnkleCrossIntoM1.Text == "0.00" || lblLeadLowerLegAngleatAnkleCrossIntoM1.Text == "0")
                        decimal LeadLowerLegAngleatAnkleCrossInto;
                        decimal.TryParse(ds.Tables[1].Rows[0]["LeadLegAngleAC"].ToString(), out LeadLowerLegAngleatAnkleCrossInto);
                        if (LeadLowerLegAngleatAnkleCrossInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblLeadLowerLegAngleatAnkleCrossIntoM1.Text = "";
                            misv.variableName = "LeadLegAngleAC";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }

                        lblLeadLowerLegMaximumAngleOverM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["LLMAngleOver"]);
                        //  if (lblLeadLowerLegMaximumAngleOverM1.Text == "" || lblLeadLowerLegMaximumAngleOverM1.Text == "0.00" || lblLeadLowerLegMaximumAngleOverM1.Text == "0")
                        decimal LeadLowerLegMaximumAngleOver;
                        decimal.TryParse(ds.Tables[1].Rows[0]["LLMAngleOver"].ToString(), out LeadLowerLegMaximumAngleOver);
                        if (LeadLowerLegMaximumAngleOver == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblLeadLowerLegMaximumAngleOverM1.Text = "";
                            misv.variableName = "LLMAngleOver";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }


                        lblLowerLegAngleatTouchdownOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["LLAngleTDOff"]);
                        //   if (lblLowerLegAngleatTouchdownOffM1.Text == "" || lblLowerLegAngleatTouchdownOffM1.Text == "0.00" || lblLowerLegAngleatTouchdownOffM1.Text == "0")
                        decimal LowerLegAngleatTouchdownOff;
                        decimal.TryParse(ds.Tables[1].Rows[0]["LLAngleTDOff"].ToString(), out LowerLegAngleatTouchdownOff);
                        if (LowerLegAngleatTouchdownOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblLowerLegAngleatTouchdownOffM1.Text = "";
                            misv.variableName = "LLAngleTDOff";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        lblLowerLegAngleatTakeoffOffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["LLAngleTOOff"]);
                        //  if (lblLowerLegAngleatTakeoffOffM1.Text == "" || lblLowerLegAngleatTakeoffOffM1.Text == "0.00" || lblLowerLegAngleatTakeoffOffM1.Text == "0")
                        decimal LowerLegAngleatTakeoffOff;
                        decimal.TryParse(ds.Tables[1].Rows[0]["LLAngleTOOff"].ToString(), out LowerLegAngleatTakeoffOff);
                        if (LowerLegAngleatTakeoffOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "model";
                            lblLowerLegAngleatTakeoffOffM1.Text = "";
                            misv.variableName = "LLAngleTOOff";
                            missingVariable.Add(misv);
                            modelCnt++;
                        }
                        #endregion[model Data]
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        DataRow drVariable = ds.Tables[2].Rows[0];
                        #region[Current Data]
                        lblGroundTimeIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["GroundTimeInto"]);
                        //if (lblGroundTimeIntoF.Text == "" || lblGroundTimeIntoF.Text == "0.000" || lblGroundTimeIntoF.Text == "0")
                        decimal GroundTimeInto;
                        decimal.TryParse(ds.Tables[2].Rows[0]["GroundTimeInto"].ToString(), out GroundTimeInto);
                        if (GroundTimeInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblGroundTimeIntoF.Text = "";
                            misv.variableName = "GroundTimeInto";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblGroundTimeOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["GroundTimeOff"]);
                        // if (lblGroundTimeOffF.Text == "" || lblGroundTimeOffF.Text == "0.000" || lblGroundTimeOffF.Text == "0")
                        decimal GroundTimeOff;
                        decimal.TryParse(ds.Tables[2].Rows[0]["GroundTimeOff"].ToString(), out GroundTimeOff);
                        if (GroundTimeOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblGroundTimeOffF.Text = "";
                            misv.variableName = "GroundTimeOff";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblAirTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["AirTimeOver"]);
                        // if (lblAirTimeF.Text == "" || lblAirTimeF.Text == "0.000" || lblAirTimeF.Text == "0")
                        decimal AirTime;
                        decimal.TryParse(ds.Tables[2].Rows[0]["AirTimeOver"].ToString(), out AirTime);
                        if (AirTime == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblAirTimeF.Text = "";
                            misv.variableName = "AirTimeOver";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblStrideLengthIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["StrideLengthInto"]);
                        // if (lblStrideLengthIntoF.Text == "" || lblStrideLengthIntoF.Text == "0.000" || lblStrideLengthIntoF.Text == "0")
                        decimal StrideLengthInto;
                        decimal.TryParse(ds.Tables[2].Rows[0]["StrideLengthInto"].ToString(), out StrideLengthInto);
                        if (StrideLengthInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblStrideLengthIntoF.Text = "";
                            misv.variableName = "StrideLengthInto";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblStrideLengthOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["StrideLengthOff"]);
                        // if (lblStrideLengthOffF.Text == "" || lblStrideLengthOffF.Text == "0.000" || lblStrideLengthOffF.Text == "0")
                        decimal StrideLengthOff;
                        decimal.TryParse(ds.Tables[2].Rows[0]["StrideLengthOff"].ToString(), out StrideLengthOff);
                        if (StrideLengthOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblStrideLengthOffF.Text = "";
                            misv.variableName = "StrideLengthOff";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblStrideLengthTotalF.Text = Convert.ToString(ds.Tables[2].Rows[0]["StrideLengthTotal"]);
                        // if (lblStrideLengthTotalF.Text == "" || lblStrideLengthTotalF.Text == "0.000" || lblStrideLengthTotalF.Text == "0")
                        decimal StrideLengthTotal;
                        decimal.TryParse(ds.Tables[2].Rows[0]["StrideLengthTotal"].ToString(), out StrideLengthTotal);
                        if (StrideLengthTotal == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblStrideLengthTotalF.Text = "";
                            misv.variableName = "StrideLengthTotal";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblVelocityHurdleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Velocity"]);
                        // if (lblVelocityHurdleF.Text == "" || lblVelocityHurdleF.Text == "0.000" || lblVelocityHurdleF.Text == "0")
                        decimal Velocity;
                        decimal.TryParse(ds.Tables[2].Rows[0]["Velocity"].ToString(), out Velocity);
                        if (Velocity == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblVelocityHurdleF.Text = "";
                            misv.variableName = "Velocity";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblTouchdownDistanceIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["COGDistanceInto"]);
                        // if (lblTouchdownDistanceIntoF.Text == "" || lblTouchdownDistanceIntoF.Text == "0.000" || lblTouchdownDistanceIntoF.Text == "0")
                        decimal TouchdownDistanceInto;
                        decimal.TryParse(ds.Tables[2].Rows[0]["COGDistanceInto"].ToString(), out TouchdownDistanceInto);
                        if (TouchdownDistanceInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblTouchdownDistanceIntoF.Text = "";
                            misv.variableName = "COGDistanceInto";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblTouchdownDistanceOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["COGDistanceOff"]);
                        // if (lblTouchdownDistanceOffF.Text == "" || lblTouchdownDistanceOffF.Text == "0.000" || lblTouchdownDistanceOffF.Text == "0")
                        decimal TouchdownDistanceOff;
                        decimal.TryParse(ds.Tables[2].Rows[0]["COGDistanceOff"].ToString(), out TouchdownDistanceOff);
                        if (TouchdownDistanceOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblTouchdownDistanceOffF.Text = "";
                            misv.variableName = "COGDistanceOff";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }

                        lblKneeSeperationTouchDownIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["KSTouchDownInto"]);
                        //  if (lblKneeSeperationTouchDownIntoF.Text == "" || lblKneeSeperationTouchDownIntoF.Text == "0.000" || lblKneeSeperationTouchDownIntoF.Text == "0")
                        decimal KneeSeperationTouchDownInto;
                        decimal.TryParse(ds.Tables[2].Rows[0]["KSTouchDownInto"].ToString(), out KneeSeperationTouchDownInto);
                        if (KneeSeperationTouchDownInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblKneeSeperationTouchDownIntoF.Text = "";
                            misv.variableName = "KSTouchDownInto";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblKneeSeperationTouchDownOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["KSTouchDownOff"]);
                        //   if (lblKneeSeperationTouchDownOffF.Text == "" || lblKneeSeperationTouchDownOffF.Text == "0.000" || lblKneeSeperationTouchDownOffF.Text == "0")
                        decimal KneeSeperationTouchDownOff;
                        decimal.TryParse(ds.Tables[2].Rows[0]["KSTouchDownOff"].ToString(), out KneeSeperationTouchDownOff);
                        if (KneeSeperationTouchDownOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblKneeSeperationTouchDownOffF.Text = "";
                            misv.variableName = "KSTouchDownOff";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }

                        lblTrunkTouchDownAngleIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TTDAngleInto"]);
                        // if (lblTrunkTouchDownAngleIntoF.Text == "" || lblTrunkTouchDownAngleIntoF.Text == "0.000" || lblTrunkTouchDownAngleIntoF.Text == "0")
                        decimal TrunkTouchDownAngleInto;
                        decimal.TryParse(ds.Tables[2].Rows[0]["TTDAngleInto"].ToString(), out TrunkTouchDownAngleInto);
                        if (TrunkTouchDownAngleInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblTrunkTouchDownAngleIntoF.Text = "";
                            misv.variableName = "TTDAngleInto";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblTrunkTakeoffAngleIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TTAngleInto"]);
                        // if (lblTrunkTakeoffAngleIntoF.Text == "" || lblTrunkTakeoffAngleIntoF.Text == "0.000" || lblTrunkTakeoffAngleIntoF.Text == "0")
                        decimal TrunkTakeoffAngleInto;
                        decimal.TryParse(ds.Tables[2].Rows[0]["TTAngleInto"].ToString(), out TrunkTakeoffAngleInto);
                        if (TrunkTakeoffAngleInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblTrunkTakeoffAngleIntoF.Text = "";
                            misv.variableName = "TTAngleInto";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblTrunkMinimumAngleOverF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TMAngleOver"]);
                        //if (lblTrunkMinimumAngleOverF.Text == "" || lblTrunkMinimumAngleOverF.Text == "0.000" || lblTrunkMinimumAngleOverF.Text == "0")
                        decimal TrunkMinimumAngleOver;
                        decimal.TryParse(ds.Tables[2].Rows[0]["TMAngleOver"].ToString(), out TrunkMinimumAngleOver);
                        if (TrunkMinimumAngleOver == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblTrunkMinimumAngleOverF.Text = "";
                            misv.variableName = "TMAngleOver";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblTrunkTouchDownAngleOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TTDAngleOff"]);
                        // if (lblTrunkTouchDownAngleOffF.Text == "" || lblTrunkTouchDownAngleOffF.Text == "0.000" || lblTrunkTouchDownAngleOffF.Text == "0")
                        decimal TrunkTouchDownAngleOff;
                        decimal.TryParse(ds.Tables[2].Rows[0]["TTDAngleOff"].ToString(), out TrunkTouchDownAngleOff);
                        if (TrunkTouchDownAngleOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblTrunkTouchDownAngleOffF.Text = "";
                            misv.variableName = "TTDAngleOff";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblTrunkTakeoffAngleOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TTAngleOff"]);
                        //  if (lblTrunkTakeoffAngleOffF.Text == "" || lblTrunkTakeoffAngleOffF.Text == "0.000" || lblTrunkTakeoffAngleOffF.Text == "0")
                        decimal TrunkTakeoffAngleOff;
                        decimal.TryParse(ds.Tables[2].Rows[0]["TTAngleOff"].ToString(), out TrunkTakeoffAngleOff);
                        if (TrunkTakeoffAngleOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblTrunkTakeoffAngleOffF.Text = "";
                            misv.variableName = "TTAngleOff";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }

                        lblUpperLegAngleatTouchdownIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["ULAngleTDInto"]);
                        // if (lblUpperLegAngleatTouchdownIntoF.Text == "" || lblUpperLegAngleatTouchdownIntoF.Text == "0.000" || lblUpperLegAngleatTouchdownIntoF.Text == "0")
                        decimal UpperLegAngleatTouchdownInto;
                        decimal.TryParse(ds.Tables[2].Rows[0]["ULAngleTDInto"].ToString(), out UpperLegAngleatTouchdownInto);
                        if (UpperLegAngleatTouchdownInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblUpperLegAngleatTouchdownIntoF.Text = "";
                            misv.variableName = "ULAngleTDInto";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblUpperLegAngleatTakeoffIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["ULAngleTOInto"]);
                        //  if (lblUpperLegAngleatTakeoffIntoF.Text == "" || lblUpperLegAngleatTakeoffIntoF.Text == "0.000" || lblUpperLegAngleatTakeoffIntoF.Text == "0")
                        decimal UpperLegAngleatTakeoffInto;
                        decimal.TryParse(ds.Tables[2].Rows[0]["ULAngleTOInto"].ToString(), out UpperLegAngleatTakeoffInto);
                        if (UpperLegAngleatTakeoffInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblUpperLegAngleatTakeoffIntoF.Text = "";
                            misv.variableName = "ULAngleTOInto";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }

                        lblLeadUpperLegMaximumAngleOverF.Text = Convert.ToString(ds.Tables[2].Rows[0]["ULMAngleOver"]);
                        //  if (lblLeadUpperLegMaximumAngleOverF.Text == "" || lblLeadUpperLegMaximumAngleOverF.Text == "0.000" || lblLeadUpperLegMaximumAngleOverF.Text == "0")
                        decimal LeadUpperLegMaximumAngleOver;
                        decimal.TryParse(ds.Tables[2].Rows[0]["ULMAngleOver"].ToString(), out LeadUpperLegMaximumAngleOver);
                        if (LeadUpperLegMaximumAngleOver == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblLeadUpperLegMaximumAngleOverF.Text = "";
                            misv.variableName = "ULMAngleOver";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }

                        lblUpperLegAngleatTouchdownOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["ULAngleTDOff"]);
                        // if (lblUpperLegAngleatTouchdownOffF.Text == "" || lblUpperLegAngleatTouchdownOffF.Text == "0.000" || lblUpperLegAngleatTouchdownOffF.Text == "0")
                        decimal UpperLegAngleatTouchdownOff;
                        decimal.TryParse(ds.Tables[2].Rows[0]["ULAngleTDOff"].ToString(), out UpperLegAngleatTouchdownOff);
                        if (UpperLegAngleatTouchdownOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblUpperLegAngleatTouchdownOffF.Text = "";
                            misv.variableName = "ULAngleTDOff";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblUpperLegAngleatTakeoffOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["ULAngleTOOff"]);
                        // if (lblUpperLegAngleatTakeoffOffF.Text == "" || lblUpperLegAngleatTakeoffOffF.Text == "0.000" || lblUpperLegAngleatTakeoffOffF.Text == "0")
                        decimal UpperLegAngleatTakeoffOff;
                        decimal.TryParse(ds.Tables[2].Rows[0]["ULAngleTOOff"].ToString(), out UpperLegAngleatTakeoffOff);
                        if (UpperLegAngleatTakeoffOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblUpperLegAngleatTakeoffOffF.Text = "";
                            misv.variableName = "ULAngleTOOff";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }

                        lblKneeAnkleMinimumSeparationOverF.Text = Convert.ToString(ds.Tables[2].Rows[0]["KAMSeparationOver"]);
                        //  if (lblKneeAnkleMinimumSeparationOverF.Text == "" || lblKneeAnkleMinimumSeparationOverF.Text == "0.000" || lblKneeAnkleMinimumSeparationOverF.Text == "0")
                        decimal KneeAnkleMinimumSeparationOver;
                        decimal.TryParse(ds.Tables[2].Rows[0]["KAMSeparationOver"].ToString(), out KneeAnkleMinimumSeparationOver);
                        if (KneeAnkleMinimumSeparationOver == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblKneeAnkleMinimumSeparationOverF.Text = "";
                            misv.variableName = "KAMSeparationOver";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }

                        lblLeadLowerLegMinimumAngleIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["LeadLegMinimumAngle"]);
                        //  if (lblLeadLowerLegMinimumAngleIntoF.Text == "" || lblLeadLowerLegMinimumAngleIntoF.Text == "0.000" || lblLeadLowerLegMinimumAngleIntoF.Text == "0")
                        decimal LeadLowerLegMinimumAngleInto;
                        decimal.TryParse(ds.Tables[2].Rows[0]["LeadLegMinimumAngle"].ToString(), out LeadLowerLegMinimumAngleInto);
                        if (LeadLowerLegMinimumAngleInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblLeadLowerLegMinimumAngleIntoF.Text = "";
                            misv.variableName = "LeadLegMinimumAngle";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblLeadLowerLegAngleatAnkleCrossIntoF.Text = Convert.ToString(ds.Tables[2].Rows[0]["LeadLegAngleAC"]);
                        //  if (lblLeadLowerLegAngleatAnkleCrossIntoF.Text == "" || lblLeadLowerLegAngleatAnkleCrossIntoF.Text == "0.000" || lblLeadLowerLegAngleatAnkleCrossIntoF.Text == "0")
                        decimal LeadLowerLegAngleatAnkleCrossInto;
                        decimal.TryParse(ds.Tables[2].Rows[0]["LeadLegAngleAC"].ToString(), out LeadLowerLegAngleatAnkleCrossInto);
                        if (LeadLowerLegAngleatAnkleCrossInto == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblLeadLowerLegAngleatAnkleCrossIntoF.Text = "";
                            misv.variableName = "LeadLegAngleAC";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }

                        lblLeadLowerLegMaximumAngleOverF.Text = Convert.ToString(ds.Tables[2].Rows[0]["LLMAngleOver"]);
                        // if (lblLeadLowerLegMaximumAngleOverF.Text == "" || lblLeadLowerLegMaximumAngleOverF.Text == "0.000" || lblLeadLowerLegMaximumAngleOverF.Text == "0")
                        decimal LeadLowerLegMaximumAngleOver;
                        decimal.TryParse(ds.Tables[2].Rows[0]["LLMAngleOver"].ToString(), out LeadLowerLegMaximumAngleOver);
                        if (LeadLowerLegMaximumAngleOver == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblLeadLowerLegMaximumAngleOverF.Text = "";
                            misv.variableName = "LLMAngleOver";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }

                        lblLowerLegAngleatTouchdownOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["LLAngleTDOff"]);
                        //   if (lblLowerLegAngleatTouchdownOffF.Text == " " || lblLowerLegAngleatTouchdownOffF.Text == "0.000" || lblLowerLegAngleatTouchdownOffF.Text == "0")
                        decimal LowerLegAngleatTouchdownOff;
                        decimal.TryParse(ds.Tables[2].Rows[0]["LLAngleTDOff"].ToString(), out LowerLegAngleatTouchdownOff);
                        if (LowerLegAngleatTouchdownOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblLowerLegAngleatTouchdownOffF.Text = "";
                            misv.variableName = "LLAngleTDOff";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        lblLowerLegAngleatTakeoffOffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["LLAngleTOOff"]);
                        //  if (lblLowerLegAngleatTakeoffOffF.Text == "" || lblLowerLegAngleatTakeoffOffF.Text == "0.000" || lblLowerLegAngleatTakeoffOffF.Text == "0")
                        decimal LowerLegAngleatTakeoffOff;
                        decimal.TryParse(ds.Tables[2].Rows[0]["LLAngleTOOff"].ToString(), out LowerLegAngleatTakeoffOff);
                        if (LowerLegAngleatTakeoffOff == 0)
                        {
                            MissingVariable misv = new MissingVariable();
                            misv.type = "current";
                            lblLowerLegAngleatTakeoffOffF.Text = ""; 
                            misv.variableName = "LLAngleTOOff";
                            missingVariable.Add(misv);
                            CurrentCnt++;
                        }
                        #endregion[Current Data]
                    }
                    sendNotFoundEmail(initialcnt, modelCnt, CurrentCnt);
                }
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropdownListXmlFle.Items.Clear();
        DropDownList2.Items.Clear();
        clearAllData();
        if (!DropDownList1.SelectedValue.Equals("noathlete"))
        {
            clearAllData();
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
                dsmodelData = sae.GetAllHurdleAthleteData(lessonid);
                string groundtimeI = string.Empty;


                var tablegroundtimeI = dsmodelData.Tables[0];
                string groundtimeM = string.Empty;
                var tablegroundtimeM = dsmodelData.Tables[1];
                string groundtimeC = string.Empty;
                var tablegroundtimeC = dsmodelData.Tables[2];
                Dictionary<string, string> vals = new Dictionary<string, string>();
                Dictionary<string, string> valsModel = new Dictionary<string, string>();
                Dictionary<string, string> valsCurnt = new Dictionary<string, string>();
                List<string> Curantlist = new List<string>();
                List<string> Modellist = new List<string>();
                List<string> Initiallist = new List<string>();

                if (tablegroundtimeI.Rows.Count > 0)
                {
                    foreach (DataRow dr in tablegroundtimeI.Rows)
                    {
                        for (int i = 0; i < tablegroundtimeI.Columns.Count; i++)
                        {
                            vals.Add(tablegroundtimeI.Columns[i].ColumnName, dr[tablegroundtimeI.Columns[i].ColumnName].ToString());
                        }
                    }

                    // groundtimeI = dsmodelData.Tables[0].Rows[0]["GroundTimeInto"].ToString();

                }

                foreach (var item in vals.Values)
                {
                    if (item != "0" && item != "0.000")
                    {
                        Initiallist.Add(item);
                    }
                }
                //if (Initiallist.Count > 0)
                //{
                //    GetAllHurdleAthleteData(lessonid);
                //}

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
                        if (item != "0" && item != "0.000")
                        {
                            Modellist.Add(item);
                        }
                    }

                    //if (Modellist.Count > 0)
                    //{
                    //    GetAllHurdleAthleteData(lessonid);
                    //}
                    //  groundtimeM = dsmodelData.Tables[1].Rows[0]["GroundTimeInto"].ToString();
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
                        if (item != "0" && item != "0.000")
                        {
                            Curantlist.Add(item);
                        }
                    }
                    //if (Curantlist.Count > 0)
                    //{
                    //    GetAllHurdleAthleteData(lessonid);
                    //}
                    // groundtimeC = dsmodelData.Tables[2].Rows[0]["GroundTimeInto"].ToString();
                }



                string location1 = sae.SelectLessonlocation(lesson.LessonId.ToString());
                if (location1 == "On-Track Sesssion Summary")
                {
                    OntrackSessionSelect();
                    GetAllHurdleAthleteData(lessonid);
                }


                else if (Modellist.Count > 0)
                {
                    GetAllHurdleAthleteData(lessonid);
                }
                else if ((Initiallist.Count > 0 || Curantlist.Count > 0) && Modellist.Count > 0)
                {
                    GetAllHurdleAthleteData(lessonid);
                }
                else if (Curantlist.Count > 0)
                {
                    GetAllHurdleAthleteData(lessonid);
                }
                else
                {

                    // BindModelDataOnly(dsmodelData);
                    GetAllHurdleAthleteDataInitialNdCorrent(lessonid);
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
                }
            }
            catch (Exception ex)
            {
                GetAllHurdleAthleteData(lessonid);
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
            clearAllData();
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
            //the following status of isnewlession varible is changed depending upon the visibility of 
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
                    string initial_id = hid.LessonId.ToString();
                    string model_id = hmd.LessonId.ToString();
                    string hurdle_id = hcd.LessonId.ToString();
                    lesson = DataRepository.LessonProvider.GetByLessonId(LessonSelected);
                    //IList movieList = DataRepository.MovieProvider.GetByLessonId(LessonSelected);
                    //if (movieList.Count == 2)
                    //{
                    //    movieSide = (Movie)movieList[0];
                    //    movieBack = (Movie)movieList[1];
                    //}
                    //else if (movieList.Count == 1)
                    //{
                    //    movieSide = (Movie)movieList[0];
                    //}
                    //else
                    //{
                    //    movieSide = new Movie();
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
                lesson.LessonTypeId = 3;
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
                    bool customerprofileiisexist = false;
                    AthleteSelectedId = Convert.ToInt16(DropDownList1.SelectedValue);
                    Customer custmer = DataRepository.CustomerProvider.GetByCustomerId(AthleteSelectedId);
                    try
                    {
                        customerprofile1 = DataRepository.CustomerProfileProvider.GetByCustomerId(custmer.CustomerId)[0];
                        customerprofileiisexist = true;
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
                    if (customerprofileiisexist)
                    {
                        lesson.SiteId = customerprofile1.CustomerSite;
                    }
                    else
                    {
                        lesson.SiteId = 11;//defualt site for customer is Baylor
                    }
                    lesson.CustomerId = custmer.CustomerId;
                    lesson.LessonTypeId = 3;
                    lesson.MachineNumber = 1;
                    DataRepository.LessonProvider.Insert(lesson);
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

            #region[Insertupdate into hurdleInitialdata]
            try
            {
                _hurdledata.LessonId = lesson.LessonId;
                _hurdledata.GroundTimeInto = convertDecimal(lblGroundTimeIntoI.Text);
                _hurdledata.GroundTimeOff = convertDecimal(lblGroundTimeOffI.Text);
                _hurdledata.AirTimeOver = convertDecimal(lblAirTimeI.Text);
                _hurdledata.StrideLengthInto = convertDecimal(lblStrideLengthIntoI.Text);
                _hurdledata.StrideLengthOff = convertDecimal(lblStrideLengthOffI.Text);
                _hurdledata.StrideLengthTotal = convertDecimal(lblStrideLengthTotalI.Text);
                _hurdledata.Velocity = convertDecimal(lblVelocityI.Text);
                _hurdledata.COGDistanceInto = convertDecimal(lblTouchdownDistanceIntoI.Text);
                _hurdledata.COGDistanceOff = convertDecimal(lblTouchdownDistanceOffI.Text);
                _hurdledata.KSTouchDownInto = convertDecimal(lblKneeSeperationTouchDownIntoI.Text);
                _hurdledata.KSTouchDownOff = convertDecimal(lblKneeSeperationTouchDownOffI.Text);
                _hurdledata.TTDAngleInto = convertInt(lblTrunkTouchDownAngleIntoI.Text);
                _hurdledata.TTAngleInto = convertDecimal(lblTrunkTakeoffAngleIntoI.Text);
                _hurdledata.TMAngleOver = convertDecimal(lblTrunkMinimumAngleOverI.Text);
                _hurdledata.TTDAngleOff = convertDecimal(lblTrunkTouchDownAngleOffI.Text);
                _hurdledata.TTAngleOff = convertDecimal(lblTrunkTakeoffAngleOffI.Text);
                _hurdledata.ULAngleTDInto = convertInt(lblUpperLegAngleatTouchdownIntoI.Text);
                _hurdledata.ULAngleTOInto = convertInt(lblUpperLegAngleatTakeoffIntoI.Text);
                _hurdledata.ULMAngleOver = convertInt(lblLeadUpperLegMaximumAngleOverI.Text);
                _hurdledata.ULAngleTDOff = convertInt(lblUpperLegAngleatTouchdownOffI.Text);
                _hurdledata.ULAngleTOOff = convertInt(lblUpperLegAngleatTakeoffOffI.Text);
                //_hurdledata.KAMSeparationOver = Convert.ToInt32(lblKneeAnkleMinimumSeparationOverI.Text);
                _hurdledata.KAMSeparationOver = convertDecimal(lblKneeAnkleMinimumSeparationOverI.Text);
                _hurdledata.LeadLegMinimumAngle = convertInt(lblLeadLowerLegMinimumAngleIntoI.Text);
                _hurdledata.LeadLegAngleAC = convertInt(lblLeadLowerLegAngleatAnkleCrossIntoI.Text);
                _hurdledata.LLMAngleOver = convertInt(lblLeadLowerLegMaximumAngleOverI.Text);
                _hurdledata.LLAngleTDOff = convertInt(lblLowerLegAngleatTouchdownOffI.Text);
                _hurdledata.LLAngleTOOff = convertInt(lblLowerLegAngleatTakeoffOffI.Text);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            //_hurdledata.LessonId = Convert.ToInt32(DropDownList2.SelectedValue);
            string Hurdle_Initialdataid = sae.SelectHurdleInitialDataid(_hurdledata.LessonId.ToString());
            if (Hurdle_Initialdataid == "")
            {
                _hurdledata.InsertIntoHurdleInitialData();
                // compusport.Data.DataRepository.HurdleInitialDataProvider.Insert(hid);
            }
            else
            {
                _hurdledata.UpdateHurdleInitialData();
                //compusport.Data.DataRepository.HurdleInitialDataProvider.Update(hid);
            }
            #endregion[Insertupdate into HurdleInitialData]
            #region[Insertupdate into HurdleModelDada]
            try
            {
                _hurdledata.LessonId = lesson.LessonId;
                _hurdledata.GroundTimeInto = convertDecimal(lblGroundTimeIntoM1.Text);
                _hurdledata.GroundTimeOff = convertDecimal(lblGroundTimeOffM1.Text);
                _hurdledata.AirTimeOver = convertDecimal(lblAirTimeM1.Text);
                _hurdledata.StrideLengthInto = convertDecimal(lblStrideLengthIntoM1.Text);
                _hurdledata.StrideLengthOff = convertDecimal(lblStrideLengthOffM1.Text);
                _hurdledata.StrideLengthTotal = convertDecimal(lblStrideLengthTotalM1.Text);
                _hurdledata.Velocity = convertDecimal(lblVelocityHurdleM1.Text);
                _hurdledata.COGDistanceInto = convertDecimal(lblTouchdownDistanceIntoM1.Text);
                _hurdledata.COGDistanceOff = convertDecimal(lblTouchdownDistanceOffM1.Text);
                _hurdledata.KSTouchDownInto = convertDecimal(lblKneeSeperationTouchDownIntoM1.Text);
                _hurdledata.KSTouchDownOff = convertDecimal(lblKneeSeperationTouchDownOffM1.Text);
                _hurdledata.TTDAngleInto = convertDecimal(lblTrunkTouchDownAngleIntoM1.Text);
                _hurdledata.TTAngleInto = convertDecimal(lblTrunkTakeoffAngleIntoM1.Text);
                _hurdledata.TMAngleOver = convertDecimal(lblTrunkMinimumAngleOverM1.Text);
                _hurdledata.TTDAngleOff = convertDecimal(lblTrunkTouchDownAngleOffM1.Text);
                _hurdledata.TTAngleOff = convertDecimal(lblTrunkTakeoffAngleOffM1.Text);
                _hurdledata.ULAngleTDInto = convertInt(lblUpperLegAngleatTouchdownIntoM1.Text);
                _hurdledata.ULAngleTOInto = convertInt(lblUpperLegAngleatTakeoffIntoM1.Text);
                _hurdledata.ULMAngleOver = convertInt(lblLeadUpperLegMaximumAngleOverM1.Text);
                _hurdledata.ULAngleTDOff = convertInt(lblUpperLegAngleatTouchdownOffM1.Text);
                _hurdledata.ULAngleTOOff = convertInt(lblUpperLegAngleatTakeoffOffM1.Text);
                //_hurdledata.KAMSeparationOver = Convert.ToInt32(lblKneeAnkleMinimumSeparationOverM1.Text);
                _hurdledata.KAMSeparationOver = convertDecimal(lblKneeAnkleMinimumSeparationOverM1.Text);
                _hurdledata.LeadLegMinimumAngle = convertInt(lblLeadLowerLegMinimumAngleIntoM1.Text);
                _hurdledata.LeadLegAngleAC = convertInt(lblLeadLowerLegAngleatAnkleCrossIntoM1.Text);
                _hurdledata.LLMAngleOver = convertInt(lblLeadLowerLegMaximumAngleOverM1.Text);
                _hurdledata.LLAngleTDOff = convertInt(lblLowerLegAngleatTouchdownOffM1.Text);
                _hurdledata.LLAngleTOOff = convertInt(lblLowerLegAngleatTakeoffOffM1.Text);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            //_hurdledata.LessonId = Convert.ToInt32(DropDownList2.SelectedValue);
            string Hurdle_Modeldataid = sae.SelectHurdleModelDataid(_hurdledata.LessonId.ToString());
            if (Hurdle_Modeldataid == "")
            {
                //compusport.Data.DataRepository.HurdleModelDataProvider.Insert(hmd);
                _hurdledata.InsertIntoHurdleModelData();
            }
            else
            {
                _hurdledata.UpdateHurdleModelData();
                // compusport.Data.DataRepository.HurdleModelDataProvider.Update(hmd);
            }
            #endregion[Insertupdate into HurdleModelDada]
            #region[Insertupdate into HurdelCurrent]

            try
            {
                _hurdledata.LessonId = lesson.LessonId;
                _hurdledata.GroundTimeInto = convertDecimal(lblGroundTimeIntoF.Text);
                _hurdledata.GroundTimeOff = convertDecimal(lblGroundTimeOffF.Text);
                _hurdledata.AirTimeOver = convertDecimal(lblAirTimeF.Text);
                _hurdledata.StrideLengthInto = convertDecimal(lblStrideLengthIntoF.Text);
                _hurdledata.StrideLengthOff = convertDecimal(lblStrideLengthOffF.Text);
                _hurdledata.StrideLengthTotal = convertDecimal(lblStrideLengthTotalF.Text);
                _hurdledata.Velocity = convertDecimal(lblVelocityHurdleF.Text);
                _hurdledata.COGDistanceInto = convertDecimal(lblTouchdownDistanceIntoF.Text);
                _hurdledata.COGDistanceOff = convertDecimal(lblTouchdownDistanceOffF.Text);
                _hurdledata.KSTouchDownInto = convertDecimal(lblKneeSeperationTouchDownIntoF.Text);
                _hurdledata.KSTouchDownOff = convertDecimal(lblKneeSeperationTouchDownOffF.Text);
                _hurdledata.TTDAngleInto = convertDecimal(lblTrunkTouchDownAngleIntoF.Text);
                _hurdledata.TTAngleInto = convertDecimal(lblTrunkTakeoffAngleIntoF.Text);
                _hurdledata.TMAngleOver = convertDecimal(lblTrunkMinimumAngleOverF.Text);
                _hurdledata.TTDAngleOff = convertDecimal(lblTrunkTouchDownAngleOffF.Text);
                _hurdledata.TTAngleOff = convertDecimal(lblTrunkTakeoffAngleOffF.Text);
                _hurdledata.ULAngleTDInto = convertInt(lblUpperLegAngleatTouchdownIntoF.Text);
                _hurdledata.ULAngleTOInto = convertInt(lblUpperLegAngleatTakeoffIntoF.Text);
                _hurdledata.ULMAngleOver = convertInt(lblLeadUpperLegMaximumAngleOverF.Text);
                _hurdledata.ULAngleTDOff = convertInt(lblUpperLegAngleatTouchdownOffF.Text);
                _hurdledata.ULAngleTOOff = convertInt(lblUpperLegAngleatTakeoffOffF.Text);
                _hurdledata.KAMSeparationOver = convertDecimal(lblKneeAnkleMinimumSeparationOverF.Text);
                    _hurdledata.LeadLegMinimumAngle = convertInt(lblLeadLowerLegMinimumAngleIntoF.Text);
                    _hurdledata.LeadLegAngleAC = convertInt(lblLeadLowerLegAngleatAnkleCrossIntoF.Text);
                    _hurdledata.LLMAngleOver = convertInt(lblLeadLowerLegMaximumAngleOverF.Text);
                    _hurdledata.LLAngleTDOff = convertInt(lblLowerLegAngleatTouchdownOffF.Text);
                    _hurdledata.LLAngleTOOff = convertInt(lblLowerLegAngleatTakeoffOffF.Text);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            //_hurdledata.LessonId = Convert.ToInt32(DropDownList2.SelectedValue);
            string Hurdle_CurrentDataid = sae.SelectHurdleCurrentDataid(_hurdledata.LessonId.ToString());
            if (Hurdle_CurrentDataid == "")
            {
                //compusport.Data.DataRepository.HurdleCurrentDataProvider.Insert(hcd);
                _hurdledata.InsertIntoHurdleCurrentData();
            }
            else
            {
                _hurdledata.UpdateHurdleCurrentData();
                // compusport.Data.DataRepository.HurdleCurrentDataProvider.Update(hcd);
            }
            #endregion[Insertupdate into HurdelCurrent]

            #region[save initial movies]
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
            #endregion[save initial movies]
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
                if (txtBFrame7.Text != "")
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
                    //if (movieBack.MovieId <= 0)
                    //{
                    //    DataRepository.MovieProvider.Insert(movieBack);
                    //}
                    //else
                    //{
                    //    DataRepository.MovieProvider.Update(movieBack);
                    //}
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
            Gridview1.Visible = false;
            Gridview2.Visible = false;
            Gridview3.Visible = false;
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
            HurdlePageOnTrackSession onTrackSession = new HurdlePageOnTrackSession();
            onTrackSession.HurdlePageOnTrackSessionData(athleteSelected);
        }
        else
        {
            Label117.Text = "Please select Athlete";
        }
    }


    public Decimal calcavgdecimal(decimal number1, decimal number2)
    {
        decimal average = 0;

        average = (number1 + number2) / Convert.ToDecimal(2);

        return average;
    }

    public int calcavginteger(int number1, int number2)
    {
        int average = 0;

        average = Convert.ToInt16((number1 + number2) / 2);

        return average;
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

        txtForCurrentVideo.Text = "";

        //  txtbFilePath1.Visible = true;
        txtSumFilePath.Text = "";
        txtbFilePath.Text = "";

        btnInpuFullSession.Visible = true;
        DropdownListXmlFle.Visible = true;
        txtbFilePath.Visible = true;
        btnUpload.Visible = true;
        btnDeleteInitialMovies.Visible = true;
        txtForCurrentVideo.Visible = true;
        btnToBrowseCurrentVideo.Visible = true;
        btnDeleteCurrentMovies.Visible = true;
        txtSumFilePath.Visible = true;
        btnUpload2.Visible = true;
        btnDeleteSummaryMovie.Visible = true;
        btnSubmit.Visible = true;
        btnDeleteSession.Visible = true;


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

            //G:\NewCompuSport\SourceCode\Users\MovieFiles
            //FileInfo myFile = new FileInfo("G:\\NewCompuSport\\SourceCode\\Users\\MovieFiles");
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
                FilePathClass1 objFilePathClass = new FilePathClass1();
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
        {
            ex.Message.ToString();
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
                FilePathClass1 objFilePathClass = new FilePathClass1();
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
            //G:\NewCompuSport\SourceCode\Users\SummaryFiles
            //FileInfo myFile = new FileInfo("G:\\NewCompuSport\\SourceCode\\Users\\SummaryFiles");
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
                FilePathClass1 objFilePathClass = new FilePathClass1();
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
    protected void Gridview2_SelectedIndexChanged(object sender, EventArgs e)
    {
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
    protected void btnDeleteInitialMovies_Click(object sender, EventArgs e)
    {
        try
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
            UpdatePanel2.Update();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
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
        UpdatePanel6.Update();
    }
    protected void btnDeleteSummaryMovie_Click(object sender, EventArgs e)
    {
        Lesson _lesson = new Lesson();
        int _lessonselected = Convert.ToInt32(DropDownList2.SelectedValue);
        _lesson = DataRepository.LessonProvider.GetByLessonId(_lessonselected);
        int summarylessonid = _lesson.LessonId;
        DataRepository.SummaryMovieProvider.Delete(summarylessonid);
        txtSumFilePath.Text = "";
    }
    protected void btnDeleteSession_Click(object sender, EventArgs e)
    {
        if (!DropDownList1.SelectedValue.Equals("noathlete"))//changes 11/01/2017
        {
            try
            {
                Lesson _lesson = new Lesson();
                Movie _movieCurrentSide = new Movie();
                Movie _movieCurrentBack = new Movie();
                Movie _movieSide = new Movie();
                Movie _movieBack = new Movie();
                int AthleteSelectedId;//changes 11/01/2017
                AthleteSelectedId = Convert.ToInt16(DropDownList1.SelectedValue);//changes 11/01/2017
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

                string Sprint_InitialDataId = sae.SelectHurdleInitialDataid(_lessonselected.ToString());

                if (Sprint_InitialDataId != "")
                {
                    _hurdledata.DeleteHurdleInitialLessonData(_lessonselected);
                }

                string Sprint_ModelDataId = sae.SelectHurdleModelDataid(_lessonselected.ToString());
                if (Sprint_ModelDataId != "")
                {
                    _hurdledata.DeleteHurdleModelLessonData(_lessonselected);
                }

                string Sprint_CurrentDataId = sae.SelectHurdleCurrentDataid(_lessonselected.ToString());
                if (Sprint_CurrentDataId != "")
                {
                    _hurdledata.DeleteHurdleCurrentLessonData(_lessonselected);
                }

                DataRepository.LessonProvider.Delete(_lessonselected);   //delete lesson 
                sae.UpdateLessonLocation(location, _lesson.LessonId); // changes 11/01/2017
                //System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "refresh", "refresh();", true); //changes 11/01/2017
                HurdlePageOnTrackSession onTrackSession = new HurdlePageOnTrackSession();
                onTrackSession.HurdlePageOnTrackSessionData(_lessonselected);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            DropDownList1_SelectedIndexChanged(null, null); //changes 11/01/2017
        }
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
            // Label4.Visible = true;
        }
        if (DropdownListXmlFle.Items.Count > 0)
        {
            lblNoVideo.Visible = false;
            //  Label4.Visible = false;
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
                                    //var position9 = packageChild.Element("position9").Value;
                                    //txtCBFrame9.Text = position9;
                                    //var position10 = packageChild.Element("position10").Value;
                                }
                            }
                        }
                        //----------------------IniialSumamary -----------
                        if (returnnode.Count() > 0)
                        {
                            IEnumerable<XElement> InitialSummary = returnnode.Elements("InitialSummary");
                            if (InitialSummary.Count() > 0)
                            {
                                foreach (XElement packageChild in InitialSummary)
                                {
                                    var GroundTimeInto = packageChild.Element("GroundTimeInto").Value;
                                    if (GroundTimeInto != "")
                                    {
                                        lblGroundTimeIntoI.Text = GroundTimeInto;
                                    }

                                    var GroundTimeOff = packageChild.Element("GroundTimeOff").Value;
                                    if (GroundTimeOff != "")
                                    {
                                        lblGroundTimeOffI.Text = GroundTimeOff;
                                    }

                                    var AirTime = packageChild.Element("AirTime").Value;
                                    if (AirTime != "")
                                    {
                                        lblAirTimeI.Text = AirTime;
                                    }

                                    var StrideLengthInto = packageChild.Element("StrideLengthInto").Value;
                                    if (StrideLengthInto != "")
                                    {
                                        lblStrideLengthIntoI.Text = StrideLengthInto;
                                    }

                                    var StrideLengthOff = packageChild.Element("StrideLengthOff").Value;
                                    if (StrideLengthOff != "")
                                    {
                                        lblStrideLengthOffI.Text = StrideLengthOff;
                                    }

                                    var StrideLengthTotal = packageChild.Element("StrideLengthTotal").Value;
                                    if (StrideLengthTotal != "")
                                    {
                                        lblStrideLengthTotalI.Text = StrideLengthTotal;
                                    }

                                    var Velocity = packageChild.Element("Velocity").Value;
                                    if (Velocity != "")
                                    {
                                        lblVelocityI.Text = Velocity;
                                    }

                                    var TdDistanceInto = packageChild.Element("TdDistanceInto").Value;
                                    if (TdDistanceInto != "")
                                    {
                                        lblTouchdownDistanceIntoI.Text = TdDistanceInto;
                                    }
                                    var TdDistanceOff = packageChild.Element("TdDistanceOff").Value;
                                    if (TdDistanceOff != "")
                                    {
                                        lblTouchdownDistanceOffI.Text = TdDistanceOff;
                                    }
                                    var KneeKneeSeparationTdInto = packageChild.Element("KneeKneeSeparationTdInto").Value;
                                    if (KneeKneeSeparationTdInto != "")
                                    {
                                        lblKneeSeperationTouchDownIntoI.Text = KneeKneeSeparationTdInto;
                                    }
                                    var KneeAnkleSeparationTdOff = packageChild.Element("KneeAnkleSeparationTdOff").Value;
                                    if (KneeAnkleSeparationTdOff != "")
                                    {
                                        lblKneeSeperationTouchDownOffI.Text = KneeAnkleSeparationTdOff;
                                    }
                                    var TrunkTdInto = packageChild.Element("TrunkTdInto").Value;
                                    if (TrunkTdInto != "")
                                    {
                                        lblTrunkTouchDownAngleIntoI.Text = TrunkTdInto;
                                    }
                                    var TrunkToInto = packageChild.Element("TrunkToInto").Value;
                                    if (TrunkToInto != "")
                                    {
                                        lblTrunkTakeoffAngleIntoI.Text = TrunkToInto;
                                    }
                                    var TrunkMaxOver = packageChild.Element("TrunkMaxOver").Value;
                                    if (TrunkMaxOver != "")
                                    {
                                        lblTrunkMinimumAngleOverI.Text = TrunkMaxOver;
                                    }
                                    var TrunkTdOff = packageChild.Element("TrunkTdOff").Value;
                                    if (TrunkTdOff != "")
                                    {
                                        lblTrunkTouchDownAngleOffI.Text = TrunkTdOff;
                                    }
                                    var TrunkToOff = packageChild.Element("TrunkToOff").Value;
                                    if (TrunkToOff != "")
                                    {
                                        lblTrunkTakeoffAngleOffI.Text = TrunkToOff;
                                    }
                                    // ----------------------------------------//-----------------------

                                    var UlTdInto = packageChild.Element("UlTdInto").Value;
                                    if (UlTdInto != "")
                                    {
                                        lblUpperLegAngleatTouchdownIntoI.Text = UlTdInto;
                                    }
                                    var UlToInto = packageChild.Element("UlToInto").Value;
                                    if (UlToInto != "")
                                    {
                                        lblUpperLegAngleatTakeoffIntoI.Text = UlToInto;
                                    }
                                    var ULLeadOverMax = packageChild.Element("ULLeadOverMax").Value;
                                    if (ULLeadOverMax != "")
                                    {
                                        lblLeadUpperLegMaximumAngleOverI.Text = ULLeadOverMax;
                                    }

                                    // --------------------------

                                    var UlTdOff = packageChild.Element("UlTdOff").Value;
                                    if (UlTdOff != "")
                                    {
                                        lblUpperLegAngleatTouchdownOffI.Text = UlTdOff;
                                    }

                                    var UlToOff = packageChild.Element("UlToOff").Value;
                                    if (UlToOff != "")
                                    {
                                        lblUpperLegAngleatTakeoffOffI.Text = UlToOff;
                                    }

                                    var KneeAnkleSeparationOver = packageChild.Element("KneeAnkleSeparationOver").Value;
                                    if (KneeAnkleSeparationOver != "")
                                    {
                                        lblKneeAnkleMinimumSeparationOverI.Text = KneeAnkleSeparationOver;
                                    }

                                    //---------------------------

                                    var LlLeadFullFlexInto = packageChild.Element("LlLeadFullFlexInto").Value;
                                    if (LlLeadFullFlexInto != "")
                                    {
                                        lblLeadLowerLegMinimumAngleIntoI.Text = LlLeadFullFlexInto;
                                    }

                                    var LlLeadAnkleCrossInto = packageChild.Element("LlLeadAnkleCrossInto").Value;
                                    if (LlLeadAnkleCrossInto != "")
                                    {
                                        lblLeadLowerLegAngleatAnkleCrossIntoI.Text = LlLeadAnkleCrossInto;
                                    }

                                    var LlLeadOverMax = packageChild.Element("LlLeadOverMax").Value;
                                    if (LlLeadOverMax != "")
                                    {
                                        lblLeadLowerLegMaximumAngleOverI.Text = LlLeadOverMax;
                                    }

                                    var LlTdOff = packageChild.Element("LlTdOff").Value;
                                    if (LlTdOff != "")
                                    {
                                        lblLowerLegAngleatTouchdownOffI.Text = LlTdOff;
                                    }

                                    var LlToOff = packageChild.Element("LlToOff").Value;
                                    if (LlToOff != "")
                                    {
                                        lblLowerLegAngleatTakeoffOffI.Text = LlToOff;
                                    }

                                }
                            }
                        }
                        //-------------------------Final-------------
                        if (returnnode.Count() > 0)
                        {
                            IEnumerable<XElement> SetPosition = returnnode.Elements("CurrentSummary");

                            if (SetPosition.Count() > 0)
                            {
                                foreach (XElement packageChild in SetPosition)
                                {
                                    var GroundTimeInto = packageChild.Element("GroundTimeInto").Value;
                                    if (GroundTimeInto != "")
                                    {
                                        lblGroundTimeIntoF.Text = GroundTimeInto;
                                    }

                                    var GroundTimeOff = packageChild.Element("GroundTimeOff").Value;
                                    if (GroundTimeOff != "")
                                    {
                                        lblGroundTimeOffF.Text = GroundTimeOff;
                                    }

                                    var AirTime = packageChild.Element("AirTime").Value;
                                    if (AirTime != "")
                                    {
                                        lblAirTimeF.Text = AirTime;
                                    }

                                    var StrideLengthInto = packageChild.Element("StrideLengthInto").Value;
                                    if (StrideLengthInto != "")
                                    {
                                        lblStrideLengthIntoF.Text = StrideLengthInto;
                                    }

                                    var StrideLengthOff = packageChild.Element("StrideLengthOff").Value;
                                    if (StrideLengthOff != "")
                                    {
                                        lblStrideLengthOffF.Text = StrideLengthOff;
                                    }
                                    var StrideLengthTotal = packageChild.Element("StrideLengthTotal").Value;
                                    if (StrideLengthTotal != "")
                                    {
                                        lblStrideLengthTotalF.Text = StrideLengthTotal;
                                    }
                                    var Velocity = packageChild.Element("Velocity").Value;
                                    if (Velocity != "")
                                    {
                                        lblVelocityHurdleF.Text = Velocity;
                                    }
                                    var TdDistanceInto = packageChild.Element("TdDistanceInto").Value;
                                    if (TdDistanceInto != "")
                                    {
                                        lblTouchdownDistanceIntoF.Text = TdDistanceInto;
                                    }
                                    var TdDistanceOff = packageChild.Element("TdDistanceOff").Value;
                                    if (TdDistanceOff != "")
                                    {
                                        lblTouchdownDistanceOffF.Text = TdDistanceOff;
                                    }
                                    var KneeKneeSeparationTdInto = packageChild.Element("KneeKneeSeparationTdInto").Value;
                                    if (KneeKneeSeparationTdInto != "")
                                    {
                                        lblKneeSeperationTouchDownIntoF.Text = KneeKneeSeparationTdInto;
                                    }
                                    var KneeAnkleSeparationTdOff = packageChild.Element("KneeAnkleSeparationTdOff").Value;
                                    if (KneeAnkleSeparationTdOff != "")
                                    {
                                        lblKneeSeperationTouchDownOffF.Text = KneeAnkleSeparationTdOff;
                                    }

                                    var TrunkTdInto = packageChild.Element("TrunkTdInto").Value;
                                    if (TrunkTdInto != "")
                                    {
                                        lblTrunkTouchDownAngleIntoF.Text = TrunkTdInto;
                                    }

                                    var TrunkToInto = packageChild.Element("TrunkToInto").Value;
                                    if (TrunkToInto != "")
                                    {
                                        lblTrunkTakeoffAngleIntoF.Text = TrunkToInto;
                                    }
                                    var TrunkMaxOver = packageChild.Element("TrunkMaxOver").Value;
                                    if (TrunkMaxOver != "")
                                    {
                                        lblTrunkMinimumAngleOverF.Text = TrunkMaxOver;
                                    }
                                    var TrunkTdOff = packageChild.Element("TrunkTdOff").Value;
                                    if (TrunkTdOff != "")
                                    {
                                        lblTrunkTouchDownAngleOffF.Text = TrunkTdOff;
                                    }
                                    var TrunkToOff = packageChild.Element("TrunkToOff").Value;
                                    if (TrunkToOff != "")
                                    {
                                        lblTrunkTakeoffAngleOffF.Text = TrunkToOff;
                                    }
                                    // ----------------------------------------//-----------------------

                                    var UlTdInto = packageChild.Element("UlTdInto").Value;
                                    if (UlTdInto != "")
                                    {
                                        lblUpperLegAngleatTouchdownIntoF.Text = UlTdInto;
                                    }

                                    var UlToInto = packageChild.Element("UlToInto").Value;
                                    if (UlToInto != "")
                                    {
                                        lblUpperLegAngleatTakeoffIntoF.Text = UlToInto;
                                    }
                                    var ULLeadOverMax = packageChild.Element("ULLeadOverMax").Value;
                                    if (ULLeadOverMax != "")
                                    {
                                        lblLeadUpperLegMaximumAngleOverF.Text = ULLeadOverMax;
                                    }
                                    var UlTdOff = packageChild.Element("UlTdOff").Value;
                                    if (UlTdOff != "")
                                    {
                                        lblUpperLegAngleatTouchdownOffF.Text = UlTdOff;
                                    }
                                    var UlToOff = packageChild.Element("UlToOff").Value;
                                    if (UlToOff != "")
                                    {
                                        lblUpperLegAngleatTakeoffOffF.Text = UlToOff;
                                    }
                                    var KneeAnkleSeparationOver = packageChild.Element("KneeAnkleSeparationOver").Value;
                                    if (KneeAnkleSeparationOver != "")
                                    {
                                        lblKneeAnkleMinimumSeparationOverF.Text = KneeAnkleSeparationOver;
                                    }

                                    //---------------------------

                                    var LlLeadFullFlexInto = packageChild.Element("LlLeadFullFlexInto").Value;
                                    if (LlLeadFullFlexInto != "")
                                    {
                                        lblLeadLowerLegMinimumAngleIntoF.Text = LlLeadFullFlexInto;
                                    }
                                    var LlLeadAnkleCrossInto = packageChild.Element("LlLeadAnkleCrossInto").Value;
                                    if (LlLeadAnkleCrossInto != "")
                                    {
                                        lblLeadLowerLegAngleatAnkleCrossIntoF.Text = LlLeadAnkleCrossInto;
                                    }
                                    var LlLeadOverMax = packageChild.Element("LlLeadOverMax").Value;
                                    if (LlLeadOverMax != "")
                                    {
                                        lblLeadLowerLegMaximumAngleOverF.Text = LlLeadOverMax;
                                    }
                                    var LlTdOff = packageChild.Element("LlTdOff").Value;
                                    if (LlTdOff != "")
                                    {
                                        lblLowerLegAngleatTouchdownOffF.Text = LlTdOff;
                                    }
                                    var LlToOff = packageChild.Element("LlToOff").Value;
                                    if (LlToOff != "")
                                    {
                                        lblLowerLegAngleatTakeoffOffF.Text = LlToOff;

                                    }
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
        lblNoVideo.Visible = false;
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

public class FilePathClass1
{

    public int Index { get; set; }

    public string FilePath { get; set; }
}


