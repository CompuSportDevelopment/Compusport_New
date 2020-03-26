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

public partial class Controls_DualPlayer : System.Web.UI.UserControl
{
    public string wmpfile = "";
    //    int customerId = 2;//TODO: after unit testing is finished, use the customer id from the logged in user.

    Customer customer;
    SummaryMovie summarymovie;
    public bool displaysummary;

    private Movie leftMovie;
    private Movie rightMovie;

    protected void Page_Load(object sender, EventArgs e)
    {
        customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
        if (!IsPostBack)
        {
            LoadDefaultData();
            WriteObjectsToPageAjax();
            LoadSummary();
            Label1.Text = customer.FirstName + " " + customer.LastName;
            /*
            if (leftMovie.DateRecorded.ToShortDateString().Equals(rightMovie.DateRecorded.ToShortDateString()))
            {
                Label2.Text = leftMovie.DateRecorded.ToShortDateString();
                Label5.Text = " - ";
            }
            else
            {
                Label2.Text = "";
                Label5.Text = "";
            }
            */
            Label3.Text = customer.FirstName + " " + customer.LastName;
            /*
            if (displaysummary)
                Label4.Text = summarymovie.DateRecorded.ToShortDateString();
            */
        }
    }

    //private string leftMoviePath = @"TestMovieFiles/SideFinal.swf";
    //private string rightMoviePath = @"TestMovieFiles/BackFinal.swf";

    //private void WriteObjectsToPage()
    //{
    //    JavaScriptSerializer js = new JavaScriptSerializer();
    //    string leftMovieString = js.Serialize(CreateSimpleMovieStructure(leftMovie));
    //    if (leftMovie != null)
    //        this.Page.RegisterClientScriptBlock("leftvar", "<script type=\"text/javascript\">var leftMoviePath='../" + leftMovie.FilePath + "'; var leftMovie='" + leftMovieString + "';</script>");
    //    string rightMovieString = js.Serialize(CreateSimpleMovieStructure(rightMovie));
    //    if (rightMovie != null)
    //        this.Page.RegisterClientScriptBlock("rightvar", "<script type=\"text/javascript\">var rightMoviePath='../" + rightMovie.FilePath + "'; var rightMovie='" + rightMovieString + "';</script>");
    //}

