<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true"
    CodeFile="GetMemberPlayer.aspx.cs" Inherits="Admin_GetMemberPlayer" Title="SwingModel - Teachers Member Date Video Player" %>

<%@ Register Src="~/Controls/FacilityMenu.ascx" TagName="FacilityMenu" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="submenu">
        <uc1:FacilityMenu ID="FacilityMenu1" runat="server" />
    </div>
    <p class="pagetitle">
        Search for My CompuSport Member over a Date Range to Load into Player</p>
    <div id="centeronpage" class="centeronpage">
        <p style="text-align: justify; width: 800px;">
            Select the teacher to find members they created in the desired date range. Enter
            a beginning date in the left hand date field and an ending date in the right hand
            date field. The search will locate all members created by the selected teacher during
            the specified date range.</p>
        <br />
        <table style="margin-left: 300px;">
            <tr>
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Beginning Date:" Font-Bold="True" Width="120px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="148px"></asp:TextBox>
                </td>
                <td>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox1"
                        CssClass="MyCalendar" Format="MM/dd/yyyy" PopupButtonID="Image1" />
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Calendar.png" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Ending Date :" Font-Bold="True" Width="120px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="148px"></asp:TextBox>
                </td>
                <td>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox2"
                        CssClass="MyCalendar" Format="MM/dd/yyyy" PopupButtonID="Image2" />
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Calendar.png" />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <%--<asp:TextBox ID="TextBox1" runat="server" Width="148px"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox1" CssClass="MyCalendar" Format="MM/dd/yyyy" PopupButtonID="Image1" />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Calendar.png" />
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Width="154px"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox2" CssClass="MyCalendar" Format="MM/dd/yyyy" PopupButtonID="Image2" />
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Calendar.png" />
        <br /><br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" />
        <br />--%>
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
        <br />
        <br />
    </div>
</asp:Content>
