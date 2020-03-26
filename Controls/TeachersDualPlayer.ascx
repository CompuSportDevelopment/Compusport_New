<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TeachersDualPlayer.ascx.cs"
    Inherits="Controls_TeachersDualPlayer" %>
<style type="text/css">
    .style1
    {
        width: 290px;
        cursor: pointer;
    }
    .style2
    {
        width: 260px;
        cursor: pointer;
    }
    .overlay
    {
        position: absolute;
        top: 0;
        bottom: 0;
        left: 0;
        right: 0;
        background: rgba(0,0,0,0.7);
        transition: opacity 500ms; /*visibility:hidden; */
        opacity: 0;
    }
</style>
<script language="javascript" type="text/javascript" for="movie1" event="onkeypress">

// <!CDATA[
return movie1_onkeypress()
// ]]>
</script>
<%--<script type="text/javascript" src="http://code.jquery.com/jquery-1.11.0.min.js"></script>--%>
<link type="text/css" rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
<script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
<%--<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>--%>
<%--<script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>--%>
<%-- <link rel="stylesheet" href="../StyleSheets/demo.css" type="tstyle="color:Red;ext/css" media="screen" title="no title" charset="utf-8">
    <link rel="stylesheet" href="../StyleSheets/reset.css" type="text/css" media="screen" title="no title" charset="utf-8">
    <link rel="stylesheet" href="../StyleSheets/simplemodal.css" type="text/css" media="screen" title="no title" charset="utf-8">
--%>
<%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <!--[if lt IE 9]><script language="javascript" type="text/javascript" src="excanvas.js"></script><![endif]-->

    <script src="../Jqplot/jquery.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../Jqplot/jquery.jqplot.js"></script>

    <link rel="stylesheet" type="text/css" href="../Jqplot/jquery.jqplot.css" />--%>
    <%--<script src="../Scripts/Mpa1.js" type="text/javascript"></script>
    <script src="../Scripts/Map2.js" type="text/javascript"></script>
    <script src="../Scripts/Map.js" type="text/javascript"></script>
    <script src="../Scripts/Loder.js" type="text/javascript"></script>
    <script src="../Scripts/comman.js" type="text/javascript"></script>
    <script src="../Scripts/util.js" type="text/javascript"></script>--%>
