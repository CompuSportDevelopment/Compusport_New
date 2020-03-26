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

public partial class Controls_TSPlayer : System.Web.UI.UserControl
{
    public string wmpfile = "";
    //    int customerId = 2;//TODO: after unit testing is finished, use the customer id from the logged in user.

    Customer customer;
    SummaryMovie summarymovie;

    protected void Page_Load(object sender, EventArgs e)
    {
        customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
        if (!IsPostBack)
        {
            WriteObjectsToPageAjax();
            LoadSummary();
        }
    }

    private void WriteObjectsToPageAjax()
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        //System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "domready", "document.getElementById('square').innerHTML = 'Your instructor messages will appear here.';__H = new com.acap.VideoPlayer();", true);
    }

    private void LoadSummary()
    {
        TList<Lesson> listlessons = new TList<Lesson>();

        listlessons = DataRepository.LessonProvider.GetByCustomerId(customer.CustomerId);
        listlessons.Sort("LessonDate DESC");
        try
        {
            summarymovie = DataRepository.SummaryMovieProvider.GetByLessonId(listlessons[0].LessonId)[0];
            wmpfile = "http://www.swingmodel.com/" + summarymovie.FilePath;
            //System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "anyKey", "MakeSummaryVisible();", true);

            TList<SummaryMovie> summarymovies = new TList<SummaryMovie>();
            summarymovies.Add(summarymovie);
            
            TList<Lesson> lessons = new TList<Lesson>();
            lessons = DataRepository.LessonProvider.GetByCustomerId(customer.CustomerId);
            lessons.Sort("LessonDate DESC");
            SummaryMovie sm;
            foreach (Lesson l in lessons)
            {
                try
                {
                    sm = DataRepository.SummaryMovieProvider.GetByLessonId(l.LessonId)[0];
                    if (!sm.DateRecorded.Equals(summarymovie.DateRecorded))
                        summarymovies.Add(sm);
                }
                catch (Exception ex)
                {
                }
            }
        }
        catch (Exception)
        {
            wmpfile = string.Empty;
            //System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "key", "document.getElementById('square').innerHTML = '';", true);
            //System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "anyOtherKey", "MakeSummaryInvisible();", true);
        }
    }
}
