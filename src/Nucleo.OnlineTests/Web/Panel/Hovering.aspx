<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="Hovering.aspx.cs" Inherits="Nucleo.Web.Panel.Hovering" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<asp:TextBox ID="txtControl" runat="server" />
	
	<br />
	<br />
	<br />
	<br />

	<n:Panel ID="pHover" runat="server">
		<Hovering RelocatePanel="true" RelocatePosition="BottomLeft" ControlID="txtControl" />
		<Content>
			<Template>
				This is my client content.
			</Template>
		</Content>
	</n:Panel>

</asp:Content>
