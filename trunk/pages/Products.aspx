<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="pages_Products" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../css/jquery/jquery-ui-1.7.2.custom.css" />
    <script type="text/javascript" src="../js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui-1.7.2.custom.min.js"></script>
    <script type="text/javascript">
    function loadPrices(product)
    {
        $('#dialog').load('Prices.aspx?productId='+product);   
        jQuery("#dialog").dialog('open');        
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
	<div class="header">
		<div class="heading">BUY a product</div>
		<div class="noFloat" style="font-weight:bold; padding-top:10px; font-size:1.3em;">Select a product from below to buy</div>			
	</div>	
	<div class="productsScreen">
        <asp:Repeater ID="rptProducts" runat="server" DataSourceID="odsProducts">
            <HeaderTemplate>
                <div class="row">
            </HeaderTemplate>
	        <ItemTemplate>
	        <div class='col<%#GetColNumber(DataBinder.Eval(Container, "ItemIndex", ""))%>'>
	            <a href="#" onclick='loadPrices(<%# DataBinder.Eval(Container, "DataItem.ProductId") %>); return false'>
			       <asp:Image ID="imgBtnLogout" runat="server" 
                    ImageUrl='<%# "~/images/Buy_" + DataBinder.Eval(Container, "DataItem.ShortName") + ".gif" %>' AlternateText='<%# "Buy " + DataBinder.Eval(Container, "DataItem.Name") %>' 
                    onmouseover='<%# GetMouseOver(DataBinder.Eval(Container, "DataItem.ShortName"))%>' 
                    onmouseout='<%# GetMouseOut(DataBinder.Eval(Container, "DataItem.ShortName")) %>'/></a>
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

<script type="text/javascript">
  jQuery(document).ready(function() {
    jQuery("#dialog").dialog({
      bgiframe: true, autoOpen: false, height: 735, width:620, modal: true
    });
  });
</script>

	        
</asp:Content>

