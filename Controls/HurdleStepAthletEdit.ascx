<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HurdleStepAthletEdit.ascx.cs"
    Inherits="Controls_HurdleStepAthletEdit" %>
<style type="text/css">
    .style1
    {
        width: 135px;
        vertical-align: bottom;
    }
    .ModalPopupBG
    {
        background-color: #666699;
        filter: alpha(opacity=50);
        opacity: 0.7;
    }
    
    .HellowWorldPopup
    {
        min-width: 200px;
        min-height: 150px;
        background: white;
        margin-top:-325px;
        margin-left:-206px;
        margin-right:250px;
        padding: 15px !important;
    }
    .btn1
    {
        width:67px;
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
    
    <div style="float: left; padding: 0px; width: 600px; height: 40px; font-size: xx-large;
        text-align: center;">
        <b>Hurdle Steps - Maximum Velocity</b>
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
                    Visible="false"></asp:Label>   <asp:Label ID="lblVariableMssing" ForeColor="Red" runat="server" Text="identifying the Variable Group that is missing or has a zero value."
                                Visible="false"></asp:Label>
                <asp:GridView ID="Gridview1" runat="server" OnRowDataBound="Gridview1_RowDataBound"
                    Width="100%" AutoGenerateColumns="false" ShowHeader="false" OnRowCommand="Gridview1_RowCommand">
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
                        <div style="float: left; width: 595px; height: 1px; background-color: Black;">
                        </div>
                        <div style="float: left; width: 750px; border: 1px;">
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 1254px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                                <br />
                                <br />
                                <br />
                                <br />
                            </div>
                            <div style="float: left; width: 320px; padding: 0px; border: 3px none Black; margin-right: 0px;">
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    <b>Variable</b></div>
                                <br />
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Hurdle Distance Between</div>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Stride Length Into</div>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Ground Time Average</div><br />--%>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Stride Length Off</div>
                                <%-- <div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                               Hurdle Step Velocity</div>--%>
                                <br />
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    <b>Step One</b></div>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Air Time Average</div><br />--%>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step One Ground Time
                                </div>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Step One Air Time</div>
                                <%-- <div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Time to Upper Leg Full Flexion Average</div><br />--%>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Stride Rate</div><br />--%>
                                <%-- <div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Step One Upper Leg Flexion Time </div>--%>
                                <%--<div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                    Step One StrideRate</div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Stride Length Average</div><br />--%>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Velocity</div><br />--%>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step One Stride Length</div>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Step One Touchdown Distance</div>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Touchdown Distance Average</div><br />--%>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step One Knee Seperation at Touchdown</div>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Step One Trunk Touchdown Angle</div>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Upper Leg Full Extension Angle Average</div>--%>
                                <%--<div style="background-color: White; width: 296px; height: 4px;">
                                </div>--%>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step One Trunk Takeoff Angle</div>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Step One Upper Leg at Full Extension</div>
                                <%--<div style="background-color: #FFB9AF; width: 295px; height: 26px;">Lower Leg Angle at Takeoff Average</div>--%>
                                <%--<div style="background-color: White; width: 296px; height: 4px;">
                                </div>--%>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step One Lower Leg at Take off</div>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Step One Upper Leg at Full Flexion</div>
                                <br />
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    <b>Step Two</b></div>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Lower Leg Full Flexion Angle Average</div>--%>
                                <%--                                <div style="background-color: White; width: 296px; height: 4px;">
                                </div>--%>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Step Two Ground Time
                                </div>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step Two Air Time</div>
                                <%--<div style="background-color: #FFB9AF; width: 295px; height: 26px;">Lower Leg Angle at Ankle Cross Average</div>--%>
                                <%--<div style="background-color: White; width: 296px; height: 4px;">
                                </div>--%>
                                <%-- <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Step Two Upper Leg Flexion Time</div>--%>
                                <%--<div style="background-color: #FFB9AF; width: 295px; height: 26px;">
                                   Step Two Stride Rate</div>--%>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Step Two Stride Length</div>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step Two Touchdown Distance</div>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Step Two Knee Seperation at Touchdown</div>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step Two Trunk Touchdown Angle
                                </div>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Step Two Trunk Takeoff Angle
                                </div>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step Two Upper Leg at Full Extension
                                </div>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Step Two Lower Leg at Take off</div>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step Two Lower Leg at Full Flexion</div>
                                <%--  <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                  Step Two  Lower Leg at Ankle Cross</div>--%>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Step Two Upper Leg At Full Flexion
                                </div>
                                <br />
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    <b>Step Three</b></div>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step Three Ground Time</div>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Step Three Air Time</div>
                                <%-- <div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Step Three  Upper Leg Flexion Time</div>--%>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">
                                    Step Three Stride Rate</div>--%>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step Three Stride Length</div>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Step Three Touchdown Distance</div>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step Three Knee Seperation at Touchdown</div>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Step Three Trunk Touchdown Angle
                                </div>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step Three Trunk Takeoff Angle</div>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Step Three Upper Leg at Full Extension</div>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step Three Lower Leg at Take off</div>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Step Three Lower Leg Full Flexion
                                </div>
                                <%--                                     <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step Three  Lower Leg at Ankle Cross</div>--%>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    Step Three Upper Leg At Full Flexion</div>
                                <br />
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    <b>Into Hurdle</b></div>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Into Hurdle Touchdown Distance</div>
                                <div style="background-color: #FFB9AF; width: 320px; height: 24px;">
                                    Into Hurdle Knee Seperation at Touchdown</div>
                                <div style="background-color: #FFE1AA; width: 320px; height: 26px;">
                                    Into Hurdle Trunk Touchdown Angle</div>
                                <div style="background-color: #FFB9AF; width: 320px; height: 26px;">
                                    <%--<b>Td Knee Angle</b>--%>Into Hurdle Lower Leg at Touchdown</div>
                                <%--<div style="background-color: #FFE1AA; width: 295px; height: 26px;">Upper Leg Full Flexion Angle Average</div>--%>
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 1254px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                            <div style="float: left; width: 90px; padding: 0px; text-align: center;">
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <b>Initial</b></div>
                                <br />
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtHurdleDistanceBtweenI" runat="server" Width="60px" Height="21px"
                                        Style="margin-top: 0px"></asp:TextBox><br />
                                </div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtHurdleDistanceIntoI" runat="server" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"> <asp:TextBox ID="txtGroundTimeAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox></div><br />--%>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtHurdleDistanceOffI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="lblAirTimeRightToLeftI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>--%>
                                <%-- <div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtAirTimeAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                  <asp:TextBox ID="TxtHurdleVelocityI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox> </div>--%>
                                <br />
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    &nbsp;</div>
                                <%-- <div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtFullFlexionAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtStriderate" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1GroundTimeI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1AirTimeI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtStrideLengthAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"> <asp:TextBox ID="txtVelocity" runat="server" Width="60px" Height="16px"  ReadOnly="True"></asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1UlFlexTimeI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>--%>
                                <%--<div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1StrideRateI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtCogDistanceAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1StrideLengthI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1TouchDistanceI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtUlFullExtensionAngleAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1KSTouchDistanceI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1TrunkTouchdownAngleI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #EBEB41; width: 90px;height:20px;"><asp:TextBox ID="txtLlaAngleTakeoffAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1TrunkTakeoffAngleI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1ULFullExtensionI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #FFFF80; width: 90px;height:20px;"><asp:TextBox ID="txtLlFullFlexionAngleAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1LLTakeOffI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1ULFullFlexionI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <%--<div style="background-color: #EBEB41; width: 90px;height:20px;"><asp:TextBox ID="txtLlAngleAcAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    &nbsp;</div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2GroundTimeI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2AirTimeI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%-- <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2UlFlexTimeI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <%--<div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2StrideRateI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2StrideLengthI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2TouchDistanceI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2KSTouchDistanceI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2TrunkTouchdownAngleI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2TrunkTakeoffAngleI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2ULFullExtensionI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2LLTakeOffI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2LLFullFlexionI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--    <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2LLAnkleCrossI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2ULFullFlexionI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    &nbsp;</div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3GroundTimeI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3AirTimeI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3UlFlexTimeI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <%--  <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3StrideRateI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3StrideLengthI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3TouchDistanceI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3KSTouchDistanceI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3TrunkTouchdownAngleI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3TrunkTakeoffAngleI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3ULFullExtensionI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3LLTakeOffI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3LLFullFlexionI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--  <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3LLAnkleCrossI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3ULFullFlexionI" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    &nbsp;</div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtIntoHurdleTouchDistanceI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtIntoHurdleKSTouchDistanceI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #FFFF80; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtIntoHurdleTrunkTouchdownAngleI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #EBEB41; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtIntoHurdleLLTouchDistanceI" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #FFFF80; width: 90px; height: 26px;"><asp:TextBox ID="txtUlFullFlexionAngleAverage" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 1254px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                            <div style="float: left; width: 90px; padding: 0px; text-align: center;">
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <b>Model</b></div>
                                <br />
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtHurdleDistanceBtweenM1" runat="server" Width="60px" Height="21px"></asp:TextBox><%--<asp:Label ID="Label41" runat="server" Text="" Width="60px"></asp:Label>--%></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtHurdleDistanceIntoM1" runat="server" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtGroundTimeAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox> </div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtHurdleDistanceOffM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #91F591; width: 90px; height: 26px;">
                                  <asp:TextBox ID="TxtHurdleVelocityM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <br />
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtAirTimeAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    &nbsp;</div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1GroundTimeM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtFullFlexionAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtStriderate1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1AirTimeM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1UlFlexTimeM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtStrideLengthAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtVelocity1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1StrideRateM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1StrideLengthM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtCogDistanceAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1TouchDistanceM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1KSTouchDistanceM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtUlFullExtensionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1TrunkTouchdownAngleM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1TrunkTakeoffAngleM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #91F591; width: 90px;height:20px;"><asp:TextBox ID="txtLlaAngleTakeoffAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1ULFullExtensionM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1LLTakeOffM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtLlFullFlexionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1ULFullFlexionM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    &nbsp;</div>
                                <%--<div style="background-color: #91F591; width: 90px;height:20px;"><asp:TextBox ID="txtLlAngleAcAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2GroundTimeM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2AirTimeM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2UlFlexTimeM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <%-- <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2StrideRateM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2StrideLengthM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2TouchDistanceM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2KSTouchDistanceM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2TrunkTouchdownAngleM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2TrunkTakeoffAngleM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2ULFullExtensionM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2LLTakeOffM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2LLFullFlexionM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--     <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2LLAnkleCrossM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2ULFullFlexionM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    &nbsp;</div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3GroundTimeM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3AirTimeM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%-- <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3UlFlexTimeM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <%-- <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3StrideRateM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3StrideLengthM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3TouchDistanceM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3KSTouchDistanceM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3TrunkTouchdownAngleM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3TrunkTakeoffAngleM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3ULFullExtensionM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3LLTakeOffM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3LLFullFlexionM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3LLAnkleCrossM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3ULFullFlexionM1" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    &nbsp;</div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtIntoHurdleTouchDistanceM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtIntoHurdleKSTouchDistanceM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtIntoHurdleTrunkTouchdownAngleM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtIntoHurdleLLTouchDistanceM1" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px; height:20px;"><asp:TextBox ID="txtUlFullFlexionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 1254px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                            <div style="float: left; width: 90px; padding: 0px; text-align: center;">
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <b>Final</b></div>
                                <br />
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtHurdleDistanceBtweenF" runat="server" Width="60px" Height="21px"></asp:TextBox><%--<asp:Label ID="Label41" runat="server" Text="" Width="60px"></asp:Label>--%></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtHurdleDistanceIntoF" runat="server" Width="60px" Height="21px"></asp:TextBox></div>
                                <%-- <div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtGroundTimeAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox> </div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtHurdleDistanceOffF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #91F591; width: 90px; height: 26px;">
                                   <asp:TextBox ID="TxtHurdleVelocityF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox> </div>--%>
                                <br />
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtAirTimeAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"></asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    &nbsp;</div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1GroundTimeF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%-- <div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtFullFlexionAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtStriderate1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1AirTimeF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1UlFlexTimeF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtStrideLengthAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtVelocity1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1StrideRateF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>--%>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1StrideLengthF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%-- <div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtCogDistanceAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div><br />--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1TouchDistanceF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1KSTouchDistanceF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtUlFullExtensionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1TrunkTouchdownAngleF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1TrunkTakeoffAngleF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #91F591; width: 90px;height:20px;"><asp:TextBox ID="txtLlaAngleTakeoffAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1ULFullExtensionF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1LLTakeOffF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px;height:20px;"><asp:TextBox ID="txtLlFullFlexionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep1ULFullFlexionF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    &nbsp;</div>
                                <%--<div style="background-color: #91F591; width: 90px;height:20px;"><asp:TextBox ID="txtLlAngleAcAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                                <%--<div style="background-color: White; width: 90px; height: 4px;">
                                </div>--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2GroundTimeF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2AirTimeF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2UlFlexTimeF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <%--<div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2StrideRateF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2StrideLengthF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2TouchDistanceF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2KSTouchDistanceF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2TrunkTouchdownAngleF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2TrunkTakeoffAngleF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2ULFullExtensionF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2LLTakeOffF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2LLFullFlexionF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--  <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2LLAnkleCrossF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep2ULFullFlexionF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    &nbsp;</div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3GroundTimeF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3AirTimeF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3UlFlexTimeF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <%--<div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3StrideRateF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3StrideLengthF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3TouchDistanceF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3KSTouchDistanceF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3TrunkTouchdownAngleF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3TrunkTakeoffAngleF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3ULFullExtensionF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3LLTakeOffF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3LLFullFlexionF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3LLAnkleCrossF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>--%>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtStep3ULFullFlexionF" runat="server" Text="" Width="60px" Height="21px"></asp:TextBox></div>
                                <br />
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    &nbsp;</div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtIntoHurdleTouchDistanceF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtIntoHurdleKSTouchDistanceF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtIntoHurdleTrunkTouchdownAngleF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <div style="background-color: #91F591; width: 90px; height: 26px;">
                                    <asp:TextBox ID="TxtIntoHurdleLLTouchDistanceF" runat="server" Text="" Width="60px"
                                        Height="21px"></asp:TextBox></div>
                                <%--<div style="background-color: #C0FFC0; width: 90px; height:20px;"><asp:TextBox ID="txtUlFullFlexionAngleAverage1" runat="server" Width="60px" Height="21px" ReadOnly="True"> </asp:TextBox></div>--%>
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 1254px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                            <div style="float: left; width: 595px; height: 1px; background-color: Black;">
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
