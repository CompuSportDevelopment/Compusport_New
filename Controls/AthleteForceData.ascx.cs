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
using System.Web.Script.Serialization;
using System.Windows.Forms;

public partial class Controls_AthleteForceData : System.Web.UI.UserControl
{
    Customer customer;
    bool customerexists;
    CompuSportDAL.SprintAthleteEdit sae = new CompuSportDAL.SprintAthleteEdit();
    DataTable dtActualForceData = new DataTable();
    //DataTable dtRelativeForces = new DataTable();
    DataTable dtActualPower = new DataTable();
    //DataTable dtRelativePower = new DataTable();
    Lesson lesson;
    TList<Lesson> lessonList = new TList<Lesson>();
    SMSoftCharts.Gauge ga = new SMSoftCharts.Gauge();

    int _otherSelectedSessionId;
    string strUrl;
    int loggedInAthleteId;
    float ActualAthleteHorizontalForce;
    float ActualModelHorizontalForce;
    float ActualAthleteVerticalForce;
    float ActualModelVerticalForce;
    float ActualAthleteTotalForce;
    float ActualModelTotalForce;
    int RelativeHorizontalForce;
    int RelativeVerticalForce;
    int RelativeTotalForce;

    float ActualAthleteHorizontalPower;
    float ActualModelHorizontalPower;
    float ActualAthleteVerticalPower;
    float ActualModelVerticalPower;
    float ActualAthleteTotalPower;
    float ActualModelTotalPower;
    int RelativeHorizontalPower;
    int RelativeVerticalPower;
    int RelativeTotalPower;


    //protected override void OnPreLoad(EventArgs e)
    //{

    //}

