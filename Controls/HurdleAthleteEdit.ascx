<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HurdleAthleteEdit.ascx.cs"
    Inherits="TrackData_HurdleAthleteEdit" %>
<style type="text/css">
    .style1
    {
        width: 135px;
        vertical-align: bottom;
    }
    .style2
    {
        width: 100px;
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
        window.location.reload(true);// changes 20170110
    }
</script>

<div>
    <div style="float: left; padding: 0px; width: 600px; height: 40px; font-size: xx-large;
        text-align: center;">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1">
            <ProgressTemplate>
                <div style="text-align: left; position: absolute; top: 25%; left: 50%; margin-left: -70px;">
                    <img src="../images/big_loading.gif" alt="" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <b>Hurdle - Maximum Velocity</b>
        <br />
        <br />
    </div>
    <div style="float: left; width: 600px;">
        <asp:UpdateProgress ID="Updat_Paymentxyz" runat="server" DisplayAfter="1">
            <ProgressTemplate>
                <div style="text-align: left; position: absolute; top: 25%; left: 50%; margin-left: -70px;">
                    <img src="../images/big_loading.gif" alt="" />
                    &nbsp;
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        
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
                            <asp:Label ID="Label2" ForeColor="Red" runat="server" Text="The selected athlete does not have Sessions "
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
            <%--<tr>
                <td colspan="3" align="left">
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="300px" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                        <asp:ListItem Value="nodate">Select Lessson Date and Location</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>--%>
            <tr valign="top">
                <td>
                    <asp:Button ID="btndateloc" runat="server" Text="Enter New Date and Location" OnClick="Button1_Click" />
                </td>
                <td>
                    <asp:Label ID="lblLocation" runat="server" Text="Enter New Location" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLocation" runat="server" Visible="false"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblexlocation" runat="server" Visible="false" Text="(ex.Los Angeles)"></asp:Label>
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
                    <asp:Label ID="lblDateEx" runat="server" Text="(ex. 02/15/2011)" Visible="false"></asp:Label>
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
        </table>
    </div>
    <%-- browse for initial videos--%>
    <%--<asp:Panel ID="Panel1" runat="server" Height="350px" Width="100%">--%>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtbFilePath" runat="server" Width="500" Visible="true" Font-Bold="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnUpload" runat="server" Visible="true" Text="Browse for Initial Session video"
                            OnClick="btnUpload_Click" Width="215px" />
                    </td>
                    <td>
                        <asp:Button ID="btnDeleteInitialMovies" runat="server" Visible="true" 
                            Text="Delete Initial Movies" onclick="btnDeleteInitialMovies_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <div style="overflow: auto; width: 600px;height:100px;">
	 <asp:Label ID="lblNoVideo" ForeColor="Red" runat="server" Text="At least one of the video files for this Session are missing"
                                Visible="false"></asp:Label>
        <asp:UpdatePanel ID="Updatepanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="Gridview1" runat="server" OnRowDataBound="Gridview1_RowDataBound"
                    OnRowCommand="Gridview1_RowCommand" Width="100%" AutoGenerateColumns="false"
                    ShowHeader="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSelect" runat="server" CausesValidation="False" Text='<%#Eval("FilePath") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnUpload" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <br />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
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
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <%-- browse for current videos--%>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtForCurrentVideo" runat="server" Width="500" Visible="true" Font-Bold="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnToBrowseCurrentVideo" runat="server" Visible="true" Text="Browse for Session Current Video"
                            OnClick="btnToBrowseCurrentVideo_Click" Width="215px" />
                    </td>
                    <td>
                        <asp:Button ID="btnDeleteCurrentMovies" runat="server" Visible="true" 
                            Text="Delete Current Movies" onclick="btnDeleteCurrentMovies_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="overflow: auto; width: 600px; height:100px;">
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
    <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
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
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <%-- browse for summary sessions--%>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtSumFilePath" runat="server" Width="500" Visible="true" Font-Bold="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnUpload2" runat="server" Visible="true" Text="Browse for Summary Video"
                            OnClick="btnUpload2_Click" Width="215px" />
                    </td>
                    <td>
                        <asp:Button ID="btnDeleteSummaryMovie" runat="server" Visible="true" 
                            Text="Delete Summary Movie" onclick="btnDeleteSummaryMovie_Click"
                           />
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
            <div style="overflow: auto; width: 600px;height:100px;">
                <asp:GridView ID="Gridview2" runat="server" OnRowDataBound="Gridview2_RowDataBound"
                    Width="100%" AutoGenerateColumns="false" ShowHeader="false" 
                    OnRowCommand="Gridview2_RowCommand" Height="66px">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSumSelect" runat="server" CausesValidation="False" Text='<%#Eval("FilePath") %>'></asp:LinkButton>
                            </ItemTemplate>
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
<table id="table1" border="0px" cellpadding="0px" cellspacing="0px">
    <tr>
        <td>
            <div id="div12" style="margin-top: 0px; margin-bottom: 0px;">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <div style="float: left; padding: 0px; width: 600px; height: 30px; text-align: center;">
                            <asp:Label ID="Label117" runat="server" Width="591px" ForeColor="Red" Font-Size="Large"
                                Font-Bold="True" Height="16px"></asp:Label>
                        </div>
                        <%--  <div id="VideoDiv" runat="server" style="float: left; padding: 0px; width: 600px;
        height: 520px;">
        <object width="600px" height="516px" classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6">
            <param name="autoStart" value="False">
            <param name="URL" value="<% =wmpfile %>">
            <param name="stretchToFit" value="True">
            <embed type="video/x-ms-wmv" width="600px" height="516px" autostart="False" url="<% =wmpfile %>"
                enabled="True" stretchtofit="True">
        </object>
    </div>--%>
                        <%--div style="float: left; padding: 0px; margin-left: 150px; width: 450px;">
                                <asp:FileUpload ID="fUpload" runat="server" Width="300px" Visible="false" />
                                <asp:Label ID="lblMsg" CssClass="tdMessage" Text="" runat="server"></asp:Label>
                            </div>--%>
                        <%--<div style="float: left; margin-top: 20px; padding: 0px; width: 600px;">
                        </div>--%>
                        <%--<div style="float: left; padding: 0px; width: 600px;">
                        </div>--%>
                        <div style="float: left; margin-left: 10px; width: 576px; height: 1px; background-color: Black;">
                        </div>
                        <div style="float: left; margin-left: 10px; width: 730px; height: 938px">
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 950px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                                    Ground Time Into</div>
                                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                                    Ground Time Off</div>
                                <br />
                                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                                    Air Time</div>
                                <br />
                                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                                    Stride Length Into</div>
                                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                                    Stride Length Off</div>
                                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                                    Stride Length Total</div>
                                <br />
                                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                                    Velocity</div>
                                <br />
                                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                                    Touchdown Distance Into</div>
                                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                                    Touchdown Distance Off</div>
                                <br />
                                
                                <div style="background-color: #FFE1AA; width: 297px; height: 26px;">
                                    Knee-Knee Separation at Touchdown Into</div>
                                
                                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                                    Knee-Ankle Separation at Touchdown Off</div>
                                <br />
                                
                                 <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                                    Trunk Touchdown Angle Into</div>
                                
                                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                                   Trunk Takeoff Angle Into</div>
                                 <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                                    Trunk Minimum Angle Over</div>
                                
                                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                                   Trunk Touchdown Angle Off</div>
                                    <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                                    Trunk Takeoff Angle Off</div>
                                <br />
                                
                                
                                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                                    Lead Upper Leg Angle at Touchdown Into</div>
                                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                                    Lead Upper Leg Angle at Takeoff Into</div>
                               <%-- <div style="background-color: White; width: 296px; height: 26px; height: 4px;">
                                </div>--%>
                                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                                   Lead Upper Leg Maximum Angle Over</div>
                                
                                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                                    Lead Upper Leg Angle at Touchdown Off</div>
                                <div style="background-color:#FFB9AF; width: 296px; height: 26px;">
                                    Lead Upper Leg Angle at Takeoff Off</div>
                                    
                                     <br />
                                <%--<div style="background-color: White; width: 296px; height: 26px; height: 4px;">
                                </div>--%>
                               
                                
                                 <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                                    Knee-Ankle Minimum Separation Over</div>
                                 <br />
                                
                                <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                                    Lead Lower Leg Minimum Angle Into</div>
                                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                                    Lead Lower Leg Angle at Ankle Cross Into</div>
                                <%--<div style="background-color: White; width: 296px; height: 26px; height: 4px;">
                                </div>
                                --%>
                                 <div style="background-color: #FFB9AF; width: 296px; height: 26px;">
                                    Lead Lower Leg Maximum Angle Over</div>
                                
                                <div style="background-color: #FFE1AA; width: 296px; height: 26px;">
                                   Lead Lower Leg Angle at Touchdown Off</div>
                                <div style="background-color:#FFB9AF; width: 296px; height: 26px;">
                                  Lead Lower Leg Angle at Takeoff Off</div>
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 950px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                                    <asp:TextBox ID="lblGroundTimeIntoI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblGroundTimeOffI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblAirTimeI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblStrideLengthIntoI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblStrideLengthOffI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblStrideLengthTotalI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblVelocityI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTouchdownDistanceIntoI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTouchdownDistanceOffI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblKneeSeperationTouchDownIntoI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblKneeSeperationTouchDownOffI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                
                                 <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkTouchDownAngleIntoI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkTakeoffAngleIntoI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                    <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkMinimumAngleOverI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                    <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkTouchDownAngleOffI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                    <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkTakeoffAngleOffI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                
                                
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegAngleatTouchdownIntoI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegAngleatTakeoffIntoI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: White; width: 90px; height: 26px; height: 4px;">
                                </div>
                                --%>
                                 <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLeadUpperLegMaximumAngleOverI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegAngleatTouchdownOffI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegAngleatTakeoffOffI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                     <br />
                              <%--  <div style="background-color: White; width: 90px; height: 26px; height: 4px;">
                                </div>--%>
                                
                                
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblKneeAnkleMinimumSeparationOverI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                        
                                   <br />
                                
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLeadLowerLegMinimumAngleIntoI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLeadLowerLegAngleatAnkleCrossIntoI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                              <%--  <div style="background-color: White; width: 90px; height: 26px; height: 4px;">
                                </div>--%>
                                
                                  <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLeadLowerLegMaximumAngleOverI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleatTouchdownOffI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleatTakeoffOffI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 950px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                                    <asp:TextBox ID="lblGroundTimeIntoM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblGroundTimeOffM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblAirTimeM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblStrideLengthIntoM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblStrideLengthOffM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblStrideLengthTotalM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                               <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblVelocityHurdleM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTouchdownDistanceIntoM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTouchdownDistanceOffM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblKneeSeperationTouchDownIntoM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblKneeSeperationTouchDownOffM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                
                                 <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkTouchDownAngleIntoM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkTakeoffAngleIntoM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                    <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkMinimumAngleOverM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                    <div style="background-color:#91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkTouchDownAngleOffM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                    <div style="background-color:#C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkTakeoffAngleOffM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegAngleatTouchdownIntoM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegAngleatTakeoffIntoM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: White; width: 90px; height: 26px; height: 4px;">
                                </div>
                                --%>
                                      <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLeadUpperLegMaximumAngleOverM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegAngleatTouchdownOffM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegAngleatTakeoffOffM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                        
                                      <br />
                               <%-- <div style="background-color: White; width: 90px; height: 26px; height: 4px;">
                                </div>
                                --%>
                                <div style="background-color:#C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblKneeAnkleMinimumSeparationOverM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                   <br />
                                
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLeadLowerLegMinimumAngleIntoM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLeadLowerLegAngleatAnkleCrossIntoM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: White; width: 90px; height: 26px; height: 4px;">
                                </div>
                                --%>
                                 <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLeadLowerLegMaximumAngleOverM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleatTouchdownOffM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleatTakeoffOffM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 950px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                                    <asp:TextBox ID="lblGroundTimeIntoF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblGroundTimeOffF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblAirTimeF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblStrideLengthIntoF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblStrideLengthOffF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblStrideLengthTotalF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                               <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblVelocityHurdleF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTouchdownDistanceIntoF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTouchdownDistanceOffF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblKneeSeperationTouchDownIntoF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblKneeSeperationTouchDownOffF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                
                                 <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkTouchDownAngleIntoF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkTakeoffAngleIntoF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkMinimumAngleOverF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkTouchDownAngleOffF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color:#C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkTakeoffAngleOffF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                
                                <div style="background-color:#91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegAngleatTouchdownIntoF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegAngleatTakeoffIntoF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                               <%-- <div style="background-color: White; width: 90px; height: 26px; height: 4px;">
                                </div>--%>
                                
                                      <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLeadUpperLegMaximumAngleOverF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegAngleatTouchdownOffF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegAngleatTakeoffOffF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                        
                                     <br />
                                <%--<div style="background-color: White; width: 90px; height: 26px; height: 4px;">
                                </div>--%>
                                
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblKneeAnkleMinimumSeparationOverF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                    <br />
                                
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLeadLowerLegMinimumAngleIntoF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLeadLowerLegAngleatAnkleCrossIntoF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                               <%-- <div style="background-color: White; width: 90px; height: 26px; height: 4px;">
                                </div>--%>
                                
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLeadLowerLegMaximumAngleOverF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                
                                
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleatTouchdownOffF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleatTakeoffOffF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 950px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                            <%-- </div>--%>
                            <div style="float: left; width: 574px; height: 1px; background-color: Black;">
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
            </div>
        </td>
    </tr>
    <tr>
        <td>
        </td>
    </tr>
</table>


<table style="margin-left:300px;">
<tr>
<br/>
<td class="style2">
<asp:Button ID="btnSubmit" runat="server" Width="100px" Text="Submit" 
        OnClick="btnSubmit_Click" Height="26px" />
</td>
<td>
<asp:Button ID="btnDeleteSession" runat="server" Width="100px" 
        Text="Delete Session1" onclick="btnDeleteSession_Click" OnClientClick="return getAlert()"/>
</td>
</tr>
</table>
<%--<div style="margin-top: 0px; margin-bottom: 100px; margin-left: 300px;">
    <asp:Button ID="btnSubmit" runat="server" Width="100px" Text="Submit" OnClick="btnSubmit_Click" />
</div>--%><%-- <div style="float: left; margin-left: 10px; width: 652px; height: 1px; background-color: Black;">
                                </div>
                                <div style="float: left; padding: 0px; width: 570px; height: 20px;">
                                    &nbsp;
                                </div>
                            </div>
                            <br />
                            <br />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <br />
                      <br />
                    <div style="float: left; margin-left: 250px; margin-bottom: 50px; padding: 0px; width: 300px;
                        height: 30px;">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="150px" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
--%>