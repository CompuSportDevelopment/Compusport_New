using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Text;
using System.IO;
using SwingModel.Data;
using SwingModel.Entities;
using System.Diagnostics;

public partial class Mobile_CreateMobileFiles : System.Web.UI.Page
//public partial class Mobile_CreateMobileFiles : SwingModel.UI.BasePage
{
    string strUserName = "";
    //string strPassword = "";
    string strEmail = "";
    string strAppType = "";
    int AppType = 0;
    string strGuid = "";
    bool memberExists = false;
    Customer customer;
    string plistFilename = "";
    
    protected override void OnPreRender(EventArgs e)
    {
        strUserName = Request.QueryString.Get("username");
        //strPassword = Request.QueryString.Get("password");
        strEmail = Request.QueryString.Get("email");
        strAppType = Request.QueryString.Get("apptype");
        AppType = Convert.ToInt16(strAppType);

        MembershipUserCollection listUsers = new MembershipUserCollection();
        listUsers = Membership.FindUsersByEmail(strEmail);

        foreach (MembershipUser user in listUsers)
        {
            if (user.UserName.ToLower().Equals(strUserName.ToLower()))
            {
                strGuid = user.ProviderUserKey.ToString();
                memberExists = true;
                break;
            }
        }

        if (memberExists)
        {
            Guid memGuid = new Guid(strGuid);
            customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(memGuid)[0];

            plistFilename = CreateNamePlist(strGuid);

            CreateMyDimensionsPlist(strGuid, customer);
            CreateMyGolfPlist(strGuid, customer);
            CreateVideosPlist(strGuid, customer);
            CreateSharesPlist(strGuid);
            CreateErrorsPlist(strGuid, customer);

            CreateLessonVideos(strGuid, customer);

            Response.Redirect("~/Mobile/XML/" + plistFilename + ".txt");
        }
        else
        {
            // Handle member not found, possibly
            Response.Redirect("~/Mobile/XML/cmfFail.txt");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected string CreateNamePlist(string strGuid)
    {
        string strUnConverted = "";
        string year = "";
        string month = "";
        string todayday = "";
        string hour = "";
        string minute = "";
        string plistFilename = "";

        strUnConverted = strUserName.Replace(" ", "_");
        year = DateTime.Today.Year.ToString();
        month = DateTime.Today.Month.ToString();
        todayday = DateTime.Today.Day.ToString();
        hour = DateTime.Today.Hour.ToString();
        minute = DateTime.Today.Minute.ToString();
        plistFilename = strUnConverted + "_" + year + "_" + month + "_" + todayday + "_" + hour + "_" + minute;

        //string path = @"C:\Projects\SwingModel\Solution\SwingModel Website\Mobile\XML\" + strGuid + ".plist";
        string path = @"G:\SwingModelLive\Mobile\XML\" + strGuid + ".plist";
        FileStream fs = File.Create(path);
        StreamWriter sw = new StreamWriter(fs);

        sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        sw.WriteLine("<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">");
        sw.WriteLine("<plist version=\"1.0\">");
        sw.WriteLine("<array>");
        sw.WriteLine("<string>" + strGuid + "-MyDimensions.plist</string>");
        sw.WriteLine("<string>" + strGuid + "-MyGolf.plist</string>");
        sw.WriteLine("<string>" + strGuid + "-Videos.plist</string>");
        sw.WriteLine("<string>" + strGuid + "-Shares.plist</string>");
        sw.WriteLine("<string>" + strGuid + "-Errors.plist</string>");
        sw.WriteLine("</array>");
        sw.WriteLine("</plist>");
        sw.Close();
        fs.Close();

        //path = @"C:\Projects\SwingModel\Solution\SwingModel Website\Mobile\XML\" + plistFilename + ".txt";
        path = @"G:\SwingModelLive\Mobile\XML\" + plistFilename + ".txt";
        fs = File.Create(path);
        sw = new StreamWriter(fs);
        sw.WriteLine(strGuid + ".plist");
        sw.Close();

        return plistFilename;
    }

    protected void CreateMyDimensionsPlist(string strGuid, Customer customer)
    {
        CustomerProfile customerprofile;

        customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customer.CustomerId)[0];

        //string path = @"C:\Projects\SwingModel\Solution\SwingModel Website\Mobile\XML\" + strGuid + "-MyDimensions.plist";
        string path = @"G:\SwingModelLive\Mobile\XML\" + strGuid + "-MyDimensions.plist";
        FileStream fs = File.Create(path);
        StreamWriter sw = new StreamWriter(fs);

        sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        sw.WriteLine("<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">");
        sw.WriteLine("<plist version=\"1.0\">");
        sw.WriteLine("<array>");
        sw.WriteLine("<integer>" + Convert.ToInt16((customerprofile.Height - 48)).ToString() + "</integer>");
        sw.WriteLine("<integer>" + Convert.ToInt16((customerprofile.Weight - 50)).ToString() + "</integer>");
        sw.WriteLine("<integer>" + Convert.ToInt16(((customerprofile.Shoulder - 12) * 2)).ToString() + "</integer>");
        sw.WriteLine("<integer>" + Convert.ToInt16(((customerprofile.Sleeve - 15) * 2)).ToString() + "</integer>");
        switch (customerprofile.Glove)
        {
            case "Cadet Small":
                sw.WriteLine("<integer>0</integer>");
                break;
            case "Small":
                sw.WriteLine("<integer>1</integer>");
                break;
            case "Cadet Medium":
                sw.WriteLine("<integer>2</integer>");
                break;
            case "Medium":
                sw.WriteLine("<integer>3</integer>");
                break;
            case "Cadet Medium Large":
                sw.WriteLine("<integer>4</integer>");
                break;
            case "Medium Large":
                sw.WriteLine("<integer>5</integer>");
                break;
            case "Cadet Large":
                sw.WriteLine("<integer>6</integer>");
                break;
            case "Large":
                sw.WriteLine("<integer>7</integer>");
                break;
            case "Cadet Extra Large":
                sw.WriteLine("<integer>8</integer>");
                break;
            case "Extra Large":
                sw.WriteLine("<integer>9</integer>");
                break;
            case "Cadet Double XL":
                sw.WriteLine("<integer>10</integer>");
                break;
            case "Double XL":
                sw.WriteLine("<integer>11</integer>");
                break;
            case "Triple XL":
                sw.WriteLine("<integer>12</integer>");
                break;
            default:
                sw.WriteLine("<integer>3</integer>");
                break;
        }
        sw.WriteLine("<integer>" + Convert.ToInt16(((customerprofile.Waist - 25) * 2)).ToString() + "</integer>");
        sw.WriteLine("<integer>" + Convert.ToInt16(((customerprofile.Inseam - 20) * 2)).ToString() + "</integer>");
        sw.WriteLine("<integer>" + Convert.ToInt16(((customerprofile.Shoe - 1) * 2)).ToString() + "</integer>");
        sw.WriteLine("</array>");
        sw.WriteLine("</plist>");
        sw.Close();
        fs.Close();

        return;
    }

    protected void CreateMyGolfPlist(string strGuid, Customer customer)
    {
        CustomerProfile customerprofile;

        customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customer.CustomerId)[0];

        //string path = @"C:\Projects\SwingModel\Solution\SwingModel Website\Mobile\XML\" + strGuid + "-MyGolf.plist";
        string path = @"G:\SwingModelLive\Mobile\XML\" + strGuid + "-MyGolf.plist";
        FileStream fs = File.Create(path);
        StreamWriter sw = new StreamWriter(fs);

        sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        sw.WriteLine("<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">");
        sw.WriteLine("<plist version=\"1.0\">");
        sw.WriteLine("<array>");
        switch (customerprofile.Age)
        {
            case "Adult (15-55)":
                sw.WriteLine("<integer>0</integer>");
                break;
            case "Junior (Under 15)":
                sw.WriteLine("<integer>1</integer>");
                break;
            case "Senior (over 55)":
                sw.WriteLine("<integer>2</integer>");
                break;
            default:
                sw.WriteLine("<integer>0</integer>");
                break;
        }
        switch (customerprofile.Hand)
        {
            case "Right":
                sw.WriteLine("<integer>0</integer>");
                break;
            case "Left":
                sw.WriteLine("<integer>1</integer>");
                break;
            default:
                sw.WriteLine("<integer>0</integer>");
                break;
        }
        sw.WriteLine("<integer>" + Convert.ToInt16(customerprofile.Hcp).ToString() + "</integer>");
        switch (customerprofile.Rounds)
        {
            case "0-5 Rounds/Year":
                sw.WriteLine("<integer>0</integer>");
                break;
            case "6-12 Rounds/Year":
                sw.WriteLine("<integer>1</integer>");
                break;
            case "13-24 Rounds/Year":
                sw.WriteLine("<integer>2</integer>");
                break;
            case "24+ Rounds/Year":
                sw.WriteLine("<integer>3</integer>");
                break;
            default:
                sw.WriteLine("<integer>0</integer>");
                break;
        }
        switch (customerprofile.Practice)
        {
            case "0-5 Sessions/Year":
                sw.WriteLine("<integer>0</integer>");
                break;
            case "6-12 Sessions/Year":
                sw.WriteLine("<integer>1</integer>");
                break;
            case "13-24 Sessions/Year":
                sw.WriteLine("<integer>2</integer>");
                break;
            case "24+ Sessions/Year":
                sw.WriteLine("<integer>3</integer>");
                break;
            default:
                sw.WriteLine("<integer>0</integer>");
                break;
        }
        switch (customerprofile.Lessons)
        {
            case "0-5 Lessons/Year":
                sw.WriteLine("<integer>0</integer>");
                break;
            case "6-12 Lessons/Year":
                sw.WriteLine("<integer>1</integer>");
                break;
            case "13-24 Lessons/Year":
                sw.WriteLine("<integer>2</integer>");
                break;
            case "24+ Lessons/Year":
                sw.WriteLine("<integer>3</integer>");
                break;
            case "24+Lessons/Year":
                sw.WriteLine("<integer>3</integer>");
                break;
            default:
                sw.WriteLine("<integer>0</integer>");
                break;
        }
        switch (customerprofile.Altitude)
        {
            case "Under 1000 Feet":
                sw.WriteLine("<integer>0</integer>");
                break;
            case "1000-2000 Feet":
                sw.WriteLine("<integer>1</integer>");
                break;
            case "2000-3000 Feet":
                sw.WriteLine("<integer>2</integer>");
                break;
            case "3000-4000 Feet":
                sw.WriteLine("<integer>3</integer>");
                break;
            case "4000-5000 Feet":
                sw.WriteLine("<integer>4</integer>");
                break;
            case "5000-6000 Feet":
                sw.WriteLine("<integer>5</integer>");
                break;
            case "6000-7000 Feet":
                sw.WriteLine("<integer>6</integer>");
                break;
            case "7000-8000 Feet":
                sw.WriteLine("<integer>7</integer>");
                break;
            case "Over 8000 Feet":
                sw.WriteLine("<integer>8</integer>");
                break;
            default:
                sw.WriteLine("<integer>0</integer>");
                break;
        }
        switch (customerprofile.Wind)
        {
            case "Low":
                sw.WriteLine("<integer>0</integer>");
                break;
            case "Typical":
                sw.WriteLine("<integer>1</integer>");
                break;
            case "High":
                sw.WriteLine("<integer>2</integer>");
                break;
            default:
                sw.WriteLine("<integer>1</integer>");
                break;
        }
        switch (customerprofile.Roll)
        {
            case "Soft (Low Roll)":
                sw.WriteLine("<integer>0</integer>");
                break;
            case "Average (Normal Roll)":
                sw.WriteLine("<integer>1</integer>");
                break;
            case "Firm (High Roll)":
                sw.WriteLine("<integer>2</integer>");
                break;
            case "Very Firm (Very High Roll)":
                sw.WriteLine("<integer>3</integer>");
                break;
            default:
                sw.WriteLine("<integer>1</integer>");
                break;
        }

        sw.WriteLine("</array>");
        sw.WriteLine("</plist>");
        sw.Close();
        fs.Close();

        return;
    }
    
    protected void CreateVideosPlist(string strGuid, Customer customer)
    {
        TList<Lesson> lessons = new TList<Lesson>();
        TList<Movie> movies = new TList<Movie>();
        TList<MovieClip> movieclips = new TList<MovieClip>();
        SummaryMovie summarymovie = new SummaryMovie();
        string DashedName;
        string Mp4Filename;
        string SummaryFilename;
        
        DashedName = customer.LastName.ToLower() + "-" + customer.FirstName.ToLower();
        
        //string path = @"C:\Projects\SwingModel\Solution\SwingModel Website\Mobile\XML\" + strGuid + "-Videos.plist";
        string path = @"G:\SwingModelLive\Mobile\XML\" + strGuid + "-Videos.plist";
        FileStream fs = File.Create(path);
        StreamWriter sw = new StreamWriter(fs);

        sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        sw.WriteLine("<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">");
        sw.WriteLine("<plist version=\"1.0\">");
        sw.WriteLine("<array>");
        lessons = DataRepository.LessonProvider.GetByCustomerId(customer.CustomerId);
        foreach (Lesson l in lessons)
        {
            movies = DataRepository.MovieProvider.GetByLessonId(l.LessonId);
            foreach (Movie m in movies)
            {
                switch (m.MovieType)
                {
                    case 0:
                        Mp4Filename = m.FilePath.ToLower().Replace("Users/MovieFiles/".ToLower() + DashedName.ToLower(), strGuid);
                        Mp4Filename = Mp4Filename.ToLower().Replace(".swf", ".mp4");
                        sw.WriteLine("<string>" + Mp4Filename + "</string>");
                        break;
                    case 1:
                        Mp4Filename = m.FilePath.ToLower().Replace("Users/MovieFiles/".ToLower() + DashedName.ToLower(), strGuid);
                        Mp4Filename = Mp4Filename.ToLower().Replace(".swf", ".mp4");
                        sw.WriteLine("<string>" + Mp4Filename + "</string>");
                        movieclips = DataRepository.MovieClipProvider.GetByMovieId(m.MovieId);
                        movieclips.Sort("EndFrame");
                        foreach (MovieClip mc in movieclips)
                        {
                            sw.WriteLine("<integer>" + mc.EndFrame.ToString() + "</integer>");
                        }
                        break;
                    case 2:
                        Mp4Filename = m.FilePath.ToLower().Replace("Users/MovieFiles/".ToLower() + DashedName.ToLower(), strGuid);
                        Mp4Filename = Mp4Filename.ToLower().Replace(".swf", ".mp4");
                        sw.WriteLine("<string>" + Mp4Filename + "</string>");
                        break;
                    case 3:
                        Mp4Filename = m.FilePath.ToLower().Replace("Users/MovieFiles/".ToLower() + DashedName.ToLower(), strGuid);
                        Mp4Filename = Mp4Filename.ToLower().Replace(".swf", ".mp4");
                        sw.WriteLine("<string>" + Mp4Filename + "</string>");
                        movieclips = DataRepository.MovieClipProvider.GetByMovieId(m.MovieId);
                        movieclips.Sort("EndFrame");
                        foreach (MovieClip mc in movieclips)
                        {
                            sw.WriteLine("<integer>" + mc.EndFrame.ToString() + "</integer>");
                        }
                        break;
                }
            }
            try
            {
                summarymovie = DataRepository.SummaryMovieProvider.GetByLessonId(l.LessonId)[0];
                SummaryFilename = summarymovie.FilePath.ToLower().Replace("Users/SummaryFiles/".ToLower() + DashedName.ToLower(), strGuid);
                SummaryFilename = SummaryFilename.ToLower().Replace(".swf", ".mp4");
            }
            catch (Exception ex)
            {
                SummaryFilename = "";
            }
            sw.WriteLine("<string>" + SummaryFilename + "</string>");
        }
        
        sw.WriteLine("</array>");
        sw.WriteLine("</plist>");
        sw.Close();
        fs.Close();

        return;
    }

    protected void CreateSharesPlist(string strGuid)
    {
        //string path = @"C:\Projects\SwingModel\Solution\SwingModel Website\Mobile\XML\" + strGuid + "-Shares.plist";
        string path = @"G:\SwingModelLive\Mobile\XML\" + strGuid + "-Shares.plist";
        FileStream fs = File.Create(path);
        StreamWriter sw = new StreamWriter(fs);

        sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        sw.WriteLine("<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">");
        sw.WriteLine("<plist version=\"1.0\">");
        sw.WriteLine("<array>");
        sw.WriteLine("<string></string>");
        sw.WriteLine("</array>");
        sw.WriteLine("</plist>");
        sw.Close();
        fs.Close();

        return;
    }

    protected void CreateErrorsPlist(string strGuid, Customer customer)
    {
        TList<Lesson> lessons = new TList<Lesson>();
        TList<Movie> movies = new TList<Movie>();
        TList<MovieClip> movieclips = new TList<MovieClip>();
        TList<MovieError> movieerrors = new TList<MovieError>(); 
        SwingErrorLookup sel = new SwingErrorLookup();

        //string path = @"C:\Projects\SwingModel\Solution\SwingModel Website\Mobile\XML\" + strGuid + "-Errors.plist";
        string path = @"G:\SwingModelLive\Mobile\XML\" + strGuid + "-Errors.plist";
        FileStream fs = File.Create(path);
        StreamWriter sw = new StreamWriter(fs);

        sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        sw.WriteLine("<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">");
        sw.WriteLine("<plist version=\"1.0\">");
        sw.WriteLine("<array>");

        lessons = DataRepository.LessonProvider.GetByCustomerId(customer.CustomerId);
        foreach (Lesson l in lessons)
        {
            sw.WriteLine("<array>");
            sw.WriteLine("<string>" + l.LessonDate.Year.ToString() + "-" + l.LessonDate.Month.ToString() + "-" + l.LessonDate.Day.ToString() + "-" + l.LessonDate.Hour.ToString() + "-" + l.LessonDate.Minute.ToString() + "</string>");
            movies = DataRepository.MovieProvider.GetByLessonId(l.LessonId);
            movieclips = DataRepository.MovieClipProvider.GetByMovieId(movies[0].MovieId);
            movieclips.Sort("EndFrame");
            for (int i = 0; i < 10; i++)
            {
                sw.WriteLine("<array>");
                sw.WriteLine("<integer>" + (i + 1).ToString() + "</integer>");
                movieerrors = DataRepository.MovieErrorProvider.GetByMovieClipId(movieclips[i].MovieClipId);
                if (movieerrors.Count < 1)
                    sw.WriteLine("<string></string>");
                else
                {
                    foreach (MovieError me in movieerrors)
                    {
                        sel = DataRepository.SwingErrorLookupProvider.GetBySwingErrorId(me.SwingErrorId);
                        sw.WriteLine("<string>" + sel.TextDescription + "</string>");
                    }
                }
                sw.WriteLine("</array>");
            }
            sw.WriteLine("</array>");
        }

        sw.WriteLine("</array>");
        sw.WriteLine("</plist>");
        sw.Close();
        fs.Close();

        return;
    }

    protected void CreateLessonVideos(string strGuid, Customer customer)
    {
        TList<Lesson> lessons = new TList<Lesson>();
        TList<Movie> movies = new TList<Movie>();
        SummaryMovie summarymovie = new SummaryMovie();
        string args = "";
        string DashedName = "";
        string Mp4Filename = "";
        string SummaryFilename = "";

        DashedName = customer.LastName.ToLower() + "-" + customer.FirstName.ToLower();

        lessons = DataRepository.LessonProvider.GetByCustomerId(customer.CustomerId);
        foreach (Lesson l in lessons)
        {
            movies = DataRepository.MovieProvider.GetByLessonId(l.LessonId);
            foreach (Movie m in movies)
            {
                switch (m.MovieType)
                {
                    case 0:
                        Mp4Filename = m.FilePath.ToLower().Replace("Users/MovieFiles/".ToLower() + DashedName.ToLower(), strGuid);
                        Mp4Filename = Mp4Filename.ToLower().Replace(".swf", ".mp4");
                        break;
                    case 1:
                        Mp4Filename = m.FilePath.ToLower().Replace("Users/MovieFiles/".ToLower() + DashedName.ToLower(), strGuid);
                        Mp4Filename = Mp4Filename.ToLower().Replace(".swf", ".mp4");
                        break;
                    case 2:
                        Mp4Filename = m.FilePath.ToLower().Replace("Users/MovieFiles/".ToLower() + DashedName.ToLower(), strGuid);
                        Mp4Filename = Mp4Filename.ToLower().Replace(".swf", ".mp4");
                        break;
                    case 3:
                        Mp4Filename = m.FilePath.ToLower().Replace("Users/MovieFiles/".ToLower() + DashedName.ToLower(), strGuid);
                        Mp4Filename = Mp4Filename.ToLower().Replace(".swf", ".mp4");
                        break;
                }
                args = "-i \"G:\\SwingModelLive\\Users\\MovieFiles\\" + m.FilePath.Replace("Users/MovieFiles/", "") + "\" -y \"G:\\SwingModelLive\\Mobile\\Video\\" + Mp4Filename + "\"";
                ProcessStartInfo processInfo = new ProcessStartInfo(Server.MapPath("") + "\\ffmpeg.exe", args);
                //MessageBox.Show(processInfo.FileName);
                //MessageBox.Show(args);
                //processInfo.WindowStyle = ProcessWindowStyle.Normal;
                processInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processInfo.UseShellExecute = true;
                Process process = new Process();
                process = Process.Start(processInfo);
                process.WaitForExit(2000);
            }

            try
            {
                summarymovie = DataRepository.SummaryMovieProvider.GetByLessonId(l.LessonId)[0];
                SummaryFilename = summarymovie.FilePath.ToLower().Replace("Users/SummaryFiles/".ToLower() + DashedName.ToLower(), strGuid);
                SummaryFilename = SummaryFilename.ToLower().Replace(".swf", ".mp4");

                args = "-i \"G:\\SwingModelLive\\Users\\SummaryFiles\\" + summarymovie.FilePath.ToLower().Replace("Users/SummaryFiles/".ToLower(), "") + "\" -y \"G:\\SwingModelLive\\Mobile\\Video\\" + SummaryFilename + "\"";
                ProcessStartInfo processInfo = new ProcessStartInfo(Server.MapPath("") + "\\ffmpeg.exe", args);
                //MessageBox.Show(processInfo.FileName);
                //MessageBox.Show(args);
                //processInfo.WindowStyle = ProcessWindowStyle.Normal;
                processInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processInfo.UseShellExecute = true;
                Process process = new Process();
                process = Process.Start(processInfo);
                process.WaitForExit(2000);
            }
            catch (Exception ex)
            {

            }
        }

        return;
    }
}
