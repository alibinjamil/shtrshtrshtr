<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="pages_Login" Title="Simplicity4Business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="noFloat"></div>
    <div class="header">
			<div class="heading">Customer Login</div>
			<div class="noFloat"></div>
    </div>
	<div class="login" id="mainLogin">
	    <div class="loginConnectSimplicity" onclick="javascript:window.open('http://84.51.250.96/')">
	    </div>		
	    <div class="loginConnectHnS" onclick="javascript:window.open('http://84.51.250.96/HS/')">
    	</div>        
        <div>
            <asp:Panel ID="PanelAlreadyLoggedIn" runat="server" Visible="false">
                <div class="infoSummary" style="padding-top:150px;padding-left:50px;font-size:14pt;">You are already logged in.</div>
            </asp:Panel>
            <asp:Panel ID="PanelLogin" runat="server">
    	
                <div class="floatLeft" style="padding-top:50px;padding-left:10px;">
                    <img src="../images/Account_login_man.gif" />
                </div>
                <div class="floatLeft">
                    <div style="padding-top:60px;padding-left:10px;" class="row">
	                    <div class="colerror"> 
	                        &nbsp;<div class="errorMessage"><asp:Label ID="lblErrorMessage" runat="server" Text="Label" Visible="false"></asp:Label> </div>		
	                        
                        </div>
                        <div class="noFloat"></div>
	                </div>
		            <div class="row">
			            <div class="col1">Username</div>
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
			            <div class="col1">Password</div>
			            <div class="col2"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="170px"></asp:TextBox></div>
			            <div class="col3">
                            <asp:ImageButton ID="imgBtnLogin" runat="server" OnClick="imgBtnLogin_Click" ImageUrl="~/images/Login.gif" 
                            onmouseover="this.src='../images/Login_rollover.gif'" onmouseout="this.src='../images/Login.gif'"/></div>
			            <div class="noFloat"></div>
		            </div>
                        
		            <div style="padding-left:30px;padding-top:50px;">
		                <div class="col1"><a href="ForgotPassword.aspx" style="color:black;">Forgot your password?</a></div>
		            </div>
		            <div style="padding-left:30px;padding-top:10px;">
				        <u>Do not have an account? </u><a href="CreateAccount.aspx" style="color:blue;">Sign up for free!</a>
		            </div>
                
                </asp:Panel>
		    </div>
		</div>
	</div>	
	<div class="noFloat" style="height:20px;"></div>
    
</asp:Content>

