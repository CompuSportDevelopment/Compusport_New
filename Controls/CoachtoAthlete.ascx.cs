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
//using System.Windows.Forms;
using System.IO;
using SwingModel.Data;
using SwingModel.Entities;
using System.Data.SqlClient;


public partial class TrackData_CoachtoAthlete : System.Web.UI.UserControl
{
    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    CompuSportDAL.SprintAthleteEdit sae = new CompuSportDAL.SprintAthleteEdit();

    public Customer customerid;
    Customer cust;
    public CustomerProfile customerprofile;
    TList<Customer> customer = new TList<Customer>();
    TList<Lesson> lessonlist = new TList<Lesson>();
    TList<Teacher> teach = new TList<Teacher>();
    TList<TeacherSite> lstTecherSite = new TList<TeacherSite>();
    Movie m_vid;
    Teacher teacher;
    DataTable dt = new DataTable();
    bool customerprofileexists = false;


    //SiteUser currentUser;
    //MpUsers mpuser;
    // compusport.Entities.
    compusport.Entities.CoachAthleteLookup cal = new compusport.Entities.CoachAthleteLookup();
    //MpUsers athlete;
    compusport.Entities.TList<compusport.Entities.CoachAthleteLookup> coachathletelist = new compusport.Entities.TList<compusport.Entities.CoachAthleteLookup>();
    //TList<Lesson> lessonlist = new TList<Lesson>();
    //TList<MpUserRoles> mpusercoachroles = new TList<MpUserRoles>();
    //TList<MpUserRoles> mpuserathletehroles = new TList<MpUserRoles>();
    //TList<MpUsers> allusers = new TList<MpUsers>();
    int x;
    int TeacherId;
    int Y;
    public string wmpfile = "";
    bool InitialExists = false;
    bool CurrentExists = false;
    bool AthleteAlreadyInList = false;
    bool AlreadyAthlete = false;
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

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList2.Items.Clear();
        DataTable dt1 = new DataTable();
        dt1 = sae.GetAllTeachers();
        DataRow dr = dt1.NewRow();
        dr["FullName"] = "Select Coach for Athlete";
        dr["TeacherId"] = 0;
        dt1.Rows.InsertAt(dr, 0);
        DropDownList2.DataSource = dt1;
        DropDownList2.DataTextField = "FullName";
        DropDownList2.DataValueField = "TeacherId";
        DropDownList2.DataBind();
        DropDownList2.SelectedIndex = 0;


        DataRow dr1 = dt1.NewRow();
        dr["FullName"] = "Select Primary Coach for Athlete";
        dr["TeacherId"] = 0;
        ddlPrimaryCoach.DataSource = dt1;
        ddlPrimaryCoach.DataTextField = "FullName";
        ddlPrimaryCoach.DataValueField = "TeacherId";
        ddlPrimaryCoach.DataBind();
        ddlPrimaryCoach.SelectedIndex = 0;

        lblmsg.Text = "";


        GridDisplay();
        GridPrimaryRoleBind(Convert.ToInt16(DropDownList1.SelectedValue));

        #region[old code]
        //if (AthleteView.Rows.Count > 0)
        //{
        //    btnAdd.Visible = true;
        //}
        //else
        //{
        //    btnAdd.Visible = false;
        //}
        //if (grdPrimaryCoach.Rows.Count > 0)
        //{
        //    btnaddPrimaryCoach.Visible = true;
        //}
        //else
        //{
        //    btnaddPrimaryCoach.Visible = false;
        //}

        //    //if (athlete != null)
        //    //{
        //    //}

        // DropDownList2.SelectedValue = "nodate";
        //Y = 0;
        //teach = DataRepository.TeacherProvider.GetAll();
        //foreach (Teacher _teacher in teach)
        //{
        //    if (DropDownList2.Items.Count > 0)
        //    {
        //    if (DropDownList2.Items.Contains(DropDownList2.Items.FindByValue(_teacher.TeacherId.ToString())))

        //        AthleteAlreadyInList = true;
        //       else
        //        AthleteAlreadyInList = false;               
        //    }
        //    if (!AthleteAlreadyInList)
        //    {
        //        Y++;
        //        DropDownList2.Items.Add(teacher.FirstName + "" + teacher.LastName);
        //        //mpuser = DataRepository.MpUsersProvider.GetByUserId(ah.UserId);
        //        //DropDownList2.Items.Add(mpuser.Name);
        //        DropDownList2.Items[Y].Value = teacher.TeacherId.ToString();
        //    }

        //}

        //else
        // {
        //     DropDownList2.Items.Clear();
        //     DropDownList2.Items.Add("Select Athlete to Add");
        //     DropDownList2.Items[0].Value = "nodate";
        // }


