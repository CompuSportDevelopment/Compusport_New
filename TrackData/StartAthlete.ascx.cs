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
using mojoPortal.Business;
using mojoPortal.Business.WebHelpers;
using mojoPortal.Web;
//using compusport.Data;
//using compusport.Entities;
using System.Web.Mail;
using System.IO;
using System.Data.SqlClient;
using SwingModel.Data;
using SwingModel.Entities;
using System.Web.Script.Serialization;
using CompuSportDAL;
using System.Drawing;
public partial class TrackData_StartAthlete : System.Web.UI.UserControl
{

    SiteUser currentUser;
    //MpUsers mpuser;
    //MpUsers athlete;
    Lesson lesson;
    Customer customer;
    Customer customerid;
    //TList<MpUsers> userslist = new TList<MpUsers>();
    //TList<Lesson> lessonlist = new TList<Lesson>();
    int x;
    public string wmpfile = "";
    bool InitialExists = false;
    bool CurrentExists = false;

    //string ConnectionString = ConfigurationManager.ConnectionStrings["compusport.Data.ConnectionString"].ToString();
    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();



    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
        Guid MemGuid = new Guid(customer.AspnetMembershipUserId.ToString());
        MembershipUser user = Membership.GetUser(MemGuid);
        int id = customer.CustomerId;
        lesson = DataRepository.LessonProvider.GetByCustomerId(customer.CustomerId)[0];
        //    currentUser = SiteUtils.GetCurrentSiteUser();

        //    //customer = DataRepository.CustomerProvider.GetByCustomerId(currentUser.UserId);
        //    //mpuser = DataRepository.MpUsersProvider.GetByUserId(11);

