<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TSPlayer.ascx.cs" Inherits="Controls_TSPlayer" %>

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
        //embed.nativeProperty.anotherNativeMethod();
    }

    function PauseFlashMovie() {
        var flashMovie = getFlashMovieObject("WMP1");
        flashMovie.StopPlay();
        //embed.nativeProperty.anotherNativeMethod();
    }

//-->
</script>

<div style="text-align: center; height: 360px;">
    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,16,0"
        width="800" height="300" id="WMP1">
        <param name="movie" value="<% =wmpfile %>">
        <param name="quality" value="high">
        <param name="play" value="false">
        <param name="loop" value="false">
        <embed id="WMP1" src="<% =wmpfile %>" width="800" height="300" play="false" loop="false"
            quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"></embed>
    </object>
    
    <asp:Image CssClass="SummaryFrame2" ID="Image1" runat="server" ImageUrl="../Images/SummaryFrame.png" />
    
    <asp:Panel CssClass="SummaryButtons2" ID="SummaryButtons2" runat="server" Visible="true">
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
    <div style="display: none;">
        <img src="../images/pause.png">
        <img src="../images/play.png">
        <img src="../images/stop.png">
    </div>
</div>
