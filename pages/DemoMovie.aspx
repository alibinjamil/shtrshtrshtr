<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemoMovie.aspx.cs" Inherits="pages_DemoMovie" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<div style="background-color:#292F8D;">
<object id="MediaPlayer" width=1024 height=760 classid="CLSID:22D6F312-B0F6-11D0-94AB-0080C74C7E95" standby="Loading Windows Media Player components..." type="application/x-oleobject"> 
<param name="filename" value="<%=VideoURL%>"> 
<param name="Showcontrols" value="True"> 
<param name="AutoStart" value="True"> 
<embed type="application/x-mplayer2" src="<%=VideoURL%>" width=1024 height=760></embed> 
</object> 
</div>
