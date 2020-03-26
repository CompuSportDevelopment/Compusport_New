<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RelayAthleteEdit.ascx.cs" Inherits="Controls_RelayAthleteEdit" %>

<script  type="text/javascript">


    function Validation() {
        if (document.getElementById('<%=lblRelayVelocityIn.ClientID %>').value == "") {
            alert("Please Enter the Value in the field");
            return false;}
          if(document.getElementById('<%=lblRelayVelocityOut.ClientID %>').value == "") {
              alert("Please Enter the Value in the field");
            return false;}
            if (document.getElementById('<%=lblRelayStart.ClientID %>').value == "") {
                alert("Please Enter the Value in the field");
                return false;
            }
            if (document.getElementById('<%=lblMeterTime.ClientID %>').value == "") {
                alert("Please Enter the Value in the field");
            return false;
        }
    }
   

function demo()
{
  if (/^[0-9]*(\.[0-9]{2,2})?$/)
  {
   if (document.getElementById('<%=lblRelayVelocityIn.ClientID %>').value <= 14.0 && document.getElementById('<%=lblRelayVelocityIn.ClientID %>').value >= 6.0) 
   {
     return true;
   }
 }
 alert('Enter value between 6.0 to 14.0 range.');
 document.getElementById('<%=lblRelayVelocityIn.ClientID %>').value ='';
 //document.getElementById('<%=lblRelayVelocityIn.ClientID %>').focus();
 
  return false;
  
  }
  function demo1()
  {
  if (/^[0-9]*(\.[0-9]{2,2})?$/) {
     
      if (document.getElementById('<%=lblRelayVelocityOut.ClientID %>').value <= 14.0 && document.getElementById('<%=lblRelayVelocityOut.ClientID %>').value >= 5.0) {
          return true;
      }
  }
  alert('Enter value between 5.0 to 14.0 range.');
  document.getElementById('<%=lblRelayVelocityOut.ClientID %>').value = '';
  return false;
  }

function demo2()
{
  if (/^[0-9]*(\.[0-9]{2,2})?$/) {
      
      if (document.getElementById('<%=lblRelayStart.ClientID %>').value <= 4.0 && document.getElementById('<%=lblRelayStart.ClientID %>').value >= 2.0) {
          return true;
      }
  }
  alert('Enter value between 2.0 to 4.0 range.');
  document.getElementById('<%=lblRelayStart.ClientID %>').value = '';
  return false;
  }
  function demo3(){
      if (/^[0-9]*(\.[0-9]{2,2})?$/) 
  {
      
      if (document.getElementById('<%=lblMeterTime.ClientID %>').value <= 14.0 && document.getElementById('<%=lblMeterTime.ClientID %>').value >= 9.0) {
          return true;
      }
  }
  alert('Enter value between 9.0 to 14.0 range.');
  document.getElementById('<%=lblMeterTime.ClientID %>').value = '';
  return false;
}
function validate1() {
    if(document.getElementById('<%=DropDownList1.ClientID%>').value == "") {
        alert("Please select value"); // prompt user
       // document.getElementById('<%= DropDownList1.ClientID%>').focus(); //set focus back to control
        return false;
    }
}

</script>

<script type="text/javascript">
    function ValidateDropdown() {
        var result = document.getElementById('<%=DropDownList1.ClientID%>').value;
        if (result == "0") {
            alert("Please Select Athlete");
            return false;
        }
        else {
            return true;
        }
    }
</script>


<div style="float: left; padding: 0px; width: 600px; height: 40px; font-size: xx-large;
        text-align: left;font-family: Magneto;">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1">
            <ProgressTemplate>
                <div style="text-align: left; position: absolute; top: 10%; left: 50%; margin-left: -70px;">
                    <img src="../images/big_loading.gif" alt="" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <b>Relay Performance Result</b>
        <br />
        <br />
    </div>



<table cellpadding="2" cellspacing="2" border="0" width="100%">
            <tr>
                <td colspan="3" align="left">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="300px" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                        CausesValidation="True">
                        <asp:ListItem Text="noathlete" Value="0">Select an Athlete</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="DropDownList1_Required" ControlToValidate="DropDownList1" InitialValue="0" runat="server">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
</table>


