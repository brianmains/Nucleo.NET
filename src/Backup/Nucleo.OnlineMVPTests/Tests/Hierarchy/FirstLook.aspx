<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Tests.Hierarchy.FirstLook" %>
<%@ Register src="Hierarchy1.ascx" tagname="Hierarchy1" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

	
	<h1>First Look</h1>

	<uc1:Hierarchy1 ID="Hierarchy11" runat="server" />

	

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
