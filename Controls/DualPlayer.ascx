<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DualPlayer.ascx.cs" Inherits="Controls_DualPlayer" %>

<script language="JavaScript" type="text/javascript">

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
    var buttonclickedseven = false;
    var buttonclickedsix = false;
    var buttonclickedeight = false;
    var buttonclickedback = false;
    var linkbuttonOneclicked = false;
    var lessontypeid;
    var clipid;
    var _selectedLessonId;
    var currentposionid;
    var beginFrame1;
    var endFrame2;
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
	var flag = true;
    var framecount;
	
    function playleftnew() {
        // var username = document.getElementById("<%=HiddenField1.ClientID %>").value;
        //  debugger;
        if ((currentclipid != 7 && _selectedLessonId == 2) || (currentclipid != 6 && _selectedLessonId == 3) || (!currentclipid != 8 && _selectedLessonId == 1)) {
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
        // debugger;
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
        if (isComparison == true) {
        }
        else {
            if (errorsRepeated)
            { }
            else {
                $("square").empty();
                var err_cb = function(err, to2) {
                    var divErr = new Element("div");
                    divErr.set("html", err);
                    divErr.injectInside($("square"));
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
        return str;
    }
    function FunctionForAllBtns(newval) {
        //debugger;
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
                // alert(to);
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
                //  alert(to2);
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
        try {
            document.getElementById('movie').pause();
        } catch (Error) { }
        try {
            document.getElementById('movie1').pause();
        } catch (Error) { }
        // alert("current clip id=" + currentclipid);
        _selectedLessonId = document.getElementById("<%=DropDownList2.ClientID %>").value;
        if (_selectedLessonId == 1) {
            NextFrameFlashMovie1();
        }
        if (_selectedLessonId == 2) {
            NextFrameFlashMovie3();
        }
        if (_selectedLessonId == 3) {
            NextFrameFlashMovie2();
        }
    }
    function managepositionsForReverseButton(param) {
        // debugger;

        buttonclickedseven = false;
        buttonclickedsix = false;
        buttonclickedeight = false;
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
        // debugger;
        if (!PlayRightButton) {
            if (case1) {
                currentclipid = 1;
            }
            switch (currentclipid) {
                case 1:
                    try {
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

                    } catch (Error) { }

                    try {
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
                            buttonclickedsix = true;
                        }
                        frameBackwardLeft = framediff;
                    } catch (Error) { }

                    try {
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
                                buttonclickedsix = true;
                            }
                        }
                        frameBackwardRight = framediff1;
                    } catch (Error) { }
                    break;

                case 8:
                    try {
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
                            buttonclickedseven = true;

                        }
                        frameBackwardLeft = framediff;
                    } catch (Error) { }

                    try {
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
        managepositionsForReverseButton(-0.01666667);
    }
    function managepositionsForForwardButton() {
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
        else
            if (lessontypeid == 2) {
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
        //  debugger;
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
        // debugger;
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
        // debugger;
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

//    function MakeSummaryVisible() {
//        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
//        if (dualplayerdiv) {
//            dualplayerdiv.style.height = '1151px';
//        }
//    }
    function MakeStartHeight() {
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '2300px';
        }
    }
    function MakeStartComparisonHeight() {
        //debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1640px';
        }
    }
    function MakeStartNonTiresHeight() {
        //debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1630px';
        }
    }
    function MakeStartNoSummaryHeight() {

        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1740px';
        }
    }
    function MakeSprintHeight() {
           
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1990px';
        }
    }


    function MakeHurdleStepsHeight() {
       
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1990px';
        }
    }

    function MakeSprintComparisonHeight() {
        //debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1300px';
        }
    }
    function MakeSprintNonTiresHeight() {
        //debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1450px';
        }
    }
    function MakeSprintNoSummaryHeight() {

        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1400px';
        }
    }

    function MakeHurdleStepsNoSummaryHeight() {

        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1600px';           //'1400px';
        }
    }


    function MakeHurdleHeight() {
        //   debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1650px';           //1580px';
        }
    }
    function MakeHurdleComparisonHeight() {
        //debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '900px';
        }
    }
    function MakeHurdleNoSummaryHeight() {
        
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '1060px';
        }
    }
    function MakeHurdleNonTiresHeight() {
        // debugger;
        var dualplayerdiv = document.getElementById('ctl00_ContentPlaceHolder1_dualplayerdiv');
        if (dualplayerdiv) {
            dualplayerdiv.style.height = '980px';
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
    function OpenHelpWindow(URL) {
        var popWindow = window.showModalDialog(URL, null, "dialogWidth: 800px; dialogHeight: 600px; center: yes; resizable: no; scroll: yes; status: no;");
    }
    function OpenVariablePopup(URL) {
        var popWindow = window.showModalDialog(URL, null, "dialogWidth: 800px; dialogHeight: 600px; center: yes; resizable: no; scroll: yes; status: no;");
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
        }

    }

    function SendEmailOnBadSWFLeft(fileName) {
        //debugger;
        var arrControl = new Array();
        arrControl[0] = '<%=HiddenField1.Value %>';
        arrControl[1] = '<%=HiddenField5.Value %>';

        //arrControl[0] = '<%=HiddenField1.Value %>';
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
        // debugger;
        var flashMovie = getFlashMovieObject("movie");
        var flashMovie1 = getFlashMovieObject("movie1");
        if (flashMovie != null) {
            if (flashMovie.PercentLoaded() == 100) {
                document.body.style.cursor = 'wait';
            }
            else {
                document.body.style.cursor = 'default';
            }
        }
        if (flashMovie1 != null) {
            if (flashMovie1.PercentLoaded() == 100) {
                document.body.style.cursor = 'wait';
            }
            else {
            }
        }
        document.body.style.cursor = 'default';
    }
    function Delay(videoPosition) {

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
                    setTimeout("FunctionForAllBtns(" + videoPosition + ")", 1000);
                    clearInterval(clearTiming);
                }
                catch (err) { }
                document.getElementById("divLoading").style.display = 'none';
                document.getElementById("divLoadingMask").style.display = 'none';
            }
        }
        catch (err) {
            document.getElementById("divLoadingMask").style.display = 'none';
            document.getElementById("divLoading").style.display = 'none';
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

<div id="divLoading" style="position: fixed; right: 0px; top: 0%; z-index: 9999;
    margin-right: 0px; display: block;">
    <img src="../Images/loading.gif" alt="" height="80" width="80" />
</div>
<div id="divLoadingMask" class="maskdiv">
</div>
<asp:UpdateProgress ID="Updat_Paymentxyz" runat="server" DisplayAfter="1">
    <ProgressTemplate>
        <div style="position: fixed; right: 0px; top: 0%; z-index: 9999; margin-right: 0px;
            display: block;">
            <img src="../Images/loading.gif" alt="" height="80" width="80" />
        </div>
        <div class="maskdiv">
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="Update" runat="server">
    <ContentTemplate>
        <p style="font-family: Magneto; font-size: 26px;" class="pagetitle">
            My Performance-
            <asp:Label ID="Label6" runat="server"></asp:Label>
        </p>
        <%--<div id="PlayerIntroduction" runat="server" style="margin-left:30px;float:left; margin-bottom:30px; width:797px">--%>
        <p style="font-family: Magneto; text-align: center; font-size: 22px;">
            The Video Players</p>
        <div id="SprintIntro" runat="server" visible="false">
            <p class="SprintIntro" style="font-family: Magneto;">
                Top Player (Tier One Athletes Only): In the Session Display Mode, the Left window
                displays the selected Session video with the athlete’s Model Overlay. Performer
                and Model will always match at Position 3 (Touchdown). The Right window displays
                the same video without the Model. Upon initial entry, the latest Session video will
                be displayed in this Mode.
            </p>
            <p class="SprintIntro" style="font-family: Magneto;">
                If the athlete has several past On-Track Sessions, they may have a Summary Session
                – which is an average of all Sessions. This is provided so overall performance trends
                can be identified. If this Session is available, it will be displayed on entry and
                be at the top of the Session selection lists.
            </p>
            <p class="SprintIntro" style="font-family: Magneto;">
                In Session Comparison Mode, the Left window displays one Session video with the
                athlete’s Model Overlay while the Right window displays another Session video with
                the athlete’s Model Overlay.
            </p>
        </div>
        <div id="SprintTireText" runat="server" visible="false">
            <p style="font-family: Magneto;">
                <font color="red">Top Player</font>(Tier Two, Three, and Four Athletes): For athletes
                who are not Tier One, Session videos are not available. In the Session Display Mode,
                the Left and Right windows display a three-dimensional image of a Model Sprinter.
                Initially the Model will be positioned at Touchdown (Position 3). Upon initial entry,
                the latest Session will be displayed in this Mode. By moving the Model from Position
                to Position, the athlete’s Session Errors will be displayed below the Player.
            </p>
            <p class="SprintIntro" style="font-family: Magneto;">
                If the athlete has several past On-Track Sessions, they may have a Summary Session
                – which is an average of all Sessions. This is provided so overall performance trends
                can be identified. If this Session is available, it will be displayed on entry and
                be at the top of the Session selection lists.
            </p>
            <p style="font-family: Magneto;">
                In Session Comparison Mode, information from the two selected Sessions can be displayed
                in the Variable Chart. This Mode can be used to compare the results of any two Sessions.
            </p>
            <p style="font-family: Magneto;">
                <font color="red">Bottom Player</font>(Tier Two, Three, and Four Athletes): Not
                available.
            </p>
        </div>
        <div id="HurdleStepsIntro" runat="server" visible="false"> <%--If need Create the class HurdleStepsIntro--%>
            <p class="SprintIntro" style="font-family: Magneto;">
                Top Player (Tier One Athletes Only): In the Session Display Mode, the Left window
                displays the selected Session video with the athlete’s Model Overlay. Performer
                and Model will always match at Position 3 (Touchdown). The Right window displays
                the same video without the Model. Upon initial entry, the latest Session video will
                be displayed in this Mode.
            </p>
            <p class="SprintIntro" style="font-family: Magneto;">
                If the athlete has several past On-Track Sessions, they may have a Summary Session
                – which is an average of all Sessions. This is provided so overall performance trends
                can be identified. If this Session is available, it will be displayed on entry and
                be at the top of the Session selection lists.
            </p>
            <p class="SprintIntro" style="font-family: Magneto;">
                In Session Comparison Mode, the Left window displays one Session video with the
                athlete’s Model Overlay while the Right window displays another Session video with
                the athlete’s Model Overlay.
            </p>
        </div>
        <div id="HurdleStepsTrialText" runat="server" visible="false">
            <p style="font-family: Magneto;">
                <font color="red">Top Player</font>(Tier Two, Three, and Four Athletes): For athletes
                who are not Tier One, Session videos are not available. In the Session Display Mode,
                the Left and Right windows display a three-dimensional image of a Model Sprinter.
                Initially the Model will be positioned at Touchdown (Position 3). Upon initial entry,
                the latest Session will be displayed in this Mode. By moving the Model from Position
                to Position, the athlete’s Session Errors will be displayed below the Player.
            </p>
            <p style="font-family: Magneto;">
                If the athlete has several past On-Track Sessions, they may have a Summary Session
                – which is an average of all Sessions. This is provided so overall performance trends
                can be identified. If this Session is available, it will be displayed on entry and
                be at the top of the Session selection lists.
            </p>
            <p style="font-family: Magneto;">
                In Session Comparison Mode, information from the two selected Sessions can be displayed
                in the Variable Chart. This Mode can be used to compare the results of any two Sessions.
            </p>
            <p style="font-family: Magneto;">
                <font color="red">Bottom Player</font>(Tier Two, Three, and Four Athletes): Not
                available.
            </p>
        </div>
        <div id="StartIntro" runat="server" visible="false">
            <p class="StartIntro" style="font-family: Magneto;">
                Top Player (Tier One Athletes Only): In the Session Display Mode, the Left window
                displays the selected Session video with the athlete’s Model Overlay. Performer
                and Model will always match at Position 1 (Set Position). The Right window displays
                the same video without the Model. Upon initial entry, the latest Session video will
                be displayed in this Mode.
            </p>
            <p style="font-family: Magneto;">
                If the athlete has several past On-Track Sessions, they may have a Summary Session
                – which is an average of all Sessions. This is provided so overall performance trends
                can be identified. If this Session is available, it will be displayed on entry and
                be at the top of the Session selection lists.
            </p>
            <p class="StartIntro" style="font-family: Magneto;">
                In Session Comparison Mode, the Left window displays one Session video with the
                athlete’s Model Overlay while the Right window displays another Session video with
                the athlete’s Model Overlay.
            </p>
        </div>
        <div id="StartTireText" runat="server" visible="false">
            <p style="font-family: Magneto;">
                <font color="red">Top Player</font>(Tier Two, Three, and Four Athletes): For athletes
                who are not Tier One, Session videos are not available. In the Session Display Mode,
                the Left and Right windows display a three-dimensional image of a Model Start. Initially
                the Model will be positioned at the Set Position (Position 1). Upon initial entry,
                the latest Session will be displayed in this Mode. By moving the Model from Position
                to Position, the athlete’s Session Errors will be displayed below the Player.
            </p>
            <p style="font-family: Magneto;">
                If the athlete has several past On-Track Sessions, they may have a Summary Session
                – which is an average of all Sessions. This is provided so overall performance trends
                can be identified. If this Session is available, it will be displayed on entry and
                be at the top of the Session selection lists.
            </p>
            <p style="font-family: Magneto;">
                In Session Comparison Mode, information from the two selected Sessions can be displayed
                in the Variable Chart. This Mode can be used to compare the results of any two Sessions.
            </p>
            <p style="font-family: Magneto;">
                <font color="red">Bottom Player</font>(Tier Two, Three, and Four Athletes): Not
                available.
            </p>
        </div>
        <div id="HurdleIntro" runat="server" visible="false">
            <p style="font-family: Magneto;">
                Top Player (Tier One Athletes Only): In the Session Display Mode, the Left window
                displays the selected Session video with the athlete’s Model Overlay. Performer
                and Model will always match at Position 2 (Touchdown Into the Hurdle). The Right
                window displays the same video without the Model. Upon initial entry, the latest
                Session video will be displayed in this Mode.
            </p>
            <p style="font-family: Magneto;">
                If the athlete has several past On-Track Sessions, they may have a Summary Session
                – which is an average of all Sessions. This is provided so overall performance trends
                can be identified. If this Session is available, it will be displayed on entry and
                be at the top of the Session selection lists.
            </p>
            <p style="font-family: Magneto;">
                In Session Comparison Mode, the Left window displays one Session video with the
                athlete’s Model Overlay while the Right window displays another Session video with
                the athlete’s Model Overlay.
            </p>
        </div>
        <div id="HurdleTireText" runat="server" visible="false">
            <p style="font-family: Magneto;">
                <font color="red">Top Player</font>(Tier Two, Three, and Four Athletes): For athletes
                who are not Tier One, Session videos are not available. In the Session Display Mode,
                the Left and Right windows display a three-dimensional image of a Model Hurdler.
                Initially the Model will be positioned at Touchdown Into the Hurdle (Position 2).
                Upon initial entry, the latest Session will be displayed in this Mode. By moving
                the Model from Position to Position, the athlete’s Session Errors will be displayed
                below the Player.
            </p>
            <p style="font-family: Magneto;">
                If the athlete has several past On-Track Sessions, they may have a Summary Session
                – which is an average of all Sessions. This is provided so overall performance trends
                can be identified. If this Session is available, it will be displayed on entry and
                be at the top of the Session selection lists.
            </p>
            <p style="font-family: Magneto;">
                In Session Comparison Mode, information from the two selected Sessions can be displayed
                in the Variable Chart. This Mode can be used to compare the results of any two Sessions.
            </p>
            <p style="font-family: Magneto;">
                <font color="red">Bottom Player</font>Tier Two, Three, and Four Athletes): Not available.
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
            <p style="font-family: Magneto; margin-top: -5px;">
                Bottom player (Tier One athlete only): This Player displays a Session summary video
                with audio commentary. These are special videos typically done for analyses performed
                on Competitions (National or International), or by special request from a coach
                or athlete. If any of these summaries have been created for the athlete, the Bottom
                Player will be displayed below the Top Player.
            </p>
        </div>
        <div id="MsgDiv2" runat="server" visible="false" style="height: 30px; text-align: center;
            margin-bottom: 30px; margin-top: 10px">
            <p style="font-family: Magneto;">
                <font color="red" size="3px">Latest Summary Video is not displayed. Click
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">here</asp:LinkButton>
                    to request video.</font></p>
        </div>
        <p style="font-family: Magneto; font-style: italic; color: red; text-align: center">
            <asp:Label ID="Label13" runat="server" Visible="false"></asp:Label>
        </p>
        <%--<div id="SummaryRequest" visible="false" runat="server" style="height: 30px; text-align: center;
    margin-top: 30px">--%>
        <p style="font-family: Magneto; font-style: italic; color: red; text-align: center">
            <%--  <asp:Label ID="Label12" runat="server" Visible="false"></asp:Label>--%>
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
        <p style="font-family: Magneto;">
            Help: For in-depth help of all of the functions of the Video Players, click on the
            HELP button located in the top right corner of the Top Player.
        </p>
        <%--</div>--%>
        <%--<asp:Timer runat="server" ID="UpdateTimer" Interval="5000" OnTick="UpdateTimer_Tick" />--%>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanelForAll" runat="server">
    <ContentTemplate>
        <table>
            <tr>
                <td>
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
                            </div>
                            <div style="width: 180px; text-align: right; font-size: 18px; position: absolute;
                                left: 699px;">
                                <a href="javascript:OpenHelpWindow('MySwingHelp.aspx')">Help</a>
                            </div>
                        </div>
                        <div class="smsummaryright" id="smsummaryright">
                            <img src="../images/summaryheaderright.gif" width="25" height="40" alt="" /></div>
                        <div class="middleleft" id="middleleft">
                            <img src="../images/middleleft.gif" width="23" height="563" alt="" /></div>
                        <div class="middlecenter" id="middlecenter">
                            <asp:Panel CssClass="SummaryVideo" ID="Panel2" runat="server" BackImageUrl="~/Images/SummaryFrame.PNG"
                                Width="818" Height="318">
                                <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 20px;">
                                    <tr>
                                        <td>
                                            <div id="obj1div" runat="server" style="width: 395px; height: 300px; text-align: center;
                                                background-color: #78B6C3; vertical-align: middle; margin-top: 7px;">
                                                <%--<img alt="" src="../Images/indicator_48.png.gif" />--%>
                                               <br />
                                               <br />
                                               <br />
                                               <br />
                                               <br />
                                               <span style="font-weight: bold; color: #FFFFFF;">File Not Found
                                               <br/>
                                               SwingModel Will Contact You When Resolved</span>
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
                                            <div id="obj1div2" runat="server" style="width: 395px; height: 300px; text-align: center;
                                                background-color: #78B6C3; vertical-align: middle; margin-top: 7px">
                                                <%--<img alt="" src="../Images/indicator_48.png.gif" />--%>
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <span style="font-weight: bold; color: #FFFFFF;">File Not Found
                                                <br/>
                                                 SwingModel Will Contact You When Resolved</span>
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
                            <%--<asp:Image CssClass="SummaryFrame" ID="Image3" runat="server" ImageUrl="../Images/SummaryFrame.png" />--%>
                            <div class="logo" id="logo">
                                <img src="../images/RunnerLogo2.jpg" width="101" height="87" alt="" /></div>
                            <div>
                                <table width="663" border="0" cellspacing="0" cellpadding="0" style="position: absolute;
                                    height: 37px; width: 635px; left: 70px; right: 159px; top: 371px; margin-top: 3px;">
                                    <tr>
                                        <td width="78">
                                            <img id="btnPlay" src="../images/play.png" alt="Left click to Jog, right click to Play"
                                                oncontextmenu="playright(); return false;" onclick="playleftnew()" />
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
                            <%--  <asp:UpdatePanel ID="updatepanel1" runat="server">
            <ContentTemplate>--%>
                            <div class="sel1" id="sel1">
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="select1" AutoPostBack="True"
                                    Font-Size="11px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <%-- </ContentTemplate>     
       <Triggers>
                <asp:asyncpostbacktrigger controlid="dropdownlist3" />
            </triggers>       
        </asp:updatepanel>--%>
                            <asp:UpdatePanel ID="updatepanel1" runat="server">
                                <ContentTemplate>
                                    <div class="sel2" id="sel2">
                                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="select2" AutoPostBack="True"
                                            Font-Size="11px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                                            Height="23px">
                                        </asp:DropDownList>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropdownlist2" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <%-- <asp:UpdatePanel ID="updatepanel2" runat="server">
            <ContentTemplate>--%>
                            <div class="sel3" id="sel3">
                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="select3" AutoPostBack="true"
                                    ForeColor="Red" Font-Bold="true" Font-Size="11px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <%--  </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownList3" />
            </Triggers>
        </asp:UpdatePanel>--%>
                            <div class="square">
                                <div class="errorText" id="square">
                                    Your instructor messages will appear here.</div>
                            </div>
                        </div>
                        <div class="middleright" id="middleright">
                            <img src="../images/middleright.gif" width="25" height="563" alt="" /></div>
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
                            <%--<div id="summaryVideoDivMask" class="maskdiv">--%>
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
                            <%--<asp:UpdatePanel ID="SummaryPanal" runat="server">
            <ContentTemplate>--%>
                            <asp:Panel CssClass="SummaryVideo" ID="SummaryVideo" runat="server">
                                <div id="divsum" runat="server" style="text-align: center">
                                    <video id="sumMovie"  name="WMP" width="395" style="height: 295px; margin-left: 0px;
                                        margin-top: 3px">
                                        <param name="movie" value="<% =wmpfile %>" />
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
                                        <source id="sumMovie" src="<% =wmpfile %>" name="WMP" width="395" height="300" play="false"
                                            loop="false" quality="high" type='video/mp4; codecs="avc1.64001E"'></source>
                                    </video>
                                </div>
                            </asp:Panel>
                            <%--</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>--%>
                            <%--<asp:Image CssClass="SummaryFrame" ID="Image1" runat="server" ImageAlign="Middle" 
            ImageUrl="../Images/SummaryFrame.png" Height="316px" Width="411px" />  --%>
                            <%--<div id="loading" class="spinner">
        <img id="spinner" alt="spinner gif" src="../Images/indicator_48.png.gif" 
                 />
        </div>--%>
                            <div class="SummaryFrame" id="Image1" runat="server" style="text-align: center;">
                                <img src="../Images/SummaryFrame.PNG" alt="image" height="316px" style="width: 412px;
                                    margin-left: 16px" /></div>
                            <asp:Panel CssClass="SummaryButtons" ID="SummaryButtons" runat="server" Visible="true">
                                <table width="216" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="78">
                                            <img alt="Play" id="SummaryPlay" name="SummaryPlay" src="../Images/play.png" runat="server"
                                                onclick="PlaysumMovieFlashMovie();" />
                                        </td>
                                        <td width="10">
                                        </td>
                                        <td width="78">
                                            <img alt="Pause" id="Img1" name="SummaryPlay" src="../Images/pause.png" runat="server"
                                                onclick="PausesumMovieFlashMovie();" />
                                        </td>
                                        <td width="10">
                                        </td>
                                        <td width="40">
                                            <img alt="Stop" id="SummaryStop" name="SummaryStop" src="../Images/stop.png" runat="server"
                                                onclick="StopsumMovieFlashMovie();" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <%--  <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>--%>
                            <asp:Panel ID="SummaryDropDown" runat="server" Visible="true">
                                <asp:DropDownList ID="DropDownList4" CssClass="SummaryDropDown" runat="server" AutoPostBack="True"
                                    Width="310" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                                </asp:DropDownList>
                            </asp:Panel>
                            <%-- </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownList1" />
            </Triggers>
        </asp:UpdatePanel>--%>
                            <%--</div>--%></asp:Panel>
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
                            <img src="../images/over3.png" />2 img src="../images/over4.png" />
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
                    </div>
                </td>
            </tr>
        </table>
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
            <table id="SprintText" runat="server" style="float: left; width: 86%; margin-left: 65px">
                <tr>
                    <td>
                        <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                            Below the Video Player, the Variable Chart lists the results that are used to evaluate
                            the Maximum Velocity Sprint. If the results are from an On-Track Session, then the
                            athlete's initial run-through results are shown in the Initial column, while the
                            final effort is shown in the Final column. In both cases, the athlete's Model values
                            are shown in the column to the right of their values. If the athlete's results are
                            in the acceptable range, the Model results are shown in <font color="black"><b>black</b></font>.
                            If the results are not up to the Model's standard (needs improvement), the result
                            is shown in <font color="red">red</font>.</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                            If the results are from a competition, then the athlete's performance is shown in
                            the Final column. As in the On-Track Sessions, the athlete's Model values are shown
                            in the column to the right of their values. If the athlete's results are in the
                            acceptable range, the Model results are shown in black. If the results are not up
                            to the Model's standard (needs improvement), the result is shown in <font color="red">
                                red</font></p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                            Information on any of the variables can be found by clicking on the variable name
                            in the Chart.
                        </p>
                    </td>
                </tr>
            </table>
            <table id="SprintTireVariableText" runat="server" visible="false" style="float: left;
                padding: 0px; width: 86%; margin-left: 65px;">
                <tr>
                    <td>
                        <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                            Below the Video Player, the Variable Chart lists the results that are used to evaluate
                            the Maximum Velocity Sprint. In Comparison Mode, the results from the Session selected
                            in the left window of the Top Player are shown in the left <font color="#ffcc00">(yellow)</font>
                            column, while the results from the Session selected in the right window are shown
                            in the right <font color="green">(green)</font> column. In both cases, the athlete's
                            Model values are shown in the column to the right of their values. If the athlete's
                            results are in the acceptable range, the Model results are shown in black. If the
                            results are not up to the Model's standard (needs improvement), the result is shown
                            in <font color="red">red</font>.
                        </p>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" style="float: left; width: 835px; margin-left: 55px; border: 3px solid black;
                font-size: small">
                <tr>
                    <th align="left" style="width: 260px; background-color: #006699; color: #FFFFFF;
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
                    <td style="width: 260px; font-size: small; cursor: pointer; background-color: #FFCAB0;
                        width: 260px;" onclick="OpenVariablePopup('../VariablePages/GroundTime.aspx')">
                        Ground Time Left
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeLeftI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeLeftM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeLeftF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeLeftM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFCAB0; font-size: small; width: 260px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/GroundTime.aspx')">
                        Ground Time Right
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeRightI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeRightM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeRightF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeRightM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB895; width: 260px; font-size: small; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/GroundTime.aspx')">
                        Ground Time Average
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center;">
                        <asp:Label ID="lblGroundTimeAverageI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeAverageM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeAverageF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
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
                    <td onclick="OpenVariablePopup('../VariablePages/GroundTime.aspx')" style="background-color: #FFCAB0;
                        font-size: small; width: 260px; cursor: pointer;">
                        Air Time Left to Right
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblAirTimeLeftToRightI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblAirTimeLeftToRightM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblAirTimeLeftToRightF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblAirTimeLeftToRightM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/GroundTime.aspx')" style="background-color: #FFCAB0;
                        font-size: small; width: 260px; cursor: pointer;">
                        Air Time Right to Left
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblAirTimeRightToLeftI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblAirTimeRightToLeftM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblAirTimeRightToLeftF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblAirTimeRightToLeftM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/GroundTime.aspx')" style="background-color: #FFB895;
                        font-size: small; width: 260px; cursor: pointer;">
                        Air Time Average
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblAirTimeAverageI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblAirTimeAverageM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblAirTimeAverageF" runat="server"></asp:Label>
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
                    <td onclick="OpenVariablePopup('../VariablePages/TimeToUpperLegFullFlexion.aspx')"
                        style="background-color: #FFCAB0; width: 260px; font-size: small; cursor: pointer;">
                        Time to Upper Leg Full Flexion Left
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeToUpperLegFullFlexionLeftI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeToUpperLegFullFlexionLeftM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeToUpperLegFullFlexionLeftF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeToUpperLegFullFlexionLeftM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/TimeToUpperLegFullFlexion.aspx')"
                        style="background-color: #FFCAB0; font-size: small; width: 260px; cursor: pointer;">
                        Time to Upper Leg Full Flexion Right
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeToUpperLegFullFlexionRightI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeToUpperLegFullFlexionRightM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeToUpperLegFullFlexionRightF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeToUpperLegFullFlexionRightM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/TimeToUpperLegFullFlexion.aspx')"
                        style="background-color: #FFB895; font-size: small; width: 260px; cursor: pointer;">
                        Time to Upper Leg Full Flexion Average
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeToUpperLegFullFlexionAverageI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeToUpperLegFullFlexionAverageM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeToUpperLegFullFlexionAverageF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
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
                    <td onclick="OpenVariablePopup('../VariablePages/StrideRate.aspx')" style="background-color: #FFB895;
                        width: 260px; font-size: small; cursor: pointer;">
                        Stride Rate
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideRateI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideRateM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideRateF" runat="server"></asp:Label>
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
                    <td onclick="OpenVariablePopup('../VariablePages/StrideLength.aspx')" style="background-color: #FFCAB0;
                        font-size: small; width: 260px; cursor: pointer;">
                        Stride Length Left to Right
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthLeftToRightI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthLeftToRighM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthLeftToRighF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthLeftToRighM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/StrideLength.aspx')" style="background-color: #FFCAB0;
                        font-size: small; width: 260px; cursor: pointer;">
                        Stride Length Right to Left
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthRightToLeftI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthRightToLeftM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthRightToLeftF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthRightToLeftM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/StrideLength.aspx')" style="background-color: #FFB895;
                        font-size: small; width: 260px; cursor: pointer;">
                        Stride Length Average
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthAverageI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthAverageM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthAverageF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
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
                    <td onclick="OpenVariablePopup('../VariablePages/Velocity.aspx')" style="background-color: #FFB895;
                        font-size: small; width: 260px; cursor: pointer;">
                        Velocity
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblVelocity" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblVelocityM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblVelocityF" runat="server"></asp:Label>
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
                    <td onclick="OpenVariablePopup('../VariablePages/TouchDown.aspx')" style="background-color: #FFCAB0;
                        font-size: small; width: 260px; cursor: pointer;">
                        Touchdown Distance Left
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchDownDistanceLeftI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchDownDistanceLeftM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchDownDistanceLeftF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchDownDistanceLeftM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/TouchDown.aspx')" style="background-color: #FFCAB0;
                        font-size: small; width: 260px; cursor: pointer;">
                        Touchdown Distance Right
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchDownDistanceRightI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchDownDistanceRightM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchDownDistanceRightF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchDownDistanceRightM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/TouchDown.aspx')" style="background-color: #FFB895;
                        font-size: small; width: 260px; cursor: pointer;">
                        Touchdown Distance Average
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchDownDistanceAverageI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchDownDistanceAverageM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchDownDistanceAverageF" runat="server"></asp:Label>
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
                    <td onclick="OpenVariablePopup('../VariablePages/UpperLegFullExtension.aspx')" style="background-color: #FFCAB0;
                        font-size: small; width: 260px; cursor: pointer;">
                        Upper Leg Full Extension Angle Left
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullExtentionAngleLeftI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullExtentionAngleLeftM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullExtentionAngleLeftF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullExtentionAngleLeftM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/UpperLegFullExtension.aspx')" style="background-color: #FFCAB0;
                        font-size: small; width: 260px; cursor: pointer;">
                        Upper Leg Full Extension Angle Right
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullExtentionAngleRightI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullExtentionAngleRightM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullExtentionAngleRightF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullExtentionAngleRightM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/UpperLegFullExtension.aspx')" style="background-color: #FFB895;
                        font-size: small; width: 260px; cursor: pointer;">
                        Upper Leg Full Extension Angle Average
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullExtentionAngleAverageI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullExtentionAngleAverageM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullExtentionAngleAverageF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
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
                    <td onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')" style="background-color: #FFCAB0;
                        font-size: small; width: 260px; cursor: pointer;">
                        Lower Leg Angle at Takeoff Left
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegAngleAtTakeOfLeftI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegAngleAtTakeOfLeftM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegAngleAtTakeOfLeftF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegAngleAtTakeOfLeftM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')" style="background-color: #FFCAB0;
                        font-size: small; width: 260px; cursor: pointer;">
                        Lower Leg Angle at Takeoff Right
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegAngleAtTakeOfRightI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegAngleAtTakeOfRightM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegAngleAtTakeOfRightF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegAngleAtTakeOfRightM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')" style="background-color: #FFB895;
                        font-size: small; width: 260px; cursor: pointer;">
                        Lower Leg Angle at Takeoff Average
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegAngleAtTakeOfAverageI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegAngleAtTakeOfAverageM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegAngleAtTakeOfAverageF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
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
                    <td onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')" style="background-color: #FFCAB0;
                        font-size: small; width: 260px; cursor: pointer;">
                        Lower Leg Full Flexion Angle Left
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegFullFlexionAngleLeftI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegFullFlexionAngleLeftM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegFullFlexionAngleLeftF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegFullFlexionAngleLeftM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')" style="background-color: #FFCAB0;
                        font-size: small; width: 260px; cursor: pointer;">
                        Lower Leg Full Flexion Angle Right
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegFullFlexionAngleRightI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegFullFlexionAngleRightM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegFullFlexionAngleRightF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegFullFlexionAngleRightM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')" style="background-color: #FFB895;
                        width: 260px; font-size: small; cursor: pointer;">
                        Lower Leg Full Flexion Angle Average
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegFullFlexionAngleAverageI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegFullFlexionAngleAverageM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegFullFlexionAngleAverageF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblLowerLegFullFlexionAngleAverageM2" runat="server"></asp:Label>
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
                    <td onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')" style="background-color: #FFCAB0;
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
                    <td onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')" style="background-color: #FFCAB0;
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
                    <td onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')" style="background-color: #FFB895;
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
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/UpperLegFullFlexion.aspx')" style="background-color: #FFCAB0;
                        font-size: small; width: 260px; cursor: pointer;">
                        Upper Leg Full Flexion Angle Left
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullFlexionAngleLeftI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullFlexionAngleLeftM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullFlexionAngleLeftF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullFlexionAngleLeftM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/UpperLegFullFlexion.aspx')" style="background-color: #FFCAB0;
                        font-size: small; width: 260px; cursor: pointer;">
                        Upper Leg Full Flexion Angle Right
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullFlexionAngleRightI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullFlexionAngleRightM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullFlexionAngleRightF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullFlexionAngleRightM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td onclick="OpenVariablePopup('../VariablePages/UpperLegFullFlexion.aspx')" style="background-color: #FFB895;
                        font-size: small; width: 260px; cursor: pointer;">
                        Upper Leg Full Flexion Angle Average
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullFlexionAngleAverageI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullFlexionAngleAverageM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullFlexionAngleAverageF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegFullFlexionAngleAverageM2" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <%-- </div>--%>
        </div>
        <div id="StartId" runat="server">
            <table id="Startheader" style="float: left; width: 600px; height: 75px; margin-bottom: 220px;
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
                    <td>
                        <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            Below the Video Player, the Variable Chart lists the results that are used to evaluate
                            the Sprint Start. If the results are from an On-Track Session, then the athlete's
                            initial run-through results are shown in the Initial column, while the final effort
                            is shown in the Final column. In both cases, the athlete's Model values are shown
                            in the column to the right of their values. If the athlete's results are in the
                            acceptable range, the Model results are shown in black. If the results are not up
                            to the Model's standard (needs improvement), the result is shown in <font color="red">
                                red</font>).</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            If the results are from a competition, then the athlete's performance is shown in
                            the Final column. As in the On-Track Sessions, the athlete's Model values are shown
                            in the column to the right of their values. If the athlete's results are in the
                            acceptable range, the Model results are shown in black. If the results are not up
                            to the Model's standard (needs improvement), the result is shown in red.</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                            Information on any of the variables can be found by clicking on the variable name
                            in the Chart.
                        </p>
                    </td>
                </tr>
            </table>
            <table id="StartTireVariablesChart" runat="server" style="float: left; padding: 0px;
                width: 600px; margin-top: -230px; margin-bottom: 15px; padding: 0px; width: 86%;
                margin-left: 65px">
                <tr>
                    <td>
                        <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                            Below the Video Player, the Variable Chart lists the results that are used to evaluate
                            the Start. In Comparison Mode, the results from the Session selected in the left
                            window of the Top Player are shown in the left <font color="#ff9900">(yellow)</font>
                            column, while the results from the Session selected in the right window are shown
                            in the right <font color="green">(green)</font> column. In both cases, the athlete's
                            Model values are shown in the column to the right of their values. If the athlete's
                            results are in the acceptable range, the Model results are shown in black. If the
                            results are not up to the Model's standard (needs improvement), the result is shown
                            in <font color="red">red</font>.
                        </p>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" style="float: left; width: 834px; margin-left: 53px; border: 3px solid black;
                font-size: small">
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
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartSetBlockDistance.aspx')">
                        Front Block Distance
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblSetFrontBlockDistanceI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblSetFrontBlockDistanceM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblSetFrontBlockDistanceF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblSetFrontBlockDistanceM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartSetBlockDistance.aspx')">
                        Rear Block Distance
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblSetRearBlockDistanceI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblSetRearBlockDistanceM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblSetRearBlockDistanceF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblSetRearBlockDistanceM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartSegmentAnglesatSetPosition.aspx')">
                        Front Upper Leg Angle
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center;">
                        <asp:Label ID="lblSetFrontULAngleI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblSetFrontULAngleM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblSetFrontULAngleF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblSetFrontULAngleM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartSegmentAnglesatSetPosition.aspx')">
                        Rear Upper Leg Angle
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblSetRearULAngleI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblSetRearULAngleM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblSetRearULAngleF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblSetRearULAngleM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartSegmentAnglesatSetPosition.aspx')">
                        Front Lower Leg Angle
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblSetFrontLLAngleI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblSetFrontLLAngleM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblSetFrontLLAngleF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblSetFrontLLAngleM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartSegmentAnglesatSetPosition.aspx')">
                        Rear Lower Leg Angle
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblSetRearLLAngleI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblSetRearLLAngleM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblSetRearLLAngleF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblSetRearLLAngleM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartSegmentAnglesatSetPosition.aspx')">
                        Trunk Angle
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblSetTrunkAngleI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblSetTrunkAngleM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblSetTrunkAngleF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblSetTrunkAngleM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartcogDistanceatSetPosition.aspx')">
                        COG Distance
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblSetCOGDistanceI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblSetCOGDistanceM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblSetCOGDistanceF" runat="server"></asp:Label>
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
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenSegmentAnglesDuringBlockClearance('../VariablePages/SegmentAnglesDuringBlockClearance.aspx')">
                        <b>Block Clearance</b>
                    </td>
                    <td colspan="2" style="background-color: #FFFF80; width: 115px; font-size: 13px;">
                    </td>
                    <td colspan="2" style="background-color: #C0FFC0; width: 110px; font-size: 13px;">
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartGroundTimeandAirTime.aspx')">
                        Rear Foot Clearance Time
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblBCRearFootClearanceTimeI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblBCRearFootClearanceTimeM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblBCRearFootClearanceTimeF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblBCRearFootClearanceTimeM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartGroundTimeandAirTime.aspx')">
                        Front Foot Clearance Time
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblBCFrontFootClearanceTimeI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblBCFrontFootClearanceTimeM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblBCFrontFootClearanceTimeF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblBCFrontFootClearanceTimeM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/SegmentAnglesDuringBlockClearance.aspx')">
                        Rear Lower Leg Angle at Rear Takeoff
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblBCRearLLAngleTakeoffI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblBCRearLLAngleTakeoffM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblBCRearLLAngleTakeoffF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblBCRearLLAngleTakeoffM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/SegmentAnglesDuringBlockClearance.aspx')">
                        Front Lower Leg Angle at Front Takeoff
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblBCFrontLLAngleTakeoffI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblBCFrontLLAngleTakeoffM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblBCFrontLLAngleTakeoffF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblBCFrontLLAngleTakeoffM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/SegmentAnglesDuringBlockClearance.aspx')">
                        Trunk Angle at Takeoff
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblBCTrunkAngleTakeoffI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblBCTrunkAngleTakeoffM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblBCTrunkAngleTakeoffF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblBCTrunkAngleTakeoffM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/SegmentAnglesDuringBlockClearance.aspx')">
                        Lower Leg Angle at Ankle Cross
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblBCLLAngleACI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblBCLLAngleACM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblBCLLAngleACF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblBCLLAngleACM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartGroundTimeandAirTime.aspx')">
                        Air Time
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblBCAirTimeI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblBCAirTimeM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblBCAirTimeF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblBCAirTimeM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Start_strideLengthandRate.aspx')">
                        Stride Rate
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblBCStrideRateI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblBCStrideRateM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblBCStrideRateF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblBCStrideRateM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Start_strideLengthandRate.aspx')">
                        Stride Length
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblBCStrideLengthI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblBCStrideLengthM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblBCStrideLengthF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblBCStrideLengthM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartHorizontalVelocity.aspx')">
                        Velocity
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblBCVelocityI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblBCVelocityM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblBCVelocityF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblBCVelocityM2" runat="server"></asp:Label>
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
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartTouchdowndistance.aspx')">
                        COG Touchdown Distance
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1COGDistanceI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1COGDistanceM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1COGDistanceF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1COGDistanceM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartTouchdowndistance.aspx')">
                        Rear Lower Leg Angle at Takeoff
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1LLAngleTakeoffI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1LLAngleTakeoffM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1LLAngleTakeoffF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1LLAngleTakeoffM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartTouchdowndistance.aspx')">
                        Trunk Angle at Takeoff
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1TrunkAngleTakeoffI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1TrunkAngleTakeoffM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1TrunkAngleTakeoffF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1TrunkAngleTakeoffM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartTouchdowndistance.aspx')">
                        Lower Leg Angle at Ankle Cross
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1LLAngleACI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1LLAngleACM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1LLAngleACF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1LLAngleACM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartGroundTimeandAirTime.aspx')">
                        Ground Time
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1GroundTimeI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1GroundTimeM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1GroundTimeF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1GroundTimeM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartGroundTimeandAirTime.aspx')">
                        Air Time
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1AirTimeI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1AirTimeM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1AirTimeF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1AirTimeM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Start_strideLengthandRate.aspx')">
                        Stride Rate
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1StrideRateI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1StrideRateM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1StrideRateF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1StrideRateM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Start_strideLengthandRate.aspx')">
                        Stride Length
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1StrideLengthI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1StrideLengthM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1StrideLengthF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1StrideLengthM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartHorizontalVelocity.aspx')">
                        Velocity
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1VelocityI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1VelocityM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1VelocityF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1VelocityM2" runat="server"></asp:Label>
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
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/COGDistanceandSegmentAnglesDuringStep2.aspx')">
                        COG Touchdown Distance
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2COGDistanceI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2COGDistanceM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2COGDistanceF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2COGDistanceM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/COGDistanceandSegmentAnglesDuringStep2.aspx')">
                        Rear Lower Leg Angle at Takeoff
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2LLAngleTakeoffI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2LLAngleTakeoffM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2LLAngleTakeoffF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2LLAngleTakeoffM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/COGDistanceandSegmentAnglesDuringStep2.aspx')">
                        Trunk Angle at Takeoff
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2TrunkAngleTakeoffI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2TrunkAngleTakeoffM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2TrunkAngleTakeoffF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2TrunkAngleTakeoffM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/COGDistanceandSegmentAnglesDuringStep2.aspx')">
                        Lower Leg Angle at Ankle Cross
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2LLAngleACI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2LLAngleACM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2LLAngleACF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2LLAngleACM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartGroundTimeandAirTime.aspx')">
                        Ground Time
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2GroundTimeI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2GroundTimeM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2GroundTimeF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2GroundTimeM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartGroundTimeandAirTime.aspx')">
                        Air Time
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2AirTimeI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2AirTimeM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2AirTimeF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2AirTimeM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Start_strideLengthandRate.aspx')">
                        Stride Rate
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2StrideRateI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2StrideRateM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2StrideRateF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2StrideRateM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Start_strideLengthandRate.aspx')">
                        Stride Length
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2StrideLengthI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2StrideLengthM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2StrideLengthF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2StrideLengthM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartHorizontalVelocity.aspx')">
                        Velocity
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2VelocityI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2VelocityM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2VelocityF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep2VelocityM2" runat="server"></asp:Label>
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
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/StartCOGDistanceDuringStep3.aspx')">
                        COG Touchdown Distance
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep3COGDistanceI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblStep3COGDistanceM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep3COGDistanceF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblStep3COGDistanceM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Start_3to5meter.aspx')">
                        <b>Time to Marker</b>
                    </td>
                    <td colspan="2" style="background-color: #FFFF80; width: 115px; font-size: 13px;">
                    </td>
                    <td colspan="2" style="background-color: #C0FFC0; width: 110px; font-size: 13px;">
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Start_3to5meter.aspx')">
                        Time to 3m
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeTo3mI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeTo3mM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeTo3mF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #91F591; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeTo3mM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Start_3to5meter.aspx')">
                        Time to 5m
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeTo5mI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeTo5mM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeTo5mF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblTimeTo5mM2" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div id="HurdleId" runat="server" style="margin-left: 1px;">
            <table id="HurdleHeader" style="float: left; padding: l0px; width: 600px; height: 40px;
                text-align: center; margin-left: 130px; margin-top: 10px">
                <tr>
                    <td style="font-size: 22px; font-family: Magneto;">
                        <b>The Variable Chart</b>
                    </td>
                </tr>
            </table>
            <table id="HurdleText" runat="server" style="float: left; margin-top: 8px; padding: 0px;
                width: 600px; margin-left: 65px">
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
                            If the results are from a competition, then the athlete's performance is shown in
                            the Final column. As in the On-Track Sessions, the athlete's Model values are shown
                            in the column to the right of their values. If the athlete's results are in the
                            acceptable range, the Model results are shown in black. If the results are not up
                            to the Model's standard (needs improvement),the result is shown in red.</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p style="width: 794px; font-family: Magneto; font-size: large;">
                            Information on any of the variables can be found by clicking on the variable name
                            in the Chart.
                        </p>
                    </td>
                </tr>
            </table>
            <table id="HurdleTireVarableChart" runat="server" visible="false" style="float: left;
                margin-top: 30px; padding: 0px; width: 600px; margin-left: 65px">
                <tr>
                    <td>
                        <p style="width: 794px; font-family: Magneto; font-size: large;">
                            Below the Video Player, the Variable Chart lists the results that are used to evaluate
                            the Maximum Velocity Hurdle. In Comparison Mode, the results from the Session selected
                            in the left window of the Top Player are shown in the left <font color="#ff9900">(yellow)</font>
                            column, while the results from the Session selected in the right window are shown
                            in the right <font color="green">(green)</font> column. In both cases, the athlete's
                            Model values are shown in the column to the right of their values. If the athlete's
                            results are in the acceptable range, the Model results are shown in black. If the
                            results are not up to the Model's standard (needs improvement), the result is shown
                            in <font color="red">red</font>.
                        </p>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" style="float: left; width: 834px; margin-left: 53px; border: 3px solid black;
                font-size: small">
                <tr>
                    <th align="left" style="width: 390px; background-color: #006699; color: #FFFFFF;
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
                    <td style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Hurdle_GroundTime.aspx')">
                        Ground Time Into
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeIntoI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeIntoM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeIntoF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeIntoM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Hurdle_GroundTime.aspx')">
                        Ground Time Off
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeOffI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeOffM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblGroundTimeOffF" runat="server"></asp:Label>
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
                    <td style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Hurdle_AirtimeAndStrideRate.aspx')">
                        Air Time
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblAirTimeI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblAirTimeM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblAirTimeF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
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
                    <td style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Hurdle_AirtimeAndStrideRate.aspx')">
                        Stride Length Into
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthIntoI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthIntoM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthIntoF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthIntoM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Hurdle_AirtimeAndStrideRate.aspx')">
                        Stride Length Off
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthOffI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthOffM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthOffF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthOffM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Hurdle_AirtimeAndStrideRate.aspx')">
                        Stride Length Total
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthTotalI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthTotalM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblStrideLengthTotalF" runat="server"></asp:Label>
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
                    <td style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Hurdle_Velocity.aspx')">
                        Velocity
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblVelocityI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblVelocityHurdleM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblVelocityHurdleF" runat="server"></asp:Label>
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
                    <td style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/HurdleTDIonAndoff.aspx')">
                        Touchdown Distance Into
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchdownDistanceIntoI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchdownDistanceIntoM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchdownDistanceIntoF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchdownDistanceIntoM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/HurdleTDIonAndoff.aspx')">
                        Touchdown Distance Off
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchdownDistanceOffI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchdownDistanceOffM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblTouchdownDistanceOffF" runat="server"></asp:Label>
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
                    <td style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Hurdle_UpperLegTDInto.aspx')">
                        Upper Leg Angle at Touchdown Into
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegAngleatTouchdownIntoI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegAngleatTouchdownIntoM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegAngleatTouchdownIntoF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegAngleatTouchdownIntoM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Hurdle_UpperLegTDInto.aspx')">
                        Upper Leg Angle at Takeoff Into
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegAngleatTakeoffIntoI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegAngleatTakeoffIntoM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegAngleatTakeoffIntoF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
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
                    <td style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Hurdle_UpperLegTDInto.aspx')">
                        Upper Leg Angle at Touchdown Off
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegAngleatTouchdownOffI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegAngleatTouchdownOffM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegAngleatTouchdownOffF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegAngleatTouchdownOffM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/Hurdle_UpperLegTDInto.aspx')">
                        Upper Leg Angle at Takeoff Off
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegAngleatTakeoffOffI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegAngleatTakeoffOffM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblUpperLegAngleatTakeoffOffF" runat="server"></asp:Label>
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
                    <td style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/HurdleLowerLegRecoveryMotion.aspx')">
                        Lead Lower Leg Minimum Angle Into
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblLeadLowerLegMinimumAngleIntoI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblLeadLowerLegMinimumAngleIntoM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblLeadLowerLegMinimumAngleIntoF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblLeadLowerLegMinimumAngleIntoM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;"
                        onclick="OpenVariablePopup('../VariablePages/HurdleLowerLegRecoveryMotion.aspx')">
                        Lead Lower Leg Angle at Ankle Cross Into
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblLeadLowerLegAngleatAnkleCrossIntoI" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblLeadLowerLegAngleatAnkleCrossIntoM1" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblLeadLowerLegAngleatAnkleCrossIntoF" runat="server"></asp:Label>
                    </td>
                    <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblLeadLowerLegAngleatAnkleCrossIntoM2" runat="server"></asp:Label>
                    </td>
                </tr>
                <caption>
                    <br/>
                    <br/>
                    <br/>
                    <br/>
                    <br/>
                    <br>
                    <br></br>
                    <br></br>
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
                        <td onclick="OpenVariablePopup('../VariablePages/HurdleLowerLegMotion.aspx')" 
                            style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;">
                            Lower Leg Angle at Touchdown Off
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleatTouchdownOffI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleatTouchdownOffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleatTouchdownOffF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleatTouchdownOffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td onclick="OpenVariablePopup('../VariablePages/HurdleLowerLegMotion.aspx')" 
                            style="background-color: #FFCAB0; width: 280px; font-size: 13px; cursor: pointer;">
                            Lower Leg Angle at Takeoff Off
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleatTakeoffOffI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleatTakeoffOffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleatTakeoffOffF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblLowerLegAngleatTakeoffOffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <caption>
                        <br>
                        <br>
                        <br>
                        <br></br>
                        <br></br>
                        <br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        </br>
                        </br>
                        </br>
                        </br>
                    </caption>
                    <caption>
                        <br>
                        <br>
                        <br></br>
                        <br></br>
                        <br>
                        <br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        </br>
                        </br>
                        </br>
                        </br>
                    </caption>
                    <caption>
                        <br>
                        <br></br>
                        <br></br>
                        <br>
                        <br></br>
                        <br></br>
                        <br>
                        <br></br>
                        <br></br>
                        </br>
                        </br>
                        </br>
                    </caption>
                    <caption>
                        <br>
                        <br></br>
                        <br></br>
                        <br>
                        <br></br>
                        <br></br>
                        <br>
                        <br></br>
                        <br></br>
                        <br>
                        <br></br>
                        <br></br>
                        </br>
                        </br>
                        </br>
                        </br>
                    </caption>
                    </br>
                </caption>
            </table>
        </div>
        <br/>
                <br/>
                <br />
                <br/>
                <br />
                 <br/>
                <br />
                <br/>
                <br />
        <div id="HurdleStepId" runat="server">
                 <table id="HurdleStepsHeader" style="float: left; padding: l0px; width: 600px; height: 40px;
                    text-align: center; margin-left: 130px; margin-top: 10px">
                    <tr>
                        <td style="font-size: 22px; font-family: Magneto;">
                            <b>The Variable Chart</b>
                        </td>
                    </tr>
                </table>
                
                <table id="HurdleStepText" runat="server" style="width: 600px; margin-top: -230px; margin-bottom: 15px;
                    width: 86%; margin-left: 65px;">
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                                Below the Video Player, the Variable Chart lists the results that are used to evaluate
                                the Sprint Start. If the results are from an On-Track Session, then the athlete's
                                initial run-through results are shown in the Initial column, while the final effort
                                is shown in the Final column. In both cases, the athlete's Model values are shown
                                in the column to the right of their values. If the athlete's results are in the
                                acceptable range, the Model results are shown in black. If the results are not up
                                to the Model's standard (needs improvement), the result is shown in <font color="red">
                                    red</font>).</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                                If the results are from a competition, then the athlete's performance is shown in
                                the Final column. As in the On-Track Sessions, the athlete's Model values are shown
                                in the column to the right of their values. If the athlete's results are in the
                                acceptable range, the Model results are shown in black. If the results are not up
                                to the Model's standard (needs improvement), the result is shown in red.</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="width: 797px; text-align: justify; font-family: Magneto; font-size: 18px;">
                                Information on any of the variables can be found by clicking on the variable name
                                in the Chart.
                            </p>
                        </td>
                    </tr>
                </table>
                <table id="HurdleStepTireVariablesText" runat="server" style="float: left; padding: 0px;
                    width: 600px; margin-top: -230px; margin-bottom: 15px; padding: 0px; width: 86%;
                    margin-left: 65px">
                    <tr>
                        <td>
                            <p style="width: 797px; font-family: Magneto; font-size: 18px;">
                                Below the Video Player, the Variable Chart lists the results that are used to evaluate
                                the Start. In Comparison Mode, the results from the Session selected in the left
                                window of the Top Player are shown in the left <font color="#ff9900">(yellow)</font>
                                column, while the results from the Session selected in the right window are shown
                                in the right <font color="green">(green)</font> column. In both cases, the athlete's
                                Model values are shown in the column to the right of their values. If the athlete's
                                results are in the acceptable range, the Model results are shown in black. If the
                                results are not up to the Model's standard (needs improvement), the result is shown
                                in <font color="red">red</font>.
                            </p>
                        </td>
                    </tr>
                </table>
                
                      <table cellpadding="0" style="float: left; width: 834px; margin-left: 53px; border: 3px solid black;
                    font-size: small">
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
                        <td width="120px" id="HurdleStepFinal" runat="server" style="background-color: #006699;" align="center">
                            Final
                        </td>
                        <td width="120px" id="Td6" align="center" runat="server" style="background-color: #006699;
                            font-weight: bold; color: #FFFFFF">
                            Model
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 390px; font-size: small;">
                            <b>Hurdle Distances </b>
                        </td>
                        <td colspan="2" style="background-color: #FFFF80; width: 115px; font-size: 13px;">
                        </td>
                        <td colspan="2" style="background-color: #C0FFC0; width: 110px; font-size: 13px;">
                        </td>
                    </tr>
                    <tr style="font-size: small">
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;">
                            Between the Hurdles
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblHurdleStepBetweenI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblHurdleStepBetweenM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblHurdleStepBetweenF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblHurdleStepBetweenM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;">
                            Into the Hurdle
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblHurdleStepIntoI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblHurdleStepIntoM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblHurdleStepIntoF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblHurdleStepIntoM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            >
                            Off the Hurdle
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center;">
                            <asp:Label ID="lblHurdleStepOffI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblHurdleStepOffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblHurdleStepOffF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblHurdleStepOffM2" runat="server"></asp:Label>
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
                        <td style="background-color: #FFE1AA; font-size: 13px; " class="style1" onclick="OpenVariablePopup('../VariablePages/Velocity.aspx')">
                            <b>Hurdle Step Velocity </b>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblHurdleStepVelocityI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblHurdleStepVelocityM1" runat="server"></asp:Label>
                        </td>
                        <td  style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblHurdleStepVelocityF" runat="server"></asp:Label>
                        </td>
                        <td  style="background-color: #C0FFC0; font-size: small; text-align: center">
                        <asp:Label ID="lblHurdleStepVelocityM2" runat="server"></asp:Label>
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
                            <b>Step One</b>
                        </td>
                        <td colspan="2" style="background-color: #EBEB41; width: 115px; font-size: 13px;">
                        </td>
                        <td colspan="2" style="background-color: #91F591; width: 110px; font-size: 13px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/GroundTime.aspx')">
                            Ground Time
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1HSGroundTimeI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblStep1HSGroundTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1HSGroundTimeF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1HSGroundTimeM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/GroundTime.aspx')">
                            Air Time
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1HSAirTimeI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1HSAirTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1HSAirTimeF" runat="server"></asp:Label>
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
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/StrideRate.aspx')">
                            Stride Rate
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1HSStrideRateI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1HSStrideRateM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1HSStrideRateF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1HSStrideRateM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/StrideLength.aspx')">
                            Stride Length
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1HSStrideLengthI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1HSStrideLengthM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1HSStrideLengthF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1HSStrideLengthM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/TouchDown.aspx')">
                            Touchdown Distance
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1TouchdownDistanceI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1TouchdownDistanceM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1TouchdownDistanceF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1TouchdownDistanceM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/TouchDown.aspx')">
                            Knee Seperation at Touchdown
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1KSTouchdownI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1KSTouchdownM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1KSTouchdownF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1KSTouchdownM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/TouchDown.aspx')">
                            Trunk Touchdown Angle
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1TrunkTouchdownAngleI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1TrunkTouchdownAngleM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1TrunkTouchdownAngleF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1TrunkTouchdownAngleM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')">
                            Trunk Takeoff Angle
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1TrunkTakeoffAngleI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1TrunkTakeoffAngleM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1TrunkTakeoffAngleF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1TrunkTakeoffAngleM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/UpperLegFullExtension.aspx')">
                            Upper Leg at Full Extension
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1ULFullExtensionI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1ULAtFullExtensionM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1ULAtFullExtensionF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1ULFullExtensionM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')">
                            Lower Leg at Take off
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1LLAtTakeoffI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1LLAtTakeoffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1LLAtTakeoffF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1LLAtTakeoffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/UpperLegFullFlexion.aspx')">
                            Upper Leg at Full Flexion
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1ULFullFlexionI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1ULFullFlexionM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1ULFullFlexionF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep1ULFullFlexionM2" runat="server"></asp:Label>
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
                        <td style="background-color: #FFE1AA ; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/GroundTime.aspx')">
                            Ground Time
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2HSGroundTimeI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2HSGroundTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2HSGroundTimeF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2HSGroundTimeM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/GroundTime.aspx')">
                            Air Time
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2HSAirTimeI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2HSAirTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2HSAirTimeF" runat="server"></asp:Label>
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
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/StrideRate.aspx')">
                            Stride Rate
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2HSStrideRateI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2HSStrideRateM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2HSStrideRateF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2HSStrideRateM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/StrideLength.aspx')">
                            Stride Length
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2HSStrideLengthI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStepHS2StrideLengthM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2HSStrideLengthF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2HSStrideLengthM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/TouchDown.aspx')">
                            Touchdown Distance
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2TouchdownDistanceI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2TouchdownDistanceM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2TouchdownDistanceF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2TouchdownDistanceM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/TouchDown.aspx')">
                            Knee Seperation at Touchdown
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2KSAtTouchdownI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2KSAtTouchdownM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2KSAtTouchdownF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2KSAtTouchdownM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/StartTouchdowndistance.aspx')">
                            Trunk Touchdown Angle
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2TrunkTouchdownAngleI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2TrunkTouchdownAngleM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2TrunkTouchdownAngleF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2TrunkTouchdownAngleM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')">
                            Trunk Takeoff Angle
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2TrunkTakeoffAngleI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2TrunkTakeoffAngleM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2TrunkTakeoffAngleF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2TrunkTakeoffAngleM2" runat="server"></asp:Label>
                        </td>
                    </tr>

                    
                    
                    
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/UpperLegFullExtension.aspx')">
                            Upper Leg at Full Extension
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2ULAtFullExtensionI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2ULAtFullExtensionM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2ULAtFullExtensionF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2ULAtFullExtensionM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')">
                            Lower Leg at Take off
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAtTakeoffI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAtTakeoffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAtTakeoffF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAtTakeoffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')">
                            Lower Leg at Full Flexion
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAtFullFlexionI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLFullAtFlexionM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAtFullFlexionF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2LLAtFullFlexionM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')">
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
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/UpperLegFullFlexion.aspx')">
                            Upper Leg at Full Flexion
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2ULAtFullFlexionI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2ULAtFullFlexionM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep2ULAtFullFlexionF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
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
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/GroundTime.aspx')">
                            Ground Time
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3HSGroundTimeI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3HSGroundTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3HSGroundTimeF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3HSGroundTimeM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/GroundTime.aspx')">
                            Air Time
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3HSAirTimeI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3HSAirTimeM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3HSAirTimeF" runat="server"></asp:Label>
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
                        <td style="background-color: #FFE1AA ; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/StrideRate.aspx')">
                            Stride Rate
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3StrideRateI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3StrideRateM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3StrideRateF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3StrideRateM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/StrideLength.aspx')">
                            Stride Length
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3StrideLengthI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3StrideLengthM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3StrideLengthF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3StrideLengthM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/TouchDown.aspx')">
                            Touchdown Distance
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3TouchdownDistanceI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3TouchdownDistanceM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3TouchdownDistanceF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3TouchdownDistanceM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/TouchDown.aspx')">
                            Knee Seperation at Touchdown
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3KSAtTouchdownI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3KSAtTouchdownM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3KSAtTouchdownF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3KSAtTouchdownM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/TouchDown.aspx')">
                            Trunk Touchdown Angle
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3TrunkTouchdownAngleI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3TrunkTouchdownAngleM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3TrunkTouchdownAngleF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3TrunkTouchdownAngleM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                                       
                     <tr>
                         <td onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')" 
                             style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;">
                             Trunk Takeoff Angle
                         </td>
                         <td style="background-color: #EBEB41; font-size: small; text-align: center">
                             <asp:Label ID="lblStep3TrunkTakeoffAngleI" runat="server"></asp:Label>
                         </td>
                         <td style="background-color: #EBEB41; font-size: small; text-align: center">
                             <asp:Label ID="lblStep3TrunkTakeoffAngleM1" runat="server"></asp:Label>
                         </td>
                         <td style="background-color: #91F591; font-size: small; text-align: center">
                             <asp:Label ID="lblStep3TrunkTakeoffAngleF" runat="server"></asp:Label>
                         </td>
                         <td style="background-color: #91F591; font-size: small; text-align: center">
                             <asp:Label ID="lblStep3TrunkTakeoffAngleM2" runat="server"></asp:Label>
                         </td>
                     </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/UpperLegFullExtension.aspx')">
                            Upper Leg at Full Extension
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3ULAtFullExtensionI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3ULAtFullExtensionM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3ULAtFullExtensionF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3ULAtFullExtensionM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')">
                            Lower Leg at Take off
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3LLAtTakeoffI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3LLAtTakeoffM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3LLAtTakeoffF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3LLAtTakeoffM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')">
                            Lower Leg at Full Flexion
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3LLAtFullFlexionI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3LLAtFullFlexionM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3LLAtFullFlexionF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3LLAtFullFlexionM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; font-size: 13px; "
                            
                            onclick="OpenVariablePopup('../VariablePages/LowerLegAngleAtTakeOf.aspx')" 
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
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/UpperLegFullFlexion.aspx')">
                            Upper Leg at Full Flexion
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3ULAtFullFlexionI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3ULAtFullFlexionM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblStep3ULAtFullFlexionF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
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
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenSegmentAnglesDuringBlockClearance('../VariablePages/SegmentAnglesDuringBlockClearance.aspx')">
                            <b>Into The Hurdle </b>
                        </td>
                        <td colspan="2" style="background-color: #EBEB41; width: 110px; font-size: 13px;">
                        </td>
                        <td colspan="2" style="background-color: #91F591; width: 110px; font-size: 13px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/TouchDown.aspx')">
                            Touchdown Distance
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblIntoHurdleTouchdownDistanceI" runat="server"></asp:Label>
                        </td>
                         <td style="background-color: #FFFF80; font-size: small; text-align: center">
                            <asp:Label ID="lblIntoHurdleTouchdownDistanceM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblIntoHurdleTouchdownDistanceF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblIntoHurdleTouchdownDistanceM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/TouchDown.aspx')">
                            Knee Seperation at Touchdown
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                        <asp:Label ID="lblIntoHurdleKSTouchdownI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41;font-size: small; text-align: center">
                        <asp:Label ID="lblIntoHurdleKSTouchdownM1" runat="server"></asp:Label>
                        </td>
                        
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblIntoHurdleKSTouchdownF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblIntoHurdleKSTouchdownM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                    
                     <tr>
                        <td style="background-color: #FFE1AA; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/TouchDown.aspx')">
                            Trunk Touchdown Angle
                        </td>
                        <td style="background-color: #FFFF80; font-size: small; text-align: center">
                        <asp:Label ID="lblIntoHurdleTrunkTouchdownAngleI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #FFFF80;font-size: small; text-align: center">
                        <asp:Label ID="lblIntoHurdleTrunkTouchdownAngleM1" runat="server"></asp:Label>
                        </td>
                        
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblIntoHurdleTrunkTouchdownAngleF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #C0FFC0; font-size: small; text-align: center">
                            <asp:Label ID="lblIntoHurdleTrunkTouchdownAngleM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFB9AF; width: 290px; font-size: 13px; cursor: pointer;"
                            onclick="OpenVariablePopup('../VariablePages/TouchDown.aspx')">
                            Lower Leg at Touchdown
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblIntoHurdleLLTouchdownI" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #EBEB41; font-size: small; text-align: center">
                            <asp:Label ID="lblIntoHurdleLLTouchdownM1" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblIntoHurdleLLTouchdownF" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #91F591; font-size: small; text-align: center">
                            <asp:Label ID="lblIntoHurdleLLTouchdownM2" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        


    </ContentTemplate>
    <%--<Triggers>
        <asp:AsyncPostBackTrigger  ControlID="UpdateTimer" EventName="Tick" />
    </Triggers>--%>
</asp:UpdatePanel>

<script type="text/javascript">
    var clicknum = 0;
    var selectedLessonId = document.getElementById("<%=DropDownList1.ClientID %>").value;

    function RefreshDropdowns() {
        //debugger;

        clicknum++;
        if (clicknum == 2) {
            if (selectedLessonId == document.getElementById("<%=DropDownList1.ClientID %>").value) {

                document.getElementById('<%=btnreset.ClientID%>').click()
            }
            else {
                selectedLessonId = document.getElementById("<%=DropDownList1.ClientID %>").value;
            }
            clicknum = 0;
        }
    }
</script>

<%
    if (DropDownList2.SelectedItem.Text.Equals("Sprint"))
    {
%>

<script type="text/javascript">
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
%>