<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div>
    <fieldset style="width:350px;">
   
    <table>
    <tr>
    <td>User Name: * </td>
    <td>
        <asp:TextBox ID="txtUserName" runat="server" ReadOnly="true" BackColor="LightGray"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="rfvuserName" runat="server"
            ErrorMessage="Please enter User Name" ControlToValidate="txtUserName"
            Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td>
    </tr>
   
     <tr>
    <td>New Password: * </td>
    <td>
        <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="rfvNewPwd" runat="server"
            ErrorMessage="Please enter new password" ControlToValidate="txtNewPwd"
            Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtNewPwd" 
             ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{4,}$" runat="server" 
             ErrorMessage="Password must be at Least 4 Characters"></asp:RegularExpressionValidator>
         </td>
    </tr>
         <tr>
    <td>Confirm Password: * </td>
    <td>
        <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="rfvConfirmPwd" runat="server"
            ErrorMessage="Please re-enter password to confirm"
            ControlToValidate="txtConfirmPwd" Display="Dynamic" ForeColor="Red"
            SetFocusOnError="True"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cmvConfirmPwd" runat="server"
            ControlToCompare="txtNewPwd" ControlToValidate="txtConfirmPwd"
            Display="Dynamic" ErrorMessage="New and confirm password didn't match"
            ForeColor="Red" SetFocusOnError="True"></asp:CompareValidator>
             </td>
    </tr>
   
  
     <tr>
    <td>
        &nbsp;</td><td>
        <asp:Button ID="btnSubmit" runat="server" Text="Reset Password"
             onclick="btnSubmit_Click"/></td>
    </tr>
   <tr>
   <td>
   <asp:HyperLink ID="MyHyperLinkControl" NavigateUrl="~/login.aspx" runat="server">Login</asp:HyperLink>
   </td>
   
   </tr>
    
     <tr>
    <td colspan="2">
     <asp:Label ID="lblsuccess" runat="server" ForeColor="Green"></asp:Label>
     <br />
        <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
       
         </td>
    </tr>
    </table>
    </fieldset>   
    </div>

</asp:Content>

