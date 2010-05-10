<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="CreateAccount.aspx.cs" Inherits="pages_CreateAccount" Title="Simplicity4Business" %>
<%@ Register src="~/common/CheckBox.ascx" tagname="CheckBox" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <script src="../js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHead" runat="server">
    <div class="breadcrumps">
		<a href="#">Checkout ></a>
		<a class="current" href="#">Create an Account ></a>
		<a href="#">Confirm Checkout ></a>		
		<a href="#">Payment Details ></a>
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
                            <asp:ListItem Text="What was your childhood nickname?" Value="1"></asp:ListItem>
                            <asp:ListItem Text="In what city did you meet your spouse/significant other?" Value="2"></asp:ListItem>
                            <asp:ListItem Text="What is the name of your favorite childhood friend?" Value="3"></asp:ListItem> 
                            <asp:ListItem Text="What is your oldest sibling’s birthday month and year? (e.g., January 1900)" Value="4"></asp:ListItem>
                            <asp:ListItem Text="What is the middle name of your youngest child?" Value="5"></asp:ListItem>
                            <asp:ListItem Text="What is your oldest sibling's middle name?" Value="6"></asp:ListItem>
                            <asp:ListItem Text="What school did you attend in fifth year?" Value="7"></asp:ListItem>
                            <asp:ListItem Text="What was your childhood phone number including area code? (e.g., 000-000-0000)" Value="8"></asp:ListItem>
                            <asp:ListItem Text="What was the name of your first pet?" Value="9"></asp:ListItem>
                            <asp:ListItem Text="In what city or town did your mother and father meet?" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Where were you when you had your first kiss?" Value="11"></asp:ListItem>
                            <asp:ListItem Text="What is the first name of the boy or girl that you first kissed?" Value="12"></asp:ListItem>
                            <asp:ListItem Text="What was the last name of your third grade teacher?" Value="13"></asp:ListItem>
                            <asp:ListItem Text="In what city does your nearest sibling live?" Value="14"></asp:ListItem>
                            <asp:ListItem Text="What is your youngest brother’s birthday month and year? (e.g., January 1900)" Value="15"></asp:ListItem>
                            <asp:ListItem Text="What is your maternal grandmother's maiden name?" Value="16"></asp:ListItem>
                            <asp:ListItem Text="In what city or town was your first job?" Value="17"></asp:ListItem>
                            <asp:ListItem Text="What is the name of the place your wedding reception was held?" Value="18"></asp:ListItem>
                            <asp:ListItem Text="What is the name of a college you applied to but didn't attend?" Value="19"></asp:ListItem>
                            <asp:ListItem Text="Where were you when you first heard about 9/11?" Value="20"></asp:ListItem>
                            <asp:ListItem Text="What are your initials?" Value="21"></asp:ListItem>
                            
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rf8" InitialValue="#" runat="server" ErrorMessage="*" ControlToValidate="listForgotPasswordQuestion" CssClass="errorMessage"></asp:RequiredFieldValidator>                        
                    </div>
                </div>
                <div class="row">
                    <div class="col1"><asp:Label ID="Label1" runat="server" Text="Forgot Password Answer"></asp:Label></div>
                    <div class="col2">
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
                    <uc1:CheckBox ID="cbEmails" runat="server" CssClass="col5" Text="Please indicate if you would like to receives further updates for products" Selected="true"/>
                </div>               
            </div>
        </div>
        <div class="noFloat"></div>
        <div style="text-align:right;padding-right:10em; padding-top:2em;">
            <asp:ImageButton ID="btnSave" ImageUrl="../images/Continue.gif" runat="server" onclick="btnSave_Click" onmouseover="this.src='../images/Continue_rollover.gif'" onmouseout="this.src='../images/Continue.gif'" OnClientClick="showProcessingImage();" />
        </div>
        <div class="noFloat" style="height:10px;"></div>
        
</asp:Content>