<script language="JavaScript" type="text/javascript">
    ////////////////////////////////////////////////////////////////////////////////
    var $j = jQuery.noConflict();

    // F. Permadi May 2000
    var i1 = 1;
    var f1;
    var f2;
    var clipidmain = 0;
    var currentclipid = 1;
    var fwdframe = false
    var framediff = 0; framediff1 = 0;
    var backframe = false
    var backdiff = 0; backdiff1 = 0;
    var xx = 0;
    var yy = 0;
    var Incval = 0;
    var Incval1 = 0;
    var isvideoRF = true;
    var isfwdframes = false;
    var isbwdframes = false;
    var isComparison = false;
    var tempSummaryCount = 0;
    var buttonclickedseven = false;
    var buttonclickedsix = false;
    var buttonclickedeight = false;
    var lessontypeid;
    var clipid;
    var flashmovie1 = false;
    var flashmovie2 = false;
    var flashmovie3 = false;
    var flashmovie4 = false;
    var flashmovie5 = false;
    var flashmovie6 = false;
    var flashmovie7 = false;
    var flashmovie8 = false;
    var case1 = false;
    var frameBackwardLeft;
    var frameBackwardRight;
    var leftframedifference;
    var rightframedifference;
    var errorsRepeated = false;
    var PlayRightButton = false;
    var _selectedLessonId = 1;
    var myVar, myVar1, e1;
    var testWindow = null;
    var flag = true;

    var flag = true;

    function LodingLogo() {
        document.getElementById("divLoading").style.display = "none";
    }

    function myFunction(temp) {

        e1 = temp;
        myVar = setTimeout(alertFunc, 200);
        document.getElementById("show").style.display = "none";
        document.getElementById("divLoading").style.display = "none";
        document.getElementById("divLoadingMask").style.display = "none";

    }
    function alertFunc() {

        document.getElementById("show").style.display = "block";
        document.getElementById("divLoading").style.display = "block";
        document.getElementById("divLoadingMask").style.display = "block";

        cleanFunction();

    }
    function cleanFunction() {
        myVar1 = myVar = setTimeout(alertFunc1, 1000);
    }
    function alertFunc1() {


        document.getElementById("show").style.display = "none";
        document.getElementById("divLoading").style.display = "none";
        document.getElementById("divLoadingMask").style.display = "none";

        display(e1);

    }
    function LoderLoding() {
        document.getElementById("show").style.display = "block";
        document.getElementById("divLoading").style.display = "block";
        document.getElementById("divLoadingMask").style.display = "block";
        Delay(2), true;
    }
    function display(e1) {
        if (window.showModalDialog) {
            window.showModalDialog('../VariablePages/' + e1 + '', "popUpWindow", "dialogWidth:800px;dialogHeight:600px");
        }
        else {
            testWindow = window.open(e1, 'popUpWindow', 'toolbar=no, scrollbars=yes, resizable=no,top=300px, left=300px, width=800px, height=600px , directories=no, status=yes, menubar=no,location=no, dialog=no, dom.disable_window_open_feature=false');

        }
    }
    ////////////////////////////////////////////////////////////////////////////////

    function GroundTime1() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=1');
        //        $j.ajax({
        //            async: false,
        //            success: function() {
        //                alert("function Called Async..... 1!");

        //  InitialiseDialog();


        // $j("#ShowGraph").dialog('open');
        //            }
        //        });

        return true;
    };

    function GroundTimeRight() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=2');
        //        $j("#ShowGraph").dialog('open');
        //                $j("#ShowingGroundTime").load('../VariablePages/CanvasGraph.aspx?index=2');
        //                //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //                $j("#ShowingGroundTime").dialog({
        //                    width: 830,
        //                    height: 600,
        //                    resizable: false,
        //                    modal: true,
        //                    close: function(event, ui) {
        //                    $j("#ShowingGroundTime").dialog('close');

        //                    }
        //                });
        return true;

    };
    function GroundTimeTotal() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=3');
        //        $j("#ShowGraph").dialog('open');

        //        $j("#ShowingGroundTime").load('../VariablePages/CanvasGraph.aspx?index=3');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowingGroundTime").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j("#ShowingGroundTime").dialog('close');
        //            }
        //        });
        return true;

    };

    function KneeTouchDownLeft() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=4');
        //        $j("#ShowGraph").dialog('open');

        //                $j("#ShowTouchDown").load('../VariablePages/CanvasGraph.aspx?index=4');
        //                var id = "#ShowTouchDown";
        //                                dialog(id);
        //                //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        ////                $j("#ShowTouchDown").dialog({
        ////                    width: 830,
        ////                    height: 600,
        ////                    resizable: false,
        ////                     modal: true,
        ////                    close: function(event, ui) {
        ////                    $j("#ShowTouchDown").dialog('close');
        ////                    }
        ////                });
        return true;
    };

    function KneeTouchDownRight() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=5');
        //        $j("#ShowGraph").dialog('open');

        //        $j("#ShowTouchDown").load('../VariablePages/CanvasGraph.aspx?index=5');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowTouchDown").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j("#ShowTouchDown").dialog('close');
        //            }

        //        });
        return true;
    };

    function KneeTouchDownTotal() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=6');
        //        $j("#ShowGraph").dialog('open');
        //        $j("#ShowTouchDown").load('../VariablePages/CanvasGraph.aspx?index=6');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowTouchDown").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j("#ShowTouchDown").dialog('close');

        //            }
        //        });
        return true;
    };

    function LowerLegAngleAtTakeOfLeft() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=7');
        //        $j("#ShowGraph").dialog('open');
        //        $j("#ShowLowerLegAngleAtTakeOf").load('../VariablePages/CanvasGraph.aspx?index=7');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowLowerLegAngleAtTakeOf").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return false;
    };


    function LowerLegAngleAtTakeOfRight() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=8');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowLowerLegAngleAtTakeOf").load('../VariablePages/CanvasGraph.aspx?index=8');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowLowerLegAngleAtTakeOf").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };

    function LowerLegAngleAtTakeOfTotal() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=9');
        //$j("#ShowGraph").dialog('open');

        //        $j("#ShowLowerLegAngleAtTakeOf").load('../VariablePages/CanvasGraph.aspx?index=9');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowLowerLegAngleAtTakeOf").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };

    function TouchDownLeft() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=10');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowTouchDown").load('../VariablePages/CanvasGraph.aspx?index=10');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowTouchDown").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };

    function TouchDownRight() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=11');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowTouchDown").load('../VariablePages/CanvasGraph.aspx?index=11');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowTouchDown").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };
    function TouchDownTotal() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=12');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowTouchDown").load('../VariablePages/CanvasGraph.aspx?index=12');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowTouchDown").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };


    function GroundTime() {
        LoderLoding();

        $j("#ShowingGroundTime").load('../VariablePages/GroundTime.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowingGroundTime").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };


    function TimeToUpperLeg() {
        LoderLoding();
        $j("#ShowTimeToUpperLeg").load('../VariablePages/TimeToUpperLegFullFlexion.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowTimeToUpperLeg").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };

    function FullFlexionLeft() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=13');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowTimeToUpperLeg").load('../VariablePages/CanvasGraph.aspx?index=13');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowTimeToUpperLeg").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };

    function FullFlexionRight() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=14');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowTimeToUpperLeg").load('../VariablePages/CanvasGraph.aspx?index=14');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowTimeToUpperLeg").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };

    function FullFlexionTotal() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=15');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowTimeToUpperLeg").load('../VariablePages/CanvasGraph.aspx?index=15');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowTimeToUpperLeg").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };


    function StrideRate() {
        LoderLoding();
        $j("#ShowStrideRate").load('../VariablePages/StrideRate.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowStrideRate").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };

    function StrideLength() {
        LoderLoding();
        $j("#ShowStrideLength").load('../VariablePages/StrideLength.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowStrideLength").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };



    function Velocity1() {
        LoderLoding();
        $j("#ShowVelocity").load('../VariablePages/Velocity.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowVelocity").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };

    function VelocityLeft() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=28');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowVelocity").load('../VariablePages/CanvasGraph.aspx?index=28');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowVelocity").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };

    function VelocityRight() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=29');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowVelocity").load('../VariablePages/CanvasGraph.aspx?index=29');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowVelocity").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };


    function TrunkAngleForSprintPlayer() {
        LoderLoding();
        $j("#ShowTrunkAngleForSprintPlayer").load('../VariablePages/TrunkAngleForSprintPlayer.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowTrunkAngleForSprintPlayer").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };

    function TrunkAngleLeft() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=16');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowTrunkAngleForSprintPlayer").load('../VariablePages/CanvasGraph.aspx?index=16');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowTrunkAngleForSprintPlayer").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };

    function TrunkAngleRight() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=17');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowTrunkAngleForSprintPlayer").load('../VariablePages/CanvasGraph.aspx?index=17');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowTrunkAngleForSprintPlayer").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };


    function TrunkAngleTotal() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=18');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowTrunkAngleForSprintPlayer").load('../VariablePages/CanvasGraph.aspx?index=18');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowTrunkAngleForSprintPlayer").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };

    function KneeSeparationForSprint() {
        LoderLoding();
        $j("#ShowKneeSeparationForSprint").load('../VariablePages/KneeSeparationForSprint.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowKneeSeparationForSprint").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };

    function TouchDown() {
        LoderLoding();
        $j("#ShowTouchDown").load('../VariablePages/TouchDown.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowTouchDown").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function UpperLegFullExtension1() {
        LoderLoding();
        $j("#ShowUpperLegFullExtension").load('../VariablePages/UpperLegFullExtension.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowUpperLegFullExtension").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };

    function UpperLegFullExtensionLeft() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=19');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowUpperLegFullExtension").load('../VariablePages/CanvasGraph.aspx?index=19');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowUpperLegFullExtension").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };

    function UpperLegFullExtensionRight() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=20');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowUpperLegFullExtension").load('../VariablePages/CanvasGraph.aspx?index=20');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowUpperLegFullExtension").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };

    function UpperLegFullExtensionTotal() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=21');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowUpperLegFullExtension").load('../VariablePages/CanvasGraph.aspx?index=21');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowUpperLegFullExtension").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };

    function UpperLegFullFlexion1() {
        LoderLoding();

        $j("#ShowUpperLegFullFlexion").load('../VariablePages/UpperLegFullFlexion.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowUpperLegFullFlexion").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return true;
    };

    function UpperLegFullFlexionLeft() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=22');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowUpperLegFullFlexion").load('../VariablePages/CanvasGraph.aspx?index=22');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowUpperLegFullFlexion").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };


    function UpperLegFullFlexionRight() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=23');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowUpperLegFullFlexion").load('../VariablePages/CanvasGraph.aspx?index=23');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowUpperLegFullFlexion").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };


    function UpperLegFullFlexionTotal() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=24');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowUpperLegFullFlexion").load('../VariablePages/CanvasGraph.aspx?index=24');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowUpperLegFullFlexion").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };



    function LowerLegAngleAtTakeOf() {
        LoderLoding();
        $j("#ShowLowerLegAngleAtTakeOf").load('../VariablePages/LowerLegAngleAtTakeOf.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowLowerLegAngleAtTakeOf").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };

    function LowerLegFullFlexionLeft() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=25');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowLowerLegAngleAtTakeOf").load('../VariablePages/CanvasGraph.aspx?index=25');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowLowerLegAngleAtTakeOf").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };


    function LowerLegFullFlexionRight() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=26');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowLowerLegAngleAtTakeOf").load('../VariablePages/CanvasGraph.aspx?index=26');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowLowerLegAngleAtTakeOf").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };

    function LowerLegFullFlexionTotal() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=27');
        //$j("#ShowGraph").dialog('open');
        //        $j("#ShowLowerLegAngleAtTakeOf").load('../VariablePages/CanvasGraph.aspx?index=27');
        //        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        //        $j("#ShowLowerLegAngleAtTakeOf").dialog({
        //            width: 830,
        //            height: 600,
        //            resizable: false,
        //            modal: true,
        //            close: function(event, ui) {
        //                $j(this).dialog('close');

        //            }
        //        });
        return true;
    };

    function AirTimeLeftToRight() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=30');

        return true;
    };
    function AirTimeRightToLeft() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=31');

        return true;
    };
    function AirTimeTotal() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=32');

        return true;
    };
    function StrideRate1() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=33');

        return true;
    };
    function StrideRate1() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=34');

        return true;
    };
    function StrideLengthLeft() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=35');

        return true;
    };
    function StrideLengthRight() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=36');

        return true;
    };
    function StrideLengthTotal1() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=37');
        return true;
    };

    ////////////////////////////////////////////////////////////////////////////
    /////Start Player////////////////////////
    function StartSetBlockDistance() {
        LoderLoding();
        $j("#ShowStartSetBlockDistance").load('../VariablePages/StartSetBlockDistance.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowStartSetBlockDistance").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };
    function FrontBlockDistance() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=38');
        return true;
    };
    function RearBlockDistance() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=39');
        return true;
    };
    function FrontULAngle() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=40');
        return true;
    };
    function RearULAngle() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=41');
        return true;
    };
    function FrontLLAngle() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=42');
        return true;
    };
    function RearLLAngle() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=43');
        return true;
    };
    function TrunkAngle2() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=44');
        return true;
    };
    function COG() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=45');
        return true;
    };
    function Trunk_Angle_at_Takeoff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=46');
        return true;
    };
    function BCStrideRide() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=47');
        return true;
    };
    function BCStrideLength() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=48');
        return true;
    };
    function Step1Trunk_Angle() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=49');
        return true;
    };
    function Step1_StrideRate() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=50');
        return true;
    };
    function Step_1Stride_Length() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=51');
        return true;
    };
    function Step2_Trunk_Angle_Takeoff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=52');
        return true;
    };
    function Step2Stride_Rate() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=53');
        return true;
    };
    function Step2Stride_Length() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=54');
        return true;
    };
    function LowerLegAngle_Ankle() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=55');
        return true;
    };
    function Step1_LowerLeg_Angle_Ankle() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=56');
        return true;
    };
    function Step2_LowerLegAngle_Ankle() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=57');
        return true;
    };
    function BC_Velocity1() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=58');
        return true;
    };
    function Step1Velocity1() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=59');
        return true;
    };
    function Step2Velocity1() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=60');
        return true;
    };
    //start player type 1 graph start
    function Rear_Foot_Clearance_Time() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=61');
        return true;
    };
    function Front_Foot_Clearance_Time() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=62');
        return true;
    };
    function Rear_Lower_Leg_Angle_at_Rear_Takeoff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=63');
        return true;
    };
    function Front_Lower_Leg_Angle_at_Front_Takeoff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=64');
        return true;
    };
    function BC_AirTime() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=65');
        return true;
    };
    function Step1COG() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=66');
        return true;
    };
    function Step_1_Rear_Leg_Angle() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=67');
        return true;
    };
    function Step1GroundTime() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=68');
        return true;
    };
    function Step1AirTime() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=69');
        return true;
    };

    function Step2COG() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=70');
        return true;
    };
    function Step_2_Rear_Leg_Angle() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=71');
        return true;
    };
    function Step2GroundTime() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=72');
        return true;
    };
    function Step2AirTime() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=73');
        return true;
    };

    function Step3COG() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=74');
        return true;
    };

    function Timeto3m() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=75');
        return true;
    };
    function Timeto5m() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=76');
        return true;
    };

    //***********************************************Graph End *************************************************************************

    function StartSegmentAnglesatSetPosition() {
        LoderLoding();
        $j("#ShowStartSegmentAnglesatSetPosition").load('../VariablePages/StartSegmentAnglesatSetPosition.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowStartSegmentAnglesatSetPosition").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };

    function StartcogDistanceatSetPosition() {
        LoderLoding();
        $j("#ShowStartcogDistanceatSetPosition").load('../VariablePages/StartcogDistanceatSetPosition.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowStartcogDistanceatSetPosition").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function StartGroundTimeandAirTime() {
        LoderLoding();
        $j("#ShowStartGroundTimeandAirTime").load('../VariablePages/StartGroundTimeandAirTime.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowStartGroundTimeandAirTime").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };

    function SegmentAnglesDuringBlockClearance() {
        LoderLoding();
        $j("#ShowSegmentAnglesDuringBlockClearance").load('../VariablePages/SegmentAnglesDuringBlockClearance.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowSegmentAnglesDuringBlockClearance").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };


    function Start_strideLengthandRate() {
        LoderLoding();
        $j("#ShowStart_strideLengthandRate").load('../VariablePages/Start_strideLengthandRate.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowStart_strideLengthandRate").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };

    function StartHorizontalVelocity() {
        LoderLoding();
        $j("#ShowStartHorizontalVelocity").load('../VariablePages/StartHorizontalVelocity.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowStartHorizontalVelocity").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };

    function StartTouchdowndistance() {
        LoderLoding();
        $j("#ShowStartTouchdowndistance").load('../VariablePages/StartTouchdowndistance.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowStartTouchdowndistance").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };

    function COGDistanceandSegmentAnglesDuringStep2() {
        LoderLoding();
        $j("#ShowCOGDistanceandSegmentAnglesDuringStep2").load('../VariablePages/COGDistanceandSegmentAnglesDuringStep2.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowCOGDistanceandSegmentAnglesDuringStep2").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };

    function StartCOGDistanceDuringStep3() {
        LoderLoding();
        $j("#ShowStartCOGDistanceDuringStep3").load('../VariablePages/StartCOGDistanceDuringStep3.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowStartCOGDistanceDuringStep3").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };


    function Start_3to5meter() {
        LoderLoding();
        $j("#ShowStart_3to5meter").load('../VariablePages/Start_3to5meter.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowStart_3to5meter").dialog({
            width: 830,
            height: 600,
            resizable: false,
            draggable: false,
            modal: true
        });
        return false;
    };

    ///////////////////Hurdle Video Player////////////////////////////
    //Hurdle_AirtimeAndStrideRate player graph start
    //Hurdle_player graph start
    //graph type 1 start
    function GroundTimeInto() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=77');
        return true;
    };
    function GroundTimeoff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=78');
        return true;
    };
    function AirTimeoff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=79');
        return true;
    };
    function TouchDownDistanceinto() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=80');
        return true;
    };
    function TouchDownDistanceoff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=81');
        return true;
    };
    function KneeSeparationtouchdowninto() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=82');
        return true;
    };
    function KneeSeparationtouchdownoff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=83');
        return true;
    };
    function TrunkMinimumAngle() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=84');
        return true;
    };
    function Hurdle_TrailUpperLegAngleatTouchdownInto() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=85');
        return true;
    };
    function LeadUpperLegAngleTouchdownOff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=86');
        return true;
    };
    function Hurdle_LeadLowerLegAngleTouchdownOff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=87');
        return true;
    };
    function Hurdle_LeadLowerLegMaximumAngleOver() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=88');
        return true;
    };
    function Hurdle_StrideLengthTotal() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=89');
        return true;
    };
    function StrideLengthinto() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=90');
        return true;
    };
    function StrideLengthoff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=91');
        return true;
    };
    function HurdleVelocitygraph() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=92');
        return true;
    };
    function Hurdle_TrunkAngleTouchdownInto() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=93');
        return true;
    };
    function Hurdle_TrunkAngleTouchdownoff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=94');
        return true;
    };
    function Hurdle_TrunkAngleTakeoffInto() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=95');
        return true;
    };
    function Hurdle_TrunkAngleatTakeoffOff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=96');
        return true;
    };
    function Hurdle_TrailUpperLegAngleTakeoffInto() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=97');
        return true;
    };
    function Hurdle_LeadUpperLegMaximumAngleOver() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=98');
        return true;
    }
    function Hurdle_LeadUpperLegAngleTakeoffOff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=99');
        return true;
    }
    function Hurdle_LeadLowerLegMinimumAngleInto() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=100');
        return true;
    };
    function Hurdle_LeadLowerLegAngleAnkleCrossInto() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=101');
        return true;
    };
    function Hurdle_KneeAnkleMinimumSeparationOver() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=102');
        return true;
    };
    function Hurdle_LeadLowerLegAngleTakeoffOff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=103');
        return true;
    };



    //grap type 1 end 
    //Hurdle player graph end
    function Hurdle_GroundTime() {
        LoderLoding();

        $j("#ShowHurdle_GroundTime").load('../VariablePages/Hurdle_GroundTime.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowHurdle_GroundTime").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;

    };

    function Hurdle_AirtimeAndStrideRate() {
        LoderLoding();
        $j("#ShowHurdle_AirtimeAndStrideRate").load('../VariablePages/Hurdle_AirtimeAndStrideRate.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowHurdle_AirtimeAndStrideRate").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function Hurdle_StrideLength() {
        LoderLoding();
        $j("#ShowHurdle_StrideLength").load('../VariablePages/Hurdle_StrideLength.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowHurdle_StrideLength").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function Hurdle_Velocity1() {
        LoderLoding();
        $j("#ShowHurdle_Velocity").load('../VariablePages/Hurdle_Velocity.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowHurdle_Velocity").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function HurdleTDIonAndoff() {
        LoderLoding();
        $j("#ShowHurdleTDIonAndoff").load('../VariablePages/HurdleTDIonAndoff.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowHurdleTDIonAndoff").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function HurdleKneeSeparationForPlayer() {
        LoderLoding();
        $j("#ShowHurdleKneeSeparationForPlayer").load('../VariablePages/HurdleKneeSeparationForPlayer.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowHurdleKneeSeparationForPlayer").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function HurdleTrunkAngleForPlayer() {
        LoderLoding();
        $j("#ShowHurdleTrunkAngleForPlayer").load('../VariablePages/HurdleTrunkAngleForPlayer.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowHurdleTrunkAngleForPlayer").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function Hurdle_UpperLegTDInto() {
        LoderLoding();
        $j("#ShowHurdle_UpperLegTDInto").load('../VariablePages/Hurdle_UpperLegTDInto.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowHurdle_UpperLegTDInto").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function HurdleLowerLegRecoveryMotion() {
        LoderLoding();
        $j("#ShowHurdleLowerLegRecoveryMotion").load('../VariablePages/HurdleLowerLegRecoveryMotion.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowHurdleLowerLegRecoveryMotion").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function Hurdle_KneeAnkleSeparationOver() {
        LoderLoding();
        $j("#ShowHurdle_KneeAnkleSeparationOver").load('../VariablePages/Hurdle_KneeAnkleSeparationOver.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowHurdle_KneeAnkleSeparationOver").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function HurdleLowerLegRecoveryMotion() {
        LoderLoding();
        $j("#ShowHurdleLowerLegRecoveryMotion").load('../VariablePages/HurdleLowerLegRecoveryMotion.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowHurdleLowerLegRecoveryMotion").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function HurdleLowerLegMotion() {
        LoderLoding();
        $j("#ShowHurdleLowerLegMotion").load('../VariablePages/HurdleLowerLegMotion.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowHurdleLowerLegMotion").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    ////////////////////Hurdle Steps/////////////////////////////////////////////////
    function HurdleStep_GroundTime() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=105');
        return true;
    };
    function HurdleStep_AirTime() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=106');
        return true;
    };
    function HurdleStep_TouchDown() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=107');
        return true;
    };
    function HurdleStep_KneeSeperationTouchdown() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=108');
        return true;
    };
    function Hurdle_UpperLegAngleFullExtension() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=109');
        return true;
    };
    function Hurdle_LowerLegTakeoff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=110');
        return true;
    };
    function HurdleStep_StrideRate() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=111');
        return true;
    };
    function HurdleStep_TrunkTouchdownAngle() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=112');
        return true;
    };
    function HurdleStep1_TrunkTakeoffAngle() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=113');
        return true;
    };
    function HurdleStep1_UpperLegAngleFullFlexion() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=114');
        return true;
    };
    function HurdleStep1_StrideLength() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=115');
        return true;
    };
    function HurdleStep2_Striderate() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=116');
        return true;
    };
    function HurdleStep2_TrunkAngleTouchdown() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=117');
        return true;
    };
    function HurdleStep2_TrunkAngleTakeoff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=118');
        return true;
    };
    function HurdleStep2_UpperLegAngleFullFlexion() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=119');
        return true;
    };
    function HurdleStep2_StrideLength() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=120');
        return true;
    };
    function HurdleStep2_GroundTime() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=121');
        return true;
    };
    function HurdleStep2_AirTime() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=122');
        return true;
    };
    function HurdleStep2_TouchdownDistance() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=123');
        return true;
    };
    function HurdleStep2_KneeSeperationTouchdown() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=124');
        return true;
    };
    function HurdleStep2_UpperLegAngleFullExtension() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=125');
        return true;
    };
    function HurdleStep2_LowerLegTakeoff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=126');
        return true;
    };
    function HurdleStep2_LowerLegFullFlexion() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=127');
        return true;
    };
    //hurdle step 3 start
    function HurdleStep3_GroundTime() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=128');
        return true;
    };
    function HurdleStep3_AirTime() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=129');
        return true;
    };
    function HurdleStep3_TouchdownDistance() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=130');
        return true;
    };
    function HurdleStep3_KneeSeperationTouchdown() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=131');
        return true;
    };
    function HurdleStep3_UpperLegAngleFullExtension() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=132');
        return true;
    };
    function HurdleStep3_LowerLegTakeoff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=133');
        return true;
    };
    function HurdleStep3_LowerLegAngleFullFlexion() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=134');
        return true;
    };
    function HurdleStep3_StrideRateGraph() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=135');
        return true;
    };
    function HurdleStep3_TrunkTouchdown() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=136');
        return true;
    };
    function HurdleStep3_TrunkAngleTakeoff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=137');
        return true;
    };
    function HurdleStep3_UpperLegAngleFullFlexion() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=138');
        return true;
    };
    function HurdleStep3_StrideLength() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=139');
        return true;
    };
    function HurdleStep3_intoTouchdownDistance() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=140');
        return true;
    };
    function HurdleStep3_KneeSeparationTouchdown() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=141');
        return true;
    };
    function HurdleStep3_StepintoKneeSeparationTouchdown() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=142');
        return true;
    };
    function HurdleStep3_StepintoLowerLegTouchdown() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=143');
        return true;
    };
    function Hurdle_Distance_StrideLengthInto() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=144');
        return true;
    };
    function Hurdle_Distance_StrideLengthOff() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=145');
        return true;
    };
    function Hurdle_Distance_Velocity() {
        LoderLoding();
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=146');
        return true;
    };




    function BeetweenTheHurdle_HurdleSteps() {
        LoderLoding();
        $j("#ShowBeetweenTheHurdle_HurdleSteps").load('../VariablePages/BeetweenThe%20Hurdle_HurdleSteps.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowBeetweenTheHurdle_HurdleSteps").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function TouchDownDist() {
        LoderLoding();
        $j("#ShowTouchDownDist").load('../VariablePages/TouchDownDist.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowTouchDownDist").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function VelocityHurdleSteps() {
        LoderLoding();
        $j("#ShowVelocityHurdleSteps").load('../VariablePages/Hurdle_Velocity.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowVelocityHurdleSteps").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function GroundTimeHurdleStep() {
        LoderLoding();
        $j("#ShowGroundTimeHurdleStep").load('../VariablePages/GroundTimeHurdleStep.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowGroundTimeHurdleStep").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function AirTimeHurdleStep() {
        LoderLoding();
        $j("#ShowAirTimeHurdleStep").load('../VariablePages/AirTimeHurdleStep.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowAirTimeHurdleStep").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function StrideRateHurdleStep() {
        LoderLoding();
        $j("#ShowStrideRateHurdleStep").load('../VariablePages/StrideRateHurdleStep.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowStrideRateHurdleStep").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function StrideLengthHurdleStep() {
        LoderLoding();
        $j("#ShowStrideLengthHurdleStep").load('../VariablePages/StrideLengthHurdleStep.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowStrideLengthHurdleStep").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function TouchDown_HurdleSteps() {
        LoderLoding();
        $j("#ShowTouchDown_HurdleSteps").load('../VariablePages/TouchDown_HurdleSteps.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowTouchDown_HurdleSteps").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function KneeSeperation_HurdleSteps() {
        LoderLoding();
        $j("#ShowTouchDown_HurdleSteps").load('../VariablePages/KneeSeperation_HurdleSteps.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowTouchDown_HurdleSteps").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function TrunkAngles_HurdleSteps() {
        LoderLoding();
        $j("#ShowTrunkAngles_HurdleSteps").load('../VariablePages/TrunkAngles_HurdleSteps.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowTrunkAngles_HurdleSteps").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function UpperLegAngles_HurdleSteps() {
        LoderLoding();
        $j("#ShowUpperLegAngles_HurdleSteps").load('../VariablePages/UpperLegAngles_HurdleSteps.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowUpperLegAngles_HurdleSteps").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };

    function LowerLegAngles_HurdleSteps() {
        LoderLoding();
        $j("#ShowLowerLegAngles_HurdleSteps").load('../VariablePages/LowerLegAngles_HurdleSteps.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowLowerLegAngles_HurdleSteps").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true
        });
        return false;
    };
    function MySwingHelp() {
        LoderLoding();
        $j("#ShowMySwingHelp").html('');
        $j("#ShowMySwingHelp").load('../Users/MySwingHelp.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowMySwingHelp").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true,
            close: function () {
                $j('#ShowMySwingHelp').html('');
                $j('#ShowMySwingHelp').hide();
                $j('.ui-dialog').remove();
            }
        });

        return false;
    };
    ////////////////////////////////////////////////////////////////////////////////

    function playleftnew() {
        // var username = document.getElementById("<%=HiddenField1.ClientID %>").value;

        if ((currentclipid != 7 && _selectedLessonId == 2) || (currentclipid != 6 && _selectedLessonId == 3) || (!currentclipid != 8 && _selectedLessonId == 1) || (!currentclipid != 4 && _selectedLessonId == 6)) {
            if (currentclipid > 9) {
                i1 = 1;
                i2 = 1;
                f1 = 1;
                f2 = 1;
                currentclipid = 1;
            }
            if (backframe) {
                if (currentclipid > 1) {
                    currentclipid--;
                }
            }
            var fromclipid = currentclipid;
            var tolipid = currentclipid - 1;
            var strg1, strg2;
            // (function($){
            strg1 = Centralfs(tolipid);
            strg2 = Centralfs(fromclipid);
            // })(document.id);

            var Arrstr1 = new Array();
            var Arrstr2 = new Array();

            Arrstr1 = strg1.split(',');
            Arrstr2 = strg2.split(',');

            var tofrm1 = Arrstr1[0];
            var to2frm1 = Arrstr1[1];

            var tofrm2 = Arrstr2[1];
            var to2frm2 = Arrstr2[0];
            f1 = to2frm2;
            f2 = tofrm2;

            i1 = tofrm1;
            i2 = to2frm1;

            if (isvideoRF == false) {
                i1 = framecount;
                i2 = framecount;
                isvideoRF = true;
            }
            //        alert(i2);
            // chk();

            playVideo("movie", 1);
            playVideo("movie1", 0);

            if (currentclipid < 9) {
                currentclipid++;
            }
            else {
                currentclipid = 1;
            }
            ButtonsRedOnPlay(currentclipid)
        }
    }

    function playVideo(movieId, isLeft) {
        var objMovie = document.getElementById(movieId);
        var bframe = 0, endFrame = 0;
        if (isLeft == 1) {
            if (f1 == null) {
                i1 = 1; f1 = 1;
            }
            bframe = parseInt(i1);
            endFrame = parseInt(f1);
        } else {
            if (f2 == null) {
                i2 = 1; f2 = 1;
            }
            bframe = parseInt(i2);
            endFrame = parseInt(f2);
        }

        var isVideoStopped = false;
        backframe = false;
        if (bframe > endFrame) {
            if (isLeft == 1) { i1 = endFrame; } else { i2 = endFrame; }
            try {
                objMovie.pause();
                isVideoStopped = true;
            } catch (Error) { }
        } else if (bframe <= endFrame) {
            isVideoStopped = false;
            try {        // 10/10/17
                if (flag == true) {
                    setTimeout(function () {
                        objMovie.playbackRate = 0.2;
                        frameRate = 60;
                        curTime = isLeft == 1 ? i1 : i2;
                        curTime--;
                        objMovie.play();
                        if (curTime == endFrame) {
                            theCurrentFrame = Math.min(curTime / frameRate);
                            objMovie.currentTime = theCurrentFrame;
                            objMovie.pause();
                        }
                    });
                }
                else if (flag == false) {
                    setTimeout(function () {
                        objMovie.playbackRate = 0.2;
                        frameRate = 60;
                        curTime = isLeft == 1 ? i1 : i2;
                        curTime--;
                        theCurrentFrame = Math.min(curTime / frameRate);
                        objMovie.currentTime = theCurrentFrame;
                        flag = true;
                    });
                }
            } catch (Error) { }
            if (isLeft == 1) { i1++; } else { i2++; }
        }
        if (isVideoStopped == false) setTimeout("playVideo('" + movieId + "', " + isLeft + ")", 80);
    }




    function Centralfs(i) {
        var clipid = i;
        this.rightInfo = JSON.decode(rightMovie);
        this.rightInfo.clips[clipid];

        this.leftInfo = JSON.decode(leftMovie);
        this.leftInfo.clips[clipid];

        if (leftMovie == null || rightMovie == null) {
            return;
        }
        this.leftInfo = JSON.decode(leftMovie);
        this.rightInfo = JSON.decode(rightMovie);
        var fs = this.leftInfo.clips[clipid];
        var from = fs.beginFrame;
        var to = fs.endFrame;
        var fs2 = this.rightInfo.clips[clipid];
        var from2 = fs2.beginFrame;
        var to2 = fs2.endFrame;
        //  debugger;
        var error = [];
        if (isComparison == true) {
        }
        else {
            if (errorsRepeated)
            { }
            else {
                $("square").empty();
                var err_cb = function (err, to2) {
                    var divErr = new Element("div");
                    divErr.set("html", err);
                    divErr.injectInside($("square"));
                    error.push(err);
                }
                fs.errors.each(err_cb);
                if (fs.errors == "") {
                    document.getElementById("square").innerHTML = 'No Errors Entered at This Position';
                }
            }
        };
        //domready;
        // fs2.errors.each(err_cmp);
        var str = to + "," + to2;
        document.getElementById("ctl00_ContentPlaceHolder1_DualPlayer1_hdnError").value = error;

        return str;

    }


    function FunctionForAllBtns(newval) {
        //debugger;
        //var frameRate = 60;
        // var framevalue = 13.55;
        errorsRepeated = false;
        var flashMovie = document.getElementById("movie");
        var flashMovie1 = document.getElementById("movie1");
        // alert("flashMovie = " + flashMovie);
        var val = parseInt(newval);
        currentclipid = val + 1;
        //getCuttentclipid(currentclipid);
        if (currentclipid == 7)
            buttonclickedseven = true;
        else
            buttonclickedseven = false;
        if (currentclipid == 6)
            buttonclickedsix = true;
        else
            buttonclickedsix = false;
        if (currentclipid == 8)
            buttonclickedeight = true;
        else
            buttonclickedeight = false;
        if (val < 10) {
            var str1 = Centralfs(val);
            var tempSrData = new Array();
            tempSrData = str1.split(',');

            var to = tempSrData[0];
            var to2 = tempSrData[1];
            try {

                frameRate = 60;
                setTimeout(function () {
                    curTime = to;
                    //curTime--;
                    theCurrentFrame = Math.min(curTime / frameRate);
                    flashMovie.currentTime = theCurrentFrame;
                    flashMovie.pause();
                }, false);

            } catch (Error) { }
            try {

                frameRate = 60;
                setTimeout(function () {
                    curTime = to2;
                    // curTime--;
                    theCurrentFrame = Math.min(curTime / frameRate);
                    flashMovie1.currentTime = theCurrentFrame;
                    flashMovie1.pause();
                }, false);


            } catch (Error) { }

        }

        if (val == 6) {

            try {
                flashMovie.pause();
            } catch (Error) { }
            try {
                flashMovie1.pause();
            } catch (Error) { }
        }

        if (val == 9) {

            try {
                flashMovie.pause();
            } catch (Error) { }
            try {
                flashMovie1.pause();
            } catch (Error) { }
        }

        if (val == 10) {

            try {
                flashMovie.play();
            } catch (Error) { }
            try {
                flashMovie1.play();
            } catch (Error) { }
        }

        if (val == 11) {

            try {
                document.getElementById('movie').pause();
            } catch (Error) { }
            try {
                document.getElementById('movie1').pause();
            } catch (Error) { }

        }
    }

    function playMovieRight(objectName) {
        var flashMovie = document.getElementById(objectName);
        try {
            if (typeof flashMovie.loop == 'boolean') { // 10/10/17
                flashMovie.playbackRate = 1;
                flashMovie.play(); // 10/10/17
                flashMovie.loop = true;
            } // 10/10/17

        } catch (Error) { }
    }

    function playright() {
        // FunctionForAllBtns(10);
        PlayRightButton = true;
        playMovieRight('movie');
        playMovieRight('movie1');


        _selectedLessonId = document.getElementById("<%=DropDownList2.ClientID %>").value;
        var buttonfirstblack = document.getElementById('btnFirstBlack');
        var buttonsecondblack = document.getElementById('btnSecondBlack');
        var buttonthirdblack = document.getElementById('btnThirdBlack');
        var buttonfourblack = document.getElementById('btnFourBlack');
        var buttonfiveblack = document.getElementById('btnFiveBlack');
        var buttonsixblack = document.getElementById('btnSixBlack');
        var buttonsevenblack = document.getElementById("<%=btnSeven.ClientID %>");
        var buttoneightblack = document.getElementById("<%=btnEight.ClientID %>");

        var buttonfirstred = document.getElementById('btnFirstRed');
        var buttonsecondred = document.getElementById('btnSecondRed');
        var buttonthirdred = document.getElementById('btnThirdRed');
        var buttonfourred = document.getElementById('btnFourRed');
        var buttonfivered = document.getElementById('btnFiveRed');
        var buttonsixred = document.getElementById('btnSixRed');
        var buttonsevenred = document.getElementById('btnSevenRed');
        var buttoneightred = document.getElementById('btnEightRed');

        buttonfirstred.style.display = 'none';
        buttonfirstblack.style.display = 'block';
        buttonsecondred.style.display = 'none';
        buttonsecondblack.style.display = 'block';
        buttonthirdred.style.display = 'none';
        buttonthirdblack.style.display = 'block';
        buttonfourred.style.display = 'none';
        buttonfourblack.style.display = 'block';
        buttonfivered.style.display = 'none';
        buttonfiveblack.style.display = 'block';
        buttonsixred.style.display = 'none';
        buttonsixblack.style.display = 'block';
        buttoneightblack.style.display = 'none';
        buttoneightred.style.display = 'none';
        buttonsevenred.style.display = 'none';
        buttonsevenblack.style.display = 'block';
        PositioningButtons();
    }
    function stop() {
        //   debugger;
        // FunctionForAllBtns(11);
        //        try {
        //            document.getElementById('movie').StopPlay();
        //        } catch (Error) { }
        //        try {
        //            document.getElementById('movie1').StopPlay();
        //        } catch (Error) { }
        if (_selectedLessonId == 1) {
            NextFrameFlashMovie1();
        }
        if (_selectedLessonId == 2) {
            NextFrameFlashMovie3();
        }
        if (_selectedLessonId == 3) {
            NextFrameFlashMovie2();
        }
        if (_selectedLessonId == 6) {
            NextFrameFlashMovie2();
        }
    }
    function managepositionsForReverseButton(param) {
        // debugger;
        var Vdeo = document.getElementById("movie");
        var Vdeo1 = document.getElementById("movie1");
        backframe = true;

        isvideoRF = false;
        var framerate = 60;
        case1 = false;
        if (currentclipid)
            if (currentclipid == 1) {
                currentclipid = 2;
                case1 = true;
            }
        var fromclipid = currentclipid - 1;
        var tolipid = fromclipid - 1;

        var strg1 = Centralfs(tolipid);
        var strg2 = Centralfs(fromclipid);

        var Arrstr1 = new Array();
        var Arrstr2 = new Array();

        Arrstr1 = strg1.split(',');
        Arrstr2 = strg2.split(',');

        var tofrm1 = Arrstr1[0];
        var to2frm1 = Arrstr1[1];

        var tofrm2 = Arrstr2[1];
        var to2frm2 = Arrstr2[0];
        var leftframedifference = tofrm1 - tofrm2;
        var rightframedifference = to2frm1 - to2frm2;
        var buttonfirstblack = document.getElementById('btnFirstBlack');
        var buttonsecondblack = document.getElementById('btnSecondBlack');
        var buttonthirdblack = document.getElementById('btnThirdBlack');
        var buttonfourblack = document.getElementById('btnFourBlack');
        var buttonfiveblack = document.getElementById('btnFiveBlack');
        var buttonsixblack = document.getElementById('btnSixBlack');
        var buttonsevenblack = document.getElementById("<%=btnSeven.ClientID %>");
        var buttoneightblack = document.getElementById("<%=btnEight.ClientID %>");

        var buttonfirstred = document.getElementById('btnFirstRed');
        var buttonsecondred = document.getElementById('btnSecondRed');
        var buttonthirdred = document.getElementById('btnThirdRed');
        var buttonfourred = document.getElementById('btnFourRed');
        var buttonfivered = document.getElementById('btnFiveRed');
        var buttonsixred = document.getElementById('btnSixRed');
        var buttonsevenred = document.getElementById('btnSevenRed');
        var buttoneightred = document.getElementById('btnEightRed');
        if (!PlayRightButton) {
            if (case1) {
                currentclipid = 1;
            }
            switch (currentclipid) {
                case 1:
                    try {
                        //flashMovie.Back();
                        Vdeo.currentTime += param;
                        framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                        var frameno = Math.abs(--framediff);
                        //  frameno++;
                        if (framediff == 0) {
                            buttonfirstred.style.display = 'block';
                            buttonfirstblack.style.display = 'none';
                        }
                        else {
                            buttonfirstred.style.display = 'none';
                            buttonfirstblack.style.display = 'block';
                        }
                        if (framediff == leftframedifference) {
                            currentclipid = 2;
                            leftframedifference = 0;
                        }
                    } catch (Error) { }

                    try {
                        //flashMovie1.Back();
                        Vdeo1.currentTime += param;
                        framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                        var frameno1 = Math.abs(--framediff1);
                        if (framediff1 == 0) {
                            buttonfirstred.style.display = 'block';
                            buttonfirstblack.style.display = 'none';
                        }
                        else {
                            buttonfirstred.style.display = 'none';
                            buttonfirstblack.style.display = 'block';
                        }
                        if (framediff1 == rightframedifference) {
                            currentclipid = 2;
                            rightframedifference = 0;
                            flashmovie2 = true;
                            NextFrameFlashMovie2();
                            flashmovie2 = false;
                        }
                    } catch (Error) { }
                    break;

                case 2:
                    try {
                        // flashMovie.Back();
                        Vdeo.currentTime += param;
                        framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                        var frameno = Math.abs(--framediff);
                        //  frameno++;
                        if (framediff == 0) {
                            buttonsecondblack.style.display = 'none';
                            buttonsecondred.style.display = 'block';
                        }
                        else {
                            buttonsecondblack.style.display = 'block';
                            buttonsecondred.style.display = 'none';
                        }
                        if (framediff == leftframedifference) {
                            currentclipid = 1;
                            leftframedifference = 0;
                        }
                    } catch (Error) { }

                    try {
                        //flashMovie1.Back();
                        Vdeo1.currentTime += param;
                        framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                        var frameno1 = Math.abs(--framediff1);
                        if (framediff1 == 0) {
                            buttonsecondblack.style.display = 'none';
                            buttonsecondred.style.display = 'block';
                        }
                        else {
                            buttonsecondblack.style.display = 'block';
                            buttonsecondred.style.display = 'none';
                        }
                        if (framediff1 == rightframedifference) {
                            currentclipid = 1;
                            rightframedifference = 0;
                            flashmovie1 = true;
                            NextFrameFlashMovie1();
                            flashmovie1 = false;
                        }
                    } catch (Error) { }
                    break;

                case 3:

                    try {
                        //flashMovie.Back();
                        Vdeo.currentTime += param;
                        framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                        var frameno = Math.abs(--framediff);
                        //  frameno++;
                        if (framediff == 0) {
                            buttonthirdblack.style.display = 'none';
                            buttonthirdred.style.display = 'block';
                        }
                        else {
                            buttonthirdblack.style.display = 'block';
                            buttonthirdred.style.display = 'none';
                        }
                        if (framediff == leftframedifference) {
                            currentclipid = 2;
                            leftframedifference = 0;
                        }
                        // alert("left frame difference " + framediff);
                    } catch (Error) { }

                    try {
                        //flashMovie1.Back();
                        Vdeo1.currentTime += param;
                        framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                        var frameno1 = Math.abs(--framediff1);
                        if (framediff1 == 0) {
                            buttonthirdblack.style.display = 'none';
                            buttonthirdred.style.display = 'block';
                        }
                        else {
                            buttonthirdblack.style.display = 'block';
                            buttonthirdred.style.display = 'none';
                        }
                        if (framediff1 == rightframedifference) {
                            currentclipid = 2;
                            rightframedifference = 0;
                            flashmovie2 = true;
                            NextFrameFlashMovie2();
                            flashmovie2 = false;
                        }
                    } catch (Error) { }
                    break;
                case 4:
                    try {
                        //flashMovie.Back();
                        Vdeo.currentTime += param;
                        framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                        var frameno = Math.abs(--framediff);
                        //  frameno++;
                        if (framediff == 0) {
                            buttonfourblack.style.display = 'none';
                            buttonfourred.style.display = 'block';
                        }
                        else {
                            buttonfourblack.style.display = 'block';
                            buttonfourred.style.display = 'none';
                        }
                        if (framediff == leftframedifference) {
                            currentclipid = 3;
                            leftframedifference = 0;
                        }

                        //  alert("left frame difference " + framediff);
                    } catch (Error) { }

                    try {
                        //flashMovie1.Back();
                        Vdeo1.currentTime += param;
                        framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                        var frameno1 = Math.abs(--framediff1);
                        if (framediff1 == 0) {
                            buttonfourblack.style.display = 'none';
                            buttonfourred.style.display = 'block';

                        }
                        else {
                            buttonfourblack.style.display = 'block';
                            buttonfourred.style.display = 'none';
                        }
                        if (framediff1 == rightframedifference) {
                            currentclipid = 3;
                            rightframedifference = 0;
                            flashmovie3 = true;
                            NextFrameFlashMovie3();
                            flashmovie3 = false;
                        }
                    } catch (Error) { }
                    break;
                case 5:
                    try {
                        //flashMovie.Back();
                        Vdeo.currentTime += param;
                        framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                        var frameno = Math.abs(--framediff);
                        //  frameno++;
                        if (framediff == 0) {
                            buttonfiveblack.style.display = 'none';
                            buttonfivered.style.display = 'block';
                        }
                        else {
                            buttonfiveblack.style.display = 'block';
                            buttonfivered.style.display = 'none';
                        }
                        if (framediff == leftframedifference) {
                            currentclipid = 4;
                            leftframedifference = 0;
                        }
                    } catch (Error) { }
                    try {
                        //flashMovie1.Back();
                        Vdeo1.currentTime += param;
                        framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                        var frameno1 = Math.abs(--framediff1);
                        if (framediff1 == 0) {
                            buttonfiveblack.style.display = 'none';
                            buttonfivered.style.display = 'block';
                        }
                        else {
                            buttonfiveblack.style.display = 'block';
                            buttonfivered.style.display = 'none';
                        }
                        if (framediff1 == rightframedifference) {
                            currentclipid = 4;
                            rightframedifference = 0;
                            flashmovie4 = true;
                            NextFrameFlashMovie4();
                            flashmovie4 = false;
                        }
                    } catch (Error) { }
                    break;

                case 6:
                    try {
                        //flashMovie.Back();
                        Vdeo.currentTime += param;
                        framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                        var frameno = Math.abs(--framediff);
                        //  frameno++;
                        if (framediff == 0) {
                            buttonsixblack.style.display = 'none';
                            buttonsixred.style.display = 'block';
                        }
                        else {
                            buttonsixblack.style.display = 'block';
                            buttonsixred.style.display = 'none';
                        }
                        if (framediff == leftframedifference) {
                            currentclipid = 5;
                            leftframedifference = 0;
                        }
                        frameBackwardLeft = framediff;
                    } catch (Error) { }

                    try {
                        //flashMovie1.Back();
                        Vdeo1.currentTime += param;
                        framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                        var frameno1 = Math.abs(--framediff1);
                        if (framediff1 == 0) {
                            buttonsixblack.style.display = 'none';
                            buttonsixred.style.display = 'block';
                        }
                        else {
                            buttonsixblack.style.display = 'block';
                            buttonsixred.style.display = 'none';
                        }
                        if (framediff1 == rightframedifference) {
                            currentclipid = 5;
                            rightframedifference = 0;
                            flashmovie5 = true;
                            NextFrameFlashMovie5();
                            flashmovie5 = false;
                        }
                        frameBackwardRight = framediff1;
                    } catch (Error) { }
                    break;

                case 7:
                    try {
                        //flashMovie.Back();
                        Vdeo.currentTime += param;
                        framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                        var frameno = Math.abs(--framediff);
                        //  frameno++;
                        if (framediff == 0) {
                            buttonsevenblack.style.display = 'none';
                            buttonsevenred.style.display = 'block';
                        }
                        else {
                            buttonsevenblack.style.display = 'block';
                            buttonsevenred.style.display = 'none';
                        }
                        if (framediff == leftframedifference) {
                            currentclipid = 6;
                            leftframedifference = 0;
                        }
                        frameBackwardLeft = framediff;
                    } catch (Error) { }

                    try {
                        //flashMovie1.Back();
                        Vdeo1.currentTime += param;
                        framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                        var frameno1 = Math.abs(--framediff1);
                        if (framediff1 == 0) {
                            buttonsevenblack.style.display = 'none';
                            buttonsevenred.style.display = 'block';
                        }
                        else {
                            buttonsevenblack.style.display = 'block';
                            buttonsevenred.style.display = 'none';
                        }
                        if (_selectedLessonId != 2 && _selectedLessonId != 3) {
                            if (framediff1 == rightframedifference) {
                                currentclipid = 6;
                                rightframedifference = 0;
                                flashmovie6 = true;
                                NextFrameFlashMovie6();
                                flashmovie6 = false;
                            }
                        }
                        frameBackwardRight = framediff1;
                    } catch (Error) { }
                    break;

                case 8:
                    try {
                        //flashMovie.Back();
                        Vdeo.currentTime += param;
                        framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                        var frameno = Math.abs(--framediff);
                        //  frameno++;
                        if (framediff == 0) {

                            buttoneightblack.style.display = 'none';
                            buttoneightred.style.display = 'block';
                        }
                        else {
                            buttoneightblack.style.display = 'block';
                            buttoneightred.style.display = 'none';
                        }
                        if (framediff == leftframedifference) {
                            currentclipid = 9;
                            leftframedifference = 0;
                        }
                        frameBackwardLeft = framediff;
                    } catch (Error) { }

                    try {
                        //flashMovie1.Back();
                        Vdeo1.currentTime += param;
                        framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                        var frameno1 = Math.abs(--framediff1);
                        if (framediff1 == 0) {
                            buttoneightblack.style.display = 'none';
                            buttoneightred.style.display = 'block';
                        }
                        else {
                            buttoneightblack.style.display = 'block';
                            buttoneightred.style.display = 'none';

                        }
                        if (framediff1 == rightframedifference) {
                            currentclipid = 9;
                            rightframedifference = 0;
                            flashmovie9 = true;
                            NextFrameFlashMovie9();
                            flashmovie9 = false;
                        }
                        frameBackwardRight = framediff1;
                    } catch (Error) { }
                    break;
            }
        }
        else {
            stop();
            PlayRightButton = false;
        }
    }
    function RewindFlashMovie() {
        flag = false;
        // debugger;
        //        if ((buttonclickedseven && _selectedLessonId == 2) || (_selectedLessonId == 3 && buttonclickedsix) || (_selectedLessonId == 1 && buttonclickedeight)) {

        //            var flashMovie = getFlashMovieObject("movie");
        //            var flashMovie1 = getFlashMovieObject("movie1");
        //            backframe = true;
        //            try {
        //                flashMovie.Back();
        //                backdiff--;

        //            } catch (Error) { }
        //            try {
        //                backdiff1--;
        //                flashMovie1.Back();
        //            } catch (Error) { }
        //        }
        //        else {
        managepositionsForReverseButton(-0.01666667);
        // }
    }
    function managepositionsForForwardButton(param) {
        //  debugger;      
        var Vdeo = document.getElementById("movie");
        var Vdeo1 = document.getElementById("movie1");
        fwdframe = true;

        isvideoRF = false;
        var framerate = 60;
        if (currentclipid)
        //    alert("tofrm1 of forward=" + currentclipid);

            var fromclipid = currentclipid;
        var tolipid = currentclipid - 1;
        errorsRepeated = false;
        var strg1 = Centralfs(tolipid);
        errorsRepeated = true;
        if ((framediff1 == --rightframedifference) || (framediff == --leftframedifference))
        { errorsRepeated = false; }
        var strg2 = Centralfs(fromclipid);

        var Arrstr1 = new Array();
        var Arrstr2 = new Array();

        Arrstr1 = strg1.split(',');
        Arrstr2 = strg2.split(',');

        var tofrm1 = Arrstr1[0];
        var to2frm1 = Arrstr1[1];

        var tofrm2 = Arrstr2[1];
        var to2frm2 = Arrstr2[0];
        leftframedifference = tofrm2 - tofrm1;
        rightframedifference = to2frm2 - to2frm1;
        var buttonfirstblack = document.getElementById('btnFirstBlack');
        var buttonsecondblack = document.getElementById('btnSecondBlack');
        var buttonthirdblack = document.getElementById('btnThirdBlack');
        var buttonfourblack = document.getElementById('btnFourBlack');
        var buttonfiveblack = document.getElementById('btnFiveBlack');
        var buttonsixblack = document.getElementById('btnSixBlack');
        var buttonsevenblack = document.getElementById("<%=btnSeven.ClientID %>");
        var buttoneightblack = document.getElementById("<%=btnEight.ClientID %>");

        var buttonfirstred = document.getElementById('btnFirstRed');
        var buttonsecondred = document.getElementById('btnSecondRed');
        var buttonthirdred = document.getElementById('btnThirdRed');
        var buttonfourred = document.getElementById('btnFourRed');
        var buttonfivered = document.getElementById('btnFiveRed');
        var buttonsixred = document.getElementById('btnSixRed');
        var buttonsevenred = document.getElementById('btnSevenRed');
        var buttoneightred = document.getElementById('btnEightRed');
        if (!PlayRightButton) {
            switch (currentclipid) {
                case 1:
                    // debugger;
                    try {
                        //flashMovie.Forward();
                        Vdeo.currentTime += param;
                        framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                        var frameno = ++framediff;
                        if (framediff == 0) {
                            buttonfirstblack.style.display = 'none';
                            buttonfirstred.style.display = 'block';
                        }
                        else {
                            buttonfirstred.style.display = 'none';
                            buttonfirstblack.style.display = 'block';
                        }
                        if (framediff == leftframedifference) {
                            currentclipid = 2;
                            leftframedifference = 0;
                        }

                    } catch (Error) { }

                    try {
                        // flashMovie1.Forward();
                        Vdeo1.currentTime += param;
                        framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                        var frameno1 = ++framediff1;
                        if (framediff1 == 0) {
                            buttonfirstblack.style.display = 'none';
                            buttonfirstred.style.display = 'block';
                        }
                        else {
                            buttonfirstred.style.display = 'none';
                            buttonfirstblack.style.display = 'block';
                        }
                        if (framediff1 == rightframedifference) {
                            currentclipid = 2;
                            flashmovie2 = true;
                            NextFrameFlashMovie2();
                            flashmovie2 = false;
                            rightframedifference = 0;
                        }

                    } catch (Error) { }
                    break;

                case 2:
                    try {
                        //flashMovie.Forward();
                        Vdeo.currentTime += param;
                        framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                        var frameno = ++framediff;
                        if (framediff == 0) {
                            buttonsecondblack.style.display = 'none';
                            buttonsecondred.style.display = 'block';
                        }
                        else {
                            buttonsecondred.style.display = 'none';
                            buttonsecondblack.style.display = 'block';
                        }
                        if (framediff == leftframedifference) {
                            currentclipid = 3;
                            leftframedifference = 0;
                        }

                    } catch (Error) { }

                    try {
                        //flashMovie1.Forward();
                        Vdeo1.currentTime += param;
                        framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                        var frameno1 = ++framediff1;
                        if (framediff1 == 0) {
                            buttonsecondblack.style.display = 'none';
                            buttonsecondred.style.display = 'block';
                        }
                        else {
                            buttonsecondred.style.display = 'none';
                            buttonsecondblack.style.display = 'block';
                        }
                        if (framediff1 == rightframedifference) {
                            currentclipid = 3;
                            flashmovie3 = true;
                            NextFrameFlashMovie3();
                            flashmovie3 = false;
                            rightframedifference = 0;
                        }
                    } catch (Error) { }
                    break;

                case 3:
                    try {
                        //flashMovie.Forward();
                        Vdeo.currentTime += param;
                        framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                        var frameno = ++framediff;
                        if (framediff == 0) {
                            buttonthirdred.style.display = 'block';
                            buttonthirdblack.style.display = 'none';
                        }
                        else {
                            buttonthirdblack.style.display = 'block';
                            buttonthirdred.style.display = 'none';
                        }
                        if (framediff == leftframedifference) {
                            currentclipid = 4;
                            leftframedifference = 0;
                        }

                        //  alert("forward frame difference " + frameno);
                    } catch (Error) { }

                    try {
                        //flashMovie1.Forward();
                        Vdeo1.currentTime += param;
                        framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                        var frameno1 = ++framediff1;
                        if (framediff1 == 0) {
                            buttonthirdred.style.display = 'block';
                            buttonthirdblack.style.display = 'none';
                        }
                        else {
                            buttonthirdblack.style.display = 'block';
                            buttonthirdred.style.display = 'none';
                        }
                        if (framediff1 == rightframedifference) {
                            currentclipid = 4;
                            flashmovie4 = true;
                            // errorsRepeated = false;                        
                            NextFrameFlashMovie4();
                            flashmovie4 = false;
                            rightframedifference = 0;
                        }

                    } catch (Error) { }
                    break;

                case 4:
                    try {
                        //flashMovie.Forward();
                        Vdeo.currentTime += param;
                        framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                        var frameno = ++framediff;
                        if (framediff == 0) {
                            buttonfourred.style.display = 'block';
                            buttonfourblack.style.display = 'none';
                        }
                        else {
                            buttonfourblack.style.display = 'block';
                            buttonfourred.style.display = 'none';
                        }
                        if (framediff == leftframedifference) {
                            currentclipid = 5;
                            leftframedifference = 0;
                        }

                    } catch (Error) { }

                    try {
                        // flashMovie1.Forward();
                        Vdeo1.currentTime += param;
                        framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                        var frameno1 = ++framediff1;
                        if (framediff1 == 0) {
                            buttonfourred.style.display = 'block';
                            buttonfourblack.style.display = 'none';
                        }
                        else {
                            buttonfourblack.style.display = 'block';
                            buttonfourred.style.display = 'none';
                        }
                        if (framediff1 == rightframedifference) {
                            currentclipid = 5;
                            flashmovie5 = true;
                            NextFrameFlashMovie5();
                            flashmovie5 = false;
                            rightframedifference = 0;
                        }

                    } catch (Error) { }
                    break;


                case 5:
                    try {
                        //flashMovie.Forward();
                        Vdeo.currentTime += param;
                        framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                        var frameno = ++framediff;
                        if (framediff == 0) {
                            buttonfivered.style.display = 'block';
                            buttonfiveblack.style.display = 'none';
                        }
                        else {
                            buttonfiveblack.style.display = 'block';
                            buttonfivered.style.display = 'none';
                        }
                        if (framediff == leftframedifference) {
                            currentclipid = 6;
                            leftframedifference = 0;
                        }

                    } catch (Error) { }

                    try {
                        //flashMovie1.Forward();
                        Vdeo1.currentTime += param;
                        framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                        var frameno1 = ++framediff1;
                        if (framediff1 == 0) {
                            buttonfivered.style.display = 'block';
                            buttonfiveblack.style.display = 'none';
                        }
                        else {
                            buttonfiveblack.style.display = 'block';
                            buttonfivered.style.display = 'none';
                        }
                        if (framediff1 == rightframedifference) {
                            currentclipid = 6;
                            flashmovie6 = true;
                            NextFrameFlashMovie6();
                            flashmovie6 = false;
                            rightframedifference = 0;
                        }

                    } catch (Error) { }

                    break;

                case 6:
                    // debugger;
                    if (_selectedLessonId == 3) {
                        if (frameBackwardLeft < 0 || frameBackwardRight < 0) {
                            try {
                                // flashMovie.Forward();
                                Vdeo.currentTime += param;
                                framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                                var frameno = ++framediff;
                                if (framediff == 0) {
                                    buttonsixred.style.display = 'block';
                                    buttonsixblack.style.display = 'none';
                                }
                                else {
                                    buttonsixblack.style.display = 'block';
                                    buttonsixred.style.display = 'none';
                                }
                                if (framediff == leftframedifference) {
                                    currentclipid = 7;
                                    leftframedifference = 0;
                                }
                                frameBackwardLeft = framediff;

                            } catch (Error) { }

                            try {
                                //flashMovie1.Forward();
                                Vdeo1.currentTime += param;
                                framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                                var frameno1 = ++framediff1;
                                if (framediff1 == 0) {
                                    buttonsixred.style.display = 'block';
                                    buttonsixblack.style.display = 'none';
                                }
                                else {
                                    buttonsixblack.style.display = 'block';
                                    buttonsixred.style.display = 'none';

                                }
                                if (framediff1 == rightframedifference) {
                                    currentclipid = 7;
                                    flashmovie7 = true;
                                    NextFrameFlashMovie7();
                                    flashmovie7 = false;
                                    rightframedifference = 0;
                                }
                                frameBackwardRight = framediff1;
                            } catch (Error) { }
                        }
                    }
                    else {
                        try {
                            // flashMovie.Forward();
                            Vdeo.currentTime += param;
                            framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                            var frameno = ++framediff;
                            if (framediff == 0) {
                                buttonsixred.style.display = 'block';
                                buttonsixblack.style.display = 'none';
                            }
                            else {
                                buttonsixblack.style.display = 'block';
                                buttonsixred.style.display = 'none';
                            }
                            if (framediff == leftframedifference) {
                                currentclipid = 7;
                                leftframedifference = 0;
                            }
                            // frameBackwardLeft = framediff;

                        } catch (Error) { }

                        try {
                            //flashMovie1.Forward();
                            Vdeo1.currentTime += param;
                            framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                            var frameno1 = ++framediff1;
                            if (framediff1 == 0) {
                                buttonsixred.style.display = 'block';
                                buttonsixblack.style.display = 'none';
                            }
                            else {
                                buttonsixblack.style.display = 'block';
                                buttonsixred.style.display = 'none';
                            }
                            if (framediff1 == rightframedifference) {
                                currentclipid = 7;
                                flashmovie7 = true;
                                NextFrameFlashMovie7();
                                flashmovie7 = false;
                                rightframedifference = 0;
                            }
                            // frameBackwardRight = framediff1;
                        } catch (Error) { }
                    }
                    break;

                case 7:
                    // debugger;
                    if (_selectedLessonId == 2) {
                        if (frameBackwardLeft < 0 || frameBackwardRight < 0) {
                            // debugger;
                            //  if (frameBackwardLeft < 0 || frameBackwardRight < 0) {
                            //if (_selectedLessonId != 2 && _selectedLessonId != 3) {
                            try {
                                // flashMovie.Forward();
                                Vdeo.currentTime += param;
                                framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                                var frameno = ++framediff;
                                if (framediff == 0) {
                                    buttonsevenred.style.display = 'block';
                                    buttonsevenblack.style.display = 'none';
                                }
                                else {
                                    buttonsevenblack.style.display = 'block';
                                    buttonsevenred.style.display = 'none';
                                }
                                if (framediff == leftframedifference) {
                                    currentclipid = 8;
                                    leftframedifference = 0;
                                }
                                frameBackwardLeft = framediff;
                            } catch (Error) { }

                            try {
                                //flashMovie1.Forward();
                                Vdeo1.currentTime += param;
                                framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                                var frameno1 = ++framediff1;
                                if (framediff1 == 0) {
                                    buttonsevenred.style.display = 'block';
                                    buttonsevenblack.style.display = 'none';
                                }
                                else {
                                    buttonsevenblack.style.display = 'block';
                                    buttonsevenred.style.display = 'none';
                                }
                                if (_selectedLessonId != 2 && _selectedLessonId != 3) {
                                    if (framediff1 == rightframedifference) {
                                        currentclipid = 8;
                                        flashmovie8 = true;
                                        NextFrameFlashMovie8();
                                        flashmovie8 = false;
                                        rightframedifference = 0;
                                    }
                                }
                                frameBackwardRight = framediff1;
                            } catch (Error) { }
                        }
                    }
                    else {
                        try {
                            // flashMovie.Forward();
                            Vdeo.currentTime += param;
                            framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                            var frameno = ++framediff;
                            if (framediff == 0) {
                                buttonsevenred.style.display = 'block';
                                buttonsevenblack.style.display = 'none';
                            }
                            else {
                                buttonsevenblack.style.display = 'block';
                                buttonsevenred.style.display = 'none';
                            }
                            if (framediff == leftframedifference) {
                                currentclipid = 8;
                                leftframedifference = 0;
                            }
                            frameBackwardLeft = framediff;
                        } catch (Error) { }

                        try {
                            //flashMovie1.Forward();
                            Vdeo1.currentTime += param;
                            framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                            var frameno1 = ++framediff1;
                            if (framediff1 == 0) {
                                buttonsevenred.style.display = 'block';
                                buttonsevenblack.style.display = 'none';
                            }
                            else {
                                buttonsevenblack.style.display = 'block';
                                buttonsevenred.style.display = 'none';
                            }
                            if (_selectedLessonId != 2 && _selectedLessonId != 3) {
                                if (framediff1 == rightframedifference) {
                                    currentclipid = 8;
                                    flashmovie8 = true;
                                    NextFrameFlashMovie8();
                                    flashmovie8 = false;
                                    rightframedifference = 0;
                                }
                            }
                            frameBackwardRight = framediff1;
                        } catch (Error) { }
                    }
                    break;

                case 8:
                    if (frameBackwardLeft < 0 || frameBackwardRight < 0) {
                        // if (_selectedLessonId != 1) {
                        try {
                            //flashMovie.Forward();
                            Vdeo.currentTime += param;
                            framecount = parseInt(Vdeo.currentTime * framerate).toFixed(0);
                            var frameno = ++framediff;
                            if (framediff == 0) {
                                buttoneightred.style.display = 'block';
                                buttoneightblack.style.display = 'none';
                            }
                            else {
                                buttoneightblack.style.display = 'block';
                                buttoneightred.style.display = 'none';
                            }
                            if (framediff == leftframedifference) {
                                currentclipid = 9;
                                leftframedifference = 0;
                            }
                            frameBackwardLeft = framediff;
                        } catch (Error) { }

                        try {
                            // flashMovie1.Forward();
                            Vdeo1.currentTime += param;
                            framecount = parseInt(Vdeo1.currentTime * framerate).toFixed(0);
                            var frameno1 = ++framediff1;
                            if (framediff1 == 0) {
                                buttoneightred.style.display = 'block';
                                buttoneightblack.style.display = 'none';
                            }
                            else {
                                buttoneightblack.style.display = 'block';
                                buttoneightred.style.display = 'none';
                            }
                            if (framediff1 == rightframedifference) {
                                currentclipid = 9;
                                flashmovie9 = true;
                                NextFrameFlashMovie9();
                                flashmovie9 = false;
                                rightframedifference = 0;
                            }
                            frameBackwardRight = framediff1;
                        } catch (Error) { }
                        break;
                    }
            }
        }
        else {
            stop();
            PlayRightButton = false;
        }
    }
    function forwardFlashMovie() {
        var flashMovie = getFlashMovieObject("movie");
        var flashMovie1 = getFlashMovieObject("movie1");
        flag = false;
        _selectedLessonId = document.getElementById("<%=DropDownList2.ClientID %>").value;
        managepositionsForForwardButton(0.01666667);
    }
    function PausesumMovieFlashMovie() {
        var pausemovie = document.getElementById('sumMovie');
        if (pausemovie != null) {
            pausemovie.pause();
        }
    }
    function PlaysumMovieFlashMovie() {
        //debugger;
        var flashMovie2 = document.getElementById('sumMovie');
        if (flashMovie2 != null) {
            flashMovie2.play();
        }
        //embed.nativeProperty.anotherNativeMethod();
    }
    function StopsumMovieFlashMovie() {
        var flashMovie2 = document.getElementById('sumMovie');
        if (flashMovie2 != null) {
            flashMovie2.currentTime = 0;
            flashMovie2.pause();
        }
    }

    function PositioningButtons() {
        var buttonfirstblack = document.getElementById('btnFirstBlack');
        var buttonsecondblack = document.getElementById('btnSecondBlack');
        var buttonthirdblack = document.getElementById('btnThirdBlack');
        var buttonfourblack = document.getElementById('btnFourBlack');
        var buttonfiveblack = document.getElementById('btnFiveBlack');
        var buttonsixblack = document.getElementById('btnSixBlack');
        var buttonsevenblack = document.getElementById("<%=btnSeven.ClientID %>");
        var buttoneightblack = document.getElementById("<%=btnEight.ClientID %>");

        var buttonfirstred = document.getElementById('btnFirstRed');
        var buttonsecondred = document.getElementById('btnSecondRed');
        var buttonthirdred = document.getElementById('btnThirdRed');
        var buttonfourred = document.getElementById('btnFourRed');
        var buttonfivered = document.getElementById('btnFiveRed');
        var buttonsixred = document.getElementById('btnSixRed');
        var buttonsevenred = document.getElementById('btnSevenRed');
        var buttoneightred = document.getElementById('btnEightRed');

        buttonfirstblack.style.marginBottom = '4px';
        buttonsecondblack.style.marginBottom = '4px';
        buttonthirdblack.style.marginBottom = '4px';
        buttonfourblack.style.marginBottom = '4px';
        buttonfiveblack.style.marginBottom = '4px';
        buttonsixblack.style.marginBottom = '4px';
        buttonsevenblack.style.marginBottom = '4px';
        buttoneightblack.style.marginBottom = '4px';

        buttonfirstred.style.marginBottom = '4px';
        buttonsecondred.style.marginBottom = '4px';
        buttonthirdred.style.marginBottom = '4px';
        buttonfourred.style.marginBottom = '4px';
        buttonfivered.style.marginBottom = '4px';
        buttonsixred.style.marginBottom = '4px';
        buttoneightred.style.marginBottom = '4px';
        buttonsevenred.style.marginBottom = '4px';
    }

    function CheckForLessonSelected(lessontypeid) {
        // debugger;
        var buttoneightred = document.getElementById('btnEightRed');
        var buttoneightblack = document.getElementById("<%=btnEight.ClientID %>");
        var buttonsevenblack = document.getElementById("<%=btnSeven.ClientID %>");
        var buttonsevenred = document.getElementById('btnSevenRed');
        if (lessontypeid == 1) {
            buttoneightblack.style.display = 'block';
            buttonsevenblack.style.display = 'block';
            buttonsevenred.style.display = 'none';
            buttoneightred.style.display = 'none';
        }
        else if (lessontypeid == 2) {
            buttoneightblack.style.display = 'none';
            buttoneightred.style.display = 'none';
            buttonsevenblack.style.display = 'block';
            buttonsevenred.style.display = 'none';
        }

        else if (lessontypeid == 6) {
            buttoneightblack.style.display = 'none';
            buttoneightred.style.display = 'none';
            buttonsevenblack.style.display = 'block';
            buttonsevenred.style.display = 'none';
        }
        else {
            buttonsevenred.style.display = 'none';
            buttoneightblack.style.display = 'none';
            buttoneightred.style.display = 'none';
            buttonsevenblack.style.display = 'none';
        }
    }

    function NextFrameFlashMovie1() {
        // debugger;
        if (!flashmovie1) {
            FunctionForAllBtns(0);
        }
        _selectedLessonId = document.getElementById("<%=DropDownList2.ClientID %>").value;

        var buttonfirstblack = document.getElementById('btnFirstBlack');
        var buttonsecondblack = document.getElementById('btnSecondBlack');
        var buttonthirdblack = document.getElementById('btnThirdBlack');
        var buttonfourblack = document.getElementById('btnFourBlack');
        var buttonfiveblack = document.getElementById('btnFiveBlack');
        var buttonsixblack = document.getElementById('btnSixBlack');
        var buttonsevenblack = document.getElementById("<%=btnSeven.ClientID %>");
        var buttoneightblack = document.getElementById("<%=btnEight.ClientID %>");


        var buttonfirstred = document.getElementById('btnFirstRed');
        var buttonsecondred = document.getElementById('btnSecondRed');
        var buttonthirdred = document.getElementById('btnThirdRed');
        var buttonfourred = document.getElementById('btnFourRed');
        var buttonfivered = document.getElementById('btnFiveRed');
        var buttonsixred = document.getElementById('btnSixRed');
        var buttonsevenred = document.getElementById('btnSevenRed');
        var buttoneightred = document.getElementById('btnEightRed');

        buttonfirstred.style.display = 'block';
        buttonfirstblack.style.display = 'none';
        buttonsecondred.style.display = 'none';
        buttonsecondblack.style.display = 'block';
        buttonthirdred.style.display = 'none';
        buttonthirdblack.style.display = 'block';
        buttonfourred.style.display = 'none';
        buttonfourblack.style.display = 'block';
        buttonfivered.style.display = 'none';
        buttonfiveblack.style.display = 'block';
        buttonsixred.style.display = 'none';
        buttonsixblack.style.display = 'block';
        CheckForLessonSelected(_selectedLessonId);
        PositioningButtons();
        framediff = 0;
        framediff1 = 0;
    }
    function NextFrameFlashMovie2() {
        if (!flashmovie2) {
            FunctionForAllBtns(1);
        }
        _selectedLessonId = document.getElementById("<%=DropDownList2.ClientID %>").value;
        var buttonfirstblack = document.getElementById('btnFirstBlack');
        var buttonsecondblack = document.getElementById('btnSecondBlack');
        var buttonthirdblack = document.getElementById('btnThirdBlack');
        var buttonfourblack = document.getElementById('btnFourBlack');
        var buttonfiveblack = document.getElementById('btnFiveBlack');
        var buttonsixblack = document.getElementById('btnSixBlack');
        var buttonsevenblack = document.getElementById("<%=btnSeven.ClientID %>");
        var buttoneightblack = document.getElementById("<%=btnEight.ClientID %>");

        var buttonfirstred = document.getElementById('btnFirstRed');
        var buttonsecondred = document.getElementById('btnSecondRed');
        var buttonthirdred = document.getElementById('btnThirdRed');
        var buttonfourred = document.getElementById('btnFourRed');
        var buttonfivered = document.getElementById('btnFiveRed');
        var buttonsixred = document.getElementById('btnSixRed');
        var buttonsevenred = document.getElementById('btnSevenRed');
        var buttoneightred = document.getElementById('btnEightRed');

        buttonfirstred.style.display = 'none';
        buttonfirstblack.style.display = 'block';
        buttonsecondred.style.display = 'block';
        buttonsecondblack.style.display = 'none';
        buttonthirdred.style.display = 'none';
        buttonthirdblack.style.display = 'block';
        buttonfourred.style.display = 'none';
        buttonfourblack.style.display = 'block';
        buttonfivered.style.display = 'none';
        buttonfiveblack.style.display = 'block';
        buttonsixred.style.display = 'none';
        buttonsixblack.style.display = 'block';
        CheckForLessonSelected(_selectedLessonId);
        PositioningButtons();
        framediff = 0;
        framediff1 = 0;
    }
    function NextFrameFlashMovie3() {

        if (!flashmovie3) {
            FunctionForAllBtns(2);
        }
        _selectedLessonId = document.getElementById("<%=DropDownList2.ClientID %>").value;
        var buttonfirstblack = document.getElementById('btnFirstBlack');
        var buttonsecondblack = document.getElementById('btnSecondBlack');
        var buttonthirdblack = document.getElementById('btnThirdBlack');
        var buttonfourblack = document.getElementById('btnFourBlack');
        var buttonfiveblack = document.getElementById('btnFiveBlack');
        var buttonsixblack = document.getElementById('btnSixBlack');
        var buttonsevenblack = document.getElementById("<%=btnSeven.ClientID %>");
        var buttoneightblack = document.getElementById("<%=btnEight.ClientID %>");

        var buttonfirstred = document.getElementById('btnFirstRed');
        var buttonsecondred = document.getElementById('btnSecondRed');
        var buttonthirdred = document.getElementById('btnThirdRed');
        var buttonfourred = document.getElementById('btnFourRed');
        var buttonfivered = document.getElementById('btnFiveRed');
        var buttonsixred = document.getElementById('btnSixRed');
        var buttonsevenred = document.getElementById('btnSevenRed');
        var buttoneightred = document.getElementById('btnEightRed');

        buttonfirstred.style.display = 'none';
        buttonfirstblack.style.display = 'block';
        buttonsecondred.style.display = 'none';
        buttonsecondblack.style.display = 'block';
        buttonthirdred.style.display = 'block';
        buttonthirdblack.style.display = 'none';
        buttonfourred.style.display = 'none';
        buttonfourblack.style.display = 'block';
        buttonfivered.style.display = 'none';
        buttonfiveblack.style.display = 'block';
        buttonsixred.style.display = 'none';
        buttonsixblack.style.display = 'block';
        CheckForLessonSelected(_selectedLessonId);
        PositioningButtons();
        framediff = 0;
        framediff1 = 0;
    }
    function NextFrameFlashMovie4() {
        //debugger;
        if (!flashmovie4) {
            FunctionForAllBtns(3);
        }
        _selectedLessonId = document.getElementById("<%=DropDownList2.ClientID %>").value;
        var buttonfirstblack = document.getElementById('btnFirstBlack');
        var buttonsecondblack = document.getElementById('btnSecondBlack');
        var buttonthirdblack = document.getElementById('btnThirdBlack');
        var buttonfourblack = document.getElementById('btnFourBlack');
        var buttonfiveblack = document.getElementById('btnFiveBlack');
        var buttonsixblack = document.getElementById('btnSixBlack');
        var buttonsevenblack = document.getElementById("<%=btnSeven.ClientID %>");
        var buttoneightblack = document.getElementById("<%=btnEight.ClientID %>");

        var buttonfirstred = document.getElementById('btnFirstRed');
        var buttonsecondred = document.getElementById('btnSecondRed');
        var buttonthirdred = document.getElementById('btnThirdRed');
        var buttonfourred = document.getElementById('btnFourRed');
        var buttonfivered = document.getElementById('btnFiveRed');
        var buttonsixred = document.getElementById('btnSixRed');
        var buttonsevenred = document.getElementById('btnSevenRed');
        var buttoneightred = document.getElementById('btnEightRed');

        buttonfirstred.style.display = 'none';
        buttonfirstblack.style.display = 'block';
        buttonsecondred.style.display = 'none';
        buttonsecondblack.style.display = 'block';
        buttonthirdred.style.display = 'none';
        buttonthirdblack.style.display = 'block';
        buttonfourred.style.display = 'block';
        buttonfourblack.style.display = 'none';
        buttonfivered.style.display = 'none';
        buttonfiveblack.style.display = 'block';
        buttonsixred.style.display = 'none';
        buttonsixblack.style.display = 'block';
        CheckForLessonSelected(_selectedLessonId);
        PositioningButtons();
        framediff = 0;
        framediff1 = 0;
    }
    function NextFrameFlashMovie5() {
        if (!flashmovie5) {
            FunctionForAllBtns(4);
        }
        _selectedLessonId = document.getElementById("<%=DropDownList2.ClientID %>").value;
        var buttonfirstblack = document.getElementById('btnFirstBlack');
        var buttonsecondblack = document.getElementById('btnSecondBlack');
        var buttonthirdblack = document.getElementById('btnThirdBlack');
        var buttonfourblack = document.getElementById('btnFourBlack');
        var buttonfiveblack = document.getElementById('btnFiveBlack');
        var buttonsixblack = document.getElementById('btnSixBlack');
        var buttonsevenblack = document.getElementById("<%=btnSeven.ClientID %>");
        var buttoneightblack = document.getElementById("<%=btnEight.ClientID %>");

        var buttonfirstred = document.getElementById('btnFirstRed');
        var buttonsecondred = document.getElementById('btnSecondRed');
        var buttonthirdred = document.getElementById('btnThirdRed');
        var buttonfourred = document.getElementById('btnFourRed');
        var buttonfivered = document.getElementById('btnFiveRed');
        var buttonsixred = document.getElementById('btnSixRed');
        var buttonsevenred = document.getElementById('btnSevenRed');
        var buttoneightred = document.getElementById('btnEightRed');

        buttonfirstred.style.display = 'none';
        buttonfirstblack.style.display = 'block';
        buttonsecondred.style.display = 'none';
        buttonsecondblack.style.display = 'block';
        buttonthirdred.style.display = 'none';
        buttonthirdblack.style.display = 'block';
        buttonfourred.style.display = 'none';
        buttonfourblack.style.display = 'block';
        buttonfivered.style.display = 'block';
        buttonfiveblack.style.display = 'none';
        buttonsixred.style.display = 'none';
        buttonsixblack.style.display = 'block';
        CheckForLessonSelected(_selectedLessonId);
        PositioningButtons();
        framediff = 0;
        framediff1 = 0;
    }
    function NextFrameFlashMovie6() {
        if (!flashmovie6) {
            FunctionForAllBtns(5);
        }
        _selectedLessonId = document.getElementById("<%=DropDownList2.ClientID %>").value;
        var buttonfirstblack = document.getElementById('btnFirstBlack');
        var buttonsecondblack = document.getElementById('btnSecondBlack');
        var buttonthirdblack = document.getElementById('btnThirdBlack');
        var buttonfourblack = document.getElementById('btnFourBlack');
        var buttonfiveblack = document.getElementById('btnFiveBlack');
        var buttonsixblack = document.getElementById('btnSixBlack');
        var buttonsevenblack = document.getElementById("<%=btnSeven.ClientID %>");
        var buttoneightblack = document.getElementById("<%=btnEight.ClientID %>");

        var buttonfirstred = document.getElementById('btnFirstRed');
        var buttonsecondred = document.getElementById('btnSecondRed');
        var buttonthirdred = document.getElementById('btnThirdRed');
        var buttonfourred = document.getElementById('btnFourRed');
        var buttonfivered = document.getElementById('btnFiveRed');
        var buttonsixred = document.getElementById('btnSixRed');
        var buttonsevenred = document.getElementById('btnSevenRed');
        var buttoneightred = document.getElementById('btnEightRed');

        buttonfirstred.style.display = 'none';
        buttonfirstblack.style.display = 'block';
        buttonsecondred.style.display = 'none';
        buttonsecondblack.style.display = 'block';
        buttonthirdred.style.display = 'none';
        buttonthirdblack.style.display = 'block';
        buttonfourred.style.display = 'none';
        buttonfourblack.style.display = 'block';
        buttonfivered.style.display = 'none';
        buttonfiveblack.style.display = 'block';
        buttonsixred.style.display = 'block';
        buttonsixblack.style.display = 'none';
        CheckForLessonSelected(_selectedLessonId);
        PositioningButtons();
        framediff = 0;
        framediff1 = 0;
    }
    function NextFrameFlashMovie7() {
        if (!flashmovie7) {
            FunctionForAllBtns(6);
        }
        var buttonclicked_seven = true;
        _selectedLessonId = document.getElementById("<%=DropDownList2.ClientID %>").value;
        var buttonfirstblack = document.getElementById('btnFirstBlack');
        var buttonsecondblack = document.getElementById('btnSecondBlack');
        var buttonthirdblack = document.getElementById('btnThirdBlack');
        var buttonfourblack = document.getElementById('btnFourBlack');
        var buttonfiveblack = document.getElementById('btnFiveBlack');
        var buttonsixblack = document.getElementById('btnSixBlack');
        var buttonsevenblack = document.getElementById("<%=btnSeven.ClientID %>");
        var buttoneightblack = document.getElementById("<%=btnEight.ClientID %>");

        var buttonfirstred = document.getElementById('btnFirstRed');
        var buttonsecondred = document.getElementById('btnSecondRed');
        var buttonthirdred = document.getElementById('btnThirdRed');
        var buttonfourred = document.getElementById('btnFourRed');
        var buttonfivered = document.getElementById('btnFiveRed');
        var buttonsixred = document.getElementById('btnSixRed');
        var buttonsevenred = document.getElementById('btnSevenRed');
        var buttoneightred = document.getElementById('btnEightRed');

        buttonfirstred.style.display = 'none';
        buttonfirstblack.style.display = 'block';
        buttonsecondred.style.display = 'none';
        buttonsecondblack.style.display = 'block';
        buttonthirdred.style.display = 'none';
        buttonthirdblack.style.display = 'block';
        buttonfourred.style.display = 'none';
        buttonfourblack.style.display = 'block';
        buttonfivered.style.display = 'none';
        buttonfiveblack.style.display = 'block';
        buttonsixred.style.display = 'none';
        buttonsixblack.style.display = 'block';

        if (_selectedLessonId == 2) {
            buttonsevenred.style.display = 'block';
            buttoneightred.style.display = 'none';
            buttoneightblack.style.display = 'none';
            buttonsevenblack.style.display = 'none';
        }
        else if (_selectedLessonId == 1) {
            buttoneightred.style.display = 'none';
            buttonsevenred.style.display = 'block';
            buttoneightblack.style.display = 'block';
            buttonsevenblack.style.display = 'none';
        }
        else
            if (_selectedLessonId == 6) {
                buttonsevenred.style.display = 'block';
                buttoneightred.style.display = 'none';
                buttoneightblack.style.display = 'none';
                buttonsevenblack.style.display = 'none';
            }
            else {
                buttoneightred.style.display = 'none';
                buttoneightblack.style.display = 'none';
                buttonsevenblack.style.display = 'none';
                buttonsevenred.style.display = 'none';
            }
        PositioningButtons();
        framediff = 0;
        framediff1 = 0;
    }
    function NextFrameFlashMovie8() {
        if (!flashmovie8) {
            FunctionForAllBtns(7);
        }
        _selectedLessonId = document.getElementById("<%=DropDownList2.ClientID %>").value;
        var buttonfirstblack = document.getElementById('btnFirstBlack');
        var buttonsecondblack = document.getElementById('btnSecondBlack');
        var buttonthirdblack = document.getElementById('btnThirdBlack');
        var buttonfourblack = document.getElementById('btnFourBlack');
        var buttonfiveblack = document.getElementById('btnFiveBlack');
        var buttonsixblack = document.getElementById('btnSixBlack');
        var buttonsevenblack = document.getElementById("<%=btnSeven.ClientID %>");
        var buttoneightblack = document.getElementById("<%=btnEight.ClientID %>");

        var buttonfirstred = document.getElementById('btnFirstRed');
        var buttonsecondred = document.getElementById('btnSecondRed');
        var buttonthirdred = document.getElementById('btnThirdRed');
        var buttonfourred = document.getElementById('btnFourRed');
        var buttonfivered = document.getElementById('btnFiveRed');
        var buttonsixred = document.getElementById('btnSixRed');
        var buttonsevenred = document.getElementById('btnSevenRed');
        var buttoneightred = document.getElementById('btnEightRed');

        buttonfirstred.style.display = 'none';
        buttonfirstblack.style.display = 'block';
        buttonsecondred.style.display = 'none';
        buttonsecondblack.style.display = 'block';
        buttonthirdred.style.display = 'none';
        buttonthirdblack.style.display = 'block';
        buttonfourred.style.display = 'none';
        buttonfourblack.style.display = 'block';
        buttonfivered.style.display = 'none';
        buttonfiveblack.style.display = 'block';
        buttonsixred.style.display = 'none';
        buttonsixblack.style.display = 'block';
        buttoneightblack.style.display = 'none';
        buttoneightred.style.display = 'block';
        buttonsevenred.style.display = 'none';
        buttonsevenblack.style.display = 'block';
        PositioningButtons();
        framediff = 0;
        framediff1 = 0;
    }
    function NextFrameFlashMovie9() {
        FunctionForAllBtns(8);
    }
    function NextFrameFlashMovie10() {
        FunctionForAllBtns(9);
    }
    function ButtonsRedOnPlay(clipid) {
        //debugger;
        var currentclipnumber = clipid;
        _selectedLessonId = document.getElementById("<%=DropDownList2.ClientID %>").value;

        switch (currentclipnumber) {
            case 1:
                flashmovie1 = true;
                NextFrameFlashMovie1();
                flashmovie1 = false;
                break;
            case 2:
                flashmovie2 = true;
                NextFrameFlashMovie2();
                flashmovie2 = false;
                break;
            case 3:
                flashmovie3 = true;
                NextFrameFlashMovie3();
                flashmovie3 = false;
                break;
            case 4:
                flashmovie4 = true;
                NextFrameFlashMovie4();
                flashmovie4 = false;
                break;
            case 5:
                flashmovie5 = true;
                NextFrameFlashMovie5();
                flashmovie5 = false;
                break;
            case 6:
                flashmovie6 = true;
                NextFrameFlashMovie6();
                flashmovie6 = false;
                break;
            case 7:
                if (_selectedLessonId != 3) {
                    flashmovie7 = true;
                    NextFrameFlashMovie7();
                    flashmovie7 = false;
                }
                break;
            case 8:
                if (_selectedLessonId != 2 && _selectedLessonId != 3) {
                    flashmovie8 = true;
                    NextFrameFlashMovie8();
                    flashmovie8 = false;
                }
                break;
        }
    }

    function MakeSummaryVisible() {
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1151px';
        }
        //Check if summay video loaded
        //		tempSummaryCount = 0;
        //		document.getElementById("summaryVideoDivMask").className = 'maskdiv';
        //		checkIfSummaryVideoLoaded();
    }
    function MakeStartHeight() {
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '2290px';
        }
    }
    function MakeStartComparisonHeight() {
        //debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1630px';
        }
    }
    function MakeStartNonTiresHeight() {
        //debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1650px';
        }
    }
    function MakeStartNoSummaryHeight() {

        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1740px';
        }
    }
    function MakeSprintHeight() {
        //debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1990px';
        }
    }
    //new code 06-12-2019
    function myFunction() {
        alert("No Sessions found for this Athlete.");
        location.href = 'SelectMember.aspx';
    }
    function MakeHurdleStepsHeight() {
        //debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1990px';
        }
    }
    function MakeSprintHeightForFireFox() {
        //debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1890px';
        }
    }
    function MakeSprintComparisonHeight() {
        //debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1390px';
        }
    }
    function MakeSprintComparisonHeightForFireFox() {
        //debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1290px';
        }
    }
    function MakeSprintNonTiresHeight() {
        //debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1200px';
        }
    }
    function MakeSprintNonTiresHeightForFireFox() {
        //debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1300px';
        }
    }
    function MakeSprintNoSummaryHeight() {

        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1400px';
        }
    }
    function MakeHurdleHeight() {
        // debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1690px';
        }
    }
    function MakeHurdleComparisonHeight() {
        //debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '990px';
        }
    }
    function MakeHurdleNonTiresHeight() {
        //  debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1000px';
        }
    }
    function MakeHurdleNoSummaryHeight() {

        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1060px';
        }
    }

    function MakeSummaryInvisible() {
        // debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1px';
            //var sprinid=document.getElementById('SprintId');
            //sprinid.style.display = 'none';
        }
    }
    function AlertMessage() {
        alert("Only the Primary Coach Can Request Videos");
    }
    function OpenHelpWindow(URL) {
        var popWindow = window.showModalDialog(URL, null, "dialogWidth: 800px; dialogHeight: 600px; center: yes; resizable: no; scroll: yes; status: no;");
    }


    function OpenVariablePopup(URL) {

        //myFunction();
        //document.getElementById("show").style.display="none";
        var popWindow = window.showModalDialog(URL, null, "dialogWidth: 800px; dialogHeight: 600px; center: yes; resizable: no; scroll: yes; status: no;");
        //myFunction(); 

    }

    function getFlashMovieObject(movieName) {
        //        if (window.document[moviename]) {
        //            return window.document[moviename];
        //        }

        if (navigator.appName.indexOf("Microsoft Internet") == -1) {
            if (document.embeds && document.embeds[movieName])
                return document.embeds[movieName];
        }
        else // if (navigator.appName.indexOf("Microsoft Internet")!=-1)
        {
            return document.getElementById(movieName);
        }
    }
    function getValueByAJAX(ajaxParameter, ajaxFilePath) {// use executeAjaxMethod method here
        var req = null;
        // branch for native XMLHttpRequest object

        if (window.XMLHttpRequest && !(window.ActiveXObject)) {
            try {
                req = new XMLHttpRequest();
            } catch (e) {
                req = null;
            }
            // branch for IE/Windows ActiveX version
        } else if (window.ActiveXObject) {
            try {
                req = new ActiveXObject("Msxml2.XMLHTTP");
            } catch (e) {
                try {
                    req = new ActiveXObject("Microsoft.XMLHTTP");
                } catch (e) {
                    req = null;
                }
            }
        }

        if (req) {
            req.open("POST", ajaxFilePath, true);
            req.send("AJAX:" + ajaxParameter);
            try {
                return req.responseText;
            }
            catch (Error) { }
        }


        return null;
    }

    //    window.onload = function() {
    //            var flashMovie = getFlashMovieObject("movie");
    //            var flashMovie1 = getFlashMovieObject("movie1");

    //            var currentFrame = flashMovie.TGetProperty("/", 5);
    //            if (currentFrame) {
    //            }
    //            else {

    //                alert('A problem with one of your video files has been detected.  We will notify you when it has been resolved');
    //            }

    //    } 


    // window.onload = function() {
    //        var flashMovie = getFlashMovieObject("movie");
    //        var flashMovie1 = getFlashMovieObject("movie1");

    //        var currentFrame = flashMovie.TGetProperty("/", 5);
    //        if (currentFrame) {


    //        }
    //        else {
    //            SendEmailOnBadSWF("FileName");     
    //                var isfile = confirm('A problem with one of your video files has been detected. We will notify you when it has been resolved');
    //        }
    //        //document.getElementById("<%=HiddenField1.ClientID %>").value = currentFrame;

    //    }
    //    
    //    function SendEmailOnBadSWF(fileName) {
    //            var arrControl = new Array();
    //            arrControl[0] = '<%=HiddenField1.Value %>';
    //            arrControl[1] = '<%=HiddenField2.Value %>';

    //            var msg = getValueByAJAX(arrControl, '../Ajax/EmailForVideo.aspx');
    //            if (msg != 'True' && msg != 'False') {
    //                //alert(msg);
    //                return false;
    //            }
    //            else {
    //            }

    //            return true;
    //        }
    function Func1() {
        alert("Delayed 3 seconds");
    }

    function Func1Delay() {

        setTimeout("Func1()", 3000);
    }

    window.onload = waitindicatior;
    function PageLoadFun() {
        var flashMovie = getFlashMovieObject("movie");
        var flashMovie1 = getFlashMovieObject("movie");
        var flashMoviebottom = getFlashMovieObject("sumMovie");
        var currentFrame = null;
        var currentFrame1 = null;
        var currentFramebottom = null;
        alert(flashMovie1.PercentLoaded());
        try {
            //Run some code here
            currentFrame = flashMovie.TGetProperty("/", 5);
        }
        catch (err) {
            //Handle errors here
        }
        try {
            //Run some code here
            currentFrame1 = flashMovie1.TGetProperty("/", 5);
        }
        catch (err) {
            //Handle errors here
        }
        // currentFramebottom = flashMoviebottom.TGetProperty("/", 5);
        if (currentFrame) { }
        else {
            SendEmailOnBadSWFLeft("FileName");
        }
        if (currentFrame1) { }
        else {
            SendEmailOnBadSWFRight("FileName");
        }
        if (currentFramebottom) { }
        else {
            //SendEmailOnBadSWFBottom("FileName");
        }
        //if (currentFrame == null || currentFrame1 == null ||currentFramebottom == null)
        // var isfile = confirm('A problem with one of your video files has been detected. We will notify you when it has been resolved');
        //document.getElementById("<%=HiddenField1.ClientID %>").value = currentFrame;

    }

    function SendEmailOnBadSWFLeft(fileName) {
        //debugger;
        var arrControl = new Array();
        arrControl[0] = '<%=HiddenField1.Value %>';
        arrControl[1] = '<%=HiddenField5.Value %>';


        //            arrControl[0] = '<%=HiddenField1.Value %>';
        var msg = getValueByAJAX(arrControl, '../Ajax/EmailForVideo.aspx');
        if (msg != 'True' && msg != 'False') {
            return false;
        }
        else {
        }
        return true;



    }
    function SendEmailOnBadSWFRight(fileName) {
        var arrControl = new Array();
        arrControl[0] = '<%=HiddenField1.Value %>';
        arrControl[1] = '<%=HiddenField5.Value %>';

        var msg = getValueByAJAX(arrControl, '../Ajax/EmailForVideo.aspx');
        if (msg != 'True' && msg != 'False') {
            return false;
        }
        else {
        }

        return true;
    }
    function SendEmailOnBadSWFBottom(fileName) {
        var arrControl = new Array();
        arrControl[0] = '<%=HiddenField1.Value %>';
        arrControl[1] = '<%=HiddenField5.Value %>';

        var msg = getValueByAJAX(arrControl, '../Ajax/EmailForVideo.aspx');
        if (msg != 'True' && msg != 'False') {
            return false;
        }
        else {
        }

        return true;
    }
    function waitindicatior() {
        //debugger;
        var flashMovie = getFlashMovieObject("movie");
        var flashMovie1 = getFlashMovieObject("movie1");

        //        if (flashMovie != null) {
        //            if (flashMovie.PercentLoaded() == 100) {
        //                document.body.style.cursor = 'wait';
        //            }
        //            else {
        //                document.body.style.cursor = 'default';
        //            }
        //        }
        //        if (flashMovie1 != null) {
        //            if (flashMovie1.PercentLoaded() == 100) {
        //                document.body.style.cursor = 'wait';
        //            }
        //            else {
        //            }
        //        }
        //        
        document.body.style.cursor = 'default';
    }
    //var t = settimeout('waituntilloaded()', 3000);

    //            function waituntilloaded() {
    //                
    //          var flashMovie = getFlashMovieObject("movie");
    //            var flashMovie1 = getFlashMovieObject("movie1");
    //           var flashMovieObject2 = getFlashMovieObject("Object2");
    //            var flashMovieObject1 = getFlashMovieObject("Object1");
    //            
    //            document.getElementById("Object1").style.display = "block";
    //            document.getElementById("Object2").style.display = "block";
    //            document.getElementById("movie").style.display = "block";
    //            document.getElementById("movie1").style.display = "block";
    //            
    //            if (flashMovie.PercentLoaded() == 100) {
    //                document.getElementById("Object1").style.display = "none";
    //                document.getElementById("movie").style.display = "block";
    //                flashMovie.Play();
    //                flashMovie.TPlay('/controller');
    //                clearTimeout(t);
    //            } else {
    //           document.getElementById("movie").style.display = "none";
    //            document.getElementById("Object1").style.display = "block";
    //                flashMovieObject1.Play();
    //            }
    //            if (flashMovie1.PercentLoaded() == 100) {
    //                document.getElementById("Object2").style.display = "none";
    //            document.getElementById("movie1").style.display = "block";
    //                flashMovie1.Play();
    //               flashMovie.TPlay('/controller');
    //            } else {
    //            document.getElementById("movie1").style.display = "none";
    //            document.getElementById("Object2").style.display = "block";
    //                flashMovieObject2.Play();
    //            }
    //        }

    // window.setInterval('FunctionForAllBtns(2)', 500);

    function Delay(videoPosition) {
        // debugger;
        setTimeout("checkIfVideoLoaded(" + videoPosition + ")", 2000);
    }
    function checkIfVideoLoaded(videoPosition) {

        var flashMovie = document.getElementById("movie");
        var flashMovie1 = document.getElementById("movie1");
        try {
            var leftVideoPercentLoaded = (flashMovie != null ? flashMovie.load() : 100);
            var rightVideoPercentLoaded = (flashMovie1 != null ? flashMovie1.load() : 100);

            if (leftVideoPercentLoaded < 100 && tempCount < 100) {
                tempCount++;
                setTimeout("checkIfVideoLoaded(" + videoPosition + ")", 1000);
            }
            else if (rightVideoPercentLoaded < 100 && tempCount < 200) {
                tempCount++;
                setTimeout("checkIfVideoLoaded(" + videoPosition + ")", 1000);
            }
            else {
                try {
                    FunctionForAllBtns(videoPosition);
                    if (videoPosition == 2)
                    { NextFrameFlashMovie3(); }
                    if (videoPosition == 0)
                    { NextFrameFlashMovie1(); }
                    if (videoPosition == 1)
                    { NextFrameFlashMovie2(); }
                }
                catch (err) { }
                document.getElementById("divLoading").style.display = 'none';
                document.getElementById("divLoadingMask").style.display = 'none';

            }
        }
        catch (err) {
            document.getElementById("divLoading").style.display = 'none';
            document.getElementById("divLoadingMask").style.display = 'none';
        }
    }
    function checkIfSummaryVideoLoaded() {
        var flashSummaryMovie = document.getElementById("sumMovie");
        try {
            var summaryVideoPercentLoaded = (flashSummaryMovie != null ? flashSummaryMovie.PercentLoaded() : 100);
            if (summaryVideoPercentLoaded < 90 && tempSummaryCount < 180) {
                tempSummaryCount++;
                setTimeout("checkIfSummaryVideoLoaded()", 1000);
            }
            else {
                document.getElementById("summaryVideoDivMask").className = '';
            }
        }
        catch (err) { }
    }


    
    
    
    
    
