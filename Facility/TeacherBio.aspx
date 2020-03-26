<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true"
    CodeFile="TeacherBio.aspx.cs" Inherits="Teachers_TeacherBio" Title="CompuSport – Facility Coach Profiles"
    ValidateRequest="false" %>

<%@ Register Src="~/Controls/FacilityMenu.ascx" TagName="FacilityMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="JavaScript" type="text/javascript">

        function hideBtton() {
            var fileloadid = document.getElementById("<%=FileUpload1.ClientID%>").value;
            console.log(fileloadid);
            if (fileloadid == "") {
                debugger;
                document.getElementById("buttionid").style.display = 'none';

            }
            else {
                document.getElementById("buttionid").style.display = 'block';
                document.getElementById("divLoading").style.display = 'none';
                document.getElementById("divLoadingMask").style.display = 'none';
                HideLabel();
            }
        }
        function funloder() {
            debugger;
            var fileloadid = document.getElementById("<%=FileUpload1.ClientID%>").value;
            if (fileloadid == "") {
                document.getElementById("divLoading").style.display = 'block';
                document.getElementById("divLoadingMask").style.display = 'block';
            }
            else {
                document.getElementById("divLoading").style.display = 'none';
                document.getElementById("divLoadingMask").style.display = 'none';
            }
            document.getElementById('<%=lblsubnittext.ClientID %>').style.display = "none";
        }
    </script>
    <div class="submenu">
        <uc1:FacilityMenu ID="FacilityMenu1" runat="server" />
    </div>
    <p class="pagetitle">
        Input Coach Profile Information</p>
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>        
            </asp:TableCell>
            <asp:TableCell Width="730" Height="20" VerticalAlign="Middle">
                <asp:Label ID="lblteacher" runat="server" Text="Select the Coach to edit their Profile"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="170" Height="200">
                <asp:Image ID="Image1" runat="server" Width="150" Height="180" />
            </asp:TableCell>
            <asp:TableCell Width="730" Height="200" VerticalAlign="Middle">
                <asp:Label ID="Label1" runat="server" Text="Upload Image: " Font-Bold="True"></asp:Label><br />
                <asp:FileUpload ID="FileUpload1" runat="server" Width="380px" OnClick="funloder()"
                    onchange="hideBtton()" />
                <br />
                <br />
                <div id="buttionid" style="display: none;">
                    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" Width="87px" /><br />
                </div>
                <asp:Label ID="Label5" runat="server" Text="The image is not required, however, if you choose to submit an image, please insure that the image is about 150 pixels wide by 180 pixels tall.  The file formats JPG or PNG are accepted."
                    ForeColor="Red" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="lblsubnittext" runat="server" Text="Your image was successfully saved to the database."
                    Visible="false"></asp:Label>
                <br />
                <asp:Label ID="Label6" runat="server" Text="Once an image has been selected, please click the Submit button to update the image."
                    ForeColor="Red" Visible="false"></asp:Label>
                <asp:Label ID="Label7" runat="server" Text="It may take several minutes for the image to be updated."
                    ForeColor="Red" Visible="false"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Text="" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Welcome Text: " Font-Bold="True"></asp:Label><br />
    <%-- <FTB:FreeTextBox id="FreeTextBox1" AutoGenerateToolbarsFromString="false" Width="920px" Height="250px" runat="Server" /><br />--%>
    <asp:Label ID="LblWelcomeText" runat="server" Text="Welcome to the CompuSport Learning Program. If you haven't taken a look at your
        most recent Session video(s), please visit your 'My Performance' page. There you
        will be able to review the Session videos (Tier 1 athletes), the errors we discussed
        during the Session, as well as a detailed list of all of the Performance Variables
        that we use to determine the quality of your performance. If you'd like to ask questions
        about your Session, click on the Email My Teacher link and send me your questions."
        Visible="false"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Bio Text: " Font-Bold="True"></asp:Label><br />
    <asp:Label ID="lblprimaryCoach" runat="server" Text="As an Elite Coach, I am currently working as the Primary Coach with the following athletes:"
        Visible="false"></asp:Label>
    <br />
    <asp:Label ID="lblprimaryList" runat="server" Text=" My Athlete List:" Visible="false"></asp:Label>
    <br />
    <asp:Label ID="lblerror" runat="server" Text="No Athletes Found..." Visible="false"></asp:Label>
    <div>
        <asp:GridView ID="GridView1" runat="server" Width="263px">
        </asp:GridView>
    </div>
    <br />
    <asp:Label ID="lblSecondryCoach" runat="server" Text="I am currently assisting in the development, or have worked with the following athletes in the past:"
        Visible="false"></asp:Label>
    <br />
    <asp:Label ID="lblSecondaryList" runat="server" Text=" My Athlete List:" Visible="false"></asp:Label>
    <br />
    <asp:Label ID="lblerror1" runat="server" Text="No Athletes Found..." Visible="false"></asp:Label>
    <asp:GridView ID="GridView2" runat="server" Width="262px">
    </asp:GridView>
  <div id="divLoading" style="position: fixed; right: 0px; top: 0%; z-index: 9999;
        margin-right: 0px; display: none;">
        <img src="../Images/loading.gif" alt="" height="80" width="80" />
    </div>
    <div id="divLoadingMask" style="position: fixed; background-color: #000000; display: none;
        opacity: 0.7; filter: alpha(opacity=70); left: 0px; top: 0px; right: 0px; bottom: 0px;
        z-index: 1000;">
    </div>
</asp:Content>
