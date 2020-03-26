<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="Model.aspx.cs" Inherits="About_Model" Title="CompuSport - The New 21st Century Super Model" %>
<%@ Register Src="~/Controls/AboutMenu.ascx" TagName="AboutMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="submenu">
        <uc1:AboutMenu ID="AboutMenu1" runat="server"/>
    </div>
    <p class="pagetitle">The New 21st Century Super Model</p>
    <p>
        When Dr. Mann began the task of bringing the Model concept into the 21st 
        century, he had several goals:</p>
    <p>
        <asp:BulletedList ID="BulletedList1" runat="server" BulletStyle="Numbered">
            <asp:ListItem>The new Model had to be based on the new, more powerful swings of 
            the current PGA players.</asp:ListItem>
            <asp:ListItem>The modeling process had to be revised to improve the Model swing.</asp:ListItem>
            <asp:ListItem>The new clubs (hybrids) had to be added.</asp:ListItem>
            <asp:ListItem>The new model had to be more flexible in its ability to adapt to 
            the average golfer.</asp:ListItem>
            <asp:ListItem>The tools used to develop and display the new Model needed to have 
            the stability and technology advances available in the latest software.</asp:ListItem>
        </asp:BulletedList></p>
    <p>
        Two years later, the revision is complete. The new Model is a powerful action 
        capable of driving the ball over 300 yards with the Driver, yet still 
        maintaining the grace and control required for consistency. See the power and grace of
        the new Model below.</p>
    <div align="center">
        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,16,0"
            width="800" height="300" id="flash1" name="flash1">
            <param name="movie" value="http://www.swingmodel.com/Images/ModelBoth.swf">
            <param name="quality" value="high">
            <param name="play" value="true">
            <param name="loop" value="true">
            <embed id="flash1" name="flash1" src="http://www.swingmodel.com/Images/ModelBoth.swf" width="800" height="300" play="true" loop="true"
                quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"></embed>
        </object>
    </div>
    <p>
        As a golfer, you can imagine taking this Driver Model, or the Model for any club in your bag,
        and having it adjusted to your exact body dimensions and swing speed.  You no longer have to
        wonder what you need to do to maximize your performance; it is shown right before your eyes.</p>
    <p class="pagetitle" style="width: 100%;">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/About/System.aspx">Continue Tour</asp:HyperLink>
        or
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/About/Default.aspx">Return to Golfer Tour Home</asp:HyperLink></p>
</asp:Content>