</script>
<%--<div>
  
    <div id="div1" style="position: fixed; right: 0px; top: 0%; z-index: 9999;
               margin-right: 0px; display: block;">    
                
          </div>
             
  </div>
--%>
<div id="divLoading" style="position: fixed; right: 0px; top: 0%; z-index: 9999;
    margin-right: 0px; display: block;">
    <img id="show" src="../Images/loading.gif" alt="" height="80" width="80" />
</div>
<div id="divLoadingMask" class="maskdiv">
</div>
<asp:UpdatePanel ID="Update" runat="server">
    <ContentTemplate>
        <p style="font-family: Magneto; font-size: 26px;" class="pagetitle">
            <%--My Performance---%>
            <asp:Label ID="Label6" runat="server"></asp:Label>
        </p>
        <p style="font-family: Magneto; text-align: center; font-size: 22px;">
            The Video Player</p>
        <div id="SprintIntro" runat="server" visible="false">
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                Video Player (Tier One Athletes Only): Upon entry, the Video Player begins in Session
                Display Mode, which displays the results of the latest Session video (or Summary
                if available). In this Mode, the Left Window displays the selected Session video
                with the athlete's Model Overlay. Performer and Model will always match at Position
                3 (Touchdown). The Right Window displays the same video without the Model. Different
                Sessions can be displayed by using the left drop-down box located under the Left
                Window.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                There are two types of Sessions: On-Track and Competition. The On-Track Sessions
                take place on the track in a practice setting and are identified with a date and
                location. Competition Sessions occur in a variety of competitive situations and
                are identified with a date, location, type of meet, and the event.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                If the athlete has several past On-Track Sessions, they will have a Summary Session
                which is an average of all On-Track Sessions. This is provided so overall On-Track
                performance trends can be identified. If this Session is available, it will be displayed
                on entry and be at the top of the Session selection drop-down lists.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                In Session Comparison Mode, the Left Window displays one Session video with the
                athlete's Model Overlay while the Right Window displays another Session video with
                the athlete's Model Overlay. The current Session displayed in the Left Window can
                be compared to any other Session by using the right drop-down box located under
                the Right Window.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                Video controls are located under the Video Windows. In addition, the Performance
                Errors of the selected Session are displayed in a box under the controls. A PDF Report
                on the Session can be generated by clicking on the button to the left of the Error Box.  If
                in Comparison Mode, the common Errors of both Sessions will be displayed in both the Box 
                and the PDF Report.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                Finally, different Players (Start, Hurdle Steps, Hurdle) can be accessed by using
                the center drop-down box located under the video Windows.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                Help: For in-depth help of all of the functions of the Video Players, click on the
                HELP button located in the top right corner of the Player.
            </p>
        </div>
        <div id="SprintTireText" runat="server" visible="false">
            <p style="font-family: Magneto; font-size: 18px;">
                Video Player (Tier Two, Three, and Four): For athletes who are not Tier One, Session
                videos are not available. In Session Display Mode, the Left and Right Windows display
                a three-dimensional image of a Model Sprinter. Initially the Model will be positioned
                at Touchdown (Position 3). Upon initial entry, the latest Session (or Summary if
                available) will be displayed in this Mode. Different Sessions can be displayed by
                using the left drop-down box located under the Left Window.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                There are two types of Sessions: On-Track and Competition. The On-Track Sessions
                take place on the track in a practice setting and are identified with a date and
                location. Competition Sessions occur in a variety of competitive situations and
                are identified with a date, location, type of meet, and the event. If the athlete
                has several past On-Track Sessions, they will have a Summary Session which is an
                average of all On-Track Sessions. This is provided so overall On-Track performance
                trends can be identified. If this Session is available, it will be displayed on
                entry and be at the top of the Session selection drop-down lists.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                In Session Comparison Mode, the Left Window displays one Session video while the
                Right Window displays another Session video. The current Session displayed in the
                Left Window can be compared to any other Session by using the right drop-down box
                located under the Right Window
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                Video controls are located under the Video Windows. In addition, the Performance
                Errors of the selected Session are displayed in a box under the controls. A PDF Report
                on the Session can be generated by clicking on the button to the left of the Error Box.  If
                in Comparison Mode, the common Errors of both Sessions will be displayed in both the Box 
                and the PDF Report.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                Finally, different Players (Start, Hurdle Steps, Hurdle) can be accessed by using
                the center drop-down box located under the video Windows.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                Help: For in-depth help of all of the functions of the Video Players, click on the
                HELP button located in the top right corner of the Player.
            </p>
        </div>
        <div id="HurdleStepsIntro" runat="server" visible="false">
            <%--If need Create the class HurdleStepsIntro--%>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                Video Player (Tier One Athletes Only): Upon entry, the Video Player begins in Session
                Display Mode, which displays the results of the latest Session video (or Summary
                if available). In this Mode, the Left Window displays the selected Session video
                with the athlete's Model Overlay. Performer and Model will always match at Position
                1 (Touchdown Off the Hurdle). The Right Window displays the same video without the
                Model. Different Sessions can be displayed by using the left drop-down box located
                under the Left Window.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                There are two types of Sessions: On-Track and Competition. The On-Track Sessions
                take place on the track in a practice setting and are identified with a date and
                location. Competition Sessions occur in a variety of competitive situations and
                are identified with a date, location, type of meet, and the event.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                If the athlete has several past On-Track Sessions, they will have a Summary Session
                which is an average of all On-Track Sessions. This is provided so overall On-Track
                performance trends can be identified. If this Session is available, it will be displayed
                on entry and be at the top of the Session selection drop-down lists.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                In Session Comparison Mode, the Left Window displays one Session video with the
                athlete's Model Overlay while the Right Window displays another Session video with
                the athlete's Model Overlay. The current Session displayed in the Left Window can
                be compared to any other Session by using the right drop-down box located under
                the Right Window.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                Video controls are located under the Video Windows. In addition, the Performance
                Errors of the selected Session are displayed in a box under the controls. A PDF Report
                on the Session can be generated by clicking on the button to the left of the Error Box.  If
                in Comparison Mode, the common Errors of both Sessions will be displayed in both the Box 
                and the PDF Report.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                Finally, different Players (Sprint, Start, Hurdle) can be accessed by using the
                center drop-down box located under the video Windows.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                Help: For in-depth help of all of the functions of the Video Players, click on the
                HELP button located in the top right corner of the Player.
            </p>
        </div>
        <div id="HurdleStepsTrialText" runat="server" visible="false">
            <p style="font-family: Magneto; font-size: 18px;">
                Video Player (Tier Two, Three, and Four): For athletes who are not Tier One, Session
                videos are not available. In Session Display Mode, the Left and Right Windows display
                a three-dimensional image of a Model Hurdler. Initially the Model will be positioned
                at Position 1 (Touchdown Off the Hurdle). Upon initial entry, the latest Session
                (or Summary if available) will be displayed in this Mode. Different Sessions can
                be displayed by using the left drop-down box located under the Left Window.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                There are two types of Sessions: On-Track and Competition. The On-Track Sessions
                take place on the track in a practice setting and are identified with a date and
                location. Competition Sessions occur in a variety of competitive situations and
                are identified with a date, location, type of meet, and the event.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                If the athlete has several past On-Track Sessions, they will have a Summary Session
                which is an average of all On-Track Sessions. This is provided so overall On-Track
                performance trends can be identified. If this Session is available, it will be displayed
                on entry and be at the top of the Session selection drop-down lists.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                In Session Comparison Mode, the Left Window displays one Session video while the
                Right Window displays another Session video. The current Session displayed in the
                Left Window can be compared to any other Session by using the right drop-down box
                located under the Right Window.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                Video controls are located under the Video Windows. In addition, the Performance
                Errors of the selected Session are displayed in a box under the controls. A PDF Report
                on the Session can be generated by clicking on the button to the left of the Error Box.  If
                in Comparison Mode, the common Errors of both Sessions will be displayed in both the Box 
                and the PDF Report.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                Finally, different Players (Sprint, Start, Hurdle) can be accessed by using the
                center drop-down box located under the video Windows.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                Help: For in-depth help of all of the functions of the Video Players, click on the
                HELP button located in the top right corner of the Player.
            </p>
        </div>
        <div id="StartIntro" runat="server" visible="false">
            <p class="StartIntro" style="font-family: Magneto; font-size: 18px;">
                Video Player (Tier One Athletes Only): Upon entry, the Video Player begins in Session
                Display Mode, which displays the results of the latest Session video (or Summary
                if available). In this Mode, the Left Window displays the selected Session video
                with the athlete's Model Overlay. Performer and Model will always match at Position
                1 (Set Position). The Right Window displays the same video without the Model. Different
                Sessions can be displayed by using the left drop-down box located under the Left
                Window.
            </p>
            <p class="StartIntro" style="font-family: Magneto; font-size: 18px;">
                There are two types of Sessions: On-Track and Competition. The On-Track Sessions
                take place on the track in a practice setting and are identified with a date and
                location. Competition Sessions occur in a variety of competitive situations and
                are identified with a date, location, type of meet, and the event.
            </p>
            <p class="StartIntro" style="font-family: Magneto; font-size: 18px;">
                If the athlete has several past On-Track Sessions, they will have a Summary Session
                which is an average of all On-Track Sessions. This is provided so overall On-Track
                performance trends can be identified. If this Session is available, it will be displayed
                on entry and be at the top of the Session selection drop-down lists.
            </p>
            <p class="StartIntro" style="font-family: Magneto; font-size: 18px;">
                In Session Comparison Mode, the Left Window displays one Session video with the
                athlete's Model Overlay while the Right Window displays another Session video with
                the athlete's Model Overlay. The current Session displayed in the Left Window can
                be compared to any other Session by using the right drop-down box located under
                the Right Window.
            </p>
            <p class="StartIntro" style="font-family: Magneto; font-size: 18px;">
                Video controls are located under the Video Windows. In addition, the Performance
                Errors of the selected Session are displayed in a box under the controls. A PDF Report
                on the Session can be generated by clicking on the button to the left of the Error Box.  If
                in Comparison Mode, the common Errors of both Sessions will be displayed in both the Box 
                and the PDF Report.
            </p>
            <p class="StartIntro" style="font-family: Magneto; font-size: 18px;">
                Finally, different Players (Sprint, Hurdle Steps, Hurdle) can be accessed by using
                the center drop-down box located under the video Windows.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                Help: For in-depth help of all of the functions of the Video Players, click on the
                HELP button located in the top right corner of the Player.
            </p>
        </div>
        <div id="StartTireText" runat="server" visible="false">
            <p style="font-family: Magneto; font-size: 18px;">
                Video Player (Tier Two, Three, and Four): For athletes who are not Tier One, Session
                videos are not available. In Session Display Mode, the Left and Right Windows display
                a three-dimensional image of a Model Starter. Initially the Model will be positioned
                at Position 1 (Set Position). Upon initial entry, the latest Session (or Summary
                if available) will be displayed in this Mode. Different Sessions can be displayed
                by using the left drop-down box located under the Left Window.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                There are two types of Sessions: On-Track and Competition. The On-Track Sessions
                take place on the track in a practice setting and are identified with a date and
                location. Competition Sessions occur in a variety of competitive situations and
                are identified with a date, location, type of meet, and the event.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                If the athlete has several past On-Track Sessions, they will have a Summary Session
                which is an average of all On-Track Sessions. This is provided so overall On-Track
                performance trends can be identified. If this Session is available, it will be displayed
                on entry and be at the top of the Session selection drop-down lists.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                In Session Comparison Mode, the Left Window displays one Session video while the
                Right Window displays another Session video. The current Session displayed in the
                Left Window can be compared to any other Session by using the right drop-down box
                located under the Right Window.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                Video controls are located under the Video Windows. In addition, the Performance
                Errors of the selected Session are displayed in a box under the controls. A PDF Report
                on the Session can be generated by clicking on the button to the left of the Error Box.  If
                in Comparison Mode, the common Errors of both Sessions will be displayed in both the Box 
                and the PDF Report.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                Finally, different Players (Sprint, Hurdle Steps, Hurdle) can be accessed by using
                the center drop-down box located under the video Windows.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                Help: For in-depth help of all of the functions of the Video Players, click on the
                HELP button located in the top right corner of the Player.
            </p>
        </div>
        <div id="HurdleIntro" runat="server" visible="false">
            <p style="font-family: Magneto; font-size: 18px;">
                Video Player (Tier One Athletes Only): Upon entry, the Video Player begins in Session
                Display Mode, which displays the results of the latest Session video (or Summary
                if available). In this Mode, the Left Window displays the selected Session video
                with the athlete's Model Overlay. Performer and Model will always match at Position
                2 (Touchdown Into the Hurdle). The Right Window displays the same video without
                the Model. Different Sessions can be displayed by using the left drop-down box located
                under the Left Window.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                There are two types of Sessions: On-Track and Competition. The On-Track Sessions
                take place on the track in a practice setting and are identified with a date and
                location. Competition Sessions occur in a variety of competitive situations and
                are identified with a date, location, type of meet, and the event.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                If the athlete has several past On-Track Sessions, they will have a Summary Session
                which is an average of all On-Track Sessions. This is provided so overall On-Track
                performance trends can be identified. If this Session is available, it will be displayed
                on entry and be at the top of the Session selection drop-down lists.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                In Session Comparison Mode, the Left Window displays one Session video with the
                athlete's Model Overlay while the Right Window displays another Session video with
                the athlete's Model Overlay. The current Session displayed in the Left Window can
                be compared to any other Session by using the right drop-down box located under
                the Right Window.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                Video controls are located under the Video Windows. In addition, the Performance
                Errors of the selected Session are displayed in a box under the controls. A PDF Report
                on the Session can be generated by clicking on the button to the left of the Error Box.  If
                in Comparison Mode, the common Errors of both Sessions will be displayed in both the Box 
                and the PDF Report.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                Finally, different Players (Sprint, Start, Hurdle Steps) can be accessed by using
                the center drop-down box located under the video Windows.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                Help: For in-depth help of all of the functions of the Video Players, click on the
                HELP button located in the top right corner of the Player.
            </p>
        </div>
        <div id="HurdleTireText" runat="server" visible="false">
            <p style="font-family: Magneto; font-size: 18px;">
                Video Player (Tier Two, Three, and Four): For athletes who are not Tier One, Session
                videos are not available. In Session Display Mode, the Left and Right Windows display
                a three-dimensional image of a Model Hurdler. Initially the Model will be positioned
                at Position 2 (Touchdown Into the Hurdle). Upon initial entry, the latest Session
                (or Summary if available) will be displayed in this Mode. Different Sessions can
                be displayed by using the left drop-down box located under the Left Window.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                There are two types of Sessions: On-Track and Competition. The On-Track Sessions
                take place on the track in a practice setting and are identified with a date and
                location. Competition Sessions occur in a variety of competitive situations and
                are identified with a date, location, type of meet, and the event.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                If the athlete has several past On-Track Sessions, they will have a Summary Session
                which is an average of all On-Track Sessions. This is provided so overall On-Track
                performance trends can be identified. If this Session is available, it will be displayed
                on entry and be at the top of the Session selection drop-down lists.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                In Session Comparison Mode, the Left Window displays one Session video while the
                Right Window displays another Session video. The current Session displayed in the
                Left Window can be compared to any other Session by using the right drop-down box
                located under the Right Window.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                Video controls are located under the Video Windows. In addition, the Performance
                Errors of the selected Session are displayed in a box under the controls. A PDF Report
                on the Session can be generated by clicking on the button to the left of the Error Box.  If
                in Comparison Mode, the common Errors of both Sessions will be displayed in both the Box 
                and the PDF Report.
            </p>
            <p style="font-family: Magneto; font-size: 18px;">
                Finally, different Players (Sprint, Start, Hurdle Steps) can be accessed by using
                the center drop-down box located under the video Windows.
            </p>
            <p class="SprintIntro" style="font-family: Magneto; font-size: 18px;">
                Help: For in-depth help of all of the functions of the Video Players, click on the
                HELP button located in the top right corner of the Player.
            </p>
        </div>
        <div id="MsgDiv" runat="server" visible="false" style="height: 30px; text-align: center;
            margin-top: 30px">
            <p style="font-family: Magneto;">
                <font color="red" size="3px">Session Video is not displayed. Click
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">here</asp:LinkButton>
                    to request video.</font></p>
        </div>
        <%--<div id="SessionRequest" runat="server" visible="false" style="height: 30px; text-align: center;
    margin-top: 30px">--%>
        <p style="font-family: Magneto; font-style: italic; color: red; text-align: center">
            <asp:Label ID="Label15" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="Label17" runat="server" Visible="false"></asp:Label>
        </p>
        <%--</div>--%>
        <p style="font-family: Magneto; font-style: italic; color: red; text-align: center">
            <asp:Label ID="Label7" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="Label9" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblSessionRequested" runat="server" Visible="false">
            </asp:Label>
        </p>
        <div id="SummaryMessage" runat="server">
        </div>
        <div id="MsgDiv2" runat="server" visible="false" style="height: 30px; text-align: center;
            margin-bottom: 30px; margin-top: 10px">
            <p style="font-family: Magneto;">
                <font color="red" size="3px">Summary Video is not displayed. Click
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">here</asp:LinkButton>
                    to request video.</font></p>
        </div>
        <p style="font-family: Magneto; font-style: italic; color: red; text-align: center">
            <asp:Label ID="Label13" runat="server" Visible="false"></asp:Label>
        </p>
        <%--<div id="SummaryRequest" visible="false" runat="server" style="height: 30px; text-align: center;
    margin-top: 30px">--%>
        <p style="font-family: Magneto; font-style: italic; color: red; text-align: center">
            <asp:Label ID="Label12" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblSummaryRequested" runat="server" Visible="false">
            Summary Video has been requested. You will be notified when it is available
            </asp:Label>
        </p>
        <%--</div>--%>
        <p style="font-family: Magneto; font-style: italic; color: red; text-align: center">
            <asp:Label ID="Label8" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="Label10" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="Label16" runat="server" Visible="false"></asp:Label>
        </p>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanelForAll" runat="server">
    <ContentTemplate>
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
                        My CompuSport Session -
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                        <asp:Label ID="Label14" runat="server" Visible="false" Text=""></asp:Label>
                        <asp:Label ID="Label2" runat="server" Visible="false" Text=""></asp:Label></p>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                    <asp:HiddenField ID="HiddenField3" runat="server" />
                    <asp:HiddenField ID="HiddenField4" runat="server" />
                    <asp:HiddenField ID="HiddenField5" runat="server" />
                    <asp:HiddenField ID="hdnError" runat="server" />
                </div>
                <div style="width: 180px; text-align: right; font-size: 18px; position: absolute;
                    left: 699px;">
                    <table>
                        <%--<a href="javascript:OpenHelpWindow('../Users/MySwingHelp.aspx')">Help</a>--%>
                        <tr>
                            <td style="width: 260px; font-size: x-large;">
                                <asp:Label runat="server" Text="Help" Style="cursor: pointer; text-decoration: underline"
                                    onclick="MySwingHelp();"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="smsummaryright" id="smsummaryright">
                <img src="../images/summaryheaderright.gif" width="25" height="40" alt="" /></div>
            <div class="middleleft" id="middleleft">
                <img src="../images/middleleft.gif" width="23" height="672" alt="" /></div>
            <div class="middlecenter" id="middlecenter">
                <asp:Panel CssClass="SummaryVideo" ID="Panel2" runat="server" BackImageUrl="~/Images/SummaryFrame.PNG"
                    Width="818" Height="318">
                    <body id="appendDiv">
                        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 20px;">
                            <tr>
                                <td>
                                    <div id="obj1div" visible="false" runat="server" style="width: 395px; height: 300px;
                                        text-align: center; background-color: #78B6C3; vertical-align: middle; margin-top: 7px;">
                                        <%--<img alt="" src="../Images/indicator_48.png.gif" />--%>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <span style="font-weight: bold; color: #FFFFFF;">File Not Found
                                            <br />
                                            Compusport Will Contact You When Resolved</span>
                                    </div>
                                    <div id="moviediv1" runat="server" style="margin-top: 8px;">
                                        <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>--%>
                                        <video id="movie" loop="false" name="WMP2" height="300" style="width: 393px; margin-left: 0px;">
                                            <param name="movie" value="<% =wmpfile1 %>" />
                                            <param name="quality" value="high" />
                                            <param name="play" value="false" />
                                            <param name="loop" value="false" />
                                            <param name="wmode" value="window" />
                                            <param name="scale" value="showall" />
                                            <param name="menu" value="true" />
                                            <param name="devicefont" value="false" />
                                            <param name="salign" value="" />
                                            <param name="Menu" value="true" />
                                            <param value="#ffffff" name="bgcolor" />
                                            <source id="movie" src="<% =wmpfile1 %>" name="WMP2" width="395" height="300" play="false"
                                                loop="false" quality="high" type='video/mp4; codecs="avc1.64001E"'></source>
                                        </video>
                                        <%-- </ContentTemplate>
                             <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>--%>
                                    </div>
                                </td>
                                <td>
                                    <div id="obj1div2" visible="false" runat="server" style="width: 395px; height: 300px;
                                        text-align: center; background-color: #78B6C3; vertical-align: middle; margin-top: 7px">
                                        <%--<img alt="" src="../Images/indicator_48.png.gif" />--%>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <span style="font-weight: bold; color: #FFFFFF;">File Not Found
                                            <br />
                                            Compusport Will Contact You When Resolved</span>
                                    </div>
                                    <div id="moviediv2" runat="server" style="margin-top: 8px;">
                                        <%--<asp:UpdatePanel ID="UpdatePanel111" runat="server">
                                <ContentTemplate>--%>
                                        <video id="movie1" loop="false" height="300" name="WMP3" width="395">
                                            <param name="movie" value="<% =wmpfile2 %>" />
                                            <param name="quality" value="high" />
                                            <param name="play" value="false" />
                                            <param name="loop" value="false" />
                                            <param name="wmode" value="window" />
                                            <param name="scale" value="showall" />
                                            <param name="menu" value="true" />
                                            <param name="devicefont" value="false" />
                                            <param name="salign" value="" />
                                            <param name="Menu" value="true" />
                                            <param value="#ffffff" name="bgcolor" />
                                            <source id="movie1" src="<% =wmpfile2 %>" name="WMP3" width="395" height="300" play="false"
                                                loop="false" quality="high" type='video/mp4; codecs="avc1.64001E"'></source>
                                        </video>
                                        <%--  </ContentTemplate>
                            <triggers>
                                    <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                                </triggers>
                            </asp:UpdatePanel>--%>
                                    </div>
                                </td>
                            </tr>
                        </table>
                </asp:Panel>
                <div class="logo" id="logo">
                    <%--<img src="../images/RunnerLogo2.jpg" width="101" height="87" alt="" /></div>--%>
                    <%--<input type="button" id="btnImage" style="background-image: url('../images/PDF_ErrorClick.jpg');
                        height: 197px; cursor: pointer; width: 101px" onclick="OpenPDFInNewTab()" />--%>
                        <img style="height: 196px; margin-left: 0; width: 101px; cursor: pointer;" src="../images/PDF_ErrorClick.jpg" alt="Alternate Text" onclick="OpenPDFInNewTab()" />
                </div>
                <div>
                    <table width="663" border="0" cellspacing="0" cellpadding="0" style="position: absolute;
                        height: 37px; width: 635px; left: 70px; right: 159px; top: 371px; margin-top: 3px;">
                        <tr>
                            <td width="78">
                                <img id="btnPlay" src="../images/play.png" alt="Left click to Jog, right click to Play"
                                    oncontextmenu="playright(); return false;" onclick="playleftnew();" />
                            </td>
                            <td width="5">
                            </td>
                            <td width="40">
                                <img id="btnStop" src="../images/stop.png" alt="Stop" onclick="stop();" />
                            </td>
                            <td width="8">
                            </td>
                            <td width="19">
                                <img id="btnRewind" src="../images/rew.png" alt="Step 1 Frame Backward" onclick="RewindFlashMovie();" />
                            </td>
                            <td width="3">
                            </td>
                            <td width="19">
                                <img id="btnForwind" src="../images/fw.png" alt="Step 1 Frame Forward" onclick="forwardFlashMovie();" />
                            </td>
                            <td width="20">
                            </td>
                            <td width="19">
                                <img class="btnVideoNo" id="btnFirstBlack" src="../images/1.png" alt="Jump to Position 1"
                                    onclick="NextFrameFlashMovie1();" />
                                <img class="btnVideoNo" id="btnFirstRed" src="../images/PositionRedP1.jpg" style="display: none;"
                                    alt="Jump to Position 1" onclick="NextFrameFlashMovie1();" />
                            </td>
                            <td width="5">
                            </td>
                            <td width="19">
                                <img class="btnVideoNo" id="btnSecondBlack" src="../images/2.png" alt="Jump to Position 2"
                                    onclick="NextFrameFlashMovie2();" />
                                <img class="btnVideoNo" id="btnSecondRed" src="../images/PositionRedP2.jpg" style="display: none;"
                                    alt="Jump to Position 2" onclick="NextFrameFlashMovie2();" />
                            </td>
                            <td width="5">
                            </td>
                            <td width="19">
                                <img class="btnVideoNo" id="btnThirdBlack" src="../images/3.png" alt="Jump to Position 3"
                                    onclick="NextFrameFlashMovie3();" />
                                <img class="btnVideoNo" id="btnThirdRed" src="../images/PositionRedP3.jpg" style="display: none;"
                                    alt="Jump to Position 3" onclick="NextFrameFlashMovie3();" />
                            </td>
                            <td width="5">
                            </td>
                            <td width="19">
                                <img class="btnVideoNo" id="btnFourBlack" src="../images/4.png" alt="Jump to Position 4"
                                    onclick="NextFrameFlashMovie4(); " />
                                <img class="btnVideoNo" id="btnFourRed" src="../images/PositionRedP4.jpg" style="display: none;"
                                    alt="Jump to Position 4" onclick="NextFrameFlashMovie4();" />
                            </td>
                            <td width="5">
                            </td>
                            <td width="19">
                                <img class="btnVideoNo" id="btnFiveBlack" src="../images/5.png" alt="Jump to Position 5"
                                    onclick="NextFrameFlashMovie5(); " />
                                <img class="btnVideoNo" id="btnFiveRed" src="../images/PositionRedP5.jpg" style="display: none;"
                                    alt="Jump to Position 5" onclick="NextFrameFlashMovie5();" />
                            </td>
                            <td width="5">
                            </td>
                            <td width="19">
                                <img class="btnVideoNo" id="btnSixBlack" src="../images/6.png" alt="Jump to Position 6"
                                    onclick="NextFrameFlashMovie6(); " />
                                <img class="btnVideoNo" id="btnSixRed" src="../images/PositionRedP6.jpg" style="display: none;"
                                    alt="Jump to Position 6" onclick="NextFrameFlashMovie6();" />
                            </td>
                            <td width="5">
                            </td>
                            <td width="19">
                                <img class="btnVideoNo" id="btnSeven" style="display: block;" runat="server" src="../images/7.png"
                                    alt="Jump to Position 7" onclick="NextFrameFlashMovie7(); " />
                                <img class="btnVideoNo" id="btnSevenRed" src="../images/PositionRedP7.jpg" style="display: none;"
                                    alt="Jump to Position 7" onclick="NextFrameFlashMovie7()" />
                            </td>
                            <td width="5">
                            </td>
                            <td width="19">
                                <img class="btnVideoNo" id="btnEight" runat="server" src="../images/8.png" alt="Jump to Position 8"
                                    onclick="NextFrameFlashMovie8(); " />
                                <img class="btnVideoNo" id="btnEightRed" src="../images/PositionRedP8.jpg" style="display: none;"
                                    alt="Jump to Position 8" onclick="NextFrameFlashMovie8();" />
                            </td>
                            <td width="5">
                            </td>
                            <td width="19">
                                <img class="btnVideoNo" id="btnNine" runat="server" src="../images/9.png" alt="Jump to Position 9"
                                    onclick="FunctionForAllBtns(8); " />
                            </td>
                            <td width="5">
                            </td>
                            <td width="41">
                                <img class="btnVideoNo" id="btnTen" runat="server" src="../images/10.png" alt="Jump to Position 10"
                                    onclick="FunctionForAllBtns(9); " />
                            </td>
                            <td width="5">
                            </td>
                            <td width="41">
                                <asp:Button ID="btnreset" runat="server" OnClick="btnreset_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sel1" id="sel1">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="select1" AutoPostBack="True"
                        Font-Size="11px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="sel2" id="sel2">
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="select2" AutoPostBack="True"
                        Font-Size="11px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                        Height="23px">
                    </asp:DropDownList>
                </div>
                <div class="sel3" id="sel3">
                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="select3" AutoPostBack="True"
                        Font-Size="11px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div>
                    <img src="../images/CaptureLine.jpg" alt="" style="width: 100%; width: 103%; margin-top: 660px;
                        z-index: 1; position: absolute; margin-left: -8px; height: 8px;" />
                </div>
                <div style="position: absolute; top: 547px; margin-left: 96px;">
                    <img src="../images/CaptureColorLie.jpg" alt="" style="width: 100%" />
                </div>
                <div class="square">
                    <div class="errorText" id="square">
                        Your instructor messages will appear here.</div>
                </div>
            </div>
            <div class="middleright" id="middleright">
                <img src="../images/middleright.gif" width="25" height="672" alt="" /></div>
            <div id="divSummaryVideo" runat="server" style="height: 0px;">
                <asp:Panel CssClass="fillerleft" ID="fillerleft" runat="server" Visible="true">
                    <img src="../images/summaryfillerleft.gif" width="23" height="26" alt="" /></asp:Panel>
                <asp:Panel CssClass="fillercenter" ID="fillercenter" runat="server" Visible="true">
                </asp:Panel>
                <asp:Panel CssClass="fillerright" ID="fillerright" runat="server" Visible="true">
                    <img src="../images/summaryfillerright.gif" width="25" height="26" alt="" /></asp:Panel>
                <asp:Panel CssClass="teachersummaryleft" ID="teachersummaryleft" runat="server" Visible="true">
                    <img src="../images/summaryheaderleft.gif" width="23" height="40" alt="" /></asp:Panel>
                <asp:Panel CssClass="teachersummarycenter" ID="teachersummarycenter" runat="server"
                    Visible="true">
                    <p class="summarytitle">
                        My Teacher Summary -
                        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                        -
                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label></p>
                </asp:Panel>
                <asp:Panel CssClass="teachersummaryright" ID="teachersummaryright" runat="server"
                    Visible="true">
                    <img src="../images/summaryheaderright.gif" width="25" height="40" alt="" /></asp:Panel>
                <asp:Panel CssClass="SumDivLeft" ID="SumDivLeftPanel" runat="server" Visible="true">
                    <img src="../images/summaryleft.gif" width="23" height="455" alt="" /></asp:Panel>
                <asp:Panel CssClass="SumDivCenter" ID="SumDivCenterPanel" runat="server">
                    <div id="objdivsum" runat="server" visible="false" style="width: 395px; height: 295px;
                        text-align: center; background-color: #78B6C3; margin-top: 40px; margin-left: 250px">
                        <%--<img alt="" src="../Images/indicator_48.png.gif" />--%>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <span style="font-weight: bold; color: Black; font-family: Magneto; font-size: 25px;">
                            No Video Available.</span>
                    </div>
                    <asp:Panel CssClass="SummaryVideo" ID="SummaryVideo" runat="server">
                        <div id="divsum" runat="server" style="text-align: center">
                            <video id="sumMovie" controls width="395" height="300" name="WMP1">
                            <param name="movie" value="<% =wmpfile %>" />
                            <param name="quality" value="high" />
                            <param value="#ffffff" name="bgcolor" />
                            <param name="play" value="false" />
                            <param name="loop" value="false" />
                            <param name="wmode" value="window" />
                            <param name="scale" value="showall" />
                            <param name="menu" value="true" />
                            <param name="devicefont" value="false" />
                            <param name="salign" value="" />
                            <param name="Menu" value="true" />
                            <source id="sumMovie" src="<% =wmpfile %>" name="WMP1" width="395" height="300" play="false"
                                loop="false" quality="high" type='video/mp4; codecs="avc1.64001E"'></source>
                        </video>
                        </div>
                    </asp:Panel>
                    <div class="SummaryFrame" id="Image1" runat="server" style="text-align: center;">
                        <img src="../Images/SummaryFrame.PNG" alt="image" height="316px" style="width: 412px;
                            margin-left: 16px" /></div>
                    <asp:Panel CssClass="SummaryButtons" ID="SummaryButtons" runat="server" Visible="true">
                        <table width="216" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="78">
                                    <img alt="Play" id="SummaryPlay" name="SummaryPlay" src="~/Images/play.png" runat="server"
                                        onclick="PlaysumMovieFlashMovie();" />
                                </td>
                                <td width="10">
                                </td>
                                <td width="78">
                                    <img alt="Pause" id="Img1" name="SummaryPlay" src="~/Images/pause.png" runat="server"
                                        onclick="PausesumMovieFlashMovie();" />
                                </td>
                                <td width="10">
                                </td>
                                <td width="40">
                                    <img alt="Stop" id="SummaryStop" name="SummaryStop" src="~/Images/stop.png" runat="server"
                                        onclick="StopsumMovieFlashMovie();" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="SummaryDropDown" runat="server" Visible="true">
                        <asp:DropDownList ID="DropDownList4" CssClass="SummaryDropDown" runat="server" AutoPostBack="True"
                            Width="310" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                        </asp:DropDownList>
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel CssClass="SumDivRight" ID="SumDivRightPanel" runat="server" Visible="true">
                    <img src="../images/summaryright.gif" width="25" height="455" alt="" /></asp:Panel>
            </div>
            <asp:Panel CssClass="bottomleft" ID="bottomleft" runat="server">
                <img src="../images/bottomleft.gif" width="23" height="31" alt="" /></asp:Panel>
            <asp:Panel CssClass="bottomcenter" ID="bottomcenter" runat="server">
            </asp:Panel>
            <asp:Panel CssClass="bottomright" ID="bottomright" runat="server">
                <img src="../images/bottomright.gif" width="25" height="31" alt="" /></asp:Panel>
            <div style="display: none;">
                <img src="../images/over1.png" />
                <img src="../images/over2.png" />
                <img src="../images/over3.png" /><%--2 img src="../images/over4.png" />--%>
                <img src="../images/over4.png" />
                <img src="../images/over5.png" />
                <img src="../images/over6.png" />
                <img src="../images/over7.png" />
                <img src="../images/over8.png" />
                <img src="../images/over9.png" />
                <img src="../images/over10.png" />
                <img src="../images/pause.jpg" />
                <img src="../images/pause.png" />
                <img src="../images/play.png" />
                <img src="../images/stop.png" />
            </div>
            <div id="SprintId" runat="server">
                <%--  <div style="margin-left: 1px;">--%>
                <table id="Sprintheader" runat="server" style="float: left; padding: 0px; width: 749px;
                    height: 75px; font-size: 22px; text-align: center; margin-left: 70px; font-family: Magneto;">
                    <tr>
                        <td style="font-family: Magneto; font-size: 22px;">
                            The Variable Chart
                        </td>
                    </tr>
                </table>
                <div id="SprintText" runat="server" style="float: left; width: 86%; margin-left: 65px">
                        <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 22px;">
                        Session Display Mode
                    </p>
                    <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                        Below the Video Player, the Variable Chart lists the results that are used to evaluate
                        the Maximum Velocity Sprint. If the results are from an On-Track Session, then the
                        athlete's initial run-through results are shown in the Initial column, while the
                        final effort is shown in the Final column. In both cases, the athlete's Model values
                        are shown in the column to the right of their values. If the athlete's results are
                        in the acceptable range, the Model results are shown in <font color="black"><b>black</b></font>.
                        If the results are not up to the Model's standard (needs improvement), the result
                        is shown in <font color="red">red</font>.</p>
                    <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                        If the results are from a Competition then the athlete's performance is shown in
                        the Final column, with the athlete's Model values shown in the column to the right 
                        of their values. As in the On-Track Sessions, the Model results are shown in black if
                        acceptabe, or in in <font color="red"> red</font> if not up to the Model's standard.
                    </p>
                    <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                        Performance Variables are categorized in three Groups: Result, General, and Specific. 
                        The challenge for the Elite Coach is to improve the Specific Variables which will, in 
                        turn, improve the results in the remaining Groups.</p>
                    <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                        The only result that must be treated differently is the Sprint Stride Length value.
                        Since it can only be properly altered by improving what happens during Ground Contact,
                        it should not directly be the focus of improvement. If Stride Length is flagged
                        as a problem, then the focus should be on improving the mechanics and force production
                        during the Ground Phase. Due to the uniqueness of this Variable, if the result is
                        not up to the Model's standard (needs improvement), the Model result is shown in
                        <font color="purple">purple</font>.  It is also removed from the General Group and given 
                        its own Group designation "Special".
                    </p>
                    <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                        <%--Information on any of the variables can be found by clicking on the variable name
                                in the Chart.--%>
                        Information on the definition of any of the Variables can be found by clicking on
                        the Variable name in the Chart. In addition, a graph showing the Athlete’s Variable
                        results for all of their Sessions and Competitions can be displayed by clicking
                        on any of the Athlete's results. In each graph, a grey shaded area will identify
                        the Model result. Due to the uniqueness of the Sprint Stride Length Variable, no
                        Model values are displayed on its graph.
                    </p>
                    <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                        Finally, to provide greater insight into the overall Sprint performance of an Athlete, 
                        each Session is given a Score in each of the four Groups (Result, General, Special, 
                        and Specific) that includes the quality of every Variable. If the Athlete’s Score 
                        reaches 100, they have matched the Model in every Variable in the Group.  A Score of
                        50 indicates an "Average" elite performance, while a Score of 75 or higher points to 
                        an exceptional Group performance.
                    </p>
                </div>
                <table id="SprintTireVariableText" runat="server" visible="false" style="float: left;
                    padding: 0px; width: 86%; margin-left: 65px;">
                    <tr>
                        <td style="width: 797px; text-align: justify; font-family: Magneto; font-size: 22px;">
                            Session Comparison Mode
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                                Below the Video Player, the Variable Chart lists the results that are used to evaluate
                                the Maximum Velocity Sprint. In Comparison Mode, the results from the Session selected
                                in the left window of the Top Player are shown in the left <font color="#fcc60a">(yellow)</font>
                                column, while the results from the Session selected in the right window are shown
                                in the right <font color="green">(green)</font> column. In both cases, the athlete's
                                Model values are shown in the column to the right of their values. If the athlete's
                                results are in the acceptable range, the Model results are shown in black. If the
                                results are not up to the Model's standard (needs improvement), the result is shown
                                in <font color="red">red</font>.  
                        </td>
                    </tr>
                    <tr>
                    <td>
                         <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                        Performance Variables are categorized in three Groups: Result, General, and Specific. 
                        The challenge for the Elite Coach is to improve the Specific Variables which will, in 
                        turn, improve the results in the remaining Groups.
                    </p>
                    </td>
                    </tr>
                    <tr>
                    <td>
                         <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                         The only result that must be treated differently is the Sprint Stride Length value.
                         Since it can only be properly altered by improving what happens during Ground Contact, 
                         it should not directly be the focus of improvement. If Stride Length is flagged as a problem, 
                         then the focus should be on improving the mechanics and force production during the Ground Phase.
                         Due to the uniqueness of this Variable, if the result is not up to the Model's standard (needs improvement), 
                         the Model result is shown in <font color="purple">purple</font>.  It is also removed from the General Group and given 
                         its own Group designation "Special".
                    </p>
                    </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                                <%-- Information on any of the variables can be found by clicking on the variable name
                                in the Chart.--%>
                                Information on the definition of any of the Variables can be found by clicking on
                                the Variable name in the Chart. In addition, a graph showing the Athlete’s Variable
                                results for all of their Sessions and Competitions can be displayed by clicking
                                on any of the Athlete's results. In each graph, a grey shaded area will identify
                                the Model result.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            Finally, to provide greater insight into the overall Sprint performance of an Athlete, 
                            each Session is given a Score in each of the four Groups (Result, General, Special, 
                            and Specific) that includes the quality of every Variable. If the Athlete’s Score 
                            reaches 100, they have matched the Model in every Variable in the Group.  A Score of
                            50 indicates an "Average" elite performance, while a Score of 75 or higher points to 
                            an exceptional Group performance.
                            </p>
                        </td>
                    </tr>
                </table>
                <table id="tblvalue" cellpadding="0" style="float: left; width: 835px; margin-left: 55px;
                    border: 3px solid black; font-size: small">
                    <tr>
                        <th align="left" style="width: 400px; background-color: #006699; color: #FFFFFF;
                            font-weight: bold">
                            Sessions
                        </th>
                        <td colspan="2" align="center" style="font-size: small; width: 287; background-color: #006699;
                            color: #FFFFFF; font-weight: bold">
                            <asp:Label ID="lblleftmovie" runat="server" ForeColor="White"></asp:Label>
                        </td>
                        <td colspan="2" align="center" style="font-size: small; width: 287; background-color: #006699;
                            color: #FFFFFF; font-weight: bold">
                            <asp:Label ID="lblRightMovie" runat="server" ForeColor="White"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="left" style="width: 260px; background-color: #006699; color: #FFFFFF;
                            font-weight: bold;">
                            Variable
                        </th>
                        <td width="143" id="SprintInitial" runat="server" align="center" style="background-color: #006699;">
                            Initial
                        </td>
                        <td width="143" align="center" style="background-color: #006699; color: #FFFFFF;
                            width: 143px; font-weight: bold;">
                            Model
                        </td>
                        <td width="143" id="SprintFinal" runat="server" style="background-color: #006699;"
                            align="center">
                            Final
                        </td>
                        <td width="143" id="Td1" align="center" runat="server" style="background-color: #006699;
                            font-weight: bold; color: #FFFFFF">
                            Model
                        </td>
                    </tr>
                    <tr style="font-size: small">
                        <td style="background-color: #FFB9AF; font-size: small; width: 260px;">
                            <asp:Label ID="Label11" runat="server" Text="Result: Sprint Velocity" Style="cursor: pointer"
                                onclick="Velocity1();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblVelocity" runat="server" Style="cursor: pointer" onclick="VelocityLeft();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblVelocityM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblVelocityF" runat="server" Style="cursor: pointer" onclick="VelocityRight();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblVelocityM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 260px; font-size: small; background-color: #FFE1AA; width: 260px;">
                            <asp:Label runat="server" ID="lblGroundTime" Text="General: Ground Time Left" Style="cursor: pointer"
                                onclick="GroundTime();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblGroundTimeLeftI" runat="server" onclick="GroundTime1();" Style="cursor: pointer"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblGroundTimeLeftM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblGroundTimeLeftF" runat="server" onclick="GroundTime1();" Style="cursor: pointer"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblGroundTimeLeftM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                        <%--<asp:UpdatePanel ID="UP1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="OpenVariablePopup" EventName="Click" />
                        </Triggers>
                        <ContentTemplate>--%>
                        <tr>
                            <td style="background-color: #FFB9AF; font-size: small;">
                                <asp:Label runat="server" onclick="GroundTime();" Style="cursor: pointer" 
                                    Text="General: Ground Time Right"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblGroundTimeRightI" runat="server" onclick="GroundTimeRight();" 
                                    Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblGroundTimeRightM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblGroundTimeRightF" runat="server" onclick="GroundTimeRight();" 
                                    Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblGroundTimeRightM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; width: 260px; font-size: small;">
                                <asp:Label runat="server" onclick="GroundTime();" Style="cursor: pointer" 
                                    Text="General: Ground Time Average"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center;">
                                <asp:Label ID="lblGroundTimeAverageI" runat="server" 
                                    onclick="GroundTimeTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblGroundTimeAverageM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblGroundTimeAverageF" runat="server" 
                                    onclick="GroundTimeTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblGroundTimeAverageM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="GroundTime();" Style="cursor: pointer" 
                                    Text="General: Air Time Left to Right"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblAirTimeLeftToRightI" runat="server" 
                                    onclick="AirTimeLeftToRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblAirTimeLeftToRightM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblAirTimeLeftToRightF" runat="server" 
                                    onclick="AirTimeLeftToRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblAirTimeLeftToRightM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="GroundTime();" Style="cursor: pointer" 
                                    Text="General: Air Time Right to Left"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblAirTimeRightToLeftI" runat="server" 
                                    onclick="AirTimeRightToLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblAirTimeRightToLeftM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblAirTimeRightToLeftF" runat="server" 
                                    onclick="AirTimeRightToLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblAirTimeRightToLeftM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="GroundTime();" Style="cursor: pointer" 
                                    Text="General: Air Time Average"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblAirTimeAverageI" runat="server" onclick="AirTimeTotal();" 
                                    Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblAirTimeAverageM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblAirTimeAverageF" runat="server" onclick="AirTimeTotal();" 
                                    Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblAirTimeAverageM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; width: 260px; font-size: small;">
                                <asp:Label runat="server" onclick="TimeToUpperLeg();" Style="cursor: pointer" 
                                    Text="General: Time to Upper Leg Full Flexion Left"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblTimeToUpperLegFullFlexionLeftI" runat="server" 
                                    onclick="FullFlexionLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblTimeToUpperLegFullFlexionLeftM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblTimeToUpperLegFullFlexionLeftF" runat="server" 
                                    onclick="FullFlexionLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblTimeToUpperLegFullFlexionLeftM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="TimeToUpperLeg();" Style="cursor: pointer" 
                                    Text="General: Time to Upper Leg Full Flexion Right"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblTimeToUpperLegFullFlexionRightI" runat="server" 
                                    onclick="FullFlexionRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblTimeToUpperLegFullFlexionRightM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblTimeToUpperLegFullFlexionRightF" runat="server" 
                                    onclick="FullFlexionRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblTimeToUpperLegFullFlexionRightM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="TimeToUpperLeg();" Style="cursor: pointer" 
                                    Text="General: Time to Upper Leg Full Flexion Average"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblTimeToUpperLegFullFlexionAverageI" runat="server" 
                                    onclick="FullFlexionTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblTimeToUpperLegFullFlexionAverageM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblTimeToUpperLegFullFlexionAverageF" runat="server" 
                                    onclick="FullFlexionTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblTimeToUpperLegFullFlexionAverageM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 260px; font-size: small;">
                                <asp:Label runat="server" onclick="StrideRate();" Style="cursor: pointer" 
                                    Text="General: Stride Rate"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStrideRateI" runat="server" onclick="StrideRate1();" 
                                    Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStrideRateM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStrideRateF" runat="server" onclick="StrideRate1();" 
                                    Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStrideRateM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="StrideLength();" Style="cursor: pointer" 
                                    Text="Special: Stride Length Left to Right"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStrideLengthLeftToRightI" runat="server" 
                                    onclick="StrideLengthLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStrideLengthLeftToRighM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStrideLengthLeftToRighF" runat="server" 
                                    onclick="StrideLengthLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStrideLengthLeftToRighM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="StrideLength();" Style="cursor: pointer" 
                                    Text="Special: Stride Length Right to Left"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStrideLengthRightToLeftI" runat="server" 
                                    onclick="StrideLengthRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStrideLengthRightToLeftM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStrideLengthRightToLeftF" runat="server" 
                                    onclick="StrideLengthRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStrideLengthRightToLeftM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="StrideLength();" Style="cursor: pointer" 
                                    Text="Special: Stride Length Average"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStrideLengthAverageI" runat="server" 
                                    onclick="StrideLengthTotal1();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStrideLengthAverageM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStrideLengthAverageF" runat="server" 
                                    onclick="StrideLengthTotal1();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStrideLengthAverageM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="TrunkAngleForSprintPlayer();" 
                                    Style="cursor: pointer" Text="Specific: Trunk Angle at Touchdown Left"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblTrunkAngleAtTouchdownLeftI" runat="server" 
                                    onclick="TrunkAngleLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblTrunkAngleAtTouchdownLeftM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblTrunkAngleAtTouchdownLeftF" runat="server" 
                                    onclick="TrunkAngleLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblTrunkAngleAtTouchdownLeftM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="TrunkAngleForSprintPlayer();" 
                                    Style="cursor: pointer" Text="Specific: Trunk Angle at Touchdown Right"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblTrunkAngleAtTouchdownRightI" runat="server" 
                                    onclick="TrunkAngleRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblTrunkAngleAtTouchdownRightM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblTrunkAngleAtTouchdownRightF" runat="server" 
                                    onclick="TrunkAngleRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblTrunkAngleAtTouchdownRightM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="TrunkAngleForSprintPlayer();" 
                                    Style="cursor: pointer" Text="Specific: Trunk Angle at Touchdown Average"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblTrunkAngleAtTouchdownAverageI" runat="server" 
                                    onclick="TrunkAngleTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblTrunkAngleAtTouchdownAverageM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblTrunkAngleAtTouchdownAverageF" runat="server" 
                                    onclick="TrunkAngleTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblTrunkAngleAtTouchdownAverageM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="KneeSeparationForSprint();" 
                                    Style="cursor: pointer" Text="Specific: Knee-Knee Separation at Touchdown Left"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblKneeSeparationAtTouchdownLeftI" runat="server" 
                                    onclick="KneeTouchDownLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblKneeSeparationAtTouchdownLeftM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblKneeSeparationAtTouchdownLeftF" runat="server" 
                                    onclick="KneeTouchDownLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblKneeSeparationAtTouchdownLeftM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="KneeSeparationForSprint();" 
                                    Style="cursor: pointer" 
                                    Text="Specific: Knee-Knee Separation at Touchdown Right"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblKneeSeparationAtTouchdownRightI" runat="server" 
                                    onclick="KneeTouchDownRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblKneeSeparationAtTouchdownRightM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblKneeSeparationAtTouchdownRightF" runat="server" 
                                    onclick="KneeTouchDownRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblKneeSeparationAtTouchdownRightM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="KneeSeparationForSprint();" 
                                    Style="cursor: pointer" 
                                    Text="Specific: Knee-Knee Separation at Touchdown Average"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblKneeSeparationAtTouchdownAverageI" runat="server" 
                                    onclick="KneeTouchDownTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblKneeSeparationAtTouchdownAverageM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblKneeSeparationAtTouchdownAverageF" runat="server" 
                                    onclick="KneeTouchDownTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblKneeSeparationAtTouchdownAverageM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="TouchDown();" Style="cursor: pointer" 
                                    Text="Specific: COG to Foot Touchdown Distance Left"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblTouchDownDistanceLeftI" runat="server" 
                                    onclick="TouchDownLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblTouchDownDistanceLeftM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblTouchDownDistanceLeftF" runat="server" 
                                    onclick="TouchDownLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblTouchDownDistanceLeftM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="TouchDown();" Style="cursor: pointer" 
                                    Text="Specific: COG to Foot Touchdown Distance Right"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblTouchDownDistanceRightI" runat="server" 
                                    onclick="TouchDownRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblTouchDownDistanceRightM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblTouchDownDistanceRightF" runat="server" 
                                    onclick="TouchDownRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblTouchDownDistanceRightM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="TouchDown();" Style="cursor: pointer" 
                                    Text="Specific: COG to Foot Touchdown Distance Average"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblTouchDownDistanceAverageI" runat="server" 
                                    onclick="TouchDownTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblTouchDownDistanceAverageM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblTouchDownDistanceAverageF" runat="server" 
                                    onclick="TouchDownTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblTouchDownDistanceAverageM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="UpperLegFullExtension1();" 
                                    Style="cursor: pointer" Text="Specific: Upper Leg Full Extension Angle Left"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullExtentionAngleLeftI" runat="server" 
                                    onclick="UpperLegFullExtensionLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullExtentionAngleLeftM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullExtentionAngleLeftF" runat="server" 
                                    onclick="UpperLegFullExtensionLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullExtentionAngleLeftM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="UpperLegFullExtension1();" 
                                    Style="cursor: pointer" Text="Specific: Upper Leg Full Extension Angle Right"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullExtentionAngleRightI" runat="server" 
                                    onclick="UpperLegFullExtensionRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullExtentionAngleRightM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullExtentionAngleRightF" runat="server" 
                                    onclick="UpperLegFullExtensionRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullExtentionAngleRightM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="UpperLegFullExtension1();" 
                                    Style="cursor: pointer" Text="Specific: Upper Leg Full Extension Angle Average"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullExtentionAngleAverageI" runat="server" 
                                    onclick="UpperLegFullExtensionTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullExtentionAngleAverageM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullExtentionAngleAverageF" runat="server" 
                                    onclick="UpperLegFullExtensionTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullExtentionAngleAverageM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="UpperLegFullFlexion1();" 
                                    Style="cursor: pointer" Text="Specific: Upper Leg Full Flexion Angle Left"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullFlexionAngleLeftI" runat="server" 
                                    onclick="UpperLegFullFlexionLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullFlexionAngleLeftM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullFlexionAngleLeftF" runat="server" 
                                    onclick="UpperLegFullFlexionLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullFlexionAngleLeftM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="UpperLegFullFlexion1();" 
                                    Style="cursor: pointer" Text="Specific: Upper Leg Full Flexion Angle Right"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullFlexionAngleRightI" runat="server" 
                                    onclick="UpperLegFullFlexionRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullFlexionAngleRightM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullFlexionAngleRightF" runat="server" 
                                    onclick="UpperLegFullFlexionRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullFlexionAngleRightM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="UpperLegFullFlexion1();" 
                                    Style="cursor: pointer" Text="Specific: Upper Leg Full Flexion Angle Average"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullFlexionAngleAverageI" runat="server" 
                                    onclick="UpperLegFullFlexionTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullFlexionAngleAverageM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullFlexionAngleAverageF" runat="server" 
                                    onclick="UpperLegFullFlexionTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblUpperLegFullFlexionAngleAverageM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="LowerLegAngleAtTakeOf();" 
                                    Style="cursor: pointer" Text="Specific: Lower Leg Angle at Takeoff Left"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegAngleAtTakeOfLeftI" runat="server" 
                                    onclick="LowerLegAngleAtTakeOfLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegAngleAtTakeOfLeftM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegAngleAtTakeOfLeftF" runat="server" 
                                    onclick="LowerLegAngleAtTakeOfLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegAngleAtTakeOfLeftM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="LowerLegAngleAtTakeOf();" 
                                    Style="cursor: pointer" Text="Specific: Lower Leg Angle at Takeoff Right"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegAngleAtTakeOfRightI" runat="server" 
                                    onclick="LowerLegAngleAtTakeOfRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegAngleAtTakeOfRightM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegAngleAtTakeOfRightF" runat="server" 
                                    onclick="LowerLegAngleAtTakeOfRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegAngleAtTakeOfRightM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="LowerLegAngleAtTakeOf();" 
                                    Style="cursor: pointer" Text="Specific: Lower Leg Angle at Takeoff Average"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegAngleAtTakeOfAverageI" runat="server" 
                                    onclick="LowerLegAngleAtTakeOfTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegAngleAtTakeOfAverageM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegAngleAtTakeOfAverageF" runat="server" 
                                    onclick="LowerLegAngleAtTakeOfTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegAngleAtTakeOfAverageM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="LowerLegAngleAtTakeOf();" 
                                    Style="cursor: pointer" Text="Specific: Lower Leg Full Flexion Angle Left"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegFullFlexionAngleLeftI" runat="server" 
                                    onclick="LowerLegFullFlexionLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegFullFlexionAngleLeftM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegFullFlexionAngleLeftF" runat="server" 
                                    onclick="LowerLegFullFlexionLeft();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegFullFlexionAngleLeftM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; font-size: small; width: 260px;">
                                <asp:Label runat="server" onclick="LowerLegAngleAtTakeOf();" 
                                    Style="cursor: pointer" Text="Specific: Lower Leg Full Flexion Angle Right"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegFullFlexionAngleRightI" runat="server" 
                                    onclick="LowerLegFullFlexionRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegFullFlexionAngleRightM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegFullFlexionAngleRightF" runat="server" 
                                    onclick="LowerLegFullFlexionRight();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegFullFlexionAngleRightM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 260px; font-size: small;">
                                <asp:Label runat="server" onclick="LowerLegAngleAtTakeOf();" 
                                    Style="cursor: pointer" Text="Specific: Lower Leg Full Flexion Angle Average"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegFullFlexionAngleAverageI" runat="server" 
                                    onclick="LowerLegFullFlexionTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegFullFlexionAngleAverageM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegFullFlexionAngleAverageF" runat="server" 
                                    onclick="LowerLegFullFlexionTotal();" Style="cursor: pointer"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblLowerLegFullFlexionAngleAverageM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <%--<tr>
                        <td onclick="myFunction('../VariablePages/LowerLegAngleAtTakeOf.aspx')" style="background-color: #FFCAB0;
                            font-size: small; width: 260px; cursor: pointer;">
                            Lower Leg Angle at Ankle Cross Left
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossLeftI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossLeftM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossLeftF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossLeftM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td onclick="myFunction('../VariablePages/LowerLegAngleAtTakeOf.aspx')" style="background-color: #FFCAB0;
                            width: 260px; font-size: small; cursor: pointer;">
                            Lower Leg Angle at Ankle Cross Right
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossRightI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossRightM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossRightF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossRightM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td onclick="myFunction('../VariablePages/LowerLegAngleAtTakeOf.aspx')" style="background-color: #FFB895;
                            width: 260px; font-size: small; cursor: pointer;">
                            Lower Leg Angle at Ankle Cross Average
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossAverageI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossAverageM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossAverageF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleAtAnkleCrossAverageM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>--%>
                        <tr>
                            <th align="left" 
                                style="width: 260px; background-color: #006699; color: #FFFFFF; font-weight: bold;">
                                Scores
                            </th>
                            <td ID="SprintScoresInitial" runat="server" align="center" 
                                style="background-color: #006699; color: #FFFFFF; font-weight: bold" 
                                width="143">
                                Initial
                            </td>
                            <td ID="SprintScoresModel" align="center" 
                                style="background-color: #006699; color: #FFFFFF; width: 143px; font-weight: bold;" 
                                width="143">
                                Model
                            </td>
                            <td ID="SprintScoresFinal" runat="server" align="center" 
                                style="background-color: #006699; color: #FFFFFF; font-weight: bold" 
                                width="143">
                                Final
                            </td>
                            <td ID="SprintScoresModel2" runat="server" align="center" 
                                style="background-color: #006699; color: #FFFFFF; font-weight: bold" 
                                width="143">
                                Model
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 260px; font-size: small;">
                            <asp:Label ID="Label22" runat="server" Style="cursor: pointer" 
                                Text="Result: Velocity Compared to Model"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="SprintResultScoreI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="SprintResultScoreM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="SprintResultScoreF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="SprintResultScoreM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 260px; font-size: small;">
                            <asp:Label ID="Label51" runat="server" Style="cursor: pointer" 
                                Text="General: Time and Rate Results"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="SprintGeneralScoreI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="SprintGeneralScoreM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="SprintGeneralScoreF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="SprintGeneralScoreM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 260px; font-size: small;">
                            <asp:Label ID="Label56" runat="server" Style="cursor: pointer" 
                                Text="Special: Stride Length Creation While on Ground"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="SprintSpecialScoreI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="SprintSpecialScoreM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="SprintSpecialScoreF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="SprintSpecialScoreM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 260px; font-size: small;">
                            <asp:Label ID="Label61" runat="server" Style="cursor: pointer" 
                                Text="Specific: Critical Body Positions"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="SprintSpecificScoreI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="SprintSpecificScoreM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="SprintSpecificScoreF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="SprintSpecificScoreM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <%-- </div>--%>
            </div>
            <div id="StartId" runat="server">
                <table id="Startheader" style="width: 600px; height: 75px; margin-bottom: 220px;
                    text-align: center; margin-left: 150px; margin-top: 10px;">
                    <tr>
                        <td style="font-size: 22px; font-family: Magneto;">
                            <%--div id="Startheader" style="float: left; padding: 0px; width: 600px; height: 75px;
                            margin-bottom: 220px; text-align: center; margin-left: 150px; margin-top: 10px;
                            font-size: 22px; font-family: Magneto;">                            
                            <br />
                            <br />
                        </div>--%>
                            The Variable Chart
                        </td>
                    </tr>
                </table>
                <table id="StartText" runat="server" style="width: 600px; margin-top: -230px; margin-bottom: 15px;
                    width: 86%; margin-left: 65px;">
                    <tr>
                        <td style="width: 797px; text-align: justify; font-family: Magneto; font-size: 22px;">
                            Session Display Mode
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                                Below the Video Player, the Variable Chart lists the results that are used to evaluate
                                the Sprint Start. If the results are from an On-Track Session, then the athlete's
                                initial run-through results are shown in the Initial column, while the final effort
                                is shown in the Final column. In both cases, the athlete's Model values are shown
                                in the column to the right of their values. If the athlete's results are in the
                                acceptable range, the Model results are shown in <font color="black"><b>black</b></font>.
                                If the results are not up to the Model's standard (needs improvement), the result
                                is shown in <font color="red">red</font>.</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                                If the results are from a Competition then the athlete's performance is shown in
                                the Final column, with the athlete's Model values shown in the column to the right 
                                of their values. As in the On-Track Sessions, the Model results are shown in black if
                                acceptabe, or in in <font color="red"> red</font> if not up to the Model's standard.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            Performance Variables are categorized in three Groups: Result, General, and Specific. 
                            The challenge for the Elite Coach is to improve the Specific Variables which will, in 
                            turn, improve the results in the remaining Groups.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                                <%-- Information on any of the variables can be found by clicking on the variable name
                                in the Chart.--%>
                                Information on the definition of any of the Variables can be found by clicking on
                                the Variable name in the Chart. In addition, a graph showing the Athlete’s Variable
                                results for all of their Sessions and Competitions can be displayed by clicking
                                on any of the Athlete's results. In each graph, a grey shaded area will identify
                                the Model result.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            Finally, to provide greater insight into the overall Start performance of an Athlete, 
                            each Session is given a Score in each of the three Groups (Result, General, and Specific) 
                            that includes the quality of every Variable. If the Athlete’s Score 
                            reaches 100, they have matched the Model in every Variable in the Group.  A Score of
                            50 indicates an "Average" elite performance, while a Score of 75 or higher points to 
                            an exceptional Group performance.
                            </p>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <table id="StartTireVariablesChart" runat="server" style="float: left; padding: 0px;
                    width: 600px; margin-top: -230px; margin-bottom: 15px; padding: 0px; width: 86%;
                    margin-left: 65px">
                    <tr>
                        <td style="width: 797px; text-align: justify; font-family: Magneto; font-size: 22px;">
                            Session Comparison Mode
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            Below the Video Player, the Variable Chart lists the results that are used to evaluate
                            the Sprint Start. In Comparison Mode, the results from the Session selected in the
                            left window of the Top Player are shown in the left <font color="#fcc60a">(yellow)</font>
                            column, while the results from the Session selected in the right window are shown
                            in the right <font color="green">(green)</font> column. In both cases, the athlete's
                            Model values are shown in the column to the right of their values. If the athlete's
                            results are in the acceptable range, the Model results are shown in black. If the
                            results are not up to the Model's standard (needs improvement), the result is shown
                            in <font color="red">red</font>.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            Performance Variables are categorized in three Groups: Result, General, and Specific. 
                            The challenge for the Elite Coach is to improve the Specific Variables which will, in 
                            turn, improve the results in the remaining Groups.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                                <%-- Information on any of the variables can be found by clicking on the variable name
                                in the Chart.--%>
                                Information on the definition of any of the Variables can be found by clicking on
                                the Variable name in the Chart. In addition, a graph showing the Athlete’s Variable
                                results for all of their Sessions and Competitions can be displayed by clicking
                                on any of the Athlete's results. In each graph, a grey shaded area will identify
                                the Model result.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            Finally, to provide greater insight into the overall Start performance of an Athlete, 
                            each Session is given a Score in each of the three Groups (Result, General, and Specific) 
                            that includes the quality of every Variable. If the Athlete’s Score 
                            reaches 100, they have matched the Model in every Variable in the Group.  A Score of
                            50 indicates an "Average" elite performance, while a Score of 75 or higher points to 
                            an exceptional Group performance.
                            </p>
                        </td>
                    </tr>
                </table>
                <table id="tblstart" cellpadding="0" style="float: left; width: 861px; margin-left: 53px;
                    border: 3px solid black; font-size: small">
                    <tr>
                        <td width="270px" align="left" style="background-color: #006699; color: #FFFFFF;
                            font-weight: bold">
                            Sessions
                        </td>
                        <td colspan="2" align="center" style="font-size: small; background-color: #006699;
                            color: #FFFFFF; font-weight: bold">
                            <asp:Label ID="lblStartLeftMovie" runat="server" Width="240px" ForeColor="White"></asp:Label>
                        </td>
                        <td colspan="2" align="center" style="font-size: small; background-color: #006699;
                            color: #FFFFFF; font-weight: bold">
                            <asp:Label ID="lblStartRightMovie" runat="server" Width="240px" ForeColor="White"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="270px" align="left" style="background-color: #006699; color: #FFFFFF;
                            font-weight: bold;">
                            Variable
                        </td>
                        <td width="120px" id="StartInitial" runat="server" align="center" style="background-color: #006699;">
                            Initial
                        </td>
                        <td width="120px" align="center" style="background-color: #006699; color: #FFFFFF;
                            font-weight: bold;">
                            Model
                        </td>
                        <td width="120px" id="StartFinal" runat="server" style="background-color: #006699;"
                            align="center">
                            Final
                        </td>
                        <td width="120px" id="Td2" align="center" runat="server" style="background-color: #006699;
                            font-weight: bold; color: #FFFFFF">
                            Model
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 390px; font-size: small;">
                            <b>Set Position</b>
                        </td>
                        <td colspan="2" style="background-color: #FFFF80; width: 115px; font-size: 13px;">
                        </td>
                        <td colspan="2" style="background-color: #C0FFC0; width: 110px; font-size: 13px;">
                        </td>
                    </tr>
                    <tr style="font-size: small">
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Front Block Distance" Style="cursor: pointer"
                                onclick="StartSetBlockDistance();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblSetFrontBlockDistanceI" runat="server" Style="cursor: pointer"
                                onclick="FrontBlockDistance();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblSetFrontBlockDistanceM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblSetFrontBlockDistanceF" runat="server" Style="cursor: pointer"
                                onclick="FrontBlockDistance();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblSetFrontBlockDistanceM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Rear Block Distance" Style="cursor: pointer"
                                onclick="StartSetBlockDistance();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblSetRearBlockDistanceI" runat="server" Style="cursor: pointer" onclick="RearBlockDistance();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblSetRearBlockDistanceM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblSetRearBlockDistanceF" runat="server" Style="cursor: pointer" onclick="RearBlockDistance();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblSetRearBlockDistanceM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Front Upper Leg Angle" Style="cursor: pointer"
                                onclick="StartSegmentAnglesatSetPosition();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center;">
                            <asp:Label ID="lblSetFrontULAngleI" runat="server" Style="cursor: pointer" onclick="FrontULAngle();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblSetFrontULAngleM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblSetFrontULAngleF" runat="server" Style="cursor: pointer" onclick="FrontULAngle();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblSetFrontULAngleM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Rear Upper Leg Angle" Style="cursor: pointer"
                                onclick="StartSegmentAnglesatSetPosition();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblSetRearULAngleI" runat="server" Style="cursor: pointer" onclick="RearULAngle();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblSetRearULAngleM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblSetRearULAngleF" runat="server" Style="cursor: pointer" onclick="RearULAngle();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblSetRearULAngleM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Front Lower Leg Angle" Style="cursor: pointer"
                                onclick="StartSegmentAnglesatSetPosition();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblSetFrontLLAngleI" runat="server" Style="cursor: pointer" onclick="FrontLLAngle();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblSetFrontLLAngleM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblSetFrontLLAngleF" runat="server" Style="cursor: pointer" onclick="FrontLLAngle();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblSetFrontLLAngleM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Rear Lower Leg Angle" Style="cursor: pointer"
                                onclick="StartSegmentAnglesatSetPosition();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblSetRearLLAngleI" runat="server" Style="cursor: pointer" onclick="RearLLAngle();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblSetRearLLAngleM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblSetRearLLAngleF" runat="server" Style="cursor: pointer" onclick="RearLLAngle();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblSetRearLLAngleM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Trunk Angle" Style="cursor: pointer" onclick="StartSegmentAnglesatSetPosition();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblSetTrunkAngleI" runat="server" Style="cursor: pointer" onclick="TrunkAngle2();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblSetTrunkAngleM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblSetTrunkAngleF" runat="server" Style="cursor: pointer" onclick="TrunkAngle2();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblSetTrunkAngleM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: COG Distance From Front Block" Style="cursor: pointer"
                                onclick="StartcogDistanceatSetPosition();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblSetCOGDistanceI" runat="server" Style="cursor: pointer" onclick="COG();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblSetCOGDistanceM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblSetCOGDistanceF" runat="server" Style="cursor: pointer" onclick="COG();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblSetCOGDistanceM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <b>Block Clearance</b>
                        </td>
                        <td colspan="2" style="background-color: #FFFF80; width: 115px; font-size: 13px;">
                        </td>
                        <td colspan="2" style="background-color: #C0FFC0; width: 110px; font-size: 13px;">
                        </td>
                    </tr>
                    <%--                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label22" runat="server" Text="Result: Velocity" Style="cursor: pointer"
                                onclick="StartHorizontalVelocity();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblBCVelocityI" runat="server" Style="cursor: pointer" onclick="BC_Velocity1();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblBCVelocityM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblBCVelocityF" runat="server" Style="cursor: pointer" onclick="BC_Velocity1();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblBCVelocityM2" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label23" runat="server" Text="General: Rear Foot Clearance Time" Style="cursor: pointer"
                                onclick="StartGroundTimeandAirTime();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblBCRearFootClearanceTimeI" runat="server" Style="cursor: pointer"
                                onclick="Rear_Foot_Clearance_Time();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblBCRearFootClearanceTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblBCRearFootClearanceTimeF" runat="server" Style="cursor: pointer"
                                onclick="Rear_Foot_Clearance_Time();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblBCRearFootClearanceTimeM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label24" runat="server" Text="General: Front Foot Clearance Time"
                                Style="cursor: pointer" onclick="StartGroundTimeandAirTime();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblBCFrontFootClearanceTimeI" runat="server" Style="cursor: pointer"
                                onclick="Front_Foot_Clearance_Time();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblBCFrontFootClearanceTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblBCFrontFootClearanceTimeF" runat="server" Style="cursor: pointer"
                                onclick="Front_Foot_Clearance_Time();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblBCFrontFootClearanceTimeM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label19" runat="server" Text="General: Air Time" Style="cursor: pointer"
                                onclick="StartGroundTimeandAirTime();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblBCAirTimeI" runat="server" Style="cursor: pointer" onclick="BC_AirTime();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblBCAirTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblBCAirTimeF" runat="server" Style="cursor: pointer" onclick="BC_AirTime();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblBCAirTimeM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label20" runat="server" Text="General: Stride Rate" Style="cursor: pointer"
                                onclick="Start_strideLengthandRate();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblBCStrideRateI" runat="server" Style="cursor: pointer" onclick="BCStrideRide();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblBCStrideRateM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblBCStrideRateF" runat="server" Style="cursor: pointer" onclick="BCStrideRide();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblBCStrideRateM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label21" runat="server" Text="General: Stride Length From Front Block"
                                Style="cursor: pointer" onclick="Start_strideLengthandRate();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblBCStrideLengthI" runat="server" Style="cursor: pointer" onclick="BCStrideLength();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblBCStrideLengthM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblBCStrideLengthF" runat="server" Style="cursor: pointer" onclick="BCStrideLength();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblBCStrideLengthM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label30" runat="server" Text="Specific: Lower Leg Angle at Ankle Cross"
                                Style="cursor: pointer" onclick="SegmentAnglesDuringBlockClearance();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblBCLLAngleACI" runat="server" Style="cursor: pointer" onclick="LowerLegAngle_Ankle();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblBCLLAngleACM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblBCLLAngleACF" runat="server" Style="cursor: pointer" onclick="LowerLegAngle_Ankle();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblBCLLAngleACM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Rear Lower Leg Angle at Rear Takeoff" Style="cursor: pointer"
                                onclick="SegmentAnglesDuringBlockClearance();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblBCRearLLAngleTakeoffI" runat="server" Style="cursor: pointer" onclick="Rear_Lower_Leg_Angle_at_Rear_Takeoff();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblBCRearLLAngleTakeoffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblBCRearLLAngleTakeoffF" runat="server" Style="cursor: pointer" onclick="Rear_Lower_Leg_Angle_at_Rear_Takeoff();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblBCRearLLAngleTakeoffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Front Lower Leg Angle at Front Takeoff"
                                Style="cursor: pointer" onclick="SegmentAnglesDuringBlockClearance();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblBCFrontLLAngleTakeoffI" runat="server" Style="cursor: pointer"
                                onclick="Front_Lower_Leg_Angle_at_Front_Takeoff();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblBCFrontLLAngleTakeoffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblBCFrontLLAngleTakeoffF" runat="server" Style="cursor: pointer"
                                onclick="Front_Lower_Leg_Angle_at_Front_Takeoff();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblBCFrontLLAngleTakeoffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Trunk Angle at Takeoff" Style="cursor: pointer"
                                onclick="SegmentAnglesDuringBlockClearance();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblBCTrunkAngleTakeoffI" runat="server" Style="cursor: pointer" onclick="Trunk_Angle_at_Takeoff();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblBCTrunkAngleTakeoffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblBCTrunkAngleTakeoffF" runat="server" Style="cursor: pointer" onclick="Trunk_Angle_at_Takeoff();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblBCTrunkAngleTakeoffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <b>Step 1</b>
                        </td>
                        <td colspan="2" style="background-color: #FFFF80; width: 115px; font-size: 13px;">
                        </td>
                        <td colspan="2" style="background-color: #C0FFC0; width: 110px; font-size: 13px;">
                        </td>
                    </tr>
                    <%--<tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label29" runat="server" Text="Result: Velocity" Style="cursor: pointer"
                                onclick="StartHorizontalVelocity();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1VelocityI" runat="server" Style="cursor: pointer" onclick="Step1Velocity1();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1VelocityM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1VelocityF" runat="server" Style="cursor: pointer" onclick="Step1Velocity1();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1VelocityM2" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label25" runat="server" Text="General: Ground Time" Style="cursor: pointer"
                                onclick="StartGroundTimeandAirTime();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1GroundTimeI" runat="server" Style="cursor: pointer" onclick="Step1GroundTime();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1GroundTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1GroundTimeF" runat="server" Style="cursor: pointer" onclick="Step1GroundTime();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1GroundTimeM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label26" runat="server" Text="General: Air Time" Style="cursor: pointer"
                                onclick="StartGroundTimeandAirTime();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1AirTimeI" runat="server" Style="cursor: pointer" onclick="Step1AirTime();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1AirTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1AirTimeF" runat="server" Style="cursor: pointer" onclick="Step1AirTime();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1AirTimeM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label27" runat="server" Text="General: Stride Rate" Style="cursor: pointer"
                                onclick="Start_strideLengthandRate();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1StrideRateI" runat="server" Style="cursor: pointer" onclick="Step1_StrideRate();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1StrideRateM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1StrideRateF" runat="server" Style="cursor: pointer" onclick="Step1_StrideRate();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1StrideRateM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label28" runat="server" Text="General: Stride Length" Style="cursor: pointer"
                                onclick="Start_strideLengthandRate();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1StrideLengthI" runat="server" Style="cursor: pointer" onclick="Step_1Stride_Length();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1StrideLengthM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1StrideLengthF" runat="server" Style="cursor: pointer" onclick="Step_1Stride_Length();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1StrideLengthM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label37" runat="server" Text="Specific: COG to Foot Touchdown Distance"
                                Style="cursor: pointer" onclick="StartTouchdowndistance();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1COGDistanceI" runat="server" Style="cursor: pointer" onclick="Step1COG();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1COGDistanceM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1COGDistanceF" runat="server" Style="cursor: pointer" onclick="Step1COG();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1COGDistanceM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label31" runat="server" Text="Specific: Lower Leg Angle at Ankle Cross"
                                Style="cursor: pointer" onclick="StartTouchdowndistance();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1LLAngleACI" runat="server" Style="cursor: pointer" onclick="Step1_LowerLeg_Angle_Ankle();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1LLAngleACM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1LLAngleACF" runat="server" Style="cursor: pointer" onclick="Step1_LowerLeg_Angle_Ankle();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1LLAngleACM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Rear Lower Leg Angle at Takeoff" Style="cursor: pointer"
                                onclick="StartTouchdowndistance();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1LLAngleTakeoffI" runat="server" Style="cursor: pointer" onclick="Step_1_Rear_Leg_Angle();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1LLAngleTakeoffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1LLAngleTakeoffF" runat="server" Style="cursor: pointer" onclick="Step_1_Rear_Leg_Angle();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1LLAngleTakeoffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Trunk Angle at Takeoff" Style="cursor: pointer"
                                onclick="StartTouchdowndistance();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1TrunkAngleTakeoffI" runat="server" Style="cursor: pointer"
                                onclick="Step1Trunk_Angle();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1TrunkAngleTakeoffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1TrunkAngleTakeoffF" runat="server" Style="cursor: pointer"
                                onclick="Step1Trunk_Angle();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1TrunkAngleTakeoffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <b>Step 2</b>
                        </td>
                        <td colspan="2" style="background-color: #FFFF80; width: 115px; font-size: 13px;">
                        </td>
                        <td colspan="2" style="background-color: #C0FFC0; width: 110px; font-size: 13px;">
                        </td>
                    </tr>
                    <%--                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label36" runat="server" Text="Result: Velocity" Style="cursor: pointer"
                                onclick="StartHorizontalVelocity();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2VelocityI" runat="server" Style="cursor: pointer" onclick="Step2Velocity1();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2VelocityM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2VelocityF" runat="server" Style="cursor: pointer" onclick="Step2Velocity1();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2VelocityM2" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label32" runat="server" Text="General: Ground Time" Style="cursor: pointer"
                                onclick="StartGroundTimeandAirTime();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2GroundTimeI" runat="server" Style="cursor: pointer" onclick="Step2GroundTime();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2GroundTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2GroundTimeF" runat="server" Style="cursor: pointer" onclick="Step2GroundTime();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2GroundTimeM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label33" runat="server" Text="General: Air Time" Style="cursor: pointer"
                                onclick="StartGroundTimeandAirTime();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2AirTimeI" runat="server" Style="cursor: pointer" onclick="Step2AirTime();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2AirTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2AirTimeF" runat="server" Style="cursor: pointer" onclick="Step2AirTime();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2AirTimeM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label34" runat="server" Text="General: Stride Rate" Style="cursor: pointer"
                                onclick="Start_strideLengthandRate();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2StrideRateI" runat="server" Style="cursor: pointer" onclick="Step2Stride_Rate();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2StrideRateM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2StrideRateF" runat="server" Style="cursor: pointer" onclick="Step2Stride_Rate();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2StrideRateM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label35" runat="server" Text="General: Stride Length" Style="cursor: pointer"
                                onclick="Start_strideLengthandRate();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2StrideLengthI" runat="server" Style="cursor: pointer" onclick="Step2Stride_Length();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2StrideLengthM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2StrideLengthF" runat="server" Style="cursor: pointer" onclick="Step2Stride_Length();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2StrideLengthM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: COG to Foot Touchdown Distance" Style="cursor: pointer"
                                onclick="COGDistanceandSegmentAnglesDuringStep2();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2COGDistanceI" runat="server" Style="cursor: pointer" onclick="Step2COG();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2COGDistanceM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2COGDistanceF" runat="server" Style="cursor: pointer" onclick="Step2COG();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2COGDistanceM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label ID="Label38" runat="server" Text="Specific: Lower Leg Angle at Ankle Cross"
                                Style="cursor: pointer" onclick="COGDistanceandSegmentAnglesDuringStep2();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAngleACI" runat="server" Style="cursor: pointer" onclick="Step2_LowerLegAngle_Ankle();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAngleACM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAngleACF" runat="server" Style="cursor: pointer" onclick="Step2_LowerLegAngle_Ankle();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAngleACM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Rear Lower Leg Angle at Takeoff" Style="cursor: pointer"
                                onclick="COGDistanceandSegmentAnglesDuringStep2();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAngleTakeoffI" runat="server" Style="cursor: pointer" onclick="Step_2_Rear_Leg_Angle();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAngleTakeoffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAngleTakeoffF" runat="server" Style="cursor: pointer" onclick="Step_2_Rear_Leg_Angle();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAngleTakeoffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Trunk Angle at Takeoff" Style="cursor: pointer"
                                onclick="COGDistanceandSegmentAnglesDuringStep2();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2TrunkAngleTakeoffI" runat="server" Style="cursor: pointer"
                                onclick="Step2_Trunk_Angle_Takeoff();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2TrunkAngleTakeoffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2TrunkAngleTakeoffF" runat="server" Style="cursor: pointer"
                                onclick="Step2_Trunk_Angle_Takeoff();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2TrunkAngleTakeoffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <b>Step 3</b>
                        </td>
                        <td colspan="2" style="background-color: #FFFF80; width: 115px; font-size: 13px;">
                        </td>
                        <td colspan="2" style="background-color: #C0FFC0; width: 110px; font-size: 13px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: COG to Foot Touchdown Distance" Style="cursor: pointer"
                                onclick="StartCOGDistanceDuringStep3();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3COGDistanceI" runat="server" Style="cursor: pointer" onclick="Step3COG();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3COGDistanceM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3COGDistanceF" runat="server" Style="cursor: pointer" onclick="Step3COG();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3COGDistanceM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="<b>Results at Markers</b>" Style="cursor: pointer"
                                onclick="Start_3to5meter();"></asp:Label>
                        </td>
                        <td colspan="2" style="background-color: #FFFF80; width: 115px; font-size: 13px;">
                        </td>
                        <td colspan="2" style="background-color: #C0FFC0; width: 110px; font-size: 13px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Result: Time to 3m (Head Position)" Style="cursor: pointer"
                                onclick="Start_3to5meter();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblTimeTo3mI" runat="server" Style="cursor: pointer" onclick="Timeto3m();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblTimeTo3mM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblTimeTo3mF" runat="server" Style="cursor: pointer" onclick="Timeto3m();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblTimeTo3mM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Result: Time to 5m (Head Position)" Style="cursor: pointer"
                                onclick="Start_3to5meter();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblTimeTo5mI" runat="server" Style="cursor: pointer" onclick="Timeto5m();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblTimeTo5mM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblTimeTo5mF" runat="server" Style="cursor: pointer" onclick="Timeto5m();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblTimeTo5mM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                            <asp:Label runat="server" Text="Result: Body Velocity at 3 Meters (COG Position)"
                                Style="cursor: pointer" onclick="StartHorizontalVelocity();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStart_BodyVolAt3MetersI" runat="server" Style="cursor: pointer" onclick="Step1Velocity1();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStart_BodyVolAt3MetersI1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStart_BodyVolAt3MetersF" runat="server" Style="cursor: pointer" onclick="Step1Velocity1();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStart_BodyVolAt3Meters2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="left" 
                            style="width: 260px; background-color: #006699; color: #FFFFFF; font-weight: bold;">
                            Scores
                        </th>
                        <td ID="Td4" runat="server" align="center" 
                            style="background-color: #006699; color: #FFFFFF; font-weight: bold" 
                            width="143">
                            Initial
                        </td>
                        <td ID="Td5" align="center" 
                            style="background-color: #006699; color: #FFFFFF; width: 143px; font-weight: bold;" 
                            width="143">
                            Model
                        </td>
                        <td ID="Td7" runat="server" align="center" 
                            style="background-color: #006699; color: #FFFFFF; font-weight: bold" 
                            width="143">
                            Final
                        </td>
                        <td ID="Td8" runat="server" align="center" 
                            style="background-color: #006699; color: #FFFFFF; font-weight: bold" 
                            width="143">
                            Model
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 260px; font-size: small;">
                            <asp:Label ID="Label29" runat="server" Style="cursor: pointer" Text="Result: Velocity and Time Compared to Model"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="StartResultScoreI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="StartResultScoreM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="StartResultScoreF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="StartResultScoreM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 260px; font-size: small;">
                            <asp:Label ID="Label53" runat="server" Style="cursor: pointer" Text="General: Time, Rate and Distance Results"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="StartGeneralScoreI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="StartGeneralScoreM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="StartGeneralScoreF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="StartGeneralScoreM2" runat="server"></asp:Label>
                        </td>
                    </tr>
