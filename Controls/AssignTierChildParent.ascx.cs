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

public partial class TrackData_AssignTierChildParent : System.Web.UI.UserControl
{
    //SiteUser currentUser;
    //MpUsers mpuser;


    TList<Customer> customer = new TList<Customer>();
    //TList<MpUsers> userslist = new TList<MpUsers>();
    //TList<CoachAthleteLookup> coachathletelist = new TList<CoachAthleteLookup>();
    //MpUsers athlete;
    //TList<Lesson> lessonlist = new TList<Lesson>();
    //Lesson lesson;

    //int parentid;

    int x;

    public Customer customerid;
    public Customer cust;
    public CustomerProfile customerprofile;

    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
   // string ConnectionString = ConfigurationManager.ConnectionStrings["compusport.Data.ConnectionString"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        bool AthleteAlreadyInList = false;
        customerid = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
        customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customerid.CustomerId)[0];


        // currentUser = SiteUtils.GetCurrentSiteUser();
        // mpuser = DataRepository.MpUsersProvider.GetByUserId(2);
        //mpuser = DataRepository.MpUsersProvider.GetByUserId(2);

        if (!IsPostBack)
        {
            //athletelist = DataRepository.MpUserRolesProvider.GetByRoleId(9);
            //userslist = DataRepository.MpUsersProvider.GetAll();
            //userslist.Sort("Name");

            customer = DataRepository.CustomerProvider.GetAll();
            customer.Sort("FirstName");
           // customer.Sort("LastName");
            //customer.Sort("FirstName" + "LastName");
            foreach (var item in customer)
            {
                //foreach (MpUserRoles a in athletelist)
                //{
                //    if (a.UserId == item.UserId)
                //{
                cust = DataRepository.CustomerProvider.GetByCustomerId(item.CustomerId);
                
                // lessonlist = DataRepository.LessonProvider.GetByUserId(athlete.UserId);
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
            //    }
            //}

        }
    }
    

    //public void Tire_Insert(string _name, int _roleid, string _athletelookup)
    //{
    //    try
    //    {
    //        //@AthleteUserId = 14,
    //        //@CoachUserId = 21
    //        using (SqlConnection connection = new SqlConnection(ConnectionString))
    //        {
    //            connection.Open();
    //            using (SqlCommand cmdDCoachAthlete = connection.CreateCommand())
    //            {
    //                cmdDCoachAthlete.CommandType = CommandType.StoredProcedure;
    //                cmdDCoachAthlete.CommandText = "Insert_Tire";
    //                //cmdDCoachAthlete.Parameters.AddWithValue("@Id", _id);
    //                cmdDCoachAthlete.Parameters.AddWithValue("@Name", _name);
    //                cmdDCoachAthlete.Parameters.AddWithValue("@RoleId", _roleid);
    //                cmdDCoachAthlete.Parameters.AddWithValue("@AthleteLookUp", _athletelookup);

    //                cmdDCoachAthlete.ExecuteNonQuery();
    //            }
    //        }
    //    }
    //    catch (Exception err)
    //    {
    //        throw err;
    //    }

    //}

    //public void TireLookUp_Insert(int _AthleteUserId, int _ParentId, string _Title)
    //{
    //    try
    //    {
    //        //@AthleteUserId = 14,
    //        //@CoachUserId = 21
    //        using (SqlConnection connection = new SqlConnection(ConnectionString))
    //        {
    //            connection.Open();
    //            using (SqlCommand cmdDCoachAthlete = connection.CreateCommand())
    //            {
    //                cmdDCoachAthlete.CommandType = CommandType.StoredProcedure;
    //                cmdDCoachAthlete.CommandText = "Insert_TireLookUp";
    //                //cmdDCoachAthlete.Parameters.AddWithValue("@Id", _id);
    //                cmdDCoachAthlete.Parameters.AddWithValue("@AthleteUserId", _AthleteUserId);
    //                cmdDCoachAthlete.Parameters.AddWithValue("@ParentId", _ParentId);
    //                cmdDCoachAthlete.Parameters.AddWithValue("@Title", _Title);

    //                cmdDCoachAthlete.ExecuteNonQuery();
    //            }
    //        }
    //    }
    //    catch (Exception err)
    //    {
    //        throw err;
    //    }

    //}

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    //    if (!DropDownList1.SelectedValue.Equals("noathlete"))
    //    {

    //        DropDownList2.Items.Clear();
    //        DataTable dt1 = new DataTable();
    //        dt1 = SelectParentall();       //get data from parenttier table
    //        DataRow dr = dt1.NewRow();
    //        dr["Tireid"] = "-1";
    //        dr["Tirename"] = "Select Parent for Athlete";


    //        dt1.Rows.InsertAt(dr, 0);
    //        DropDownList2.DataSource = dt1;
    //        DropDownList2.DataTextField = "Tirename";
    //        DropDownList2.DataValueField = "Tireid";


    //        DropDownList2.DataBind();
    //        DropDownList3.Items.Clear();
    //        DropDownList3.Items.Add("Select Child for Parent");
    //        DropDownList3.Items[0].Value = "-1";
    //    }
    //    else
    //    {
    //        DropDownList2.Items.Clear();
    //        DropDownList2.Items.Add("Select Parent for Athlete");
    //        DropDownList2.Items[0].Value = "nodate";
    //    }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
    //    parentid = Convert.ToInt32(DropDownList2.SelectedValue);

    //    if (!DropDownList2.SelectedValue.Equals("nodate"))
    //    {
    //        int AthleteSelected;

    //        AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);

    //        mpuser = DataRepository.MpUsersProvider.GetByUserId(AthleteSelected);

    //        DropDownList3.Items.Clear();
    //        DataTable dt2 = new DataTable();
    //        dt2 = SelectChildAll(parentid);                          //get data from "childtire" table
    //        DataRow dr = dt2.NewRow();
    //        dr["ChildId"] = "-1";
    //        dr["ChildTitle"] = "Select Child for Parent";
    //        dt2.Rows.InsertAt(dr, 0);                                //rows are inserted as "-1" and "select child for parent" at 0th rows  
    //        DropDownList3.DataSource = dt2;
    //        DropDownList3.DataTextField = "ChildTitle";
    //        DropDownList3.DataValueField = "ChildId";
    //        DropDownList3.DataBind();
    //    }
    //    else
    //    {
    //        DropDownList3.Items.Clear();
    //        DropDownList3.Items.Add("Select Child for Parent");
    //        DropDownList3.Items[0].Value = "nodate";
    //    }
    //    try
    //    {

    //        object ChildID;
    //        int ChildID1 = 0;
    //        int Selectedparentid = Convert.ToInt32(DropDownList2.SelectedValue);

    //        ChildID = GetChildID(mpuser.UserId, Selectedparentid);


    //        //parentid=Convert.ToInt32(DropDownList2.SelectedValue);

    //        if (ChildID != null)
    //        {

    //            DropDownList3.SelectedValue = ChildID.ToString();
    //        }
    //        else
    //        {
    //            DropDownList3.SelectedValue = "-1";

    //        }




    //        //Response.Write("<script language='javascript'>alert('UserId:"+ mpuser.UserId.ToString()+ " .');</script>");


    //    }
    //    catch { }

    }

    protected void btnAddAthleteTier_Click(object sender, EventArgs e)
    {
    //    int Selectedparentid = Convert.ToInt32(DropDownList2.SelectedValue);
    //    try
    //    {
    //        if (DropDownList1.SelectedValue != "noathlete")
    //        {
    //            if (DropDownList2.SelectedValue != "-1")
    //            {
    //                int AthleteSelected;

    //                AthleteSelected = Convert.ToInt16(DropDownList1.SelectedValue);

    //                mpuser = DataRepository.MpUsersProvider.GetByUserId(AthleteSelected);

    //                object ChildID = null;

    //                ChildID = GetChildID(mpuser.UserId, Selectedparentid);

    //                int Userid = Convert.ToInt32(DropDownList1.SelectedValue);

    //                int parentid = Convert.ToInt32(DropDownList2.SelectedValue);
    //                int Childid = Convert.ToInt32(DropDownList3.SelectedValue);
    //                if (Childid == -1)
    //                {
    //                    Response.Write("<script language='javascript'>alert('Please Select Child .');</script>");

    //                }
    //                else if (ChildID == null)
    //                {
    //                    Insert_IntoAthleteInfo(Userid, parentid, Childid);
    //                }
    //                else
    //                {
    //                    Update_IntoAthleteInfo(Userid, parentid, Childid);
    //                }



    //                DropDownList1.SelectedValue = "noathlete";
    //                DropDownList2.SelectedValue = "-1";
    //                DropDownList3.SelectedValue = "-1";
    //            }
    //            else
    //            {
    //                Response.Write("<script language='javascript'>alert('Please Select Parent .');</script>");

    //            }
    //        }
    //        else
    //        {
    //            Response.Write("<script language='javascript'>alert('Please Select An Athlete .');</script>");

    //        }

    //    }
    //    catch { }


    }


    ////old
    ////public object GetChildID(object __userid)
    ////{
    ////    try
    ////    {
    ////        object ChilId;
    ////        using (SqlConnection connection = new SqlConnection(ConnectionString))
    ////        {
    ////            connection.Open();
    ////            using (SqlCommand cmdupdate = connection.CreateCommand())
    ////            {
    ////                cmdupdate.CommandType = CommandType.StoredProcedure;
    ////                cmdupdate.CommandText = "SelectChildIDofUser";
    ////                cmdupdate.Parameters.AddWithValue("@UserId", __userid);
    ////                ChilId = cmdupdate.ExecuteScalar();
    ////                return ChilId;
    ////            }

    ////        }

    ////    }
    ////    catch (Exception err)
    ////    {
    ////        return err;
    ////    }
    ////}


    //public object GetChildID(int Userid, int Parentid)
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
    //                cmdupdate.Parameters.AddWithValue("@UserId", Userid);
    //                cmdupdate.Parameters.AddWithValue("@Parentid", Parentid);
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








    ////public void Update_UsertblWithTierChild(int Userid, int Parentid, int Childid)
    ////{
    ////    try
    ////    {
    ////        //@AthleteUserId = 14,
    ////        //@CoachUserId = 21
    ////        using (SqlConnection connection = new SqlConnection(ConnectionString))
    ////        {
    ////            connection.Open();
    ////            using (SqlCommand cmdupdate = connection.CreateCommand())
    ////            {
    ////                cmdupdate.CommandType = CommandType.StoredProcedure;
    ////                cmdupdate.CommandText = "Insert_AthletInfo";
    ////                cmdupdate.Parameters.AddWithValue("@Userid", Userid);
    ////                cmdupdate.Parameters.AddWithValue("@Parentid", Parentid);
    ////                cmdupdate.Parameters.AddWithValue("@ChildiD", Childid);

    ////                cmdupdate.ExecuteNonQuery();
    ////            }
    ////        }
    ////    }
    ////    catch (Exception err)
    ////    {
    ////        throw err;
    ////    }

    ////}
    //public void Insert_IntoAthleteInfo(int Userid, int Parentid, int Childid)
    //{
    //    try
    //    {
    //        //@AthleteUserId = 14,
    //        //@CoachUserId = 21
    //        using (SqlConnection connection = new SqlConnection(ConnectionString))
    //        {
    //            connection.Open();
    //            using (SqlCommand cmdupdate = connection.CreateCommand())
    //            {
    //                cmdupdate.CommandType = CommandType.StoredProcedure;
    //                cmdupdate.CommandText = "Insert_AthletInfo";
    //                cmdupdate.Parameters.AddWithValue("@Userid", Userid);
    //                cmdupdate.Parameters.AddWithValue("@Parentid", Parentid);
    //                cmdupdate.Parameters.AddWithValue("@ChildiD", Childid);

    //                cmdupdate.ExecuteNonQuery();
    //            }
    //        }
    //    }
    //    catch (Exception err)
    //    {
    //        throw err;
    //    }

    //}
    //public void Update_IntoAthleteInfo(int Userid, int Parentid, int Childid)
    //{
    //    try
    //    {
    //        //@AthleteUserId = 14,
    //        //@CoachUserId = 21
    //        using (SqlConnection connection = new SqlConnection(ConnectionString))
    //        {
    //            connection.Open();
    //            using (SqlCommand cmdupdate = connection.CreateCommand())
    //            {
    //                cmdupdate.CommandType = CommandType.StoredProcedure;
    //                cmdupdate.CommandText = "Update_AthletInfo";
    //                cmdupdate.Parameters.AddWithValue("@Userid", Userid);
    //                cmdupdate.Parameters.AddWithValue("@Parentid", Parentid);
    //                cmdupdate.Parameters.AddWithValue("@ChildiD", Childid);

    //                cmdupdate.ExecuteNonQuery();
    //            }
    //        }
    //    }
    //    catch (Exception err)
    //    {
    //        throw err;
    //    }

    //}


    //public DataTable SelectParentall()
    //{
    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        using (SqlConnection connection = new SqlConnection(ConnectionString))
    //        {
    //            connection.Open();
    //            using (SqlCommand cmdSelectTire = connection.CreateCommand())
    //            {
    //                cmdSelectTire.CommandType = CommandType.StoredProcedure;
    //                cmdSelectTire.CommandText = "SelectAll_TireParent";
    //                cmdSelectTire.Connection = connection;
    //                SqlDataAdapter da = new SqlDataAdapter(cmdSelectTire);
    //                da.Fill(dt);
    //                return dt;
    //            }
    //        }
    //    }
    //    catch
    //    {
    //        return dt = null;
    //    }
    //}

    //public DataTable SelectChildAll(int Parentid)
    //{
    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        using (SqlConnection connection = new SqlConnection(ConnectionString))
    //        {
    //            connection.Open();
    //            using (SqlCommand cmdchildTire = connection.CreateCommand())
    //            {
    //                cmdchildTire.CommandType = CommandType.StoredProcedure;
    //                cmdchildTire.CommandText = "SelectAll_TireChildAll";

    //                cmdchildTire.Parameters.AddWithValue("@TireId", Parentid);
    //                cmdchildTire.ExecuteNonQuery();

    //                cmdchildTire.Connection = connection;
    //                SqlDataAdapter da = new SqlDataAdapter(cmdchildTire);
    //                da.Fill(dt);
    //                return dt;
    //            }
    //        }
    //    }
    //    catch
    //    {
    //        return dt = null;
    //    }
    //}

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
    //    //DropDownList2.Visible = false;
    //    //btndateloc.Visible = false;

    //    if (!DropDownList3.SelectedValue.Equals("nodate"))
    //    { }
    }



}


