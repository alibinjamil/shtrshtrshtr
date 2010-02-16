<%@ Page Language="C#" MasterPageFile="~/Simplicity.master" AutoEventWireup="true" CodeFile="WatchDemo.aspx.cs" Inherits="pages_WatchDemo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../css/jquery/jquery-ui-1.7.2.custom.css" />
    <script type="text/javascript" src="../js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui-1.7.2.custom.min.js"></script>
    <script type="text/javascript">
    function loadMovie(str)
    {
        $('#demoDialog').load('DemoMovie.aspx');   
        jQuery("#demoDialog").dialog('open');        
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="heading">Watch a Demo</div>
    <br />
    <br />
        <h3>Please select a demo from below to watch</h3>
        <h3>Simplicity H&amp;S Live</h3>
        <h3>1. H&amp;S Live Demo</h3><a href="#" onclick="loadMovie('123'); return false">Watch Demo</a>

<div id="demoDialog" title="Demo"></div>

<script type="text/javascript">
  jQuery(document).ready(function() {
    jQuery("#demoDialog").dialog({
      bgiframe: true, autoOpen: false, height: 635, width:845, modal: true
    });
  });
</script>

	        

</asp:Content>

