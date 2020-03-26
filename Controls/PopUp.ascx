<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PopUp.ascx.cs" Inherits="Controls_PopUp" %>

<script language="JavaScript" type="text/javascript">

    function OpenWindow(URL, Width, Height) {
        //var popWindow = window.open(URL, null, "width=" + Width + ", height=" + Height + ", scrollbars=no, toolbar=no, resizable=no, menubar=no, location=no, status=no", "");
        //popWindow.moveTo((screen.width-772)/2, (screen.height-738)/2);
        var popWindow = window.showModalDialog(URL, null, "dialogWidth: " + Width + "px; dialogHeight: " + Height + "px; center: yes; resizable: no; scroll: no; status: no;");
    }

</script>

<table>
    <tr>
        <td>
            <a href="javascript:OpenWindow('../Users/Dimensions/BodyHeight.aspx', 500, 150)">Body
                Height</a>
        </td>
    </tr>
    <tr>
        <td>
            <a href="javascript:OpenWindow('../Users/Dimensions/BodyWeight.aspx', 500, 150)">Body
                Weight</a>
        </td>
    </tr>
    <tr>
        <td>
            <a href="javascript:OpenWindow('../Users/Dimensions/ShoulderWidth.aspx', 500, 400)">
                Shoulder Width </a>
        </td>
    </tr>
    <tr>
        <td>
            <a href="javascript:OpenWindow('../Users/Dimensions/TrunkLength.aspx', 500, 400)">Trunk
                Length</a>
        </td>
    </tr>
    <tr>
        <td>
            <a href="javascript:OpenWindow('../Users/Dimensions/UpperArmLength.aspx', 500, 400)">
                Upper Arm Length</a>
        </td>
    </tr>
    <tr>
        <td>
            <a href="javascript:OpenWindow('../Users/Dimensions/LowerArmLength.aspx', 500, 400)">
                Lower Arm Length</a>
        </td>
    </tr>
    
     <tr>
        <td>
            <br />
        </td>
    </tr>
    
    <tr>
        <td>
            <a href="javascript:OpenWindow('../Users/Dimensions/HipLength.aspx', 500, 400)">Hip
                Length</a>
        </td>
    </tr>
    <tr>
        <td>
            <a href="javascript:OpenWindow('../Users/Dimensions/UpperLegLength.aspx', 500, 400)">
                Upper Leg Length</a>
        </td>
    </tr>
    <tr>
        <td>
            <a href="javascript:OpenWindow('../Users/Dimensions/LowerLegLength.aspx', 500, 400)">
                Lower Leg Length</a>
        </td>
    </tr>
    <tr>
        <td>
            <a href="javascript:OpenWindow('../Users/Dimensions/AnkleHeight.aspx', 500, 350)">Ankle
                Height</a>
        </td>
    </tr>
    <tr>
        <td>
            <a href="javascript:OpenWindow('../Users/Dimensions/ShoeSize.aspx', 500, 150)">Shoe
                Size</a>
        </td>
    </tr>
</table>
