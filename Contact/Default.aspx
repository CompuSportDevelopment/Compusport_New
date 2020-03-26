<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Contact_Default" Title="CompuSport – Corporate" %>
<%@ Register Src="~/Controls/ContactMenu.ascx" TagName="ContactMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="submenu">
        <uc1:ContactMenu runat="server" />
    </div>
    <p class="pagetitle">Corporate</p>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" VerticalAlign="Top">
                    <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="true">Address: </asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                    CompuSport Inc<br />
                    10620 Southern Highlands Pkwy<br />
                    Suite 110-189<br />
                    Las Vegas NV 89141
                </asp:TableCell>
            </asp:TableRow>
           <%-- <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" VerticalAlign="Top">
                    <asp:Label ID="Label2" runat="server" Text="Label" Font-Bold="true">Phone: </asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                    702.879.8337 (702-TRY-TEES)
                </asp:TableCell>
            </asp:TableRow>--%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" VerticalAlign="Top">
                    <asp:Label ID="Label3" runat="server" Text="Label" Font-Bold="true">Email: </asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                    <asp:Label ID="Label4" runat="server" Text="CompuSport Website/Technical Support - "></asp:Label>
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="mailto:info@compusport.com?subject=Support%20Inquiry">info@compusport.co</asp:HyperLink>
                    <br />
                    <%--<asp:Label ID="Label5" runat="server" Text="CompuSport Teaching System Sales - "></asp:Label>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="mailto:sales@swingmodel.com?cc=jhidock@swingmodel.com&subject=SwingModel%20Sales%20Inquiry">sales@swingmodel.com</asp:HyperLink>--%>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
</asp:Content>

