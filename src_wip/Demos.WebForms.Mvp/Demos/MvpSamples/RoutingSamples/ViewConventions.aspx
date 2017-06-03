<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/DemoLayout.Master" AutoEventWireup="true" CodeBehind="ViewConventions.aspx.cs" Inherits="Nucleo.Demos.MvpSamples.RoutingSamples.ViewConventions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<asp:Button ID="btn" runat="server" Text="Redirect to Routing Target"
		OnClick="btn_Click" />

</asp:Content>
