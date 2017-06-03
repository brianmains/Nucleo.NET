<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ServerSideAPI.aspx.cs" Inherits="Nucleo.Web.Button.ServerSideAPI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:Button ID="btnControl" runat="server" Text="Initial Text" RenderingMode="ServerOnly">
		<ClientEvents OnClientClicked="btnControl_Clicked" />
	</n:Button>
	<br /><br />
	
	<strong>Server-Side Settings</strong><br />
	
	Enabled:
	<asp:CheckBox ID="chkEnabled" runat="server" Checked="true" />
	<br />

	Text:
	<asp:TextBox ID="txtText" runat="server" />
	<br />
	
	Validation Group:
	<asp:TextBox ID="txtValidationGroup" runat="server" />
	<br />

	Mode:
	<asp:DropDownList ID="ddlMode" runat="server">
		<asp:ListItem>Button</asp:ListItem>
		<asp:ListItem>Image</asp:ListItem>
		<asp:ListItem>Link</asp:ListItem>
	</asp:DropDownList>
	<br />
	
	Disable On First Click:
	<asp:CheckBox ID="chkDisableFirstClick" runat="server" />
	<br />
	
	Disable On First Click Timeout:
	<asp:TextBox ID="txtDisableFirstClickTimeout" runat="server" />
	<br />
	
	Disable Until Page Load:
	<asp:CheckBox ID="chkDisableUntilPageLoad" runat="server" />
	<br />
	
	Postback Url:
	<asp:TextBox ID="txtPostbackUrl" runat="server" />
	<br />
	
	Postback Always:
	<asp:CheckBox ID="chkPostbackAlways" runat="server" />
	<br />
	
	On Client Click JS Code:
	<asp:TextBox ID="txtOnClientClick" runat="server" />
	<br />
	
	Causes Validation:
	<asp:CheckBox ID="chkCausesValidation" runat="server" />
	<br />
	
	Command Name:
	<asp:TextBox ID="txtCommandName" runat="server" />
	<br />
	
	Command Argument:
	<asp:TextBox ID="txtCommandArgument" runat="server" />
	<br />
	
	Image Url:
	<asp:TextBox ID="txtImageUrl" runat="server" />
	<br />
	
	Image Alternate Text:
	<asp:TextBox ID="txtImageAlternateText" runat="server" />
	<br />
	
	<asp:Button ID="btnChangeServerSettings" runat="server" Text="Change Server Settings" />
	<br /><br />

	<asp:Label ID="lblOutput" runat="server" />

</asp:Content>
