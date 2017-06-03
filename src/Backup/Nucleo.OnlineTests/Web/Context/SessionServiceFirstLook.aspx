<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="SessionServiceFirstLook.aspx.cs" Inherits="Nucleo.Web.Context.SessionServiceFirstLook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<asp:Button ID="btnLoadSession" runat="server" Text="Load Session"
		OnClick="btnLoadSession_Click" />
	<asp:Button ID="btnQuerySesson" runat="server" Text="Query Session"
		OnClick="btnQuerySesson_Click" />
	<br /><br />
	
	<asp:Label ID="lblSessionData" runat="server"></asp:Label>

</asp:Content>
