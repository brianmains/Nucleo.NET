<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ServerSideAPI.aspx.cs" Inherits="Nucleo.Web.Check.ServerSideAPI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">
	<br /><br />
	
	<n:Check ID="chkControl" runat="server" Text="Click Me" RenderingMode="ServerOnly" AllowEmptyCheckState="false">
		<TrueImage ImageUrl="~/TestImages/check_yes.gif" DisabledImageUrl="~/TestImages/check_yes_disabled.gif" />
		<FalseImage ImageUrl="~/TestImages/check_no.gif" DisabledImageUrl="~/TestImages/check_no_disabled.gif" />
		<EmptyImage ImageUrl="~/TestImages/check_empty.gif" DisabledImageUrl="~/TestImages/check_empty_disabled.gif" />
	</n:Check>
	<br /><br />
	
	<strong>Server-Side Functions</strong>

	Checked:
	<asp:DropDownList ID="ddlChecked" runat="server">
		<asp:ListItem Value="True">Yes</asp:ListItem>
		<asp:ListItem Value="False">No</asp:ListItem>
		<asp:ListItem Value="">Empty</asp:ListItem>
	</asp:DropDownList>
	<br />
	
	Allow Empty Check State:
	<asp:DropDownList ID="ddlAllowEmptyCheckState" runat="server">
		<asp:ListItem Value="True">Yes</asp:ListItem>
		<asp:ListItem Value="False">No</asp:ListItem>
	</asp:DropDownList>
	<br />
	
	Enabled:
	<asp:DropDownList ID="ddlEnabled" runat="server">
		<asp:ListItem Value="True">Yes</asp:ListItem>
		<asp:ListItem Value="False">No</asp:ListItem>
	</asp:DropDownList>
	<br />
	
	Text:
	<asp:TextBox ID="txtText" runat="server"></asp:TextBox>
	<br />
	
	Text Format:
	<asp:TextBox ID="txtTextFormat" runat="server"></asp:TextBox>
	<br />
	
	<asp:Button ID="btnChange" runat="server" Text="Change Settings"
		OnClick="btnChange_Click" />
	
</asp:Content>
