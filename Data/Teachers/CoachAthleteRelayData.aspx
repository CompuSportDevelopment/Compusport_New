<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="CoachAthleteRelayData.aspx.cs" Inherits="Teachers_CoachAthleteRelayData" %>

<%@ Register Src="~/Controls/TeachersMenu.ascx" TagName="TeachersMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
    
    <link type="text/css" rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
<script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>


 <script type="text/javascript" >
     function ValidateDemo() {
         var result = document.getElementById('<%=DropDownList1.ClientID%>').value;
         if (result == "0") {
             alert("Please Select Relay");
             document.getElementById('<%=DropDownList1.ClientID%>').focus();
             return false;
         }
         else
          {
             return true;
         }
     }
     function Validation() {
         if (document.getElementById('<%=txtrmv.ClientID %>').value == "") {
             alert("Please Enter the Value in the field");
             return false;
         }
         if (document.getElementById('<%=txtrmv1.ClientID %>').value == "") {
             alert("Please Enter the Value in the field");
             return false;
         }
         if (document.getElementById('<%=txtrzv.ClientID %>').value == "") {
             alert("Please Enter the Value in the field");
             return false;
         }
         if (document.getElementById('<%=txtrzv1.ClientID %>').value == "") {
             alert("Please Enter the Value in the field");
             return false;
         }
         if (document.getElementById('<%=txtrst.ClientID %>').value == "") {
             alert("Please Enter the Value in the field");
             return false;
         }
         if (document.getElementById('<%=txtrst1.ClientID %>').value == "") {
             alert("Please Enter the Value in the field");
             return false;
         }
     }
     function demo() {
         if (/^[0-9]*(\.[0-9]{2,2})?$/) {
             if (document.getElementById('<%=txtrmv.ClientID %>').value <= 14.0 && document.getElementById('<%=txtrmv.ClientID %>').value >= 6.0) {
                 return true;
             }
         }
         alert('Enter value between 6.0 to 14.0 range.');
         document.getElementById('<%=txtrmv.ClientID %>').value = '';
         
         return false;

     }
     function demo1() {
         if (/^[0-9]*(\.[0-9]{2,2})?$/) {
             if (document.getElementById('<%=txtrmv1.ClientID%>').value <= 14.0 && document.getElementById('<%=txtrmv1.ClientID %>').value >= 6.0) {
                 return true;
             }
         }
         alert('Enter value between 6.0 to 14.0 range.');
         document.getElementById('<%=txtrmv1.ClientID %>').value = '';

         return false;
         
     }
     function demo2() {
         if (/^[0-9]*(\.[0-9]{2,2})?$/) {

             if (document.getElementById('<%=txtrzv.ClientID %>').value <= 14.0 && document.getElementById('<%=txtrzv.ClientID %>').value >= 5.0) {
                 return true;
             }
         }
         alert('Enter value between 5.0 to 14.0 range.');
         document.getElementById('<%=txtrzv.ClientID %>').value = '';
         return false;
     }
     function demo3() {
         if (/^[0-9]*(\.[0-9]{2,2})?$/) {

             if (document.getElementById('<%=txtrzv1.ClientID %>').value <= 14.0 && document.getElementById('<%=txtrzv1.ClientID %>').value >= 5.0) {
                 return true;
             }
         }
         alert('Enter value between 5.0 to 14.0 range.');
         document.getElementById('<%=txtrzv1.ClientID %>').value = '';
         return false;
     }
     function demo4() {
         if (/^[0-9]*(\.[0-9]{2,2})?$/) {

             if (document.getElementById('<%=txtrst.ClientID %>').value <= 4.0 && document.getElementById('<%=txtrst.ClientID %>').value >= 2.0) {
                 return true;
             }
         }
         alert('Enter value between 2.0 to 4.0 range.');
         document.getElementById('<%=txtrst.ClientID %>').value = '';
         return false;
     }
     function demo5() {
         if (/^[0-9]*(\.[0-9]{2,2})?$/) {

             if (document.getElementById('<%=txtrst1.ClientID %>').value <= 4.0 && document.getElementById('<%=txtrst1.ClientID %>').value >= 2.0) {
                 return true;
             }
         }
         alert('Enter value between 2.0 to 4.0 range.');
         document.getElementById('<%=txtrst1.ClientID %>').value = '';
         return false;
     }

     function NameValidate() {
        
         var textBox = document.getElementById('<%=txtname.ClientID %>');
         var textLength = textBox.value.length;

             if (textLength >= 3 && textLength <= 40) {
                 return true;
             }
             else {
                 alert('Enter Character Between 3 to 40 Range');
                 return false;
             }
         }
       
       
         $(function() {
         $("#overview").click(function() {
         $("#overviewdiv").load('../VariablePages/TheRelayOverview.aspx');
                 //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                 $("#overviewdiv").dialog({
                     width: 830,
                     height: 600,
                     resizable: false,
                     modal: true
                 });
                 return false;
             });
         })

         $(function() {
             $('#<%=Label1.ClientID%>').click(function() {
                 $("#relaydiv").load('../VariablePages/TheRelay.aspx');
                 //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                 $("#relaydiv").dialog({
                     width: 820,
                     height: 230,
                     resizable: false,
                     modal: true
                  });
                 return false;
             });
         })

             $(function() {
                 $('#<%=Label2.ClientID%>').click(function() {
                 $("#passcompletdiv").load('../VariablePages/ThePassCompletionPosition.aspx');
                     //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                 $("#passcompletdiv").dialog({
                         width: 840,
                         height: 360,
                         resizable: false,
                         modal: true
                     });
                     return false;
                 });
             })

             $(function() {
                 $('#<%=Label3.ClientID%>').click(function() {
                     $("#passtimediv").load('../VariablePages/ThePassTimeQuality.aspx');
                     //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                     $("#passtimediv").dialog({
                         width: 820,
                         height: 340,
                         resizable: false,
                         modal: true
                      });
                     return false;
                 });
             })
             
             $(function() {
             $('#<%=rmvlabel.ClientID%>').click(function() {
             $("#rmvdiv").load('../VariablePages/TheRelayMaximumVelocity.aspx');
                     //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                     $("#rmvdiv").dialog({
                         width: 830,
                         height: 600,
                         resizable: false,
                         modal: true
                     });
                     return false;
                 });
             })

             $(function() {
                 $('#<%=rzvlabel.ClientID%>').click(function() {
                 $("#rzvdiv").load('../VariablePages/TheRelayZoneVelocity.aspx');
                     //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                     $("#rzvdiv").dialog({
                         width: 830,
                         height: 600,
                         resizable: false,
                         modal: true
                     });
                     return false;
                 });
             })

             $(function() {
                 $('#<%=rsvlabel.ClientID%>').click(function() {
                 $("#rsvdiv").load('../VariablePages/TheRelayStartVelocity.aspx');
                     //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                     $("#rsvdiv").dialog({
                         width: 830,
                         height: 600,
                         resizable: false,
                         modal: true
                     });
                     return false;
                 });
             })

             $(function() {
                 $('#<%=passlabel.ClientID%>').click(function() {
                 $("#passdiv").load('../VariablePages/ThePassCompletionPosition.aspx');
                     //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                     $("#passdiv").dialog({
                         width: 830,
                         height: 360,
                         resizable: false,
                         modal: true
                     });
                     return false;
                 });
             })

             $(function() {
                 $('#<%=passtimelabel.ClientID%>').click(function() {
                 $("#passtimediv").load('../VariablePages/ThePassTimeQuality.aspx');
                     //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                     $("#passtimediv").dialog({
                         width: 830,
                         height: 340,
                         resizable: false,
                         modal: true
                     });
                     return false;
                 });
             })

             $(function() {
                 $('#<%=rmv1label.ClientID%>').click(function() {
                 $("#rmv1div").load('../VariablePages/TheRelayMaximumVelocity.aspx');
                     //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                     $("#rmv1div").dialog({
                         width: 830,
                         height: 600,
                         resizable: false,
                         modal: true
                     });
                     return false;
                 });
             })


             $(function() {
                 $('#<%=rzv1label.ClientID%>').click(function() {
                 $("#rzv1div").load('../VariablePages/TheRelayZoneVelocity.aspx');
                     //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                     $("#rzv1div").dialog({
                         width: 830,
                         height: 600,
                         resizable: false,
                         modal: true
                     });
                     return false;
                 });
             })

             $(function() {
                 $('#<%=rsv1label.ClientID%>').click(function() {
                 $("#rsv1div").load('../VariablePages/TheRelayStartVelocity.aspx');
                     //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                     $("#rsv1div").dialog({
                         width: 830,
                         height: 600,
                         resizable: false,
                         modal: true
                     });
                     return false;
                 });
             })

             $(function() {
                 $('#<%=incominglabel.ClientID%>').click(function() {
                 $("#incomingdiv").load('../VariablePages/TheIncoming.aspx');
                     //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                     $("#incomingdiv").dialog({
                         width: 830,
                         height: 180,
                         resizable: false,
                         modal: true
                     });
                     return false;
                 });
             })

             $(function() {
                 $('#<%=outgoinglabel.ClientID%>').click(function() {
                 $("#outgoingdiv").load('../VariablePages/TheOutgoing.aspx');
                     //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                     $("#outgoingdiv").dialog({
                         width: 830,
                         height: 180,
                         resizable: false,
                         modal: true
                     });
                     return false;
                 });
             })

             $(function() {
                 $('#<%=golinelabel.ClientID%>').click(function() {
                 $("#golinediv").load('../VariablePages/TheGoLine.aspx');
                     //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                     $("#golinediv").dialog({
                         width: 830,
                         height: 600,
                         resizable: false,
                         modal: true
                     });
                     return false;
                 });
             })


             $(function() {
                 $('#<%=incoming1label.ClientID%>').click(function() {
                 $("#incoming1div").load('../VariablePages/TheIncoming.aspx');
                     //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                     $("#incoming1div").dialog({
                         width: 830,
                         height: 180,
                         resizable: false,
                         modal: true
                     });
                     return false;
                 });
             })


             $(function() {
                 $('#<%=outgoing1label.ClientID%>').click(function() {
                 $("#outgoing1div").load('../VariablePages/TheOutgoing.aspx');
                     //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                     $("#outgoing1div").dialog({
                         width: 830,
                         height: 180,
                         resizable: false,
                         modal: true
                     });
                     return false;
                 });
             })
             $(function() {
                 $('#<%=potentiallabel.ClientID%>').click(function() {
                 $("#potentialdiv").load('../VariablePages/ThePotentialTime.aspx');
                     //$("#relaydiv").dialog().siblings('.ui-dialog-titlebar').remove();
                     $("#potentialdiv").dialog({
                         width: 830,
                         height: 205,
                         resizable: false,
                         modal: true
                     });
                     return false;
                 });
             })


      </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
   <div class="submenu">
        <uc1:TeachersMenu ID="TeachersMenu1" runat="server" />
    </div>
    
     <%--<div id="divLoading" style="position: fixed; right: 0px; top: 0%; z-index: 9999;
             margin-right: 0px; display: block;">
            <img id="show" src="../Images/loading.gif" alt="" height="80" width="80" /> 
       </div>
        <div id="divLoadingMask" class="maskdiv">
        </div>--%>

          <div id="divloading" style="position: fixed; right: 0px; top: 0%; z-index: 9999;
                margin-right: 0px; display: none;">
                    <img id="show" src="../Images/loading.gif" alt="" height="80" width="80" />
         </div>
       <div id="divLoadingMask" class="maskdiv" style="display:none;">
        </div>
       
        <asp:UpdateProgress ID="Updat_Paymentxyz" runat="server" DisplayAfter="1">
            <ProgressTemplate>
              <div class="maskdiv" style="display:none;">
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
                                
    <p class="pagetitle">
        Go Line Calculation For the Relay Exchange
    </p>
    <div id="centeronpage" class="centeronpage">
        <p style="text-align: justify; width: 800px;">
            To determine the Go Line, select the Race, Pass Completion Position, Pass Quality, then enter the athlete's Names and Relay Performance Data.
            Once this is done, left click the "Submit" button and the Go-Line Distance for the both Athletes will be generated. In
            addition, a best case time prediction will be made for the Exchange Zone times. assuming each athlete achieves their
            Performance Potential as well as executing perfect passes. Left click on any of the Input Variables for an explanation of the selected variable.  
           </p>
           <div id="overviewdiv"></div>
           <div >
          <p style="text-align: justify; width: 800px;">
          This page is designed to generate the Go Line distance for two athletes in the 4x100 Relay. For an overview of the concept of this calculation, the input variables required, and how to collect them, left click <a style="cursor:pointer;"><font color="red"><u id="overview">here</u></font></a>.
          </p>
          </div>
            <p style="text-align: justify; width: 800px;">
          For information on any of the individual Relay Variables utilized on this page, simply left click on the Variable of interest.
          </p>
          
        <table cellpadding="2" cellspacing="2" border="0" width="100%" >
           <%--<tr>
                <td style="width: 21px">
                </td>
             <div id="relaydiv">
                <td  align="left" style="width: 365px">
                    <asp:Label ID="Label1" runat="server" Text="Relay" Font-Bold="True" Width="63px" style="cursor:pointer;" 
                    onclick="myFunction('../VariablePages/TheRelay.aspx')"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                        AutoPostBack="true">
                        <asp:ListItem Text="Select a Relay" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Men’s 4x100 Relay" Value="male"></asp:ListItem>
                        <asp:ListItem Text="Women’s 4x100 Relay" Value="female"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                </div>
            </tr>--%>
            <tr>
                <td style="width: 21px">
                </td>
             <div id="relaydiv">
                <td  align="left" style="width: 365px">
                    <asp:Label ID="Label1" runat="server" Text="Relay" Font-Bold="True" Width="63px" style="cursor:pointer;"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                        AutoPostBack="true">
                        <asp:ListItem Text="Select a Relay" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Men’s 4x100 Relay" Value="male"></asp:ListItem>
                        <asp:ListItem Text="Women’s 4x100 Relay" Value="female"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                </div>
            </tr>
            <tr>
                <td colspan="" align="left" style="width: 21px">
                </td>
                <div id="passcompletdiv">
                <td align="left" style="width: 365px">
                 <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                   <asp:Label ID="Label2" runat="server" Text="Pass Completion Position" Font-Bold="True" style="cursor:pointer;"></asp:Label>
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="150px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                        Style="margin-left: 20px" AutoPostBack="True">
                        <asp:ListItem Text="1 meters" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 meters" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 meters" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 meters" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 meters" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6 meters" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7 meters" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8 meters" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9 meters" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10 meters" Value="10" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="11 meters" Value="11"></asp:ListItem>
                        <asp:ListItem Text="12 meters" Value="12"></asp:ListItem>
                        <asp:ListItem Text="13 meters" Value="13"></asp:ListItem>
                        <asp:ListItem Text="14 meters" Value="14"></asp:ListItem>
                        <asp:ListItem Text="15 meters" Value="15"></asp:ListItem>
                        <asp:ListItem Text="16 meters" Value="16"></asp:ListItem>
                        <asp:ListItem Text="17 meters" Value="17"></asp:ListItem>
                        <asp:ListItem Text="18 meters" Value="18"></asp:ListItem>
                        <asp:ListItem Text="19 meters" Value="19"></asp:ListItem>
                        <asp:ListItem Text="20 meters" Value="20"></asp:ListItem>
                    </asp:DropDownList>
                     </ContentTemplate>
                       
                    </asp:UpdatePanel>
                </td>
                </div>
            </tr>
            <tr>
                <td colspan="" align="left" style="width: 21px; height: 21px;">
                </td>
                <div id="passtimediv">
                <td align="left" style="height: 21px; width: 365px;">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                    <asp:Label ID="Label3" runat="server" Text="Pass Time Quality" Font-Bold="True" style="cursor:pointer;"></asp:Label>
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="150px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"
                        Style="margin-left: 17px" AutoPostBack="True">
                        <asp:ListItem Text="0.4 seconds" Value="0.4" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="0.5 seconds" Value="0.5"></asp:ListItem>
                        <asp:ListItem Text="0.6 seconds" Value="0.6"></asp:ListItem>
                        <asp:ListItem Text="0.7 seconds" Value="0.7"></asp:ListItem>
                        <asp:ListItem Text="0.8 seconds" Value="0.8"></asp:ListItem>
                        <asp:ListItem Text="0.9 seconds" Value="0.9"></asp:ListItem>
                        <asp:ListItem Text="1.0 seconds" Value="1.0"></asp:ListItem>
                    </asp:DropDownList>
                     </ContentTemplate>
                       
                    </asp:UpdatePanel>
                    <br />
                    <br />
                </td>
                </div>
            </tr>
           
               
                </table>
               <%-- <div style="text-align: left; margin-left: 410px;">
                    <br />
                    <asp:Button ID="Button1" runat="server" OnClick="buttonSubmit_Click" Text="Submit"
                        OnClientClick="ValidateDemo();return ValidationDemo1();" />
                </div>--%>
                <br />
                <br />
                                 
                 <table border="1" align="center" frame="border" style="border-style:none;border-width:inherit;
                  border-color: #000000">
            
            <tr>    
                <th style="border-style:none;"></th>
                   
                <th style="background-color: #aad18e; width: 130px; border-style: groove;border-width:inherit;
                    border-color: #000000">
                    Name
                </th>
                
                <div id="rmvdiv"> 
                <th style="background-color: #607397; line-height: 30px; width: 130px;border-style: groove;
                    border-width: inherit; border-color: #000000;">
                    <asp:label ID="rmvlabel" runat="server" Text="RMV (m/s)" style="cursor:pointer"></asp:label>
                </th>
                </div>
               
               <div id="rzvdiv">
                <th style="background-color: #607397; line-height: 30px; width: 130px;border-style: groove;
                    border-width: inherit; border-color: #000000;">
                   <asp:label ID="rzvlabel" runat="server" Text="RZV (m/s)" style="cursor:pointer"></asp:label>
                </th>
                </div>
             
                <div id="rsvdiv">
                <th style="background-color: #607397; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000;">
                    <asp:label ID="rsvlabel" runat="server" Text="RST (s)" style="cursor:pointer"></asp:label>
                </th>
                </div>
               </tr>  
          
               <tr>
                <td>
                <asp:Label ID="lblone" runat="server">Athlete One</asp:Label>  
                </td>
                <td>
                    <asp:TextBox ID="txtname" runat="server" onblur="NameValidate();"></asp:TextBox>
                </td>                
                <td>
                <asp:TextBox ID="txtrmv" runat="server" onblur="demo();"></asp:TextBox>
                </td>
                <td>
                <asp:TextBox ID="txtrzv" runat="server" onblur="demo2();"></asp:TextBox>
                </td>
                <td>
                <asp:TextBox ID="txtrst" runat="server" onblur="demo4();"></asp:TextBox>
                </td>               
            </tr>     
                      
             <tr>              
                <td> <asp:Label ID="Label4" runat="server">Athlete Two</asp:Label>   </td>
                <td>
                <asp:TextBox ID="txtname1" runat="server" onblur="NameValidate();"></asp:TextBox>
                    
                </td>                
                <td>
                <asp:TextBox ID="txtrmv1" runat="server" onblur="demo1();"></asp:TextBox>
                   
                </td>
                <td>
                <asp:TextBox ID="txtrzv1" runat="server" onblur="demo3();"></asp:TextBox>
                    
                </td>
                <td>
                <asp:TextBox ID="txtrst1" runat="server" onblur="demo5();"></asp:TextBox>
                    
                </td>
               
            </tr>     
                        
            </table>
            
                    
                <div style="text-align: left; margin-left: 410px;">
                    <br />
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" onclick="btnsubmit_Click"
                    OnClientClick="ValidateDemo(); Validation();"
                        />
                </div>
                <br />
                <br />
                
                <div>
                    <h2>
                        <b>Relay Result</b></h2>
                    <table border="1" align="left" frame="border" style="border-style: groove;margin-left:50px; border-width: inherit;
                        border-color: #000000">
                        <tr>
                            
                            <div id="passdiv">
                            <td style="background-color: #dfa37e; width: 250px; border-style: groove; border-width: inherit;
                                border-color: #000000;">
                                <asp:Label ID="passlabel" runat="server" Text="Pass Completion Position(Meters)" style="cursor:pointer"></asp:Label>
                            </td>
                            </div>
                            <td style="background-color: #aad18e; width: 50px; border-style: groove; border-width: inherit;
                                border-color: #000000"
                                <%=ViewState["dd1PassComplete"].ToString()%>
                            </td>
                                                        
            </tr>
            <tr>
                <div id="passtimediv">
                <td style="background-color: #dfa37e; width: 200px; border-style: groove; border-width: inherit;
                    border-color: #000000;">
                   <asp:label ID="passtimelabel" runat="server" Text="Pass Time Quality(Seconds)" style="cursor:pointer"></asp:label>
                </td>
                </div>
                <td style="background-color: #aad18e; width: 50px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                    <%=ViewState["ddlPassTime"].ToString()%>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
    </div>
    
    <div>
        <h2>
            <b>Athlete Relay Variables</b></h2>
        <table border="1" align="center" frame="border" style="border-style: groove; border-width: inherit;
            border-color: #000000">
            <tr>
                
                <th style="background-color: #aad18e; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                    Name
                </th>
                
                <div id="rmv1div">
                <th style="background-color: #607397; line-height: 30px; width: 130px; border-style: groove;
                    border-width: inherit; border-color: #000000;">
                   <asp:Label ID="rmv1label" runat="server" Text="RMV (m/s)" style="cursor:pointer"></asp:Label>
                </th>
                </div>
                
                <div id="rzv1div">
                <th style="background-color: #607397; line-height: 30px; width: 130px; border-style: groove;
                    border-width: inherit; border-color: #000000;">
                  <asp:label ID="rzv1label" runat="server" Text="RZV (m/s)" style="cursor:pointer"></asp:label>
                </th>
                </div>
                
                <div id="rsv1div">
                <th style="background-color: #607397; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000;">
                   <asp:Label ID="rsv1label" runat="server" Text="RST (s)" style="cursor:pointer"></asp:Label>
                </th>
                </div>
                
            </tr>
            <tr>
                               
                <td style="background-color: #ebf8e3; width: 130px; height:28px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                    <%=ViewState["dd1Name1"].ToString()%>
                </td>                
                <td style="background-color: #e6edff; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                    <%=ViewState["dd2Name1"].ToString()%>
                </td>
                <td style="background-color: #e6edff; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                     <%=ViewState["dd3Name1"].ToString()%>
                </td>
                <td style="background-color: #dee5f7; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                     <%=ViewState["dd4Name1"].ToString()%>
                </td>
            </tr>
            <tr>
                <td style="background-color: #c6e0b1; width: 130px;height:28px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                     <%=ViewState["dd1Name2"].ToString()%>
                </td>
                <td style="background-color: #b3c6e8; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                     <%=ViewState["dd2Name2"].ToString()%>
                </td>
                <td style="background-color: #b9c8ee; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                     <%=ViewState["dd3Name2"].ToString()%>
                </td>
                <td style="background-color: #b9c8ee; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                     <%=ViewState["dd4Name2"].ToString()%>
                </td>
               
            </tr>
           
        </table>
    </div>
    <div>
        <h2>
            <b>Go Line Distances</b></h2>
        <table border="1" align="center" frame="border" style="border-style: groove; border-width: inherit;
            border-color: #000000">
            <tr>
            
                <div id="incomingdiv">
                <th style="background-color: #aad18e; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000;">
                   <asp:label ID="incominglabel" runat="server" Text="Incoming" style="cursor:pointer"></asp:label>
                </th>
                </div>
                
                <div id="outgoingdiv">
                <th style="background-color: #aad18e; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000;">
                   <asp:label ID="outgoinglabel" runat="server" text="Outgoing" style="cursor:pointer"></asp:label>
                    </th>
                </div>
                
                <div id="golinediv">
                <th style="background-color: #607397; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000;">
                   <asp:Label ID="golinelabel" runat="server" text="Go Line(m)" style="cursor:pointer"></asp:Label>
                </th>
                </div>
                
            </tr>
            <tr>
                <td style="background-color: #ebf8e3; width: 130px;height:28px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                     <%=ViewState["dd1Name1"].ToString()%>
                </td>
                <td style="background-color: #ebf8e3; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                    <%=ViewState["dd1Name2"].ToString()%>
                </td>
                <td style="background-color: #e6edff; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                    <%=ViewState["Final1"].ToString()%>
                </td>
            </tr>
            <tr>
               
                <td style="background-color: #aad18e; width: 130px; height:28px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                     <%=ViewState["dd1Name2"].ToString()%>
                </td>
                <td style="background-color: #aad18e; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                    <%=ViewState["dd1Name1"].ToString()%>
                </td>
                <td style="background-color: #b9c8ee; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                    <%=ViewState["Final2"].ToString()%>
                </td>
            </tr>
           
        </table>
    </div>
    <div>
        <h2>
            <b>Potential Time</b></h2>
        <table border="1" align="center" frame="border" style="border-style: groove; border-width: inherit;
            border-color: #000000">
             <tr>
              
                <div id="incoming1div">
                <th style="background-color: #aad18e; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000;">
                   <asp:Label ID="incoming1label" runat="server" text="Incoming" style="cursor:pointer"></asp:Label>
                </th>
                </div>
                
                <div id="outgoing1div">
                <th style="background-color: #aad18e; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000;">
                   <asp:Label ID="outgoing1label" runat="server" text="Outgoing" style="cursor:pointer"></asp:Label>
                </th>
                </div>
                
                <div id="potentialdiv">
                <th style="background-color: #607397; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000;">
                   <asp:Label ID="potentiallabel" runat="server" text="Potential Time(s)" style="cursor:pointer"></asp:Label>
                </th>
                </div>
            </tr>
            <tr>
                
                <td style="background-color: #ebf8e3; width: 130px;height:28px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                    <%=ViewState["dd1Name1"].ToString()%>
                </td>
                <td style="background-color: #ebf8e3; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                    <%=ViewState["dd1Name2"].ToString()%>
                </td>
                <td style="background-color: #e6edff; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                     <%=ViewState["ThirdTableResult2"].ToString()%>
                </td>
            </tr>
            <tr>
               
                <td style="background-color: #aad18e; width: 130px; height:28px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                    <%=ViewState["dd1Name2"].ToString()%>
                </td>
                <td style="background-color: #aad18e; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                    <%=ViewState["dd1Name1"].ToString()%>
                </td>
                <td style="background-color: #b9c8ee; width: 130px; border-style: groove; border-width: inherit;
                    border-color: #000000">
                    <%=ViewState["ThirdTableResult4"].ToString()%>
                </td>
            </tr>
        </table>
    </div>
   </div>
</asp:Content>


