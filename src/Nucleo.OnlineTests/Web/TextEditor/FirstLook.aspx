<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Web.TextEditor.FirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:TextEditor ID="txtEditor" runat="server" OnTextChanged="txtEditor_TextChanged" />
	<asp:Button ID="btnPostback" runat="server" Text="Postback" />

	<br /><br />
	
	<h1>Server Settings</h1>
	
	<div>
		Error State: <asp:CheckBox ID="chkIsInErrorState" runat="server" />
	</div>
	
	<asp:Button ID="btnChangeSettings" runat="server" Text="Change Settings"
		OnClick="btnChangeSettings_Click" />
	
	<h1>Client Settings</h1>
	
	<div>
		Error State: <asp:CheckBox ID="chkClientIsInErrorState" runat="server" />
	</div>
	
	<input type="button" value="Change Client Settings" onclick="changeSettings();" />
	
	<script type="text/javascript">
		function changeSettings() {
			var editor = $find("<%= txtEditor.ClientID %>");
			editor.set_currentState($get("<%= chkClientIsInErrorState.ClientID %>").checked
				? Nucleo.Web.EditorControls.EditorCurrentState.Error
				: Nucleo.Web.EditorControls.EditorCurrentState.Normal);
		}
	</script>

</asp:Content>
