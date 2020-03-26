<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="EmailTeacher.aspx.cs" Inherits="Users_EmailTeacher" Title="CompuSport – Email a Coach" ValidateRequest="false" %>
<%@ Register Src="~/Controls/ContactMenu.ascx" TagName="ContactMenu" TagPrefix="uc1" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="submenu">
        <uc1:ContactMenu runat="server" />
    </div>
    <p class="pagetitle">Email a Coach</p>
    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 75px;">
        <asp:Label ID="Label1" runat="server" Text="Location: " Font-Bold="True" Width="75px"></asp:Label>
    </div>
    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 800px;">
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
                <asp:DropDownList ID="DropDownList2" runat="server"
                    onselectedindexchanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList><br />
                </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 75px;">
        <asp:Label ID="Label4" runat="server" Text="Coach: " Font-Bold="True" Width="75px"></asp:Label>
    </div>
    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 800px;">
        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="DropDownList2" eventname="SelectedIndexChanged" />
            </Triggers>
            <ContentTemplate>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList><br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
    <asp:Label ID="Label7" runat="server" Text="My Email: " Font-Bold="true" Width="75px"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server" Rows="1" Width="378px"></asp:TextBox><br />
    <asp:Label ID="Label5" runat="server" Text="Subject: " Font-Bold="True" Width="75px"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Rows="1" Width="378px"></asp:TextBox><br />
    <asp:Label ID="Label6" runat="server" Text="Email: " Font-Bold="True" Width="75px"></asp:Label>
    <%--
    <asp:TextBox ID="TextBox2" runat="server" Height="300px" MaxLength="2000" 
        TextMode="MultiLine" Width="453px"></asp:TextBox>
    <br /><br />
    --%>
    <FTB:FreeTextBox id="FreeTextBox1" AutoGenerateToolbarsFromString="false" Width="453px" Height="300px" runat="Server" />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
    <asp:Label ID="Label2" runat="server" Text="Your email was successfully sent." Visible="False"></asp:Label>
</asp:Content>

