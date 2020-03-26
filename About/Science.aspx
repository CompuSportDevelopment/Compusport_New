<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="Science.aspx.cs" Inherits="About_Science" Title="SwingModel - Science Based Technology" %>
<%@ Register Src="~/Controls/AboutMenu.ascx" TagName="AboutMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="submenu">
        <uc1:AboutMenu ID="AboutMenu1" runat="server" />
    </div>
    <p class="pagetitle">Science Based Technology</p>
    <p>
        <asp:Image ID="Image1" runat="server" ImageAlign="Left" ImageUrl="~/Images/BaylorSetup.jpg" />
        In the Golf Teaching and Equipment Fitting world, opinions dominate the landscape.  Every
        year there are new opinions that catch on and, for a brief period, dominate the pages of
        the golf magazines.</p>
    <p>
        In teaching, there have been opinions that the key to success lies in a big shift off the
        ball, or no shift off the ball, or a big turn, or no turn.  In equipment, there have been
        opinions that the key to performance is light clubs, or heavy clubs, or stepped flexes,
        or flat flexes.</p>
    <p>
        The list of contradictory opinions is long, but the result is that the individuals that
        promote their opinions to popularity are the winners, while the golfing population is
        usually the loser.  EBay is filled with the tapes and equipment of past opinion fads,
        selling at pennies on the dollar.</p>
    <p>
        If a student is truly interested in improving their game, they should find a teacher and
        equipment fitter that uses science as a guide to their knowledge base.  Sports science
        has been used for over 30 years in the Olympic sports to guide the development of the
        elite athletes.  Unfortunately, golf has not fully embraced this approach, which is the
        main reason that the handicap of the average golfer has improved little over the last 20
        years.</p>
    <p>
        SwingModel is dedicated to providing those teachers, fitters, and students a learning
        process that is based on scientific research.  It may not conform to the latest fad, but
        it provides the user with what truly works in golf performance.</p>
    <p class="pagetitle" style="width: 100%;">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/About/Process.aspx">Continue Tour</asp:HyperLink>
        or
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/About/Default.aspx">Return to Golfer Tour Home</asp:HyperLink></p>
</asp:Content>