    protected override void OnPreRender(EventArgs e)
    {
        Accordion1.FindControl("Accordion1");
        Accordion2.FindControl("Accordion2");
        Accordion3.FindControl("Accordion3");
        Accordion4.FindControl("Accordion4");
        Accordion5.FindControl("Accordion5");
        Accordion6.FindControl("Accordion6");

        if (Page.User.Identity.IsAuthenticated)
        {
            try
            {
                customer = DataRepository.CustomerProvider.GetByCustomerId(Convert.ToInt16(Request.QueryString.Get("customerid")));
                //  customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
                customerexists = true;
                lblSelectedAthlete.Text = customer.FirstName + " " + customer.LastName; customerexists = true;
            }
            catch
            {
                customerexists = false;

            }
        }
        // CheckProfiles myCheckProfiles = new CheckProfiles();

        //if (this.User.Identity.IsAuthenticated)
        //{
        //if (!myCheckProfiles.Personal())
        //{
        //    //MessageBox.Show("1a");
        //    this.Page.Response.Redirect("~/Users/MyAccount.aspx");
        //}

        //if (!myCheckProfiles.Address())
        //{
        //    if (myCheckProfiles.Personal() && myCheckProfiles.Facility())
        //    {
        //        //MessageBox.Show("2a");
        //        this.Page.Response.Redirect("~/Users/MyAccount.aspx");
        //    }
        //}

        //if (!myCheckProfiles.Facility())
        //{
        //    if (myCheckProfiles.Personal() && myCheckProfiles.Address())
        //    {
        //        //MessageBox.Show("3a");
        //        this.Page.Response.Redirect("~/Users/MyAccount.aspx");
        //    }
        //}

        //if (!myCheckProfiles.Dimensions())
        //{
        //    if (myCheckProfiles.Personal() && myCheckProfiles.Address() && myCheckProfiles.Facility())
        //    {
        //        //MessageBox.Show("4a");
        //        this.Page.Response.Redirect("~/Users/MyDimensions.aspx");
        //    }
        //}

        //if (!myCheckProfiles.Golf())
        //{
        //    if (myCheckProfiles.Personal() && myCheckProfiles.Address() && myCheckProfiles.Facility() && myCheckProfiles.Dimensions())
        //    {
        //        //MessageBox.Show("5a");
        //        this.Page.Response.Redirect("~/Users/MyGolf.aspx");
        //    }
        //}
        //  }

        base.OnPreRender(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            customer = DataRepository.CustomerProvider.GetByCustomerId(Convert.ToInt32(Request.QueryString.Get("customerid")));
            lblSelectedAthlete.Text = customer.FirstName + " " + customer.LastName;
            int backBlockCurrentSelectedSessionId;

            int frontBlockCurrentSelectedSessionId;
            int frontBlockInitialSelectedSessionId;
            int counterForBackBlockData = 0;
            int counterForFrontBlockData = 0;
            int backBlockInitialSelectedSessionId;
            loggedInAthleteId = customer.CustomerId;
            lessonList = DataRepository.LessonProvider.GetByCustomerId(loggedInAthleteId);
            #region[back block data]
            foreach (Lesson session1 in lessonList)
            {
                if (session1.LessonTypeId.Equals(1))
                {
                    sae.CustomerId = customer.CustomerId;
                    sae.LessonId = session1.LessonId;
                    dtActualForceData = sae.GetActualForceBlockForceInputData();
                    if (dtActualForceData.Rows.Count > 0)
                    {
                        counterForBackBlockData++;
                    }
                }
            }
            int numberOfBackBlockForceSessions = counterForBackBlockData;
            if (numberOfBackBlockForceSessions > 0)
            {

                DataTable dtBackBlockInitialSelectedSessionId = new DataTable();
                dtBackBlockInitialSelectedSessionId = sae.SelectSecondEarliestLessonIdOfForces();
                backBlockInitialSelectedSessionId = Convert.ToInt32(dtBackBlockInitialSelectedSessionId.Rows[0]["LessonId"]);

                DataTable dtBackBlockCurrentSelectedSessionId = new DataTable();
                dtBackBlockCurrentSelectedSessionId = sae.SelectLatestLessonIdOfForces();
                backBlockCurrentSelectedSessionId = Convert.ToInt32(dtBackBlockCurrentSelectedSessionId.Rows[0]["LessonId"]);
                switch (numberOfBackBlockForceSessions)
                {
                    case 1:
                        if (numberOfBackBlockForceSessions == 1)
                        {
                            DisplayCurrentBackBlockData(backBlockCurrentSelectedSessionId);
                            MakeImagesHiddenForInitialBackBlockData();
                            MakeImagesHiddenForOtherBackBlockData();
                        }
                        break;
                    case 2:
                        if (numberOfBackBlockForceSessions == 2)
                        {
                            DisplayCurrentBackBlockData(backBlockCurrentSelectedSessionId);
                            DisplayInitialBackBlockData(backBlockInitialSelectedSessionId);
                            MakeImagesHiddenForOtherBackBlockData();
                        }
                        break;
                    default:
                        if (numberOfBackBlockForceSessions >= 3)
                        {
                            DisplayCurrentBackBlockData(backBlockCurrentSelectedSessionId);
                            DisplayInitialBackBlockData(backBlockInitialSelectedSessionId);
                            DisplayOtherBackBlockData(backBlockCurrentSelectedSessionId, backBlockInitialSelectedSessionId);
                        }
                        break;
                }
            }
            else
            {
                MakeImagesHiddenForInitialBackBlockData();
                MakeImagesHiddenForOtherBackBlockData();
                MakeImagesHiddenForCurrentBackBlockData();

            }
            #endregion[back block data]

            #region[front block data]
            foreach (Lesson session2 in lessonList)
            {
                if (session2.LessonTypeId.Equals(1))
                {
                    sae.CustomerId = customer.CustomerId;
                    sae.LessonId = session2.LessonId;
                    dtActualForceData = sae.GetActualForceFrontBlockForceInputData();
                    if (dtActualForceData.Rows.Count > 0)
                    {
                        counterForFrontBlockData++;
                    }
                }
            }
            int numberOfFrontBlockForceSessions = counterForFrontBlockData;
            if (numberOfFrontBlockForceSessions > 0)
            {

                DataTable dtFrontBlockInitialSelectedSessionId = new DataTable();
                dtFrontBlockInitialSelectedSessionId = sae.SelectSecondEarliestLessonIdOfForces();
                frontBlockInitialSelectedSessionId = Convert.ToInt32(dtFrontBlockInitialSelectedSessionId.Rows[0]["LessonId"]);

                DataTable dtFrontBlockCurrentSelectedSessionId = new DataTable();
                dtFrontBlockCurrentSelectedSessionId = sae.SelectLatestLessonIdOfForces();
                frontBlockCurrentSelectedSessionId = Convert.ToInt32(dtFrontBlockCurrentSelectedSessionId.Rows[0]["LessonId"]);

                switch (numberOfFrontBlockForceSessions)
                {
                    case 1:
                        if (numberOfFrontBlockForceSessions == 1)
                        {
                            DisplayCurrentFrontBlockData(frontBlockCurrentSelectedSessionId);
                            MakeImagesHiddenForInitialFrontBlockData();
                            MakeImagesHiddenForOtherFrontBlockData();
                        }
                        break;
                    case 2:
                        if (numberOfFrontBlockForceSessions == 2)
                        {
                            DisplayCurrentFrontBlockData(frontBlockCurrentSelectedSessionId);
                            DisplayInitialFrontBlockData(frontBlockInitialSelectedSessionId);
                            MakeImagesHiddenForOtherFrontBlockData();
                        }
                        break;
                    default:
                        if (numberOfFrontBlockForceSessions >= 2)
                        {
                            DisplayCurrentFrontBlockData(frontBlockCurrentSelectedSessionId);
                            DisplayInitialFrontBlockData(frontBlockInitialSelectedSessionId);
                            DisplayOtherFrontBlockData(frontBlockCurrentSelectedSessionId, frontBlockInitialSelectedSessionId);
                        }
                        break;
                }
            }
            else
            {
                MakeImagesHiddenForCurrentFrontBlockData();
                MakeImagesHiddenForInitialFrontBlockData();
                MakeImagesHiddenForOtherFrontBlockData();
            }
            #endregion[front block data]
        }
    }
    private void DisplayCurrentBackBlockData(int lessonId)
    {
        TabPanel1.HeaderText = "Current Back Block Data";
        TabPanel1.Visible = true;
        sae.CustomerId = customer.CustomerId;
        sae.LessonId = lessonId;
        #region[Actual force]
        dtActualForceData = sae.GetActualForceBlockForceInputData();
        if (dtActualForceData.Rows.Count > 0)
        {
            strUrl = "~/Users/DistanceGauge.aspx?athleteHorizontalValue=" + dtActualForceData.Rows[0]["AthleteHorizontalValue"].ToString() + "&modelHorizontalValue=" + dtActualForceData.Rows[0]["ModelHorizontalValue"].ToString();
            Image1.ImageUrl = strUrl;

            strUrl = "~/Users/SideDistanceGauge.aspx?athleteVerticalValue=" + dtActualForceData.Rows[0]["AthleteVerticalValue"].ToString() + "&ModelVerticalValue=" + dtActualForceData.Rows[0]["ModelVerticalValue"].ToString();
            Image7.ImageUrl = strUrl;

            strUrl = "~/Users/SideDeviationGauge.aspx?athleteTotalValue=" + dtActualForceData.Rows[0]["AthleteTotalValue"].ToString() + "&modelTotalvalue=" + dtActualForceData.Rows[0]["ModelTotalValue"].ToString();
            Image8.ImageUrl = strUrl;
        }
        else
        {
            Image1.Visible = false; Image7.Visible = false; Image8.Visible = false; AFCurrentBackBlockData.Visible = false; lblCurrentBackAF.Visible = true;
        }
        #endregion[Actual Force]

        #region[Relative Force]

        ActualAthleteHorizontalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteHorizontalValue"].ToString());
        ActualModelHorizontalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelHorizontalValue"].ToString());
        ActualAthleteVerticalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteVerticalValue"].ToString());
        ActualModelVerticalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelVerticalValue"].ToString());
        ActualAthleteTotalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteTotalValue"].ToString());
        ActualModelTotalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelTotalValue"].ToString());



        if ((ActualModelHorizontalForce > 0) && (ActualModelVerticalForce > 0) && (ActualModelTotalForce > 0))
        {
            RelativeHorizontalForce = Convert.ToInt32((ActualAthleteHorizontalForce / ActualModelHorizontalForce) * 100);
            RelativeVerticalForce = Convert.ToInt32((ActualAthleteVerticalForce / ActualModelVerticalForce) * 100);
            RelativeTotalForce = Convert.ToInt32((ActualAthleteTotalForce / ActualModelTotalForce) * 100);

            strUrl = "~/Users/ClubheadSpeedGauge.aspx?RelativeHorizontalForce=" + RelativeHorizontalForce;
            Image9.ImageUrl = strUrl;

            strUrl = "~/Users/SmashFactorGauge.aspx?RelativeVerticalForce=" + RelativeVerticalForce;
            Image2.ImageUrl = strUrl;


            strUrl = "~/Users/BallSpeedGauge.aspx?RelativeTotalForce=" + RelativeTotalForce;
            Image10.ImageUrl = strUrl;
        }
        else
        {
            Image9.Visible = false; Image2.Visible = false; Image10.Visible = false; RFCurrentBackBlockData.Visible = false; lblCurrentBackRF.Visible = true;
        }

        #endregion[Relative Force]

        #region[Actual Power]

        dtActualPower = sae.GetActualPowerBlockForceInputData();
        if (dtActualPower.Rows.Count > 0)
        {
            strUrl = "~/Users/LaunchAngleGauge.aspx?athleteHorizontalValue=" + dtActualPower.Rows[0]["AthleteHorizontalValue"].ToString() + "&modelHorizontalValue=" + dtActualPower.Rows[0]["modelHorizontalValue"].ToString();
            Image3.ImageUrl = strUrl;

            strUrl = "~/Users/BackSpinGauge.aspx?athleteVerticalValue=" + dtActualPower.Rows[0]["AthleteVerticalValue"].ToString() + "&ModelVerticalValue=" + dtActualPower.Rows[0]["ModelVerticalValue"].ToString();
            Image4.ImageUrl = strUrl;

            strUrl = "~/Users/TotalActualPower.aspx?athleteTotalValue=" + dtActualPower.Rows[0]["AthleteTotalValue"].ToString() + "&modelTotalvalue=" + dtActualPower.Rows[0]["ModelTotalValue"].ToString();
            Image61.ImageUrl = strUrl;
        }
        else
        {
            Image3.Visible = false; Image4.Visible = false; Image61.Visible = false; APCurrentBackBlockData.Visible = false; lblCurrentBackAP.Visible = true;
        }

        #endregion[Actual Power]

        #region[Relative Power]

        ActualAthleteHorizontalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteHorizontalValue"].ToString());
        ActualModelHorizontalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelHorizontalValue"].ToString());
        ActualAthleteVerticalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteVerticalValue"].ToString());
        ActualModelVerticalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelVerticalValue"].ToString());
        ActualAthleteTotalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteTotalValue"].ToString());
        ActualModelTotalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelTotalValue"].ToString());



        if ((ActualModelHorizontalPower > 0) && (ActualModelVerticalPower > 0) && (ActualModelTotalPower > 0))
        {
            RelativeHorizontalPower = Convert.ToInt32((ActualAthleteHorizontalPower / ActualModelHorizontalPower) * 100);
            RelativeVerticalPower = Convert.ToInt32((ActualAthleteVerticalPower / ActualModelVerticalPower) * 100);
            RelativeTotalPower = Convert.ToInt32((ActualAthleteTotalPower / ActualModelTotalPower) * 100);

            strUrl = "~/Users/SideAngleGauge.aspx?RelativeHorizontalPower=" + RelativeHorizontalPower;
            Image5.ImageUrl = strUrl;

            strUrl = "~/Users/SideSpinGauge.aspx?RelativeVerticalPower=" + RelativeVerticalPower;
            Image6.ImageUrl = strUrl;

            strUrl = "~/Users/TotalRelativePower.aspx?RelativeTotalPower=" + RelativeTotalPower;
            Image62.ImageUrl = strUrl;

            lesson = DataRepository.LessonProvider.GetByLessonId(lessonId);
            Label1.Text = DateTime.Parse(lesson.LessonDate.ToString()).ToShortDateString();
        }
        else
        {
            Image5.Visible = false; Image6.Visible = false; Image62.Visible = false; RPCurrentBackBlockData.Visible = false; lblCurrentBackRP.Visible = true;
        }
        #endregion[Relative Power]
    }