<%--                    <tr>
                        <td style="background-color: #FFB9AF; width: 260px; font-size: small;">
                            <asp:Label ID="Label59" runat="server" Style="cursor: pointer" Text="Special: Stride Length Creation While on Ground"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="StartSpecialScoreI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="StartSpecialScoreM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="StartSpecialScoreF" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="StartSpecialScoreM2" runat="server"></asp:Label>
                        </td>
                    </tr>
--%>                <tr>
                        <td style="background-color: #FFB9AF; width: 260px; font-size: small;">
                            <asp:Label ID="Label65" runat="server" Style="cursor: pointer" Text="Specific: Critical Body Positions"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="StartSpecificScoreI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="StartSpecificScoreM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="StartSpecificScoreF" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="StartSpecificScoreM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <%--   <div class="wrapper">
         <ul>
                <li class="example-item" id="modal" onclick="function demo123();">
                        <img src="../Images/example-3.jpg" width="196" height="147" alt="Example 3">
                        <a href="#">Modal</a>
                 </li>
        </ul>
        </div>--%>
            <div id="HurdleId" runat="server" style="margin-left: 1px;">
                <table id="HurdleHeader" style="float: left; padding: l0px; width: 600px; height: 33px;
                    text-align: center; margin-left: 130px">
                    <!-- height: 40px; margin-top: 10px" !-->
                    <tr>
                        <td style="font-size: 22px; font-family: Magneto;">
                            <b>The Variable Chart: Session Display Mode</b>
                        </td>
                    </tr>
                </table>
                <table id="HurdleText" runat="server" style="float: left; margin-top: 8px; padding: 0px;
                    width: 600px; margin-left: 65px">
                    <tr>
                        <td style="width: 797px; text-align: justify; font-family: Magneto; font-size: 22px;">
                            Session Display Mode
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 794px; font-family: Magneto; font-size: large;">
                                Below the Video Player, the Variable Chart lists the results that are used to evaluate
                                the Maximum Velocity Hurdle. If the results are from an On-Track Session, then the
                                athlete's initial run-through results are shown in the Initial column, while the
                                final effort is shown in the Final column. In both cases, the athlete's Model values
                                are shown in the column to the right of their values. If the athlete's results are
                                in the acceptable range, the Model results are shown in <font color="black">black</font>.
                                If the results are not up to the Model's standard (needs improvement), the result
                                is shown in <font color="red">red</font>).</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 794px; font-family: Magneto; font-size: large;">
                                If the results are from a Competition then the athlete's performance is shown in
                                the Final column, with the athlete's Model values shown in the column to the right 
                                of their values. As in the On-Track Sessions, the Model results are shown in black if
                                acceptabe, or in in <font color="red"> red</font> if not up to the Model's standard.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            Performance Variables are categorized in three Groups: Result, General, and Specific. 
                            The challenge for the Elite Coach is to improve the Specific Variables which will, in 
                            turn, improve the results in the remaining Groups.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 794px; font-family: Magneto; font-size: large;">
                                <%--Information on any of the variables can be found by clicking on the variable name
                                in the Chart.--%>
                                Information on the definition of any of the Variables can be found by clicking on
                                the Variable name in the Chart.  In addition, a graph showing the Athlete’s Variable
                                results for all of their Sessions and Competitions can be displayed by clicking
                                on any of the Athlete's results. In each graph, a grey shaded area will identify
                                the Model result.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            Finally, to provide greater insight into the overall Hurdle performance of an Athlete, 
                            each Session is given a Score in each of the three Groups (Result, General, and Specific) 
                            that includes the quality of every Variable. If the Athlete’s Score 
                            reaches 100, they have matched the Model in every Variable in the Group.  A Score of
                            50 indicates an "Average" elite performance, while a Score of 75 or higher points to 
                            an exceptional Group performance.
                            </p>
                        </td>
                    </tr>
                </table>
                <table id="HurdleTireVarableChart" runat="server" visible="false" style="float: left;
                    margin-top: 30px; padding: 0px; width: 600px; margin-left: 65px">
                    <tr>
                        <td style="width: 797px; text-align: justify; font-family: Magneto; font-size: 22px;">
                            Session Comparison Mode
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 794px; font-family: Magneto; font-size: large;">
                                Below the Video Player, the Variable Chart lists the results that are used to evaluate
                                the Maximum Velocity Hurdle. In Comparison Mode, the results from the Session selected
                                in the left window of the Top Player are shown in the left <font color="#fcc60a">(yellow)</font>
                                column, while the results from the Session selected in the right window are shown
                                in the right <font color="green">(green)</font> column. In both cases, the athlete's
                                Model values are shown in the column to the right of their values. If the athlete's
                                results are in the acceptable range, the Model results are shown in black. If the
                                results are not up to the Model's standard (needs improvement), the result is shown
                                in <font color="red">red</font>.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            Performance Variables are categorized in three Groups: Result, General, and Specific. 
                            The challenge for the Elite Coach is to improve the Specific Variables which will, in 
                            turn, improve the results in the remaining Groups.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            <%-- Information on any of the variables can be found by clicking on the variable name
                                in the Chart.--%>
                            Information on the definition of any of the Variables can be found by clicking on
                            the Variable name in the Chart. In addition, a graph showing the Athlete’s Variable
                            results for all of their Sessions and Competitions can be displayed by clicking
                            on any of the Athlete's results. In each graph, a grey shaded area will identify
                            the Model result. </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            Finally, to provide greater insight into the overall Hurdle performance of an Athlete, 
                            each Session is given a Score in each of the three Groups (Result, General, and Specific) 
                            that includes the quality of every Variable. If the Athlete’s Score 
                            reaches 100, they have matched the Model in every Variable in the Group.  A Score of
                            50 indicates an "Average" elite performance, while a Score of 75 or higher points to 
                            an exceptional Group performance.
                            </p>
                        </td>
                    </tr>
                </table>
                <table id="tblhurdle" cellpadding="0" style="float: left; width: 860px; margin-left: 45px;
                    border: 3px solid black; font-size: small">
                    <tr>
                        <th align="left" style="width: 400px; background-color: #006699; color: #FFFFFF;
                            font-weight: bold">
                            Sessions
                        </th>
                        <td colspan="2" align="center" style="font-size: small; background-color: #006699;
                            color: #FFFFFF; font-weight: bold">
                            <asp:Label ID="lblLeftHurdleMovie" runat="server" Width="240px" ForeColor="White"></asp:Label>
                        </td>
                        <td colspan="2" align="center" style="font-size: small; background-color: #006699;
                            color: #FFFFFF; font-weight: bold">
                            <asp:Label ID="lblRightHurdleMovie" runat="server" Width="240px" ForeColor="White"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="left" style="width: 390px; background-color: #006699; color: #FFFFFF;
                            font-weight: bold;">
                            Variable
                        </th>
                        <td width="120px" id="HurdleInitial" runat="server" align="center" style="background-color: #006699;">
                            Initial
                        </td>
                        <td width="120px" align="center" style="background-color: #006699; color: #FFFFFF;
                            font-weight: bold;">
                            Model
                        </td>
                        <td width="120px" id="HurdleFinal" runat="server" style="background-color: #006699;"
                            align="center">
                            Final
                        </td>
                        <td width="120px" id="Td3" align="center" runat="server" style="background-color: #006699;
                            font-weight: bold; color: #FFFFFF">
                            Model
                        </td>
                    </tr>
                    <tr style="font-size: small">
                        <td style="background-color: #FFE1AA; width: 280px; font-size: 13px;">
                            <asp:Label ID="Label18" runat="server" Text="Result: Hurdle Clearance Velocity" Style="cursor: pointer"
                                onclick="Hurdle_Velocity1();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblVelocityI" runat="server" Style="cursor: pointer" onclick="HurdleVelocitygraph();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblVelocityHurdleM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblVelocityHurdleF" runat="server" Style="cursor: pointer" onclick="HurdleVelocitygraph();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblVelocityHurdleM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="General: Ground Time Into" Style="cursor: pointer"
                                onclick="Hurdle_GroundTime();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblGroundTimeIntoI" runat="server" Style="cursor: pointer" onclick="GroundTimeInto();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblGroundTimeIntoM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblGroundTimeIntoF" runat="server" Style="cursor: pointer" onclick="GroundTimeInto();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblGroundTimeIntoM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="General: Ground Time Off" Style="cursor: pointer"
                                onclick="Hurdle_GroundTime();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblGroundTimeOffI" runat="server" Style="cursor: pointer" onclick="GroundTimeoff();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblGroundTimeOffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblGroundTimeOffF" runat="server" Style="cursor: pointer" onclick="GroundTimeoff();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblGroundTimeOffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="General: Air Time" Style="cursor: pointer" onclick="Hurdle_AirtimeAndStrideRate();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblAirTimeI" runat="server" Style="cursor: pointer" onclick="AirTimeoff();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblAirTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblAirTimeF" runat="server" Style="cursor: pointer" onclick="AirTimeoff();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblAirTimeM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="General: Stride Length Into" Style="cursor: pointer"
                                onclick="Hurdle_StrideLength();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStrideLengthIntoI" runat="server" Style="cursor: pointer" onclick="StrideLengthinto();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStrideLengthIntoM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStrideLengthIntoF" runat="server" Style="cursor: pointer" onclick="StrideLengthinto();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStrideLengthIntoM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="General: Stride Length Off" Style="cursor: pointer"
                                onclick="Hurdle_StrideLength();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStrideLengthOffI" runat="server" Style="cursor: pointer" onclick="StrideLengthoff();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStrideLengthOffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStrideLengthOffF" runat="server" Style="cursor: pointer" onclick="StrideLengthoff();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStrideLengthOffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="General: Stride Length Total" Style="cursor: pointer"
                                onclick="Hurdle_StrideLength();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStrideLengthTotalI" runat="server" Style="cursor: pointer" onclick="Hurdle_StrideLengthTotal();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStrideLengthTotalM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStrideLengthTotalF" runat="server" Style="cursor: pointer" onclick="Hurdle_StrideLengthTotal();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStrideLengthTotalM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: COG to Foot Touchdown Distance Into" Style="cursor: pointer"
                                onclick="HurdleTDIonAndoff();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblTouchdownDistanceIntoI" runat="server" Style="cursor: pointer"
                                onclick="TouchDownDistanceinto();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblTouchdownDistanceIntoM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblTouchdownDistanceIntoF" runat="server" Style="cursor: pointer"
                                onclick="TouchDownDistanceinto();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblTouchdownDistanceIntoM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: COG to Foot Touchdown Distance Off" Style="cursor: pointer"
                                onclick="HurdleTDIonAndoff();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblTouchdownDistanceOffI" runat="server" Style="cursor: pointer" onclick="TouchDownDistanceoff();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblTouchdownDistanceOffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblTouchdownDistanceOffF" runat="server" Style="cursor: pointer" onclick="TouchDownDistanceoff();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblTouchdownDistanceOffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Knee-Knee Separation at Touchdown Into"
                                Style="cursor: pointer" onclick="HurdleKneeSeparationForPlayer();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblKneeSeparationatTouchdownIntoI" runat="server" Style="cursor: pointer"
                                onclick="KneeSeparationtouchdowninto();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblKneeSeparationatTouchdownIntoM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblKneeSeparationatTouchdownIntoF" runat="server" Style="cursor: pointer"
                                onclick="KneeSeparationtouchdowninto();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblKneeSeparationatTouchdownIntoM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Knee-Ankle Separation at Touchdown Off"
                                Style="cursor: pointer" onclick="HurdleKneeSeparationForPlayer();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblKneeSeparationatTouchdownOffI" runat="server" Style="cursor: pointer"
                                onclick="KneeSeparationtouchdownoff();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblKneeSeparationatTouchdownOffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblKneeSeparationatTouchdownOffF" runat="server" Style="cursor: pointer"
                                onclick="KneeSeparationtouchdownoff();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblKneeSeparationatTouchdownOffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Trunk Angle at Touchdown Into" Style="cursor: pointer"
                                onclick="HurdleTrunkAngleForPlayer();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkAngleatTouchdownIntoI" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_TrunkAngleTouchdownInto();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkAngleatTouchdownIntoM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkAngleatTouchdownIntoF" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_TrunkAngleTouchdownInto();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkAngleatTouchdownIntoM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Trunk Angle at Takeoff Into" Style="cursor: pointer"
                                onclick="HurdleTrunkAngleForPlayer();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkAngleatTakeoffIntoI" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_TrunkAngleTakeoffInto();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkAngleatTakeoffIntoM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkAngleatTakeoffIntoF" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_TrunkAngleTakeoffInto();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkAngleatTakeoffIntoM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Trunk Minimum Angle Over" Style="cursor: pointer"
                                onclick="HurdleTrunkAngleForPlayer();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkMinimumAngleOverI" runat="server" Style="cursor: pointer"
                                onclick="TrunkMinimumAngle();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkMinimumAngleOverM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkMinimumAngleOverF" runat="server" Style="cursor: pointer"
                                onclick="TrunkMinimumAngle();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkMinimumAngleOverM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Trunk Angle at Touchdown Off" Style="cursor: pointer"
                                onclick="HurdleTrunkAngleForPlayer();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkAngleatTouchdownOffI" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_TrunkAngleTouchdownoff();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkAngleatTouchdownOffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkAngleatTouchdownOffF" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_TrunkAngleTouchdownoff();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkAngleatTouchdownOffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Trunk Angle at Takeoff Off" Style="cursor: pointer"
                                onclick="HurdleTrunkAngleForPlayer();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkAngleatTakeoffOffI" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_TrunkAngleatTakeoffOff();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkAngleatTakeoffOffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkAngleatTakeoffOffF" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_TrunkAngleatTakeoffOff();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblTrunkAngleatTakeoffOffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Trail Upper Leg Angle at Touchdown Into"
                                Style="cursor: pointer" onclick="Hurdle_UpperLegTDInto();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblUpperLegAngleatTouchdownIntoI" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_TrailUpperLegAngleatTouchdownInto();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblUpperLegAngleatTouchdownIntoM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblUpperLegAngleatTouchdownIntoF" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_TrailUpperLegAngleatTouchdownInto();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblUpperLegAngleatTouchdownIntoM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Trail Upper Leg Angle at Takeoff Into"
                                Style="cursor: pointer" onclick="Hurdle_UpperLegTDInto();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblUpperLegAngleatTakeoffIntoI" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_TrailUpperLegAngleTakeoffInto();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblUpperLegAngleatTakeoffIntoM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblUpperLegAngleatTakeoffIntoF" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_TrailUpperLegAngleTakeoffInto();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblUpperLegAngleatTakeoffIntoM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Lead Upper Leg Maximum Angle Over" Style="cursor: pointer"
                                onclick="Hurdle_UpperLegTDInto();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblLeadUpperLegMaximumAngleOverI" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_LeadUpperLegMaximumAngleOver();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblLeadUpperLegMaximumAngleOverM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblLeadUpperLegMaximumAngleOverF" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_LeadUpperLegMaximumAngleOver();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblLeadUpperLegMaximumAngleOverM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Lead Upper Leg Angle at Touchdown Off"
                                Style="cursor: pointer" onclick="Hurdle_UpperLegTDInto();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblUpperLegAngleatTouchdownOffI" runat="server" Style="cursor: pointer"
                                onclick="LeadUpperLegAngleTouchdownOff();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblUpperLegAngleatTouchdownOffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblUpperLegAngleatTouchdownOffF" runat="server" Style="cursor: pointer"
                                onclick="LeadUpperLegAngleTouchdownOff();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblUpperLegAngleatTouchdownOffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Lead Upper Leg Angle at Takeoff Off" Style="cursor: pointer"
                                onclick="Hurdle_UpperLegTDInto();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblUpperLegAngleatTakeoffOffI" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_LeadUpperLegAngleTakeoffOff();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblUpperLegAngleatTakeoffOffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblUpperLegAngleatTakeoffOffF" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_LeadUpperLegAngleTakeoffOff();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblUpperLegAngleatTakeoffOffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Lead Lower Leg Minimum Angle Into" Style="cursor: pointer"
                                onclick="HurdleLowerLegRecoveryMotion();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblLeadLowerLegMinimumAngleIntoI" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_LeadLowerLegMinimumAngleInto();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblLeadLowerLegMinimumAngleIntoM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblLeadLowerLegMinimumAngleIntoF" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_LeadLowerLegMinimumAngleInto();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblLeadLowerLegMinimumAngleIntoM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Lead Lower Leg Angle at Ankle Cross Into"
                                Style="cursor: pointer" onclick="HurdleLowerLegRecoveryMotion();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblLeadLowerLegAngleatAnkleCrossIntoI" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_LeadLowerLegAngleAnkleCrossInto();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblLeadLowerLegAngleatAnkleCrossIntoM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblLeadLowerLegAngleatAnkleCrossIntoF" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_LeadLowerLegAngleAnkleCrossInto();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblLeadLowerLegAngleatAnkleCrossIntoM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Knee-Ankle Vertical Separation Over"
                                Style="cursor: pointer" onclick="Hurdle_KneeAnkleSeparationOver();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblTrailKneeAnkleMinimumSeparationOverI" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_KneeAnkleMinimumSeparationOver();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblTrailKneeAnkleMinimumSeparationOverM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblTrailKneeAnkleMinimumSeparationOverF" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_KneeAnkleMinimumSeparationOver();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblTrailKneeAnkleMinimumSeparationOverM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Lead Lower Leg Maximum Angle Over" Style="cursor: pointer"
                                onclick="HurdleLowerLegRecoveryMotion();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblLeadLowerLegMaximumAngleOverI" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_LeadLowerLegMaximumAngleOver();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblLeadLowerLegMaximumAngleOverM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblLeadLowerLegMaximumAngleOverF" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_LeadLowerLegMaximumAngleOver();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblLeadLowerLegMaximumAngleOverM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Lead Lower Leg Angle at Touchdown Off"
                                Style="cursor: pointer" onclick="HurdleLowerLegMotion();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleatTouchdownOffI" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_LeadLowerLegAngleTouchdownOff();"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleatTouchdownOffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleatTouchdownOffF" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_LeadLowerLegAngleTouchdownOff();"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleatTouchdownOffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 280px; font-size: 13px;">
                            <asp:Label runat="server" Text="Specific: Lead Lower Leg Angle at Takeoff Off" Style="cursor: pointer"
                                onclick="HurdleLowerLegMotion();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleatTakeoffOffI" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_LeadLowerLegAngleTakeoffOff();"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleatTakeoffOffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleatTakeoffOffF" runat="server" Style="cursor: pointer"
                                onclick="Hurdle_LeadLowerLegAngleTakeoffOff();"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleatTakeoffOffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                             <tr>
                                 <th align="left" 
                                     style="width: 260px; background-color: #006699; color: #FFFFFF; font-weight: bold;">
                                     Scores
                                 </th>
                                 <td ID="Td9" runat="server" align="center" 
                                     style="background-color: #006699; color: #FFFFFF; font-weight: bold" 
                                     width="143">
                                     Initial
                                 </td>
                                 <td ID="Td10" align="center" 
                                     style="background-color: #006699; color: #FFFFFF; width: 143px; font-weight: bold;" 
                                     width="143">
                                     Model
                                 </td>
                                 <td ID="Td11" runat="server" align="center" 
                                     style="background-color: #006699; color: #FFFFFF; font-weight: bold" 
                                     width="143">
                                     Final
                                 </td>
                                 <td ID="Td12" runat="server" align="center" 
                                     style="background-color: #006699; color: #FFFFFF; font-weight: bold" 
                                     width="143">
                                     Model
                                 </td>
                    </tr>
                    <tr>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                        <td style="height: 5px; background-color: #666633">
                        </td>
                    </tr>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 260px; font-size: small;">
                            <asp:Label ID="Label36" runat="server" Style="cursor: pointer" Text="Result: Velocity Compared to Model"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="HurdleResultScoreI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="HurdleResultScoreM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="HurdleResultScoreF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="HurdleResultScoreM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 260px; font-size: small;">
                            <asp:Label ID="Label55" runat="server" Style="cursor: pointer" Text="General: Time and Distance Results"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="HurdleGeneralScoreI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="HurdleGeneralScoreM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="HurdleGeneralScoreF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="HurdleGeneralScoreM2" runat="server"></asp:Label>
                        </td>
                    </tr>
