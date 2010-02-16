<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="ViewDemo.aspx.cs" Inherits="pages_ViewDemo" Title="Untitled Page" %>


<%@ Register src="../common/CallMePageUserControl.ascx" tagname="CallMePageUserControl" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <uc1:CallMePageUserControl ID="CallMePageUserControl1" runat="server" ViewDemo="true" PageName="View Demo" />

</asp:Content>

