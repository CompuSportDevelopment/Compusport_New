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
         
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=30');
        
        return true;
    };
    function AirTimeRightToLeft() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=31');

        return true;
    };
    function AirTimeTotal() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=32');

        return true;
    };
    function StrideRate1() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=33');

        return true;
    };
    function StrideRate1() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=34');

        return true;
    };
    function StrideLengthLeft() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=35');

        return true;
    };
    function StrideLengthRight() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=36');

        return true;
    };
    function StrideLengthTotal1() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=37');
        return true;
    }; 
    
    ////////////////////////////////////////////////////////////////////////////
    /////Start Player////////////////////////
    function StartSetBlockDistance() {
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
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=38');
        return true;
    };
    function RearBlockDistance() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=39');
        return true;
    };
    function FrontULAngle() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=40');
        return true;
    };
    function RearULAngle() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=41');
        return true;
    };
    function FrontLLAngle() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=42');
        return true;
    };
    function RearLLAngle() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=43');
        return true;
    };
    function TrunkAngle2() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=44');
        return true;
    };
    function COG() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=45');
        return true;
    };
    function Trunk_Angle_at_Takeoff() {
        
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=46');
        return true;
    };
    function BCStrideRide() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=47');
        return true;
    };
    function BCStrideLength() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=48');
        return true;
    }; 
    function Step1Trunk_Angle() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=49');
        return true;
    };
    function Step1_StrideRate() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=50');
        return true;
    };
    function Step_1Stride_Length() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=51');
        return true;
    };
    function Step2_Trunk_Angle_Takeoff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=52');
        return true;
    };
    function Step2Stride_Rate() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=53');
        return true;
    };
    function Step2Stride_Length() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=54');
        return true;
    };
    function LowerLegAngle_Ankle() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=55');
        return true;
    };
    function Step1_LowerLeg_Angle_Ankle() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=56');
        return true;
    };
    function Step2_LowerLegAngle_Ankle() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=57');
        return true;
    };
    function BC_Velocity1() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=58');
        return true;
    };
    function Step1Velocity1() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=59');
        return true;
    };
    function Step2Velocity1() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=60');
        return true;
    };
    //start player type 1 graph start
    function Rear_Foot_Clearance_Time() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=61');
        return true;
    };
    function Front_Foot_Clearance_Time() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=62');
        return true;
    };
    function Rear_Lower_Leg_Angle_at_Rear_Takeoff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=63');
        return true;
    };
    function Front_Lower_Leg_Angle_at_Front_Takeoff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=64');
        return true;
    };
    function BC_AirTime() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=65');
        return true;
    };
    function Step1COG() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=66');
        return true;
    };
    function Step_1_Rear_Leg_Angle() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=67');
        return true;
    };
    function Step1GroundTime() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=68');
        return true;
    };
    function Step1AirTime() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=69');
        return true;
    };

    function Step2COG() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=70');
        return true;
    };
    function Step_2_Rear_Leg_Angle() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=71');
        return true;
    };
    function Step2GroundTime() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=72');
        return true;
    };
    function Step2AirTime() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=73');
        return true;
    };

    function Step3COG() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=74');
        return true;
    };

    function Timeto3m() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=75');
        return true;
    };
    function Timeto5m() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=76');
        return true;
    };
   
   //***********************************************Graph End *************************************************************************

    function StartSegmentAnglesatSetPosition() {
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
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=77');
        return true;
    };
    function GroundTimeoff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=78');
        return true;
    };
    function AirTimeoff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=79');
        return true;
    };
    function TouchDownDistanceinto() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=80');
        return true;
    };
    function TouchDownDistanceoff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=81');
        return true;
    };
    function KneeSeparationtouchdowninto() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=82');
        return true;
    };
    function KneeSeparationtouchdownoff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=83');
        return true;
    };
    function TrunkMinimumAngle() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=84');
        return true;
    };
    function Hurdle_TrailUpperLegAngleatTouchdownInto() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=85');
        return true;
    };
    function LeadUpperLegAngleTouchdownOff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=86');
        return true;
    };
    function Hurdle_LeadLowerLegAngleTouchdownOff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=87');
        return true;
    };
    function Hurdle_LeadLowerLegMaximumAngleOver() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=88');
        return true;
    };
    function Hurdle_StrideLengthTotal() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=89');
        return true;
    };
    function StrideLengthinto() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=90');
        return true;
    };
    function StrideLengthoff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=91');
        return true;
    };
    function HurdleVelocitygraph() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=92');
        return true;
    };
    function Hurdle_TrunkAngleTouchdownInto() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=93');
        return true;
    };
    function Hurdle_TrunkAngleTouchdownoff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=94');
        return true;
    };
    function Hurdle_TrunkAngleTakeoffInto() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=95');
        return true;
    };
    function Hurdle_TrunkAngleatTakeoffOff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=96');
        return true;
    };
    function Hurdle_TrailUpperLegAngleTakeoffInto() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=97');
        return true;
    };
    function Hurdle_LeadUpperLegMaximumAngleOver() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=98');
        return true;
    }
    function Hurdle_LeadUpperLegAngleTakeoffOff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=99');
        return true;
    }
    function Hurdle_LeadLowerLegMinimumAngleInto() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=100');
        return true;
    };
    function Hurdle_LeadLowerLegAngleAnkleCrossInto() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=101');
        return true;
    };
    function Hurdle_KneeAnkleMinimumSeparationOver() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=102');
        return true;
    };
    function Hurdle_LeadLowerLegAngleTakeoffOff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=103');
        return true;
    };
    
    
   
     //grap type 1 end 
    //Hurdle player graph end
    function Hurdle_GroundTime() {


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
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=105');
        return true;
    };
    function HurdleStep_AirTime() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=106');
        return true;
    };
    function HurdleStep_TouchDown() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=107');
        return true;
    };
    function HurdleStep_KneeSeperationTouchdown() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=108');
        return true;
    };
    function Hurdle_UpperLegAngleFullExtension() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=109');
        return true;
    };
    function Hurdle_LowerLegTakeoff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=110');
        return true;
    };
    function HurdleStep_StrideRate() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=111');
        return true;
    };
    function HurdleStep_TrunkTouchdownAngle() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=112');
        return true;
    };
    function HurdleStep1_TrunkTakeoffAngle() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=113');
        return true;
    };
    function HurdleStep1_UpperLegAngleFullFlexion() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=114');
        return true;
    };
    function HurdleStep1_StrideLength() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=115');
        return true;
    };
    function HurdleStep2_Striderate() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=116');
        return true;
    };
    function HurdleStep2_TrunkAngleTouchdown() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=117');
        return true;
    };
    function HurdleStep2_TrunkAngleTakeoff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=118');
        return true;
    };
    function HurdleStep2_UpperLegAngleFullFlexion() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=119');
        return true;
    };
    function HurdleStep2_StrideLength() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=120');
        return true;
    };
    function HurdleStep2_GroundTime() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=121');
        return true;
    };
    function HurdleStep2_AirTime() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=122');
        return true;
    };
    function HurdleStep2_TouchdownDistance() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=123');
        return true;
    };
    function HurdleStep2_KneeSeperationTouchdown() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=124');
        return true;
    };
    function HurdleStep2_UpperLegAngleFullExtension() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=125');
        return true;
    };
    function HurdleStep2_LowerLegTakeoff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=126');
        return true;
    };
    function HurdleStep2_LowerLegFullFlexion() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=127');
        return true;
    };
