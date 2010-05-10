<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemoMovie.aspx.cs" Inherits="pages_DemoMovie" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<div style="background-color:#292F8D;">
           
<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0" width="640" height="480" id="FlvPlayer" align="middle">
<param name="allowScriptAccess" value="sameDomain" />
<param name="allowFullScreen" value="true" />
<param name="movie" value="http://flvplayer.com/free-flv-player/FlvPlayer.swf" />
<param name="quality" value="high" />
<param name="bgcolor" value="292F8D" />
<param name="FlashVars" value="flvpFolderLocation=http://flvplayer.com/free-flv-player/flvplayer/&flvpVideoSource=<%=VideoURL%>&flvpWidth=640&flvpHeight=480&flvpInitVolume=50&flvpTurnOnCorners=true&flvpBgColor=292F8D"
<embed src="http://flvplayer.com/free-flv-player/FlvPlayer.swf" flashvars="flvpFolderLocation=http://flvplayer.com/free-flv-player/flvplayer/&flvpVideoSource=<%=VideoURL%>&flvpWidth=640&flvpHeight=480&flvpInitVolume=50&flvpTurnOnCorners=true&flvpBgColor=292F8D" quality="high" bgcolor="292F8D" width="640" height="480" name="FlvPlayer" align="middle" allowScriptAccess="sameDomain" allowFullScreen="true" type="application/x-shockwave-flash" pluginspage="http://www.adobe.com/go/getflashplayer" />
</object>
            
            
                        
</div>
