<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="EquipmentFitting.aspx.cs" Inherits="TeacherInfo_EquipmentFitting" Title="SwingModel - Component Based Golf Equipment Fitting System" %>
<%@ Register Src="~/Controls/TeacherInfoMenu.ascx" TagName="TeacherInfoMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="submenu">
        <uc1:TeacherInfoMenu ID="TeacherInfoMenu1" runat="server" />
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
        This process begins with an evaluation of your student’s golf swing, identifying the errors,
        and determining the swing path and speed components of the student. Since the student’s golf
        shaft selection is dependent upon this information, it is a critical part of the process.</p>
    <div class="centerimage">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Fit1.jpg" />
    </div>
    <p>
        The next step is to identify the current equipment that your student is currently using. Since the
        ball launch results are dependent on the current equipment, it is critical that this information be
        collected.</p>
    <div class="centerimage">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Fit2.jpg" />
    </div>
    <p>
        Once this is done, the student takes 10 swings, with the ball and club results recorded with
        video and a launch monitor.</p>
    <div class="centerimage">
        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Fit3.jpg" />
    </div>
    <p>
        You can then use the SwingModel data base to determine the proper clubhead, shaft, and ball
        for the student. You can use the entire equipment database, or select specific clubheads,
        shafts, or balls. The resulting fit identifies the best three results for each component.</p>
    <div class="centerimage">
        <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Fit4.jpg" />
    </div>
    <p>
        You can then have the student try any combination of the suggested components to determine
        the one that “feels” the best. Once the final selections are made, the entire Wood club set
        is displayed.</p>
    <div class="centerimage">
        <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/Fit5.jpg" />
    </div>
    <p>
        Once the set makeup is completed, and the grip selected, the fitting moves on to the Iron
        fitting. The same process is employed, with your student hitting a 6 Iron as the launch and
        video results are collected.</p>
    <p>
        Once the entire club set is determined, the purchase is confirmed on-line, and the
        specifications are forwarded, via the Internet, to TPT Golf (or your own club builder) for
        fulfillment. In addition, all of the fitting results are sent to the TPT Golf website for the
        student to review at any time.</p>
    <p>
        Finally, since TPT Golf stands behind its product with a performance guarantee (when
        fulfilled by TPT Golf), your student is assured of a successful fitting process.  Since you
        know that the equipment that your students have is a major factor in maximizing their ability
        to improve, providing them with the best equipment for their game is imperative.</p>
    <p>
        The beauty of this fitting system is that you can perform high quality equipment fitting
        without having to have years of fitting experience.  The research performed by SwingModel
        gives you fitting expertise unavailable even from the best fitters.  In addition, the revenue
        generated from fitting and sales provides an additional revenue source.</p>
    <p class="pagetitle" style="width: 100%;">
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/TeacherInfo/Membership.aspx">Continue Tour</asp:HyperLink>
        or
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/TeacherInfo/Default.aspx">Return to Teacher Tour Home</asp:HyperLink></p>
</asp:Content>
