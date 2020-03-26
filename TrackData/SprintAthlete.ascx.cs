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
using System.Web.Mail;
using System.Net.Mail;
using System.IO;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Web.SessionState;
using CompuSportDAL;
using mojoPortal.Business;
using mojoPortal.Business.WebHelpers;
using mojoPortal.Web;
using SwingModel.Data;
using SwingModel.Entities;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using SwfDotNet.IO;

public partial class TrackData_SprintAthlete : System.Web.UI.UserControl
{
    int x;
    public string wmpfile = "";
    bool InitialExists = false;
    bool CurrentExists = false;
    int code1, code2, code3, code4;

    Customer customer;
    SummaryMovie summarymovie;
    Lesson lesson;
    MovieClip movieclip;
    MovieClip movieclipid;
   
    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

    DataSet ds = new DataSet();
    
    protected void Page_Load(object sender, EventArgs e)
    {       

        
        //CompuSportDAL.SprintAthleteEdit sae = new CompuSportDAL.SprintAthleteEdit();

        //ds = sae.GetAllSprintAthletesData(19);
        
        //GetAllSprintAthleteData(lessonid);
        //GetAllSprintAthleteData();

        //int tables = ds.Tables.Count;
        //int rows = Convert.ToInt32(ds.Tables[tables - 1].Rows.Count.ToString());
        //int cols = Convert.ToInt32(ds.Tables[tables - 1].Columns.Count.ToString());

    }
    public void GetAllSprintAthleteData(int lessonid)
    {       

        CompuSportDAL.SprintAthleteEdit sae = new CompuSportDAL.SprintAthleteEdit();
        ds = sae.GetAllSprintAthletesData(lessonid);

        lblGroundTimeLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ground Time Left"].ToString()); 
        
        lblGroundTimeRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ground Time Right"].ToString());            

        lblGroundTimeAverageI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ground Time Average"].ToString());

        lblAirTimeLeftToRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Air Time Left to Right"].ToString());
      

        lblAirTimeRightToLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Air Time Right to Left"].ToString());
        lblAirTimeAverageI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Air Time Average"].ToString());

        lblTimeToUpperLegFullFlexionLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Time to Upper Leg Full Flexion Left"].ToString());
        lblTimeToUpperLegFullFlexionRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Time to Upper Leg Full Flexion Right"].ToString());
        lblTimeToUpperLegFullFlexionAverageI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Time to Upper Leg Full Flexion Average"].ToString());

        lblStrideRateI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Stride Rate"].ToString());

        lblStrideLengthLeftToRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Stride Length Left to Right"].ToString());
        lblStrideLengthRightToLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Stride Length Right to Left"].ToString());
        lblStrideLengthAverageI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Stride Length Average"].ToString());

        lblVelocity.Text = Convert.ToString(ds.Tables[0].Rows[0]["Velocity"].ToString());

        lblTouchDownDistanceLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Touchdown Distance Left"].ToString());
        lblTouchDownDistanceRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Touchdown Distance Right"].ToString());
        lblTouchDownDistanceAverageI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Touchdown Distance Average"].ToString());

        lblUpperLegFullExtentionAngleLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Extension Angle Left"].ToString());
        lblUpperLegFullExtentionAngleRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Extension Angle Right"].ToString());
        lblUpperLegFullExtentionAngleAverageI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Extension Angle Average"].ToString());

        lblLowerLegAngleAtTakeOfLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Angle at Takeoff Left"].ToString());
        lblLowerLegAngleAtTakeOfRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Angle at Takeoff Right"].ToString());
        lblLowerLegAngleAtTakeOfAverageI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Angle at Takeoff Average"].ToString());

        lblLowerLegFullFlexionAngleLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Full Flexion Angle Left"].ToString());
        lblLowerLegFullFlexionAngleRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Full Flexion Angle Right"].ToString());
        lblLowerLegFullFlexionAngleAverageI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Full Flexion Angle Average"].ToString());

        lblLowerLegAngleAtAnkleCrossLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Angle at Ankle Cross Left"].ToString());
        lblLowerLegAngleAtAnkleCrossRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Angle at Ankle Cross Right"].ToString());
        lblLowerLegAngleAtAnkleCrossAverageI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lower Leg Angle at Ankle Cross Average"].ToString());

        lblUpperLegFullFlexionAngleLeftI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Flexion Angle Left"].ToString());
        lblUpperLegFullFlexionAngleRightI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Flexion Angle Right"].ToString());
        lblUpperLegFullFlexionAngleAverageI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Upper Leg Full Flexion Angle Average"].ToString());

        //model data

        lblGroundTimeLeftM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["GroundTime"].ToString());
       

