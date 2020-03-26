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
using CompuSportDAL;


//public partial class Teachers_MemberList : System.Web.UI.Page
public partial class Teachers_MemberList : SwingModel.UI.BasePage
{
    public Customer customer;
    public CustomerProfile customerprofile;
    public TList<TeacherSite> teachersatsite = new TList<TeacherSite>();
    public Teacher teacher;
    public CustomerSite customersite;
    SprintAthleteEdit _sprintAthleteEdit = new SprintAthleteEdit();
    bool isTeacherExist = false;
    bool isCustomerExist = false;
    string[] roles = Roles.GetAllRoles();
    Customer AthleteSearched;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                teacher = DataRepository.TeacherProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
                isTeacherExist = true;
            }
            catch
            {
                //customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
                //customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customer.CustomerId)[0];
                //isCustomerExist = true;
            }

            CustomerSite siteid;
            int x = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("Count", typeof(int));
            dt.Columns.Add("First Name", typeof(string));
            dt.Columns.Add("Last Name", typeof(string));

            dt.Columns.Add("Email Address", typeof(string));
            dt.Columns.Add("Facility", typeof(string));
            dt.Columns.Add("ExpirationDate", typeof(string));
            dt.Columns.Add("TeacherType", typeof(int));
            dt.Columns.Add("Tier", typeof(int));
            try
            {
                //DataTable dtathlets = _sprintAthleteEdit.GetPrimarySecondaryAthlets_Coach(teacher.TeacherId);
                DataTable dtathlets = _sprintAthleteEdit.GetPrimaryAthletsCoach(teacher.TeacherId);
                DataTable dtathlets1 = _sprintAthleteEdit.GetSecondaryAthlets_Coach(teacher.TeacherId);
                
                #region[Primary Coach Data]
                if (dtathlets != null)
                {
                    foreach (DataRow row in dtathlets.Rows)
                    {
                        DataRow r = dt.NewRow();
                       
                        string userrolename = string.Empty;
                        int customerid = Convert.ToInt32(row["CustomerId"]);
                        AthleteSearched = DataRepository.CustomerProvider.GetByCustomerId(customerid);
                        Guid MemGuid = new Guid(AthleteSearched.AspnetMembershipUserId.ToString());
                        MembershipUser user = Membership.GetUser(MemGuid);
                        string[] userrole = Roles.GetRolesForUser(user.UserName);
                        userrolename = userrole[0];
                        if (userrolename == "Athletes")
                        {                           
                            string custid = row["CustomerId"].ToString();
                            x++;
                            r["First Name"] = row["FirstName"].ToString();
                            r["Last Name"] = row["LastName"].ToString();
                            r["Email Address"] = row["Email"].ToString();

                            DateTime date = new DateTime();
                            date = Convert.ToDateTime(row["MemberShipExpiration"]);
                            string onlydate = date.Month + "/" + date.Day + "/" + date.Year;
                            r["ExpirationDate"] = onlydate;
                            // r["Status"] = row["MemberShipStatus"].ToString();
                            r["Count"] = x.ToString();
                            customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(Convert.ToInt16(custid))[0];
                            siteid = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(customerprofile.CustomerSite);
                            r["Facility"] = siteid.SiteName.ToString();
                            if (!string.IsNullOrEmpty(customerprofile.InitialTeacher.ToString()))
                            {
                                r["Tier"] = customerprofile.InitialTeacher;
                            }
                            else
                            {
                                r["Tier"] = Convert.ToInt16(null);
                            }
                            r["TeacherType"] = 1;
                            siteid = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(customerprofile.CustomerSite);
                            r["Facility"] = siteid.SiteName.ToString();
                            dt.Rows.Add(r);
                        }
                       
                    }
                }
                #endregion[Primary Coach Data]
                #region[Secondary Coach Data]
                if (dtathlets1 != null)
                {
                    foreach (DataRow row in dtathlets1.Rows)
                    {
                        DataRow r = dt.NewRow();
                        string userrolename1 = string.Empty;
                        int customerid1 = Convert.ToInt32(row["CustomerId"]);
                        AthleteSearched = DataRepository.CustomerProvider.GetByCustomerId(customerid1);
                        Guid MemGuid1 = new Guid(AthleteSearched.AspnetMembershipUserId.ToString());
                        MembershipUser user1 = Membership.GetUser(MemGuid1);
                        string[] userrole1 = Roles.GetRolesForUser(user1.UserName);
                        userrolename1 = userrole1[0];
                        if (userrolename1 == "Athletes")
                        {
                            string custid = row["CustomerId"].ToString();
                            x++;
                            r["First Name"] = row["FirstName"].ToString();
                            r["Last Name"] = row["LastName"].ToString();
                            r["Email Address"] = row["Email"].ToString();

                            DateTime date = new DateTime();
                            date = Convert.ToDateTime(row["MemberShipExpiration"]);
                            string onlydate = date.Month + "/" + date.Day + "/" + date.Year;
                            r["ExpirationDate"] = onlydate;
                            //r["Status"] = row["MemberShipStatus"].ToString();
                            r["Count"] = x.ToString();
                            customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(Convert.ToInt16(custid))[0];
                            if (!string.IsNullOrEmpty(customerprofile.InitialTeacher.ToString()))
                            {
                                r["Tier"] = customerprofile.InitialTeacher;//tier number of athlete
                            }
                            else
                            {
                                r["Tier"] = Convert.ToInt16(null);
                            }
                            r["TeacherType"] = 2;
                            siteid = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(customerprofile.CustomerSite);
                            r["Facility"] = siteid.SiteName.ToString();
                            dt.Rows.Add(r);
                        }
                    }
                }
                #endregion[Secondary Coach Data]
            }
            catch
            {
            }
            DataTable AthleteData = dt;
            GridView1.DataSource = AthleteData;
            GridView1.DataBind();
        }
    }
    //        customersite = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(customerprofile.CustomerSite);
    //        //Label1.Text = customersite.SiteName;

    //        teachersatsite = DataRepository.TeacherSiteProvider.GetBySiteId(customerprofile.CustomerSite);
    //        teachersatsite.Sort("TeacherId ASC");
    //        if (DropDownList1.Items.Count.Equals(0))
    //        {
    //            DropDownList1.Items.Clear();
    //            string logusrname = User.Identity.Name;
    //            DropDownList1.Items.Add(logusrname.ToString());
    //            DropDownList1.Items[0].Value = "1";
    //            DropDownList1_SelectedIndexChanged(this, null);
    //        }

    //        //if (DropDownList1.Items.Count.Equals(0))
    //        //{
    //        //    DropDownList1.Items.Clear();
    //        //    DropDownList1.Items.Add("Make a Selection");
    //        //    DropDownList1.Items[0].Value = "-1";
    //        //    DropDownList1.Items.Add("All Teachers");
    //        //    DropDownList1.Items[1].Value = "0";
    //        //    int x = 1;
    //        //    foreach (TeacherSite ts in teachersatsite)
    //        //    {
    //        //        x++;
    //        //        teacher = DataRepository.TeacherProvider.GetByTeacherId(ts.TeacherId);
    //        //        DropDownList1.Items.Add(teacher.FirstName + " " + teacher.LastName);
    //        //        DropDownList1.Items[x].Value = teacher.TeacherId.ToString();
    //        //    }
    //        //}
    //    }
    //}

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    //    //int SelectedTeacherId = Convert.ToInt16(DropDownList1.SelectedValue);
    //    int SelectedTeacherId = Convert.ToInt16(teacher.TeacherId);

    //    TList<CustomerProfile> customerprofiles = new TList<CustomerProfile>();
    //    int x = 0;
    //    DataTable dt = new DataTable();
    //    dt.Columns.Add("Count", typeof(int));
    //    dt.Columns.Add("First Name", typeof(string));
    //    dt.Columns.Add("Last Name", typeof(string));
    //    dt.Columns.Add("Email Address", typeof(string));
    //    dt.Columns.Add("Facility", typeof(string));
    //    dt.Columns.Add("ExpirationDate", typeof(string));
    //    dt.Columns.Add("Status", typeof(string));
    //    string StatusText = "";

    //    if (SelectedTeacherId.Equals(-1))
    //    {
    //        //Do Nothing
    //        GridView1.Visible = false;
    //    }
    //    else if (SelectedTeacherId.Equals(0))
    //    {
    //        GridView1.Visible = true;
    //        foreach (TeacherSite ts in teachersatsite)
    //        {
    //            Teacher teach = DataRepository.TeacherProvider.GetByTeacherId(ts.TeacherId);
    //            customerprofiles = DataRepository.CustomerProfileProvider.GetByTeacher(teach.TeacherId);
    //            customersite = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(customerprofile.CustomerSite);
    //            foreach (CustomerProfile cp in customerprofiles)
    //            {
    //                x++;
    //                Customer cus = DataRepository.CustomerProvider.GetByCustomerId(cp.CustomerId);
    //                Guid MemGuid = new Guid(cus.AspnetMembershipUserId.ToString());
    //                MembershipUser user = Membership.GetUser(MemGuid);
    //                customersite = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(cp.CustomerSite);

    //                StatusText = "";
    //                switch (cus.MembershipStatus)
    //                {
    //                    case 0:
    //                        StatusText = "Expired";
    //                        break;

    //                    case 1:
    //                        StatusText = "Member";
    //                        break;

    //                    case 2:
    //                        StatusText = "FullTeach";
    //                        break;

    //                    case 3:
    //                        StatusText = "FullFit";
    //                        break;

    //                    case 4:
    //                        StatusText = "FullTeachFit";
    //                        break;

    //                    case 97:
    //                        StatusText = "CompTeach";
    //                        break;

    //                    case 98:
    //                        StatusText = "CompFit";
    //                        break;

    //                    case 99:
    //                        StatusText = "CompTeachFit";
    //                        break;

    //                    default:
    //                        StatusText = "Missing";
    //                        break;
    //                }
    //                DateTime date = new DateTime();
    //                date = cus.MembershipExpiration;
    //                string onlydate = date.Month + "/" + date.Day + "/" + date.Year;
    //                if (cp.CustomerSite.Equals(customersite.CustomerSiteId) && user != null)
    //                    dt.Rows.Add(x, cus.FirstName, cus.LastName, user.Email, customersite.SiteName, onlydate, StatusText);
    //            }
    //        }
    //        dt.DefaultView.Sort = "Last Name ASC, First Name ASC, Facility ASC";
    //        x = 0;
    //        foreach (DataRowView row in dt.DefaultView)
    //        {
    //            x++;
    //            row.Row.SetField("Count", x);
    //        }
    //        GridView1.DataSource = dt;
    //        GridView1.DataBind();
    //    }
    //    else
    //    {
    //        GridView1.Visible = true;
    //        Teacher teach = DataRepository.TeacherProvider.GetByTeacherId(SelectedTeacherId);
    //        customerprofiles = DataRepository.CustomerProfileProvider.GetByTeacher(SelectedTeacherId);
    //        customersite = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(customerprofile.CustomerSite);
    //        foreach (CustomerProfile cp in customerprofiles)
    //        {
    //            if (cp.CustomerProfileId != cp.Teacher)
    //            {
    //                x++;
    //                Customer cus = DataRepository.CustomerProvider.GetByCustomerId(cp.CustomerId);
    //                Guid MemGuid = new Guid(cus.AspnetMembershipUserId.ToString());
    //                MembershipUser user = Membership.GetUser(MemGuid);
    //                customersite = DataRepository.CustomerSiteProvider.GetByCustomerSiteId(cp.CustomerSite);

    //                StatusText = "";
    //                switch (cus.MembershipStatus)
    //                {
    //                    case 0:
    //                        StatusText = "Expired";
    //                        break;

    //                    case 1:
    //                        StatusText = "Member";
    //                        break;

    //                    case 2:
    //                        StatusText = "FullTeach";
    //                        break;

    //                    case 3:
    //                        StatusText = "FullFit";
    //                        break;

    //                    case 4:
    //                        StatusText = "FullTeachFit";
    //                        break;

    //                    case 97:
    //                        StatusText = "CompTeach";
    //                        break;

    //                    case 98:
    //                        StatusText = "CompFit";
    //                        break;

    //                    case 99:
    //                        StatusText = "CompTeachFit";
    //                        break;

    //                    default:
    //                        StatusText = "Missing";
    //                        break;
    //                }
    //                try
    //                {
    //                    DateTime date = new DateTime();
    //                    date = cus.MembershipExpiration;
    //                    string onlydate = date.Month + "/" + date.Day + "/" + date.Year;
    //                    if (cp.CustomerSite.Equals(customersite.CustomerSiteId))
    //                        dt.Rows.Add(x, cus.FirstName, cus.LastName, user.Email, customersite.SiteName, onlydate, StatusText);


    //                }
    //                catch { }
    //            }
    //        }
    //        dt.DefaultView.Sort = "Last Name ASC, First Name ASC, Facility ASC";
    //        x = 0;
    //        foreach (DataRowView row in dt.DefaultView)
    //        {
    //            x++;
    //            row.Row.SetField("Count", x);
    //        }
    //        GridView1.DataSource = dt;
    //        GridView1.DataBind();
    //    }
}

