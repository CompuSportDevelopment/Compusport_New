<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="false"
    CodeFile="Football.aspx.cs" Inherits="About_Football" Title="CompuSport - Football" %>

<%--<%@ Register Src="~/Controls/PageUnderDevelopment.ascx" TagName="AboutMenu" TagPrefix="uc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <div class="submenu">
        <uc1:AboutMenu ID="AboutMenu1" runat="server" />
    </div>--%>
    <p class="pagetitle" style="margin-left: 90px">
        Football</p>
    <asp:Table ID="Table1" runat="server" Style="margin: 0px 90px 0px 90px">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Image ID="image11" runat="server" ImageAlign="Left" ImageUrl="~/Images/runner.bmp" />
            </asp:TableCell>
            <asp:TableCell VerticalAlign="Top">
                <p>
                   CompuSport LLC has been analyzing elite sports performances, (track, football, baseball, tennis, etc.) for over 30 years.  Using its proprietary modeling technique, it has developed the ability to identify the significant performance factors in these activities, then generate models that are built to the exact body dimensions of any athlete.</p>
                <p>
                  In football, CompuSport has applied these performance models to assist hundreds of potential NFL players prepare for their Combine performances.   In cooperation with IMG, numerous top rated collegiate have maximized their draft standings. </p>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table2" runat="server" Style="margin: 8px 90px 30px 90px">
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top">
                <p>
                   The ability to generate both two and three dimensional models, and overlay the results directly over the athlete’s video performance, has proven to be a powerful teaching tools for both coach and athlete.  Regardless of where the analysis takes place, in the classroom or on the field, this research based teaching process has moved the coaching profession into the 21st century.
                </p>
            </asp:TableCell>
            <asp:TableCell VerticalAlign="Top">
                <p>
                    <asp:Image ID="Image1" ImageAlign="AbsMiddle" runat="server" ImageUrl="~/Images/Football.bmp" />
                </p>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
