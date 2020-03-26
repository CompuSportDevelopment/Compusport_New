<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StartAthleteEdit.ascx.cs"
    Inherits="TrackData_StartAthleteEdit" %>
<style type="text/css">
    .style1
    {
        width: 135px;
        vertical-align: bottom;
    }
    
</style>

<script type="text/javascript">
    function PrintFilePath(filePath) {
        document.getElementById("<%=txtbFilePath.ClientID %>").value = filePath;
        return false;
    }
    function PrintFilePathTwo(filePath) {
        document.getElementById("<%=txtSumFilePath.ClientID %>").value = filePath;
        return false;
    }
    function PrintFilePathThree(filePath) {
        document.getElementById("<%=txtForCurrentVideo.ClientID %>").value = filePath;
        return false;
    }
    function getAlert() {
        return confirm('Are you sure you want to delete this Session?');
    }
    function refresh() {
        window.location.reload(true);
    }
</script>

<div>
    <div style="float: left; padding: 0px; width: 650px; height: 40px; font-size: xx-large;
        text-align: center;">
        <b>Sprint/Hurdle – Start</b>
        <br />
        <br />
        <br />
    </div>
    <asp:UpdateProgress ID="Updat_Paymentxyz" runat="server" DisplayAfter="1">
        <ProgressTemplate>
            <div style="text-align: left; position: absolute; top: 25%; left: 50%; margin-left: -70px;">
                <img src="../images/big_loading.gif" alt="" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div style="float: left; width: 600px;">
        <table cellpadding="2" cellspacing="2" border="0" width="100%">
            <tr>
                <td colspan="3" align="left">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="300px" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Value="noathlete">Select an Athlete</asp:ListItem>
                    </asp:DropDownList>
					<asp:Label ID="Label3" ForeColor="Red" runat="server" Text="please Select Athlete....!"
                        Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="300px" AutoPostBack="True"
                                Visible="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                <asp:ListItem Value="nodate">Select Analysis Date and Location</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="Label2" ForeColor="Red" runat="server" Text="The selected athlete does not have Sessions"
                                Visible="false"></asp:Label>
                            <asp:Label ID="Label4" ForeColor="Red" runat="server" Text="please Select Session.....!"
                                Visible="false"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left">
                    <%--  <asp:DropDownList ID="DropDownList3" runat="server" Width="300px" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                        <asp:ListItem Value="nodate">Select Lessson Date and Location</asp:ListItem>
                    </asp:DropDownList>--%>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table>
                    <tr valign="top">
                        <td align="left">
                            <asp:Button ID="btndateloc" runat="server" Text="Create New Session" OnClick="Button1_Click" />
                        </td>
                        <td>
                            <asp:Label ID="lblLocation" runat="server" Text="Enter New Location" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLocation" runat="server" Visible="false"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblexlocation" runat="server" Text="(ex.Los Angeles)" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="lblDate" runat="server" Text="Enter New Date" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server" Visible="false"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblDateEx" runat="server" Visible="false" Text="(ex. 02/15/2011)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="lblTime" runat="server" Text="Enter Time" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTime" runat="server" Visible="false"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblExTime" Text="(ex. 15:30:00)" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
					 <tr>
                        <td align="left">
                            <asp:Button ID="btnInpuFullSession" runat="server" Text="Input Full Session Data"
                                OnClick="btnInpuFullSession_Click" />
                            
                        </td>
			<td colspan="2">
                    <asp:DropDownList ID="DropdownListXmlFle" runat="server" Width="560px">
                    </asp:DropDownList>
                </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" ForeColor="Red" runat="server" Text="No Xml file For this Session or Please Select other Session ...!"
                                Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%-- browse for initial videos--%>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtbFilePath" runat="server" Width="500" Visible="true" Font-Bold="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnUpload" runat="server" Visible="true" Text="Browse for Session Initial videos"
                            OnClick="btnUpload_Click" Width="206px" />
                    </td>
                    <td>
                        <asp:Button ID="btnDeleteInitialMovies" runat="server" Visible="true" Text="Delete Initial Movies"
                            OnClick="btnDeleteInitialMovies_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <div style="overflow: auto; width: 600px; height: 150px;">
            <asp:Label ID="lblNoVideo" ForeColor="Red" runat="server" Text="At least one of the video files for this Session are missing"
                                Visible="false"></asp:Label>  <asp:Label ID="lblVariableMssing" ForeColor="Red" runat="server" Text="identifying the Variable Group that is missing or has a zero value."
                                Visible="false"></asp:Label>
                <asp:GridView ID="Gridview1" runat="server" OnRowDataBound="Gridview1_RowDataBound"
                    OnRowCommand="Gridview1_RowCommand" Width="100%" AutoGenerateColumns="false"
                    ShowHeader="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSelect" runat="server" CausesValidation="False" Text='<%#Eval("FilePath") %>'></asp:LinkButton></ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnUpload" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
        <ContentTemplate>
            <table id="tblInitialFrames" runat="server" cellpadding="1" cellspacing="2" border="1"
                style="width: 50%" visible="true">
                <tr>
                    <th align="left" class="style1">
                        <h3>
                            Positions</h3>
                    </th>
                    <td align="center">
                        P1
                    </td>
                    <td align="center">
                        P2
                    </td>
                    <td align="center">
                        P3
                    </td>
                    <td align="center">
                        P4
                    </td>
                    <td align="center">
                        P5
                    </td>
                    <td align="center">
                        P6
                    </td>
                    <td align="center">
                        P7
                    </td>
                    <td align="center">
                        P8
                    </td>
                    <td align="center">
                        P9
                    </td>
                </tr>
                <tr>
                    <th align="left" class="style1">
                        <h3>
                            Frames</h3>
                    </th>
                    <td align="center">
                        <asp:TextBox ID="txtBFrame1" runat="server" Width="30px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtBFrame2" runat="server" Width="30px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtBFrame3" runat="server" Width="30px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtBFrame4" runat="server" Width="30px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtBFrame5" runat="server" Width="30px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtBFrame6" runat="server" Width="30px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtBFrame7" runat="server" Width="30px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtBFrame8" runat="server" Width="30px"></asp:TextBox>
                    </td>
                     <td align="center">
                        <asp:TextBox ID="txtBFrame9" runat="server" Width="30px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <%-- browse for current videos--%>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtForCurrentVideo" runat="server" Width="500" Visible="true" Font-Bold="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnToBrowseCurrentVideo" runat="server" Visible="true" Text="Browse for Session Current Video"
                            OnClick="btnToBrowseCurrentVideo_Click" Width="212px" />
                    </td>
                    <td>
                        <asp:Button ID="btnDeleteCurrentMovies" runat="server" Visible="true" Text="Delete Current Movies"
                            OnClick="btnDeleteCurrentMovies_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="overflow: auto; width: 600px; height: 150px;">
                <asp:GridView ID="Gridview3" runat="server" AutoGenerateColumns="false" OnRowCommand="Gridview3_RowCommand"
                    OnRowDataBound="Gridview3_RowDataBound" OnSelectedIndexChanged="Gridview3_SelectedIndexChanged"
                    ShowHeader="false" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSelectCurrent" runat="server" CausesValidation="False" Text='<%#Eval("FilePath") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnToBrowseCurrentVideo" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table id="tblCurrentFrames" runat="server" cellpadding="1" cellspacing="2" border="1"
                style="width: 50%" visible="true">
                <tr>
                    <th align="left" class="style1">
                        <h3>
                            Positions</h3>
                    </th>
                    <td align="center">
                        P1
                    </td>
                    <td align="center">
                        P2
                    </td>
                    <td align="center">
                        P3
                    </td>
                    <td align="center">
                        P4
                    </td>
                    <td align="center">
                        P5
                    </td>
                    <td align="center">
                        P6
                    </td>
                    <td align="center">
                        P7
                    </td>
                    <td align="center">
                        P8
                    </td>
                    <td align="center">
                        P9
                    </td>
                </tr>
                <tr>
                    <th align="left" class="style1">
                        <h3>
                            Frames</h3>
                    </th>
                    <td align="center">
                        <asp:TextBox ID="txtCBFrame1" runat="server" Width="30px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtCBFrame2" runat="server" Width="30px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtCBFrame3" runat="server" Width="30px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtCBFrame4" runat="server" Width="30px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtCBFrame5" runat="server" Width="30px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtCBFrame6" runat="server" Width="30px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtCBFrame7" runat="server" Width="30px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtCBFrame8" runat="server" Width="30px"></asp:TextBox>
                    </td>
                     <td align="center">
                        <asp:TextBox ID="txtCBFrame9" runat="server" Width="30px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtSumFilePath" runat="server" Width="500" Visible="true" Font-Bold="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnUpload2" runat="server" Visible="true" Text="Browse for Summary Video"
                            OnClick="btnUpload2_Click" Width="216px" />
                    </td>
                    <td>
                        <asp:Button ID="btnDeleteSummaryMovie" runat="server" Visible="true" Text="Delete Summary Movies"
                            OnClick="btnDeleteSummaryMovie_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="updtepnlgridforsum" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="overflow: auto; width: 600px; height: 150px;">
                <asp:GridView ID="Gridview2" runat="server" OnRowDataBound="Gridview2_RowDataBound"
                    Width="100%" AutoGenerateColumns="false" ShowHeader="false" OnRowCommand="Gridview2_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSumSelect" runat="server" CausesValidation="False" Text='<%#Eval("FilePath") %>'></asp:LinkButton></ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnUpload2" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</div>
<asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div style="float: left; padding: 0px; width: 600px; height: 30px; text-align: center;">
            <asp:Label ID="Label157" runat="server" Text="" Width="600px" ForeColor="Red" Font-Size="Large"
                Font-Bold="True"></asp:Label>
        </div>
        <%-- <div id="VideoDiv" runat="server" style="float: left; padding: 0px; width: 600px;
        height: 520px;">
        <object width="600px" height="516px" classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6">
            <param name="autoStart" value="False">
            <param name="URL" value="<% =wmpfile %>">
            <param name="stretchToFit" value="True">
            <embed type="video/x-ms-wmv" width="600px" height="516px" autostart="False" url="<% =wmpfile %>"
                enabled="True" stretchtofit="True">
        </object>
    </div>
    <div style="float: left; padding: 0px; margin-left: 90px; width: 450px;">
        <b>Video Name </b><asp:TextBox ID="txtvideo" runat="server" Width="300px"></asp:TextBox>
        <asp:FileUpload ID="fUpload" runat="server" Width="300px" Visible="false" />
        <asp:Label ID="lblMsg" CssClass="tdMessage" Text="" runat="server"></asp:Label>
    </div>--%>
        <div style="float: left; margin-top: 20px; padding: 0px; width: 600px;">
        </div>
        <div style="float: left; padding: 0px; width: 600px;">
        </div>
        <div style="float: left; width: 570px; height: 1px; background-color: Black;">
        </div>
        <div style="float: left; width: 600px; height: 1094px;">
            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 1172px;">
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
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>
            <div style="float: left; width: 296px; height: 26px; padding: 0px;">
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    <b>Variable</b></div>
                <br />
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    <b>Set Position</b></div>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    Front Block Distance</div>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    Rear Block Distance</div>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    Front Upper Leg Angle</div>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    Rear Upper Leg Angle</div>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    Front Lower Leg Angle</div>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    Rear Lower Leg Angle</div>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    Trunk Angle</div>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    COG Distance</div>
                <br />
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    <b>Block Clearance</b></div>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    Rear Foot Clearance Time</div>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    Front Foot Clearance Time</div>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    Rear Lower Leg Angle at Rear Takeoff</div>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    Front Lower Leg Angle at Front Takeoff</div>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    Trunk Angle at Takeoff</div>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    Lower Leg Angle at Ankle Cross</div>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    Air Time</div>
                <%--<div style="background-color: #FFE1AA; width: 296px; height: 26px;">Stride RateBC</div>--%>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    Stride Length</div>
                    
                  <br />
                <%--<div style="background-color: #FFE1AA; width: 296px; height: 26px;">Velocity</div><br />--%>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                  <b>Step 1</b></div>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    COG Touchdown Distance</div>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    Rear Lower Leg Angle at Takeoff</div>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    Trunk Angle at Takeoff</div>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    Lower Leg Angle at Ankle Cross</div>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    Ground Time</div>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    Air Time</div>
                <%--<div style="background-color: #FFB9AF; width: 296px; height: 26px;">Stride Rate</div>--%>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    Stride Length</div>
                    
                   <br />
                <%--<div style="background-color: #FFB9AF; width: 296px; height: 26px;">Velocity</div><br />--%>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    <b>Step 2</b></div>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    COG Touchdown Distance</div>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    Rear Lower Leg Angle at Takeoff</div>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    Trunk Angle at Takeoff</div>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    Lower Leg Angle at Ankle Cross</div>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    Ground Time</div>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    Air Time</div>
                <%--<div style="background-color: #FFB9AF; width: 296px; height: 26px;">Stride Rate</div>--%>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    Stride Length</div>
                <%--<div style="background-color: #FFB9AF; width: 296px; height: 26px;">Velocity</div><br />--%>
                
                <br />
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    <b>Step 3</b></div>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    COG Touchdown Distance</div>
                <br />
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    <b>Time to Marker</b></div>
                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                    Time to 3m</div>
                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                    Time to 5m</div>
            </div>
            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 1172px;">
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
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>
            <div style="float: left; width: 90px; height: 26px; padding: 0px; text-align: center;">
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <b>Initial</b></div>
                <br />
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetFrontBlockDistanceI" runat="server" Text="" Width="50px" Height="20px"> </asp:TextBox></div>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetRearBlockDistanceI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetFrontULAngleI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetRearULAngleI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetFrontLLAngleI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetRearLLAngleI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetTrunkAngleI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetCOGDistanceI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <br />
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCRearFootClearanceTimeI" runat="server" Text="" Width="50px"
                        Height="20px"></asp:TextBox></div>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCFrontFootClearanceTimeI" runat="server" Text="" Width="50px"
                        Height="20px"></asp:TextBox></div>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCRearLLAngleTakeoffI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCFrontLLAngleTakeoffI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCTrunkAngleTakeoffI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCLLAngleACI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCAirTimeI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <%--<div style="background-color: #FFFF80; width: 90px; height: 26px;"><asp:Label ID="Label16" runat="server" Text="" Width="75px"></asp:Label></div>--%>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCStrideLengthI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                    <br />
                <%--<div style="background-color: #FFFF80; width: 90px; height: 26px;"><asp:Label ID="Label18" runat="server" Text="" Width="75px"></asp:Label></div><br />--%>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1COGDistanceI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1LLAngleTakeoffI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1TrunkAngleTakeoffI" runat="server" Text="" Width="50px"
                        Height="20px"></asp:TextBox></div>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1LLAngleACI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1GroundTimeI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1AirTimeI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <%--<div style="background-color: #EBEB41; width: 90px; height: 26px;"><asp:Label ID="Label25" runat="server" Text="" Width="50px" Height="20px" ></asp:TextBox></div>--%>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1StrideLengthI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                    
                  <br />
                <%--<div style="background-color: #EBEB41; width: 90px; height: 26px;"><asp:Label ID="Label27" runat="server" Text="" Width="75px"></asp:Label></div><br />--%>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2COGDistanceI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2LLAngleTakeoffI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2TrunkAngleTakeoffI" runat="server" Text="" Width="50px"
                        Height="20px"></asp:TextBox></div>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2LLAngleACI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2GroundTimeI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2AirTimeI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <%--<div style="background-color: #EBEB41; width: 90px; height: 26px;"><asp:Label ID="Label34" runat="server" Text="" Width="75px"></asp:Label></div>--%>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2StrideLengthI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                  <br />  
                  
                <%--<div style="background-color: #EBEB41; width: 90px; height: 26px;"><asp:Label ID="Label36" runat="server" Text="" Width="75px"></asp:Label></div><br />--%>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep3COGDistanceI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <br />
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblTimeTo3mI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblTimeTo5mI" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
            </div>
            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 1172px;">
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
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>
            <div style="float: left; width: 90px; height: 26px; padding: 0px; text-align: center;">
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <b>Model</b></div>
                <br />
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetFrontBlockDistanceM1" runat="server" Text="" Width="50px"
                        Height="20px"> </asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetRearBlockDistanceM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetFrontULAngleM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetRearULAngleM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetFrontLLAngleM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetRearLLAngleM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetTrunkAngleM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetCOGDistanceM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <br />
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCRearFootClearanceTimeM1" runat="server" Text="" Width="50px"
                        Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCFrontFootClearanceTimeM1" runat="server" Text="" Width="50px"
                        Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCRearLLAngleTakeoffM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCFrontLLAngleTakeoffM1" runat="server" Text="" Width="50px"
                        Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCTrunkAngleTakeoffM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCLLAngleACM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCAirTimeM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <%--<div style="background-color: #C0FFC0; width: 90px; height: 26px;"><asp:Label ID="Label16" runat="server" Text="" Width="75px"></asp:Label></div>--%>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCStrideLengthM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                    
                   <br />
                <%--<div style="background-color: #C0FFC0; width: 90px; height: 26px;"><asp:Label ID="Label18" runat="server" Text="" Width="75px"></asp:Label></div><br />--%>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1COGDistanceM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1LLAngleTakeoffM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1TrunkAngleTakeoffM1" runat="server" Text="" Width="50px"
                        Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1LLAngleACM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1GroundTimeM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1AirTimeM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <%--<div style="background-color: #91F591; width: 90px; height: 26px;"><asp:Label ID="Label25" runat="server" Text="" Width="50px" Height="20px" ></asp:TextBox></div>--%>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1StrideLengthM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                    
                  <br />
                <%--<div style="background-color: #91F591; width: 90px; height: 26px;"><asp:Label ID="Label27" runat="server" Text="" Width="75px"></asp:Label></div><br />--%>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2COGDistanceM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2LLAngleTakeoffM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2TrunkAngleTakeoffM1" runat="server" Text="" Width="50px"
                        Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2LLAngleACM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2GroundTimeM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2AirTimeM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <%--<div style="background-color: #91F591; width: 90px; height: 26px;"><asp:Label ID="Label34" runat="server" Text="" Width="75px"></asp:Label></div>--%>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2StrideLengthM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                    
                  <br />
                <%--<div style="background-color: #91F591; width: 90px; height: 26px;"><asp:Label ID="Label36" runat="server" Text="" Width="75px"></asp:Label></div><br />--%>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep3COGDistanceM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <br />
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblTimeTo3mM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblTimeTo5mM1" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
            </div>
            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 1172px;">
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
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>
            <div style="float: left; width: 90px; height: 26px; padding: 0px; text-align: center;">
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <b>Final</b></div>
                <br />
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetFrontBlockDistanceF" runat="server" Text="" Width="50px" Height="20px"> </asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetRearBlockDistanceF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetFrontULAngleF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetRearULAngleF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetFrontLLAngleF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetRearLLAngleF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetTrunkAngleF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblSetCOGDistanceF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <br />
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCRearFootClearanceTimeF" runat="server" Text="" Width="50px"
                        Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCFrontFootClearanceTimeF" runat="server" Text="" Width="50px"
                        Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCRearLLAngleTakeoffF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCFrontLLAngleTakeoffF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCTrunkAngleTakeoffF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCLLAngleACF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCAirTimeF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <%--<div style="background-color: #C0FFC0; width: 90px; height: 26px;"><asp:Label ID="Label16" runat="server" Text="" Width="75px"></asp:Label></div>--%>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblBCStrideLengthF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                    
                   <br />
                <%--<div style="background-color: #C0FFC0; width: 90px; height: 26px;"><asp:Label ID="Label18" runat="server" Text="" Width="75px"></asp:Label></div><br />--%>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1COGDistanceF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1LLAngleTakeoffF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1TrunkAngleTakeoffF" runat="server" Text="" Width="50px"
                        Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1LLAngleACF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1GroundTimeF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1AirTimeF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <%--<div style="background-color: #91F591; width: 90px; height: 26px;"><asp:Label ID="Label25" runat="server" Text="" Width="50px" Height="20px" ></asp:TextBox></div>--%>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep1StrideLengthF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                    
                  <br />
                <%--<div style="background-color: #91F591; width: 90px; height: 26px;"><asp:Label ID="Label27" runat="server" Text="" Width="75px"></asp:Label></div><br />--%>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2COGDistanceF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2LLAngleTakeoffF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2TrunkAngleTakeoffF" runat="server" Text="" Width="50px"
                        Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2LLAngleACF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2GroundTimeF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2AirTimeF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <%--<div style="background-color: #91F591; width: 90px; height: 26px;"><asp:Label ID="Label34" runat="server" Text="" Width="75px"></asp:Label></div>--%>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep2StrideLengthF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                    
                  <br />
                <%--<div style="background-color: #91F591; width: 90px; height: 26px;"><asp:Label ID="Label36" runat="server" Text="" Width="75px"></asp:Label></div><br />--%>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblStep3COGDistanceF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <br />
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    &nbsp;</div>
                <div style="background-color: #91F591; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblTimeTo3mF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                    <asp:TextBox ID="lblTimeTo5mF" runat="server" Text="" Width="50px" Height="20px"></asp:TextBox></div>
            </div>
            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 1172px;">
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
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>
            <div style="float: left; width: 570px; height: 1px; background-color: Black;">
            </div>
            <div style="float: left; padding: 0px; width: 600px; height: 20px; margin-left: 200px;">
            </div>
            <div style="float: left; padding: 0px; margin-left: 200px; width: 300px; height: 26px;">
                <asp:Label ID="Label1" runat="server" Text="" Width="600px" ForeColor="Red" Font-Size="Large"
                    Font-Bold="True"></asp:Label>
            </div>
            <%-- <div style="float: left; padding: 0px; margin-left: 250px; width: 100px; height: 20px;">
                <asp:Button ID="btnSubmit" runat="server" Width="100px" Text="Submit" OnClick="btnSubmit_Click" />
            </div>--%>
            <table style="margin-left: 250px;">
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Width="100px" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnDeleteSession" runat="server" Width="100px" Text="Delete Session"
                            OnClick="btnDeleteSession_Click" OnClientClick="return getAlert()"/>
                    </td>
                </tr>
            </table>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
