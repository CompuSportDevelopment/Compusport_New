<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="GolfModeling.aspx.cs" Inherits="About_GolfModeling" Title="CompuSport - Modeling Process in Golf" %>
<%@ Register Src="~/Controls/AboutMenu.ascx" TagName="AboutMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="submenu">
        <uc1:AboutMenu ID="AboutMenu1" runat="server" />
    </div>
    <p class="pagetitle">Modeling Process in Golf</p>
    <p>
        <asp:Image ID="Image1" runat="server" ImageAlign="Left" ImageUrl="~/Images/WoodsDriver1.jpg" />
        The 
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/About/Process.aspx">modeling 
        techniques</asp:HyperLink>
        that Dr. Mann began developing in 1976 are now being used to teach golf the 
        world over. The new model, based on the swings of the best of the current 
        players on the PGA Tour, is the next step in the modeling process in Golf.</p>
    <p>
        As with all of the models Dr. Mann has developed, the golf model is a composite 
        of all of the best movements made by the best players in golf to successfully 
        strike the golf ball. Models have been developed for the Woods, Irons, and 
        Hybrids.</p>
    <p>
        Each of these models can be customized to any student’s exact body size and swing speed. This
        gives any golfer the ability to truly move in the right direction in their development
        process.</p>
    <p>
        The key to maximizing your improvement is the ability to rely on the science based process of
        discovering your proper movement pattern. The key to this is to develop your swing model
        from the best current players in the game.</p>
    <p class="pagetitle" style="width: 100%;">
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/About/Model.aspx">Continue Tour</asp:HyperLink>
        or
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/About/Default.aspx">Return to Golfer Tour Home</asp:HyperLink></p>
</asp:Content>
