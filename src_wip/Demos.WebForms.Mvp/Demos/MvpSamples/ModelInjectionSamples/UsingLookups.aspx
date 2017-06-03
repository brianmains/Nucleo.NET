<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="UsingLookups.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.ModelInjectionSamples.UsingLookups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<h1>Countries</h1>

	<div>
		<asp:GridView ID="gvwCountries" runat="server" />
	</div>

	<h1>States</h1>

	<div>
		<asp:GridView ID="gvwStates" runat="server" />
	</div>

</asp:Content>
