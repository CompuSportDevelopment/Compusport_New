/////////////////////////////////////////////////
//Some useful functions//
/////////////////////////////////////////////////
function sleep(milliseconds)
{
  var start = new Date().getTime();
  for (var i = 0; i < 1e7; i++)
  {
    if ((new Date().getTime() - start) > milliseconds)
    {
      break;
    }
  }
}

function fire_it(request,sender,sendResponse)
{
      //var number_of_messages = document.getElementsByClassName("boldIfNew").length;
      if (number_of_messages != 0)
      {
	  //chrome.extension.sendRequest({}, function(response) {});
	  for (var i = 0; i< number_of_messages; i++)
	  {
	      var evt = document.createEvent("MouseEvents");
	      evt.initMouseEvent("click", true, true, window,
		       0, 0, 0, 0, 0, false, false, false, false, 0, null);
	      if (InboxOrOutbox == "Inbox")
	      {
		  var cb = document.getElementsByClassName("boldIfNew")[i];
	      }
	      else
	      {
		  var cb = document.getElementsByClassName("readMsgLink")[i];
	      }
              if (cb.title == "lesen")
              {
		  var canceled = !cb.dispatchEvent(evt);
              }
	  }
      }
}

function getNumberOfPages()
{
  var pageLinks = document.getElementsByClassName("pager");
  var lastPageLink=pageLinks[pageLinks.length-1].href;
  if (!lastPageLink)
  {
      page = Number(pageLinks[pageLinks.length-1].innerHTML);
  }
  else
  {
	var linkSplit = lastPageLink.split("/");
	var page=Number(linkSplit[linkSplit.length-1]);
  }
  return page;
}

/////////////////////////////////////////////////
//Begin our script
/////////////////////////////////////////////////


//First of all, we need our link in the left navigation bar to point to
//http://www.studivz.net/Messages/Inbox/p/1,
//otherwise our Algorithm to collect all messages will fail.
//Begin changing the link
document.getElementsByClassName("Navi-Messages-Link")[0].href="http://www.studivz.net/Messages/Inbox/p/1"; //??? Warum klappt das nicht?
//End changing the link
//Changing Link in Messages

var port = null;
var InboxOrOutbox= "Outbox";
var number_of_messages = document.getElementsByClassName("readMsgLink").length;
if (number_of_messages == 0)
{//Vielleicht sind wir in der Outbox?
    number_of_messages = document.getElementsByClassName("boldIfNew").length;
    InboxOrOutbox = "Inbox";
}//Vielleicht sind wir in der Outbox?
if (number_of_messages != 0)
{
    port = chrome.extension.connect({name:"studiVZND"});
    port.postMessage({respond:"number_of_pages",number:getNumberOfPages()});
    port.onMessage.addListener(function(msg) {
      if (msg.order == "open_all")
      {
	fire_it();
	port.postMessage({respond:"fired"});
      }
      else if (msg.order == "extr_content")
      {
	var messages = document.getElementsByClassName("body_text");
	  if (InboxOrOutbox == "Inbox")
	  {
	      var froms    = document.getElementsByClassName("from-subject clearFix");
	  }
	  else
	  {
	      var froms    = document.getElementsByClassName("clearFix");
	  }
	var response_message = "";
        for (var i = 0; i<messages.length;i++)
        {
	  response_message += froms[i].innerText+"\n"+messages[i].innerText;
	  response_message += "\n===============================================================\n"
        }
	port.postMessage({respond:"sendMessageBody",textbody:response_message});
      }
      else if (msg.order == "is_all_open")
      {
	port.postMessage({respond:String(document.getElementsByClassName("body_text").length)})
      }
    });
}