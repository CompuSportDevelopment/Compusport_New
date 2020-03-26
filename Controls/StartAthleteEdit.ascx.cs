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

public partial class TrackData_StartAthleteEdit : System.Web.UI.UserControl
{
    int x;
    public Customer customerid;
    public Customer cust;
    public CustomerProfile customerprofile;
    public CustomerProfile customerprofile1;
    TList<Customer> customer = new TList<Customer>();
    TList<Lesson> lessonlist = new TList<Lesson>();
    Movie movieSide;
    Movie CurrentMovieSide;
    Movie CurrentMovieBack;
    bool isMovieClipsExist = false;
    SummaryMovie summaryMovie;
    string location;
    int lessonid;
    Customer custmer;
    int summarysessionlessionid = 0;
    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    CompuSportDAL.SprintAthleteEdit sae = new CompuSportDAL.SprintAthleteEdit();
    CompuSportDAL.StartInitialData _startinitialdata = new CompuSportDAL.StartInitialData();

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    //public Customer Startcustomer;
    Customer Startcustomer;

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

    //changes 04/01/2017
    private void DataClear()
    {
        #region[DataClear]

        lblSetFrontBlockDistanceM1.Text = "";
        lblSetRearBlockDistanceM1.Text = "";
        lblSetFrontULAngleM1.Text = "";
        lblSetRearULAngleM1.Text = "";
        lblSetFrontLLAngleM1.Text = "";
        lblSetRearLLAngleM1.Text = "";
        lblSetTrunkAngleM1.Text = "";
        lblSetCOGDistanceM1.Text = "";

        lblBCRearFootClearanceTimeM1.Text = "";
        lblBCFrontFootClearanceTimeM1.Text = "";
        lblBCRearLLAngleTakeoffM1.Text = "";
        lblBCFrontLLAngleTakeoffM1.Text = "";
        lblBCTrunkAngleTakeoffM1.Text = "";
        lblBCLLAngleACM1.Text = "";
        lblBCAirTimeM1.Text = "";
        lblBCStrideLengthM1.Text = "";
        lblStep1COGDistanceM1.Text = "";


        lblStep1LLAngleTakeoffM1.Text = "";
        lblStep1TrunkAngleTakeoffM1.Text = "";
        lblStep1LLAngleACM1.Text = "";
        lblStep1GroundTimeM1.Text = "";
        lblStep1AirTimeM1.Text = "";
        lblStep1StrideLengthM1.Text = "";
        lblStep2COGDistanceM1.Text = "";
        lblStep2LLAngleTakeoffM1.Text = "";
        lblStep2TrunkAngleTakeoffM1.Text = "";
        lblStep2LLAngleACM1.Text = "";
        lblStep2GroundTimeM1.Text = "";
        lblStep2AirTimeM1.Text = "";
        lblStep2StrideLengthM1.Text = "";
        lblStep3COGDistanceM1.Text = "";
        lblTimeTo3mM1.Text = "";
        lblTimeTo5mM1.Text = "";
        #endregion[DataClear]

    }

    private void ClearData()
    {
        #region[Clear Data]
        lblSetFrontBlockDistanceI.Text = "";
        lblSetRearBlockDistanceI.Text = "";
        lblSetFrontULAngleI.Text = "";
        lblSetRearULAngleI.Text = "";
        lblSetFrontLLAngleI.Text = "";
        lblSetRearLLAngleI.Text = "";
        lblSetTrunkAngleI.Text = "";
        lblSetCOGDistanceI.Text = "";

        lblBCRearFootClearanceTimeI.Text = "";
        lblBCFrontFootClearanceTimeI.Text = "";
        lblBCRearLLAngleTakeoffI.Text = "";
        lblBCFrontLLAngleTakeoffI.Text = "";
        lblBCTrunkAngleTakeoffI.Text = "";
        lblBCLLAngleACI.Text = "";
        lblBCAirTimeI.Text = "";
        lblBCStrideLengthI.Text = "";
        lblStep1COGDistanceI.Text = "";


        lblStep1LLAngleTakeoffI.Text = "";
        lblStep1TrunkAngleTakeoffI.Text = "";
        lblStep1LLAngleACI.Text = "";
        lblStep1GroundTimeI.Text = "";
        lblStep1AirTimeI.Text = "";
        lblStep1StrideLengthI.Text = "";
        lblStep2COGDistanceI.Text = "";
        lblStep2LLAngleTakeoffI.Text = "";
        lblStep2TrunkAngleTakeoffI.Text = "";
        lblStep2LLAngleACI.Text = "";
        lblStep2GroundTimeI.Text = "";
        lblStep2AirTimeI.Text = "";
        lblStep2StrideLengthI.Text = "";
        lblStep3COGDistanceI.Text = "";
        lblTimeTo3mI.Text = "";
        lblTimeTo5mI.Text = "";


        //changes 04/01/2017

        //lblSetFrontBlockDistanceM1.Text = "";
        //lblSetRearBlockDistanceM1.Text = "";
        //lblSetFrontULAngleM1.Text = "";
        //lblSetRearULAngleM1.Text = "";
        //lblSetFrontLLAngleM1.Text = "";
        //lblSetRearLLAngleM1.Text = "";
        //lblSetTrunkAngleM1.Text = "";
        //lblSetCOGDistanceM1.Text = "";

        //lblBCRearFootClearanceTimeM1.Text = "";
        //lblBCFrontFootClearanceTimeM1.Text = "";
        //lblBCRearLLAngleTakeoffM1.Text = "";
        //lblBCFrontLLAngleTakeoffM1.Text = "";
        //lblBCTrunkAngleTakeoffM1.Text = "";
        //lblBCLLAngleACM1.Text = "";
        //lblBCAirTimeM1.Text = "";
        //lblBCStrideLengthM1.Text = "";
        //lblStep1COGDistanceM1.Text = "";


        //lblStep1LLAngleTakeoffM1.Text = "";
        //lblStep1TrunkAngleTakeoffM1.Text = "";
        //lblStep1LLAngleACM1.Text = "";
        //lblStep1GroundTimeM1.Text = "";
        //lblStep1AirTimeM1.Text = "";
        //lblStep1StrideLengthM1.Text = "";
        //lblStep2COGDistanceM1.Text = "";
        //lblStep2LLAngleTakeoffM1.Text = "";
        //lblStep2TrunkAngleTakeoffM1.Text = "";
        //lblStep2LLAngleACM1.Text = "";
        //lblStep2GroundTimeM1.Text = "";
        //lblStep2AirTimeM1.Text = "";
        //lblStep2StrideLengthM1.Text = "";
        //lblStep3COGDistanceM1.Text = "";
        //lblTimeTo3mM1.Text = "";
        //lblTimeTo5mM1.Text = "";



        lblSetFrontBlockDistanceF.Text = "";
        lblSetRearBlockDistanceF.Text = "";
        lblSetFrontULAngleF.Text = "";
        lblSetRearULAngleF.Text = "";
        lblSetFrontLLAngleF.Text = "";
        lblSetRearLLAngleF.Text = "";
        lblSetTrunkAngleF.Text = "";
        lblSetCOGDistanceF.Text = "";

        lblBCRearFootClearanceTimeF.Text = "";
        lblBCFrontFootClearanceTimeF.Text = "";
        lblBCRearLLAngleTakeoffF.Text = "";
        lblBCFrontLLAngleTakeoffF.Text = "";
        lblBCTrunkAngleTakeoffF.Text = "";
        lblBCLLAngleACF.Text = "";
        lblBCAirTimeF.Text = "";
        lblBCStrideLengthF.Text = "";
        lblStep1COGDistanceF.Text = "";


        lblStep1LLAngleTakeoffF.Text = "";
        lblStep1TrunkAngleTakeoffF.Text = "";
        lblStep1LLAngleACF.Text = "";
        lblStep1GroundTimeF.Text = "";
        lblStep1AirTimeF.Text = "";
        lblStep1StrideLengthF.Text = "";
        lblStep2COGDistanceF.Text = "";
        lblStep2LLAngleTakeoffF.Text = "";
        lblStep2TrunkAngleTakeoffF.Text = "";
        lblStep2LLAngleACF.Text = "";
        lblStep2GroundTimeF.Text = "";
        lblStep2AirTimeF.Text = "";
        lblStep2StrideLengthF.Text = "";
        lblStep3COGDistanceF.Text = "";
        lblTimeTo3mF.Text = "";
        lblTimeTo5mF.Text = "";



        //TextBox1.Text = "";
        //   wmpfile = "";
        Label157.Text = "";
        // #endregion
        #endregion[Clear Data]
    }
    private void OntrackSessionSelect()
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

        lblSetFrontBlockDistanceI.ReadOnly = true;
        lblSetRearBlockDistanceI.ReadOnly = true;
        lblSetFrontULAngleI.ReadOnly = true;
        lblSetRearULAngleI.ReadOnly = true;
        lblSetFrontLLAngleI.ReadOnly = true;
        lblSetRearLLAngleI.ReadOnly = true;
        lblSetTrunkAngleI.ReadOnly = true;
        lblSetCOGDistanceI.ReadOnly = true;

        lblBCRearFootClearanceTimeI.ReadOnly = true;
        lblBCFrontFootClearanceTimeI.ReadOnly = true;
        lblBCRearLLAngleTakeoffI.ReadOnly = true;
        lblBCFrontLLAngleTakeoffI.ReadOnly = true;
        lblBCTrunkAngleTakeoffI.ReadOnly = true;
        lblBCLLAngleACI.ReadOnly = true;
        lblBCAirTimeI.ReadOnly = true;
        lblBCStrideLengthI.ReadOnly = true;
        lblStep1COGDistanceI.ReadOnly = true;


        lblStep1LLAngleTakeoffI.ReadOnly = true;
        lblStep1TrunkAngleTakeoffI.ReadOnly = true;
        lblStep1LLAngleACI.ReadOnly = true;
        lblStep1GroundTimeI.ReadOnly = true;
        lblStep1AirTimeI.ReadOnly = true;
        lblStep1StrideLengthI.ReadOnly = true;
        lblStep2COGDistanceI.ReadOnly = true;
        lblStep2LLAngleTakeoffI.ReadOnly = true;
        lblStep2TrunkAngleTakeoffI.ReadOnly = true;
        lblStep2LLAngleACI.ReadOnly = true;
        lblStep2GroundTimeI.ReadOnly = true;
        lblStep2AirTimeI.ReadOnly = true;
        lblStep2StrideLengthI.ReadOnly = true;
        lblStep3COGDistanceI.ReadOnly = true;
        lblTimeTo3mI.ReadOnly = true;
        lblTimeTo5mI.ReadOnly = true;

        lblSetFrontBlockDistanceM1.ReadOnly = true;
        lblSetRearBlockDistanceM1.ReadOnly = true;
        lblSetFrontULAngleM1.ReadOnly = true;
        lblSetRearULAngleM1.ReadOnly = true;
        lblSetFrontLLAngleM1.ReadOnly = true;
        lblSetRearLLAngleM1.ReadOnly = true;
        lblSetTrunkAngleM1.ReadOnly = true;
        lblSetCOGDistanceM1.ReadOnly = true;

        lblBCRearFootClearanceTimeM1.ReadOnly = true;
        lblBCFrontFootClearanceTimeM1.ReadOnly = true;
        lblBCRearLLAngleTakeoffM1.ReadOnly = true;
        lblBCFrontLLAngleTakeoffM1.ReadOnly = true;
        lblBCTrunkAngleTakeoffM1.ReadOnly = true;
        lblBCLLAngleACM1.ReadOnly = true;
        lblBCAirTimeM1.ReadOnly = true;
        lblBCStrideLengthM1.ReadOnly = true;
        lblStep1COGDistanceM1.ReadOnly = true;


        lblStep1LLAngleTakeoffM1.ReadOnly = true;
        lblStep1TrunkAngleTakeoffM1.ReadOnly = true;
        lblStep1LLAngleACM1.ReadOnly = true;
        lblStep1GroundTimeM1.ReadOnly = true;
        lblStep1AirTimeM1.ReadOnly = true;
        lblStep1StrideLengthM1.ReadOnly = true;
        lblStep2COGDistanceM1.ReadOnly = true;
        lblStep2LLAngleTakeoffM1.ReadOnly = true;
        lblStep2TrunkAngleTakeoffM1.ReadOnly = true;
        lblStep2LLAngleACM1.ReadOnly = true;
        lblStep2GroundTimeM1.ReadOnly = true;
        lblStep2AirTimeM1.ReadOnly = true;
        lblStep2StrideLengthM1.ReadOnly = true;
        lblStep3COGDistanceM1.ReadOnly = true;
        lblTimeTo3mM1.ReadOnly = true;
        lblTimeTo5mM1.ReadOnly = true;



        lblSetFrontBlockDistanceF.ReadOnly = true;
        lblSetRearBlockDistanceF.ReadOnly = true;
        lblSetFrontULAngleF.ReadOnly = true;
        lblSetRearULAngleF.ReadOnly = true;
        lblSetFrontLLAngleF.ReadOnly = true;
        lblSetRearLLAngleF.ReadOnly = true;
        lblSetTrunkAngleF.ReadOnly = true;
        lblSetCOGDistanceF.ReadOnly = true;

        lblBCRearFootClearanceTimeF.ReadOnly = true;
        lblBCFrontFootClearanceTimeF.ReadOnly = true;
        lblBCRearLLAngleTakeoffF.ReadOnly = true;
        lblBCFrontLLAngleTakeoffF.ReadOnly = true;
        lblBCTrunkAngleTakeoffF.ReadOnly = true;
        lblBCLLAngleACF.ReadOnly = true;
        lblBCAirTimeF.ReadOnly = true;
        lblBCStrideLengthF.ReadOnly = true;
        lblStep1COGDistanceF.ReadOnly = true;


        lblStep1LLAngleTakeoffF.ReadOnly = true;
        lblStep1TrunkAngleTakeoffF.ReadOnly = true;
        lblStep1LLAngleACF.ReadOnly = true;
        lblStep1GroundTimeF.ReadOnly = true;
        lblStep1AirTimeF.ReadOnly = true;
        lblStep1StrideLengthF.ReadOnly = true;
        lblStep2COGDistanceF.ReadOnly = true;
        lblStep2LLAngleTakeoffF.ReadOnly = true;
        lblStep2TrunkAngleTakeoffF.ReadOnly = true;
        lblStep2LLAngleACF.ReadOnly = true;
        lblStep2GroundTimeF.ReadOnly = true;
        lblStep2AirTimeF.ReadOnly = true;
        lblStep2StrideLengthF.ReadOnly = true;
        lblStep3COGDistanceF.ReadOnly = true;
        lblTimeTo3mF.ReadOnly = true;
        lblTimeTo5mF.ReadOnly = true;

        txtCBFrame1.ReadOnly = true;
        txtCBFrame2.ReadOnly = true;
        txtCBFrame3.ReadOnly = true;
        txtCBFrame4.ReadOnly = true;
        txtCBFrame5.ReadOnly = true;
        txtCBFrame6.ReadOnly = true;
        txtCBFrame7.ReadOnly = true;
        txtCBFrame8.ReadOnly = true;
        txtCBFrame9.ReadOnly = true;

        txtBFrame1.ReadOnly = true;
        txtBFrame2.ReadOnly = true;
        txtBFrame3.ReadOnly = true;
        txtBFrame4.ReadOnly = true;
        txtBFrame5.ReadOnly = true;
        txtBFrame6.ReadOnly = true;
        txtBFrame7.ReadOnly = true;
        txtBFrame8.ReadOnly = true;
        txtBFrame9.ReadOnly = true;

