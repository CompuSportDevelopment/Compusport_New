<%@ Control Language="C#" AutoEventWireup="true" CodeFile="addto.ascx.cs" Inherits="Controls_DualPlayer" %>

<script language="JavaScript">
<!--
    // F. Permadi May 2000
    function getFlashMovieObject(movieName) {
        //alert (navigator.appName);
        //alert ("moviename: " + movieName);
        //alert (window.document[movieName]);
        //if (window.document[movieName]) {
        //    alert ("first: " + window.document[movieName]);
        //    return window.document[movieName];
        //}
        if (navigator.appName.indexOf("Microsoft Internet") == -1) {
            if (document.embeds && document.embeds[movieName]) {
                //alert ("not IE: " + document.embeds[movieName]);
                return document.embeds[movieName];
            }
        }
        else // if (navigator.appName.indexOf("Microsoft Internet")!=-1)
        {
            //alert ("IE: " + document.getElementById[movieName]);
            return document.getElementById(movieName);
        }
        if (window.document[movieName]) {
            //alert ("second: " + window.document[movieName]);
            return window.document[movieName];
        }
    }

    function StopFlashMovie() {
        var flashMovie = getFlashMovieObject("WMP1");
        flashMovie.StopPlay();
        flashMovie.Rewind();
    }

    function PlayFlashMovie() {
        var flashMovie = getFlashMovieObject("WMP1");
        flashMovie.Play();
        //embed.nativeProperty.anotherNativeMethod();
    }

    function PauseFlashMovie() {
        var flashMovie = getFlashMovieObject("WMP1");
        flashMovie.StopPlay();
        //embed.nativeProperty.anotherNativeMethod();
    }

    function OpenWindow(URL) {
        //var popWindow = window.open(URL, null, "width=772, height=738, scrollbars=no, toolbar=no, resizable=no, menubar=no, location=no, status=no", "");
        //popWindow.moveTo((screen.width-772)/2, (screen.height-738)/2);
        var popWindow = window.showModalDialog(URL, null, "dialogWidth: 772px; dialogHeight: 738px; center: yes; resizable: no; scroll: no; status: no;");
    }
    function OpenHelpWindow(URL) {
        //var popWindow = window.open(URL, null, "width=800, height=600, scrollbars=yes, toolbar=no, resizable=no, menubar=no, location=no, status=no", "");
        var popWindow = window.showModalDialog(URL, null, "dialogWidth: 800px; dialogHeight: 600px; center: yes; resizable: no; scroll: yes; status: no;");
    }
    function MakeSummaryVisible() {
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1151px';
        }
    }
    function MakeSummaryInvisible() {
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '660px';
        }
    }
    function LoadAnimation(MoviePath) {
        var playerVersion = swfobject.getFlashPlayerVersion();
        if (obj != null) {
            alert("dd");
            //var so = new SWFObject('_embed/player.swf', 'mpl', '300', '250', '9');
            //so.addParam('allowfullscreen', 'true');
            //so.addParam('flashvars', 'file=' + _embed / video.flv);
            //so.write('player');
        }
        else {
            alert("Else");
        }
    }

//-->
</script>

