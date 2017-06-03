<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ClientSideAPI.aspx.cs" Inherits="Nucleo.Web.Button.ClientSideAPI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:Button ID="btnControl" runat="server" Text="Initial Text" RenderingMode="ClientOnly">
		<ClientEvents OnClientClicked="btnControl_Clicked" />
	</n:Button>
	<br /><br />
	
	<strong>Client-Side Settings</strong>
	
	<br />

	Enabled:
	<asp:CheckBox ID="chkClientEnabled" runat="server" Checked="true" />
	<br />

	Text:
	<asp:TextBox ID="txtClientText" runat="server" Text="Initial Text" />
	<br />
	
	Disable On First Click:
	<asp:CheckBox ID="chkClientDisableFirstClick" runat="server" />
	<br />
	
	Disable On First Click Timeout:
	<asp:TextBox ID="txtClientDisableFirstClickTimeout" runat="server" />
	<br />
	
	Postback Always:
	<asp:CheckBox ID="chkClientPostbackAlways" runat="server" />
	<br />
	
	Command Name:
	<asp:TextBox ID="txtClientCommandName" runat="server" />
	<br />
	
	Command Argument:
	<asp:TextBox ID="txtClientCommandArgument" runat="server" />
	<br />
	
	Image Url:
	<asp:TextBox ID="txtClientImageUrl" runat="server" />
	<br />
	
	Image Alternate Text:
	<asp:TextBox ID="txtClientImageAlternateText" runat="server" />
	<br />
	
	<asp:Button ID="btnChangeClientSettings" runat="server" Text="Change Client Settings"
		OnClientClick="changeClientSettings();return false;" UseSubmitBehavior="false" />
	<br /><br />

	<asp:Label ID="lblOutput" runat="server" />

	<script type="text/javascript">
		var label = null;
	
		function pageLoad() {
			label = $get("<%= lblOutput.ClientID %>");
		}
	
		function changeClientSettings() {
			var control = $find("<%= btnControl.ClientID %>");
			var label = $get("<%= lblOutput.ClientID %>");

			control.set_text($get("<%= txtClientText.ClientID %>").value);
			control.set_enabled($get("<%= chkClientEnabled.ClientID %>").checked);
			control.set_disableOnFirstClick($get("<%= chkClientDisableFirstClick.ClientID %>").checked);
			control.set_disableOnFirstClickTimeout(Number.parseInvariant($get("<%= txtClientDisableFirstClickTimeout.ClientID %>").value));
			control.set_postBackAlways($get("<%= chkClientPostbackAlways.ClientID %>").checked);
			control.set_commandName($get("<%= txtClientCommandName.ClientID %>").value);
			control.set_commandArgument($get("<%= txtClientCommandArgument.ClientID %>").value);
			control.set_imageUrl($get("<%= txtClientImageUrl.ClientID %>").value);
			control.set_imageAlternateText($get("<%= txtClientImageAlternateText.ClientID %>").value);

			control.refresh();
		}

		function btnControl_Clicked(sender, e) {
			n$.Debug.write("Button clicked on the client.");
		}
	</script>

</asp:Content>
