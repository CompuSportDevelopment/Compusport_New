<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="ClubOrder.aspx.cs" Inherits="Shop_ClubOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p class="pagetitle">Complete Club Order</p>
    <p>
        Please review the clubs you selected for purchase below. If the order is correct, please complete
        the credit card payment form, and submit the order. If you wish to add or delete clubs from your
        order please click on the Back to My Clubfitting button.</p>
    <div style="float: left; margin: 0px; padding: 0px; width: 100%; height: 40px; text-align: center;">
        <input type="button" value="Back to My Clubfitting" onClick="javascript: history.go(-1)">
    </div>
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
    <div style="float: left; width: 850px; text-align: right;">
        <asp:Label ID="Label1" runat="server" Text="Subtotal: " Font-Bold="True" Font-Names="Trebuchet MS" Font-Size="Medium"></asp:Label>
    </div>
    <div style="float: left; width: 66px; text-align: right;">
        <asp:Label ID="Label2" runat="server" Text="$0.00" Font-Names="Trebuchet MS" Font-Size="Medium"></asp:Label>
    </div>
    <p class="pagetitle">Credit Card Payment Form</p>
    <asp:Label ID="Label45" runat="server" Text="Please complete fields with * below." Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
    <br />
    <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0" Width="100%">
        <asp:TableRow>
            <asp:TableCell Width="560" VerticalAlign="Top">
                <asp:Table ID="Table2" runat="server" CellPadding="0" CellSpacing="0" Width="560">
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Left" ColumnSpan="2">
                            <asp:Label ID="Label46" runat="server" Text="Credit Card Details" Font-Bold="True"></asp:Label>
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
                        <asp:TableCell HorizontalAlign="Left">
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
                        <asp:TableCell HorizontalAlign="Left">
                            <asp:Label ID="Label17" runat="server" Text="Shipping Address" Font-Bold="True" Width="140px"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Left">
                            <asp:CheckBox ID="CheckBox2" runat="server" Text="same as Billing Address" OnCheckedChanged="CheckBox2_Changed" AutoPostBack="true" Font-Bold="False" Font-Names="Trebuchet MS" Font-Size="Medium" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label19" runat="server" Text="Country:" Font-Bold="True" Width="140px"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Left">
                            <asp:DropDownList ID="DropDownList6" runat="server" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:Label ID="Label32" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label34" runat="server" Text="Address Line 1:" Font-Bold="True" Width="140px"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Left">
                            <asp:TextBox ID="TextBox11" runat="server" Width="300px"></asp:TextBox>
                            <asp:Label ID="Label35" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label36" runat="server" Text="Address Line 2:" Font-Bold="True" Width="140px"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Left">
                            <asp:TextBox ID="TextBox12" runat="server" Width="300px"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label37" runat="server" Text="City:" Font-Bold="True" Width="140px"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Left">
                            <asp:TextBox ID="TextBox13" runat="server" Width="200px"></asp:TextBox>
                            <asp:Label ID="Label38" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label39" runat="server" Text="State/Province:" Font-Bold="True" Width="140px"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Left">
                            <asp:TextBox ID="TextBox14" runat="server" Width="200px"></asp:TextBox>
                            <asp:DropDownList ID="DropDownList7" runat="server" Visible="false">
                            </asp:DropDownList>
                            <asp:Label ID="Label40" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label41" runat="server" Text="Postal Code:" Font-Bold="True" Width="140px"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Left">
                            <asp:TextBox ID="TextBox15" runat="server" Rows="10" MaxLength="10" Width="76px"></asp:TextBox>
                            <asp:Label ID="Label42" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label43" runat="server" Text="Email Address:" Font-Bold="True" Width="140px"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Left">
                            <asp:TextBox ID="TextBox16" runat="server" Width="300px"></asp:TextBox>
                            <asp:Label ID="Label44" runat="server" Text="*" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
            <asp:TableCell Width="372" VerticalAlign="Top">
                <asp:Table ID="Table3" runat="server" CellPadding="0" CellSpacing="0" Width="400">
                    <asp:TableRow>
                        <asp:TableCell Width="372">
                            <div style="float: left; width: 360px;">
                                Once you've completed the Credit Card Details form, please click the
                                Get Shipping Rates button. Click the radio button beside your desired
                                shipping option.
                            </div>
                            <div style="float: left; width: 100%; height: 15px;">&nbsp;</div>
                            <div style="float: left; width: 100%; height: 40px; text-align: center">
                                <asp:Button ID="Button2" runat="server" Text="Get Shipping Rates" Font-Names="Trebuchet MS" onclick="Button2_Click" />
                            </div>
                            <asp:Table ID="Table4" runat="server" Width="356" CellPadding="0" CellSpacing="0">
                                <asp:TableRow>
                                    <asp:TableCell Width="286" VerticalAlign="Top">
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CellPadding="0" CellSpacing="0" OnSelectedIndexChanged="RadioButtonList1_IndexChanged" AutoPostBack="True">
                                            <asp:ListItem Value="1" Enabled="False" Selected="True"><b>FedEx Ground: </b></asp:ListItem>
                                            <asp:ListItem Value="2" Enabled="False"><b>FedEx 2 Day: </b></asp:ListItem>
                                            <asp:ListItem Value="3" Enabled="False"><b>FedEx Standard Overnight: </b></asp:ListItem>
                                            <asp:ListItem Value="4" Enabled="False"><b>FedEx International Priority: </b></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </asp:TableCell>
                                    <asp:TableCell Width="66" HorizontalAlign="Right" VerticalAlign="Top">
                                        <asp:Label ID="Label55" runat="server" Text="" Width="66"></asp:Label><br />
                                        <asp:Label ID="Label56" runat="server" Text="" Width="66"></asp:Label><br />
                                        <asp:Label ID="Label57" runat="server" Text="" Width="66"></asp:Label><br />
                                        <asp:Label ID="Label58" runat="server" Text="" Width="66" Enabled="False"></asp:Label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Height="20">
                        <asp:TableCell Width="372" Height="20">&nbsp;</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Width="372">
                            <div style="float: left; width: 360px;">
                                Typical club order delivery time is 4-6 weeks. The delivery time of your order can be cut to
                                as little as 1 day by using the Expedite my order feature. If the order cannot be shipped
                                within 1 week of the order submission, the expedite fee will be refunded. If you'd like to
                                expedite your order, please click the checkbox below.
                            </div>
                            <div style="float: left; width: 100%; height: 15px;">&nbsp;</div>
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Expedite my order" Width="302" Font-Bold="True" OnCheckedChanged="CheckBox1_Changed" AutoPostBack="True" Enabled="False" />
                            <asp:Label ID="Label48" runat="server" Text="" Enabled="False"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Height="40">
                        <asp:TableCell Width="372" Height="20">&nbsp;</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Width="372" HorizontalAlign="Center">
                            <div style="float: left; width: 290px; text-align: right">
                                <asp:Label ID="Label49" runat="server" Text="Grand Total: " Font-Bold="True"></asp:Label>
                            </div>
                            <div style="float: left; width: 66px; text-align: right">
                                <asp:Label ID="Label50" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Height="20">
                        <asp:TableCell Width="372" Height="20">&nbsp;</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Width="372" HorizontalAlign="Center">
                            <asp:Button ID="Button1" runat="server" Text="Submit Order" Font-Names="Trebuchet MS" Enabled="False" onclick="Button1_Click" />
                            <br /><br />
                            <asp:Label ID="Label47" runat="server" Text="" Visible="false"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

