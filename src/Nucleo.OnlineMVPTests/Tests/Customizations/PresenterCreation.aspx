<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PresenterCreation.aspx.cs" Inherits="Nucleo.Tests.Customizations.PresenterCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
	
	<div>
		This illustrates using a custom presenter.
	</div>

	<div>
		<asp:GridView ID="gvw" runat="server" />
	</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
