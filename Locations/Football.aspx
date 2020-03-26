<%@ Page Title="CompuSport – Football Locations" Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="Football.aspx.cs" Inherits="Locations_Football" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p class="pagetitle">
       CompuSport Football Locations</p>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <cc1:TabContainer runat="server" ID="Tabs" CssClass="ajax__tab_xp" AutoPostBack="False">
        <cc1:TabPanel runat="server" ID="TabPanel1" HeaderText="United States">
            <ContentTemplate>
                <cc1:Accordion ID="Accordion2" runat="server" SelectedIndex="-1" HeaderCssClass="accordionHeader"
                    HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent"
                    FadeTransitions="false" FramesPerSecond="40" TransitionDuration="250" AutoSize="None"
                    RequireOpenedPane="false" SuppressHeaderPostbacks="true">
                    <Panes>
                    </Panes>
                </cc1:Accordion>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel runat="server" ID="TabPanel2" HeaderText="International">
            <ContentTemplate>
                <cc1:Accordion ID="Accordion4" runat="server" SelectedIndex="-1" HeaderCssClass="accordionHeader"
                    HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent"
                    FadeTransitions="false" FramesPerSecond="40" TransitionDuration="250" AutoSize="None"
                    RequireOpenedPane="false" SuppressHeaderPostbacks="true">
                    <Panes>
                    </Panes>
                </cc1:Accordion>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
</asp:Content>
