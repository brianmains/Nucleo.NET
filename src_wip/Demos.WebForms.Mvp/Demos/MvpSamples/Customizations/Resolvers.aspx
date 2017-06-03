<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="Resolvers.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.Customizations.Resolvers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<div>
		This illustrates using a resolver.
	</div>

	<div>
		<asp:GridView ID="gvw" runat="server" />
	</div>

</asp:Content>
