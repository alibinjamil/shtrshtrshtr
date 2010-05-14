<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="pages_Products" Title="Simplicity4Business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
	<div class="header">
		<div class="heading"><%=GetBuyOrTry()%> a product</div>
		<div class="noFloat" style="font-weight:bold; padding-top:10px; font-size:1.3em;">Select a product from below to <%=GetBuyOrTry().ToLower()%></div>			
	</div>	
	<div class="productsScreen">
        <asp:Repeater ID="rptProducts" runat="server" DataSourceID="odsProducts">
            <HeaderTemplate>
                <div class="row">
            </HeaderTemplate>
	        <ItemTemplate>
	        <div class='col<%#GetColNumber(DataBinder.Eval(Container, "ItemIndex", ""))%>'>
	            <a href="ProductPrices.aspx?productId=<%# DataBinder.Eval(Container, "DataItem.product_id")%>">
			       <asp:Image ID="imgBtnLogout" runat="server" 
                    ImageUrl='<%# "~/images/Buy_" + DataBinder.Eval(Container, "DataItem.short_name") + ".gif" %>' AlternateText='<%# "Buy " + DataBinder.Eval(Container, "DataItem.name") %>' 
                    onmouseover='<%# GetMouseOver(DataBinder.Eval(Container, "DataItem.short_name"))%>' 
                    onmouseout='<%# GetMouseOut(DataBinder.Eval(Container, "DataItem.short_name")) %>'/></a>
            </div>
	        </ItemTemplate>
	        <SeparatorTemplate>
	            <%#GetSeperatorHTML(DataBinder.Eval(Container, "ItemIndex", ""))%>
	        </SeparatorTemplate>
	        <FooterTemplate>
	            </div>
	        </FooterTemplate>	    
	    </asp:Repeater>
	    <div class="noFloat" style="height:20px;">
            <asp:ObjectDataSource ID="odsProducts" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllProducts" 
                TypeName="ProductsTableAdapters.ProductTableAdapter"></asp:ObjectDataSource>
        </div>
	</div>	
	<div id="dialog" style="padding:0px;" title="Prices"></div>
</asp:Content>

