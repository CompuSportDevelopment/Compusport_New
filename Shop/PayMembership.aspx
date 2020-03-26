<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="PayMembership.aspx.cs" Inherits="Shop_PayMembership" Title="SwingModel - Purchase My SwingModel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p class="pagetitle">Purchase My SwingModel Account</p>
    <div id="centeronpage" class="centeronpage">
        <asp:Label ID="Label19" runat="server" Text="Please complete items with * below." Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
        <br />
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label1" runat="server" Text="Username:" Font-Bold="True" Width="140px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:Label ID="Label2" runat="server" Text="" Width="300px"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label3" runat="server" Text="Card First Name:" Font-Bold="True" Width="140px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
                    <asp:Label ID="Label21" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label20" runat="server" Text="Card Last Name:" Font-Bold="True" Width="140px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:TextBox ID="TextBox10" runat="server" Width="200px"></asp:TextBox>
                    <asp:Label ID="Label33" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label4" runat="server" Text="Card Type:" Font-Bold="True" Width="140px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <%--<asp:ListItem Value="AmericanExpress">American Express</asp:ListItem>--%>
                        <asp:ListItem Value="Discover">Discover</asp:ListItem>
                        <asp:ListItem Value="Mastercard">Mastercard</asp:ListItem>
                        <asp:ListItem Value="Visa">Visa</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="Label22" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label5" runat="server" Text="Card Number:" Font-Bold="True" Width="140px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:TextBox ID="TextBox2" runat="server" Rows="16" MaxLength="16" Width="120px"></asp:TextBox>
                    <asp:Label ID="Label23" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label6" runat="server" Text="Expiration:" Font-Bold="True" Width="140px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem Value="0">Month</asp:ListItem>
                        <asp:ListItem Value="01">January (01)</asp:ListItem>
                        <asp:ListItem Value="02">February (02)</asp:ListItem>
                        <asp:ListItem Value="03">March (03)</asp:ListItem>
                        <asp:ListItem Value="04">April (04)</asp:ListItem>
                        <asp:ListItem Value="05">May (05)</asp:ListItem>
                        <asp:ListItem Value="06">June (06)</asp:ListItem>
                        <asp:ListItem Value="07">July (07)</asp:ListItem>
                        <asp:ListItem Value="08">August (08)</asp:ListItem>
                        <asp:ListItem Value="09">September (09)</asp:ListItem>
                        <asp:ListItem Value="10">October (10)</asp:ListItem>
                        <asp:ListItem Value="11">November (11)</asp:ListItem>
                        <asp:ListItem Value="12">December (12)</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownList3" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="Label24" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label7" runat="server" Text="CVV Number:" Font-Bold="True" Width="140px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:TextBox ID="TextBox3" runat="server" Rows="4" MaxLength="4" Width="36px"></asp:TextBox>
                    <asp:Label ID="Label25" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label8" runat="server" Text="Billing Address" Font-Bold="True" Width="140px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:Label ID="Label9" runat="server" Text="" Width="200px"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label10" runat="server" Text="Country:" Font-Bold="True" Width="140px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:DropDownList ID="DropDownList4" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:Label ID="Label26" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label11" runat="server" Text="Address Line 1:" Font-Bold="True" Width="140px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:TextBox ID="TextBox4" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="Label27" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label12" runat="server" Text="Address Line 2:" Font-Bold="True" Width="140px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:TextBox ID="TextBox5" runat="server" Width="300px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label13" runat="server" Text="City:" Font-Bold="True" Width="140px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:TextBox ID="TextBox6" runat="server" Width="200px"></asp:TextBox>
                    <asp:Label ID="Label28" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label14" runat="server" Text="State/Province:" Font-Bold="True" Width="140px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:TextBox ID="TextBox7" runat="server" Width="200px"></asp:TextBox>
                    <asp:DropDownList ID="DropDownList5" runat="server" Visible="false">
                    </asp:DropDownList>
                    <asp:Label ID="Label29" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label15" runat="server" Text="Postal Code:" Font-Bold="True" Width="140px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:TextBox ID="TextBox8" runat="server" Rows="10" MaxLength="10" Width="76px"></asp:TextBox>
                    <asp:Label ID="Label30" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label16" runat="server" Text="Email Address:" Font-Bold="True" Width="140px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:TextBox ID="TextBox9" runat="server" Width="300px"></asp:TextBox>
                    <asp:Label ID="Label31" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label17" runat="server" Text="Amount Charged:" Font-Bold="True" Width="140px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:Label ID="Label18" runat="server" Text="$100.00"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
        <br /><br />
        <asp:Label ID="Label32" runat="server" Text="" Visible="false"></asp:Label>
        <br /><br />
        <asp:Button ID="Button2" runat="server" Text="Continue" Visible="false" 
            onclick="Button2_Click" />
        <br /><br />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/starterssl-ssl-secure.gif" /> 
    </div>
</asp:Content>

