<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="ConfirmCheckout.aspx.cs" Inherits="pages_ConfirmCheckout" Title="Simplicity4Business" %>
<%@ Register src="~/common/CheckBox.ascx" tagname="CheckBox" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../js/CheckBox.js" type="text/javascript"></script>
<script type="text/javascript">    
function openWindow(url)
{
	window.open(url, "Simplicity", "width=820,height=620,location=no,toolbar=no,scrollbars=yes,status=no,resizable=1");
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHead" Runat="Server">
    <div class="breadcrumps">
			<a href="#">Trolley ></a>
			<a href="#">Billing &amp; Shipping Information ></a>
			<a class="current" href="#">Confirm Checkout ></a>			
			<a href="#">Payment Details ></a>
		</div>
		
		<div class="header">
			<div class="heading">Confirm Checkout</div>
			<div class="noFloat"></div>
		</div>		
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
            <div class="confirmCheckout">
			
			<asp:Repeater ID="rptItems" runat="server">
			    <HeaderTemplate><div class="orderSummary">Order Summary</div>
			    </HeaderTemplate>
			    <ItemTemplate>
			        <div class="row">
                        <div class="col1"><%# DataBinder.Eval(Container, "DataItem.Quantity") %> x <%# DataBinder.Eval(Container, "DataItem.Product.name") %>&nbsp;<%#DataBinder.Eval(Container, "DataItem.ProductVersion.name")%>&nbsp;<%# DataBinder.Eval(Container, "DataItem.ProductDetail.product_detail")%> for <%# DataBinder.Eval(Container, "DataItem.DurationString") %></div>
                        <div class="col2"><%# ShoppingCart.GetCurrentCurrency().html_currency_code%><%# DataBinder.Eval(Container, "DataItem.Total", "{0:N2}")%></div>
			            <div style="clear:both;"></div>
			        </div>
			        <div class="terms">
				        <div><a href="<%# "javascript: openWindow('" + DataBinder.Eval(Container, "DataItem.Product.terms_url") + "');" %>" style="color:black;">Terms & Conditions</a></div>
                        <uc1:CheckBox ID="cbTerms" runat="server" Style="padding-top:5px;" Text="Please tick to confirm that you have read the terms & conditions" Selected="false"/>				        
				        <div class="noFloat"/>
			        </div>
			        <div class="row">
			            <hr />
			        </div>
			    </ItemTemplate>
			</asp:Repeater>
		</div>

		<div class="noFloat" style="padding-top:15px;">
			<div>
                <asp:Label ID="paymentMsg" Font-Bold="false" Font-Italic="true" runat="server" Text="Label"></asp:Label>
                <hr/></div>
			<div class="floatRight">
			    <a href="Trolley.aspx">
			        <asp:Image ID="imgTrolley" runat="server" AlternateText="Cancel"
			        ImageUrl="~/images/Cancel.gif" onmouseover="this.src='../images/Cancel_rollover.gif'" 
                    onmouseout="this.src='../images/Cancel.gif'" />
			    </a>
                
			    
				<asp:ImageButton ID="btnCheckout" runat="server" 
                    ImageUrl="~/images/Confirm.gif" AlternateText="Confirm Payment" 
                    onmouseover="this.src='../images/Confirm_rollover.gif'" 
                    onmouseout="this.src='../images/Confirm.gif'" onclick="btnCheckout_Click" />
			</div>			
			
		</div>


		<div class="noFloat" style="padding-top:30px;">
			<img src="../images/paymentOptions.png"/>
		</div>
		
					
                
        

            

</asp:Content>



