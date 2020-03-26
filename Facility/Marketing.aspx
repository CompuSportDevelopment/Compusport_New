<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="Marketing.aspx.cs" Inherits="Teachers_Marketing" Title="SwingModel - Facility Marketing Materials" %>
<%@ Register Src="~/Controls/FacilityMenu.ascx" TagName="TeachersMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="submenu">
        <uc1:TeachersMenu ID="TeachersMenu1" runat="server" />
    </div>
    <p class="pagetitle">CompuSport Marketing Materials</p>
    <p style="font-size: large; font-weight: bold;">Downloading Instructions</p>
    <p style="text-align: justify;">
        Below are the CompuSport Marketing Materials available to licensed facilities. To download any
        of the items, right-click (control-click on Mac) on the desired link. Then click on Save
        Target As.../Save Link As... Save the item to the folder of your choice on your local hard
        drive.
        <br /><br />
        All images may be sized down smaller than their native sizes. This may be accomplished by
        changing the printing size setting (DPI), or by changing the physical dimensions of the
        image (Pixels). It is not recommended to increase the size of the images for printing. If a
        larger version of an image is desired, please contact CompuSport for a customized version.
        <br /><br />
        When obtaining prints of any of the items, be sure to get a proof of the item before
        completing the print job. A proof is necessary to insure that all images and text will print on
        the final print. It is also necessary to insure that folds will be placed in the proper
        location. If there are any issues, your printer may contact CompuSport for any additional
        help.
    </p>
    <div style="text-align: center;">
        <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/Divider-900PixelsWide.png" />
    </div>
    <p style="font-size: x-large; font-weight: bold;">Impact Banner</p>
    <div style="width: 20%; height: 300px; float: left;">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Marketing/PromoImpactNoStickThumb.jpg" Width="160" Height="280" />
    </div>
    <div style="width: 60%; height: 300px; float: left; text-align: justify;">
        The Impact Banner is available with or without the stick figure overlay. The banner indicates
        PGA Tour players with segment lenghts that match those of the new 21st Century Super Model.
        <br /><br />
        <div style="text-align: center;">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Marketing/PromoImpactNoStickSmall.jpg">Impact Banner without Stick Figure Small</asp:HyperLink>
            <br />
            (6"x10.5" @100 dpi, 4"x7" @150 dpi, 2"x3.5" @300 dpi)
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Marketing/PromoImpactNoStick.jpg">Impact Banner without Stick Figure</asp:HyperLink>
            <br />
            (24"x42" @100 dpi, 16"x28" @150 dpi, 8"x14" @300 dpi)
            <br />
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Marketing/PromoImpactStickSmall.jpg">Impact Banner with Stick Figure Small</asp:HyperLink>
            <br />
            (6"x10.5" @100 dpi, 4"x7" @150 dpi, 2"x3.5" @300 dpi)
            <br />
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Marketing/PromoImpactStick.jpg">Impact Banner with Stick Figure</asp:HyperLink>
            <br />
            (24"x42" @100 dpi, 16"x28" @150 dpi, 8"x14" @300 dpi)
        </div>
    </div>
    <div style="width: 20%; height: 300px; float: left; text-align: right;">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Marketing/PromoImpactStickThumb.jpg" Width="160" Height="280" />
    </div>
    <div style="text-align: center;">
        <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/Divider-900PixelsWide.png" />
    </div>
    <p style="font-size: x-large; font-weight: bold;">Setup Banner</p>
    <div style="width: 20%; height: 300px; float: left;">
        <asp:Image ID="Image3" runat="server" ImageUrl="~/Marketing/PromoSetupNoStickThumb.jpg" Width="160" Height="280" />
    </div>
    <div style="width: 60%; height: 300px; float: left; text-align: justify;">
        The Setup Banner is available with or without the stick figure overlay. The banner indicates
        PGA Tour players with segment lenghts that match those of the new 21st Century Super Model.
        <br /><br />
        <div style="text-align: center;">
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Marketing/PromoSetupNoStickSmall.jpg">Setup Banner without Stick Figure Small</asp:HyperLink>
            <br />
            (6"x10.5" @100 dpi, 4"x7" @150 dpi, 2"x3.5" @300 dpi)
            <br />
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Marketing/PromoSetupNoStick.jpg">Setup Banner without Stick Figure</asp:HyperLink>
            <br />
            (24"x42" @100 dpi, 16"x28" @150 dpi, 8"x14" @300 dpi)
            <br />
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Marketing/PromoSetupStickSmall.jpg">Setup Banner with Stick Figure Small</asp:HyperLink>
            <br />
            (6"x10.5" @100 dpi, 4"x7" @150 dpi, 2"x3.5" @300 dpi)
            <br />
            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Marketing/PromoSetupStick.jpg">Setup Banner with Stick Figure</asp:HyperLink>
            <br />
            (24"x42" @100 dpi, 16"x28" @150 dpi, 8"x14" @300 dpi)
        </div>
    </div>
    <div style="width: 20%; height: 300px; float: left; text-align: right;">
        <asp:Image ID="Image4" runat="server" ImageUrl="~/Marketing/PromoSetupStickThumb.jpg" Width="160" Height="280" />
    </div>
    <div style="text-align: center;">
        <asp:Image ID="Image10" runat="server" ImageUrl="~/Images/Divider-900PixelsWide.png" />
    </div>
    <p style="font-size: x-large; font-weight: bold;">21st Century Super Model Sequence Wide Banner</p>
    <div style="width: 51%; height: auto; float: left;">
        <asp:Image ID="Image5" runat="server" runat="server" ImageUrl="~/Marketing/PromoSwingSequence01Thumb.jpg" Height="193" Width="450" />
    </div>
    <div  style="width: 49%; height: auto; float: left; text-align: justify;">
        The 21st Century Super Model Sequence wide banner is available for printing is sizes up to
        7 feet wide by 3 feet tall. This is a great banner to hang on a wall, or to set up on an
        outdoor range.
        <br /><br />
        <div style="text-align: center;">
            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Marketing/PromoSwingSequence01Small.jpg">21st Century Super Model Sequence Wide Banner Small</asp:HyperLink>
            <br />
            (15"x6.5" @100 dpi, 10"x4.25" @150 dpi, 5"x2.25" @300 dpi)
            <br />
            <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Marketing/PromoSwingSequence01.jpg">21st Century Super Model Sequence Wide Banner</asp:HyperLink>
            <br />
            (84"x36" @100 dpi, 56"x24" @150 dpi, 28"x12" @300 dpi)
        </div>
    </div>
    <div style="text-align: center;">
        <asp:Image ID="Image11" runat="server" ImageUrl="~/Images/Divider-900PixelsWide.png" />
    </div>
    <p style="font-size: x-large; font-weight: bold;">CompuSport Logo</p>
    <div style="width: 51%; height: 420px; float: left;">
        <asp:Image ID="Image6" runat="server" ImageUrl="~/Marketing/SwingModelLogoWallSize100dpiThumb.png" Height="403" Width="450" />
    </div>
    <div  style="width: 49%; height: 420px; float: left; text-align: justify;">
        The CompuSport logo is available for printing in sizes up to 6.5 feet wide by 6 feet tall.
        This logo may be used for a wall print, a large range banner, as a backstop in an inside hitting
        bay, or may be sized down to use for any purpose.
        <br /><br />
        <div style="text-align: center;">
            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Marketing/SwingModelLogoWallSize100dpiSmall.png">CompuSport Logo Small</asp:HyperLink>
            <br />
            (40"x36" @100 dpi, 26.75"x24" @150 dpi, 13.5"x12" @300 dpi)
            <br />
            <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Marketing/SwingModelLogoWallSize100dpi.png">CompuSport Logo</asp:HyperLink>
            <br />
            (78"x70" @100 dpi, 52"x46.5" @150 dpi, 26"x23.25" @300 dpi)
        </div>
    </div>
    <div style="width: 100%; height: 20px;">&nbsp;</div>
    <div style="width: 51%; height: 170px; float: left; text-align: center;">
        <asp:Image ID="Image13" runat="server" ImageUrl="~/Marketing/SwingModelLogoBusinessCardSize300dpi.png" Height="150" Width="186" />
    </div>
    <div  style="width: 49%; height: 170px; float: left; text-align: justify;">
        The CompuSport logo is available for inclusion on business cards for licensed facilities (and their employees).
        <br /><br />
        <div style="text-align: center;">
            <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/Marketing/SwingModelLogoBusinessCardSize300dpi.png">CompuSport Logo for Business Cards</asp:HyperLink>
            <br />
            (1.9"x1.5" @300 dpi)
        </div>
    </div>
    <div style="text-align: center;">
        <asp:Image ID="Image12" runat="server" ImageUrl="~/Images/Divider-900PixelsWide.png" />
    </div>
    <p style="font-size: x-large; font-weight: bold;">CompuSport Tri-Fold Teaching Brochure</p>
    <div style="width: 25%; height: 175px; float: left;">
        <asp:Image ID="Image7" runat="server" ImageUrl="~/Marketing/SwingModelBrochureThumb.png" Height="155" Width="200" />
    </div>
    <div  style="width: 75%; height: 175px; float: left; text-align: justify;">
        The CompuSport Tri-Fold Teaching brochure is available to use as a marketing tool for any licensed
        facility. There is a panel on the back third that may be customized for the facility
        with information including the address and facility logo.
        <br /><br />
        <div style="text-align: center;">
            <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Marketing/SwingModel%20Brochure-Final2.pdf">CompuSport Tri-Fold Brochure in PDF format (for viewing only)</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Marketing/SwingModel%20Brochure-Final2.pub">CompuSport Tri-Fold Brochure in Microsoft Publisher format (customizable)</asp:HyperLink>
        </div>
    </div>
</asp:Content>

