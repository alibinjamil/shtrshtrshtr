<%@ Page Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="pages_UserHome" Title="Simplicity4Business" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HomeContent" Runat="Server">
	<object classid="clsid:D697CDE7E-AE6D-11cf-96B8-458453540000"
            codebase="http://active.macromedia.com/flash4/cabs/swflash.cab#version=4,0,0,0"
            id="animation name" width="750" height="340">
        <param name="movie" value="../images/Movie_flash_page.swf"/>
        <param name="quality" value="high"/>
        <param name="bgcolor" value="#FFFFFF"/>
        <embed name="Simplicity" src="../images/Movie_flash_page.swf" quality="high" bgcolor="#FFFFFF"
            width="750px" height="440px" type="application/x-shockwave-flash"
            pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash">
        </embed>
    </object>
</asp:Content>

