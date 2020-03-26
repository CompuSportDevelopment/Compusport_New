<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DrillsPlayer.ascx.cs" Inherits="Controls_DrillsPlayer" %>

<script language="JavaScript">
<!--
    // F. Permadi May 2000
    function getFlashMovieObject(movieName) {
        if (navigator.appName.indexOf("Microsoft Internet") == -1) {
            if (document.embeds && document.embeds[movieName]) {
                return document.embeds[movieName];
            }
        }
        else // if (navigator.appName.indexOf("Microsoft Internet")!=-1)
        {
            return document.getElementById(movieName);
        }
        if (window.document[movieName]) {
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
    }

    function PauseFlashMovie() {
        var flashMovie = getFlashMovieObject("WMP1");
        flashMovie.StopPlay();
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
        <p class="summarytitle">
            <div class="centeronpage" id="centeronpage">
                <asp:DropDownList ID="DropDownList1" runat="server" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </div>
        </p>
    </div>
    <div class="smsummaryright" id="smsummaryright">
        <img src="../images/summaryheaderright.gif" width="25" height="40" alt="" /></div>
    <div class="middleleft" id="middleleft">
        <img src="../images/drillsmiddleleft.gif" width="23" height="613" alt="" /></div>
    <div class="middlecenter" id="middlecenter">
        <asp:Panel CssClass="DrillsDivCenter" ID="DrillsDivCenter" runat="server">
            <asp:Panel CssClass="DrillsVideo" ID="DrillsVideo" runat="server">
                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,16,0"
                    width="640" height="480" id="WMP1">
                    <param name="movie" value="<% =wmpfile %>">
                    <param name="quality" value="high">
                    <param name="play" value="false">
                    <param name="loop" value="false">
                    <embed id="WMP1" src="<% =wmpfile %>" width="800" height="300" play="false" loop="false"
                        quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"></embed>
                </object>
                <%--
                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,16,0"
                    width="640" height="480" id="Object1">
                    <param name="movie" value="DrillFiles/DrillTest.swf">
                    <param name="quality" value="high">
                    <param name="play" value="false">
                    <param name="loop" value="false">
                    <embed id="WMP1" src="DrillFiles/DrillTest.swf" width="800" height="300" play="false" loop="false"
                        quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"></embed>
                </object>
                --%></asp:Panel>
            <asp:Image CssClass="DrillsFrame" ID="Image1" runat="server" ImageUrl="../Images/DrillsFrame.png" />
            <asp:Panel CssClass="DrillsButtons" ID="DrillsButtons" runat="server" Visible="true">
                <table width="216" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="78">
                            <img alt="Play" id="SummaryPlay" name="SummaryPlay" src="~/Images/play.png" runat="server"
                                onclick="PlayFlashMovie();" />
                        </td>
                        <td width="10">
                        </td>
                        <td width="78">
                            <img alt="Pause" id="Img1" name="SummaryPlay" src="~/Images/pause.png" runat="server"
                                onclick="PauseFlashMovie();" />
                        </td>
                        <td width="10">
                        </td>
                        <td width="40">
                            <img alt="Stop" id="SummaryStop" name="SummaryStop" src="~/Images/stop.png" runat="server"
                                onclick="StopFlashMovie();" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:Panel>
    </div>
    <div class="middleright" id="middleright">
        <img src="../images/drillsmiddleright.gif" width="25" height="613" alt="" /></div>
    <asp:Panel CssClass="bottomleft" ID="bottomleft" runat="server">
        <img src="../images/bottomleft.gif" width="23" height="31" alt="" /></asp:Panel>
    <asp:Panel CssClass="bottomcenter" ID="bottomcenter" runat="server">
    </asp:Panel>
    <asp:Panel CssClass="bottomright" ID="bottomright" runat="server">
        <img src="../images/bottomright.gif" width="25" height="31" alt="" /></asp:Panel>
    <div style="display: none;">
        <img src="../images/pause.jpg">
        <img src="../images/pause.png">
        <img src="../images/play.png">
        <img src="../images/stop.png">
    </div>
</div>
