<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="ClubOrderSuccess.aspx.cs" Inherits="Shop_ClubOrderSuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p class="pagetitle">Club Order Confirmation</p>
    <p>
        <div style="width: 33%; float: left; text-align: left;">
            <b>Customer:</b>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
        <div style="width: 34%; float: left; text-align: center;">
            <b>Date:</b>
            <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
        </div>
        <div style="width: 33%; float: left; text-align: right;">
            <b>Order #:</b>
            <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
        </div>
    </p>
    <br /><br />
    <div style="float: left; margin: 0px; padding: 0px; width: 100%;">
        <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" BorderStyle="Solid" Font-Bold="True">
            <Columns>
                <asp:BoundField DataField="Club" HeaderText="Club" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="310" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="Lie" HeaderText="Lie" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Loft" HeaderText="Loft" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Shaft" HeaderText="Shaft" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="300" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="Freq" HeaderText="Frequency" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Length" HeaderText="Length" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Cost" HeaderText="Cost" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="66" HeaderStyle-HorizontalAlign="Center" />
            </Columns>
        </asp:GridView>
    </div>
    <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0">
        <asp:TableRow>
            <asp:TableCell Width="850" HorizontalAlign="Right"><b>Subtotal:</b></asp:TableCell>
            <asp:TableCell Width="66" HorizontalAlign="Right">
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="850" HorizontalAlign="Right"><b>Shipping Amount:</b></asp:TableCell>
            <asp:TableCell Width="66" HorizontalAlign="Right">
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="850" HorizontalAlign="Right"><b>Expedite Fee:</b></asp:TableCell>
            <asp:TableCell Width="66" HorizontalAlign="Right">
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="850" HorizontalAlign="Right"><b>Grand Total:</b></asp:TableCell>
            <asp:TableCell Width="66" HorizontalAlign="Right">
                <asp:Label ID="Label5" runat="server" Text=""></asp:Label></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <p>
        Your order will be shipped via
        <asp:Label ID="Label6" runat="server" Text=""></asp:Label></p>
    <p>
        Ship to:<br />
        <asp:Label ID="Label7" runat="server" Text=""></asp:Label></p>
    <div style="text-align: center; width: 100%;">
        <asp:Button ID="Button1" runat="server" Text="Continue" 
            onclick="Button1_Click" />
    </div>
</asp:Content>

