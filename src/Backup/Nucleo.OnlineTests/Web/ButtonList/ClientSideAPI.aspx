<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ClientSideAPI.aspx.cs" Inherits="Nucleo.Web.ButtonList.ClientSideAPI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:ButtonList ID="blControl" runat="server" RenderingMode="ClientOnly">
		<Buttons>
			<n:Button ID="Button1" runat="server" Text="Btn1" VisibilityGroup="First" />
			<n:Button ID="Button2" runat="server" Text="Btn2" VisibilityGroup="Second" />
			<n:Button ID="Button3" runat="server" Text="Btn3" VisibilityGroup="Third" />
			<n:Button ID="Button4" runat="server" Text="Btn1" VisibilityGroup="First" />
			<n:Button ID="Button5" runat="server" Text="Btn2" VisibilityGroup="Second" />
			<n:Button ID="Button6" runat="server" Text="Btn3" VisibilityGroup="Third" />
			<n:Button ID="Button7" runat="server" Text="Btn1" VisibilityGroup="First" />
			<n:Button ID="Button8" runat="server" Text="Btn2" VisibilityGroup="Second" />
			<n:Button ID="Button9" runat="server" Text="Btn3" VisibilityGroup="Third" />
		</Buttons>
	</n:ButtonList>
	<br /><br />
	
	<strong>Client-Side Settings</strong>
	<br />
	
	<asp:Button ID="btnClientToggleFirstVisibility" runat="server" Text="Toggle First Visibility Group"
		OnClientClick="toggleVisibility('First');return false;" />
	<asp:Button ID="btnClientToggleSecondVisibility" runat="server" Text="Toggle Second Visibility Group"
		OnClientClick="toggleVisibility('Second');return false;" />
	<asp:Button ID="btnClientToggleThirdVisibility" runat="server" Text="Toggle Third Visibility Group"
		OnClientClick="toggleVisibility('Third');return false;" />
	<br />
	
	<asp:Button ID="btnClientSetFirstVisible" runat="server" Text="Set First Group Visible"
		OnClientClick="changeVisibility('First', true);return false;" />
	<asp:Button ID="btnClientSetSecondVisible" runat="server" Text="Set Second Group Visible"
		OnClientClick="changeVisibility('Second', true);return false;" />
	<asp:Button ID="btnClientSetThirdVisible" runat="server" Text="Set Third Group Visible"
		OnClientClick="changeVisibility('Third', true);return false;" />
	<br />
	
	<asp:Button ID="btnClientSetFirstInvisible" runat="server" Text="Set First Group Invisible"
		OnClientClick="changeVisibility('First', false);return false;" />
	<asp:Button ID="btnClientSetSecondInvisible" runat="server" Text="Set Second Group Invisible"
		OnClientClick="changeVisibility('Second', false);return false;" />
	<asp:Button ID="btnClientSetThirdInvisible" runat="server" Text="Set Third Group Invisible"
		OnClientClick="changeVisibility('Third', false);return false;" />
	<br />
		
	<script type="text/javascript">
		var control = null;

		function pageLoad() {
			control = $find("<%= blControl.ClientID %>");
		}
		
		function changeVisibility(group, visible) {
			control.changeVisibility(group, visible);
		}
	
		function toggleVisibility(group) {
			control.toggleVisibility(group);
		}
	</script>
</asp:Content>