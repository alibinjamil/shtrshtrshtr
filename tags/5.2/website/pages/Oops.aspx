<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="Oops.aspx.cs" Inherits="pages_Oops" Title="Simplicity4Business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
        <div>An unexpected error has occured on our website. The website administrator has been notified.</div>
    <div>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/pages/UserHome.aspx">Return to Home Page</asp:HyperLink></div>

</asp:Content>

