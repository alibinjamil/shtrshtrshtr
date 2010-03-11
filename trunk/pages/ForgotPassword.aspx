<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="pages_ForgotPassword" Title="Simplicity4Business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
	<div class="noFloat"></div>
    <div class="header">
			<div class="heading">Forget Password</div>
			<div class="noFloat"></div>
    </div>
	<div class="forgotPassword" id="mainLogin">
	    <div class="loginConnectSimplicity" onclick="javascript:window.open('http://94.236.98.81/')">
	    </div>		
	    <div class="loginConnectHnS" onclick="javascript:window.open('http://hands-live.com/')">
    	</div>
    	<div>
    	    <div class="floatLeft">
    	        <div style="padding-top:70px;" class="row">
	                    <div class="colerror"> 
	                        &nbsp;<div class="errorMessage"><asp:Label ID="lblErrorMessage" runat="server" Text="Label" Visible="false"></asp:Label> </div>		
                        </div>
                        <div class="noFloat"></div>
	            </div>
                <div class="row" >
                    <div class="col1">Email</div>
                    <div class="col2">                            
                        <asp:TextBox ID="txtEmail" runat="server" Width="170px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rf1" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" CssClass="errorMessage"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                        ErrorMessage="!" ControlToValidate="txtEmail" CssClass="errorMessage" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>                    			    
                    </div>	  
                    <div class="noFloat"></div>
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
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rf8" InitialValue="#" runat="server" ErrorMessage="*" ControlToValidate="listForgotPasswordQuestion" CssClass="errorMessage"></asp:RequiredFieldValidator>                        
                    </div>
                    <div class="noFloat"></div>
                </div>
                <div class="row">
                    <div class="col1"><asp:Label ID="Label1" runat="server" Text="Forgot Password Answer"></asp:Label></div>
                    <div class="col2">
                        <asp:TextBox ID="txtForgotPasswordAnswer" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rf5" runat="server" ErrorMessage="*" ControlToValidate="txtForgotPasswordAnswer" CssClass="errorMessage"></asp:RequiredFieldValidator>                        
                    </div>   
                    <div class="noFloat"></div>                     
                </div>
    	        <div class="row">
    	            <div class="col1">&nbsp;</div>
    	            <div class="col2"><asp:ImageButton ID="btnCotninue" ImageUrl="../images/Continue.gif" runat="server" onclick="btnContinue_Click" onmouseover="this.src='../images/Continue_rollover.gif'" onmouseout="this.src='../images/Continue.gif'"/></div>
    	        </div>
    	    </div>
    	</div>
    </div>
</asp:Content>