    private void WriteObjectsToPageAjax()
    {
        if (leftMovie == null && rightMovie == null)
        {
            return;
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        if (leftMovie!=null)
        {
            string leftMovieString = js.Serialize(CreateSimpleMovieStructure(leftMovie));
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "leftvar", "var leftMoviePath='../" + leftMovie.FilePath + "'; var leftMovie='" + leftMovieString + "';", true);
        }
        if (rightMovie != null)
        {
            string rightMovieString = js.Serialize(CreateSimpleMovieStructure(rightMovie));
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "rightvar", "var rightMoviePath='../" + rightMovie.FilePath + "'; var rightMovie='" + rightMovieString + "';", true);
        }
        System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "domready", "document.getElementById('square').innerHTML = 'Your instructor messages will appear here.';__H = new com.acap.VideoPlayer();", true);
    }

    public class SimpleMovieClip
    {
        public int beginFrame;
        public int endFrame;
        public string[] errors;
    }

    public class SimpleMovie
    {
        public int id;
        public SimpleMovieClip[] clips = new SimpleMovieClip[10];
    }

    private SimpleMovie CreateSimpleMovieStructure(Movie movie)
    {
        SimpleMovie sm = new SimpleMovie();
        if (movie != null)
        {
            sm.id = movie.MovieId;
            movie.MovieClipCollection.Sort("EndFrame ASC");
            for (int i = 0; i < movie.MovieClipCollection.Count; i++)
            {
                sm.clips[i] = CreateSimpleClipStructure(movie.MovieClipCollection[i]);
            }
        }
        return sm;
    }

    private SimpleMovieClip CreateSimpleClipStructure(MovieClip movieClip)
    {
        DataRepository.MovieClipProvider.DeepLoad(movieClip);
        SimpleMovieClip smc = new SimpleMovieClip();
        smc.errors = new string[movieClip.MovieErrorCollection.Count];
        smc.beginFrame = movieClip.BeginFrame;
        smc.endFrame = movieClip.EndFrame;

        CustomerProfileQuery customerQuery = new CustomerProfileQuery();
        customerQuery.AppendEquals(CustomerProfileColumn.CustomerId, customer.CustomerId.ToString());
        TList<CustomerProfile> customerProfile = DataRepository.CustomerProfileProvider.Find(customerQuery.GetParameters());
        int TeacherId = customerProfile[0].Teacher;
        int CustomerSite = customerProfile[0].CustomerSite;
        TList<ErrorDrill> errordrills = new TList<ErrorDrill>();

        DataRepository.MovieErrorProvider.DeepLoad(movieClip.MovieErrorCollection);

        for (int i = 0; i < movieClip.MovieErrorCollection.Count; i++)
        {
            try
            {
                errordrills = DataRepository.ErrorDrillProvider.GetBySwingErrorId(movieClip.MovieErrorCollection[i].SwingErrorIdSource.SwingErrorId);
                if (errordrills.Count > 0)
                {
                    smc.errors[i] = "<a href=javascript:OpenWindow('MyDrills.aspx?ErrorId=" +
                        movieClip.MovieErrorCollection[i].SwingErrorIdSource.SwingErrorId +
                        "&TeacherId=" + TeacherId +
                        "&CustomerSiteId=" + CustomerSite + "') >" +
                        movieClip.MovieErrorCollection[i].SwingErrorIdSource.TextDescription + "</a>";
                }
                else
                {
                    smc.errors[i] = movieClip.MovieErrorCollection[i].SwingErrorIdSource.TextDescription;
                }
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
            }
        }
        return smc;
    }

    private TList<Movie> GetMovies(int lessonTypeId)
    {
        TList<Movie> movies = new TList<Movie>();
        DataRepository.CustomerProvider.DeepLoad(customer);
        LessonQuery lessonQuery = new LessonQuery();
        lessonQuery.AppendEquals(string.Empty, LessonColumn.CustomerId, customer.CustomerId.ToString());
        lessonQuery.AppendEquals("AND", LessonColumn.LessonTypeId, lessonTypeId.ToString());
        TList<Lesson> lessons = DataRepository.LessonProvider.Find(lessonQuery.GetParameters());
        foreach (Lesson l in lessons)
        {
            DataRepository.LessonProvider.DeepLoad(l);
            foreach (Movie m in l.MovieCollection)
            {
                DataRepository.MovieProvider.DeepLoad(m);
                movies.Add(m);
            }
        }
        // movies.Sort("MovieType ASC, DateRecorded DESC");
        movies.Sort("DateRecorded DESC");
        return movies;
    }

    private void LoadDefaultData()
    {
        LessonQuery lessonQuery = new LessonQuery();
        lessonQuery.AppendEquals(LessonColumn.CustomerId, customer.CustomerId.ToString());
        TList<Lesson> lessons = DataRepository.LessonProvider.Find(lessonQuery.GetParameters(), "LessonDate DESC");
        LessonTypeLookup lookUp = null;
        Dictionary<string, LessonTypeLookup> lessonTypeLookUp = new Dictionary<string, LessonTypeLookup>();
        foreach (Lesson l in lessons)
        {
            DataRepository.LessonProvider.DeepLoad(l);
            lookUp = DataRepository.LessonTypeLookupProvider.GetByLessonTypeId(l.LessonTypeId);
            if (lookUp != null && !lessonTypeLookUp.ContainsKey(lookUp.LessonTypeText))
            {
                lessonTypeLookUp.Add(lookUp.LessonTypeText, lookUp);
            }
        }
        if (lessons.Count > 0)
        {
            foreach (LessonTypeLookup l in lessonTypeLookUp.Values)
            {
                DropDownList2.Items.Add(new ListItem(l.LessonTypeText, l.LessonTypeId.ToString()));
            }
            if (!DropDownList1.Enabled) DropDownList1.Enabled = true;
            if (!DropDownList3.Enabled) DropDownList3.Enabled = true;
            LoadVideoList();
        }
        else
        {
            DropDownList1.Enabled = false;
            DropDownList3.Enabled = false;
        }
    }

    private void LoadVideoList()
    {
        TList<Movie> movies = GetMovies(int.Parse(DropDownList2.SelectedValue));
        if (movies.Count > 1)
        {
            if (DropDownList1.Items.Count > 0) DropDownList1.Items.Clear();
            // for left hand dropdown
            foreach (Movie m in movies)
            {
                if (m.MovieType == 2) //A value of 2 means the video is a Side View – Final video
                {
                    ListItem li = new ListItem(m.DateRecorded + " Side View – Final", m.MovieId.ToString(), true);
                    DropDownList1.Items.Add(li);
                }
                if (m.MovieType == 0) //A value of 0 means the video is a Side View – Initial video
                {
                    ListItem li = new ListItem(m.DateRecorded + " Side View – Initial", m.MovieId.ToString(), true);
                    DropDownList1.Items.Add(li);
                }
            }
            // for left hand dropdown
            foreach (Movie m in movies)
            {
                if (m.MovieType == 3) //a value of 3 means the video is a Back View – Final video
                {
                    ListItem li = new ListItem(m.DateRecorded + " Back View - Final", m.MovieId.ToString(), true);
                    DropDownList1.Items.Add(li);
                }
                if (m.MovieType == 1) //A value of 1 means the video is a Back View – Initial video
                {
                    ListItem li = new ListItem(m.DateRecorded + " Back View – Initial", m.MovieId.ToString(), true);
                    DropDownList1.Items.Add(li);
                }
            }
            // for right hand drop down
            leftMovie = movies[0];
            LoadRightDropDown();
            DropDownList1.SelectedValue = leftMovie.MovieId.ToString();
        }
        else
        {
            if (DropDownList1.Items.Count > 0)
                DropDownList1.Items.Clear();
            if (DropDownList3.Items.Count > 0)
                DropDownList3.Items.Clear();
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        leftMovie = DataRepository.MovieProvider.GetByMovieId(int.Parse(DropDownList1.SelectedValue));
        LoadRightDropDown();
        WriteObjectsToPageAjax();
    }

    private void LoadRightDropDown()
    {
        TList<Movie> movies = GetMovies(int.Parse(DropDownList2.SelectedValue));
        if (DropDownList3.Items.Count > 0) DropDownList3.Items.Clear();
        movies.Sort("DateRecorded DESC");
        if (DropDownList1.SelectedItem.Text.EndsWith("Side View – Initial")) // for 0
        {
            foreach (Movie m in movies)
            {
                if (m.MovieType == 1 && m != leftMovie && m.DateRecorded.Equals(leftMovie.DateRecorded))
                {
                    ListItem item = new ListItem(m.DateRecorded + " Back View – Initial", m.MovieId.ToString(), true);
                    DropDownList3.Items.Add(item);
                }
            }
            foreach (Movie m in movies)
            {
                if (m.MovieType == 0 && m != leftMovie)
                {
                    ListItem item = new ListItem(m.DateRecorded + " Side View – Initial", m.MovieId.ToString(), true);
                    DropDownList3.Items.Add(item);
                }
                if (m.MovieType == 2 && m != leftMovie)
                {
                    ListItem item = new ListItem(m.DateRecorded + " Side View – Final", m.MovieId.ToString(), true);
                    DropDownList3.Items.Add(item);
                }
            }
        }
        //if (DropDownList1.SelectedItem.Text.EndsWith("Back View - Initial")) // for 1
        if (DropDownList1.SelectedItem.Text.EndsWith("Back View – Initial")) // for 1
        {
            foreach (Movie m in movies)
            {
                if (m.MovieType == 3 && m != leftMovie && m.DateRecorded.Equals(leftMovie.DateRecorded))
                {
                    ListItem item = new ListItem(m.DateRecorded + " Back View - Final", m.MovieId.ToString(), true);
                    DropDownList3.Items.Add(item);
                }
            }
            foreach (Movie m in movies)
            {
                if (m.MovieType == 1 && m != leftMovie && m.DateRecorded.Equals(leftMovie.DateRecorded))
                {
                    ListItem item = new ListItem(m.DateRecorded + " Back View - Initial", m.MovieId.ToString(), true);
                    DropDownList3.Items.Add(item);
                }
            }
            foreach (Movie m in movies)
            {
                if (m.MovieType == 1 && m != leftMovie)
                {
                    ListItem item = new ListItem(m.DateRecorded + " Back View – Initial", m.MovieId.ToString(), true);
                    DropDownList3.Items.Add(item);
                }
                if (m.MovieType == 3 && m != leftMovie)
                {
                    ListItem item = new ListItem(m.DateRecorded + " Back View - Final", m.MovieId.ToString(), true);
                    DropDownList3.Items.Add(item);
                }
            }
        }
        if (DropDownList1.SelectedItem.Text.EndsWith("Side View – Final")) // for 2
        {
            foreach (Movie m in movies)
            {
                if (m.MovieType == 3 && m!=leftMovie && m.DateRecorded.Equals(leftMovie.DateRecorded))
                {
                    ListItem item = new ListItem(m.DateRecorded + " Back View - Final", m.MovieId.ToString(), true);
                    DropDownList3.Items.Add(item);
                }
            }
            foreach (Movie m in movies)
            {
                if (m.MovieType == 2 && m != leftMovie)
                {
                    ListItem item = new ListItem(m.DateRecorded + " Side View – Final", m.MovieId.ToString(), true);
                    DropDownList3.Items.Add(item);
                }
                if (m.MovieType == 0 && m != leftMovie)
                {
                    ListItem item = new ListItem(m.DateRecorded + " Side View – Initial", m.MovieId.ToString(), true);
                    DropDownList3.Items.Add(item);
                }
            }
        }
        if (DropDownList1.SelectedItem.Text.EndsWith("Back View - Final")) // for 3
        {
            foreach (Movie m in movies)
            {
                if (m.MovieType == 3 && m != leftMovie && m.DateRecorded.Equals(leftMovie.DateRecorded))
                {
                    ListItem item = new ListItem(m.DateRecorded + " Back View - Final", m.MovieId.ToString(), true);
                    DropDownList3.Items.Add(item);
                }
            }
            foreach (Movie m in movies)
            {
                if (m.MovieType == 1 && m != leftMovie && m.DateRecorded.Equals(leftMovie.DateRecorded))
                {
                    ListItem item = new ListItem(m.DateRecorded + " Back View - Initial", m.MovieId.ToString(), true);
                    DropDownList3.Items.Add(item);
                }
            }
            foreach (Movie m in movies)
            {
                if (m.MovieType == 1 && m != leftMovie)
                {
                    ListItem item = new ListItem(m.DateRecorded + " Back View – Initial", m.MovieId.ToString(), true);
                    DropDownList3.Items.Add(item);
                }
                if (m.MovieType == 3 && m != leftMovie)
                {
                    ListItem item = new ListItem(m.DateRecorded + " Back View - Final", m.MovieId.ToString(), true);
                    DropDownList3.Items.Add(item);
                }
            }
        }
        if (DropDownList3.Items.Count > 0)
        {
            DropDownList3.SelectedIndex = 0;
            rightMovie = DataRepository.MovieProvider.GetByMovieId(int.Parse(DropDownList3.SelectedValue));
        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadVideoList();
        if (DropDownList1.Items.Count > 0)
            leftMovie = DataRepository.MovieProvider.GetByMovieId(int.Parse(DropDownList1.SelectedValue));
        if (DropDownList3.Items.Count > 0)
            rightMovie = DataRepository.MovieProvider.GetByMovieId(int.Parse(DropDownList3.SelectedValue));
        WriteObjectsToPageAjax();
    }

    private Movie GetMatching(Movie leftMovie, TList<Movie> movies)
    {
        if (leftMovie.MovieType == 0)
        {
            foreach (Movie m in movies)
            {
                if (m.LessonId == leftMovie.LessonId && m.MovieType == 1 && m.DateRecorded == leftMovie.DateRecorded)
                    return m;
            }
        }
        else
        {
            foreach (Movie m in movies)
            {
                if (m.LessonId == leftMovie.LessonId && m.MovieType == 0 && m.DateRecorded == leftMovie.DateRecorded)
                    return m;
            }
        }
        return null;
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.Items.Count > 0) leftMovie = DataRepository.MovieProvider.GetByMovieId(int.Parse(DropDownList1.SelectedValue));
        rightMovie = DataRepository.MovieProvider.GetByMovieId(int.Parse(DropDownList3.SelectedValue));
        WriteObjectsToPageAjax();
    }

    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        Lesson less;
        less = DataRepository.LessonProvider.GetByLessonId(int.Parse(DropDownList4.SelectedValue));
        TList<Movie> movs = new TList<Movie>();
        movs = DataRepository.MovieProvider.GetByLessonId(less.LessonId);
        if (movs.Count > 2)
        {
            leftMovie = DataRepository.MovieProvider.GetByLessonId(less.LessonId)[2];
            DropDownList1.SelectedValue = leftMovie.MovieId.ToString();
            LoadRightDropDown();
        }
        else
        {
            leftMovie = DataRepository.MovieProvider.GetByLessonId(less.LessonId)[0];
            DropDownList1.SelectedValue = leftMovie.MovieId.ToString();
            LoadRightDropDown();
        }
        WriteObjectsToPageAjax();
        LoadSummary();
    }

    private void LoadSummary()
    {
        DropDownList4.Items.Clear();
        if (leftMovie == null || rightMovie == null)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "key", "document.getElementById('square').innerHTML = '';", true);
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "anyOtherKey", "MakeSummaryInvisible();", true);
            return;
        }
        if (leftMovie.MovieType.Equals(rightMovie.MovieType))
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "key", "document.getElementById('square').innerHTML = '';", true);
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "anyOtherKey", "MakeSummaryInvisible();", true);
            displaysummary = false;
        }
        else
        {
            if (leftMovie.DateRecorded.Equals(rightMovie.DateRecorded))
            {
                try
                {
                    summarymovie = DataRepository.SummaryMovieProvider.GetByLessonId(leftMovie.LessonId)[0];
                    wmpfile = "http://www.swingmodel.com/" + summarymovie.FilePath;
                    displaysummary = true;
                    System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "anyKey", "MakeSummaryVisible();", true);

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
                    int x = 0;
                    foreach (SummaryMovie sms in summarymovies)
                    {
                        DropDownList4.Items.Add(sms.DateRecorded.ToString());
                        DropDownList4.Items[x].Value = sms.LessonId.ToString();
                        x++;
                    }
                }
                catch (Exception)
                {
                    displaysummary = false;
                    wmpfile = string.Empty;
                    System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "key", "document.getElementById('square').innerHTML = '';", true);
                    System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "anyOtherKey", "MakeSummaryInvisible();", true);
                }
            }
            else
            {
                displaysummary = false;
                System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "key", "document.getElementById('square').innerHTML = '';", true);
                System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "anyOtherKey", "MakeSummaryInvisible();", true);
            }
        }
        if (displaysummary)
        {
            contplay.Attributes["style"] = String.Format("font-family:Arial,Helvetica sans-serif;font-size:12px;color:#000000;text-decoration:none;position:absolute;height:1181px;width:930px;");
            fillerleft.Visible = true;
            fillercenter.Visible = true;
            fillerright.Visible = true;
            teachersummaryleft.Visible = true;
            teachersummarycenter.Visible = true;
            teachersummaryright.Visible = true;
            SumDivLeftPanel.Visible = true;
            SumDivCenterPanel.Visible = true;
            SummaryVideo.Visible = true;
            SummaryButtons.Visible = true;
            SummaryDropDown.Visible = true;
            SumDivRightPanel.Visible = true;
            bottomleft.Attributes["style"] = String.Format("font-family:Arial,Helvetica,sans-serif;font-size:12px;text-decoration:none;position:absolute;height:31px;width:23px;left:0px;top:1150px;");
            bottomcenter.Attributes["style"] = String.Format("font-family:Arial,Helvetica,sans-serif;font-size:12px;text-decoration:none;position:absolute;height:31px;width:879px;left:24px;top:1150px;");
            bottomright.Attributes["style"] = String.Format("font-family:Arial,Helvetica,sans-serif;font-size:12px;text-decoration:none;position:absolute;height:31px;width:23px;left:897px;top:1150px;");
            //System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "playkey", "PlayFlashMovie();", true);
            //System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "pausekey", "PauseFlashMovie();", true);
            //System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "stopkey", "StopFlashMovie();", true);
        }
        else
        {
            contplay.Attributes["style"] = String.Format("font-family:Arial,Helvetica sans-serif;font-size:12px;color:#000000;text-decoration:none;position:absolute;height:660px;width:930px;");
            fillerleft.Visible = false;
            fillercenter.Visible = false;
            fillerright.Visible = false;
            teachersummaryleft.Visible = false;
            teachersummarycenter.Visible = false;
            teachersummaryright.Visible = false;
            SumDivLeftPanel.Visible = false;
            SumDivCenterPanel.Visible = false;
            SummaryVideo.Visible = false;
            SummaryButtons.Visible = false;
            SummaryDropDown.Visible = false;
            SumDivRightPanel.Visible = false;
            bottomleft.Attributes["style"] = String.Format("font-family:Arial,Helvetica,sans-serif;font-size:12px;text-decoration:none;position:absolute;height:31px;width:23px;left:0px;top:629px;");
            bottomcenter.Attributes["style"] = String.Format("font-family:Arial,Helvetica,sans-serif;font-size:12px;text-decoration:none;position:absolute;height:31px;width:879px;left:24px;top:629px;");
            bottomright.Attributes["style"] = String.Format("font-family:Arial,Helvetica,sans-serif;font-size:12px;text-decoration:none;position:absolute;height:31px;width:23px;left:897px;top:629px;");
        }

        if (leftMovie.DateRecorded.ToShortDateString().Equals(rightMovie.DateRecorded.ToShortDateString()))
        {
            Label2.Text = leftMovie.DateRecorded.ToShortDateString();
            Label5.Text = " - ";
        }
        else
        {
            Label2.Text = "";
            Label5.Text = "";
        }
        if (displaysummary)
            Label4.Text = summarymovie.DateRecorded.ToShortDateString();
    }
}
