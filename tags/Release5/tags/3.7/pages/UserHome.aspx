<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="pages_UserHome" Title="Simplicity4Business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
		<div class="homePage">
			<div class='homePageContent'>
				<div class="floatLeft" > 
					<object classid="clsid:D697CDE7E-AE6D-11cf-96B8-458453540000"
                            codebase="http://active.macromedia.com/flash4/cabs/swflash.cab#version=4,0,0,0"
                            id="animation name" width="468" height="60">
                        <param name="movie" value="../images/Movie_flash_page.swf"/>
                        <param name="quality" value="high"/>
                        <param name="bgcolor" value="#FFFFFF"/>
                        <embed name="Simplicity" src="../images/Movie_flash_page.swf" quality="high" bgcolor="#FFFFFF"
                            width="750px" height="340px" type="application/x-shockwave-flash"
                            pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash">
                        </embed>
                    </object>
				</div>
				<div class="floatRight" style="padding-right:30px;">
					<div style="padding-top:30px;">
						<a href="ViewDemo.aspx"><img class="button" src="../images/Watch.gif" onmouseover="this.src='../images/Watch_rollover.gif'" onmouseout="this.src='../images/Watch.gif'"></a>
					</div>					
					<div style="padding-top:10px;">
						<a href="Products.aspx"><img class="button" src="../images/Buy.gif" onmouseover="this.src='../images/Buy_rollover.gif'" onmouseout="this.src='../images/Buy.gif'"></a>
					</div>					
					<div style="padding-top:10px;">
						<a href="CallMePage.aspx"><img class="button" src="../images/Call.gif" onmouseover="this.src='../images/Call_rollover.gif'" onmouseout="this.src='../images/Call.gif'"></a>
					</div>					
				</div>			
			</div>
			<div class="noFloat"/>
			<div class="homePageButtons">
				<a href="#"><img class="button" src="../images/Sales.gif" onmouseover="this.src='../images/Sales_rollover.gif'" onmouseout="this.src='../images/Sales.gif'"></a>
				<a href="#"><img class="button" src="../images/Operations.gif" onmouseover="this.src='../images/Operations_rollover.gif'" onmouseout="this.src='../images/Operations.gif'"></a>
				<a href="#"><img class="button" src="../images/Health.gif" onmouseover="this.src='../images/Health_rollover.gif'" onmouseout="this.src='../images/Health.gif'"></a>
				<a href="#"><img class="button" src="../images/Resource.gif" onmouseover="this.src='../images/Resource_rollover.gif'" onmouseout="this.src='../images/Resource.gif'"></a>
				<a href="#"><img class="button" src="../images/Finance.gif" onmouseover="this.src='../images/Finance_rollover.gif'" onmouseout="this.src='../images/Finance.gif'"></a>
				<a href="#"><img class="button" src="../images/Mobile.gif" onmouseover="this.src='../images/Mobile_rollover.gif'" onmouseout="this.src='../images/Mobile.gif'"></a>
			</div>
			<div class="noFloat"/>
		</div>
	</asp:Content>

