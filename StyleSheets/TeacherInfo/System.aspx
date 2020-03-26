<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="System.aspx.cs" Inherits="TeacherInfo_System" Title="SwingModel - The Teaching and Fitting System" %>
<%@ Register Src="~/Controls/TeacherInfoMenu.ascx" TagName="TeacherInfoMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="submenu">
        <uc1:TeacherInfoMenu ID="TeacherInfoMenu1" runat="server" />
    </div>
    <p class="pagetitle">The Teaching System</p>
    <p>
        The new SwingModel Teaching System is designed to allow you, as a teacher to develop your
        students to their greatest potential. The Teaching portion of the System is based around the
        concept of building a personalized SwingModel for your student, then allowing you to use your
        teaching skills to move the student toward their Model.</p>
    <p>
        The teaching session begins with input about the student’s golf profile and body dimensions.</p>
    <div class="centerimage">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Fit6.jpg" />
    </div>
    <p>
        This is followed by the selection of the club that your student will be using during the
        teaching session (any of the Woods, Irons, and Hybrids are available). In addition, the swing
        speed of the student’s Model can be set anywhere from 50 to 100 percent of the Tour inspired
        Model.</p>
    <div class="centerimage">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Fit7.jpg" />
    </div>
    <p>
        Once this has been completed, the student’s Model is built and displayed on two side-by-side
        video windows. The student then takes a swing, and the lesson begins. Since the Model is
        overlaid directly on top of the student’s swing, the quality of the performance can easily be
        seen.</p>
    <div class="centerimage">
        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Fit8.jpg" />
    </div>
    <p>
        You can then jog the student and their Model through the entire swing, identifying the
        strengths and weaknesses in the performance. To mark the errors at each of the ten SwingModel
        Teaching Positions, you can select the problems from a list of swing problems.</p>
    <div class="centerimage">
        <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Fit10.jpg" />
    </div>
    <p>
        Once the entire swing has been reviewed, the teaching process can begin. Using the student’s
        SwingModel as the standard, and a variety of other tools, you can move the student toward a
        better swing.</p>
    <p>
        In addition to these interactive teaching tools, you have the following additional modes to
        enhance the learning process:
        <asp:BulletedList ID="BulletedList1" runat="server">
            <asp:ListItem>
                Practice Mode: This allows a student to practice with their Model, independently.
                Upon ball contact, the swing is replayed a selected number of times, at a selected
                speed – slowing down when the selected Model position is reached. Once display is
                complete, recording begins again. This has proved to be a great self practice tool
                for students.
            </asp:ListItem>
            <asp:ListItem>
                Summary Mode: This provides you with the ability to record a video summary, with
                voice over, of the lesson. This video is sent to the SwingModel Internet site and
                attached to the student’s lesson record. This is a great way to personalize the
                student’s lesson to the individual teacher.
            </asp:ListItem>
            <asp:ListItem>
                Drill Mode: This allows you to record your own drills, and send them to the SwingModel
                Internet site. Then when your student has a swing error addressed by these drills,
                the student can view them by simply clicking on the error displayed in their Internet
                swing lesson summary. This is another way to personalize the student’s lesson to the
                individual teacher.
            </asp:ListItem>
        </asp:BulletedList>
        </p>
    <p>
        At the end of the session, the critical lesson information is uploaded to the student’s
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/About/Membership.aspx">Membership</asp:HyperLink>
        area on the SwingModel website.</p>
    <%--
    <p>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#">Click here</asp:HyperLink> for a video example of this evaluation process.</p>
    --%>
    <p class="pagetitle" style="width: 100%;">
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TeacherInfo/Research.aspx">Continue Tour</asp:HyperLink>
        or
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/TeacherInfo/Default.aspx">Return to Teacher Tour Home</asp:HyperLink></p>
</asp:Content>
