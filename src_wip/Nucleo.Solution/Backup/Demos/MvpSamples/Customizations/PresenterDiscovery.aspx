<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="PresenterDiscovery.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.Customizations.PresenterDiscovery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<div>
		This illustrates finding the PresenterDiscoveryPresenter.
	</div>

	<div>
		<asp:GridView ID="gvw" runat="server" />
	</div>

</asp:Content>
