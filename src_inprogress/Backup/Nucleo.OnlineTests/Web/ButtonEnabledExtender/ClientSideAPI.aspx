<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ClientSideAPI.aspx.cs" Inherits="Nucleo.Web.ButtonEnabledExtender.ClientSideAPI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<asp:TextBox ID="txtControl" runat="server" />
	<asp:Button ID="btnControl" runat="server" Text="Test Button" />
	<n:ButtonEnabledExtender ID="extControl" runat="server" TargetControlID="btnControl"
		ReceiverControlID="txtControl" />
	
	<br /><br />

	<strong>Client-Side Settings</strong>
	<br />
	
	Allow Postback:
	<asp:CheckBox ID="chkClientAllowPostback" runat="server" />
	<br />
	
	<asp:Button ID="btnChangeClientSettings" runat="server" Text="Change Client Settings"
		OnClientClick="changeClientSettings();return false;" />

	<asp:Button ID="btnToggleStatus" runat="server" Text="Toggle Status"
		OnClientClick="toggleStatus();return false;" />
	
	
	<script type="text/javascript">
		function changeClientSettings() {
			var control = $find("<%= extControl.ClientID %>");
			control.set_allowPostback($get("<%= chkClientAllowPostback.ClientID %>").checked);
		}

		function toggleStatus() {
			var control = $find("<%= extControl.ClientID %>");
			control.toggleStatus();
		}
	</script>

</asp:Content>
