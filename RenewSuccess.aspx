<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="RenewSuccess.aspx.cs" Inherits="RenewSuccess" Title="SwingModel - Successful Renewal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width: 50%; float: left;">
        <p class="pagetitle">Successful Renewal</p>
        <p>
            Thank you and welcome back. The charge for your annual membership renewal was 
            successful. You will receive an email with the transaction details.</p>
        <p>
            Your renewal insures continued access to the SwingModel teaching system and your 
            personal account on the website. All of your previous lessons, including your 
            swing videos and teacher summary videos, are available for viewing.</p>
        <p>
            Click the Continue button below to go to the Login page.</p>
        <div class="centeronpage" id="centeronpage">
            <p>
                <asp:Button ID="Button1" runat="server" Text="Continue to Login" 
                    onclick="Button1_Click" /></p>
        </div>
    </div>
    <div style="width: 50%; float: left;">
        <div class="centeronpage" id="Div1">
        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,16,0"
            width="400" height="300" id="WMP1">
            <param name="movie" value="http://www.swingmodel.com/Images/ModelSide.swf">
            <param name="quality" value="high">
            <param name="play" value="true">
            <param name="loop" value="true">
            <param name="wmode" value="transparent">
            <embed id="WMP1" src="http://www.swingmodel.com/Images/ModelSide.swf" width="400" height="300" play="true" loop="true"
                quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"
                wmode="transparent"></embed>
        </object>
        </div>
    </div>
</asp:Content>

