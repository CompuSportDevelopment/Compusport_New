<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master"
    AutoEventWireup="true" CodeFile="CoachProfile.aspx.cs" Inherits="Contact_CoachProfile" %>

<%--<%@ Register Src="~/Controls/TeachersMenu.ascx" TagName="TeachersMenu" TagPrefix="uc1" %>--%>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <a href="javascript:history.go(-1)">Back To Location</a>
    </div>
    <%--<div class="submenu">
        <uc1:TeachersMenu ID="TeachersMenu1" runat="server" />
    </div>--%>
    <p class="pagetitle">
        Input My Coach Profile Information</p>
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell Width="170" Height="200">
                <asp:Image ID="Image1" runat="server" Width="150" Height="180" />
            </asp:TableCell>
            <asp:TableCell Width="730" Height="200" VerticalAlign="Middle">
                <asp:Label ID="lblImgUpload" runat="server" Text="Upload Image: " Font-Bold="True"></asp:Label><br />
                <asp:FileUpload ID="FileUpload1" runat="server" Width="450px" Visible="false" /><br />
                <asp:Label ID="lblImgTxt1" runat="server" Text="The image is not required. Please insure that the image is 150 pixels wide by 180 pixels tall. JPG or PNG accepted."
                    ForeColor="Red"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblImgTxt2" runat="server" Text="Once an image has been selected, please click the Submit button at the bottom of the page to update the image."
                    ForeColor="Red"></asp:Label>
                <asp:Label ID="lblImgTxt3" runat="server" Text="It may take several minutes for the image to be updated. Please refresh the page after several minutes to confirm the change."
                    ForeColor="Red"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label ID="Label2" runat="server" Text="Welcome Text: " Font-Bold="True"></asp:Label><br />
    <FTB:FreeTextBox ID="FreeTextBox1" AutoGenerateToolbarsFromString="false" Width="920px"
        Height="250px" runat="Server" />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Bio Text: " Font-Bold="True"></asp:Label><br />
    <FTB:FreeTextBox ID="FreeTextBox2" AutoGenerateToolbarsFromString="false" Width="920px"
        Height="250px" runat="Server" />
    <br />
    <asp:Button ID="Button1" runat="server" Visible="false" Text="Submit" OnClick="Button1_Click" />
    <asp:Label ID="Label4" runat="server" Text="" Visible="False"></asp:Label>
</asp:Content>
