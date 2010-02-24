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
	    <div class="loginConnectSimplicity" onclick="javascript:window.open('http://84.51.250.96/')">
	    </div>		
	    <div class="loginConnectHnS" onclick="javascript:window.open('http://84.51.250.96/HS/')">
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
                            <asp:ListItem Text="Where did you meet your spouse" Value="1"></asp:ListItem>
                            <asp:ListItem Text="What was your first pet's name" Value="2"></asp:ListItem>
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