        //    DropDownList2.SelectedValue = "nodate";
        //    Y = 0;
        //    allusers = DataRepository.MpUsersProvider.GetAll();
        //    allusers.Sort("Name ASC");
        //    foreach (MpUsers user in allusers)
        //    {

        //        foreach (MpUserRoles ah in mpuserathletehroles)
        //        {
        //            if (user.UserId == ah.UserId)
        //            {
        //                athlete = DataRepository.MpUsersProvider.GetByUserId(ah.UserId);

        //                if (DropDownList2.Items.Count > 0)
        //                {
        //                    if (DropDownList2.Items.Contains(DropDownList2.Items.FindByValue(athlete.UserId.ToString())))
        //                        AthleteAlreadyInList = true;
        //                    else
        //                        AthleteAlreadyInList = false;
        //                }

        //                if (!AthleteAlreadyInList)
        //                {
        //                    Y++;
        //                    mpuser = DataRepository.MpUsersProvider.GetByUserId(ah.UserId);
        //                    DropDownList2.Items.Add(mpuser.Name);
        //                    DropDownList2.Items[Y].Value = mpuser.UserId.ToString();
        //                }
        //            }
        //        }
        //    }
        //}
        //else
        //{
        //    DropDownList2.Items.Clear();
        //    DropDownList2.Items.Add("Select Athlete to Add");
        //    DropDownList2.Items[0].Value = "nodate";
        //}
        #endregion[old code]
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        btnAdd.Visible = true;
    }

    protected void ddlPrimaryCoach_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        btnaddPrimaryCoach.Visible = true;
    }

    //protected void btnAdd_Click(object sender, EventArgs e)
    //{
    //    CoachAthleteLookup tblcoachathletelookup = new CoachAthleteLookup();
    //    int CoachSelected;
    //    CoachSelected = Convert.ToInt16(DropDownList1.SelectedValue);
    //    int AthleteSelected;
    //    try
    //    {
    //        AthleteSelected = Convert.ToInt16(DropDownList2.SelectedValue);
    //        tblcoachathletelookup.AthleteUserId = AthleteSelected;
    //        tblcoachathletelookup.CoachUserId = CoachSelected;
    //        DataRepository.CoachAthleteLookupProvider.Insert(tblcoachathletelookup);
    //    }
    //    catch { }

    //    //lblmsg.Text = "Athlete is Associated with Coach";
    //    for (int i = 0; i < AthleteView.Rows.Count; i++)
    //    {
    //        int Athleteid = (int)AthleteView.DataKeys[i][0];
    //        CheckBox cb = (CheckBox)AthleteView.Rows[i].FindControl("CheckBoxPurchase");
    //        if (!cb.Checked)
    //        {
    //            CoachAthleteLookup coachthleteLookup = new CoachAthleteLookup();
    //            // coachthleteLookup = DataRepository.CoachAthleteLookupProvider.GetByAthleteUserId(Athleteid)[0];
    //            coachthleteLookup = DataRepository.CoachAthleteLookupProvider.GetByCoachUserId(CoachSelected)[0];
    //            sae.Data_Delete(Athleteid, CoachSelected);
    //            // DataRepository.CoachAthleteLookupProvider.Delete(coachthleteLookup);
    //        }
    //    }
    //    DropDownList1_SelectedIndexChanged(null, null);
    //    //GridDisplay();
    //    //DropDownList1.SelectedValue = "noathlete";
    //    //DropDownList2.SelectedValue = "nodate";
    //}


    //assigning secondary coaches
    protected void btnAdd_Click(object sender, EventArgs e)
    {
       
        lblmsg.Text = "";
        try
        {
            int _athletId = Convert.ToInt16(DropDownList1.SelectedValue);
            if (DropDownList2.SelectedIndex > 0)
            {
                if (Convert.ToInt16(DropDownList2.SelectedValue) != 0)
                {
                    int _CoachId;
                    _CoachId = Convert.ToInt16(DropDownList2.SelectedValue);
                    if (DropDownList2.SelectedValue != "nodate" && AthleteView.Rows.Count > 0)
                    {
                        for (int i = 0; i < AthleteView.Rows.Count; i++)
                        {
                            TeacherId = (int)AthleteView.DataKeys[i][0];
                            if (_CoachId == TeacherId)
                            {
                                lblmsg.Text = "Athlete you selected is already associated with this coach";
                                AlreadyAthlete = true;
                                break;
                            }
                        }
                    }
                    if (!AlreadyAthlete || AthleteView.Rows.Count == 0)
                    {
                        sae.InsertIntoAssignAthleteCoach(_athletId, _CoachId);                      

                    }
                }
            }
            for (int i = 0; i < AthleteView.Rows.Count; i++)
            {
                int TeacherId = (int)AthleteView.DataKeys[i][0];
                CheckBox cb = (CheckBox)AthleteView.Rows[i].FindControl("CheckBoxPurchase");
                if (!cb.Checked)
                {
                    // CoachAthleteLookup coachthleteLookup = new CoachAthleteLookup();
                    sae.Data_Delete(_athletId, TeacherId);
                    // coachthleteLookup = DataRepository.CoachAthleteLookupProvider.GetByCoachUserId(CoachSelected)[0];
                    // Data_Delete(Athleteid, CoachSelected);
                }
            }
            // DropDownList1_SelectedIndexChanged(null, null);

            GridDisplay();
            UpdatePanel2.Update();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

        //old data

        //  lblmsg.Text = "";
        //int CoachSelected;
        //CoachSelected = Convert.ToInt16(DropDownList1.SelectedValue);
        //try
        //{
        //    CoachAthleteLookup tblcoachathletelookup = new CoachAthleteLookup();

        //    int AthleteSelected;
        //    AthleteSelected = Convert.ToInt16(DropDownList2.SelectedValue);

        //    if (DropDownList2.SelectedValue != "nodate" && AthleteView.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < AthleteView.Rows.Count; i++)
        //        {
        //            int Athleteid = (int)AthleteView.DataKeys[i][0];
        //            if (AthleteSelected == Athleteid)
        //            {
        //                lblmsg.Text = "Athlete you selected is already associated with this coach";
        //                AlreadyAthlete = true;
        //            }

        //        }
        //    }
        //    if (!AlreadyAthlete || AthleteView.Rows.Count == 0)
        //    {
        //        tblcoachathletelookup.AthleteUserId = AthleteSelected;
        //        tblcoachathletelookup.CoachUserId = CoachSelected;
        //        DataRepository.CoachAthleteLookupProvider.Insert(tblcoachathletelookup);

        //    }



        //    for (int i = 0; i < AthleteView.Rows.Count; i++)
        //    {
        //        int Athleteid = (int)AthleteView.DataKeys[i][0];
        //        CheckBox cb = (CheckBox)AthleteView.Rows[i].FindControl("CheckBoxPurchase");
        //        if (!cb.Checked)
        //        {
        //            CoachAthleteLookup coachthleteLookup = new CoachAthleteLookup();
        //            coachthleteLookup = DataRepository.CoachAthleteLookupProvider.GetByCoachUserId(CoachSelected)[0];
        //            Data_Delete(Athleteid, CoachSelected);
        //        }
        //    }
        //    DropDownList1_SelectedIndexChanged(null, null);
        //    UpdatePanel2.Update();
        //}
        //catch (Exception ex)
        //{
        //    ex.Message.ToString();
        //}
    }

    private void GetCoachAthleteid(int coachid, int athleteid)
    {
    }
    private void GridDisplay()
    {
        DropDownList2.Items.Clear();
        DataTable dt1 = new DataTable();
        dt1 = sae.GetCoaches();
        DataRow dr = dt1.NewRow();
        // dr["FullName"] = "-1";
        dr["FullName"] = "Select Coach for Athlete";
        dt1.Rows.InsertAt(dr, 0);
        DropDownList2.DataSource = dt1;
        DropDownList2.DataBind();

        int AthleteSelected;
        AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);

        x = 0;
        DataTable t = new DataTable();
        t.Columns.Add(new DataColumn("TeacherId", typeof(int)));
        t.Columns.Add(new DataColumn("CoachName", typeof(string)));

        DataTable table = sae.GetCoachesForAthlete(AthleteSelected);
        foreach (DataRow row in table.Rows)
        {
            int teacherId = 0;
            teacherId = Convert.ToInt16(row[2]);

            teacher = DataRepository.TeacherProvider.GetByTeacherId(teacherId);
            DataRow r = t.NewRow();
            r["TeacherId"] = teacher.TeacherId.ToString();
            r["CoachName"] = teacher.FirstName + " " + teacher.LastName;
            t.Rows.Add(r);

        }

        DataTable AthleteData = t;
        AthleteView.DataSource = AthleteData;
        AthleteView.DataBind();


        for (int i = 0; i < AthleteView.Rows.Count; i++)
        {
            int productId = (int)AthleteView.DataKeys[i][0];
            CheckBox cb = (CheckBox)AthleteView.Rows[i].FindControl("CheckBoxPurchase");
            cb.Checked = true;
        }

        if (AthleteView.Rows.Count > 0)
        {
            btnAdd.Visible = true;
        }
        else
        {
            btnAdd.Visible = false;
        }


    }
    
    private void GridPrimaryRoleBind(int _athletId)
    {

        ddlPrimaryCoach.Items.Clear();
        DataTable dt1 = new DataTable();
        dt1 = sae.GetCoaches();
        DataRow dr = dt1.NewRow();
        // dr["FullName"] = "-1";
        dr["FullName"] = "Select Primary Coach for Athlete";
        dt1.Rows.InsertAt(dr, 0);
        ddlPrimaryCoach.DataSource = dt1;
        ddlPrimaryCoach.DataBind();

        int AthleteSelected;
        AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);
        x = 0;
        DataTable t = new DataTable();
        t.Columns.Add(new DataColumn("TeacherId", typeof(int)));
        t.Columns.Add(new DataColumn("CoachName", typeof(string)));

        DataTable table = sae.GetPrimaryCoachesForAthlete(_athletId);
        foreach (DataRow row in table.Rows)
        {
            int teacherId = 0;
            teacherId = Convert.ToInt16(row[2]);

            teacher = DataRepository.TeacherProvider.GetByTeacherId(teacherId);
            DataRow r = t.NewRow();
            r["TeacherId"] = teacher.TeacherId.ToString();
            r["CoachName"] = teacher.FirstName + " " + teacher.LastName;
            t.Rows.Add(r);
        }

        DataTable AthleteData = t;
        grdPrimaryCoach.DataSource = AthleteData;
        grdPrimaryCoach.DataBind();
        for (int i = 0; i < grdPrimaryCoach.Rows.Count; i++)
        {
            int productId = (int)grdPrimaryCoach.DataKeys[i][0];
            CheckBox cb = (CheckBox)grdPrimaryCoach.Rows[i].FindControl("CheckBoxPurchase");
            cb.Checked = true;
        }
        if (grdPrimaryCoach.Rows.Count > 0)
        {
            btnaddPrimaryCoach.Visible = true;
        }
        else
        {
            btnaddPrimaryCoach.Visible = false;
        }
    }

    protected void btnaddPrimaryCoach_Click(object sender, EventArgs e)
    {
        lblPrimaryMessage.Text = "";
        try
        {
            int _athletId = Convert.ToInt16(DropDownList1.SelectedValue);
            if (ddlPrimaryCoach.SelectedIndex > 0)
            {
                if (Convert.ToInt16(ddlPrimaryCoach.SelectedValue) != 0)
                {
                    int _CoachId;
                    _CoachId = Convert.ToInt16(ddlPrimaryCoach.SelectedValue);
                    TList<TeacherSite> lstTecherSite = DataRepository.TeacherSiteProvider.GetAll();
                    customerprofile = null;
                    try
                    {
                        customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(_athletId)[0];
                        customerprofileexists = true;
                    }
                    catch
                    {
                        customerprofile = new CustomerProfile();
                        //no entery in CustomerProfile table for current member
                        customerprofileexists = false;
                    }
                    foreach (TeacherSite ts in lstTecherSite)
                    {
                        if (ts.TeacherId == _CoachId)
                        {
                            customerprofile.CustomerSite = ts.SiteId;
                            break;
                        }
                    }
                    if (ddlPrimaryCoach.SelectedValue != "nodate" && grdPrimaryCoach.Rows.Count > 0)
                    {
                        sae.UpdateAssignPrimaryCoach(_athletId, _CoachId);
                        if (customerprofileexists)
                        {
                            customerprofile.Teacher = _CoachId;                           
                            DataRepository.CustomerProfileProvider.Update(customerprofile);
                        }
                        else
                        {
                            customerprofile.Teacher = _CoachId;
                            customerprofile.CustomerId = _athletId;
                            DataRepository.CustomerProfileProvider.Insert(customerprofile);
                        }
                        AlreadyAthlete = true;
                    }
                    if (!AlreadyAthlete || grdPrimaryCoach.Rows.Count == 0)
                    {
                        sae.InsertIntoAssignPrimaryCoach(_athletId, _CoachId);
                       
                        if (customerprofileexists)
                        {
                            customerprofile.Teacher = _CoachId;
                            customerprofile.CustomerId = _athletId;
                            DataRepository.CustomerProfileProvider.Update(customerprofile);
                        }
                        else
                        {
                            customerprofile.Teacher = _CoachId;
                            customerprofile.CustomerId = _athletId;
                            DataRepository.CustomerProfileProvider.Insert(customerprofile);
                        }
                    }
                }
            }
            for (int i = 0; i < grdPrimaryCoach.Rows.Count; i++)
            {
                int TeacherId = (int)grdPrimaryCoach.DataKeys[i][0];
                CheckBox cb = (CheckBox)grdPrimaryCoach.Rows[i].FindControl("CheckBoxPurchase");
                if (!cb.Checked)
                {
                    sae.Delete_PrimaaryCoach(_athletId, TeacherId);
                }
            }
            GridPrimaryRoleBind(_athletId);
            UpdatePanel5.Update();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }


    }


   
}

