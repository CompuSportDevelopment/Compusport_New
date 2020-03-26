<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Controls_Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <div id="SprintId" runat="server">
            <%--<div style="margin-left: 1px;">--%>
            <table id="Sprintheader" runat="server" style="float: left; padding: 0px; width: 749px;
                    height: 75px; font-size: 22px; text-align: center; margin-left: 60px; font-family: Magneto;">
                <tr >
                    <td>
                        The Variable Chart
                    </td>
                </tr>
            </table>
            <%--   </div>--%>
            <table id="SprintText" runat="server" style="float: left; width: 86%; margin-left: 65px">
                <tr>
                    <td>
                        <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                            Below the Video Player, the Variable Chart lists the results that are used to evaluate
                            the Maximum Velocity Sprint. If the results are from an On-Track Session, then the
                            athlete's initial run-through results are shown in the Initial column, while the
                            final effort is shown in the Final column. In both cases, the athlete's Model values
                            are shown in the column to the right of their values. If the athlete's results are
                            in the acceptable range, the Model results are shown in <font color="black"><b>black</b></font>.
                            If the results are not up to the Model's standard (needs improvement), the result
                            is shown in <font color="red">red</font>.</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                            If the results are from a competition, then the athlete's performance is shown in
                            the Final column. As in the On-Track Sessions, the athlete's Model values are shown
                            in the column to the right of their values. If the athlete's results are in the
                            acceptable range, the Model results are shown in black. If the results are not up
                            to the Model's standard (needs improvement), the result is shown in <font color="red">
                                red</font></p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                            Information on any of the variables can be found by clicking on the variable name
                            in the Chart.
                        </p>
                    </td>
                </tr>
            </table>
            <table id="SprintTireVariableText" runat="server" visible="false" style="float: left;
                margin-top: -260px; padding: 0px; width: 86%;">
                <tr>
                    <td>
                        <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                            Below the Video Player, the Variable Chart lists the results that are used to evaluate
                            the Maximum Velocity Sprint. In Comparison Mode, the results from the Session selected
                            in the left window of the Top Player are shown in the left <font color="#ffcc00">(yellow)</font>
                            column, while the results from the Session selected in the right window are shown
                            in the right <font color="green">(green)</font> column. In both cases, the athlete's
                            Model values are shown in the column to the right of their values. If the athlete's
                            results are in the acceptable range, the Model results are shown in black. If the
                            results are not up to the Model's standard (needs improvement), the result is shown
                            in <font color="red">red</font>.
                        </p>
                    </td>
                </tr>
            </table>
            <table border="2" style="float: left; width: 745px; height: 1px; margin-left: 85px;">
                <tr style="float: left; width: 834px; margin-right: 2px; margin-left: 85px;">
                    <td style="font-size: small; width: 260px; float: left;">
                        <%--<div style="float: left; width: 260px; padding: 0px;">--%>
                        <div style="background-color: #006699; width: 260px;">
                            <b style="color: #FFFFFF">Session</b></div>
                        <div style="height: 2px; background-color: #666633">
                        </div>
                        <div style="background-color: #006699; width: 260px;">
                            <b style="color: #FFFFFF">Variable</b></div>
                        <div onclick="OpenGroundTime('../VariablePages/GroundTime.aspx')" style="background-color: #FFCAB0;
                            width: 260px; cursor: pointer;">
                            Ground Time Left</div>
                        <div onclick="OpenGroundTime('../VariablePages/GroundTime.aspx')" style="background-color: #FFCAB0;
                            width: 260px; cursor: pointer;">
                            Ground Time Right</div>
                        <div onclick="OpenGroundTime('../VariablePages/GroundTime.aspx')" style="background-color: #FFB895;
                            width: 260px; cursor: pointer;">
                            Ground Time Average</div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <%--<br />--%>
                        <div onclick="OpenGroundTime('../VariablePages/GroundTime.aspx')" style="background-color: #FFCAB0;
                            width: 260px; cursor: pointer;">
                            Air Time Left to Right</div>
                        <div onclick="OpenGroundTime('../VariablePages/GroundTime.aspx')" style="background-color: #FFCAB0;
                            width: 260px; cursor: pointer;">
                            Air Time Right to Left</div>
                        <div onclick="OpenGroundTime('../VariablePages/GroundTime.aspx')" style="background-color: #FFCAB0;
                            width: 260px; cursor: pointer;">
                            Air Time Average</div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <%-- <br />--%>
                        <div onclick="OpenFullFlexion('../VariablePages/TimeToUpperLegFullFlexion.aspx')"
                            style="background-color: #FFCAB0; width: 260px; cursor: pointer;">
                            Time to Upper Leg Full Flexion Left</div>
                        <div onclick="OpenFullFlexion('../VariablePages/TimeToUpperLegFullFlexion.aspx')"
                            style="background-color: #FFCAB0; width: 260px; cursor: pointer;">
                            Time to Upper Leg Full Flexion Right</div>
                        <div onclick="OpenFullFlexion('../VariablePages/TimeToUpperLegFullFlexion.aspx')"
                            style="background-color: #FFB895; width: 260px; cursor: pointer;">
                            Time to Upper Leg Full Flexion Average</div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <%--<br />--%>
                        <div onclick="OpenStrideRate('../VariablePages/StrideRate.aspx')" style="background-color: #FFB895;
                            width: 260px; cursor: pointer;">
                            Stride Rate</div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <%--  <br />--%>
                        <div onclick="OpenStrideLength('../VariablePages/StrideLength.aspx')" style="background-color: #FFCAB0;
                            width: 260px; cursor: pointer;">
                            Stride Length Left to Right</div>
                        <div onclick="OpenStrideLength('../VariablePages/StrideLength.aspx')" style="background-color: #FFCAB0;
                            width: 260px; cursor: pointer;">
                            Stride Length Right to Left</div>
                        <div onclick="OpenStrideLength('../VariablePages/StrideLength.aspx')" style="background-color: #FFB895;
                            width: 260px; cursor: pointer;">
                            Stride Length Average</div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <%--    <br />--%>
                        <div onclick="OpenVelocity('../VariablePages/Velocity.aspx')" style="background-color: #FFB895;
                            width: 260px; cursor: pointer;">
                            Velocity</div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <%-- <br />--%>
                        <div onclick="OpenTouchDown('../VariablePages/TouchDown.aspx')" style="background-color: #FFCAB0;
                            width: 260px; cursor: pointer;">
                            Touchdown Distance Left</div>
                        <div onclick="OpenTouchDown('../VariablePages/TouchDown.aspx')" style="background-color: #FFCAB0;
                            width: 260px; cursor: pointer;">
                            Touchdown Distance Right</div>
                        <div onclick="OpenTouchDown('../VariablePages/TouchDown.aspx')" style="background-color: #FFB895;
                            width: 260px; cursor: pointer;">
                            Touchdown Distance Average</div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <%-- <br />--%>
                        <div onclick="OpenFullFlexion('../VariablePages/UpperLegFullExtension.aspx')" style="background-color: #FFB895;
                            width: 260px; cursor: pointer;">
                            Upper Leg Full Extension Angle Left</div>
                        <div onclick="OpenFullFlexion('../VariablePages/UpperLegFullExtension.aspx')" style="background-color: #FFB895;
                            width: 260px; cursor: pointer;">
                            Upper Leg Full Extension Angle Right</div>
                        <div onclick="OpenFullFlexion('../VariablePages/UpperLegFullExtension.aspx')" style="background-color: #FFB895;
                            width: 260px; cursor: pointer;">
                            Upper Leg Full Extension Angle Average</div>
                        <%-- <div style="background-color: White; width: 260px; height: 4px;">--%>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div onclick="OpenLowerLegAngleAtTakeOf('../VariablePages/LowerLegAngleAtTakeOf.aspx')"
                            style="background-color: #FFCAB0; width: 260px; cursor: pointer;">
                            Lower Leg Angle at Takeoff Left</div>
                        <div onclick="OpenLowerLegAngleAtTakeOf('../VariablePages/LowerLegAngleAtTakeOf.aspx')"
                            style="background-color: #FFCAB0; width: 260px; cursor: pointer;">
                            Lower Leg Angle at Takeoff Right</div>
                        <div onclick="OpenLowerLegAngleAtTakeOf('../VariablePages/LowerLegAngleAtTakeOf.aspx')"
                            style="background-color: #FFB895; width: 260px; cursor: pointer;">
                            Lower Leg Angle at Takeoff Average</div>
                        <%--<div style="background-color: White; width: 260px; height: 4px;">--%>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <%-- </div>--%>
                        <div onclick="OpenLowerLegAngleAtTakeOf('../VariablePages/LowerLegAngleAtTakeOf.aspx')"
                            style="background-color: #FFCAB0; width: 260px; cursor: pointer;">
                            Lower Leg Full Flexion Angle Left</div>
                        <div onclick="OpenLowerLegAngleAtTakeOf('../VariablePages/LowerLegAngleAtTakeOf.aspx')"
                            style="background-color: #FFCAB0; width: 260px; cursor: pointer;">
                            Lower Leg Full Flexion Angle Right</div>
                        <div onclick="OpenLowerLegAngleAtTakeOf('../VariablePages/LowerLegAngleAtTakeOf.aspx')"
                            style="background-color: #FFB895; width: 260px; cursor: pointer;">
                            Lower Leg Full Flexion Angle Average</div>
                        <%--<div style="background-color: White; width: 260px; height: 4px;">--%>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <%-- </div>--%>
                        <div onclick="OpenLowerLegAngleAtTakeOf('../VariablePages/LowerLegAngleAtTakeOf.aspx')"
                            style="background-color: #FFCAB0; width: 260px; cursor: pointer;">
                            Lower Leg Angle at Ankle Cross Left</div>
                        <div onclick="OpenLowerLegAngleAtTakeOf('../VariablePages/LowerLegAngleAtTakeOf.aspx')"
                            style="background-color: #FFCAB0; width: 260px; cursor: pointer;">
                            Lower Leg Angle at Ankle Cross Right</div>
                        <div onclick="OpenLowerLegAngleAtTakeOf('../VariablePages/LowerLegAngleAtTakeOf.aspx')"
                            style="background-color: #FFB895; width: 260px; cursor: pointer;">
                            Lower Leg Angle at Ankle Cross Average</div>
                        <%-- <div style="background-color: White; width: 260px; height: 4px;">--%>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <%-- </div>--%>
                        <div onclick="OpenFullFlexion('../VariablePages/UpperLegFullFlexion.aspx')" style="background-color: #FFCAB0;
                            width: 260px; cursor: pointer;">
                            Upper Leg Full Flexion Angle Left</div>
                        <div onclick="OpenFullFlexion('../VariablePages/UpperLegFullFlexion.aspx')" style="background-color: #FFCAB0;
                            width: 260px; cursor: pointer;">
                            Upper Leg Full Flexion Angle Right</div>
                        <div onclick="OpenFullFlexion('../VariablePages/UpperLegFullFlexion.aspx')" style="background-color: #FFB895;
                            width: 260px; cursor: pointer;">
                            Upper Leg Full Flexion Angle Average</div>
                        <%-- </div>--%>
                    </td>
                    <td style="float: left; width: 120px; padding: 0px; text-align: center; font-size: small">
                        <div id="leftmovie" runat="server" style="background-color: #006699; width: 240px;">
                            <asp:Label ID="lblleftmovie" runat="server" Width="240px" ForeColor="White"></asp:Label></div>
                        <div style="height: 2px; background-color: #666633">
                        </div>
                        <div id="SprintIniital" runat="server" style="background-color: #006699; width: 120px;">
                            <b style="color: #FFFFFF">Initial</b></div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblGroundTimeLeftI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblGroundTimeRightI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #EBEB41; width: 120px;">
                            <asp:Label ID="lblGroundTimeAverageI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblAirTimeLeftToRightI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblAirTimeRightToLeftI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #EBEB41; width: 120px;">
                            <asp:Label ID="lblAirTimeAverageI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblTimeToUpperLegFullFlexionLeftI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblTimeToUpperLegFullFlexionRightI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #EBEB41; width: 120px;">
                            <asp:Label ID="lblTimeToUpperLegFullFlexionAverageI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #EBEB41; width: 120px;">
                            <asp:Label ID="lblStrideRateI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblStrideLengthLeftToRightI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblStrideLengthRightToLeftI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #EBEB41; width: 120px;">
                            <asp:Label ID="lblStrideLengthAverageI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #EBEB41; width: 120px;">
                            <asp:Label ID="lblVelocity" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblTouchDownDistanceLeftI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblTouchDownDistanceRightI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #EBEB41; width: 120px;">
                            <asp:Label ID="lblTouchDownDistanceAverageI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblUpperLegFullExtentionAngleLeftI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblUpperLegFullExtentionAngleRightI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #EBEB41; width: 120px;">
                            <asp:Label ID="lblUpperLegFullExtentionAngleAverageI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <%--<div style="background-color: White; width: 80px;"></div>--%>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtTakeOfLeftI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtTakeOfRightI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #EBEB41; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtTakeOfAverageI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <%--<div style="background-color: White; width: 80px; height: 4px;">--%>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblLowerLegFullFlexionAngleLeftI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblLowerLegFullFlexionAngleRightI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #EBEB41; width: 120px;">
                            <asp:Label ID="lblLowerLegFullFlexionAngleAverageI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <%-- <div style="background-color: White; width: 80px; height: 4px;">--%>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossLeftI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossRightI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #EBEB41; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossAverageI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <%--<div style="background-color: White; width: 80px; height: 4px;">--%>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblUpperLegFullFlexionAngleLeftI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #FFFF80; width: 120px;">
                            <asp:Label ID="lblUpperLegFullFlexionAngleRightI" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #EBEB41; width: 120px;">
                            <asp:Label ID="lblUpperLegFullFlexionAngleAverageI" runat="server" Text="" Width="90px"></asp:Label></div>
                    </td>
                    <td style="float: left; width: 120px; padding: 0px; text-align: center; font-size: small;">
                      
                            <div id="Div2" style="background-color: #006699; width: 0px;">
                                <asp:Label ID="Label16" runat="server" Width="1px" ForeColor="White"></asp:Label></div>
                            <div style="height: 2px; background-color: #666633">
                            </div>
                            <div id="SprintModelM1" class="ModelDiv" runat="server" style="background-color: #006699;
                                width: 120px;">
                                <b style="color: #FFFFFF">Model</b></div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblGroundTimeLeftM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblGroundTimeRightM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #EBEB41; width: 120px;">
                                <asp:Label ID="lblGroundTimeAverageM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="height: 5px; background-color: #666633">
                            </div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblAirTimeLeftToRightM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblAirTimeRightToLeftM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #EBEB41; width: 120px;">
                                <asp:Label ID="lblAirTimeAverageM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="height: 5px; background-color: #666633">
                            </div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblTimeToUpperLegFullFlexionLeftM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblTimeToUpperLegFullFlexionRightM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #EBEB41; width: 120px;">
                                <asp:Label ID="lblTimeToUpperLegFullFlexionAverageM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="height: 5px; background-color: #666633">
                            </div>
                            <div style="background-color: #EBEB41; width: 120px;">
                                <asp:Label ID="lblStrideRateM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="height: 5px; background-color: #666633">
                            </div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblStrideLengthLeftToRighM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblStrideLengthRightToLeftM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #EBEB41; width: 120px;">
                                <asp:Label ID="lblStrideLengthAverageM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="height: 5px; background-color: #666633">
                            </div>
                            <div style="background-color: #EBEB41; width: 120px;">
                                <asp:Label ID="lblVelocityM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="height: 5px; background-color: #666633">
                            </div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblTouchDownDistanceLeftM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblTouchDownDistanceRightM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #EBEB41; width: 120px;">
                                <asp:Label ID="lblTouchDownDistanceAverageM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="height: 5px; background-color: #666633">
                            </div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblUpperLegFullExtentionAngleLeftM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblUpperLegFullExtentionAngleRightM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #EBEB41; width: 120px;">
                                <asp:Label ID="lblUpperLegFullExtentionAngleAverageM1" runat="server" Text="" Width="90px"></asp:Label></div>
                           
                            <div style="height: 5px; background-color: #666633">
                            </div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblLowerLegAngleAtTakeOfLeftM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblLowerLegAngleAtTakeOfRightM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #EBEB41; width: 120px;">
                                <asp:Label ID="lblLowerLegAngleAtTakeOfAverageM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="height: 5px; background-color: #666633">
                            </div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblLowerLegFullFlexionAngleLeftM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblLowerLegFullFlexionAngleRightM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #EBEB41; width: 120px;">
                                <asp:Label ID="lblLowerLegFullFlexionAngleAverageM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="height: 5px; background-color: #666633">
                            </div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblLowerLegAngleAtAnkleCrossLeftM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblLowerLegAngleAtAnkleCrossRightM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #EBEB41; width: 120px;">
                                <asp:Label ID="lblLowerLegAngleAtAnkleCrossAverageM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="height: 5px; background-color: #666633">
                            </div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblUpperLegFullFlexionAngleLeftM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #FFFF80; width: 120px;">
                                <asp:Label ID="lblUpperLegFullFlexionAngleRightM1" runat="server" Text="" Width="90px"></asp:Label></div>
                            <div style="background-color: #EBEB41; width: 120px;">
                                <asp:Label ID="lblUpperLegFullFlexionAngleAverageM1" runat="server" Text="" Width="90px"></asp:Label></div>
                    </td>
                    <td style="float: left; width: 120px; padding: 0px; text-align: center; font-size: small">
                        <div id="Div3" runat="server" style="background-color: #006699; width: 240px;">
                            <asp:Label ID="lblRightMovie" runat="server" Width="240px" ForeColor="White"></asp:Label></div>
                        <div style="height: 2px; background-color: #666633">
                        </div>
                        <div id="SprintFinal" runat="server" style="background-color: #006699; width: 120px;">
                            <b style="color: #FFFFFF">Final</b></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblGroundTimeLeftF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblGroundTimeRightF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblGroundTimeAverageF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblAirTimeLeftToRightF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblAirTimeRightToLeftF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblAirTimeAverageF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblTimeToUpperLegFullFlexionLeftF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblTimeToUpperLegFullFlexionRightF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblTimeToUpperLegFullFlexionAverageF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblStrideRateF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblStrideLengthLeftToRighF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblStrideLengthRightToLeftF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblStrideLengthAverageF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblVelocityF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblTouchDownDistanceLeftF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblTouchDownDistanceRightF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblTouchDownDistanceAverageF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblUpperLegFullExtentionAngleLeftF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblUpperLegFullExtentionAngleRightF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblUpperLegFullExtentionAngleAverageF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtTakeOfLeftF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtTakeOfRightF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtTakeOfAverageF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblLowerLegFullFlexionAngleLeftF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblLowerLegFullFlexionAngleRightF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblLowerLegFullFlexionAngleAverageF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossLeftF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossRightF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossAverageF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblUpperLegFullFlexionAngleLeftF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblUpperLegFullFlexionAngleRightF" runat="server" Text="" Width="80px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblUpperLegFullFlexionAngleAverageF" runat="server" Text="" Width="80px"></asp:Label></div>
                    </td>
                    <td style="float: left; width: 120px; padding: 0px; text-align: center; font-size: small">
                        <div id="Div4" style="background-color: #006699; width: 0px;">
                            <asp:Label ID="Label17" runat="server" Width="1px" ForeColor="White"></asp:Label></div>
                        <div style="height: 2px; background-color: #666633">
                        </div>
                        <div id="SprintModelM2" class="ModelDiv" runat="server" style="background-color: #006699;
                            width: 120px;">
                            <b style="color: #FFFFFF">Model</b></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblGroundTimeLeftM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblGroundTimeRightM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblGroundTimeAverageM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblAirTimeLeftToRightM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblAirTimeRightToLeftM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblAirTimeAverageM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblTimeToUpperLegFullFlexionLeftM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblTimeToUpperLegFullFlexionRightM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblTimeToUpperLegFullFlexionAverageM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblStrideRateM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblStrideLengthLeftToRighM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblStrideLengthRightToLeftM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblStrideLengthAverageM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblVelocityM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblTouchDownDistanceLeftM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblTouchDownDistanceRightM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblTouchDownDistanceAverageM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblUpperLegFullExtentionAngleLeftM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblUpperLegFullExtentionAngleRightM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblUpperLegFullExtentionAngleAverageM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtTakeOfLeftM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtTakeOfRightM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtTakeOfAverageM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblLowerLegFullFlexionAngleLeftM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblLowerLegFullFlexionAngleRightM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblLowerLegFullFlexionAngleAverageM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossLeftM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossRightM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossAverageM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="height: 5px; background-color: #666633">
                        </div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblUpperLegFullFlexionAngleLeftM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #C0FFC0; width: 120px;">
                            <asp:Label ID="lblUpperLegFullFlexionAngleRightM2" runat="server" Text="" Width="90px"></asp:Label></div>
                        <div style="background-color: #91F591; width: 120px;">
                            <asp:Label ID="lblUpperLegFullFlexionAngleAverageM2" runat="server" Text="" Width="90px"></asp:Label></div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
