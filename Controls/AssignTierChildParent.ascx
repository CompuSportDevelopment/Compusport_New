<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AssignTierChildParent.ascx.cs" Inherits="TrackData_AssignTierChildParent" %>
<div>
     
<div>
    <div style="float: left; padding: 0px; height: 40px; font-size: xx-large; text-align: center; margin-left:20px;">
        <br />
        <b>Assign Athletes Page</b>
        <br />
        <br />
        <br />
        </div>   
        <asp:UpdateProgress ID="Updat_Paymentxyz" runat="server" DisplayAfter="1">
            <ProgressTemplate>
                <div style="text-align: left; position: absolute; top: 25%; left: 50%; margin-left: -70px;">
                    <img src="../image/big_loading.gif" alt="" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress> 
</div>
    <div style="float: left; width: 600px; margin-left:100px; margin-top:50px;">
        <table cellpadding="2" cellspacing="2" border="0" width="100%">
            <tr>
                <td colspan="3" align="left">
                <asp:UpdatePanel runat="server" UpdateMode="Always"> 
                <ContentTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="300px" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Value="noathlete">Select an Athlete</asp:ListItem>
                    </asp:DropDownList>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <%--<tr>
                <td colspan="3" align="left">
                <asp:UpdatePanel runat="server" UpdateMode="Always">
                 <ContentTemplate>
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="300px" AutoPostBack="True"
                        Visible="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                        <asp:ListItem Value="noparent">Select Coach for Athlete</asp:ListItem>
                    </asp:DropDownList>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>--%>
            <tr>
                <td colspan="3" align="left">
                <asp:UpdatePanel runat="server" UpdateMode="Always">
                 <ContentTemplate>
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="300px" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                        <asp:ListItem Value="nodate">Select Facility </asp:ListItem>
                    </asp:DropDownList>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr valign="top">
                <td align="left">
                    <asp:Button ID="btnAddAthleteTier" runat="server" Text="Add" OnClick="btnAddAthleteTier_Click" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <br />
                </td>
            </tr>
        </table>        
    </div>
    
</div>