<%--                    <tr>
                        <td style="background-color: #FFB9AF; width: 260px; font-size: small;">
                            <asp:Label ID="Label63" runat="server" Style="cursor: pointer" Text="Special:"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="HurdleSpecialScoreI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="HurdleSpecialScoreM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="HurdleSpecialScoreF" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="HurdleSpecialScoreM2" runat="server"></asp:Label>
                        </td>
                    </tr>
--%>                <tr>
                        <td style="background-color: #FFB9AF; width: 260px; font-size: small;">
                            <asp:Label ID="Label69" runat="server" Style="cursor: pointer" Text="Specific: Critical Body Positions"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="HurdleSpecificScoreI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="HurdleSpecificScoreM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="HurdleSpecificScoreF" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="HurdleSpecificScoreM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="HurdleStepId" runat="server">
                <table id="HurdleStepsHeader" style="float: left; padding: 0px; width: 749px; height: 28px;
                    font-size: 21px; text-align: center; margin-left: 70px; font-family: Magneto;">
                    <!-- height: 75px; !-->
                    <tr>
                        <td style="font-size: 22px; font-family: Magneto;">
                            <b>The Variable Chart</b>
                        </td>
                    </tr>
                </table>
                <table id="HurdleStepText" runat="server" style="float: left; width: 86%; margin-left: 65px">
                    <tr>
                        <td style="width: 797px; text-align: justify; font-family: Magneto; font-size: 22px;">
                            Session Display Mode
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                                Below the Video Player, the Variable Chart lists the results that are used to evaluate
                                the Hurdle Steps. If the results are from an On-Track Session, then the athlete's
                                initial run-through results are shown in the Initial column, while the final effort
                                is shown in the Final column. In both cases, the athlete's Model values are shown
                                in the column to the right of their values. If the athlete's results are in the
                                acceptable range, the Model results are shown in <font color="black"><b>black</b></font>.
                                If the results are not up to the Model's standard (needs improvement), the result
                                is shown in <font color="red">red</font>.</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                                If the results are from a Competition then the athlete's performance is shown in
                                the Final column, with the athlete's Model values shown in the column to the right 
                                of their values. As in the On-Track Sessions, the Model results are shown in black if
                                acceptabe, or in in <font color="red"> red</font> if not up to the Model's standard.
                             </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            Performance Variables are categorized in three Groups: Result, General, and Specific. 
                            The challenge for the Elite Coach is to improve the Specific Variables which will, in 
                            turn, improve the results in the remaining Groups.
                            </p>
                        </td>
                    </tr>
                        <tr>
                        <td>
                            <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                                <%--Information on any of the variables can be found by clicking on the variable name
                                in the Chart.--%>
                                Information on the definition of any of the Variables can be found by clicking on
                                the Variable name in the Chart.  In addition, a graph showing the Athlete’s Variable
                                results for all of their Sessions and Competitions can be displayed by clicking
                                on any of the Athlete's results. In each graph, a grey shaded area will identify
                                the Model result.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            Finally, to provide greater insight into the overall Hurdle Step performance of an Athlete, 
                            each Session is given a Score in each of the three Groups (Result, General, and Specific) 
                            that includes the quality of every Variable. If the Athlete’s Score 
                            reaches 100, they have matched the Model in every Variable in the Group.  A Score of
                            50 indicates an "Average" elite performance, while a Score of 75 or higher points to 
                            an exceptional Group performance.
                            </p>
                        </td>
                    </tr>
                </table>
                <table id="HurdleStepTireVariablesText" runat="server" visible="false" style="float: left;
                    padding: 0px; width: 86%; margin-left: 65px;">
                    <tr>
                        <td style="width: 797px; text-align: justify; font-family: Magneto; font-size: 22px;">
                            Session Comparison Mode
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                                Below the Video Player, the Variable Chart lists the results that are used to evaluate
                                the Maximum Hurdle Steps Velocity. In Comparison Mode, the results from the Session
                                selected in the left window of the Top Player are shown in the left <font color="#fcc60a">
                                    (yellow)</font> column, while the results from the Session selected in the right
                                window are shown in the right <font color="green">(green)</font> column. In both
                                cases, the athlete's Model values are shown in the column to the right of their
                                values. If the athlete's results are in the acceptable range, the Model results
                                are shown in black. If the results are not up to the Model's standard (needs improvement),
                                the result is shown in <font color="red">red</font>.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            Performance Variables are categorized in three Groups: Result, General, and Specific. 
                            The challenge for the Elite Coach is to improve the Specific Variables which will, in 
                            turn, improve the results in the remaining Groups.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td> 
                        <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            <%-- Information on any of the variables can be found by clicking on the variable name
                                in the Chart.--%>
                            Information on the definition of any of the Variables can be found by clicking on
                            the Variable name in the Chart. In addition, a graph showing the Athlete’s Variable
                            results for all of their Sessions and Competitions can be displayed by clicking
                            on any of the Athlete's results. In each graph, a grey shaded area will identify
                            the Model result. </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            Finally, to provide greater insight into the overall Hurdle Step performance of an Athlete, 
                            each Session is given a Score in each of the three Groups (Result, General, and Specific) 
                            that includes the quality of every Variable. If the Athlete’s Score 
                            reaches 100, they have matched the Model in every Variable in the Group.  A Score of
                            50 indicates an "Average" elite performance, while a Score of 75 or higher points to 
                            an exceptional Group performance.
                            </p>
                        </td>
                    </tr>
                </table>
                <div>
                    <table id="tblstephurdle" cellpadding="0" style="float: left; width: 834px; margin-left: 53px;
                        border: 3px solid black; font-size: small">
                        <tr>
                            <td width="270px" align="left" style="background-color: #006699; color: #FFFFFF;
                                font-weight: bold">
                                Sessions
                            </td>
                            <td colspan="2" align="center" style="font-size: small; background-color: #006699;
                                color: #FFFFFF; font-weight: bold">
                                <asp:Label ID="lblHurdleStepLeftMovie" runat="server" Width="240px" ForeColor="White"></asp:Label>
                            </td>
                            <td colspan="2" align="center" style="font-size: small; background-color: #006699;
                                color: #FFFFFF; font-weight: bold">
                                <asp:Label ID="lblHurdleStepRightMovie" runat="server" Width="240px" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="270px" align="left" style="background-color: #006699; color: #FFFFFF;
                                font-weight: bold;">
                                Variable
                            </td>
                            <td width="120px" id="HurdleStepInitial" runat="server" align="center" style="background-color: #006699;">
                                Initial
                            </td>
                            <td width="120px" align="center" style="background-color: #006699; color: #FFFFFF;
                                font-weight: bold;">
                                Model
                            </td>
                            <td width="120px" id="HurdleStepFinal" runat="server" style="background-color: #006699;"
                                align="center">
                                Final
                            </td>
                            <td width="120px" id="Td6" align="center" runat="server" style="background-color: #006699;
                                font-weight: bold; color: #FFFFFF">
                                Model
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 390px; font-size: small;">
                                <b>Hurdle Distances </b>
                            </td>
                            <td colspan="2" style="background-color: #EBEB41; width: 115px; font-size: 13px;">
                            </td>
                            <td colspan="2" style="background-color: #91F591; width: 110px; font-size: 13px;">
                            </td>
                        </tr>
                        <tr style="font-size: small">
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Setting: Between the Hurdles" Style="cursor: pointer"
                                    onclick="BeetweenTheHurdle_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblHurdleStepBetweenI" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblHurdleStepBetweenM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblHurdleStepBetweenF" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblHurdleStepBetweenM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="3">
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="General: Stride Length Into" Style="cursor: pointer"
                                    onclick="TouchDownDist();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblHurdleStepIntoI" runat="server" Style="cursor: pointer" onclick="Hurdle_Distance_StrideLengthInto();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblHurdleStepIntoM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblHurdleStepIntoF" runat="server" Style="cursor: pointer" onclick="Hurdle_Distance_StrideLengthInto();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblHurdleStepIntoM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="4">
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="General: Stride Length Off" Style="cursor: pointer"
                                    onclick="TouchDownDist();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center;">
                                <asp:Label ID="lblHurdleStepOffI" runat="server" Style="cursor: pointer" onclick="Hurdle_Distance_StrideLengthOff();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblHurdleStepOffM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblHurdleStepOffF" runat="server" Style="cursor: pointer" onclick="Hurdle_Distance_StrideLengthOff();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblHurdleStepOffM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="5">
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        <tr id="6">
                            <td style="background-color: #FFE1AA; font-size: 13px;">
                                <asp:Label runat="server" Text="<b>Result: Hurdle Step Velocity </b>" Style="cursor: pointer"
                                    onclick="VelocityHurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblHurdleStepVelocityI" runat="server" Style="cursor: pointer" onclick="Hurdle_Distance_Velocity();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblHurdleStepVelocityM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblHurdleStepVelocityF" runat="server" Style="cursor: pointer" onclick="Hurdle_Distance_Velocity();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblHurdleStepVelocityM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="7">
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        <tr id="8">
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <b>Step One</b>
                            </td>
                            <td colspan="2" style="background-color: #EBEB41; width: 115px; font-size: 13px;">
                            </td>
                            <td colspan="2" style="background-color: #91F591; width: 110px; font-size: 13px;">
                            </td>
                        </tr>
                        <tr id="9">
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="General: Ground Time" Style="cursor: pointer" onclick="GroundTimeHurdleStep();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1HSGroundTimeI" runat="server" Style="cursor: pointer" onclick="HurdleStep_GroundTime();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1HSGroundTimeM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1HSGroundTimeF" runat="server" Style="cursor: pointer" onclick="HurdleStep_GroundTime();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1HSGroundTimeM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="10">
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="General: Air Time" Style="cursor: pointer" onclick="AirTimeHurdleStep();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1HSAirTimeI" runat="server" Style="cursor: pointer" onclick="HurdleStep_AirTime();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1HSAirTimeM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1HSAirTimeF" runat="server" Style="cursor: pointer" onclick="HurdleStep_AirTime();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1HSAirTimeM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <%--  <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                             onclick="OpenVariablePopup('../VariablePages/TimeToUpperLegFullFlexion.aspx')">
                            Upper Leg Flexion Time
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                         <asp:Label ID="lblStep1UlFlexTimeI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                         <asp:Label ID="lblStep1UlFlexTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1UlFlexTimeF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1UlFlexTimeM2" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                        <tr id="11">
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="General: Stride Rate" Style="cursor: pointer" onclick="StrideRateHurdleStep();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1HSStrideRateI" runat="server" Style="cursor: pointer" onclick="HurdleStep_StrideRate();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1HSStrideRateM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1HSStrideRateF" runat="server" Style="cursor: pointer" onclick="HurdleStep_StrideRate();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1HSStrideRateM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="12">
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="General: Stride Length" Style="cursor: pointer" onclick="StrideLengthHurdleStep();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1HSStrideLengthI" runat="server" Style="cursor: pointer" onclick="HurdleStep1_StrideLength();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1HSStrideLengthM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1HSStrideLengthF" runat="server" Style="cursor: pointer" onclick="HurdleStep1_StrideLength();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1HSStrideLengthM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="13">
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: COG to Foot Touchdown Distance" Style="cursor: pointer"
                                    onclick="TouchDown_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1TouchdownDistanceI" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep_TouchDown();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1TouchdownDistanceM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1TouchdownDistanceF" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep_TouchDown();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1TouchdownDistanceM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="14">
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: Knee-Ankle Separation at Touchdown" Style="cursor: pointer"
                                    onclick="KneeSeperation_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1KSTouchdownI" runat="server" Style="cursor: pointer" onclick="HurdleStep_KneeSeperationTouchdown();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1KSTouchdownM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1KSTouchdownF" runat="server" Style="cursor: pointer" onclick="HurdleStep_KneeSeperationTouchdown();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1KSTouchdownM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="15">
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: Trunk Angle at Touchdown" Style="cursor: pointer"
                                    onclick="TrunkAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1TrunkTouchdownAngleI" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep_TrunkTouchdownAngle();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1TrunkTouchdownAngleM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1TrunkTouchdownAngleF" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep_TrunkTouchdownAngle();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1TrunkTouchdownAngleM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="19">
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label ID="Label39" runat="server" Text="Specific: Upper Leg Angle at Full Flexion"
                                    Style="cursor: pointer" onclick="UpperLegAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1ULFullFlexionI" runat="server" Style="cursor: pointer" onclick="HurdleStep1_UpperLegAngleFullFlexion();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1ULFullFlexionM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1ULFullFlexionF" runat="server" Style="cursor: pointer" onclick="HurdleStep1_UpperLegAngleFullFlexion();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1ULFullFlexionM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="18">
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label ID="Label41" runat="server" Text="Specific: Lower Leg Angle at Takeoff"
                                    Style="cursor: pointer" onclick="LowerLegAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1LLAtTakeoffI" runat="server" Style="cursor: pointer" onclick="Hurdle_LowerLegTakeoff();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1LLAtTakeoffM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1LLAtTakeoffF" runat="server" Style="cursor: pointer" onclick="Hurdle_LowerLegTakeoff();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1LLAtTakeoffM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="16">
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: Trunk Angle at Takeoff" Style="cursor: pointer"
                                    onclick="TrunkAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1TrunkTakeoffAngleI" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep1_TrunkTakeoffAngle();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1TrunkTakeoffAngleM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1TrunkTakeoffAngleF" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep1_TrunkTakeoffAngle();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1TrunkTakeoffAngleM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="17">
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label ID="Label40" runat="server" Text="Specific: Upper Leg Angle at Full Extension"
                                    Style="cursor: pointer" onclick="UpperLegAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1ULFullExtensionI" runat="server" Style="cursor: pointer" onclick="Hurdle_UpperLegAngleFullExtension();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1ULAtFullExtensionM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1ULAtFullExtensionF" runat="server" Style="cursor: pointer"
                                    onclick="Hurdle_UpperLegAngleFullExtension();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep1ULFullExtensionM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <b>Step Two</b>
                            </td>
                            <td colspan="2" style="background-color: #EBEB41; width: 115px; font-size: 13px;">
                            </td>
                            <td colspan="2" style="background-color: #91F591; width: 110px; font-size: 13px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="General: Ground Time" Style="cursor: pointer" onclick="GroundTimeHurdleStep();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2HSGroundTimeI" runat="server" Style="cursor: pointer" onclick="HurdleStep2_GroundTime();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2HSGroundTimeM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2HSGroundTimeF" runat="server" Style="cursor: pointer" onclick="HurdleStep2_GroundTime();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2HSGroundTimeM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="General: Air Time" Style="cursor: pointer" onclick="AirTimeHurdleStep();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2HSAirTimeI" runat="server" Style="cursor: pointer" onclick="HurdleStep2_AirTime();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2HSAirTimeM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2HSAirTimeF" runat="server" Style="cursor: pointer" onclick="HurdleStep2_AirTime();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2HSAirTimeM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <%--  <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/TimeToUpperLegFullFlexion.aspx')">
                            Upper Leg Flexion Time
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2UlFlexTimeI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2UlFlexTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2UlFlexTimeF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2UlFlexTimeM2" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                        <tr>
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="General: Stride Rate" Style="cursor: pointer" onclick="StrideRateHurdleStep();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2HSStrideRateI" runat="server" Style="cursor: pointer" onclick="HurdleStep2_Striderate();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2HSStrideRateM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2HSStrideRateF" runat="server" Style="cursor: pointer" onclick="HurdleStep2_Striderate();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2HSStrideRateM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="General: Stride Length" Style="cursor: pointer" onclick="StrideLengthHurdleStep();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2HSStrideLengthI" runat="server" Style="cursor: pointer" onclick="HurdleStep2_StrideLength();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStepHS2StrideLengthM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2HSStrideLengthF" runat="server" Style="cursor: pointer" onclick="HurdleStep2_StrideLength();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2HSStrideLengthM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: COG to Foot Touchdown Distance" Style="cursor: pointer"
                                    onclick="TouchDown_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2TouchdownDistanceI" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep2_TouchdownDistance();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2TouchdownDistanceM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2TouchdownDistanceF" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep2_TouchdownDistance();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2TouchdownDistanceM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: Knee-Knee Separation at Touchdown" Style="cursor: pointer"
                                    onclick="KneeSeperation_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2KSAtTouchdownI" runat="server" Style="cursor: pointer" onclick="HurdleStep2_KneeSeperationTouchdown();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2KSAtTouchdownM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2KSAtTouchdownF" runat="server" Style="cursor: pointer" onclick="HurdleStep2_KneeSeperationTouchdown();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2KSAtTouchdownM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: Trunk Angle at Touchdown" Style="cursor: pointer"
                                    onclick="TrunkAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2TrunkTouchdownAngleI" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep2_TrunkAngleTouchdown();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2TrunkTouchdownAngleM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2TrunkTouchdownAngleF" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep2_TrunkAngleTouchdown();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2TrunkTouchdownAngleM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: Lower Leg Angle at Full Flexion" Style="cursor: pointer"
                                    onclick="LowerLegAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2LLAtFullFlexionI" runat="server" Style="cursor: pointer" onclick="HurdleStep2_LowerLegFullFlexion();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2LLFullAtFlexionM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2LLAtFullFlexionF" runat="server" Style="cursor: pointer" onclick="HurdleStep2_LowerLegFullFlexion();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2LLAtFullFlexionM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label ID="Label44" runat="server" Text="Specific: Lower Leg Angle at Takeoff"
                                    Style="cursor: pointer" onclick="LowerLegAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2LLAtTakeoffI" runat="server" Style="cursor: pointer" onclick="HurdleStep2_LowerLegTakeoff();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2LLAtTakeoffM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2LLAtTakeoffF" runat="server" Style="cursor: pointer" onclick="HurdleStep2_LowerLegTakeoff();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2LLAtTakeoffM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label ID="Label42" runat="server" Text="Specific: Trunk Angle at Takeoff" Style="cursor: pointer"
                                    onclick="TrunkAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2TrunkTakeoffAngleI" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep2_TrunkAngleTakeoff();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2TrunkTakeoffAngleM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2TrunkTakeoffAngleF" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep2_TrunkAngleTakeoff();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2TrunkTakeoffAngleM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label ID="Label43" runat="server" Text="Specific: Upper Leg Angle at Full Extension"
                                    Style="cursor: pointer" onclick="UpperLegAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2ULAtFullExtensionI" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep2_UpperLegAngleFullExtension();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2ULAtFullExtensionM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2ULAtFullExtensionF" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep2_UpperLegAngleFullExtension();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2ULAtFullExtensionM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <%--<tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/LowerLegAngles_HurdleSteps.aspx')">
                            Lower Leg at Ankle Cross
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAtAngleCrossI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAtAngleCrossM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAtAngleCrossF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAtAngleCrossM2" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: Upper Leg Angle at Full Flexion" Style="cursor: pointer"
                                    onclick="UpperLegAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2ULAtFullFlexionI" runat="server" Style="cursor: pointer" onclick="HurdleStep2_UpperLegAngleFullFlexion();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2ULAtFullFlexionM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2ULAtFullFlexionF" runat="server" Style="cursor: pointer" onclick="HurdleStep2_UpperLegAngleFullFlexion();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep2ULAtFullFlexionM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <b>Step Three</b>
                            </td>
                            <td colspan="2" style="background-color: #EBEB41; width: 115px; font-size: 13px;">
                            </td>
                            <td colspan="2" style="background-color: #91F591; width: 110px; font-size: 13px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="General: Ground Time" Style="cursor: pointer" onclick="GroundTimeHurdleStep();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3HSGroundTimeI" runat="server" Style="cursor: pointer" onclick="HurdleStep3_GroundTime();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3HSGroundTimeM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3HSGroundTimeF" runat="server" Style="cursor: pointer" onclick="HurdleStep3_GroundTime();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3HSGroundTimeM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="General: Air Time" Style="cursor: pointer" onclick="AirTimeHurdleStep();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3HSAirTimeI" runat="server" Style="cursor: pointer" onclick="HurdleStep3_AirTime();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3HSAirTimeM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3HSAirTimeF" runat="server" Style="cursor: pointer" onclick="HurdleStep3_AirTime();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3HSAirTimeM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <%-- <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/TimeToUpperLegFullFlexion.aspx')">
                           Upper Leg Flexion Time
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep3UlFlexTimeI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep3UlFlexTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3UlFlexTimeF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3UlFlexTimeM2" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                        <tr>
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="General: Stride Rate" Style="cursor: pointer" onclick="StrideRateHurdleStep();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3StrideRateI" runat="server" Style="cursor: pointer" onclick="HurdleStep3_StrideRateGraph();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3StrideRateM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3StrideRateF" runat="server" Style="cursor: pointer" onclick="HurdleStep3_StrideRateGraph();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3StrideRateM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="General: Stride Length" Style="cursor: pointer" onclick="StrideLengthHurdleStep();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3StrideLengthI" runat="server" Style="cursor: pointer" onclick="HurdleStep3_StrideLength();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3StrideLengthM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3StrideLengthF" runat="server" Style="cursor: pointer" onclick="HurdleStep3_StrideLength();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3StrideLengthM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: COG to Foot Touchdown Distance" Style="cursor: pointer"
                                    onclick="TouchDown_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3TouchdownDistanceI" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep3_TouchdownDistance();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3TouchdownDistanceM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3TouchdownDistanceF" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep3_TouchdownDistance();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3TouchdownDistanceM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: Knee-Knee Separation at Touchdown" Style="cursor: pointer"
                                    onclick="KneeSeperation_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3KSAtTouchdownI" runat="server" Style="cursor: pointer" onclick="HurdleStep3_KneeSeperationTouchdown();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3KSAtTouchdownM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3KSAtTouchdownF" runat="server" Style="cursor: pointer" onclick="HurdleStep3_KneeSeperationTouchdown();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3KSAtTouchdownM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: Trunk Angle at Touchdown" Style="cursor: pointer"
                                    onclick="TrunkAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3TrunkTouchdownAngleI" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep3_TrunkTouchdown();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3TrunkTouchdownAngleM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3TrunkTouchdownAngleF" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep3_TrunkTouchdown();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3TrunkTouchdownAngleM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label ID="Label46" runat="server" Text="Specific: Lower Leg Angle at Full Flexion"
                                    Style="cursor: pointer" onclick="LowerLegAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3LLAtFullFlexionI" runat="server" Style="cursor: pointer" onclick="HurdleStep3_LowerLegAngleFullFlexion();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3LLAtFullFlexionM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3LLAtFullFlexionF" runat="server" Style="cursor: pointer" onclick="HurdleStep3_LowerLegAngleFullFlexion();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3LLAtFullFlexionM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: Lower Leg Angle at Takeoff" Style="cursor: pointer"
                                    onclick="LowerLegAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3LLAtTakeoffI" runat="server" Style="cursor: pointer" onclick="HurdleStep3_LowerLegTakeoff();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3LLAtTakeoffM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3LLAtTakeoffF" runat="server" Style="cursor: pointer" onclick="HurdleStep3_LowerLegTakeoff();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3LLAtTakeoffM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label ID="Label45" runat="server" Text="Specific: Trunk Angle at Takeoff" Style="cursor: pointer"
                                    onclick="TrunkAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3TrunkTakeoffAngleI" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep3_TrunkAngleTakeoff();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3TrunkTakeoffAngleM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3TrunkTakeoffAngleF" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep3_TrunkAngleTakeoff();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3TrunkTakeoffAngleM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <%--<tr>
                        <td style="background-color: #FFB9AF; font-size: 13px; "
                            
                            onclick="OpenVariablePopup('../VariablePages/LowerLegAngles_HurdleSteps.aspx')" 
                            class="style1">
                            Lower Leg at Ankle Cross
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3LLAtAngleCrossI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3LLAtAngleCrossM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3LLAtAngleCrossF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3LLAtAngleCrossM2" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                        <tr>
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label ID="Label47" runat="server" Text="Specific: Upper Leg Angle at Full Extension"
                                    Style="cursor: pointer" onclick="UpperLegAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3ULAtFullExtensionI" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep3_UpperLegAngleFullExtension();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3ULAtFullExtensionM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3ULAtFullExtensionF" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep3_UpperLegAngleFullExtension();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3ULAtFullExtensionM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: Upper Leg Angle at Full Flexion" Style="cursor: pointer"
                                    onclick="UpperLegAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3ULAtFullFlexionI" runat="server" Style="cursor: pointer" onclick="HurdleStep3_UpperLegAngleFullFlexion();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3ULAtFullFlexionM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3ULAtFullFlexionF" runat="server" Style="cursor: pointer" onclick="HurdleStep3_UpperLegAngleFullFlexion();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblStep3ULAtFullFlexionM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="<b>Into The Hurdle </b>" Style="cursor: pointer"
                                    onclick="SegmentAnglesDuringBlockClearance();"></asp:Label>
                            </td>
                            <td colspan="2" style="background-color: #EBEB41; width: 110px; font-size: 13px;">
                            </td>
                            <td colspan="2" style="background-color: #91F591; width: 110px; font-size: 13px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: COG to Foot Touchdown Distance" Style="cursor: pointer"
                                    onclick="TouchDown_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblIntoHurdleTouchdownDistanceI" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep3_intoTouchdownDistance();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblIntoHurdleTouchdownDistanceM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblIntoHurdleTouchdownDistanceF" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep3_intoTouchdownDistance();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblIntoHurdleTouchdownDistanceM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: Knee-Knee Separation at Touchdown" Style="cursor: pointer"
                                    onclick="KneeSeperation_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblIntoHurdleKSTouchdownI" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep3_KneeSeparationTouchdown();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblIntoHurdleKSTouchdownM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblIntoHurdleKSTouchdownF" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep3_KneeSeparationTouchdown();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblIntoHurdleKSTouchdownM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFE1AA; width: 290px; font-size: 13px;">
                                <asp:Label runat="server" Text="Specific: Lower Leg Angle at Touchdown" Style="cursor: pointer"
                                    onclick="LowerLegAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblIntoHurdleLLTouchdownI" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep3_StepintoLowerLegTouchdown();"></asp:Label>
                            </td>
                            <td style="background-color: #FFFF80; font-size: small; text-align: center">
                                <asp:Label ID="lblIntoHurdleLLTouchdownM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblIntoHurdleLLTouchdownF" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep3_StepintoLowerLegTouchdown();"></asp:Label>
                            </td>
                            <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                                <asp:Label ID="lblIntoHurdleLLTouchdownM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #FFB9AF; width: 290px; font-size: 13px;">
                                <asp:Label ID="Label48" runat="server" Text="Specific: Trunk Angle at Touchdown"
                                    Style="cursor: pointer" onclick="TrunkAngles_HurdleSteps();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblIntoHurdleTrunkTouchdownAngleI" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep3_StepintoKneeSeparationTouchdown();"></asp:Label>
                            </td>
                            <td style="background-color: #EBEB41; font-size: small; text-align: center">
                                <asp:Label ID="lblIntoHurdleTrunkTouchdownAngleM1" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblIntoHurdleTrunkTouchdownAngleF" runat="server" Style="cursor: pointer"
                                    onclick="HurdleStep3_StepintoKneeSeparationTouchdown();"></asp:Label>
                            </td>
                            <td style="background-color: #91F591; font-size: small; text-align: center">
                                <asp:Label ID="lblIntoHurdleTrunkTouchdownAngleM2" runat="server"></asp:Label>
                            </td>
                        </tr>
                                 <tr>
                                     <th align="left" 
                                         style="width: 260px; background-color: #006699; color: #FFFFFF; font-weight: bold;">
                                         Scores
                                     </th>
                                     <td ID="Td13" runat="server" align="center" 
                                         style="background-color: #006699; color: #FFFFFF; font-weight: bold" 
                                         width="143">
                                         Initial
                                     </td>
                                     <td ID="Td14" align="center" 
                                         style="background-color: #006699; color: #FFFFFF; width: 143px; font-weight: bold;" 
                                         width="143">
                                         Model
                                     </td>
                                     <td ID="Td15" runat="server" align="center" 
                                         style="background-color: #006699; color: #FFFFFF; font-weight: bold" 
                                         width="143">
                                         Final
                                     </td>
                                     <td ID="Td16" runat="server" align="center" 
                                         style="background-color: #006699; color: #FFFFFF; font-weight: bold" 
                                         width="143">
                                         Model
                                     </td>
                    </tr>
                        <tr>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                            <td style="height: 5px; background-color: #666633">
                            </td>
                        </tr>
                        </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 260px; font-size: small;">
                            <asp:Label ID="Label49" runat="server" Style="cursor: pointer" Text="Result: Velocity Compared to Model"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="HurdleStepResultScoreI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="HurdleStepResultScoreM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="HurdleStepResultScoreF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="HurdleStepResultScoreM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 260px; font-size: small;">
                            <asp:Label ID="Label58" runat="server" Style="cursor: pointer" Text="General: Time, Distance and Rate Results"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="HurdleStepGeneralScoreI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="HurdleStepGeneralScoreM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="HurdleStepGeneralScoreF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="HurdleStepGeneralScoreM2" runat="server"></asp:Label>
                        </td>
                    </tr>
