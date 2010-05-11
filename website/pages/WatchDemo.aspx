<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="WatchDemo.aspx.cs" Inherits="pages_WatchDemo" Title="Simplicity4Business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../css/jquery/jquery-ui-1.7.2.custom.css" />
    <script type="text/javascript" src="../js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui-1.7.2.custom.min.js"></script>
    <script type="text/javascript">
	    function open_train(tar){
		    //window.open('DemoMovie.aspx?videoId=' + tar, "Simplicity4Business", "width=820,height=620,location=no,toolbar=no,scrollbars=yes,status=no,resizable=1");
		    $('#demoDialog').load('DemoMovie.aspx?videoId='+tar);   
            jQuery("#demoDialog").dialog('open');      
	    }
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageHead" runat="server" ID="conten4">
    <h2>Watch a demo</h2>
    <div id="demoDialog" title="Demo"></div>    
    <script type="text/javascript">
      jQuery(document).ready(function() {
        jQuery("#demoDialog").dialog({
          bgiframe: true, autoOpen: false, height: 550, width:700, modal: true,
          close: function(ev, ui) {
             $('#demoDialog').load('Oops.aspx');
        }
        });
      });
    </script>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
		<div class="watchDemo">
			<div class='watchDemoContent'>
				<div class="content" > 
				    <div>
				        <asp:Label runat="server" ID="lblContent" Text="Select the product of your choice from the buttons below to view related videos"></asp:Label> 
				    </div>
				    <div class="heading">
				        <asp:Label runat="server" ID="lblProdName" Text="test" Visible="false"></asp:Label> 
				    </div>	
				    <br />
				    <div>			       				     
				    <asp:Repeater ID="rptVideos" runat="server">
				        <HeaderTemplate><ol>
				        </HeaderTemplate>
                        <ItemTemplate><li><a href='<%#GetURL(DataBinder.Eval(Container.DataItem, "video_id"))%>'><%#DataBinder.Eval(Container.DataItem, "text")%></a></li>
                        </ItemTemplate>
                        <FooterTemplate></ol>
                        </FooterTemplate>
                    </asp:Repeater>
                    </div>
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
			<div class="watchDemoButtons">
                <asp:Repeater ID="rptProds" runat="server">
                    <ItemTemplate>
                    <a href='WatchDemo.aspx?productId=<%#DataBinder.Eval(Container.DataItem, "ProductId")%>' style="margin-left:10px;">
                        <asp:Image ID="Image2" runat="server" ImageUrl='<%#"~/images/watch_" + DataBinder.Eval(Container.DataItem, "ShortName") + ".gif"%>'
                        onmouseover='<%#GetMouseOver(DataBinder.Eval(Container.DataItem, "ShortName"))%>' onmouseout='<%#GetMouseOut(DataBinder.Eval(Container.DataItem, "ShortName"))%>'/>
                    </a>
                    </ItemTemplate>
                </asp:Repeater>				
				<a href="#"><img class="button" src="../images/Watch_Client_login.gif" onmouseover="this.src='../images/Watch_Client_login_rollover.gif'" onmouseout="this.src='../images/Watch_Client_login.gif'"></a>
			</div>
			<div class="noFloat"/>
		</div>
   

</asp:Content>

