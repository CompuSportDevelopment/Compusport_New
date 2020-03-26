<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Default" Title="CompSport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--
    <div id="centeronpage">Its a testing
        <p style="font-size: xx-large; font-weight: bold; font-family: Magneto;">CompSport: 
            Using Science in Golf</p>
        <p>
            <span style="font-family: Magneto; font-size: large">Join Our Community: </span>
            <span style="font-size: large"> 
            <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="MakeMember.aspx">Become</asp:HyperLink>
            &nbsp;a CompSport member now.<br />
            <br />
            </span></p>
    </div>
    <br /><br />
    --%>
    <div style="width: 628px; height: 376px; float: left;">
        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/CompuSportHomepageMainImage.jpg"
            Style="margin: 0px 0px 0px 0px; padding: 0px 0px 1px 0px;" Height="353px" Width="624px" />
        <%--<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,16,0"
            width="620" height="356" id="Object1">
            <param name="movie" value="<% =FlashFile %>">
            <param name="quality" value="high">
            <param name="play" value="true">
            <param name="loop" value="false">
            <param name="wmode" value="transparent">
            <embed id="WMP1" src="<% =FlashFile %>" width="620" height="356" play="true" loop="false"
                quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"
                wmode="transparent"></embed>
        </object>--%>
    </div>
    <div>
        <div style="width: 290px; height: 388px; float: left;">
            <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; width: 290px; height: 71px;">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/login.aspx?ReturnUrl=%2fUsers%2fDefault.aspx">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/CompuSportLoginImage.jpg"
                        Style="margin: 0px 0px 0px 0px; padding: 0px 0px 1px 0px;" />
                </asp:HyperLink>
                <%-- <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/MakeMember.aspx">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/hp_joinnow.png" Style="margin: 0px 0px 0px 0px;
                        padding: 1px 0px 1px 0px;" />
                </asp:HyperLink>--%>
                <%-- <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/About/Default.aspx">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/hp_golfertour.png" Style="margin: 0px 0px 0px 0px;
                        padding: 1px 0px 1px 0px;" />
                </asp:HyperLink>--%>
                <%--<asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/TeacherInfo/Default.aspx">
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/hp_teachertour.png" Style="margin: 0px 0px 0px 0px;
                        padding: 1px 0px 1px 0px;" />
                </asp:HyperLink>--%>
                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Contact/Default.aspx">
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/CompuSportHomeContactImage.jpg"
                        Style="margin: 0px 0px 0px 0px; padding: 1px 0px 1px 0px;" />
                </asp:HyperLink>
            </div>
            <div style="display: block; margin: 0px 0px 0px 6px; padding: 5px 8px 5px 8px; width: 266px;
                height: 274px; border: solid 1px #043c5d; font-size: small; overflow: hidden;">
                <asp:Label ID="Label3" runat="server" Text="CompSport Debuts" Font-Bold="True" ForeColor="#043C5D"
                    Font-Size="Medium"></asp:Label>
                <br />
                Sport's most inventive teaching system and website, CompuSport unveils it's new
                data delivery website. Incorporating 3D modeling technology, the system allows athletes
                the ability to compare their performance to that of a Model that is built to their
                exact body dimensions, and performs better than any human.
                <br />
                Currently, these Models are being used by USATF and IMG to improve the performance
                of their elite athletes.
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <%-- <asp:Timer ID="Timer1" runat="server" Interval="8000" OnTick="Timer1_Tick">
                </asp:Timer>--%>
                <div id="leftRSS" style="display: block; margin: 0px 0px 0px 0px; padding: 5px 8px 5px 8px;
                    width: 290px; height: 470px; float: left; font-size: small; overflow: hidden;">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Edition2018.JPG" Style="margin: 60px 0px 0px 0px;
                        padding: 0px 0px 1px 0px;" Height="401px" Width="280px" />
                    <%--   <asp:Label ID="Label2" runat="server" Text="Golf Digest Instruction News" Font-Bold="True"
                        ForeColor="#043C5D" Font-Size="Medium"></asp:Label>--%>
                    <%-- <br />--%>
                    <%--<asp:HyperLink ID="HyperLink3" runat="server" Target="_blank"></asp:HyperLink>
                    <br />
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Visible="False"></asp:Label>--%>
                </div>
                <div id="middleRSS" 
                    style="border-top: 1px solid #043c5d; border-bottom: 1px solid #043c5d;
                    display: block; padding: 5px 8px 5px 8px; width: 592px; height: 558px; float: left;
                    font-size: small; overflow: hidden; margin-bottom: 15px;
                    margin-left: 0px; margin-right: 0px; margin-top: 0px; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium;">
                    <p class="PageTitle" style="text-align: center; font-size: large; color: #043C5D;">
                       The Mechanics of Sprinting and Hurdling, 2018 Edition is Now Available 
                        <br />
                        Authored by Dr. Ralph Mann Ph.D. and Amber Murphy M.S.
                    </p>
                    <p style="color: #043C5D">
                       Dr. Ralph Mann is a pioneer in conducting sports research, and using these results to produce computer-based teaching technology.  
                        An authority in the field of Sport Biomechanics, Dr. Mann has become a leader in analyzing the performance of top amateur and professional athletes. 

                        <p>
                           A world class Track athlete himself, Dr. Mann won 5 national championships and 3 collegiate championships in the hurdles.
                            He set the world record in the intermediate hurdles, was ranked number one in the world numerous times, and won several international titles.
                              In the 1972 Munich Games, he won the Olympic Silver Medal in the 400 Meter Hurdles.
                                In 2015 he was elected to the USA Track and Field Hall of Fame.

                        </p>
                        <p>
                            In 1982, Dr. Mann was one of the six individuals that created the Elite Athlete Program that brought sports science to USA Track and Field. 
                             Since that time, he has served as the Director of the Elite Athlete Sprint and Hurdle Program.  
                             Essentially every elite sprinter and hurdler during this time period has been biomechanically analyzed,
                              with the goal of understanding the characteristics of great sprinters and hurdlers.  
                              This information has been used to evaluate and improve the performance of virtually every US sprint/hurdle athlete since 
                              the program’s inception.  This book contains the findings of this unique effort.

                        </p>
                        <p>
                            <b>This edition represents a major update in the research effort on Sprinting and Hurdling, including an Introduction Chapter by the primary author covering the history of the Sports Science Program in the United States.  In addition, all of the performance variables have been updated to include every athlete analyzed over the past 37 years.  Finally, new insights into the Sprint, Start, and Hurdles; 
                               as well as a re-evaluation of the importance of fatigue, have been added.
                            </b>
                        </p>
                        <br />
                        <br />
                        <p>
                        </p>
                        <%--<asp:Label ID="Label10" runat="server" Text="Golf Digest Equipment News" Font-Bold="True"
                        ForeColor="#043C5D" Font-Size="Medium"></asp:Label>
                    <br />
                    <asp:HyperLink ID="HyperLink4" runat="server" Target="_blank"></asp:HyperLink>
                    <br />
                    <asp:Label ID="Label7" runat="server"></asp:Label>
                    <asp:Label ID="Label8" runat="server" Visible="False"></asp:Label>--%>
                        <p>
                        </p>
                        <p>
                        </p>
                    </p>
                </div>
                <div id="BottomText" style="width: 911px; height: 94px; float: left; font-size: small">
                    <p style="width: 275px; text-align: center; font-style: italic">
                        List Price: $25.00
                    </p>
                    <p style="font-size: small; color: #043C5D;">
                        To order small quantities (less than 15) of <i>Mechanics of Sprinting and Hurdling</i>
                        visit our
                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="https://www.amazon.com/Mechanics-Sprinting-Hurdling-Ralph-Ph-D/dp/1727514769/ref=sr_1_fkmr0_1?ie=UTF8&qid=1543172035&sr=8-1-fkmr0&keywords=mechanics+of+sprinting+and+hurdling"
                            Target="_blank">Amazon Books.</asp:HyperLink>
                        If you would like to order larger quantities of the manual, please send an email
                        to <a href="mailto:track@compusport.com?subject=TMOSH%20Bulk%20Order" target="_blank">
                            track@compusport.com</a>
                    </p>
                </div>
                <%-- <div id="rightRSS" style="display: block; margin: 0px 0px 0px 0px; padding: 5px 8px 5px 7px;
                    width: 290px; height: 125px; float: left; border: solid 1px #043c5d; font-size: small;
                    overflow: hidden;">
                    <asp:Label ID="Label11" runat="server" Text="Golf Digest News" Font-Bold="True" ForeColor="#043C5D"
                        Font-Size="Medium"></asp:Label>
                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank"></asp:HyperLink>
                    <br />
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <asp:Label ID="Label9" runat="server" Visible="False"></asp:Label>
                </div>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
