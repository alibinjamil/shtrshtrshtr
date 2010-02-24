<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="CreateAccount.aspx.cs" Inherits="pages_CreateAccount" Title="Simplicity4Business" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function onCheckboxClick(){
	        var img = document.getElementById('chk_ReceiveEmails');
	        var hid = document.getElementById('receiveEmails');
	        if(hid.value == '') 
	        {
		        img.src = '../images/checkbox_checked.png';
		        hid.value = "true";		
	        }
	        else
	        {
		        img.src = '../images/checkbox_unchecked.png';
		        hid.value = "";
	        }            
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHead" runat="server">
    <div class="breadcrumps">
		<a href="#">Checkout ></a>
		<a class="current" href="#">Create an Account ></a>
		<a href="#">Payment Details ></a>
		<a href="#">Confirm Checkout ></a>
	</div>
	<div id="screenTitle">
		<div class="heading">Create an Account</div>
	</div>		
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    		
        <div class="createAccount" >            
            <div class="noFloat" style="padding-top:15px">
                <div class="row">
                    <div class="col1"><asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label></div>
                    <div class="col2">
                        <asp:TextBox ID="txtEmail" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rf1" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" CssClass="errorMessage"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ErrorMessage="!" ControlToValidate="txtEmail" CssClass="errorMessage" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col3"><asp:Label ID="lblConfirmEmail" runat="server" Text="Confirm Email"></asp:Label></div>
                    <div class="col4">
                        <asp:TextBox ID="txtConfirmEmail" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rf2" runat="server" ErrorMessage="*" ControlToValidate="txtConfirmEmail" CssClass="errorMessage"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ErrorMessage="!" ControlToValidate="txtConfirmEmail" CssClass="errorMessage" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                </div>            
                <div class="row">
                    <div class="col1"><asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label></div>
                    <div class="col2">
                        <asp:TextBox ID="txtPassword" Width="250px" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rf3" runat="server" ErrorMessage="*" ControlToValidate="txtPassword" CssClass="errorMessage"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col3"><asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label></div>
                    <div class="col4">
                        <asp:TextBox ID="txtConfirmPassword" Width="250px" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rf4" runat="server" ErrorMessage="*" ControlToValidate="txtConfirmPassword" CssClass="errorMessage"></asp:RequiredFieldValidator>
                    </div>
                </div>            
                <div class="row">
                    <div class="col1"><asp:Label ID="lblForgotPasswordQuestion" runat="server" Text="Forgot Password Question"></asp:Label></div>
                    <div class="col2">
                        <asp:DropDownList ID="listForgotPasswordQuestion" runat="server">
                            <asp:ListItem Text="--- Choose a question ---" Value="#"></asp:ListItem>
                            <asp:ListItem Text="Where did you meet your spouse" Value="1"></asp:ListItem>
                            <asp:ListItem Text="What was your first pet's name" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rf8" InitialValue="#" runat="server" ErrorMessage="*" ControlToValidate="listForgotPasswordQuestion" CssClass="errorMessage"></asp:RequiredFieldValidator>                        
                    </div>
                    <div class="col3"><asp:Label ID="Label1" runat="server" Text="Forgot Password Answer"></asp:Label></div>
                    <div class="col4">
                        <asp:TextBox ID="txtForgotPasswordAnswer" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rf5" runat="server" ErrorMessage="*" ControlToValidate="txtForgotPasswordAnswer" CssClass="errorMessage"></asp:RequiredFieldValidator>                        
                    </div>            
                </div>            
            </div>
            <div class="noFloat">
                <div class="row">
                    <div class="col1"><asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label></div>
                    <div class="col2">
                        <asp:TextBox ID="txtFirstName" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rf6" runat="server" ErrorMessage="*" ControlToValidate="txtFirstName" CssClass="errorMessage"></asp:RequiredFieldValidator>                        
                    </div>
                    <div class="col3"><asp:Label ID="lblSurname" runat="server" Text="Surname"></asp:Label></div>
                    <div class="col4">
                        <asp:TextBox ID="txtSurname" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rf7" runat="server" ErrorMessage="*" ControlToValidate="txtSurname" CssClass="errorMessage"></asp:RequiredFieldValidator>                        
                    </div>            
                </div>            
                <div class="row">
                    <div class="col1"><asp:Label ID="lblCompanyName" runat="server" Text="Company Name"></asp:Label></div>
                    <div class="col2">
                        <asp:TextBox ID="txtCompanyName" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtCompanyName" CssClass="errorMessage"></asp:RequiredFieldValidator>                                                
                    </div>
                    <div class="col3"><asp:Label ID="lblJobTitle" runat="server" Text="Job Title"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtJobTitle" Width="250px" runat="server"></asp:TextBox></div>            
                </div>    
            </div>
            <div class="noFloat" style="padding-top:10px"><!-- address div starts -->
                <div class="row">
                    <div class="col1"><asp:Label ID="lblAddressNo" runat="server" Text="Address No"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtAddressNo" Width="250px" runat="server"></asp:TextBox></div>                
                    <div class="col3"><asp:Label ID="lblAddressLine1" runat="server" Text="Address Line 1"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtAddressLine1" Width="250px" runat="server"></asp:TextBox></div>
                </div>            
                <div class="row">
                    <div class="col1"><asp:Label ID="lblAddressLine2" runat="server" Text="Address Line 2"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtAddressLine2" Width="250px" runat="server"></asp:TextBox></div>                
                    <div class="col3"><asp:Label ID="lblAddressLine3" runat="server" Text="Address Line 3"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtAddressLine3" Width="250px" runat="server"></asp:TextBox></div>
                </div>            
                <div class="row">
                    <div class="col1"><asp:Label ID="lblAddressLine4" runat="server" Text="Address Line 4"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtAddressLine4" Width="250px" runat="server"></asp:TextBox></div>                
                    <div class="col3"><asp:Label ID="lblAddressLine5" runat="server" Text="Address Line 5"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtAddressLine5" Width="250px" runat="server"></asp:TextBox></div>
                </div>            
                <div class="row">
                    <div class="col1"><asp:Label ID="lblPostCode" runat="server" Text="Post Code"></asp:Label></div>
                    <div class="col2">
                        <asp:TextBox ID="txtPostCode" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rf9" runat="server" ErrorMessage="*" ControlToValidate="txtPostCode" CssClass="errorMessage"></asp:RequiredFieldValidator>                                                
                    </div>                
                    <div class="col3"><asp:Label ID="lblTown" runat="server" Text="Town"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtTown" Width="250px" runat="server"></asp:TextBox></div>
                </div>            
                <div class="row">
                    <div class="col1"><asp:Label ID="lblCounty" runat="server" Text="County"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtCounty" Width="250px" runat="server"></asp:TextBox></div>                
                    <div class="col3"><asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtCountry" Width="250px" runat="server"></asp:TextBox></div>
                </div>                            
                <div class="row">
                    <div class="col1"><asp:Label ID="lblTele1" runat="server" Text="Telephone 1"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtTele1" Width="250px" runat="server"></asp:TextBox></div>
                    <div class="col3"><asp:Label ID="lblTele2" runat="server" Text="Telephone 2"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtTele2" Width="250px" runat="server"></asp:TextBox></div>            
                </div>                
                <div class="row">
                    <div class="col1"><asp:Label ID="lblFax" runat="server" Text="Fax"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtFax" Width="250px" runat="server"></asp:TextBox></div>
                    <div class="col3"><asp:Label ID="lblMobile" runat="server" Text="Mobile"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtMobile" Width="250px" runat="server"></asp:TextBox></div>            
                </div> 
                <div class="row" style="margin-top:30px;">
                    <div class="col5" onclick="onCheckboxClick();" >						
                        <img id="chk_ReceiveEmails" src='../images/checkbox_unchecked.png'/>
						<input type="hidden" name="receiveEmails" id="receiveEmails" value=""/>
						<span>Please indicate if you would like to receives further updates for products</span>
					</div>
                </div>               
            </div>
        </div>
        <div class="noFloat"></div>
        <div style="text-align:right;padding-right:10em; padding-top:2em;">
            <asp:ImageButton ID="btnSave" ImageUrl="../images/Continue.gif" runat="server" onclick="btnSave_Click" onmouseover="this.src='../images/Continue_rollover.gif'" onmouseout="this.src='../images/Continue.gif'"/>
        </div>
        <div class="noFloat" style="height:10px;"></div>
        </form>
</asp:Content>

