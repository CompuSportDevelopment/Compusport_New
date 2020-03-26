<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BodyDimensions.ascx.cs" Inherits="TrackData_BodyDimensions" %>

<div style="float: left; padding: 0px; width: 600px; height: 40px; font-size: xx-large; text-align: center;"><b>Athlete Body Dimensions</b></div>
<div style="float: left; width: 600px; text-align: center;">
    <asp:DropDownList ID="DropDownList1" runat="server" Width="220px" 
        AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Value="noathlete">Select an Athlete</asp:ListItem>
    </asp:DropDownList>
    <br /><br />
    <asp:Label ID="Label1" runat="server" Text="Height:" Width="140px"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Width="60px"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Waist:" Width="140px"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" Width="60px"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Hip Height:" Width="140px"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server" Width="60px"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Upper Leg Length:" Width="140px"></asp:Label>
    <asp:TextBox ID="TextBox4" runat="server" Width="60px"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Lower Leg Length:" Width="140px"></asp:Label>
    <asp:TextBox ID="TextBox5" runat="server" Width="60px"></asp:TextBox>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Ankle Height:" Width="140px"></asp:Label>
    <asp:TextBox ID="TextBox6" runat="server" Width="60px"></asp:TextBox>
    <br />
    <asp:Label ID="Label7" runat="server" Text="Shoe Size:" Width="140px"></asp:Label>
    <asp:TextBox ID="TextBox7" runat="server" Width="60px"></asp:TextBox>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Trunk Length:" Width="140px"></asp:Label>
    <asp:TextBox ID="TextBox8" runat="server" Width="60px"></asp:TextBox>
    <br />
    <asp:Label ID="Label9" runat="server" Text="Upper Arm Length:" Width="140px"></asp:Label>
    <asp:TextBox ID="TextBox9" runat="server" Width="60px"></asp:TextBox>
    <br />
    <asp:Label ID="Label10" runat="server" Text="Lower Arm Length:" Width="140px"></asp:Label>
    <asp:TextBox ID="TextBox10" runat="server" Width="60px"></asp:TextBox>
    <br />
    <asp:Label ID="Label11" runat="server" Text="Shoulder Width:" Width="140px"></asp:Label>
    <asp:TextBox ID="TextBox11" runat="server" Width="60px"></asp:TextBox>
    <br />
    <asp:Label ID="Label12" runat="server" Text="Enter Velocity As:" Width="140px"></asp:Label>
    <asp:TextBox ID="TextBox12" runat="server" Width="60px"></asp:TextBox>
    <br />
    <asp:Label ID="Label13" runat="server" Text="Enter Start Velocity As:" Width="140px"></asp:Label>
    <asp:TextBox ID="TextBox13" runat="server" Width="60px"></asp:TextBox>
    <br /><br />
    <asp:Button ID="Submit" runat="server" Text="Button" onclick="Button1_Click" />
</div>