    private void DisplayInitialBackBlockData(int lessonId)
    {
        TabPanel2.HeaderText = "Initial Back Block Data ";
        TabPanel2.Visible = true;
        sae.CustomerId = customer.CustomerId;
        sae.LessonId = lessonId;

        #region[Actual force]

        dtActualForceData = sae.GetActualForceBlockForceInputData();
        if (dtActualForceData.Rows.Count > 0)
        {
            strUrl = "~/Users/DistanceGauge.aspx?athleteHorizontalValue=" + dtActualForceData.Rows[0]["AthleteHorizontalValue"].ToString() + "&modelHorizontalValue=" + dtActualForceData.Rows[0]["modelHorizontalValue"].ToString();
            Image11.ImageUrl = strUrl;

            strUrl = "~/Users/SideDistanceGauge.aspx?athleteVerticalValue=" + dtActualForceData.Rows[0]["AthleteVerticalValue"].ToString() + "&ModelVerticalValue=" + dtActualForceData.Rows[0]["ModelVerticalValue"].ToString();
            Image12.ImageUrl = strUrl;

            strUrl = "~/Users/SideDeviationGauge.aspx?athleteTotalValue=" + dtActualForceData.Rows[0]["AthleteTotalValue"].ToString() + "&modelTotalvalue=" + dtActualForceData.Rows[0]["ModelTotalValue"].ToString();
            Image13.ImageUrl = strUrl;
        }
        else
        {
            Image11.Visible = false; Image12.Visible = false; Image13.Visible = false; AFInitialBackBlockData.Visible = false; lblInitialBackAF.Visible = true;
        }
        #endregion[Actual force]

        #region[Relative Force]

        ActualAthleteHorizontalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteHorizontalValue"].ToString());
        ActualModelHorizontalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelHorizontalValue"].ToString());
        ActualAthleteVerticalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteVerticalValue"].ToString());
        ActualModelVerticalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelVerticalValue"].ToString());
        ActualAthleteTotalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteTotalValue"].ToString());
        ActualModelTotalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelTotalValue"].ToString());

        if ((ActualModelHorizontalForce > 0) && (ActualModelVerticalForce > 0) && (ActualModelTotalForce > 0))
        {
            RelativeHorizontalForce = Convert.ToInt32((ActualAthleteHorizontalForce / ActualModelHorizontalForce) * 100);
            RelativeVerticalForce = Convert.ToInt32((ActualAthleteVerticalForce / ActualModelVerticalForce) * 100);
            RelativeTotalForce = Convert.ToInt32((ActualAthleteTotalForce / ActualModelTotalForce) * 100);

            strUrl = "~/Users/ClubheadSpeedGauge.aspx?RelativeHorizontalForce=" + RelativeHorizontalForce;
            Image14.ImageUrl = strUrl;

            strUrl = "~/Users/SmashFactorGauge.aspx?RelativeVerticalForce=" + RelativeVerticalForce;
            Image15.ImageUrl = strUrl;

            strUrl = "~/Users/BallSpeedGauge.aspx?RelativeTotalForce=" + RelativeTotalForce;
            Image16.ImageUrl = strUrl;
        }
        else
        {
            Image14.Visible = false; Image15.Visible = false; Image16.Visible = false; RFInitialBackBlockData.Visible = false; lblInitialBackRF.Visible = true;
        }

        #endregion[Relative Force]
        #region[Actual Power]

        dtActualPower = sae.GetActualPowerBlockForceInputData();
        if (dtActualPower.Rows.Count > 0)
        {
            strUrl = "~/Users/LaunchAngleGauge.aspx?athleteHorizontalValue=" + dtActualPower.Rows[0]["AthleteHorizontalValue"].ToString() + "&modelHorizontalValue=" + dtActualPower.Rows[0]["modelHorizontalValue"].ToString();
            Image17.ImageUrl = strUrl;

            strUrl = "~/Users/BackSpinGauge.aspx?athleteVerticalValue=" + dtActualPower.Rows[0]["AthleteVerticalValue"].ToString() + "&ModelVerticalValue=" + dtActualPower.Rows[0]["ModelVerticalValue"].ToString();
            Image18.ImageUrl = strUrl;

            strUrl = "~/Users/TotalActualPower.aspx?athleteTotalValue=" + dtActualPower.Rows[0]["AthleteTotalValue"].ToString() + "&modelTotalvalue=" + dtActualPower.Rows[0]["ModelTotalValue"].ToString();
            Image63.ImageUrl = strUrl;

        }
        else
        {
            Image17.Visible = false; Image18.Visible = false; Image63.Visible = false; APInitialBackBlockData.Visible = false; lblInitialBackAP.Visible = true;
        }
        #endregion[Actual Power]
        #region[Relative Power]

        ActualAthleteHorizontalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteHorizontalValue"].ToString());
        ActualModelHorizontalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelHorizontalValue"].ToString());
        ActualAthleteVerticalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteVerticalValue"].ToString());
        ActualModelVerticalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelVerticalValue"].ToString());
        ActualAthleteTotalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteTotalValue"].ToString());
        ActualModelTotalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelTotalValue"].ToString());

        if ((ActualModelHorizontalPower > 0) && (ActualModelVerticalPower > 0) && (ActualModelTotalPower > 0))
        {
            RelativeHorizontalPower = Convert.ToInt32((ActualAthleteHorizontalPower / ActualModelHorizontalPower) * 100);
            RelativeVerticalPower = Convert.ToInt32((ActualAthleteVerticalPower / ActualModelVerticalPower) * 100);
            RelativeTotalPower = Convert.ToInt32((ActualAthleteTotalPower / ActualModelTotalPower) * 100);

            strUrl = "~/Users/SideAngleGauge.aspx?RelativeHorizontalPower=" + RelativeHorizontalPower;
            Image19.ImageUrl = strUrl;

            strUrl = "~/Users/SideSpinGauge.aspx?RelativeVerticalPower=" + RelativeVerticalPower;
            Image20.ImageUrl = strUrl;

            strUrl = "~/Users/TotalRelativePower.aspx?RelativeTotalPower=" + RelativeTotalPower;
            Image64.ImageUrl = strUrl;

            lesson = DataRepository.LessonProvider.GetByLessonId(lessonId);
            Label3.Text = DateTime.Parse(lesson.LessonDate.ToString()).ToShortDateString();
        }
        else
        {
            Image19.Visible = false; Image20.Visible = false; Image64.Visible = false; RPInitialBackBlockData.Visible = false; lblInitialBackRP.Visible = true;
        }
        #endregion[Relative Power]

    }
    private void DisplayOtherBackBlockData(int latestLessonId, int secondLetestLessonId)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Clear();
            loggedInAthleteId = customer.CustomerId;
            lessonList = DataRepository.LessonProvider.GetByCustomerId(loggedInAthleteId);
            lessonList.Sort("LessonDate DESC");
            lesson = DataRepository.LessonProvider.GetByCustomerId(loggedInAthleteId)[0];
            if (lessonList.Count != 0)
            {
                int count = 0;
                DropDownList1.Items.Add("Select Analysis Date and Location");
                DropDownList1.Items[count].Value = "";
                Accordion1.Visible = true;
                foreach (Lesson session in lessonList)
                {
                    if (session.LessonTypeId.Equals(1))
                    {
                        sae.LessonId = session.LessonId;
                        sae.CustomerId = session.CustomerId;
                        dtActualForceData = sae.GetActualForceBlockForceInputData();
                        if (dtActualForceData.Rows.Count > 0)
                        {
                            string location = sae.SelectLessonlocation(session.LessonId.ToString());
                            if ((session.LessonId != latestLessonId) && (session.LessonId != secondLetestLessonId))
                            {
                                count++;
                                DropDownList1.Items.Add(session.LessonDate.ToString(("MM/dd/yyyy")) + " - " + location);
                                DropDownList1.Items[count].Value = session.LessonId.ToString();
                            }
                        }
                    }
                }
            }
            MakeImagesHiddenForOtherBackBlockData();
        }
    }
    private void DisplayCurrentFrontBlockData(int lessonId)
    {
        TabPanel4.HeaderText = "Current Front Block Data";
        TabPanel4.Visible = true;
        sae.CustomerId = customer.CustomerId;
        sae.LessonId = lessonId;
        #region[Actual force]
        dtActualForceData = sae.GetActualForceFrontBlockForceInputData();

        if (dtActualForceData.Rows.Count > 0)
        {
            strUrl = "~/Users/DistanceGauge.aspx?athleteHorizontalValue=" + dtActualForceData.Rows[0]["AthleteHorizontalValue"].ToString() + "&modelHorizontalValue=" + dtActualForceData.Rows[0]["modelHorizontalValue"].ToString();
            Image21.ImageUrl = strUrl;

            strUrl = "~/Users/SideDistanceGauge.aspx?athleteVerticalValue=" + dtActualForceData.Rows[0]["AthleteVerticalValue"].ToString() + "&ModelVerticalValue=" + dtActualForceData.Rows[0]["ModelVerticalValue"].ToString();
            Image22.ImageUrl = strUrl;

            strUrl = "~/Users/SideDeviationGauge.aspx?athleteTotalValue=" + dtActualForceData.Rows[0]["AthleteTotalValue"].ToString() + "&modelTotalvalue=" + dtActualForceData.Rows[0]["ModelTotalValue"].ToString();
            Image23.ImageUrl = strUrl;
        }

        else
        {
            Image21.Visible = false; Image22.Visible = false; Image23.Visible = false; AFCurrentFrontBlockData.Visible = false; lblCurrentFrontAF.Visible = true;
        }
        #endregion[Actual force]
        #region[Relative Force]

        ActualAthleteHorizontalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteHorizontalValue"].ToString());
        ActualModelHorizontalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelHorizontalValue"].ToString());
        ActualAthleteVerticalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteVerticalValue"].ToString());
        ActualModelVerticalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelVerticalValue"].ToString());
        ActualAthleteTotalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteTotalValue"].ToString());
        ActualModelTotalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelTotalValue"].ToString());

        if ((ActualModelHorizontalForce > 0) && (ActualModelVerticalForce > 0) && (ActualModelTotalForce > 0))
        {
            RelativeHorizontalForce = Convert.ToInt32((ActualAthleteHorizontalForce / ActualModelHorizontalForce) * 100);
            RelativeVerticalForce = Convert.ToInt32((ActualAthleteVerticalForce / ActualModelVerticalForce) * 100);
            RelativeTotalForce = Convert.ToInt32((ActualAthleteTotalForce / ActualModelTotalForce) * 100);

            strUrl = "~/Users/ClubheadSpeedGauge.aspx?RelativeHorizontalForce=" + RelativeHorizontalForce;
            Image24.ImageUrl = strUrl;

            strUrl = "~/Users/SmashFactorGauge.aspx?RelativeVerticalForce=" + RelativeVerticalForce;
            Image25.ImageUrl = strUrl;

            strUrl = "~/Users/BallSpeedGauge.aspx?RelativeTotalForce=" + RelativeTotalForce;
            Image26.ImageUrl = strUrl;
        }

        else
        {
            Image24.Visible = false; Image25.Visible = false; Image26.Visible = false; RFCurrentFrontBlockData.Visible = false; lblCurrrentFrontRF.Visible = true;
        }
        #endregion[Relative Force]
        #region[Actual Power]

        dtActualPower = sae.GetActualPowerFrontBlockForceInputData();
        if (dtActualPower.Rows.Count > 0)
        {
            strUrl = "~/Users/LaunchAngleGauge.aspx?athleteHorizontalValue=" + dtActualPower.Rows[0]["AthleteHorizontalValue"].ToString() + "&modelHorizontalValue=" + dtActualPower.Rows[0]["modelHorizontalValue"].ToString();
            Image27.ImageUrl = strUrl;

            strUrl = "~/Users/BackSpinGauge.aspx?athleteVerticalValue=" + dtActualPower.Rows[0]["AthleteVerticalValue"].ToString() + "&ModelVerticalValue=" + dtActualPower.Rows[0]["ModelVerticalValue"].ToString();
            Image28.ImageUrl = strUrl;

            strUrl = "~/Users/TotalActualPower.aspx?athleteTotalValue=" + dtActualPower.Rows[0]["AthleteTotalValue"].ToString() + "&modelTotalvalue=" + dtActualPower.Rows[0]["ModelTotalValue"].ToString();
            Image67.ImageUrl = strUrl;

        }
        else
        {
            Image27.Visible = false; Image28.Visible = false; Image67.Visible = false; APCurrentFrontBlockData.Visible = false; lblCurrrentFrontAP.Visible = true;
        }

        #endregion[Actual Power]

        #region[Relative Power]

        ActualAthleteHorizontalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteHorizontalValue"].ToString());
        ActualModelHorizontalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelHorizontalValue"].ToString());
        ActualAthleteVerticalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteVerticalValue"].ToString());
        ActualModelVerticalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelVerticalValue"].ToString());
        ActualAthleteTotalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteTotalValue"].ToString());
        ActualModelTotalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelTotalValue"].ToString());

        if ((ActualModelHorizontalPower > 0) && (ActualModelVerticalPower > 0) && (ActualModelTotalPower > 0))
        {
            RelativeHorizontalPower = Convert.ToInt32((ActualAthleteHorizontalPower / ActualModelHorizontalPower) * 100);
            RelativeVerticalPower = Convert.ToInt32((ActualAthleteVerticalPower / ActualModelVerticalPower) * 100);
            RelativeTotalPower = Convert.ToInt32((ActualAthleteTotalPower / ActualModelTotalPower) * 100);

            strUrl = "~/Users/SideAngleGauge.aspx?RelativeHorizontalPower=" + RelativeHorizontalPower;
            Image29.ImageUrl = strUrl;

            strUrl = "~/Users/SideSpinGauge.aspx?RelativeVerticalPower=" + RelativeVerticalPower;
            Image30.ImageUrl = strUrl;

            strUrl = "~/Users/TotalRelativePower.aspx?RelativeTotalPower=" + RelativeTotalPower;
            Image68.ImageUrl = strUrl;

            lesson = DataRepository.LessonProvider.GetByLessonId(lessonId);
            Label7.Text = DateTime.Parse(lesson.LessonDate.ToString()).ToShortDateString();
        }

        else
        {
            Image29.Visible = false; Image30.Visible = false; Image68.Visible = false; RFCurrentFrontBlockData.Visible = false; lblCurrrentFrontRP.Visible = true;
        }
        #endregion[Relative Power]
    }


    private void DisplayInitialFrontBlockData(int lessonId)
    {
        TabPanel5.HeaderText = "Initial Front Block Data";
        TabPanel5.Visible = true;
        sae.CustomerId = customer.CustomerId;
        sae.LessonId = lessonId;

        #region[Actual force]


        dtActualForceData = sae.GetActualForceFrontBlockForceInputData();
        if (dtActualForceData.Rows.Count > 0)
        {
            strUrl = "~/Users/DistanceGauge.aspx?athleteHorizontalValue=" + dtActualForceData.Rows[0]["AthleteHorizontalValue"].ToString() + "&modelHorizontalValue=" + dtActualForceData.Rows[0]["modelHorizontalValue"].ToString();
            Image31.ImageUrl = strUrl;

            strUrl = "~/Users/SideDistanceGauge.aspx?athleteVerticalValue=" + dtActualForceData.Rows[0]["AthleteVerticalValue"].ToString() + "&ModelVerticalValue=" + dtActualForceData.Rows[0]["ModelVerticalValue"].ToString();
            Image32.ImageUrl = strUrl;

            strUrl = "~/Users/SideDeviationGauge.aspx?athleteTotalValue=" + dtActualForceData.Rows[0]["AthleteTotalValue"].ToString() + "&modelTotalvalue=" + dtActualForceData.Rows[0]["ModelTotalValue"].ToString();
            Image33.ImageUrl = strUrl;
        }
        else
        {
            Image31.Visible = false; Image32.Visible = false; Image33.Visible = false; AFInitialFrontBlockData.Visible = false; lblInitialFrontAF.Visible = true;
        }
        #endregion[Actual force]
        #region[Relative Force]

        ActualAthleteHorizontalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteHorizontalValue"].ToString());
        ActualModelHorizontalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelHorizontalValue"].ToString());
        ActualAthleteVerticalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteVerticalValue"].ToString());
        ActualModelVerticalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelVerticalValue"].ToString());
        ActualAthleteTotalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteTotalValue"].ToString());
        ActualModelTotalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelTotalValue"].ToString());

        if ((ActualModelHorizontalForce > 0) && (ActualModelVerticalForce > 0) && (ActualModelTotalForce > 0))
        {
            RelativeHorizontalForce = Convert.ToInt32((ActualAthleteHorizontalForce / ActualModelHorizontalForce) * 100);
            RelativeVerticalForce = Convert.ToInt32((ActualAthleteVerticalForce / ActualModelVerticalForce) * 100);
            RelativeTotalForce = Convert.ToInt32((ActualAthleteTotalForce / ActualModelTotalForce) * 100);

            strUrl = "~/Users/ClubheadSpeedGauge.aspx?RelativeHorizontalForce=" + RelativeHorizontalForce;
            Image34.ImageUrl = strUrl;

            strUrl = "~/Users/SmashFactorGauge.aspx?RelativeVerticalForce=" + RelativeVerticalForce;
            Image35.ImageUrl = strUrl;

            strUrl = "~/Users/BallSpeedGauge.aspx?RelativeTotalForce=" + RelativeTotalForce;
            Image36.ImageUrl = strUrl;
        }

        else
        {
            Image34.Visible = false; Image35.Visible = false; Image36.Visible = false; RFInitialFrontBlockData.Visible = false; lblInitialFrontRF.Visible = true;
        }

        #endregion[Relative Force]

        #region[Actual Power]

        dtActualPower = sae.GetActualPowerFrontBlockForceInputData();
        if (dtActualPower.Rows.Count > 0)
        {
            strUrl = "~/Users/LaunchAngleGauge.aspx?athleteHorizontalValue=" + dtActualPower.Rows[0]["AthleteHorizontalValue"].ToString() + "&modelHorizontalValue=" + dtActualPower.Rows[0]["modelHorizontalValue"].ToString();
            Image37.ImageUrl = strUrl;

            strUrl = "~/Users/BackSpinGauge.aspx?athleteVerticalValue=" + dtActualPower.Rows[0]["AthleteVerticalValue"].ToString() + "&ModelVerticalValue=" + dtActualPower.Rows[0]["ModelVerticalValue"].ToString();
            Image38.ImageUrl = strUrl;

            strUrl = "~/Users/TotalActualPower.aspx?athleteTotalValue=" + dtActualPower.Rows[0]["AthleteTotalValue"].ToString() + "&modelTotalvalue=" + dtActualPower.Rows[0]["ModelTotalValue"].ToString();
            Image69.ImageUrl = strUrl;
        }
        else
        {
            Image37.Visible = false; Image38.Visible = false; Image69.Visible = false; APInitialFrontBlockData.Visible = false; lblInitialFrontAP.Visible = true;
        }
        #endregion[Actual Power]
        #region[Relative Power]

        ActualAthleteHorizontalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteHorizontalValue"].ToString());
        ActualModelHorizontalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelHorizontalValue"].ToString());
        ActualAthleteVerticalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteVerticalValue"].ToString());
        ActualModelVerticalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelVerticalValue"].ToString());
        ActualAthleteTotalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteTotalValue"].ToString());
        ActualModelTotalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelTotalValue"].ToString());

        if ((ActualModelHorizontalPower > 0) && (ActualModelVerticalPower > 0) && (ActualModelTotalPower > 0))
        {
            RelativeHorizontalPower = Convert.ToInt32((ActualAthleteHorizontalPower / ActualModelHorizontalPower) * 100);
            RelativeVerticalPower = Convert.ToInt32((ActualAthleteVerticalPower / ActualModelVerticalPower) * 100);
            RelativeTotalPower = Convert.ToInt32((ActualAthleteTotalPower / ActualModelTotalPower) * 100);

            strUrl = "~/Users/SideAngleGauge.aspx?RelativeHorizontalPower=" + RelativeHorizontalPower;
            Image39.ImageUrl = strUrl;

            strUrl = "~/Users/SideSpinGauge.aspx?RelativeVerticalPower=" + RelativeVerticalPower;
            Image40.ImageUrl = strUrl;

            strUrl = "~/Users/TotalRelativePower.aspx?RelativeTotalPower=" + RelativeTotalPower;
            Image70.ImageUrl = strUrl;

            lesson = DataRepository.LessonProvider.GetByLessonId(lessonId);
            Label9.Text = DateTime.Parse(lesson.LessonDate.ToString()).ToShortDateString();
        }

        else
        {
            Image39.Visible = false; Image40.Visible = false; Image70.Visible = false; RPInitialFrontBlockData.Visible = false; lblInitialFrontRP.Visible = true;
        }
        #endregion[Relative Power]
    }


    private void DisplayOtherFrontBlockData(int latestLessonId, int secondLetestLessonId)
    {
        TabPanel6.HeaderText = "Other Front Block Data";
        TabPanel6.Visible = true;
        if (!IsPostBack)
        {
            DropDownList2.Items.Clear();
            loggedInAthleteId = customer.CustomerId;

            lessonList = DataRepository.LessonProvider.GetByCustomerId(loggedInAthleteId);
            lessonList.Sort("LessonDate DESC");

            lesson = DataRepository.LessonProvider.GetByCustomerId(loggedInAthleteId)[0];
            if (lessonList.Count != 0)
            {
                int count = 0;
                DropDownList2.Items.Add("Select Analysis Date and Location");
                DropDownList2.Items[count].Value = "";
                foreach (Lesson session in lessonList)
                {
                    if (session.LessonTypeId.Equals(1))
                    {
                        sae.LessonId = session.LessonId;
                        sae.CustomerId = session.CustomerId;
                        dtActualForceData = sae.GetActualForceFrontBlockForceInputData();
                        if (dtActualForceData.Rows.Count > 0)
                        {
                            if ((session.LessonId != latestLessonId) && (session.LessonId != secondLetestLessonId))
                            {
                                string location = sae.SelectLessonlocation(session.LessonId.ToString());
                                count++;
                                DropDownList2.Items.Add(session.LessonDate.ToString(("MM/dd/yyyy")) + " - " + location);
                                DropDownList2.Items[count].Value = session.LessonId.ToString();
                            }
                        }
                    }
                }
            }
        }
        MakeImagesHiddenForOtherFrontBlockData();
    }
    private void MakeImagesHiddenForOtherBackBlockData()
    {
        Image41.Visible = false; Image42.Visible = false; Image43.Visible = false; Image44.Visible = false; Image45.Visible = false;
        Image46.Visible = false; Image47.Visible = false; Image48.Visible = false; Image49.Visible = false; Image50.Visible = false;
        Image65.Visible = false; Image66.Visible = false;
        owdp.Visible = false; owsp.Visible = false; owlp.Visible = false; owsdp.Visible = false;
        lblOtherBackAF.Visible = true; lblOtherBackRF.Visible = true; lblOtherBackAP.Visible = true; lblOtherBackRP.Visible = true;
    }

    private void MakeImagesHiddenForOtherFrontBlockData()
    {
        Label11.Text = "";
        Image51.Visible = false; Image52.Visible = false; Image53.Visible = false; Image54.Visible = false; Image55.Visible = false;
        Image56.Visible = false; Image57.Visible = false; Image58.Visible = false; Image59.Visible = false; Image60.Visible = false;
        Image71.Visible = false; Image72.Visible = false;
        oidp.Visible = false; oisp.Visible = false; oilp.Visible = false; oisdp.Visible = false;
        lblOtherFrontAF.Visible = true; lblOtherFrontRF.Visible = true; lblOtherFrontAP.Visible = true; lblOtherFrontRP.Visible = true;
    }

    private void MakeImagesHiddenForCurrentBackBlockData()
    {
        Image1.Visible = false; Image7.Visible = false; Image8.Visible = false; AFCurrentBackBlockData.Visible = false;
        Image9.Visible = false; Image2.Visible = false; Image10.Visible = false; RFCurrentBackBlockData.Visible = false;
        Image3.Visible = false; Image4.Visible = false; Image61.Visible = false; APCurrentBackBlockData.Visible = false;
        Image5.Visible = false; Image6.Visible = false; Image62.Visible = false; RPCurrentBackBlockData.Visible = false;
        lblCurrentBackAF.Visible = true; lblCurrentBackRF.Visible = true; lblCurrentBackAP.Visible = true; lblCurrentBackRP.Visible = true;

    }
    private void MakeImagesHiddenForInitialBackBlockData()
    {
        Image11.Visible = false; Image12.Visible = false; Image13.Visible = false; AFInitialBackBlockData.Visible = false;
        Image14.Visible = false; Image15.Visible = false; Image16.Visible = false; RFInitialBackBlockData.Visible = false;
        Image17.Visible = false; Image18.Visible = false; Image63.Visible = false; APInitialBackBlockData.Visible = false;
        Image19.Visible = false; Image20.Visible = false; Image64.Visible = false; RPInitialBackBlockData.Visible = false;
        lblInitialBackAF.Visible = true; lblInitialBackRF.Visible = true; lblInitialBackAP.Visible = true; lblInitialBackRP.Visible = true;

    }
    private void MakeImagesHiddenForCurrentFrontBlockData()
    {
        Image21.Visible = false; Image22.Visible = false; Image23.Visible = false; AFCurrentFrontBlockData.Visible = false;
        Image24.Visible = false; Image25.Visible = false; Image26.Visible = false; RFCurrentFrontBlockData.Visible = false;
        Image27.Visible = false; Image28.Visible = false; Image67.Visible = false; APCurrentFrontBlockData.Visible = false;
        Image29.Visible = false; Image30.Visible = false; Image68.Visible = false; RPCurrentFrontBlockData.Visible = false;
        lblCurrentFrontAF.Visible = true; lblCurrrentFrontRF.Visible = true; lblCurrrentFrontAP.Visible = true; lblCurrrentFrontRP.Visible = true;
    }
    private void MakeImagesHiddenForInitialFrontBlockData()
    {
        Image31.Visible = false; Image32.Visible = false; Image33.Visible = false; AFInitialFrontBlockData.Visible = false;
        Image34.Visible = false; Image35.Visible = false; Image36.Visible = false; RFInitialFrontBlockData.Visible = false;
        Image37.Visible = false; Image38.Visible = false; Image69.Visible = false; APInitialFrontBlockData.Visible = false;
        Image39.Visible = false; Image40.Visible = false; Image70.Visible = false; RPInitialFrontBlockData.Visible = false;
        lblInitialFrontAF.Visible = true; lblInitialFrontRF.Visible = true; lblInitialFrontAP.Visible = true; lblInitialFrontRP.Visible = true;
    }
    private void MakeImagesHiddenForOtherBackBlockDataOnDropDown1Change()
    {
        lblOtherBackAF.Visible = false; lblOtherBackRF.Visible = false; lblOtherBackAP.Visible = false; lblOtherBackRP.Visible = false;
    }
    private void MakeImagesHiddenForOtherFrontBlockDataOnDropDown2Change()
    {
        lblOtherFrontAF.Visible = false; lblOtherFrontRF.Visible = false; lblOtherFrontAP.Visible = false; lblOtherFrontRP.Visible = false;
    }


    protected void DropDownList1_Changed(object sender, EventArgs e)
    {
        try
        {
            int lessonSelected = Convert.ToInt16(DropDownList1.SelectedValue);
            lesson = DataRepository.LessonProvider.GetByLessonId(lessonSelected);
            customer = DataRepository.CustomerProvider.GetByCustomerId(Convert.ToInt16(Request.QueryString.Get("customerid")));
            sae.CustomerId = customer.CustomerId;
            sae.LessonId = lessonSelected;
            dtActualForceData = sae.GetActualForceBlockForceInputData();
            //dtRelativeForces = sae.GetRelativeForcesBlockForceInputData();
            dtActualPower = sae.GetActualPowerBlockForceInputData();
            //dtRelativePower = sae.GetRelativePowerBlockForceInputData();
            // dtActualForceData = sae.GetActualForceBlockForceInputData();
            //dtRelativeForces = sae.GetRelativeForcesBlockForceInputData();       

            string strUrl;

            if (lessonSelected.Equals(0))
            {
                Label5.Text = "";
                Image41.Visible = false; Image42.Visible = false; Image43.Visible = false; Image44.Visible = false; Image45.Visible = false;
                Image46.Visible = false; Image47.Visible = false; Image48.Visible = false; Image49.Visible = false; Image50.Visible = false;
                Image65.Visible = false; Image66.Visible = false;
                owdp.Visible = false; owsp.Visible = false; owlp.Visible = false; owsdp.Visible = false;
            }
            else
            {
                Image41.Visible = true; Image42.Visible = true; Image43.Visible = true; Image44.Visible = true; Image45.Visible = true;
                Image46.Visible = true; Image47.Visible = true; Image48.Visible = true; Image49.Visible = true; Image50.Visible = true;
                Image65.Visible = true; Image66.Visible = true;
                owdp.Visible = true; owsp.Visible = true; owlp.Visible = true; owsdp.Visible = true;
                Label5.Text = DateTime.Parse(lesson.LessonDate.ToString()).ToShortDateString();

                #region[Actual force]


                if (dtActualForceData.Rows.Count > 0)
                {
                    strUrl = "~/Users/DistanceGauge.aspx?athleteHorizontalValue=" + dtActualForceData.Rows[0]["AthleteHorizontalValue"].ToString() + "&modelHorizontalValue=" + dtActualForceData.Rows[0]["modelHorizontalValue"].ToString();
                    Image41.ImageUrl = strUrl;

                    strUrl = "~/Users/SideDistanceGauge.aspx?athleteVerticalValue=" + dtActualForceData.Rows[0]["AthleteVerticalValue"].ToString() + "&ModelVerticalValue=" + dtActualForceData.Rows[0]["ModelVerticalValue"].ToString();
                    Image42.ImageUrl = strUrl;

                    strUrl = "~/Users/SideDeviationGauge.aspx?athleteTotalValue=" + dtActualForceData.Rows[0]["AthleteTotalValue"].ToString() + "&modelTotalvalue=" + dtActualForceData.Rows[0]["ModelTotalValue"].ToString();
                    Image43.ImageUrl = strUrl;
                    MakeImagesHiddenForOtherBackBlockDataOnDropDown1Change();
                }
                else
                {
                    MakeImagesHiddenForOtherBackBlockData();
                }
                #endregion[Actual force]

                #region[Relative Force]
                //if (dtRelativeForces.Rows.Count > 0)
                //{
                //    strUrl = "~/Users/ClubheadSpeedGauge.aspx?athleteHorizontalValue=" + dtRelativeForces.Rows[0]["AthleteHorizontalValue"].ToString() + "&modelHorizontalValue=" + dtRelativeForces.Rows[0]["modelHorizontalValue"].ToString();
                //    Image44.ImageUrl = strUrl;

                //    strUrl = "~/Users/SmashFactorGauge.aspx?athleteVerticalValue=" + dtRelativeForces.Rows[0]["AthleteVerticalValue"].ToString() + "&ModelVerticalValue=" + dtRelativeForces.Rows[0]["ModelVerticalValue"].ToString();
                //    Image45.ImageUrl = strUrl;

                //    strUrl = "~/Users/BallSpeedGauge.aspx?athleteTotalValue=" + dtRelativeForces.Rows[0]["AthleteTotalValue"].ToString() + "&modelTotalvalue=" + dtRelativeForces.Rows[0]["ModelTotalValue"].ToString();
                //    Image46.ImageUrl = strUrl;
                //    MakeImagesHiddenForOtherBackBlockDataOnDropDown1Change();
                //}
                ActualAthleteHorizontalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteHorizontalValue"].ToString());
                ActualModelHorizontalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelHorizontalValue"].ToString());
                ActualAthleteVerticalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteVerticalValue"].ToString());
                ActualModelVerticalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelVerticalValue"].ToString());
                ActualAthleteTotalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteTotalValue"].ToString());
                ActualModelTotalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelTotalValue"].ToString());

                if ((ActualModelHorizontalForce > 0) && (ActualModelVerticalForce > 0) && (ActualModelTotalForce > 0))
                {
                    RelativeHorizontalForce = Convert.ToInt32((ActualAthleteHorizontalForce / ActualModelHorizontalForce) * 100);
                    RelativeVerticalForce = Convert.ToInt32((ActualAthleteVerticalForce / ActualModelVerticalForce) * 100);
                    RelativeTotalForce = Convert.ToInt32((ActualAthleteTotalForce / ActualModelTotalForce) * 100);

                    strUrl = "~/Users/ClubheadSpeedGauge.aspx?RelativeHorizontalForce=" + RelativeHorizontalForce;
                    Image44.ImageUrl = strUrl;

                    strUrl = "~/Users/SmashFactorGauge.aspx?RelativeVerticalForce=" + RelativeVerticalForce;
                    Image45.ImageUrl = strUrl;

                    strUrl = "~/Users/BallSpeedGauge.aspx?RelativeTotalForce=" + RelativeTotalForce;
                    Image46.ImageUrl = strUrl;

                    MakeImagesHiddenForOtherBackBlockDataOnDropDown1Change();
                }
                else
                {
                    MakeImagesHiddenForOtherBackBlockData();
                }
                #endregion[Relative Force]

                #region[Actual Power]
                if (dtActualPower.Rows.Count > 0)
                {
                    strUrl = "~/Users/LaunchAngleGauge.aspx?athleteHorizontalValue=" + dtActualPower.Rows[0]["AthleteHorizontalValue"].ToString() + "&modelHorizontalValue=" + dtActualPower.Rows[0]["modelHorizontalValue"].ToString();
                    Image47.ImageUrl = strUrl;

                    strUrl = "~/Users/BackSpinGauge.aspx?athleteVerticalValue=" + dtActualPower.Rows[0]["AthleteVerticalValue"].ToString() + "&ModelVerticalValue=" + dtActualPower.Rows[0]["ModelVerticalValue"].ToString();
                    Image48.ImageUrl = strUrl;

                    strUrl = "~/Users/TotalActualPower.aspx?athleteTotalValue=" + dtActualPower.Rows[0]["AthleteTotalValue"].ToString() + "&modelTotalvalue=" + dtActualPower.Rows[0]["ModelTotalValue"].ToString();
                    Image65.ImageUrl = strUrl;
                    MakeImagesHiddenForOtherBackBlockDataOnDropDown1Change();
                }
                else
                {
                    MakeImagesHiddenForOtherBackBlockData();
                }
                #endregion[Actual Power]

                #region[Relative Power]
                //if (dtRelativePower.Rows.Count > 0)
                //{
                //    strUrl = "~/Users/SideAngleGauge.aspx?athleteHorizontalValue=" + dtRelativePower.Rows[0]["AthleteHorizontalValue"].ToString() + "&modelHorizontalValue=" + dtRelativePower.Rows[0]["modelHorizontalValue"].ToString();
                //    Image49.ImageUrl = strUrl;

                //    strUrl = "~/Users/SideSpinGauge.aspx?athleteVerticalValue=" + dtRelativePower.Rows[0]["AthleteVerticalValue"].ToString() + "&modelVerticalValue=" + dtRelativePower.Rows[0]["ModelVerticalValue"].ToString();
                //    Image50.ImageUrl = strUrl;

                //    strUrl = "~/Users/TotalRelativePower.aspx?athleteTotalValue=" + dtRelativePower.Rows[0]["AthleteTotalValue"].ToString() + "&modelTotalvalue=" + dtRelativePower.Rows[0]["ModelTotalValue"].ToString();
                //    Image66.ImageUrl = strUrl;
                //    MakeImagesHiddenForOtherBackBlockDataOnDropDown1Change();
                //}
                ActualAthleteHorizontalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteHorizontalValue"].ToString());
                ActualModelHorizontalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelHorizontalValue"].ToString());
                ActualAthleteVerticalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteVerticalValue"].ToString());
                ActualModelVerticalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelVerticalValue"].ToString());
                ActualAthleteTotalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteTotalValue"].ToString());
                ActualModelTotalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelTotalValue"].ToString());

                if ((ActualModelHorizontalPower > 0) && (ActualModelVerticalPower > 0) && (ActualModelTotalPower > 0))
                {
                    RelativeHorizontalPower = Convert.ToInt32((ActualAthleteHorizontalPower / ActualModelHorizontalPower) * 100);
                    RelativeVerticalPower = Convert.ToInt32((ActualAthleteVerticalPower / ActualModelVerticalPower) * 100);
                    RelativeTotalPower = Convert.ToInt32((ActualAthleteTotalPower / ActualModelTotalPower) * 100);

                    strUrl = "~/Users/SideAngleGauge.aspx?RelativeHorizontalPower=" + RelativeHorizontalPower;
                    Image49.ImageUrl = strUrl;

                    strUrl = "~/Users/SideSpinGauge.aspx?RelativeVerticalPower=" + RelativeVerticalPower;
                    Image50.ImageUrl = strUrl;

                    strUrl = "~/Users/TotalRelativePower.aspx?RelativeTotalPower=" + RelativeTotalPower;
                    Image66.ImageUrl = strUrl;
                    MakeImagesHiddenForOtherBackBlockDataOnDropDown1Change();
                }
                else
                {
                    MakeImagesHiddenForOtherBackBlockData();
                }
                #endregion[Relative Power]

                Tabs.ActiveTabIndex = 2;
            }
        }
        catch (Exception ex)
        {
            Convert.ToString(ex);
        }
    }

    protected void DropDownList2_Changed(object sender, EventArgs e)
    {
        try
        {
            int lessonSelected = Convert.ToInt16(DropDownList2.SelectedValue);
            lesson = DataRepository.LessonProvider.GetByLessonId(lessonSelected);
            customer = DataRepository.CustomerProvider.GetByCustomerId(Convert.ToInt16(Request.QueryString.Get("customerid")));
            sae.CustomerId = customer.CustomerId;
            sae.LessonId = lessonSelected;
            dtActualForceData = sae.GetActualForceFrontBlockForceInputData();
            //dtRelativeForces = sae.GetRelativeForcesFrontBlockForceInputData();
            dtActualPower = sae.GetActualPowerFrontBlockForceInputData();
            //dtRelativePower = sae.GetRelativePowerFrontBlockForceInputData();
            string strUrl;

            if (lessonSelected.Equals(0))
            {
                Label11.Text = "";
                Image51.Visible = false; Image52.Visible = false; Image53.Visible = false; Image54.Visible = false; Image55.Visible = false;
                Image56.Visible = false; Image57.Visible = false; Image58.Visible = false; Image59.Visible = false; Image60.Visible = false;
                Image71.Visible = false; Image72.Visible = false;
                oidp.Visible = false; oisp.Visible = false; oilp.Visible = false; oisdp.Visible = false;
            }
            else
            {
                Image51.Visible = true; Image52.Visible = true; Image53.Visible = true; Image54.Visible = true; Image55.Visible = true;
                Image56.Visible = true; Image57.Visible = true; Image58.Visible = true; Image59.Visible = true; Image60.Visible = true;
                Image71.Visible = true; Image72.Visible = true;
                oidp.Visible = true; oisp.Visible = true; oilp.Visible = true; oisdp.Visible = true;
                Label11.Text = DateTime.Parse(lesson.LessonDate.ToString()).ToShortDateString();

                #region[Actual force]


                if (dtActualForceData.Rows.Count > 0)
                {
                    strUrl = "~/Users/DistanceGauge.aspx?athleteHorizontalValue=" + dtActualForceData.Rows[0]["AthleteHorizontalValue"].ToString() + "&modelHorizontalValue=" + dtActualForceData.Rows[0]["modelHorizontalValue"].ToString();
                    Image51.ImageUrl = strUrl;

                    strUrl = "~/Users/SideDistanceGauge.aspx?athleteVerticalValue=" + dtActualForceData.Rows[0]["AthleteVerticalValue"].ToString() + "&ModelVerticalValue=" + dtActualForceData.Rows[0]["ModelVerticalValue"].ToString();
                    Image52.ImageUrl = strUrl;

                    strUrl = "~/Users/SideDeviationGauge.aspx?athleteTotalValue=" + dtActualForceData.Rows[0]["AthleteTotalValue"].ToString() + "&modelTotalValue=" + dtActualForceData.Rows[0]["modelTotalValue"].ToString();
                    Image53.ImageUrl = strUrl;
                    MakeImagesHiddenForOtherFrontBlockDataOnDropDown2Change();
                }
                else
                {
                    MakeImagesHiddenForOtherFrontBlockData();
                }
                #endregion[Actual force]
                #region[Relative Force]
                //if (dtRelativeForces.Rows.Count > 0)
                //{
                //    strUrl = "~/Users/ClubheadSpeedGauge.aspx?athleteHorizontalValue=" + dtRelativeForces.Rows[0]["AthleteHorizontalValue"].ToString() + "&modelHorizontalValue=" + dtRelativeForces.Rows[0]["modelHorizontalValue"].ToString();
                //    Image54.ImageUrl = strUrl;

                //    strUrl = "~/Users/SmashFactorGauge.aspx?athleteVerticalValue=" + dtRelativeForces.Rows[0]["AthleteVerticalValue"].ToString() + "&ModelVerticalValue=" + dtRelativeForces.Rows[0]["ModelVerticalValue"].ToString();
                //    Image55.ImageUrl = strUrl;

                //    strUrl = "~/Users/BallSpeedGauge.aspx?athleteTotalValue=" + dtRelativeForces.Rows[0]["AthleteTotalValue"].ToString() + "&modelTotalValue=" + dtRelativeForces.Rows[0]["modelTotalValue"].ToString();
                //    Image56.ImageUrl = strUrl;
                //    MakeImagesHiddenForOtherFrontBlockDataOnDropDown2Change();
                //}
                ActualAthleteHorizontalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteHorizontalValue"].ToString());
                ActualModelHorizontalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelHorizontalValue"].ToString());
                ActualAthleteVerticalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteVerticalValue"].ToString());
                ActualModelVerticalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelVerticalValue"].ToString());
                ActualAthleteTotalForce = Convert.ToInt32(dtActualForceData.Rows[0]["AthleteTotalValue"].ToString());
                ActualModelTotalForce = Convert.ToInt32(dtActualForceData.Rows[0]["ModelTotalValue"].ToString());

                if ((ActualModelHorizontalForce > 0) && (ActualModelVerticalForce > 0) && (ActualModelTotalForce > 0))
                {
                    RelativeHorizontalForce = Convert.ToInt32((ActualAthleteHorizontalForce / ActualModelHorizontalForce) * 100);
                    RelativeVerticalForce = Convert.ToInt32((ActualAthleteVerticalForce / ActualModelVerticalForce) * 100);
                    RelativeTotalForce = Convert.ToInt32((ActualAthleteTotalForce / ActualModelTotalForce) * 100);

                    strUrl = "~/Users/ClubheadSpeedGauge.aspx?RelativeHorizontalForce=" + RelativeHorizontalForce;
                    Image54.ImageUrl = strUrl;

                    strUrl = "~/Users/SmashFactorGauge.aspx?RelativeVerticalForce=" + RelativeVerticalForce;
                    Image55.ImageUrl = strUrl;

                    strUrl = "~/Users/BallSpeedGauge.aspx?RelativeTotalForce=" + RelativeTotalForce;
                    Image56.ImageUrl = strUrl;

                    MakeImagesHiddenForOtherFrontBlockDataOnDropDown2Change();
                }
                else
                {
                    MakeImagesHiddenForOtherFrontBlockData();
                }
                #endregion[Relative Force]
                #region[Actual Power]
                if (dtActualPower.Rows.Count > 0)
                {

                    strUrl = "~/Users/LaunchAngleGauge.aspx?athleteHorizontalValue=" + dtActualPower.Rows[0]["AthleteHorizontalValue"].ToString() + "&modelHorizontalValue=" + dtActualPower.Rows[0]["modelHorizontalValue"].ToString();
                    Image57.ImageUrl = strUrl;

                    strUrl = "~/Users/BackSpinGauge.aspx?athleteVerticalValue=" + dtActualPower.Rows[0]["AthleteVerticalValue"].ToString() + "&ModelVerticalValue=" + dtActualPower.Rows[0]["ModelVerticalValue"].ToString();
                    Image58.ImageUrl = strUrl;

                    strUrl = "~/Users/TotalActualPower.aspx?athleteTotalValue=" + dtActualPower.Rows[0]["AthleteTotalValue"].ToString() + "&modelTotalValue=" + dtActualPower.Rows[0]["modelTotalValue"].ToString();
                    Image71.ImageUrl = strUrl;
                    MakeImagesHiddenForOtherFrontBlockDataOnDropDown2Change();
                }
                else
                {
                    MakeImagesHiddenForOtherFrontBlockData();
                }
                #endregion[Actual Power]
                #region[Relative Power]
                //if (dtRelativePower.Rows.Count > 0)
                //{
                //    strUrl = "~/Users/SideAngleGauge.aspx?athleteHorizontalValue=" + dtRelativePower.Rows[0]["AthleteHorizontalValue"].ToString() + "&modelHorizontalValue=" + dtRelativePower.Rows[0]["modelHorizontalValue"].ToString();
                //    Image59.ImageUrl = strUrl;

                //    strUrl = "~/Users/SideSpinGauge.aspx?athleteVerticalValue=" + dtRelativePower.Rows[0]["AthleteVerticalValue"].ToString() + "&modelVerticalValue=" + dtRelativePower.Rows[0]["ModelVerticalValue"].ToString();
                //    Image60.ImageUrl = strUrl;

                //    strUrl = "~/Users/TotalRelativePower.aspx?athleteTotalValue=" + dtRelativePower.Rows[0]["AthleteTotalValue"].ToString() + "&modelTotalValue=" + dtRelativePower.Rows[0]["modelTotalValue"].ToString();
                //    Image72.ImageUrl = strUrl;
                //    MakeImagesHiddenForOtherFrontBlockDataOnDropDown2Change();
                //}
                ActualAthleteHorizontalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteHorizontalValue"].ToString());
                ActualModelHorizontalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelHorizontalValue"].ToString());
                ActualAthleteVerticalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteVerticalValue"].ToString());
                ActualModelVerticalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelVerticalValue"].ToString());
                ActualAthleteTotalPower = Convert.ToInt32(dtActualPower.Rows[0]["AthleteTotalValue"].ToString());
                ActualModelTotalPower = Convert.ToInt32(dtActualPower.Rows[0]["ModelTotalValue"].ToString());

                if ((ActualModelHorizontalPower > 0) && (ActualModelVerticalPower > 0) && (ActualModelTotalPower > 0))
                {
                    RelativeHorizontalPower = Convert.ToInt32((ActualAthleteHorizontalPower / ActualModelHorizontalPower) * 100);
                    RelativeVerticalPower = Convert.ToInt32((ActualAthleteVerticalPower / ActualModelVerticalPower) * 100);
                    RelativeTotalPower = Convert.ToInt32((ActualAthleteTotalPower / ActualModelTotalPower) * 100);

                    strUrl = "~/Users/SideAngleGauge.aspx?RelativeHorizontalPower=" + RelativeHorizontalPower;
                    Image59.ImageUrl = strUrl;

                    strUrl = "~/Users/SideSpinGauge.aspx?RelativeVerticalPower=" + RelativeVerticalPower;
                    Image60.ImageUrl = strUrl;

                    strUrl = "~/Users/TotalRelativePower.aspx?RelativeTotalPower=" + RelativeTotalPower;
                    Image72.ImageUrl = strUrl;

                    MakeImagesHiddenForOtherFrontBlockDataOnDropDown2Change();
                }
                else
                {
                    MakeImagesHiddenForOtherFrontBlockData();
                }
                #endregion[Relative Power]
                Tabs.ActiveTabIndex = 5;
            }
        }
        catch (Exception ex)
        {
            Convert.ToString(ex);
        }
    }
}
