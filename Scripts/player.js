com = {};
com.acap = {};

com.acap.VideoPlayer = new Class({

    initialize: function() {

        var self = this;

        this.isLeftLoaded = false;
        this.isRightLoaded = false;
        this.isRewinded = false;

        this.currFrame = 1;
        this.currFrameSet = 0;
        this.nextFrameSet = 0;
        if (leftMovie == null || rightMovie == null) {
            return;
        }
        this.leftInfo = JSON.decode(leftMovie);
        this.rightInfo = JSON.decode(rightMovie);

        this.totalFrameSet = this.rightInfo.clips.length;
        this.totalFrames = this.rightInfo.clips.getLast().endFrame;
        this.cache_end_frames();

        this.isPausedManually = false;
        this.isPlaying = false;
        this.isPlayingFrameSet = true;
        this.cb_clear_indicator = function() { };
        this.cb_show_indicator = function() { };

        var flashvars = {};

        flashvars.name = "leftVideo";
        flashvars.path = leftMoviePath;
        //  flashvars.controlbar = "over";
        //  flashvars.icons = "true";
        //  flashvars.bufferlength = "10";


        swfobject.embedSWF("../Users/player.swf?" + Math.random(), "player1", "437", "329", "9.0.0", "../Scripts/swfobject/expressInstall.swf", flashvars, { bgcolor: "#ffffff" });

        flashvars.name = "rightVideo";
        flashvars.path = rightMoviePath;

        swfobject.embedSWF("../Users/player.swf?" + Math.random(), "player2", "437", "329", "9.0.0", "../Scripts/swfobject/expressInstall.swf", flashvars, { bgcolor: "#ffffff" });

        this.leftVideo = $("player1");
        this.rightVideo = $("player2");

        this.init_ui();
    },

    init_ui: function() {

        $("btnPlay").addEvent("click", this.play.bind(this));
        $("btnStop").addEvent("click", this.stop.bind(this));
        $("btnRewind").addEvent("click", this.rewind.bind(this));
        $("btnForwind").addEvent("click", this.forwind.bind(this));

        $("btnPlay").addEvent('contextmenu', this.play_cont.bind(this));

        var self = this;
        var b = function(btn, i) {
            if (i < self.totalFrameSet)
                btn.addEvent("click", self.go_to_fs.bind(self, i));
            else
                btn.set("style", "display:none");
        };

        $$("img.btnVideoNo").each(b);
        $("btns").getElement("table").set("style", "display:block");

        b = null;

        //$("SummaryPlay").addEvent("click", this.playflash.bind(this));
        //$("SummaryPause").addEvent("click", this.pauseflash.bind(this));
        //$("SummaryStop").addEvent("click", this.stopflash.bind(this));
    },

    play_cont: function(e) {

        if (e) {
            var e = new Event(e).stop();
        }

        this.stop();
        this.isPlaying = true;
        this.isPlayingCont = true;

        this.leftVideo.play_cont();
        this.rightVideo.play_cont();

        this.clear_err_text();
        this.clear_indicator(this.currFrameSet);
    },

    play: function() {

        if (this.isLeftLoaded) {
            //console.log("play start frame ", this.currFrame);
            if (this.isPlaying) {
                this._pause();
                this.show_play();
            }
            else if (this.isPausedManually) {
                this.continue_play();
                this.show_pause();
            }
            else {
                if (this.is_end_frame(this.currFrame)) {
                    this.play_fs(this.nextFrameSet);
                }
                else {
                    if (this.isRewinded) {
                        this.play_fs(this.currFrameSet);
                    }
                    else
                        this.play_fs(this.nextFrameSet);
                }
                this.show_pause();
            }

            this.isRewinded = false;
        }
    },

    go_to_fs: function(i) {
        this.isRewinded = false;
        this.swap_indicators(this.currFrameSet, i);
        var o = this._play_fs(i);
        this.show_curr_errors();
       // this.leftVideo.play_video(o.to, o.to);
       // this.rightVideo.play_video(o.to2, o.to2);
    },

    play_fs: function(i) {
        var j = this.currFrameSet;
        var self = this;

        this.clear_err_text();
        this.clear_indicator(j);

        if (!this.isRewinded && this.nextFrameSet == this.totalFrameSet) {
            this.currFrameSet = 0;
            this.currFrame = 1;
        } else {
            this.currFrameSet = i;
        }

        /*really this closure is  not necc but let's do it for now. */
        var k = this.currFrameSet;
        this.cb_show_indicator = function() {
            self.show_indicator(k);
            self.show_curr_errors();
        };

        this.show_pause();
        var o = this._play_fs(this.currFrameSet);
        this.isPlayingFrameSet = true;

        //console.log("currFrame:", this.currFrame, o.to);

        //this.leftVideo.play_video(this.currFrame, o.to);
        //this.rightVideo.play_video(this.currFrame, o.to2);
        //this.leftVideo.play_video(this.currFrame, o.to);
        this.leftVideo.play_video(o.from, o.to);
        this.rightVideo.play_video(o.from2, o.to2);
        ////console.log("asycn?");
    },

    _play_fs: function(i) {
        ////console.log("setting currFrameSet:",i);
        this.currFrameSet = i;
        this.nextFrameSet = i + 1;

        var fs = this.get_frame_set_left(this.currFrameSet);
        var from = fs.beginFrame;
        var to = fs.endFrame;

        var fs2 = this.get_frame_set_right(this.currFrameSet);
        var from2 = fs2.beginFrame;
        var to2 = fs2.endFrame;

        this.isPausedManually = false;
        this.isPlaying = true;
        //this.show_errors(fs2);
        return { to: to, to2: to2, from: from, from2: from2 };
    },

    show_errors: function(fs2) {

        $("square").empty();
        var err_cb = function(err, i) {
        var divErr = new Element("div");
        
            divErr.set("html", err);
            divErr.injectInside($("square"));
        };

        fs2.errors.each(err_cb);
        err_cb = null;
    },

    show_curr_errors: function() {
        var fs2 = this.get_frame_set_right(this.currFrameSet);
        this.show_errors(fs2);
    },

    _pause: function() {
        this.isPausedManually = true;
        this.isPlaying = false;
        this.leftVideo.pause_video();
        this.rightVideo.pause_video();
    },

    continue_play: function() {
        this.leftVideo.continue_play();
        this.rightVideo.continue_play();
        this.isPausedManually = false;
        this.isPlaying = true;
    },

    clear_indicator: function(i) {
        var j = i + 1;
        //$$("img.btnVideoNo")[i].set("style", "border-color:#1e5974");
        $$("img.btnVideoNo")[i].set("src", "../Images/" + j + ".png");
    },

    show_indicator: function(i) {
        var j = i + 1;
        //$$("img.btnVideoNo")[i].set("style", "border-color:#dd0000");
        $$("img.btnVideoNo")[i].set("src", "../Images/over" + j + ".png");
    },

    stop: function() {
        this.leftVideo.stop_video();
        this.rightVideo.stop_video();

        //this.go_to_fs(0);

        this.swap_indicators(this.currFrameSet, 0);
        var o = this._play_fs(0);
        this.show_curr_errors();
        this.show_play();

        this.currFrame = 1;
        this.currFrameSet = 0;
        this.nextFrameSet = 1;
        this.isPausedManually = false;
        this.isPlaying = false;
        this.isRewinded = false;
        this.isPlayingCont = false;
    },

    rewind: function(e) {
        if (!this.isPlaying && this.currFrame > 1) {
            this._base_wind(-1);
            this.isRewinded = true;
            this.leftVideo.prev_frame();
            this.rightVideo.prev_frame();
        }
        else {
            //console.warn("caught runaway frame; isPLaying", this.isPlaying,this.currFrame,this.currFrameSet);
        }
    },

    forwind: function(e) {
        if (!this.isPlaying && this.currFrame < this.totalFrames) {
            this._base_wind(1);
            this.isRewinded = false;
            this.leftVideo.next_frame();
            this.rightVideo.next_frame();
        }
        else {
            //console.warn("caught runaway frame; isPLaying", this.isPlaying,this.currFrame,this.currFrameSet);
        }
    },

    pause: function() {

    },

    _base_wind: function(df) {

        this.isPlaying = true;
        var fs = this.get_frameset_from_frame_wind(this.currFrame + df);
        ////console.log(this.currFrame+df, "/",fs);
        ////console.log("inside:", fsInside);
        ////console.log("currFrameSet:", this.currFrameSet);
        var j = this.currFrame + df;
        if (this.endFrames[j] != null) {
            this.show_indicator(this.endFrames[j]);
            this.currFrameSet = fs;
            this.nextFrameSet = this.currFrameSet + 1;
            var fs2 = this.get_frame_set_right(this.currFrameSet);
            this.show_errors(fs2);
        }
        else {
            this.clear_indicator(this.currFrameSet);
            this.clear_err_text();
        }

        /*
        if(fs !=this.currFrameSet){
        //this.swap_indicators(this.currFrameSet, fs);
        this.currFrameSet = fs;
        this.nextFrameSet = this.currFrameSet+1;
        var fs2 = this.get_frame_set_right(this.currFrameSet );
        this.show_errors(fs2);
        }
        */

    },

    get_frame_set_left: function(i) {
        return this.leftInfo.clips[i];
    },

    get_frame_set_right: function(i) {
        return this.rightInfo.clips[i];
    },

    fs_end: function(f) {
        this.reset();
        //console.log("fs_end", f);
        this.currFrame = f;
    },

    video_end: function() {
        //console.log("video end");
        //this.currFrameSet = 0;
        //this.reset();
    },

    onPlayContEnd: function() {
        //console.log("onPlayContEnd");
        this.isPlayingCont = false;
        this.isPlaying = false;
        this.currFrame = 1;
        //console.log("currFrame", this.currFrame);
        this.currFrameSet = 0;
        this.nextFrameSet = 1;
    },

    reset: function() {
        if (this.isPlayingFrameSet) {
            this.cb_show_indicator();
            this.cb_show_indicator = function() { };
            this.isPlayingFrameSet = false;
        }
        this.isPausedManually = false;
        this.isPlaying = false;
        this.show_play();
    },

    show_play: function() {
        $("btnPlay").setProperty("src", "../Images/play.png");
    },

    show_pause: function() {
        $("btnPlay").setProperty("src", "../Images/pause.jpg")
    },

    clear_err_text: function() {
        $("square").empty();
    },

    get_frameset_from_frame: function(f) {
        var arr = this.leftInfo.clips;
        var i;
        var n = arr.length;
        var fs = 0;
        for (i = 0; i < n; ++i) {
            var obj = arr[i];
            if (obj.beginFrame <= f && f <= obj.endFrame) {
                fs = i;
                break;
            }
        }

        return fs;
    },

    get_frameset_from_frame_wind: function(f) {
        var arr = this.leftInfo.clips;
        var i;
        var n = arr.length;
        var fs = this.currFrameSet;
        for (i = 0; i < n; ++i) {
            var obj = arr[i];
            if (f == obj.endFrame) {
                fs = i;
                break;
            }
        }

        return fs;
    },

    cache_end_frames: function() {

        var arr = this.leftInfo.clips;
        var n = arr.length;
        this.endFrames = {};
        var i;
        for (i = 0; i < n; ++i) {
            this.endFrames[arr[i].endFrame] = i;
        }
    },

    swap_indicators: function(i, j) {
        this.clear_indicator(i);
        this.show_indicator(j);
    },

    load_video_left: function(p) {
        leftMoviePath = p;
    },

    load_video_right: function(p) {
        rightMoviePath = p;
    },

    is_end_frame: function(p) {
        if (this.endFrames[p] != null) {
            return true;
        }
        return false;
    }
    //},

    /*
    playflash: function() {

        if (navigator.appName.indexOf("Microsoft Internet") == -1)
        {
            if (document.embeds && document.embeds["WMP1"])
            {
                document.embeds["WMP1"].Play();
            }
        }
        else
        {
            document.getElementById("WMP1").Play();
        }
    },

    pauseflash: function() {

        if (navigator.appName.indexOf("Microsoft Internet") == -1)
        {
            if (document.embeds && document.embeds["WMP1"])
            {
                document.embeds["WMP1"].StopPlay();
            }
        }
        else
        {
            document.getElementById("WMP1").StopPlay();
        }
    },

    stopflash: function() {

        if (navigator.appName.indexOf("Microsoft Internet") == -1)
        {
            if (document.embeds && document.embeds["WMP1"])
            {
                document.embeds["WMP1"].StopPlay();
                document.embeds["WMP1"].Rewind();
            }
        }
        else
        {
            document.getElementById("WMP1").StopPlay();
            document.getElementById("WMP1").Rewind();
        }
    }
    */
});

window.addEvent('domready', function() {  
		__H = new com.acap.VideoPlayer();
} );

com.acap.VideoPlayer.loaded_leftVideo = function(){
	__H.isLeftLoaded = true;
	__H.go_to_fs(0);
};

com.acap.VideoPlayer.loaded_rightVideo = function(){
	__H.isRightLoaded = true;
};

