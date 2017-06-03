<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="Resizing.aspx.cs" Inherits="Nucleo.Web.Panel.Resizing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.ResizePanel
		{
			background-color:LightGray;
			color:Navy;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:Panel ID="pnlResizing" runat="server" CssClass="ResizePanel">
		<Resizing AutoCapHeight="true" MinHeight="100" MinWidth="100"
				  MaxHeight="500" MaxWidth="500" />
		<Content>
			<Template>
				This is my template for within the resize panel.
			</Template>
		</Content>
	</n:Panel>

</asp:Content>
