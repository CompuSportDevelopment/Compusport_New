<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="Research.aspx.cs" Inherits="TeacherInfo_Research" Title="SwingModel - SwingModel Equipment Research Effort" %>
<%@ Register Src="~/Controls/TeacherInfoMenu.ascx" TagName="TeacherInfoMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="submenu">
        <uc1:TeacherInfoMenu ID="TeacherInfoMenu1" runat="server" />
    </div>
    <p class="pagetitle">SwingModel Equipment Research Effort</p>
    <p>
        <asp:Image ID="Image1" runat="server" ImageAlign="Left" ImageUrl="~/Images/research1.jpg" />
        In golf, the performance of the equipment used to strike the ball is dependent on the
        three components involved; the clubhead, the shaft, and the ball.  Given the number of
        available heads, shafts, and balls on the market, there are well over one million
        combinations for the Driver alone.  With this in mind, what are the odds that any golfer
        can find the equipment combination that will best fit their game.</p>
    <p>
        With the quality of information that is currently available on equipment, the number of
        fitting options, and the typical fitting process, the answer is “pretty slim”.</p>
    <p style="font-weight: bold;">
        Information</p>
    <p>
        In 2006, Dr. Ralph Mann began the research effort to attempt to understand the
        performance characteristics of golf equipment.  The effort was divided into two major
        areas; mechanical testing and human testing.</p>
    <p style="font-weight: bold;">
        Mechanical Testing</p>
    <p>
        To be successful, the research effort had to be able to determine the individual
        contributions of each of the three components (clubhead, shaft, and ball).  In addition,
        the human factor needed to be included in the testing if it was a major contributor.
        These requirements quickly eliminated one major testing method, as well as one of the
        three components from this process.</p>
    <p>
        <asp:Image ID="Image2" runat="server" ImageAlign="Right" ImageUrl="~/Images/IronByron.jpg" />
        Although the mechanical swing machines like Iron Byron are used by some to evaluate
        equipment, those most familiar with their operation recognize their limitations.  To a
        scientist, the fact that it uses all three equipment components at once, is difficult to
        reproduce results day after day, and has infinite swing settings makes it an unreliable
        research tool.  Perhaps more important is the fact that the swing machines grip the club
        with an inhuman metal grip, and swigs the club on a path no human follows, further
        disqualifies their use.</p>
    <p>
        The one equipment component that does not lend itself to mechanical testing is the golf
        shaft.  The golf clubhead and ball do not care how the golf swing occurs; they only
        respond to the impact conditions when the head and the ball collide.  The shaft, however,
        will perform differently due to differences in the swing path.  Thus, if two golfers
        produce the same clubhead speed at impact using the same shaft, the shaft will respond
        differently if their swing paths are different.</p>
    <p>
        <asp:Image ID="Image3" runat="server" ImageAlign="Left" ImageUrl="~/Images/research2.jpg" />
        Due to these conclusions, the mechanical testing was confined to cubheads and balls.
        Moreover, the mechanical testing was performed using a ball cannon.  This device fires
        golf balls at a stationary clubhead, eliminating the problems inherent in the mechanical
        swing machines.</p>
    <p>
        Using a rigid research process, SwingModel in conjunction with 
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.ustgolfshaft.com" Target="_blank">UST</asp:HyperLink>,
        has used the ball cannon to identify the performance characteristics of the top balls and
        clubheads in golf.</p>
    <p>
        With this information, the last component, that of the golf shaft, was the only factor
        left to determine.  For this, human testing was the only viable avenue.</p>
    <p style="font-weight: bold;">
        Human Testing</p>
    <p>
        <asp:Image ID="Image4" runat="server" ImageAlign="Left" ImageUrl="~/Images/BaylorSetup.jpg" />
        The golf shaft is the wildcard in the equipment fitting process.  Of the three components,
        it has the greatest complexity.  From weight, to torque, to flex, to length; the shaft
        can be the greatest contributor to a successful equipment fit.  These same factors,
        however, makes the shaft the most difficult to research.</p>
    <p>
        Because the golfer, and how they swing, directly affects how the shaft behaves, all
        research was done using human subjects.  Working closely with 
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://baylorhealth.com" Target="_blank">Baylor Medical Center</asp:HyperLink>,
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="http://www.ustgolfshaft.com" Target="_blank">UST</asp:HyperLink>,
        and 
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="http://www.tptgolf.com" Target="_blank">TPT Golf</asp:HyperLink>,
        the four groups brought together the resources needed to measure the complex interaction
        between the golf swing and how it affects the golf shaft.</p>
    <p>
        Whereas the mechanical testing was straight forward, the complexity of the human testing
        was a much more difficult process.  However, with a cooperative effort, the effects of
        golf shafts to swing performance was identified.</p>
    <br />
    <p style="font-weight: bold;">
        Application</p>
    <p>
        With the individual characteristics of balls, clubheads, and shafts determined, the
        process of using this information to fit equipment was the next goal.  In recent
        collaboration with
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="http://www.tptgolf.com" Target="_blank">TPT Golf</asp:HyperLink>,
        SwingModel has integrated this equipment research into the first true
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/About/System.aspx">component based golf equipment fitting system</asp:HyperLink>.
        Applying the fitting techniques developed by Bill Choung of TPT Golf has produced a
        fitting process that will provide golfers with the ability to select the best components
        for their individual swing.</p>
    <p class="pagetitle" style="width: 100%;">
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/TeacherInfo/EquipmentFitting.aspx">Continue Tour</asp:HyperLink>
        or
        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/TeacherInfo/Default.aspx">Return to Teacher Tour Home</asp:HyperLink></p>
</asp:Content>
