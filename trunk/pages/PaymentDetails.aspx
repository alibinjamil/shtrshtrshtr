<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="PaymentDetails.aspx.cs" Inherits="pages_PaymentDetails" Title="Untitled Page" %>

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
				<div class="col1">Card Name</div>
				<div class="col2"><input type="text" /></div>
				<div class="col3">Expiry Date</div>
				<div class="col4"><input type="text" size="2" />&nbsp;&nbsp;<input type="text" size="2"/>&nbsp;&nbsp;<input type="text" size="2"/></div>
			</div>
			<div class="row">
				<div class="col1">Company Name</div>
				<div class="col2"><input type="text" /></div>
				<div class="col3">Start Date</div>
				<div class="col4"><input type="text" size="2" />&nbsp;&nbsp;<input type="text" size="2"/>&nbsp;&nbsp;<input type="text" size="2"/></div>
			</div>
			<div class="row">
				<div class="col1">Security Code</div>
				<div class="col2"><input type="text" size="4"/></div>
			</div>
			<div class="row">
				<div class="col1">Telephone</div>
				<div class="col2"><input type="text" /></div>
			</div>
			<div class="row" style="padding-top:15px;">
				<div class="col1">Card Billing Address</div>
			</div>
			<div class="row" style="padding-top:10px;">
				<div class="col1">Street & Number</div>
				<div class="col2"><input type="text" /></div>
			</div>

			<div class="row">
				<div class="col1">Town</div>
				<div class="col2"><input type="text" /></div>
			</div>
			<div class="row">
				<div class="col1">County</div>
				<div class="col2"><input type="text" /></div>
			</div>
			<div class="row">
				<div class="col1">Country</div>
				<div class="col2"><input type="text" /></div>
			</div>
			<div class="row">
				<div class="col1">Postcode/Zip</div>
				<div class="col2"><input type="text" /></div>
			</div>
			<div class="noFloat"/>
		</div>

		<div class="noFloat" style="padding-top:15px;">
			<div class="floatRight">
				<a href="#"><img src="../images/Continue.gif" onmouseover="this.src='../images/Continue_rollover.gif'" onmouseout="this.src='../images/Continue.gif'"></a>
			</div>
		</div>

		<div class="noFloat" style="padding-top:30px;">
			<img src="../images/paymentOptions.png"/>
		</div>
</asp:Content>

