<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="Modal.aspx.cs" Inherits="Nucleo.Web.Panel.Modal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:Panel ID="pnlModal" runat="server">
		<Modal />
		<Content>
			<Template>
				This is the content of the modal panel.

				<br /><br />

				<asp:Button ID="btnPostback" runat="server" Text="Submit" />
				<a href="javascript:postback();">Postback</a>
			</Template>
		</Content>
	</n:Panel>

	<div>
		<a href="javascript:open();">Open</a>
		<a href="javascript:close();">Close</a>

		
	</div>

	<script type="text/javascript">
		function open() {
			var panel = $find("<%= pnlModal.ClientID %>");
			panel.get_modal().open();
		}

		function close() {
			var panel = $find("<%= pnlModal.ClientID %>");
			panel.get_modal().close();
		}
	</script>

</asp:Content>
