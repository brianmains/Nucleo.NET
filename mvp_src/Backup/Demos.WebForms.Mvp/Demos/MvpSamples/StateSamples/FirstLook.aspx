<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.StateSamples.FirstLook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<h1>Current State Output</h1>
	<div>
		<asp:Label ID="lblCurrentStateOutput" runat="server" />
	</div>

</asp:Content>
