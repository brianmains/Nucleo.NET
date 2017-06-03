<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ServerSideAPI.aspx.cs" Inherits="Nucleo.Web.ButtonList.ServerSideAPI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:ButtonList ID="blControl" runat="server" RenderingMode="ServerOnly">
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
	
	<strong>Server Side Settings</strong>
	<br />
	
	<asp:Button ID="btnToggleFirst" runat="server" Text="Toggle First Group" />
	<asp:Button ID="btnToggleSecond" runat="server" Text="Toggle Second Group" />
	<asp:Button ID="btnToggleThird" runat="server" Text="Toggle Third Group" />
	<br />
	
	Disable On First Click:
	<asp:DropDownList ID="ddlDisableOnFirstClick" runat="server">
		<asp:ListItem Value="">None</asp:ListItem>
		<asp:ListItem>True</asp:ListItem>
		<asp:ListItem>False</asp:ListItem>
	</asp:DropDownList>
	<br />
	
	Disable On First Click Timeout:
	<asp:TextBox ID="txtDisableOnFirstClickTimeout" runat="server" />
	<br />
	
	Disable Until Page Load
	<asp:DropDownList ID="ddlDisableUntilPageLoad" runat="server">
		<asp:ListItem Value="">None</asp:ListItem>
		<asp:ListItem>True</asp:ListItem>
		<asp:ListItem>False</asp:ListItem>
	</asp:DropDownList>
	<br />
	
	Orientation:
	<asp:DropDownList ID="ddlOrientation" runat="server">
		<asp:ListItem>Vertical</asp:ListItem>
		<asp:ListItem>Horizontal</asp:ListItem>
	</asp:DropDownList>
	<br />
	
	<asp:Button ID="btnChangeServerSettings" runat="server" Text="Change Server Settings" />
	
	<br /><br />

</asp:Content>
