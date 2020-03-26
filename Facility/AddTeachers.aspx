<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true"
    CodeFile="AddTeachers.aspx.cs" Inherits="Facility_AddTeachers" Title="SwingModel - Add/Edit/Delete Teachers" %>

<%@ Register Src="~/Controls/FacilityMenu.ascx" TagName="FacilityMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="submenu">
        <uc1:FacilityMenu ID="FacilityMenu1" runat="server" />
    </div>
    <p class="pagetitle">
        Create/Edit
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        Teachers
    </p>
    <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" OnRowCommand="GridView1_RowCommand"
        OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <%--<cs:ConfirmButtonField ItemStyle-Width="70" ItemStyle-HorizontalAlign="Center" ButtonType="Link" Text="Delete" CommandName="DeleteRow" />--%>
            <%--<asp:ButtonField ItemStyle-Width="70" ItemStyle-HorizontalAlign="Center" ButtonType="Button" CommandName="DeleteRow" Text="Delete" />--%>
            <%-- <asp:ButtonField ItemStyle-Width="70" ItemStyle-HorizontalAlign="Center" ButtonType="Link" CommandName="DeleteRow" Text="Delete" />
            <asp:ButtonField ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center" ButtonType="Link" CommandName="EditRow" Text="Edit" />--%>
            <asp:TemplateField ItemStyle-Width="70" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" CommandArgument='<%# Eval("TeacherLocationId") %>'
                        CommandName="DeleteRow" runat="server">Delete</asp:LinkButton>
                    <asp:HiddenField ID="hfRole" runat="server" Value='<%# Eval("Roles") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="70" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" CommandArgument='<%# Eval("TeacherId") %>' CommandName="EditRow"
                        runat="server">Edit</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TeacherId" HeaderText="TeacherId" Visible="false" />
            <asp:BoundField ItemStyle-Width="150" DataField="First Name" HeaderText="First Name" />
            <asp:BoundField ItemStyle-Width="150" DataField="Last Name" HeaderText="Last Name" />
            <%--<asp:BoundField ItemStyle-Width="150" DataField="Work Phone" HeaderText="Work Phone" />--%>
            <asp:BoundField ItemStyle-Width="100" DataField="Roles" HeaderText="Roles" />
            <asp:BoundField ItemStyle-Width="150" DataField="Mobile Phone" HeaderText="Mobile Phone" />
            <asp:BoundField ItemStyle-Width="150" DataField="Fax" HeaderText="Fax" Visible="false" />
            <asp:BoundField DataField="AspNetMembershipUserId" HeaderText="AspNetMembershipUserId"
                Visible="false" />
            <asp:BoundField DataField="Picture Path" HeaderText="Picture Path" Visible="false" />
            <asp:BoundField DataField="Bio Text" HeaderText="Bio Text" Visible="false" />
            <asp:BoundField DataField="Welcome Text" HeaderText="Welcome Text" Visible="false" />
            <asp:BoundField ItemStyle-Width="170" DataField="Teaching Password" HeaderText="Teaching Password" />
            <asp:BoundField DataField="TeacherLocationId" HeaderText="TeacherLocationId" Visible="false" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Table ID="Table1" runat="server" Width="840px" Height="700px">
        <asp:TableRow>
            <asp:TableCell Width="500px" HorizontalAlign="Center" VerticalAlign="Top">
                <p class="pagetitle">
                    Add
                    <% =Label1.Text %>
                    Teachers
                </p>
                <p style="text-align: justify; width: 450px;">
                    Enter the name or initials of the Member you would like to add as a Teacher. A minimum
                    of the first letter of each name is required.</p>
                <asp:Label ID="Label4" runat="server" Text="First Name:" Font-Bold="True" Width="120px"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Width="220px"></asp:TextBox>
                <br />
                <asp:Label ID="Label5" runat="server" Text="Last Name:" Font-Bold="True" Width="120px"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" Width="220px"></asp:TextBox>
                <%--
                <br />
                <asp:Label ID="Label3" runat="server" Text="Email Address:" Font-Bold="True" Width="120px"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" Width="220px"></asp:TextBox>
                --%>
                <br />
                <div style="text-align: left; margin-left: 100px;">
                    <br />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
                </div>
                <br />
                <br />
                <p style="text-align: justify; width: 450px;">
                    Select the member in the list below, and then click the Add button, to add them
                    as a
                    <% =Label1.Text %>
                    Teacher.</p>
                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:ListBox ID="ListBox1" runat="server" Height="200px" Width="450px" SelectionMode="Single"
                            OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
            </asp:TableCell>
            <asp:TableCell VerticalAlign="Top">
                <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ListBox1" EventName="SelectedIndexChanged" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:Label ID="Label8" runat="server" Text="Username: " Font-Bold="True" Width="130px">
                        </asp:Label>
                        <asp:Label ID="Label9" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label44" runat="server" Text="First Name: " Font-Bold="True" Width="130px">
                        </asp:Label>
                        <asp:Label ID="Label45" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label46" runat="server" Text="Last Name: " Font-Bold="True" Width="130px">
                        </asp:Label>
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
                        <br />
                        <br />
                        <div style="text-align: center;">
                            <asp:Button ID="Button2" runat="server" Text="Add" OnClick="Button2_Click" Width="70px" />
                        </div>
                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
