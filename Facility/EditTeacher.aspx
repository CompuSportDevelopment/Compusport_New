<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="EditTeacher.aspx.cs" Inherits="Facility_EditTeacher" Title="SwingModel - Edit Teacher Details" %>
<%@ Register Src="~/Controls/FacilityMenu.ascx" TagName="FacilityMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="submenu">
        <uc1:FacilityMenu ID="FacilityMenu1" runat="server" />
    </div>
    <p class="pagetitle">Edit Teacher Details</p>
    <asp:Label ID="Label1" runat="server" Text="First Name:" Width="160" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Width="300"></asp:TextBox>
    <asp:Label ID="Label7" runat="server" Text="* Required" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Last Name:" Width="160" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" Width="300"></asp:TextBox>
    <asp:Label ID="Label8" runat="server" Text="* Required" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Work Phone:" Width="160" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server" Width="300"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Mobile Phone:" Width="160" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="TextBox4" runat="server" Width="300"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Fax:" Width="160" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="TextBox5" runat="server" Width="300"></asp:TextBox>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Teaching Password:" Width="160" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="TextBox6" runat="server" Width="300"></asp:TextBox>
    <asp:Label ID="Label9" runat="server" Text="* Required" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label>
    <br /><br />
    <div style="width: 500px; text-align: center;">
        <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
    </div>
</asp:Content>

