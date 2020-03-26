<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="Membership.aspx.cs" Inherits="TeacherInfo_Membership" Title="SwingModel - SwingModel Website Membership" %>
<%@ Register Src="~/Controls/TeacherInfoMenu.ascx" TagName="TeacherInfoMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="submenu">
        <uc1:TeacherInfoMenu ID="TeacherInfoMenu1" runat="server" />
    </div>
    <p class="pagetitle">SwingModel Website Membership</p>
    <p>
        When your student experiences a lesson with the Teaching and Fitting System, they become a
        Member of the SwingModel Website. This site serves as a repository of the student’s lesson
        information, as well as a connection to you as their teacher.</p>
    <p>
        Each student has a secure site, with the SwingModel Homepage serving as a portal to their
        program information. From this page, the student has access to:</p>
    <p>
        <asp:BulletedList ID="BulletedList1" runat="server" BulletStyle="Numbered">
            <asp:ListItem>SwingModel Locations and Teachers</asp:ListItem>
            <asp:ListItem>SwingModel Information</asp:ListItem>
            <asp:ListItem>Contact Information</asp:ListItem>
            <asp:ListItem>Their Personal Learning Program</asp:ListItem>
        </asp:BulletedList>
    <p>
        The student’s learning program, termed My SwingModel, is a robust summary of all of the
        student’s lessons, as well as methods to insure continued improvement.</p>
    <p>
        The Program is divided into the following areas:</p>
    <p style="font-weight: bold">
        My SwingModel Overview</p>
    <p>
        The Home Page of the student’s Learning Program. This page provides information 
        regarding new and current lesson information, fitting information, and website 
        specials.</p>
    <div class="centerimage">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Membership1.jpg" />
    </div>
    <p style="font-weight: bold">
        My Swing</p>
    <p>
        The My Swing page contains the Video Player that displays the information for all of your
        student’s current and past lessons.  The major features include:</p>
    <asp:BulletedList ID="BulletedList2" runat="server">
        <asp:ListItem>
            Full screen, side-by-side videos of all of your student’s lessons:  All videos include
            their Swing Model, superimposed on their own swing.  They can control the video, playing
            the entire swing, jumping to Teaching Positions, or stepping frame-by-frame.
        </asp:ListItem>
        <asp:ListItem>
            Club selection:  Your student’s lessons with Woods, Irons, and Hybrids are separated for
            display.
        </asp:ListItem>
        <asp:ListItem>
            Lesson comparison: Your student’s can compare the swings from any of their lessons to
            those of any other.  For example, they can compare the first swing of their first lesson
            to their current lesson to see the overall improvement over time.
        </asp:ListItem>
        <asp:ListItem>
            Swing errors: The errors selected by you during the selected lesson are displayed at each
            Teaching Position.
        </asp:ListItem>
        <asp:ListItem>
            Error videos:  If your have recorded a drill video for your student’s swing errors, they
            can click on the error to view the video.
        </asp:ListItem>
        <asp:ListItem>
            Lesson Summary: Apart from their SwingModel video, you can record an individualized
            lesson summary (audio and video).  This can be viewed for the lesson that is being
            displayed.
        </asp:ListItem>
    </asp:BulletedList>
    <div class="centerimage">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Membership2.jpg" />
    </div>
    <p style="font-weight: bold">
        My Teacher</p>
    <p>
        This page provides you information about you (your student’s teacher).</p>
    <p style="font-weight: bold">
        My Account/My Golf/My Dimensions</p>
    <p>
        These pages contain your contact information, as well as the data required to build your
        student’s swing Model and provide the required fitting information.</p>
    <p style="font-weight: bold">
        Email My Teacher/Schedule a Lesson</p>
    <p>
        These pages allow your student to contact you for information, or to schedule their next
        lesson.</p>
    <p class="pagetitle">
        If you would like more information about becoming a SwingModel Teacher,
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="mailto:rmann@swingmodel.com?subject=Teacher%20Info%20Inquiry">click here</asp:HyperLink>
        to have a SwingModel representative contact you.</p>
    <%--
    <p style="font-weight: bold">
        Website Demo</p>
    <p>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#">Click here</asp:HyperLink> for a video summary of the SwingModel website.</p>
    --%>
    <p class="pagetitle" style="width: 100%;">
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/TeacherInfo/Default.aspx">Return to Teacher Tour Home</asp:HyperLink></p>
</asp:Content>
