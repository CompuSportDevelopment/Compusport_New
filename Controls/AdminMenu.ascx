<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminMenu.ascx.cs" Inherits="Controls_AdminMenu" %>
<%--
<asp:HyperLink ID="HyperLink12" runat="server" Text="My Performance Model" NavigateUrl="~/Admin/Default.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">My Performance Model</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink13" runat="server" Text="My Account" NavigateUrl="~/Users/MyAccount.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">My Account</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink14" runat="server" Text="Change My Password/My Email Address" NavigateUrl="~/Users/ChangePasswordEmail.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Change My Password/My Email Address</asp:HyperLink>

--%>
<asp:HyperLink ID="HyperLink1" runat="server" Text="All Member Search" NavigateUrl="~/Admin/MemberSearch.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">All Member Search</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink2" runat="server" Text="All Athlete Video Player" NavigateUrl="~/Admin/SelectMember.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">All Athlete Video Player</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink19" runat="server" Text="All Athlete Force Data" NavigateUrl="~/Admin/SelectMemberForForceData.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">All Athlete Force Data</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink29" runat="server" Text="Coach Athlete Relay Data" NavigateUrl="~/Admin/CoachAthleteRelayData.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Coach Athlete Relay Data</asp:HyperLink>
|

<asp:HyperLink ID="HyperLink27" runat="server" Text="All Athlete Relay Data" NavigateUrl="~/Admin/AllAthleteRelayData.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">All Athlete Relay Data</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink9" runat="server" Text="All Athlete List" NavigateUrl="~/Admin/MemberList.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">All Athlete List</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink3" runat="server" Text="All Coach Profiles" NavigateUrl="~/Admin/TeacherBio.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">All Coach Profiles</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink10" runat="server" Text="Facility Teach Version" NavigateUrl="~/Admin/AddTeachers.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Create Edit Coaches</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink4" runat="server" Text="Facility Billing Details" NavigateUrl="~/Admin/MakeNewMember.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Make New Member</asp:HyperLink>
|

<asp:HyperLink ID="HyperLink11" runat="server" Text="Coaches List" NavigateUrl="~/Admin/RenewMember.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Renew Members</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink5" runat="server" Text="Member Search" NavigateUrl="~/Admin/TeacherList.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Coaches List</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink6" runat="server" Text="Member Name Video Player" NavigateUrl="~/Admin/MembershipExpiration.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Alter Expiration Date</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink7" runat="server" Text="Member Date Video Player" NavigateUrl="~/Admin/ResetMemberPassword.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Reset Member Password</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink8" runat="server" Text="My Member List" NavigateUrl="~/Admin/DeleteUser.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Delete Members</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink12" runat="server" Text="My Member List" NavigateUrl="~/Admin/AssignAthlete.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Assign Athlete</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink13" runat="server" Text="My Member List" NavigateUrl="~/Admin/InputSprintData.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Input Sprint Data</asp:HyperLink>
<%--<asp:HyperLink ID="HyperLink24" runat="server" Text="My Member List" NavigateUrl="~/Admin/InputHurdleStepData.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Input Hurdle Step Data</asp:HyperLink>--%>
|
<asp:HyperLink ID="HyperLink14" runat="server" Text="My Member List" NavigateUrl="~/Admin/InputStartData.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Input Start Data</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink15" runat="server" Text="My Member List" NavigateUrl="~/Admin/InputHurdleData.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Input Hurdle Data</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink26" runat="server" Text="Input Relay Data" NavigateUrl="~/Admin/Input Relay Data.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Input Relay Data</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink24" runat="server" Text="My Member List" NavigateUrl="~/Admin/InputHurdleStepData.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Input Hurdle Step Data</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink16" runat="server" Text="Input Athlete Profile Data" NavigateUrl="~/Admin/My Profile.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Input Athlete Profile Data</asp:HyperLink>
|
<%--<asp:HyperLink ID="HyperLink17" runat="server" Text="Input Athlete Dimensions Data" NavigateUrl="~/Admin/AthletesDimesions.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Input Athlete Dimensions Data</asp:HyperLink>--%>
|
<asp:HyperLink ID="HyperLink18" runat="server" Text="Input Athlete Account Data" NavigateUrl="~/Admin/AthletesAccount.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Input Athlete Account Data</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink20" runat="server" Text="Alter Sprint Session ID" NavigateUrl="~/Admin/LessonData.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Alter Sprint Session ID</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink25" runat="server" Text="Alter HurdleStep Session ID" NavigateUrl="~/Admin/AlterHurdleStepSessionID.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Alter Hurdle Step Session ID</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink21" runat="server" Text="Alter Start Session ID" NavigateUrl="~/Admin/AlterStartSessionID.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Alter Start Session ID</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink22" runat="server" Text="Alter Hurdle Session ID" NavigateUrl="~/Admin/AlterHurdleSessionID.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Alter Hurdle Session ID</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink23" runat="server" Text="Block Force Input Page" NavigateUrl="~/Admin/BlockForceInput.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Block Force Input Page</asp:HyperLink>
|

<asp:HyperLink ID="HyperLink28" runat="server" Text="Create/Edit Locations" NavigateUrl="~/Admin/AlterLocation.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Create/Edit Locations</asp:HyperLink>