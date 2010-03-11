<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="ConfirmMail.aspx.cs" Inherits="pages_ConfirmMail" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
<div style="text-align:right">
    <asp:ImageButton ID="btnContinue" ImageUrl="../images/Continue.gif" runat="server" onclick="btnSave_Click" onmouseover="this.src='../images/Continue_rollover.gif'" onmouseout="this.src='../images/Continue.gif'"/>
</div>
</asp:Content>

