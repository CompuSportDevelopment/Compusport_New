<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="MakeMember.aspx.cs" Inherits="MakeMember" Title="SwingModel - Make Me A Member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p class="pagetitle">Sign Up for Your New SwingModel Account</p>
    <div class="makemember">
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
            CancelDestinationPageUrl="Default.aspx" DisableCreatedUser="True" 
            DisplayCancelButton="True" LoginCreatedUser="False" 
            oncreateduser="CreateUserWizard1_CreatedUser">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
    </div>
</asp:Content>

