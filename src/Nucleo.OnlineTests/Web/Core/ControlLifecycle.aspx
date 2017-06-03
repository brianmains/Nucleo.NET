<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="ControlLifecycle.aspx.cs" Inherits="Nucleo.Web.Core.ControlLifecycle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<div>
		<asp:TextBox ID="txtTestFormElement" runat="server" style="display:none" />

		<asp:Button ID="btnPostback" runat="server" Text="Postback" CausesValidation="false" />
		<asp:Button ID="btnPostbackWithValidation" runat="server" Text="Postback With Validation" CausesValidation="true" />
	</div>


	<asp:Label ID="lblEvents" runat="server" EnableViewState="false" />

</asp:Content>