<%--                    <tr>
                        <td style="background-color: #FFB9AF; width: 260px; font-size: small;">
                            <asp:Label ID="Label67" runat="server" Style="cursor: pointer" Text="Special: Ability to Create Stride Length During Ground Contact"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="HurdleStepSpecialScoreI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="HurdleStepSpecialScoreM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="HurdleStepSpecialScoreF" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="HurdleStepSpecialScoreM2" runat="server"></asp:Label>
                        </td>
                    </tr>
--%>                <tr>
                        <td style="background-color: #FFB9AF; width: 260px; font-size: small;">
                            <asp:Label ID="Label73" runat="server" Style="cursor: pointer" Text="Specific: Critical Body Positions"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="HurdleStepSpecificScoreI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="HurdleStepSpecificScoreM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="HurdleStepSpecificScoreF" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="HurdleStepSpecificScoreM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    </table>
                </div>
            </div>
        </div>
        <div id="ShowGraph" style="height: 100%; width: 100%;">
        </div>
        <div id="ShowingGroundTime" style="overflow-x: hidden">
            <%-- <asp:Button ID="Button1" runat="server"  Text="Button" />--%>
        </div>
        <div id="ShowTimeToUpperLeg" style="overflow-x: hidden">
            <%-- <div id="chartContainer" style="width: 300px; height: 300px;">--%>
        </div>
        </div>
        <div id="ShowStrideRate" style="overflow-x: hidden">
        </div>
        <div id="ShowStrideLength" style="overflow-x: hidden">
        </div>
        <div id="ShowVelocity" style="overflow-x: hidden">
        </div>
        <div id="ShowTrunkAngleForSprintPlayer" style="overflow-x: hidden">
        </div>
        <div id="ShowKneeSeparationForSprint" style="overflow-x: hidden">
        </div>
        <div id="ShowTouchDown" style="overflow-x: hidden">
        </div>
        <div id="ShowUpperLegFullExtension" style="overflow-x: hidden">
        </div>
        <div id="ShowUpperLegFullFlexion" style="overflow-x: hidden">
        </div>
        <div id="ShowLowerLegAngleAtTakeOf" style="overflow-x: hidden">
        </div>
        <div id="ShowMySwingHelp" style="overflow-x: hidden">
        </div>
        <div id="ShowStartSetBlockDistance" style="overflow-x: hidden">
        </div>
        <div id="ShowStartSegmentAnglesatSetPosition" style="overflow-x: hidden">
        </div>
        <div id="ShowStartcogDistanceatSetPosition" style="overflow-x: hidden">
        </div>
        <div id="ShowStartGroundTimeandAirTime" style="overflow-x: hidden">
        </div>
        <div id="ShowSegmentAnglesDuringBlockClearance" style="overflow-x: hidden">
        </div>
        <div id="ShowStart_strideLengthandRate" style="overflow-x: hidden">
        </div>
        <div id="ShowStartHorizontalVelocity" style="overflow-x: hidden">
        </div>
        <div id="ShowStartTouchdowndistance" style="overflow-x: hidden">
        </div>
        <div id="ShowCOGDistanceandSegmentAnglesDuringStep2" style="overflow-x: hidden">
        </div>
        <div id="ShowStartCOGDistanceDuringStep3" style="overflow-x: hidden">
        </div>
        <div id="ShowStart_3to5meter" style="overflow-x: hidden">
        </div>
        <div id="ShowHurdle_GroundTime" style="overflow-x: hidden">
        </div>
        <div id="ShowHurdle_AirtimeAndStrideRate" style="overflow-x: hidden">
        </div>
        <div id="ShowHurdle_StrideLength" style="overflow-x: hidden">
        </div>
        <div id="ShowHurdle_Velocity" style="overflow-x: hidden">
        </div>
        <div id="ShowHurdleTDIonAndoff" style="overflow-x: hidden">
        </div>
        <div id="ShowHurdleKneeSeparationForPlayer" style="overflow-x: hidden">
        </div>
        <div id="ShowHurdleTrunkAngleForPlayer" style="overflow-x: hidden">
        </div>
        <div id="ShowHurdle_UpperLegTDInto" style="overflow-x: hidden">
        </div>
        <div id="ShowHurdleLowerLegRecoveryMotion" style="overflow-x: hidden">
        </div>
        <div id="ShowHurdle_KneeAnkleSeparationOver" style="overflow-x: hidden">
        </div>
        <div id="ShowHurdleLowerLegRecoveryMotion" style="overflow-x: hidden">
        </div>
        <div id="ShowHurdleLowerLegMotion" style="overflow-x: hidden">
        </div>
        <div id="ShowBeetweenTheHurdle_HurdleSteps" style="overflow-x: hidden">
        </div>
        <div id="ShowTouchDownDist" style="overflow-x: hidden">
        </div>
        <div id="ShowVelocityHurdleSteps" style="overflow-x: hidden">
        </div>
        <div id="ShowGroundTimeHurdleStep" style="overflow-x: hidden">
        </div>
        <div id="ShowAirTimeHurdleStep" style="overflow-x: hidden">
        </div>
        <div id="ShowStrideRateHurdleStep" style="overflow-x: hidden">
        </div>
        <div id="ShowStrideLengthHurdleStep" style="overflow-x: hidden">
        </div>
        <div id="ShowTouchDown_HurdleSteps" style="overflow-x: hidden">
        </div>
        <div id="ShowTrunkAngles_HurdleSteps" style="overflow-x: hidden">
        </div>
        <div id="ShowUpperLegAngles_HurdleSteps" style="overflow-x: hidden">
        </div>
        <div id="ShowLowerLegAngles_HurdleSteps" style="overflow-x: hidden">
        </div>
        <div id="marker">
        </div>
        </body>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="DropDownList3" EventName="SelectedIndexChanged" />
        <%--<asp:AsyncPostBackTrigger ControlID="btnImage" EventName="Click" />--%>
    </Triggers>
    <%--<Triggers>
        <asp:AsyncPostBackTrigger  ControlID="UpdateTimer" EventName="Tick" />
    </Triggers>--%>
