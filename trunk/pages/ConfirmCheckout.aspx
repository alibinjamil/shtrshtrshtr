<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="ConfirmCheckout.aspx.cs" Inherits="pages_ConfirmCheckout" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
function onTermsAndConditionsChkboxClick(index)
{
	var img = document.getElementById('img_chk_TermsAndConditions' + index);
	var hid = document.getElementById('chk_TermsAndConditions' + index);
	if(hid.value == 'false') 
	{
		img.src = '../images/checkbox_checked.png';
		hid.value = "true";		
	}
	else
	{
		img.src = '../images/checkbox_unchecked.png';
		hid.value = "false";
	}
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHead" Runat="Server">
	<div class="breadcrumps">
			<a href="#">Trolley ></a>
			<a href="#">Create an Account ></a>
			<a href="#">Payment Details ></a>
			<a class="current" href="#">Confirm Checkout</a>
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
			        <div class="row"><%# DataBinder.Eval(Container, "DataItem.Quantity") %> x <%# DataBinder.Eval(Container, "DataItem.ProductName") %> for a <%# DataBinder.Eval(Container, "DataItem.DurationString") %></div>
			        <div class="terms">
				        <div><a href="<%# DataBinder.Eval(Container, "DataItem.TermsUrl") %>" style="color:black;">Terms & Conditions</a></div>
				        <div onclick='onTermsAndConditionsChkboxClick(<%#DataBinder.Eval(Container, "ItemIndex", "")%>)' class="floatLeft" style="padding-top:5px;">
					        <img id='img_chk_TermsAndConditions<%#DataBinder.Eval(Container, "ItemIndex", "")%>' src='../images/checkbox_unchecked.png' alt="Accept Terms & Conditions"/>
					        <input type="hidden" name="acceptTerms" id='chk_TermsAndConditions<%#DataBinder.Eval(Container, "ItemIndex", "")%>' value="false"/>
				        </div>
				        <div class="floatLeft" style="padding-left:10px;padding-top:5px; vertical-align:middle;">	Please tick to confirm that you have read the terms & conditions</div>
				        <div class="noFloat"/>
			        </div>
			    </ItemTemplate>
			</asp:Repeater>
		</div>

		<div class="noFloat" style="padding-top:15px;">
			<div><hr/></div>
			<div class="floatRight">
				<asp:ImageButton ID="btnCheckout" runat="server" 
                    ImageUrl="~/images/Confirm.gif" AlternateText="Confirm Payment" 
                    onmouseover="this.src='../images/Confirm_rollover.gif'" 
                    onmouseout="this.src='../images/Confirm.gif'" onclick="btnCheckout_Click"/>
			</div>			
		</div>

		<div class="noFloat" style="padding-top:30px;">
			<img src="../images/paymentOptions.png"/>
		</div>
</asp:Content>

