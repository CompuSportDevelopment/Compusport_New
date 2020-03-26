<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true"
    CodeFile="login.aspx.cs" Inherits="login" Title="CompuSport - Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <script type="text/javascript" src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
  <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script type="text/javascript" language="javascript">
      
        
        function IETextBoxAlignment() {
            var val = navigator.userAgent.toLowerCase();
            if (val.indexOf("msie") > -1) {
                // debugger;
                var txtBoxTwoID = document.getElementById('ctl00_ContentPlaceHolder1_Login1_Password');
                txtBoxTwoID.style.width = '150px';
                txtBoxTwoID.style.marginLeft = '1px';
                var txtBoxPasswordID = document.getElementById('ctl00_ContentPlaceHolder1_PasswordRecovery1_UserNameContainerID_UserName');
                //txtBoxPasswordID.style.marginLeft = '-90px';
            }
        }
        window.onload = IETextBoxAlignment;
    </script>

    <p style="font-size: x-large; font-weight: bold;">
        Login to My CompuSport</p>
    <div class="login">
        <div align="center">
            <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Users/Default.aspx" OnLoggedIn="Login1_LoggedIn"
                RememberMeText="Remember me next time (for 365 days)." OnLoginError="Login1_OnLoginError">
            </asp:Login>
        </div>
    </div>
    <div id="ShowingGroundTime">
    </div>
    <div class="logindivider">
    </div>
    <a style="margin-left: 150px">Forgot your Password?</a>
    <br />
    <br />
    <a style="margin-left: 100px">Enter Your User Name:</a>
    <br />
    <br />
    <a style="margin-left: 100px">
        <asp:Label ID="label1" runat="server">UserName:</asp:Label></a> &nbsp&nbsp<asp:TextBox
            ID="txtusername" runat="server"></asp:TextBox>
    <br />
    <br />
    <a style="margin-left: 220px">
        <asp:Button ID="btnsubmit" Text="Submit" runat="server" OnClick="btnsubmit_Click1" /></a>
    <br />
    <div style="margin-left: 55%">
        <asp:Label ID="lblsuccess" runat="server" ForeColor="Green"></asp:Label>
        <br />
        <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
        <br />
    </div>
    <asp:Label ID="Label8" runat="server" Visible="False" ForeColor="Red"></asp:Label>
    <br />
    <%--<div class="passwordrecovery">
        <div align="center">
            <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" UserNameInstructionText="Enter your User Name to receive a new, temporary password."
                SuccessText="Your password has been sent to your email account. Retrieve the password from your email, return to this login page, and enter your username and temporary password. Once logged in, you may go to the Change My Password page to enter your desired password.">
            </asp:PasswordRecovery>
        </div>
    </div>--%>
</asp:Content>
