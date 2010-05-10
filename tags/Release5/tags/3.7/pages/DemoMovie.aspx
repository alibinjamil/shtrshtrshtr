<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemoMovie.aspx.cs" Inherits="pages_DemoMovie" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<div style="background-color:#292F8D;">
<script type="text/javascript" src="http://flvplayer.com/free-flv-player/flvplayer/swfobject/swfobject.js"></script>
<div id="embed_player">
<h1>Please Upgrade Your Flash Player</h1>
<p><a href="http://www.adobe.com/go/getflashplayer"><img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif" alt="Get Adobe Flash player" /></a></p>
</div>
<script type="text/javascript">
var flashvars = {
flvpFolderLocation: "http://flvplayer.com/free-flv-player/flvplayer/", 
flvpVideoSource: "<%=VideoURL%>", 
flvpWidth: "640", 
flvpHeight: "480", 
flvpInitVolume: "50", 
flvpTurnOnCorners: "true", 
flvpBgColor: "292F8D"
};
var params = {
bgcolor: "292F8D", 
menu: "true", 
allowfullscreen: "true"
};
swfobject.embedSWF("http://flvplayer.com/free-flv-player/FlvPlayer.swf", "embed_player", "640", "480", "9.0.0", "http://flvplayer.com/free-flv-player/flvplayer/swfobject/expressInstall.swf", flashvars, params);
</script>
            
            
</div>
