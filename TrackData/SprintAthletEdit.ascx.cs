using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using compusport.Data;
using compusport.Entities;
using compusport.Data.SqlClient;
using SwingModel.Data;
using SwingModel.Entities;
using SwingModel.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
public partial class TrackData_SprintAthletEdit : System.Web.UI.UserControl
{
   // SiteUser currentUser;
    //MpUsers mpuser;
    SwingModel.Entities.Customer customer;
    SwingModel.Entities.TList<SwingModel.Entities.Customer> customers = new SwingModel.Entities.TList<SwingModel.Entities.Customer>();
    SwingModel.Entities.TList<SwingModel.Entities.Customer> customerlist = new SwingModel.Entities.TList<SwingModel.Entities.Customer>();
    //TList<MpUserRoles> athletelist = new TList<MpUserRoles>();

    compusport.Entities.TList<compusport.Entities.CoachAthleteLookup> coachathletelist = new compusport.Entities.TList<compusport.Entities.CoachAthleteLookup>();
    MpUsers athlete;
    compusport.Entities.TList<compusport.Entities.Lesson> lessonlist = new compusport.Entities.TList<compusport.Entities.Lesson>();
    compusport.Entities.Lesson lesson;
    int x;
    public string wmvFileName = "";
    public string wmpfile = "";
    bool InitialExists = false;
    bool CurrentExists = false;

    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            int x = 0;
            customers =SwingModel.Data.DataRepository.CustomerProvider.GetAll();
            foreach (var item in customers)
            {

                x++;
                DropDownList1.Items.Add(item.FirstName + " " + item.LastName);
                DropDownList1.Items[x].Value = item.CustomerId.ToString();
                continue;
            }
            lessonlist = compusport.Data.DataRepository.LessonProvider.GetAll();
        }

    }
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    bool AthleteAlreadyInList = false;

    //    //currentUser = SiteUtils.GetCurrentSiteUser();
    //    //mpuser = DataRepository.MpUsersProvider.GetByUserId(2);
    //    customer = SwingModel.Data.DataRepository.CustomerProvider.GetByCustomerId(customer.CustomerId);
    //    if (!IsPostBack)
    //    {
    //        x = 0;
    //        VideoDiv.Visible = false;
    //        //DropDownList3.Visible = false;
    //       foreach (MpUserRoles a in customerlist)
    //            {
    //                athlete = DataRepository.MpUsersProvider.GetByUserId(a.UserId);
    //                lessonlist = DataRepository.LessonProvider.GetByUserId(athlete.UserId);
    //                foreach (Lesson l in lessonlist)
    //                {
    //                    if (l.LessonType.Equals(2) && l.LessonDate >= DateTime.Parse("6/23/2010") && l.LessonDate <= DateTime.Parse("6/28/2010"))
    //                    {
    //                        if (DropDownList1.Items.Count > 0)
    //                        {
    //                            if (DropDownList1.Items.Contains(DropDownList1.Items.FindByValue(athlete.UserId.ToString())))
    //                                AthleteAlreadyInList = true;
    //                            else
    //                                AthleteAlreadyInList = false;
    //                        }

    //                        if (!AthleteAlreadyInList)
    //                        {
    //                            x++;
    //                            DropDownList1.Items.Add(athlete.Name);
    //                            DropDownList1.Items[x].Value = athlete.UserId.ToString();
    //                            continue;
    //                        }
    //                    }
    //                }
    //            }
           
    //        //LoadAllLocation();
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

    //private void ClearData()
    //{
    //    #region Clear-Texboxes
    //    txtGroundTimeLeft.Text = "";
    //    txtGroundTimeRight.Text = "";
    //    //txtGroundTimeAverage.Text = "";
    //    txtAirTimeLeftToRight.Text = "";
    //    txtAirTimeRightToLeft.Text = "";
    //    //txtAirTimeAverage.Text = "";
    //    txtFullFlexionTimeLeft.Text = "";
    //    txtFullFlexionTimeRight.Text = "";
    //    //txtFullFlexionAverage.Text = "";        
    //    //txtStriderate.Text = "";
    //    txtStrideLengthLeftToRight.Text = "";
    //    txtStrideLengthRightToLeft.Text = "";
    //    //txtStrideLengthAverage.Text = "";
    //    //txtVelocity.Text = "";
    //    txtCogDistanceLeft.Text = "";
    //    txtCogDistanceRight.Text = "";
    //    // txtCogDistanceAverage.Text = "";
    //    txtUlFullExtensionAngleLeft.Text = "";
    //    txtUlFullExtensionAngleRight.Text = "";
    //    // txtUlFullExtensionAngleAverage.Text = "";

    //    txtLlAngleTakeoffLeft.Text = "";
    //    txtLlaAngleTakeoffRight.Text = "";
    //    //txtLlaAngleTakeoffAverage.Text = "";

    //    txtLlFullFlexionAngleLeft.Text = "";
    //    txtLlFullFlexionAngleRight.Text = "";
    //    //txtLlFullFlexionAngleAverage.Text = "";

    //    txtLlAngleAcLeft.Text = "";
    //    txtLlAngleAcRight.Text = "";
    //    // txtLlAngleAcAverage.Text = "";

    //    txtUlFullFlexionAngleLeft.Text = "";
    //    txtUlFullFlexionAngleRight.Text = "";
    //    // txtUlFullFlexionAngleAverage.Text = "";



    //    txtGroundTimeLeft1.Text = "";
    //    txtGroundTimeRight1.Text = "";
    //    //txtGroundTimeAverage1.Text = "";
    //    txtAirTimeLeftToRight1.Text = "";
    //    txtAirTimeRightToLeft1.Text = "";
    //    //txtAirTimeAverage1.Text = "";
    //    txtFullFlexionTimeLeft1.Text = "";
    //    txtFullFlexionTimeRight1.Text = "";
    //    // txtFullFlexionAverage1.Text = "";
    //    // txtStriderate1.Text = "";
    //    txtStrideLengthLeftToRight1.Text = "";
    //    txtStrideLengthRightToLeft1.Text = "";
    //    //txtStrideLengthAverage1.Text = "";
    //    // txtVelocity1.Text = "";
    //    txtCogDistanceLeft1.Text = "";
    //    txtCogDistanceRight1.Text = "";
    //    //txtCogDistanceAverage1.Text = "";
    //    txtUlFullExtensionAngleLeft1.Text = "";
    //    txtUlFullExtensionAngleRight1.Text = "";
    //    //txtUlFullExtensionAngleAverage1.Text = "";

    //    txtLlAngleTakeoffLeft1.Text = "";
    //    txtLlaAngleTakeoffRight1.Text = "";
    //    // txtLlaAngleTakeoffAverage1.Text = "";

    //    txtLlFullFlexionAngleLeft1.Text = "";
    //    txtLlFullFlexionAngleRight1.Text = "";
    //    //txtLlFullFlexionAngleAverage1.Text = "";

    //    txtLlAngleAcLeft1.Text = "";
    //    txtLlAngleAcRight1.Text = "";
    //    //txtLlAngleAcAverage1.Text = "";

    //    txtUlFullFlexionAngleLeft1.Text = "";
    //    txtUlFullFlexionAngleRight1.Text = "";
    //    //txtUlFullFlexionAngleAverage1.Text = "";


    //    txtGroundTimeLeft2.Text = "";
    //    txtGroundTimeRight2.Text = "";

    //    txtAirTimeLeftToRight2.Text = "";
    //    txtAirTimeRightToLeft2.Text = "";

    //    txtFullFlexionTimeLeft2.Text = "";
    //    txtFullFlexionTimeRight2.Text = "";

    //    txtStrideLengthLeftToRight2.Text = "";
    //    txtStrideLengthRightToLeft2.Text = "";

    //    txtCogDistanceLeft2.Text = "";
    //    txtCogDistanceRight2.Text = "";

    //    txtUlFullExtensionAngleLeft2.Text = "";
    //    txtUlFullExtensionAngleRight2.Text = "";

    //    txtLlAngleTakeoffLeft2.Text = "";
    //    txtLlaAngleTakeoffRight2.Text = "";

    //    txtLlFullFlexionAngleLeft2.Text = "";
    //    txtLlFullFlexionAngleRight2.Text = "";

    //    txtLlAngleAcLeft2.Text = "";
    //    txtLlAngleAcRight2.Text = "";

    //    txtUlFullFlexionAngleLeft2.Text = "";
    //    txtUlFullFlexionAngleRight2.Text = "";


    //    //TextBox1.Text = "";
    //    wmpfile = "";
    //    //Label117.Text = "";
    //    #endregion
    //}

    //private void LoadExistingLocation()
    //{
    //    int AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
    //    lessonlist = DataRepository.LessonProvider.GetByUserId(AthleteSelected);
    //    lessonlist.Sort("LessonDate DESC");
    //    x = 0;
    //    DropDownList2.Items.Add("Select Analysis Date and Location");
    //    DropDownList2.Items[0].Value = "nodate";
    //    foreach (Lesson lesson in lessonlist)
    //    {
    //        if (lesson.LessonType.Equals(2))
    //        {
    //            x++;
    //            DropDownList2.Items.Add(lesson.LessonDate.ToString("MM/dd/yyyy HH:mm:ss") + " - " + lesson.LessonLocation);
    //            DropDownList2.Items[x].Value = lesson.LessonId.ToString();
    //        }
    //    }
    //}

    //private void LoadAllLocation()
    //{
    //    DropDownList3.Items.Clear();

    //    lessonlist = DataRepository.LessonProvider.GetByLessonType(2);
    //    lessonlist.Sort("LessonDate DESC");
    //    x = 0;
    //    DropDownList3.Items.Add("Select Lessson Date and Location");
    //    DropDownList3.Items[0].Value = "nodate";
    //    foreach (Lesson lesson in lessonlist)
    //    {
    //        x++;
    //        DropDownList3.Items.Add(lesson.LessonDate.ToString("MM/dd/yyyy HH:mm:ss") + " - " + lesson.LessonLocation);
    //        DropDownList3.Items[x].Value = lesson.LessonId.ToString();
    //    }
    //}

    //private void LoadSprintInitialData(int LessonSelected)
    //{
    //    SprintInitialData sprintinitialdata = DataRepository.SprintInitialDataProvider.GetByLessonId(LessonSelected)[0];

    //    int AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
    //    Lesson lesson = DataRepository.LessonProvider.GetByLessonId(LessonSelected);

    //    if (AthleteSelected == lesson.UserId)
    //    {
    //        if (!sprintinitialdata.GroundTimeLeft.Equals(null))
    //            txtGroundTimeLeft.Text = sprintinitialdata.GroundTimeLeft.Value.ToString("0.000");
    //        if (!sprintinitialdata.GroundTimeRight.Equals(null))
    //            txtGroundTimeRight.Text = sprintinitialdata.GroundTimeRight.Value.ToString("0.000");
    //        if (!sprintinitialdata.AirTimeLeftToRight.Equals(null))
    //            txtAirTimeLeftToRight.Text = sprintinitialdata.AirTimeLeftToRight.Value.ToString("0.000");
    //        if (!sprintinitialdata.AirTimeRightToLeft.Equals(null))
    //            txtAirTimeRightToLeft.Text = sprintinitialdata.AirTimeRightToLeft.Value.ToString("0.000");
    //        if (!sprintinitialdata.FullFlexionTimeLeft.Equals(null))
    //            txtFullFlexionTimeLeft.Text = sprintinitialdata.FullFlexionTimeLeft.Value.ToString("0.000");
    //        if (!sprintinitialdata.FullFlexionTimeRight.Equals(null))
    //            txtFullFlexionTimeRight.Text = sprintinitialdata.FullFlexionTimeRight.Value.ToString("0.000");
    //        if (!sprintinitialdata.StrideLengthLeftToRight.Equals(null))
    //            txtStrideLengthLeftToRight.Text = sprintinitialdata.StrideLengthLeftToRight.Value.ToString("0.00");
    //        if (!sprintinitialdata.StrideLengthRightToLeft.Equals(null))
    //            txtStrideLengthRightToLeft.Text = sprintinitialdata.StrideLengthRightToLeft.Value.ToString("0.00");
    //        if (!sprintinitialdata.CogDistanceLeft.Equals(null))
    //            txtCogDistanceLeft.Text = sprintinitialdata.CogDistanceLeft.Value.ToString("0.00");
    //        if (!sprintinitialdata.CogDistanceRight.Equals(null))
    //            txtCogDistanceRight.Text = sprintinitialdata.CogDistanceRight.Value.ToString("0.00");
    //        if (!sprintinitialdata.UlFullExtensionAngleLeft.Equals(null))
    //            txtUlFullExtensionAngleLeft.Text = sprintinitialdata.UlFullExtensionAngleLeft.Value.ToString("#");
    //        if (!sprintinitialdata.UlFullExtensionAngleRight.Equals(null))
    //            txtUlFullExtensionAngleRight.Text = sprintinitialdata.UlFullExtensionAngleRight.Value.ToString("#");
    //        if (!sprintinitialdata.LlAngleTakeoffLeft.Equals(null))
    //            txtLlAngleTakeoffLeft.Text = sprintinitialdata.LlAngleTakeoffLeft.Value.ToString("#");
    //        if (!sprintinitialdata.LlaAngleTakeoffRight.Equals(null))
    //            txtLlaAngleTakeoffRight.Text = sprintinitialdata.LlaAngleTakeoffRight.Value.ToString("#");
    //        if (!sprintinitialdata.LlFullFlexionAngleLeft.Equals(null))
    //            txtLlFullFlexionAngleLeft.Text = sprintinitialdata.LlFullFlexionAngleLeft.Value.ToString("#");
    //        if (!sprintinitialdata.LlFullFlexionAngleRight.Equals(null))
    //            txtLlFullFlexionAngleRight.Text = sprintinitialdata.LlFullFlexionAngleRight.Value.ToString("#");
    //        if (!sprintinitialdata.LlAngleAcLeft.Equals(null))
    //            txtLlAngleAcLeft.Text = sprintinitialdata.LlAngleAcLeft.Value.ToString("#");
    //        if (!sprintinitialdata.LlAngleAcRight.Equals(null))
    //            txtLlAngleAcRight.Text = sprintinitialdata.LlAngleAcRight.Value.ToString("#");
    //        if (!sprintinitialdata.UlFullFlexionAngleLeft.Equals(null))
    //            txtUlFullFlexionAngleLeft.Text = sprintinitialdata.UlFullFlexionAngleLeft.Value.ToString("#");
    //        if (!sprintinitialdata.UlFullFlexionAngleRight.Equals(null))
    //            txtUlFullFlexionAngleRight.Text = sprintinitialdata.UlFullFlexionAngleRight.Value.ToString("#");
    //    }
    //}

    //private void LoadSprintCurrentData(int LessonSelected)
    //{
    //    SprintCurrentData sprintcurrentdata = DataRepository.SprintCurrentDataProvider.GetByLessonId(LessonSelected)[0];

    //    int AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
    //    Lesson lesson = DataRepository.LessonProvider.GetByLessonId(LessonSelected);

    //    if (AthleteSelected == lesson.UserId)
    //    {
    //        if (!sprintcurrentdata.GroundTimeLeft.Equals(null))
    //            txtGroundTimeLeft1.Text = sprintcurrentdata.GroundTimeLeft.Value.ToString("0.000");
    //        if (!sprintcurrentdata.GroundTimeRight.Equals(null))
    //            txtGroundTimeRight1.Text = sprintcurrentdata.GroundTimeRight.Value.ToString("0.000");
    //        if (!sprintcurrentdata.AirTimeLeftToRight.Equals(null))
    //            txtAirTimeLeftToRight1.Text = sprintcurrentdata.AirTimeLeftToRight.Value.ToString("0.000");
    //        if (!sprintcurrentdata.AirTimeRightToLeft.Equals(null))
    //            txtAirTimeRightToLeft1.Text = sprintcurrentdata.AirTimeRightToLeft.Value.ToString("0.000");
    //        if (!sprintcurrentdata.FullFlexionTimeLeft.Equals(null))
    //            txtFullFlexionTimeLeft1.Text = sprintcurrentdata.FullFlexionTimeLeft.Value.ToString("0.000");
    //        if (!sprintcurrentdata.FullFlexionTimeRight.Equals(null))
    //            txtFullFlexionTimeRight1.Text = sprintcurrentdata.FullFlexionTimeRight.Value.ToString("0.000");
    //        if (!sprintcurrentdata.StrideLengthLeftToRight.Equals(null))
    //            txtStrideLengthLeftToRight1.Text = sprintcurrentdata.StrideLengthLeftToRight.Value.ToString("0.00");
    //        if (!sprintcurrentdata.StrideLengthRightToLeft.Equals(null))
    //            txtStrideLengthRightToLeft1.Text = sprintcurrentdata.StrideLengthRightToLeft.Value.ToString("0.00");
    //        if (!sprintcurrentdata.CogDistanceLeft.Equals(null))
    //            txtCogDistanceLeft1.Text = sprintcurrentdata.CogDistanceLeft.Value.ToString("0.00");
    //        if (!sprintcurrentdata.CogDistanceRight.Equals(null))
    //            txtCogDistanceRight1.Text = sprintcurrentdata.CogDistanceRight.Value.ToString("0.00");
    //        if (!sprintcurrentdata.UlFullExtensionAngleLeft.Equals(null))
    //            txtUlFullExtensionAngleLeft1.Text = sprintcurrentdata.UlFullExtensionAngleLeft.Value.ToString("#");
    //        if (!sprintcurrentdata.UlFullExtensionAngleRight.Equals(null))
    //            txtUlFullExtensionAngleRight1.Text = sprintcurrentdata.UlFullExtensionAngleRight.Value.ToString("#");
    //        if (!sprintcurrentdata.LlAngleTakeoffLeft.Equals(null))
    //            txtLlAngleTakeoffLeft1.Text = sprintcurrentdata.LlAngleTakeoffLeft.Value.ToString("#");
    //        if (!sprintcurrentdata.LlaAngleTakeoffRight.Equals(null))
    //            txtLlaAngleTakeoffRight1.Text = sprintcurrentdata.LlaAngleTakeoffRight.Value.ToString("#");
    //        if (!sprintcurrentdata.LlFullFlexionAngleLeft.Equals(null))
    //            txtLlFullFlexionAngleLeft1.Text = sprintcurrentdata.LlFullFlexionAngleLeft.Value.ToString("#");
    //        if (!sprintcurrentdata.LlFullFlexionAngleRight.Equals(null))
    //            txtLlFullFlexionAngleRight1.Text = sprintcurrentdata.LlFullFlexionAngleRight.Value.ToString("#");
    //        if (!sprintcurrentdata.LlAngleAcLeft.Equals(null))
    //            txtLlAngleAcLeft1.Text = sprintcurrentdata.LlAngleAcLeft.Value.ToString("#");
    //        if (!sprintcurrentdata.LlAngleAcRight.Equals(null))
    //            txtLlAngleAcRight1.Text = sprintcurrentdata.LlAngleAcRight.Value.ToString("#");
    //        if (!sprintcurrentdata.UlFullFlexionAngleLeft.Equals(null))
    //            txtUlFullFlexionAngleLeft1.Text = sprintcurrentdata.UlFullFlexionAngleLeft.Value.ToString("#");
    //        if (!sprintcurrentdata.UlFullFlexionAngleRight.Equals(null))
    //            txtUlFullFlexionAngleRight1.Text = sprintcurrentdata.UlFullFlexionAngleRight.Value.ToString("#");
    //    }
    //}

    //private void LoadSprintModelData(int LessonSelected)
    //{
    //    SprintModelData sprintmodeldata = DataRepository.SprintModelDataProvider.GetByLessonId(LessonSelected)[0];

    //    int AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
    //    Lesson lesson = DataRepository.LessonProvider.GetByLessonId(LessonSelected);

    //    if (AthleteSelected == lesson.UserId)
    //    {
    //        txtGroundTimeLeft2.Text = sprintmodeldata.GroundTime.Value.ToString("0.000");
    //        txtGroundTimeRight2.Text = sprintmodeldata.GroundTime.Value.ToString("0.000");

    //        txtAirTimeLeftToRight2.Text = sprintmodeldata.AirTime.Value.ToString("0.000");
    //        txtAirTimeRightToLeft2.Text = sprintmodeldata.AirTime.Value.ToString("0.000");

    //        txtFullFlexionTimeLeft2.Text = sprintmodeldata.FullFlexionTime.Value.ToString("0.000");
    //        txtFullFlexionTimeRight2.Text = sprintmodeldata.FullFlexionTime.Value.ToString("0.000");

    //        txtStrideLengthLeftToRight2.Text = sprintmodeldata.StrideLength.Value.ToString("0.00");
    //        txtStrideLengthRightToLeft2.Text = sprintmodeldata.StrideLength.Value.ToString("0.00");

    //        txtCogDistanceLeft2.Text = sprintmodeldata.CogDistance.Value.ToString("0.00");
    //        txtCogDistanceRight2.Text = sprintmodeldata.CogDistance.Value.ToString("0.00");

    //        txtUlFullExtensionAngleLeft2.Text = sprintmodeldata.UlFullExtensionAngle.Value.ToString("#");
    //        txtUlFullExtensionAngleRight2.Text = sprintmodeldata.UlFullExtensionAngle.Value.ToString("#");

    //        txtLlAngleTakeoffLeft2.Text = sprintmodeldata.LlAngleTakeoff.Value.ToString("#");
    //        txtLlaAngleTakeoffRight2.Text = sprintmodeldata.LlAngleTakeoff.Value.ToString("#");

    //        txtLlFullFlexionAngleLeft2.Text = sprintmodeldata.LlFullFlexionAngle.Value.ToString("#");
    //        txtLlFullFlexionAngleRight2.Text = sprintmodeldata.LlFullFlexionAngle.Value.ToString("#");

    //        txtLlAngleAcLeft2.Text = sprintmodeldata.LlAngleAc.Value.ToString("#");
    //        txtLlAngleAcRight2.Text = sprintmodeldata.LlAngleAc.Value.ToString("#");

    //        txtUlFullFlexionAngleLeft2.Text = sprintmodeldata.UlFullFlexionAngle.Value.ToString("#");
    //        txtUlFullFlexionAngleRight2.Text = sprintmodeldata.UlFullFlexionAngle.Value.ToString("#");
    //    }
    //}

    //private void InsertupdateSprintinitialData(int LessonSelected)
    //{
    //    SprintInitialData sprintinitialdata = new SprintInitialData();
    //    if (LessonSelected > 0)
    //    {
    //        sprintinitialdata = DataRepository.SprintInitialDataProvider.GetByLessonId(LessonSelected)[0];
    //        lesson = DataRepository.LessonProvider.GetByLessonId(LessonSelected);
    //    }

    //    try
    //    {

    //        sprintinitialdata.LessonId = lesson.LessonId;

    //        if (!string.IsNullOrEmpty(txtGroundTimeLeft.Text))
    //        {
    //            sprintinitialdata.GroundTimeLeft = Convert.ToDecimal(txtGroundTimeLeft.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.GroundTimeLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtGroundTimeRight.Text))
    //        {
    //            sprintinitialdata.GroundTimeRight = Convert.ToDecimal(txtGroundTimeRight.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.GroundTimeRight = null;
    //        }

    //        if (!string.IsNullOrEmpty(txtAirTimeLeftToRight.Text))
    //        {
    //            sprintinitialdata.AirTimeLeftToRight = Convert.ToDecimal(txtAirTimeLeftToRight.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.AirTimeLeftToRight = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtAirTimeRightToLeft.Text))
    //        {
    //            sprintinitialdata.AirTimeRightToLeft = Convert.ToDecimal(txtAirTimeRightToLeft.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.AirTimeRightToLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtFullFlexionTimeLeft.Text))
    //        {
    //            sprintinitialdata.FullFlexionTimeLeft = Convert.ToDecimal(txtFullFlexionTimeLeft.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.FullFlexionTimeLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtFullFlexionTimeRight.Text))
    //        {
    //            sprintinitialdata.FullFlexionTimeRight = Convert.ToDecimal(txtFullFlexionTimeRight.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.FullFlexionTimeRight = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtStrideLengthLeftToRight.Text))
    //        {
    //            sprintinitialdata.StrideLengthLeftToRight = Convert.ToDecimal(txtStrideLengthLeftToRight.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.StrideLengthLeftToRight = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtStrideLengthRightToLeft.Text))
    //        {
    //            sprintinitialdata.StrideLengthRightToLeft = Convert.ToDecimal(txtStrideLengthRightToLeft.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.StrideLengthRightToLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtCogDistanceLeft.Text))
    //        {
    //            sprintinitialdata.CogDistanceLeft = Convert.ToDecimal(txtCogDistanceLeft.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.CogDistanceLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtCogDistanceRight.Text))
    //        {
    //            sprintinitialdata.CogDistanceRight = Convert.ToDecimal(txtCogDistanceRight.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.CogDistanceRight = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtUlFullExtensionAngleLeft.Text))
    //        {
    //            sprintinitialdata.UlFullExtensionAngleLeft = Convert.ToInt32(txtUlFullExtensionAngleLeft.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.UlFullExtensionAngleLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtUlFullExtensionAngleRight.Text))
    //        {
    //            sprintinitialdata.UlFullExtensionAngleRight = Convert.ToInt32(txtUlFullExtensionAngleRight.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.UlFullExtensionAngleRight = null;
    //        }

    //        if (!string.IsNullOrEmpty(txtLlAngleTakeoffLeft.Text))
    //        {
    //            sprintinitialdata.LlAngleTakeoffLeft = Convert.ToInt32(txtLlAngleTakeoffLeft.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.LlAngleTakeoffLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtLlaAngleTakeoffRight.Text))
    //        {
    //            sprintinitialdata.LlaAngleTakeoffRight = Convert.ToInt32(txtLlaAngleTakeoffRight.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.LlaAngleTakeoffRight = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtLlFullFlexionAngleLeft.Text))
    //        {
    //            sprintinitialdata.LlFullFlexionAngleLeft = Convert.ToInt32(txtLlFullFlexionAngleLeft.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.LlFullFlexionAngleLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtLlFullFlexionAngleRight.Text))
    //        {
    //            sprintinitialdata.LlFullFlexionAngleRight = Convert.ToInt32(txtLlFullFlexionAngleRight.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.LlFullFlexionAngleRight = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtLlAngleAcLeft.Text))
    //        {
    //            sprintinitialdata.LlAngleAcLeft = Convert.ToInt32(txtLlAngleAcLeft.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.LlAngleAcLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtLlAngleAcRight.Text))
    //        {
    //            sprintinitialdata.LlAngleAcRight = Convert.ToInt32(txtLlAngleAcRight.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.LlAngleAcRight = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtUlFullFlexionAngleLeft.Text))
    //        {
    //            sprintinitialdata.UlFullFlexionAngleLeft = Convert.ToInt32(txtUlFullFlexionAngleLeft.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.UlFullFlexionAngleLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtUlFullFlexionAngleRight.Text))
    //        {
    //            sprintinitialdata.UlFullFlexionAngleRight = Convert.ToInt32(txtUlFullFlexionAngleRight.Text);
    //        }
    //        else
    //        {
    //            sprintinitialdata.UlFullFlexionAngleRight = null;
    //        }
    //    }
    //    catch { }
    //    if (sprintinitialdata.SprintInitialDataId <= 0)
    //    {
    //        DataRepository.SprintInitialDataProvider.Insert(sprintinitialdata);
    //    }
    //    else
    //    {
    //        DataRepository.SprintInitialDataProvider.Update(sprintinitialdata);
    //    }

    //}

    //private void InsertupdateSprintCurrentData(int LessonSelected)
    //{
    //    SprintCurrentData sprintcurrentdata = new SprintCurrentData();
    //    if (LessonSelected > 0)
    //    {
    //        sprintcurrentdata = DataRepository.SprintCurrentDataProvider.GetByLessonId(LessonSelected)[0];
    //        lesson = DataRepository.LessonProvider.GetByLessonId(LessonSelected);
    //    }

    //    try
    //    {

    //        sprintcurrentdata.LessonId = lesson.LessonId;

    //        if (!string.IsNullOrEmpty(txtGroundTimeLeft1.Text))
    //        {
    //            sprintcurrentdata.GroundTimeLeft = Convert.ToDecimal(txtGroundTimeLeft1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.GroundTimeLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtGroundTimeRight1.Text))
    //        {
    //            sprintcurrentdata.GroundTimeRight = Convert.ToDecimal(txtGroundTimeRight1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.GroundTimeRight = null;
    //        }

    //        if (!string.IsNullOrEmpty(txtAirTimeLeftToRight1.Text))
    //        {
    //            sprintcurrentdata.AirTimeLeftToRight = Convert.ToDecimal(txtAirTimeLeftToRight1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.AirTimeLeftToRight = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtAirTimeRightToLeft1.Text))
    //        {
    //            sprintcurrentdata.AirTimeRightToLeft = Convert.ToDecimal(txtAirTimeRightToLeft1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.AirTimeRightToLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtFullFlexionTimeLeft1.Text))
    //        {
    //            sprintcurrentdata.FullFlexionTimeLeft = Convert.ToDecimal(txtFullFlexionTimeLeft1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.FullFlexionTimeLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtFullFlexionTimeRight1.Text))
    //        {
    //            sprintcurrentdata.FullFlexionTimeRight = Convert.ToDecimal(txtFullFlexionTimeRight1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.FullFlexionTimeRight = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtStrideLengthLeftToRight1.Text))
    //        {
    //            sprintcurrentdata.StrideLengthLeftToRight = Convert.ToDecimal(txtStrideLengthLeftToRight1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.StrideLengthLeftToRight = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtStrideLengthRightToLeft1.Text))
    //        {
    //            sprintcurrentdata.StrideLengthRightToLeft = Convert.ToDecimal(txtStrideLengthRightToLeft1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.StrideLengthRightToLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtCogDistanceLeft1.Text))
    //        {
    //            sprintcurrentdata.CogDistanceLeft = Convert.ToDecimal(txtCogDistanceLeft1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.CogDistanceLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtCogDistanceRight1.Text))
    //        {
    //            sprintcurrentdata.CogDistanceRight = Convert.ToDecimal(txtCogDistanceRight1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.CogDistanceRight = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtUlFullExtensionAngleLeft1.Text))
    //        {
    //            sprintcurrentdata.UlFullExtensionAngleLeft = Convert.ToInt32(txtUlFullExtensionAngleLeft1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.UlFullExtensionAngleLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtUlFullExtensionAngleRight1.Text))
    //        {
    //            sprintcurrentdata.UlFullExtensionAngleRight = Convert.ToInt32(txtUlFullExtensionAngleRight1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.UlFullExtensionAngleRight = null;
    //        }

    //        if (!string.IsNullOrEmpty(txtLlAngleTakeoffLeft1.Text))
    //        {
    //            sprintcurrentdata.LlAngleTakeoffLeft = Convert.ToInt32(txtLlAngleTakeoffLeft1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.LlAngleTakeoffLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtLlaAngleTakeoffRight1.Text))
    //        {
    //            sprintcurrentdata.LlaAngleTakeoffRight = Convert.ToInt32(txtLlaAngleTakeoffRight1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.LlaAngleTakeoffRight = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtLlFullFlexionAngleLeft1.Text))
    //        {
    //            sprintcurrentdata.LlFullFlexionAngleLeft = Convert.ToInt32(txtLlFullFlexionAngleLeft1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.LlFullFlexionAngleLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtLlFullFlexionAngleRight1.Text))
    //        {
    //            sprintcurrentdata.LlFullFlexionAngleRight = Convert.ToInt32(txtLlFullFlexionAngleRight1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.LlFullFlexionAngleRight = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtLlAngleAcLeft1.Text))
    //        {
    //            sprintcurrentdata.LlAngleAcLeft = Convert.ToInt32(txtLlAngleAcLeft1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.LlAngleAcLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtLlAngleAcRight1.Text))
    //        {
    //            sprintcurrentdata.LlAngleAcRight = Convert.ToInt32(txtLlAngleAcRight1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.LlAngleAcRight = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtUlFullFlexionAngleLeft1.Text))
    //        {
    //            sprintcurrentdata.UlFullFlexionAngleLeft = Convert.ToInt32(txtUlFullFlexionAngleLeft1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.UlFullFlexionAngleLeft = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtUlFullFlexionAngleRight1.Text))
    //        {
    //            sprintcurrentdata.UlFullFlexionAngleRight = Convert.ToInt32(txtUlFullFlexionAngleRight1.Text);
    //        }
    //        else
    //        {
    //            sprintcurrentdata.UlFullFlexionAngleRight = null;
    //        }
    //    }
    //    catch { }
    //    if (sprintcurrentdata.SprintCurrentDataId <= 0)
    //    {
    //        DataRepository.SprintCurrentDataProvider.Insert(sprintcurrentdata);
    //    }
    //    else
    //    {
    //        DataRepository.SprintCurrentDataProvider.Update(sprintcurrentdata);
    //    }

    //}

    //private void InsertupdateSprintModelData(int LessonSelected)
    //{
    //    SprintModelData sprintmodeldata = new SprintModelData();
    //    if (LessonSelected > 0)
    //    {
    //        sprintmodeldata = DataRepository.SprintModelDataProvider.GetByLessonId(LessonSelected)[0];
    //        lesson = DataRepository.LessonProvider.GetByLessonId(LessonSelected);
    //    }

    //    try
    //    {

    //        sprintmodeldata.LessonId = lesson.LessonId;

    //        if (!string.IsNullOrEmpty(txtGroundTimeLeft2.Text))
    //        {
    //            sprintmodeldata.GroundTime = Convert.ToDecimal(txtGroundTimeLeft2.Text);
    //        }
    //        else
    //        {
    //            sprintmodeldata.GroundTime = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtAirTimeLeftToRight2.Text))
    //        {
    //            sprintmodeldata.AirTime = Convert.ToDecimal(txtAirTimeLeftToRight2.Text);

    //        }
    //        else
    //        {
    //            sprintmodeldata.AirTime = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtFullFlexionTimeLeft2.Text))
    //        {
    //            sprintmodeldata.FullFlexionTime = Convert.ToDecimal(txtFullFlexionTimeLeft2.Text);
    //        }
    //        else
    //        {
    //            sprintmodeldata.FullFlexionTime = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtStrideLengthLeftToRight2.Text))
    //        {
    //            sprintmodeldata.StrideLength = Convert.ToDecimal(txtStrideLengthLeftToRight2.Text);

    //        }
    //        else
    //        {
    //            sprintmodeldata.StrideLength = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtCogDistanceLeft2.Text))
    //        {
    //            sprintmodeldata.CogDistance = Convert.ToDecimal(txtCogDistanceLeft2.Text);

    //        }
    //        else
    //        {
    //            sprintmodeldata.CogDistance = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtUlFullExtensionAngleLeft2.Text))
    //        {
    //            sprintmodeldata.UlFullExtensionAngle = Convert.ToInt32(txtUlFullExtensionAngleLeft2.Text);

    //        }
    //        else
    //        {
    //            sprintmodeldata.UlFullExtensionAngle = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtLlAngleTakeoffLeft2.Text))
    //        {
    //            sprintmodeldata.LlAngleTakeoff = Convert.ToInt32(txtLlAngleTakeoffLeft2.Text);

    //        }
    //        else
    //        {
    //            sprintmodeldata.LlAngleTakeoff = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtLlFullFlexionAngleLeft2.Text))
    //        {
    //            sprintmodeldata.LlFullFlexionAngle = Convert.ToInt32(txtLlFullFlexionAngleLeft2.Text);

    //        }
    //        else
    //        {
    //            sprintmodeldata.LlFullFlexionAngle = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtLlAngleAcLeft2.Text))
    //        {
    //            sprintmodeldata.LlAngleAc = Convert.ToInt32(txtLlAngleAcLeft2.Text);

    //        }
    //        else
    //        {
    //            sprintmodeldata.LlAngleAc = null;
    //        }
    //        if (!string.IsNullOrEmpty(txtUlFullFlexionAngleLeft2.Text))
    //        {
    //            sprintmodeldata.UlFullFlexionAngle = Convert.ToInt32(txtUlFullFlexionAngleLeft2.Text);

    //        }
    //        else
    //        {
    //            sprintmodeldata.UlFullFlexionAngle = null;
    //        }



    //    }
    //    catch { }
    //    if (sprintmodeldata.SprintModelDataId <= 0)
    //    {
    //        DataRepository.SprintModelDataProvider.Insert(sprintmodeldata);
    //    }
    //    else
    //    {
    //        DataRepository.SprintModelDataProvider.Update(sprintmodeldata);
    //    }

    //}

    //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    ClearData();
    //    DropDownList3.SelectedValue = "nodate";
    //    lblDate.Visible = false;
    //    lblDateEx.Visible = false;
    //    lblLocation.Visible = false;
    //    txtDate.Visible = false;
    //    txtLocation.Visible = false;
    //    Gridview1.Visible = false;
    //    txtbFilePath.Text = "";
    //    txtbFilePath.Visible = false;
    //    btnUpload.Visible = false;
    //    Label117.Text = "";

    //    if (!DropDownList1.SelectedValue.Equals("noathlete"))
    //    {
    //        DropDownList2.Items.Clear();
    //        LoadExistingLocation();
    //    }
    //    else
    //    {
    //        DropDownList2.Items.Clear();
    //        DropDownList2.Items.Add("Select Analysis Date and Location");
    //        DropDownList2.Items[0].Value = "nodate";
    //        DropDownList2.Visible = false;
    //    }

    //    //if (DropDownList2.Items.Count == 1)
    //    //{
    //    //    if (!DropDownList1.SelectedValue.Equals("noathlete"))
    //    //    {

    //    //    }
    //    //    else
    //    //    {
    //    //        DropDownList3.Items.Clear();
    //    //        DropDownList3.Items.Add("Select Lessson Date and Location");
    //    //        DropDownList3.Items[0].Value = "nodateloc";
    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    //DropDownList2.Visible = true;
    //    //}
    //}

    //protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //wmplayer.MovieURL = "";
    //    wmpfile = "";
    //    //DropDownList2.Visible = false;
    //    //DropDownList3.Visible = true;
    //    //btndateloc.Visible = true;
    //    Gridview1.Visible = false;
    //    txtbFilePath.Text = "";
    //    txtbFilePath.Visible = true;
    //    btnUpload.Visible = true;
    //    DropDownList3.SelectedValue = "nodate";
    //    lblDate.Visible = false;
    //    lblDateEx.Visible = false;
    //    lblLocation.Visible = false;
    //    txtDate.Visible = false;
    //    txtLocation.Visible = false;

    //    int LessonSelected;
    //    SprintVideo sprintvideo;

    //    #region [Commented]
    //    //if (!DropDownList2.SelectedValue.Equals("nodate"))
    //    //{
    //    //    DropDownList3.Items.Clear();
    //    //    //DropDownList3.Visible = true;

    //    //    // AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
    //    //    lessonlist = DataRepository.LessonProvider.GetByLessonType(2);
    //    //    // lessonlist = DataRepository.LessonProvider.GetByUserId(AthleteSelected);
    //    //    lessonlist.Sort("LessonDate DESC");
    //    //    x = 0;
    //    //    DropDownList3.Items.Add("Select Lessson Date and Location");
    //    //    DropDownList3.Items[0].Value = "nodateloc";
    //    //    foreach (Lesson lesson in lessonlist)
    //    //    {
    //    //        //if (lesson.LessonType.Equals(2))
    //    //        //{
    //    //        x++;
    //    //        DropDownList3.Items.Add(lesson.LessonDate.ToShortDateString() + " - " + lesson.LessonLocation);
    //    //        DropDownList3.Items[x].Value = lesson.LessonId.ToString();
    //    //        //}
    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    DropDownList3.Items.Clear();
    //    //    DropDownList3.Items.Add("Select Lessson Date and Location");
    //    //    DropDownList3.Items[0].Value = "nodateloc";
    //    //    // DropDownList3.Visible = false;
    //    //}
    //    #endregion [Commented]

    //    if (!DropDownList2.SelectedValue.Equals("nodate"))
    //    {

    //        LessonSelected = Convert.ToInt16(DropDownList2.SelectedValue);
    //        try
    //        {
    //            int AthleteSelected;
    //            int LocationSelected;
    //            LocationSelected = Convert.ToInt16(DropDownList2.SelectedValue);
    //            AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);

    //            customer = DataRepository.MpUsersProvider.GetByUserId(AthleteSelected);
    //            lesson = DataRepository.LessonProvider.GetByLessonId(LocationSelected);
    //            sprintvideo = DataRepository.SprintVideoProvider.GetByLessonId(LessonSelected)[0];
    //            //wmplayer.MovieURL = sprintvideo.SprintVideoPath;
    //            wmpfile = "http://www.compusport.com/" + sprintvideo.SprintVideoPath;
    //            string savepath = Server.MapPath(sprintvideo.SprintVideoPath);
    //            if (!File.Exists(savepath))
    //            {

    //                //SmtpMail.SmtpServer = "localhost";
    //                //SmtpMail.Send("track@compusport.com", "ralph@compusport.com", "Video is not Available for " + customer.Name.ToString(),
    //                //    //SmtpMail.Send("track@compusport.com", "ralph@compusport.com", "Video Requested from " + customer.Name.ToString(),
    //                //    "Email : " + currentUser.Email.ToString() + "    " + "Name : " + customer.Name.ToString() + "  " +
    //                //    "Location : " + lesson.LessonLocation.ToString() + "Path is available but video not found");
    //                Label117.Text = "Path is available but video not found";
    //                VideoDiv.Visible = false;
    //            }
    //            else
    //            {
    //               // object childId;
    //               // int childId1 = 0;
    //               //// Response.Write("<script language='javascript'>alert('Child ID: \n" + childId1.ToString() + " .');</script>");
    //               // try
    //               // {
    //               //     childId = GetChildID(customer.UserId);
    //               //     childId1 = Convert.ToInt32(childId);
    //               // }
    //               // catch { }
    //               // if(childId1==1)
    //               // {
    //                string sprintvideopath = sprintvideo.SprintVideoPath.ToString();
    //                string[] sprintvideonames = sprintvideopath.Split('/');
    //                //txtvideo.Text= sprintvideonames[4].ToString();
    //                txtbFilePath.Text = sprintvideonames[4].ToString();
    //                VideoDiv.Visible = true;
    //                Label117.Text = "Click the Play button to start the video.";
    //                //}
    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            VideoDiv.Visible = false;
    //            Label117.Text = "No Video Available.";
    //        }




    //        //    wmpfile = "http://www.compusport.com/" + hurdlevideo.HurdleVideoPath;
    //        //    string savepath = Server.MapPath(hurdlevideo.HurdleVideoPath);
    //        //    if (!File.Exists(savepath))
    //        //    {
    //        //        int AthleteSelected;
    //        //        int LocationSelected;
    //        //        LocationSelected = Convert.ToInt16(DropDownList2.SelectedValue);
    //        //        AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);

    //        //        customer = DataRepository.MpUsersProvider.GetByUserId(AthleteSelected);
    //        //        lesson = DataRepository.LessonProvider.GetByLessonId(LocationSelected);
    //        //        SmtpMail.SmtpServer = "localhost";
    //        //        //SmtpMail.Send("track@compusport.com", "ralph@compusport.com", "Video is not Available for " + mpuser.Name.ToString(),
    //        //        //    //SmtpMail.Send("track@compusport.com", "ralph@compusport.com", "Video Requested from " + mpuser.Name.ToString(),
    //        //        //    "Email : " + currentUser.Email.ToString() + "    " + "Name : " + mpuser.Name.ToString() + "  " +
    //        //        //    "Location : " + lesson.LessonLocation.ToString() + "Path is available but video not found");
    //        //        Label117.Text = "Path is available but video not found";
    //        //        videodiv.Visible = false;
    //        //        MsgDiv.Visible = true;
    //        //        //Label117.Text = "";
    //        //    }
    //        //    else
    //        //    {
    //        //        videodiv.Visible = true;
    //        //        Label117.Text = "Click the Play button to start the video.";
    //        //        MsgDiv.Visible = false;

    //        //    }
    //        //}
    //        //catch (Exception ex)
    //        //{
    //        //    videodiv.Visible = false;
    //        //    MsgDiv.Visible = true;
    //        //    Label117.Text = "";
    //        //}








    //        try
    //        {
    //            LoadSprintInitialData(LessonSelected);
    //            InitialExists = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            InitialExists = false;
    //        }
    //        try
    //        {
    //            LoadSprintCurrentData(LessonSelected);
    //            CurrentExists = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            CurrentExists = false;
    //        }
    //        try
    //        {
    //            LoadSprintModelData(LessonSelected);
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }
    //}

    ////protected void btnSubmit_Click(object sender, EventArgs e)
    ////{
    ////    if (!DropDownList1.SelectedValue.Equals("noathlete") && (!DropDownList2.SelectedValue.Equals("nodate") || !DropDownList3.SelectedValue.Equals("nodate")))
    ////    {
    ////        SprintInitialData sprintinitialdata = new SprintInitialData();
    ////        SprintCurrentData sprintcurrentdata = new SprintCurrentData();
    ////        SprintModelData sprintmodeldata = new SprintModelData();
    ////        SprintVideo sprintvideo = new SprintVideo();
    ////        Lesson lesson = new Lesson();
    ////        int LessonSelected = 0;
    ////        bool isNewLesson = true;
    ////        try
    ////        {
    ////            // memuser = DataRepository.MpUsersProvider.GetByUserId(currentUser.UserId);
    ////            if (!DropDownList3.SelectedValue.Equals("nodate"))
    ////            {
    ////                LessonSelected = Convert.ToInt32(DropDownList3.SelectedValue);

    ////                int AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
    ////                Lesson tempLesson = DataRepository.LessonProvider.GetByLessonId(LessonSelected);

    ////                lesson.LessonDate = tempLesson.LessonDate;
    ////                lesson.LessonLocation = tempLesson.LessonLocation;

    ////                if (AthleteSelected == tempLesson.UserId)
    ////                {
    ////                    isNewLesson = false;
    ////                }
    ////            }
    ////            else if (!DropDownList2.SelectedValue.Equals("nodate"))
    ////            {
    ////                LessonSelected = Convert.ToInt32(DropDownList2.SelectedValue);
    ////                isNewLesson = false;
    ////            }
    ////            if (LessonSelected > 0 & !isNewLesson)
    ////            {
    ////                sprintinitialdata = DataRepository.SprintInitialDataProvider.GetByLessonId(LessonSelected)[0];
    ////                sprintcurrentdata = DataRepository.SprintCurrentDataProvider.GetByLessonId(LessonSelected)[0];
    ////                sprintmodeldata = DataRepository.SprintModelDataProvider.GetByLessonId(LessonSelected)[0];
    ////                sprintvideo = DataRepository.SprintVideoProvider.GetByLessonId(LessonSelected)[0];
    ////                lesson = DataRepository.LessonProvider.GetByLessonId(LessonSelected);
    ////                // LessonSelected = Convert.ToInt16(DropDownList2.SelectedValue);
    ////                //sprintinitialdata = DataRepository.SprintInitialDataProvider.GetBySprintInitialDataId(2);
    ////            }
    ////        }
    ////        catch (Exception)
    ////        {
    ////        }

    ////        try
    ////        {
    ////            lesson.UserId = Convert.ToInt32(DropDownList1.SelectedValue);
    ////            lesson.LessonType = 2;
    ////            if (DropDownList3.Items[0].Selected == false)
    ////            {
    ////                //string dateloc = DropDownList3.SelectedItem.ToString();
    ////                //string[] dateloc1 = dateloc.Split('-');
    ////                //lesson.LessonDate = Convert.ToDateTime(dateloc1[0].ToString());
    ////                //lesson.LessonLocation = dateloc1[1].ToString();
    ////                lesson.LessonId = 0;
    ////            }
    ////            else if (DropDownList2.Items[0].Selected == true)
    ////            {
    ////                try
    ////                {
    ////                    lesson.LessonDate = Convert.ToDateTime(txtDate.Text);
    ////                }
    ////                catch
    ////                {
    ////                    //Response.Write("<script>alert('Please enter valid date and time[MM-dd-yyyy]');</script>");
    ////                    Label1.Text = "Please enter valid date and time[MM-dd-yyyy]";
    ////                    // return;
    ////                }
    ////                lesson.LessonLocation = txtLocation.Text;
    ////            }
    ////            if (isNewLesson)
    ////            {
    ////                DataRepository.LessonProvider.Insert(lesson);
    ////            }
    ////            else
    ////            {
    ////                DataRepository.LessonProvider.Update(lesson);
    ////            }
    ////        }
    ////        catch (Exception ex)
    ////        {

    ////        }

    ////        try
    ////        {
    ////            sprintinitialdata.LessonId = lesson.LessonId;

    ////            if (!string.IsNullOrEmpty(txtbFilePath.Text))
    ////            {
    ////                sprintvideo.LessonId = lesson.LessonId;
    ////                sprintvideo.SprintVideoPath = Convert.ToString(txtbFilePath.Text);
    ////                //sprintvideo.GroundTimeLeft = Convert.ToDecimal(txtGroundTimeLeft.Text);
    ////            }
    ////            if (isNewLesson)
    ////            {
    ////                DataRepository.SprintVideoProvider.Insert(sprintvideo);
    ////            }
    ////            else
    ////            {
    ////                DataRepository.SprintVideoProvider.Update(sprintvideo);
    ////            }
    ////        }
    ////        catch
    ////        {


    ////        }
    ////        try
    ////        {

    ////            sprintinitialdata.LessonId = lesson.LessonId;

    ////            if (!string.IsNullOrEmpty(txtGroundTimeLeft.Text))
    ////            {
    ////                sprintinitialdata.GroundTimeLeft = Convert.ToDecimal(txtGroundTimeLeft.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.GroundTimeLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtGroundTimeRight.Text))
    ////            {
    ////                sprintinitialdata.GroundTimeRight = Convert.ToDecimal(txtGroundTimeRight.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.GroundTimeRight = null;
    ////            }

    ////            if (!string.IsNullOrEmpty(txtAirTimeLeftToRight.Text))
    ////            {
    ////                sprintinitialdata.AirTimeLeftToRight = Convert.ToDecimal(txtAirTimeLeftToRight.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.AirTimeLeftToRight = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtAirTimeRightToLeft.Text))
    ////            {
    ////                sprintinitialdata.AirTimeRightToLeft = Convert.ToDecimal(txtAirTimeRightToLeft.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.AirTimeRightToLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtFullFlexionTimeLeft.Text))
    ////            {
    ////                sprintinitialdata.FullFlexionTimeLeft = Convert.ToDecimal(txtFullFlexionTimeLeft.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.FullFlexionTimeLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtFullFlexionTimeRight.Text))
    ////            {
    ////                sprintinitialdata.FullFlexionTimeRight = Convert.ToDecimal(txtFullFlexionTimeRight.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.FullFlexionTimeRight = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtStrideLengthLeftToRight.Text))
    ////            {
    ////                sprintinitialdata.StrideLengthLeftToRight = Convert.ToDecimal(txtStrideLengthLeftToRight.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.StrideLengthLeftToRight = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtStrideLengthRightToLeft.Text))
    ////            {
    ////                sprintinitialdata.StrideLengthRightToLeft = Convert.ToDecimal(txtStrideLengthRightToLeft.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.StrideLengthRightToLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtCogDistanceLeft.Text))
    ////            {
    ////                sprintinitialdata.CogDistanceLeft = Convert.ToDecimal(txtCogDistanceLeft.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.CogDistanceLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtCogDistanceRight.Text))
    ////            {
    ////                sprintinitialdata.CogDistanceRight = Convert.ToDecimal(txtCogDistanceRight.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.CogDistanceRight = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtUlFullExtensionAngleLeft.Text))
    ////            {
    ////                sprintinitialdata.UlFullExtensionAngleLeft = Convert.ToInt32(txtUlFullExtensionAngleLeft.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.UlFullExtensionAngleLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtUlFullExtensionAngleRight.Text))
    ////            {
    ////                sprintinitialdata.UlFullExtensionAngleRight = Convert.ToInt32(txtUlFullExtensionAngleRight.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.UlFullExtensionAngleRight = null;
    ////            }

    ////            if (!string.IsNullOrEmpty(txtLlAngleTakeoffLeft.Text))
    ////            {
    ////                sprintinitialdata.LlAngleTakeoffLeft = Convert.ToInt32(txtLlAngleTakeoffLeft.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.LlAngleTakeoffLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtLlaAngleTakeoffRight.Text))
    ////            {
    ////                sprintinitialdata.LlaAngleTakeoffRight = Convert.ToInt32(txtLlaAngleTakeoffRight.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.LlaAngleTakeoffRight = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtLlFullFlexionAngleLeft.Text))
    ////            {
    ////                sprintinitialdata.LlFullFlexionAngleLeft = Convert.ToInt32(txtLlFullFlexionAngleLeft.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.LlFullFlexionAngleLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtLlFullFlexionAngleRight.Text))
    ////            {
    ////                sprintinitialdata.LlFullFlexionAngleRight = Convert.ToInt32(txtLlFullFlexionAngleRight.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.LlFullFlexionAngleRight = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtLlAngleAcLeft.Text))
    ////            {
    ////                sprintinitialdata.LlAngleAcLeft = Convert.ToInt32(txtLlAngleAcLeft.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.LlAngleAcLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtLlAngleAcRight.Text))
    ////            {
    ////                sprintinitialdata.LlAngleAcRight = Convert.ToInt32(txtLlAngleAcRight.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.LlAngleAcRight = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtUlFullFlexionAngleLeft.Text))
    ////            {
    ////                sprintinitialdata.UlFullFlexionAngleLeft = Convert.ToInt32(txtUlFullFlexionAngleLeft.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.UlFullFlexionAngleLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtUlFullFlexionAngleRight.Text))
    ////            {
    ////                sprintinitialdata.UlFullFlexionAngleRight = Convert.ToInt32(txtUlFullFlexionAngleRight.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintinitialdata.UlFullFlexionAngleRight = null;
    ////            }
    ////        }
    ////        catch { }

    ////            if (sprintinitialdata.SprintInitialDataId <= 0)
    ////            {
    ////                DataRepository.SprintInitialDataProvider.Insert(sprintinitialdata);
    ////            }
    ////            else
    ////            {
    ////                DataRepository.SprintInitialDataProvider.Update(sprintinitialdata);
    ////            }

    ////        //}

    ////        //private void InsertupdateSprintCurrentData(int LessonSelected)
    ////        //{
    ////        //    SprintCurrentData sprintcurrentdata = new SprintCurrentData();
    ////        //    if (LessonSelected > 0)
    ////        //    {
    ////        //        sprintcurrentdata = DataRepository.SprintCurrentDataProvider.GetByLessonId(LessonSelected)[0];
    ////        //        lesson = DataRepository.LessonProvider.GetByLessonId(LessonSelected);
    ////        //    }

    ////        try
    ////        {

    ////            sprintcurrentdata.LessonId = lesson.LessonId;

    ////            if (!string.IsNullOrEmpty(txtGroundTimeLeft1.Text))
    ////            {
    ////                sprintcurrentdata.GroundTimeLeft = Convert.ToDecimal(txtGroundTimeLeft1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.GroundTimeLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtGroundTimeRight1.Text))
    ////            {
    ////                sprintcurrentdata.GroundTimeRight = Convert.ToDecimal(txtGroundTimeRight1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.GroundTimeRight = null;
    ////            }

    ////            if (!string.IsNullOrEmpty(txtAirTimeLeftToRight1.Text))
    ////            {
    ////                sprintcurrentdata.AirTimeLeftToRight = Convert.ToDecimal(txtAirTimeLeftToRight1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.AirTimeLeftToRight = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtAirTimeRightToLeft1.Text))
    ////            {
    ////                sprintcurrentdata.AirTimeRightToLeft = Convert.ToDecimal(txtAirTimeRightToLeft1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.AirTimeRightToLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtFullFlexionTimeLeft1.Text))
    ////            {
    ////                sprintcurrentdata.FullFlexionTimeLeft = Convert.ToDecimal(txtFullFlexionTimeLeft1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.FullFlexionTimeLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtFullFlexionTimeRight1.Text))
    ////            {
    ////                sprintcurrentdata.FullFlexionTimeRight = Convert.ToDecimal(txtFullFlexionTimeRight1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.FullFlexionTimeRight = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtStrideLengthLeftToRight1.Text))
    ////            {
    ////                sprintcurrentdata.StrideLengthLeftToRight = Convert.ToDecimal(txtStrideLengthLeftToRight1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.StrideLengthLeftToRight = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtStrideLengthRightToLeft1.Text))
    ////            {
    ////                sprintcurrentdata.StrideLengthRightToLeft = Convert.ToDecimal(txtStrideLengthRightToLeft1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.StrideLengthRightToLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtCogDistanceLeft1.Text))
    ////            {
    ////                sprintcurrentdata.CogDistanceLeft = Convert.ToDecimal(txtCogDistanceLeft1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.CogDistanceLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtCogDistanceRight1.Text))
    ////            {
    ////                sprintcurrentdata.CogDistanceRight = Convert.ToDecimal(txtCogDistanceRight1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.CogDistanceRight = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtUlFullExtensionAngleLeft1.Text))
    ////            {
    ////                sprintcurrentdata.UlFullExtensionAngleLeft = Convert.ToInt32(txtUlFullExtensionAngleLeft1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.UlFullExtensionAngleLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtUlFullExtensionAngleRight1.Text))
    ////            {
    ////                sprintcurrentdata.UlFullExtensionAngleRight = Convert.ToInt32(txtUlFullExtensionAngleRight1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.UlFullExtensionAngleRight = null;
    ////            }

    ////            if (!string.IsNullOrEmpty(txtLlAngleTakeoffLeft1.Text))
    ////            {
    ////                sprintcurrentdata.LlAngleTakeoffLeft = Convert.ToInt32(txtLlAngleTakeoffLeft1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.LlAngleTakeoffLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtLlaAngleTakeoffRight1.Text))
    ////            {
    ////                sprintcurrentdata.LlaAngleTakeoffRight = Convert.ToInt32(txtLlaAngleTakeoffRight1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.LlaAngleTakeoffRight = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtLlFullFlexionAngleLeft1.Text))
    ////            {
    ////                sprintcurrentdata.LlFullFlexionAngleLeft = Convert.ToInt32(txtLlFullFlexionAngleLeft1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.LlFullFlexionAngleLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtLlFullFlexionAngleRight1.Text))
    ////            {
    ////                sprintcurrentdata.LlFullFlexionAngleRight = Convert.ToInt32(txtLlFullFlexionAngleRight1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.LlFullFlexionAngleRight = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtLlAngleAcLeft1.Text))
    ////            {
    ////                sprintcurrentdata.LlAngleAcLeft = Convert.ToInt32(txtLlAngleAcLeft1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.LlAngleAcLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtLlAngleAcRight1.Text))
    ////            {
    ////                sprintcurrentdata.LlAngleAcRight = Convert.ToInt32(txtLlAngleAcRight1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.LlAngleAcRight = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtUlFullFlexionAngleLeft1.Text))
    ////            {
    ////                sprintcurrentdata.UlFullFlexionAngleLeft = Convert.ToInt32(txtUlFullFlexionAngleLeft1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.UlFullFlexionAngleLeft = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtUlFullFlexionAngleRight1.Text))
    ////            {
    ////                sprintcurrentdata.UlFullFlexionAngleRight = Convert.ToInt32(txtUlFullFlexionAngleRight1.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintcurrentdata.UlFullFlexionAngleRight = null;
    ////            }
    ////        }
    ////        catch { }
    ////        if (sprintcurrentdata.SprintCurrentDataId <= 0)
    ////        {
    ////            DataRepository.SprintCurrentDataProvider.Insert(sprintcurrentdata);
    ////        }
    ////        else
    ////        {
    ////            DataRepository.SprintCurrentDataProvider.Update(sprintcurrentdata);
    ////        }

    ////        try
    ////        {

    ////            sprintmodeldata.LessonId = lesson.LessonId;

    ////            if (!string.IsNullOrEmpty(txtGroundTimeLeft2.Text))
    ////            {
    ////                sprintmodeldata.GroundTime = Convert.ToDecimal(txtGroundTimeLeft2.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintmodeldata.GroundTime = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtAirTimeLeftToRight2.Text))
    ////            {
    ////                sprintmodeldata.AirTime = Convert.ToDecimal(txtAirTimeLeftToRight2.Text);

    ////            }
    ////            else
    ////            {
    ////                sprintmodeldata.AirTime = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtFullFlexionTimeLeft2.Text))
    ////            {
    ////                sprintmodeldata.FullFlexionTime = Convert.ToDecimal(txtFullFlexionTimeLeft2.Text);
    ////            }
    ////            else
    ////            {
    ////                sprintmodeldata.FullFlexionTime = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtStrideLengthLeftToRight2.Text))
    ////            {
    ////                sprintmodeldata.StrideLength = Convert.ToDecimal(txtStrideLengthLeftToRight2.Text);

    ////            }
    ////            else
    ////            {
    ////                sprintmodeldata.StrideLength = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtCogDistanceLeft2.Text))
    ////            {
    ////                sprintmodeldata.CogDistance = Convert.ToDecimal(txtCogDistanceLeft2.Text);

    ////            }
    ////            else
    ////            {
    ////                sprintmodeldata.CogDistance = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtUlFullExtensionAngleLeft2.Text))
    ////            {
    ////                sprintmodeldata.UlFullExtensionAngle = Convert.ToInt32(txtUlFullExtensionAngleLeft2.Text);

    ////            }
    ////            else
    ////            {
    ////                sprintmodeldata.UlFullExtensionAngle = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtLlAngleTakeoffLeft2.Text))
    ////            {
    ////                sprintmodeldata.LlAngleTakeoff = Convert.ToInt32(txtLlAngleTakeoffLeft2.Text);

    ////            }
    ////            else
    ////            {
    ////                sprintmodeldata.LlAngleTakeoff = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtLlFullFlexionAngleLeft2.Text))
    ////            {
    ////                sprintmodeldata.LlFullFlexionAngle = Convert.ToInt32(txtLlFullFlexionAngleLeft2.Text);

    ////            }
    ////            else
    ////            {
    ////                sprintmodeldata.LlFullFlexionAngle = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtLlAngleAcLeft2.Text))
    ////            {
    ////                sprintmodeldata.LlAngleAc = Convert.ToInt32(txtLlAngleAcLeft2.Text);

    ////            }
    ////            else
    ////            {
    ////                sprintmodeldata.LlAngleAc = null;
    ////            }
    ////            if (!string.IsNullOrEmpty(txtUlFullFlexionAngleLeft2.Text))
    ////            {
    ////                sprintmodeldata.UlFullFlexionAngle = Convert.ToInt32(txtUlFullFlexionAngleLeft2.Text);

    ////            }
    ////            else
    ////            {
    ////                sprintmodeldata.UlFullFlexionAngle = null;
    ////            }



    ////        }
    ////        catch { }
    ////        if (sprintmodeldata.SprintModelDataId <= 0)
    ////        {
    ////            DataRepository.SprintModelDataProvider.Insert(sprintmodeldata);
    ////        }
    ////        else
    ////        {
    ////            DataRepository.SprintModelDataProvider.Update(sprintmodeldata);
    ////        }
    ////        try
    ////        {
    ////            sprintvideo.LessonId = lesson.LessonId;
    ////            sprintvideo.SprintVideoPath = "Data/Sites/1/videos/" + Convert.ToString(txtbFilePath.Text);
    ////        }
    ////        catch { }
    ////        if (sprintvideo.SprintVideoId <= 0)
    ////        {
    ////            DataRepository.SprintVideoProvider.Insert(sprintvideo);
    ////        }
    ////        else
    ////        {
    ////            DataRepository.SprintVideoProvider.Update(sprintvideo);
    ////        }



    ////        ClearData();

    ////        //DropDownList2.Visible = false;
    ////        //DropDownList3.Visible = false;
    ////        DropDownList1.SelectedValue = "noathlete";
    ////        DropDownList2.Items.Clear();
    ////        DropDownList2.Items.Add("Select Analysis Date and Location");
    ////        DropDownList2.Items[0].Value = "nodate";
    ////        DropDownList3.SelectedValue = "nodate";
    ////        lblDate.Visible = false;
    ////        lblDateEx.Visible = false;
    ////        lblLocation.Visible = false;
    ////        txtDate.Visible = false;
    ////        txtLocation.Visible = false;
    ////        DropDownList1.SelectedItem.Value = "1";
    ////        Gridview1.Visible = false;
    ////        txtbFilePath.Visible = false;
    ////        btnUpload.Visible = false;

    ////        // Response.Write("<script>alert('Data saved successfully');</script>");
    ////        //  Label1.Text = "Data saved successfully";
    ////    }
    ////    else
    ////    {
    ////        // Response.Write("<script>alert('Please select Athlete');</script>");
    ////        //Label1.Text = "Please select Athlete";
    ////    }
    ////}

    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{
    //    if (!DropDownList1.SelectedValue.Equals("noathlete"))
    //    {
    //        SprintInitialData sprintinitialdata = new SprintInitialData();
    //        SprintCurrentData sprintcurrentdata = new SprintCurrentData();
    //        SprintModelData sprintmodeldata = new SprintModelData();
    //        SprintVideo sprintvideo = new SprintVideo();
    //        Lesson lesson = new Lesson();
    //        int LessonSelected = 0;
    //        bool isNewLesson = true;
    //        try
    //        {
    //            // memuser = DataRepository.MpUsersProvider.GetByUserId(currentUser.UserId);
    //            if (!DropDownList3.SelectedValue.Equals("nodate"))
    //            {
    //                LessonSelected = Convert.ToInt32(DropDownList3.SelectedValue);

    //                int AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
    //                Lesson tempLesson = DataRepository.LessonProvider.GetByLessonId(LessonSelected);

    //                lesson.LessonDate = tempLesson.LessonDate;
    //                lesson.LessonLocation = tempLesson.LessonLocation;

    //                if (AthleteSelected == tempLesson.UserId)
    //                {
    //                    isNewLesson = false;
    //                }
    //            }
    //            else if (!DropDownList2.SelectedValue.Equals("nodate"))
    //            {
    //                LessonSelected = Convert.ToInt32(DropDownList2.SelectedValue);
    //                isNewLesson = false;
    //            }
    //            if (LessonSelected > 0 & !isNewLesson)
    //            {
    //                sprintinitialdata = DataRepository.SprintInitialDataProvider.GetByLessonId(LessonSelected)[0];
    //                sprintcurrentdata = DataRepository.SprintCurrentDataProvider.GetByLessonId(LessonSelected)[0];
    //                sprintmodeldata = DataRepository.SprintModelDataProvider.GetByLessonId(LessonSelected)[0];
    //                lesson = DataRepository.LessonProvider.GetByLessonId(LessonSelected);
    //                sprintvideo = DataRepository.SprintVideoProvider.GetByLessonId(LessonSelected)[0];
    //                // LessonSelected = Convert.ToInt16(DropDownList2.SelectedValue);
    //                //sprintinitialdata = DataRepository.SprintInitialDataProvider.GetBySprintInitialDataId(2);
    //            }
    //        }
    //        catch (Exception)
    //        {
    //        }

    //        try
    //        {
    //            lesson.UserId = Convert.ToInt32(DropDownList1.SelectedValue);
    //            lesson.LessonType = 2;
    //            if (DropDownList3.Items[0].Selected == false)
    //            {
    //                //string dateloc = DropDownList3.SelectedItem.ToString();
    //                //string[] dateloc1 = dateloc.Split('-');
    //                //lesson.LessonDate = Convert.ToDateTime(dateloc1[0].ToString());
    //                //lesson.LessonLocation = dateloc1[1].ToString();
    //                lesson.LessonId = 0;
    //            }
    //            else if (DropDownList2.Items[0].Selected == true)
    //            {
    //                try
    //                {
    //                    lesson.LessonDate = Convert.ToDateTime(txtDate.Text);
    //                }
    //                catch
    //                {
    //                    //Response.Write("<script>alert('Please enter valid date and time[MM-dd-yyyy]');</script>");
    //                    Label1.Text = "Please enter valid date and time[MM-dd-yyyy]";
    //                    // return;
    //                }
    //                lesson.LessonLocation = txtLocation.Text;
    //            }
    //            if (isNewLesson)
    //            {
    //                DataRepository.LessonProvider.Insert(lesson);
    //            }
    //            else
    //            {
    //                DataRepository.LessonProvider.Update(lesson);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //        }

    //        try
    //        {

    //            sprintinitialdata.LessonId = lesson.LessonId;

    //            if (!string.IsNullOrEmpty(txtGroundTimeLeft.Text))
    //            {
    //                sprintinitialdata.GroundTimeLeft = Convert.ToDecimal(txtGroundTimeLeft.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.GroundTimeLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtGroundTimeRight.Text))
    //            {
    //                sprintinitialdata.GroundTimeRight = Convert.ToDecimal(txtGroundTimeRight.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.GroundTimeRight = null;
    //            }

    //            if (!string.IsNullOrEmpty(txtAirTimeLeftToRight.Text))
    //            {
    //                sprintinitialdata.AirTimeLeftToRight = Convert.ToDecimal(txtAirTimeLeftToRight.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.AirTimeLeftToRight = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtAirTimeRightToLeft.Text))
    //            {
    //                sprintinitialdata.AirTimeRightToLeft = Convert.ToDecimal(txtAirTimeRightToLeft.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.AirTimeRightToLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtFullFlexionTimeLeft.Text))
    //            {
    //                sprintinitialdata.FullFlexionTimeLeft = Convert.ToDecimal(txtFullFlexionTimeLeft.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.FullFlexionTimeLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtFullFlexionTimeRight.Text))
    //            {
    //                sprintinitialdata.FullFlexionTimeRight = Convert.ToDecimal(txtFullFlexionTimeRight.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.FullFlexionTimeRight = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtStrideLengthLeftToRight.Text))
    //            {
    //                sprintinitialdata.StrideLengthLeftToRight = Convert.ToDecimal(txtStrideLengthLeftToRight.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.StrideLengthLeftToRight = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtStrideLengthRightToLeft.Text))
    //            {
    //                sprintinitialdata.StrideLengthRightToLeft = Convert.ToDecimal(txtStrideLengthRightToLeft.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.StrideLengthRightToLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtCogDistanceLeft.Text))
    //            {
    //                sprintinitialdata.CogDistanceLeft = Convert.ToDecimal(txtCogDistanceLeft.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.CogDistanceLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtCogDistanceRight.Text))
    //            {
    //                sprintinitialdata.CogDistanceRight = Convert.ToDecimal(txtCogDistanceRight.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.CogDistanceRight = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtUlFullExtensionAngleLeft.Text))
    //            {
    //                sprintinitialdata.UlFullExtensionAngleLeft = Convert.ToInt32(txtUlFullExtensionAngleLeft.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.UlFullExtensionAngleLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtUlFullExtensionAngleRight.Text))
    //            {
    //                sprintinitialdata.UlFullExtensionAngleRight = Convert.ToInt32(txtUlFullExtensionAngleRight.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.UlFullExtensionAngleRight = null;
    //            }

    //            if (!string.IsNullOrEmpty(txtLlAngleTakeoffLeft.Text))
    //            {
    //                sprintinitialdata.LlAngleTakeoffLeft = Convert.ToInt32(txtLlAngleTakeoffLeft.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.LlAngleTakeoffLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtLlaAngleTakeoffRight.Text))
    //            {
    //                sprintinitialdata.LlaAngleTakeoffRight = Convert.ToInt32(txtLlaAngleTakeoffRight.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.LlaAngleTakeoffRight = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtLlFullFlexionAngleLeft.Text))
    //            {
    //                sprintinitialdata.LlFullFlexionAngleLeft = Convert.ToInt32(txtLlFullFlexionAngleLeft.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.LlFullFlexionAngleLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtLlFullFlexionAngleRight.Text))
    //            {
    //                sprintinitialdata.LlFullFlexionAngleRight = Convert.ToInt32(txtLlFullFlexionAngleRight.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.LlFullFlexionAngleRight = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtLlAngleAcLeft.Text))
    //            {
    //                sprintinitialdata.LlAngleAcLeft = Convert.ToInt32(txtLlAngleAcLeft.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.LlAngleAcLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtLlAngleAcRight.Text))
    //            {
    //                sprintinitialdata.LlAngleAcRight = Convert.ToInt32(txtLlAngleAcRight.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.LlAngleAcRight = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtUlFullFlexionAngleLeft.Text))
    //            {
    //                sprintinitialdata.UlFullFlexionAngleLeft = Convert.ToInt32(txtUlFullFlexionAngleLeft.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.UlFullFlexionAngleLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtUlFullFlexionAngleRight.Text))
    //            {
    //                sprintinitialdata.UlFullFlexionAngleRight = Convert.ToInt32(txtUlFullFlexionAngleRight.Text);
    //            }
    //            else
    //            {
    //                sprintinitialdata.UlFullFlexionAngleRight = null;
    //            }
    //        }
    //        catch { }
    //        if (sprintinitialdata.SprintInitialDataId <= 0)
    //        {
    //            DataRepository.SprintInitialDataProvider.Insert(sprintinitialdata);
    //        }
    //        else
    //        {
    //            DataRepository.SprintInitialDataProvider.Update(sprintinitialdata);
    //        }

    //        //}

    //        //private void InsertupdateSprintCurrentData(int LessonSelected)
    //        //{
    //        //    SprintCurrentData sprintcurrentdata = new SprintCurrentData();
    //        //    if (LessonSelected > 0)
    //        //    {
    //        //        sprintcurrentdata = DataRepository.SprintCurrentDataProvider.GetByLessonId(LessonSelected)[0];
    //        //        lesson = DataRepository.LessonProvider.GetByLessonId(LessonSelected);
    //        //    }

    //        try
    //        {

    //            sprintcurrentdata.LessonId = lesson.LessonId;

    //            if (!string.IsNullOrEmpty(txtGroundTimeLeft1.Text))
    //            {
    //                sprintcurrentdata.GroundTimeLeft = Convert.ToDecimal(txtGroundTimeLeft1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.GroundTimeLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtGroundTimeRight1.Text))
    //            {
    //                sprintcurrentdata.GroundTimeRight = Convert.ToDecimal(txtGroundTimeRight1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.GroundTimeRight = null;
    //            }

    //            if (!string.IsNullOrEmpty(txtAirTimeLeftToRight1.Text))
    //            {
    //                sprintcurrentdata.AirTimeLeftToRight = Convert.ToDecimal(txtAirTimeLeftToRight1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.AirTimeLeftToRight = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtAirTimeRightToLeft1.Text))
    //            {
    //                sprintcurrentdata.AirTimeRightToLeft = Convert.ToDecimal(txtAirTimeRightToLeft1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.AirTimeRightToLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtFullFlexionTimeLeft1.Text))
    //            {
    //                sprintcurrentdata.FullFlexionTimeLeft = Convert.ToDecimal(txtFullFlexionTimeLeft1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.FullFlexionTimeLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtFullFlexionTimeRight1.Text))
    //            {
    //                sprintcurrentdata.FullFlexionTimeRight = Convert.ToDecimal(txtFullFlexionTimeRight1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.FullFlexionTimeRight = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtStrideLengthLeftToRight1.Text))
    //            {
    //                sprintcurrentdata.StrideLengthLeftToRight = Convert.ToDecimal(txtStrideLengthLeftToRight1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.StrideLengthLeftToRight = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtStrideLengthRightToLeft1.Text))
    //            {
    //                sprintcurrentdata.StrideLengthRightToLeft = Convert.ToDecimal(txtStrideLengthRightToLeft1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.StrideLengthRightToLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtCogDistanceLeft1.Text))
    //            {
    //                sprintcurrentdata.CogDistanceLeft = Convert.ToDecimal(txtCogDistanceLeft1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.CogDistanceLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtCogDistanceRight1.Text))
    //            {
    //                sprintcurrentdata.CogDistanceRight = Convert.ToDecimal(txtCogDistanceRight1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.CogDistanceRight = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtUlFullExtensionAngleLeft1.Text))
    //            {
    //                sprintcurrentdata.UlFullExtensionAngleLeft = Convert.ToInt32(txtUlFullExtensionAngleLeft1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.UlFullExtensionAngleLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtUlFullExtensionAngleRight1.Text))
    //            {
    //                sprintcurrentdata.UlFullExtensionAngleRight = Convert.ToInt32(txtUlFullExtensionAngleRight1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.UlFullExtensionAngleRight = null;
    //            }

    //            if (!string.IsNullOrEmpty(txtLlAngleTakeoffLeft1.Text))
    //            {
    //                sprintcurrentdata.LlAngleTakeoffLeft = Convert.ToInt32(txtLlAngleTakeoffLeft1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.LlAngleTakeoffLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtLlaAngleTakeoffRight1.Text))
    //            {
    //                sprintcurrentdata.LlaAngleTakeoffRight = Convert.ToInt32(txtLlaAngleTakeoffRight1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.LlaAngleTakeoffRight = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtLlFullFlexionAngleLeft1.Text))
    //            {
    //                sprintcurrentdata.LlFullFlexionAngleLeft = Convert.ToInt32(txtLlFullFlexionAngleLeft1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.LlFullFlexionAngleLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtLlFullFlexionAngleRight1.Text))
    //            {
    //                sprintcurrentdata.LlFullFlexionAngleRight = Convert.ToInt32(txtLlFullFlexionAngleRight1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.LlFullFlexionAngleRight = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtLlAngleAcLeft1.Text))
    //            {
    //                sprintcurrentdata.LlAngleAcLeft = Convert.ToInt32(txtLlAngleAcLeft1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.LlAngleAcLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtLlAngleAcRight1.Text))
    //            {
    //                sprintcurrentdata.LlAngleAcRight = Convert.ToInt32(txtLlAngleAcRight1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.LlAngleAcRight = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtUlFullFlexionAngleLeft1.Text))
    //            {
    //                sprintcurrentdata.UlFullFlexionAngleLeft = Convert.ToInt32(txtUlFullFlexionAngleLeft1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.UlFullFlexionAngleLeft = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtUlFullFlexionAngleRight1.Text))
    //            {
    //                sprintcurrentdata.UlFullFlexionAngleRight = Convert.ToInt32(txtUlFullFlexionAngleRight1.Text);
    //            }
    //            else
    //            {
    //                sprintcurrentdata.UlFullFlexionAngleRight = null;
    //            }
    //        }
    //        catch { }
    //        if (sprintcurrentdata.SprintCurrentDataId <= 0)
    //        {
    //            DataRepository.SprintCurrentDataProvider.Insert(sprintcurrentdata);
    //        }
    //        else
    //        {
    //            DataRepository.SprintCurrentDataProvider.Update(sprintcurrentdata);
    //        }

    //        try
    //        {

    //            sprintmodeldata.LessonId = lesson.LessonId;

    //            if (!string.IsNullOrEmpty(txtGroundTimeLeft2.Text))
    //            {
    //                sprintmodeldata.GroundTime = Convert.ToDecimal(txtGroundTimeLeft2.Text);
    //            }
    //            else
    //            {
    //                sprintmodeldata.GroundTime = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtAirTimeLeftToRight2.Text))
    //            {
    //                sprintmodeldata.AirTime = Convert.ToDecimal(txtAirTimeLeftToRight2.Text);

    //            }
    //            else
    //            {
    //                sprintmodeldata.AirTime = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtFullFlexionTimeLeft2.Text))
    //            {
    //                sprintmodeldata.FullFlexionTime = Convert.ToDecimal(txtFullFlexionTimeLeft2.Text);
    //            }
    //            else
    //            {
    //                sprintmodeldata.FullFlexionTime = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtStrideLengthLeftToRight2.Text))
    //            {
    //                sprintmodeldata.StrideLength = Convert.ToDecimal(txtStrideLengthLeftToRight2.Text);

    //            }
    //            else
    //            {
    //                sprintmodeldata.StrideLength = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtCogDistanceLeft2.Text))
    //            {
    //                sprintmodeldata.CogDistance = Convert.ToDecimal(txtCogDistanceLeft2.Text);

    //            }
    //            else
    //            {
    //                sprintmodeldata.CogDistance = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtUlFullExtensionAngleLeft2.Text))
    //            {
    //                sprintmodeldata.UlFullExtensionAngle = Convert.ToInt32(txtUlFullExtensionAngleLeft2.Text);

    //            }
    //            else
    //            {
    //                sprintmodeldata.UlFullExtensionAngle = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtLlAngleTakeoffLeft2.Text))
    //            {
    //                sprintmodeldata.LlAngleTakeoff = Convert.ToInt32(txtLlAngleTakeoffLeft2.Text);

    //            }
    //            else
    //            {
    //                sprintmodeldata.LlAngleTakeoff = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtLlFullFlexionAngleLeft2.Text))
    //            {
    //                sprintmodeldata.LlFullFlexionAngle = Convert.ToInt32(txtLlFullFlexionAngleLeft2.Text);

    //            }
    //            else
    //            {
    //                sprintmodeldata.LlFullFlexionAngle = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtLlAngleAcLeft2.Text))
    //            {
    //                sprintmodeldata.LlAngleAc = Convert.ToInt32(txtLlAngleAcLeft2.Text);

    //            }
    //            else
    //            {
    //                sprintmodeldata.LlAngleAc = null;
    //            }
    //            if (!string.IsNullOrEmpty(txtUlFullFlexionAngleLeft2.Text))
    //            {
    //                sprintmodeldata.UlFullFlexionAngle = Convert.ToInt32(txtUlFullFlexionAngleLeft2.Text);

    //            }
    //            else
    //            {
    //                sprintmodeldata.UlFullFlexionAngle = null;
    //            }



    //        }
    //        catch { }
    //        if (sprintmodeldata.SprintModelDataId <= 0)
    //        {
    //            DataRepository.SprintModelDataProvider.Insert(sprintmodeldata);
    //        }
    //        else
    //        {
    //            DataRepository.SprintModelDataProvider.Update(sprintmodeldata);
    //        }
    //        try
    //        {
    //            sprintvideo.LessonId = lesson.LessonId;
    //            sprintvideo.SprintVideoPath = "Data/Sites/1/videos/" + Convert.ToString(txtbFilePath.Text);
    //        }
    //        catch { }
    //        if (sprintvideo.SprintVideoId <= 0)
    //        {
    //            DataRepository.SprintVideoProvider.Insert(sprintvideo);
    //        }
    //        else
    //        {
    //            DataRepository.SprintVideoProvider.Update(sprintvideo);
    //        }




    //        //DropDownList2.Visible = false;
    //        //DropDownList3.Visible = false;
    //        DropDownList1.SelectedValue = "noathlete";
    //        DropDownList2.Items.Clear();
    //        DropDownList2.Items.Add("Select Analysis Date and Location");
    //        DropDownList2.Items[0].Value = "nodate";
    //        DropDownList3.SelectedValue = "nodate";
    //        lblDate.Visible = false;
    //        lblDateEx.Visible = false;
    //        lblLocation.Visible = false;
    //        txtDate.Visible = false;
    //        txtLocation.Visible = false;
    //        VideoDiv.Visible = false;
    //        Gridview1.Visible = false;
    //        txtbFilePath.Visible = false;
    //        btnUpload.Visible = false;

    //        //DropDownList1.SelectedItem.Value = "1";

    //        //DataRepository.SprintVideoProvider.Update(sprintvideo);
    //        //Response.Write("<script>alert('Data saved successfully');</script>");
    //        Label117.Text = "Data saved successfully";
    //        ClearData();
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Please select Athlete');</script>");
    //        Label117.Text = "Please select Athlete";
    //    }
    //}

    //public Decimal calcavgdecimal(decimal number1, decimal number2)
    //{
    //    decimal average = 0;

    //    average = (number1 + number2) / Convert.ToDecimal(2);

    //    return average;
    //}

    //public int calcavginteger(int number1, int number2)
    //{
    //    int average = 0;

    //    average = Convert.ToInt16((number1 + number2) / 2);

    //    return average;
    //}

    //protected void txtDate_TextChanged(object sender, EventArgs e)
    //{

    //}

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    ClearData();

    //    DropDownList2.SelectedValue = "nodate";
    //    DropDownList3.SelectedValue = "nodate";
    //    lblDate.Visible = true;
    //    lblDateEx.Visible = true;
    //    lblLocation.Visible = true;
    //    txtDate.Visible = true;
    //    txtLocation.Visible = true;
    //}

    //protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //DropDownList2.Visible = false;
    //    //btndateloc.Visible = false;
    //    ClearData();
    //    txtbFilePath.Visible = true;
    //    txtbFilePath.Text = "";
    //    btnUpload.Visible = true;
    //    DropDownList2.SelectedValue = "nodate";
    //    lblDate.Visible = false;
    //    lblDateEx.Visible = false;
    //    lblLocation.Visible = false;
    //    txtDate.Visible = false;
    //    txtLocation.Visible = false;

    //    if (!DropDownList3.SelectedValue.Equals("nodate"))
    //    {
    //        int LessonSelected = Convert.ToInt32(DropDownList3.SelectedValue);
    //        try
    //        {
    //            LoadSprintInitialData(LessonSelected);
    //            InitialExists = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            InitialExists = false;
    //        }
    //        try
    //        {
    //            LoadSprintCurrentData(LessonSelected);
    //            CurrentExists = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            CurrentExists = false;
    //        }
    //        try
    //        {
    //            LoadSprintModelData(LessonSelected);
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }
    //}

    //protected void btnUpload_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Gridview1.Visible = true;
    //        FileInfo myFile = new FileInfo("G:\\CompuSportLive\\compusport\\Data\\Sites\\1\\videos");
    //        string[] files = Directory.GetFiles("G:\\CompuSportLive\\compusport\\Data\\Sites\\1\\videos");
    //        ArrayList arrFiles = new ArrayList();

    //        for (int i = 0; i < files.Length; i++)
    //        {
    //            FilePathClass objFilePathClass = new FilePathClass();
    //            objFilePathClass.Index = i;
    //            try
    //            {
    //                string strTemp = files[i];
    //                files[i] = strTemp.Substring(strTemp.LastIndexOf("\\") + 1, strTemp.Length - strTemp.LastIndexOf("\\") - 1);
    //                objFilePathClass.FilePath = files[i];
    //                arrFiles.Add(objFilePathClass);
    //            }
    //            catch (Exception ex1)
    //            { }
    //        }

    //        Gridview1.DataSource = arrFiles;
    //        Gridview1.DataBind();
    //        Label117.Text = "";
    //    }
    //    catch (Exception ex)
    //    { }
    //}

    //protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    LinkButton lnkSelect = (LinkButton)e.Row.FindControl("lnkSelect");
    //    if (lnkSelect != null)
    //    {
    //        lnkSelect.OnClientClick = "PrintFilePath('" + lnkSelect.Text + "');";
    //    }
    //    //txtbFilePath.Text =
    //}

    ////    DirectoryInfo di = new DirectoryInfo("G:\\CompuSportLive\\compusport\\Data\\Sites\\1\\videos");
    ////    //DirectoryInfo di = new DirectoryInfo("G:\\Backup");
    ////    FileInfo[] rgFiles = di.GetFiles("*.wmv");
    ////    int i = rgFiles.Count();
    ////    object[] Dates = new object[rgFiles.Count()];
    ////    DataTable dtFiles = new DataTable();
    ////    dtFiles.Columns.Add("Athleteid", typeof(int));
    ////    dtFiles.Columns.Add("FileName", typeof(string));
    ////    for (i = 0; i < rgFiles.Count(); i++)
    ////    {
    ////        string filename = Convert.ToString(rgFiles[i]); ;
    ////        DataRow dr = dtFiles.NewRow();
    ////        dr["Athleteid"] = i;
    ////        dr["FileName"] = filename;
    ////        dtFiles.Rows.Add(dr);
    ////    }
    ////    DataTable productData = dtFiles;
    ////    AthleteView.DataSource = productData;
    ////    AthleteView.DataBind();

    ////}

    ////protected void LinkButton1_Click(object sender, EventArgs e)
    ////{
    ////    LinkButton btn = (LinkButton)sender;
    ////    GridViewRow row = (GridViewRow)btn.NamingContainer;
    ////    Response.Write("Row Index of Link button: " + row.RowIndex +
    ////                   "DataKey value:" + AthleteView.DataKeys[row.RowIndex].Value.ToString());
    ////    //GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
    ////    //Label lblID = (Label)clickedRow.FindControl("lblID");
    ////}

    ////protected void AthleteView_RowCommand(object sender, GridViewCommandEventArgs e)
    ////{
    ////    if (e.CommandName.Equals("MyCustomCommand"))
    ////    {
    ////        int ii = Convert.ToInt32(AthleteView.SelectedDataKey);
    ////        GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
    ////        Label lblID = (Label)clickedRow.FindControl("lblID");
    ////    }
    ////}

    //protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    //{


    //    // wmpfile = "G:\\CompuSportLive\\compusport\\Data\\Sites\\1\\videos\\" + txtbFilePath.Text.ToString();
    //    wmpfile = "Data\\Sites\\1\\videos\\" + txtbFilePath.Text.ToString();

    //    VideoDiv.Visible = true;
    //    Label117.Text = "Click the Play button to start the video.";


    //}

}
public class FilePathClass
{
    public int Index { get; set; }

    public string FilePath { get; set; }
}