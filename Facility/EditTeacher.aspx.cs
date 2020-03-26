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
using SwingModel.Data;
using SwingModel.Entities;

//public partial class Facility_EditTeacher : System.Web.UI.Page
public partial class Facility_EditTeacher : SwingModel.UI.BasePage
{
    public int TeacherId;
    Teacher teacher = new Teacher();

    protected void Page_Load(object sender, EventArgs e)
    {
        TeacherId = Convert.ToInt16(Request.QueryString.Get("TeacherId"));
        teacher = DataRepository.TeacherProvider.GetByTeacherId(TeacherId);
        if (!IsPostBack)
        {
            TextBox1.Text = teacher.FirstName;
            TextBox2.Text = teacher.LastName;
            TextBox3.Text = teacher.WorkPhone;
            TextBox4.Text = teacher.MobilePhone;
            TextBox5.Text = teacher.Fax;
            TextBox6.Text = teacher.TeachingPassword;

            MembershipUser user = Membership.GetUser(teacher.AspnetMembershipUserId);
            string[] userrole = Roles.GetRolesForUser(user.UserName.ToString());

            if ((Roles.IsUserInRole("Facility Administrators") || Roles.IsUserInRole("Teachers")) && !Roles.IsUserInRole("Administrators"))
            {
                TextBox6.Visible = true;
                Label6.Visible = true;
            }
            else
            {
                TextBox6.Visible = false;
                Label6.Visible = false;

            }
            //foreach (var item in userrole)
            //{
            //    if (item.Equals("Facility Administrators"))
            //    {
            //        TextBox6.Visible = false;
            //        Label6.Visible = false;
            //    }

            //}
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        bool DoSubmit = false;

        if (TextBox1.Text.Equals("") || TextBox1.Text.Equals(null))
        {
            DoSubmit = false;
            Label7.Visible = true;
        }
        else
        {
            DoSubmit = true;
            Label7.Visible = false;
        }
        if (TextBox2.Text.Equals("") || TextBox2.Text.Equals(null))
        {
            DoSubmit = false;
            Label8.Visible = true;
        }
        else
        {
            if (DoSubmit)
                DoSubmit = true;
            Label8.Visible = false;
        }
        if (TextBox6.Text.Equals("") || TextBox6.Text.Equals(null))
        {
            DoSubmit = false;
            Label9.Visible = true;
        }
        else
        {
            if (DoSubmit)
                DoSubmit = true;
            Label9.Visible = false;
        }

        if (DoSubmit)
        {
            teacher.FirstName = TextBox1.Text;
            teacher.LastName = TextBox2.Text;
            if (!TextBox3.Text.Equals("") && !TextBox3.Text.Equals(null))
                teacher.WorkPhone = TextBox3.Text;
            else
                teacher.WorkPhone = null;
            if (!TextBox4.Text.Equals("") && !TextBox4.Text.Equals(null))
                teacher.MobilePhone = TextBox4.Text;
            else
                teacher.MobilePhone = null;
            if (!TextBox5.Text.Equals("") && !TextBox5.Text.Equals(null))
                teacher.Fax = TextBox5.Text;
            else
                teacher.Fax = null;
            teacher.TeachingPassword = TextBox6.Text;

            DataRepository.TeacherProvider.Update(teacher);

            this.Page.Response.Redirect("~/Facility/AddTeachers.aspx");
        }
    }
}
