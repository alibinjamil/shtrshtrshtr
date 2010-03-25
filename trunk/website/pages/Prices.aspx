<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Prices.aspx.cs" Inherits="pages_Prices" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<div style="padding:0px;">
    <div>
        <div style="background-image: url(../images/Pricing_Eas_1.gif); float:left; width:314px; height:143px;"></div>
        <div style="background-image: url(../images/Pricing_Eas_3.gif); float:left; width:145px; height:143px;"></div>
        <div style="background-image: url(../images/Pricing_Eas_4.gif); float:left; width:154px; height:143px;"></div>        
        <div style="clear:both"></div>
    </div>
    <div>
        <div style="float:left; background-image: url(../images/Pricing_info_section.gif); height:551px; width:314px;">
            <!-- row -->
            <div style="color:#292F8D; padding-top:3px; padding-left:17px; padding-right: 10px; height:25px;">
                <div style="text-align:left;border-bottom:1px #D0D2D1 solid; vertical-align:center;">
                    &nbsp;&nbsp;testing 123
                </div>
            </div>
        </div>
        <div style="float:left; background-image: url(../images/Pricing_prf_enter_section.gif); height:551px; width:145px;">
            <!-- row -->
            <div style="color:#292F8D; padding-top:3px; padding-left:1px; padding-right: 10px; height:25px;">
                <div style="text-align:center;border-bottom:1px #D0D2D1 solid; vertical-align:center;">
                    &nbsp;<img src="../images/Ticks.gif" />
                </div>
            </div>
        </div>
        <div style="float:left; background-image: url(../images/Pricing_corporate_section.gif); height:551px; width:154px;">
            <!-- row -->
            <div style="color:#292F8D; padding-top:3px; padding-left:1px; padding-right: 20px; height:25px;">
                <div style="text-align:center;border-bottom:1px #D0D2D1 solid; vertical-align:center;">
                    &nbsp;<img src="../images/Ticks.gif" />
                </div>
            </div>        
        </div>        
        <div style="position:absolute; left:345px; padding-top:495px;width:145px;">
            <a href="" >
                <asp:Image ID="BuyNowEnterprise" runat="server" 
                    ImageUrl="~/images/Buy_Now.gif" AlternateText="Buy Now" 
                    onmouseover="this.src='../images/Buy_Now_rollover.gif'" 
                    onmouseout="this.src='../images/Buy_Now.gif'"/>
            </a>      
        </div>        
        <div style="position:absolute; left:490px; padding-top:495px;width:145px;">
            <a href="" >
                <asp:Image ID="BuyNowCorporate" runat="server" 
                    ImageUrl="~/images/Buy_Now.gif" AlternateText="Buy Now" 
                    onmouseover="this.src='../images/Buy_Now_rollover.gif'" 
                    onmouseout="this.src='../images/Buy_Now.gif'"/>
            </a>      
        </div>        
        <div style="clear:both"></div>
    </div>
</div>