        //    if (!IsPostBack)
        //    {
        //        lessonlist = DataRepository.LessonProvider.GetByUserId(mpuser.UserId);
        //        lessonlist.Sort("LessonDate DESC");
        //        x = 0;
        //        foreach (Lesson lesson in lessonlist)
        //        {
        //            if (lesson.LessonType.Equals(1))
        //            {
        //                x++;
        //                DropDownList2.Items.Add(lesson.LessonDate.ToShortDateString() + " - " + lesson.LessonLocation);
        //                DropDownList2.Items[x].Value = lesson.LessonId.ToString();
        //            }
        //        }
        //    }
    }

    public void GetAllStartAthleteData(int lessonid)
    {

        CompuSportDAL.SprintAthleteEdit sae1 = new CompuSportDAL.SprintAthleteEdit();
        ds = sae1.GetAllStartAthletesData(lessonid);

        //initial data
        lblSetFrontBlockDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetFrontBlockDistance"].ToString());
        lblSetRearBlockDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetRearBlockDistance"].ToString());
        lblSetFrontULAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetFrontULAngle"].ToString());
        lblSetRearULAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetRearULAngle"].ToString());
        lblSetFrontLLAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetFrontLLAngle"].ToString());
        lblSetRearLLAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetRearLLAngle"].ToString());
        lblSetTrunkAngleI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetFrontBlockDistance"].ToString());
        lblSetCOGDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["SetCOGDistance"].ToString());

        lblBCRearFootClearanceTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCRearFootClearanceTime"].ToString());
        lblBCFrontFootClearanceTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCFrontFootClearanceTime"].ToString());
        lblBCRearLLAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCRearLLAngleTakeoff"].ToString());
        lblBCFrontLLAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCFrontLLAngleTakeoff"].ToString());
        lblBCTrunkAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCTrunkAngleTakeoff"].ToString());
        lblBCLLAngleACI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCLLAngleAC"].ToString());
        lblBCAirTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCAirTime"].ToString());
        lblBCStrideRateI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BC StrideRate"].ToString());
        lblBCStrideLengthI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCRearFootClearanceTime"].ToString());
        lblBCVelocityI.Text = Convert.ToString(ds.Tables[0].Rows[0]["BC Velocity"].ToString());

        lblStep1COGDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1COGDistance"].ToString());
        lblStep1LLAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1LLAngleTakeoff"].ToString());
        lblStep1TrunkAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1TrunkAngleTakeoff"].ToString());
        lblStep1LLAngleACI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1LLAngleAC"].ToString());
        lblStep1GroundTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1GroundTime"].ToString());
        lblStep1AirTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1AirTime"].ToString());
        lblStep1StrideRateI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1 Stride Rate"].ToString());
        lblStep1StrideLengthI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1StrideLength"].ToString());
        lblStep1VelocityI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step1 Velocity"].ToString());

        lblStep2COGDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2COGDistance"].ToString());
        lblStep2LLAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2LLAngleTakeoff"].ToString());
        lblStep2TrunkAngleTakeoffI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2TrunkAngleTakeoff"].ToString());
        lblStep2LLAngleACI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2LLAngleAC"].ToString());
        lblStep2GroundTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2GroundTime"].ToString());
        lblStep2AirTimeI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2AirTime"].ToString());
        lblStep2StrideRateI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2 Stride Rate"].ToString());
        lblStep2StrideLengthI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2StrideLength"].ToString());
        lblStep2VelocityI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step2 Velocity"].ToString());

        lblStep3COGDistanceI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Step3COGDistance"].ToString());
        lblTimeTo3mI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TimeTo3m"].ToString());
        lblTimeTo5mI.Text = Convert.ToString(ds.Tables[0].Rows[0]["TimeTo5m"].ToString());

        //model data

        lblSetFrontBlockDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetFrontBlockDistance"].ToString());
        lblSetRearBlockDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetRearBlockDistance"].ToString());
        lblSetFrontULAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetFrontULAngle"].ToString());
        lblSetRearULAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetRearULAngle"].ToString());
        lblSetFrontLLAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetFrontLLAngle"].ToString());
        lblSetRearLLAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetRearLLAngle"].ToString());
        lblSetTrunkAngleM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetFrontBlockDistance"].ToString());
        lblSetCOGDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["SetCOGDistance"].ToString());

        lblBCRearFootClearanceTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BCRearFootClearanceTime"].ToString());
        lblBCFrontFootClearanceTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BCFrontFootClearanceTime"].ToString());
        lblBCRearLLAngleTakeoffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BCRearLLAngleTakeoff"].ToString());
        lblBCFrontLLAngleTakeoffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BCFrontLLAngleTakeoff"].ToString());
        lblBCTrunkAngleTakeoffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BCTrunkAngleTakeoff"].ToString());
        lblBCLLAngleACM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BCLLAngleAC"].ToString());
        lblBCAirTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BCAirTime"].ToString());
        lblBCStrideRateM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BC StrideRate"].ToString());
        lblBCStrideLengthM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BCRearFootClearanceTime"].ToString());
        lblBCVelocityM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["BC Velocity"].ToString());

        lblStep1COGDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1COGDistance"].ToString());
        lblStep1LLAngleTakeoffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1LLAngleTakeoff"].ToString());
        lblStep1TrunkAngleTakeoffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1TrunkAngleTakeoff"].ToString());
        lblStep1LLAngleACM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1LLAngleAC"].ToString());
        lblStep1GroundTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1GroundTime"].ToString());
        lblStep1AirTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1AirTime"].ToString());
        lblStep1StrideRateM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1 Stride Rate"].ToString());
        lblStep1StrideLengthM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1StrideLength"].ToString());
        lblStep1VelocityM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step1 Velocity"].ToString());

        lblStep2COGDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2COGDistance"].ToString());
        lblStep2LLAngleTakeoffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2LLAngleTakeoff"].ToString());
        lblStep2TrunkAngleTakeoffM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2TrunkAngleTakeoff"].ToString());
        lblStep2LLAngleACM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2LLAngleAC"].ToString());
        lblStep2GroundTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2GroundTime"].ToString());
        lblStep2AirTimeM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2AirTime"].ToString());
        lblStep2StrideRateM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2 Stride Rate"].ToString());
        lblStep2StrideLengthM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2StrideLength"].ToString());
        lblStep2VelocityM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step2 Velocity"].ToString());

        lblStep3COGDistanceM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Step3COGDistance"].ToString());
        lblTimeTo3mM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["TimeTo3m"].ToString());
        lblTimeTo5mM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["TimeTo5m"].ToString());


        //final data

        lblSetFrontBlockDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetFrontBlockDistance"].ToString());
        lblSetRearBlockDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetRearBlockDistance"].ToString());
        lblSetFrontULAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetFrontULAngle"].ToString());
        lblSetRearULAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetRearULAngle"].ToString());
        lblSetFrontLLAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetFrontLLAngle"].ToString());
        lblSetRearLLAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetRearLLAngle"].ToString());
        lblSetTrunkAngleF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetFrontBlockDistance"].ToString());
        lblSetCOGDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["SetCOGDistance"].ToString());

        lblBCRearFootClearanceTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCRearFootClearanceTime"].ToString());
        lblBCFrontFootClearanceTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCFrontFootClearanceTime"].ToString());
        lblBCRearLLAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCRearLLAngleTakeoff"].ToString());
        lblBCFrontLLAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCFrontLLAngleTakeoff"].ToString());
        lblBCTrunkAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCTrunkAngleTakeoff"].ToString());
        lblBCLLAngleACF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLLAngleAC"].ToString());
        lblBCAirTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCAirTime"].ToString());
        lblBCStrideRateF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BC StrideRate"].ToString());
        lblBCStrideLengthF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCRearFootClearanceTime"].ToString());
        lblBCVelocityF.Text = Convert.ToString(ds.Tables[2].Rows[0]["BC Velocity"].ToString());

        lblStep1COGDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1COGDistance"].ToString());
        lblStep1LLAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1LLAngleTakeoff"].ToString());
        lblStep1TrunkAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1TrunkAngleTakeoff"].ToString());
        lblStep1LLAngleACF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1LLAngleAC"].ToString());
        lblStep1GroundTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1GroundTime"].ToString());
        lblStep1AirTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1AirTime"].ToString());
        lblStep1StrideRateF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1 Stride Rate"].ToString());
        lblStep1StrideLengthF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1StrideLength"].ToString());
        lblStep1VelocityF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step1 Velocity"].ToString());

        lblStep2COGDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2COGDistance"].ToString());
        lblStep2LLAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2LLAngleTakeoff"].ToString());
        lblStep2TrunkAngleTakeoffF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2TrunkAngleTakeoff"].ToString());
        lblStep2LLAngleACF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2LLAngleAC"].ToString());
        lblStep2GroundTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2GroundTime"].ToString());
        lblStep2AirTimeF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2AirTime"].ToString());
        lblStep2StrideRateF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2 Stride Rate"].ToString());
        lblStep2StrideLengthF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2StrideLength"].ToString());
        lblStep2VelocityF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step2 Velocity"].ToString());

        lblStep3COGDistanceF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Step3COGDistance"].ToString());
        lblTimeTo3mF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TimeTo3m"].ToString());
        lblTimeTo5mF.Text = Convert.ToString(ds.Tables[2].Rows[0]["TimeTo5m"].ToString());

        //model 2 data

        lblSetFrontBlockDistanceM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["SetFrontBlockDistance"].ToString());
        lblSetRearBlockDistanceM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["SetRearBlockDistance"].ToString());
        lblSetFrontULAngleM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["SetFrontULAngle"].ToString());
        lblSetRearULAngleM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["SetRearULAngle"].ToString());
        lblSetFrontLLAngleM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["SetFrontLLAngle"].ToString());
        lblSetRearLLAngleM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["SetRearLLAngle"].ToString());
        lblSetTrunkAngleM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["SetFrontBlockDistance"].ToString());
        lblSetCOGDistanceM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["SetCOGDistance"].ToString());

        lblBCRearFootClearanceTimeM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["BCRearFootClearanceTime"].ToString());
        lblBCFrontFootClearanceTimeM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["BCFrontFootClearanceTime"].ToString());
        lblBCRearLLAngleTakeoffM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["BCRearLLAngleTakeoff"].ToString());
        lblBCFrontLLAngleTakeoffM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["BCFrontLLAngleTakeoff"].ToString());
        lblBCTrunkAngleTakeoffM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["BCTrunkAngleTakeoff"].ToString());
        lblBCLLAngleACM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["BCLLAngleAC"].ToString());
        lblBCAirTimeM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["BCAirTime"].ToString());
        lblBCStrideRateM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["BC StrideRate"].ToString());
        lblBCStrideLengthM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["BCRearFootClearanceTime"].ToString());
        lblBCVelocityM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["BC Velocity"].ToString());

        lblStep1COGDistanceM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step1COGDistance"].ToString());
        lblStep1LLAngleTakeoffM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step1LLAngleTakeoff"].ToString());
        lblStep1TrunkAngleTakeoffM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step1TrunkAngleTakeoff"].ToString());
        lblStep1LLAngleACM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step1LLAngleAC"].ToString());
        lblStep1GroundTimeM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step1GroundTime"].ToString());
        lblStep1AirTimeM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step1AirTime"].ToString());
        lblStep1StrideRateM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step1 Stride Rate"].ToString());
        lblStep1StrideLengthM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step1StrideLength"].ToString());
        lblStep1VelocityM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step1 Velocity"].ToString());

        lblStep2COGDistanceM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step2COGDistance"].ToString());
        lblStep2LLAngleTakeoffM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step2LLAngleTakeoff"].ToString());
        lblStep2TrunkAngleTakeoffM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step2TrunkAngleTakeoff"].ToString());
        lblStep2LLAngleACM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step2LLAngleAC"].ToString());
        lblStep2GroundTimeM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step2GroundTime"].ToString());
        lblStep2AirTimeM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step2AirTime"].ToString());
        lblStep2StrideRateM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step2 Stride Rate"].ToString());
        lblStep2StrideLengthM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step2StrideLength"].ToString());
        lblStep2VelocityM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step2 Velocity"].ToString());

        lblStep3COGDistanceM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Step3COGDistance"].ToString());
        lblTimeTo3mM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["TimeTo3m"].ToString());
        lblTimeTo5mM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["TimeTo5m"].ToString());


           

        //initial data

        if (!lblSetFrontBlockDistanceI.Text.Equals("") && (!lblSetFrontBlockDistanceM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblSetFrontBlockDistanceI.Text) - Convert.ToSingle(lblSetFrontBlockDistanceM1.Text)) >= Convert.ToSingle(.04))
                lblSetFrontBlockDistanceM1.ForeColor = Color.Red;
            else
                lblSetFrontBlockDistanceM1.ForeColor = Color.Black;
        }
        else
        {
            lblSetFrontBlockDistanceM1.ForeColor = Color.Black;
        }

        if (!lblSetRearBlockDistanceI.Text.Equals("") && (!lblSetRearBlockDistanceM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblSetRearBlockDistanceI.Text) - Convert.ToSingle(lblSetRearBlockDistanceM1.Text)) >= Convert.ToSingle(.04))
                lblSetRearBlockDistanceM1.ForeColor = Color.Red;
            else
                lblSetRearBlockDistanceM1.ForeColor = Color.Black;
        }
        else
        {
            lblSetRearBlockDistanceM1.ForeColor = Color.Black;
        }

        if (!lblSetFrontULAngleI.Text.Equals("") && (!lblSetFrontULAngleM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblSetFrontULAngleI.Text) - Convert.ToSingle(lblSetFrontULAngleM1.Text)) >= Convert.ToInt16(7))
                lblSetFrontULAngleM1.ForeColor = Color.Red;
            else
                lblSetFrontULAngleM1.ForeColor = Color.Black;
        }
        else
        {
            lblSetFrontULAngleM1.ForeColor = Color.Black;
        }

        if (!lblSetRearULAngleI.Text.Equals("") && (!lblSetRearULAngleM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblSetRearULAngleI.Text) - Convert.ToSingle(lblSetRearULAngleM1.Text)) >= Convert.ToInt16(7))
                lblSetRearULAngleM1.ForeColor = Color.Red;
            else
                lblSetRearULAngleM1.ForeColor = Color.Black;
        }
        else
        {
            lblSetRearULAngleM1.ForeColor = Color.Black;
        }

        if (!lblSetFrontLLAngleI.Text.Equals("") && (!lblSetFrontLLAngleM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblSetFrontLLAngleI.Text) - Convert.ToSingle(lblSetFrontLLAngleM1.Text)) >= Convert.ToInt16(7))
                lblSetFrontLLAngleM1.ForeColor = Color.Red;
            else
                lblSetFrontLLAngleM1.ForeColor = Color.Black;
        }
        else
        {
            lblSetRearULAngleM1.ForeColor = Color.Black;
        }

        if (!lblSetRearLLAngleI.Text.Equals("") && (!lblSetRearLLAngleM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblSetRearLLAngleI.Text) - Convert.ToSingle(lblSetRearLLAngleM1.Text)) >= Convert.ToInt16(7))
                lblSetRearLLAngleM1.ForeColor = Color.Red;
            else
                lblSetRearLLAngleM1.ForeColor = Color.Black;
        }
        else
        {
            lblSetRearLLAngleM1.ForeColor = Color.Black;
        }

        if (!lblSetTrunkAngleI.Text.Equals("") && (!lblSetTrunkAngleM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblSetTrunkAngleI.Text) - Convert.ToSingle(lblSetTrunkAngleM1.Text)) >= Convert.ToInt16(7))
                lblSetTrunkAngleM1.ForeColor = Color.Red;
            else
                lblSetTrunkAngleM1.ForeColor = Color.Black;
        }
        else
        {
            lblSetTrunkAngleM1.ForeColor = Color.Black;
        }

        if (!lblStep1COGDistanceI.Text.Equals("") && (!lblSetCOGDistanceM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblStep1COGDistanceI.Text) - Convert.ToSingle(lblSetCOGDistanceM1.Text)) >= Convert.ToSingle(.05))
                lblSetCOGDistanceM1.ForeColor = Color.Red;
            else
                lblSetCOGDistanceM1.ForeColor = Color.Black;
        }
        else
        {
            lblSetCOGDistanceM1.ForeColor = Color.Black;
        }

        if (!lblBCRearFootClearanceTimeI.Text.Equals("") && (!lblBCRearFootClearanceTimeM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblBCRearFootClearanceTimeI.Text) - Convert.ToSingle(lblBCRearFootClearanceTimeM1.Text) >= Convert.ToSingle(.02))
                lblBCRearFootClearanceTimeM1.ForeColor = Color.Red;
            else
                lblBCRearFootClearanceTimeM1.ForeColor = Color.Black;
        }
        else
        {
            lblBCRearFootClearanceTimeM1.ForeColor = Color.Black;
        }

        if (!lblBCFrontFootClearanceTimeI.Text.Equals("") && (!lblBCFrontFootClearanceTimeM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblBCFrontFootClearanceTimeI.Text) - Convert.ToSingle(lblBCFrontFootClearanceTimeM1.Text) >= Convert.ToSingle(.04))
                lblBCFrontFootClearanceTimeM1.ForeColor = Color.Red;
            else
                lblBCFrontFootClearanceTimeM1.ForeColor = Color.Black;
        }
        else
        {
            lblBCFrontFootClearanceTimeM1.ForeColor = Color.Black;
        }

        if (!lblBCRearLLAngleTakeoffI.Text.Equals("") && (!lblBCRearLLAngleTakeoffM1.Text.Equals("")))
        {
            if (Convert.ToInt16(lblBCRearLLAngleTakeoffI.Text) - Convert.ToInt16(lblBCRearLLAngleTakeoffM1.Text) >= Convert.ToInt16(7))
                lblBCRearLLAngleTakeoffM1.ForeColor = Color.Red;
            else
                lblBCRearLLAngleTakeoffM1.ForeColor = Color.Black;
        }
        else
        {
            lblBCRearLLAngleTakeoffM1.ForeColor = Color.Black;
        }

        if (!lblBCFrontLLAngleTakeoffI.Text.Equals("") && (!lblBCFrontLLAngleTakeoffM1.Text.Equals("")))
        {
            if (Convert.ToInt16(lblBCFrontLLAngleTakeoffI.Text) - Convert.ToInt16(lblBCFrontLLAngleTakeoffM1.Text) >= Convert.ToInt16(7))
                lblBCFrontLLAngleTakeoffM1.ForeColor = Color.Red;
            else
                lblBCFrontLLAngleTakeoffM1.ForeColor = Color.Black;
        }
        else
        {
            lblBCFrontLLAngleTakeoffM1.ForeColor = Color.Black;
        }

        if (!lblBCTrunkAngleTakeoffI.Text.Equals("") && (!lblBCTrunkAngleTakeoffM1.Text.Equals("")))
        {
            if (Convert.ToInt16(lblBCTrunkAngleTakeoffI.Text) - Convert.ToInt16(lblBCTrunkAngleTakeoffM1.Text) >= Convert.ToInt16(7))
                lblBCTrunkAngleTakeoffM1.ForeColor = Color.Red;
            else
                lblBCTrunkAngleTakeoffM1.ForeColor = Color.Black;
        }
        else
        {
            lblBCTrunkAngleTakeoffM1.ForeColor = Color.Black;
        }

        if (!lblBCLLAngleACI.Text.Equals("") && (!lblBCLLAngleACM1.Text.Equals("")))
        {
            if (Convert.ToInt16(lblBCLLAngleACI.Text) - Convert.ToInt16(lblBCLLAngleACM1.Text) <= Convert.ToInt16(-7))
                lblBCLLAngleACM1.ForeColor = Color.Red;
            else
                lblBCLLAngleACM1.ForeColor = Color.Black;
        }
        else
        {
            lblBCLLAngleACM1.ForeColor = Color.Black;
        }

        if (!lblBCAirTimeI.Text.Equals("") && (!lblBCAirTimeM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblBCAirTimeI.Text) - Convert.ToSingle(lblBCAirTimeM1.Text) >= Convert.ToSingle(.02))
                lblBCAirTimeM1.ForeColor = Color.Red;
            else
                lblBCAirTimeM1.ForeColor = Color.Black;
        }
        else
        {
            lblBCAirTimeM1.ForeColor = Color.Black;
        }
        if (!lblBCStrideRateI.Text.Equals("") && (!lblBCStrideRateM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblBCStrideRateI.Text) - Convert.ToSingle(lblBCStrideRateM1.Text) <= Convert.ToSingle(-0.2))
                lblBCStrideRateM1.ForeColor = Color.Red;
            else
                lblBCStrideRateM1.ForeColor = Color.Black;
        }
        else
        {
            lblBCStrideRateM1.ForeColor = Color.Black;
        }

        if (!lblBCStrideLengthI.Text.Equals("") && (!lblBCStrideLengthM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblBCStrideLengthI.Text) - Convert.ToSingle(lblBCStrideLengthM1.Text) >= Convert.ToSingle(.05))
                lblBCStrideLengthM1.ForeColor = Color.Red;
            else
                lblBCStrideLengthM1.ForeColor = Color.Black;
        }
        else
        {
            lblBCStrideLengthM1.ForeColor = Color.Black;
        }

        if (!lblBCVelocityI.Text.Equals("") && (!lblBCVelocityM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblBCVelocityI.Text) - Convert.ToSingle(lblBCVelocityM1.Text) <= Convert.ToSingle(-0.5))
                lblBCVelocityM1.ForeColor = Color.Red;
            else
                lblBCVelocityM1.ForeColor = Color.Black;
        }
        else
        {
            lblBCVelocityM1.ForeColor = Color.Black;
        }

        if (!lblStep1COGDistanceI.Text.Equals("") && (!lblStep1COGDistanceM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblStep1COGDistanceI.Text) - Convert.ToSingle(lblStep1COGDistanceM1.Text)) >= Convert.ToSingle(.05))
                lblStep1COGDistanceM1.ForeColor = Color.Red;
            else
                lblStep1COGDistanceM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep1COGDistanceM1.ForeColor = Color.Black;
        }
        if (!lblStep1LLAngleTakeoffI.Text.Equals("") && (!lblStep1LLAngleTakeoffM1.Text.Equals("")))
        {
            if (Convert.ToInt16(lblStep1LLAngleTakeoffI.Text) - Convert.ToInt16(lblStep1LLAngleTakeoffM1.Text) >= Convert.ToInt16(7))
                lblStep1LLAngleTakeoffM1.ForeColor = Color.Red;
            else
                lblStep1LLAngleTakeoffM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep1LLAngleTakeoffM1.ForeColor = Color.Black;
        }

        if (!lblStep1TrunkAngleTakeoffI.Text.Equals("") && (!lblStep1TrunkAngleTakeoffM1.Text.Equals("")))
        {
            if (Convert.ToInt16(lblStep1TrunkAngleTakeoffI.Text) - Convert.ToInt16(lblStep1TrunkAngleTakeoffM1.Text) >= Convert.ToInt16(7))
                lblStep1TrunkAngleTakeoffM1.ForeColor = Color.Red;
            else
                lblStep1TrunkAngleTakeoffM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep1TrunkAngleTakeoffM1.ForeColor = Color.Black;
        }


        if (!lblStep1LLAngleACI.Text.Equals("") && (!lblStep1LLAngleACM1.Text.Equals("")))
        {
            if (Convert.ToInt16(lblStep1LLAngleACI.Text) - Convert.ToInt16(lblStep1LLAngleACM1.Text) <= Convert.ToInt16(-7))
                lblStep1LLAngleACM1.ForeColor = Color.Red;
            else
                lblStep1LLAngleACM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep1LLAngleACM1.ForeColor = Color.Black;
        }


        if (!lblStep1GroundTimeI.Text.Equals("") && (!lblStep1LLAngleACM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep1GroundTimeI.Text) - Convert.ToSingle(lblStep1LLAngleACM1.Text) >= Convert.ToSingle(.02))
                lblStep1LLAngleACM1.ForeColor = Color.Red;
            else
                lblStep1LLAngleACM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep1LLAngleACM1.ForeColor = Color.Black;
        }

        if (!lblStep1AirTimeI.Text.Equals("") && (!lblStep1AirTimeM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep1AirTimeI.Text) - Convert.ToSingle(lblStep1AirTimeM1.Text) >= Convert.ToSingle(.02))
                lblStep1AirTimeM1.ForeColor = Color.Red;
            else
                lblStep1AirTimeM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep1AirTimeM1.ForeColor = Color.Black;
        }

        if (!lblStep1StrideRateI.Text.Equals("") && (!lblStep1StrideRateM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep1StrideRateI.Text) - Convert.ToSingle(lblStep1StrideRateM1.Text) <= Convert.ToSingle(-0.2))
                lblStep1StrideRateM1.ForeColor = Color.Red;
            else
                lblStep1StrideRateM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep1StrideRateM1.ForeColor = Color.Black;
        }

        if (!lblStep1StrideLengthI.Text.Equals("") && (!lblStep1StrideLengthM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep1StrideLengthI.Text) - Convert.ToSingle(lblStep1StrideLengthM1.Text) >= Convert.ToSingle(.05))
                lblStep1StrideLengthM1.ForeColor = Color.Red;
            else
                lblStep1StrideLengthM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep1StrideLengthM1.ForeColor = Color.Black;
        }
        if (!lblStep1VelocityI.Text.Equals("") && (!lblStep1VelocityM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep1VelocityI.Text) - Convert.ToSingle(lblStep1VelocityM1.Text) <= Convert.ToSingle(-0.5))
                lblStep1VelocityM1.ForeColor = Color.Red;
            else
                lblStep1VelocityM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep1VelocityM1.ForeColor = Color.Black;
        }

        if (!lblStep2COGDistanceI.Text.Equals("") && (!lblStep2COGDistanceM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblStep2COGDistanceI.Text) - Convert.ToSingle(lblStep2COGDistanceM1.Text)) >= Convert.ToSingle(.05))
                lblStep2COGDistanceM1.ForeColor = Color.Red;
            else
                lblStep2COGDistanceM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep2COGDistanceM1.ForeColor = Color.Black;
        }

        if (!lblStep2LLAngleTakeoffI.Text.Equals("") && (!lblStep2LLAngleTakeoffM1.Text.Equals("")))
        {
            if (Convert.ToInt16(lblStep1VelocityI.Text) - Convert.ToInt16(lblStep2LLAngleTakeoffM1.Text) >= Convert.ToInt16(7))
                lblStep2LLAngleTakeoffM1.ForeColor = Color.Red;
            else
                lblStep2LLAngleTakeoffM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep2LLAngleTakeoffM1.ForeColor = Color.Black;
        }

        if (!lblStep2TrunkAngleTakeoffI.Text.Equals("") && (!lblStep2LLAngleTakeoffM1.Text.Equals("")))
        {
            if (Convert.ToInt16(lblStep2TrunkAngleTakeoffI.Text) - Convert.ToInt16(lblStep2LLAngleTakeoffM1.Text) >= Convert.ToInt16(7))
                lblStep2LLAngleTakeoffM1.ForeColor = Color.Red;
            else
                lblStep2LLAngleTakeoffM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep2LLAngleTakeoffM1.ForeColor = Color.Black;
        }
        if (!lblStep2LLAngleACI.Text.Equals("") && (!lblStep2LLAngleACM1.Text.Equals("")))
        {
            if (Convert.ToInt16(lblStep2LLAngleACI.Text) - Convert.ToInt16(lblStep2LLAngleACM1.Text) <= Convert.ToInt16(-7))
                lblStep2LLAngleACM1.ForeColor = Color.Red;
            else
                lblStep2LLAngleACM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep2LLAngleACM1.ForeColor = Color.Black;
        }

        if (!lblStep2GroundTimeI.Text.Equals("") && (!lblStep2GroundTimeM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep2GroundTimeI.Text) - Convert.ToSingle(lblStep2GroundTimeM1.Text) >= Convert.ToSingle(.02))
                lblStep2GroundTimeM1.ForeColor = Color.Red;
            else
                lblStep2GroundTimeM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep2GroundTimeM1.ForeColor = Color.Black;
        }
        if (!lblStep2AirTimeI.Text.Equals("") && (!lblStep2AirTimeM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep2AirTimeI.Text) - Convert.ToSingle(lblStep2AirTimeM1.Text) >= Convert.ToSingle(.02))
                lblStep2AirTimeM1.ForeColor = Color.Red;
            else
                lblStep2AirTimeM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep2AirTimeM1.ForeColor = Color.Black;
        }

        if (!lblStep2StrideRateI.Text.Equals("") && (!lblStep2StrideRateM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep2AirTimeI.Text) - Convert.ToSingle(lblStep2StrideRateM1.Text) <= Convert.ToSingle(-0.2))
                lblStep2StrideRateM1.ForeColor = Color.Red;
            else
                lblStep2StrideRateM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep2StrideRateM1.ForeColor = Color.Black;
        }
        if (!lblStep2StrideLengthI.Text.Equals("") && (!lblStep2StrideLengthM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep2StrideLengthI.Text) - Convert.ToSingle(lblStep2StrideLengthM1.Text) >= Convert.ToSingle(.05))
                lblStep2StrideLengthM1.ForeColor = Color.Red;
            else
                lblStep2StrideLengthM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep2StrideLengthM1.ForeColor = Color.Black;
        }
        if (!lblStep2VelocityI.Text.Equals("") && (!lblStep2VelocityM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep2VelocityI.Text) - Convert.ToSingle(lblStep2VelocityM1.Text) <= Convert.ToSingle(-0.5))
                lblStep2VelocityM1.ForeColor = Color.Red;
            else
                lblStep2VelocityM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep2VelocityM1.ForeColor = Color.Black;
        }
        if (!lblStep3COGDistanceI.Text.Equals("") && (!lblStep3COGDistanceM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblStep2VelocityI.Text) - Convert.ToSingle(lblStep3COGDistanceM1.Text)) >= Convert.ToSingle(.05))
                lblStep3COGDistanceM1.ForeColor = Color.Red;
            else
                lblStep3COGDistanceM1.ForeColor = Color.Black;
        }
        else
        {
            lblStep3COGDistanceM1.ForeColor = Color.Black;
        }
        if (!lblTimeTo3mI.Text.Equals("") && (!lblTimeTo3mM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep2VelocityI.Text) - Convert.ToSingle(lblTimeTo3mM1.Text) >= Convert.ToSingle(0.05))
                lblTimeTo3mM1.ForeColor = Color.Red;
            else
                lblTimeTo3mM1.ForeColor = Color.Black;
        }
        else
        {
            lblTimeTo3mM1.ForeColor = Color.Black;
        }
        if (!lblTimeTo5mI.Text.Equals("") && (!lblTimeTo5mM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblTimeTo5mI.Text) - Convert.ToSingle(lblTimeTo5mM1.Text) >= Convert.ToSingle(0.05))
                lblTimeTo5mM1.ForeColor = Color.Red;
            else
                lblTimeTo5mM1.ForeColor = Color.Black;
        }
        else
        {
            lblTimeTo5mM1.ForeColor = Color.Black;
        }


        //for final data

        if (!lblSetFrontBlockDistanceF.Text.Equals("") && (!lblSetFrontBlockDistanceM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblSetFrontBlockDistanceF.Text) - Convert.ToSingle(lblSetFrontBlockDistanceM2.Text)) >= Convert.ToSingle(.04))
                lblSetFrontBlockDistanceM2.ForeColor = Color.Red;
            else
                lblSetFrontBlockDistanceM2.ForeColor = Color.Black;
        }
        else
        {
            lblSetFrontBlockDistanceM2.ForeColor = Color.Black;
        }

        if (!lblSetRearBlockDistanceF.Text.Equals("") && (!lblSetRearBlockDistanceM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblSetRearBlockDistanceF.Text) - Convert.ToSingle(lblSetRearBlockDistanceM2.Text)) >= Convert.ToSingle(.04))
                lblSetRearBlockDistanceM2.ForeColor = Color.Red;
            else
                lblSetRearBlockDistanceM2.ForeColor = Color.Black;
        }
        else
        {
            lblSetRearBlockDistanceM2.ForeColor = Color.Black;
        }

        if (!lblSetFrontULAngleF.Text.Equals("") && (!lblSetFrontULAngleM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblSetFrontULAngleF.Text) - Convert.ToSingle(lblSetFrontULAngleM2.Text)) >= Convert.ToInt16(7))
                lblSetFrontULAngleM2.ForeColor = Color.Red;
            else
                lblSetFrontULAngleM2.ForeColor = Color.Black;
        }
        else
        {
            lblSetFrontULAngleM2.ForeColor = Color.Black;
        }

        if (!lblSetRearULAngleF.Text.Equals("") && (!lblSetRearULAngleM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblSetRearULAngleF.Text) - Convert.ToSingle(lblSetRearULAngleM2.Text)) >= Convert.ToInt16(7))
                lblSetRearULAngleM2.ForeColor = Color.Red;
            else
                lblSetRearULAngleM2.ForeColor = Color.Black;
        }
        else
        {
            lblSetRearULAngleM2.ForeColor = Color.Black;
        }

        if (!lblSetFrontLLAngleF.Text.Equals("") && (!lblSetFrontLLAngleM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblSetFrontLLAngleF.Text) - Convert.ToSingle(lblSetFrontLLAngleM2.Text)) >= Convert.ToInt16(7))
                lblSetFrontLLAngleM2.ForeColor = Color.Red;
            else
                lblSetFrontLLAngleM2.ForeColor = Color.Black;
        }
        else
        {
            lblSetRearULAngleM2.ForeColor = Color.Black;
        }

        if (!lblSetRearLLAngleF.Text.Equals("") && (!lblSetRearLLAngleM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblSetRearLLAngleF.Text) - Convert.ToSingle(lblSetRearLLAngleM2.Text)) >= Convert.ToInt16(7))
                lblSetRearLLAngleM2.ForeColor = Color.Red;
            else
                lblSetRearLLAngleM2.ForeColor = Color.Black;
        }
        else
        {
            lblSetRearLLAngleM2.ForeColor = Color.Black;
        }

        if (!lblSetTrunkAngleF.Text.Equals("") && (!lblSetTrunkAngleM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblSetTrunkAngleF.Text) - Convert.ToSingle(lblSetTrunkAngleM2.Text)) >= Convert.ToInt16(7))
                lblSetTrunkAngleM2.ForeColor = Color.Red;
            else
                lblSetTrunkAngleM2.ForeColor = Color.Black;
        }
        else
        {
            lblSetTrunkAngleM2.ForeColor = Color.Black;
        }

        if (!lblStep1COGDistanceF.Text.Equals("") && (!lblSetCOGDistanceM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblStep1COGDistanceF.Text) - Convert.ToSingle(lblSetCOGDistanceM2.Text)) >= Convert.ToSingle(.05))
                lblSetCOGDistanceM2.ForeColor = Color.Red;
            else
                lblSetCOGDistanceM2.ForeColor = Color.Black;
        }
        else
        {
            lblSetCOGDistanceM2.ForeColor = Color.Black;
        }

        if (!lblBCRearFootClearanceTimeF.Text.Equals("") && (!lblBCRearFootClearanceTimeM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblBCRearFootClearanceTimeF.Text) - Convert.ToSingle(lblBCRearFootClearanceTimeM2.Text) >= Convert.ToSingle(.02))
                lblBCRearFootClearanceTimeM2.ForeColor = Color.Red;
            else
                lblBCRearFootClearanceTimeM2.ForeColor = Color.Black;
        }
        else
        {
            lblBCRearFootClearanceTimeM2.ForeColor = Color.Black;
        }

        if (!lblBCFrontFootClearanceTimeF.Text.Equals("") && (!lblBCFrontFootClearanceTimeM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblBCFrontFootClearanceTimeF.Text) - Convert.ToSingle(lblBCFrontFootClearanceTimeM2.Text) >= Convert.ToSingle(.04))
                lblBCFrontFootClearanceTimeM2.ForeColor = Color.Red;
            else
                lblBCFrontFootClearanceTimeM2.ForeColor = Color.Black;
        }
        else
        {
            lblBCFrontFootClearanceTimeM2.ForeColor = Color.Black;
        }

        if (!lblBCRearLLAngleTakeoffF.Text.Equals("") && (!lblBCRearLLAngleTakeoffM2.Text.Equals("")))
        {
            if (Convert.ToInt16(lblBCRearLLAngleTakeoffF.Text) - Convert.ToInt16(lblBCRearLLAngleTakeoffM2.Text) >= Convert.ToInt16(7))
                lblBCRearLLAngleTakeoffM2.ForeColor = Color.Red;
            else
                lblBCRearLLAngleTakeoffM2.ForeColor = Color.Black;
        }
        else
        {
            lblBCRearLLAngleTakeoffM2.ForeColor = Color.Black;
        }

        if (!lblBCFrontLLAngleTakeoffF.Text.Equals("") && (!lblBCFrontLLAngleTakeoffM2.Text.Equals("")))
        {
            if (Convert.ToInt16(lblBCFrontLLAngleTakeoffF.Text) - Convert.ToInt16(lblBCFrontLLAngleTakeoffM2.Text) >= Convert.ToInt16(7))
                lblBCFrontLLAngleTakeoffM2.ForeColor = Color.Red;
            else
                lblBCFrontLLAngleTakeoffM2.ForeColor = Color.Black;
        }
        else
        {
            lblBCFrontLLAngleTakeoffM2.ForeColor = Color.Black;
        }

        if (!lblBCTrunkAngleTakeoffF.Text.Equals("") && (!lblBCTrunkAngleTakeoffM2.Text.Equals("")))
        {
            if (Convert.ToInt16(lblBCTrunkAngleTakeoffF.Text) - Convert.ToInt16(lblBCTrunkAngleTakeoffM2.Text) >= Convert.ToInt16(7))
                lblBCTrunkAngleTakeoffM2.ForeColor = Color.Red;
            else
                lblBCTrunkAngleTakeoffM2.ForeColor = Color.Black;
        }
        else
        {
            lblBCTrunkAngleTakeoffM2.ForeColor = Color.Black;
        }

        if (!lblBCLLAngleACF.Text.Equals("") && (!lblBCLLAngleACM2.Text.Equals("")))
        {
            if (Convert.ToInt16(lblBCLLAngleACF.Text) - Convert.ToInt16(lblBCLLAngleACM2.Text) <= Convert.ToInt16(-7))
                lblBCLLAngleACM2.ForeColor = Color.Red;
            else
                lblBCLLAngleACM2.ForeColor = Color.Black;
        }
        else
        {
            lblBCLLAngleACM2.ForeColor = Color.Black;
        }

        if (!lblBCAirTimeF.Text.Equals("") && (!lblBCAirTimeM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblBCAirTimeF.Text) - Convert.ToSingle(lblBCAirTimeM2.Text) >= Convert.ToSingle(.02))
                lblBCAirTimeM2.ForeColor = Color.Red;
            else
                lblBCAirTimeM2.ForeColor = Color.Black;
        }
        else
        {
            lblBCAirTimeM2.ForeColor = Color.Black;
        }
        if (!lblBCStrideRateF.Text.Equals("") && (!lblBCStrideRateM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblBCStrideRateF.Text) - Convert.ToSingle(lblBCStrideRateM2.Text) <= Convert.ToSingle(-0.2))
                lblBCStrideRateM2.ForeColor = Color.Red;
            else
                lblBCStrideRateM2.ForeColor = Color.Black;
        }
        else
        {
            lblBCStrideRateM2.ForeColor = Color.Black;
        }

        if (!lblBCStrideLengthF.Text.Equals("") && (!lblBCStrideLengthM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblBCStrideLengthF.Text) - Convert.ToSingle(lblBCStrideLengthM2.Text) >= Convert.ToSingle(.05))
                lblBCStrideLengthM2.ForeColor = Color.Red;
            else
                lblBCStrideLengthM2.ForeColor = Color.Black;
        }
        else
        {
            lblBCStrideLengthM2.ForeColor = Color.Black;
        }

        if (!lblBCVelocityF.Text.Equals("") && (!lblBCVelocityM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblBCVelocityF.Text) - Convert.ToSingle(lblBCVelocityM2.Text) <= Convert.ToSingle(-0.5))
                lblBCVelocityM2.ForeColor = Color.Red;
            else
                lblBCVelocityM2.ForeColor = Color.Black;
        }
        else
        {
            lblBCVelocityM2.ForeColor = Color.Black;
        }

        if (!lblStep1COGDistanceF.Text.Equals("") && (!lblStep1COGDistanceM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblStep1COGDistanceF.Text) - Convert.ToSingle(lblStep1COGDistanceM2.Text)) >= Convert.ToSingle(.05))
                lblStep1COGDistanceM2.ForeColor = Color.Red;
            else
                lblStep1COGDistanceM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep1COGDistanceM2.ForeColor = Color.Black;
        }
        if (!lblStep1LLAngleTakeoffF.Text.Equals("") && (!lblStep1LLAngleTakeoffM2.Text.Equals("")))
        {
            if (Convert.ToInt16(lblStep1LLAngleTakeoffF.Text) - Convert.ToInt16(lblStep1LLAngleTakeoffM2.Text) >= Convert.ToInt16(7))
                lblStep1LLAngleTakeoffM2.ForeColor = Color.Red;
            else
                lblStep1LLAngleTakeoffM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep1LLAngleTakeoffM2.ForeColor = Color.Black;
        }

        if (!lblStep1TrunkAngleTakeoffF.Text.Equals("") && (!lblStep1TrunkAngleTakeoffM2.Text.Equals("")))
        {
            if (Convert.ToInt16(lblStep1TrunkAngleTakeoffF.Text) - Convert.ToInt16(lblStep1TrunkAngleTakeoffM2.Text) >= Convert.ToInt16(7))
                lblStep1TrunkAngleTakeoffM2.ForeColor = Color.Red;
            else
                lblStep1TrunkAngleTakeoffM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep1TrunkAngleTakeoffM2.ForeColor = Color.Black;
        }


        if (!lblStep1LLAngleACF.Text.Equals("") && (!lblStep1LLAngleACM2.Text.Equals("")))
        {
            if (Convert.ToInt16(lblStep1LLAngleACF.Text) - Convert.ToInt16(lblStep1LLAngleACM2.Text) <= Convert.ToInt16(-7))
                lblStep1LLAngleACM2.ForeColor = Color.Red;
            else
                lblStep1LLAngleACM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep1LLAngleACM2.ForeColor = Color.Black;
        }


        if (!lblStep1GroundTimeF.Text.Equals("") && (!lblStep1LLAngleACM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep1GroundTimeF.Text) - Convert.ToSingle(lblStep1LLAngleACM2.Text) >= Convert.ToSingle(.02))
                lblStep1LLAngleACM2.ForeColor = Color.Red;
            else
                lblStep1LLAngleACM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep1LLAngleACM2.ForeColor = Color.Black;
        }

        if (!lblStep1AirTimeF.Text.Equals("") && (!lblStep1AirTimeM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep1AirTimeF.Text) - Convert.ToSingle(lblStep1AirTimeM2.Text) >= Convert.ToSingle(.02))
                lblStep1AirTimeM2.ForeColor = Color.Red;
            else
                lblStep1AirTimeM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep1AirTimeM2.ForeColor = Color.Black;
        }

        if (!lblStep1StrideRateF.Text.Equals("") && (!lblStep1StrideRateM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep1StrideRateF.Text) - Convert.ToSingle(lblStep1StrideRateM2.Text) <= Convert.ToSingle(-0.2))
                lblStep1StrideRateM2.ForeColor = Color.Red;
            else
                lblStep1StrideRateM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep1StrideRateM2.ForeColor = Color.Black;
        }

        if (!lblStep1StrideLengthF.Text.Equals("") && (!lblStep1StrideLengthM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep1StrideLengthF.Text) - Convert.ToSingle(lblStep1StrideLengthM2.Text) >= Convert.ToSingle(.05))
                lblStep1StrideLengthM2.ForeColor = Color.Red;
            else
                lblStep1StrideLengthM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep1StrideLengthM2.ForeColor = Color.Black;
        }
        if (!lblStep1VelocityF.Text.Equals("") && (!lblStep1VelocityM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep1VelocityF.Text) - Convert.ToSingle(lblStep1VelocityM2.Text) <= Convert.ToSingle(-0.5))
                lblStep1VelocityM2.ForeColor = Color.Red;
            else
                lblStep1VelocityM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep1VelocityM2.ForeColor = Color.Black;
        }

        if (!lblStep2COGDistanceF.Text.Equals("") && (!lblStep2COGDistanceM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblStep2COGDistanceF.Text) - Convert.ToSingle(lblStep2COGDistanceM2.Text)) >= Convert.ToSingle(.05))
                lblStep2COGDistanceM2.ForeColor = Color.Red;
            else
                lblStep2COGDistanceM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep2COGDistanceM2.ForeColor = Color.Black;
        }

        if (!lblStep2LLAngleTakeoffF.Text.Equals("") && (!lblStep2LLAngleTakeoffM2.Text.Equals("")))
        {
            if (Convert.ToInt16(lblStep1VelocityF.Text) - Convert.ToInt16(lblStep2LLAngleTakeoffM2.Text) >= Convert.ToInt16(7))
                lblStep2LLAngleTakeoffM2.ForeColor = Color.Red;
            else
                lblStep2LLAngleTakeoffM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep2LLAngleTakeoffM2.ForeColor = Color.Black;
        }

        if (!lblStep2TrunkAngleTakeoffF.Text.Equals("") && (!lblStep2LLAngleTakeoffM2.Text.Equals("")))
        {
            if (Convert.ToInt16(lblStep2TrunkAngleTakeoffF.Text) - Convert.ToInt16(lblStep2LLAngleTakeoffM2.Text) >= Convert.ToInt16(7))
                lblStep2LLAngleTakeoffM2.ForeColor = Color.Red;
            else
                lblStep2LLAngleTakeoffM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep2LLAngleTakeoffM2.ForeColor = Color.Black;
        }
        if (!lblStep2LLAngleACF.Text.Equals("") && (!lblStep2LLAngleACM2.Text.Equals("")))
        {
            if (Convert.ToInt16(lblStep2LLAngleACF.Text) - Convert.ToInt16(lblStep2LLAngleACM2.Text) <= Convert.ToInt16(-7))
                lblStep2LLAngleACM2.ForeColor = Color.Red;
            else
                lblStep2LLAngleACM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep2LLAngleACM2.ForeColor = Color.Black;
        }

        if (!lblStep2GroundTimeF.Text.Equals("") && (!lblStep2GroundTimeM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep2GroundTimeF.Text) - Convert.ToSingle(lblStep2GroundTimeM2.Text) >= Convert.ToSingle(.02))
                lblStep2GroundTimeM2.ForeColor = Color.Red;
            else
                lblStep2GroundTimeM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep2GroundTimeM2.ForeColor = Color.Black;
        }
        if (!lblStep2AirTimeF.Text.Equals("") && (!lblStep2AirTimeM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep2AirTimeF.Text) - Convert.ToSingle(lblStep2AirTimeM2.Text) >= Convert.ToSingle(.02))
                lblStep2AirTimeM2.ForeColor = Color.Red;
            else
                lblStep2AirTimeM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep2AirTimeM2.ForeColor = Color.Black;
        }

        if (!lblStep2StrideRateF.Text.Equals("") && (!lblStep2StrideRateM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep2AirTimeF.Text) - Convert.ToSingle(lblStep2StrideRateM2.Text) <= Convert.ToSingle(-0.2))
                lblStep2StrideRateM2.ForeColor = Color.Red;
            else
                lblStep2StrideRateM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep2StrideRateM2.ForeColor = Color.Black;
        }
        if (!lblStep2StrideLengthF.Text.Equals("") && (!lblStep2StrideLengthM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep2StrideLengthF.Text) - Convert.ToSingle(lblStep2StrideLengthM2.Text) >= Convert.ToSingle(.05))
                lblStep2StrideLengthM2.ForeColor = Color.Red;
            else
                lblStep2StrideLengthM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep2StrideLengthM2.ForeColor = Color.Black;
        }
        if (!lblStep2VelocityF.Text.Equals("") && (!lblStep2VelocityM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep2VelocityF.Text) - Convert.ToSingle(lblStep2VelocityM2.Text) <= Convert.ToSingle(-0.5))
                lblStep2VelocityM2.ForeColor = Color.Red;
            else
                lblStep2VelocityM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep2VelocityM2.ForeColor = Color.Black;
        }
        if (!lblStep3COGDistanceF.Text.Equals("") && (!lblStep3COGDistanceM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblStep2VelocityF.Text) - Convert.ToSingle(lblStep3COGDistanceM2.Text)) >= Convert.ToSingle(.05))
                lblStep3COGDistanceM2.ForeColor = Color.Red;
            else
                lblStep3COGDistanceM2.ForeColor = Color.Black;
        }
        else
        {
            lblStep3COGDistanceM2.ForeColor = Color.Black;
        }
        if (!lblTimeTo3mF.Text.Equals("") && (!lblTimeTo3mM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStep2VelocityF.Text) - Convert.ToSingle(lblTimeTo3mM2.Text) >= Convert.ToSingle(0.05))
                lblTimeTo3mM2.ForeColor = Color.Red;
            else
                lblTimeTo3mM2.ForeColor = Color.Black;
        }
        else
        {
            lblTimeTo3mM2.ForeColor = Color.Black;
        }
        if (!lblTimeTo5mF.Text.Equals("") && (!lblTimeTo5mM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblTimeTo5mF.Text) - Convert.ToSingle(lblTimeTo5mM2.Text) >= Convert.ToSingle(0.05))
                lblTimeTo5mM2.ForeColor = Color.Red;
            else
                lblTimeTo5mM2.ForeColor = Color.Black;
        }
        else
        {
            lblTimeTo5mM2.ForeColor = Color.Black;
        }


      //  WriteObjectsToPageAjax();
    }

    

}


    ////protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    
    //    wmpfile = "";

    //    Label1.Text = "";
    //    Label2.Text = "";
    //    Label3.Text = "";
    //    Label4.Text = "";
    //    Label5.Text = "";
    //    Label6.Text = "";
    //    Label7.Text = "";
    //    Label8.Text = "";
    //    Label9.Text = "";
    //    Label10.Text = "";
    //    Label11.Text = "";
    //    Label12.Text = "";
    //    Label13.Text = "";
    //    Label14.Text = "";
    //    Label15.Text = "";
    //    Label16.Text = "";
    //    Label17.Text = "";
    //    Label18.Text = "";
    //    Label19.Text = "";
    //    Label20.Text = "";
    //    Label21.Text = "";
    //    Label22.Text = "";
    //    Label23.Text = "";
    //    Label24.Text = "";
    //    Label25.Text = "";
    //    Label26.Text = "";
    //    Label27.Text = "";
    //    Label28.Text = "";
    //    Label29.Text = "";
    //    Label30.Text = "";
    //    Label31.Text = "";
    //    Label32.Text = "";
    //    Label33.Text = "";
    //    Label34.Text = "";
    //    Label35.Text = "";
    //    Label36.Text = "";
    //    Label37.Text = "";
    //    Label38.Text = "";
    //    Label39.Text = "";

    //    Label79.Text = "";
    //    Label80.Text = "";
    //    Label81.Text = "";
    //    Label82.Text = "";
    //    Label83.Text = "";
    //    Label84.Text = "";
    //    Label85.Text = "";
    //    Label86.Text = "";
    //    Label87.Text = "";
    //    Label88.Text = "";
    //    Label89.Text = "";
    //    Label90.Text = "";
    //    Label91.Text = "";
    //    Label92.Text = "";
    //    Label93.Text = "";
    //    Label94.Text = "";
    //    Label95.Text = "";
    //    Label96.Text = "";
    //    Label97.Text = "";
    //    Label98.Text = "";
    //    Label99.Text = "";
    //    Label100.Text = "";
    //    Label101.Text = "";
    //    Label102.Text = "";
    //    Label103.Text = "";
    //    Label104.Text = "";
    //    Label105.Text = "";
    //    Label106.Text = "";
    //    Label107.Text = "";
    //    Label108.Text = "";
    //    Label109.Text = "";
    //    Label110.Text = "";
    //    Label111.Text = "";
    //    Label112.Text = "";
    //    Label113.Text = "";
    //    Label114.Text = "";
    //    Label115.Text = "";
    //    Label116.Text = "";
    //    Label117.Text = "";

    //    Label40.Text = "";
    //    Label41.Text = "";
    //    Label42.Text = "";
    //    Label43.Text = "";
    //    Label44.Text = "";
    //    Label45.Text = "";
    //    Label46.Text = "";
    //    Label47.Text = "";
    //    Label48.Text = "";
    //    Label49.Text = "";
    //    Label50.Text = "";
    //    Label51.Text = "";
    //    Label52.Text = "";
    //    Label53.Text = "";
    //    Label54.Text = "";
    //    Label55.Text = "";
    //    Label56.Text = "";
    //    Label57.Text = "";
    //    Label58.Text = "";
    //    Label59.Text = "";
    //    Label60.Text = "";
    //    Label61.Text = "";
    //    Label62.Text = "";
    //    Label63.Text = "";
    //    Label64.Text = "";
    //    Label65.Text = "";
    //    Label66.Text = "";
    //    Label67.Text = "";
    //    Label68.Text = "";
    //    Label69.Text = "";
    //    Label70.Text = "";
    //    Label71.Text = "";
    //    Label72.Text = "";
    //    Label73.Text = "";
    //    Label74.Text = "";
    //    Label75.Text = "";
    //    Label76.Text = "";
    //    Label77.Text = "";
    //    Label78.Text = "";

    //    Label118.Text = "";
    //    Label119.Text = "";
    //    Label120.Text = "";
    //    Label121.Text = "";
    //    Label122.Text = "";
    //    Label123.Text = "";
    //    Label124.Text = "";
    //    Label125.Text = "";
    //    Label126.Text = "";
    //    Label127.Text = "";
    //    Label128.Text = "";
    //    Label129.Text = "";
    //    Label130.Text = "";
    //    Label131.Text = "";
    //    Label132.Text = "";
    //    Label133.Text = "";
    //    Label134.Text = "";
    //    Label135.Text = "";
    //    Label136.Text = "";
    //    Label137.Text = "";
    //    Label138.Text = "";
    //    Label139.Text = "";
    //    Label140.Text = "";
    //    Label141.Text = "";
    //    Label142.Text = "";
    //    Label143.Text = "";
    //    Label144.Text = "";
    //    Label145.Text = "";
    //    Label146.Text = "";
    //    Label147.Text = "";
    //    Label148.Text = "";
    //    Label149.Text = "";
    //    Label150.Text = "";
    //    Label151.Text = "";
    //    Label152.Text = "";
    //    Label153.Text = "";
    //    Label154.Text = "";
    //    Label155.Text = "";
    //    Label156.Text = "";

    //    for (int y = 1; y < 157; y++)
    //    {
    //        string Lindex = "Label" + y.ToString();
    //        Label l;
    //        l = (Label)FindControl(Lindex);
    //        l.ForeColor = System.Drawing.Color.Black;
    //    }

    //    int LessonSelected;
    //    StartInitialData startinitialdata;
    //    StartCurrentData startcurrentdata;
    //    StartModelData startmodeldata;
    //    StartVideo startvideo;

    //   if (!DropDownList2.SelectedValue.Equals("nodate"))
    //    {
    //        LessonSelected = Convert.ToInt16(DropDownList2.SelectedValue);
    //        try
    //        {
    //            startvideo = DataRepository.StartVideoProvider.GetByLessonId(LessonSelected)[0];
    //            wmplayer.MovieURL = startvideo.StartVideoPath;
    //            wmpfile = "http://www.compusport.com/" + startvideo.StartVideoPath;
    //            string savepath = Server.MapPath(startvideo.StartVideoPath);
    //             object childId;
    //                int childId1 = 0;
    //                Response.Write("<script language='javascript'>alert('Child ID: \n" + childId1.ToString() + " .');</script>");
    //                try
    //                {
    //                    childId = GetChildID(mpuser.UserId);
    //                    childId1 = Convert.ToInt32(childId);
                      
    //                }
    //                catch
    //                {
    //                    if (childId1 == 0)
    //                    {
    //                        currentUser = SiteUtils.GetCurrentSiteUser();
    //                        SmtpMail.SmtpServer = "localhost";
    //                        SmtpMail.Send("track@compusport.com", "ralph@compusport.com", "Tier level has not been set for " + mpuser.Name.ToString(),
    //                            "Email : " + currentUser.Email.ToString() + "    " + "Name : " + mpuser.Name.ToString() 
    //                            + " \n Please check back for video availability.");
    //                    }
    //                }
    //                if (childId1 == 1)
    //                {
    //                    if (!File.Exists(savepath))
    //                    {
    //                        int LocationSelected;
    //                        LocationSelected = Convert.ToInt16(DropDownList2.SelectedValue);
    //                        currentUser = SiteUtils.GetCurrentSiteUser();
    //                        lesson = DataRepository.LessonProvider.GetByLessonId(LocationSelected);
    //                        SmtpMail.SmtpServer = "localhost";
    //                        SmtpMail.Send("track@compusport.com", "ralph@compusport.com", "Video is not Available for " + mpuser.Name.ToString(),
    //                            "Email : " + currentUser.Email.ToString() + "    " + "Name : " + currentUser.Name.ToString() + "  " +
    //                            "Location : " + lesson.LessonLocation.ToString() + "Path is available but video not found");
    //                        SmtpMail.Send("track@compusport.com", "ralph@compusport.com", "Video Athlete-Sprint from " + mpuser.Name.ToString(),
    //                            "Email : " + currentUser.Email.ToString() + "    " + "Name : " + mpuser.Name.ToString() + "  " +
    //                            "Location : " + lesson.LessonLocation.ToString() + " Date : " + lesson.LessonDate.ToString() + "  Path is available but video not found");
    //                        videodiv.Visible = false;
    //                        MsgDiv.Visible = true;

    //                    }
    //                    else
    //                    {
    //                            videodiv.Visible = true;
    //                            Label117.Text = "Click the Play button to start the video.";
    //                            MsgDiv.Visible = false;

    //                    }
    //                }
    //        }
    //        catch (Exception ex)
    //        {
    //            videodiv.Visible = false;
    //            MsgDiv.Visible = true;
    //            Label117.Text = "";
    //        }
    //        }
    //        catch (Exception ex)
    //        {
    //            VideoDiv.Visible = false;
    //            Label157.Text = "No Video Available.";
    //        }
    //        try
    //        {
    //            startinitialdata = DataRepository.StartInitialDataProvider.GetByLessonId(LessonSelected)[0];

    //            if (!startinitialdata.SetFrontBlockDistance.Equals(null))
    //                Label1.Text = startinitialdata.SetFrontBlockDistance.Value.ToString("0.00");
    //            if (!startinitialdata.SetRearBlockDistance.Equals(null))
    //                Label2.Text = startinitialdata.SetRearBlockDistance.Value.ToString("0.00");
    //            if (!startinitialdata.SetFrontUlAngle.Equals(null))
    //                Label3.Text = startinitialdata.SetFrontUlAngle.Value.ToString("#");
    //            if (!startinitialdata.SetRearUlAngle.Equals(null))
    //                Label4.Text = startinitialdata.SetRearUlAngle.Value.ToString("#");
    //            if (!startinitialdata.SetFrontLlAngle.Equals(null))
    //                Label5.Text = startinitialdata.SetFrontLlAngle.Value.ToString("#");
    //            if (!startinitialdata.SetRearLlAngle.Equals(null))
    //                Label6.Text = startinitialdata.SetRearLlAngle.Value.ToString("#");
    //            if (!startinitialdata.SetTrunkAngle.Equals(null))
    //                Label7.Text = startinitialdata.SetTrunkAngle.Value.ToString("#");
    //            if (!startinitialdata.SetCogDistance.Equals(null))
    //                Label8.Text = startinitialdata.SetCogDistance.Value.ToString("0.00");
    //            if (!startinitialdata.BcRearFootClearanceTime.Equals(null))
    //                Label9.Text = startinitialdata.BcRearFootClearanceTime.Value.ToString("0.000");
    //            if (!startinitialdata.BcFrontFootClearanceTime.Equals(null))
    //                Label10.Text = startinitialdata.BcFrontFootClearanceTime.Value.ToString("0.000");
    //            if (!startinitialdata.BcRearLlAngleTakeoff.Equals(null))
    //                Label11.Text = startinitialdata.BcRearLlAngleTakeoff.Value.ToString("#");
    //            if (!startinitialdata.BcFrontLlAngleTakeoff.Equals(null))
    //                Label12.Text = startinitialdata.BcFrontLlAngleTakeoff.Value.ToString("#");
    //            if (!startinitialdata.BcTrunkAngleTakeoff.Equals(null))
    //                Label13.Text = startinitialdata.BcTrunkAngleTakeoff.Value.ToString("#");
    //            if (!startinitialdata.BcllAngleAc.Equals(null))
    //                Label14.Text = startinitialdata.BcllAngleAc.Value.ToString("#");
    //            if (!startinitialdata.BcAirTime.Equals(null))
    //                Label15.Text = startinitialdata.BcAirTime.Value.ToString("0.000");
    //            try
    //            {
    //                Label16.Text = (Convert.ToDecimal(1) / (Convert.ToDecimal(Label10.Text) + Convert.ToDecimal(Label15.Text))).ToString("0.00");
    //            }
    //            catch { }
    //            if (!startinitialdata.BcStrideLength.Equals(null))
    //                Label17.Text = startinitialdata.BcStrideLength.Value.ToString("0.00");
    //            if (!startinitialdata.Step1CogDistance.Equals(null))
    //                Label19.Text = startinitialdata.Step1CogDistance.Value.ToString("0.00");
    //            try
    //            {
    //                Label18.Text = (Convert.ToDecimal(Label16.Text) * (Convert.ToDecimal(Label17.Text) + (Convert.ToDecimal(Label8.Text) - Convert.ToDecimal(Label19.Text))) * Convert.ToDecimal(1.58)).ToString("0.00");
    //            }
    //            catch { }
    //            if (!startinitialdata.Step1LlAngleTakeoff.Equals(null))
    //                Label20.Text = startinitialdata.Step1LlAngleTakeoff.Value.ToString("#");
    //            if (!startinitialdata.Step1TrunkAngleTakeoff.Equals(null))
    //                Label21.Text = startinitialdata.Step1TrunkAngleTakeoff.Value.ToString("#");
    //            if (!startinitialdata.Step1LlAngleAc.Equals(null))
    //                Label22.Text = startinitialdata.Step1LlAngleAc.Value.ToString("#");
    //            if (!startinitialdata.Step1GroundTime.Equals(null))
    //                Label23.Text = startinitialdata.Step1GroundTime.Value.ToString("0.000");
    //            if (!startinitialdata.Step1AirTime.Equals(null))
    //                Label24.Text = startinitialdata.Step1AirTime.Value.ToString("0.000");
    //            try
    //            {
    //                Label25.Text = (1 / (Convert.ToDecimal(Label23.Text) + Convert.ToDecimal(Label24.Text))).ToString("0.00");
    //            }
    //            catch { }
    //            if (!startinitialdata.Step1StrideLength.Equals(null))
    //                Label26.Text = startinitialdata.Step1StrideLength.Value.ToString("0.00");
    //            if (!startinitialdata.Step2CogDistance.Equals(null))
    //                Label28.Text = startinitialdata.Step2CogDistance.Value.ToString("0.00");
    //            try
    //            {
    //                Label27.Text = (Convert.ToDecimal(Label25.Text) * (Convert.ToDecimal(Label26.Text) + (Convert.ToDecimal(Label19.Text) - Convert.ToDecimal(Label28.Text))) * Convert.ToDecimal(1.25)).ToString("0.00");
    //            }
    //            catch { }
    //            if (!startinitialdata.Step2LlAngleTakeoff.Equals(null))
    //                Label29.Text = startinitialdata.Step2LlAngleTakeoff.Value.ToString("#");
    //            if (!startinitialdata.Step2TrunkAngleTakeoff.Equals(null))
    //                Label30.Text = startinitialdata.Step2TrunkAngleTakeoff.Value.ToString("#");
    //            if (!startinitialdata.Step2LlAngleAc.Equals(null))
    //                Label31.Text = startinitialdata.Step2LlAngleAc.Value.ToString("#");
    //            if (!startinitialdata.Step2GroundTime.Equals(null))
    //                Label32.Text = startinitialdata.Step2GroundTime.Value.ToString("0.000");
    //            if (!startinitialdata.Step2AirTime.Equals(null))
    //                Label33.Text = startinitialdata.Step2AirTime.Value.ToString("0.000");
    //            try
    //            {
    //                Label34.Text = (1 / (Convert.ToDecimal(Label32.Text) + Convert.ToDecimal(Label33.Text))).ToString("0.00");
    //            }
    //            catch { }
    //            if (!startinitialdata.Step2StrideLength.Equals(null))
    //                Label35.Text = startinitialdata.Step2StrideLength.Value.ToString("0.00");
    //            if (!startinitialdata.Step3CogDistance.Equals(null))
    //                Label37.Text = startinitialdata.Step3CogDistance.Value.ToString("0.00");
    //            try
    //            {
    //                Label36.Text = (Convert.ToDecimal(Label34.Text) * (Convert.ToDecimal(Label35.Text) + (Convert.ToDecimal(Label28.Text) - Convert.ToDecimal(Label37.Text))) * Convert.ToDecimal(1.08)).ToString("0.00");
    //            }
    //            catch { }
    //            if (!startinitialdata.TimeTo3m.Equals(null))
    //                Label38.Text = startinitialdata.TimeTo3m.Value.ToString("0.000");
    //            if (!startinitialdata.TimeTo5m.Equals(null))
    //                Label39.Text = startinitialdata.TimeTo5m.Value.ToString("0.000");

    //            InitialExists = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            InitialExists = false;
    //        }
    //        try
    //        {
    //            startcurrentdata = DataRepository.StartCurrentDataProvider.GetByLessonId(LessonSelected)[0];

    //            if (!startcurrentdata.SetFrontBlockDistance.Equals(null))
    //                Label79.Text = startcurrentdata.SetFrontBlockDistance.Value.ToString("0.00");
    //            if (!startcurrentdata.SetRearBlockDistance.Equals(null))
    //                Label80.Text = startcurrentdata.SetRearBlockDistance.Value.ToString("0.00");
    //            if (!startcurrentdata.SetFrontUlAngle.Equals(null))
    //                Label81.Text = startcurrentdata.SetFrontUlAngle.Value.ToString("#");
    //            if (!startcurrentdata.SetRearUlAngle.Equals(null))
    //                Label82.Text = startcurrentdata.SetRearUlAngle.Value.ToString("#");
    //            if (!startcurrentdata.SetFrontLlAngle.Equals(null))
    //                Label83.Text = startcurrentdata.SetFrontLlAngle.Value.ToString("#");
    //            if (!startcurrentdata.SetRearLlAngle.Equals(null))
    //                Label84.Text = startcurrentdata.SetRearLlAngle.Value.ToString("#");
    //            if (!startcurrentdata.SetTrunkAngle.Equals(null))
    //                Label85.Text = startcurrentdata.SetTrunkAngle.Value.ToString("#");
    //            if (!startcurrentdata.SetCogDistance.Equals(null))
    //                Label86.Text = startcurrentdata.SetCogDistance.Value.ToString("0.00");
    //            if (!startcurrentdata.BcRearFootClearanceTime.Equals(null))
    //                Label87.Text = startcurrentdata.BcRearFootClearanceTime.Value.ToString("0.000");
    //            if (!startcurrentdata.BcFrontFootClearanceTime.Equals(null))
    //                Label88.Text = startcurrentdata.BcFrontFootClearanceTime.Value.ToString("0.000");
    //            if (!startcurrentdata.BcRearLlAngleTakeoff.Equals(null))
    //                Label89.Text = startcurrentdata.BcRearLlAngleTakeoff.Value.ToString("#");
    //            if (!startcurrentdata.BcFrontLlAngleTakeoff.Equals(null))
    //                Label90.Text = startcurrentdata.BcFrontLlAngleTakeoff.Value.ToString("#");
    //            if (!startcurrentdata.BcTrunkAngleTakeoff.Equals(null))
    //                Label91.Text = startcurrentdata.BcTrunkAngleTakeoff.Value.ToString("#");
    //            if (!startcurrentdata.BcllAngleAc.Equals(null))
    //                Label92.Text = startcurrentdata.BcllAngleAc.Value.ToString("#");
    //            if (!startcurrentdata.BcAirTime.Equals(null))
    //                Label93.Text = startcurrentdata.BcAirTime.Value.ToString("0.000");
    //            try
    //            {
    //                Label94.Text = (Convert.ToDecimal(1) / (Convert.ToDecimal(Label88.Text) + Convert.ToDecimal(Label93.Text))).ToString("0.00");
    //            }
    //            catch { }
    //            if (!startcurrentdata.BcStrideLength.Equals(null))
    //                Label95.Text = startcurrentdata.BcStrideLength.Value.ToString("0.00");
    //            if (!startcurrentdata.Step1CogDistance.Equals(null))
    //                Label97.Text = startcurrentdata.Step1CogDistance.Value.ToString("0.00");
    //            try
    //            {
    //                Label96.Text = (Convert.ToDecimal(Label94.Text) * (Convert.ToDecimal(Label95.Text) + (Convert.ToDecimal(Label86.Text) - Convert.ToDecimal(Label97.Text))) * Convert.ToDecimal(1.58)).ToString("0.00");
    //            }
    //            catch { }
    //            if (!startcurrentdata.Step1LlAngleTakeoff.Equals(null))
    //                Label98.Text = startcurrentdata.Step1LlAngleTakeoff.Value.ToString("#");
    //            if (!startcurrentdata.Step1TrunkAngleTakeoff.Equals(null))
    //                Label99.Text = startcurrentdata.Step1TrunkAngleTakeoff.Value.ToString("#");
    //            if (!startcurrentdata.Step1LlAngleAc.Equals(null))
    //                Label100.Text = startcurrentdata.Step1LlAngleAc.Value.ToString("#");
    //            if (!startcurrentdata.Step1GroundTime.Equals(null))
    //                Label101.Text = startcurrentdata.Step1GroundTime.Value.ToString("0.000");
    //            if (!startcurrentdata.Step1AirTime.Equals(null))
    //                Label102.Text = startcurrentdata.Step1AirTime.Value.ToString("0.000");
    //            try
    //            {
    //                Label103.Text = (1 / (Convert.ToDecimal(Label101.Text) + Convert.ToDecimal(Label102.Text))).ToString("0.00");
    //            }
    //            catch { }
    //            if (!startcurrentdata.Step1StrideLength.Equals(null))
    //                Label104.Text = startcurrentdata.Step1StrideLength.Value.ToString("0.00");
    //            if (!startcurrentdata.Step2CogDistance.Equals(null))
    //                Label106.Text = startcurrentdata.Step2CogDistance.Value.ToString("0.00");
    //            try
    //            {
    //                Label105.Text = (Convert.ToDecimal(Label103.Text) * (Convert.ToDecimal(Label104.Text) + (Convert.ToDecimal(Label97.Text) - Convert.ToDecimal(Label106.Text))) * Convert.ToDecimal(1.25)).ToString("0.00");
    //            }
    //            catch { }
    //            if (!startcurrentdata.Step2LlAngleTakeoff.Equals(null))
    //                Label107.Text = startcurrentdata.Step2LlAngleTakeoff.Value.ToString("#");
    //            if (!startcurrentdata.Step2TrunkAngleTakeoff.Equals(null))
    //                Label108.Text = startcurrentdata.Step2TrunkAngleTakeoff.Value.ToString("#");
    //            if (!startcurrentdata.Step2LlAngleAc.Equals(null))
    //                Label109.Text = startcurrentdata.Step2LlAngleAc.Value.ToString("#");
    //            if (!startcurrentdata.Step2GroundTime.Equals(null))
    //                Label110.Text = startcurrentdata.Step2GroundTime.Value.ToString("0.000");
    //            if (!startcurrentdata.Step2AirTime.Equals(null))
    //                Label111.Text = startcurrentdata.Step2AirTime.Value.ToString("0.000");
    //            try
    //            {
    //                Label112.Text = (1 / (Convert.ToDecimal(Label110.Text) + Convert.ToDecimal(Label111.Text))).ToString("0.00");
    //            }
    //            catch { }
    //            if (!startcurrentdata.Step2StrideLength.Equals(null))
    //                Label113.Text = startcurrentdata.Step2StrideLength.Value.ToString("0.00");
    //            if (!startcurrentdata.Step3CogDistance.Equals(null))
    //                Label115.Text = startcurrentdata.Step3CogDistance.Value.ToString("0.00");
    //            try
    //            {
    //                Label114.Text = (Convert.ToDecimal(Label112.Text) * (Convert.ToDecimal(Label113.Text) + (Convert.ToDecimal(Label106.Text) - Convert.ToDecimal(Label115.Text))) * Convert.ToDecimal(1.08)).ToString("0.00");
    //            }
    //            catch { }
    //            if (!startcurrentdata.TimeTo3m.Equals(null))
    //                Label116.Text = startcurrentdata.TimeTo3m.Value.ToString("0.000");
    //            if (!startcurrentdata.TimeTo5m.Equals(null))
    //                Label117.Text = startcurrentdata.TimeTo5m.Value.ToString("0.000");

    //            CurrentExists = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            CurrentExists = false;
    //        }
    //        try
    //        {
    //            startmodeldata = DataRepository.StartModelDataProvider.GetByLessonId(LessonSelected)[0];

    //            if (InitialExists)
    //            {
    //                Label40.Text = startmodeldata.SetFrontBlockDistance.Value.ToString("0.00");
    //                Label41.Text = startmodeldata.SetRearBlockDistance.Value.ToString("0.00");
    //                Label42.Text = startmodeldata.SetFrontUlAngle.Value.ToString("#");
    //                Label43.Text = startmodeldata.SetRearUlAngle.Value.ToString("#");
    //                Label44.Text = startmodeldata.SetFrontLlAngle.Value.ToString("#");
    //                Label45.Text = startmodeldata.SetRearLlAngle.Value.ToString("#");
    //                Label46.Text = startmodeldata.SetTrunkAngle.Value.ToString("#");
    //                Label47.Text = startmodeldata.SetCogDistance.Value.ToString("0.00");
    //                Label48.Text = startmodeldata.BcRearFootClearanceTime.Value.ToString("0.000");
    //                Label49.Text = startmodeldata.BcFrontFootClearanceTime.Value.ToString("0.000");
    //                Label50.Text = startmodeldata.BcRearLlAngleTakeoff.Value.ToString("#");
    //                Label51.Text = startmodeldata.BcFrontLlAngleTakeoff.Value.ToString("#");
    //                Label52.Text = startmodeldata.BcTrunkAngleTakeoff.Value.ToString("#");
    //                Label53.Text = startmodeldata.BcllAngleAc.Value.ToString("#");
    //                Label54.Text = startmodeldata.BcAirTime.Value.ToString("0.000");
    //                Label55.Text = (Convert.ToDecimal(1) / (startmodeldata.BcFrontFootClearanceTime + startmodeldata.BcAirTime)).Value.ToString("0.00");
    //                Label56.Text = startmodeldata.BcStrideLength.Value.ToString("0.00");
    //                Label57.Text = ((Convert.ToDecimal(1) / (startmodeldata.BcFrontFootClearanceTime + startmodeldata.BcAirTime)) * (startmodeldata.BcStrideLength + (startmodeldata.SetCogDistance - startmodeldata.Step1CogDistance)) * Convert.ToDecimal(1.58)).Value.ToString("0.00");
    //                Label58.Text = startmodeldata.Step1CogDistance.Value.ToString("0.00");
    //                Label59.Text = startmodeldata.Step1LlAngleTakeoff.Value.ToString("#");
    //                Label60.Text = startmodeldata.Step1TrunkAngleTakeoff.Value.ToString("#");
    //                Label61.Text = startmodeldata.Step1LlAngleAc.Value.ToString("#");
    //                Label62.Text = startmodeldata.Step1GroundTime.Value.ToString("0.000");
    //                Label63.Text = startmodeldata.Step1AirTime.Value.ToString("0.000");
    //                Label64.Text = (1 / (startmodeldata.Step1GroundTime + startmodeldata.Step1AirTime)).Value.ToString("0.00");
    //                Label65.Text = startmodeldata.Step1StrideLength.Value.ToString("0.00");
    //                Label66.Text = ((1 / (startmodeldata.Step1GroundTime + startmodeldata.Step1AirTime)) * (startmodeldata.Step1StrideLength + (startmodeldata.Step1CogDistance - startmodeldata.Step2CogDistance)) * Convert.ToDecimal(1.25)).Value.ToString("0.00");
    //                Label67.Text = startmodeldata.Step2CogDistance.Value.ToString("0.00");
    //                Label68.Text = startmodeldata.Step2LlAngleTakeoff.Value.ToString("#");
    //                Label69.Text = startmodeldata.Step2TrunkAngleTakeoff.Value.ToString("#");
    //                Label70.Text = startmodeldata.Step2LlAngleAc.Value.ToString("#");
    //                Label71.Text = startmodeldata.Step2GroundTime.Value.ToString("0.000");
    //                Label72.Text = startmodeldata.Step2AirTime.Value.ToString("0.000");
    //                Label73.Text = (1 / (startmodeldata.Step2GroundTime + startmodeldata.Step2AirTime)).Value.ToString("0.00");
    //                Label74.Text = startmodeldata.Step2StrideLength.Value.ToString("0.00");
    //                Label75.Text = ((1 / (startmodeldata.Step2GroundTime + startmodeldata.Step2AirTime)) * (startmodeldata.Step2StrideLength + (startmodeldata.Step2CogDistance - startmodeldata.Step3CogDistance)) * Convert.ToDecimal(1.08)).Value.ToString("0.00");
    //                Label76.Text = startmodeldata.Step3CogDistance.Value.ToString("0.00");
    //                Label77.Text = startmodeldata.TimeTo3m.Value.ToString("0.000");
    //                Label78.Text = startmodeldata.TimeTo5m.Value.ToString("0.000");
    //                if (!Label1.Text.Equals(""))
    //                {
    //                    if (Math.Abs(Convert.ToSingle(Label1.Text) - Convert.ToSingle(Label40.Text)) >= Convert.ToSingle(.04))
    //                        Label40.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label40.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label2.Text.Equals(""))
    //                {
    //                    if (Math.Abs(Convert.ToSingle(Label2.Text) - Convert.ToSingle(Label41.Text)) >= Convert.ToSingle(.04))
    //                        Label41.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label41.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label3.Text.Equals(""))
    //                {
    //                    if (Math.Abs(Convert.ToInt16(Label3.Text) - Convert.ToInt16(Label42.Text)) >= Convert.ToInt16(7))
    //                        Label42.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label42.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label4.Text.Equals(""))
    //                {
    //                    if (Math.Abs(Convert.ToInt16(Label4.Text) - Convert.ToInt16(Label43.Text)) >= Convert.ToInt16(7))
    //                        Label43.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label43.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label5.Text.Equals(""))
    //                {
    //                    if (Math.Abs(Convert.ToInt16(Label5.Text) - Convert.ToInt16(Label44.Text)) >= Convert.ToInt16(7))
    //                        Label44.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label44.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label6.Text.Equals(""))
    //                {
    //                    if (Math.Abs(Convert.ToInt16(Label6.Text) - Convert.ToInt16(Label45.Text)) >= Convert.ToInt16(7))
    //                        Label45.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label45.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label7.Text.Equals(""))
    //                {
    //                    if (Math.Abs(Convert.ToInt16(Label7.Text) - Convert.ToInt16(Label46.Text)) >= Convert.ToInt16(7))
    //                        Label46.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label46.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label8.Text.Equals(""))
    //                {
    //                    if (Math.Abs(Convert.ToSingle(Label8.Text) - Convert.ToSingle(Label47.Text)) >= Convert.ToSingle(.05))
    //                        Label47.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label47.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label9.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label9.Text) - Convert.ToSingle(Label48.Text) >= Convert.ToSingle(.02))
    //                        Label48.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label48.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label10.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label10.Text) - Convert.ToSingle(Label49.Text) >= Convert.ToSingle(.04))
    //                        Label49.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label49.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label11.Text.Equals(""))
    //                {
    //                    if (Convert.ToInt16(Label11.Text) - Convert.ToInt16(Label50.Text) >= Convert.ToInt16(7))
    //                        Label50.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label50.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label12.Text.Equals(""))
    //                {
    //                    if (Convert.ToInt16(Label12.Text) - Convert.ToInt16(Label51.Text) >= Convert.ToInt16(7))
    //                        Label51.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label51.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label13.Text.Equals(""))
    //                {
    //                    if (Convert.ToInt16(Label13.Text) - Convert.ToInt16(Label52.Text) >= Convert.ToInt16(7))
    //                        Label52.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label52.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label14.Text.Equals(""))
    //                {
    //                    if (Convert.ToInt16(Label14.Text) - Convert.ToInt16(Label53.Text) <= Convert.ToInt16(-7))
    //                        Label53.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label53.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label15.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label15.Text) - Convert.ToSingle(Label54.Text) >= Convert.ToSingle(.02))
    //                        Label54.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label54.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label16.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label16.Text) - Convert.ToSingle(Label55.Text) <= Convert.ToSingle(-0.2))
    //                        Label55.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label55.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label17.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label17.Text) - Convert.ToSingle(Label56.Text) >= Convert.ToSingle(.05))
    //                        Label56.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label56.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label18.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label18.Text) - Convert.ToSingle(Label57.Text) <= Convert.ToSingle(-0.5))
    //                        Label57.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label57.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label19.Text.Equals(""))
    //                {
    //                    if (Math.Abs(Convert.ToSingle(Label19.Text) - Convert.ToSingle(Label58.Text)) >= Convert.ToSingle(.05))
    //                        Label58.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label58.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label20.Text.Equals(""))
    //                {
    //                    if (Convert.ToInt16(Label20.Text) - Convert.ToInt16(Label59.Text) >= Convert.ToInt16(7))
    //                        Label59.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label59.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label21.Text.Equals(""))
    //                {
    //                    if (Convert.ToInt16(Label21.Text) - Convert.ToInt16(Label60.Text) >= Convert.ToInt16(7))
    //                        Label60.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label60.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label22.Text.Equals(""))
    //                {
    //                    if (Convert.ToInt16(Label22.Text) - Convert.ToInt16(Label61.Text) <= Convert.ToInt16(-7))
    //                        Label61.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label61.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label23.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label23.Text) - Convert.ToSingle(Label62.Text) >= Convert.ToSingle(.02))
    //                        Label62.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label62.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label24.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label24.Text) - Convert.ToSingle(Label63.Text) >= Convert.ToSingle(.02))
    //                        Label63.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label63.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label25.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label25.Text) - Convert.ToSingle(Label64.Text) <= Convert.ToSingle(-0.2))
    //                        Label64.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label64.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label26.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label26.Text) - Convert.ToSingle(Label65.Text) >= Convert.ToSingle(.05))
    //                        Label65.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label65.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label27.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label27.Text) - Convert.ToSingle(Label66.Text) <= Convert.ToSingle(-0.5))
    //                        Label66.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label66.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label28.Text.Equals(""))
    //                {
    //                    if (Math.Abs(Convert.ToSingle(Label28.Text) - Convert.ToSingle(Label67.Text)) >= Convert.ToSingle(.05))
    //                        Label67.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label67.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label29.Text.Equals(""))
    //                {
    //                    if (Convert.ToInt16(Label29.Text) - Convert.ToInt16(Label68.Text) >= Convert.ToInt16(7))
    //                        Label68.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label68.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label30.Text.Equals(""))
    //                {
    //                    if (Convert.ToInt16(Label30.Text) - Convert.ToInt16(Label69.Text) >= Convert.ToInt16(7))
    //                        Label69.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label69.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label31.Text.Equals(""))
    //                {
    //                    if (Convert.ToInt16(Label31.Text) - Convert.ToInt16(Label70.Text) <= Convert.ToInt16(-7))
    //                        Label70.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label70.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label32.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label32.Text) - Convert.ToSingle(Label71.Text) >= Convert.ToSingle(.02))
    //                        Label71.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label71.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label33.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label33.Text) - Convert.ToSingle(Label72.Text) >= Convert.ToSingle(.02))
    //                        Label72.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label72.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label34.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label34.Text) - Convert.ToSingle(Label73.Text) <= Convert.ToSingle(-0.2))
    //                        Label73.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label73.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label35.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label35.Text) - Convert.ToSingle(Label74.Text) >= Convert.ToSingle(.05))
    //                        Label74.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label74.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label36.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label36.Text) - Convert.ToSingle(Label75.Text) <= Convert.ToSingle(-0.5))
    //                        Label75.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label75.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label37.Text.Equals(""))
    //                {
    //                    if (Math.Abs(Convert.ToSingle(Label37.Text) - Convert.ToSingle(Label76.Text)) >= Convert.ToSingle(.05))
    //                        Label76.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label76.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label38.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label38.Text) - Convert.ToSingle(Label77.Text) >= Convert.ToSingle(0.05))
    //                        Label77.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label77.ForeColor = System.Drawing.Color.Black;
    //                }
    //                if (!Label39.Text.Equals(""))
    //                {
    //                    if (Convert.ToSingle(Label39.Text) - Convert.ToSingle(Label78.Text) >= Convert.ToSingle(0.05))
    //                        Label78.ForeColor = System.Drawing.Color.Red;
    //                    else
    //                        Label78.ForeColor = System.Drawing.Color.Black;
    //                }
    //            }

    //            if (CurrentExists)
    //            {
    //            Label118.Text = startmodeldata.SetFrontBlockDistance.Value.ToString("0.00");
    //            Label119.Text = startmodeldata.SetRearBlockDistance.Value.ToString("0.00");
    //            Label120.Text = startmodeldata.SetFrontUlAngle.Value.ToString("#");
    //            Label121.Text = startmodeldata.SetRearUlAngle.Value.ToString("#");
    //            Label122.Text = startmodeldata.SetFrontLlAngle.Value.ToString("#");
    //            Label123.Text = startmodeldata.SetRearLlAngle.Value.ToString("#");
    //            Label124.Text = startmodeldata.SetTrunkAngle.Value.ToString("#");
    //            Label125.Text = startmodeldata.SetCogDistance.Value.ToString("0.00");
    //            Label126.Text = startmodeldata.BcRearFootClearanceTime.Value.ToString("0.000");
    //            Label127.Text = startmodeldata.BcFrontFootClearanceTime.Value.ToString("0.000");
    //            Label128.Text = startmodeldata.BcRearLlAngleTakeoff.Value.ToString("#");
    //            Label129.Text = startmodeldata.BcFrontLlAngleTakeoff.Value.ToString("#");
    //            Label130.Text = startmodeldata.BcTrunkAngleTakeoff.Value.ToString("#");
    //            Label131.Text = startmodeldata.BcllAngleAc.Value.ToString("#");
    //            Label132.Text = startmodeldata.BcAirTime.Value.ToString("0.000");
    //            Label133.Text = (Convert.ToDecimal(1) / (startmodeldata.BcFrontFootClearanceTime + startmodeldata.BcAirTime)).Value.ToString("0.00");
    //            Label134.Text = startmodeldata.BcStrideLength.Value.ToString("0.00");
    //            Label135.Text = ((Convert.ToDecimal(1) / (startmodeldata.BcFrontFootClearanceTime + startmodeldata.BcAirTime)) * (startmodeldata.BcStrideLength + (startmodeldata.SetCogDistance - startmodeldata.Step1CogDistance)) * Convert.ToDecimal(1.58)).Value.ToString("0.00");
    //            Label136.Text = startmodeldata.Step1CogDistance.Value.ToString("0.00");
    //            Label137.Text = startmodeldata.Step1LlAngleTakeoff.Value.ToString("#");
    //            Label138.Text = startmodeldata.Step1TrunkAngleTakeoff.Value.ToString("#");
    //            Label139.Text = startmodeldata.Step1LlAngleAc.Value.ToString("#");
    //            Label140.Text = startmodeldata.Step1GroundTime.Value.ToString("0.000");
    //            Label141.Text = startmodeldata.Step1AirTime.Value.ToString("0.000");
    //            Label142.Text = (1 / (startmodeldata.Step1GroundTime + startmodeldata.Step1AirTime)).Value.ToString("0.00");
    //            Label143.Text = startmodeldata.Step1StrideLength.Value.ToString("0.00");
    //            Label144.Text = ((1 / (startmodeldata.Step1GroundTime + startmodeldata.Step1AirTime)) * (startmodeldata.Step1StrideLength + (startmodeldata.Step1CogDistance - startmodeldata.Step2CogDistance)) * Convert.ToDecimal(1.25)).Value.ToString("0.00");
    //            Label145.Text = startmodeldata.Step2CogDistance.Value.ToString("0.00");
    //            Label146.Text = startmodeldata.Step2LlAngleTakeoff.Value.ToString("#");
    //            Label147.Text = startmodeldata.Step2TrunkAngleTakeoff.Value.ToString("#");
    //            Label148.Text = startmodeldata.Step2LlAngleAc.Value.ToString("#");
    //            Label149.Text = startmodeldata.Step2GroundTime.Value.ToString("0.000");
    //            Label150.Text = startmodeldata.Step2AirTime.Value.ToString("0.000");
    //            Label151.Text = (1 / (startmodeldata.Step2GroundTime + startmodeldata.Step2AirTime)).Value.ToString("0.00");
    //            Label152.Text = startmodeldata.Step2StrideLength.Value.ToString("0.00");
    //            Label153.Text = ((1 / (startmodeldata.Step2GroundTime + startmodeldata.Step2AirTime)) * (startmodeldata.Step2StrideLength + (startmodeldata.Step2CogDistance - startmodeldata.Step3CogDistance)) * Convert.ToDecimal(1.08)).Value.ToString("0.00");
    //            Label154.Text = startmodeldata.Step3CogDistance.Value.ToString("0.00");
    //            Label155.Text = startmodeldata.TimeTo3m.Value.ToString("0.000");
    //            Label156.Text = startmodeldata.TimeTo5m.Value.ToString("0.000");
    //            
    //            if (!Label79.Text.Equals(""))
    //            {
    //                if (Math.Abs(Convert.ToSingle(Label79.Text) - Convert.ToSingle(Label118.Text)) >= Convert.ToSingle(.04))
    //                    Label118.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label118.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label80.Text.Equals(""))
    //            {
    //                if (Math.Abs(Convert.ToSingle(Label80.Text) - Convert.ToSingle(Label119.Text)) >= Convert.ToSingle(.04))
    //                    Label119.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label119.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label81.Text.Equals(""))
    //            {
    //                if (Math.Abs(Convert.ToInt16(Label81.Text) - Convert.ToInt16(Label120.Text)) >= Convert.ToInt16(7))
    //                    Label120.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label120.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label82.Text.Equals(""))
    //            {
    //                if (Math.Abs(Convert.ToInt16(Label82.Text) - Convert.ToInt16(Label121.Text)) >= Convert.ToInt16(7))
    //                    Label121.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label121.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label83.Text.Equals(""))
    //            {
    //                if (Math.Abs(Convert.ToInt16(Label83.Text) - Convert.ToInt16(Label122.Text)) >= Convert.ToInt16(7))
    //                    Label122.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label122.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label84.Text.Equals(""))
    //            {
    //                if (Math.Abs(Convert.ToInt16(Label84.Text) - Convert.ToInt16(Label123.Text)) >= Convert.ToInt16(7))
    //                    Label123.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label123.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label85.Text.Equals(""))
    //            {
    //                if (Math.Abs(Convert.ToInt16(Label85.Text) - Convert.ToInt16(Label124.Text)) >= Convert.ToInt16(7))
    //                    Label124.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label124.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label86.Text.Equals(""))
    //            {
    //                if (Math.Abs(Convert.ToSingle(Label86.Text) - Convert.ToSingle(Label125.Text)) >= Convert.ToSingle(.05))
    //                    Label125.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label125.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label87.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label87.Text) - Convert.ToSingle(Label126.Text) >= Convert.ToSingle(.02))
    //                    Label126.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label126.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label88.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label88.Text) - Convert.ToSingle(Label127.Text) >= Convert.ToSingle(.04))
    //                    Label127.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label127.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label89.Text.Equals(""))
    //            {
    //                if (Convert.ToInt16(Label89.Text) - Convert.ToInt16(Label128.Text) >= Convert.ToInt16(7))
    //                    Label128.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label128.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label90.Text.Equals(""))
    //            {
    //                if (Convert.ToInt16(Label90.Text) - Convert.ToInt16(Label129.Text) >= Convert.ToInt16(7))
    //                    Label129.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label129.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label91.Text.Equals(""))
    //            {
    //                if (Convert.ToInt16(Label91.Text) - Convert.ToInt16(Label130.Text) >= Convert.ToInt16(7))
    //                    Label130.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label130.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label92.Text.Equals(""))
    //            {
    //                if (Convert.ToInt16(Label92.Text) - Convert.ToInt16(Label131.Text) <= Convert.ToInt16(-7))
    //                    Label131.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label131.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label93.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label93.Text) - Convert.ToSingle(Label132.Text) >= Convert.ToSingle(.02))
    //                    Label132.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label132.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label94.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label94.Text) - Convert.ToSingle(Label133.Text) <= Convert.ToSingle(-0.2))
    //                    Label133.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label133.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label95.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label95.Text) - Convert.ToSingle(Label134.Text) >= Convert.ToSingle(.05))
    //                    Label134.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label134.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label96.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label96.Text) - Convert.ToSingle(Label135.Text) <= Convert.ToSingle(-0.5))
    //                    Label135.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label135.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label97.Text.Equals(""))
    //            {
    //                if (Math.Abs(Convert.ToSingle(Label97.Text) - Convert.ToSingle(Label136.Text)) >= Convert.ToSingle(.05))
    //                    Label136.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label136.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label98.Text.Equals(""))
    //            {
    //                if (Convert.ToInt16(Label98.Text) - Convert.ToInt16(Label137.Text) >= Convert.ToInt16(7))
    //                    Label137.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label137.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label99.Text.Equals(""))
    //            {
    //                if (Convert.ToInt16(Label99.Text) - Convert.ToInt16(Label138.Text) >= Convert.ToInt16(7))
    //                    Label138.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label138.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label100.Text.Equals(""))
    //            {
    //                if (Convert.ToInt16(Label100.Text) - Convert.ToInt16(Label139.Text) <= Convert.ToInt16(-7))
    //                    Label139.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label139.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label101.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label101.Text) - Convert.ToSingle(Label140.Text) >= Convert.ToSingle(.02))
    //                    Label140.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label140.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label102.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label102.Text) - Convert.ToSingle(Label141.Text) >= Convert.ToSingle(.02))
    //                    Label141.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label141.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label103.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label103.Text) - Convert.ToSingle(Label142.Text) <= Convert.ToSingle(-0.2))
    //                    Label142.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label142.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label104.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label104.Text) - Convert.ToSingle(Label143.Text) >= Convert.ToSingle(.05))
    //                    Label143.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label143.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label105.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label105.Text) - Convert.ToSingle(Label144.Text) <= Convert.ToSingle(-0.5))
    //                    Label144.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label144.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label106.Text.Equals(""))
    //            {
    //                if (Math.Abs(Convert.ToSingle(Label106.Text) - Convert.ToSingle(Label145.Text)) >= Convert.ToSingle(.05))
    //                    Label145.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label145.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label107.Text.Equals(""))
    //            {
    //                if (Convert.ToInt16(Label107.Text) - Convert.ToInt16(Label146.Text) >= Convert.ToInt16(7))
    //                    Label146.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label146.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label108.Text.Equals(""))
    //            {
    //                if (Convert.ToInt16(Label108.Text) - Convert.ToInt16(Label147.Text) >= Convert.ToInt16(7))
    //                    Label147.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label147.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label109.Text.Equals(""))
    //            {
    //                if (Convert.ToInt16(Label109.Text) - Convert.ToInt16(Label148.Text) <= Convert.ToInt16(-7))
    //                    Label148.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label148.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label110.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label110.Text) - Convert.ToSingle(Label149.Text) >= Convert.ToSingle(.02))
    //                    Label149.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label149.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label111.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label111.Text) - Convert.ToSingle(Label150.Text) >= Convert.ToSingle(.02))
    //                    Label150.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label150.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label112.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label112.Text) - Convert.ToSingle(Label151.Text) <= Convert.ToSingle(-0.2))
    //                    Label151.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label151.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label113.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label113.Text) - Convert.ToSingle(Label152.Text) >= Convert.ToSingle(.05))
    //                    Label152.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label152.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label114.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label114.Text) - Convert.ToSingle(Label153.Text) <= Convert.ToSingle(-0.5))
    //                    Label153.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label153.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label115.Text.Equals(""))
    //            {
    //                if (Math.Abs(Convert.ToSingle(Label115.Text) - Convert.ToSingle(Label154.Text)) >= Convert.ToSingle(.05))
    //                    Label154.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label154.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label116.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label116.Text) - Convert.ToSingle(Label155.Text) >= Convert.ToSingle(0.05))
    //                    Label155.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label155.ForeColor = System.Drawing.Color.Black;
    //            }
    //            if (!Label117.Text.Equals(""))
    //            {
    //                if (Convert.ToSingle(Label117.Text) - Convert.ToSingle(Label156.Text) >= Convert.ToSingle(0.05))
    //                    Label156.ForeColor = System.Drawing.Color.Red;
    //                else
    //                    Label156.ForeColor = System.Drawing.Color.Black;
    //            }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }
    //    else
    //    {
    //        Label157.Text = "";
    //    }
    //}
    //public object GetChildID(object __userid)
    //{
    //    try
    //    {
    //        object ChilId;
    //        using (SqlConnection connection = new SqlConnection(ConnectionString))
    //        {
    //            connection.Open();
    //            using (SqlCommand cmdupdate = connection.CreateCommand())
    //            {
    //                cmdupdate.CommandType = CommandType.StoredProcedure;
    //                cmdupdate.CommandText = "SelectChildIDofUser";
    //                cmdupdate.Parameters.AddWithValue("@UserId", __userid);
    //                ChilId = cmdupdate.ExecuteScalar();
    //                return ChilId;
    //            }

    //        }

    //    }
    //    catch (Exception err)
    //    {
    //        return err;
    //    }
    //}

    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    ////    int AthleteSelected;
    ////    int LocationSelected;
    ////    LocationSelected = Convert.ToInt16(DropDownList2.SelectedValue);
    ////    currentUser = SiteUtils.GetCurrentSiteUser();
    ////    lesson = DataRepository.LessonProvider.GetByLessonId(LocationSelected);
    ////    SmtpMail.SmtpServer = "localhost";
    ////    //SmtpMail.Send("track@compusport.com", "ralph@compusport.com", "Video Requested from " + mpuser.Name.ToString(),
    ////    SmtpMail.Send("track@compusport.com", "ralph@compusport.com", "Video Athlete-Start from " + mpuser.Name.ToString(),
    ////         "Email : " + currentUser.Email.ToString() + "    " + "Name : " + mpuser.Name.ToString() + "  " +
    ////         "Location : " + lesson.LessonLocation.ToString() + " Date : " + lesson.LessonDate.ToString());
    ////    MsgDiv.Visible = false;
    ////    Label117.Text = "You will receive and email confirmation when the video is available.";
    //}

