using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class Controls_DrillsPlayer : System.Web.UI.UserControl
{
    public string wmpfile = "";
    public int ErrorId;
    public int TeacherId;
    public int CustomerSiteId;
    //    int customerId = 2;//TODO: after unit testing is finished, use the customer id from the logged in user.

    Customer customer;
    TList<ErrorDrill> errordrills = new TList<ErrorDrill>();
    Drill drill;
    DrillMedia drillmedia;
    DrillTeacherExtension drillteacherextension;
    Teacher teacher;
    TList<TeacherSite> teacheratsites = new TList<TeacherSite>();

    protected void Page_Load(object sender, EventArgs e)
    {
        customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
        //customer = DataRepository.CustomerProvider.GetByCustomerId(Convert.ToInt16(Request.QueryString.Get("customerid")));

        ErrorId = Convert.ToInt16(Request.QueryString.Get("ErrorId"));
        TeacherId = Convert.ToInt16(Request.QueryString.Get("TeacherId"));
        CustomerSiteId = Convert.ToInt16(Request.QueryString.Get("CustomerSiteId"));
        //MessageBox.Show("ErrorId: " + ErrorId.ToString());
        //MessageBox.Show("TeacherId: " + TeacherId.ToString());
        //MessageBox.Show("CustomerSiteId: " + CustomerSiteId.ToString());

        errordrills = DataRepository.ErrorDrillProvider.GetBySwingErrorId(ErrorId);
        int x = 0;
        if (!IsPostBack)
        {
            foreach (ErrorDrill ed in errordrills)
            {
                drill = DataRepository.DrillProvider.GetByDrillId(ed.DrillId);
                drillmedia = DataRepository.DrillMediaProvider.GetByDrillId(ed.DrillId)[0];
                drillteacherextension = DataRepository.DrillTeacherExtensionProvider.GetByDrillMediaId(drillmedia.DrillMediaId)[0];
                teacher = DataRepository.TeacherProvider.GetByTeacherId(drillteacherextension.TeacherId);

                if (drillteacherextension.TeacherId.Equals(TeacherId))
                {
                    DropDownList1.Items.Add(drill.DrillName + " - " + teacher.FirstName + " " + teacher.LastName);
                    DropDownList1.Items[x].Value = drillmedia.DrillMediaId.ToString();
                    x++;
                }
            }
            foreach (ErrorDrill ed in errordrills)
            {
                drill = DataRepository.DrillProvider.GetByDrillId(ed.DrillId);
                drillmedia = DataRepository.DrillMediaProvider.GetByDrillId(ed.DrillId)[0];
                drillteacherextension = DataRepository.DrillTeacherExtensionProvider.GetByDrillMediaId(drillmedia.DrillMediaId)[0];
                teacher = DataRepository.TeacherProvider.GetByTeacherId(drillteacherextension.TeacherId);
                teacheratsites = DataRepository.TeacherSiteProvider.GetByTeacherId(drillteacherextension.TeacherId);

                foreach (TeacherSite tas in teacheratsites)
                {
                    if (tas.SiteId.Equals(CustomerSiteId) && !drillteacherextension.TeacherId.Equals(TeacherId))
                    {
                        DropDownList1.Items.Add(drill.DrillName + " - " + teacher.FirstName + " " + teacher.LastName);
                        DropDownList1.Items[x].Value = drillmedia.DrillMediaId.ToString();
                        x++;
                    }
                }
            }
            foreach (ErrorDrill ed in errordrills)
            {
                drill = DataRepository.DrillProvider.GetByDrillId(ed.DrillId);
                drillmedia = DataRepository.DrillMediaProvider.GetByDrillId(ed.DrillId)[0];
                drillteacherextension = DataRepository.DrillTeacherExtensionProvider.GetByDrillMediaId(drillmedia.DrillMediaId)[0];
                teacher = DataRepository.TeacherProvider.GetByTeacherId(drillteacherextension.TeacherId);
                teacheratsites = DataRepository.TeacherSiteProvider.GetByTeacherId(drillteacherextension.TeacherId);

                foreach (TeacherSite tas in teacheratsites)
                {
                    if (!tas.SiteId.Equals(CustomerSiteId))
                    {
                        if (drillmedia.Type.Equals(100) && !drillteacherextension.TeacherId.Equals(TeacherId))
                        {
                            DropDownList1.Items.Add(drill.DrillName + " - " + teacher.FirstName + " " + teacher.LastName);
                            DropDownList1.Items[x].Value = drillmedia.DrillMediaId.ToString();
                            x++;
                        }
                    }
                }
            }
            LoadDrillVideo();
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDrillVideo();
    }

    private void LoadDrillVideo()
    {
        DrillMedia dm;
        try
        {
            dm = DataRepository.DrillMediaProvider.GetByDrillMediaId(Convert.ToInt16(DropDownList1.SelectedValue));
            wmpfile = "http://www.swingmodel.com/" + dm.MediaPath;
            //MessageBox.Show("wmpfile: " + wmpfile);
        }
        catch (Exception ex)
        {
            wmpfile = "";
        }
    }
}
