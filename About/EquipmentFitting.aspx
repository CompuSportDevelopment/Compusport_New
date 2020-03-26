<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="EquipmentFitting.aspx.cs" Inherits="About_EquipmentFitting" Title="CompuSport - Component Based Golf Equipment Fitting System" %>
<%@ Register Src="~/Controls/AboutMenu.ascx" TagName="AboutMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="submenu">
        <uc1:AboutMenu ID="AboutMenu1" runat="server" />
    </div>
    <p class="pagetitle">Component Based Golf Equipment Fitting System</p>
    <p>
        Using the results from the 
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/About/Research.aspx">SwingModel 
        equipment research effort</asp:HyperLink>, in conjunction with
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.tptgolf.com" Target="_blank">TPT 
        Golf</asp:HyperLink>, Swing Model has developed the first component based 
        equipment fitting system.</p>
    <p>
        This process begins with an evaluation of your golf swing, identifying your swing errors, and
        determining the swing path and speed components of your swing. Since your golf shaft
        selection is dependent upon this information, it is a critical part of the process.</p>
    <div class="centerimage">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Fit1.jpg" />
    </div>
    <p>
        The next step is to identify the current equipment that you are currently using. Since the
        ball launch results are dependent on your current equipment, it is critical that this
        information be collected.</p>
    <div class="centerimage">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Fit2.jpg" />
    </div>
    <p>
        Once this is done, you will need to take 10 swings, with the ball and club results recorded
        with video and a launch monitor.</p>
    <div class="centerimage">
        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Fit3.jpg" />
    </div>
    <p>
        Your teacher or equipment fitter can then use the SwingModel data base to determine your
        proper clubhead, shaft, and ball. They can use the entire equipment database, or select
        specific clubheads, shafts, or balls. The resulting fit identifies the best three results for
        each component.</p>
    <div class="centerimage">
        <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Fit4.jpg" />
    </div>
    <p>
        Your teacher or equipment fitter can then have you try any combination of the suggested
        components to determine the one that “feels” the best. Once the final selections are made,
        the entire Wood club set is displayed.</p>
    <div class="centerimage">
        <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/Fit5.jpg" />
    </div>
    <p>
        Once your set makeup is completed, and the grip selected, the fitting moves on to the Iron
        fitting. The same process is employed by having you hit a 6 Iron as the launch and video
        results are collected.</p>
    <p>
        Once the entire club set is determined, the purchase is confirmed on-line, and the
        specifications are forwarded, via the Internet, to TPT Golf for fulfillment. In addition, all
        of the fitting results are sent to the TPT Golf website for you to review at any time.</p>
    <p>
        Finally, since TPT Golf stands behind its product with a performance guarantee, you are
        assured of a successful fitting process.  If you are not satisfied with the results, TPT Golf
        will work with you to resolve the problems.</p>
    <p class="pagetitle" style="width: 100%;">
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/About/Membership.aspx">Continue Tour</asp:HyperLink>
        or
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/About/Default.aspx">Return to Golfer Tour Home</asp:HyperLink></p>
</asp:Content>
