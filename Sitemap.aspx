<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="Sitemap.aspx.cs" Inherits="Sitemap" Title="SwingModel - Sitemap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" StartingNodeOffset="0" />
    <asp:TreeView ID="TreeView1"
        ForeColor="#053654"
        runat="server"
        DataSourceID="SiteMapDataSource1"
        Orientation="TreeView"
        MaximumDynamicDisplayLevels="1"
        SkipLinkText=""
        StaticDisplayLevels="2" 
        onselectednodechanged="TreeView1_SelectedNodeChanged" />
</asp:Content>

