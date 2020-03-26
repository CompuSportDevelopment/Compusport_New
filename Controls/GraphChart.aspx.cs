using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using CompuSportDAL;
using SwingModel.Data;
using SwingModel.Entities;

public partial class Controls_GraphChart : System.Web.UI.Page
{
    const string COLOR_GREEN = "#92d050"; //0 or less
    const string COLOR_LIGHTBLUE = "#8faadc"; //0 to 0.5
    const string COLOR_PINK = "#ffcccc";//0.5 to 1
    const string COLOR_LIGHTRED = "#ff7c80";//1 to 1.5
    const string COLOR_RED = "#c00000";//1.5 to 2
    const string COLOR_DARKGRAY = "#7f7f7f";//2 or more
    const Decimal MULT = (decimal)2.000;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == true)
        {
            Session["CHART1_IMAGE1"] = Request.Form["Chart1"];
            Session["CHART2_IMAGE1"] = Request.Form["Chart2"];
            Response.End();
            
        }
    }

    [System.Web.Services.WebMethod]
    public static void SetGraphData(string DropDownList1Text, string DropDownList2Text, string DropDownList3Text, string PassSpecificScoreF)
    {
        SprintAthleteEdit sae = new SprintAthleteEdit();
        DataTable dtTable = new DataTable();
        dtTable = sae.GetSprintVariable();
        var session_Initial = DropDownList1Text;
        var session_Final = DropDownList3Text;
        var SummaryCheckPage = DropDownList2Text;
        HttpContext.Current.Session["GRAPH_DATA_Name"] = SummaryCheckPage;
        DataRow sprintDataFinal = HttpContext.Current.Session["SPRINT_DATA_Final"] as DataRow;
        DataRow sprintDataFinalModel = HttpContext.Current.Session["SPRINT_DATA_FinalModel"] as DataRow;
        DataRow dtVariablesSD = HttpContext.Current.Session["SPRINT_DATA_SD_variable"] as DataRow;

        DataRow sprintDataInitial = HttpContext.Current.Session["SPRINT_DATA_Initial"] as DataRow;
        DataRow sprintDataInitialModel = HttpContext.Current.Session["SPRINT_DATA_InitialModel"] as DataRow;
        DataRow SprintSDVariable = HttpContext.Current.Session["GetAllSprintAND_SDValue"] as DataRow;

        Decimal valAthVel = 1;
        Decimal valModAt = 1;
        Decimal valAthAtLR = 1;
        Decimal valAthAtRL = 1;
        Decimal valAthAtAv = 1;

        string graphDataChart1 = "['Element', '', { role: 'style'},\"ModelValue\"],";
        string graphDataChart2 = "['Element', '', { role: 'style'},\"ModelValue\"],";
        string Code = string.Empty;
        string sd = string.Empty;
        string Chart = string.Empty;
        string GroupNo = string.Empty;
        string ChartNo = string.Empty;
        string result = string.Empty;
        string sessionName = string.Empty;
        foreach (DataRow dtRow in SprintSDVariable.Table.Rows)
        {
            Chart = dtRow["ChartNo"].ToString();
            Code = dtRow["Code"].ToString();
            sd = dtRow["SD"].ToString();
            Decimal sdvalue = Convert.ToDecimal(sd);

            if (DropDownList3Text.Contains("Initial"))
            {
                sessionName = "Intial";
                Decimal valIntial = Convert.ToDecimal(sprintDataInitial[Code]);
                Decimal valIntialModel = Convert.ToDecimal(sprintDataInitialModel[Code]);

                if (Code == "Velocity")
                    valAthVel = valIntial;
                if (Code == "Air Time Left to Right")
                    valAthAtLR = valIntial;
                if (Code == "Air Time Right to Left")
                    valAthAtRL = valIntial;
                if (Code == "Air Time Average")
                {
                    valAthAtAv = valIntial;
                    valModAt = valIntialModel;
                }

                if (Chart == "1")
                {
                    string chartDataIntial = getChartData(Code, valIntial, valIntialModel, sdvalue, valAthVel, valModAt, valAthAtLR, valAthAtRL, valAthAtAv);

                    if (dtRow["GroupNo"].ToString().Trim().ToUpper() != GroupNo.Trim().ToUpper())
                    {
                        graphDataChart1 += "['',0,'',\"\"],";
                        graphDataChart1 += chartDataIntial;
                        GroupNo = dtRow["GroupNo"].ToString();
                    }
                    else
                    {
                        graphDataChart1 += chartDataIntial;
                        GroupNo = dtRow["GroupNo"].ToString();
                    }
                }
                else
                {
                    string chartDataIntialModel = getChartData(Code, valIntial, valIntialModel, sdvalue, valAthVel, valModAt, valAthAtLR, valAthAtRL, valAthAtAv);
                    if (dtRow["GroupNo"].ToString().Trim().ToUpper() != GroupNo.Trim().ToUpper())
                    {
                        graphDataChart2 += "['',0,'',\"\"],";
                        graphDataChart2 += chartDataIntialModel;
                        GroupNo = dtRow["GroupNo"].ToString();
                    }
                    else
                    {
                        graphDataChart2 += chartDataIntialModel;
                        GroupNo = dtRow["GroupNo"].ToString();
                    }
                }
            }
            else
            {
                sessionName = "Final";
                Decimal valFinal = Convert.ToDecimal(sprintDataFinal[Code]);
                Decimal valFinalModel = Convert.ToDecimal(sprintDataFinalModel[Code]);

                if (Code == "Velocity")
                    valAthVel = valFinal;
                if (Code == "Air Time Left to Right")
                    valAthAtLR = valFinal;
                if (Code == "Air Time Right to Left")
                    valAthAtRL = valFinal;
                if (Code == "Air Time Average")
                {
                    valAthAtAv = valFinal;
                    valModAt = valFinalModel;
                }
 
                if (Chart == "1")
                {
                    string chartDataFinal = getChartData(Code, valFinal, valFinalModel, sdvalue, valAthVel, valModAt, valAthAtLR, valAthAtRL, valAthAtAv);

                    if (dtRow["GroupNo"].ToString().Trim().ToUpper() != GroupNo.Trim().ToUpper())
                    {
                        graphDataChart1 += "['',0,'',\"\"],";
                        graphDataChart1 += chartDataFinal;
                        GroupNo = dtRow["GroupNo"].ToString();
                    }
                    else
                    {
                        graphDataChart1 += chartDataFinal;
                        GroupNo = dtRow["GroupNo"].ToString();
                    }
                }
                else
                {
                    string chartDataFinalModel = getChartData(Code, valFinal, valFinalModel, sdvalue, valAthVel, valModAt, valAthAtLR, valAthAtRL, valAthAtAv);
                    if (dtRow["GroupNo"].ToString().Trim().ToUpper() != GroupNo.Trim().ToUpper())
                    {
                        graphDataChart2 += "['',0,'',\"\"],";
                        graphDataChart2 += chartDataFinalModel;
                        GroupNo = dtRow["GroupNo"].ToString();
                    }
                    else
                    {
                        graphDataChart2 += chartDataFinalModel;
                        GroupNo = dtRow["GroupNo"].ToString();
                    }
                }

            }
            HttpContext.Current.Session["GRAPH_DATA_CHART1"] = graphDataChart1.TrimEnd(",".ToCharArray());
            HttpContext.Current.Session["GRAPH_DATA_CHART2"] = graphDataChart2.TrimEnd(",".ToCharArray());
        }
        HttpContext.Current.Session["Session_Name"] = sessionName;

    }
    private static string getChartData(string colName, decimal initial, decimal initialModel, decimal sd, decimal passAthVel, decimal passModAt, decimal passAthAtLR, decimal passAthAtRL, decimal passAthAtAv)
    {
        Decimal ratio = initial / initialModel;
        Decimal percentageValue = 0;
        Decimal percentageconvertedVal = 0;

        if (colName != "Result: Velocity Compared to Model" && colName != "General: Time and Rate Results" && colName != "Special: Stride Length Creation While on Ground" && colName != "Specific: Critical Body Positions")
        {
            if (colName == "Ground Time Left" || colName == "Ground Time Right" || colName == "Ground Time Average" || colName == "Touchdown Distance Left" || colName == "Touchdown Distance Right" || colName == "Touchdown Distance Average" || colName == "Lower Leg Angle at Takeoff Left" || colName == "Lower Leg Angle at Takeoff Right" || colName == "Lower Leg Angle at Takeoff Average")
                percentageValue = (initial - initialModel) / (sd * MULT);//Here we calculate (Athlete - Model) / (SD *mult)
            else
            {
                if (colName == "Stride Rate" || colName == "Air Time Left to Right" || colName == "Air Time Right to Left" || colName == "Air Time Average" || colName == "Knee Separation at Touchdown Left" || colName == "Knee Separation at Touchdown Right" || colName == "Knee Separation at Touchdown Average")
                    percentageValue = Math.Abs((initial - initialModel) / (sd * MULT));//Here we calculate Absolute Value of ((Athlete - Model) / (SD *mult))
                else
                {
                    if (colName == "Stride Length Left to Right")
                    {
                        percentageValue = Math.Abs((initialModel - (initial + (passAthVel * (passModAt - passAthAtLR)))) / (sd * MULT));//Here we calculate Absolute Value of ((Athlete - Model) / (SD *mult))
                    }
                    else
                    {
                        if (colName == "Stride Length Right to Left")
                            percentageValue = Math.Abs((initialModel - (initial + (passAthVel * (passModAt - passAthAtRL)))) / (sd * MULT));//Here we calculate Absolute Value of ((Athlete - Model) / (SD *mult))
                        else
                        {
                            if (colName == "Stride Length Average")
                                percentageValue = Math.Abs((initialModel - (initial + (passAthVel * (passModAt - passAthAtAv)))) / (sd * MULT));//Here we calculate Absolute Value of ((Athlete - Model) / (SD *mult))
                            else
                                percentageValue = (initialModel - initial) / (sd * MULT);//Here we calculate (Model - Athlete) / (SD *mult)
                        }
                    }
                }
            }
        }
        else
        {
            percentageValue = ((initialModel - initial) * MULT) / 100;  //((C54-B54)*G54)/100 - This is ((Model-Athlete)*MULT)/100
        }

        percentageconvertedVal = Math.Round(Convert.ToDecimal(percentageValue), 3);
        
        return "['(" + initialModel + ") " + colName + "'," + percentageconvertedVal + "," + "'" + getColorCode(percentageconvertedVal) + "'," + "\"" + initial + "\"" + "],";
    }
    private static string getColorCode(decimal val)
    {
        string colorCode = "";
        if (val <= 0) colorCode = COLOR_GREEN;
        else if (val > 0 && val <= (decimal)0.5) colorCode = COLOR_LIGHTBLUE;
        else if (val > (decimal)0.5 && val <= 1) colorCode = COLOR_PINK;
        else if (val > 1 && val <= (decimal)1.5) colorCode = COLOR_LIGHTRED;
        else if (val > (decimal)1.5 && val <= 2) colorCode = COLOR_RED;
        else colorCode = COLOR_DARKGRAY;

        return colorCode;
    }

}