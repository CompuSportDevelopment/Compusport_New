using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwingModel.Data;
using SwingModel.Entities;
using System.Web.Security;

public partial class Locations_Football : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TList<RegionLookup> regions = new TList<RegionLookup>();
        TList<CustomerSite> customersites = new TList<CustomerSite>();
        StateProvince sp = new StateProvince();
        Teacher hi = new Teacher();
        TList<TeacherSite> facilityteachers = new TList<TeacherSite>();
        string[] roles = Roles.GetAllRoles();
        int i = 0;

        regions = DataRepository.RegionLookupProvider.GetByUs(1);

        foreach (RegionLookup r in regions)
        {
            i++;
            System.Web.UI.WebControls.Label lblHeader = new System.Web.UI.WebControls.Label();
            System.Web.UI.WebControls.Label lblContent = new System.Web.UI.WebControls.Label();

            lblHeader.Text = r.RegionName;
            customersites = DataRepository.CustomerSiteProvider.GetByRegion(r.RegionId);
            customersites.Sort("SiteName");
            lblContent.Text = "";
            #region[commented]
            /*foreach (CustomerSite cs in customersites)
            {
                lblContent.Text = lblContent.Text + "<b>" + cs.SiteName + "</b><br>"
                    + cs.Address1 + "<br>";
                try
                {
                    if (!cs.Address2.Equals("") && !cs.Address2.Equals(null))
                        lblContent.Text = lblContent.Text + cs.Address2 + "<br>";
                }
                catch (Exception ex)
                {
                }
                sp = DataRepository.StateProvinceProvider.GetByStateProvinceId(Convert.ToInt16(cs.StateProvince));
                lblContent.Text = lblContent.Text + cs.City + " " + sp.StateProvinceAbbvr + " " + cs.ZipCode + "<br>";

                lblContent.Text = lblContent.Text + "<br>";
            }*/
            #endregion[commented]
            foreach (CustomerSite cs in customersites)
            {
                if (cs.IsApproved.Equals(1) && cs.CustomerSiteId.Equals(23))
                {
                    facilityteachers = DataRepository.TeacherSiteProvider.GetBySiteId(cs.CustomerSiteId);
                    foreach (TeacherSite ts in facilityteachers)
                    {
                        hi = DataRepository.TeacherProvider.GetByTeacherId(ts.TeacherId);
                        //  hi = DataRepository.TeacherProvider.GetByTeacherId(cs.FacilityAdministratorId);
                        Guid MemGuid = new Guid(hi.AspnetMembershipUserId.ToString());
                        MembershipUser user = Membership.GetUser(MemGuid);
                        string[] userrole = Roles.GetRolesForUser(user.UserName);
                        string userrolename = string.Empty;
                        userrolename = userrole[0];
                        lblContent.Text = lblContent.Text + "<table><tr><td colspan=5>"
                            + "<b>" + cs.SiteName + "</b></td>"
                            + "<tr><td width=220 valign=top>"
                            + cs.Address1+"<br>";
                        try
                        {
                            if (!cs.Address2.Equals("") && cs.Address2.Equals(null))
                                lblContent.Text = lblContent.Text + cs.Address2 + "<br>";
                        }
                        catch (Exception ex)
                        {
                        }
                        sp = DataRepository.StateProvinceProvider.GetByStateProvinceId(Convert.ToInt16(cs.StateProvince));
                        if (cs.StateProvince.Equals("-1"))
                            lblContent.Text = lblContent.Text + cs.City + " " + cs.ZipCode
                                + "</td>";
                        else
                            lblContent.Text = lblContent.Text + cs.City + " " + sp.StateProvinceAbbvr + " " + cs.ZipCode
                                + "</td>";
                        lblContent.Text = lblContent.Text + "<td width=180 align=right valign=top><font color=black>" + userrolename + ":<br>Website:</font></td>";

                        //  hi = DataRepository.TeacherProvider.GetByTeacherId(cs.FacilityAdministratorId);

                        lblContent.Text = lblContent.Text +
                                       "<td width=160 valign=top> <a href=../Contact/CoachProfile.aspx?teacherid=" + hi.TeacherId.ToString() + ">" + hi.FirstName + " " + hi.LastName + "</a>";
                        //lblContent.Text = lblContent.Text + "<td width=160 valign=top>" + hi.FirstName + " " + hi.LastName;
                        if (cs.Website.Equals("-1"))
                            lblContent.Text = lblContent.Text + "<br>NA</td>";
                        else
                            lblContent.Text = lblContent.Text + "<br><a href=http://" + cs.Website + " target=_blank>click here</a></td>";
                        lblContent.Text = lblContent.Text + "<td width=180 align=right valign=top><br>Email Instructor:</font></td>";

                        lblContent.Text = lblContent.Text + "<td><br><a href=../Contact/EmailTeacher.aspx?facilityid=" + cs.CustomerSiteId.ToString() + ">click here</a></td></tr>";

                        lblContent.Text = lblContent.Text + "</table>";
                    }
                }
            }

            AjaxControlToolkit.AccordionPane ap2 = new AjaxControlToolkit.AccordionPane();
            ap2.ID = "dynPane" + i.ToString();
            if (lblHeader.Text != "Northwest" && lblHeader.Text != "Alaska & Hawaii")
            {
                ap2.HeaderContainer.Controls.Add(lblHeader);
                ap2.ContentContainer.Controls.Add(lblContent);
                Accordion2.Panes.Add(ap2);
            }
        }

        i = 0;
        regions = DataRepository.RegionLookupProvider.GetByUs(0);

        foreach (RegionLookup r in regions)
        {
            i++;
            System.Web.UI.WebControls.Label lblHeader2 = new System.Web.UI.WebControls.Label();
            System.Web.UI.WebControls.Label lblContent2 = new System.Web.UI.WebControls.Label();
            lblHeader2.Text = r.RegionName;
            customersites = DataRepository.CustomerSiteProvider.GetByRegion(r.RegionId);
            customersites.Sort("SiteName");
            lblContent2.Text = "";
            foreach (CustomerSite cs in customersites)
            {

                facilityteachers = DataRepository.TeacherSiteProvider.GetBySiteId(cs.CustomerSiteId);
                foreach (TeacherSite ts in facilityteachers)
                {

                    hi = DataRepository.TeacherProvider.GetByTeacherId(ts.TeacherId);
                    Guid MemGuid = new Guid(hi.AspnetMembershipUserId.ToString());
                    MembershipUser user = Membership.GetUser(MemGuid);
                    string[] userrole = Roles.GetRolesForUser(user.UserName);
                    string userrolename = string.Empty;
                    userrolename = userrole[0];

                    if (cs.IsApproved.Equals(1) && cs.CustomerSiteId.Equals(23))
                    {
                        lblContent2.Text = lblContent2.Text + "<table><tr><td colspan=5>"
                            + "<b>" + cs.SiteName + "</b></td>"
                            + "<tr><td width=230 valign=top>"
                            + cs.Address1;

                        //+ "<br>";
                        try
                        {
                            if (!cs.Address2.Equals("") && !cs.Address2.Equals(null))
                                lblContent2.Text = lblContent2.Text + cs.Address2;
                            //+"<br>";
                        }
                        catch (Exception ex)
                        {
                        }
                        if (cs.StateProvince.Equals("-1"))
                            lblContent2.Text = lblContent2.Text + cs.City + " " + cs.ZipCode
                                + "</td>";
                        else
                            lblContent2.Text = lblContent2.Text + cs.City + " " + cs.StateProvince + " " + cs.ZipCode
                                + "</td>";
                        lblContent2.Text = lblContent2.Text + "<td width=180 align=right valign=top><font color=black>" + userrolename + ":<br>Website:</font></td>";
                        // hi = DataRepository.TeacherProvider.GetByTeacherId(cs.FacilityAdministratorId);
                        lblContent2.Text = lblContent2.Text +
                                        "<td width=160 valign=top> <a href=../Contact/CoachProfile.aspx?teacherid=" + hi.TeacherId.ToString() + ">" + hi.FirstName + " " + hi.LastName + "</a>";

                        
                        //lblContent2.Text = lblContent2.Text + "<td width=160 valign=top>" + hi.FirstName + " " + hi.LastName;
                        if (cs.Website.Equals("-1"))
                            lblContent2.Text = lblContent2.Text + "<br>NA</td>";
                        else
                            lblContent2.Text = lblContent2.Text + "<br><a href=mailto:dev@compusport.com?subject=Support%20Inquiry + cs.Website +  target=_blank>click here</a></td>";
                        lblContent2.Text = lblContent2.Text + "<td width=180 align=right valign=top><font color=black>Schedule Lesson:"
                            + "<br>Email Instructor:</font></td>";
                        lblContent2.Text = lblContent2.Text + "<td><a href=mailto:dev@compusport.com?subject=Support%20Inquiry + cs.CustomerSiteId.ToString() + >click here</a>"
                            + "<br><a href=mailto:dev@compusport.com?subject=Support%20Inquiry + cs.CustomerSiteId.ToString() + >click here</a></td></tr>";

                        lblContent2.Text = lblContent2.Text + "</table>";
                    }

                }
            }

            AjaxControlToolkit.AccordionPane ap3 = new AjaxControlToolkit.AccordionPane();
            ap3.ID = "dynPane" + i.ToString();
            if (lblHeader2.Text != "India" && lblHeader2.Text != "Antarctica" && lblHeader2.Text != "Russia" && lblHeader2.Text != "Greenland" && lblHeader2.Text != "Caribbean" && lblHeader2.Text != "Central & South America")
            {
                ap3.HeaderContainer.Controls.Add(lblHeader2);
                ap3.ContentContainer.Controls.Add(lblContent2);
                Accordion4.Panes.Add(ap3);
            }
        }
    }
}
