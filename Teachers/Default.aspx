<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Teachers_Default" Title="SwingModel - Teachers Home" %>

<%@ Register Src="~/Controls/TeachersMenu.ascx" TagName="TeachersMenu" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="submenu">
        <uc1:TeachersMenu runat="server" />
    </div>
    <br />
    <p class="pagetitle">
    </p>
    <div id="AboutMeSection">
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="My Name:"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="My Home Location:"></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label><br />
    </div>
    <br />
    <br />
    <div id="CoachMembers">
        <p>
            Welcome to CompuSport. As a Coach Member of CompuSport, you now have full-time access
            to all of your athlete’s Sessions, both the On-Track as well as their identified
            Competitions.</p>
        <p>
            You will find their Sessions using the
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Teachers/SelectMember.aspx">My Athlete Video Player</asp:HyperLink>
            page, found under the Coaches tab. These Sessions contain videos of each athlete’s
            runs (sprints, starts, and/or hurdles) along with their associated performance errors.
            The video player on the Page allows you to load their entire history of Sessions.
            You can view the performance with and without their Performance Model for any one
            Session, or compare different Sessions with either Model or no Model. The Player
            allows frame-by-frame control (both forward and backward), as well as full run playback.</p>
        <p>
            If any of your Athlete’s Sessions included the collection of Starting Block Force
            Data, they can be found on the
            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Teachers/MyAthleteForceData.aspx">My Athlete Force Data</asp:HyperLink>
            page. You will find performance results including Starting Force and Power results
            (Force Data). In addition, if they have had more than one Session, you can make
            comparisons between any of these results.</p>
        <p>
            You view a list of all of your athletes using the
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Teachers/MemberList.aspx">My Athlete List</asp:HyperLink>
            page, or find additional information on them using the
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Teachers/MemberSearch.aspx">My Athlete Search</asp:HyperLink>
            page, both found under the Coaches tab.
        </p>
        <p>
            You can create, edit, or view your biography on the
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Teachers/TeacherBio.aspx">My Coach Profile</asp:HyperLink>
            page, found under the Coaches tab.
        </p>
        <p>
            To change details in your CompuSport account go to the
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Users/MyAccount.aspx">My Account</asp:HyperLink>
            page.If you need to change the Password for your account, or change your email address,
            go to the
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Users/ChangePasswordEmail.aspx">Change My Password/Email Address</asp:HyperLink>
            page.
        </p>
        <br />
        <br />
        <br />
    </div>
</asp:Content>
