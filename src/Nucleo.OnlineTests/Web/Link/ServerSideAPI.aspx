<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ServerSideAPI.aspx.cs" Inherits="Nucleo.Web.Link.ServerSideAPI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:Link ID="lnkControl" runat="server" Text="Initial Text" RenderingMode="ServerOnly" />
	<br /><br />
	
	<strong>Server-Side Options</strong>
	<br />
	
	Text:
	<asp:TextBox ID="txtText" runat="server" />
	<br />
	
	Text Format:
	<asp:TextBox ID="txtTextFormat" runat="server" />
	<br />
	
	Navigate Url:
	<asp:TextBox ID="txtNavigateUrl" runat="server" />
	<br />
	
	Navigate Url Format String:
	<asp:TextBox ID="txtNavigateUrlFormatSring" runat="server" />
	<br />
	
	Click Action:
	<asp:DropDownList ID="ddlClickAction" runat="server">
		<asp:ListItem>FireEvent</asp:ListItem>
		<asp:ListItem>Redirect</asp:ListItem>
	</asp:DropDownList>
	<br />
	
	Target:
	<asp:DropDownList ID="ddlTarget" runat="server">
		<asp:ListItem>NewWindow</asp:ListItem>
		<asp:ListItem>SameWindow</asp:ListItem>
	</asp:DropDownList>
	<br />
	
	<asp:Button ID="btnChangeServerSettings" runat="server" Text="Change Settings"
		OnClick="btnChangeServerSettings_Click" />
	<br /><br />
	
	
	<asp:Label ID="lblOutput" runat="server"></asp:Label>
	
</asp:Content>
