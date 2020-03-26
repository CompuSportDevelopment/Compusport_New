using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel.Syndication;
using System.Windows.Forms;

//public partial class Default : System.Web.UI.Page
public partial class Default : SwingModel.UI.BasePage
{
    public string FlashFile = "";
    public DataTable dt1 = new DataTable();
    public DataTable dt2 = new DataTable();
    public DataTable dt3 = new DataTable();
    int counter1;
    int counter2;
    int counter3;

    protected override void OnPreLoad(EventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            Image1.ImageUrl = "~/Images/hp_logout.png";
            HyperLink2.NavigateUrl = "~/Logout.aspx";
            //Image2.ImageUrl = "~/Images/hp_myswingmodel.png";
            //HyperLink5.NavigateUrl = "~/Users/Default.aspx";
            //Image3.ImageUrl = "~/Images/hp_myswing.png";
            //HyperLink6.NavigateUrl = "~/Users/MySwing.aspx"; 
            //Image4.ImageUrl = "~/Images/hp_schedulelesson.png";
            //HyperLink7.NavigateUrl = "~/Users/ScheduleLesson.aspx";
            Image5.ImageUrl = "~/Images/hp_emailteacher.png";
            HyperLink8.NavigateUrl = "~/Users/EmailTeacher.aspx";
            //FlashFile = "D:\\preview7us.swf";
            FlashFile = "../images/HomepageFlash.swf";
            //FlashFile = "../griffiths-iwan-6 Iron-Irons-2012-2-8-9-25-Current-Back.swf";
        }
        else
        {
            Image1.ImageUrl = "~/Images/CompuSportLoginImage.jpg";
            HyperLink2.NavigateUrl = "~/Login.aspx?ReturnUrl=%2fUsers%2fDefault.aspx";
            //Image2.ImageUrl = "~/Images/hp_joinnow.png";
            //HyperLink5.NavigateUrl = "~/MakeMember.aspx";
            //Image3.ImageUrl = "~/Images/hp_golfertour.png";
            //HyperLink6.NavigateUrl = "~/About/Default.aspx";
            //Image4.ImageUrl = "~/Images/hp_teachertour.png";
            //HyperLink7.NavigateUrl = "~/TeacherInfo/Default.aspx";
            Image5.ImageUrl = "~/Images/CompuSportHomeContactImage.jpg";
            HyperLink8.NavigateUrl = "~/Contact/Default.aspx";
            //FlashFile = "D:\\preview7us.swf";
            FlashFile = "~/images/HomepageFlash.swf";
            //FlashFile = "../griffiths-iwan-6 Iron-Irons-2012-2-8-9-25-Current-Back.swf";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //int x = 0;

        ////XmlReader reader = XmlReader.Create("http://www.golfdigest.com/services/rss");
        //XmlReader reader = XmlReader.Create("http://www.golfdigest.com/services/rss/feeds/gd_instruction.xml");
        //Rss20FeedFormatter formatter = new Rss20FeedFormatter();
        //formatter.ReadFrom(reader);
        //reader.Close();
        //dt1.Columns.Add("LinkText", typeof(string));
        //dt1.Columns.Add("Hyperlink", typeof(string));
        //dt1.Columns.Add("SummaryText", typeof(string));
        //x = 0;
        //foreach (SyndicationItem si in formatter.Feed.Items)
        //{
        //    try
        //    {
        //        dt1.Rows.Add(si.Title.Text, si.Links[0].Uri.AbsoluteUri.ToString(), si.Summary.Text);
        //        x++;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //XmlReaderSettings xReaderSettings;

        //xReaderSettings = new XmlReaderSettings();
        //xReaderSettings.ValidationType = ValidationType.DTD;
        //xReaderSettings.ProhibitDtd = false;

        //XmlReader reader2 = XmlReader.Create("http://www.golfdigest.com/services/rss", xReaderSettings);
        ////XmlReader reader2 = XmlReader.Create("http://www.golfdigest.com/services/rss/feeds/gd_equipment.xml");
        //Rss20FeedFormatter formatter2 = new Rss20FeedFormatter();
        //formatter2.ReadFrom(reader2);
        //reader2.Close();
        //dt2.Columns.Add("LinkText", typeof(string));
        //dt2.Columns.Add("Hyperlink", typeof(string));
        //dt2.Columns.Add("SummaryText", typeof(string));
        //x = 0;
        //foreach (SyndicationItem si in formatter2.Feed.Items)
        //{
        //    try
        //    {
        //        dt2.Rows.Add(si.Title.Text, si.Links[0].Uri.AbsoluteUri.ToString(), si.Summary.Text);
        //        x++;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //XmlReader reader3 = XmlReader.Create("http://www.golfdigest.com/services/rss");
        ////XmlReader reader3 = XmlReader.Create("http://www.golfdigest.com/services/rss/feeds/news.xml");
        //Rss20FeedFormatter formatter3 = new Rss20FeedFormatter();
        //formatter3.ReadFrom(reader3);
        //reader3.Close();
        //dt3.Columns.Add("LinkText", typeof(string));
        //dt3.Columns.Add("Hyperlink", typeof(string));
        //dt3.Columns.Add("SummaryText", typeof(string));
        //x = 0;
        //foreach (SyndicationItem si in formatter3.Feed.Items)
        //{
        //    try
        //    {
        //        dt3.Rows.Add(si.Title.Text, si.Links[0].Uri.AbsoluteUri.ToString(), si.Summary.Text);
        //        x++;
        //    }
        //    catch
        //    {
        //    }
        //}

        //if (!IsPostBack)
        //{
        //    try
        //    {
        //        //HyperLink3.Text = dt1.Rows[0].Field<string>("LinkText");
        //        //HyperLink3.NavigateUrl = dt1.Rows[0].Field<string>("Hyperlink");
        //        //Label5.Text = dt1.Rows[0].Field<string>("SummaryText");
        //        //counter1 = 0;
        //        //Label6.Text = counter1.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        //Label5.Text = "RSS Feed Currently Unavailable";
        //    }

        //    try
        //    {
        //        //HyperLink4.Text = dt2.Rows[0].Field<string>("LinkText");
        //        //HyperLink4.NavigateUrl = dt2.Rows[0].Field<string>("Hyperlink");
        //        //Label7.Text = dt2.Rows[0].Field<string>("SummaryText");
        //        //counter2 = 0;
        //        //Label8.Text = counter1.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        //Label7.Text = "RSS Feed Currently Unavailable";
        //    }

        //    try
        //    {
        //        //HyperLink1.Text = dt3.Rows[0].Field<string>("LinkText");
        //        //HyperLink1.NavigateUrl = dt3.Rows[0].Field<string>("Hyperlink");
        //        //Label1.Text = dt3.Rows[0].Field<string>("SummaryText");
        //        //counter3 = 0;
        //        //Label9.Text = counter1.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        //Label11.Text = "RSS Feed Currently Unavailable";
        //    }
        //}
    }

