<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SprintAthletEdit.ascx.cs"
    Inherits="TrackData_SprintAthletEdit" %>

<script type="text/javascript">
		function PrintFilePath(filePath) {
			document.getElementById("<%=txtbFilePath.ClientID %>").value = filePath;
			return false;
		}
</script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div>
    <div style="float: left; padding: 0px; width: 600px; height: 40px; font-size: xx-large;
        text-align: center;">
        <b>Sprint - Maximum Velocity</b>
        <asp:UpdateProgress ID="Updat_Paymentxyz" runat="server" DisplayAfter="1">
            <ProgressTemplate>
                <div style="text-align: left; position: absolute; top: 25%; left: 50%; margin-left: -70px;">
                    <img src="../image/big_loading.gif" alt="" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    <div style="float: left; width: 600px;">
        <table cellpadding="2" cellspacing="2" border="0" width="100%">
            <tr>
                <td colspan="3" align="left">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="300px" AutoPostBack="True">
                        <asp:ListItem Value="noathlete">Select an Athlete</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="300px" AutoPostBack="True"
                                Visible="true" >
                                <asp:ListItem Value="nodate">Select Analysis Date and Location</asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left">
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="300px" AutoPostBack="True">
                        <asp:ListItem Value="nodate">Select Lessson Date and Location</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr valign="top">
                <td align="left">
                    <asp:Button ID="btndateloc" runat="server" Text="Enter New Date and Location"  />
                </td>
                <td>
                    <asp:Label ID="lblDate" runat="server" Text="Enter New Date" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server" Visible="false"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblDateEx" runat="server" Text="(ex. 02/15/2011 22:11:00)" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblLocation" runat="server" Text="Enter New Location" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLocation" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:TextBox ID="txtbFilePath" runat="server" Width="500" Visible="false" Font-Bold="true"></asp:TextBox>
            <asp:Button ID="btnUpload" runat="server" Visible="false" Text="Browse"  />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="updtepnlgrig" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="overflow: auto; width: 600px; height: 150px;">
                <asp:GridView ID="Gridview1" runat="server" 
                    Width="100%" AutoGenerateColumns="false" ShowHeader="false" >
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSelect" runat="server" CausesValidation="False" Text='<%#Eval("FilePath") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnUpload" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</div>
<table id="table1" border="0px" cellpadding="0px" cellspacing="0px">
    <tr>
        <td>
            <div id="div12" style="margin-top: 0px; margin-bottom: 0px;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <div style="float: left; padding: 0px; width: 600px; height: 30px; text-align: center;">
                            <asp:Label ID="Label117" runat="server" Text="" Width="600px" ForeColor="Red" Font-Size="Large"
                                Font-Bold="True"></asp:Label>
                        </div>
                       <%-- <div id="VideoDiv" runat="server" visible="false" style="float: left; padding: 0px;
                            width: 600px; height: 520px;" ondblclick="return VideoDiv_ondblclick()">--%>
                       <%--     <object width="600px" height="516px" classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6">
                                <param name="autoStart" value="False">
                                <param name="URL" value="<% =wmpfile %>">
                                <param name="stretchToFit" value="True">
                                <embed type="video/x-ms-wmv" width="600px" height="516px" autostart="False" url="<% =wmpfile %>"
                                    enabled="True" stretchtofit="True">
                            </object>--%>
                        </div>
                        <div style="float: left; padding: 0px; margin-left: 90px; width: 450px;">
                            <%--<b>Video Name </b><asp:TextBox ID="txtvideo" runat="server" Width="300px"></asp:TextBox>--%>
                            <asp:FileUpload ID="fUpload" runat="server" Width="300px" Visible="false" />
                            <asp:Label ID="lblMsg" CssClass="tdMessage" Text="" runat="server"></asp:Label>
                        </div>
                        <div style="float: left; margin-top: 20px; padding: 0px; width: 600px;">
                        </div>
                        <div style="float: left; width: 570px; height: 1px; background-color: Black;">
                        </div>
                        <div style="float: left; width: 600px; border: 1px;">
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <div style="height: 4px;">
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                                <div style="height: 4px;">
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                            </div>
                            <div style="float: left; width: 296px; padding: 0px; border: 3px; border-color: Black;">
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    <b>Variable</b></div>
                                <br />
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Ground Time Left</div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Ground Time Right</div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Ground Time Average</div><br />--%>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Air Time Left to Right</div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Air Time Right to Left</div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Air Time Average</div><br />--%>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Time to Upper Leg Full Flexion Left</div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Time to Upper Leg Full Flexion Right</div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Time to Upper Leg Full Flexion Average</div><br />--%>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Stride Rate</div><br />--%>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Stride Length Left to Right</div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Stride Length Right to Left</div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Stride Length Average</div><br />--%>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Velocity</div><br />--%>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Touchdown Distance Left</div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Touchdown Distance Right</div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Touchdown Distance Average</div><br />--%>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Upper Leg Full Extension Angle Left</div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Upper Leg Full Extension Angle Right</div>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Upper Leg Full Extension Angle Average</div>--%>
                                <div style="background-color: White; width: 296px; height: 4px;">
                                </div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Lower Leg Angle at Takeoff Left</div>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Lower Leg Angle at Takeoff Right</div>
                                <%--<div style="background-color: #FFB9AF; width: 295px; height: 26px;">Lower Leg Angle at Takeoff Average</div>--%>
                                <div style="background-color: White; width: 296px; height: 4px;">
                                </div>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Lower Leg Full Flexion Angle Left</div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Lower Leg Full Flexion Angle Right</div>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Lower Leg Full Flexion Angle Average</div>--%>
                                <div style="background-color: White; width: 296px; height: 4px;">
                                </div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Lower Leg Angle at Ankle Cross Left</div>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Lower Leg Angle at Ankle Cross Right</div>
                                <%--<div style="background-color: #FFB9AF; width: 295px; height: 26px;">Lower Leg Angle at Ankle Cross Average</div>--%>
                                <div style="background-color: White; width: 296px; height: 4px;">
                                </div>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Upper Leg Full Flexion Angle Left</div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Upper Leg Full Flexion Angle Right</div>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Upper Leg Full Flexion Angle Average</div>--%>
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <div style="height: 4px;">
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                                <div style="height: 4px;">
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                            </div>
                            <div style="float: left; width: 90px; padding: 0px; text-align: center;">
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <b>Initial</b></div>
                                <br />
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtGroundTimeLeft" runat="server" Width="60px" Height="21px" Style="margin-top: 0px"></asp:TextBox><br />
                                </div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtGroundTimeRight" runat="server" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"> <asp:TextBox ID="txtGroundTimeAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox></div><br />--%>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtAirTimeLeftToRight" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtAirTimeRightToLeft" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtAirTimeAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox></div><br />--%>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtFullFlexionTimeLeft" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtFullFlexionTimeRight" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtFullFlexionAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtStriderate" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtStrideLengthLeftToRight" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtStrideLengthRightToLeft" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtStrideLengthAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"> <asp:TextBox ID="txtVelocity" runat="server" Width="60px" Height="16px"  ReadOnly="True"></asp:TextBox></div><br />--%>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtCogDistanceLeft" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtCogDistanceRight" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtCogDistanceAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtUlFullExtensionAngleLeft" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtUlFullExtensionAngleRight" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtUlFullExtensionAngleAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlAngleTakeoffLeft" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlaAngleTakeoffRight" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #EBEB41; width: 90px;height:20px;"><asp:TextBox ID="txtLlaAngleTakeoffAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlFullFlexionAngleLeft" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlFullFlexionAngleRight" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtLlFullFlexionAngleAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlAngleAcLeft" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlAngleAcRight" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #EBEB41; width: 90px;height:20px;"><asp:TextBox ID="txtLlAngleAcAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtUlFullFlexionAngleLeft" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtUlFullFlexionAngleRight" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #FFFF80; width: 90px; height: 26px;"><asp:TextBox ID="txtUlFullFlexionAngleAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <div style="height: 4px;">
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                                <div style="height: 4px;">
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                            </div>
                            <div style="float: left; width: 90px; padding: 0px; text-align: center;">
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <b>Final</b></div>
                                <br />
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtGroundTimeLeft1" runat="server" Width="60px" Height="21px"></asp:TextBox><%--<asp:Label ID="Label41" runat="server" Text="" Width="60px"></asp:Label>--%></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtGroundTimeRight1" runat="server" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtGroundTimeAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox> </div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtAirTimeLeftToRight1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtAirTimeRightToLeft1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtAirTimeAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtFullFlexionTimeLeft1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtFullFlexionTimeRight1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtFullFlexionAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtStriderate1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtStrideLengthLeftToRight1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtStrideLengthRightToLeft1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtStrideLengthAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtVelocity1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtCogDistanceLeft1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtCogDistanceRight1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtCogDistanceAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtUlFullExtensionAngleLeft1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtUlFullExtensionAngleRight1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtUlFullExtensionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlAngleTakeoffLeft1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlaAngleTakeoffRight1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #91F591; width: 90px;height:20px;"><asp:TextBox ID="txtLlaAngleTakeoffAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlFullFlexionAngleLeft1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlFullFlexionAngleRight1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtLlFullFlexionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlAngleAcLeft1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlAngleAcRight1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #91F591; width: 90px;height:20px;"><asp:TextBox ID="txtLlAngleAcAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtUlFullFlexionAngleLeft1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtUlFullFlexionAngleRight1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px; height:20px;"><asp:TextBox ID="txtUlFullFlexionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <div style="height: 4px;">
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                                <div style="height: 4px;">
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                            </div>
                            <div style="float: left; width: 90px; padding: 0px; text-align: center;">
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <b>Model</b></div>
                                <br />
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtGroundTimeLeft2" runat="server" Width="60px" Height="21px"></asp:TextBox><%--<asp:Label ID="Label41" runat="server" Text="" Width="60px"></asp:Label>--%></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtGroundTimeRight2" runat="server" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtGroundTimeAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox> </div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtAirTimeLeftToRight2" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtAirTimeRightToLeft2" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtAirTimeAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtFullFlexionTimeLeft2" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtFullFlexionTimeRight2" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtFullFlexionAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtStriderate1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtStrideLengthLeftToRight2" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtStrideLengthRightToLeft2" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtStrideLengthAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtVelocity1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtCogDistanceLeft2" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtCogDistanceRight2" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtCogDistanceAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtUlFullExtensionAngleLeft2" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtUlFullExtensionAngleRight2" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtUlFullExtensionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlAngleTakeoffLeft2" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlaAngleTakeoffRight2" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #91F591; width: 90px;height:20px;"><asp:TextBox ID="txtLlaAngleTakeoffAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlFullFlexionAngleLeft2" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlFullFlexionAngleRight2" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtLlFullFlexionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlAngleAcLeft2" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtLlAngleAcRight2" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #91F591; width: 90px;height:20px;"><asp:TextBox ID="txtLlAngleAcAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtUlFullFlexionAngleLeft2" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="txtUlFullFlexionAngleRight2" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px; height:20px;"><asp:TextBox ID="txtUlFullFlexionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <div style="height: 4px;">
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                                <div style="height: 4px;">
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                            </div>
                            <div style="float: left; width: 570px; height: 1px; background-color: Black;">
                            </div>
                            <div style="float: left; padding: 0px; margin-left: 200px; width: 300px; height: 26px;">
                            </div>
                            <div style="float: left; padding: 0px; margin-left: 200px; width: 300px; height: 26px;">
                                <asp:Label ID="Label1" runat="server" Text="" Width="600px" ForeColor="Red" Font-Size="Large"
                                    Font-Bold="True"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            <div style="margin-top: 0px; margin-bottom:100px; margin-left: 300px;">
                <asp:Button ID="btnSubmit" runat="server" Width="100px" Text="Submit"  />
            </div>
                
            </div>
        </td>
    </tr>
    <tr>
        <td>
        </td>
    </tr>
</table>
