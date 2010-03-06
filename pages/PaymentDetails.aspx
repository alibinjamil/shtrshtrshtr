<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="PaymentDetails.aspx.cs" Inherits="pages_PaymentDetails" Title="Simplicity4Business" %>

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
				<div class="col1">Card Type</div>
				<div class="col2">
				<asp:DropDownList ID="lstCardType" runat="server">
				    <asp:ListItem Text="Visa" Value="001"></asp:ListItem>
				    <asp:ListItem Text="MasterCard" Value="002"></asp:ListItem>
				    <asp:ListItem Text="American Express" Value="003"></asp:ListItem>
				    <asp:ListItem Text="Discover" Value="004"></asp:ListItem>
				    <asp:ListItem Text="Diners Club" Value="005"></asp:ListItem>
				    <asp:ListItem Text="JCB" Value="007"></asp:ListItem>
				    <asp:ListItem Text="Maestro/Solo" Value="024"></asp:ListItem>
				</asp:DropDownList>
				</div>
				<div class="noFloat"></div>
			</div>		
			<div class="row">
				<div class="col1">Card Number</div>
				<div class="col2"><asp:TextBox ID="txtCardNumber" MaxLength="16" runat="server" Text="4111111111111111"></asp:TextBox>
				    <asp:RegularExpressionValidator ControlToValidate="txtCardNumber"
                            ID="RegularExpressionValidator1" runat="server" ErrorMessage="!" ValidationExpression="^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtCardNumber"></asp:RequiredFieldValidator>                        
                </div>
                        
				<div class="col3">Expiry Date</div>
				<div class="col4">
				    <asp:DropDownList id="txtExpiryMonth" runat="server">
				        <asp:ListItem Value="01">01</asp:ListItem>
				        <asp:ListItem Value="02">02</asp:ListItem>
				        <asp:ListItem Value="03">03</asp:ListItem>
				        <asp:ListItem Value="04">04</asp:ListItem>
				        <asp:ListItem Value="05">05</asp:ListItem>
				        <asp:ListItem Value="06">06</asp:ListItem>
				        <asp:ListItem Value="07">07</asp:ListItem>
				        <asp:ListItem Value="08">08</asp:ListItem>
				        <asp:ListItem Value="09">09</asp:ListItem>
				        <asp:ListItem Value="10">10</asp:ListItem>
				        <asp:ListItem Value="11">11</asp:ListItem>
				        <asp:ListItem Value="12">12</asp:ListItem>
				    </asp:DropDownList>
				    &nbsp;&nbsp;<asp:DropDownList id="txtExpiryYear" runat="server"></asp:DropDownList>		
				    
				</div>
			</div>
			<div class="row">
				<div class="col1">Security Code</div>
				<div class="col2">
				    <asp:TextBox ID="txtSecurityCode" Width="30px" MaxLength="3" runat="server" Text="111"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtSecurityCode"></asp:RequiredFieldValidator>				    
				</div>
				<div class="col3">Start Date</div>
				<div class="col4">
				    <asp:DropDownList id="txtStartMonth" runat="server">
				        <asp:ListItem Value="01">01</asp:ListItem>
				        <asp:ListItem Value="02">02</asp:ListItem>
				        <asp:ListItem Value="03">03</asp:ListItem>
				        <asp:ListItem Value="04">04</asp:ListItem>
				        <asp:ListItem Value="05">05</asp:ListItem>
				        <asp:ListItem Value="06">06</asp:ListItem>
				        <asp:ListItem Value="07">07</asp:ListItem>
				        <asp:ListItem Value="08">08</asp:ListItem>
				        <asp:ListItem Value="09">09</asp:ListItem>
				        <asp:ListItem Value="10">10</asp:ListItem>
				        <asp:ListItem Value="11">11</asp:ListItem>
				        <asp:ListItem Value="12">12</asp:ListItem>
				    </asp:DropDownList>				
				    &nbsp;&nbsp;<asp:DropDownList id="txtStartYear" runat="server"></asp:DropDownList>
				</div>
			</div>
			<div class="row">
				<div class="col1">First Name</div>
				<div class="col2">
				    <asp:TextBox ID="txtFirstName" MaxLength="30" runat="server" Text="Rashid"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>				    
				</div>
			</div>
			<div class="row">
				<div class="col1">Last Name</div>
				<div class="col2">
				    <asp:TextBox ID="txtLastName" MaxLength="30" runat="server" Text="Awan"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>				    
				</div>
			</div>
			<div class="row">
				<div class="col1">Telephone</div>
				<div class="col2">
				    <asp:TextBox ID="txtTelephone" MaxLength="20" runat="server" Text="111-111-1111"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="txtTelephone"></asp:RequiredFieldValidator>				    
				</div>
			</div>
			<div class="row" style="padding-top:15px;">
				<div class="col1">Card Billing Address</div>
			</div>
			<div class="row" style="padding-top:10px;">
				<div class="col1">Street & Number</div>
				<div class="col2">
				    <asp:TextBox ID="txtBillingStreet" MaxLength="100" Width="300px" runat="server" Text="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ControlToValidate="txtBillingStreet"></asp:RequiredFieldValidator>				    
				</div>
			</div>

			<div class="row">
				<div class="col1">Town</div>
				<div class="col2">
				    <asp:TextBox ID="txtBillingTown" MaxLength="30" runat="server" Text="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="txtBillingTown"></asp:RequiredFieldValidator>				    
				</div>
			</div>
			<div class="row">
				<div class="col1">County</div>
				<div class="col2">
				    <asp:TextBox ID="txtBillingCounty" MaxLength="30" runat="server" Text = "1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ControlToValidate="txtBillingCounty"></asp:RequiredFieldValidator>				    
				</div>
			</div>
			<div class="row">
				<div class="col1">Country</div>
				<div class="col2">
                    <asp:DropDownList id="txtBillingCountry" runat="server">
                        <asp:ListItem Value="AF">Afghanistan</asp:ListItem>
                        <asp:ListItem Value="AL">Albania</asp:ListItem>
                        <asp:ListItem Value="DZ">Algeria</asp:ListItem>
                        <asp:ListItem Value="AS">American Samoa</asp:ListItem>
                        <asp:ListItem Value="AD">Andorra</asp:ListItem>
                        <asp:ListItem Value="AO">Angola</asp:ListItem>
                        <asp:ListItem Value="AI">Anguilla</asp:ListItem>
                        <asp:ListItem Value="AQ">Antarctica</asp:ListItem>
                        <asp:ListItem Value="AG">Antigua And Barbuda</asp:ListItem>
                        <asp:ListItem Value="AR">Argentina</asp:ListItem>
                        <asp:ListItem Value="AM">Armenia</asp:ListItem>
                        <asp:ListItem Value="AW">Aruba</asp:ListItem>
                        <asp:ListItem Value="AU">Australia</asp:ListItem>
                        <asp:ListItem Value="AT">Austria</asp:ListItem>
                        <asp:ListItem Value="AZ">Azerbaijan</asp:ListItem>
                        <asp:ListItem Value="BS">Bahamas</asp:ListItem>
                        <asp:ListItem Value="BH">Bahrain</asp:ListItem>
                        <asp:ListItem Value="BD">Bangladesh</asp:ListItem>
                        <asp:ListItem Value="BB">Barbados</asp:ListItem>
                        <asp:ListItem Value="BY">Belarus</asp:ListItem>
                        <asp:ListItem Value="BE">Belgium</asp:ListItem>
                        <asp:ListItem Value="BZ">Belize</asp:ListItem>
                        <asp:ListItem Value="BJ">Benin</asp:ListItem>
                        <asp:ListItem Value="BM">Bermuda</asp:ListItem>
                        <asp:ListItem Value="BT">Bhutan</asp:ListItem>
                        <asp:ListItem Value="BO">Bolivia</asp:ListItem>
                        <asp:ListItem Value="BA">Bosnia And Herzegowina</asp:ListItem>
                        <asp:ListItem Value="BW">Botswana</asp:ListItem>
                        <asp:ListItem Value="BV">Bouvet Island</asp:ListItem>
                        <asp:ListItem Value="BR">Brazil</asp:ListItem>
                        <asp:ListItem Value="IO">British Indian Ocean Territory</asp:ListItem>
                        <asp:ListItem Value="BN">Brunei Darussalam</asp:ListItem>
                        <asp:ListItem Value="BG">Bulgaria</asp:ListItem>
                        <asp:ListItem Value="BF">Burkina Faso</asp:ListItem>
                        <asp:ListItem Value="BI">Burundi</asp:ListItem>
                        <asp:ListItem Value="KH">Cambodia</asp:ListItem>
                        <asp:ListItem Value="CM">Cameroon</asp:ListItem>
                        <asp:ListItem Value="CA">Canada</asp:ListItem>
                        <asp:ListItem Value="CV">Cape Verde</asp:ListItem>
                        <asp:ListItem Value="KY">Cayman Islands</asp:ListItem>
                        <asp:ListItem Value="CF">Central African Republic</asp:ListItem>
                        <asp:ListItem Value="TD">Chad</asp:ListItem>
                        <asp:ListItem Value="CL">Chile</asp:ListItem>
                        <asp:ListItem Value="CN">China</asp:ListItem>
                        <asp:ListItem Value="CX">Christmas Island</asp:ListItem>
                        <asp:ListItem Value="CC">Cocos (Keeling) Islands</asp:ListItem>
                        <asp:ListItem Value="CO">Colombia</asp:ListItem>
                        <asp:ListItem Value="KM">Comoros</asp:ListItem>
                        <asp:ListItem Value="CG">Congo</asp:ListItem>
                        <asp:ListItem Value="CK">Cook Islands</asp:ListItem>
                        <asp:ListItem Value="CR">Costa Rica</asp:ListItem>
                        <asp:ListItem Value="CI">Cote D'Ivoire</asp:ListItem>
                        <asp:ListItem Value="HR">Croatia (Local Name: Hrvatska)</asp:ListItem>
                        <asp:ListItem Value="CU">Cuba</asp:ListItem>
                        <asp:ListItem Value="CY">Cyprus</asp:ListItem>
                        <asp:ListItem Value="CZ">Czech Republic</asp:ListItem>
                        <asp:ListItem Value="DK">Denmark</asp:ListItem>
                        <asp:ListItem Value="DJ">Djibouti</asp:ListItem>
                        <asp:ListItem Value="DM">Dominica</asp:ListItem>
                        <asp:ListItem Value="DO">Dominican Republic</asp:ListItem>
                        <asp:ListItem Value="TP">East Timor</asp:ListItem>
                        <asp:ListItem Value="EC">Ecuador</asp:ListItem>
                        <asp:ListItem Value="EG">Egypt</asp:ListItem>
                        <asp:ListItem Value="SV">El Salvador</asp:ListItem>
                        <asp:ListItem Value="GQ">Equatorial Guinea</asp:ListItem>
                        <asp:ListItem Value="ER">Eritrea</asp:ListItem>
                        <asp:ListItem Value="EE">Estonia</asp:ListItem>
                        <asp:ListItem Value="ET">Ethiopia</asp:ListItem>
                        <asp:ListItem Value="FK">Falkland Islands (Malvinas)</asp:ListItem>
                        <asp:ListItem Value="FO">Faroe Islands</asp:ListItem>
                        <asp:ListItem Value="FJ">Fiji</asp:ListItem>
                        <asp:ListItem Value="FI">Finland</asp:ListItem>
                        <asp:ListItem Value="FR">France</asp:ListItem>
                        <asp:ListItem Value="GF">French Guiana</asp:ListItem>
                        <asp:ListItem Value="PF">French Polynesia</asp:ListItem>
                        <asp:ListItem Value="TF">French Southern Territories</asp:ListItem>
                        <asp:ListItem Value="GA">Gabon</asp:ListItem>
                        <asp:ListItem Value="GM">Gambia</asp:ListItem>
                        <asp:ListItem Value="GE">Georgia</asp:ListItem>
                        <asp:ListItem Value="DE">Germany</asp:ListItem>
                        <asp:ListItem Value="GH">Ghana</asp:ListItem>
                        <asp:ListItem Value="GI">Gibraltar</asp:ListItem>
                        <asp:ListItem Value="GR">Greece</asp:ListItem>
                        <asp:ListItem Value="GL">Greenland</asp:ListItem>
                        <asp:ListItem Value="GD">Grenada</asp:ListItem>
                        <asp:ListItem Value="GP">Guadeloupe</asp:ListItem>
                        <asp:ListItem Value="GU">Guam</asp:ListItem>
                        <asp:ListItem Value="GT">Guatemala</asp:ListItem>
                        <asp:ListItem Value="GN">Guinea</asp:ListItem>
                        <asp:ListItem Value="GW">Guinea-Bissau</asp:ListItem>
                        <asp:ListItem Value="GY">Guyana</asp:ListItem>
                        <asp:ListItem Value="HT">Haiti</asp:ListItem>
                        <asp:ListItem Value="HM">Heard And Mc Donald Islands</asp:ListItem>
                        <asp:ListItem Value="VA">Holy See (Vatican City State)</asp:ListItem>
                        <asp:ListItem Value="HN">Honduras</asp:ListItem>
                        <asp:ListItem Value="HK">Hong Kong</asp:ListItem>
                        <asp:ListItem Value="HU">Hungary</asp:ListItem>
                        <asp:ListItem Value="IS">Icel And</asp:ListItem>
                        <asp:ListItem Value="IN">India</asp:ListItem>
                        <asp:ListItem Value="ID">Indonesia</asp:ListItem>
                        <asp:ListItem Value="IR">Iran (Islamic Republic Of)</asp:ListItem>
                        <asp:ListItem Value="IQ">Iraq</asp:ListItem>
                        <asp:ListItem Value="IE">Ireland</asp:ListItem>
                        <asp:ListItem Value="IL">Israel</asp:ListItem>
                        <asp:ListItem Value="IT">Italy</asp:ListItem>
                        <asp:ListItem Value="JM">Jamaica</asp:ListItem>
                        <asp:ListItem Value="JP">Japan</asp:ListItem>
                        <asp:ListItem Value="JO">Jordan</asp:ListItem>
                        <asp:ListItem Value="KZ">Kazakhstan</asp:ListItem>
                        <asp:ListItem Value="KE">Kenya</asp:ListItem>
                        <asp:ListItem Value="KI">Kiribati</asp:ListItem>
                        <asp:ListItem Value="KP">Korea, Dem People'S Republic</asp:ListItem>
                        <asp:ListItem Value="KR">Korea, Republic Of</asp:ListItem>
                        <asp:ListItem Value="KW">Kuwait</asp:ListItem>
                        <asp:ListItem Value="KG">Kyrgyzstan</asp:ListItem>
                        <asp:ListItem Value="LA">Lao People'S Dem Republic</asp:ListItem>
                        <asp:ListItem Value="LV">Latvia</asp:ListItem>
                        <asp:ListItem Value="LB">Lebanon</asp:ListItem>
                        <asp:ListItem Value="LS">Lesotho</asp:ListItem>
                        <asp:ListItem Value="LR">Liberia</asp:ListItem>
                        <asp:ListItem Value="LY">Libyan Arab Jamahiriya</asp:ListItem>
                        <asp:ListItem Value="LI">Liechtenstein</asp:ListItem>
                        <asp:ListItem Value="LT">Lithuania</asp:ListItem>
                        <asp:ListItem Value="LU">Luxembourg</asp:ListItem>
                        <asp:ListItem Value="MO">Macau</asp:ListItem>
                        <asp:ListItem Value="MK">Macedonia</asp:ListItem>
                        <asp:ListItem Value="MG">Madagascar</asp:ListItem>
                        <asp:ListItem Value="MW">Malawi</asp:ListItem>
                        <asp:ListItem Value="MY">Malaysia</asp:ListItem>
                        <asp:ListItem Value="MV">Maldives</asp:ListItem>
                        <asp:ListItem Value="ML">Mali</asp:ListItem>
                        <asp:ListItem Value="MT">Malta</asp:ListItem>
                        <asp:ListItem Value="MH">Marshall Islands</asp:ListItem>
                        <asp:ListItem Value="MQ">Martinique</asp:ListItem>
                        <asp:ListItem Value="MR">Mauritania</asp:ListItem>
                        <asp:ListItem Value="MU">Mauritius</asp:ListItem>
                        <asp:ListItem Value="YT">Mayotte</asp:ListItem>
                        <asp:ListItem Value="MX">Mexico</asp:ListItem>
                        <asp:ListItem Value="FM">Micronesia, Federated States</asp:ListItem>
                        <asp:ListItem Value="MD">Moldova, Republic Of</asp:ListItem>
                        <asp:ListItem Value="MC">Monaco</asp:ListItem>
                        <asp:ListItem Value="MN">Mongolia</asp:ListItem>
                        <asp:ListItem Value="MS">Montserrat</asp:ListItem>
                        <asp:ListItem Value="MA">Morocco</asp:ListItem>
                        <asp:ListItem Value="MZ">Mozambique</asp:ListItem>
                        <asp:ListItem Value="MM">Myanmar</asp:ListItem>
                        <asp:ListItem Value="NA">Namibia</asp:ListItem>
                        <asp:ListItem Value="NR">Nauru</asp:ListItem>
                        <asp:ListItem Value="NP">Nepal</asp:ListItem>
                        <asp:ListItem Value="NL">Netherlands</asp:ListItem>
                        <asp:ListItem Value="AN">Netherlands Ant Illes</asp:ListItem>
                        <asp:ListItem Value="NC">New Caledonia</asp:ListItem>
                        <asp:ListItem Value="NZ" >New Zealand</asp:ListItem>
                        <asp:ListItem Value="NI">Nicaragua</asp:ListItem>
                        <asp:ListItem Value="NE">Niger</asp:ListItem>
                        <asp:ListItem Value="NG">Nigeria</asp:ListItem>
                        <asp:ListItem Value="NU">Niue</asp:ListItem>
                        <asp:ListItem Value="NF">Norfolk Island</asp:ListItem>
                        <asp:ListItem Value="MP">Northern Mariana Islands</asp:ListItem>
                        <asp:ListItem Value="NO">Norway</asp:ListItem>
                        <asp:ListItem Value="OM">Oman</asp:ListItem>
                        <asp:ListItem Value="PK">Pakistan</asp:ListItem>
                        <asp:ListItem Value="PW">Palau</asp:ListItem>
                        <asp:ListItem Value="PA">Panama</asp:ListItem>
                        <asp:ListItem Value="PG">Papua New Guinea</asp:ListItem>
                        <asp:ListItem Value="PY">Paraguay</asp:ListItem>
                        <asp:ListItem Value="PE">Peru</asp:ListItem>
                        <asp:ListItem Value="PH">Philippines</asp:ListItem>
                        <asp:ListItem Value="PN">Pitcairn</asp:ListItem>
                        <asp:ListItem Value="PL">Poland</asp:ListItem>
                        <asp:ListItem Value="PT">Portugal</asp:ListItem>
                        <asp:ListItem Value="PR">Puerto Rico</asp:ListItem>
                        <asp:ListItem Value="QA">Qatar</asp:ListItem>
                        <asp:ListItem Value="RE">Reunion</asp:ListItem>
                        <asp:ListItem Value="RO">Romania</asp:ListItem>
                        <asp:ListItem Value="RU">Russian Federation</asp:ListItem>
                        <asp:ListItem Value="RW">Rwanda</asp:ListItem>
                        <asp:ListItem Value="KN">Saint K Itts And Nevis</asp:ListItem>
                        <asp:ListItem Value="LC">Saint Lucia</asp:ListItem>
                        <asp:ListItem Value="VC">Saint Vincent, The Grenadines</asp:ListItem>
                        <asp:ListItem Value="WS">Samoa</asp:ListItem>
                        <asp:ListItem Value="SM">San Marino</asp:ListItem>
                        <asp:ListItem Value="ST">Sao Tome And Principe</asp:ListItem>
                        <asp:ListItem Value="SA">Saudi Arabia</asp:ListItem>
                        <asp:ListItem Value="SN">Senegal</asp:ListItem>
                        <asp:ListItem Value="SC">Seychelles</asp:ListItem>
                        <asp:ListItem Value="SL">Sierra Leone</asp:ListItem>
                        <asp:ListItem Value="SG">Singapore</asp:ListItem>
                        <asp:ListItem Value="SK">Slovakia (Slovak Republic)</asp:ListItem>
                        <asp:ListItem Value="SI">Slovenia</asp:ListItem>
                        <asp:ListItem Value="SB">Solomon Islands</asp:ListItem>
                        <asp:ListItem Value="SO">Somalia</asp:ListItem>
                        <asp:ListItem Value="ZA">South Africa</asp:ListItem>
                        <asp:ListItem Value="GS">South Georgia , S Sandwich Is.</asp:ListItem>
                        <asp:ListItem Value="ES">Spain</asp:ListItem>
                        <asp:ListItem Value="LK">Sri Lanka</asp:ListItem>
                        <asp:ListItem Value="SH">St. Helena</asp:ListItem>
                        <asp:ListItem Value="PM">St. Pierre And Miquelon</asp:ListItem>
                        <asp:ListItem Value="SD">Sudan</asp:ListItem>
                        <asp:ListItem Value="SR">Suriname</asp:ListItem>
                        <asp:ListItem Value="SJ">Svalbard, Jan Mayen Islands</asp:ListItem>
                        <asp:ListItem Value="SZ">Sw Aziland</asp:ListItem>
                        <asp:ListItem Value="SE">Sweden</asp:ListItem>
                        <asp:ListItem Value="CH">Switzerland</asp:ListItem>
                        <asp:ListItem Value="SY">Syrian Arab Republic</asp:ListItem>
                        <asp:ListItem Value="TW">Taiwan</asp:ListItem>
                        <asp:ListItem Value="TJ">Tajikistan</asp:ListItem>
                        <asp:ListItem Value="TZ">Tanzania, United Republic Of</asp:ListItem>
                        <asp:ListItem Value="TH">Thailand</asp:ListItem>
                        <asp:ListItem Value="TG">Togo</asp:ListItem>
                        <asp:ListItem Value="TK">Tokelau</asp:ListItem>
                        <asp:ListItem Value="TO">Tonga</asp:ListItem>
                        <asp:ListItem Value="TT">Trinidad And Tobago</asp:ListItem>
                        <asp:ListItem Value="TN">Tunisia</asp:ListItem>
                        <asp:ListItem Value="TR">Turkey</asp:ListItem>
                        <asp:ListItem Value="TM">Turkmenistan</asp:ListItem>
                        <asp:ListItem Value="TC">Turks And Caicos Islands</asp:ListItem>
                        <asp:ListItem Value="TV">Tuvalu</asp:ListItem>
                        <asp:ListItem Value="UG">Uganda</asp:ListItem>
                        <asp:ListItem Value="UA">Ukraine</asp:ListItem>
                        <asp:ListItem Value="AE">United Arab Emirates</asp:ListItem>
                        <asp:ListItem Value="GB" Selected="True">United Kingdom</asp:ListItem>
                        <asp:ListItem Value="US">United States</asp:ListItem>
                        <asp:ListItem Value="UM">United States Minor Is.</asp:ListItem>
                        <asp:ListItem Value="UY">Uruguay</asp:ListItem>
                        <asp:ListItem Value="UZ">Uzbekistan</asp:ListItem>
                        <asp:ListItem Value="VU">Vanuatu</asp:ListItem>
                        <asp:ListItem Value="VE">Venezuela</asp:ListItem>
                        <asp:ListItem Value="VN">Viet Nam</asp:ListItem>
                        <asp:ListItem Value="VG">Virgin Islands (British)</asp:ListItem>
                        <asp:ListItem Value="VI">Virgin Islands (U.S.)</asp:ListItem>
                        <asp:ListItem Value="WF">Wallis And Futuna Islands</asp:ListItem>
                        <asp:ListItem Value="EH">Western Sahara</asp:ListItem>
                        <asp:ListItem Value="YE">Yemen</asp:ListItem>
                        <asp:ListItem Value="YU">Yugoslavia</asp:ListItem>
                        <asp:ListItem Value="ZR">Zaire</asp:ListItem>
                        <asp:ListItem Value="ZM">Zambia</asp:ListItem>
                        <asp:ListItem Value="ZW">Zimbabwe</asp:ListItem>
                    </asp:DropDownList>				    
				</div>
			</div>
			<div class="row">
				<div class="col1">Postcode/Zip</div>
				<div class="col2">
				    <asp:TextBox ID="txtBillingZipCode" MaxLength="10" Width="75px" runat="server" Text="54000"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ControlToValidate="txtBillingZipCode"></asp:RequiredFieldValidator>				    
				</div>
			</div>
			<div class="noFloat"/>
		</div>

		<div class="noFloat" style="padding-top:15px;">
			<div class="floatRight">
			<asp:ImageButton ID="btnCheckout" runat="server" 
                    ImageUrl="~/images/Continue.gif" AlternateText="Continue" 
                    onmouseover="this.src='../images/Continue_rollover.gif'" 
                    onmouseout="this.src='../images/Continue.gif'" onclick="btnContinue_Click"/>				
			</div>
		</div>

		<div class="noFloat" style="padding-top:30px;">
			<img src="../images/paymentOptions.png"/>
		</div>
		<% insertSignature3(); %>
		
		<% insertSubscriptionSignature(); %>
		
</asp:Content>