    //protected void Timer1_Tick(object sender, EventArgs e)
    //{

    //int count1;
    //count1 = Convert.ToInt16(Label6.Text);
    //count1++;
    //if (count1.Equals(dt1.Rows.Count))
    //    count1 = 0;
    ////Label6.Text = count1.ToString();
    ////HyperLink3.Text = dt1.Rows[count1].Field<string>("LinkText");
    ////HyperLink3.NavigateUrl = dt1.Rows[count1].Field<string>("Hyperlink");
    ////Label5.Text = dt1.Rows[count1].Field<string>("SummaryText");

    //int count2;
    //count2 = Convert.ToInt16(Label8.Text);
    //count2++;
    //if (count2.Equals(dt2.Rows.Count))
    //    count2 = 0;
    //Label8.Text = count2.ToString();
    //HyperLink4.Text = dt2.Rows[count2].Field<string>("LinkText");
    //HyperLink4.NavigateUrl = dt2.Rows[count2].Field<string>("Hyperlink");
    //Label7.Text = dt2.Rows[count2].Field<string>("SummaryText");

    //int count3;
    //count3 = Convert.ToInt16(Label9.Text);
    //count3++;
    //if (count3.Equals(dt3.Rows.Count))
    //    count3 = 0;
    //Label9.Text = count3.ToString();
    //HyperLink1.Text = dt3.Rows[count3].Field<string>("LinkText");
    //HyperLink1.NavigateUrl = dt3.Rows[count3].Field<string>("Hyperlink");
    //Label1.Text = dt3.Rows[count3].Field<string>("SummaryText");

    // }

