<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="TeacherBio.aspx.cs" Inherits="Teachers_TeacherBio" Title="SwingModel - Edit Teacher Intro & Bio" ValidateRequest="false" %>
<%@ Register Src="~/Controls/TeachersMenu.ascx" TagName="TeachersMenu" TagPrefix="uc1" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="submenu">
        <uc1:TeachersMenu ID="TeachersMenu1" runat="server" />
    </div>
    <p class="pagetitle">Input My Coach Profile Information</p>
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell Width="170" Height="200">
                <asp:Image ID="Image1" runat="server" Width="150" Height="180" />
            </asp:TableCell>
            <asp:TableCell Width="730" Height="200" VerticalAlign="Middle">
                <asp:Label ID="Label1" runat="server" Text="Upload Image: " Font-Bold="True"></asp:Label><br />
                <asp:FileUpload ID="FileUpload1" runat="server" Width="450px" /><br />
                <asp:Label ID="Label5" runat="server" Text="The image is not required. Please insure that the image is 150 pixels wide by 180 pixels tall. JPG or PNG accepted." ForeColor="Red"></asp:Label>
                <br /><br />
                <asp:Label ID="Label6" runat="server" Text="Once an image has been selected, please click the Submit button at the bottom of the page to update the image." ForeColor="Red"></asp:Label>
                <asp:Label ID="Label7" runat="server" Text="It may take several minutes for the image to be updated. Please refresh the page after several minutes to confirm the change." ForeColor="Red"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label ID="Label2" runat="server" Text="Welcome Text: " Font-Bold="True"></asp:Label><br />
    <FTB:FreeTextBox id="FreeTextBox1" AutoGenerateToolbarsFromString="false" Width="920px" Height="250px" runat="Server" /><br />
    <asp:Label ID="Label3" runat="server" Text="Bio Text: " Font-Bold="True"></asp:Label><br />
    <FTB:FreeTextBox id="FreeTextBox2" AutoGenerateToolbarsFromString="false" Width="920px" Height="250px" runat="Server" />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
    <asp:Label ID="Label4" runat="server" Text="" Visible="False"></asp:Label>
</asp:Content>

