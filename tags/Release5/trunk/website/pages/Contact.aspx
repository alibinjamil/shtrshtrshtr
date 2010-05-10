<%@ Page Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="pages_Contact" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HomeContent" Runat="Server">
				<div class="content" > 
				    <div>
				        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Sales_hotline.gif"/>
				    </div>
				    <div style="margin-top:10px;margin-left:35px;">
				        <b>T.&nbsp;+4420&nbsp;7272&nbsp;8127</b>
				    </div>
				    <div style="margin-left:35px;">
				        <b>E.&nbsp;sales@simplicity4business.com</b>
				    </div>
				    <div style="margin-top:10px;">
				        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Training.gif"/>
				    </div>
				    <%-- <div style="margin-top:10px;margin-left:35px;">
				        T.&nbsp;+4420&nbsp;7272&nbsp;8127
				    </div> --%>
				    <div style="margin-top:10px;margin-left:35px;">
				        <b>E.&nbsp;training@simplicity4business.com</b>
				    </div>
                    <div style="margin-left:35px;font-size:8pt;color:#243482;padding-right:40px;">
                        <p>We do not accept training or support calls on any other number. Calling on this number from BT line is charged at &pound;1.50 per minute for a maximum of 20 minutes.
                        <br />Charges from other service providers and mobile phones may vary.</p>
                    </div>
                    <div style="margin-top:10px;">
                        <div class="floatLeft" >
                            <div >
				                <asp:Image ID="Image3" runat="server" ImageUrl="~/images/Head_office.gif"/>
				            </div>
				            <div style="margin-left:35px;">
				            <b><p>Simplicity4Business<br />2a Grenville Road <br />London <br />N19 4EH <br /><br />
				                E. info@simplicity4business.com T. +4420 7272 8127 F. +4420 7281 7239
				            </p></b>
				            </div>
                        </div>
                        <div class="floatRight" style="margin-right:40px;">                        
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/images/Call_man.gif"/>
                        </div>
                        <div style="clear:both"></div>
                    </div>
                    
				</div>

</asp:Content>

