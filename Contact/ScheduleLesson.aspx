<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="ScheduleLesson.aspx.cs" Inherits="Users_ScheduleLesson" Title="CompuSport- Schedule A Lesson" ValidateRequest="false" %>
<%@ Register Src="~/Controls/ContactMenu.ascx" TagName="ContactMenu" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="submenu">
        <uc1:ContactMenu ID="ContactMenu1" runat="server" />
    </div>
    <p class="pagetitle">Schedule a Session</p>
    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 145px;">
        <asp:Label ID="Label1" runat="server" Text="Beginning Date: " Font-Bold="True" Width="145px"></asp:Label>
    </div>
    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 700px;">
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="TextBox2" eventname="TextChanged" />
            </Triggers>
            <ContentTemplate>
                <asp:TextBox ID="TextBox2" runat="server" ontextchanged="TextBox2_TextChanged" AutoPostBack="true"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox2" CssClass="MyCalendar" Format="MM/dd/yyyy" PopupButtonID="Image1" />
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Calendar.png" />
                <asp:Label ID="Label9" runat="server" Text="Selected Date Must Be Later Than Today" Visible="False"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 145px;">
        <asp:Label ID="Label2" runat="server" Text="Ending Date: " Font-Bold="True" Width="145px"></asp:Label>
    </div>
    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 700px;">
        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="TextBox3" eventname="TextChanged" />
            </Triggers>
            <ContentTemplate>
                <asp:TextBox ID="TextBox3" runat="server" ontextchanged="TextBox3_TextChanged" AutoPostBack="true"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox3" CssClass="MyCalendar" Format="MM/dd/yyyy" PopupButtonID="Image2" />
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Calendar.png" />
                <asp:Label ID="Label10" runat="server" Text="Selected Date Must Be Later Than Today" Visible="False"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Start Time: " Font-Bold="True" Width="145px"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="Any Time" Selected="True">Any Time</asp:ListItem>
        <asp:ListItem Value="AM (8:00 AM - 12:00 Noon)">AM (8:00 AM - 12:00 Noon)</asp:ListItem>
        <asp:ListItem Value="PM (1:00 PM - 5:00 PM)">PM (1:00 PM - 5:00 PM)</asp:ListItem>
        <asp:ListItem Value="8:00 AM">8:00 AM</asp:ListItem>
        <asp:ListItem Value="9:00 AM">9:00 AM</asp:ListItem>
        <asp:ListItem Value="10:00 AM">10:00 AM</asp:ListItem>
        <asp:ListItem Value="11:00 AM">11:00 AM</asp:ListItem>
        <asp:ListItem Value="1:00 PM">1:00 PM</asp:ListItem>
        <asp:ListItem Value="2:00 PM">2:00 PM</asp:ListItem>
        <asp:ListItem Value="3:00 PM">3:00 PM</asp:ListItem>
        <asp:ListItem Value="4:00 PM">4:00 PM</asp:ListItem>
        <asp:ListItem Value="Other">Other (Instructor Will Contact You)</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Number of Hours: " Font-Bold="True" Width="145px"></asp:Label>
    <asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem Value="1">1</asp:ListItem>
        <asp:ListItem Value="2">2</asp:ListItem>
        <asp:ListItem Value="3">3</asp:ListItem>
        <asp:ListItem Value="4">4</asp:ListItem>
        <asp:ListItem Value="Other">Other (Instructor Will Contact You)</asp:ListItem>
    </asp:DropDownList>
    <br />
    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 145px;">
        <asp:Label ID="Label7" runat="server" Text="Location: " Font-Bold="True" Width="145px"></asp:Label>
    </div>
    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 700px;">
        <asp:UpdatePanel runat="server" ID="UpdatePanel3">
            <ContentTemplate>
                <asp:DropDownList ID="DropDownList8" runat="server"
                    onselectedindexchanged="DropDownList8_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 145px;">
        <asp:Label ID="Label6" runat="server" Text="Teacher: " Font-Bold="True" Width="145px"></asp:Label>
    </div>
    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 700px;">
        <asp:UpdatePanel runat="server" ID="UpdatePanel4">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="DropDownList8" eventname="SelectedIndexChanged" />
            </Triggers>
            <ContentTemplate>
                <asp:DropDownList ID="DropDownList9" runat="server">
                </asp:DropDownList>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
    <asp:Label ID="Label11" runat="server" Text="My Name: " Font-Bold="true" Width="145px"></asp:Label>
    <asp:TextBox ID="TextBox5" runat="server" Rows="1" Width="378px"></asp:TextBox>
    <asp:Label ID="Label12" runat="server" Text="Please Enter Your Name" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="Label8" runat="server" Text="My Email: " Font-Bold="true" Width="145px"></asp:Label>
    <asp:TextBox ID="TextBox4" runat="server" Rows="1" Width="378px"></asp:TextBox>
    <asp:Label ID="Label13" runat="server" Text="Please Enter Your Email Address" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Special Information: " Width="145px" Font-Bold="True"></asp:Label>
    <%--
    <asp:TextBox ID="TextBox1" runat="server" Height="300px" MaxLength="2000" 
        TextMode="MultiLine" Width="453px"></asp:TextBox>
    <br /><br />
    --%>
    <FTB:FreeTextBox id="FreeTextBox1" AutoGenerateToolbarsFromString="false" Width="523px" Height="300px" runat="Server" />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit" 
        onclick="Button1_Click1" />
    <asp:Label ID="Label14" runat="server" Text="Your lesson appointment request was successfully sent." Visible="False"></asp:Label>
</asp:Content>