    //public void AthleteChildSendMail()
    //{
    //    customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
    //    Guid MemGuid = new Guid(customer.AspnetMembershipUserId.ToString());
    //    MembershipUser user = Membership.GetUser(MemGuid);

    //    string cust_fullname = customer.FirstName + " " + customer.LastName;
    //    int movieid = Convert.ToInt32(DropDownList1.SelectedItem.Value);
    //    leftMovie = DataRepository.MovieProvider.GetByMovieId(movieid);
    //    lesson = DataRepository.LessonProvider.GetByLessonId(leftMovie.LessonId);
    //    // summarymovie = DataRepository.SummaryMovieProvider.GetByLessonId(leftMovie.LessonId)[0];
    //    DateTime date = lesson.LessonDate;
    //    string location = sae.SelectLessonlocation(lesson.LessonId.ToString());
    //    string[] path = rightMovie.FilePath.Split('/');
    //    string lpath = path[2];
    //    if (!DropDownList1.SelectedValue.Equals("nodate"))
    //    {
    //        _child_id = DataRepository.CustomerProfileProvider.GetByCustomerId(customer.CustomerId)[0];
    //        int AthletesChildId = Convert.ToInt16(_child_id.InitialTeacher);

    //        try
    //        {
    //            if (obj1div.Visible.Equals(true) || obj1div2.Visible.Equals(true))  //video is not available
    //            {
    //                if (obj1div.Visible.Equals(true))
    //                {
    //                    moviediv1.Visible = false;
    //                }
    //                else
    //                {
    //                    moviediv1.Visible = true;
    //                    isLeftMovie = true;
    //                }
    //                if (obj1div2.Visible.Equals(true))
    //                {
    //                    moviediv2.Visible = false;
    //                }
    //                else
    //                {
    //                    moviediv2.Visible = true;
    //                    isRightMovie = true;
    //                }
    //                if (AthletesChildId == 1)
    //                {
    //                    MsgDiv.Visible = true;
    //                    MsgDiv.Style.Add("display", "block");
    //                    Label7.Visible = false;
    //                }
    //                else
    //                {
    //                    if (DropDownList2.SelectedItem.Text.Equals("Sprint"))
    //                    {
    //                        // SprintTireText.Visible = true;
    //                        SprintIntro.Visible = false;
    //                        SummaryMessage.Visible = false;
    //                    }
    //                    else if (DropDownList2.SelectedItem.Text.Equals("Start"))
    //                    {
    //                        //  StartTireText.Visible = true;
    //                        StartIntro.Visible = false;
    //                        SummaryMessage.Visible = false;
    //                    }
    //                    else if (DropDownList2.SelectedItem.Text.Equals("Hurdle"))
    //                    {
    //                        HurdleTireText.Visible = true;
    //                        HurdleIntro.Visible = false;
    //                        SummaryMessage.Visible = false;
    //                        SprintId.Visible = false;

    //                    }
    //                    MsgDiv.Visible = false;
    //                }

    //                Label13.Visible = false;

    //                isLeftMovie = false;
    //                isRightMovie = false;
    //            }
    //            else
    //            {
    //                MsgDiv.Visible = false;
    //                Label7.Text = "Session Video is Displayed";

    //                Label7.Visible = true;
    //                Label13.Visible = false;
    //            }
    //            if (location == "Summary")
    //            {
    //                Label9.Text = "No Session Video available since selected Session is Summary of all Sessions.";

    //                Label9.Visible = true;
    //                Label7.Visible = false;
    //                Label13.Visible = false;
    //            }
    //            else
    //            {
    //                Label9.Visible = false;
    //                Label13.Visible = false;
    //            }
    //        }
    //        catch
    //        {
    //            moviediv1.Visible = false;

    //            if (AthletesChildId == 1)
    //            {
    //                MsgDiv.Visible = true;


    //            }
    //            else
    //            {
    //                if (DropDownList2.SelectedItem.Text.Equals("Sprint"))
    //                {
    //                    //  SprintTireText.Visible = true;
    //                    SprintIntro.Visible = false;
    //                    SummaryMessage.Visible = false;

