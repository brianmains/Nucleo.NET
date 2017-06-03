<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Demos.WebForms._Default" %>

<html>
<head>
	
</head>
<body>
	
	<div>
		
		<div class="HomeTopBar">
			
			<div style="float:left;">
				Nucleo.NET
			</div>
			<div style="float:left;">
				Nucleo.NET is a set of common components for web forms and MVC.  It is also
				and MVP framework for web forms, Razor Web Pages, and a preliminary Silverlight
				framework.
			</div>
			<div style="clear:both;"></div>

		</div>

		<div class="HomeLinksBar">
			
			<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Demos/Samples/Home.aspx">
				Samples
			</asp:HyperLink>
			<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Demos/Scenarios/Home.aspx">
				Scenarios
			</asp:HyperLink>

		</div>

		<div class="HomeFooterBar">
					
		</div>

	</div>

</body>
</html>