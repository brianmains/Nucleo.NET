<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AjaxViewsFirstLook.aspx.cs" Inherits="Nucleo.Tests.Ajax.AjaxViewsFirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

	<div id="MessageContainer"></div>
	<n:Check ID="chk" runat="server" />
	<asp:Button ID="btn" runat="server" Text="Test" />
	<n:ButtonEnabledExtender ID="be" runat="server" TargetControlID="btn" ReceiverControlID="chk" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">

	<script type="text/javascript">
		function changed() {
			alert("Changed fired");
		}
	</script>

</asp:Content>
