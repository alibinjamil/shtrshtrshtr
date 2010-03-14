<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="Trolley.aspx.cs" Inherits="pages_Trolley" Title="Simplicity4Business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHead" runat="server">
        <div class="header">
			<div class="heading">Trolley</div>
			<div class="headingImages">
				<asp:ImageButton ID="Sterling" runat="server" 
                    onmouseover="this.src='../images/Sterling_rollover.gif'" onmouseout="this.src='../images/Sterling.gif'"
                    ImageUrl="~/images/Sterling.gif" onclick="Sterling_Click" />
                &nbsp;    
                <asp:ImageButton ID="Euro" runat="server" 
                    onmouseover="this.src='../images/Euro_rollover.gif'" onmouseout="this.src='../images/Euro.gif'"
                    ImageUrl="~/images/Euro.gif" onclick="Euro_Click" />
                &nbsp;    
                <asp:ImageButton ID="Dollar" runat="server" 
                    onmouseover="this.src='../images/Dollar_rollover.gif'" onmouseout="this.src='../images/Dollar.gif'"
                    ImageUrl="~/images/Dollar.gif" onclick="Dollar_Click" />
			    
			</div>	
			<div class="noFloat"></div>
		</div>	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
	

        <asp:Repeater ID="rptItems" runat="server" onitemcommand="rptItems_ItemCommand">
        <HeaderTemplate>
		<div class="trolleyActionBar">
			<div class="floatLeft" style="background-image:url(../images/blueBar.png);width:930px">
				<div class="floatLeft"><img src="../images/leftRoundBlue.png"/></div>
				<div class="floatRight"><img src="../images/rightRoundBlue.png"/></div>
				<div class="trolleyActionsHeaders trolleyActionsHeader1">Actions</div>
				<div class="trolleyActionsHeaders trolleyActionsHeader2">Description</div>
				<div class="trolleyActionsHeaders trolleyActionsHeader3">No. of License(s)</div>
				<div class="trolleyActionsHeaders trolleyActionsHeader4">Price</div>
				<div class="trolleyActionsHeaders trolleyActionsHeader5">Total</div>
			</div>
			<div class="noFloat"></div>
		</div>	
        
        </HeaderTemplate>
        <ItemTemplate>
		<div class="trolleyActions">
			<div class="floatLeft" style="width:19px;">&nbsp;</div>
			<div class="trolleyActionsCol1" >
				<div class="trolleyCell">
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Save" CommandArgument='<%#DataBinder.Eval(Container, "ItemIndex", "")%>'>Save For Later</asp:LinkButton></div>
				<div class="trolleyCell"><asp:LinkButton ID="LinkButton2" runat="server" CommandName="Remove" CommandArgument='<%#DataBinder.Eval(Container, "ItemIndex", "")%>'>Remove</asp:LinkButton></div>
			</div>		
			<div class="trolleyActionsCol2">
				<div class="floatLeft">
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/images/" + DataBinder.Eval(Container, "DataItem.Product.short_name") + "_man.png" %>' AlternateText='<%# DataBinder.Eval(Container, "DataItem.Product.name") %>'/></div>
				<div class="floatLeft" >
				    <div class="trolleyCell"><asp:Image ID="Image2" runat="server" ImageUrl='<%# "~/images/" + DataBinder.Eval(Container, "DataItem.Product.short_name") + "_logo.png" %>' AlternateText='<%# DataBinder.Eval(Container, "DataItem.Product.name") %>'/></div>
				    <div class="trolleyCell"><%# DataBinder.Eval(Container, "DataItem.Product.name")%> [<%# DataBinder.Eval(Container, "DataItem.DurationString")%>]</div>		
				    <div class="trolleyCell"><%# DataBinder.Eval(Container, "DataItem.ProductVersion.name")%></div>		
				    <div class="trolleyCell"><%# DataBinder.Eval(Container, "DataItem.ProductDetail.product_detail")%></div>		
				</div>		
			</div>
			<div class="trolleyActionsCol3">
				<div class="trolleyCell" >
					<asp:TextBox ID="txtQty" runat="server" Width="25px" Text='<%# DataBinder.Eval(Container, "DataItem.Quantity")%>' AutoPostBack="True" OnTextChanged="txtQty_OnTextChanged" EnableViewState="False" ></asp:TextBox>
				</div>
			</div>		
			<div class="trolleyActionsCol4">
				<div id="" class="trolleyCell" >
				<%# ShoppingCart.GetCurrentCurrency().html_currency_code%><asp:Label ID='unitPrice' runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Price","{0:N2}")%>' ></asp:Label>
				</div>
			</div>		
			<div class="trolleyActionsCol5">
				<div class="trolleyCell" >
				<%# ShoppingCart.GetCurrentCurrency().html_currency_code%><asp:Label ID='totalPrice' runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Total","{0:N2}")%>'></asp:Label>
                </div>
			</div>		
			<div class="noFloat"></div>            
		</div>
		<div class="noFloat" style="padding-bottom:5px;width:925px"><hr/></div>
		</ItemTemplate>
		<FooterTemplate>
		</FooterTemplate>
		</asp:Repeater>
		<div class="trolleyActions">
			<div class="floatLeft" style="width:19px;">&nbsp;</div>
			<div class="trolleyFooterCol1">
			    <%="Charge each month from " + DateTime.Now.AddDays(1).ToShortDateString() + " till " + DateTime.Now.AddDays(1).AddMonths(12).ToShortDateString() %>
			    &nbsp;&nbsp;&nbsp;
			    <%= ShoppingCart.GetCurrentCurrency().html_currency_code%><%= String.Format("{0:N2}",ShoppingCart.GetTotalAmount())%>
			    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			</div>		
			<div class="noFloat"></div>            
		</div>
		<div class="noFloat" style="padding-bottom:5px;width:925px"><hr/></div>		
		
		<div class="noFloat">
			<div class="floatRight">
    				<asp:ImageButton ID="imbBtnContinue" runat="server" 
                    ImageUrl="~/images/Continue_shopping.gif" 
                    onmouseover="this.src='../images/Continue_shopping_rollover.gif'" 
                    onmouseout="this.src='../images/Continue_shopping.gif'" 
                    onclick="imbBtnContinue_Click"/>
			&nbsp;<asp:ImageButton ID="imbBtnCheckout" runat="server" 
                    ImageUrl="~/images/Checkout.gif" 
                    onmouseover="this.src='../images/Checkout_rollover.gif'" 
                    onmouseout="this.src='../images/Checkout.gif'" onclick="imbBtnCheckout_Click"/>
			</div>
		</div>
	</asp:Content>