//hurdle step 3 start
    function HurdleStep3_GroundTime() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=128');
        return true;
    };
    function HurdleStep3_AirTime() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=129');
        return true;
    };
    function HurdleStep3_TouchdownDistance() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=130');
        return true;
    };
    function HurdleStep3_KneeSeperationTouchdown() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=131');
        return true;
    };
    function HurdleStep3_UpperLegAngleFullExtension() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=132');
        return true;
    };
    function HurdleStep3_LowerLegTakeoff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=133');
        return true;
    };
    function HurdleStep3_LowerLegAngleFullFlexion() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=134');
        return true;
    };
    function HurdleStep3_StrideRateGraph() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=135');
        return true;
    }; 
    function HurdleStep3_TrunkTouchdown() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=136');
        return true;
    };
    function HurdleStep3_TrunkAngleTakeoff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=137');
        return true;
    };
    function HurdleStep3_UpperLegAngleFullFlexion() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=138');
        return true;
    };
    function HurdleStep3_StrideLength() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=139');
        return true;
    };
    function HurdleStep3_intoTouchdownDistance() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=140');
        return true;
    };
    function HurdleStep3_KneeSeparationTouchdown() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=141');
        return true;
    }; 
    function HurdleStep3_StepintoKneeSeparationTouchdown() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=142');
        return true;
    };
    function HurdleStep3_StepintoLowerLegTouchdown() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=143');
        return true;
    };
    function Hurdle_Distance_StrideLengthInto() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=144');
        return true;
    };
    function Hurdle_Distance_StrideLengthOff() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=145');
        return true;
    };
    function Hurdle_Distance_Velocity() {
        ShowPopup();
        $j("#ShowGraph").load('../VariablePages/CanvasGraph.aspx?index=146');
        return true;
    };
    
    
    

    function BeetweenTheHurdle_HurdleSteps() {
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
        $j("#ShowMySwingHelp").html('');
        $j("#ShowMySwingHelp").load('../Users/MySwingHelp.aspx');
        //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
        $j("#ShowMySwingHelp").dialog({
            width: 830,
            height: 600,
            resizable: false,
            modal: true,
            close: function() {
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
	
	
	
	
//    function Centralfs(i) {

//        var clipid = i;
//        this.rightInfo = JSON.decode(rightMovie);
//        this.rightInfo.clips[clipid];

//        this.leftInfo = JSON.decode(leftMovie);
//        this.leftInfo.clips[clipid];

//        if (leftMovie == null || rightMovie == null) {
//            return;
//        }
//        this.leftInfo = JSON.decode(leftMovie);
//        this.rightInfo = JSON.decode(rightMovie);
//        var fs = this.leftInfo.clips[clipid];
//        var from = fs.beginFrame;
//        var to = fs.endFrame;
//        var fs2 = this.rightInfo.clips[clipid];
//        var from2 = fs2.beginFrame;
//        var to2 = fs2.endFrame;
//        //  debugger;
//        if (isComparison == true) {
//        }
//        else {
//            if (errorsRepeated)
//            { }
//            else {
//                $("square").empty();
//                var err_cb = function(err, to2) {
//                    var divErr = new Element("div");
//                    divErr.set("html", err);
//                    divErr.injectInside($("square"));
//                }
//                fs.errors.each(err_cb);
//				if (fs.errors == "") {
//                    document.getElementById("square").innerHTML = 'No Errors Entered at This Position';
//                }
//            }
//        };
//        //domready;
//        // fs2.errors.each(err_cmp);
//        var str = to + "," + to2;
//        return str;
//    }


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
