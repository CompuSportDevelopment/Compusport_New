<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true"
    CodeFile="SelectMember.aspx.cs" Inherits="Teachers_SelectMember" Title="CompuSport – My Athlete Video Player" %>

<%@ Register Src="~/Controls/TeachersMenu.ascx" TagName="TeachersMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        function getAlert() {
            var ls = document.getElementById('<%= ListBox1.ClientID %>');
            var selected = ls.selectedIndex;
            if (selected == -1) {
                alert('Please select member from list.');
                return false;
            }
            return true;
        }
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="submenu">
        <uc1:TeachersMenu ID="TeachersMenu1" runat="server" />
    </div>
    <p class="pagetitle">
        Search for My Athletes to Load Into Video Player
        <asp:UpdateProgress ID="Updat_Paymentxyz" runat="server" DisplayAfter="1">
            <ProgressTemplate>
                <div style="text-align: left; position: absolute; top: 40%; left: 40%;">
                    <img src="../images/big_loading.gif" alt="" width="70px" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </p>
    <div id="centeronpage" class="centeronpage">
        <p style="text-align: justify; width: 800px;">
            Enter the name or initials of any of your Athletes that you would like to display.
            A minimum of the first letter of each name is required. You may use an asterisk
            (*) as a wildcard to list all Athletes in the First Name and/or Last Name category.</p>
        <asp:Label ID="Label1" runat="server" Text="First Name:" Font-Bold="True" Width="120px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Last Name:" Font-Bold="True" Width="120px"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
        <div style="text-align: left; margin-left: 320px;">
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        </div>
        <%--
        <br />
        <asp:Label ID="Label3" runat="server" Text="Email Address:" Font-Bold="True" Width="120px"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" Width="200px"></asp:TextBox>
        --%>
        <br />
        <br />
        <br />
        <br />
        <p style="text-align: justify; width: 800px;">
            Select the member in the list below, and then click the View button, to view their
            CompuSport Video Player.</p>
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <asp:ListBox ID="ListBox1" runat="server" Height="200px" Width="450px" SelectionMode="Single">
                </asp:ListBox>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="View" OnClick="Button2_Click" OnClientClick="return getAlert();" />
    </div>
</asp:Content>
