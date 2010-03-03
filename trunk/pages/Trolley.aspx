<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="Trolley.aspx.cs" Inherits="pages_Trolley" Title="Simplicity4Business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHead" runat="server">
        <div class="header">
			<div class="heading">Trolley</div>
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
	

		<div class="trolleyActionBar">
			<div class="floatLeft" style="background-image:url(../images/blueBar.png);width:930px">
				<div class="floatLeft"><img src="../images/leftRoundBlue.png"/></div>
				<div class="floatRight"><img src="../images/rightRoundBlue.png"/></div>
				<div class="trolleyActionsHeaders trolleyActionsHeader1">ACTIONS</div>
				<div class="trolleyActionsHeaders trolleyActionsHeader2">DESCRIPTIONS</div>
				<div class="trolleyActionsHeaders trolleyActionsHeader3">QTY</div>
				<div class="trolleyActionsHeaders trolleyActionsHeader4">PRICE</div>
				<div class="trolleyActionsHeaders trolleyActionsHeader5">TOTAL</div>
			</div>
			<div class="noFloat"></div>
		</div>	
        <asp:Repeater ID="rptItems" runat="server" onitemcommand="rptItems_ItemCommand">
        <ItemTemplate>
		<div class="trolleyActions">
			<div class="floatLeft" style="width:19px;">&nbsp;</div>
			<div class="trolleyActionsCol1" style="margin-top:20px;">
				<div class="trolleyCell">
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Save" CommandArgument='<%#DataBinder.Eval(Container, "ItemIndex", "")%>'>Save For Later</asp:LinkButton></div>
				<div class="trolleyCell"><asp:LinkButton ID="LinkButton2" runat="server" CommandName="Remove" CommandArgument='<%#DataBinder.Eval(Container, "ItemIndex", "")%>'>Remove</asp:LinkButton></div>
			</div>		
			<div class="trolleyActionsCol2">
				<div class="floatLeft">
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/images/" + DataBinder.Eval(Container, "DataItem.Product.short_name") + "_man.png" %>' AlternateText='<%# DataBinder.Eval(Container, "DataItem.Product.name") %>'/></div>
				<div class="floatLeft" style="margin-top:20px;">
				<div class="trolleyCell"><asp:Image ID="Image2" runat="server" ImageUrl='<%# "~/images/" + DataBinder.Eval(Container, "DataItem.Product.short_name") + "_logo.png" %>' AlternateText='<%# DataBinder.Eval(Container, "DataItem.Product.name") %>'/></div>
				<div class="trolleyCell"><%# DataBinder.Eval(Container, "DataItem.Product.name")%> (<%# DataBinder.Eval(Container, "DataItem.DurationString")%>)</div>		
				</div>		
			</div>
			<div class="trolleyActionsCol3">
				<div class="trolleyCell" style="margin-top:20px;">
					<asp:TextBox ID="txtQty" runat="server" Width="25px" Text='<%# DataBinder.Eval(Container, "DataItem.Quantity")%>' AutoPostBack="True" OnTextChanged="txtQty_OnTextChanged" EnableViewState="False" ></asp:TextBox>
				</div>
			</div>		
			<div class="trolleyActionsCol4">
				<div id= "" class="trolleyCell" style="margin-top:20px;">
				<%# DataBinder.Eval(Container, "DataItem.Currency")%>
				<asp:Label ID='unitPrice' runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Price")%>' ></asp:Label>
				</div>
			</div>		
			<div class="trolleyActionsCol5">
				<div class="trolleyCell" style="margin-top:20px;">
				<%# DataBinder.Eval(Container, "DataItem.Currency")%>
				
                    <asp:Label ID='totalPrice' runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Total")%>'></asp:Label>
			</div>		
			<div class="noFloat"></div>
            
		</div>
		<div class="noFloat" style="padding-bottom:7em;width:925px"><hr/></div>
		</ItemTemplate>
		</asp:Repeater>
		
		<div class="noFloat">
			<div class="floatRight">
    				<asp:ImageButton ID="imbBtnContinue" runat="server" 
                    ImageUrl="~/images/Continue.gif" 
                    onmouseover="this.src='../images/Continue_rollover.gif'" 
                    onmouseout="this.src='../images/Continue.gif'" 
                    onclick="imbBtnContinue_Click"/>
			&nbsp;<asp:ImageButton ID="imbBtnCheckout" runat="server" 
                    ImageUrl="~/images/Checkout.gif" 
                    onmouseover="this.src='../images/Checkout_rollover.gif'" 
                    onmouseout="this.src='../images/Checkout.gif'" onclick="imbBtnCheckout_Click"/>
			</div>
		</div>
	</asp:Content>


