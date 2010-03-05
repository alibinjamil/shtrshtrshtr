﻿<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="WishList.aspx.cs" Inherits="pages_WishList" Title="Simplicity4Business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHead" Runat="Server">
		<div class="header">
			<div class="heading">Wish List</div>
			<div class="headingImages">
				<asp:ImageButton ID="Sterling" runat="server" BorderWidth="2px" BorderColor="blue"
                    onmouseover="this.src='../images/Sterling_rollover.gif'" onmouseout="this.src='../images/Sterling.gif'"
                    ImageUrl="~/images/Sterling.gif" onclick="Sterling_Click" />
                &nbsp;    
                <asp:ImageButton ID="Euro" runat="server" BorderWidth="2px" BorderColor="blue"
                    onmouseover="this.src='../images/Euro_rollover.gif'" onmouseout="this.src='../images/Euro.gif'"
                    ImageUrl="~/images/Euro.gif" onclick="Euro_Click" />
                &nbsp;    
                <asp:ImageButton ID="Dollar" runat="server" BorderWidth="2px" BorderColor="blue"
                    onmouseover="this.src='../images/Dollar_rollover.gif'" onmouseout="this.src='../images/Dollar.gif'"
                    ImageUrl="~/images/Dollar.gif" onclick="Dollar_Click" />
			</div>	
			<div class="noFloat"></div>
		</div>	
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
		<div class="wishListActionBar">
			<div class="floatLeft" style="background-image:url(../images/blueBar.png);width:930px">
				<div class="floatLeft"><img src="../images/leftRoundBlue.png"/></div>
				<div class="floatRight"><img src="../images/rightRoundBlue.png"/></div>
				<div class="wishListActionsHeaders wishListActionsHeader1">ACTIONS</div>
				<div class="wishListActionsHeaders wishListActionsHeader2">DESCRIPTIONS</div>
				<div class="wishListActionsHeaders wishListActionsHeader3">QTY</div>
				<div class="wishListActionsHeaders wishListActionsHeader4">PRICE</div>
				<div class="wishListActionsHeaders wishListActionsHeader5">TOTAL</div>
			</div>
			<div class="noFloat"></div>
		</div>	
		<asp:Repeater ID="rpt" runat="server" onitemcommand="rptItems_ItemCommand">        			
        <ItemTemplate>
		<div class="wishListActions">
			<div class="floatLeft" style="width:19px;">&nbsp;</div>
			<div class="wishListActionsCol1" style="margin-top:20px;">
				<div class="wishListCell">
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Save" CommandArgument='<%#DataBinder.Eval(Container, "DataItem.WishListItemId")%>'>Add to Trolley</asp:LinkButton></div>
				<div class="wishListCell"><asp:LinkButton ID="LinkButton2" runat="server" CommandName="Remove" CommandArgument='<%#DataBinder.Eval(Container, "DataItem.WishListItemId")%>'>Remove</asp:LinkButton></div>
			</div>		
			<div class="wishListActionsCol2">
				<div class="floatLeft">
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/images/" + DataBinder.Eval(Container, "DataItem.Product.short_name") + "_man.png" %>' AlternateText='<%# DataBinder.Eval(Container, "DataItem.Product.name") %>'/>
                </div>
				<div class="floatLeft" style="margin-top:20px;">
				<div class="wishListCell"><asp:Image ID="Image2" runat="server" ImageUrl='<%# "~/images/" + DataBinder.Eval(Container, "DataItem.Product.short_name") + "_logo.png" %>' AlternateText='<%# DataBinder.Eval(Container, "DataItem.Product.name") %>'/></div>
				<div class="wishListCell"><%# DataBinder.Eval(Container, "DataItem.Product.name")%> (<%# DataBinder.Eval(Container, "DataItem.DurationString")%>)</div>		
				</div>		
			</div>
			<div class="wishListActionsCol3">
				<div class="wishListCell" style="margin-top:20px;">
					<%# DataBinder.Eval(Container, "DataItem.Quantity")%>
				</div>
			</div>		
			<div class="wishListActionsCol4">
				<div class="wishListCell" style="margin-top:20px;">
				<%# DataBinder.Eval(Container, "DataItem.Currency")%>
				<%# DataBinder.Eval(Container, "DataItem.Price")%></div>
			</div>		
			<div class="wishListActionsCol5">
				<div class="wishListCell"style="margin-top:20px;">
				<%# DataBinder.Eval(Container, "DataItem.Currency")%>
				<%# DataBinder.Eval(Container, "DataItem.Total")%></div>
			</div>		
			<div class="noFloat"></div>
		</div>
		<div class="noFloat" style="padding-bottom:7em;width:925px"><hr/></div>
		</ItemTemplate>
		</asp:Repeater>
		
		<div class="noFloat">
			<div class="floatRight">
				<a href="Products.aspx"><img src="../images/Continue_shopping.gif" onmouseover="this.src='../images/Continue_shopping_rollover.gif'" onmouseout="this.src='../images/Continue_shopping.gif'"></a>
				<a href="PaymentDetails.aspx"><img src="../images/Checkout.gif" onmouseover="this.src='../images/Checkout_rollover.gif'" onmouseout="this.src='../images/Checkout.gif'"></a>
			</div>
			<div class="noFloat"></div>
		</div>
		
		<div class="noFloat" style="padding-top:30px;">
			<img src="../images/paymentOptions.png"/>
		</div>
        <div class="noFloat" style="height:15px;"></div>
</asp:Content>

