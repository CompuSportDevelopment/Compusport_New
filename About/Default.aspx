<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="About_Default" Title="CompuSport – Track and Field" %>

<%--<%@ Register Src="~/Controls/AboutMenu.ascx" TagName="AboutMenu" TagPrefix="uc1" %>--%>
<%--<%@ Register Src="~/Controls/PageUnderDevelopment.ascx" TagName="AboutMenu" TagPrefix="uc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="submenu">
        <%-- <uc1:AboutMenu ID="TeacherInfoMenu1" runat="server" />--%>
    </div>
    <p class="pagetitle" style="margin-left: 90px">
        Track and Field</p>
    <asp:table runat="server" style="margin: 0px 90px 0px 90px">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Image ID="image11" runat="server" ImageAlign="Left" ImageUrl="~/Images/runner.bmp" />
           </asp:TableCell>
            <asp:TableCell VerticalAlign="Top">
                <p>
                    CompuSport LLC has been analyzing elite sprint and hurdle performances for over
                    30 years. Using its proprietary modeling technique, it has developed the ability
                    to identify the significant performance factors in these activities, then generate
                    models that are built to the exact body dimensions of any athlete.</p>
                <p>
                    CompuSport has applied these sprint and hurdle models to hundreds of elite track
                    and field athletes from the United States, Great Britain, and the Netherlands as
                    consultants to each of these country’s National Governing Bodies.</p>
            </asp:TableCell>
        </asp:TableRow>
    </asp:table>
    <asp:table runat="server" style="margin: 8px 90px 30px 90px">
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top">
                <p>
                    The ability to generate both two and three dimensional models, and overlay the results
                    directly over the athlete’s video performance, has proven to be a powerful teaching
                    tools for both coach and athlete. Regardless of where the analysis takes place,
                    in the classroom or on the track, this research based teaching process has moved
                    the coaching profession into the 21st century.
                </p>
            </asp:TableCell>
            <asp:TableCell VerticalAlign="Top">
                <p>
                    <asp:Image ImageAlign="AbsMiddle" runat="server" ImageUrl="~/Images/AboutUsRunner.bmp" />
                </p>
            </asp:TableCell>
        </asp:TableRow>
    </asp:table>
    <%-- Below div is Removed for temporarily--%>
    <%-- <div style="margin: 0px 0px 0px 0px; display: block; padding: 2px 0px 10px 0px; width: 930px; height: 620px; float: left;">
        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,16,0"
            width="930" height="610" id="WMP1">
            <param name="movie" value="http://www.swingmodel.com/Images/GolferTour.swf">
            <param name="quality" value="high">
            <param name="play" value="true">
            <param name="loop" value="false">
            <param name="wmode" value="transparent">
            <embed id="WMP1" src="http://www.swingmodel.com/Images/GolferTour.swf" width="930" height="610" play="true" loop="false"
                quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"
                wmode="transparent"></embed>
        </object>
    </div>--%>
    <%--
    <p>
        <span style="font-family: Magneto; font-size: x-large;">Our Purpose: </span>
        SwingModel was created to provide golf teachers and equipment fitters with the best science
        based technology to allow the greatest potential performance improvement in their students.
        The links below will allow you to fully understand how SwingModel can help you become the
        best golfer instructor and/or fitter.</p>
    <p>
        <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/TeacherInfo/Science.aspx">Begin the Teacher Tour</asp:HyperLink>
        or select links below.</p>
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/BaylorSetupThumb.png" PostBackUrl="~/TeacherInfo/Science.aspx" CssClass="imgbtn" />
            </asp:TableCell>
            <asp:TableCell>
                <p>
                    <span style="font-family: Magneto; font-size: x-large;">Science Based: </span>
                    SwingModel is dedicated to providing your students with a learning process that
                    is based on scientific research. It may not conform to the latest fad, but it
                    provides teachers with what truly works in golf performance.
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TeacherInfo/Science.aspx">Click 
                    here</asp:HyperLink>
                    to learn more about SwingModel&#39;s science based technology.</p>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table2" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <p>
                    <span style="font-family: Magneto; font-size: x-large;">The “Model”: </span>
                    In 1976, Dr. Ralph Mann completed his studies for his Ph.D. in Biomechanics by
                    submitting his dissertation titled “A Comprehensive Computer Technique to Process
                    Human Motion Data”. Using a common jumping action, the technique was designed to
                    maximize the motion by estimating the potential maximum human effort possible,
                    then predicting the simulated result.
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TeacherInfo/Process.aspx">Click 
                    here</asp:HyperLink>
                    to learn more about the modeling techniques.</p>
            </asp:TableCell>
            <asp:TableCell>
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/CarlLewisStickThumb.png" PostBackUrl="~/TeacherInfo/Process.aspx" CssClass="imgbtn" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table3" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/WoodsDriver1Thumb.png" PostBackUrl="~/TeacherInfo/GolfModeling.aspx" CssClass="imgbtn" />
            </asp:TableCell>
            <asp:TableCell>
                <p>
                    <span style="font-family: Magneto; font-size: x-large;">The Golf Model: </span>
                    As with all of the models SwingModel has developed, the golf model is a composite
                    of all of the best movements made by the best players in golf to successfully
                    strike the golf ball. Models have been developed for the Woods, Irons, and
                    Hybrids.
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/TeacherInfo/GolfModeling.aspx">Click 
                    here</asp:HyperLink>
                    to learn about the modeling process in golf and how it can improve your teaching.</p>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table6" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <p>
                    <span style="font-family: Magneto; font-size: x-large;">The New Super Model: </span>
                    The new Model is a powerful action capable of driving the ball over 300 yards
                    with the Driver, yet still maintaining the grace and control required for
                    consistency.
                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/TeacherInfo/Model.aspx">Click 
                    here</asp:HyperLink>
                    to learn about the 21st century model and how it can make you a better teacher.</p>
            </asp:TableCell>
            <asp:TableCell>
                <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/Images/modelimpactfrontthumb.png" PostBackUrl="~/TeacherInfo/Model.aspx" CssClass="imgbtn" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table4" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Images/Fit10Thumb.png" PostBackUrl="~/TeacherInfo/System.aspx" CssClass="imgbtn" />
            </asp:TableCell>
            <asp:TableCell>
                <p>
                    <span style="font-family: Magneto; font-size: x-large;">The SwingModel Teaching System: </span>
                    The new SwingModel Teaching System is designed to allow dedicated teachers the
                    scientific tools to help their students to achieve their greatest potential.
                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/TeacherInfo/System.aspx">Click 
                    here</asp:HyperLink>
                    to learn about the new SwingModel Teaching System, and how it can provide the
                    best learning experience in golf.</p>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table5" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <p>
                    <span style="font-family: Magneto; font-size: x-large;">Equipment Research: </span>
                    In 2006, SwingModel began the research effort to attempt to understand the
                    performance characteristics of golf equipment. The effort was divided into two
                    major areas; mechanical testing and human testing.
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/TeacherInfo/Research.aspx">Click 
                    here</asp:HyperLink>
                    to learn about our mechanical and human equipment testing.</p>
            </asp:TableCell>
            <asp:TableCell>
                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/IronByronThumb.png" PostBackUrl="~/TeacherInfo/Research.aspx" CssClass="imgbtn" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table7" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Images/Fit1Thumb.png" PostBackUrl="~/TeacherInfo/EquipmentFitting.aspx" CssClass="imgbtn" />
            </asp:TableCell>
            <asp:TableCell>
                <p>
                    <span style="font-family: Magneto; font-size: x-large;">The SwingModel Equipment Fitting System: </span>
                    Using the results from the SwingModel equipment research effort, in conjunction 
                    with TPT Golf, Swing Model has developed the first component based equipment 
                    fitting system.
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/TeacherInfo/EquipmentFitting.aspx">Click 
                    here</asp:HyperLink>
                    to learn about SwingModel's component based golf Equipment Fitting System, and
                    how it can maximize your student’s choice of golf heads, shafts, and balls.</p>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table9" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <p>
                    <span style="font-family: Magneto; font-size: x-large;">Integrated Learning: </span>
                    Since SwingModel recognizes that golf teaching and fitting are highly
                    inter-related, we have merged the Teaching System and the Fitting System into a
                    single integrated program.  Although each program is available as a stand-alone
                    program, the fully functional Teaching and Fitting Program offers you the best
                    method to maximize your teaching process and improve all aspects of your
                    student’s game.</p>
            </asp:TableCell>
            <asp:TableCell>
                <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/Images/Fit1Thumb.png" PostBackUrl="~/TeacherInfo/Membership.aspx" CssClass="imgbtn" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table8" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/Images/Membership2Thumb.png" PostBackUrl="~/TeacherInfo/Membership.aspx" CssClass="imgbtn" />
            </asp:TableCell>
            <asp:TableCell>
                <p>
                    <span style="font-family: Magneto; font-size: x-large;">Web Membership: </span>
                    When your students experience a lesson with any aspect of the Teaching and
                    Fitting System, they become a Member of the SwingModel Website. This site serves
                    as a repository of the student’s lesson information, as well as a connection to
                    you as their teacher.  As a SwingModel teacher, the site also allows you access
                    to tools that give you the ability to view the results of all of your student’s
                    lesson results.
                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/TeacherInfo/Membership.aspx">Click 
                    here</asp:HyperLink> 
                    to learn about what is provided in the SwingModel membership.
                    <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="mailto:rmann@swingmodel.com?subject=Teacher%20Info%20Inquiry">Click 
                    here</asp:HyperLink>
                    to have a SwingModel representative contact you with more information on how to
                    become a SwingModel Teacher.</p>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    --%>
</asp:Content>
