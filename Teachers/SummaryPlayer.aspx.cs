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
using MemberDownload;
using SwingModel.Data;
using SwingModel.Entities;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using SwfDotNet.IO;
using System.Drawing;
using CompuSportDAL;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using iTextSharp.text;
using iTextSharp.text.pdf;

//public partial class Teachers_SummaryPlayer : System.Web.UI.Page
public partial class Teachers_SummaryPlayer : SwingModel.UI.BasePage
{
    static int customerId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.Params["customerid"]))
        {
            //Session["customerid"] = Convert.ToInt32(Request.Params["customerid"]);
            Session["customerid"] = Convert.ToInt32(Request.Params["customerid"]);
            customerId = Convert.ToInt16(Request.Params["customerid"]);
        }
    }
    [System.Web.Services.WebMethod]
    public static string OpenPDFInNewTab(string DropDownList1Text, string DropDownList1Value, string DropDownList2Text, string DropDownList2Value, string DropDownList3Text, string DropDownList3Value, string PassResultScoreI, string PassResultScoreF, string PassResultScoreM1, string PassResultScoreM2, string PassGeneralScoreI, string PassGeneralScoreM1, string PassGeneralScoreF, string PassGeneralScoreM2, string PassSpecialScoreI, string PassSpecialScoreF, string PassSpecialScoreM1, string PassSpecialScoreM2, string PassSpecificScoreI, string PassSpecificScoreM1, string PassSpecificScoreF, string PassSpecificScoreM2)
    {

        //ArrayList P4Error = P4Errortemp;
        string pdffile = string.Empty;
        string summaryCheckLocation = DropDownList1Text;
        var SummaryCheckPage = DropDownList2Text;
        var lessiodatelocaonMiddle = DropDownList1Text;
        string lessiodatelocaonRight = DropDownList3Text;
        string[] Chars = new string[] { "-", "–", ",", "*", ".", " ", "  " };
        foreach (var c in Chars)
        {
            summaryCheckLocation = summaryCheckLocation.Replace(c, string.Empty);
        }
        foreach (var c in Chars)
        {
            lessiodatelocaonRight = lessiodatelocaonRight.Replace(c, string.Empty);
        }
        //if (summaryCheckLocation.Trim().ToLower() == lessiodatelocaonRight.Trim().ToLower())
        //{
        int movieid = Convert.ToInt32(DropDownList1Value);
        var leftMovie = DataRepository.MovieProvider.GetByMovieId(movieid);
        var lesson = DataRepository.LessonProvider.GetByLessonId(leftMovie.LessonId);
        DateTime date = lesson.LessonDate;
        string Date = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();
        SprintAthleteEdit sae = new SprintAthleteEdit();
        string location = sae.SelectLessonlocation(lesson.LessonId.ToString());
        string pdfpath = AppDomain.CurrentDomain.BaseDirectory + @"PDF_Folder";
        string imagepath = System.AppDomain.CurrentDomain.BaseDirectory + "Images"; //"~/Images";
        ArrayList P4errorList = Controls_TeachersDualPlayer.arrErrorMessages1;
        P4errorList.ToArray().Distinct();
        Customer customer = DataRepository.CustomerProvider.GetByCustomerId(customerId);

        if (SummaryCheckPage == "Sprint")
            pdffile = "CompuSport Sprint Summary-" + customer.FirstName + "" + customer.LastName + " " + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".pdf";
        else
        {
            if (SummaryCheckPage == "Start")
                pdffile = "CompuSport Start Summary-" + customer.FirstName + "" + customer.LastName + " " + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".pdf";
            else
            {
                if (SummaryCheckPage == "Hurdle")
                    pdffile = "CompuSport Hurdle Summary-" + customer.FirstName + "" + customer.LastName + " " + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".pdf";
                else
                    pdffile = "CompuSport Hurdle Steps Summary-" + customer.FirstName + "" + customer.LastName + " " + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".pdf";
            }
        }
        bool sessionmode = false;
        var pdfname = Path.Combine(pdfpath, pdffile);
        Document doc = new Document();
        try
        {
            PdfWriter.GetInstance(doc, new FileStream(pdfname, FileMode.Create));
            doc.Open();
            iTextSharp.text.Image JPG = iTextSharp.text.Image.GetInstance(imagepath + "/PDF_Error.JPG");
            JPG.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            JPG.ScaleAbsolute(500f, 100f);
            doc.Add(JPG);
            doc.Add(new Paragraph("\n"));
            iTextSharp.text.Font myFontread = FontFactory.GetFont("Arial", 12, new iTextSharp.text.BaseColor(255, 0, 0));
            iTextSharp.text.Font myFont1 = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font myFont = FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font myFont2 = FontFactory.GetFont("Arial", 20, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font myFont3 = FontFactory.GetFont("Arial", 12, new iTextSharp.text.BaseColor(255, 0, 0));
            if (summaryCheckLocation.Trim().ToLower() == lessiodatelocaonRight.Trim().ToLower())
            {
                //Paragraph preface = new Paragraph("Single Session" + SummaryCheckPage + " " + "Analysis: " + customer.FirstName + " " + customer.LastName, myFont2);
                Paragraph preface = new Paragraph("Single Session " + SummaryCheckPage + " " + "Analysis", myFont2);
                preface.Alignment = Element.ALIGN_CENTER;
                doc.Add(preface);

                preface = new Paragraph(customer.FirstName + " " + customer.LastName, myFont2);
                preface.Alignment = Element.ALIGN_CENTER;
                doc.Add(preface);

                doc.Add(new Paragraph("\n"));

                Paragraph Sprint_Session = new Paragraph("Session: " + DropDownList1Text);
                Sprint_Session.Alignment = Element.ALIGN_CENTER;
                doc.Add(Sprint_Session);

                doc.Add(new Paragraph("\n"));
            }
            else
            {
                //Paragraph preface = new Paragraph("Two Session (Comparison)" + " " + SummaryCheckPage + " " + "Analysis: " + customer.FirstName + " " + customer.LastName, myFont2);
                Paragraph preface = new Paragraph("Two Session (Comparison) " + " " + SummaryCheckPage + " " + "Analysis", myFont2);
                preface.Alignment = Element.ALIGN_CENTER;
                doc.Add(preface);

                preface = new Paragraph(customer.FirstName + " " + customer.LastName, myFont2);
                preface.Alignment = Element.ALIGN_CENTER;
                doc.Add(preface);

                doc.Add(new Paragraph("\n"));

                //Paragraph Sprint_Session = new Paragraph("Session: " + DropDownList1Text + " " + "AND" + " " + DropDownList3Text);
                Paragraph Sprint_Session = new Paragraph("Session1: " + DropDownList1Text);
                Sprint_Session.Alignment = Element.ALIGN_CENTER;
                doc.Add(Sprint_Session);

                Sprint_Session = new Paragraph("Session2: " + DropDownList3Text);
                Sprint_Session.Alignment = Element.ALIGN_CENTER;
                doc.Add(Sprint_Session);

                doc.Add(new Paragraph("\n"));
                sessionmode = true;
            }

            if (sessionmode == true)
            {
                if (SummaryCheckPage == "Sprint")
                    doc.Add(new Paragraph("This is a summary of the Comparison of the two On-Track and/or Competitive Sprint Sessions listed above. Performance Variables that are flagged as errors are identified in four Groups: Result, General, Special, and Specific. The challenge for the Elite Coach is to improve the Specific Performance Descriptors which will, in turn, improve the results in the remaining Groups."));
                else
                {
                    if (SummaryCheckPage == "Start")
                        doc.Add(new Paragraph("This is a summary of the Comparison of the two On-Track and/or Competitive Start Sessions listed above. Performance Variables that are flagged as errors are identified in three Groups: Result, General, and Specific. The challenge for the Elite Coach is to improve the Specific Performance Descriptors which will, in turn, improve the results in the remaining Groups."));
                    else
                    {
                        if (SummaryCheckPage == "Hurdle")
                            doc.Add(new Paragraph("This is a summary of the Comparison of the two On-Track and/or Competitive Hurdle Sessions listed above. Performance Variables that are flagged as errors are identified in three Groups: Result, General, and Specific. The challenge for the Elite Coach is to improve the Specific Performance Descriptors which will, in turn, improve the results in the remaining Groups."));
                        else
                            doc.Add(new Paragraph("This is a summary of the Comparison of the two On-Track and/or Competitive Hurdle Steps Sessions listed above. Performance Variables that are flagged as errors are identified in three Groups: Result, General, and Specific. The challenge for the Elite Coach is to improve the Specific Performance Descriptors which will, in turn, improve the results in the remaining Groups."));
                    }
                }

                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("It is important to remember that, for each of the Groups, Errors are only listed IF THE ERROR IS PRESENT IN BOTH SESSIONS. If the Errors listed consistently occur across time (i.e. between months or years in Practice and/or Competition) or between Session types (i.e. Practice vs Competition or Non-Fatigue vs Fatigue), then the Error can be considered a primary issue to be resolved."));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("If all of the Errors for each Session is wanted, return to the Player and create this Report with only one Session loaded in the Player."));
            }
            else
            {
                if (SummaryCheckPage == "Sprint")
                    doc.Add(new Paragraph("This is a summary of the On-Track or Competitive Sprint Session listed above. Performance Variables that are flagged as errors are identified in four Groups: Result, General, Special, and Specific. The challenge for the Elite Coach is to improve the Specific Performance Descriptors which will, in turn, improve the results in the remaining Groups."));
                else
                {
                    if (SummaryCheckPage == "Start")
                        doc.Add(new Paragraph("This is a summary of the On-Track or Competitive Start Session listed above. Performance Variables that are flagged as errors are identified in three Groups: Result, General, and Specific. The challenge for the Elite Coach is to improve the Specific Performance Descriptors which will, in turn, improve the results in the remaining Groups."));
                    else
                    {
                        if (SummaryCheckPage == "Hurdle")
                            doc.Add(new Paragraph("This is a summary of the On-Track or Competitive Hurdle Session listed above. Performance Variables that are flagged as errors are identified in three Groups: Result, General, and Specific. The challenge for the Elite Coach is to improve the Specific Performance Descriptors which will, in turn, improve the results in the remaining Groups."));
                        else
                            doc.Add(new Paragraph("This is a summary of the On-Track or Competitive Hurdle Steps Between Session listed above. Performance Variables that are flagged as errors are identified in three Groups: Result, General, and Specific. The challenge for the Elite Coach is to improve the Specific Performance Descriptors which will, in turn, improve the results in the remaining Groups."));
                    }
                }
            }

            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("Result:", myFont));
            doc.Add(new Paragraph("\n"));

            if (SummaryCheckPage == "Sprint")
                doc.Add(new Paragraph("The Variable that is the end product of all of the athlete's efforts is put in the Result category. In the Sprint, this Variable is the Horizontal Velocity down the Track. Since this result is compared to the velocity required to produce a World Record effort, it is extremely rare for this variable not to be flagged as one to be improved."));
            else
            {
                if (SummaryCheckPage == "Start")
                    doc.Add(new Paragraph("The Variables that are the end products of all of the athlete's efforts are put in the Result category. In the Start, these Variables include the Time from the first movement to when the Head reaches 3 and 5 Meter Marks and the Horizontal Velocity when the Body Center (COG) reaches the 3 Meter Mark. Since these results are compared to the results required to produce a World Record effort, it is extremely rare for these variables not to be flagged as ones to be improved."));
                else
                {
                    if (SummaryCheckPage == "Hurdle")
                        doc.Add(new Paragraph("The Variable that is the end product of all of the athlete's efforts is put in the Result category. In the Hurdles, this Variable is the Horizontal Velocity during Hurdle Clearance. Since this result is compared to the velocity required to produce a World Record effort, it is extremely rare for this variable not to be flagged as one to be improved."));
                    else
                        doc.Add(new Paragraph("The Variable that is the end product of all of the athlete's efforts is put in the Result category. In the Steps Between the Hurdles, this Variable is the Horizontal Velocity down the Track. Since this result is compared to the velocity required to produce a World Record effort, it is extremely rare for this variable not to be flagged as one to be improved."));
                }
            }

            doc.Add(new Paragraph("\n"));
            ////Paragraph Sprint_Result = new Paragraph(Controls_TeachersDualPlayer.ErrorList._resultMsg, myFontread);
            ////Sprint_Result.Alignment = Element.ALIGN_CENTER;
            ////doc.Add(Sprint_Result);

            ArrayList errorList_Result = new ArrayList();
            foreach (string aString in P4errorList)
            {
                if (!errorList_Result.Contains(aString))
                {
                    errorList_Result.Add(aString);
                }
            }
            ArrayList P4errorList2 = new ArrayList();
            if (errorList_Result != null)
            {
                var sessionError1 = errorList_Result;
                for (int i = 0; i < sessionError1.Count; i++)
                {
                    if (!String.IsNullOrEmpty(sessionError1[i].ToString()))
                    {
                        var errmsg = sessionError1[i].ToString().Split(':');
                        P4errorList2.Add(errmsg[1].Trim());
                    }
                }
            }
            ArrayList errorListResult = new ArrayList();
            if (P4errorList2 != null)
            {
                foreach (string aString in Controls_TeachersDualPlayer.ErrorList._resultMsg)
                {
                    if (!errorListResult.Contains(aString))
                    {
                        errorListResult.Add(aString);
                    }
                }

                var nerrorListResult = new ArrayList();

                for (int i = 0; i < errorListResult.Count; i++)
                {
                    var errmsg = errorListResult[i].ToString().Trim();

                    if (P4errorList2.Contains(errmsg))
                    {
                        nerrorListResult.Add(errmsg);
                    }
                }
                if (nerrorListResult != null)
                {
                    var FontColour = new BaseColor(255, 0, 0);
                    for (int i = 0; i < nerrorListResult.Count; i++)
                    {
                        Paragraph ErrorlistAirr = new Paragraph(nerrorListResult[i].ToString());
                        ErrorlistAirr.IndentationLeft = 25f;
                        ErrorlistAirr.Font.Color = FontColour;
                        doc.Add(ErrorlistAirr);
                    }
                }

                if (nerrorListResult.Count == 0)
                {
                    Paragraph No_Text;

                    if (SummaryCheckPage == "Sprint")
                        No_Text = new Paragraph("There Are No Sprint Result Errors", myFont3);
                    else
                    {
                        if (SummaryCheckPage == "Start")
                            No_Text = new Paragraph("There Are No Start Result Errors", myFont3);
                        else
                        {
                            if (SummaryCheckPage == "Hurdle")
                                No_Text = new Paragraph("There Are No Hurdle Result Errors", myFont3);
                            else
                                No_Text = new Paragraph("There Are No Hurdle Step Result Errors", myFont3);
                        }
                    }

                    No_Text.IndentationLeft = 15f;
                    doc.Add(No_Text);
                }
            }

            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("General Performance Descriptors:", myFont));
            doc.Add(new Paragraph("\n"));

            if (SummaryCheckPage == "Sprint")
                doc.Add(new Paragraph("The variables in this Group identify how well the athlete is doing in creating the Time and Rate results, but they do not identify how the performer is mechanically producing the results. They are critical, however, in determining what areas needs to be addressed for improvement to occur.  They are listed below where they occur - either in the Ground Phase or the Air Phase."));
            else
                doc.Add(new Paragraph("The variables in this Group identify how well the athlete is doing in creating the Time, Rate, and Distance results; but they do not identify how the performer is mechanically producing the results. They are critical, however, in determining what areas needs to be addressed for improvement to occur.  They are listed below where they occur - either in the Ground Phase or the Air Phase."));

            doc.Add(new Paragraph("\n"));
            //--------------------------------------------------------------------------------------->>>>>>>>>>Ground Phase
            Paragraph Sprint_Ground = new Paragraph("Ground Phase:", myFont1);
            Sprint_Ground.IndentationLeft = 15f;
            doc.Add(Sprint_Ground);
            doc.Add(new Paragraph("\n"));

            ArrayList errorList_Ground = new ArrayList();
            foreach (string aString in P4errorList)
            {
                if (!errorList_Ground.Contains(aString))
                {
                    errorList_Ground.Add(aString);
                }
            }
            // ArrayList P4errorList2 = new ArrayList();
            if (errorList_Ground != null)
            {
                var sessionError1 = errorList_Ground;
                for (int i = 0; i < sessionError1.Count; i++)
                {
                    if (!String.IsNullOrEmpty(sessionError1[i].ToString()))
                    {
                        var errmsg = sessionError1[i].ToString().Split(':');
                        P4errorList2.Add(errmsg[1].Trim());
                    }
                }
            }
            ArrayList errorListGeneral = new ArrayList();
            if (P4errorList2 != null)
            {
                foreach (string aString in Controls_TeachersDualPlayer.ErrorList._generalMsgs)
                {
                    if (!errorListGeneral.Contains(aString))
                    {
                        errorListGeneral.Add(aString);
                    }
                }

                var nerrorListGeneral = new ArrayList();

                for (int i = 0; i < errorListGeneral.Count; i++)
                {
                    var errmsg = errorListGeneral[i].ToString().Trim();

                    if (P4errorList2.Contains(errmsg))
                    {
                        nerrorListGeneral.Add(errmsg);
                    }
                }
                if (nerrorListGeneral != null)
                {
                    var FontColour = new BaseColor(255, 0, 0);
                    for (int i = 0; i < nerrorListGeneral.Count; i++)
                    {
                        Paragraph ErrorlistAirr = new Paragraph(nerrorListGeneral[i].ToString());
                        ErrorlistAirr.IndentationLeft = 20f;
                        ErrorlistAirr.Font.Color = FontColour;
                        doc.Add(ErrorlistAirr);
                    }

                    if (nerrorListGeneral.Count == 0)
                    {
                        Paragraph No_Text = new Paragraph("There Are No Ground Phase Errors", myFont3);
                        No_Text.IndentationLeft = 20f;
                        doc.Add(No_Text);
                    }
                }
            }
            doc.Add(new Paragraph("\n"));
            //---------------------------------------------------------------------------------------------------->>>>>>>>>//Air Phase
            Paragraph Sprint_Air = new Paragraph("Air Phase:", myFont1);
            Sprint_Air.IndentationLeft = 15f;
            doc.Add(Sprint_Air);
            doc.Add(new Paragraph("\n"));
            ArrayList errorListAir = new ArrayList();
            foreach (string aString in Controls_TeachersDualPlayer.ErrorList._airMsgs)
            {
                if (!errorListAir.Contains(aString))
                {
                    errorListAir.Add(aString);
                }
            }
            var nerrorListAir = new ArrayList();
            for (int i = 0; i < errorListAir.Count; i++)
            {
                var errmsg = errorListAir[i].ToString().Trim();

                if (P4errorList2.Contains(errmsg))
                {
                    nerrorListAir.Add(errmsg);
                }
            }
            if (nerrorListAir != null)
            {
                var FontColour = new BaseColor(255, 0, 0);
                for (int i = 0; i < nerrorListAir.Count; i++)
                {
                    Paragraph ErrorlistAirr = new Paragraph(nerrorListAir[i].ToString());
                    ErrorlistAirr.IndentationLeft = 20f;
                    ErrorlistAirr.Font.Color = FontColour;
                    doc.Add(ErrorlistAirr);
                }

                if (nerrorListAir.Count == 0)
                {
                    Paragraph No_Text = new Paragraph("There Are No Air Phase Errors", myFont3);
                    No_Text.IndentationLeft = 20f;
                    doc.Add(No_Text);
                }
            }
            //--------------------------------------------------------------------------------------------------->>>>>>>>>>>
            if (SummaryCheckPage == "Sprint")//Currently no Special Scores in any event except the Sprint
            {
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("Special Performance Descriptors:", myFont));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("Stride Length in the Sprint is placed in its own Special group because it is evaluated differently than other Variables. Because the actual Length result is directly affected by Air Time, to determine if the Length is actually a problem the result is adjusted for the athlete's actual Air Time. This error can be mechanically based, but in most cases it is due to the athlete's inability to generate sufficient Dynamic Strength during Ground contact."));
                doc.Add(new Paragraph("\n"));
                //Paragraph Sprint_specialMsg = new Paragraph(Controls_TeachersDualPlayer.ErrorList._specialMsg, myFontread);
                //Sprint_specialMsg.Alignment = Element.ALIGN_CENTER;
                //doc.Add(Sprint_specialMsg);

                ArrayList errorList_special = new ArrayList();
                foreach (string aString in P4errorList)
                {
                    if (!errorList_special.Contains(aString))
                    {
                        errorList_special.Add(aString);
                    }
                }
                // ArrayList P4errorList2 = new ArrayList();
                if (errorList_special != null)
                {
                    var sessionError1 = errorList_special;
                    for (int i = 0; i < sessionError1.Count; i++)
                    {
                        if (!String.IsNullOrEmpty(sessionError1[i].ToString()))
                        {
                            var errmsg = sessionError1[i].ToString().Split(':');
                            P4errorList2.Add(errmsg[1].Trim());
                        }
                    }
                }
                ArrayList errorListspecial = new ArrayList();
                if (P4errorList2 != null)
                {
                    foreach (string aString in Controls_TeachersDualPlayer.ErrorList._specialMsg)
                    {
                        if (!errorListspecial.Contains(aString))
                        {
                            errorListspecial.Add(aString);
                        }
                    }

                    var nerrorListspecial = new ArrayList();

                    for (int i = 0; i < errorListspecial.Count; i++)
                    {
                        var errmsg = errorListspecial[i].ToString().Trim();

                        if (P4errorList2.Contains(errmsg))
                        {
                            nerrorListspecial.Add(errmsg);
                        }
                    }
                    if (nerrorListspecial != null)
                    {
                        var FontColour = new BaseColor(255, 0, 0);
                        for (int i = 0; i < nerrorListspecial.Count; i++)
                        {
                            Paragraph ErrorlistAirrspecial = new Paragraph(nerrorListspecial[i].ToString());
                            ErrorlistAirrspecial.IndentationLeft = 20f;
                            ErrorlistAirrspecial.Font.Color = FontColour;
                            doc.Add(ErrorlistAirrspecial);
                        }

                        if (nerrorListspecial.Count == 0)
                        {
                            Paragraph No_Text = new Paragraph("There Are No Sprint Special Errors", myFont3);
                            No_Text.IndentationLeft = 15f;
                            doc.Add(No_Text);
                        }
                    }
                }
            }

            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("Specific Performance Descriptors:", myFont));
            doc.Add(new Paragraph("\n"));

            if (SummaryCheckPage == "Sprint")
                doc.Add(new Paragraph("These Variables identify how the performer is mechanically producing the results in the Result, General, and Special groups. These are the areas where changes must be made to improve performance. In the unlikely case where all Specific Variables fall in the acceptable range, the only remaining way to improve performance would be to improve Strength levels (Static, Dynamic, or Elastic). As with the General results, they are listed below where they occur - either in the Ground Phase or the Air Phase."));
            else
                doc.Add(new Paragraph("These Variables identify how the performer is mechanically producing the results in the Result and General groups. These are the areas where changes must be made to improve performance. In the unlikely case where all Specific Variables fall in the acceptable range, the only remaining way to improve performance would be to improve Strength levels (Static, Dynamic, or Elastic). As with the General results, they are listed below where they occur - either in the Ground Phase or the Air Phase."));

            doc.Add(new Paragraph("\n"));
            //------------------------------------------------------------------------------------->>>>>>>>>>>Specific Ground Phase
            Paragraph Ground_Phase = new Paragraph("Ground Phase:", myFont1);
            Ground_Phase.IndentationLeft = 15f;
            doc.Add(Ground_Phase);
            doc.Add(new Paragraph("\n"));

            ArrayList errorListSpecificGround = new ArrayList();
            foreach (string aString in Controls_TeachersDualPlayer.ErrorList._specific)
            {
                if (!errorListSpecificGround.Contains(aString))
                {
                    errorListSpecificGround.Add(aString);
                }
            }
            var nerrorListSpecificGround = new ArrayList();
            for (int i = 0; i < errorListSpecificGround.Count; i++)
            {
                var errmsg = errorListSpecificGround[i].ToString().Trim();

                if (P4errorList2.Contains(errmsg))
                {
                    nerrorListSpecificGround.Add(errmsg);
                }
            }
            if (nerrorListSpecificGround != null)
            {
                var FontColour = new BaseColor(255, 0, 0);
                for (int i = 0; i < nerrorListSpecificGround.Count; i++)
                {
                    Paragraph ErrorlistAirr = new Paragraph(nerrorListSpecificGround[i].ToString());
                    ErrorlistAirr.IndentationLeft = 20f;
                    ErrorlistAirr.Font.Color = FontColour;
                    doc.Add(ErrorlistAirr);
                }

                if (nerrorListSpecificGround.Count == 0)
                {
                    Paragraph No_Text = new Paragraph("There Are No Ground Phase Errors", myFont3);
                    No_Text.IndentationLeft = 20f;
                    doc.Add(No_Text);
                }
            }
            doc.Add(new Paragraph("\n"));
            //------------------------------------------------------------------------------------->>>>>>>>>>>Specific Air Phase
            Paragraph Air_Phase = new Paragraph("Air Phase:", myFont1);
            Air_Phase.IndentationLeft = 15f;
            doc.Add(Air_Phase);
            doc.Add(new Paragraph("\n"));
            ArrayList errorListSpecificAir = new ArrayList();
            foreach (string aString in Controls_TeachersDualPlayer.ErrorList._specific_Air)
            {
                if (!errorListSpecificAir.Contains(aString))
                {
                    errorListSpecificAir.Add(aString);
                }
            }
            var nerrorListSpecificAir = new ArrayList();
            for (int i = 0; i < errorListSpecificAir.Count; i++)
            {
                var errmsg = errorListSpecificAir[i].ToString().Trim();
                if (P4errorList2.Contains(errmsg))
                {
                    nerrorListSpecificAir.Add(errmsg);
                }
            }
            if (nerrorListSpecificAir != null)
            {
                var FontColour = new BaseColor(255, 0, 0);
                for (int i = 0; i < nerrorListSpecificAir.Count; i++)
                {
                    Paragraph ErrorlistAirr = new Paragraph(nerrorListSpecificAir[i].ToString());
                    ErrorlistAirr.IndentationLeft = 20f;
                    ErrorlistAirr.Font.Color = FontColour;
                    doc.Add(ErrorlistAirr);
                }

                if (nerrorListSpecificAir.Count == 0)
                {
                    Paragraph No_Text = new Paragraph("There Are No Air Phase Errors", myFont3);
                    No_Text.IndentationLeft = 20f;
                    doc.Add(No_Text);
                }
            }
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));
            //----------------------------------------------------------------------------------------------------------------------->>>>
            Paragraph preface1 = new Paragraph(SummaryCheckPage + " " + "Scores: " + customer.FirstName + " " + customer.LastName, myFont);
            preface1.Alignment = Element.ALIGN_CENTER;
            doc.Add(preface1);
            doc.Add(new Paragraph("\n"));

            if (SummaryCheckPage == "Sprint")
                doc.Add(new Paragraph("All of the Errors listed above are triggered when the Athlete’s performance in any Variable falls outside of a certain range.  Although these Errors identify the major problems with the Athlete’s Sprinting action, it does not identify how bad each Variable actually is (does it barely reach the problem level or is it really bad).  Likewise, it does not identify the level of performance of those Variables that do not reach the problem level (do they barely reach the level of acceptance or are they very good)."));
            else
            {
                if (SummaryCheckPage == "Start")
                    doc.Add(new Paragraph("All of the Errors listed above are triggered when the Athlete’s performance in any Variable falls outside of a certain range.  Although these Errors identify the major problems with the Athlete’s Starting action, it does not identify how bad each Variable actually is (does it barely reach the problem level or is it really bad).  Likewise, it does not identify the level of performance of those Variables that do not reach the problem level (do they barely reach the level of acceptance or are they very good)."));
                else
                {
                    if (SummaryCheckPage == "Hurdle")
                        doc.Add(new Paragraph("All of the Errors listed above are triggered when the Athlete’s performance in any Variable falls outside of a certain range.  Although these Errors identify the major problems with the Athlete’s Hurdling action, it does not identify how bad each Variable actually is (does it barely reach the problem level or is it really bad).  Likewise, it does not identify the level of performance of those Variables that do not reach the problem level (do they barely reach the level of acceptance or are they very good)."));
                    else
                        doc.Add(new Paragraph("All of the Errors listed above are triggered when the Athlete’s performance in any Variable falls outside of a certain range.  Although these Errors identify the major problems with the Athlete’s Hurdle Steps action, it does not identify how bad each Variable actually is (does it barely reach the problem level or is it really bad).  Likewise, it does not identify the level of performance of those Variables that do not reach the problem level (do they barely reach the level of acceptance or are they very good)."));
                }
            }

            doc.Add(new Paragraph("\n"));

            if (SummaryCheckPage == "Sprint")
            {
                doc.Add(new Paragraph("To provide greater insight into the overall Sprint performance of an Athlete, each Session is given a Score in each of the four Groups (Result, General, Special, and Specific) that includes the quality of every Variable.  If the Athlete’s Score reaches 100, they have matched the Model in every Variable in the Group."));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("These Scores provide an excellent measure of the overall strength or weakness of each of the Groups, as well as the best measure of how the Athlete changes over time."));

                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("For every Group result, a Score above 50 places the Athlete above the average for Elite Sprint performance.  A Score of 75 or higher places the Athlete among the best in this category."));
            }
            else
            {
                if (SummaryCheckPage == "Start")
                {
                    doc.Add(new Paragraph("To provide greater insight into the overall Start performance of an Athlete, each Session is given a Score in each of the three Groups (Result, General, and Specific) that includes the quality of every Variable.  If the Athlete’s Score reaches 100, they have matched the Model in every Variable in the Group."));
                    doc.Add(new Paragraph("\n"));
                    doc.Add(new Paragraph("These Scores provide an excellent measure of the overall strength or weakness of each of the Groups, as well as the best measure of how the Athlete changes over time."));

                    doc.Add(new Paragraph("\n"));
                    doc.Add(new Paragraph("For every Group result, a Score above 50 places the Athlete above the average for Elite Start performance.  A Score of 75 or higher places the Athlete among the best in this category."));
                }
                else
                {
                    if (SummaryCheckPage == "Hurdle")
                    {
                        doc.Add(new Paragraph("To provide greater insight into the overall Hurdle performance of an Athlete, each Session is given a Score in each of the three Groups (Result, General, and Specific) that includes the quality of every Variable.  If the Athlete’s Score reaches 100, they have matched the Model in every Variable in the Group."));
                        doc.Add(new Paragraph("\n"));
                        doc.Add(new Paragraph("These Scores provide an excellent measure of the overall strength or weakness of each of the Groups, as well as the best measure of how the Athlete changes over time."));

                        doc.Add(new Paragraph("\n"));
                        doc.Add(new Paragraph("For every Group result, a Score above 50 places the Athlete above the average for Elite Hurdle performance.  A Score of 75 or higher places the Athlete among the best in this category."));
                    }
                    else
                    {
                        doc.Add(new Paragraph("To provide greater insight into the overall Hurdle Step performance of an Athlete, each Session is given a Score in each of the three Groups (Result, General, and Specific) that includes the quality of every Variable.  If the Athlete’s Score reaches 100, they have matched the Model in every Variable in the Group."));
                        doc.Add(new Paragraph("\n"));
                        doc.Add(new Paragraph("These Scores provide an excellent measure of the overall strength or weakness of each of the Groups, as well as the best measure of how the Athlete changes over time."));

                        doc.Add(new Paragraph("\n"));
                        doc.Add(new Paragraph("For every Group result, a Score above 50 places the Athlete above the average for Elite Hurdle Step performance.  A Score of 75 or higher places the Athlete among the best in this category."));
                    }
                }
            }

            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph(SummaryCheckPage + " " + "Result Score: ", myFont));
            doc.Add(new Paragraph("\n"));

            if (SummaryCheckPage == "Sprint")
            {
                doc.Add(new Paragraph("For the Sprint, the Velocity Variable is the only measure of overall success.  If a Sprinter can produce a Score of 75 in the On-Track Practice Sessions, or a Score of 90 in Competition, they will have reached a level of performance that will be hard to beat."));
            }
            else
            {
                if (SummaryCheckPage == "Start")
                    doc.Add(new Paragraph("For the Start, the Time to the 3 and 5 Meter Marks, along with the Velocity to the 3 Meter Mark, are the three measures of overall success.  If an Athlete can produce a Score of 75 in the On-Track Practice Sessions they will have reached a level of performance that will be hard to beat."));
                else
                {
                    if (SummaryCheckPage == "Hurdle")
                        doc.Add(new Paragraph("For the Hurdles, the Velocity Variable is the only measure of overall success.  If a Hurdler can produce a Score of 75 in the On-Track Practice Sessions, or a Score of 90 in Competition, they will have reached a level of performance that will be hard to beat."));
                    else
                        doc.Add(new Paragraph("For the Hurdle Steps, the Velocity Variable is the only measure of overall success.  If a Hurdler can produce a Score of 75 in the On-Track Practice Sessions, or a Score of 90 in Competition, they will have reached a level of performance that will be hard to beat."));
                }
            }

            doc.Add(new Paragraph("\n"));

            if (SummaryCheckPage == "Sprint")
            {
                //  if (PassResultScoreI == "" && PassResultScoreM1 == "")
                if (sessionmode == true && PassResultScoreI != "" && PassResultScoreM1 != "")
                {
                    Paragraph SprintResult1 = new Paragraph(SummaryCheckPage + " " + "Result Score: " + PassResultScoreI + " " + "( " + DropDownList1Text + " )", myFontread);
                    SprintResult1.Alignment = Element.ALIGN_CENTER;
                    doc.Add(SprintResult1);
                    Paragraph SprintResul2 = new Paragraph(SummaryCheckPage + " " + "Result Score: " + PassResultScoreF + " " + "( " + DropDownList3Text + " )", myFontread);
                    SprintResul2.Alignment = Element.ALIGN_CENTER;
                    doc.Add(SprintResul2);
                }
                else
                {
                    if (PassResultScoreI != "" && PassResultScoreM1 != "")
                    {
                        Paragraph SprintResult = new Paragraph(SummaryCheckPage + " " + "Result Score: " + PassResultScoreI, myFontread);
                        SprintResult.Alignment = Element.ALIGN_CENTER;
                        doc.Add(SprintResult);
                    }
                    else
                    {
                        Paragraph SprintResult = new Paragraph(SummaryCheckPage + " " + "Result Score: " + PassResultScoreF, myFontread);
                        SprintResult.Alignment = Element.ALIGN_CENTER;
                        doc.Add(SprintResult);
                    }
                }
            }
            else
            {
                if (SummaryCheckPage == "Start")
                {
                    //if (PassResultScoreI == "" && PassResultScoreM1 == "")
                    if (sessionmode == true && PassResultScoreI != "" && PassResultScoreM1 != "")
                    {
                        Paragraph StartResult1 = new Paragraph(SummaryCheckPage + " " + "Result Score: " + PassResultScoreI + " " + "( " + DropDownList1Text + " )", myFontread);
                        StartResult1.Alignment = Element.ALIGN_CENTER;
                        doc.Add(StartResult1);
                        Paragraph StartResult2 = new Paragraph(SummaryCheckPage + " " + "Result Score: " + PassResultScoreF + " " + "( " + DropDownList3Text + " )", myFontread);
                        StartResult2.Alignment = Element.ALIGN_CENTER;
                        doc.Add(StartResult2);
                    }
                    else
                    {
                        if (PassResultScoreI != "" && PassResultScoreM1 != "")
                        {
                            Paragraph StartResult = new Paragraph(SummaryCheckPage + " " + "Result Score: " + PassResultScoreI, myFontread);
                            StartResult.Alignment = Element.ALIGN_CENTER;
                            doc.Add(StartResult);
                        }
                        else
                        {
                            Paragraph StartResult = new Paragraph(SummaryCheckPage + " " + "Result Score: " + PassResultScoreF, myFontread);
                            StartResult.Alignment = Element.ALIGN_CENTER;
                            doc.Add(StartResult);
                        }
                    }
                }
                else
                {
                    if (SummaryCheckPage == "Hurdle")
                    {
                        //if (PassResultScoreI == "" && PassResultScoreM1 == "")
                        if (sessionmode == true && PassResultScoreI != "" && PassResultScoreM1 != "")
                        {
                            Paragraph HurdleResult1 = new Paragraph(SummaryCheckPage + " " + "Result Score: " + PassResultScoreI + " " + "( " + DropDownList1Text + " )", myFontread);
                            HurdleResult1.Alignment = Element.ALIGN_CENTER;
                            doc.Add(HurdleResult1);
                            Paragraph HurdleResult2 = new Paragraph(SummaryCheckPage + " " + "Result Score2: " + PassResultScoreF + " " + "( " + DropDownList3Text + " )", myFontread);
                            HurdleResult2.Alignment = Element.ALIGN_CENTER;
                            doc.Add(HurdleResult2);
                        }
                        else
                        {
                            if (PassResultScoreI != "" && PassResultScoreM1 != "")
                            {
                                Paragraph HurdleResult = new Paragraph(SummaryCheckPage + " " + "Result Score: " + PassResultScoreI, myFontread);
                                HurdleResult.Alignment = Element.ALIGN_CENTER;
                                doc.Add(HurdleResult);
                            }
                            else
                            {
                                Paragraph HurdleResult = new Paragraph(SummaryCheckPage + " " + "Result Score: " + PassResultScoreF, myFontread);
                                HurdleResult.Alignment = Element.ALIGN_CENTER;
                                doc.Add(HurdleResult);
                            }
                        }
                    }
                    else
                    {
                        //if (PassResultScoreI == "" && PassResultScoreM1 == "")
                        if (sessionmode == true && PassResultScoreI != "" && PassResultScoreM1 != "")
                        {
                            Paragraph HurdleStepResult1 = new Paragraph(SummaryCheckPage + " " + "Result Score: " + PassResultScoreI + " " + "( " + DropDownList1Text + " )", myFontread);
                            HurdleStepResult1.Alignment = Element.ALIGN_CENTER;
                            doc.Add(HurdleStepResult1);
                            Paragraph HurdleStepResult2 = new Paragraph(SummaryCheckPage + " " + "Result Score: " + PassResultScoreF + " " + "( " + DropDownList3Text + " )", myFontread);
                            HurdleStepResult2.Alignment = Element.ALIGN_CENTER;
                            doc.Add(HurdleStepResult2);
                        }
                        else
                        {
                            if (PassResultScoreI != "" && PassResultScoreM1 != "")
                            {
                                Paragraph HurdleStepResult = new Paragraph(SummaryCheckPage + " " + "Result Score: " + PassResultScoreI, myFontread);
                                HurdleStepResult.Alignment = Element.ALIGN_CENTER;
                                doc.Add(HurdleStepResult);
                            }
                            else
                            {
                                Paragraph HurdleStepResult = new Paragraph(SummaryCheckPage + " " + "Result Score: " + PassResultScoreF, myFontread);
                                HurdleStepResult.Alignment = Element.ALIGN_CENTER;
                                doc.Add(HurdleStepResult);
                            }

                        }
                    }
                }
            }

            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph(SummaryCheckPage + " " + "General Score: ", myFont));
            doc.Add(new Paragraph("\n"));

            if (SummaryCheckPage == "Sprint")
            {
                doc.Add(new Paragraph("The General Score is made up of the results of all the Time Variables, including the Stride Rate.  This Score provides an excellent measure of how well the Athlete is producing and managing the time demands of the performance.  Regardless of the quality of the rest of the Sprint Scores, this Score tends to be high in all Elite Sprinters.  In fact, it is difficult to be a world class sprinter without the genetic ability to score well in these Variables.  Many times young Athletes will score in the 70s or higher, while producing poor Scores in both the Special and Specific Groups."));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("Since this Score is primarily genetically driven, it tends to be similar in both the On-Track Practice Sessions and Competitions."));
            }
            else
            {
                if (SummaryCheckPage == "Start")
                    doc.Add(new Paragraph("The General Score is made up of the results of all the Time and Distance Variables.  This Score provides an excellent measure of how well the Athlete is producing and managing the time and distance demands of the performance.  Due to the high technical nature of this skill, this Score is highly dependent upon the quality of the Start mechanics - which is measure by the Specific Score."));
                else
                {
                    if (SummaryCheckPage == "Hurdle")
                        doc.Add(new Paragraph("The General Score is made up of the results of all the Time and Distance Variables.  This Score provides an excellent measure of how well the Athlete is producing and managing the time and distance demands of the performance.  Due to the high technical nature of this skill, this Score is highly dependent upon the quality of the Hurdle mechanics - which is measure by the Specific Score."));
                    else
                        doc.Add(new Paragraph("The General Score is made up of the results of all the Time and Distance Variables.  This Score provides an excellent measure of how well the Athlete is producing and managing the time and distance demands of the performance.  Due to the high technical nature of this skill, this Score is highly dependent upon the quality of the Hurdle Steps mechanics - which is measure by the Specific Score."));
                }
            }

            doc.Add(new Paragraph("\n"));

            if (SummaryCheckPage == "Sprint")
            {
                if (sessionmode == true && PassGeneralScoreI != "" && PassGeneralScoreM1 != "")
                {
                    Paragraph SprintGeneral1 = new Paragraph(SummaryCheckPage + " " + "General Score: " + PassGeneralScoreI + " " + "( " + DropDownList1Text + " )", myFontread);
                    SprintGeneral1.Alignment = Element.ALIGN_CENTER;
                    doc.Add(SprintGeneral1);
                    Paragraph SprintGeneral2 = new Paragraph(SummaryCheckPage + " " + "General Score: " + PassGeneralScoreF + " " + "( " + DropDownList3Text + " )", myFontread);
                    SprintGeneral2.Alignment = Element.ALIGN_CENTER;
                    doc.Add(SprintGeneral2);
                }
                else
                {
                    if (PassGeneralScoreI != "" && PassGeneralScoreM1 != "")
                    {
                        Paragraph SprintGeneral = new Paragraph(SummaryCheckPage + " " + "General Score: " + PassGeneralScoreI, myFontread);
                        SprintGeneral.Alignment = Element.ALIGN_CENTER;
                        doc.Add(SprintGeneral);
                    }
                    else
                    {
                        Paragraph SprintGeneral2 = new Paragraph(SummaryCheckPage + " " + "General Score: " + PassGeneralScoreF, myFontread);
                        SprintGeneral2.Alignment = Element.ALIGN_CENTER;
                        doc.Add(SprintGeneral2);
                    }
                }
            }
            else if (SummaryCheckPage == "Start")
            {
                if (sessionmode == true && PassGeneralScoreI != "")
                {
                    Paragraph StartGeneral1 = new Paragraph(SummaryCheckPage + " " + "General Score: " + PassGeneralScoreI + " " + "( " + DropDownList1Text + " )", myFontread);
                    StartGeneral1.Alignment = Element.ALIGN_CENTER;
                    doc.Add(StartGeneral1);
                    Paragraph StartGeneral2 = new Paragraph(SummaryCheckPage + " " + "General Score: " + PassGeneralScoreF + " " + "( " + DropDownList3Text + " )", myFontread);
                    StartGeneral2.Alignment = Element.ALIGN_CENTER;
                    doc.Add(StartGeneral2);
                }
                else
                {
                    if (PassGeneralScoreI != "")
                    {
                        Paragraph StartGeneral = new Paragraph(SummaryCheckPage + " " + "General Score: " + PassGeneralScoreI, myFontread);
                        StartGeneral.Alignment = Element.ALIGN_CENTER;
                        doc.Add(StartGeneral);
                    }
                    else
                    {
                        Paragraph StartGeneral = new Paragraph(SummaryCheckPage + " " + "General Score: " + PassGeneralScoreF, myFontread);
                        StartGeneral.Alignment = Element.ALIGN_CENTER;
                        doc.Add(StartGeneral);
                    }
                }
            }
            else if (SummaryCheckPage == "Hurdle")
            {
                if (sessionmode == true && PassGeneralScoreI != "" && PassGeneralScoreM1 != "")
                {
                    Paragraph HurdleGeneral1 = new Paragraph(SummaryCheckPage + " " + "General Score: " + PassGeneralScoreI + " " + "( " + DropDownList1Text + " )", myFontread);
                    HurdleGeneral1.Alignment = Element.ALIGN_CENTER;
                    doc.Add(HurdleGeneral1);
                    Paragraph HurdleGeneral2 = new Paragraph(SummaryCheckPage + " " + "General Score: " + PassGeneralScoreF + " " + "( " + DropDownList3Text + " )", myFontread);
                    HurdleGeneral2.Alignment = Element.ALIGN_CENTER;
                    doc.Add(HurdleGeneral2);
                }
                else
                {
                    if (PassGeneralScoreI != "" && PassGeneralScoreM1 != "")
                    {
                        Paragraph HurdleGeneral = new Paragraph(SummaryCheckPage + " " + "General Score: " + PassGeneralScoreI, myFontread);
                        HurdleGeneral.Alignment = Element.ALIGN_CENTER;
                        doc.Add(HurdleGeneral);
                    }
                    else
                    {
                        Paragraph HurdleGeneral = new Paragraph(SummaryCheckPage + " " + "General Score: " + PassGeneralScoreF, myFontread);
                        HurdleGeneral.Alignment = Element.ALIGN_CENTER;
                        doc.Add(HurdleGeneral);
                    }
                }
            }
            else
            {
                if (sessionmode == true && PassGeneralScoreI != "" && PassGeneralScoreM1 != "")
                {
                    Paragraph HurdleStepGeneral1 = new Paragraph(SummaryCheckPage + " " + "General Score: " + PassGeneralScoreI + " " + "( " + DropDownList1Text + " )", myFontread);
                    HurdleStepGeneral1.Alignment = Element.ALIGN_CENTER;
                    doc.Add(HurdleStepGeneral1);
                    Paragraph HurdleStepGeneral2 = new Paragraph(SummaryCheckPage + " " + "General Score: " + PassGeneralScoreF + " " + "( " + DropDownList3Text + " )", myFontread);
                    HurdleStepGeneral2.Alignment = Element.ALIGN_CENTER;
                    doc.Add(HurdleStepGeneral2);
                }
                else
                {
                    if (PassGeneralScoreI != "" && PassGeneralScoreM1 != "")
                    {
                        Paragraph HurdleStepGeneral = new Paragraph(SummaryCheckPage + " " + "General Score: " + PassGeneralScoreI, myFontread);
                        HurdleStepGeneral.Alignment = Element.ALIGN_CENTER;
                        doc.Add(HurdleStepGeneral);
                    }
                    else
                    {
                        Paragraph HurdleStepGeneral = new Paragraph(SummaryCheckPage + " " + "General Score: " + PassGeneralScoreF, myFontread);
                        HurdleStepGeneral.Alignment = Element.ALIGN_CENTER;
                        doc.Add(HurdleStepGeneral);
                    }
                }
            }

            if (SummaryCheckPage == "Sprint")//Currently no Special Scores in any event except the Sprint
            {
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph(SummaryCheckPage + " " + "Special Score: ", myFont));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("The Special Score indicates the Athlete’s ability to produce an effective Stride Length during the Ground Contact phase.  Since the Ground Phase becomes shorter as the quality of the Sprint performance increases, scoring high in this Group is a difficult task.  Successful Sprint times can be produced with average Special Scores (40-60), but the great Sprinters score well here as well (above 80)."));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("Due to the extreme power demands required to produce a world class Stride Length, coupled with the fact that good Sprint Mechanics tends to decrease Stride Length, this Score is typically the lowest of the Group."));
                doc.Add(new Paragraph("\n"));

                if (sessionmode == true && PassSpecialScoreF != "" && PassSpecialScoreM2 != "")
                {
                    Paragraph SprintSpecial1 = new Paragraph(SummaryCheckPage + " " + "Special Score: " + PassSpecialScoreI + " " + "( " + DropDownList1Text + " )", myFontread);
                    SprintSpecial1.Alignment = Element.ALIGN_CENTER;
                    doc.Add(SprintSpecial1);
                    Paragraph SprintSpecial2 = new Paragraph(SummaryCheckPage + " " + "Special Score: " + PassSpecialScoreF + " " + "( " + DropDownList3Text + " )", myFontread);
                    SprintSpecial2.Alignment = Element.ALIGN_CENTER;
                    doc.Add(SprintSpecial2);
                    doc.Add(new Paragraph("\n"));
                }
                else
                {
                    if (PassSpecialScoreF != "" && PassSpecialScoreM2 != "")
                    {
                        Paragraph SprintSpecial = new Paragraph(SummaryCheckPage + " " + "Special Score: " + PassSpecialScoreF, myFontread);
                        SprintSpecial.Alignment = Element.ALIGN_CENTER;
                        doc.Add(SprintSpecial);
                        doc.Add(new Paragraph("\n"));
                    }
                    else
                    {
                        Paragraph SprintSpecial = new Paragraph(SummaryCheckPage + " " + "Special Score: " + PassSpecialScoreI, myFontread);
                        SprintSpecial.Alignment = Element.ALIGN_CENTER;
                        doc.Add(SprintSpecial);
                        doc.Add(new Paragraph("\n"));
                    }
                }
            }

            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph(SummaryCheckPage + " " + "Specific Score: ", myFont));
            doc.Add(new Paragraph("\n"));

            if (SummaryCheckPage == "Sprint")
                doc.Add(new Paragraph("The Specific Score is the best indicator for how the Athlete is using the body segments to produce the overall Sprint performance.  Talent alone can produce respectable levels of Result, General, and Special Scores, but for a true World Class result, proper body movements must be achieved to allow the talent to achieve its potential."));
            else
            {
                if (SummaryCheckPage == "Start")
                    doc.Add(new Paragraph("The Specific Score is the best indicator for how the Athlete is using the body segments to produce the overall Start performance.  Talent alone can produce respectable levels of Result and General Scores, but for a true World Class result, proper body movements must be achieved to allow the talent to achieve its potential."));
                else
                {
                    if (SummaryCheckPage == "Hurdle")
                        doc.Add(new Paragraph("The Specific Score is the best indicator for how the Athlete is using the body segments to produce the overall Hurdle performance.  Talent alone can produce respectable levels of Result and General Scores, but for a true World Class result, proper body movements must be achieved to allow the talent to achieve its potential."));
                    else
                        doc.Add(new Paragraph("The Specific Score is the best indicator for how the Athlete is using the body segments to produce the overall Hurdle Steps performance.  Talent alone can produce respectable levels of Result and General Scores, but for a true World Class result, proper body movements must be achieved to allow the talent to achieve its potential."));
                }
            }

            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("Due to the stress of Competition, coupled with the emphasis on proper Mechanics during the On-Track Practice Sessions, the Specific Scores in Competition are always lower.  The truely great athletes develop the ability to produce high Scores in both Practice and Competition."));
            doc.Add(new Paragraph("\n"));

            if (SummaryCheckPage == "Sprint")
            {
                if (sessionmode == true && PassSpecificScoreF != "" && PassSpecificScoreM2 != "")
                {

                    Paragraph SprintSpecific1 = new Paragraph(SummaryCheckPage + " " + "Specific Score: " + PassSpecificScoreI + " " + "( " + DropDownList1Text + " )", myFontread);
                    SprintSpecific1.Alignment = Element.ALIGN_CENTER;
                    doc.Add(SprintSpecific1);
                    Paragraph SprintSpecific2 = new Paragraph(SummaryCheckPage + " " + "Specific Score: " + PassSpecificScoreF + " " + "( " + DropDownList3Text + " )", myFontread);
                    SprintSpecific2.Alignment = Element.ALIGN_CENTER;
                    doc.Add(SprintSpecific2);
                }
                else
                {
                    if (PassSpecificScoreF != "" && PassSpecificScoreM2 != "")
                    {
                        Paragraph SprintSpecific = new Paragraph(SummaryCheckPage + " " + "Specific Score: " + PassSpecificScoreF, myFontread);
                        SprintSpecific.Alignment = Element.ALIGN_CENTER;
                        doc.Add(SprintSpecific);
                    }
                    else
                    {
                        Paragraph SprintSpecific = new Paragraph(SummaryCheckPage + " " + "Specific Score: " + PassSpecificScoreI, myFontread);
                        SprintSpecific.Alignment = Element.ALIGN_CENTER;
                        doc.Add(SprintSpecific);
                    }
                }
            }
            else if (SummaryCheckPage == "Start")
            {
                if (sessionmode == true && PassSpecificScoreF != "")
                {
                    Paragraph StartSpecific1 = new Paragraph(SummaryCheckPage + " " + "Specific Score: " + PassSpecificScoreI + " " + "( " + DropDownList1Text + " )", myFontread);
                    StartSpecific1.Alignment = Element.ALIGN_CENTER;
                    doc.Add(StartSpecific1);
                    Paragraph StartSpecific2 = new Paragraph(SummaryCheckPage + " " + "Specific Score: " + PassSpecificScoreF + " " + "( " + DropDownList3Text + " )", myFontread);
                    StartSpecific2.Alignment = Element.ALIGN_CENTER;
                    doc.Add(StartSpecific2);
                }
                else
                {
                    if (PassSpecificScoreF != "")
                    {
                        Paragraph StartSpecific = new Paragraph(SummaryCheckPage + " " + "Specific Score: " + PassSpecificScoreF, myFontread);
                        StartSpecific.Alignment = Element.ALIGN_CENTER;
                        doc.Add(StartSpecific);
                    }
                    else
                    {
                        Paragraph StartSpecific = new Paragraph(SummaryCheckPage + " " + "Specific Score: " + PassSpecificScoreI, myFontread);
                        StartSpecific.Alignment = Element.ALIGN_CENTER;
                        doc.Add(StartSpecific);
                    }
                }
            }
            else if (SummaryCheckPage == "Hurdle")
            {
                if (sessionmode == true && PassSpecificScoreF != "" && PassSpecificScoreM2 != "")
                {
                    Paragraph HurdleSpecific1 = new Paragraph(SummaryCheckPage + " " + "Specific Score: " + PassSpecificScoreI + " " + "( " + DropDownList1Text + " )", myFontread);
                    HurdleSpecific1.Alignment = Element.ALIGN_CENTER;
                    doc.Add(HurdleSpecific1);
                    Paragraph HurdleSpecific2 = new Paragraph(SummaryCheckPage + " " + "Specific Score: " + PassSpecificScoreF + " " + "( " + DropDownList3Text + " )", myFontread);
                    HurdleSpecific2.Alignment = Element.ALIGN_CENTER;
                    doc.Add(HurdleSpecific2);
                }
                else
                {
                    if (PassSpecificScoreF != "" && PassSpecificScoreM2 != "")
                    {
                        Paragraph HurdleSpecific = new Paragraph(SummaryCheckPage + " " + "Specific Score: " + PassSpecificScoreF, myFontread);
                        HurdleSpecific.Alignment = Element.ALIGN_CENTER;
                        doc.Add(HurdleSpecific);
                    }
                    else
                    {
                        Paragraph HurdleSpecific = new Paragraph(SummaryCheckPage + " " + "Specific Score: " + PassSpecificScoreI, myFontread);
                        HurdleSpecific.Alignment = Element.ALIGN_CENTER;
                        doc.Add(HurdleSpecific);
                    }
                }
            }
            else
            {
                if (sessionmode == true && PassSpecificScoreF != "" && PassSpecificScoreM2 != "")
                {
                    Paragraph HurdleStepSpecific1 = new Paragraph(SummaryCheckPage + " " + "Specific Score: " + PassSpecificScoreI + " " + "( " + DropDownList1Text + " )", myFontread);
                    HurdleStepSpecific1.Alignment = Element.ALIGN_CENTER;
                    doc.Add(HurdleStepSpecific1);
                    Paragraph HurdleStepSpecific2 = new Paragraph(SummaryCheckPage + " " + "Specific Score: " + PassSpecificScoreF + " " + "( " + DropDownList3Text + " )", myFontread);
                    HurdleStepSpecific2.Alignment = Element.ALIGN_CENTER;
                    doc.Add(HurdleStepSpecific2);
                }
                else
                {
                    if (PassSpecificScoreF != "" && PassSpecificScoreM2 != "")
                    {
                        Paragraph HurdleStepSpecific = new Paragraph(SummaryCheckPage + " " + "Specific Score: " + PassSpecificScoreF, myFontread);
                        HurdleStepSpecific.Alignment = Element.ALIGN_CENTER;
                        doc.Add(HurdleStepSpecific);
                    }
                    else
                    {
                        Paragraph HurdleStepSpecific = new Paragraph(SummaryCheckPage + " " + "Specific Score: " + PassSpecificScoreI, myFontread);
                        HurdleStepSpecific.Alignment = Element.ALIGN_CENTER;
                        doc.Add(HurdleStepSpecific);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string errorsmg = ex.Message.ToString();
        }
        finally
        {
            doc.Close();
        }
        // }
        return pdffile;
    }
}