    //                }
    //                else if (DropDownList2.SelectedItem.Text.Equals("Start"))
    //                {
    //                    //  StartTireText.Visible = true;
    //                    StartIntro.Visible = false;
    //                    SummaryMessage.Visible = false;
    //                }
    //                else if (DropDownList2.SelectedItem.Text.Equals("Hurdle"))
    //                {
    //                    //HurdleTireText.Visible = true;
    //                    HurdleIntro.Visible = false;
    //                    SummaryMessage.Visible = false;
    //                }
    //                MsgDiv.Visible = false;
    //            }
    //            Label13.Visible = false;
    //        }
    //        try
    //        {
    //            if (AthletesChildId == 1)
    //            {
    //                DateTime letestSummaryDate = ReturnLatestSummaryDate();
    //                string letestDate = letestSummaryDate.Month.ToString() + "/" + letestSummaryDate.Day.ToString() + "/" + letestSummaryDate.Year.ToString();
    //                leftMovie = DataRepository.MovieProvider.GetByMovieId(int.Parse(DropDownList1.SelectedValue));
    //                rightMovie = DataRepository.MovieProvider.GetByMovieId(int.Parse(DropDownList3.SelectedValue));
    //                string Leftlocation = sae.SelectLessonlocation(leftMovie.LessonId.ToString());
    //                string Rightlocation = sae.SelectLessonlocation(rightMovie.LessonId.ToString());
    //                DateTime selectedLessonDate = leftMovie.DateRecorded;
    //                string Ldate = leftMovie.DateRecorded.ToString();
    //                string Rdate = rightMovie.DateRecorded.ToString();

    //                string selectedLessonDate2 = selectedLessonDate.Month.ToString() + "/" + selectedLessonDate.Day.ToString() + "/" + selectedLessonDate.Year.ToString();

    //                if (objdivsum.Visible == true)        //summary movie not available                   
    //                {
    //                    if (AthletesChildId == 1)
    //                    {
    //                        if (selectedLessonDate2 == letestDate)
    //                        {
    //                            MsgDiv2.Visible = true;
    //                            MsgDiv2.Style.Add("display", "block");
    //                            Label10.Visible = false;
    //                            Label16.Visible = false;
    //                            Label8.Visible = false;
    //                        }
    //                        else
    //                        {
    //                            MsgDiv2.Visible = false;
    //                            MsgDiv2.Style.Add("display", "none");
    //                            if (selectedLessonDate2 != "1/1/2020")
    //                            {
    //                                if (!isComparison)
    //                                {
    //                                    Label16.Text = "Summary Video is only available for the Latest Session";
    //                                    Label16.Visible = true;
    //                                    Label8.Visible = false;
    //                                    Label10.Visible = false;
    //                                }
    //                                else
    //                                {
    //                                    DisplaySummaryForComparisonSessions(Ldate, Rdate, Leftlocation, Rightlocation, selectedLessonDate2, letestDate);

    //                                    // Label16.Visible = false;
    //                                }
    //                            }
    //                        }
    //                    }
    //                    else
    //                    {
    //                        if (DropDownList2.SelectedItem.Text.Equals("Sprint"))
    //                        {
    //                            SprintIntro.Visible = false;
    //                            SummaryMessage.Visible = false;
    //                        }
    //                        else if (DropDownList2.SelectedItem.Text.Equals("Start"))
    //                        {
    //                            StartIntro.Visible = false;
    //                            SummaryMessage.Visible = false;
    //                        }
    //                        else if (DropDownList2.SelectedItem.Text.Equals("Hurdle"))
    //                        {
    //                            HurdleIntro.Visible = false;
    //                            SummaryMessage.Visible = false;
    //                        }
    //                        MsgDiv2.Visible = false;
    //                    }
    //                }
    //                else
    //                {
    //                    if (!isComparison)
    //                    {
    //                        MsgDiv2.Visible = false;
    //                        Label8.Text = "Summary Video is displayed";
    //                        Label8.Visible = true;
    //                        Label13.Visible = false;
    //                        Label10.Visible = false;
    //                        Label16.Visible = false;
    //                    }
    //                    else
    //                    {
    //                        DisplaySummaryForComparisonSessions(Ldate, Rdate, Leftlocation, Rightlocation, selectedLessonDate2, letestDate);
    //                    }
    //                }
    //            }
    //            if (AthletesChildId == 1)
    //            {
    //                if (DropDownList1.SelectedItem.Text.Contains("Summary"))
    //                {
    //                    Label10.Text = "No Summary Video Available for Summary Sessions.";
    //                    Label10.Visible = true;
    //                    Label8.Visible = false;
    //                    MsgDiv2.Visible = false;
    //                    MsgDiv.Visible = false;
    //                    Label13.Visible = false;
    //                    Label16.Visible = false;
    //                }
    //            }
    //            else
    //            {
    //                if (DropDownList2.SelectedItem.Text.Equals("Sprint"))
    //                {
    //                    SprintIntro.Visible = false;
    //                    SummaryMessage.Visible = false;
    //                }
    //                else if (DropDownList2.SelectedItem.Text.Equals("Start"))
    //                {
    //                    StartIntro.Visible = false;
    //                    SummaryMessage.Visible = false;
    //                }
    //                else if (DropDownList2.SelectedItem.Text.Equals("Hurdle"))
    //                {
    //                    HurdleIntro.Visible = false;
    //                    SummaryMessage.Visible = false;
    //                }
    //                MsgDiv2.Visible = false;
    //                moviediv1.Visible = true;
    //                moviediv2.Visible = true;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            ex.Message.ToString();
    //            if (AthletesChildId == 1)
    //            {
    //                MsgDiv2.Visible = true;
    //                MsgDiv2.Style.Add("display", "block");
    //            }
    //            else
    //            {
    //                if (DropDownList2.SelectedItem.Text.Equals("Sprint"))
    //                {
    //                    SprintIntro.Visible = false;
    //                    SummaryMessage.Visible = false;

