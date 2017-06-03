<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="SampleWebControlFirstLook.aspx.cs" Inherits="Nucleo.Web.CustomComponents.SampleWebControlFirstLook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">
	
	<n:SampleWebControl ID="sc1" runat="server" AlertMessage="This is my alert"
		Text="This is my text" />
	
	<input type="button" onclick="changeSettings();" value="Change" />
	
	<script type="text/javascript" language="javascript">
		function changeSettings() {
			var comp = $find("<%= sc1.ClientID %>");
			comp.set_alertMessage("This is my new message for the alert");
			comp.set_text("New Text");
		}
	</script>
	
</asp:Content>
