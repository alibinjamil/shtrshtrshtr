<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="PaymentDetails.aspx.cs" Inherits="pages_PaymentDetails" Title="Simplicity4Business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHead" Runat="Server">
    	<div class="breadcrumps">
			<a href="#">Trolley ></a>
			<a href="#">Create an Account ></a>
			<a class="current" href="#">Payment Details ></a>
			<a href="#">Confirm Checkout</a>
		</div>
		
		<div class="header">
			<div class="heading">Payment Details</div>
			<div class="noFloat"></div>
		</div>		
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
		<div class="paymentDetails">
			<div class="row">			
				<div class="col1">Card Type</div>
				<div class="col2">
				<asp:DropDownList ID="lstCardType" runat="server">
				    <asp:ListItem Text="Visa" Value="001"></asp:ListItem>
				    <asp:ListItem Text="MasterCard" Value="002"></asp:ListItem>
				    <asp:ListItem Text="American Express" Value="003"></asp:ListItem>
				    <asp:ListItem Text="Discover" Value="004"></asp:ListItem>
				    <asp:ListItem Text="Diners Club" Value="005"></asp:ListItem>
				    <asp:ListItem Text="JCB" Value="007"></asp:ListItem>
				    <asp:ListItem Text="Maestro/Solo" Value="024"></asp:ListItem>
				</asp:DropDownList>
				</div>
				<div class="noFloat"></div>
			</div>		
			<div class="row">
				<div class="col1">Card Number</div>
				<div class="col2"><asp:TextBox ID="txtCardNumber" MaxLength="16" runat="server"></asp:TextBox></div>
				<div class="col3">Expiry Date</div>
				<div class="col4"><asp:TextBox ID="txtExpiryMonth" Width="20px" MaxLength="2" runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:TextBox ID="txtExpiryYear" MaxLength="4" Width="35px" runat="server"></asp:TextBox></div>
			</div>
			<div class="row">
				<div class="col1">Security Code</div>
				<div class="col2"><asp:TextBox ID="txtSecurityCode" Width="30px" MaxLength="3" runat="server"></asp:TextBox></div>
				<div class="col3">Start Date</div>
				<div class="col4"><asp:TextBox ID="txtStartMonth" Width="20px" MaxLength="2" runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:TextBox ID="txtStartYear" Width="35px" MaxLength="4" runat="server"></asp:TextBox></div>
			</div>
			<div class="row">
				<div class="col1">First Name</div>
				<div class="col2"><asp:TextBox ID="txtFirstName" MaxLength="30" runat="server"></asp:TextBox></div>
			</div>
			<div class="row">
				<div class="col1">Last Name</div>
				<div class="col2"><asp:TextBox ID="txtLastName" MaxLength="30" runat="server"></asp:TextBox></div>
			</div>
			<div class="row">
				<div class="col1">Telephone</div>
				<div class="col2"><asp:TextBox ID="txtTelephone" MaxLength="20" runat="server"></asp:TextBox></div>
			</div>
			<div class="row" style="padding-top:15px;">
				<div class="col1">Card Billing Address</div>
			</div>
			<div class="row" style="padding-top:10px;">
				<div class="col1">Street & Number</div>
				<div class="col2"><asp:TextBox ID="txtBillingStreet" MaxLength="100" Width="300px" runat="server"></asp:TextBox></div>
			</div>

			<div class="row">
				<div class="col1">Town</div>
				<div class="col2"><asp:TextBox ID="txtBillingTown" MaxLength="30" runat="server"></asp:TextBox></div>
			</div>
			<div class="row">
				<div class="col1">County</div>
				<div class="col2"><asp:TextBox ID="txtBillingCounty" MaxLength="30" runat="server"></asp:TextBox></div>
			</div>
			<div class="row">
				<div class="col1">Country</div>
				<div class="col2"><asp:TextBox ID="txtBillingCountry" MaxLength="50" runat="server"></asp:TextBox></div>
			</div>
			<div class="row">
				<div class="col1">Postcode/Zip</div>
				<div class="col2"><asp:TextBox ID="txtBillingZipCode" MaxLength="10" Width="75px" runat="server"></asp:TextBox></div>
			</div>
			<div class="noFloat"/>
		</div>

		<div class="noFloat" style="padding-top:15px;">
			<div class="floatRight">
			<asp:ImageButton ID="btnCheckout" runat="server" 
                    ImageUrl="~/images/Continue.gif" AlternateText="Continue" 
                    onmouseover="this.src='../images/Continue_rollover.gif'" 
                    onmouseout="this.src='../images/Continue.gif'" onclick="btnContinue_Click"/>				
			</div>
		</div>

		<div class="noFloat" style="padding-top:30px;">
			<img src="../images/paymentOptions.png"/>
		</div>
</asp:Content>

