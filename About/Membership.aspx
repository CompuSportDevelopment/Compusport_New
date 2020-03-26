<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="Membership.aspx.cs" Inherits="About_Membership" Title="CompuSport - CompuSport Website Membership" %>
<%@ Register Src="~/Controls/AboutMenu.ascx" TagName="AboutMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="submenu">
        <uc1:AboutMenu ID="AboutMenu1" runat="server" />
    </div>
    <p class="pagetitle">CompuSport Website Membership</p>
    <p>
        When you experience a lesson or fitting with the Teaching and Fitting System, you become a
        Member of the SwingModel Website. This site serves as a repository of all of your lesson
        information, as well as a connection to your teacher.</p>
    <p>
        Each student has a secure site, with the SwingModel Homepage serving as a portal to your
        program information. From this page, you have access to:</p>
    <p>
        <asp:BulletedList ID="BulletedList1" runat="server" BulletStyle="Numbered">
            <asp:ListItem>SwingModel Locations and Teachers</asp:ListItem>
            <asp:ListItem>SwingModel Information</asp:ListItem>
            <asp:ListItem>Contact Information</asp:ListItem>
            <asp:ListItem>Your Personal Learning Program</asp:ListItem>
        </asp:BulletedList></p>
    <p>
        Your learning program, termed My SwingModel, is a robust summary of all of your
        lessons, as well as methods to insure continued improvement.</p>
    <p>
        Your Program is divided into the following areas:</p>
    <p style="font-weight: bold">
        My SwingModel Overview</p>
    <p>
        This is the Home Page of your Learning Program. This page provides information regarding new
        and current lesson information, fitting information, and website specials.</p>
    <div class="centerimage">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Membership1.jpg" />
    </div>
    <p style="font-weight: bold">
        My Swing</p>
    <p>
        The My Swing page contains the Video Player that displays the information for all of your
        current and past lessons.  The major features include:</p>
    <asp:BulletedList ID="BulletedList2" runat="server">
        <asp:ListItem>
            Full screen, side-by-side videos of all of your lessons:  All videos include your
            Swing Model, superimposed on your swing.  You can control the video, playing the
            entire swing, jumping to Teaching Positions, or stepping frame-by-frame.
        </asp:ListItem>
        <asp:ListItem>
            Club selection:  Your lessons with Woods, Irons, and Hybrids are separated for display.
        </asp:ListItem>
        <asp:ListItem>
            Lesson comparison: You can compare the swings from any lesson to those of any other lesson.  For
            example, you can compare the first swing of your first lesson to your current lesson to see your
            improvement over time.
        </asp:ListItem>
        <asp:ListItem>
            Swing errors: The errors selected by your teacher during the selected lesson are displayed at each
            Teaching Position.
        </asp:ListItem>
        <asp:ListItem>
            Error videos:  If your teacher has recorded a drill video for your swing errors, you can click on
            your error to view the video.
        </asp:ListItem>
        <asp:ListItem>
            Lesson Summary: Apart from your SwingModel video, your teacher can record an individualized lesson
            summary (audio and video).  This can be viewed for the lesson that is being displayed.
        </asp:ListItem>
    </asp:BulletedList>
    <div class="centerimage">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Membership2.jpg" />
    </div>
    <p style="font-weight: bold">
        My Teacher</p>
    <p>
        This page provides you information about your SwingModel Teacher.</p>
    <p style="font-weight: bold">
        My Account/My Golf/My Dimensions</p>
    <p>
        These pages contain your contact information, as well as the data required to build your
        swing Model and provide the required fitting information.</p>
    <p style="font-weight: bold">
        Email My Teacher/Schedule a Lesson</p>
    <p>
        These pages allow you to contact your teacher for information, or to schedule your next
        lesson.</p>
    <p class="pagetitle">
        Join SwingModel: If you would like to become a Member of our golf community,
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MakeMember.aspx">click here</asp:HyperLink>
        to join.</p>
    <%--
    <p style="font-weight: bold">
        Website Demo</p>
    <p>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#">Click here</asp:HyperLink> for a video summary of the SwingModel website.</p>
    --%>
    <p class="pagetitle" style="width: 100%;">
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/About/Default.aspx">Return to Golfer Tour Home</asp:HyperLink></p>
</asp:Content>
