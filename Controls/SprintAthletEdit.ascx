<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SprintAthletEdit.ascx.cs"
    Inherits="TrackData_SprintAthletEdit" %>
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
        window.location.reload(false);
    }
</script>
<div>
    <div style="float: left; padding: 0px; width: 600px; height: 40px; font-size: xx-large;
        text-align: center;">
        <b>Sprint - Maximum Velocity</b>
        <br />
        <br />
        <br />
        <asp:UpdateProgress ID="Updat_Paymentxyz" runat="server" DisplayAfter="1">
            <ProgressTemplate>
                <div style="text-align: left; position: absolute; top: 25%; left: 50%; margin-left: -70px;">
                    <img src="../images/big_loading.gif" alt="" />
                    <%-- <img src="../image/big_loading.gif" alt="" />--%>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
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
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="300px" AutoPostBack="True"
                                Visible="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                <asp:ListItem Value="nodate">Select Session</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="Label2" ForeColor="Red" runat="server" Text="The selected athlete does not have Sessions "
                                Visible="false"></asp:Label>
                            <asp:Label ID="Label4" ForeColor="Red" runat="server" Text="please Select Session.....!"
                                Visible="false"></asp:Label>
                              <%--  <asp:Label ID="Label5" ForeColor="Red" runat="server" Text="No MovieFiles Available ...!"
                        Visible="false"></asp:Label>--%>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left">
                    <%--<asp:DropDownList ID="DropDownList3" runat="server" Width="300px" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                        <asp:ListItem Value="nodate">Select Lessson Date and Location</asp:ListItem>
                    </asp:DropDownList>--%>
                </td>
            </tr>
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
          <%--  <tr>
                <td>
                    <asp:Label ID="Label5" ForeColor="Red" runat="server" Text="No MovieFiles Available ...!"
                        Visible="false"></asp:Label>
                </td>
            </tr>--%>
        </table>
    </div>
    <%-- browse for initial videos--%>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtbFilePath" runat="server" Width="500" Visible="true" Font-Bold="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnUpload" runat="server" Visible="true" Text="Browse for Session Initial Video"
                            OnClick="btnUpload_Click" Width="215px" />
                    </td>
                    <td>
                        <asp:Button ID="btnDeleteInitialMovies" runat="server" Visible="true" Text="Delete Initial Movies"
                            OnClick="btnDelete_Click" />
                    </td>
                </tr>
                
            </table>
        </ContentTemplate>
       
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="updtepnlgrig" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="overflow: auto; width: 600px; height: 150px;">
             <asp:Label ID="lblNoVideo" ForeColor="Red" runat="server" Text="At least one of the video files for this Session are missing"
                                Visible="false"></asp:Label>  <asp:Label ID="lblVariableMssing" ForeColor="Red" runat="server" Text="identifying the Variable Group that is missing or has a zero value."
                                Visible="false"></asp:Label>
                <asp:GridView ID="Gridview1" runat="server" OnRowDataBound="Gridview1_RowDataBound"
                    Width="100%" AutoGenerateColumns="false" ShowHeader="false" OnRowCommand="Gridview1_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSelect" runat="server" CausesValidation="False" Text='<%#Eval("FilePath") %>'></asp:LinkButton>
                                <%--<asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" Text='<%#Eval("FilePath") %>'></asp:LinkButton>--%>
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
    <br />
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
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
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
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
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
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
    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
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
    <%-- newly added coede--%>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
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
                        <asp:Button ID="btnDeleteSummaryMovie" runat="server" Visible="true" Text="Delete Summary Movie"
                            OnClick="DeleteSummaryMovie_Click" />
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
    <%--  end--%>
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
                                <asp:Label ID="lblDataSave" ForeColor="Red" runat="server" Text="Data saved successfully"
                                Visible="false"></asp:Label>
                        </div>
                        <%--<div id="VideoDiv" runat="server" visible="false" style="float: left; padding: 0px;
                            width: 600px; height: 520px;" ondblclick="return VideoDiv_ondblclick()">
                            <object width="600px" height="516px" classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6">
                                <param name="autoStart" value="False">
                                <param name="URL" value="<% =wmpfile %>">
                                <param name="stretchToFit" value="True">
                                <embed type="video/x-ms-wmv" width="600px" height="516px" autostart="False" url="<% =wmpfile %>"
                                    enabled="True" stretchtofit="True">
                            </object>
                        </div>--%>
                        <%--<div style="float: left; padding: 0px; margin-left: 90px; width: 450px;">
                            <b>Video Name </b><asp:TextBox ID="txtvideo" runat="server" Width="300px"></asp:TextBox>
                            <asp:FileUpload ID="fUpload" runat="server" Width="300px" Visible="true" />
                            <asp:Label ID="lblMsg" CssClass="tdMessage" Text="" runat="server"></asp:Label>
                        </div>--%>
                        <div style="float: left; margin-top: 20px; padding: 0px; width: 600px;">
                        </div>
                        <div style="float: left; width: 571px; height: 1px; background-color: Black;">
                        </div>
                        <div id="AllVaribal" style="float: left; width: 750px; border: 1px;">
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 808px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                                <br />
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Ground Time Average</div><br />--%>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Air Time Left to Right</div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Air Time Right to Left</div>
                                <br />
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Air Time Average</div><br />--%>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Time to Upper Leg Full Flexion Left</div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Time to Upper Leg Full Flexion Right</div>
                                <br />
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Time to Upper Leg Full Flexion Average</div><br />--%>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Stride Rate</div><br />--%>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Stride Length Left to Right</div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Stride Length Right to Left</div>
                                <br />
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Time to Upper Leg Full Flexion Average</div><br />--%>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Stride Rate</div><br />--%>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Trunk Angle at Touchdown Left</div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Trunk Angle at Touchdown Right</div>
                                <br />
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Time to Upper Leg Full Flexion Average</div><br />--%>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Stride Rate</div><br />--%>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Knee Separation at Touchdown Left</div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Knee Separation at Touchdown Right</div>
                                <br />
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Stride Length Average</div><br />--%>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Velocity</div><br />--%>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Touchdown Distance Left</div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Touchdown Distance Right</div>
                                <br />
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Touchdown Distance Average</div><br />--%>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Upper Leg Full Extension Angle Left</div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Upper Leg Full Extension Angle Right</div>
                                <div style="background-color: White; width: 296px; height: 2px;">
                                </div>
                                <div style="background-color: White; width: 296px; height: 4px;">
                                </div>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Upper Leg Full Flexion Angle Left</div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Upper Leg Full Flexion Angle Right</div>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Upper Leg Full Extension Angle Average</div>--%>
                                <br />
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
                                <%--<div style="background-color: White; width: 296px; height: 4px;">
                                </div>
                                <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Lower Leg Angle at Ankle Cross Left</div>
                                <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Lower Leg Angle at Ankle Cross Right</div>--%>
                                <%--<div style="background-color: #FFB9AF; width: 295px; height: 26px;">Lower Leg Angle at Ankle Cross Average</div>--%>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Upper Leg Full Flexion Angle Average</div>--%>
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 808px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                                    <asp:TextBox ID="lblGroundTimeLeftI" runat="server" Width="60px" Height="21px" Style="margin-top: 0px"></asp:TextBox><br />
                                </div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblGroundTimeRightI" runat="server" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"> <asp:TextBox ID="txtGroundTimeAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox></div><br />--%>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblAirTimeLeftToRightI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblAirTimeRightToLeftI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtAirTimeAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox></div><br />--%>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTimeToUpperLegFullFlexionLeftI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTimeToUpperLegFullFlexionRightI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtFullFlexionAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtStriderate" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblStrideLengthLeftToRightI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblStrideLengthRightToLeftI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtFullFlexionAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtStriderate" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkAngleAtTouchdownLeftI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkAngleAtTouchdownRightI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtFullFlexionAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtStriderate" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblKneeSeperationAtTouchdownLeftI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblKneeSeperationAtTouchdownRightI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtStrideLengthAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"> <asp:TextBox ID="txtVelocity" runat="server" Width="60px" Height="16px"  ReadOnly="True"></asp:TextBox></div><br />--%>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTouchDownDistanceLeftI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTouchDownDistanceRightI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtCogDistanceAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegFullExtentionAngleLeftI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegFullExtentionAngleRightI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegFullFlexionAngleLeftI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegFullFlexionAngleRightI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtUlFullExtensionAngleAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <br />
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleAtTakeOfLeftI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleAtTakeOfRightI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #EBEB41; width: 90px;height:20px;"><asp:TextBox ID="txtLlaAngleTakeoffAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegFullFlexionAngleLeftI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegFullFlexionAngleRightI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtLlFullFlexionAngleAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleAtAnkleCrossLeftI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleAtAnkleCrossRightI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <%--<div style="background-color: #EBEB41; width: 90px;height:20px;"><asp:TextBox ID="txtLlAngleAcAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: #FFFF80; width: 90px; height: 26px;"><asp:TextBox ID="txtUlFullFlexionAngleAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 808px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                                    <asp:TextBox ID="lblGroundTimeLeftM1" runat="server" Width="60px" Height="21px"></asp:TextBox><%--<asp:Label ID="Label41" runat="server" Text="" Width="60px"></asp:Label>--%></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblGroundTimeRightM1" runat="server" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtGroundTimeAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox> </div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblAirTimeLeftToRightM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblAirTimeRightToLeftM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtAirTimeAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTimeToUpperLegFullFlexionLeftM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTimeToUpperLegFullFlexionRightM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtFullFlexionAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtStriderate1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblStrideLengthLeftToRighM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblStrideLengthRightToLeftM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtFullFlexionAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtStriderate1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkAngleAtTouchdownLeftM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkAngleAtTouchdownRightM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtFullFlexionAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtStriderate1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblKneeSeperationAtTouchdownLeftM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblKneeSeperationAtTouchdownRightM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtStrideLengthAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtVelocity1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTouchDownDistanceLeftM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTouchDownDistanceRightM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtCogDistanceAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegFullExtentionAngleLeftM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegFullExtentionAngleRightM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegFullFlexionAngleLeftM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegFullFlexionAngleRightM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtUlFullExtensionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <br />
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleAtTakeOfLeftM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleAtTakeOfRightM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #91F591; width: 90px;height:20px;"><asp:TextBox ID="txtLlaAngleTakeoffAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegFullFlexionAngleLeftM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegFullFlexionAngleRightM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtLlFullFlexionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleAtAnkleCrossLeftM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleAtAnkleCrossRightM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <%--<div style="background-color: #91F591; width: 90px;height:20px;"><asp:TextBox ID="txtLlAngleAcAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px; height:20px;"><asp:TextBox ID="txtUlFullFlexionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 808px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                                    <asp:TextBox ID="lblGroundTimeLeftF" runat="server" Width="60px" Height="21px"></asp:TextBox><%--<asp:Label ID="Label41" runat="server" Text="" Width="60px"></asp:Label>--%></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblGroundTimeRightF" runat="server" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtGroundTimeAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox> </div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblAirTimeLeftToRightF" runat="server" Text="" Width="60px" 
                                        Height="21px" ontextchanged="lblAirTimeLeftToRightF_TextChanged"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblAirTimeRightToLeftF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtAirTimeAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTimeToUpperLegFullFlexionLeftF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTimeToUpperLegFullFlexionRightF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtFullFlexionAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtStriderate1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblStrideLengthLeftToRighF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblStrideLengthRightToLeftF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtFullFlexionAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtStriderate1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkAngleAtTouchdownLeftF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTrunkAngleAtTouchdownRightF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtFullFlexionAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtStriderate1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblKneeSeperationAtTouchdownLeftF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblKneeSeperationAtTouchdownRightF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtStrideLengthAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtVelocity1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTouchDownDistanceLeftF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblTouchDownDistanceRightF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtCogDistanceAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegFullExtentionAngleLeftF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegFullExtentionAngleRightF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegFullFlexionAngleLeftF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblUpperLegFullFlexionAngleRightF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtUlFullExtensionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <br />
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleAtTakeOfLeftF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleAtTakeOfRightF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #91F591; width: 90px;height:20px;"><asp:TextBox ID="txtLlaAngleTakeoffAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegFullFlexionAngleLeftF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegFullFlexionAngleRightF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtLlFullFlexionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleAtAnkleCrossLeftF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblLowerLegAngleAtAnkleCrossRightF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <%--<div style="background-color: #91F591; width: 90px;height:20px;"><asp:TextBox ID="txtLlAngleAcAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px; height:20px;"><asp:TextBox ID="txtUlFullFlexionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 808px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
            </div>
        </td>
    </tr>
    <tr>
        <td>
        </td>
    </tr>
</table>
<%--<div style="margin-top: 0px; margin-left: 300px;">--%>
<table style="margin-left: 300px;">
    <tr>
        <td>
            <asp:Button ID="btnSubmit" runat="server" Width="100px" Text="Submit" OnClick="btnSubmit_Click" />
        </td>
        <td>
            <asp:Button ID="btnDeleteSession" runat="server" Width="100px" Text="Delete Session"
                OnClick="btnDeleteSession_Click" OnClientClick="return getAlert()" />
        </td>
    </tr>
</table>
<%--</div>--%>