<table id="table1" border="0px" cellpadding="0px" cellspacing="0px">
    <tr>
        
        <td>
            <div id="div12" style="margin-top: 0px; margin-bottom: 0px;">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <div style="float: left; padding: 0px; width: 600px; height: 30px; text-align: center;">
                            <asp:Label ID="Label117" runat="server" Text="" Width="600px" ForeColor="Red" Font-Size="Large"
                                Font-Bold="True"></asp:Label>
                        </div>
                        
                        
                        
                        <div style="float: left; margin-top: 20px; padding: 0px; width: 600px;">
                        </div>
                       <%-- <div style="float: left; margin-left: 10px; width: 576px; height: 1px; background-color: Black;">
                        </div>--%>
                       
                        <div style="float: left; margin-left: 10px; width: 730px; height: 950px">
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 185px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                            </div>
                            
                            <div style="float: left; width: 345px; height: 26px; padding: 0px;">
                                <div style="background-color: #FFE1AA; width: 350px; height: 26px;">
                                    <b>Variable</b></div>
                                <br />
                                <div style="background-color: #FFE1AA;width: 350px;line-height:30px ">
                                   Relay Maximum Velocity (RMV) - meters/second </div>
                                                                
                                 <div style="background-color: White; width: 295px; height: 30px; height: 4px;">
                                </div>
                                
                                <div style="background-color: #FFB9AF; width: 350px; line-height:30px">
                                   Relay Zone Velocity (RZV) - meters/second</sub>
                                 </div>
                                 
                                    
                                 <div style="background-color: White; width: 295px; height: 30px; height: 4px;">
                                </div>
                                
                                
                                <div style="background-color: #FFE1AA; width: 350px; height: 30px;">
                                   Relay Start Time (RST) – seconds</div>
                                    
                                    
                                 <div style="background-color: White; width: 295px; height: 26px; height: 4px;">
                                </div>
                                 
                                  
                                <div style="background-color: #FFB9AF; width: 350px; height: 30px;">
                                   100 Meter Time</div>
                                   
                                   
                                 <div style="background-color: White; width: 295px; height: 26px; height: 4px;">
                                </div>
                                
                               
                            </div>
                            <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 185px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                 <br />
                                <br />
                                <br />
                                <br />
                            </div>
                            <div style="float: left; width: 90px; height: 26px; padding: 0px; text-align: center;">
                                <div style="background-color: #C0FFC0; width: 90px; height: 26px;">
                                    <b>Result</b></div>
                                <br />
                                <div style="background-color: #C0FFC0; width: 90px; height: 30px;">
                                    <asp:TextBox ID="lblRelayVelocityIn" runat="server" Text="" Width="60px" Height="21px"  onfocus="validate1();" onblur="demo();"></asp:TextBox></div>
                                   
                                 <div style="background-color: White; width: 90px; height: 26px; height: 4px;">
                                </div>
                                
                                
                                <div style="background-color:#91F591; width: 90px; height: 30px;">
                                    <asp:TextBox ID="lblRelayVelocityOut" runat="server" Text="" Width="60px" Height="21px" onblur="demo1();"></asp:TextBox></div>
                                   
                                 <div style="background-color: White; width: 90px; height: 26px; height: 4px;">
                                </div>
                                
                                
                                <div style="background-color:  #C0FFC0; width: 90px; height: 30px;">
                                    <asp:TextBox ID="lblRelayStart" runat="server" Text="" Width="60px" Height="21px" onblur="demo2();"></asp:TextBox></div>
                                   
                                 <div style="background-color: White; width: 90px; height: 26px; height: 4px;">
                                </div>
                                
                                
                                <div style="background-color: #91F591; width: 90px; height: 30px;">
                                    <asp:TextBox ID="lblMeterTime" runat="server" Text="" Width="60px" Height="21px" onblur="demo3();"></asp:TextBox></div>
                               
                                  
                                 <div style="background-color: White; width: 90px; height: 26px; height: 4px;">
                                </div>
                                
                            
                            </div>
                             <div style="float: left; width: 1px; padding: 0px; background-color: Black; height: 185px;">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                            </div>
                           
                            <%-- </div>--%>
                            <%--<div style="float: left; width: 574px; height: 1px; background-color: Black;">
                            </div>--%>
                            <%-- <div style="float: left; padding: 0px; margin-left: 200px; width: 300px; height: 26px;">
                            </div>--%>
                            
                            <div style="float: left; padding: 0px; margin-left: 200px; width: 300px; height: 26px;">
                                <asp:Label ID="Label1" runat="server" Text="" Width="600px" ForeColor="Red" Font-Size="Large"
                                    Font-Bold="True"></asp:Label>
                            </div>
                            
                            
                        </div>
                        
                     </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            
           
        </td>
        
    </tr>
    <div> 
<asp:Label ID="Message" runat="server"></asp:Label>
</div>
</table>

                                 
  <div style="margin-left:130px;margin-top:-740px;">
            <asp:Button ID="btnSubmit" runat="server" Width="100px" Text="Submit" OnClick="btnSubmit_Click"  OnClientClick="ValidateDropdown(); Validation();" />
            
           <%-- <asp:RequiredFieldValidator ID="btnsubmit_require"  ControlToValidate="btnSubmit" runat="server" ErrorMessage="Please Fill the value">
            </asp:RequiredFieldValidator>--%>
  </div>