</asp:UpdatePanel>

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
<script type="text/javascript">
    var ddlList1;
    var DropDownList1Text;
    var DropDownList1Value;

    var ddlList2;
    var DropDownList2Text;
    var DropDownList2Value;

    var ddlList3;
    var DropDownList3Text;
    var DropDownList3Value;
    debugger;
    var PassResultScoreI = '';
    var PassResultScoreF = '';
    var PassResultScoreM1 = '';
    var PassResultScoreM2 = '';
    var PassGeneralScoreI = '';
    var PassGeneralScoreM1 = '';
    var PassGeneralScoreF = '';
    var PassGeneralScoreM2 = '';
    var PassSpecialScoreI = '';
    var PassSpecialScoreF = '';
    var PassSpecialScoreM1 = '';
    var PassSpecialScoreM2 = '';
    var PassSpecificScoreI = '';
    var PassSpecificScoreM1 = '';
    var PassSpecificScoreF = '';
    var PassSpecificScoreM2 = '';

    function getDropdownText(ClientID) {
        debugger;
        var selectedText = document.getElementById(ClientID)
        var ddlObj = selectedText.options[selectedText.selectedIndex].innerHTML;
        return ddlObj;
    }
    function getPassScore(ClientID) {
        debugger;
        var ddlObj = document.getElementById(ClientID)
        if (ddlObj != null)
            return ddlObj.innerHTML;
    }

    function loadChartFrame() {

        var ddlList1 = getDropdownText("<%=DropDownList1.ClientID %>");
        var ddlList2 = getDropdownText("<%=DropDownList2.ClientID %>");
        var ddlList3 = getDropdownText("<%=DropDownList3.ClientID %>");
        var passScoreF = getPassScore("<%=SprintSpecificScoreF.ClientID %>");

        jQuery.ajax({
            type: "POST",
            url: "../Controls/GraphChart.aspx/SetGraphData",
            data: "{DropDownList1Text: '" + ddlList1 + "', DropDownList2Text: '" + ddlList2 + "', DropDownList3Text: '" + ddlList3 + "', PassSpecificScoreF: '" + passScoreF + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var ifrm = document.createElement('iframe');
                ifrm.setAttribute('id', 'ifrm'); // assign an id
                var el = document.getElementById('marker');
                el.parentNode.insertBefore(ifrm, el);
                ifrm.setAttribute('src', 'http://localhost:60914/Compusport/Controls/GraphChart.aspx');
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }

    function OpenPDFInNewTab() {
        debugger;
        //loadChartFrame();

        ddlList1 = document.getElementById("<%=DropDownList1.ClientID %>");
        DropDownList1Text = ddlList1.options[ddlList1.selectedIndex].innerHTML;
        DropDownList1Value = ddlList1.value;

        ddlList2 = document.getElementById("<%=DropDownList2.ClientID %>");
        DropDownList2Text = ddlList2.options[ddlList2.selectedIndex].innerHTML;
        DropDownList2Value = ddlList2.value;

        ddlList3 = document.getElementById("<%=DropDownList3.ClientID %>");
        DropDownList3Text = ddlList3.options[ddlList3.selectedIndex].innerHTML;
        DropDownList3Value = ddlList3.value;

        if (DropDownList2Text == "Sprint") {
            if (document.getElementById("<%=SprintResultScoreI.ClientID %>") != null) {
                PassResultScoreI = document.getElementById("<%=SprintResultScoreI.ClientID %>").innerText;
            }
            if (document.getElementById("<%=SprintResultScoreF.ClientID %>") != null) {
                PassResultScoreF = document.getElementById("<%=SprintResultScoreF.ClientID %>").innerText;
            }
            if (document.getElementById("<%=SprintResultScoreM1.ClientID %>") != null) {
                PassResultScoreM1 = document.getElementById("<%=SprintResultScoreM1.ClientID %>").innerText;
            }
            if (document.getElementById("<%=SprintResultScoreM2.ClientID %>") != null) {
                PassResultScoreM2 = document.getElementById("<%=SprintResultScoreM2.ClientID %>").innerText;
            }
            if (document.getElementById("<%=SprintGeneralScoreI.ClientID %>") != null) {
                PassGeneralScoreI = document.getElementById("<%=SprintGeneralScoreI.ClientID %>").innerText;
            }
            if (document.getElementById("<%=SprintGeneralScoreM1.ClientID %>") != null) {
                PassGeneralScoreM1 = document.getElementById("<%=SprintGeneralScoreM1.ClientID %>").innerText;
            }
            if (document.getElementById("<%=SprintGeneralScoreF.ClientID %>") != null) {
                PassGeneralScoreF = document.getElementById("<%=SprintGeneralScoreF.ClientID %>").innerText;
            }
            if (document.getElementById("<%=SprintGeneralScoreM2.ClientID %>") != null) {
                PassGeneralScoreM2 = document.getElementById("<%=SprintGeneralScoreM2.ClientID %>").innerText;
            }
            if (document.getElementById("<%=SprintSpecialScoreI.ClientID %>") != null) {
                PassSpecialScoreI = document.getElementById("<%=SprintSpecialScoreI.ClientID %>").innerText;
            }
            if (document.getElementById("<%=SprintSpecialScoreF.ClientID %>") != null) {
                PassSpecialScoreF = document.getElementById("<%=SprintSpecialScoreF.ClientID %>").innerText;
            }
            if (document.getElementById("<%=SprintSpecialScoreM1.ClientID %>") != null) {
                PassSpecialScoreM1 = document.getElementById("<%=SprintSpecialScoreM1.ClientID %>").innerText;
            }
            if (document.getElementById("<%=SprintSpecialScoreM2.ClientID %>") != null) {
                PassSpecialScoreM2 = document.getElementById("<%=SprintSpecialScoreM2.ClientID %>").innerText;
            }
            if (document.getElementById("<%=SprintSpecificScoreI.ClientID %>") != null) {
                PassSpecificScoreI = document.getElementById("<%=SprintSpecificScoreI.ClientID %>").innerText;
            }
            if (document.getElementById("<%=SprintSpecificScoreM1.ClientID %>") != null) {
                PassSpecificScoreM1 = document.getElementById("<%=SprintSpecificScoreM1.ClientID %>").innerText;
            }
            if (document.getElementById("<%=SprintSpecificScoreF.ClientID %>") != null) {
                PassSpecificScoreF = document.getElementById("<%=SprintSpecificScoreF.ClientID %>").innerText;
            }
            if (document.getElementById("<%=SprintSpecificScoreM2.ClientID %>") != null) {
                PassSpecificScoreM2 = document.getElementById("<%=SprintSpecificScoreM2.ClientID %>").innerText;
            }
        }
        else {
            if (DropDownList2Text == "Start") {
                if (document.getElementById("<%=StartResultScoreI.ClientID %>") != null) {
                    PassResultScoreI = document.getElementById("<%=StartResultScoreI.ClientID %>").innerText;
                }
                if (document.getElementById("<%=StartResultScoreF.ClientID %>") != null) {
                    PassResultScoreF = document.getElementById("<%=StartResultScoreF.ClientID %>").innerText;
                }
                if (document.getElementById("<%=StartResultScoreM1.ClientID %>") != null) {
                    PassResultScoreM1 = document.getElementById("<%=StartResultScoreM1.ClientID %>").innerText;
                }
                if (document.getElementById("<%=StartResultScoreM2.ClientID %>") != null) {
                    PassResultScoreM2 = document.getElementById("<%=StartResultScoreM2.ClientID %>").innerText;
                }
                if (document.getElementById("<%=StartGeneralScoreI.ClientID %>") != null) {
                    PassGeneralScoreI = document.getElementById("<%=StartGeneralScoreI.ClientID %>").innerText;
                }
                if (document.getElementById("<%=StartGeneralScoreM1.ClientID %>") != null) {
                    PassGeneralScoreM1 = document.getElementById("<%=StartGeneralScoreM1.ClientID %>").innerText;
                }
                if (document.getElementById("<%=StartGeneralScoreF.ClientID %>") != null) {
                    PassGeneralScoreF = document.getElementById("<%=StartGeneralScoreF.ClientID %>").innerText;
                }
                if (document.getElementById("<%=StartGeneralScoreM2.ClientID %>") != null) {
                    PassGeneralScoreM2 = document.getElementById("<%=StartGeneralScoreM2.ClientID %>").innerText;
                }
                if (document.getElementById("<%=StartSpecificScoreI.ClientID %>") != null) {
                    PassSpecificScoreI = document.getElementById("<%=StartSpecificScoreI.ClientID %>").innerText;
                }
                if (document.getElementById("<%=StartSpecificScoreM1.ClientID %>") != null) {
                    PassSpecificScoreM1 = document.getElementById("<%=StartSpecificScoreM1.ClientID %>").innerText;
                }
                if (document.getElementById("<%=StartSpecificScoreF.ClientID %>") != null) {
                    PassSpecificScoreF = document.getElementById("<%=StartSpecificScoreF.ClientID %>").innerText;
                }
                if (document.getElementById("<%=StartSpecificScoreM2.ClientID %>") != null) {
                    PassSpecificScoreM2 = document.getElementById("<%=StartSpecificScoreM2.ClientID %>").innerText;
                }
            }
            else {
                if (DropDownList2Text == "Hurdle") {
                    if (document.getElementById("<%=HurdleResultScoreI.ClientID %>") != null) {
                        PassResultScoreI = document.getElementById("<%=HurdleResultScoreI.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleResultScoreF.ClientID %>") != null) {
                        PassResultScoreF = document.getElementById("<%=HurdleResultScoreF.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleResultScoreM1.ClientID %>") != null) {
                        PassResultScoreM1 = document.getElementById("<%=HurdleResultScoreM1.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleResultScoreM2.ClientID %>") != null) {
                        PassResultScoreM2 = document.getElementById("<%=HurdleResultScoreM2.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleGeneralScoreI.ClientID %>") != null) {
                        PassGeneralScoreI = document.getElementById("<%=HurdleGeneralScoreI.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleGeneralScoreM1.ClientID %>") != null) {
                        PassGeneralScoreM1 = document.getElementById("<%=HurdleGeneralScoreM1.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleGeneralScoreF.ClientID %>") != null) {
                        PassGeneralScoreF = document.getElementById("<%=HurdleGeneralScoreF.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleGeneralScoreM2.ClientID %>") != null) {
                        PassGeneralScoreM2 = document.getElementById("<%=HurdleGeneralScoreM2.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleSpecificScoreI.ClientID %>") != null) {
                        PassSpecificScoreI = document.getElementById("<%=HurdleSpecificScoreI.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleSpecificScoreM1.ClientID %>") != null) {
                        PassSpecificScoreM1 = document.getElementById("<%=HurdleSpecificScoreM1.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleSpecificScoreF.ClientID %>") != null) {
                        PassSpecificScoreF = document.getElementById("<%=HurdleSpecificScoreF.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleSpecificScoreM2.ClientID %>") != null) {
                        PassSpecificScoreM2 = document.getElementById("<%=HurdleSpecificScoreM2.ClientID %>").innerText;
                    }
                }
                else {
                    if (document.getElementById("<%=HurdleStepResultScoreI.ClientID %>") != null) {
                        PassResultScoreI = document.getElementById("<%=HurdleStepResultScoreI.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleStepResultScoreF.ClientID %>") != null) {
                        PassResultScoreF = document.getElementById("<%=HurdleStepResultScoreF.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleStepResultScoreM1.ClientID %>") != null) {
                        PassResultScoreM1 = document.getElementById("<%=HurdleStepResultScoreM1.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleStepResultScoreM2.ClientID %>") != null) {
                        PassResultScoreM2 = document.getElementById("<%=HurdleStepResultScoreM2.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleStepGeneralScoreI.ClientID %>") != null) {
                        PassGeneralScoreI = document.getElementById("<%=HurdleStepGeneralScoreI.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleStepGeneralScoreM1.ClientID %>") != null) {
                        PassGeneralScoreM1 = document.getElementById("<%=HurdleStepGeneralScoreM1.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleStepGeneralScoreF.ClientID %>") != null) {
                        PassGeneralScoreF = document.getElementById("<%=HurdleStepGeneralScoreF.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleStepGeneralScoreM2.ClientID %>") != null) {
                        PassGeneralScoreM2 = document.getElementById("<%=HurdleStepGeneralScoreM2.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleStepSpecificScoreI.ClientID %>") != null) {
                        PassSpecificScoreI = document.getElementById("<%=HurdleStepSpecificScoreI.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleStepSpecificScoreM1.ClientID %>") != null) {
                        PassSpecificScoreM1 = document.getElementById("<%=HurdleStepSpecificScoreM1.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleStepSpecificScoreF.ClientID %>") != null) {
                        PassSpecificScoreF = document.getElementById("<%=HurdleStepSpecificScoreF.ClientID %>").innerText;
                    }
                    if (document.getElementById("<%=HurdleStepSpecificScoreM2.ClientID %>") != null) {
                        PassSpecificScoreM2 = document.getElementById("<%=HurdleStepSpecificScoreM2.ClientID %>").innerText;
                    }
                }
            }
        }
        WaitForOpenPDFInNewTab();
    }
    function WaitForOpenPDFInNewTab() {
        jQuery.ajax({
            type: "POST",
            url: "SummaryPlayer.aspx/OpenPDFInNewTab",
            data: '{DropDownList1Text: "' + DropDownList1Text + '", DropDownList1Value: "' + DropDownList1Value + '", DropDownList2Text: "' + DropDownList2Text + '", DropDownList2Value: "' + DropDownList2Value + '", DropDownList3Value: "' + DropDownList3Value + '", DropDownList3Text: "' + DropDownList3Text + '", PassResultScoreI: "' + PassResultScoreI + '", PassResultScoreF: "' + PassResultScoreF + '", PassResultScoreM1: "' + PassResultScoreM1 + '", PassResultScoreM2: "' + PassResultScoreM2 + '", PassGeneralScoreI: "' + PassGeneralScoreI + '", PassGeneralScoreM1: "' + PassGeneralScoreM1 + '", PassGeneralScoreF: "' + PassGeneralScoreF + '", PassGeneralScoreM2: "' + PassGeneralScoreM2 + '", PassSpecialScoreI: "' + PassSpecialScoreI + '", PassSpecialScoreF: "' + PassSpecialScoreF + '", PassSpecialScoreM1: "' + PassSpecialScoreM1 + '", PassSpecialScoreM2: "' + PassSpecialScoreM2 + '", PassSpecificScoreI: "' + PassSpecificScoreI + '", PassSpecificScoreM1: "' + PassSpecificScoreM1 + '", PassSpecificScoreF: "' + PassSpecificScoreF + '", PassSpecificScoreM2: "' + PassSpecificScoreM2 + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
                debugger;
                if (response.d !== "") {
                    window.open('../PDF_Folder/' + response.d);
                }
                else {
                    alert('PDF Report Not Available in Comparison Mode');
                }
            },
            failure: function (response) {
                debugger;
                alert("WaitForOpenPDFInNewTab---fail");
            }
        });
    }

    //       function OnSuccess(response) {
    //           WaitForOpenPDFInNewTab();
    //       }


    var clicknum = 0;
    var selectedLessonId = document.getElementById("<%=DropDownList1.ClientID %>").value;

    function RefreshDropdowns() {
        //debugger;

        clicknum++;
        if (clicknum == 2) {
            if (selectedLessonId == document.getElementById("<%=DropDownList1.ClientID %>").value) {
                // document.getElementById("<%=DropDownList1.ClientID %>").onchange();
                // __doPostBack("<%= Update.ClientID %>", "");
                // ('<%= btnreset.ClientID %>').Click();
                document.getElementById('<%=btnreset.ClientID%>').click()
                //alert(document.getElementById("<%=DropDownList1.ClientID %>").value);
            }
            else {
                selectedLessonId = document.getElementById("<%=DropDownList1.ClientID %>").value;
            }
            clicknum = 0;
        }

    }
</script>
<%--<%
    if (DropDownList2.SelectedItem.Text.Equals("Sprint"))
    {
%>
<script type="text/javascript">
    // debugger;

    var tempCount = 0;
    checkIfVideoLoaded(2);
</script>
<%  }
    else if (DropDownList2.SelectedItem.Text.Equals("Start"))
    {
%>
<script type="text/javascript">
    var tempCount = 0;
    checkIfVideoLoaded(0);
</script>
<%
    }
    else
    {
%>
<script type="text/javascript">
    var tempCount = 0;
    checkIfVideoLoaded(1);
</script>
<%  }
%>--%>