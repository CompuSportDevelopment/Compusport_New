<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Flashplayer.aspx.cs" Inherits="Flashplayer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Flash Interaction with JavaScript</title>

    <script language="JavaScript">
        // F. Permadi May 2000
        function getFlashMovieObject(movieName) {
            if (window.document[movieName]) {
                return window.document[movieName];
            }
            if (navigator.appName.indexOf("Microsoft Internet") == -1) {
                if (document.embeds && document.embeds[movieName])
                    return document.embeds[movieName];
            }
            else // if (navigator.appName.indexOf("Microsoft Internet")!=-1)
            {
                return document.getElementById(movieName);
            }
        }

        function StopFlashMovie() {
            var flashMovie = getFlashMovieObject("myFlashMovie");
            flashMovie.StopPlay();
        }

        function PlayFlashMovie() {
            var flashMovie = getFlashMovieObject("myFlashMovie");
            flashMovie.Play();
           
            //embed.nativeProperty.anotherNativeMethod();
        }

        function RewindFlashMovie() {
            var flashMovie = getFlashMovieObject("myFlashMovie");
            flashMovie.Rewind();
        }

        function NextFrameFlashMovie() {
            var flashMovie = getFlashMovieObject("myFlashMovie");
            // 4 is the index of the property for _currentFrame
            var currentFrame = flashMovie.TGetProperty("/", 3);
            var nextFrame = parseInt(currentFrame);
//            if (nextFrame >= 10)
//                nextFrame = 0;
            flashMovie.GotoFrame(nextFrame);
        }


        function ZoominFlashMovie() {
            var flashMovie = getFlashMovieObject("myFlashMovie");
            flashMovie.Zoom(90);
        }

        function ZoomoutFlashMovie() {
            var flashMovie = getFlashMovieObject("myFlashMovie");
            flashMovie.Zoom(110);
        }


        function SendDataToFlashMovie() {
            var flashMovie = getFlashMovieObject("myFlashMovie");
            flashMovie.SetVariable("/:message", document.controller.Data.value);
        }

        function ReceiveDataFromFlashMovie() {
            var flashMovie = getFlashMovieObject("myFlashMovie");
            var message = flashMovie.GetVariable("/:message");
            document.controller.Data.value = message;
        }

    </script>

</head>
<body bgcolor="#FFFFFF">
    <p>
        <div align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="800" bordercolor="#000000">
                <tr>
                    <td bgcolor="#FFFFFF">
                        <blockquote>
                            <table border="0" width="80%" bgcolor="#FFFFCC">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <p align="center">
                                <b><font color="#0099CC">Flash Movie</font></b><br>
                                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://active.macromedia.com/flash2/cabs/swflash.cab#version=4,0,0,0"
                                    id="myFlashMovie" width="481" height="86">
                                    <param name="movie" value="griffiths-iwan-6 Iron-Irons-2012-2-8-9-25-Current-Side.swf">
                                    <param name="quality" value="high">
                                    <param name="play" value="false">
                                    <param name="bgcolor" value="#FFFFFF">
                                    <embed play="false" swliveconnect="true" name="myFlashMovie" src="griffiths-iwan-6 Iron-Irons-2012-2-8-9-25-Current-Side.swf"
                                        quality="high" bgcolor="#FFFFFF" width="481" height="86" type="application/x-shockwave-flash"
                                        pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash"> </embed>
                                </object>
                            </p>
                            <form name="controller" method="POST">
                            <p>
                                <center>
                                    <b><font color="#0099CC">JavaScript Controller<br>
                                    </font></b>
                                    <input type="button" value="Play" name="Play" onclick="PlayFlashMovie();">
                                    <input type="button" value="Stop" name="Stop" onclick="StopFlashMovie();">
                                    <input type="button" value="Rewind" name="Rewind" onclick="RewindFlashMovie();">
                                    <input type="button" value="NextFrame" name="NextFrame" onclick="NextFrameFlashMovie();">
                                    <input type="button" value="Zoomin" name="Zoomin" onclick="ZoominFlashMovie();">
                                    <input type="button" value="Zoomout" name="Zoomout" onclick="ZoomoutFlashMovie();">
                                    &nbsp;<br>
                                    Form Data:
                                    <input type="text" name="Data" size="20" value="Enter message">
                                    <input type="button" value="Send Data" name="SendData" onclick="SendDataToFlashMovie();">
                                    <input type="button" value="Receive Data" name="ReceiveData" onclick="ReceiveDataFromFlashMovie();">
                                    <br>
                                </center>
                            </p>
                            </form>
                        </blockquote>
                    </td>
                </tr>
            </table>
        </div>
        <p>
</body>
</html>
