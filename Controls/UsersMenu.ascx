<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UsersMenu.ascx.cs" Inherits="Controls_UsersMenu" %>

<asp:HyperLink ID="HyperLink1" runat="server" Text="My Information Page" NavigateUrl="~/Users/Default.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">My Information Page</asp:HyperLink>
|
<%--
<asp:HyperLink ID="HyperLink2" runat="server" Text="My Summary" NavigateUrl="~/Users/MySummary.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">My Summary</asp:HyperLink>
|
--%>
<asp:HyperLink ID="HyperLink10" runat="server" Text="My Performance" NavigateUrl="~/Users/MySwing.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">My Performance</asp:HyperLink>
|
<%--
<asp:HyperLink ID="HyperLink3" runat="server" Text="My Drills" NavigateUrl="~/Users/MyDrills.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">My Drills</asp:HyperLink>
|
--%>
<asp:HyperLink ID="HyperLink12" runat="server" Text="My Swing Errors" NavigateUrl="~/Users/SwingErrors.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True" Visible="False">My Swing Errors</asp:HyperLink>
<asp:Label ID="Label1" runat="server" Text="|" Visible="false"></asp:Label>
<asp:HyperLink ID="HyperLink2" runat="server" Text="My Angular and Force Data" NavigateUrl="~/Users/MyTeachData.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">My Force Data</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink8" runat="server" Text="Email My Primary Coach" NavigateUrl="~/Users/EmailTeacher.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Email My Primary Coach</asp:HyperLink>
<%--|
<asp:HyperLink ID="HyperLink9" runat="server" Text="Schedule A Lesson" NavigateUrl="~/Users/ScheduleLesson.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Schedule A Lesson</asp:HyperLink>--%>
<br />
<asp:HyperLink ID="HyperLink4" runat="server" Text="My Teacher" NavigateUrl="~/Users/MyTeacher.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">My Primary Coach</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink5" runat="server" Text="My Account" NavigateUrl="~/Users/MyAccount.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">My Account</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink6" runat="server" Text="My Dimensions" NavigateUrl="~/Users/MyDimensions.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">My Dimensions</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink7" runat="server" Text="My Golf" NavigateUrl="~/Users/MyGolf.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">My Profile</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink11" runat="server" Text="Change My Password/My Email" NavigateUrl="~/Users/ChangePasswordEmail.aspx" Font-Underline="False" CssClass="submenu" ForeColor="#053654" Font-Bold="True">Change My Password/My Email Address</asp:HyperLink>
