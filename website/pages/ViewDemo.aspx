﻿<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="ViewDemo.aspx.cs" Inherits="pages_ViewDemo" Title="Simplicity4Business" %>


<%@ Register src="../common/CallMePageUserControl.ascx" tagname="CallMePageUserControl" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="../js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <uc1:CallMePageUserControl ID="CallMePageUserControl1" runat="server" ViewDemo="true" PageName="View Demo" />

</asp:Content>

