<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="PaymentResponse.aspx.cs" Inherits="pages_PaymentResponse" Title="Simplicity4Business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
<div style="margin-top:25px;">
    <asp:Panel ID="panelSignature" runat="server" Visible="false">
        <span style='color:red'>Invalid response from Payment gateway. Please Try again</span>
    </asp:Panel>
    <asp:Panel ID="panelSuccess" runat="server" Visible="false">        
        <div class="header">
        	<div class="heading">Payment Receipt</div>
			<div class="noFloat"></div>        			
        </div>		
        <div class="receipt">
            <div>
                <div class="col1">Card holder's name:</div>
                <div class="col2"><% Response.Write(Request.Form.Get("billTo_firstName")); %>&nbsp; <% Response.Write(Request.Form.Get("billTo_lastName")); %></div>
                <div class="noFloat"></div>        			
                <div class="col1">Card #:</div>
                <div class="col2"><% Response.Write(Request.Form.Get("card_accountNumber")); %></div>
                <div class="noFloat"></div>        			                        
                <div class="col1">Card Expiry:</div>
                <div class="col2"><% Response.Write(Request.Form.Get("card_expirationMonth")); %>/<% Response.Write(Request.Form.Get("card_expirationYear")); %></div>
                <div class="noFloat"></div>        			                        
                <div class="col1">Card Type:</div>
                <div class="col2"><% if (Request.Form.Get("card_cardType") == "001")
                                     {%>Visa<% }
                                     else if (Request.Form.Get("card_cardType") == "002")
                                     { %>MasterCard<% }
                                     else if (Request.Form.Get("card_cardType") == "003")
                                     {%>American Express<% }
                                     else if (Request.Form.Get("card_cardType") == "004")
                                     { %>Discover<% }
                                     else if (Request.Form.Get("card_cardType") == "005")
                                     { %> Diners Club <% }
                                     else if (Request.Form.Get("card_cardType") == "007")
                                     {%> JCB <% }
                                     else if (Request.Form.Get("card_cardType") == "024")
                                     {%> Maestro/Solo <% } %></div>
                <div class="noFloat"></div>
                <div class="col1">Amount Charged:</div>
                <div class="col2">
                    <asp:Label ID="lblAmountText" runat="server" Text=""></asp:Label></div>
                <div class="noFloat"></div>        			                                                        			                        
                <div><a href="JavaScript:window.print();">Print</a></div>
            </div>
        </div>
    </asp:Panel>        
    <asp:Panel ID="panelFailure" runat="server" Visible="false">        
                <div>
                    <div style="color:Red;font-weight:bold;font-size:13px;">Some error occured while processing the payment</div>
                    <div style="padding-top:5px;color:Red;font-weight:bold;font-size:13px;">Error: <% Response.Write(Request.Form.Get("reasonCode")); %><br />
                    <% if (Request.Form.Get("reasonCode") == "102")
                       { %>
                        Some of the required fields are missing. Please provide all mandatory fields and proceed with checkout
                        <% }
                       else if (Request.Form.Get("reasonCode") == "202")//Expired card. Possible action: Request a different card or other form of payment.
                       { %>
                       The credit card provided is expired. Please try again with a different card
                        <%}
                       else if (Request.Form.Get("reasonCode") == "203")//The card was declined. No other information provided by the issuing bank. Possible action: Request a different card or other form of payment
                       { %>
                       Payment declined by issuer. Please try again with a different card
                        <%}
                       else if (Request.Form.Get("reasonCode") == "204")//Insufficient funds in the account. Possible action: Request a different card or other form of payment.
                       { %>
                       Insufficient funds in the account. Please try again with a different card
                        <%}
                       else if (Request.Form.Get("reasonCode") == "205")//The card was stolen or lost. Possible action: Review the customer’s information and determine if you want to request a different card from the customer
                       { %>
                       Invalid credit card. Please try again with a different card 
                        <%}
                       else if (Request.Form.Get("reasonCode") == "207")//The issuing bank was unavailable. Possible action: Wait a few minutes and resend the request.
                       { %>
                       Unable to connect to issuer. Your card is not charged. Please try again after some time or try with a different card
                        <%}
                       else if (Request.Form.Get("reasonCode") == "208")//The card is inactive or not authorized for card-not-present transactions. Possible action: Request a different card or other form of payment.
                       { %>
                       The card is either not activated or cannot be used online. Please try again with a different card
                        <%}
                       else if (Request.Form.Get("reasonCode") == "210")//The credit limit for the card has been reached. Possible action: Request a different card or other form of payment.
                       { %>
                       The card limit has been reached. Please try again with a different card
                        <%}
                       else if (Request.Form.Get("reasonCode") == "211")//The card verification number is invalid. Possible action: Request a different card or other form of payment.
                       { %>
                       The card verification number is invalid. Please provide correct verification number to proceed with checkout
                        <%}
                       else if (Request.Form.Get("reasonCode") == "220")//The processor declined the request based on a general issue with the customer’s account. Possible action: Request a different form of payment.
                       { %>
                       Some error occurred processing the card. Please try again or try with a different card
                        <%}
                       else if (Request.Form.Get("reasonCode") == "221")//The customer matched an entry on the processor’s negative file. Possible action: Review the order and contact the payment processor.
                       { %>
                       Some error occurred processing the card. Please try again or try with a different card
                        <%}
                       else if (Request.Form.Get("reasonCode") == "222")//The customer’s bank account is frozen. Possible action: Review the order or request a different form of payment.
                       { %>
                       Your account seems to be frozen by bank. Please try again with a different card
                        <%}
                       else if (Request.Form.Get("reasonCode") == "231")//The account number is invalid. Possible action: Request a different card or other form of payment.
                       { %>
                       Invalid card number. Please provide correct card number to proceed with checkout
                        <%}
                       else if (Request.Form.Get("reasonCode") == "232")//The card type is not accepted by the payment processor. Possible action: Request a different card or other form of payment. Also, check with CyberSource Customer Support to make sure that your account is configured correctly.
                       { %>
                       Invalid card type. Please provide select correct card type to proceed with checkout or contact support
                        <%}
                       else if (Request.Form.Get("reasonCode") == "233")//The processor declined the request based on an issue with the request itself. Possible action: Request a different form of payment.
                       { %>
                       Some error occurred while processing the payment. Your card is not charged. Please try again after some time or contact support
                        <%}
                       else if (Request.Form.Get("reasonCode") == "234")//There is a problem with your CyberSource merchant configuration. Possible action: Do not resend the request. Contact Customer Support to correct the configuration problem.
                       { %>
                       Some error occurred while processing the payment. Your card is not charged. Please try again after some time or contact support
                        <%}
                       else if (Request.Form.Get("reasonCode") == "236")//A processor failure occurred. Possible action: Possible action: Wait a few minutes and resend the request.
                       { %>
                       Some error occurred while processing the payment. Your card is not charged. Please try again after some time
                        <%}
                       else if (Request.Form.Get("reasonCode") == "240")//The card type is invalid or does not correlate with the credit card number.
                       { %>
                       Invalid card type selected for the given card number. Please select correct card type to proceed with checkout
                        <%}
                       else if (Request.Form.Get("reasonCode") == "476")//The customer cannot be authenticated. Possible action: Review the customer's order.
                       { %>
                       Unable to authenticate the card. Please try again with a different card or contact support
                        <%}
                       else if (Request.Form.Get("reasonCode") == "475")//The customer is enrolled in payer authentication. Possible action: Authenticate the cardholder before continuing with the transaction.
                       { %>
                       Some error occurred while processing the payment. Your card is not charged. Please contact support
                        <%}
                       else if (Request.Form.Get("reasonCode") == "150")//Error: General system failure. Possible action: Wait a few minutes and resend the request.
                       { %>
                       Some error occurred while processing the payment. Your card is not charged. Please wait for few minutes and try again with checkout
                        <%}
                       else if (Request.Form.Get("reasonCode") == "151")//Error: The request was received, but a server time-out occurred. This error does not include time-outs between the client and the server. Possible action: To avoid duplicating the order, do not resend the request until you have reviewed the order status in the Business Center.
                       { %>
                       Some error occurred while processing the payment. Your card might have been charged. To avoid duplicating the payment, please contact support
                        <%}
                       else if (Request.Form.Get("reasonCode") == "152")//Error: The request was received, but a service did not finish running in time. Possible action: To avoid duplicating the order, do not resend the request until you have reviewed the order status in the Business Center.
                       { %>
                       Some error occurred while processing the payment. Your card might have been charged. To avoid duplicating the payment, please contact support
                        <%}
                       else if (Request.Form.Get("reasonCode") == "250")//The request was received, but a time-out occurred with the payment processor. Possible action: To avoid duplicating the transaction, do not resend the request until you have reviewed the transaction status in the Business Center.
                       { %>
                       Some error occurred while processing the payment. Your card might have been charged. To avoid duplicating the payment, please contact support
                       <%} %>
                    </div>
                    <div style="padding-top:10px">
                        <asp:HyperLink ID="hlBack" runat="server">Back to Payment Details</asp:HyperLink></div>
                </div>
            </asp:Panel>
    </div>
</asp:Content>

