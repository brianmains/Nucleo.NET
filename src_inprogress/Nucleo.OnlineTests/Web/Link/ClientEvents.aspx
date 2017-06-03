<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ClientEvents.aspx.cs" Inherits="Nucleo.Web.Link.ClientEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:Link ID="lnkControl" runat="server" Text="Initial Text" RenderingMode="ClientOnly">
		<ClientEvents OnClientClicked="lnkControl_Clicked" />
	</n:Link>

	<script type="text/javascript">
		function lnkControl_Clicked(sender, e) {
			n$.Debug.write("Link control clicked.");
		}
	</script>

</asp:Content>