        txtDate.ReadOnly = true;
        txtTime.ReadOnly = true;
        txtLocation.ReadOnly = true;
        txtForCurrentVideo.ReadOnly = true;
        txtSumFilePath.ReadOnly = true;
        txtbFilePath.ReadOnly = true;
    }
    private void ReadOntrackSessionSelect()
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

        lblSetFrontBlockDistanceI.ReadOnly = false;
        lblSetRearBlockDistanceI.ReadOnly = false;
        lblSetFrontULAngleI.ReadOnly = false;
        lblSetRearULAngleI.ReadOnly = false;
        lblSetFrontLLAngleI.ReadOnly = false;
        lblSetRearLLAngleI.ReadOnly = false;
        lblSetTrunkAngleI.ReadOnly = false;
        lblSetCOGDistanceI.ReadOnly = false;

        lblBCRearFootClearanceTimeI.ReadOnly = false;
        lblBCFrontFootClearanceTimeI.ReadOnly = false;
        lblBCRearLLAngleTakeoffI.ReadOnly = false;
        lblBCFrontLLAngleTakeoffI.ReadOnly = false;
        lblBCTrunkAngleTakeoffI.ReadOnly = false;
        lblBCLLAngleACI.ReadOnly = false;
        lblBCAirTimeI.ReadOnly = false;
        lblBCStrideLengthI.ReadOnly = false;
        lblStep1COGDistanceI.ReadOnly = false;


        lblStep1LLAngleTakeoffI.ReadOnly = false;
        lblStep1TrunkAngleTakeoffI.ReadOnly = false;
        lblStep1LLAngleACI.ReadOnly = false;
        lblStep1GroundTimeI.ReadOnly = false;
        lblStep1AirTimeI.ReadOnly = false;
        lblStep1StrideLengthI.ReadOnly = false;
        lblStep2COGDistanceI.ReadOnly = false;
        lblStep2LLAngleTakeoffI.ReadOnly = false;
        lblStep2TrunkAngleTakeoffI.ReadOnly = false;
        lblStep2LLAngleACI.ReadOnly = false;
        lblStep2GroundTimeI.ReadOnly = false;
        lblStep2AirTimeI.ReadOnly = false;
        lblStep2StrideLengthI.ReadOnly = false;
        lblStep3COGDistanceI.ReadOnly = false;
        lblTimeTo3mI.ReadOnly = false;
        lblTimeTo5mI.ReadOnly = false;

        lblSetFrontBlockDistanceM1.ReadOnly = false;
        lblSetRearBlockDistanceM1.ReadOnly = false;
        lblSetFrontULAngleM1.ReadOnly = false;
        lblSetRearULAngleM1.ReadOnly = false;
        lblSetFrontLLAngleM1.ReadOnly = false;
        lblSetRearLLAngleM1.ReadOnly = false;
        lblSetTrunkAngleM1.ReadOnly = false;
        lblSetCOGDistanceM1.ReadOnly = false;

        lblBCRearFootClearanceTimeM1.ReadOnly = false;
        lblBCFrontFootClearanceTimeM1.ReadOnly = false;
        lblBCRearLLAngleTakeoffM1.ReadOnly = false;
        lblBCFrontLLAngleTakeoffM1.ReadOnly = false;
        lblBCTrunkAngleTakeoffM1.ReadOnly = false;
        lblBCLLAngleACM1.ReadOnly = false;
        lblBCAirTimeM1.ReadOnly = false;
        lblBCStrideLengthM1.ReadOnly = false;
        lblStep1COGDistanceM1.ReadOnly = false;


        lblStep1LLAngleTakeoffM1.ReadOnly = false;
        lblStep1TrunkAngleTakeoffM1.ReadOnly = false;
        lblStep1LLAngleACM1.ReadOnly = false;
        lblStep1GroundTimeM1.ReadOnly = false;
        lblStep1AirTimeM1.ReadOnly = false;
        lblStep1StrideLengthM1.ReadOnly = false;
        lblStep2COGDistanceM1.ReadOnly = false;
        lblStep2LLAngleTakeoffM1.ReadOnly = false;
        lblStep2TrunkAngleTakeoffM1.ReadOnly = false;
        lblStep2LLAngleACM1.ReadOnly = false;
        lblStep2GroundTimeM1.ReadOnly = false;
        lblStep2AirTimeM1.ReadOnly = false;
        lblStep2StrideLengthM1.ReadOnly = false;
        lblStep3COGDistanceM1.ReadOnly = false;
        lblTimeTo3mM1.ReadOnly = false;
        lblTimeTo5mM1.ReadOnly = false;



        lblSetFrontBlockDistanceF.ReadOnly = false;
        lblSetRearBlockDistanceF.ReadOnly = false;
        lblSetFrontULAngleF.ReadOnly = false;
        lblSetRearULAngleF.ReadOnly = false;
        lblSetFrontLLAngleF.ReadOnly = false;
        lblSetRearLLAngleF.ReadOnly = false;
        lblSetTrunkAngleF.ReadOnly = false;
        lblSetCOGDistanceF.ReadOnly = false;

        lblBCRearFootClearanceTimeF.ReadOnly = false;
        lblBCFrontFootClearanceTimeF.ReadOnly = false;
        lblBCRearLLAngleTakeoffF.ReadOnly = false;
        lblBCFrontLLAngleTakeoffF.ReadOnly = false;
        lblBCTrunkAngleTakeoffF.ReadOnly = false;
        lblBCLLAngleACF.ReadOnly = false;
        lblBCAirTimeF.ReadOnly = false;
        lblBCStrideLengthF.ReadOnly = false;
        lblStep1COGDistanceF.ReadOnly = false;


        lblStep1LLAngleTakeoffF.ReadOnly = false;
        lblStep1TrunkAngleTakeoffF.ReadOnly = false;
        lblStep1LLAngleACF.ReadOnly = false;
        lblStep1GroundTimeF.ReadOnly = false;
        lblStep1AirTimeF.ReadOnly = false;
        lblStep1StrideLengthF.ReadOnly = false;
        lblStep2COGDistanceF.ReadOnly = false;
        lblStep2LLAngleTakeoffF.ReadOnly = false;
        lblStep2TrunkAngleTakeoffF.ReadOnly = false;
        lblStep2LLAngleACF.ReadOnly = false;
        lblStep2GroundTimeF.ReadOnly = false;
        lblStep2AirTimeF.ReadOnly = false;
        lblStep2StrideLengthF.ReadOnly = false;
        lblStep3COGDistanceF.ReadOnly = false;
        lblTimeTo3mF.ReadOnly = false;
        lblTimeTo5mF.ReadOnly = false;

        txtCBFrame1.ReadOnly = false;
        txtCBFrame2.ReadOnly = false;
        txtCBFrame3.ReadOnly = false;
        txtCBFrame4.ReadOnly = false;
        txtCBFrame5.ReadOnly = false;
        txtCBFrame6.ReadOnly = false;
        txtCBFrame7.ReadOnly = false;
        txtCBFrame8.ReadOnly = false;
        txtCBFrame9.ReadOnly = false;

        txtBFrame1.ReadOnly = false;
        txtBFrame2.ReadOnly = false;
        txtBFrame3.ReadOnly = false;
        txtBFrame4.ReadOnly = false;
        txtBFrame5.ReadOnly = false;
        txtBFrame6.ReadOnly = false;
        txtBFrame7.ReadOnly = false;
        txtBFrame8.ReadOnly = false;
        txtBFrame9.ReadOnly = false;

        txtDate.ReadOnly = false;
        txtTime.ReadOnly = false;
        txtLocation.ReadOnly = false;
        txtForCurrentVideo.ReadOnly = false;
        txtSumFilePath.ReadOnly = false;
        txtbFilePath.ReadOnly = false;
    }
    private void clearAllVariableData()
    {


        lblSetFrontBlockDistanceI.Text = "";
        lblSetRearBlockDistanceI.Text = "";
        lblSetFrontULAngleI.Text = "";
        lblSetRearULAngleI.Text = "";
        lblSetFrontLLAngleI.Text = "";
        lblSetRearLLAngleI.Text = "";
        lblSetTrunkAngleI.Text = "";
        lblSetCOGDistanceI.Text = "";

        lblBCRearFootClearanceTimeI.Text = "";
        lblBCFrontFootClearanceTimeI.Text = "";
        lblBCRearLLAngleTakeoffI.Text = "";
        lblBCFrontLLAngleTakeoffI.Text = "";
        lblBCTrunkAngleTakeoffI.Text = "";
        lblBCLLAngleACI.Text = "";
        lblBCAirTimeI.Text = "";
        lblBCStrideLengthI.Text = "";
        lblStep1COGDistanceI.Text = "";


        lblStep1LLAngleTakeoffI.Text = "";
        lblStep1TrunkAngleTakeoffI.Text = "";
        lblStep1LLAngleACI.Text = "";
        lblStep1GroundTimeI.Text = "";
        lblStep1AirTimeI.Text = "";
        lblStep1StrideLengthI.Text = "";
        lblStep2COGDistanceI.Text = "";
        lblStep2LLAngleTakeoffI.Text = "";
        lblStep2TrunkAngleTakeoffI.Text = "";
        lblStep2LLAngleACI.Text = "";
        lblStep2GroundTimeI.Text = "";
        lblStep2AirTimeI.Text = "";
        lblStep2StrideLengthI.Text = "";
        lblStep3COGDistanceI.Text = "";
        lblTimeTo3mI.Text = "";
        lblTimeTo5mI.Text = "";

        lblSetFrontBlockDistanceM1.Text = "";
        lblSetRearBlockDistanceM1.Text = "";
        lblSetFrontULAngleM1.Text = "";
        lblSetRearULAngleM1.Text = "";
        lblSetFrontLLAngleM1.Text = "";
        lblSetRearLLAngleM1.Text = "";
        lblSetTrunkAngleM1.Text = "";
        lblSetCOGDistanceM1.Text = "";

        lblBCRearFootClearanceTimeM1.Text = "";
        lblBCFrontFootClearanceTimeM1.Text = "";
        lblBCRearLLAngleTakeoffM1.Text = "";
        lblBCFrontLLAngleTakeoffM1.Text = "";
        lblBCTrunkAngleTakeoffM1.Text = "";
        lblBCLLAngleACM1.Text = "";
        lblBCAirTimeM1.Text = "";
        lblBCStrideLengthM1.Text = "";
        lblStep1COGDistanceM1.Text = "";


        lblStep1LLAngleTakeoffM1.Text = "";
        lblStep1TrunkAngleTakeoffM1.Text = "";
        lblStep1LLAngleACM1.Text = "";
        lblStep1GroundTimeM1.Text = "";
        lblStep1AirTimeM1.Text = "";
        lblStep1StrideLengthM1.Text = "";
        lblStep2COGDistanceM1.Text = "";
        lblStep2LLAngleTakeoffM1.Text = "";
        lblStep2TrunkAngleTakeoffM1.Text = "";
        lblStep2LLAngleACM1.Text = "";
        lblStep2GroundTimeM1.Text = "";
        lblStep2AirTimeM1.Text = "";
        lblStep2StrideLengthM1.Text = "";
        lblStep3COGDistanceM1.Text = "";
        lblTimeTo3mM1.Text = "";
        lblTimeTo5mM1.Text = "";



        lblSetFrontBlockDistanceF.Text = "";
        lblSetRearBlockDistanceF.Text = "";
        lblSetFrontULAngleF.Text = "";
        lblSetRearULAngleF.Text = "";
        lblSetFrontLLAngleF.Text = "";
        lblSetRearLLAngleF.Text = "";
        lblSetTrunkAngleF.Text = "";
        lblSetCOGDistanceF.Text = "";

        lblBCRearFootClearanceTimeF.Text = "";
        lblBCFrontFootClearanceTimeF.Text = "";
        lblBCRearLLAngleTakeoffF.Text = "";
        lblBCFrontLLAngleTakeoffF.Text = "";
        lblBCTrunkAngleTakeoffF.Text = "";
        lblBCLLAngleACF.Text = "";
        lblBCAirTimeF.Text = "";
        lblBCStrideLengthF.Text = "";
        lblStep1COGDistanceF.Text = "";


        lblStep1LLAngleTakeoffF.Text = "";
        lblStep1TrunkAngleTakeoffF.Text = "";
        lblStep1LLAngleACF.Text = "";
        lblStep1GroundTimeF.Text = "";
        lblStep1AirTimeF.Text = "";
        lblStep1StrideLengthF.Text = "";
        lblStep2COGDistanceF.Text = "";
        lblStep2LLAngleTakeoffF.Text = "";
        lblStep2TrunkAngleTakeoffF.Text = "";
        lblStep2LLAngleACF.Text = "";
        lblStep2GroundTimeF.Text = "";
        lblStep2AirTimeF.Text = "";
        lblStep2StrideLengthF.Text = "";
        lblStep3COGDistanceF.Text = "";
        lblTimeTo3mF.Text = "";
        lblTimeTo5mF.Text = "";

        txtCBFrame1.Text = "";
        txtCBFrame2.Text = "";
        txtCBFrame3.Text = "";
        txtCBFrame4.Text = "";
        txtCBFrame5.Text = "";
        txtCBFrame6.Text = "";
        txtCBFrame7.Text = "";
        txtCBFrame8.Text = "";
        txtCBFrame9.Text = "";

        txtBFrame1.Text = "";
        txtBFrame2.Text = "";
        txtBFrame3.Text = "";
        txtBFrame4.Text = "";
        txtBFrame5.Text = "";
        txtBFrame6.Text = "";
        txtBFrame7.Text = "";
        txtBFrame8.Text = "";
        txtBFrame9.Text = "";

        txtDate.Text = "";
        txtTime.Text = "";
        txtLocation.Text = "";
        txtForCurrentVideo.Text = "";
        txtSumFilePath.Text = "";
        txtbFilePath.Text = "";
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
            StartPageOnTrackSession startPageOnTrackSession = new StartPageOnTrackSession();
            startPageOnTrackSession.StartPageOnTrackSessionData(athleteSelected);
            string expression = "LessonTypeID = 1";
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
    void sendNotFoundEmail(int CurrentCnt, int initialcnt, int modelCnt)
    {
        var _initialMessage = "This initial variable has 0 values = ";
        var _modelMessage = "This model variable has 0 values = ";
        var _currentMessage = "This current variable has 0 values = ";
        var message = "";
        var dataMising = false;
        for (int i = 0; i < missingVariableStar.Count; i++)
        {
            dataMising = true;
            if (missingVariableStar[i].type == "initial" && initialcnt < 33)
            {
                _initialMessage += missingVariableStar[i].variableName + ", ";

            }
            if (missingVariableStar[i].type == "model" && modelCnt < 33)
            {
                _modelMessage += missingVariableStar[i].variableName + ", ";

            }
            if (missingVariableStar[i].type == "current" && CurrentCnt < 33)
            {
                _currentMessage += missingVariableStar[i].variableName + ", ";
            }
        }
        if (dataMising == true)
        {
            var lessiodatelocaon = (DropDownList2.SelectedItem.Text);
            message = "Session Details :- " + " Start " + " " + "->" + " " + lessiodatelocaon + "\n" + _initialMessage + "\n" + _modelMessage + "\n" + _currentMessage;
            var email = Membership.GetUser().Email;
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new System.Net.Mail.MailAddress(email);
         msg.To.Add("dev@Compusport.com");
            msg.Body = message;
            msg.Subject = "Compusport : " + Startcustomer.FirstName + " " + Startcustomer.LastName + " Data Missing";
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "198.143.141.120";
            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential("dev@compusport.com", "develop!?");
            smtp.Send(msg);
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
                        DataRow drVariable = ds.Tables[1].Rows[0];
                        #region[model data]
                        lblSetFrontBlockDistanceM1.Text = setVariableData(drVariable["SetFrontBlockDistance"].ToString());
                        lblSetRearBlockDistanceM1.Text = setVariableData(drVariable["SetRearBlockDistance"].ToString());
                        lblSetFrontULAngleM1.Text = setVariableData(drVariable["SetFrontULAngle"].ToString());
                        lblSetRearULAngleM1.Text = setVariableData(drVariable["SetRearULAngle"].ToString());
                        lblSetFrontLLAngleM1.Text = setVariableData(drVariable["SetFrontLLAngle"].ToString());
                        lblSetRearLLAngleM1.Text = setVariableData(drVariable["SetRearLLAngle"].ToString());
                        lblSetTrunkAngleM1.Text = setVariableData(drVariable["SetTrunkAngle"].ToString());
                        lblSetCOGDistanceM1.Text = setVariableData(drVariable["SetCOGDistance"].ToString());
                        lblBCRearFootClearanceTimeM1.Text = setVariableData(drVariable["BCRearFootClearanceTime"].ToString());
                        lblBCFrontFootClearanceTimeM1.Text = setVariableData(drVariable["BCFrontFootClearanceTime"].ToString());
                        lblBCRearLLAngleTakeoffM1.Text = setVariableData(drVariable["BCRearLLAngleTakeoff"].ToString());
                        lblBCFrontLLAngleTakeoffM1.Text = setVariableData(drVariable["BCFrontLLAngleTakeoff"].ToString());
                        lblBCTrunkAngleTakeoffM1.Text = setVariableData(drVariable["BCTrunkAngleTakeoff"].ToString());
                        lblBCLLAngleACM1.Text = setVariableData(drVariable["BCLLAngleAC"].ToString());
                        lblBCAirTimeM1.Text = setVariableData(drVariable["BCAirTime"].ToString());
                        lblBCStrideLengthM1.Text = setVariableData(drVariable["BC Stride Length"].ToString());
                        lblStep1COGDistanceM1.Text = setVariableData(drVariable["Step1COGDistance"].ToString());
                        lblStep1LLAngleTakeoffM1.Text = setVariableData(drVariable["Step1LLAngleTakeoff"].ToString());
                        lblStep1TrunkAngleTakeoffM1.Text = setVariableData(drVariable["Step1TrunkAngleTakeoff"].ToString());
                        lblStep1LLAngleACM1.Text = setVariableData(drVariable["Step1LLAngleAC"].ToString());
                        lblStep1GroundTimeM1.Text = setVariableData(drVariable["Step1GroundTime"].ToString());
                        lblStep1AirTimeM1.Text = setVariableData(drVariable["Step1AirTime"].ToString());
                        lblStep1StrideLengthM1.Text = setVariableData(drVariable["Step1StrideLength"].ToString());
                        lblStep2COGDistanceM1.Text = setVariableData(drVariable["Step2COGDistance"].ToString());
                        lblStep2LLAngleTakeoffM1.Text = setVariableData(drVariable["Step2LLAngleTakeoff"].ToString());
                        lblStep2TrunkAngleTakeoffM1.Text = setVariableData(drVariable["Step2TrunkAngleTakeoff"].ToString());
                        lblStep2LLAngleACM1.Text = setVariableData(drVariable["Step2LLAngleAC"].ToString());
                        lblStep2GroundTimeM1.Text = setVariableData(drVariable["Step2GroundTime"].ToString());
                        lblStep2AirTimeM1.Text = setVariableData(drVariable["Step2AirTime"].ToString());
                        lblStep2StrideLengthM1.Text = setVariableData(drVariable["Step2StrideLength"].ToString());
                        lblStep3COGDistanceM1.Text = setVariableData(drVariable["Step3COGDistance"].ToString());
                        lblTimeTo3mM1.Text = setVariableData(drVariable["TimeTo3m"].ToString());
                        lblTimeTo5mM1.Text = setVariableData(drVariable["TimeTo5m"].ToString());
                        #endregion[model data]
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
        if (vairableValue == "" || vairableValue == "0.000" || vairableValue == "0" || vairableValue == "-0" || vairableValue == "-0.000")
        {
            vairableValue = "";
        }
        return vairableValue;
    }

    List<MissingVariable> missingVariableStar = new List<MissingVariable>();

    public void GetAllStartAthleteDataInitailNdCorrent(int lessonid)
    {

        ds = sae.GetAllStartAthletesData(lessonid);
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                //MissingVariableStart misv = new MissingVariableStart();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //misv.type = "initial";
                    DataRow drVariable = ds.Tables[0].Rows[0];
                    #region[initial data]
                    lblSetFrontBlockDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetFrontBlockDistance"].ToString());
                    if (lblSetFrontBlockDistanceI.Text == "" || lblSetFrontBlockDistanceI.Text == "0.000" || lblSetFrontBlockDistanceI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";

                        lblSetFrontBlockDistanceI.Text = "";
                        misv.variableName = "SetFrontBlockDistance";
                        missingVariableStar.Add(misv);
                    }
                    lblSetRearBlockDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetRearBlockDistance"].ToString());
                    if (lblSetRearBlockDistanceI.Text == "" || lblSetRearBlockDistanceI.Text == "0.000" || lblSetRearBlockDistanceI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblSetRearBlockDistanceI.Text = "";
                        misv.variableName = "SetRearBlockDistance";
                        missingVariableStar.Add(misv);
                    }
                    lblSetFrontULAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetFrontULAngle"].ToString());
                    if (lblSetFrontULAngleI.Text == "" || lblSetFrontULAngleI.Text == "0.000" || lblSetFrontULAngleI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblSetFrontULAngleI.Text = "";
                        misv.variableName = "SetFrontULAngle";
                        missingVariableStar.Add(misv);
                    }
                    lblSetRearULAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetRearULAngle"].ToString());
                    if (lblSetRearULAngleI.Text == "" || lblSetRearULAngleI.Text == "0.000" || lblSetRearULAngleI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblSetRearULAngleI.Text = "";
                        misv.variableName = "SetRearULAngle";
                        missingVariableStar.Add(misv);
                    }
                    lblSetFrontLLAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetFrontLLAngle"].ToString());
                    if (lblSetFrontLLAngleI.Text == "" || lblSetFrontLLAngleI.Text == "0.000" || lblSetFrontLLAngleI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblSetFrontLLAngleI.Text = "";
                        misv.variableName = "SetFrontLLAngle";
                        missingVariableStar.Add(misv);
                    }
                    lblSetRearLLAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetRearLLAngle"].ToString());
                    if (lblSetRearLLAngleI.Text == "" || lblSetRearLLAngleI.Text == "0.000" || lblSetRearLLAngleI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblSetRearLLAngleI.Text = "";
                        misv.variableName = "SetRearLLAngle";
                        missingVariableStar.Add(misv);
                    }
                    lblSetTrunkAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetTrunkAngle"].ToString());
                    if (lblSetTrunkAngleI.Text == "" || lblSetTrunkAngleI.Text == "0.000" || lblSetTrunkAngleI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblSetTrunkAngleI.Text = "";
                        misv.variableName = "SetTrunkAngle";
                        missingVariableStar.Add(misv);
                    }
                    lblSetCOGDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetCOGDistance"].ToString());
                    if (lblSetCOGDistanceI.Text == "" || lblSetCOGDistanceI.Text == "0.000" || lblSetCOGDistanceI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblSetCOGDistanceI.Text = "";
                        misv.variableName = "SetCOGDistance";
                        missingVariableStar.Add(misv);
                    }
                    lblBCRearFootClearanceTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCRearFootClearanceTime"].ToString());
                    if (lblBCRearFootClearanceTimeI.Text == "" || lblBCRearFootClearanceTimeI.Text == "0.000" || lblBCRearFootClearanceTimeI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblBCRearFootClearanceTimeI.Text = "";
                        misv.variableName = "BCRearFootClearanceTime";
                        missingVariableStar.Add(misv);
                    }
                    lblBCFrontFootClearanceTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCFrontFootClearanceTime"].ToString());
                    if (lblBCFrontFootClearanceTimeI.Text == "" || lblBCFrontFootClearanceTimeI.Text == "0.000" || lblBCFrontFootClearanceTimeI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblBCFrontFootClearanceTimeI.Text = "";
                        misv.variableName = "BCFrontFootClearanceTime";
                        missingVariableStar.Add(misv);
                    }
                    lblBCRearLLAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCRearLLAngleTakeoff"].ToString());
                    if (lblBCRearLLAngleTakeoffI.Text == "" || lblBCRearLLAngleTakeoffI.Text == "0.000" || lblBCRearLLAngleTakeoffI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblBCRearLLAngleTakeoffI.Text = "";
                        misv.variableName = "BCRearLLAngleTakeoff";
                        missingVariableStar.Add(misv);
                    }
                    lblBCFrontLLAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCFrontLLAngleTakeoff"].ToString());
                    if (lblBCFrontLLAngleTakeoffI.Text == "" || lblBCFrontLLAngleTakeoffI.Text == "0.000" || lblBCFrontLLAngleTakeoffI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblBCFrontLLAngleTakeoffI.Text = "";
                        misv.variableName = "BCFrontLLAngleTakeoff";
                        missingVariableStar.Add(misv);
                    }
                    lblBCTrunkAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCTrunkAngleTakeoff"].ToString());
                    if (lblBCTrunkAngleTakeoffI.Text == "" || lblBCTrunkAngleTakeoffI.Text == "0.000" || lblBCTrunkAngleTakeoffI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblBCTrunkAngleTakeoffI.Text = "";
                        misv.variableName = "BCTrunkAngleTakeoff";
                        missingVariableStar.Add(misv);
                    }
                    lblBCLLAngleACI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCLLAngleAC"].ToString());
                    if (lblBCLLAngleACI.Text == "" || lblBCLLAngleACI.Text == "0.000" || lblBCLLAngleACI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblBCLLAngleACI.Text = "";
                        misv.variableName = "BCLLAngleAC";
                        missingVariableStar.Add(misv);
                    }
                    lblBCAirTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCAirTime"].ToString());
                    if (lblBCAirTimeI.Text == "" || lblBCAirTimeI.Text == "0.000" || lblBCAirTimeI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblBCAirTimeI.Text = "";
                        misv.variableName = "BCAirTime";
                        missingVariableStar.Add(misv);
                    }
                    lblBCStrideLengthI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCStrideLength"].ToString());
                    if (lblBCStrideLengthI.Text == "" || lblBCStrideLengthI.Text == "0.000" || lblBCStrideLengthI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblBCStrideLengthI.Text = "";
                        misv.variableName = "BCStrideLength";
                        missingVariableStar.Add(misv);
                    }
                    lblStep1COGDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1COGDistance"].ToString());
                    if (lblStep1COGDistanceI.Text == "" || lblStep1COGDistanceI.Text == "0.000" || lblStep1COGDistanceI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep1COGDistanceI.Text = "";
                        misv.variableName = "Step1COGDistance";
                        missingVariableStar.Add(misv);
                    }
                    lblStep1LLAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1LLAngleTakeoff"].ToString());
                    if (lblStep1LLAngleTakeoffI.Text == "" || lblStep1LLAngleTakeoffI.Text == "0.000" || lblStep1LLAngleTakeoffI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep1LLAngleTakeoffI.Text = "";
                        misv.variableName = "Step1LLAngleTakeoff";
                        missingVariableStar.Add(misv);
                    }
                    lblStep1TrunkAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1TrunkAngleTakeoff"].ToString());
                    if (lblStep1TrunkAngleTakeoffI.Text == "" || lblStep1TrunkAngleTakeoffI.Text == "0.000" || lblStep1TrunkAngleTakeoffI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep1TrunkAngleTakeoffI.Text = "";
                        misv.variableName = "Step1TrunkAngleTakeoff";
                        missingVariableStar.Add(misv);
                    }
                    lblStep1LLAngleACI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1LLAngleAC"].ToString());
                    if (lblStep1LLAngleACI.Text == "" || lblStep1LLAngleACI.Text == "0.000" || lblStep1LLAngleACI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep1LLAngleACI.Text = "";
                        misv.variableName = "Step1LLAngleAC";
                        missingVariableStar.Add(misv);
                    }
                    lblStep1GroundTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1GroundTime"].ToString());
                    if (lblStep1GroundTimeI.Text == "" || lblStep1GroundTimeI.Text == "0.000" || lblStep1GroundTimeI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep1GroundTimeI.Text = "";
                        misv.variableName = "Step1GroundTime";
                        missingVariableStar.Add(misv);
                    }
                    lblStep1AirTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1AirTime"].ToString());
                    if (lblStep1AirTimeI.Text == "" || lblStep1AirTimeI.Text == "0.000" || lblStep1AirTimeI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep1AirTimeI.Text = "";
                        misv.variableName = "Step1AirTime";
                        missingVariableStar.Add(misv);
                    }
                    lblStep1StrideLengthI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1StrideLength"].ToString());
                    if (lblStep1StrideLengthI.Text == "" || lblStep1StrideLengthI.Text == "0.000" || lblStep1StrideLengthI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep1StrideLengthI.Text = "";
                        misv.variableName = "Step1StrideLength";
                        missingVariableStar.Add(misv);
                    }
                    lblStep2COGDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2COGDistance"].ToString());
                    if (lblStep2COGDistanceI.Text == "" || lblStep2COGDistanceI.Text == "0.000" || lblStep2COGDistanceI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep2COGDistanceI.Text = "";
                        misv.variableName = "Step2COGDistance";
                        missingVariableStar.Add(misv);
                    }
                    lblStep2LLAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2LLAngleTakeoff"].ToString());
                    if (lblStep2LLAngleTakeoffI.Text == "" || lblStep2LLAngleTakeoffI.Text == "0.000" || lblStep2LLAngleTakeoffI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep2LLAngleTakeoffI.Text = "";
                        misv.variableName = "Step2LLAngleTakeoff";
                        missingVariableStar.Add(misv);
                    }
                    lblStep2TrunkAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2TrunkAngleTakeoff"].ToString());
                    if (lblStep2TrunkAngleTakeoffI.Text == "" || lblStep2TrunkAngleTakeoffI.Text == "0.000" || lblStep2TrunkAngleTakeoffI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep2TrunkAngleTakeoffI.Text = "";
                        misv.variableName = "Step2TrunkAngleTakeoff";
                        missingVariableStar.Add(misv);
                    }
                    lblStep2LLAngleACI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2LLAngleAC"].ToString());
                    if (lblStep2LLAngleACI.Text == "" || lblStep2LLAngleACI.Text == "0.000" || lblStep2LLAngleACI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep2LLAngleACI.Text = "";
                        misv.variableName = "Step2LLAngleAC";
                        missingVariableStar.Add(misv);
                    }
                    lblStep2GroundTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2GroundTime"].ToString());
                    if (lblStep2GroundTimeI.Text == "" || lblStep2GroundTimeI.Text == "0.000" || lblStep2GroundTimeI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep2GroundTimeI.Text = "";
                        misv.variableName = "Step2GroundTime";
                        missingVariableStar.Add(misv);
                    }
                    lblStep2AirTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2AirTime"].ToString());
                    if (lblStep2AirTimeI.Text == "" || lblStep2AirTimeI.Text == "0.000" || lblStep2AirTimeI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep2AirTimeI.Text = "";
                        misv.variableName = "Step2AirTime";
                        missingVariableStar.Add(misv);
                    }
                    lblStep2StrideLengthI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2StrideLength"].ToString());
                    if (lblStep2StrideLengthI.Text == "" || lblStep2StrideLengthI.Text == "0.000" || lblStep2StrideLengthI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep2StrideLengthI.Text = "";
                        misv.variableName = "Step2StrideLength";
                        missingVariableStar.Add(misv);
                    }
                    lblStep3COGDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3COGDistance"].ToString());
                    if (lblStep3COGDistanceI.Text == "" || lblStep3COGDistanceI.Text == "0.000" || lblStep3COGDistanceI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep3COGDistanceI.Text = "";
                        misv.variableName = "Step3COGDistance";
                        missingVariableStar.Add(misv);
                    }
                    lblTimeTo3mI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TimeTo3m"].ToString());
                    if (lblTimeTo3mI.Text == "" || lblTimeTo3mI.Text == "0.000" || lblTimeTo3mI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblTimeTo3mI.Text = "";
                        misv.variableName = "TimeTo3m";
                        missingVariableStar.Add(misv);
                    }
                    lblTimeTo5mI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TimeTo5m"].ToString());
                    if (lblTimeTo5mI.Text == "" || lblTimeTo5mI.Text == "0.000" || lblTimeTo5mI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblTimeTo5mI.Text = "";
                        misv.variableName = "TimeTo5m";
                        missingVariableStar.Add(misv);
                    }
                    #endregion[initial data]
                }
                if (ds.Tables[2].Rows.Count > 0)
                {

                    //misv = new MissingVariableStart();

                    DataRow drVariable = ds.Tables[2].Rows[0];
                    #region[final data]
                    lblSetFrontBlockDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetFrontBlockDistance"].ToString());
                    if (lblSetFrontBlockDistanceF.Text == "" || lblSetFrontBlockDistanceF.Text == "0.000" || lblSetFrontBlockDistanceF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblSetFrontBlockDistanceF.Text = "";
                        misv.variableName = "SetFrontBlockDistance";
                        missingVariableStar.Add(misv);
                    }
                    lblSetRearBlockDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetRearBlockDistance"].ToString());
                    if (lblSetRearBlockDistanceF.Text == "" || lblSetRearBlockDistanceF.Text == "0.000" || lblSetRearBlockDistanceF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblSetRearBlockDistanceF.Text = "";
                        misv.variableName = "SetRearBlockDistance";
                        missingVariableStar.Add(misv);
                    }
                    lblSetFrontULAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetFrontULAngle"].ToString());
                    if (lblSetFrontULAngleF.Text == "" || lblSetFrontULAngleF.Text == "0.000" || lblSetFrontULAngleF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblSetFrontULAngleF.Text = "";
                        misv.variableName = "SetFrontULAngle";
                        missingVariableStar.Add(misv);
                    }
                    lblSetRearULAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetRearULAngle"].ToString());
                    if (lblSetRearULAngleF.Text == "" || lblSetRearULAngleF.Text == "0.000" || lblSetRearULAngleF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblSetRearULAngleF.Text = "";
                        misv.variableName = "SetRearULAngle";
                        missingVariableStar.Add(misv);
                    }

                    lblSetFrontLLAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetFrontLLAngle"].ToString());
                    if (lblSetFrontLLAngleF.Text == "" || lblSetFrontLLAngleF.Text == "0.000" || lblSetFrontLLAngleF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblSetFrontLLAngleF.Text = "";
                        misv.variableName = "SetFrontLLAngle";
                        missingVariableStar.Add(misv);
                    }
                    lblSetRearLLAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetRearLLAngle"].ToString());
                    if (lblSetRearLLAngleF.Text == "" || lblSetRearLLAngleF.Text == "0.000" || lblSetRearLLAngleF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblSetRearLLAngleF.Text = "";
                        misv.variableName = "SetRearLLAngle";
                        missingVariableStar.Add(misv);
                    }
                    lblSetTrunkAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetTrunkAngle"].ToString());
                    if (lblSetTrunkAngleF.Text == "" || lblSetTrunkAngleF.Text == "0.000" || lblSetTrunkAngleF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblSetTrunkAngleF.Text = "";
                        misv.variableName = "SetTrunkAngle";
                        missingVariableStar.Add(misv);
                    }
                    lblSetCOGDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetCOGDistance"].ToString());
                    if (lblSetCOGDistanceF.Text == "" || lblSetCOGDistanceF.Text == "0.000" || lblSetCOGDistanceF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblSetCOGDistanceF.Text = "";
                        misv.variableName = "SetCOGDistance";
                        missingVariableStar.Add(misv);
                    }
                    lblBCRearFootClearanceTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCRearFootClearanceTime"].ToString());
                    if (lblBCRearFootClearanceTimeF.Text == "" || lblBCRearFootClearanceTimeF.Text == "0.000" || lblBCRearFootClearanceTimeF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblBCRearFootClearanceTimeF.Text = "";
                        misv.variableName = "BCRearFootClearanceTime";
                        missingVariableStar.Add(misv);
                    }
                    lblBCFrontFootClearanceTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCFrontFootClearanceTime"].ToString());
                    if (lblSetFrontBlockDistanceF.Text == "" || lblSetFrontBlockDistanceF.Text == "0.000" || lblSetFrontBlockDistanceF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblBCFrontFootClearanceTimeF.Text = "";
                        misv.variableName = "BCFrontFootClearanceTime";
                        missingVariableStar.Add(misv);
                    }
                    lblBCRearLLAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCRearLLAngleTakeoff"].ToString());
                    if (lblBCRearLLAngleTakeoffF.Text == "" || lblBCRearLLAngleTakeoffF.Text == "0.000" || lblBCRearLLAngleTakeoffF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblBCRearLLAngleTakeoffF.Text = "";
                        misv.variableName = "BCRearLLAngleTakeoff";
                        missingVariableStar.Add(misv);
                    }
                    lblBCFrontLLAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCFrontLLAngleTakeoff"].ToString());
                    if (lblBCFrontLLAngleTakeoffF.Text == "" || lblBCFrontLLAngleTakeoffF.Text == "0.000" || lblBCFrontLLAngleTakeoffF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblBCFrontLLAngleTakeoffF.Text = "";
                        misv.variableName = "BCFrontLLAngleTakeoff";
                        missingVariableStar.Add(misv);
                    }
                    lblBCTrunkAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCTrunkAngleTakeoff"].ToString());
                    if (lblBCTrunkAngleTakeoffF.Text == "" || lblBCTrunkAngleTakeoffF.Text == "0.000" || lblBCTrunkAngleTakeoffF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblBCTrunkAngleTakeoffF.Text = "";
                        misv.variableName = "BCTrunkAngleTakeoff";
                        missingVariableStar.Add(misv);
                    }
                    lblBCLLAngleACF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLLAngleAC"].ToString());
                    if (lblBCLLAngleACF.Text == "" || lblBCLLAngleACF.Text == "0.000" || lblBCLLAngleACF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblBCLLAngleACF.Text = "";
                        misv.variableName = "BCLLAngleAC";
                        missingVariableStar.Add(misv);
                    }
                    lblBCAirTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCAirTime"].ToString());
                    if (lblBCAirTimeF.Text == "" || lblBCAirTimeF.Text == "0.000" || lblBCAirTimeF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblBCAirTimeF.Text = "";
                        misv.variableName = "BCAirTime";
                        missingVariableStar.Add(misv);
                    }
                    lblBCStrideLengthF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCStrideLength"].ToString());
                    if (lblBCStrideLengthF.Text == "" || lblBCStrideLengthF.Text == "0.000" || lblBCStrideLengthF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblBCStrideLengthF.Text = "";
                        misv.variableName = "BCStrideLength";
                        missingVariableStar.Add(misv);
                    }
                    lblStep1COGDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1COGDistance"].ToString());
                    if (lblStep1COGDistanceF.Text == "" || lblStep1COGDistanceF.Text == "0.000" || lblStep1COGDistanceF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep1COGDistanceF.Text = "";
                        misv.variableName = "Step1COGDistance";
                        missingVariableStar.Add(misv);
                    }
                    lblStep1LLAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1LLAngleTakeoff"].ToString());
                    if (lblStep1LLAngleTakeoffF.Text == "" || lblStep1LLAngleTakeoffF.Text == "0.000" || lblStep1LLAngleTakeoffF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep1LLAngleTakeoffF.Text = "";
                        misv.variableName = "Step1LLAngleTakeoff";
                        missingVariableStar.Add(misv);
                    }
                    lblStep1TrunkAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1TrunkAngleTakeoff"].ToString());
                    if (lblStep1TrunkAngleTakeoffF.Text == "" || lblStep1TrunkAngleTakeoffF.Text == "0.000" || lblStep1TrunkAngleTakeoffF.Text == "" || lblStep1TrunkAngleTakeoffF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep1TrunkAngleTakeoffF.Text = "";
                        misv.variableName = "Step1TrunkAngleTakeoff";
                        missingVariableStar.Add(misv);
                    }
                    lblStep1LLAngleACF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1LLAngleAC"].ToString());
                    if (lblStep1LLAngleACF.Text == "" || lblStep1LLAngleACF.Text == "0.000" || lblStep1LLAngleACF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep1LLAngleACF.Text = "";
                        misv.variableName = "Step1LLAngleAC";
                        missingVariableStar.Add(misv);
                    }
                    lblStep1GroundTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1GroundTime"].ToString());
                    if (lblStep1GroundTimeF.Text == "" || lblStep1GroundTimeF.Text == "0.000" || lblStep1GroundTimeF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep1GroundTimeF.Text = "";
                        misv.variableName = "Step1GroundTime";
                        missingVariableStar.Add(misv);
                    }
                    lblStep1AirTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1AirTime"].ToString());
                    if (lblStep1AirTimeF.Text == "" || lblStep1AirTimeF.Text == "0.000" || lblStep1AirTimeF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep1AirTimeF.Text = "";
                        misv.variableName = "Step1AirTime";
                        missingVariableStar.Add(misv);
                    }
                    lblStep1StrideLengthF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1StrideLength"].ToString());
                    if (lblStep1StrideLengthF.Text == "" || lblStep1StrideLengthF.Text == "0.000" || lblStep1StrideLengthF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep1StrideLengthF.Text = "";
                        misv.variableName = "Step1StrideLength";
                        missingVariableStar.Add(misv);
                    }
                    lblStep2COGDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2COGDistance"].ToString());
                    if (lblStep2COGDistanceF.Text == "" || lblStep2COGDistanceF.Text == "0.000" || lblStep2COGDistanceF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep2COGDistanceF.Text = "";
                        misv.variableName = "Step2COGDistance";
                        missingVariableStar.Add(misv);
                    }
                    lblStep2LLAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2LLAngleTakeoff"].ToString());
                    if (lblStep2LLAngleTakeoffF.Text == "" || lblStep2LLAngleTakeoffF.Text == "0.000" || lblStep2LLAngleTakeoffF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep2LLAngleTakeoffF.Text = "";
                        misv.variableName = "Step2LLAngleTakeoff";
                        missingVariableStar.Add(misv);
                    }
                    lblStep2TrunkAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2TrunkAngleTakeoff"].ToString());
                    if (lblStep2TrunkAngleTakeoffF.Text == "" || lblStep2TrunkAngleTakeoffF.Text == "0.000" || lblStep2TrunkAngleTakeoffF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep2TrunkAngleTakeoffF.Text = "";
                        misv.variableName = "Step2TrunkAngleTakeoff";
                        missingVariableStar.Add(misv);
                    }
                    lblStep2LLAngleACF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2LLAngleAC"].ToString());
                    if (lblStep2LLAngleACF.Text == "" || lblStep2LLAngleACF.Text == "0.000" || lblStep2LLAngleACF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep2LLAngleACF.Text = "";
                        misv.variableName = "Step2LLAngleAC";
                        missingVariableStar.Add(misv);
                    }
                    lblStep2GroundTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2GroundTime"].ToString());
                    if (lblStep2GroundTimeF.Text == "" || lblStep2GroundTimeF.Text == "0.000" || lblStep2GroundTimeF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep2GroundTimeF.Text = "";
                        misv.variableName = "Step2GroundTime";
                        missingVariableStar.Add(misv);
                    }
                    lblStep2AirTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2AirTime"].ToString());
                    if (lblStep2AirTimeF.Text == "" || lblStep2AirTimeF.Text == "0.000" || lblStep2AirTimeF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep2AirTimeF.Text = "";
                        misv.variableName = "Step2AirTime";
                        missingVariableStar.Add(misv);
                    }
                    lblStep2StrideLengthF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2StrideLength"].ToString());
                    if (lblStep2StrideLengthF.Text == "" || lblStep2StrideLengthF.Text == "0.000" || lblStep2StrideLengthF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep2StrideLengthF.Text = "";
                        misv.variableName = "Step2StrideLength";
                        missingVariableStar.Add(misv);
                    }
                    lblStep3COGDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3COGDistance"].ToString());
                    if (lblStep3COGDistanceF.Text == "" || lblStep3COGDistanceF.Text == "0.000" || lblStep3COGDistanceF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep3COGDistanceF.Text = "";
                        misv.variableName = "Step3COGDistance";
                        missingVariableStar.Add(misv);
                    }
                    lblTimeTo3mF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TimeTo3m"].ToString());
                    if (lblTimeTo3mF.Text == "" || lblTimeTo3mF.Text == "0.000" || lblTimeTo3mF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblTimeTo3mF.Text = "";
                        misv.variableName = "TimeTo3m";
                        missingVariableStar.Add(misv);
                    }
                    lblTimeTo5mF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TimeTo5m"].ToString());
                    if (lblTimeTo5mF.Text == "" || lblTimeTo5mF.Text == "0.000" || lblTimeTo5mF.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblTimeTo5mF.Text = "";
                        misv.variableName = "TimeTo5m";
                        missingVariableStar.Add(misv);
                    }
                    #endregion[final data]
                }
                //sendNotFoundEmail();
            }
        }
    }
    public void GetAllStartAthleteData(int lessonid)
    {

        ds = sae.GetAllStartAthletesData(lessonid);
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
                    #region[initial data]
                    lblSetFrontBlockDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetFrontBlockDistance"].ToString());
                    decimal SetFrontBlockDistance;
                    decimal.TryParse(ds.Tables[0].Rows[0]["SetFrontBlockDistance"].ToString(), out SetFrontBlockDistance);
                    if (SetFrontBlockDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblSetFrontBlockDistanceI.Text = "";
                        misv.variableName = "SetFrontBlockDistance";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblSetRearBlockDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetRearBlockDistance"].ToString());
                    // if (lblSetRearBlockDistanceI.Text == "" || lblSetRearBlockDistanceI.Text == "0.000" || lblSetRearBlockDistanceI.Text == "0")
                    decimal SetRearBlockDistance;
                    decimal.TryParse(ds.Tables[0].Rows[0]["SetRearBlockDistance"].ToString(), out SetRearBlockDistance);
                    if (SetRearBlockDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblSetRearBlockDistanceI.Text = "";
                        misv.variableName = "SetRearBlockDistance";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblSetFrontULAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetFrontULAngle"].ToString());
                    //if (lblSetFrontULAngleI.Text == "" || lblSetFrontULAngleI.Text == "0.000" || lblSetFrontULAngleI.Text == "0")
                    decimal SetFrontULAngle;
                    decimal.TryParse(ds.Tables[0].Rows[0]["SetFrontULAngle"].ToString(), out SetFrontULAngle);
                    if (SetFrontULAngle == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblSetFrontULAngleI.Text = "";
                        misv.variableName = "SetFrontULAngle";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblSetRearULAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetRearULAngle"].ToString());
                    // if (lblSetRearULAngleI.Text == "" || lblSetRearULAngleI.Text == "0.000" || lblSetRearULAngleI.Text == "0")
                    decimal SetRearULAngle;
                    decimal.TryParse(ds.Tables[0].Rows[0]["SetRearULAngle"].ToString(), out SetRearULAngle);
                    if (SetRearULAngle == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblSetRearULAngleI.Text = "";
                        misv.variableName = "SetRearULAngle";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblSetFrontLLAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetFrontLLAngle"].ToString());
                    //  if (lblSetFrontLLAngleI.Text == "" || lblSetFrontLLAngleI.Text == "0.000" || lblSetFrontLLAngleI.Text == "0")
                    decimal SetFrontLLAngle;
                    decimal.TryParse(ds.Tables[0].Rows[0]["SetFrontLLAngle"].ToString(), out SetFrontLLAngle);
                    if (SetFrontLLAngle == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblSetFrontLLAngleI.Text = "";
                        misv.variableName = "SetFrontLLAngle";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblSetRearLLAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetRearLLAngle"].ToString());
                    //  if (lblSetRearLLAngleI.Text == "" || lblSetRearLLAngleI.Text == "0.000" || lblSetRearLLAngleI.Text == "0")
                    decimal SetRearLLAngle;
                    decimal.TryParse(ds.Tables[0].Rows[0]["SetRearLLAngle"].ToString(), out SetRearLLAngle);
                    if (SetRearLLAngle == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblSetRearLLAngleI.Text = "";
                        misv.variableName = "SetRearLLAngle";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblSetTrunkAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetTrunkAngle"].ToString());
                    // if (lblSetTrunkAngleI.Text == "" || lblSetTrunkAngleI.Text == "0.000" || lblSetTrunkAngleI.Text == "0")
                    decimal SetTrunkAngle;
                    decimal.TryParse(ds.Tables[0].Rows[0]["SetTrunkAngle"].ToString(), out SetTrunkAngle);
                    if (SetTrunkAngle == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblSetTrunkAngleI.Text = "";
                        misv.variableName = "SetTrunkAngle";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblSetCOGDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetCOGDistance"].ToString());
                    //  if (lblSetCOGDistanceI.Text == "" || lblSetCOGDistanceI.Text == "0.000" || lblSetCOGDistanceI.Text == "0")
                    decimal SetCOGDistance;
                    decimal.TryParse(ds.Tables[0].Rows[0]["SetCOGDistance"].ToString(), out SetCOGDistance);
                    if (SetCOGDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblSetCOGDistanceI.Text = "";
                        misv.variableName = "SetCOGDistance";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblBCRearFootClearanceTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCRearFootClearanceTime"].ToString());
                    //  if (lblBCRearFootClearanceTimeI.Text == "" || lblBCRearFootClearanceTimeI.Text == "0.000" || lblBCRearFootClearanceTimeI.Text == "0")
                    decimal BCRearFootClearanceTime;
                    decimal.TryParse(ds.Tables[0].Rows[0]["BCRearFootClearanceTime"].ToString(), out BCRearFootClearanceTime);
                    if (BCRearFootClearanceTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblBCRearFootClearanceTimeI.Text = "";
                        misv.variableName = "BCRearFootClearanceTime";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblBCFrontFootClearanceTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCFrontFootClearanceTime"].ToString());
                    //    if (lblBCFrontFootClearanceTimeI.Text == "" || lblBCFrontFootClearanceTimeI.Text == "0.000" || lblBCFrontFootClearanceTimeI.Text == "0")
                    decimal BCFrontFootClearanceTime;
                    decimal.TryParse(ds.Tables[0].Rows[0]["BCFrontFootClearanceTime"].ToString(), out BCFrontFootClearanceTime);
                    if (BCFrontFootClearanceTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblBCFrontFootClearanceTimeI.Text = "";
                        misv.variableName = "BCFrontFootClearanceTime";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblBCRearLLAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCRearLLAngleTakeoff"].ToString());
                    // if (lblBCRearLLAngleTakeoffI.Text == "" || lblBCRearLLAngleTakeoffI.Text == "0.000" || lblBCRearLLAngleTakeoffI.Text == "0")
                    decimal BCRearLLAngleTakeoff;
                    decimal.TryParse(ds.Tables[0].Rows[0]["BCRearLLAngleTakeoff"].ToString(), out BCRearLLAngleTakeoff);
                    if (BCRearLLAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblBCRearLLAngleTakeoffI.Text = "";
                        misv.variableName = "BCRearLLAngleTakeoff";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblBCFrontLLAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCFrontLLAngleTakeoff"].ToString());
                    // if (lblBCFrontLLAngleTakeoffI.Text == "" || lblBCFrontLLAngleTakeoffI.Text == "0.000" || lblBCFrontLLAngleTakeoffI.Text == "0")
                    decimal BCFrontLLAngleTakeoff;
                    decimal.TryParse(ds.Tables[0].Rows[0]["BCFrontLLAngleTakeoff"].ToString(), out BCFrontLLAngleTakeoff);
                    if (BCFrontLLAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblBCFrontLLAngleTakeoffI.Text = "";
                        misv.variableName = "BCFrontLLAngleTakeoff";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblBCTrunkAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCTrunkAngleTakeoff"].ToString());
                    //  if (lblBCTrunkAngleTakeoffI.Text == "" || lblBCTrunkAngleTakeoffI.Text == "0.000" || lblBCTrunkAngleTakeoffI.Text == "0")
                    decimal BCTrunkAngleTakeoff;
                    decimal.TryParse(ds.Tables[0].Rows[0]["BCTrunkAngleTakeoff"].ToString(), out BCTrunkAngleTakeoff);
                    if (BCTrunkAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblBCTrunkAngleTakeoffI.Text = "";
                        misv.variableName = "BCTrunkAngleTakeoff";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblBCLLAngleACI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCLLAngleAC"].ToString());
                    //   if (lblBCLLAngleACI.Text == "" || lblBCLLAngleACI.Text == "0.000" || lblBCLLAngleACI.Text == "0")
                    decimal BCLLAngleAC;
                    decimal.TryParse(ds.Tables[0].Rows[0]["BCLLAngleAC"].ToString(), out BCLLAngleAC);
                    if (BCLLAngleAC == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblBCLLAngleACI.Text = "";
                        misv.variableName = "BCLLAngleAC";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblBCAirTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCAirTime"].ToString());
                    //   if (lblBCAirTimeI.Text == "" || lblBCAirTimeI.Text == "0.000" || lblBCAirTimeI.Text == "0")
                    decimal BCAirTime;
                    decimal.TryParse(ds.Tables[0].Rows[0]["BCAirTime"].ToString(), out BCAirTime);
                    if (BCAirTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblBCAirTimeI.Text = "";
                        misv.variableName = "BCAirTime";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblBCStrideLengthI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCStrideLength"].ToString());
                    //  if (lblBCStrideLengthI.Text == "" || lblBCStrideLengthI.Text == "0.000" || lblBCStrideLengthI.Text == "0")
                    decimal BCStrideLength;
                    decimal.TryParse(ds.Tables[0].Rows[0]["BCStrideLength"].ToString(), out BCStrideLength);
                    if (BCStrideLength == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblBCStrideLengthI.Text = "";
                        misv.variableName = "BCStrideLength";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblStep1COGDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1COGDistance"].ToString());
                    //  if (lblStep1COGDistanceI.Text == "" || lblStep1COGDistanceI.Text == "0.000" || lblStep1COGDistanceI.Text == "0")
                    decimal Step1COGDistance;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Step1COGDistance"].ToString(), out Step1COGDistance);
                    if (Step1COGDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep1COGDistanceI.Text = "";
                        misv.variableName = "Step1COGDistance";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblStep1LLAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1LLAngleTakeoff"].ToString());
                    //   if (lblStep1LLAngleTakeoffI.Text == "" || lblStep1LLAngleTakeoffI.Text == "0.000" || lblStep1LLAngleTakeoffI.Text == "0")
                    decimal Step1LLAngleTakeoff;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Step1LLAngleTakeoff"].ToString(), out Step1LLAngleTakeoff);
                    if (Step1LLAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep1LLAngleTakeoffI.Text = "";
                        misv.variableName = "Step1LLAngleTakeoff";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblStep1TrunkAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1TrunkAngleTakeoff"].ToString());
                    //    if (lblStep1TrunkAngleTakeoffI.Text == "" || lblStep1TrunkAngleTakeoffI.Text == "0.000" || lblStep1TrunkAngleTakeoffI.Text == "0")
                    decimal Step1TrunkAngleTakeoff;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Step1TrunkAngleTakeoff"].ToString(), out Step1TrunkAngleTakeoff);
                    if (Step1TrunkAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep1TrunkAngleTakeoffI.Text = "";
                        misv.variableName = "Step1TrunkAngleTakeoff";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblStep1LLAngleACI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1LLAngleAC"].ToString());
                    //   if (lblStep1LLAngleACI.Text == "" || lblStep1LLAngleACI.Text == "0.000" || lblStep1LLAngleACI.Text == "0")
                    decimal Step1LLAngleAC;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Step1LLAngleAC"].ToString(), out Step1LLAngleAC);
                    if (Step1LLAngleAC == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep1LLAngleACI.Text = "";
                        misv.variableName = "Step1LLAngleAC";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblStep1GroundTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1GroundTime"].ToString());
                    //   if (lblStep1GroundTimeI.Text == "" || lblStep1GroundTimeI.Text == "0.000" || lblStep1GroundTimeI.Text == "0")
                    decimal Step1GroundTime;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Step1GroundTime"].ToString(), out Step1GroundTime);
                    if (Step1GroundTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep1GroundTimeI.Text = "";
                        misv.variableName = "Step1GroundTime";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblStep1AirTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1AirTime"].ToString());
                    //    if (lblStep1AirTimeI.Text == "" || lblStep1AirTimeI.Text == "0.000" || lblStep1AirTimeI.Text == "0")
                    decimal Step1AirTime;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Step1AirTime"].ToString(), out Step1AirTime);
                    if (Step1AirTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep1AirTimeI.Text = "";
                        misv.variableName = "Step1AirTime";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblStep1StrideLengthI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1StrideLength"].ToString());
                    //   if (lblStep1StrideLengthI.Text == "" || lblStep1StrideLengthI.Text == "0.000" || lblStep1StrideLengthI.Text == "0")
                    decimal Step1StrideLength;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Step1StrideLength"].ToString(), out Step1StrideLength);
                    if (Step1StrideLength == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep1StrideLengthI.Text = "";
                        misv.variableName = "Step1StrideLength";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblStep2COGDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2COGDistance"].ToString());
                    //   if (lblStep2COGDistanceI.Text == "" || lblStep2COGDistanceI.Text == "0.000" || lblStep2COGDistanceI.Text == "0")
                    decimal Step2COGDistance;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Step2COGDistance"].ToString(), out Step2COGDistance);
                    if (Step2COGDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep2COGDistanceI.Text = "";
                        misv.variableName = "Step2COGDistance";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblStep2LLAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2LLAngleTakeoff"].ToString());
                    //  if (lblStep2LLAngleTakeoffI.Text == "" || lblStep2LLAngleTakeoffI.Text == "0.000" || lblStep2LLAngleTakeoffI.Text == "0")
                    decimal Step2LLAngleTakeoff;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Step2LLAngleTakeoff"].ToString(), out Step2LLAngleTakeoff);
                    if (Step2LLAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep2LLAngleTakeoffI.Text = "";
                        misv.variableName = "Step2LLAngleTakeoff";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblStep2TrunkAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2TrunkAngleTakeoff"].ToString());
                    //   if (lblStep2TrunkAngleTakeoffI.Text == "" || lblStep2TrunkAngleTakeoffI.Text == "0.000" || lblStep2TrunkAngleTakeoffI.Text == "0")
                    decimal Step2TrunkAngleTakeoff;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Step2TrunkAngleTakeoff"].ToString(), out Step2TrunkAngleTakeoff);
                    if (Step2TrunkAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep2TrunkAngleTakeoffI.Text = "";
                        misv.variableName = "Step2TrunkAngleTakeoff";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblStep2LLAngleACI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2LLAngleAC"].ToString());
                    //   if (lblStep2LLAngleACI.Text == "" || lblStep2LLAngleACI.Text == "0.000" || lblStep2LLAngleACI.Text == "0")
                    decimal Step2LLAngleAC;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Step2LLAngleAC"].ToString(), out Step2LLAngleAC);
                    if (Step2LLAngleAC == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep2LLAngleACI.Text = "";
                        misv.variableName = "Step2LLAngleAC";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblStep2GroundTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2GroundTime"].ToString());
                    //    if (lblStep2GroundTimeI.Text == "" || lblStep2GroundTimeI.Text == "0.000" || lblStep2GroundTimeI.Text == "0")
                    decimal Step2GroundTime;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Step2GroundTime"].ToString(), out Step2GroundTime);
                    if (Step2GroundTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep2GroundTimeI.Text = "";
                        misv.variableName = "Step2GroundTime";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblStep2AirTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2AirTime"].ToString());
                    //  if (lblStep2AirTimeI.Text == "" || lblStep2AirTimeI.Text == "0.000" || lblStep2AirTimeI.Text == "0")
                    decimal Step2AirTime;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Step2AirTime"].ToString(), out Step2AirTime);
                    if (Step2AirTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep2AirTimeI.Text = "";
                        misv.variableName = "Step2AirTime";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblStep2StrideLengthI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2StrideLength"].ToString());
                    //    if (lblStep2StrideLengthI.Text == "" || lblStep2StrideLengthI.Text == "0.000" || lblStep2StrideLengthI.Text == "0")
                    decimal Step2StrideLength;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Step2StrideLength"].ToString(), out Step2StrideLength);
                    if (Step2StrideLength == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep2StrideLengthI.Text = "";
                        misv.variableName = "Step2StrideLength";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblStep3COGDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3COGDistance"].ToString());
                    decimal Step3COGDistance;
                    decimal.TryParse(ds.Tables[0].Rows[0]["Step3COGDistance"].ToString(), out Step3COGDistance);
                    if (Step3COGDistance == 0)
                    //    if (lblStep3COGDistanceI.Text == "" || lblStep3COGDistanceI.Text == "0.000" || lblStep3COGDistanceI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblStep3COGDistanceI.Text = "";
                        misv.variableName = "Step3COGDistance";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblTimeTo3mI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TimeTo3m"].ToString());
                    decimal TimeTo3m;
                    decimal.TryParse(ds.Tables[0].Rows[0]["TimeTo3m"].ToString(), out TimeTo3m);
                    if (TimeTo3m == 0)
                    //  if (lblTimeTo3mI.Text == "" || lblTimeTo3mI.Text == "0.000" || lblTimeTo3mI.Text == "0")
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblTimeTo3mI.Text = "";
                        misv.variableName = "TimeTo3m";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    lblTimeTo5mI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TimeTo5m"].ToString());
                    //    if (lblTimeTo5mI.Text == "" || lblTimeTo5mI.Text == "0.000" || lblTimeTo5mI.Text == "0")
                    decimal TimeTo5m;
                    decimal.TryParse(ds.Tables[0].Rows[0]["TimeTo5m"].ToString(), out TimeTo5m);
                    if (TimeTo5m == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "initial";
                        lblTimeTo5mI.Text = "";
                        misv.variableName = "TimeTo5m";
                        missingVariableStar.Add(misv);
                        initialcnt++;
                    }
                    #endregion[initial data]
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataRow drVariable = ds.Tables[1].Rows[0];
                    #region[model data]
                    lblSetFrontBlockDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetFrontBlockDistance"].ToString());
                    // if (lblSetFrontBlockDistanceM1.Text == "" || lblSetFrontBlockDistanceM1.Text == "0.000" || lblSetFrontBlockDistanceM1.Text == "0")
                    decimal SetFrontBlockDistance;
                    decimal.TryParse(ds.Tables[1].Rows[0]["SetFrontBlockDistance"].ToString(), out SetFrontBlockDistance);
                    if (SetFrontBlockDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblSetFrontBlockDistanceM1.Text = "";
                        misv.variableName = "SetFrontBlockDistance";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblSetRearBlockDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetRearBlockDistance"].ToString());
                    // if (lblSetRearBlockDistanceM1.Text == "" || lblSetRearBlockDistanceM1.Text == "0.000" || lblSetRearBlockDistanceM1.Text == "0")
                    decimal SetRearBlockDistance;
                    decimal.TryParse(ds.Tables[1].Rows[0]["SetRearBlockDistance"].ToString(), out SetRearBlockDistance);
                    if (SetRearBlockDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblSetRearBlockDistanceM1.Text = "";
                        misv.variableName = "SetRearBlockDistance";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblSetFrontULAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetFrontULAngle"].ToString());
                    //  if (lblSetFrontULAngleM1.Text == "" || lblSetFrontULAngleM1.Text == "0.000" || lblSetFrontULAngleM1.Text == "0")
                    decimal SetFrontULAngle;
                    decimal.TryParse(ds.Tables[1].Rows[0]["SetFrontULAngle"].ToString(), out SetFrontULAngle);
                    if (SetFrontULAngle == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblSetFrontULAngleM1.Text = "";
                        misv.variableName = "SetFrontULAngle";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblSetRearULAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetRearULAngle"].ToString());
                    // if (lblSetRearULAngleM1.Text == "" || lblSetRearULAngleM1.Text == "0.000" || lblSetRearULAngleM1.Text == "0")
                    decimal SetRearULAngleM;
                    decimal.TryParse(ds.Tables[1].Rows[0]["SetRearULAngle"].ToString(), out SetRearULAngleM);
                    if (SetRearULAngleM == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblSetRearULAngleM1.Text = "";
                        misv.variableName = "SetRearULAngle";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblSetFrontLLAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetFrontLLAngle"].ToString());
                    //  if (lblSetFrontLLAngleM1.Text == "" || lblSetFrontLLAngleM1.Text == "0.000" || lblSetFrontLLAngleM1.Text == "0")
                    decimal SetRearULAngle;
                    decimal.TryParse(ds.Tables[1].Rows[0]["SetFrontLLAngle"].ToString(), out SetRearULAngle);
                    if (SetRearULAngle == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblSetFrontLLAngleM1.Text = "";
                        misv.variableName = "SetFrontLLAngle";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblSetRearLLAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetRearLLAngle"].ToString());
                    //  if (lblSetRearLLAngleM1.Text == "" || lblSetRearLLAngleM1.Text == "0.000" || lblSetRearLLAngleM1.Text == "0")
                    decimal SetFrontLLAngle;
                    decimal.TryParse(ds.Tables[1].Rows[0]["SetRearLLAngle"].ToString(), out SetFrontLLAngle);
                    if (SetFrontLLAngle == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblSetRearLLAngleM1.Text = "";
                        misv.variableName = "SetRearLLAngle";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblSetTrunkAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetTrunkAngle"].ToString());
                    //   if (lblSetTrunkAngleM1.Text == "" || lblSetTrunkAngleM1.Text == "0.000" || lblSetTrunkAngleM1.Text == "0")
                    decimal SetRearLLAngle;
                    decimal.TryParse(ds.Tables[1].Rows[0]["SetTrunkAngle"].ToString(), out SetRearLLAngle);
                    if (SetRearLLAngle == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblSetTrunkAngleM1.Text = "";
                        misv.variableName = "SetTrunkAngle";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblSetCOGDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetCOGDistance"].ToString());
                    // if (lblSetCOGDistanceM1.Text == "" || lblSetCOGDistanceM1.Text == "0.000" || lblSetCOGDistanceM1.Text == "0")
                    decimal SetTrunkAngle;
                    decimal.TryParse(ds.Tables[1].Rows[0]["SetCOGDistance"].ToString(), out SetTrunkAngle);
                    if (SetTrunkAngle == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblSetCOGDistanceM1.Text = "";
                        misv.variableName = "SetCOGDistance";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblBCRearFootClearanceTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BCRearFootClearanceTime"].ToString());
                    //  if (lblBCRearFootClearanceTimeM1.Text == "" || lblBCRearFootClearanceTimeM1.Text == "0.000" || lblBCRearFootClearanceTimeM1.Text == "0")
                    decimal SetCOGDistance;
                    decimal.TryParse(ds.Tables[1].Rows[0]["BCRearFootClearanceTime"].ToString(), out SetCOGDistance);
                    if (SetCOGDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblBCRearFootClearanceTimeM1.Text = "";
                        misv.variableName = "BCRearFootClearanceTime";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblBCFrontFootClearanceTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BCFrontFootClearanceTime"].ToString());
                    //  if (lblSetFrontBlockDistanceM1.Text == "" || lblSetFrontBlockDistanceM1.Text == "0.000" || lblSetFrontBlockDistanceM1.Text == "0")
                    decimal BCRearFootClearanceTime;
                    decimal.TryParse(ds.Tables[1].Rows[0]["BCFrontFootClearanceTime"].ToString(), out BCRearFootClearanceTime);
                    if (BCRearFootClearanceTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblSetFrontBlockDistanceM1.Text = "";
                        misv.variableName = "BCFrontFootClearanceTime";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblBCRearLLAngleTakeoffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BCRearLLAngleTakeoff"].ToString());
                    //  if (lblBCRearLLAngleTakeoffM1.Text == "" || lblBCRearLLAngleTakeoffM1.Text == "0.000" || lblBCRearLLAngleTakeoffM1.Text == "0")
                    decimal BCFrontFootClearanceTime;
                    decimal.TryParse(ds.Tables[1].Rows[0]["BCRearLLAngleTakeoff"].ToString(), out BCFrontFootClearanceTime);
                    if (BCFrontFootClearanceTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblBCRearLLAngleTakeoffM1.Text = "";
                        misv.variableName = "BCRearLLAngleTakeoff";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblBCFrontLLAngleTakeoffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BCFrontLLAngleTakeoff"].ToString());
                    //  if (lblBCFrontLLAngleTakeoffM1.Text == "" || lblBCFrontLLAngleTakeoffM1.Text == "0.000" || lblBCFrontLLAngleTakeoffM1.Text == "0")
                    decimal BCRearLLAngleTakeoff;
                    decimal.TryParse(ds.Tables[1].Rows[0]["BCFrontLLAngleTakeoff"].ToString(), out BCRearLLAngleTakeoff);
                    if (BCRearLLAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblBCFrontLLAngleTakeoffM1.Text = "";
                        misv.variableName = "BCFrontLLAngleTakeoff";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblBCTrunkAngleTakeoffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BCTrunkAngleTakeoff"].ToString());
                    //  if (lblBCTrunkAngleTakeoffM1.Text == "" || lblBCTrunkAngleTakeoffM1.Text == "0.000" || lblBCTrunkAngleTakeoffM1.Text == "0")
                    decimal BCTrunkAngleTakeoff;
                    decimal.TryParse(ds.Tables[1].Rows[0]["BCTrunkAngleTakeoff"].ToString(), out BCTrunkAngleTakeoff);
                    if (BCTrunkAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblBCTrunkAngleTakeoffM1.Text = "";
                        misv.variableName = "BCTrunkAngleTakeoff";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblBCLLAngleACM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BCLLAngleAC"].ToString());
                    //   if (lblBCLLAngleACM1.Text == "" || lblBCLLAngleACM1.Text == "0.000" || lblBCLLAngleACM1.Text == "0")
                    decimal BCLLAngleAC;
                    decimal.TryParse(ds.Tables[1].Rows[0]["BCLLAngleAC"].ToString(), out BCLLAngleAC);
                    if (BCLLAngleAC == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblBCLLAngleACM1.Text = "";
                        misv.variableName = "BCLLAngleAC";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblBCAirTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BCAirTime"].ToString());
                    //  if (lblBCAirTimeM1.Text == "" || lblBCAirTimeM1.Text == "0.000" || lblBCAirTimeM1.Text == "0")
                    decimal BCAirTime;
                    decimal.TryParse(ds.Tables[1].Rows[0]["BCAirTime"].ToString(), out BCAirTime);
                    if (BCAirTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblBCAirTimeM1.Text = "";
                        misv.variableName = "BCAirTime";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblBCStrideLengthM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BCStrideLength"].ToString());
                    //   if (lblBCStrideLengthM1.Text == "" || lblBCStrideLengthM1.Text == "0.000" || lblBCStrideLengthM1.Text == "0")
                    decimal BCStrideLength;
                    decimal.TryParse(ds.Tables[1].Rows[0]["BCStrideLength"].ToString(), out BCStrideLength);
                    if (BCStrideLength == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblBCStrideLengthM1.Text = "";
                        misv.variableName = "BCStrideLength";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblStep1COGDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1COGDistance"].ToString());
                    //   if (lblStep1COGDistanceM1.Text == "" || lblStep1COGDistanceM1.Text == "0.000" || lblStep1COGDistanceM1.Text == "0")
                    decimal Step1COGDistance;
                    decimal.TryParse(ds.Tables[1].Rows[0]["Step1COGDistance"].ToString(), out Step1COGDistance);
                    if (Step1COGDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStep1COGDistanceM1.Text = "";
                        misv.variableName = "Step1COGDistance";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblStep1LLAngleTakeoffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1LLAngleTakeoff"].ToString());
                    //  if (lblStep1LLAngleTakeoffM1.Text == "" || lblStep1LLAngleTakeoffM1.Text == "0.000" || lblStep1LLAngleTakeoffM1.Text == "0")
                    decimal Step1LLAngleTakeoff;
                    decimal.TryParse(ds.Tables[1].Rows[0]["Step1LLAngleTakeoff"].ToString(), out Step1LLAngleTakeoff);
                    if (Step1LLAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStep1LLAngleTakeoffM1.Text = "";
                        misv.variableName = "Step1LLAngleTakeoff";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblStep1TrunkAngleTakeoffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1TrunkAngleTakeoff"].ToString());
                    //  if (lblStep1TrunkAngleTakeoffM1.Text == "" || lblStep1TrunkAngleTakeoffM1.Text == "0.000" || lblStep1TrunkAngleTakeoffM1.Text == "0")
                    decimal Step1TrunkAngleTakeoff;
                    decimal.TryParse(ds.Tables[1].Rows[0]["Step1TrunkAngleTakeoff"].ToString(), out Step1TrunkAngleTakeoff);
                    if (Step1TrunkAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStep1TrunkAngleTakeoffM1.Text = "";
                        misv.variableName = "Step1TrunkAngleTakeoff";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblStep1LLAngleACM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1LLAngleAC"].ToString());
                    //  if (lblStep1LLAngleACM1.Text == "" || lblStep1LLAngleACM1.Text == "0.000" || lblStep1LLAngleACM1.Text == "0")
                    decimal Step1LLAngleAC;
                    decimal.TryParse(ds.Tables[1].Rows[0]["Step1LLAngleAC"].ToString(), out Step1LLAngleAC);
                    if (Step1LLAngleAC == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStep1LLAngleACM1.Text = "";
                        misv.variableName = "Step1LLAngleAC";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblStep1GroundTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1GroundTime"].ToString());
                    //  if (lblStep1GroundTimeM1.Text == "" || lblStep1GroundTimeM1.Text == "0.000" || lblStep1GroundTimeM1.Text == "0")
                    decimal Step1GroundTime;
                    decimal.TryParse(ds.Tables[1].Rows[0]["Step1GroundTime"].ToString(), out Step1GroundTime);
                    if (Step1GroundTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStep1GroundTimeM1.Text = "";
                        misv.variableName = "Step1GroundTime";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblStep1AirTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1AirTime"].ToString());
                    //   if (lblStep1AirTimeM1.Text == "" || lblStep1AirTimeM1.Text == "0.000" || lblStep1AirTimeM1.Text == "0")
                    decimal Step1AirTime;
                    decimal.TryParse(ds.Tables[1].Rows[0]["Step1AirTime"].ToString(), out Step1AirTime);
                    if (Step1AirTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStep1AirTimeM1.Text = "";
                        misv.variableName = "Step1AirTime";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblStep1StrideLengthM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1StrideLength"].ToString());
                    //    if (lblStep1StrideLengthM1.Text == "" || lblStep1StrideLengthM1.Text == "0.000" || lblStep1StrideLengthM1.Text == "0")
                    decimal Step1StrideLength;
                    decimal.TryParse(ds.Tables[1].Rows[0]["Step1StrideLength"].ToString(), out Step1StrideLength);
                    if (Step1StrideLength == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStep1StrideLengthM1.Text = "";
                        misv.variableName = "Step1StrideLength";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblStep2COGDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2COGDistance"].ToString());
                    //  if (lblStep2COGDistanceM1.Text == "" || lblStep2COGDistanceM1.Text == "0.000" || lblStep2COGDistanceM1.Text == "0")
                    decimal Step2COGDistance;
                    decimal.TryParse(ds.Tables[1].Rows[0]["Step2COGDistance"].ToString(), out Step2COGDistance);
                    if (Step2COGDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStep2COGDistanceM1.Text = "";
                        misv.variableName = "Step2COGDistance";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblStep2LLAngleTakeoffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2LLAngleTakeoff"].ToString());
                    //  if (lblStep2LLAngleTakeoffM1.Text == "" || lblStep2LLAngleTakeoffM1.Text == "0.000" || lblStep2LLAngleTakeoffM1.Text == "0")
                    decimal Step2LLAngleTakeoff;
                    decimal.TryParse(ds.Tables[1].Rows[0]["Step2LLAngleTakeoff"].ToString(), out Step2LLAngleTakeoff);
                    if (Step2LLAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStep2LLAngleTakeoffM1.Text = "";
                        misv.variableName = "Step2LLAngleTakeoff";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblStep2TrunkAngleTakeoffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2TrunkAngleTakeoff"].ToString());
                    //  if (lblStep2TrunkAngleTakeoffM1.Text == "" || lblStep2TrunkAngleTakeoffM1.Text == "0.000" || lblStep2TrunkAngleTakeoffM1.Text == "0")
                    decimal Step2TrunkAngleTakeoff;
                    decimal.TryParse(ds.Tables[1].Rows[0]["Step2TrunkAngleTakeoff"].ToString(), out Step2TrunkAngleTakeoff);
                    if (Step2TrunkAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStep2TrunkAngleTakeoffM1.Text = "";
                        misv.variableName = "Step2TrunkAngleTakeoff";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblStep2LLAngleACM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2LLAngleAC"].ToString());
                    //  if (lblStep2LLAngleACM1.Text == "" || lblStep2LLAngleACM1.Text == "0.000" || lblStep2LLAngleACM1.Text == "0")
                    decimal Step2LLAngleAC;
                    decimal.TryParse(ds.Tables[1].Rows[0]["Step2LLAngleAC"].ToString(), out Step2LLAngleAC);
                    if (Step2LLAngleAC == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStep2LLAngleACM1.Text = "";
                        misv.variableName = "Step2LLAngleAC";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblStep2GroundTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2GroundTime"].ToString());
                    //   if (lblStep2GroundTimeM1.Text == "" || lblStep2GroundTimeM1.Text == "0.000" || lblStep2GroundTimeM1.Text == "0")
                    decimal Step2GroundTime;
                    decimal.TryParse(ds.Tables[1].Rows[0]["Step2GroundTime"].ToString(), out Step2GroundTime);
                    if (Step2GroundTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStep2GroundTimeM1.Text = "";
                        misv.variableName = "Step2GroundTime";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblStep2AirTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2AirTime"].ToString());
                    //  if (lblStep2AirTimeM1.Text == "" || lblStep2AirTimeM1.Text == "0.000" || lblStep2AirTimeM1.Text == "0")
                    decimal Step2AirTime;
                    decimal.TryParse(ds.Tables[1].Rows[0]["Step2AirTime"].ToString(), out Step2AirTime);
                    if (Step2AirTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStep2AirTimeM1.Text = "";
                        misv.variableName = "Step2AirTime";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblStep2StrideLengthM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2StrideLength"].ToString());
                    // if (lblStep2StrideLengthM1.Text == "" || lblStep2StrideLengthM1.Text == "0.000" || lblStep2StrideLengthM1.Text == "0")
                    decimal Step2StrideLength;
                    decimal.TryParse(ds.Tables[1].Rows[0]["Step2StrideLength"].ToString(), out Step2StrideLength);
                    if (Step2StrideLength == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStep2StrideLengthM1.Text = "";
                        misv.variableName = "Step2StrideLength";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblStep3COGDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3COGDistance"].ToString());
                    //  if (lblStep3COGDistanceM1.Text == "" || lblStep3COGDistanceM1.Text == "0.000" || lblStep3COGDistanceM1.Text == "0")
                    decimal Step3COGDistance;
                    decimal.TryParse(ds.Tables[1].Rows[0]["Step3COGDistance"].ToString(), out Step3COGDistance);
                    if (Step3COGDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblStep3COGDistanceM1.Text = "";
                        misv.variableName = "Step3COGDistance";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblTimeTo3mM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["TimeTo3m"].ToString());
                    //  if (lblTimeTo3mM1.Text == "" || lblTimeTo3mM1.Text == "0.000" || lblTimeTo3mM1.Text == "0")
                    decimal TimeTo3m;
                    decimal.TryParse(ds.Tables[1].Rows[0]["TimeTo3m"].ToString(), out TimeTo3m);
                    if (TimeTo3m == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblTimeTo3mM1.Text = "";
                        misv.variableName = "TimeTo3m";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    lblTimeTo5mM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["TimeTo5m"].ToString());
                    //  if (lblTimeTo5mM1.Text == "" || lblTimeTo5mM1.Text == "0.000" || lblTimeTo5mM1.Text == "0")
                    decimal TimeTo5m;
                    decimal.TryParse(ds.Tables[1].Rows[0]["TimeTo5m"].ToString(), out TimeTo5m);
                    if (TimeTo5m == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "model";
                        lblTimeTo5mM1.Text = "";
                        misv.variableName = "TimeTo5m";
                        missingVariableStar.Add(misv);
                        modelCnt++;
                    }
                    #endregion[model data]
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    DataRow drVariable = ds.Tables[2].Rows[0];
                    #region[final data]
                    lblSetFrontBlockDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetFrontBlockDistance"].ToString());
                    //if (lblSetFrontBlockDistanceF.Text == "" || lblSetFrontBlockDistanceF.Text == "0.000" || lblSetFrontBlockDistanceF.Text == "0")
                    decimal SetFrontBlockDistance;
                    decimal.TryParse(ds.Tables[2].Rows[0]["SetFrontBlockDistance"].ToString(), out SetFrontBlockDistance);
                    if (SetFrontBlockDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblSetFrontBlockDistanceF.Text = "";
                        misv.variableName = "SetFrontBlockDistance";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblSetRearBlockDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetRearBlockDistance"].ToString());
                    // if (lblSetRearBlockDistanceF.Text == "" || lblSetRearBlockDistanceF.Text == "0.000" || lblSetRearBlockDistanceF.Text == "0")
                    decimal SetRearBlockDistance;
                    decimal.TryParse(ds.Tables[2].Rows[0]["SetRearBlockDistance"].ToString(), out SetRearBlockDistance);
                    if (SetRearBlockDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblSetRearBlockDistanceF.Text = "";
                        misv.variableName = "SetRearBlockDistance";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblSetFrontULAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetFrontULAngle"].ToString());
                    // if (lblSetFrontULAngleF.Text == "" || lblSetFrontULAngleF.Text == "0.000" || lblSetFrontULAngleF.Text == "0")
                    decimal SetFrontULAngle;
                    decimal.TryParse(ds.Tables[2].Rows[0]["SetFrontULAngle"].ToString(), out SetFrontULAngle);
                    if (SetFrontULAngle == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblSetFrontULAngleF.Text = "";
                        misv.variableName = "SetFrontULAngle";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblSetRearULAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetRearULAngle"].ToString());
                    // if (lblSetRearULAngleF.Text == "" || lblSetRearULAngleF.Text == "0.000" || lblSetRearULAngleF.Text == "0")
                    decimal SetFrontLLAngle;
                    decimal.TryParse(ds.Tables[2].Rows[0]["SetRearULAngle"].ToString(), out SetFrontLLAngle);
                    if (SetFrontLLAngle == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblSetRearULAngleF.Text = "";
                        misv.variableName = "SetRearULAngle";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }

                    lblSetFrontLLAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetFrontLLAngle"].ToString());
                    // if (lblSetFrontLLAngleF.Text == "" || lblSetFrontLLAngleF.Text == "0.000" || lblSetFrontLLAngleF.Text == "0")
                    decimal SetFrontLLAngleF;
                    decimal.TryParse(ds.Tables[2].Rows[0]["SetFrontLLAngle"].ToString(), out SetFrontLLAngleF);
                    if (SetFrontLLAngleF == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblSetFrontLLAngleF.Text = "";
                        misv.variableName = "SetFrontLLAngle";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblSetRearLLAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetRearLLAngle"].ToString());
                    // if (lblSetRearLLAngleF.Text == "" || lblSetRearLLAngleF.Text == "0.000" || lblSetRearLLAngleF.Text == "0")
                    decimal SetRearLLAngle;
                    decimal.TryParse(ds.Tables[2].Rows[0]["SetRearLLAngle"].ToString(), out SetRearLLAngle);
                    if (SetRearLLAngle == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblSetRearLLAngleF.Text = "";
                        misv.variableName = "SetRearLLAngle";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblSetTrunkAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetTrunkAngle"].ToString());
                    //  if (lblSetTrunkAngleF.Text == "" || lblSetTrunkAngleF.Text == "0.000" || lblSetTrunkAngleF.Text == "0")
                    decimal SetTrunkAngle;
                    decimal.TryParse(ds.Tables[2].Rows[0]["SetTrunkAngle"].ToString(), out SetTrunkAngle);
                    if (SetTrunkAngle == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblSetTrunkAngleF.Text = "";
                        misv.variableName = "SetTrunkAngle";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblSetCOGDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetCOGDistance"].ToString());
                    // if (lblSetCOGDistanceF.Text == "" || lblSetCOGDistanceF.Text == "0.000" || lblSetCOGDistanceF.Text == "0")
                    decimal SetCOGDistance;
                    decimal.TryParse(ds.Tables[2].Rows[0]["SetCOGDistance"].ToString(), out SetCOGDistance);
                    if (SetCOGDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblSetCOGDistanceF.Text = "";
                        misv.variableName = "SetCOGDistance";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblBCRearFootClearanceTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCRearFootClearanceTime"].ToString());
                    //  if (lblBCRearFootClearanceTimeF.Text == "" || lblBCRearFootClearanceTimeF.Text == "0.000" || lblBCRearFootClearanceTimeF.Text == "0")
                    decimal BCRearFootClearanceTime;
                    decimal.TryParse(ds.Tables[2].Rows[0]["BCRearFootClearanceTime"].ToString(), out BCRearFootClearanceTime);
                    if (BCRearFootClearanceTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblBCRearFootClearanceTimeF.Text = "";
                        misv.variableName = "BCRearFootClearanceTime";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblBCFrontFootClearanceTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCFrontFootClearanceTime"].ToString());
                    //  if (lblSetFrontBlockDistanceF.Text == "" || lblSetFrontBlockDistanceF.Text == "0.000" || lblSetFrontBlockDistanceF.Text == "0")
                    decimal BCFrontFootClearanceTime;
                    decimal.TryParse(ds.Tables[2].Rows[0]["BCFrontFootClearanceTime"].ToString(), out BCFrontFootClearanceTime);
                    if (BCFrontFootClearanceTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblBCFrontFootClearanceTimeF.Text = "";
                        misv.variableName = "BCFrontFootClearanceTime";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblBCRearLLAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCRearLLAngleTakeoff"].ToString());
                    //  if (lblBCRearLLAngleTakeoffF.Text == "" || lblBCRearLLAngleTakeoffF.Text == "0.000" || lblBCRearLLAngleTakeoffF.Text == "0")
                    decimal BCRearLLAngleTakeoff;
                    decimal.TryParse(ds.Tables[2].Rows[0]["BCRearLLAngleTakeoff"].ToString(), out BCRearLLAngleTakeoff);
                    if (BCRearLLAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblBCRearLLAngleTakeoffF.Text = "";
                        misv.variableName = "BCRearLLAngleTakeoff";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblBCFrontLLAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCFrontLLAngleTakeoff"].ToString());
                    //  if (lblBCFrontLLAngleTakeoffF.Text == "" || lblBCFrontLLAngleTakeoffF.Text == "0.000" || lblBCFrontLLAngleTakeoffF.Text == "0")
                    decimal BCFrontLLAngleTakeoff;
                    decimal.TryParse(ds.Tables[2].Rows[0]["BCFrontLLAngleTakeoff"].ToString(), out BCFrontLLAngleTakeoff);
                    if (BCFrontLLAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblBCFrontLLAngleTakeoffF.Text = "";
                        misv.variableName = "BCFrontLLAngleTakeoff";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblBCTrunkAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCTrunkAngleTakeoff"].ToString());
                    //if (lblBCTrunkAngleTakeoffF.Text == "" || lblBCTrunkAngleTakeoffF.Text == "0.000" || lblBCTrunkAngleTakeoffF.Text == "0")
                    decimal BCTrunkAngleTakeoff;
                    decimal.TryParse(ds.Tables[2].Rows[0]["BCTrunkAngleTakeoff"].ToString(), out BCTrunkAngleTakeoff);
                    if (BCTrunkAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblBCTrunkAngleTakeoffF.Text = "";
                        misv.variableName = "BCTrunkAngleTakeoff";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblBCLLAngleACF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLLAngleAC"].ToString());
                    //   if (lblBCLLAngleACF.Text == "" || lblBCLLAngleACF.Text == "0.000" || lblBCLLAngleACF.Text == "0")
                    decimal BCLLAngleAC;
                    decimal.TryParse(ds.Tables[2].Rows[0]["BCLLAngleAC"].ToString(), out BCLLAngleAC);
                    if (BCLLAngleAC == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblBCLLAngleACF.Text = "";
                        misv.variableName = "BCLLAngleAC";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblBCAirTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCAirTime"].ToString());
                    //  if (lblBCAirTimeF.Text == "" || lblBCAirTimeF.Text == "0.000" || lblBCAirTimeF.Text == "0")
                    decimal BCAirTime;
                    decimal.TryParse(ds.Tables[2].Rows[0]["BCAirTime"].ToString(), out BCAirTime);
                    if (BCAirTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblBCAirTimeF.Text = "";
                        misv.variableName = "BCAirTime";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblBCStrideLengthF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCStrideLength"].ToString());
                    //   if (lblBCStrideLengthF.Text == "" || lblBCStrideLengthF.Text == "0.000" || lblBCStrideLengthF.Text == "0")
                    decimal BCStrideLength;
                    decimal.TryParse(ds.Tables[2].Rows[0]["BCStrideLength"].ToString(), out BCStrideLength);
                    if (BCStrideLength == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblBCStrideLengthF.Text = "";
                        misv.variableName = "BCStrideLength";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblStep1COGDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1COGDistance"].ToString());
                    //  if (lblStep1COGDistanceF.Text == "" || lblStep1COGDistanceF.Text == "0.000" || lblStep1COGDistanceF.Text == "0")
                    decimal Step1COGDistance;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Step1COGDistance"].ToString(), out Step1COGDistance);
                    if (Step1COGDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep1COGDistanceF.Text = "";
                        misv.variableName = "Step1COGDistance";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblStep1LLAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1LLAngleTakeoff"].ToString());
                    //  if (lblStep1LLAngleTakeoffF.Text == "" || lblStep1LLAngleTakeoffF.Text == "0.000" || lblStep1LLAngleTakeoffF.Text == "0")
                    decimal Step1LLAngleTakeoff;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Step1LLAngleTakeoff"].ToString(), out Step1LLAngleTakeoff);
                    if (Step1LLAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep1LLAngleTakeoffF.Text = "";
                        misv.variableName = "Step1LLAngleTakeoff";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblStep1TrunkAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1TrunkAngleTakeoff"].ToString());
                    //  if (lblStep1TrunkAngleTakeoffF.Text == "" || lblStep1TrunkAngleTakeoffF.Text == "0.000" || lblStep1TrunkAngleTakeoffF.Text == "")
                    decimal Step1TrunkAngleTakeoff;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Step1TrunkAngleTakeoff"].ToString(), out Step1TrunkAngleTakeoff);
                    if (Step1TrunkAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep1TrunkAngleTakeoffF.Text = "";
                        misv.variableName = "Step1TrunkAngleTakeoff";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblStep1LLAngleACF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1LLAngleAC"].ToString());
                    //    if (lblStep1LLAngleACF.Text == "" || lblStep1LLAngleACF.Text == "0.000" || lblStep1LLAngleACF.Text == "0")
                    decimal Step1LLAngleAC;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Step1LLAngleAC"].ToString(), out Step1LLAngleAC);
                    if (Step1LLAngleAC == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep1LLAngleACF.Text = "";
                        misv.variableName = "Step1LLAngleAC";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblStep1GroundTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1GroundTime"].ToString());
                    //  if (lblStep1GroundTimeF.Text == "" || lblStep1GroundTimeF.Text == "0.000" || lblStep1GroundTimeF.Text == "0")
                    decimal Step1GroundTime;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Step1GroundTime"].ToString(), out Step1GroundTime);
                    if (Step1GroundTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep1GroundTimeF.Text = "";
                        misv.variableName = "Step1GroundTime";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblStep1AirTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1AirTime"].ToString());
                    // if (lblStep1AirTimeF.Text == "" || lblStep1AirTimeF.Text == "0.000" || lblStep1AirTimeF.Text == "0")
                    decimal Step1AirTime;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Step1AirTime"].ToString(), out Step1AirTime);
                    if (Step1AirTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep1AirTimeF.Text = "";
                        misv.variableName = "Step1AirTime";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblStep1StrideLengthF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1StrideLength"].ToString());
                    // if (lblStep1StrideLengthF.Text == "" || lblStep1StrideLengthF.Text == "0.000" || lblStep1StrideLengthF.Text == "0")
                    decimal Step1StrideLength;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Step1StrideLength"].ToString(), out Step1StrideLength);
                    if (Step1StrideLength == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep1StrideLengthF.Text = "";
                        misv.variableName = "Step1StrideLength";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblStep2COGDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2COGDistance"].ToString());
                    // if (lblStep2COGDistanceF.Text == "" || lblStep2COGDistanceF.Text == "0.000" || lblStep2COGDistanceF.Text == "0")
                    decimal Step2COGDistance;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Step2COGDistance"].ToString(), out Step2COGDistance);
                    if (Step2COGDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep2COGDistanceF.Text = "";
                        misv.variableName = "Step2COGDistance";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblStep2LLAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2LLAngleTakeoff"].ToString());
                    // if (lblStep2LLAngleTakeoffF.Text == "" || lblStep2LLAngleTakeoffF.Text == "0.000" || lblStep2LLAngleTakeoffF.Text == "0")
                    decimal Step2LLAngleTakeoff;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Step2LLAngleTakeoff"].ToString(), out Step2LLAngleTakeoff);
                    if (Step2LLAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep2LLAngleTakeoffF.Text = "";
                        misv.variableName = "Step2LLAngleTakeoff";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblStep2TrunkAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2TrunkAngleTakeoff"].ToString());
                    // if (lblStep2TrunkAngleTakeoffF.Text == "" || lblStep2TrunkAngleTakeoffF.Text == "0.000" || lblStep2TrunkAngleTakeoffF.Text == "0")
                    decimal Step2TrunkAngleTakeoff;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Step2TrunkAngleTakeoff"].ToString(), out Step2TrunkAngleTakeoff);
                    if (Step2TrunkAngleTakeoff == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep2TrunkAngleTakeoffF.Text = "";
                        misv.variableName = "Step2TrunkAngleTakeoff";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblStep2LLAngleACF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2LLAngleAC"].ToString());
                    //  if (lblStep2LLAngleACF.Text == "" || lblStep2LLAngleACF.Text == "0.000" || lblStep2LLAngleACF.Text == "0")
                    decimal Step2LLAngleAC;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Step2LLAngleAC"].ToString(), out Step2LLAngleAC);
                    if (Step2LLAngleAC == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep2LLAngleACF.Text = "";
                        misv.variableName = "Step2LLAngleAC";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblStep2GroundTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2GroundTime"].ToString());
                    // if (lblStep2GroundTimeF.Text == "" || lblStep2GroundTimeF.Text == "0.000" || lblStep2GroundTimeF.Text == "0")
                    decimal Step2GroundTime;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Step2GroundTime"].ToString(), out Step2GroundTime);
                    if (Step2GroundTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep2GroundTimeF.Text = "";
                        misv.variableName = "Step2GroundTime";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblStep2AirTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2AirTime"].ToString());
                    // if (lblStep2AirTimeF.Text == "" || lblStep2AirTimeF.Text == "0.000" || lblStep2AirTimeF.Text == "0")
                    decimal Step2AirTime;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Step2AirTime"].ToString(), out Step2AirTime);
                    if (Step2AirTime == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep2AirTimeF.Text = "";
                        misv.variableName = "Step2AirTime";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblStep2StrideLengthF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2StrideLength"].ToString());
                    //  if (lblStep2StrideLengthF.Text == "" || lblStep2StrideLengthF.Text == "0.000" || lblStep2StrideLengthF.Text == "0")
                    decimal Step2StrideLength;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Step2StrideLength"].ToString(), out Step2StrideLength);
                    if (Step2StrideLength == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep2StrideLengthF.Text = "";
                        misv.variableName = "Step2StrideLength";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblStep3COGDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3COGDistance"].ToString());
                    //   if (lblStep3COGDistanceF.Text == "" || lblStep3COGDistanceF.Text == "0.000" || lblStep3COGDistanceF.Text == "0")
                    decimal Step3COGDistance;
                    decimal.TryParse(ds.Tables[2].Rows[0]["Step3COGDistance"].ToString(), out Step3COGDistance);
                    if (Step3COGDistance == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblStep3COGDistanceF.Text = "";
                        misv.variableName = "Step3COGDistance";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblTimeTo3mF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TimeTo3m"].ToString());
                    // if (lblTimeTo3mF.Text == "" || lblTimeTo3mF.Text == "0.000" || lblTimeTo3mF.Text == "0")
                    decimal TimeTo3m;
                    decimal.TryParse(ds.Tables[2].Rows[0]["TimeTo3m"].ToString(), out TimeTo3m);
                    if (TimeTo3m == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblTimeTo3mF.Text = "";
                        misv.variableName = "TimeTo3m";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    lblTimeTo5mF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TimeTo5m"].ToString());
                    // if (lblTimeTo5mF.Text == "" || lblTimeTo5mF.Text == "0.000" || lblTimeTo5mF.Text == "0")
                    decimal TimeTo5m;
                    decimal.TryParse(ds.Tables[2].Rows[0]["TimeTo5m"].ToString(), out TimeTo5m);
                    if (TimeTo5m == 0)
                    {
                        MissingVariable misv = new MissingVariable();
                        misv.type = "current";
                        lblTimeTo5mF.Text = "";
                        misv.variableName = "TimeTo5m";
                        missingVariableStar.Add(misv);
                        CurrentCnt++;
                    }
                    #endregion[final data]
                }
                sendNotFoundEmail(CurrentCnt, initialcnt, modelCnt);
            }
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropdownListXmlFle.Items.Clear();
        DropDownList2.Items.Clear();
        clearAllVariableData();
        if (!DropDownList1.SelectedValue.Equals("noathlete"))
        {
            clearAllVariableData();
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


                custmer = Startcustomer = DataRepository.CustomerProvider.GetByCustomerId(AthleteSelected);
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
                dsmodelData = sae.GetAllStartAthletesData(lessonid);
                string groundtimeM = string.Empty;
                var tablegroundtimeM = dsmodelData.Tables[1];
                string groundtimeI = string.Empty;
                var tablegroundtimeI = dsmodelData.Tables[2];
                string groundtimeC = string.Empty;
                var tablegroundtimeC = dsmodelData.Tables[0];
                Dictionary<string, string> vals = new Dictionary<string, string>();
                Dictionary<string, string> valsModel = new Dictionary<string, string>();
                Dictionary<string, string> valsCurnt = new Dictionary<string, string>();
                List<string> Curantlist = new List<string>();
                List<string> Modellist = new List<string>();
                List<string> Initiallist = new List<string>();
                //if (tablegroundtimeM.Rows.Count > 0)
                //{
                //    groundtimeM = dsmodelData.Tables[1].Rows[0]["SetFrontBlockDistance"].ToString();
                //}
                //if (tablegroundtimeI.Rows.Count > 0)
                //{
                //    groundtimeI = dsmodelData.Tables[2].Rows[0]["SetFrontBlockDistance"].ToString();
                //}
                //if (tablegroundtimeC.Rows.Count > 0)
                //{
                //    groundtimeC = dsmodelData.Tables[0].Rows[0]["SetFrontBlockDistance"].ToString();
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
                    if (item != "0" && item != "0.000")
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
                        if (item != "0" && item != "0.000")
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
                        if (item != "0" && item != "0.000")
                        {
                            Curantlist.Add(item);
                        }
                    }
                }
                string location1 = sae.SelectLessonlocation(lesson.LessonId.ToString());
                if (location1 == "On-Track Sesssion Summary")
                {
                    //OntrackSessionSelect();
                    GetAllStartAthleteData(lessonid);
                }
                //else if ((dsmodelData.Tables[1].Rows[0]["SetFrontBlockDistance"].ToString() != "0.000") && (dsmodelData.Tables[1].Rows[0]["SetFrontBlockDistance"].ToString() != ""))
                //{
                //    GetAllStartAthleteData(lessonid);
                //}
                //else if ((groundtimeI != "0.000" || groundtimeC != "0.000") && groundtimeM != "0.000")
                //{
                //    GetAllStartAthleteData(lessonid);
                //}
                //else if (groundtimeM != "0.000")
                //{
                //    GetAllStartAthleteData(lessonid);
                //}
                else if (Modellist.Count > 0)
                {
                    GetAllStartAthleteData(lessonid);
                }
                else if ((Initiallist.Count > 0 || Curantlist.Count > 0) && Modellist.Count > 0)
                {
                    GetAllStartAthleteData(lessonid);
                }
                else if (Curantlist.Count > 0)
                {
                    GetAllStartAthleteData(lessonid);
                }
                else
                {
                    // BindModelDataOnly(dsmodelData);
                    GetAllStartAthleteDataInitailNdCorrent(lessonid);
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
                        dsmodelData = sae.GetAllStartAthletesData(summarysessionlessionid);
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
                            try
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
                                    txtBFrame9.Text = dtathlets.Rows[8]["endframe"].ToString();
                                }
                            }
                            catch
                            {
                                txtBFrame9.Text = " ";
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
                            try
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
                                    txtCBFrame9.Text = dtathlets.Rows[8]["endframe"].ToString();
                                }
                            }
                            catch
                            {
                                txtCBFrame9.Text = " ";
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
                GetAllStartAthleteData(lessonid);
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
            clearAllVariableData();
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


        Label157.Text = "";
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
                lesson.LessonTypeId = 1;
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
                        lesson.SiteId = 11;//defualt site for customer is Baylor
                    }
                    lesson.CustomerId = custmer.CustomerId;
                    lesson.LessonTypeId = 1;
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
            #region[Insertdata into StartInitialData]
            try
            {
                _startinitialdata.LessonId = lesson.LessonId;
                _startinitialdata.SetFrontBlockDistanceI = convertDecimal(lblSetFrontBlockDistanceI.Text);
                _startinitialdata.SetRearBlockDistanceI = convertDecimal(lblSetRearBlockDistanceI.Text);
                _startinitialdata.SetFrontULAngleI = convertInt(lblSetFrontULAngleI.Text);
                _startinitialdata.SetRearULAngleI = convertInt(lblSetRearULAngleI.Text);
                _startinitialdata.SetFrontLLAngleI = convertInt(lblSetFrontLLAngleI.Text);
                _startinitialdata.SetRearLLAngleI = convertInt(lblSetRearLLAngleI.Text);
                _startinitialdata.SetTrunkAngleI = convertInt(lblSetTrunkAngleI.Text);
                _startinitialdata.SetCOGDistanceI = convertDecimal(lblSetCOGDistanceI.Text);
                _startinitialdata.BCRearFootClearanceTimeI = convertDecimal(lblBCRearFootClearanceTimeI.Text);
                _startinitialdata.BCFrontFootClearanceTimeI = convertDecimal(lblBCFrontFootClearanceTimeI.Text);
                _startinitialdata.BCRearLLAngleTakeoffI = convertInt(lblBCRearLLAngleTakeoffI.Text);
                _startinitialdata.BCFrontLLAngleTakeoffI = convertInt(lblBCFrontLLAngleTakeoffI.Text);
                _startinitialdata.BCTrunkAngleTakeoffI = convertInt(lblBCTrunkAngleTakeoffI.Text);
                _startinitialdata.BCLLAngleACI = convertInt(lblBCLLAngleACI.Text);
                _startinitialdata.BCAirTimeI = convertDecimal(lblBCAirTimeI.Text);
                _startinitialdata.BCStrideLengthI = convertDecimal(lblBCStrideLengthI.Text);
                _startinitialdata.Step1COGDistanceI = convertDecimal(lblStep1COGDistanceI.Text);
                _startinitialdata.Step1LLAngleTakeoffI = convertInt(lblStep1LLAngleTakeoffI.Text);
                _startinitialdata.Step1TrunkAngleTakeoffI = convertInt(lblStep1TrunkAngleTakeoffI.Text);
                _startinitialdata.Step1LLAngleACI = convertInt(lblStep1LLAngleACI.Text);
                _startinitialdata.Step1GroundTimeI = convertDecimal(lblStep1GroundTimeI.Text);

                _startinitialdata.Step1AirTimeI = convertDecimal(lblStep1AirTimeI.Text);
                _startinitialdata.Step1StrideLengthI = convertDecimal(lblStep1StrideLengthI.Text);
                _startinitialdata.Step2COGDistanceI = convertDecimal(lblStep2COGDistanceI.Text);
                _startinitialdata.Step2LLAngleTakeoffI = convertInt(lblStep2LLAngleTakeoffI.Text);
                _startinitialdata.Step2TrunkAngleTakeoffI = convertInt(lblStep2TrunkAngleTakeoffI.Text);

                _startinitialdata.Step2LLAngleACI = convertInt(lblStep2LLAngleACI.Text);
                _startinitialdata.Step2GroundTimeI = convertDecimal(lblStep2GroundTimeI.Text);
                _startinitialdata.Step2AirTimeI = convertDecimal(lblStep2AirTimeI.Text);

                _startinitialdata.Step2StrideLengthI = convertDecimal(lblStep2StrideLengthI.Text);
                _startinitialdata.Step3COGDistanceI = convertDecimal(lblStep3COGDistanceI.Text);
                _startinitialdata.TimeTo3mI = convertDecimal(lblTimeTo3mI.Text);
                _startinitialdata.TimeTo5mI = convertDecimal(lblTimeTo5mI.Text);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            //_startinitialdata.LessonId = Convert.ToInt32(DropDownList2.SelectedValue);
            string Start_initialdataid = sae.SelectStartInitialDataid(_startinitialdata.LessonId.ToString());
            if (Start_initialdataid == "")
            {
                _startinitialdata.InsertIntoStartInitialData();
            }
            else
            {
                _startinitialdata.UpdateStartInitialData();
            }
            #endregion[Insertdata into StartInitialData]
            #region[Insert Into StartCurrentData Table ]
            //current data
            try
            {
                _startinitialdata.LessonId = lesson.LessonId;
                _startinitialdata.SetFrontBlockDistanceI = convertDecimal(lblSetFrontBlockDistanceF.Text);
                _startinitialdata.SetRearBlockDistanceI = convertDecimal(lblSetRearBlockDistanceF.Text);
                _startinitialdata.SetFrontULAngleI = convertInt(lblSetFrontULAngleF.Text);
                _startinitialdata.SetRearULAngleI = convertInt(lblSetRearULAngleF.Text);
                _startinitialdata.SetFrontLLAngleI = convertInt(lblSetFrontLLAngleF.Text);
                _startinitialdata.SetRearLLAngleI = convertInt(lblSetRearLLAngleF.Text);
                _startinitialdata.SetTrunkAngleI = convertInt(lblSetTrunkAngleF.Text);
                _startinitialdata.SetCOGDistanceI = convertDecimal(lblSetCOGDistanceF.Text);
                _startinitialdata.BCRearFootClearanceTimeI = convertDecimal(lblBCRearFootClearanceTimeF.Text);
                _startinitialdata.BCFrontFootClearanceTimeI = convertDecimal(lblBCFrontFootClearanceTimeF.Text);

                _startinitialdata.BCRearLLAngleTakeoffI = convertInt(lblBCRearLLAngleTakeoffF.Text);
                _startinitialdata.BCFrontLLAngleTakeoffI = convertInt(lblBCFrontLLAngleTakeoffF.Text);
                _startinitialdata.BCTrunkAngleTakeoffI = convertInt(lblBCTrunkAngleTakeoffF.Text);
                _startinitialdata.BCLLAngleACI = convertInt(lblBCLLAngleACF.Text);
                _startinitialdata.BCAirTimeI = convertDecimal(lblBCAirTimeF.Text);
                _startinitialdata.BCStrideLengthI = convertDecimal(lblBCStrideLengthF.Text);
                _startinitialdata.Step1COGDistanceI = convertDecimal(lblStep1COGDistanceF.Text);
                _startinitialdata.Step1LLAngleTakeoffI = convertInt(lblStep1LLAngleTakeoffF.Text);
                _startinitialdata.Step1TrunkAngleTakeoffI = convertInt(lblStep1TrunkAngleTakeoffF.Text);
                _startinitialdata.Step1LLAngleACI = convertInt(lblStep1LLAngleACF.Text);
                _startinitialdata.Step1GroundTimeI = convertDecimal(lblStep1GroundTimeF.Text);
                _startinitialdata.Step1AirTimeI = convertDecimal(lblStep1AirTimeF.Text);
                _startinitialdata.Step1StrideLengthI = convertDecimal(lblStep1StrideLengthF.Text);
                _startinitialdata.Step2COGDistanceI = convertDecimal(lblStep2COGDistanceF.Text);
                _startinitialdata.Step2LLAngleTakeoffI = convertInt(lblStep2LLAngleTakeoffF.Text);
                _startinitialdata.Step2TrunkAngleTakeoffI = convertInt(lblStep2TrunkAngleTakeoffF.Text);
                _startinitialdata.Step2LLAngleACI = convertInt(lblStep2LLAngleACF.Text);

                _startinitialdata.Step2GroundTimeI = convertDecimal(lblStep2GroundTimeF.Text);
                _startinitialdata.Step2AirTimeI = convertDecimal(lblStep2AirTimeF.Text);
                _startinitialdata.Step2StrideLengthI = convertDecimal(lblStep2StrideLengthF.Text);
                _startinitialdata.Step3COGDistanceI = convertDecimal(lblStep3COGDistanceF.Text);
                _startinitialdata.TimeTo3mI = convertDecimal(lblTimeTo3mF.Text);
                _startinitialdata.TimeTo5mI = convertDecimal(lblTimeTo5mF.Text);

            }
            catch { }
            //_startinitialdata.LessonId = Convert.ToInt32(DropDownList2.SelectedValue);
            string Start_initialdataid1 = sae.SelectStartCurrentDataid(_startinitialdata.LessonId.ToString());
            if (Start_initialdataid1 == "")
            {
                _startinitialdata.InsertIntoStartCurrentData();
            }
            else
            {
                _startinitialdata.UpdateStartCurrentData();
            }
            #endregion[Insert Into StartCurrentData Table ]
            #region[Insert Into StartModelData Table ]
            //InsertUpdateStartModelData(LessonSelected, isNewLesson);
            try
            {
                _startinitialdata.LessonId = lesson.LessonId;
                _startinitialdata.SetFrontBlockDistanceI = convertDecimal(lblSetFrontBlockDistanceM1.Text);
                _startinitialdata.SetRearBlockDistanceI = convertDecimal(lblSetRearBlockDistanceM1.Text);
                _startinitialdata.SetFrontULAngleI = convertInt(lblSetFrontULAngleM1.Text);
                _startinitialdata.SetRearULAngleI = convertInt(lblSetRearULAngleM1.Text);
                _startinitialdata.SetFrontLLAngleI = convertInt(lblSetFrontLLAngleM1.Text);
                _startinitialdata.SetRearLLAngleI = convertInt(lblSetRearLLAngleM1.Text);
                _startinitialdata.SetTrunkAngleI = convertInt(lblSetTrunkAngleM1.Text);
                _startinitialdata.SetCOGDistanceI = convertDecimal(lblSetCOGDistanceM1.Text);
                _startinitialdata.BCRearFootClearanceTimeI = convertDecimal(lblBCRearFootClearanceTimeM1.Text);
                _startinitialdata.BCFrontFootClearanceTimeI = convertDecimal(lblBCFrontFootClearanceTimeM1.Text);
                _startinitialdata.BCRearLLAngleTakeoffI = convertInt(lblBCRearLLAngleTakeoffM1.Text);
                _startinitialdata.BCFrontLLAngleTakeoffI = convertInt(lblBCFrontLLAngleTakeoffM1.Text);
                _startinitialdata.BCTrunkAngleTakeoffI = convertInt(lblBCTrunkAngleTakeoffM1.Text);
                _startinitialdata.BCLLAngleACI = convertInt(lblBCLLAngleACM1.Text);
                _startinitialdata.BCAirTimeI = convertDecimal(lblBCAirTimeM1.Text);
                _startinitialdata.BCStrideLengthI = convertDecimal(lblBCStrideLengthM1.Text);
                _startinitialdata.Step1COGDistanceI = convertDecimal(lblStep1COGDistanceM1.Text);
                _startinitialdata.Step1LLAngleTakeoffI = convertInt(lblStep1LLAngleTakeoffM1.Text);
                _startinitialdata.Step1TrunkAngleTakeoffI = convertInt(lblStep1TrunkAngleTakeoffM1.Text);
                _startinitialdata.Step1LLAngleACI = convertInt(lblStep1LLAngleACM1.Text);
                _startinitialdata.Step1GroundTimeI = convertDecimal(lblStep1GroundTimeM1.Text);
                _startinitialdata.Step1AirTimeI = convertDecimal(lblStep1AirTimeM1.Text);
                _startinitialdata.Step1StrideLengthI = convertDecimal(lblStep1StrideLengthM1.Text);
                _startinitialdata.Step2COGDistanceI = convertDecimal(lblStep2COGDistanceM1.Text);
                _startinitialdata.Step2LLAngleTakeoffI = convertInt(lblStep2LLAngleTakeoffM1.Text);
                _startinitialdata.Step2TrunkAngleTakeoffI = convertInt(lblStep2TrunkAngleTakeoffM1.Text);
                _startinitialdata.Step2LLAngleACI = convertInt(lblStep2LLAngleACM1.Text);
                _startinitialdata.Step2GroundTimeI = convertDecimal(lblStep2GroundTimeM1.Text);
                _startinitialdata.Step2AirTimeI = convertDecimal(lblStep2AirTimeM1.Text);
                _startinitialdata.Step2StrideLengthI = convertDecimal(lblStep2StrideLengthM1.Text);
                _startinitialdata.Step3COGDistanceI = convertDecimal(lblStep3COGDistanceM1.Text);
                _startinitialdata.TimeTo3mI = convertDecimal(lblTimeTo3mM1.Text);
                _startinitialdata.TimeTo5mI = convertDecimal(lblTimeTo5mM1.Text);

            }
            catch { }
            //_startinitialdata.LessonId = Convert.ToInt32(DropDownList2.SelectedValue);
            string Start_initialdataid2 = sae.SelectStartModelDataid(_startinitialdata.LessonId.ToString());
            if (Start_initialdataid2 == "")
            {
                _startinitialdata.InsertIntoStartModelData();
            }
            else
            {
                _startinitialdata.UpdateStartModelData();
            }
            #endregion[Insert Into StartModelData Table ]
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
                InitialSideClips.MovieClipId++;
                if (txtBFrame9.Text != "")
                {
                    InitialSideClips.MovieId = IniitalSideMovieid;
                    InitialSideClips.BeginFrame = Convert.ToInt16(txtBFrame8.Text);
                    InitialSideClips.EndFrame = Convert.ToInt16(txtBFrame9.Text);
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
                InitialBackClips.MovieClipId++;
                if (txtBFrame9.Text != "")
                {
                    InitialBackClips.MovieId = IniitalbackMovieid;
                    InitialBackClips.BeginFrame = Convert.ToInt16(txtBFrame8.Text);
                    InitialBackClips.EndFrame = Convert.ToInt16(txtBFrame9.Text);
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
                CurrentSideClips.MovieClipId++;
                if (txtCBFrame9.Text != "")
                {
                    CurrentSideClips.MovieId = CurrentSideMovieid;
                    CurrentSideClips.BeginFrame = Convert.ToInt16(txtCBFrame8.Text);
                    CurrentSideClips.EndFrame = Convert.ToInt16(txtCBFrame9.Text);
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
                CurrentBackClips.MovieClipId++;
                if (txtCBFrame9.Text != "")
                {
                    CurrentBackClips.MovieId = CurrentBackMovieid;
                    CurrentBackClips.BeginFrame = Convert.ToInt16(txtCBFrame8.Text);
                    CurrentBackClips.EndFrame = Convert.ToInt16(txtCBFrame9.Text);
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
            //DropDownList1.SelectedValue = "noathlete";
            //DropDownList2.Items.Clear();
            //DropDownList2.Items.Add("Select Analysis Date and Location");
            //DropDownList2.Items[0].Value = "";
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
            Label157.Text = "Data saved successfully";
            int athleteSelected;
            athleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
            StartPageOnTrackSession startPageOnTrackSession = new StartPageOnTrackSession();
            startPageOnTrackSession.StartPageOnTrackSessionData(athleteSelected);
        }
        else
        {
            Label157.Text = "Please select Athlete";
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
        // readtext();
        txtCBFrame1.Text = "";
        txtCBFrame2.Text = "";
        txtCBFrame3.Text = "";
        txtCBFrame4.Text = "";
        txtCBFrame5.Text = "";
        txtCBFrame6.Text = "";
        txtCBFrame7.Text = "";
        txtCBFrame8.Text = "";
        txtCBFrame9.Text = "";

        txtBFrame1.Text = "";
        txtBFrame2.Text = "";
        txtBFrame3.Text = "";
        txtBFrame4.Text = "";
        txtBFrame5.Text = "";
        txtBFrame6.Text = "";
        txtBFrame7.Text = "";
        txtBFrame8.Text = "";
        txtBFrame9.Text = "";

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

        Label157.Text = "";

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
                FilePathClass2 objFilePathClass = new FilePathClass2();
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
                {
                }
                i++;
            }

            Gridview1.DataSource = arrFiles;
            Gridview1.DataBind();
            //   Label117.Text = "";
        }
        catch (Exception ex)
        { }
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
                FilePathClass2 objFilePathClass = new FilePathClass2();
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
                FilePathClass2 objFilePathClass = new FilePathClass2();
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
            //  Label117.Text = "";
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
        txtBFrame9.Text = "";
        txtCBFrame1.Text = "";
        txtCBFrame2.Text = "";
        txtCBFrame3.Text = "";
        txtCBFrame4.Text = "";
        txtCBFrame5.Text = "";
        txtCBFrame6.Text = "";
        txtCBFrame7.Text = "";
        txtCBFrame8.Text = "";
        txtCBFrame9.Text = "";
    }
    protected void btnDeleteInitialMovies_Click(object sender, EventArgs e)
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
            txtBFrame9.Text = "";
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
            txtCBFrame9.Text = "";
        }

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

            string Sprint_InitialDataId = sae.SelectStartInitialDataid(_lessonselected.ToString());

            if (Sprint_InitialDataId != "")
            {
                _startinitialdata.DeleteStartInitialLessonData(_lessonselected);
            }

            string Sprint_ModelDataId = sae.SelectSprintModelDataid(_lessonselected.ToString());
            if (Sprint_ModelDataId != "")
            {
                _startinitialdata.DeleteStartModelLessonData(_lessonselected);
            }

            string Sprint_CurrentDataId = sae.SelectSprintCurrentDataid(_lessonselected.ToString());
            if (Sprint_CurrentDataId != "")
            {
                _startinitialdata.DeleteStartCurrentLessonData(_lessonselected);
            }

            DataRepository.LessonProvider.Delete(_lessonselected);   //delete lesson 
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "refresh", "refresh();", true);

            StartPageOnTrackSession startPageOnTrackSession = new StartPageOnTrackSession();
            startPageOnTrackSession.StartPageOnTrackSessionData(_lessonselected);


        }
        catch (Exception ex)
        {
            ex.Message.ToString();
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
                                    if (position9 != "")
                                    {
                                        txtBFrame9.Text = position9;
                                    }
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
                                    if (position9 != "")
                                    {
                                        txtCBFrame9.Text = position9;
                                    }
                                    var position10 = packageChild.Element("position10").Value;
                                }
                            }
                        }
                        //}
                        //----------------------IniialSumamary -----------
                        //if (returnnode.Count() > 0)
                        if (returnnode.Count() > 0)
                        {
                            //if (lblSetFrontBlockDistanceI.Text == "")
                            //{
                            IEnumerable<XElement> SetPosition = returnnode.Elements("InitialSummary").Elements("SetPosition");
                            if (SetPosition.Count() > 0)
                            {
                                foreach (XElement packageChild in SetPosition)
                                {
                                    //----------<SetPosition>
                                    var FrontBlockDistance = packageChild.Element("FrontBlockDistance").Value;
                                    if (FrontBlockDistance != "")
                                    {
                                        lblSetFrontBlockDistanceI.Text = FrontBlockDistance;
                                    }
                                    var RearBlockDistance = packageChild.Element("RearBlockDistance").Value;
                                    if (RearBlockDistance != "")
                                    {
                                        lblSetRearBlockDistanceI.Text = RearBlockDistance;
                                    }
                                    var FrontUpperLegAngle = packageChild.Element("FrontUpperLegAngle").Value;
                                    if (FrontUpperLegAngle != "")
                                    {
                                        lblSetFrontULAngleI.Text = FrontUpperLegAngle;
                                    }
                                    var RearUpperLegAngle = packageChild.Element("RearUpperLegAngle").Value;
                                    if (RearUpperLegAngle != "")
                                    {
                                        lblSetRearULAngleI.Text = RearUpperLegAngle;
                                    }
                                    var FrontLowerLegAngle = packageChild.Element("FrontLowerLegAngle").Value;
                                    if (FrontLowerLegAngle != "")
                                    {
                                        lblSetFrontLLAngleI.Text = FrontLowerLegAngle;
                                    }
                                    var RearLowerLegAngle = packageChild.Element("RearLowerLegAngle").Value;
                                    if (RearLowerLegAngle != "")
                                    {
                                        lblSetRearLLAngleI.Text = RearLowerLegAngle;
                                    }
                                    var TrunkAngle = packageChild.Element("TrunkAngle").Value;
                                    if (TrunkAngle != "")
                                    {
                                        lblSetTrunkAngleI.Text = TrunkAngle;
                                    }
                                    var COGDistance = packageChild.Element("COGDistance").Value;
                                    if (COGDistance != "")
                                    {
                                        lblSetCOGDistanceI.Text = COGDistance;
                                    }
                                }
                            }

                            IEnumerable<XElement> BlockClearance = returnnode.Elements("InitialSummary").Elements("BlockClearance");
                            if (BlockClearance.Count() > 0)
                            {
                                foreach (XElement packageChild in BlockClearance)
                                {
                                    //--------------------<BlockClearance>
                                    var RearFootClearanceTime = packageChild.Element("RearFootClearanceTime").Value;
                                    if (RearFootClearanceTime != "")
                                    {
                                        lblBCRearFootClearanceTimeI.Text = RearFootClearanceTime;
                                    }
                                    var FrontFootClearanceTime = packageChild.Element("FrontFootClearanceTime").Value;
                                    if (FrontFootClearanceTime != "")
                                    {
                                        lblBCFrontFootClearanceTimeI.Text = FrontFootClearanceTime;
                                    }
                                    var RearLowerLegAngleAtRearTakeoff = packageChild.Element("RearLowerLegAngleAtRearTakeoff").Value;
                                    if (RearLowerLegAngleAtRearTakeoff != "")
                                    {
                                        lblBCRearLLAngleTakeoffI.Text = RearLowerLegAngleAtRearTakeoff;
                                    }
                                    var FrontLowerLegAngleAtFrontTakeoff = packageChild.Element("FrontLowerLegAngleAtFrontTakeoff").Value;
                                    if (FrontLowerLegAngleAtFrontTakeoff != "")
                                    {
                                        lblBCFrontLLAngleTakeoffI.Text = FrontLowerLegAngleAtFrontTakeoff;
                                    }
                                    var TrunkAngleAtTakeoff = packageChild.Element("TrunkAngleAtTakeoff").Value;
                                    if (TrunkAngleAtTakeoff != "")
                                    {
                                        lblBCTrunkAngleTakeoffI.Text = TrunkAngleAtTakeoff;
                                    }
                                    var LowerLegAngleAtAnkleCross = packageChild.Element("LowerLegAngleAtAnkleCross").Value;
                                    if (LowerLegAngleAtAnkleCross != "")
                                    {
                                        lblBCLLAngleACI.Text = LowerLegAngleAtAnkleCross;
                                    }
                                    var AirTime = packageChild.Element("AirTime").Value;
                                    if (AirTime != "")
                                    {
                                        lblBCAirTimeI.Text = AirTime;
                                    }
                                    var StrideLength = packageChild.Element("StrideLength").Value;
                                    if (StrideLength != "")
                                    {
                                        lblBCStrideLengthI.Text = StrideLength;
                                    }
                                }
                            }
                            IEnumerable<XElement> Step1 = returnnode.Elements("InitialSummary").Elements("Step1");
                            if (Step1.Count() > 0)
                            {
                                foreach (XElement packageChild in Step1)
                                {
                                    //----------------------------<Step1>
                                    var COGTouchdownDistance = packageChild.Element("COGTouchdownDistance").Value;
                                    if (COGTouchdownDistance != "")
                                    {
                                        lblStep1COGDistanceI.Text = COGTouchdownDistance;
                                    }
                                    var RearLowerLegAngleAtTakeoff = packageChild.Element("RearLowerLegAngleAtTakeoff").Value;
                                    if (RearLowerLegAngleAtTakeoff != "")
                                    {
                                        lblStep1LLAngleTakeoffI.Text = RearLowerLegAngleAtTakeoff;
                                    }
                                    var TrunkAngleatTakeoff = packageChild.Element("TrunkAngleatTakeoff").Value;
                                    if (TrunkAngleatTakeoff != "")
                                    {
                                        lblStep1TrunkAngleTakeoffI.Text = TrunkAngleatTakeoff;
                                    }
                                    var LowerLegAngleAtAnkleCross = packageChild.Element("LowerLegAngleAtAnkleCross").Value;
                                    if (LowerLegAngleAtAnkleCross != "")
                                    {
                                        lblStep1LLAngleACI.Text = LowerLegAngleAtAnkleCross;
                                    }
                                    var GroundTime = packageChild.Element("GroundTime").Value;
                                    if (GroundTime != "")
                                    {
                                        lblStep1GroundTimeI.Text = GroundTime;
                                    }
                                    var AirTime = packageChild.Element("AirTime").Value;
                                    if (AirTime != "")
                                    {
                                        lblStep1AirTimeI.Text = AirTime;
                                    }
                                    var StrideLength = packageChild.Element("StrideLength").Value;
                                    if (StrideLength != "")
                                    {
                                        lblStep1StrideLengthI.Text = StrideLength;
                                    }
                                }
                            }
                            IEnumerable<XElement> Step2 = returnnode.Elements("InitialSummary").Elements("Step2");
                            if (Step2.Count() > 0)
                            {
                                foreach (XElement packageChild in Step2)
                                {
                                    //--------------------------------- <Step2>
                                    var COGTouchdownDistance = packageChild.Element("COGTouchdownDistance").Value;
                                    if (COGTouchdownDistance != "")
                                    {
                                        lblStep2COGDistanceI.Text = COGTouchdownDistance;
                                    }
                                    var RearLowerLegAngleAtTakeoff = packageChild.Element("RearLowerLegAngleAtTakeoff").Value;
                                    if (RearLowerLegAngleAtTakeoff != "")
                                    {
                                        lblStep2LLAngleTakeoffI.Text = RearLowerLegAngleAtTakeoff;
                                    }
                                    var TrunkAngleatTakeoff = packageChild.Element("TrunkAngleatTakeoff").Value;
                                    if (TrunkAngleatTakeoff != "")
                                    {
                                        lblStep2TrunkAngleTakeoffI.Text = TrunkAngleatTakeoff;
                                    }
                                    var LowerLegAngleAtAnkleCross = packageChild.Element("LowerLegAngleAtAnkleCross").Value;
                                    if (LowerLegAngleAtAnkleCross != "")
                                    {
                                        lblStep2LLAngleACI.Text = LowerLegAngleAtAnkleCross;
                                    }
                                    var GroundTime = packageChild.Element("GroundTime").Value;
                                    if (GroundTime != "")
                                    {
                                        lblStep2GroundTimeI.Text = GroundTime;
                                    }
                                    var AirTime = packageChild.Element("AirTime").Value;
                                    if (AirTime != "")
                                    {
                                        lblStep2AirTimeI.Text = AirTime;
                                    }
                                    var StrideLength = packageChild.Element("StrideLength").Value;
                                    if (StrideLength != "")
                                    {
                                        lblStep2StrideLengthI.Text = StrideLength;
                                    }
                                }
                            }
                            IEnumerable<XElement> Step3 = returnnode.Elements("InitialSummary").Elements("Step3");
                            if (Step3.Count() > 0)
                            {
                                foreach (XElement packageChild in Step3)
                                {
                                    //---------------------------<Step3>
                                    var COGTouchdownDistance = packageChild.Element("COGTouchdownDistance").Value;
                                    if (COGTouchdownDistance != "")
                                    {
                                        lblStep3COGDistanceI.Text = COGTouchdownDistance;
                                    }
                                }
                            }
                            IEnumerable<XElement> TimetoMarker = returnnode.Elements("InitialSummary").Elements("TimetoMarker");
                            if (TimetoMarker.Count() > 0)
                            {
                                foreach (XElement packageChild in TimetoMarker)
                                {
                                    //-----------------------------------<TimetoMarker>
                                    var TimeTo3m = packageChild.Element("TimeTo3m").Value;
                                    if (TimeTo3m != "")
                                    {
                                        lblTimeTo3mI.Text = TimeTo3m;
                                    }
                                    var TimeTo5m = packageChild.Element("TimeTo5m").Value;
                                    if (TimeTo5m != "")
                                    {
                                        lblTimeTo5mI.Text = TimeTo5m;
                                    }
                                }
                            }
                            //}
                            //---------------------------<end> <InitialSummary> <end>-----------------------
                            if (returnnode.Count() > 0)
                            {
                                //if (lblSetFrontBlockDistanceF.Text == "")
                                //{
                                IEnumerable<XElement> CurrentSummarySetPosition = returnnode.Elements("CurrentSummary").Elements("SetPosition");
                                if (CurrentSummarySetPosition.Count() > 0)
                                {
                                    foreach (XElement packageChild in CurrentSummarySetPosition)
                                    {
                                        //----------<SetPosition>
                                        var FrontBlockDistance = packageChild.Element("FrontBlockDistance").Value;
                                        if (FrontBlockDistance != "")
                                        {
                                            lblSetFrontBlockDistanceF.Text = FrontBlockDistance;
                                        }
                                        var RearBlockDistance = packageChild.Element("RearBlockDistance").Value;
                                        if (RearBlockDistance != "")
                                        {
                                            lblSetRearBlockDistanceF.Text = RearBlockDistance;
                                        }
                                        var FrontUpperLegAngle = packageChild.Element("FrontUpperLegAngle").Value;
                                        if (FrontUpperLegAngle != "")
                                        {
                                            lblSetFrontULAngleF.Text = FrontUpperLegAngle;
                                        }
                                        var RearUpperLegAngle = packageChild.Element("RearUpperLegAngle").Value;
                                        if (RearUpperLegAngle != "")
                                        {
                                            lblSetRearULAngleF.Text = RearUpperLegAngle;
                                        }
                                        var FrontLowerLegAngle = packageChild.Element("FrontLowerLegAngle").Value;
                                        if (FrontLowerLegAngle != "")
                                        {
                                            lblSetFrontLLAngleF.Text = FrontLowerLegAngle;
                                        }
                                        var RearLowerLegAngle = packageChild.Element("RearLowerLegAngle").Value;
                                        if (RearLowerLegAngle != "")
                                        {
                                            lblSetRearLLAngleF.Text = RearLowerLegAngle;
                                        }
                                        var TrunkAngle = packageChild.Element("TrunkAngle").Value;
                                        if (TrunkAngle != "")
                                        {
                                            lblSetTrunkAngleF.Text = TrunkAngle;
                                        }
                                        var COGDistance = packageChild.Element("COGDistance").Value;
                                        if (COGDistance != "")
                                        {
                                            lblSetCOGDistanceF.Text = COGDistance;
                                        }
                                    }
                                }

                                IEnumerable<XElement> CurrentSummaryBlockClearance = returnnode.Elements("CurrentSummary").Elements("BlockClearance");
                                if (CurrentSummaryBlockClearance.Count() > 0)
                                {
                                    foreach (XElement packageChild in CurrentSummaryBlockClearance)
                                    {
                                        //--------------------<BlockClearance>
                                        var RearFootClearanceTime = packageChild.Element("RearFootClearanceTime").Value;
                                        if (RearFootClearanceTime != "")
                                        {
                                            lblBCRearFootClearanceTimeF.Text = RearFootClearanceTime;
                                        }
                                        var FrontFootClearanceTime = packageChild.Element("FrontFootClearanceTime").Value;
                                        if (FrontFootClearanceTime != "")
                                        {
                                            lblBCFrontFootClearanceTimeF.Text = FrontFootClearanceTime;
                                        }
                                        var RearLowerLegAngleAtRearTakeoff = packageChild.Element("RearLowerLegAngleAtRearTakeoff").Value;
                                        if (RearLowerLegAngleAtRearTakeoff != "")
                                        {
                                            lblBCRearLLAngleTakeoffF.Text = RearLowerLegAngleAtRearTakeoff;
                                        }
                                        var FrontLowerLegAngleAtFrontTakeoff = packageChild.Element("FrontLowerLegAngleAtFrontTakeoff").Value;
                                        if (FrontLowerLegAngleAtFrontTakeoff != "")
                                        {
                                            lblBCFrontLLAngleTakeoffF.Text = FrontLowerLegAngleAtFrontTakeoff;
                                        }
                                        var TrunkAngleAtTakeoff = packageChild.Element("TrunkAngleAtTakeoff").Value;
                                        if (TrunkAngleAtTakeoff != "")
                                        {
                                            lblBCTrunkAngleTakeoffF.Text = TrunkAngleAtTakeoff;
                                        }
                                        var LowerLegAngleAtAnkleCross = packageChild.Element("LowerLegAngleAtAnkleCross").Value;
                                        if (LowerLegAngleAtAnkleCross != "")
                                        {
                                            lblBCLLAngleACF.Text = LowerLegAngleAtAnkleCross;
                                        }
                                        var AirTime = packageChild.Element("AirTime").Value;
                                        if (AirTime != "")
                                        {
                                            lblBCAirTimeF.Text = AirTime;
                                        }
                                        var StrideLength = packageChild.Element("StrideLength").Value;
                                        if (StrideLength != "")
                                        {
                                            lblBCStrideLengthF.Text = StrideLength;
                                        }
                                    }
                                }
                                IEnumerable<XElement> CurrentSummaryStep1 = returnnode.Elements("CurrentSummary").Elements("Step1");
                                if (CurrentSummaryStep1.Count() > 0)
                                {
                                    foreach (XElement packageChild in CurrentSummaryStep1)
                                    {
                                        //----------------------------<Step1>
                                        var COGTouchdownDistance = packageChild.Element("COGTouchdownDistance").Value;
                                        if (COGTouchdownDistance != "")
                                        {
                                            lblStep1COGDistanceF.Text = COGTouchdownDistance;
                                        }
                                        var RearLowerLegAngleAtTakeoff = packageChild.Element("RearLowerLegAngleAtTakeoff").Value;
                                        if (RearLowerLegAngleAtTakeoff != "")
                                        {
                                            lblStep1LLAngleTakeoffF.Text = RearLowerLegAngleAtTakeoff;
                                        }
                                        var TrunkAngleatTakeoff = packageChild.Element("TrunkAngleatTakeoff").Value;
                                        if (TrunkAngleatTakeoff != "")
                                        {
                                            lblStep1TrunkAngleTakeoffF.Text = TrunkAngleatTakeoff;
                                        }
                                        var LowerLegAngleAtAnkleCross = packageChild.Element("LowerLegAngleAtAnkleCross").Value;
                                        if (LowerLegAngleAtAnkleCross != "")
                                        {
                                            lblStep1LLAngleACF.Text = LowerLegAngleAtAnkleCross;
                                        }
                                        var GroundTime = packageChild.Element("GroundTime").Value;
                                        if (GroundTime != "")
                                        {
                                            lblStep1GroundTimeF.Text = GroundTime;
                                        }
                                        var AirTime = packageChild.Element("AirTime").Value;
                                        if (AirTime != "")
                                        {
                                            lblStep1AirTimeF.Text = AirTime;
                                        }
                                        var StrideLength = packageChild.Element("StrideLength").Value;
                                        if (StrideLength != "")
                                        {
                                            lblStep1StrideLengthF.Text = StrideLength;
                                        }
                                    }
                                }
                                IEnumerable<XElement> CurrentSummaryStep2 = returnnode.Elements("CurrentSummary").Elements("Step2");
                                if (CurrentSummaryStep2.Count() > 0)
                                {
                                    foreach (XElement packageChild in CurrentSummaryStep2)
                                    {
                                        //--------------------------------- <Step2>
                                        var COGTouchdownDistance = packageChild.Element("COGTouchdownDistance").Value;
                                        if (COGTouchdownDistance != "")
                                        {
                                            lblStep2COGDistanceF.Text = COGTouchdownDistance;
                                        }
                                        var RearLowerLegAngleAtTakeoff = packageChild.Element("RearLowerLegAngleAtTakeoff").Value;
                                        if (RearLowerLegAngleAtTakeoff != "")
                                        {
                                            lblStep2LLAngleTakeoffF.Text = RearLowerLegAngleAtTakeoff;
                                        }
                                        var TrunkAngleatTakeoff = packageChild.Element("TrunkAngleatTakeoff").Value;
                                        if (TrunkAngleatTakeoff != "")
                                        {
                                            lblStep2TrunkAngleTakeoffF.Text = TrunkAngleatTakeoff;
                                        }
                                        var LowerLegAngleAtAnkleCross = packageChild.Element("LowerLegAngleAtAnkleCross").Value;
                                        if (LowerLegAngleAtAnkleCross != "")
                                        {
                                            lblStep2LLAngleACF.Text = LowerLegAngleAtAnkleCross;
                                        }
                                        var GroundTime = packageChild.Element("GroundTime").Value;
                                        if (GroundTime != "")
                                        {
                                            lblStep2GroundTimeF.Text = GroundTime;
                                        }
                                        var AirTime = packageChild.Element("AirTime").Value;
                                        if (AirTime != "")
                                        {
                                            lblStep2AirTimeF.Text = AirTime;
                                        }
                                        var StrideLength = packageChild.Element("StrideLength").Value;
                                        if (StrideLength != "")
                                        {
                                            lblStep2StrideLengthF.Text = StrideLength;
                                        }
                                    }
                                }
                                IEnumerable<XElement> CurrentSummaryStep3 = returnnode.Elements("CurrentSummary").Elements("Step3");
                                if (CurrentSummaryStep3.Count() > 0)
                                {
                                    foreach (XElement packageChild in CurrentSummaryStep3)
                                    {
                                        //---------------------------<Step3>
                                        var COGTouchdownDistance = packageChild.Element("COGTouchdownDistance").Value;
                                        if (COGTouchdownDistance != "")
                                        {
                                            lblStep3COGDistanceF.Text = COGTouchdownDistance;
                                        }
                                    }
                                }
                                IEnumerable<XElement> CurrentSummaryTimetoMarker = returnnode.Elements("CurrentSummary").Elements("TimetoMarker");
                                if (CurrentSummaryTimetoMarker.Count() > 0)
                                {
                                    foreach (XElement packageChild in CurrentSummaryTimetoMarker)
                                    {
                                        //-----------------------------------<TimetoMarker>
                                        var TimeTo3m = packageChild.Element("TimeTo3m").Value;
                                        if (TimeTo3m != "")
                                        {
                                            lblTimeTo3mF.Text = TimeTo3m;
                                        }
                                        var TimeTo5m = packageChild.Element("TimeTo5m").Value;
                                        if (TimeTo5m != "")
                                        {
                                            lblTimeTo5mF.Text = TimeTo5m;
                                        }
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
            //Label5.Visible = true;
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
        catch (Exception ex)
        {
            return date;
        }
    }

}
public class MissingVariableStart
{
    public string type { get; set; }
    public string variableName { get; set; }
}
public class FilePathClass2
{
    public int Index { get; set; }

    public string FilePath { get; set; }
}
