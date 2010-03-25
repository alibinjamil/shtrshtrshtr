<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageEmails.aspx.cs" Inherits="pages_admin_ManageEmails"  ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>Name: &nbsp; 
            <asp:TextBox ID="tbName" runat="server" ontextchanged="TextBox2_TextChanged" 
                Width="276px"></asp:TextBox>
            <br />
            Subject:             <asp:TextBox ID="tbSubject" runat="server" ontextchanged="TextBox2_TextChanged" 
                Width="276px"></asp:TextBox>
            <br />
            <asp:Button ID="Button3" runat="server" onclick="ButtonLoad_Click" 
                Text="Load" />
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Update" />
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="View" />
        </div>
        <div>
            <asp:TextBox ID="tbHtml" runat="server" Columns="150" Rows="30" 
                TextMode="MultiLine"></asp:TextBox>
            
        </div>
    </div>
    </form>
</body>
</html>
