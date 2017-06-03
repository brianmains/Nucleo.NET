<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewInitialization.aspx.cs" Inherits="Nucleo.Tests.Customizations.ViewInitialization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

	<div>
		This process illustrates using a view initializer to initialize the view by setting a property on the view to
		a specific value.
	</div>

	<div>
		Output: <asp:Label ID="lbl" runat="server" />
	</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
