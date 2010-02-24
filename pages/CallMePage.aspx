<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="CallMePage.aspx.cs" Inherits="trunk_pages_CallMePage" Title="Simplicity4Business" %>

<%@ Register src="../common/CallMePageUserControl.ascx" tagname="CallMePageUserControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <uc1:CallMePageUserControl ID="CallMePageUserControl1" runat="server" PageName="Call Me Back" ViewDemo="false"/>
    
</asp:Content>

