<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CallMePageUserControl.ascx.cs" Inherits="common_CallMePageUserControl" %>
<script type="text/javascript">
function onCheckboxClick(value)
{
	var img = document.getElementById('chk_' + value);
	var hid = document.getElementById('prod_'+ value);
	if(hid.value == '') 
	{
		img.src = '../images/checkbox_checked.png';
		hid.value = value;		
	}
	else
	{
		img.src = '../images/checkbox_unchecked.png';
		hid.value = '';
	}
}
</script>
    		<div class="header">
			<div class="blueHeading">Complete all fields marked with *</div>
			<div class="heading"><%=PageName%></div>			
		</div>		
		<div class="errorSummary">
            <asp:Label ID="lblErrorMessage" runat="server" Text="" Visible="false"></asp:Label>		
		</div>
		<div class="infoSummary">
            <asp:Label ID="lblInfoMessage" runat="server" Text="" Visible="false"></asp:Label>		
		</div>
		<div class="callMeBack">
			<div class="row">
				<div class="col1">*First Name</div>
				<div class="col2">
				    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
				    <asp:RequiredFieldValidator ID="rf10" runat="server" ErrorMessage="*" ControlToValidate="txtFirstName" CssClass="errorMessage"></asp:RequiredFieldValidator>
				</div>
				<div class="col3">*Surname</div>
				<div class="col4">
				    <asp:TextBox ID="txtSurName" runat="server"></asp:TextBox>
				    <asp:RequiredFieldValidator ID="rf11" runat="server" ErrorMessage="*" ControlToValidate="txtSurName" CssClass="errorMessage"></asp:RequiredFieldValidator>
				</div>
			</div>
			<div class="row">
				<div class="col1">*Telephone</div>
				<div class="col2">
				    <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
				    <asp:RequiredFieldValidator ID="rf12" runat="server" ErrorMessage="*" ControlToValidate="txtTelephone" CssClass="errorMessage"></asp:RequiredFieldValidator>
				</div>
				<div class="col3">*Mobile</div>
				<div class="col4">
				    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
				    <asp:RequiredFieldValidator ID="rf13" runat="server" ErrorMessage="*" ControlToValidate="txtMobile" CssClass="errorMessage"></asp:RequiredFieldValidator>
				</div>
			</div>
			<div class="row">
				<div class="col1">*Email</div>
				<div class="col2">
				    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rf1" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" CssClass="errorMessage"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ErrorMessage="!" ControlToValidate="txtEmail" CssClass="errorMessage" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>				    
				</div>	
				<div class="col3">*Confirm Email</div>
				<div class="col4">
				    <asp:TextBox ID="txtConfirmEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rf2" runat="server" ErrorMessage="*" ControlToValidate="txtConfirmEmail" CssClass="errorMessage"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ErrorMessage="!" ControlToValidate="txtConfirmEmail" CssClass="errorMessage" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>				    
				</div>
			</div>			
		</div>
		<div class="products">
			<div style="font-weight:bold;padding-bottom:10px;">*Tick Products interested in</div>
			<div class="row">
				<div class="col1">SimplicityEAS</div>
				<div class="col2">
					<div onclick="onCheckboxClick('SimplicityEAS')">
						<img id="chk_SimplicityEAS" src='../images/checkbox_unchecked.png'>
						<input type="hidden" name="products" id="prod_SimplicityEAS" value=""/>
					</div>
				</div>
				<div class="col3">SimplicityH&Slive</div>
				<div class="col4">
					<div onclick="onCheckboxClick('SimplicityHnSlive')">
						<img id="chk_SimplicityHnSlive" src='../images/checkbox_unchecked.png'>
						<input type="hidden" name="products" id="prod_SimplicityHnSlive" value=""/>
					</div>
				</div>
				<div class="col5">SimplicityHandyGas</div>
				<div class="col6">
					<div onclick="onCheckboxClick('SimplicityHandyGas')">
						<img id="chk_SimplicityHandyGas" src='../images/checkbox_unchecked.png'>
						<input type="hidden" name="products" id="prod_SimplicityHandyGas" value=""/>
					</div>
				</div>
			</div>
			<div class="row">
				<div class="col1">SimplicityHandyServe</div>
				<div class="col2">
					<div onclick="onCheckboxClick('SimplicityHandyServe')">
						<img id="chk_SimplicityHandyServe" src='../images/checkbox_unchecked.png'>
						<input type="hidden" name="products" id="prod_SimplicityHandyServe" value=""/>
					</div>
				</div>
				<div class="col3">SimplicityHandyLEC</div>
				<div class="col4">
					<div onclick="onCheckboxClick('SimplicityHandyLEC')">
						<img id="chk_SimplicityHandyLEC" src='../images/checkbox_unchecked.png'>
						<input type="hidden" name="products" id="prod_SimplicityHandyLEC" value=""/>
					</div>
				</div>
			</div>
			<div class="noFloat"></div>
		</div>
		<div class="callMeBack">
			<div class="row">
				<div class="col1">Company Name</div>
				<div class="col2"><asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox></div>
				<div class="col3">Company website</div>
				<div class="col4"><asp:TextBox ID="txtCompanyWebsite" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ErrorMessage="!" ControlToValidate="txtCompanyWebsite" CssClass="errorMessage" 
                        ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>				    
				                    </div>
			</div>
			<div class="row">
				<div class="col1">Postal Address</div>
				<div class="col2"><asp:TextBox ID="txtPostalAddress" runat="server"></asp:TextBox></div>
				<div class="col3">Postcode</div>
				<div class="col4"><asp:TextBox ID="txtPostCode" runat="server"></asp:TextBox></div>
			</div>
			<div class="row">
				<div class="col1">Comments</div>
				<div class="floatLeft"><asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox></div>
			</div>
			<div class="noFloat"></div>
		</div>		
		<div class="noFloat"></div>
		<div style="float:right; padding-top:10px; padding-right:25px;">
            <asp:ImageButton ID="imgBtnSubmit" runat="server" 
                ImageUrl="~/images/submit.gif" 
                onmouseover="this.src='../images/submit_rollover.gif'" 
                onmouseout="this.src='../images/submit.gif'" onclick="imgBtnSubmit_Click" />
        </div>
        <div class="noFloat" style="height:10px;">&nbsp;</div>