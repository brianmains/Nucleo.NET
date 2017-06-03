<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="ViewInitialization.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.Customizations.ViewInitialization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<div>
		This process illustrates using a view initializer to initialize the view by setting a property on the view to
		a specific value.
	</div>

	<div>
		Output: <asp:Label ID="lbl" runat="server" />
	</div>

</asp:Content>
