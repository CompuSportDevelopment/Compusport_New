<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CoachtoAthlete.ascx.cs"
    Inherits="TrackData_CoachtoAthlete" %>
<div style="float: left; padding: 0px; width: 600px; height: 40px; font-size: xx-large;
    text-align: center;">
    <asp:UpdateProgress ID="Updat_Paymentxyz" runat="server" DisplayAfter="1">
        <ProgressTemplate>
            <div style="text-align: left; position: absolute; top: 25%; left: 50%; margin-left: -70px;">
                <img src="../images/big_loading.gif" alt="" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <b>Athlete/Coach Edit Page</b>
    <br />
    <br />
</div>
<div style="float: left; width: 600px; height: 500px;">
    <div style="float: left; margin-left: 200px; width: 300px; padding: 0px;">
        <asp:DropDownList ID="DropDownList1" runat="server" Width="220px" AutoPostBack="True"
            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="noathlete">Select Athlete</asp:ListItem>
        </asp:DropDownList>
        <%--</div>
    <div style="float: left; width: 300px; padding: 0px; text-align: right;">--%>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DropDownList ID="ddlPrimaryCoach" runat="server" Width="280px" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlPrimaryCoach_SelectedIndexChanged" Visible="true">
                    <asp:ListItem Value="nodate">Select Primary Coach Here To Add</asp:ListItem>
                </asp:DropDownList>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <table style="text-align: left">
            <tr>
                <td>
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="grdPrimaryCoach" runat="server" AutoGenerateColumns="false" DataKeyNames="TeacherId">
                                    <Columns>
                                        <asp:BoundField DataField="CoachName" DataFormatString="{0}" HeaderText="CoachName" />
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBoxPurchase" runat="server" Enabled="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
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
        <div style="float: left; text-align: left; margin-bottom: 20px; margin-top: 20px;">
            <asp:Label ID="lblPrimaryMessage" Text="" runat="server" Font-Size="Medium"></asp:Label>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Button ID="btnaddPrimaryCoach" Text="Add/Replace Primary Coach" runat="server" Visible="false"
                    OnClick="btnaddPrimaryCoach_Click"/>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DropDownList ID="DropDownList2" runat="server" Width="280px" AutoPostBack="True"
                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Visible="true">
                    <asp:ListItem Value="nodate">Select Coach Here To Add</asp:ListItem>
                </asp:DropDownList>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div style="float: left; text-align: left; margin-bottom: 20px; margin-top: 20px;">
        <asp:Label ID="lblmsg" Text="" runat="server" Font-Size="Medium"></asp:Label>
    </div>
    <table>
        <tr>
            <td>
                <div style="margin-left: 200px;">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="AthleteView" runat="server" AutoGenerateColumns="false" DataKeyNames="TeacherId">
                                <Columns>
                                    <asp:BoundField DataField="CoachName" DataFormatString="{0}" HeaderText="CoachName" />
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBoxPurchase" runat="server" Enabled="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
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
    <div style="margin-left: 200px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Button ID="btnAdd" Text="Add/Remove Coach" runat="server" Visible="false"
                    OnClick="btnAdd_Click" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
