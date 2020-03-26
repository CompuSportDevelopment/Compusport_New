<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="System.aspx.cs" Inherits="About_System" Title="SwingModel - The Teaching and Fitting System" %>
<%@ Register Src="~/Controls/AboutMenu.ascx" TagName="AboutMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="submenu">
        <uc1:AboutMenu ID="AboutMenu1" runat="server" />
    </div>
    <p class="pagetitle">The Teaching System</p>
    <p>
        The new SwingModel Teaching System is designed to allow your teacher to develop your golf
        swing to its greatest potential.  The Teaching portion of the System is based around the
        concept of building a personalized SwingModel for a student, then using your instructor’s
        teaching skills to move your swing toward that of your Model.</p>
    <p>
        The teaching session begins with input about your golf profile and body dimensions.</p>
    <div class="centerimage">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Fit6.jpg" />
    </div>
    <p>
        This is followed by the selection of the club that you will be using during the teaching
        session (any of the Woods, Irons, and Hybrids are available). In addition, the swing speed of
        your Model can be set anywhere from 50 to 100 percent of the Tour inspired Model.</p>
    <div class="centerimage">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Fit7.jpg" />
    </div>
    <p>
        Once this has been completed, your Model is built and displayed on two side-by-side video
        windows. You then begin the lesson by taking a swing, the first step toward game improvement.
        Since your Model is overlaid directly on top of your swing, the quality of your swing
        performance can easily be seen.</p>
    <div class="centerimage">
        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Fit8.jpg" />
    </div>
    <p>
        Your teacher can then jog you and your Model through the entire swing, identifying the
        strengths and weaknesses in your performance. To mark your errors at each of the ten
        SwingModel Teaching Positions, your teacher can select the problems from a list of swing
        problems.</p>
    <div class="centerimage">
        <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Fit10.jpg" />
    </div>
    <p>
        Once your entire swing has been reviewed, your improvement process can begin. Using your
        SwingModel as the standard, and a variety of other tools, your teacher can move you toward a
        better swing.</p>
    <p>
        In addition to these interactive teaching tools, your teacher has the following additional
        modes to enhance your learning process:
        <asp:BulletedList ID="BulletedList1" runat="server">
            <asp:ListItem>
                Practice Mode:  This allows you to practice with your Model, independently. Upon ball
                contact, your swing is replayed a selected number of times, at a selected speed –
                slowing down when the selected Model position is reached. Once display is complete,
                recording begins again. This has proved to be a great self practice tool for students.
                You simply select the Model position that you want to work on, then make a swing.The
                program will automatically stop the recording and replay your swing, slowing down
                when your selected position is reached.  You can do this over and over, each time
                checking your improvement.
            </asp:ListItem>
            <asp:ListItem>
                Summary Mode: This provides your teacher with the ability to record a video summary,
                with voice over, of your lesson. This video is sent to the SwingModel Internet site
                and attached to your individual lesson record.
            </asp:ListItem>
            <asp:ListItem>
                Drill Mode: This allows your teacher the ability to record their own drills, and send
                them to the SwingModel Internet site. Then when you have a swing error addressed by
                these drills, you can view them by simply clicking on the error displayed in your
                Internet swing lesson summary.
            </asp:ListItem>
        </asp:BulletedList>
        </p>
    <p>
        At the end of the session, the critical lesson information is uploaded to your Membership
        area on the SwingModel website.</p>
    <%--
    <p>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#">Click here</asp:HyperLink> for a video example of this evaluation process.</p>
    --%>
    <p class="pagetitle" style="width: 100%;">
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/About/Research.aspx">Continue Tour</asp:HyperLink>
        or
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/About/Default.aspx">Return to Golfer Tour Home</asp:HyperLink></p>
</asp:Content>