<div class="contplay" id="contplay" runat="server">
    <div class="topleft" id="topleft">
        <img src="../images/topleft.gif" width="23" height="26" alt="" /></div>
    <div class="topcenter" id="topcenter">
    </div>
    <div class="topright" id="topright">
        <img src="../images/topright.gif" width="25" height="26" alt="" /></div>
    <div class="smsummaryleft" id="smsummaryleft">
        <img src="../images/summaryheaderleft.gif" width="23" height="40" alt="" /></div>
    <div class="smsummarycenter" id="smsummarycenter">
        <div style="width: 679px; text-align: left; float: left;">
            <p class="summarytitle">
                My SwingModel Summary - 
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></p>
        </div>
        <div style="width: 180px; text-align: right; font-size: 18px; position: absolute; left: 699px;">
            <a href="javascript:OpenHelpWindow('MySwingHelp.aspx')">Help</a>
        </div>
    </div>
    <div class="smsummaryright" id="smsummaryright">
        <img src="../images/summaryheaderright.gif" width="25" height="40" alt="" /></div>
    <div class="middleleft" id="middleleft">
        <img src="../images/middleleft.gif" width="23" height="563" alt="" /></div>
    <div class="middlecenter" id="middlecenter">
        <div class="player1" id="player1">
        </div>
        <div class="player2" id="player2">
        </div>
        <div class="logo" id="logo">
            <img src="../images/logo2.png" width="101" height="87" alt="" /></div>
        <div class="btns" id="btns">
            <table width="663" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="78">
                        <img id="btnPlay" src="../images/play.png" alt="Play/Pause" />
                    </td>
                    <td width="5">
                    </td>
                    <td width="40">
                        <img id="btnStop" src="../images/stop.png" alt="Stop" />
                    </td>
                    <td width="8">
                    </td>
                    <td width="19">
                        <img id="btnRewind" src="../images/rew.png" alt="Step 1 Frame Backward" />
                    </td>
                    <td width="3">
                    </td>
                    <td width="19">
                        <img id="btnForwind" src="../images/fw.png" alt="Step 1 Frame Backward" />
                    </td>
                    <td width="20">
                    </td>
                    <td width="19">
                        <img class="btnVideoNo" src="../images/1.png" alt="Jump to Position 1" />
                    </td>
                    <td width="5">
                    </td>
                    <td width="19">
                        <img class="btnVideoNo" src="../images/2.png" alt="Jump to Position 2" />
                    </td>
                    <td width="5">
                    </td>
                    <td width="19">
                        <img class="btnVideoNo" src="../images/3.png" alt="Jump to Position 3" />
                    </td>
                    <td width="5">
                    </td>
                    <td width="19">
                        <img class="btnVideoNo" src="../images/4.png" alt="Jump to Position 4" />
                    </td>
                    <td width="5">
                    </td>
                    <td width="19">
                        <img class="btnVideoNo" src="../images/5.png" alt="Jump to Position 5" />
                    </td>
                    <td width="5">
                    </td>
                    <td width="19">
                        <img class="btnVideoNo" src="../images/6.png" alt="Jump to Position 6" />
                    </td>
                    <td width="5">
                    </td>
                    <td width="19">
                        <img class="btnVideoNo" src="../images/7.png" alt="Jump to Position 7" />
                    </td>
                    <td width="5">
                    </td>
                    <td width="19">
                        <img class="btnVideoNo" src="../images/8.png" alt="Jump to Position 8" />
                    </td>
                    <td width="5">
                    </td>
                    <td width="19">
                        <img class="btnVideoNo" src="../images/9.png" alt="Jump to Position 9" />
                    </td>
                    <td width="5">
                    </td>
                    <td width="41">
                        <img class="btnVideoNo" src="../images/10.png" alt="Jump to Position 10" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="sel1" id="sel1">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="select1" AutoPostBack="True"
                OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="sel2" id="sel2">
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="select2" AutoPostBack="True"
                OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="sel3" id="sel3">
            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="select1" AutoPostBack="True"
                OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="square">
            <div class="errorText" id="square">
                Your instructor messages will appear here.</div>
        </div>
    </div>
    <div class="middleright" id="middleright">
        <img src="../images/middleright.gif" width="25" height="563" alt="" /></div>
    <asp:Panel CssClass="fillerleft" ID="fillerleft" runat="server" Visible="true">
        <img src="../images/summaryfillerleft.gif" width="23" height="26" alt="" /></asp:Panel>
    <asp:Panel CssClass="fillercenter" ID="fillercenter" runat="server" Visible="true">
    </asp:Panel>
    <asp:Panel CssClass="fillerright" ID="fillerright" runat="server" Visible="true">
        <img src="../images/summaryfillerright.gif" width="25" height="26" alt="" /></asp:Panel>
    <asp:Panel CssClass="teachersummaryleft" ID="teachersummaryleft" runat="server" Visible="true">
        <img src="../images/summaryheaderleft.gif" width="23" height="40" alt="" /></asp:Panel>
    <asp:Panel CssClass="teachersummarycenter" ID="teachersummarycenter" runat="server" Visible="true">
        <p class="summarytitle">My Teacher Summary - 
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label> - 
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label></p>
    </asp:Panel>
    <asp:Panel CssClass="teachersummaryright" ID="teachersummaryright" runat="server"
        Visible="true">
        <img src="../images/summaryheaderright.gif" width="25" height="40" alt="" /></asp:Panel>
    <asp:Panel CssClass="SumDivLeft" ID="SumDivLeftPanel" runat="server" Visible="true">
        <img src="../images/summaryleft.gif" width="23" height="455" alt="" /></asp:Panel>
    <asp:Panel CssClass="SumDivCenter" ID="SumDivCenterPanel" runat="server">
        <asp:Panel CssClass="SummaryVideo" ID="SummaryVideo" runat="server">
            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,16,0"
                width="800" height="300" id="WMP1" name="WMP1">
                <param name="movie" value="<% =wmpfile %>">
                <param name="quality" value="high">
                <param name="play" value="true">
                <param name="loop" value="false">
                
                <embed id="WMP1" name="WMP1" src="<% =wmpfile %>" width="800" height="300" play="false" loop="false"
                    quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"></embed>
                
            </object>
        </asp:Panel>
        <asp:Image CssClass="SummaryFrame" ID="Image1" runat="server" ImageUrl="../Images/SummaryFrame.png" />
        <asp:Panel CssClass="SummaryButtons" ID="SummaryButtons" runat="server" Visible="true">
            <table width="216" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <%--
                    <td width="78">
                        <img alt="Play" id="SummaryPlay" name="SummaryPlay" src="../Images/play.png" 
                            onclick="PlayFlashMovie();" />
                    </td>
                    <td width="10">
                    </td>
                    <td width="78">
                        <img alt="Pause" id="SummaryPause" name="SummaryPause" src="../Images/pause.png" 
                            onclick="PauseFlashMovie();" />
                    </td>
                    <td width="10">
                    </td>
                    <td width="40">
                        <img alt="Stop" id="SummaryStop" name="SummaryStop" src="../Images/stop.png" 
                            onclick="StopFlashMovie();" />
                    </td>
                    --%>
                    
                    <td width="78">
                        <img alt="Play" id="SummaryPlay" src="../Images/play.png" />
                    </td>
                    <td width="10">
                    </td>
                    <td width="78">
                        <img alt="Pause" id="SummaryPause" src="../Images/pause.png" />
                    </td>
                    <td width="10">
                    </td>
                    <td width="40">
                        <img alt="Stop" id="SummaryStop" src="../Images/stop.png" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="SummaryDropDown" runat="server" Visible="true">
        
            <asp:DropDownList ID="DropDownList4" CssClass="SummaryDropDown" runat="server" AutoPostBack="True"
                OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
            </asp:DropDownList>
        
        </asp:Panel>
    </asp:Panel>
    <asp:Panel CssClass="SumDivRight" ID="SumDivRightPanel" runat="server" Visible="true">
        <img src="../images/summaryright.gif" width="25" height="455" alt="" /></asp:Panel>
    <asp:Panel CssClass="bottomleft" ID="bottomleft" runat="server">
        <img src="../images/bottomleft.gif" width="23" height="31" alt="" /></asp:Panel>
    <asp:Panel CssClass="bottomcenter" ID="bottomcenter" runat="server">
    </asp:Panel>
    <asp:Panel CssClass="bottomright" ID="bottomright" runat="server">
        <img src="../images/bottomright.gif" width="25" height="31" alt="" /></asp:Panel>
    <div style="display: none;">
        <img src="../images/over1.png">
        <img src="../images/over2.png">
        <img src="../images/over3.png">
        <img src="../images/over4.png">
        <img src="../images/over5.png">
        <img src="../images/over6.png">
        <img src="../images/over7.png">
        <img src="../images/over8.png">
        <img src="../images/over9.png">
        <img src="../images/over10.png">
        <img src="../images/pause.jpg">
        <img src="../images/pause.png">
        <img src="../images/play.png">
        <img src="../images/stop.png">
    </div>
</div>
