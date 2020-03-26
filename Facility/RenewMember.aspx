<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="RenewMember.aspx.cs" Inherits="Facility_RenewMember" Title="CompuSport – Facility Renew Members" %>
<%@ Register Src="~/Controls/FacilityMenu.ascx" TagName="FacilityMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="submenu">
        <uc1:FacilityMenu ID="FacilityMenu1" runat="server" />
    </div>
    <p class="pagetitle">Renew Members
     <asp:UpdateProgress ID="Updat_Paymentxyz" runat="server" DisplayAfter="1">
            <ProgressTemplate>
                <div style="text-align: left; position: absolute; top: 45%; left: 30%;">
                    <img src="../images/big_loading.gif" alt="" width="70px" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </p>
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell Width="500px" HorizontalAlign="Center">
                <p style="text-align: justify; width: 450px;">This page may be used to renew any member that lists your facility
                    as their Home CompuSport Facility. Any member whose membership is expired, or expires less than one year
                    from today, may be renewed. The annual membership fee will be billed to your facility.</p>
                <p style="text-align: justify; width: 450px;">Enter the name or initials of the member you would like to find.
                    A minimum of the first letter of each name is required.</p>
                <asp:Label ID="Label1" runat="server" Text="First Name:" Font-Bold="True" Width="120px"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Width="220px"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Last Name:" Font-Bold="True" Width="120px"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" Width="220px"></asp:TextBox>
                <div style="text-align:left; margin-left:100px;">
				<br />
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" />
				</div>
                <%--
                <br />
                <asp:Label ID="Label3" runat="server" Text="Email Address:" Font-Bold="True" Width="120px"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" Width="220px"></asp:TextBox>
                --%>
                <br /><br />
                <br />
                <br />
                <p style="text-align: justify; width: 450px;">Click on the member in the list below to view their account information.</p>
                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <Triggers>
                        <asp:AsyncPostBackTrigger controlid="Button1" eventname="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:ListBox ID="ListBox1" runat="server" Height="200px" Width="450px" 
                            SelectionMode="Single" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="true">
                        </asp:ListBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
            </asp:TableCell>
            <asp:TableCell VerticalAlign="Top">
                <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                    <Triggers>
                        <asp:AsyncPostBackTrigger controlid="ListBox1" eventname="SelectedIndexChanged" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:Label ID="Label8" runat="server" Text="Username: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label9" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="First Name: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Last Name: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label7" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label10" runat="server" Text="Email: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label11" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label12" runat="server" Text="Address: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label13" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label14" runat="server" Text="Address: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label15" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label16" runat="server" Text="City: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label17" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label18" runat="server" Text="State/Province: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label19" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label20" runat="server" Text="Postal Code: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label21" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label22" runat="server" Text="Country: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label23" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label24" runat="server" Text="Home Phone: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label25" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label26" runat="server" Text="Work Phone: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label27" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label28" runat="server" Text="Mobile Phone: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label29" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label30" runat="server" Text="Fax: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label31" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label32" runat="server" Text="Home Facility: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label33" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label34" runat="server" Text="Teacher: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label35" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label36" runat="server" Text="Initiation: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label37" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label38" runat="server" Text="Expiration: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label39" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label40" runat="server" Text="Status: " Font-Bold="True" Width="130px"></asp:Label>
                        <asp:Label ID="Label41" runat="server"></asp:Label>
                        <br /><br />
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked="false" Enabled="false" />
                        <b><font color="maroon">By checking the box and clicking the Renew Member button I acknowledge that my facility will be billed the selected member's renewal fee.</font></b>
                        <br /><br />
                        <div style="text-align: center;">
                            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Renew Member" Enabled="false" />
                        </div>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

