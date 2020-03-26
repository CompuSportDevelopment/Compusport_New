<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Facility_Default" %>

<%@ Register Src="~/Controls/FacilityMenu.ascx" TagName="FacilityMenu" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="submenu">
        <uc1:FacilityMenu runat="server" />
    </div>
    <br />
    <div id="AboutMeSection">
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="My Name:"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="My Home Location:"></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label><br />
    </div>
    <br />
    <br />
    <div id="FacilityMembers">
        <p>
            Welcome to CompuSport. As a Facility Member of CompuSport, you now have full-time
            access to all of your athlete’s Sessions, both the On-Track as well as their identified
            Competitions. Also, as a Facility Member, you also have access to all athletes that
            are associated with your Facility.</p>
        <p>
            You will find your Athlete’s Sessions using the
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Teachers/SelectMember.aspx">My Athlete Video Player</asp:HyperLink>
            page, found under the Coaches (your athletes) or Facility (all Facility athletes)
            tab.In addition, you can find all of your Facility athletes using the
            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Facility/SelectMember.aspx">Facility Athlete Video Player</asp:HyperLink>
            page,found under the Facility tab. These Sessions contain videos of each athlete’s
            runs (sprints, starts, and/or hurdles) along with their associated performance errors.
            The video player on the Page allows you to load their entire history of Sessions.
            You can view the performance with and without their Performance Model for any one
            Session, or compare different Sessions with either Model or no Model. The Player
            allows frame-by-frame control (both forward and backward), as well as full run playback.</p>
        <p>
            If any of your Athlete’s Sessions included the collection of Starting Block Force
            Data, they can be found on the
            <asp:HyperLink ID="hlTeachForceData" runat="server" NavigateUrl="~/Teachers/MyAthleteForceData.aspx">My Athlete Force Data</asp:HyperLink>
            page under the Coaches tab. In addition, if any of your Facility Athlete’s Sessions
            included the collection of data, they can be found on the
            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Facility/SelectMemberForForceData.aspx">Facility Athlete Force Data</asp:HyperLink>
            page under the Facility tab. You will find performance results including Starting
            Force and Power results (Force Data). In addition, if they have had more than one
            Session, you can make comparisons between any of these results.
        </p>
        <p>
            You view a list of your athletes using the
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Teachers/MemberList.aspx">My Athlete List</asp:HyperLink>
            page, or find additional information on them using the
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Teachers/MemberSearch.aspx">My Athlete Search</asp:HyperLink>
            page, both found under the Coaches tab. Likewise, you can view a list of all Facility
            athletes using the
            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Facility/MemberList.aspx">Facility Athlete List</asp:HyperLink>
            page, or find additional information on them using the
            <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Facility/MemberSearch.aspx">Facility Athlete Search</asp:HyperLink>
            page, both found under the Facility tab.
        </p>
        <p>
            You can create, edit, or view your biography on the
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Teachers/TeacherBio.aspx">Coach Profile</asp:HyperLink>
            , found under the Coaches tab. You can also create, edit, or view the biography
            of all coaches associated with your Facility on the
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Facility/TeacherBio.aspx">Coach Profile</asp:HyperLink>
            page, found under the Facility tab.
        </p>
        <p>
            To change details in your CompuSport account go to the
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Users/MyAccount.aspx">My Account</asp:HyperLink>
            page. If you need to change the Password for your account, or change your email
            address, go to the
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Users/ChangePasswordEmail.aspx">Change My Password/Email Address</asp:HyperLink>
            page.
        </p>
        <br />
        <br />
        <br />
    </div>
</asp:Content>
