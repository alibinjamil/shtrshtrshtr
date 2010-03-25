<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CheckBox.ascx.cs" Inherits="common_CheckBox" %>
<div class="<%=CssClass%>" onclick="onCheckboxClick('<%=this.checkImage.ClientID%>','hd_<%=this.ClientID%>');" >						
    <asp:Image ID="checkImage" runat="server" ImageUrl="~/images/checkbox_unchecked.png"/>
	<input type="hidden" name="hd_<%=this.ClientID%>" id="hd_<%=this.ClientID%>" value="<%=Selected%>"/>
	<span><%=Text%></span>
</div>