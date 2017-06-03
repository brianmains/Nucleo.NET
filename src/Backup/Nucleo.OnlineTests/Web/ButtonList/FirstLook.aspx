<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Web.ButtonList.FirstLook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<h1 class="TestHeader">Creating a Simple Button List</h1>
	This example creates a sample button list.

	<n:ButtonList ID="blSimpleButtonList" runat="server">
		<Buttons>
			<n:Button ID="Button1" runat="server" Text="B1" />
			<n:Button ID="Button2" runat="server" Text="B2" />
			<n:Button ID="Button3" runat="server" Text="B3" />
		</Buttons>
	</n:ButtonList>
	
	<h1 class="TestHeader">Overriding Properties</h1>
	This test should override the default values set.
	
	<n:ButtonList ID="blOverridingProperties" runat="server" DisableOnFirstClick="True" DisableOnFirstClickTimeout="3000"
		DisableUntilPageLoad="true">
		<Buttons>
			<n:Button ID="Button4" runat="server" Text="B4" DisableOnFirstClick="false" DisableUntilPageLoad="false" />
			<n:Button ID="Button5" runat="server" Text="B5" DisableOnFirstClick="false" DisableUntilPageLoad="false" />
			<n:Button ID="Button6" runat="server" Text="B6" DisableOnFirstClick="false" DisableUntilPageLoad="false" />
		</Buttons>
	</n:ButtonList>
	
	<h1 class="TestHeader">Visibility Groups</h1>
	By clicking the buttons below toggles the various visibility groups.
	
	<n:ButtonList ID="blVisibility" runat="server">
		<Buttons>
			<n:Button ID="Button7" runat="server" Text="B7" VisibilityGroup="First" />
			<n:Button ID="Button8" runat="server" Text="B8" VisibilityGroup="First" />
			<n:Button ID="Button9" runat="server" Text="B9" VisibilityGroup="First" />
			<n:Button ID="Button10" runat="server" Text="B10" VisibilityGroup="Second" />
			<n:Button ID="Button11" runat="server" Text="B11" VisibilityGroup="Second" />
			<n:Button ID="Button12" runat="server" Text="B12" VisibilityGroup="Second" />
		</Buttons>
	</n:ButtonList>
	
	<br /><br />
	<input type="button" onclick="firstGroupToggle(true);" value="First Group Visible" />
	<input type="button" onclick="firstGroupToggle(false);" value="First Group Invisible" />
	<input type="button" onclick="secondGroupToggle();" value="Second Group Toggle" />

	<script type="text/javascript" language="javascript">
		function firstGroupToggle(visible) {
			var list = $find("<%= blVisibility.ClientID %>");
			list.changeVisibility("First", visible);
		}

		function secondGroupToggle() {
			var list = $find("<%= blVisibility.ClientID %>");
			list.toggleVisibility("Second");
		}
	</script>

</asp:Content>