    //                }
    //                else if (DropDownList2.SelectedItem.Text.Equals("Start"))
    //                {
    //                    StartIntro.Visible = false;
    //                    SummaryMessage.Visible = false;
    //                }
    //                else if (DropDownList2.SelectedItem.Text.Equals("Hurdle"))
    //                {
    //                    HurdleIntro.Visible = false;
    //                    SummaryMessage.Visible = false;
    //                }
    //                MsgDiv2.Visible = false;
    //            }
    //            Label13.Visible = false;
    //        }
    //        if (AthletesChildId == 1)
    //        {
    //            //Label10.Visible = true;
    //            //Label9.Visible = true;
    //            if (DropDownList2.SelectedItem.Text.Equals("Sprint"))
    //            {
    //                SprintTireText.Visible = true;
    //                StartTireText.Visible = false;
    //                HurdleTireText.Visible = false;
    //                SprintIntro.Visible = false;
    //                SummaryMessage.Visible = false;
    //                StartId.Visible = false;
    //                HurdleId.Visible = false;
    //                wmpfile1 = "../Users/MovieFiles/ModelSprint-Initial-Side.swf";
    //                wmpfile2 = "../Users/MovieFiles/ModelSprint-Initial-Back.swf";
    //            }
    //            else if (DropDownList2.SelectedItem.Text.Equals("Start"))
    //            {
    //                StartTireText.Visible = true;
    //                SprintTireText.Visible = false;
    //                HurdleTireText.Visible = false;
    //                StartIntro.Visible = false;
    //                SummaryMessage.Visible = false;
    //                SprintId.Visible = false;
    //                HurdleId.Visible = false;
    //                wmpfile1 = "../Users/MovieFiles/ModelStart-Initial-Side.swf";
    //                wmpfile2 = "../Users/MovieFiles/ModelStart-Initial-Back.swf";
    //            }
    //            else if (DropDownList2.SelectedItem.Text.Equals("Hurdle"))
    //            {
    //                HurdleTireText.Visible = true;
    //                StartTireText.Visible = false;
    //                SprintTireText.Visible = false;
    //                HurdleIntro.Visible = false;
    //                SummaryMessage.Visible = false;
    //                SprintId.Visible = false;
    //                StartId.Visible = false;
    //                wmpfile1 = "../Users/MovieFiles/ModelHurdle-Side.swf";
    //                wmpfile2 = "../Users/MovieFiles/ModelHurdle-Back.swf";
    //            }
    //        }
    //        Label10.Visible = false;
    //        Label9.Visible = false;
    //        Label7.Visible = false;

    //        if (AthletesChildId == 1)
    //        {
    //            wmpfile1 = "../" + leftMovie.FilePath;
    //            wmpfile2 = "../" + rightMovie.FilePath;
    //        }
    //    }
    //}//new
    
}
