function getValueByAJAX(ajaxParameter, ajaxFilePath)
    {// use executeAjaxMethod method here
	    var req = null;
	    // branch for native XMLHttpRequest object
	    if(window.XMLHttpRequest && !(window.ActiveXObject)) {
		    try {
			    req = new XMLHttpRequest();
		    } catch(e) {
			    req = null;
		    }
		    // branch for IE/Windows ActiveX version
	    } else if(window.ActiveXObject) {
		    try {
			    req = new ActiveXObject("Msxml2.XMLHTTP");
		    } catch(e) {
			    try {
				    req = new ActiveXObject("Microsoft.XMLHTTP");
			    } catch(e) {
				    req = null;
			    }
		    }
	    }
		
	    if(req)
	    {
	        req.open("POST", ajaxFilePath, false);
	        req.send("AJAX:"+ajaxParameter); 
		    return req.responseText;
	    }

	    return null;
    }