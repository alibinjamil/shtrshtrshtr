<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="AccountAddress.aspx.cs" Inherits="pages_AccountAddress" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHead" Runat="Server">
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
            <div class="noFloat" style="padding-top:10px"><!-- address div starts -->
                <h3>Billing Information</h3>
                <div class="row" >
                    <div class="col5" >
                        <asp:ImageButton ID="imgBtnBilling" runat="server" 
                            ImageUrl="~/images/checkbox_checked.png" onclick="imgBtnBilling_Click"/>						
						<span>Billing address is the same as the address of the Account</span>
					</div>
                </div>               
                
                <div class="row">
                    <div class="col1"><asp:Label ID="lblAddressNo" runat="server" Text="Address No"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtBillingAddressNo" Width="250px" runat="server"></asp:TextBox></div>                
                    <div class="col3"><asp:Label ID="lblAddressLine1" runat="server" Text="Address Line 1"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtBillingAddressLine1" Width="250px" runat="server"></asp:TextBox></div>
                </div>            
                <div class="row">
                    <div class="col1"><asp:Label ID="lblAddressLine2" runat="server" Text="Address Line 2"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtBillingAddressLine2" Width="250px" runat="server"></asp:TextBox></div>                
                    <div class="col3"><asp:Label ID="lblAddressLine3" runat="server" Text="Address Line 3"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtBillingAddressLine3" Width="250px" runat="server"></asp:TextBox></div>
                </div>            
                <div class="row">
                    <div class="col1"><asp:Label ID="lblAddressLine4" runat="server" Text="Address Line 4"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtBillingAddressLine4" Width="250px" runat="server"></asp:TextBox></div>                
                    <div class="col3"><asp:Label ID="lblAddressLine5" runat="server" Text="Address Line 5"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtBillingAddressLine5" Width="250px" runat="server"></asp:TextBox></div>
                </div>            
                <div class="row">
                    <div class="col1"><asp:Label ID="lblPostCode" runat="server" Text="Post Code"></asp:Label></div>
                    <div class="col2">
                        <asp:TextBox ID="txtBillingPostCode" Width="250px" runat="server"></asp:TextBox>                        
                    </div>                
                    <div class="col3"><asp:Label ID="lblTown" runat="server" Text="Town"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtBillingTown" Width="250px" runat="server"></asp:TextBox></div>
                </div>            
                <div class="row">
                    <div class="col1"><asp:Label ID="lblCounty" runat="server" Text="County"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtBillingCounty" Width="250px" runat="server"></asp:TextBox></div>                
                    <div class="col3"><asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtBillingCountry" Width="250px" runat="server"></asp:TextBox></div>
                </div>                            
                <div class="row">
                    <div class="col1"><asp:Label ID="lblTele1" runat="server" Text="Telephone 1"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtBillingTele1" Width="250px" runat="server"></asp:TextBox></div>
                    <div class="col3"><asp:Label ID="lblTele2" runat="server" Text="Telephone 2"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtBillingTele2" Width="250px" runat="server"></asp:TextBox></div>            
                </div>                
                <div class="row">
                    <div class="col1"><asp:Label ID="lblFax" runat="server" Text="Fax"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtBillingFax" Width="250px" runat="server"></asp:TextBox></div>
                    <div class="col3"><asp:Label ID="lblMobile" runat="server" Text="Mobile"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtBillingMobile" Width="250px" runat="server"></asp:TextBox></div>            
                </div> 
            </div>        
            <div class="noFloat" style="padding-top:10px"><!-- address div starts -->
                <h3>Shipping Information</h3>
                <div class="row" >
                    <div class="col5"  >						
                        <asp:ImageButton ID="imgBtnShipping" runat="server" 
                            ImageUrl="~/images/checkbox_checked.png" onclick="imgBtnShipping_Click" />						
						<span>Shipping address is the same as the address of the Account</span>
					</div>
                </div>               
                
                <div class="row">
                    <div class="col1"><asp:Label ID="Label1" runat="server" Text="Address No"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtShippingAddressNo" Width="250px" runat="server"></asp:TextBox></div>                
                    <div class="col3"><asp:Label ID="Label2" runat="server" Text="Address Line 1"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtShippingAddressLine1" Width="250px" runat="server"></asp:TextBox></div>
                </div>            
                <div class="row">
                    <div class="col1"><asp:Label ID="Label3" runat="server" Text="Address Line 2"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtShippingAddressLine2" Width="250px" runat="server"></asp:TextBox></div>                
                    <div class="col3"><asp:Label ID="Label4" runat="server" Text="Address Line 3"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtShippingAddressLine3" Width="250px" runat="server"></asp:TextBox></div>
                </div>            
                <div class="row">
                    <div class="col1"><asp:Label ID="Label5" runat="server" Text="Address Line 4"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtShippingAddressLine4" Width="250px" runat="server"></asp:TextBox></div>                
                    <div class="col3"><asp:Label ID="Label6" runat="server" Text="Address Line 5"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtShippingAddressLine5" Width="250px" runat="server"></asp:TextBox></div>
                </div>            
                <div class="row">
                    <div class="col1"><asp:Label ID="Label7" runat="server" Text="Post Code"></asp:Label></div>
                    <div class="col2">
                        <asp:TextBox ID="txtShippingPostCode" Width="250px" runat="server"></asp:TextBox>                        
                    </div>                
                    <div class="col3"><asp:Label ID="Label8" runat="server" Text="Town"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtShippingTown" Width="250px" runat="server"></asp:TextBox></div>
                </div>            
                <div class="row">
                    <div class="col1"><asp:Label ID="Label9" runat="server" Text="County"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtShippingCounty" Width="250px" runat="server"></asp:TextBox></div>                
                    <div class="col3"><asp:Label ID="Label10" runat="server" Text="Country"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtShippingCountry" Width="250px" runat="server"></asp:TextBox></div>
                </div>                            
                <div class="row">
                    <div class="col1"><asp:Label ID="Label11" runat="server" Text="Telephone 1"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtShippingTele1" Width="250px" runat="server"></asp:TextBox></div>
                    <div class="col3"><asp:Label ID="Label12" runat="server" Text="Telephone 2"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtShippingTele2" Width="250px" runat="server"></asp:TextBox></div>            
                </div>                
                <div class="row">
                    <div class="col1"><asp:Label ID="Label13" runat="server" Text="Fax"></asp:Label></div>
                    <div class="col2"><asp:TextBox ID="txtShippingFax" Width="250px" runat="server"></asp:TextBox></div>
                    <div class="col3"><asp:Label ID="Label14" runat="server" Text="Mobile"></asp:Label></div>
                    <div class="col4"><asp:TextBox ID="txtShippingMobile" Width="250px" runat="server"></asp:TextBox></div>            
                </div> 
            </div>        
        <div style="text-align:right;padding-right:10px; padding-top:10px;">
            <asp:ImageButton ID="btnSave" ImageUrl="~/images/Continue.gif" runat="server" onclick="btnSave_Click" onmouseover="this.src='../images/Continue_rollover.gif'" onmouseout="this.src='../images/Continue.gif'"/>
        </div>
        <div class="noFloat" style="height:10px;"></div>
            
    </div>
</asp:Content>

