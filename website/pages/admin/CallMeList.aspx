<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CallMeList.aspx.cs" Inherits="pages_admin_CallMeList" %>

<%@ Register src="../../common/CallMeListUserControl.ascx" tagname="CallMeListUserControl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        
    <uc1:CallMeListUserControl ID="CallMeListUserControl1" runat="server" IsViewDemo="false" />
        
    </form>
</body>
</html>
