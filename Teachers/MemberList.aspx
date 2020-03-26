<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true"
    CodeFile="MemberList.aspx.cs" Inherits="Teachers_MemberList" Title="CompuSport – My Athlete List" %>

<%@ Register Src="~/Controls/TeachersMenu.ascx" TagName="TeachersMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="submenu">
        <uc1:TeachersMenu ID="TeachersMenu1" runat="server" />
    </div>
    <p class="pagetitle">
        Display All My Athletes
        <%--  <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> Members :--%>
    </p>
    <div id="centeronpage" class="centeronpage">
        <p style="text-align: justify; width: 800px;">
            Listed below are all of your Athletes. Teacher Type indicates whether you are the
            Athlete’s Primary (1) or Secondary (2) coach. Secondary coaches can be either currently
            involved with the athlete (but not the main coach), or were the Athlete’s coach
            in the past (and are still granted access to their results). The Tier level of the
            athlete indicates the USATF designated performance level of the Athlete, with 1
            being highest and 5 being lowest. If the Athlete’s level is listed as zero (0),
            then the Athlete is either retired, or their results are otherwise unavailable.
        </p>
        <p style="text-align: justify; width: 800px;">
            If any of the listed Athletes are not associated with you, or you feel any of your
            Athlete’s information is incorrect, send an email to <a href="mailto:dev@compusport.com?subject=My Athlete List Issue"
                target="_blank">dev@compusport.com</a> and identify the problem.
        </p>
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
            AutoPostBack="true" Visible="False">
        </asp:DropDownList>
    </div>
    <div style="float: left; height: 16px; width: 900px;">
    </div>
    <div style="float: left; width: 924px;">
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
            </Triggers>
            <ContentTemplate>
                <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField ItemStyle-Width="50" DataField="Count" HeaderText="Count" />
                        <asp:BoundField ItemStyle-Width="100" DataField="First Name" HeaderText="First Name" />
                        <asp:BoundField ItemStyle-Width="100" DataField="Last Name" HeaderText="Last Name" />
                        <asp:BoundField ItemStyle-Width="250" DataField="Email Address" HeaderText="Email Address" />
                        <asp:BoundField ItemStyle-Width="150" DataField="Facility" HeaderText="Facility" />
                        <asp:BoundField ItemStyle-Width="170" DataField="ExpirationDate" HeaderText="Expiration Date" />
                        <asp:BoundField ItemStyle-Width="140" DataField="TeacherType" HeaderText="Teacher Type" />
                        <asp:BoundField ItemStyle-Width="50" DataField="Tier" HeaderText="Tier" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
