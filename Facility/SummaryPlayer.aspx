<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="SummaryPlayer.aspx.cs" Inherits="Teachers_SummaryPlayer" Title="CompuSport – Facility’s Athlete Video Player’" %>
<%@ Register Src="../Controls/TeachersDualPlayer.ascx" TagName="DualPlayer" TagPrefix="uc2" %>
<%--<%@ Register Src="~/Controls/TeachersMenu.ascx" TagName="TeachersMenu" TagPrefix="uc1" %>--%>
<%--<%@ Register Src="~/TrackData/SprintAthlete.ascx" TagName="SprintAthlete" TagPrefix="uc3" %>--%>
<%@ Register Src="~/Controls/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <script type="text/javascript" src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
    
    <script src="../../Scripts/CanvasGraph/canvasjs.js" type="text/javascript"></script>

    <div class="submenu">
        <%--<uc1:TeachersMenu ID="TeachersMenu1" runat="server" />--%>
        <uc1:AdminMenu ID="AdminMenu1" runat="server" />
    </div>
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" />
    <br />
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell Width="50%" HorizontalAlign="Left" CssClass="pagetitle">
                Member Video/Summary Player
            </asp:TableCell>
            <asp:TableCell Width="50%" HorizontalAlign="Right">
                <input type="button" value="Select New Member" onClick="javascript: history.go(-1)">
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="dualplayerdiv" class="dualplayer" runat="server" style="height:1300px; margin-bottom:1500px; width:100%;" >
                <uc2:DualPlayer ID="DualPlayer1" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
     <%--<div style="margin-top:500px; height:1200px;">
                <uc3:SprintAthlete ID="SprintAthlete1" runat="server"  />
    </div>--%>
    
    
    
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
    

    </script>
</asp:Content>