        lblGroundTimeRightM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["GroundTime"].ToString());
        lblGroundTimeAverageM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["GroundTime"].ToString());
        

        lblAirTimeLeftToRightM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["AirTime"].ToString());
        lblAirTimeRightToLeftM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["AirTime"].ToString());
        lblAirTimeAverageM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["AirTime"].ToString());


        lblTimeToUpperLegFullFlexionLeftM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["FullFlexionTime"].ToString());
        lblTimeToUpperLegFullFlexionRightM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["FullFlexionTime"].ToString());
        lblTimeToUpperLegFullFlexionAverageM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["FullFlexionTime"].ToString());

        lblStrideRateM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Stride Rate"].ToString());

        lblStrideLengthLeftToRighM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["StrideLength"].ToString());
        lblStrideLengthRightToLeftM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["StrideLength"].ToString());
        lblStrideLengthAverageM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["StrideLength"]);

        lblVelocityM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["Velocity"].ToString());

        lblTouchDownDistanceLeftM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["COGDistance"].ToString());
        lblTouchDownDistanceRightM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["COGDistance"].ToString());
        lblTouchDownDistanceAverageM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["COGDistance"].ToString());

        lblUpperLegFullExtentionAngleLeftM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["ULFullExtensionAngle"].ToString());
        lblUpperLegFullExtentionAngleRightM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["ULFullExtensionAngle"].ToString());
        lblUpperLegFullExtentionAngleAverageM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["ULFullExtensionAngle"].ToString());

        lblLowerLegAngleAtTakeOfLeftM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["LLAngleTakeoff"].ToString());
        lblLowerLegAngleAtTakeOfRightM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["LLAngleTakeoff"].ToString());
        lblLowerLegAngleAtTakeOfAverageM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["LLAngleTakeoff"].ToString());

        lblLowerLegFullFlexionAngleLeftM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["LLFullFlexionAngle"].ToString());
        lblLowerLegFullFlexionAngleRightM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["LLFullFlexionAngle"].ToString());
        lblLowerLegFullFlexionAngleAverageM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["LLFullFlexionAngle"].ToString());

        lblLowerLegAngleAtAnkleCrossLeftM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["LLAngleAC"].ToString());
        lblLowerLegAngleAtAnkleCrossRightM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["LLAngleAC"].ToString());
        lblLowerLegAngleAtAnkleCrossAverageM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["LLAngleAC"].ToString());

        lblUpperLegFullFlexionAngleLeftM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["ULFullFlexionAngle"].ToString());
        lblUpperLegFullFlexionAngleRightM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["ULFullFlexionAngle"].ToString());
        lblUpperLegFullFlexionAngleAverageM1.Text = Convert.ToString(ds.Tables[1].Rows[0]["ULFullFlexionAngle"].ToString());


        //current data

        lblGroundTimeLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Ground Time Left"].ToString());
        lblGroundTimeRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Ground Time Right"].ToString());
        lblGroundTimeAverageF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Ground Time Average"].ToString());

        lblAirTimeLeftToRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Air Time Left to Right"].ToString());
        lblAirTimeRightToLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Air Time Right to Left"].ToString());
        lblAirTimeAverageF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Air Time Average"].ToString());

        lblTimeToUpperLegFullFlexionLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Time to Upper Leg Full Flexion Left"].ToString());
        lblTimeToUpperLegFullFlexionRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Time to Upper Leg Full Flexion Right"].ToString());
        lblTimeToUpperLegFullFlexionAverageF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Time to Upper Leg Full Flexion Average"].ToString());

        lblStrideRateF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Stride Rate"].ToString());

        lblStrideLengthLeftToRighF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Stride Length Left to Right"].ToString());
        lblStrideLengthRightToLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Stride Length Right to Left"].ToString());
        lblStrideLengthAverageF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Stride Length Average"].ToString());

        lblVelocityF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Velocity"].ToString());

        lblTouchDownDistanceLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Touchdown Distance Left"].ToString());
        lblTouchDownDistanceRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Touchdown Distance Right"].ToString());
        lblTouchDownDistanceAverageF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Touchdown Distance Average"].ToString());

        lblUpperLegFullExtentionAngleLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Extension Angle Left"].ToString());
        lblUpperLegFullExtentionAngleRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Extension Angle Right"].ToString());
        lblUpperLegFullExtentionAngleAverageF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Extension Angle Average"].ToString());

        lblLowerLegAngleAtTakeOfLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Takeoff Left"].ToString());
        lblLowerLegAngleAtTakeOfRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Takeoff Right"].ToString());
        lblLowerLegAngleAtTakeOfAverageF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Takeoff Average"].ToString());

        lblLowerLegFullFlexionAngleLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Full Flexion Angle Left"].ToString());
        lblLowerLegFullFlexionAngleRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Full Flexion Angle Right"].ToString());
        lblLowerLegFullFlexionAngleAverageF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Full Flexion Angle Average"].ToString());

        lblLowerLegAngleAtAnkleCrossLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Ankle Cross Left"].ToString());
        lblLowerLegAngleAtAnkleCrossRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Ankle Cross Right"].ToString());
        lblLowerLegAngleAtAnkleCrossAverageF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Lower Leg Angle at Ankle Cross Average"].ToString());

        lblUpperLegFullFlexionAngleLeftF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Flexion Angle Left"].ToString());
        lblUpperLegFullFlexionAngleRightF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Flexion Angle Right"].ToString());
        lblUpperLegFullFlexionAngleAverageF.Text = Convert.ToString(ds.Tables[2].Rows[0]["Upper Leg Full Flexion Angle Average"].ToString());


        //model_2 data

        lblGroundTimeLeftM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["GroundTime"].ToString());
        lblGroundTimeRightM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["GroundTime"].ToString());
        lblGroundTimeAverageM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["GroundTime"].ToString());

        lblAirTimeLeftToRightM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["AirTime"].ToString());
        lblAirTimeRightToLeftM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["AirTime"].ToString());
        lblAirTimeAverageM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["AirTime"].ToString());

        lblTimeToUpperLegFullFlexionLeftM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["FullFlexionTime"].ToString());
        lblTimeToUpperLegFullFlexionRightM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["FullFlexionTime"].ToString());
        lblTimeToUpperLegFullFlexionAverageM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["FullFlexionTime"].ToString());

        lblStrideRateM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Stride Rate"].ToString());

        lblStrideLengthLeftToRighM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["StrideLength"].ToString());
        lblStrideLengthRightToLeftM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["StrideLength"].ToString());
        lblStrideLengthAverageM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["StrideLength"].ToString());

        lblVelocityM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["Velocity"].ToString());

        lblTouchDownDistanceLeftM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["COGDistance"].ToString());
        lblTouchDownDistanceRightM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["COGDistance"].ToString());
        lblTouchDownDistanceAverageM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["COGDistance"].ToString());

        lblUpperLegFullExtentionAngleLeftM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["ULFullExtensionAngle"].ToString());
        lblUpperLegFullExtentionAngleRightM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["ULFullExtensionAngle"].ToString());
        lblUpperLegFullExtentionAngleAverageM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["ULFullExtensionAngle"].ToString());

        lblLowerLegAngleAtTakeOfLeftM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["LLAngleTakeoff"].ToString());
        lblLowerLegAngleAtTakeOfRightM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["LLAngleTakeoff"].ToString());
        lblLowerLegAngleAtTakeOfAverageM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["LLAngleTakeoff"].ToString());

        lblLowerLegFullFlexionAngleLeftM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["LLFullFlexionAngle"].ToString());
        lblLowerLegFullFlexionAngleRightM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["LLFullFlexionAngle"].ToString());
        lblLowerLegFullFlexionAngleAverageM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["LLFullFlexionAngle"].ToString());

        lblLowerLegAngleAtAnkleCrossLeftM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["LLAngleAC"].ToString());
        lblLowerLegAngleAtAnkleCrossRightM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["LLAngleAC"].ToString());
        lblLowerLegAngleAtAnkleCrossAverageM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["LLAngleAC"].ToString());

        lblUpperLegFullFlexionAngleLeftM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["ULFullFlexionAngle"].ToString());
        lblUpperLegFullFlexionAngleRightM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["ULFullFlexionAngle"].ToString());
        lblUpperLegFullFlexionAngleAverageM2.Text = Convert.ToString(ds.Tables[3].Rows[0]["ULFullFlexionAngle"].ToString());
       
        
        //SwingErrorLookup swingerrorlookup = DataRepository.SwingErrorLookupProvider.Find("Code1 = " + code1 + " AND Code2 = " + code2 + " AND Code3 = " + code3 + " AND Code4 = " + code4)[0];
        //string s=swingerrorlookup.TextDescription;
        //Session["val"] = s;

        if (!lblGroundTimeLeftI.Text.Equals("") && (!lblGroundTimeAverageM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblGroundTimeLeftI.Text) - Convert.ToSingle(lblGroundTimeAverageM1.Text) >= Convert.ToSingle(.007))
                lblGroundTimeLeftM1.ForeColor = System.Drawing.Color.Red;          
                           
            else
                lblGroundTimeLeftM1.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblGroundTimeLeftI.Text = lblGroundTimeLeftI.Text;            
        }

        if (!lblGroundTimeRightI.Text.Equals("") && (!lblGroundTimeAverageM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblGroundTimeRightI.Text) - Convert.ToSingle(lblGroundTimeAverageM1.Text) >= Convert.ToSingle(.007))
                lblGroundTimeRightM1.ForeColor = Color.Red;
            else
                lblGroundTimeRightM1.ForeColor = Color.Black;
        }
        else
        {
            lblGroundTimeRightI.Text = lblGroundTimeRightI.Text;            
        }


        if (!lblGroundTimeAverageI.Text.Equals("") && (!lblGroundTimeAverageM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblGroundTimeAverageI.Text) - Convert.ToSingle(lblGroundTimeAverageM1.Text) >= Convert.ToSingle(.007))
                lblGroundTimeAverageI.ForeColor = Color.Red;
            else
                lblGroundTimeAverageI.ForeColor = Color.Black;
        }
        else
        {
            lblGroundTimeAverageI.Text = lblGroundTimeAverageI.Text;
        }



        if (!lblAirTimeLeftToRightI.Text.Equals("") && (!lblGroundTimeAverageM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblAirTimeLeftToRightI.Text) - Convert.ToSingle(lblGroundTimeAverageM1.Text) >= Convert.ToSingle(.005))
                lblAirTimeLeftToRightM1.ForeColor = Color.Red;
            else
                lblAirTimeLeftToRightM1.ForeColor = Color.Black;
        }
        else
        {
            lblAirTimeLeftToRightI.Text = lblAirTimeLeftToRightI.Text;
        }


        if (!lblAirTimeRightToLeftI.Text.Equals("") && (!lblGroundTimeAverageM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblAirTimeRightToLeftI.Text) - Convert.ToSingle(lblGroundTimeAverageM1.Text) >= Convert.ToSingle(.005))
                lblAirTimeRightToLeftM1.ForeColor = Color.Red;
            else
                lblAirTimeRightToLeftM1.ForeColor = Color.Black;
        }

        else
        {
            lblAirTimeRightToLeftI.Text = lblAirTimeRightToLeftI.Text;
        }

        if (!lblAirTimeAverageI.Text.Equals("") && (!lblGroundTimeAverageM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblAirTimeAverageI.Text) - Convert.ToSingle(lblGroundTimeAverageM1.Text) >= Convert.ToSingle(.005))
                lblAirTimeAverageM1.ForeColor = Color.Red;
            else
                lblAirTimeAverageM1.ForeColor = Color.Black;
        }
        else
        {
            lblAirTimeAverageI.Text = lblAirTimeAverageI.Text;
        }


        if (!lblTimeToUpperLegFullFlexionLeftI.Text.Equals("") && (!lblTimeToUpperLegFullFlexionLeftM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblTimeToUpperLegFullFlexionLeftI.Text) - Convert.ToSingle(lblTimeToUpperLegFullFlexionLeftM1.Text) <= Convert.ToSingle(-0.01))
                lblTimeToUpperLegFullFlexionLeftM1.ForeColor = Color.Red;
            else
                lblTimeToUpperLegFullFlexionLeftM1.ForeColor = Color.Black;
        }
        else
        {
            lblTimeToUpperLegFullFlexionLeftI.Text = lblTimeToUpperLegFullFlexionLeftI.Text;
        }


        if (!lblTimeToUpperLegFullFlexionRightI.Text.Equals("") && (!lblTimeToUpperLegFullFlexionLeftM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblTimeToUpperLegFullFlexionRightI.Text) - Convert.ToSingle(lblTimeToUpperLegFullFlexionRightM1.Text) <= Convert.ToSingle(-0.01))
                lblTimeToUpperLegFullFlexionRightM1.ForeColor = Color.Red;
            else
                lblTimeToUpperLegFullFlexionRightM1.ForeColor = Color.Black;
        }
        else
        {
            lblTimeToUpperLegFullFlexionRightI.Text = lblTimeToUpperLegFullFlexionRightI.Text;
        }

        if (!lblUpperLegFullExtentionAngleAverageI.Text.Equals("") && (!lblTouchDownDistanceAverageM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblUpperLegFullExtentionAngleAverageI.Text) - Convert.ToSingle(lblTouchDownDistanceAverageM1.Text) <= Convert.ToSingle(-0.01))
                lblUpperLegFullExtentionAngleAverageM1.ForeColor = Color.Red;
            else
                lblUpperLegFullExtentionAngleAverageM1.ForeColor = Color.Black;
        }
        else
        {
            lblUpperLegFullExtentionAngleAverageI.Text = lblUpperLegFullExtentionAngleAverageI.Text;
        }

        if (!lblStrideRateI.Text.Equals("") && (!lblStrideRateM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStrideRateI.Text) - Convert.ToSingle(lblStrideRateM1.Text) <= Convert.ToSingle(-0.1))
                lblStrideRateM1.ForeColor = Color.Red;
            else
                lblStrideRateM1.ForeColor = Color.Black;
        }
        else
        {
            lblStrideRateI.Text = lblStrideRateI.Text;
        }

        if (!lblStrideLengthLeftToRightI.Text.Equals("") && (!lblStrideLengthLeftToRighM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStrideLengthLeftToRightI.Text) - Convert.ToSingle(lblStrideLengthLeftToRighM1.Text) <= Convert.ToSingle(-0.1))
                lblStrideLengthLeftToRighM1.ForeColor = Color.Red;
            else
                lblStrideLengthLeftToRighM1.ForeColor = Color.Black;
        }
        else
        {
            lblStrideLengthLeftToRightI.Text = lblStrideLengthLeftToRightI.Text;
        }


        if (!lblStrideLengthRightToLeftI.Text.Equals("") && (!lblStrideLengthRightToLeftM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStrideLengthRightToLeftI.Text) - Convert.ToSingle(lblStrideLengthRightToLeftM1.Text) <= Convert.ToSingle(-0.1))
                lblStrideLengthRightToLeftM1.ForeColor = Color.Red;
            else
                lblStrideLengthRightToLeftM1.ForeColor = Color.Black;
        }
        else
        {
            lblStrideLengthRightToLeftI.Text = lblStrideLengthRightToLeftI.Text;
        }


        if (!lblStrideLengthAverageI.Text.Equals("") && (!lblStrideLengthAverageM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStrideLengthAverageI.Text) - Convert.ToSingle(lblStrideLengthAverageM1.Text) <= Convert.ToSingle(-0.1))
                lblStrideLengthAverageM1.ForeColor = Color.Red;
            else
                lblStrideLengthAverageM1.ForeColor = Color.Black;
        }
        else
        {
            lblStrideLengthAverageI.Text = lblStrideLengthAverageI.Text;
        }

        if (!lblVelocity.Text.Equals("") && (!lblVelocityM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblVelocity.Text) - Convert.ToSingle(lblVelocityM1.Text) <= Convert.ToSingle(-0.65))
                lblVelocityM1.ForeColor = Color.Red;
            else
                lblVelocityM1.ForeColor = Color.Black;
        }
        else
        {
            lblVelocity.Text = lblVelocity.Text;
        }

        if (!lblTouchDownDistanceLeftI.Text.Equals("") && (!lblTouchDownDistanceLeftM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblTouchDownDistanceLeftI.Text) - Convert.ToSingle(lblTouchDownDistanceLeftM1.Text) >= Convert.ToSingle(.02))
                lblTouchDownDistanceLeftM1.ForeColor = Color.Red;
            else
                lblTouchDownDistanceLeftM1.ForeColor = Color.Black;
        }
        else
        {
            lblTouchDownDistanceLeftI.Text = lblTouchDownDistanceLeftI.Text;
        }

        if (!lblTouchDownDistanceRightI.Text.Equals("") && (!lblTouchDownDistanceRightM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblTouchDownDistanceRightI.Text) - Convert.ToSingle(lblTouchDownDistanceRightM1.Text) >= Convert.ToSingle(.02))
                lblTouchDownDistanceRightM1.ForeColor = Color.Red;
            else
                lblTouchDownDistanceRightM1.ForeColor = Color.Black;
        }
        else
        {
            lblTouchDownDistanceLeftI.Text = lblTouchDownDistanceLeftI.Text;
        }



        if (!lblTouchDownDistanceAverageI.Text.Equals("") && (!lblTouchDownDistanceAverageM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblTouchDownDistanceAverageI.Text) - Convert.ToSingle(lblTouchDownDistanceAverageM1.Text) >= Convert.ToSingle(.02))
                lblTouchDownDistanceAverageM1.ForeColor = Color.Red;
            else
                lblTouchDownDistanceAverageM1.ForeColor = Color.Black;
        }
        else
        {
            lblTouchDownDistanceAverageI.Text = lblTouchDownDistanceAverageI.Text;
        }

        if (!lblUpperLegFullExtentionAngleLeftI.Text.Equals("") && (!lblUpperLegFullExtentionAngleLeftM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblUpperLegFullExtentionAngleLeftI.Text) - Convert.ToSingle(lblUpperLegFullExtentionAngleLeftM1.Text) <= Convert.ToInt16(-7))
                lblUpperLegFullExtentionAngleLeftM1.ForeColor = Color.Red;
            else
                lblUpperLegFullExtentionAngleLeftM1.ForeColor = Color.Black;
        }

        else
        {
            lblUpperLegFullExtentionAngleLeftI.Text = lblUpperLegFullExtentionAngleLeftI.Text;
        }

        if (!lblUpperLegFullExtentionAngleRightI.Text.Equals("") && (!lblUpperLegFullExtentionAngleRightM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblUpperLegFullExtentionAngleRightI.Text) - Convert.ToSingle(lblUpperLegFullExtentionAngleRightM1.Text) <= Convert.ToInt16(-7))
                lblUpperLegFullExtentionAngleRightM1.ForeColor = Color.Red;
            else
                lblUpperLegFullExtentionAngleRightM1.ForeColor = Color.Black;
        }
        else
        {
            lblUpperLegFullExtentionAngleRightI.Text = lblUpperLegFullExtentionAngleRightI.Text;
        }

        if (!lblUpperLegFullExtentionAngleAverageI.Text.Equals("") && (!lblUpperLegFullExtentionAngleAverageM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblUpperLegFullExtentionAngleAverageI.Text) - Convert.ToSingle(lblUpperLegFullExtentionAngleAverageM1.Text) <= Convert.ToInt16(-7))
                lblUpperLegFullExtentionAngleAverageM1.ForeColor = Color.Red;
            else
                lblUpperLegFullExtentionAngleAverageM1.ForeColor = Color.Black;
        }
        else
        {
            lblUpperLegFullExtentionAngleAverageI.Text = lblUpperLegFullExtentionAngleAverageI.Text;
        }



        if (!lblLowerLegAngleAtTakeOfLeftI.Text.Equals("") && (!lblLowerLegAngleAtTakeOfLeftM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblLowerLegAngleAtTakeOfLeftI.Text) - Convert.ToSingle(lblLowerLegAngleAtTakeOfLeftM1.Text) >= Convert.ToInt16(7))
                lblLowerLegAngleAtTakeOfLeftM1.ForeColor = Color.Red;
            else
                lblLowerLegAngleAtTakeOfLeftM1.ForeColor = Color.Black;
        }
        else
        {
            lblLowerLegAngleAtTakeOfLeftI.Text = lblLowerLegAngleAtTakeOfLeftI.Text;
        }

        if (!lblLowerLegAngleAtTakeOfRightI.Text.Equals("") && (!lblLowerLegAngleAtTakeOfRightM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblLowerLegAngleAtTakeOfRightI.Text) - Convert.ToSingle(lblLowerLegAngleAtTakeOfRightM1.Text) >= Convert.ToInt16(7))
                lblLowerLegAngleAtTakeOfRightM1.ForeColor = Color.Red;
            else
                lblLowerLegAngleAtTakeOfRightM1.ForeColor = Color.Black;
        }
        else
        {
            lblLowerLegAngleAtTakeOfRightI.Text = lblLowerLegAngleAtTakeOfRightI.Text;
        }

        if (!lblLowerLegAngleAtTakeOfAverageI.Text.Equals("") && (!lblLowerLegAngleAtTakeOfAverageM1.Text.Equals("")))
        {
            if (Convert.ToSingle(lblLowerLegAngleAtTakeOfAverageI.Text) - Convert.ToSingle(lblLowerLegAngleAtTakeOfAverageM1.Text) >= Convert.ToInt16(7))
                lblLowerLegAngleAtTakeOfAverageM1.ForeColor = Color.Red;
            else
                lblLowerLegAngleAtTakeOfAverageM1.ForeColor = Color.Black;
        }
        else
        {
            lblLowerLegAngleAtTakeOfAverageI.Text = lblLowerLegAngleAtTakeOfAverageI.Text;
        }


        if (!lblLowerLegFullFlexionAngleLeftI.Text.Equals("") && (!lblLowerLegFullFlexionAngleLeftM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToInt16(lblLowerLegFullFlexionAngleLeftI.Text) - Convert.ToInt16(lblLowerLegFullFlexionAngleLeftM1.Text)) >= Convert.ToInt16(7))

                lblLowerLegFullFlexionAngleLeftM1.ForeColor = Color.Red;
            else
                lblLowerLegFullFlexionAngleLeftM1.ForeColor = Color.Black;
        }
        else
        {
            lblLowerLegFullFlexionAngleLeftI.Text = lblLowerLegFullFlexionAngleLeftI.Text;
        }

        if (!lblLowerLegFullFlexionAngleRightI.Text.Equals("") && (!lblLowerLegFullFlexionAngleRightM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToInt16(lblLowerLegFullFlexionAngleRightI.Text) - Convert.ToInt16(lblLowerLegFullFlexionAngleRightM1.Text)) >= Convert.ToInt16(7))
                lblLowerLegFullFlexionAngleRightM1.ForeColor = Color.Red;
            else
                lblLowerLegFullFlexionAngleRightM1.ForeColor = Color.Black;
        }
        else
        {
            lblLowerLegFullFlexionAngleRightI.Text = lblLowerLegFullFlexionAngleRightI.Text;
        }


        if (!lblLowerLegFullFlexionAngleAverageI.Text.Equals("") && (!lblLowerLegFullFlexionAngleAverageM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToDecimal(lblLowerLegFullFlexionAngleAverageI.Text) - Convert.ToDecimal(lblLowerLegFullFlexionAngleAverageM1.Text)) >= Convert.ToInt16(7))
                lblLowerLegFullFlexionAngleAverageM1.ForeColor = Color.Red;
            else
                lblLowerLegFullFlexionAngleAverageM1.ForeColor = Color.Black;
        }
        else
        {
            lblLowerLegFullFlexionAngleAverageI.Text = lblLowerLegFullFlexionAngleAverageI.Text;
        }

        if (!lblLowerLegAngleAtAnkleCrossLeftI.Text.Equals("") && (!lblLowerLegAngleAtAnkleCrossAverageM1.Text.Equals("")))
        {

            if (Math.Abs(Convert.ToDecimal(lblLowerLegAngleAtAnkleCrossLeftI.Text) - Convert.ToDecimal(lblLowerLegAngleAtAnkleCrossAverageM1.Text)) >= Convert.ToInt16(7))
                lblLowerLegAngleAtAnkleCrossLeftM1.ForeColor = Color.Red;
            else
                lblLowerLegAngleAtAnkleCrossLeftM1.ForeColor = Color.Black;
        }
        else
        {
            lblLowerLegAngleAtAnkleCrossLeftI.Text = lblLowerLegAngleAtAnkleCrossLeftI.Text;
        }


        if (!lblLowerLegAngleAtAnkleCrossRightI.Text.Equals("") && (!lblLowerLegAngleAtAnkleCrossAverageM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToInt16(lblLowerLegAngleAtAnkleCrossRightI.Text) - Convert.ToInt16(lblLowerLegAngleAtAnkleCrossAverageM1.Text)) >= Convert.ToInt16(7))
                lblLowerLegAngleAtAnkleCrossRightM1.ForeColor = Color.Red;
            else
                lblLowerLegAngleAtAnkleCrossRightM1.ForeColor = Color.Black;
        }
        else
        {
            lblLowerLegAngleAtAnkleCrossRightI.Text = lblLowerLegAngleAtAnkleCrossRightI.Text;
        }

        if (!lblLowerLegAngleAtAnkleCrossAverageI.Text.Equals("") && (!lblLowerLegAngleAtAnkleCrossAverageM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToDecimal(lblLowerLegAngleAtAnkleCrossAverageI.Text) - Convert.ToDecimal(lblLowerLegAngleAtAnkleCrossAverageM1.Text)) >= Convert.ToInt16(7))
                lblLowerLegAngleAtAnkleCrossAverageM1.ForeColor = Color.Red;
            else
                lblLowerLegAngleAtAnkleCrossAverageM1.ForeColor = Color.Black;
        }
        else
        {
            lblLowerLegAngleAtAnkleCrossAverageI.Text = lblLowerLegAngleAtAnkleCrossAverageI.Text;
        }

        if (!lblUpperLegFullFlexionAngleLeftI.Text.Equals("") && (!lblUpperLegFullFlexionAngleAverageM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToInt16(lblUpperLegFullFlexionAngleLeftI.Text) - Convert.ToInt16(lblUpperLegFullFlexionAngleAverageM1.Text)) <= Convert.ToInt16(-7))
                lblUpperLegFullFlexionAngleLeftM1.ForeColor = Color.Red;
            else
                lblUpperLegFullFlexionAngleLeftM1.ForeColor = Color.Black;
        }
        else
        {
            lblUpperLegFullFlexionAngleLeftI.Text = lblUpperLegFullFlexionAngleLeftI.Text;
        }



        if (!lblUpperLegFullFlexionAngleRightI.Text.Equals("") && (!lblUpperLegFullFlexionAngleAverageM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToInt16(lblUpperLegFullFlexionAngleRightI.Text) - Convert.ToInt16(lblUpperLegFullFlexionAngleAverageM1.Text)) <= Convert.ToInt16(-7))
                lblUpperLegFullFlexionAngleRightM1.ForeColor = Color.Red;
            else
                lblUpperLegFullFlexionAngleRightM1.ForeColor = Color.Black;
        }

        else
        {
            lblUpperLegFullFlexionAngleRightI.Text = lblUpperLegFullFlexionAngleRightI.Text;
        }

        if (!lblUpperLegFullFlexionAngleAverageI.Text.Equals("") && (!lblUpperLegFullFlexionAngleAverageM1.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToDecimal(lblUpperLegFullFlexionAngleAverageI.Text) - Convert.ToDecimal(lblUpperLegFullFlexionAngleAverageM1.Text)) <= Convert.ToInt16(-7))
                lblUpperLegFullFlexionAngleAverageM1.ForeColor = Color.Red;
            else
                lblUpperLegFullFlexionAngleAverageM1.ForeColor = Color.Black;
        }

        else
        {
            lblUpperLegFullFlexionAngleAverageI.Text = lblUpperLegFullFlexionAngleAverageI.Text;
        }

        //for model_2 data

        if (!lblGroundTimeLeftF.Text.Equals("") && (!lblGroundTimeAverageM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblGroundTimeLeftF.Text) - Convert.ToSingle(lblGroundTimeAverageM2.Text) >= Convert.ToSingle(.007))
                lblGroundTimeLeftM2.ForeColor = Color.Red;
            else
                lblGroundTimeLeftM2.ForeColor = Color.Black;
        }
        else
        {
            lblGroundTimeLeftF.Text = lblGroundTimeLeftF.Text;
        }

        if (!lblGroundTimeRightF.Text.Equals("") && (!lblGroundTimeAverageM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblGroundTimeRightF.Text) - Convert.ToSingle(lblGroundTimeAverageM2.Text) >= Convert.ToSingle(.007))
                lblGroundTimeRightM2.ForeColor = Color.Red;
                
            else
                lblGroundTimeRightM2.ForeColor = Color.Black;
        }
        else
        {
            lblGroundTimeRightF.Text = lblGroundTimeRightF.Text;
        }

        if (!lblGroundTimeAverageF.Text.Equals("") && (!lblGroundTimeAverageM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblGroundTimeAverageF.Text) - Convert.ToSingle(lblGroundTimeAverageM2.Text) >= Convert.ToSingle(.007))
                lblGroundTimeAverageM2.ForeColor = Color.Red;
            else
                lblGroundTimeAverageM2.ForeColor = Color.Black;
        }
        else
        {
            lblGroundTimeAverageF.Text = lblGroundTimeAverageF.Text;
        }


        if (!lblAirTimeLeftToRightF.Text.Equals("") && (!lblAirTimeAverageM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblAirTimeLeftToRightF.Text) - Convert.ToSingle(lblAirTimeAverageM2.Text)) >= Convert.ToSingle(.005))
                lblAirTimeLeftToRightM2.ForeColor = System.Drawing.Color.Red;
            else
                lblAirTimeLeftToRightM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblAirTimeLeftToRightF.Text = lblAirTimeLeftToRightF.Text;
        }

        if (!lblAirTimeRightToLeftF.Text.Equals("") && (!lblAirTimeAverageM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblAirTimeRightToLeftF.Text) - Convert.ToSingle(lblAirTimeAverageM2.Text)) >= Convert.ToSingle(.005))
                lblAirTimeRightToLeftM2.ForeColor = System.Drawing.Color.Red;
            else
                lblAirTimeRightToLeftM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblAirTimeRightToLeftF.Text = lblAirTimeRightToLeftF.Text;
        }


        if (!lblAirTimeAverageF.Text.Equals("") && (!lblAirTimeAverageM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblAirTimeAverageF.Text) - Convert.ToSingle(lblAirTimeAverageM2.Text)) >= Convert.ToSingle(.005))
                lblAirTimeAverageM2.ForeColor = System.Drawing.Color.Red;
            else
                lblAirTimeAverageM2.ForeColor = System.Drawing.Color.Black;
        }

        else
        {
            lblAirTimeAverageF.Text = lblAirTimeAverageF.Text;
        }

        if (!lblTimeToUpperLegFullFlexionRightF.Text.Equals("") && (!lblTimeToUpperLegFullFlexionAverageM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblTimeToUpperLegFullFlexionRightF.Text) - Convert.ToSingle(lblTimeToUpperLegFullFlexionAverageM2.Text)) >= Convert.ToSingle(.005))
                lblTimeToUpperLegFullFlexionRightM2.ForeColor = System.Drawing.Color.Red;
            else
                lblTimeToUpperLegFullFlexionRightM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblTimeToUpperLegFullFlexionRightF.Text = lblTimeToUpperLegFullFlexionRightF.Text;
        }

        if (!lblTimeToUpperLegFullFlexionLeftF.Text.Equals("") && (!lblTimeToUpperLegFullFlexionAverageM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblTimeToUpperLegFullFlexionLeftF.Text) - Convert.ToSingle(lblTimeToUpperLegFullFlexionAverageM2.Text)) >= Convert.ToSingle(.005))
                lblTimeToUpperLegFullFlexionLeftM2.ForeColor = System.Drawing.Color.Red;
            else
                lblTimeToUpperLegFullFlexionLeftM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblTimeToUpperLegFullFlexionLeftF.Text = lblTimeToUpperLegFullFlexionLeftF.Text;
        }

        if (!lblTimeToUpperLegFullFlexionAverageF.Text.Equals("") && (!lblTimeToUpperLegFullFlexionAverageM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblTimeToUpperLegFullFlexionAverageF.Text) - Convert.ToSingle(lblTimeToUpperLegFullFlexionAverageM2.Text)) >= Convert.ToSingle(.005))
                lblTimeToUpperLegFullFlexionAverageM2.ForeColor = System.Drawing.Color.Red;
            else
                lblTimeToUpperLegFullFlexionAverageM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblTimeToUpperLegFullFlexionAverageF.Text = lblTimeToUpperLegFullFlexionAverageF.Text;
        }

        if (!lblStrideRateF.Text.Equals("") && (!lblStrideRateM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblStrideRateF.Text) - Convert.ToSingle(lblStrideRateM2.Text) <= Convert.ToSingle(-0.2))
                lblStrideRateM2.ForeColor = System.Drawing.Color.Red;
            else
                lblStrideRateM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblStrideRateF.Text = lblStrideRateF.Text;
        }


        if (!lblStrideLengthLeftToRighF.Text.Equals("") && (!lblStrideLengthAverageM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblStrideLengthLeftToRighF.Text) - Convert.ToSingle(lblStrideLengthAverageM2.Text)) <= Convert.ToSingle(-0.1))
                lblStrideLengthLeftToRighM2.ForeColor = System.Drawing.Color.Red;
            else
                lblStrideLengthLeftToRighM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblStrideLengthLeftToRighF.Text = lblStrideLengthLeftToRighF.Text;
        }

        if (!lblStrideLengthRightToLeftF.Text.Equals("") && (!lblStrideLengthAverageM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblStrideLengthRightToLeftF.Text) - Convert.ToSingle(lblStrideLengthAverageM2.Text)) <= Convert.ToSingle(-0.1))
                lblStrideLengthRightToLeftM2.ForeColor = System.Drawing.Color.Red;
            else
                lblStrideLengthRightToLeftM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblStrideLengthRightToLeftF.Text = lblStrideLengthRightToLeftF.Text;
        }

        if (!lblStrideLengthAverageF.Text.Equals("") && (!lblStrideLengthAverageM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToSingle(lblStrideLengthAverageF.Text) - Convert.ToSingle(lblStrideLengthAverageM2.Text)) <= Convert.ToSingle(-0.1))
                lblStrideLengthAverageM2.ForeColor = System.Drawing.Color.Red;
            else
                lblStrideLengthAverageM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblStrideLengthAverageF.Text = lblStrideLengthAverageF.Text;
        }



        if (!lblVelocityF.Text.Equals("") && (!lblVelocityM2.Text.Equals("")))
        {
            // Convert.ToSingle(lblVelocity.Text) - Convert.ToSingle(lblVelocityM1.Text) <= Convert.ToSingle(-0.65)

            if (Convert.ToSingle(lblVelocityF.Text) - Convert.ToSingle(lblVelocityM2.Text) <= Convert.ToSingle(-0.65))
                lblVelocityM2.ForeColor = System.Drawing.Color.Red;
            else
                lblVelocityM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblVelocityF.Text = lblVelocityF.Text;
        }


        if (!lblTouchDownDistanceLeftF.Text.Equals("") && (!lblTouchDownDistanceAverageM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblTouchDownDistanceLeftF.Text) - Convert.ToSingle(lblTouchDownDistanceAverageM2.Text) >= Convert.ToSingle(.02))
                lblTouchDownDistanceLeftM2.ForeColor = System.Drawing.Color.Red;
            else
                lblTouchDownDistanceLeftM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblTouchDownDistanceLeftF.Text = lblTouchDownDistanceLeftF.Text;
        }

        if (!lblTouchDownDistanceRightF.Text.Equals("") && (!lblTouchDownDistanceAverageM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblTouchDownDistanceRightF.Text) - Convert.ToSingle(lblTouchDownDistanceAverageM2.Text) >= Convert.ToSingle(.02))
                lblTouchDownDistanceRightM2.ForeColor = System.Drawing.Color.Red;
            else
                lblTouchDownDistanceRightM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblTouchDownDistanceRightF.Text = lblTouchDownDistanceRightF.Text;
        }

        if (!lblTouchDownDistanceAverageF.Text.Equals("") && (!lblTouchDownDistanceAverageM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblTouchDownDistanceAverageF.Text) - Convert.ToSingle(lblTouchDownDistanceAverageM2.Text) >= Convert.ToSingle(.02))
                lblTouchDownDistanceAverageM2.ForeColor = System.Drawing.Color.Red;
            else
                lblTouchDownDistanceAverageM2.ForeColor = System.Drawing.Color.Black;
        }

        else
        {
            lblTouchDownDistanceAverageF.Text = lblTouchDownDistanceAverageF.Text;
        }

        if (!lblUpperLegFullExtentionAngleLeftF.Text.Equals("") && (!lblUpperLegFullExtentionAngleAverageM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblUpperLegFullExtentionAngleLeftF.Text) - Convert.ToSingle(lblUpperLegFullExtentionAngleAverageM2.Text) <= Convert.ToInt16(-7))
                lblUpperLegFullExtentionAngleLeftM2.ForeColor = System.Drawing.Color.Red;
            else
                lblUpperLegFullExtentionAngleLeftM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblUpperLegFullExtentionAngleLeftF.Text = lblUpperLegFullExtentionAngleLeftF.Text;
        }

        if (!lblUpperLegFullExtentionAngleRightF.Text.Equals("") && (!lblUpperLegFullExtentionAngleAverageM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblUpperLegFullExtentionAngleRightF.Text) - Convert.ToSingle(lblUpperLegFullExtentionAngleAverageM2.Text) <= Convert.ToInt16(-7))
                lblUpperLegFullExtentionAngleRightM2.ForeColor = System.Drawing.Color.Red;
            else
                lblUpperLegFullExtentionAngleRightM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblUpperLegFullExtentionAngleRightF.Text = lblUpperLegFullExtentionAngleRightF.Text;
        }


        if (!lblUpperLegFullExtentionAngleAverageF.Text.Equals("") && (!lblUpperLegFullExtentionAngleAverageM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblUpperLegFullExtentionAngleAverageF.Text) - Convert.ToSingle(lblUpperLegFullExtentionAngleAverageM2.Text) <= Convert.ToInt16(-7))
                lblUpperLegFullExtentionAngleAverageM2.ForeColor = System.Drawing.Color.Red;
            else
                lblUpperLegFullExtentionAngleAverageM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblUpperLegFullExtentionAngleAverageF.Text = lblUpperLegFullExtentionAngleAverageF.Text;
        }



        if (!lblLowerLegAngleAtTakeOfLeftF.Text.Equals("") && (!lblLowerLegAngleAtTakeOfAverageM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblUpperLegFullExtentionAngleAverageF.Text) - Convert.ToSingle(lblLowerLegAngleAtTakeOfAverageM2.Text) >= Convert.ToInt16(7))
                lblLowerLegAngleAtTakeOfLeftM2.ForeColor = System.Drawing.Color.Red;
            else
                lblLowerLegAngleAtTakeOfLeftM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblLowerLegAngleAtTakeOfLeftF.Text = lblLowerLegAngleAtTakeOfLeftF.Text;
        }


        if (!lblLowerLegAngleAtTakeOfRightF.Text.Equals("") && (!lblLowerLegAngleAtTakeOfAverageM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblUpperLegFullExtentionAngleRightF.Text) - Convert.ToSingle(lblLowerLegAngleAtTakeOfAverageM2.Text) >= Convert.ToInt16(7))
                lblLowerLegAngleAtTakeOfAverageM2.ForeColor = System.Drawing.Color.Red;
            else
                lblLowerLegAngleAtTakeOfAverageM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblLowerLegAngleAtTakeOfRightF.Text = lblLowerLegAngleAtTakeOfRightF.Text;
        }



        if (!lblLowerLegAngleAtTakeOfAverageF.Text.Equals("") && (!lblLowerLegAngleAtTakeOfAverageM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblUpperLegFullExtentionAngleRightF.Text) - Convert.ToSingle(lblLowerLegAngleAtTakeOfAverageM2.Text) >= Convert.ToInt16(7))
                lblLowerLegAngleAtTakeOfAverageM2.ForeColor = System.Drawing.Color.Red;
            else
                lblLowerLegAngleAtTakeOfAverageM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblLowerLegAngleAtTakeOfAverageF.Text = lblLowerLegAngleAtTakeOfAverageF.Text;
        }


        if (!lblLowerLegFullFlexionAngleLeftF.Text.Equals("") && (!lblLowerLegFullFlexionAngleLeftM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblLowerLegFullFlexionAngleLeftF.Text) - Convert.ToSingle(lblLowerLegFullFlexionAngleLeftM2.Text) >= Convert.ToInt16(7))
                lblLowerLegFullFlexionAngleLeftM2.ForeColor = System.Drawing.Color.Red;
            else
                lblLowerLegFullFlexionAngleLeftM2.ForeColor = System.Drawing.Color.Black;
        }

        else
        {
            lblLowerLegFullFlexionAngleLeftF.Text = lblLowerLegFullFlexionAngleLeftF.Text;
        }

        if (!lblLowerLegFullFlexionAngleRightF.Text.Equals("") && (!lblLowerLegFullFlexionAngleRightM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblLowerLegFullFlexionAngleRightF.Text) - Convert.ToSingle(lblLowerLegFullFlexionAngleRightM2.Text) >= Convert.ToInt16(7))
                lblLowerLegFullFlexionAngleRightM2.ForeColor = System.Drawing.Color.Red;
            else
                lblLowerLegFullFlexionAngleRightM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblLowerLegFullFlexionAngleRightF.Text = lblLowerLegFullFlexionAngleRightF.Text;
        }

        if (!lblLowerLegFullFlexionAngleAverageF.Text.Equals("") && (!lblLowerLegFullFlexionAngleAverageM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblLowerLegFullFlexionAngleAverageF.Text) - Convert.ToSingle(lblLowerLegFullFlexionAngleAverageM2.Text) >= Convert.ToInt16(7))
                lblLowerLegFullFlexionAngleAverageM2.ForeColor = System.Drawing.Color.Red;
            else
                lblLowerLegFullFlexionAngleAverageM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblLowerLegFullFlexionAngleAverageF.Text = lblLowerLegFullFlexionAngleAverageF.Text;
        }


        if (!lblLowerLegAngleAtAnkleCrossLeftF.Text.Equals("") && (!lblLowerLegAngleAtAnkleCrossAverageM2.Text.Equals("")))
        {
            if (Math.Abs(Convert.ToInt16(lblLowerLegAngleAtAnkleCrossLeftF.Text) - Convert.ToInt16(lblLowerLegAngleAtAnkleCrossAverageM2.Text)) >= Convert.ToInt16(7))
                lblLowerLegAngleAtAnkleCrossLeftM2.ForeColor = System.Drawing.Color.Red;
            else
                lblLowerLegAngleAtAnkleCrossLeftM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblLowerLegAngleAtAnkleCrossLeftF.Text = lblLowerLegAngleAtAnkleCrossLeftF.Text;
        }


        if (!lblLowerLegAngleAtAnkleCrossRightF.Text.Equals("") && (!lblLowerLegAngleAtAnkleCrossAverageM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblLowerLegAngleAtAnkleCrossRightF.Text) - Convert.ToSingle(lblLowerLegAngleAtAnkleCrossAverageM2.Text) >= Convert.ToInt16(7))
                lblLowerLegAngleAtAnkleCrossRightM2.ForeColor = System.Drawing.Color.Red;
            else
                lblLowerLegAngleAtAnkleCrossRightM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblLowerLegAngleAtAnkleCrossRightF.Text = lblLowerLegAngleAtAnkleCrossRightF.Text;
        }

        if (!lblLowerLegAngleAtAnkleCrossAverageF.Text.Equals("") && (!lblLowerLegAngleAtAnkleCrossAverageM2.Text.Equals("")))
        {
            if (Convert.ToSingle(lblLowerLegAngleAtAnkleCrossAverageF.Text) - Convert.ToSingle(lblLowerLegAngleAtAnkleCrossAverageM2.Text) >= Convert.ToInt16(7))
                lblLowerLegAngleAtAnkleCrossAverageM2.ForeColor = System.Drawing.Color.Red;
            else
                lblLowerLegAngleAtAnkleCrossAverageM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblLowerLegAngleAtAnkleCrossAverageF.Text = lblLowerLegAngleAtAnkleCrossAverageF.Text;
        }


        if (!lblUpperLegFullFlexionAngleLeftF.Text.Equals("") && (!lblUpperLegFullFlexionAngleAverageM2.Text.Equals("")))
        {
            if (Convert.ToInt16(lblUpperLegFullFlexionAngleLeftF.Text) - Convert.ToInt16(lblUpperLegFullFlexionAngleAverageM2.Text) <= Convert.ToInt16(-7))
                lblUpperLegFullFlexionAngleLeftM2.ForeColor = System.Drawing.Color.Red;
            else
                lblUpperLegFullFlexionAngleLeftM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblUpperLegFullFlexionAngleLeftF.Text = lblUpperLegFullFlexionAngleLeftF.Text;
        }

        if (!lblUpperLegFullFlexionAngleRightF.Text.Equals("") && (!lblUpperLegFullFlexionAngleAverageM2.Text.Equals("")))
        {
            if (Convert.ToInt16(lblUpperLegFullFlexionAngleRightF.Text) - Convert.ToInt16(lblUpperLegFullFlexionAngleAverageM2.Text) <= Convert.ToInt16(-7))
                lblUpperLegFullFlexionAngleRightM2.ForeColor = System.Drawing.Color.Red;
            else
                lblUpperLegFullFlexionAngleRightM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblUpperLegFullFlexionAngleRightF.Text = lblUpperLegFullFlexionAngleRightF.Text;
        }

        if (!lblUpperLegFullFlexionAngleAverageF.Text.Equals("") && (!lblUpperLegFullFlexionAngleAverageM2.Text.Equals("")))
        {
            if (Convert.ToInt16(lblUpperLegFullFlexionAngleAverageF.Text) - Convert.ToInt16(lblUpperLegFullFlexionAngleAverageM2.Text) <= Convert.ToInt16(-7))
                lblUpperLegFullFlexionAngleAverageM2.ForeColor = System.Drawing.Color.Red;
            else
                lblUpperLegFullFlexionAngleAverageM2.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblUpperLegFullFlexionAngleAverageF.Text = lblUpperLegFullFlexionAngleAverageF.Text;
        }

      
    }
  

}