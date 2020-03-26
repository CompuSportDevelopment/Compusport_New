<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="SummaryPlayer.aspx.cs" Inherits="Teachers_SummaryPlayer" Title="CompuSport – Coach’s Athlete Video Player" %>
<%@ Register Src="~/Controls/TeachersDualPlayer.ascx" TagName="DualPlayer" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/TeachersMenu.ascx" TagName="TeachersMenu" TagPrefix="uc1" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="submenu">
        <uc1:TeachersMenu ID="TeachersMenu1" runat="server" />
    </div>
    
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" />
    <br />
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell Width="50%" HorizontalAlign="Left" CssClass="pagetitle">
                Member Video/Summary Player
            </asp:TableCell>
            <asp:TableCell Width="50%" HorizontalAlign="Right">
                <input type="button" value="Select New Member" onclick="javascript: history.go(-1)";/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="dualplayerdiv" class="dualplayer" runat="server" style="height:1800px; margin-bottom:1250px; width:100%;" >
                <uc2:DualPlayer ID="DualPlayer1" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
--%>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
    
    <script src="../../Scripts/CanvasGraph/canvasjs.js" type="text/javascript"></script>

   <%-- <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>--%>

    

    
    <div class="submenu">
        <%--<uc1:TeachersMenu ID="TeachersMenu1" runat="server" />--%>
         <uc1:TeachersMenu ID="TeachersMenu1" runat="server" />
    </div>
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" />
    <br />
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell Width="50%" HorizontalAlign="Left" CssClass="pagetitle">
                Member Video/Summary Player
            </asp:TableCell>
            <asp:TableCell Width="50%" HorizontalAlign="Right">
                <input type="button" value="Select New Member" onClick="javascript: history.go(-1)"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="dualplayerdiv" class="dualplayer" runat="server" style="height: 4000px;
                margin-bottom: 1500px; width: 100%">
                <uc2:DualPlayer ID="DualPlayer1" runat="server" />
            </div>
        
           
         
        </ContentTemplate>
    </asp:UpdatePanel>


    <script type="text/javascript">

        jQuery.noConflict();
        var $j = jQuery;
        function ShowPopup() {


            var modal = document.getElementById('ShowGraph');
            modal.style.display = "block";
            var span = document.getElementsByClassName("close")[0];
            document.getElementById("appendDiv").style.overflow = "hidden";
            if (document.getElementById("tblvalue") != null) {
                document.getElementById("tblvalue").style.pointerEvents = "none";
            }
            if (document.getElementById("tblstart") != null) {
                document.getElementById("tblstart").style.pointerEvents = "none";
            }
            if (document.getElementById("tblhurdle") != null) {
                document.getElementById("tblhurdle").style.pointerEvents = "none";
            }
            if (document.getElementById("tblstephurdle") != null) {
                document.getElementById("tblstephurdle").style.pointerEvents = "none";
            }

        }
        function OnSuccess(response) {
            debugger;
            // window.open(response, '_blank', 'toolbar=0,location=0,menubar=0');
            if (response.d !== "")
                window.open('../PDF_Folder/' + response.d);
            // window.open("http://localhost/compusport/PDF_Folder/1.pdf");
        }

    </script>

</asp:Content>